//Filename: FileHelper.cs
//
//Description:
//Executes the file operations needed to support the update functionality
//
//Creator: v-ragene
//Creation Date: 5/22/2007 5:08:05 PM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/22/07     v-ragene         Initial Version.
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Globalization;
using System.EnterpriseServices.Internal;
using System.Diagnostics;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Contains utility functions to handle file system operations
    /// </summary>
    public static class FileHelper
    {
        #region Private Variables
        private static ConfigurationManager _configManager;
        private const string COMADDINSETTINGNAME = "COMAddin";
        private const string GACASSEMBLIESSETTINGNAME = "GACAssemblies";
        private const string REGSVR32ASSEMBLIESSETTINGNAME = "Regsvr32Assemblies";
        private const string ERRORINORIGINLOCATION = "Could not found origin location: ";
        private const string REGSVR32 = "Regsvr32.exe";
        private const string REGSVR32PARAMSINSTALL = "/s {0}";
        private const string REGSVR32PARAMSUNINSTALL = "/s /u {0}";

        #region Logger
        private const string LOGDELETINGFILE = "Deleting file: ";
        private const string LOGDELETINGFOLDER = "Deleting folder: ";
        private const string LOGCOPIEDCOM = "Copied and registered as COM. From ";
        private const string LOGCOPIEDGAC = "Copied and registered in the GAC. From ";
        private const string LOGCOPIEDREGSVR32 = "Copied and registered with Regsvr32. From ";
        private const string LOGTO = " to ";
        private const string LOGCOPIED = "Copied from ";
        private const string LOGREGISTERINGCOM = "Registering COM Addin: ";
        #endregion

        #endregion

        #region Constructors

        #endregion

        #region Public Methods
        /// <summary>
        /// Deletes the files from a list provided
        /// </summary>
        /// <param name="paths">List of paths to the files to be deleted</param>
        /// <returns></returns>
        public static bool Delete(Collection<string> paths)
        {
            foreach (string path in paths)
            {
                if (File.Exists(path))
                {
                    Logger.Instance.Info(LOGDELETINGFILE + path);
                    File.Delete(path);
                }
                else if (Directory.Exists(path))
                {
                    Logger.Instance.Info(LOGDELETINGFOLDER + path);
                    Directory.Delete(path, true);
                }
                //If the file or directory is not found we don't throw an exception because it might be the case
                //that the file or directory was deployed by an update that the user is missing.
            }

            return true;
        }

        /// <summary>
        /// Copies a directory and all its subdirectories and files. 
        /// </summary>
        /// <param name="origin">Path of the directory to copy</param>
        /// <param name="destination">Path to copy the directory to</param>
        public static void CopyAll(string origin, string destination)
        {
            if (!Directory.Exists(origin))
            {
                throw new DirectoryNotFoundException(ERRORINORIGINLOCATION + origin);
            }

            CopyContents(origin, destination);
        }

        /// <summary>
        /// Retrieves the last entry of a path. If the path contains a filename, this funtion will return the 
        /// filename, otherwise it will return the name of the last directory on the path string.
        /// </summary>
        /// <param name="path">Path to retrieve the last entry from</param>
        /// <returns>Last entry</returns>
        internal static string GetLastEntryFromPath(string path)
        {
            int pos = path.LastIndexOf(@"\");
            return path.Substring(pos + 1, path.Length - pos - 1);
        }

        #endregion

        #region Helper Functions
        /// <summary>
        /// Copy all the content from one path to another. 
        /// </summary>
        /// <param name="origin">Path to copy the content from</param>
        /// <param name="destination">Path to copy the content to</param>
        private static void CopyContents(string origin, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            string[] files = Directory.GetFiles(origin);
            foreach (string fileFullPathOrigin in files)
            {
                string filename = GetLastEntryFromPath(fileFullPathOrigin);

                string fileFullPathDestination = Path.Combine(destination, filename);

                if (IsComAddin(filename)) //Is this file the COM Addin?
                {
                    //UnRegisterCOM(fileFullPathDestination);
                    File.Copy(fileFullPathOrigin, fileFullPathDestination, true);
                    RegisterCOM(fileFullPathDestination);
                    Logger.Instance.Info(LOGCOPIEDCOM + fileFullPathOrigin + LOGTO + fileFullPathDestination);
                }
                else if (IsGacAssembly(filename))
                {
                    //UnRegisterAssembly(fileFullPathDestination);
                    File.Copy(fileFullPathOrigin, fileFullPathDestination, true);
                    UnRegisterAssembly(fileFullPathDestination);
                    RegisterAssembly(fileFullPathDestination);
                    Logger.Instance.Info(LOGCOPIEDGAC + fileFullPathOrigin + LOGTO + fileFullPathDestination);

                }
                else if (IsRegsvr32Assembly(filename))
                {
                    UnRegisterWithRegsvr32(fileFullPathDestination);
                    File.Copy(fileFullPathOrigin, fileFullPathDestination, true);
                    RegisterWithRegsvr32(fileFullPathDestination);
                    Logger.Instance.Info(LOGCOPIEDREGSVR32 + fileFullPathOrigin + LOGTO + fileFullPathDestination);
                }
                else
                {
                    File.Copy(fileFullPathOrigin, fileFullPathDestination, true);
                    Logger.Instance.Info(LOGCOPIED + fileFullPathOrigin + LOGTO + fileFullPathDestination);
                }
            }

            //Recursively copy files in subdirectories
            string[] directories = Directory.GetDirectories(origin);
            foreach (string directory in directories)
            {
                CopyContents(directory, Path.Combine(destination, GetLastEntryFromPath(directory)));
            }
        }

        /// <summary>
        /// Gets the configuration manager
        /// </summary>
        private static ConfigurationManager ConfigManager
        {
            get
            {
                if (_configManager == null)
                {
                    _configManager = new ConfigurationManager();
                }
                return _configManager;
            }
        }

        private static bool IsAssemblyInAppSetting(string key, string fileName)
        {
            string appSettingAssemblies = ConfigManager.ReadAppSettings(key);

            //The appSettingAssemblies are listed in the app config file separated by comma
            char[] separator = { ',' };

            string[] assembliesArray = appSettingAssemblies.Split(separator);

            foreach (string assembly in assembliesArray)
            {
                if (String.Compare(fileName, assembly, true, CultureInfo.CurrentCulture) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a file is the COM Addin that needs to be registered with Word
        /// </summary>
        /// <param name="fileName">Name of the file to check</param>
        /// <returns>True if the file is the COM Addin, false otherwise</returns>
        private static bool IsComAddin(string fileName)
        {
            return IsAssemblyInAppSetting(COMADDINSETTINGNAME, fileName);
        }

        /// <summary>
        /// Checks if a file is an assembly that needs to be registered in the GAC
        /// </summary>
        /// <param name="fileName">Name of the file to check</param>
        /// <returns>True if the assembly needs to be registered in the GAC, false otherwise</returns>
        private static bool IsGacAssembly(string fileName)
        {
            return IsAssemblyInAppSetting(GACASSEMBLIESSETTINGNAME, fileName);
        }

        /// <summary>
        /// Checks if a file is an assembly that needs to be registered using Regsvr32
        /// </summary>
        /// <param name="fileName">Name of the file to check</param>
        /// <returns>True if the assembly needs to be registered using Regsvr32, false otherwise</returns>
        private static bool IsRegsvr32Assembly(string fileName)
        {
            return IsAssemblyInAppSetting(REGSVR32ASSEMBLIESSETTINGNAME, fileName);
        }

        /// <summary>
        /// Registers an assembly with Regsvr32
        /// </summary>
        /// <param name="fileFullPath">Full path to the assembly file</param>
        private static void RegisterWithRegsvr32(string fileFullPath)
        {
            Process.Start(REGSVR32, String.Format(REGSVR32PARAMSINSTALL, fileFullPath));
        }

        /// <summary>
        /// Unregisters an assembly with Regsvr32
        /// if the file allready exists
        /// </summary>
        /// <param name="fileFullPath">Full path to the assembly file</param>
        private static void UnRegisterWithRegsvr32(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                Process.Start(REGSVR32, String.Format(REGSVR32PARAMSUNINSTALL, fileFullPath));
            }
        }

        /// <summary>
        /// Registers an assembly for COM interop
        /// </summary>
        /// <param name="fileFullPath">Full path to the assembly file</param>
        private static void RegisterCOM(string fileFullPath)
        {
            Publish publish = new Publish();
            try
            {
                //Unregister existing file
                Logger.Instance.Info(LOGREGISTERINGCOM + fileFullPath);
                publish.RegisterAssembly(fileFullPath);
            }
            catch (TypeLoadException e)
            {
                Logger.Instance.Error(LOGREGISTERINGCOM, e);
            }
            finally
            {
                publish = null;
            }
        }

        /// <summary>
        /// Register an assembly into the GAC
        /// </summary>
        /// <param name="fileFullPath">Full path to the assembly file</param>
        private static void UnRegisterAssembly(string fileFullPath)
        {
            Publish publish = new Publish();
            publish.GacRemove(fileFullPath);
        }

        /// <summary>
        /// Register an assembly into the GAC
        /// </summary>
        /// <param name="fileFullPath">Full path to the assembly file</param>
        private static void RegisterAssembly(string fileFullPath)
        {
            Publish publish = new Publish();
            publish.GacInstall(fileFullPath);
        }
        #endregion

    }
}
