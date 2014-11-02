//Filename: NativeMethods.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 7/17/2007 11:00:15 AM
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
using System.Runtime.InteropServices;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Contains all references to native methods used in the Update Framework
    /// </summary>
    internal static class NativeMethods
    {
        #region Private Variables

        #endregion

        #region Constructors

        #endregion

        #region Public Methods
        /// <summary>
        ///  Sends the specified message to a window or windows. It calls the window procedure for the specified window and does not return until the window procedure has processed the message. 
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// Microsoft Windows Vista and later. Message sending is subject to User Interface Privilege Isolation (UIPI). The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// <param name="Msg">Specifies the message to be sent</param>
        /// <param name="wParam">Specifies additional message-specific information</param>
        /// <param name="lParam">Specifies additional message-specific information</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static internal extern IntPtr SendMessage(HandleRef hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        #endregion

        #region Helper Functions

        #endregion

    }
}
