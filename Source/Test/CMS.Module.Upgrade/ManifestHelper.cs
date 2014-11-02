//Filename: ManifestHelper.cs
//
//Description:
//Handles all the manifest related functions
//
//Creator: v-ragene
//Creation Date: 5/21/2007 3:35:23 PM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/22/07     v-ragene         Initial Version
//  2           6/21/07     v-ragene         Implemented GetLastCheckedDateTime and SetLastCheckedDateTime
//                                           Changed GetLocalVersion to return 0 when directory not found
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Globalization;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Contains utility functions to handle update and local manfiests
    /// </summary>
    internal static class ManifestHelper
    {
        #region Private Variables

        private const string UPDATEMANIFESTROOTELEMENT = "UpdateManifest";
        private const string VERSIONELEMENT = "Version";
        private const string DELETEELEMENT = "Delete";
        private const string INSTALLEDVERSIONELEMENT = "InstalledVersion";
        private const string UPDATELOCATIONERRRORMESSAGE = "Error connecting to the update location.";
        private const string UPDATEMANIFESTFILENOTFOUND = "10006 - Update manifest file not found.";
        private const string UPDATESCHECKINGLOGROOTELEMENT = "UpdatesCheckingLog";
        private const string UPDATESCHECKINGLOGSECTIONNAMEELEMENT = "Name";
        private const string UPDATESCHECKINGLOGSECTIONISSCHEMAELEMENT = "IsSchema";
        private const string UPDATESCHECKINGLOGSECTIONLASTCHECKEDELEMENT = "LastChecked";
        private const string UPDATESCHECKINGLOGFILENAME = "UpdatesCheckingLog.xml";
        private const string UPDATESCHECKINGLOGSECTIONPARTIALXPATH = "/UpdatesCheckingLog/Section[@";
        private const string UPDATESCHECKINGLOGSECTIONELEMENT = "Section";
        private const string PATHSTRING = " Path:";
        private const string DATE1980 = "1/1/1980";
        private const string ERRORCREATINGUPDATELOGFILE = "Error creating update log file.";
        private const string ERRORINGETUPDATESCHECKINGLOG = "Error getting updates checking log file";
        private const string ERRORINVERSIONFILE = "10008 - Invalid version file structure. File path: {0}.";
        private const string ERRORINUPDATEMANIFESTFILE = "10007 - Invalid UpdateManifest file structure. File path: {0}.";
        private const string ERRORINUPDATESCHECKINGLOGFILE = "10011 - Error accessing the UpdatesCheckingLog.xml file.";


        #region Logger
        private const string LOGLOADINGXML = "Loading xml: ";
        private const string LOGCREATINGUPDATECHECKINGFILE = "Creating update checking log file.";
        #endregion

        #endregion

        #region Constructors


        #endregion

        #region Public Methods

        #region Version number related methods
        /// <summary>
        /// Gets the latest version from the xml manifest file
        /// </summary>
        /// <param name="path">Path to the manifest file</param>
        /// <returns>Latest version</returns>
        public static int GetLatestVersion(string path)
        {
            XmlDocument updateManifest;
            try
            {
                updateManifest = GetManifest(path, UpdateFrameworkConstants.UPDATEMANIFESTFILENAME);
            }
            catch (FileNotFoundException fe)
            {
                throw new UpdateLocationNotAvailableException(UPDATEMANIFESTFILENOTFOUND + PATHSTRING + path, fe);
            }
            catch (DirectoryNotFoundException de)
            {
                throw new UpdateLocationNotAvailableException(UPDATEMANIFESTFILENOTFOUND + PATHSTRING + path, de);
            }
            catch (IOException ioe)
            {
                throw new UpdateLocationNotAvailableException(UPDATEMANIFESTFILENOTFOUND + PATHSTRING + path, ioe);
            }
            catch (UriFormatException ue)
            {
                throw new UpdateLocationNotAvailableException(UPDATEMANIFESTFILENOTFOUND + PATHSTRING + path, ue);
            }
            catch (Exception e)
            {
                Logger.Instance.Error(String.Format(ERRORINUPDATEMANIFESTFILE, path), e);
                throw new UpdateLocationConfigurationException(String.Format(ERRORINUPDATEMANIFESTFILE, path), e);
            }

            int updateManifestNumber=0;

            try
            {
                updateManifestNumber = Convert.ToInt32(updateManifest[UPDATEMANIFESTROOTELEMENT].Attributes[VERSIONELEMENT].InnerText);
            }
            catch (Exception e)
            {
                Logger.Instance.Error(String.Format(ERRORINUPDATEMANIFESTFILE, path), e);
                throw new UpdateLocationConfigurationException(String.Format(ERRORINUPDATEMANIFESTFILE, path), e);
            }

            return updateManifestNumber;
        }

        /// <summary>
        /// Gets the local installed version of an updatable section of the application by reading
        /// the version.xml file
        /// </summary>
        /// <param name="path">Path to the version file</param>
        /// <returns>Local installed version, 0 if directory not found</returns>
        /// 
        public static int GetLocalVersion(string path)
        {
            XmlDocument localVersion;

            try
            {
                //If the folder or the file is not found it might be because the section is not installed, so we return
                //0 to make sure the update framework downloads the section from the update server
                // Although we have handled this, we still handle corrosponding exceptions as well
                // to take care of the files being deleted between the check and GetManifest(..) call
                if (!File.Exists(
                        Path.Combine(path, UpdateFrameworkConstants.LOCALVERSIONMANIFESTFILENAME)))
                {
                    return 0;
                }
                else
                {
                    localVersion = GetManifest(path, UpdateFrameworkConstants.LOCALVERSIONMANIFESTFILENAME);
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                return 0;
            }
            catch (System.IO.FileNotFoundException)
            {
                return 0;
            }
            catch (XmlException e)
            {
                Exception ex = new UpdateFrameworkException(String.Format(ERRORINVERSIONFILE, path), e);
                Logger.Instance.Error(String.Format(ERRORINVERSIONFILE, path), e);
                throw ex;
            }

            int localVersionNumber = 0;

            try
            {
                localVersionNumber = Convert.ToInt32(localVersion[VERSIONELEMENT].Attributes[INSTALLEDVERSIONELEMENT].Value);
            }
            catch (OverflowException)
            {
                return -5;
            }
            catch (Exception e)
            {
                Exception ex = new UpdateFrameworkException(String.Format(ERRORINVERSIONFILE, path), e);
                Logger.Instance.Error(String.Format(ERRORINVERSIONFILE, path), e);
                throw ex;
            }

            return localVersionNumber;

        }

        /// <summary>
        /// Sets the local installed version of an updatable section of the application by writing to
        /// the version.xml file 
        /// </summary>
        /// <param name="path">Path to the version file</param>
        /// <param name="version">New version</param>
        public static void SetLocalVersion(string path, int version)
        {
            string fullPath = Path.Combine(path, UpdateFrameworkConstants.LOCALVERSIONMANIFESTFILENAME);
            if (File.Exists(fullPath)) //Update existing version file
            {

                XmlDocument localVersion = GetManifest(path, UpdateFrameworkConstants.LOCALVERSIONMANIFESTFILENAME);

                localVersion[VERSIONELEMENT].Attributes[INSTALLEDVERSIONELEMENT].InnerText = version.ToString();

                localVersion.Save(Path.Combine(path, UpdateFrameworkConstants.LOCALVERSIONMANIFESTFILENAME));
            }
            else //Create a new version file
            {
                //If the folder doesn't exist ==> create it first
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Create a new version file
                XmlTextWriter xmlWriter = new XmlTextWriter(fullPath, Encoding.UTF8);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(VERSIONELEMENT);
                xmlWriter.WriteAttributeString(INSTALLEDVERSIONELEMENT, version.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }
        #endregion

        #region Delete File list related methods

        /// <summary>
        /// Gets the list of files to be deleted from the xml manifest file
        /// </summary>
        /// <param name="path">Path to the manifest file</param>
        /// <returns>List of files to delete. Empty list if not files to delete.</returns>
        public static Collection<string> GetDeleteFileList(string path)
        {
            XmlDocument updateManifest = GetManifest(path, UpdateFrameworkConstants.UPDATEMANIFESTFILENAME);

            Collection<string> fileList = new Collection<string>();
            XmlNode mainNode = updateManifest[UPDATEMANIFESTROOTELEMENT];

            if (mainNode[DELETEELEMENT] != null)
            {
                XmlNodeList deleteFiles = updateManifest[UPDATEMANIFESTROOTELEMENT][DELETEELEMENT].ChildNodes;
                foreach (XmlNode node in deleteFiles)
                {
                    fileList.Add(node.InnerText);
                }
            }

            return fileList;
        }

        #endregion

        #region Last checked date/time related methods

        /// <summary>
        /// Gets the last checked datetime of an updatable section of the application
        /// </summary>
        /// <param name="section">Name of the section</param>
        /// <param name="isSchema">Indicates whether the section is a schema section or not</param>
        /// <returns>Last checked datetime, 1/1/1980 if directory not found</returns>
        public static DateTime GetLastCheckedDateTime(string section, bool isSchema)
        {
             XmlDocument updatesCheckingLog = null;
            try
            {
                updatesCheckingLog = GetUpdatesCheckingLogXml();
            }
            catch (UpdateFrameworkException)
            {
                //Fix to bug 1402
                //Fail silently if we can't get the updates checking log.

                return Convert.ToDateTime(DATE1980);
            }

            XmlNode elementNode = GetSectionNodeFromUpdatesCheckingLog(updatesCheckingLog, section, isSchema);

            DateTime lastChecked;

            if (elementNode == null)
            {
                //Create a new entry for this section
                lastChecked = Convert.ToDateTime(DATE1980);

                CreateSectionNode(updatesCheckingLog, section, isSchema, lastChecked);

                SaveUpdatesCheckingLogXml(updatesCheckingLog);
            }
            else
            {
                lastChecked = Convert.ToDateTime(elementNode.Attributes[UPDATESCHECKINGLOGSECTIONLASTCHECKEDELEMENT].Value);
            }

            return lastChecked;
        }

        
        /// <summary>
        /// Sets the last checked datetime of an updatable section of the application 
        /// </summary>
        /// <param name="section">Name of the section</param>
        /// <param name="isSchema">Indicates whether the section is a schema section or not</param>
        /// <param name="lastChecked">Last checked datetime</param>
        public static void SetLastCheckedDateTime(string section, bool isSchema, DateTime lastChecked)
        {
            XmlDocument updatesCheckingLog = null;
            try
            {
                updatesCheckingLog = GetUpdatesCheckingLogXml();
            }
            catch (UpdateFrameworkException)
            {
                //Fix to bug 1402
                //Fail silently if we can't get the updates checking log.

                return;
            }

            XmlNode elementNode = GetSectionNodeFromUpdatesCheckingLog(updatesCheckingLog, section, isSchema);

            if (elementNode == null)
            {
                //Create a new entry for this section
                elementNode = CreateSectionNode(updatesCheckingLog, section, isSchema, lastChecked);
            }

            elementNode.Attributes[UPDATESCHECKINGLOGSECTIONLASTCHECKEDELEMENT].Value = lastChecked.ToString();

            SaveUpdatesCheckingLogXml(updatesCheckingLog);

        }

        #endregion

        #endregion

        #region Helper Functions

        #region Methods UpdateManifest and Version methods
        /// <summary>
        /// Gets a manifest from an specific path
        /// </summary>
        /// <param name="path">Path to the manifest to retrieve</param>
        /// <param name="manifestFileName">Name of the xml file</param>
        /// <returns></returns>
        private static XmlDocument GetManifest(string path, string manifestFileName)
        {
            return GetXmlDocument(path, manifestFileName);
        }

        /// <summary>
        /// Gets an XmlDocument provided the path and name of the file
        /// </summary>
        /// <param name="path">Path to the xml file</param>
        /// <param name="documentName">Name of the xml file</param>
        /// <returns>XmlDocument loaded from the path/file provided</returns>
        private static XmlDocument GetXmlDocument(string path,string documentName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            path = Path.Combine(path, documentName);
            Logger.Instance.Info(LOGLOADINGXML + path);
            xmlDoc.Load(path);
            return xmlDoc;
        }

        #endregion

        #region Updates Checking Log methods

        #region Isolated Storage helper methods

        /// <summary>
        /// Retrieves the updates checking log xml from the storage location
        /// </summary>
        /// <returns>XmlDocument containing the update checking log</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031")]
        private static XmlDocument GetUpdatesCheckingLogXml()
        {
            IsolatedStorageFile isoFile = GetStorageStore();
            XmlDocument updatesCheckingLogXml = new XmlDocument();

            //Verify that the file exists
            string[] updatesCheckingFileName = isoFile.GetFileNames(UPDATESCHECKINGLOGFILENAME);
            if (updatesCheckingFileName.GetUpperBound(0) < 0)
            {
                //File not found ==> Create the file
                CreateUpdatesCheckingLogFile();
            }

            IsolatedStorageFileStream updatesCheckingLogStream = null;
            try
            {
                //Open the file and load it on the xmldocument object
                updatesCheckingLogStream = new IsolatedStorageFileStream(UPDATESCHECKINGLOGFILENAME, FileMode.Open, isoFile);
                updatesCheckingLogXml = new XmlDocument();
                updatesCheckingLogXml.Load(updatesCheckingLogStream);
            }
            catch (Exception e)
            {
                //Try to delete the file, so a valid one will be recreated next time
                try
                {
                    updatesCheckingLogStream.Close();
                    isoFile.DeleteFile(UPDATESCHECKINGLOGFILENAME);
                    updatesCheckingLogStream = null;
                }
                catch { } //Fail silently if we can't delete the file.

                Exception ex = new UpdateFrameworkException(ERRORINUPDATESCHECKINGLOGFILE, e);
                Logger.Instance.Error(ERRORINUPDATESCHECKINGLOGFILE, e);
                throw ex;
            }
            finally
            {
                if (updatesCheckingLogStream != null)
                {
                    updatesCheckingLogStream.Close();
                }
            }

            return updatesCheckingLogXml;
        }

        /// <summary>
        /// Saves the updates checking log xml to the storage location
        /// </summary>
        /// <param name="xmlDoc">XmlDocument containing the update checking log</param>
        private static void SaveUpdatesCheckingLogXml(XmlDocument xmlDoc)
        {
            IsolatedStorageFile isoFile = GetStorageStore();
            IsolatedStorageFileStream updatesCheckingLogStream = null;

            try
            {
                //Saves the file to the isolate storage location
                updatesCheckingLogStream = new IsolatedStorageFileStream(UPDATESCHECKINGLOGFILENAME, FileMode.Create, FileAccess.ReadWrite, isoFile);
                xmlDoc.Save(updatesCheckingLogStream);
            }
            catch (IOException)
            {
                //Fail silently if we can't access the file.
                //Bug 1402
            }
            finally
            {
                if (updatesCheckingLogStream != null)
                {
                    updatesCheckingLogStream.Close();
                }
            }
          
        }

        /// <summary>
        /// Retrieves the isolated storage store to be used for storage
        /// </summary>
        /// <returns>Isolated storage store to be used for storage</returns>
        private static IsolatedStorageFile GetStorageStore()
        {
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForAssembly();

            return isoFile;

        }

        /// <summary>
        /// Creates a new blank updates checking log xml file
        /// </summary>
        private static void CreateUpdatesCheckingLogFile()
        {
            Logger.Instance.Info(LOGCREATINGUPDATECHECKINGFILE);

            IsolatedStorageFile isoFile = GetStorageStore();
            IsolatedStorageFileStream updatesCheckingLogStream=null;

            try
            {
                //Open an isolated storage stream and write a blank update checking log xml to it 
                updatesCheckingLogStream = new IsolatedStorageFileStream(UPDATESCHECKINGLOGFILENAME, FileMode.CreateNew, isoFile);

                XmlTextWriter xmlWriter = new XmlTextWriter(updatesCheckingLogStream, Encoding.UTF8);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(UPDATESCHECKINGLOGROOTELEMENT);

                xmlWriter.Flush();
                xmlWriter.Close();

            }
            catch (Exception e)
            {
                Logger.Instance.Error(ERRORCREATINGUPDATELOGFILE, e);
                throw;
            }
            finally
            {
                if (updatesCheckingLogStream != null)
                {
                    updatesCheckingLogStream.Close();
                }
            }
        }

        #endregion

        #region Xml Helper methods
        /// <summary>
        /// Creates a new xml attribute
        /// </summary>
        /// <param name="xmlDoc">XmlDocument that will contain the attribute</param>
        /// <param name="name">Name of attribute</param>
        /// <param name="value">Value of the attribute</param>
        /// <returns>Created XmlAttribute</returns>
        private static XmlAttribute CreateAttribute(XmlDocument xmlDoc, string name, object value)
        {
            XmlAttribute attribute = xmlDoc.CreateAttribute(name);
            attribute.Value = ProcessValueForXml(value);

            return attribute;
        }

        /// <summary>
        /// Converts an object to string and lower case. Used to keep consistency with attribute values on xml.
        /// </summary>
        /// <param name="value">Value to process. Must implement ToString().</param>
        /// <returns>Converted string</returns>
        private static string ProcessValueForXml(object value)
        {
            return value.ToString().ToLower(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Retrieves the node corresponding to a section from the updates checking log xml
        /// </summary>
        /// <param name="xmlDoc">XmlDocument containing the updates checking log xml</param>
        /// <param name="section">Name of the section to get node</param>
        /// <param name="isSchema">Indicates whether the section is a schema section or not</param>
        /// <returns>XmlNode from the specified section from the updates checking log, null if the section is not found</returns>
        private static XmlNode GetSectionNodeFromUpdatesCheckingLog(XmlDocument xmlDoc, string section, bool isSchema)
        {
            StringBuilder sectionXPath = new StringBuilder();
            sectionXPath.Append(UPDATESCHECKINGLOGSECTIONPARTIALXPATH);
            sectionXPath.Append(UPDATESCHECKINGLOGSECTIONNAMEELEMENT);
            sectionXPath.Append("=\"");
            sectionXPath.Append(ProcessValueForXml(section.Replace("\"", String.Empty)));
            sectionXPath.Append("\" and @");
            sectionXPath.Append(UPDATESCHECKINGLOGSECTIONISSCHEMAELEMENT);
            sectionXPath.Append("=\"");
            sectionXPath.Append(ProcessValueForXml(isSchema));
            sectionXPath.Append("\"]");

            XmlNode elementNode = xmlDoc.SelectSingleNode(sectionXPath.ToString());

            return elementNode;
        }


        /// <summary>
        /// Creates a new section node in the updates checking log xml
        /// </summary>
        /// <param name="xmlDoc">XmlDocument containing the updates checking log xml</param>
        /// <param name="section">Name of the section to create</param>
        /// <param name="isSchema">Indicates whether the section is a schema section or not</param>
        /// <param name="lastChecked">Last date/time updates were checked for the section</param>
        /// <returns>XmlNode representing the section</returns>
        private static XmlNode CreateSectionNode(XmlDocument xmlDoc, string section, bool isSchema, DateTime lastChecked)
        {
            XmlElement sectionElement = xmlDoc.CreateElement(UPDATESCHECKINGLOGSECTIONELEMENT);
            sectionElement.Attributes.Append(CreateAttribute(xmlDoc, UPDATESCHECKINGLOGSECTIONNAMEELEMENT, section));
            sectionElement.Attributes.Append(CreateAttribute(xmlDoc, UPDATESCHECKINGLOGSECTIONISSCHEMAELEMENT, isSchema));
            sectionElement.Attributes.Append(CreateAttribute(xmlDoc, UPDATESCHECKINGLOGSECTIONLASTCHECKEDELEMENT, lastChecked));
            xmlDoc[UPDATESCHECKINGLOGROOTELEMENT].AppendChild(sectionElement);

            return sectionElement;
        }
        #endregion

        #endregion

        #endregion

    }
}
