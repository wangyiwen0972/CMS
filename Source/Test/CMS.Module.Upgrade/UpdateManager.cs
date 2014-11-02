//Filename: DxEditorClass.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-dilam
//Creation Date: 5/18/2007 3:00:34 PM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/09/07     v-dilam         Initial Version.
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    public static class UpdateManager
    {
        #region Private Variables
        private const string UACOPERATIONS = "UacOperations.exe";

        #region Logger
        private const string LOGINSTALLINGCOREUPDATES = "Installing core updates";
        private const string LOGUPDATESECTION = "--- Update section : ";
        private const string LOGINSALLINGSCHEMAUPDATES = "Installing updates for all installed schemas";
        private const string LOGINSALLINGSCHEMAUPDATESFINISHED = "Finished installing updates for all installed schemas";
        private const string LOGINSTALLINGUPDATESFOR = "Installing updates for: ";
        private const string LOGINSTALLINGUPDATESFORFINISHED = "Finished installing updates for: ";
        private const string LOGISSCHEMA = ". Is schema: ";

        #endregion

        #endregion

        #region Constructors

        #endregion

        #region Public Methods
        /// <summary>
        /// Process updates for the main sections of the application
        /// </summary>
        public static void ProcessUpdates()
        {
            Logger.Instance.Info(LOGINSTALLINGCOREUPDATES);

            Logger.Instance.Info(LOGUPDATESECTION + UpdateFrameworkConstants.DXSTUDIOSCHEMASSECTIONNAME);
            UpdateManager.InstallSectionUpdate(UpdateFrameworkConstants.DXSTUDIOSCHEMASSECTIONNAME, false);

            Logger.Instance.Info(LOGUPDATESECTION + UpdateFrameworkConstants.CORESECTIONNAME);
            UpdateManager.InstallSectionUpdate(UpdateFrameworkConstants.CORESECTIONNAME, false);

            Logger.Instance.Info(LOGUPDATESECTION + UpdateFrameworkConstants.DATASOURCEPROVIDERSECTIONNAME);
            UpdateManager.InstallSectionUpdate(UpdateFrameworkConstants.DATASOURCEPROVIDERSECTIONNAME, false);

            Logger.Instance.Info(LOGUPDATESECTION + UpdateFrameworkConstants.TOOLSSECTIONNAME);
            UpdateManager.InstallSectionUpdate(UpdateFrameworkConstants.TOOLSSECTIONNAME, false);

            Logger.Instance.Info(LOGINSALLINGSCHEMAUPDATES);
            foreach (string schema in GetInstalledSchemas())
            {
                Logger.Instance.Info(LOGUPDATESECTION + schema);
                UpdateManager.InstallSectionUpdate(schema, true);
            }
            Logger.Instance.Info(LOGINSALLINGSCHEMAUPDATESFINISHED);
        }

        /// <summary>
        /// Process updates for the section specified
        /// </summary>
        /// <param name="section">Section to process updates</param>
        /// <param name="isSchema">Indicates whether the section is a schema or not</param>
        public static void ProcessUpdates(string section, bool isSchema)
        {
            Logger.Instance.Info(LOGINSTALLINGUPDATESFOR + section + LOGISSCHEMA + isSchema.ToString());
            UpdateManager.InstallSectionUpdate(section, isSchema);
            Logger.Instance.Info(LOGINSTALLINGUPDATESFORFINISHED + section + LOGISSCHEMA + isSchema.ToString());
        }

        /// <summary>
        /// Checks if there are updates availables for the section provided
        /// </summary>
        /// <param name="section">Section to check updates</param>
        /// <param name="isSchema">Indicates whether the section is a schema or not</param>
        /// <returns>True if there are updates available for the section, false oterwhise</returns>
        public static bool UpdatesAvailable(string section, bool isSchema)
        {
            return UpdateManager.UpdatesAvailableForSection(section, isSchema);
        }

        /// <summary>
        /// Checks for updates for the main sections of the application
        /// </summary>
        /// <returns>True if updates are available, false otherwise</returns>
        public static bool UpdatesAvailable()
        {
            return UpdateManager.UpdatesAvailableForSection(UpdateFrameworkConstants.CORESECTIONNAME, false)
                   || UpdateManager.UpdatesAvailableForSection(UpdateFrameworkConstants.DATASOURCEPROVIDERSECTIONNAME, false)
                   || UpdateManager.UpdatesAvailableForSection(UpdateFrameworkConstants.TOOLSSECTIONNAME, false);

        }

        /// <summary>
        /// Launchs the UacOperation executable responsible for installing the updates
        /// </summary>
        /// <param name="section">Name of the section to update</param>
        /// <param name="isSchema">Inidicates whether the section is an schema section</param>
        /// <returns>Result of the update operation</returns>
        public static UpdateResult LaunchExecOperations(string section, bool isSchema)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Path.Combine(UpdateFrameworkHelper.GetExecutingAssemblyPath(), UACOPERATIONS);

            //Build arguments string to pass to UacOperations
            string arguments = UpdateFramework.UpdateFrameworkConstants.LAUNCHERCODE;
            if (!string.IsNullOrEmpty(section))
            {
                arguments += " \"" + section.Replace("\"",String.Empty) + "\"";
                arguments += " " + isSchema.ToString();
            }
            psi.Arguments = arguments;
            psi.ErrorDialog = true;

            try
            {
                Process p = Process.Start(psi);
                p.WaitForExit();

                return (UpdateResult)p.ExitCode;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return UpdateResult.UserRefusedUacElevation;
            }
        }
        #endregion

        /// <summary>
        /// Installs updates for the section provided
        /// </summary>
        /// <param name="section">Section to check updates</param>
        /// <param name="isSchema">Indicates whether the section is a schema or not</param>
        private static void InstallSectionUpdate(string section, bool isSchema)
        {
            UpdatableSection updatableSection = new UpdatableSection(section, isSchema);
            updatableSection.InstallUpdates();
        }


        /// <summary>
        /// Checks if there are updates available for the section provided
        /// </summary>
        /// <param name="section">Section to check updates for</param>
        /// <param name="isSchema">Indicates whether the section is a schema or not</param>
        /// <returns>True if updates are available, false otherwise</returns>
        private static bool UpdatesAvailableForSection(string section, bool isSchema)
        {
            UpdatableSection updatableSection = new UpdatableSection(section, isSchema);
            return updatableSection.UpdatesAvailable();
        }

        /// <summary>
        /// Gets the name of all the schemas installed locally
        /// </summary>
        /// <returns>Arry with the names of all the installed schemas</returns>
        private static List<string> GetInstalledSchemas()
        {
            string localInstallPath = UpdateFrameworkHelper.GetExecutingAssemblyPath();
            string schemasPath = Path.Combine(localInstallPath, UpdateFrameworkConstants.SCHEMASFOLDERNAME);

            string[] installedSchemasFullPath = null;

            List<string> installedSchemas = new List<string>();

            if (Directory.Exists(schemasPath))
            {
                installedSchemasFullPath = Directory.GetDirectories(schemasPath);
                foreach (string schemaPath in installedSchemasFullPath)
                {
                    installedSchemas.Add(FileHelper.GetLastEntryFromPath(schemaPath));
                }
            }

            return installedSchemas;
        }

    }
}
