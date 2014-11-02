//Filename: Configuration.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 7/12/2007 2:34:11 PM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/09/07     v-ragene         Initial Version.
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using SystemConfig=System.Configuration;
using System.IO;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Contains all the functionality related to the config file
    /// </summary>
    internal class ConfigurationManager
    {
        #region Private Variables

        private const string CONFIGFILENAME = "Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll.config";
        private SystemConfig.Configuration _currentConfiguration;
        private bool _configFileExist;

        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of ConfigurationManager
        /// </summary>
        internal ConfigurationManager()
        {
            //always get the absolute path to the file
            string fullPath = Path.Combine(UpdateFrameworkHelper.GetExecutingAssemblyPath(), CONFIGFILENAME);

            //Note: Don't use OpenExeConfiguration() method because looks for the 
            //default exe application config
            //Create a ExeConfigurationFileMap to set the name of the ExeConfigFilename
            SystemConfig.ExeConfigurationFileMap configFileMap =
                new System.Configuration.ExeConfigurationFileMap();

            //The ExeConfigFilename is the absolute path of the config file
            configFileMap.ExeConfigFilename = fullPath;

            //Open our configuration file instead of the default app configuration
            _currentConfiguration = SystemConfig.ConfigurationManager.OpenMappedExeConfiguration
                (configFileMap, System.Configuration.ConfigurationUserLevel.None);

            _configFileExist = _currentConfiguration.HasFile;
        }

        #endregion

        #region Public Methods
        /// <summary>
        ///     Read the key from the currently opened configuration.  
        /// </summary>
        /// <param name="key">
        ///     The key to retrieve from the configuration app settings section.
        /// </param>
        /// <returns>
        ///     The value corresponding to the given key.  
        ///     Returns string.Empty if key or value is not found in the configuration file.
        /// </returns>
        internal string ReadAppSettings(string key)
        {
            if (!_configFileExist)
            {
                return string.Empty;
            }

            //Get given key value pair from the configuration
            SystemConfig.KeyValueConfigurationElement keyValueElement =
                _currentConfiguration.AppSettings.Settings[key];

            return keyValueElement == null ? string.Empty : keyValueElement.Value;

        }
        #endregion

        #region Helper Functions

        #endregion

    }
}
