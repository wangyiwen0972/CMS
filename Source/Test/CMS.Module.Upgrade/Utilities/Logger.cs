//Filename: Logger.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 5/17/2007 11:35:17 AM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/17/07     v-ragene        Initial Version.
//--------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Logger utility for info and error messages
    /// </summary>
    public class Logger
    {
        #region Private Variables
        private const string ENABLEUPDATELOGKEY = "LogUpdateMessages";
        private const string BLANKSPACES = "      ";
        private const string LOGFILEPARTIALNAME = "UpdateFramework";
        private const string LOGFILEEXTENSION = ".log";
        private const string LOGFILEPATH = @"DxEditor\Logs\Update Framework";
        private const string LOGERRORCLEANINGFILES = "Error cleaning up old log files";

        private static Logger instance;
        private static readonly object padlock = new object();
        private static DefaultTraceListener defaultListener;
        private bool isEnabled = true;
        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new instance of logger
        /// </summary>
        public Logger()
        {
            ConfigurationManager configManager = new ConfigurationManager();
            if (!bool.TryParse(configManager.ReadAppSettings(ENABLEUPDATELOGKEY), out isEnabled))
            {   // if we can't make sense of the config entry, it is false
                isEnabled = false;
            }
            
            defaultListener = new DefaultTraceListener();
            //Trace.Listeners.Add(defaultListener);

            string folderPath = GetLogsFolder();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            Logger.CleanUpLogFiles();

            string filePath = Path.Combine(folderPath, Logger.GetFileNameForToday());

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            defaultListener.LogFileName = filePath;
        }

        /// <summary>
        /// Logs an information message
        /// </summary>
        /// <param name="message">Information message to log</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822")]
        public void Info(string message)
        {
            if (isEnabled)
            {
                defaultListener.WriteLine(Logger.GetDateTime() + BLANKSPACES + message);
            }
        }

        /// <summary>
        /// Gets the instance of the logger
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                else
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                        return instance;
                    }
                }
            }
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">Error message to log</param>
        /// <param name="e">Exception to log</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822")]
        public void Error(string message, Exception e)
        {
            if (isEnabled)
            {
                defaultListener.WriteLine(Logger.GetDateTime() + BLANKSPACES + message);
                if (e != null)
                {
                    defaultListener.IndentLevel = 2;
                    defaultListener.WriteLine(e.Message);
                    defaultListener.WriteLine(e.InnerException);
                    defaultListener.WriteLine(e.StackTrace);
                    defaultListener.IndentLevel = 1;
                }
            }
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">Error message to log</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822")]
        public void Error(string message)
        {
            if (isEnabled)
            {
                defaultListener.WriteLine(Logger.GetDateTime() + BLANKSPACES + message);
            }
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Gets a string representing the current date/time
        /// </summary>
        /// <returns>String representing the current date/time</returns>
        private static string GetDateTime()
        {
            return DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the log filename for today
        /// </summary>
        /// <returns></returns>
        private static string GetFileNameForToday()
        {
            string year = DateTime.Now.Year.ToString(CultureInfo.CurrentCulture);

            string month = ConvertIntegerToString(DateTime.Now.Month);

            string day = ConvertIntegerToString(DateTime.Now.Day);

            return LOGFILEPARTIALNAME + month + day + year + LOGFILEEXTENSION;
        }

        /// <summary>
        /// Converts an integer to string. Makes sure the string is always two characters long.
        /// </summary>
        /// <param name="value">Integer value to convert</param>
        /// <returns>String result of the conversion</returns>
        private static string ConvertIntegerToString(int value)
        {
            if (value < 10)
            {
                return "0" + value.ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                return value.ToString(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the path to the folder for storing the log files
        /// </summary>
        /// <returns>Path to the folder for storing the log files</returns>
        private static string GetLogsFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), LOGFILEPATH);
        }

        /// <summary>
        /// Deletes old log files
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031")]
        private static void CleanUpLogFiles()
        {
            try
            {
                string folderPath = Logger.GetLogsFolder();

                foreach (string file in Directory.GetFiles(folderPath))
                {

                    DateTime lastWrite = File.GetLastWriteTime(file);

                    TimeSpan ts = DateTime.Now - lastWrite;

                    double differenceInDays = ts.TotalDays;

                    if (differenceInDays > UpdateFrameworkConstants.DAYSTOKEEPFILESINLOG)
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Instance.Error(LOGERRORCLEANINGFILES, e);
            }
        }
        #endregion
    }
}
