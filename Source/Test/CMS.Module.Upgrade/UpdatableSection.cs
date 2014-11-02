//Filename: UpdatableSection.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 5/22/2007 5:15:42 PM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/09/07     v-ragene        Initial Version.
//  2           10/11/07    v-shermq        Added functionality to support CR# 4839 - Restrict Opening Topic w/o Schema
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Collections.ObjectModel;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    public class UpdatableSection
    {
        #region Private Variables

        private bool _isSchema;
        private string _section;
        private ConfigurationManager _configManager;
        private int? _latestVersion = null;
        private const string UPDATELOCATIONSETTINGNAME = "UpdateLocation";
        private const string CHECKUPDATESFREQUENCYSETTINGNAME = "CheckUpdatesFrequency";
        private const string FOLDERCONTAININGUPDATESNAME = "Version";
        private const string THEPATH = "The path: ";
        private const string WASNOTFOUND = " was not found.";

        #region Logger
        private const string LOGCHECKEDUPDATESAVAILABLE = "Checked Updates Available for ";
        private const string LOGLOCALVERSION = ". Local version: ";
        private const string LOGLATESTVERSION = ". Latest version: ";
        private const string LOGRESULT = ". Result: ";
        private const string LOGFILETODELETE = "File to delete from manifest:";
        private const string LOGERRORREADINGUPDATESFREQUENCY = "Error reading check updates frequency value from the config file.";

        #endregion
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of UpdatableSection
        /// </summary>
        /// <param name="section">Name of the section</param>
        public UpdatableSection(string section)
        {
            _section = section;
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of UpdatableSection
        /// </summary>
        /// <param name="section">Name of the section</param>
        /// <param name="isSchema">Indicates whether the section is a schema</param>
        public UpdatableSection(string section, bool isSchema)
        {
            _section = section;
            _isSchema = isSchema;
            Initialize();
        }

        #endregion

        #region Public Methods

        #region Properties
        /// <summary>
        /// Gets or sets the name of this section
        /// </summary>
        public string Section
        {
            get { return _section; }
            set { _section = value; }
        }

        /// <summary>
        /// Gets or sets a boolean indicating whether this section is a schema section
        /// </summary>
        public bool IsSchema
        {
            get { return _isSchema; }
            set { _isSchema = value; }
        }

        /// <summary>
        /// Gets a boolean indicating whether this section is core
        /// </summary>
        private bool IsCore
        {
            get
            {
                return (string.Compare(_section, UpdateFrameworkConstants.CORESECTIONNAME, true, CultureInfo.CurrentCulture) == 0);
            }
        }
        #endregion

        /// <summary>
        /// Checks if there are updates available for the section. 
        /// If no updates are available, the last checked date/time is updated with the current date/time
        /// </summary>
        /// <returns>True if there are updates for the section, otherwise false</returns>
        public bool UpdatesAvailable()
        {

            //Get last time updates were checked for the section
            DateTime lastChecked = ManifestHelper.GetLastCheckedDateTime(this._section, this._isSchema);

            //Get the frequency updates should be checked
            int updateFrequency = GetUpdatesFrequency();

            TimeSpan ts = DateTime.Now - lastChecked;
            double differenceInMinutes = Math.Abs(ts.TotalMinutes);

            //If sufficient time has not passed since the last check ==> return
            //Ignore the update frequency when the section is not on the local system.
            if (differenceInMinutes < updateFrequency && this.IsSectionDirectoryPresent())
            {
                return false;
            }

            string updatePath = GetUpdatePath();
            string localPath = GetLocalPath();

            //Get the update share version and the local version for this section
            _latestVersion = ManifestHelper.GetLatestVersion(updatePath);
            int localVersion = ManifestHelper.GetLocalVersion(localPath);

            //If there are not updates ==> set the last checked date/time for this section to the current date/time
            if (_latestVersion == localVersion)
            {
                UpdateLastCheckedDateTime();
            }

            bool updatesAvailable = (_latestVersion != localVersion);

            Logger.Instance.Info(LOGCHECKEDUPDATESAVAILABLE + _section + LOGLOCALVERSION + localVersion.ToString() + LOGLATESTVERSION + _latestVersion.ToString() + LOGRESULT + updatesAvailable.ToString(CultureInfo.CurrentCulture));

            //Return true if latestVersion<>localVersion, it doesn't matter if it is lesser or greater
            return updatesAvailable;

        }

        /// <summary>
        /// Installs the updates available for this section.
        /// </summary>
        public void InstallUpdates()
        {
            if (!UpdatesAvailable())
            {
                return;
            }

            string updatePath = GetUpdatePath();
            string localPath = GetLocalPath();

            Collection<string> filesToDelete = ManifestHelper.GetDeleteFileList(updatePath);

            //Change the address from relative to absolute for all the files to delete
            for (int i = 0; i < filesToDelete.Count; i++)
            {
                filesToDelete[i] = Path.Combine(localPath, filesToDelete[i]);
                Logger.Instance.Info(LOGFILETODELETE + filesToDelete[i]);
            }


            //_latestVersion should has been retrieved by the previous call to UpdatesAvailable()
            //but double checking here just in case.
            if (_latestVersion == null)
            {
                ManifestHelper.GetLatestVersion(updatePath);
            }

            string newVersionPath = Path.Combine(updatePath, FOLDERCONTAININGUPDATESNAME + _latestVersion.ToString());

            if (!Directory.Exists(newVersionPath))
            {
                throw new UpdateLocationConfigurationException(THEPATH + newVersionPath + WASNOTFOUND);
            }

            //Delete the desired files
            FileHelper.Delete(filesToDelete);

            //Copy all the files from the update location
            FileHelper.CopyAll(newVersionPath, localPath);

            //Update the local version witht the latest version
            ManifestHelper.SetLocalVersion(localPath, _latestVersion.Value);

            //Update the last checked information for this section
            UpdateLastCheckedDateTime();
        }

        /// <summary>
        /// Determines if the directory for the given schema exists on the user's system
        /// </summary>
        /// <param name="section">The section that represents a schema that is under review</param>
        /// <returns>True of the schema directory exists on the local system</returns>
        public static bool IsLocalSchemaDirectoryPresent(string schemaSection)
        {
            return UpdatableSection.isLocalSchemaDirectoryPresent(schemaSection);
        }

        /// <summary>
        /// Determines if the directory for the given schema exists on the user's system
        /// </summary>
        /// <returns>True of the directory exists on the local system</returns>
        public bool IsSectionDirectoryPresent()
        {
            string versionFilePath = Path.Combine(GetLocalPath(), UpdateFrameworkConstants.LOCALVERSIONMANIFESTFILENAME);
            if (System.IO.Directory.Exists(GetLocalPath()) && File.Exists(versionFilePath))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Gets the update frequency value. This value indicates how often the update framework 
        /// should check for updates for a section
        /// </summary>
        /// <returns></returns>
        private int GetUpdatesFrequency()
        {
            int updatesFrequency = 0;

            try
            {
                updatesFrequency = Convert.ToInt32(_configManager.ReadAppSettings(CHECKUPDATESFREQUENCYSETTINGNAME));
            }
            catch (FormatException e)
            {
                Logger.Instance.Error(LOGERRORREADINGUPDATESFREQUENCY, e);
            }

            return (updatesFrequency >= UpdateFrameworkConstants.UPDATEFREQUENCYMIN
                     && updatesFrequency <= UpdateFrameworkConstants.UPDATEFREQUENCYMAX)
                     ? updatesFrequency : UpdateFrameworkConstants.UPDATEFREQUENCYMIN;

        }

        /// <summary>
        /// Initializes the class
        /// </summary>
        private void Initialize()
        {
            _configManager = new ConfigurationManager();
        }

        /// <summary>
        /// Gets the path to the update share for the section
        /// </summary>
        /// <returns></returns>
        private string GetUpdatePath()
        {
            string updatePath = _configManager.ReadAppSettings(UPDATELOCATIONSETTINGNAME);

            if (_isSchema)
            {
                //Get <update location>/schemas
                updatePath = Path.Combine(updatePath, UpdateFrameworkConstants.SCHEMASFOLDERNAME);
            }

            return Path.Combine(updatePath, _section);
        }

        /// <summary>
        /// Gets the path to this section in the local installation folder
        /// </summary>
        /// <returns></returns>
        private string GetLocalPath()
        {
            string localPath = UpdateFrameworkHelper.GetExecutingAssemblyPath();

            if (_isSchema)
            {
                //Get <local install>/schemas
                localPath = Path.Combine(localPath, UpdateFrameworkConstants.SCHEMASFOLDERNAME);
            }

            //If this is "Core" then the path is just the local install path
            //otherwise ==> add the section to the path string (i.e. <local path>/tools>)
            return IsCore ? localPath : Path.Combine(localPath, _section);
        }

        /// <summary>
        /// Updates the last checked date/time value for the section with the current date/time
        /// </summary>
        private void UpdateLastCheckedDateTime()
        {
            string localPath = GetLocalPath();
            ManifestHelper.SetLastCheckedDateTime(this._section, this._isSchema, DateTime.Now);
        }

        /// <summary>
        /// Determines if the directory for the given schema exists on the user's system
        /// </summary>
        /// <param name="section">The section that represents a schema that is under review</param>
        /// <returns>True of the schema directory exists on the local system</returns>
        private static bool isLocalSchemaDirectoryPresent(string schemaSection)
        {
            UpdatableSection updatableSection = new UpdatableSection(schemaSection, true);
            return updatableSection.IsSectionDirectoryPresent();
        }
        #endregion
    }
}
