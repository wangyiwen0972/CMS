//Filename: STAExceptionMessageBox.cs
//
//Description:
//STAExceptionMessageBox is a wrapper class for Sql Server Exception Message Box.
//
//Creator: v-ragene
//Creation Date: 7/19/2007 11:22:51 AM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/09/07     v-ragene        Initial Version.
//                                          Copied this file from Framework.
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.MessageBox;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;


namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    ///     STA Message Dialog is a wrapper class for Sql Server
    ///     Exception Message Box. It handles running the message
    ///     box in a Single Thread Appartment requirement.
    /// </summary>
    public class StaExceptionMessageBox
    {
        #region Private Variables
        const string EXCEPTIONDIALOGBOXCAPTION = "DxEditor. Error processing updates.";
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of StaExceptionMessageBox
        /// </summary>
        private StaExceptionMessageBox()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Display a message box with exception information.
        /// </summary>
        /// <param name="exception">
        ///     The exception to show.
        /// </param>
        public static void Show(Exception exception)
        {
            //Create a new thread to execute ExceptionMessageBox logic
            //since it needs to be run in a STA ApartmentState (due to
            //need of Copying to the Clipboard)

            ThreadStart threadStart = delegate { STAWrapper.ShowExceptionDialog(exception); };
            Thread staThread = new Thread(threadStart);

            //Set the thread to run in a Single Threaded Appartment required 
            //when ExceptionMessageBox access the clipboard.
            staThread.SetApartmentState(ApartmentState.STA);

            //Tells the OS to start running the thread.
            staThread.Start();

            //Block the calling thread, until this thread terminates.
            staThread.Join();
        }

        /// <summary>
        ///     Sql Message Box's Data property requires having a
        ///     "AdditionalInformation." prefix inorder for it to
        ///     display the Addintional Info data.
        /// </summary>
        /// <param name="key">
        ///     The key to concatenate with the required prefix
        /// </param>
        /// <returns>
        ///     The prefixed key.  Returns string.Empty if error occurred.  
        /// </returns>
        public static string ConstructAdditionalInfoData(string key)
        {
            string property = String.Concat(UpdateFrameworkConstants.PREFIXADDITIONALINFO, key);
            return property;
        }

        /// <summary>
        ///     Sql Message Box's Data property requires having a
        ///     "HelpLink.Advanced." prefix inorder for it to display
        ///     the Help Link information.
        /// </summary>
        /// <param name="key">
        ///     The key to concatenate with the required prefix
        /// </param>
        /// <returns>
        ///     The prefixed key.  Returns string.Empty if error occurred.
        /// </returns>
        public static string ConstructHelpLinkData(string key)
        {
            string property = String.Concat(UpdateFrameworkConstants.PREFIXHELPLINK, key);
            return property;
        }

        #endregion

        #region Helper Functions

        #endregion

        #region Private classes

        private class WindowWrapper : IWin32Window
        {
            private IntPtr _hwnd;

            /// <summary>
            ///     Default Constructor.
            /// </summary>
            /// <param name="handle">
            ///     The Window Handle.
            /// </param>
            public WindowWrapper(IntPtr handle)
            {
                _hwnd = handle;
            }

            /// <summary>
            /// Gets the window handle.
            /// </summary>
            public IntPtr Handle
            {
                get { return _hwnd; }
            }
        }

        private static class STAWrapper
        {
            /// <summary>
            ///     Displays a message dialog about the exception.
            /// </summary>
            /// <param name="exception">Exception to show on the dialog</param>
            public static void ShowExceptionDialog(Exception exception)
            {
                if (exception == null)
                    return;

                ExceptionMessageBox sqlMessageBox = new ExceptionMessageBox(exception);
                sqlMessageBox.Symbol    = ExceptionMessageBoxSymbol.Error;
                sqlMessageBox.Caption   = EXCEPTIONDIALOGBOXCAPTION;

                WindowWrapper ownerWindow;

                ownerWindow = new WindowWrapper(Process.GetCurrentProcess().MainWindowHandle);
                sqlMessageBox.Show(ownerWindow);
            }
        }
        #endregion

    }

}
