//Filename: ShieldButton.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 7/17/2007 10:53:18 AM
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
    /// Button with the capability of showing the Uac shield
    /// </summary>
    public class ShieldButton : System.Windows.Forms.Button
    {

        private bool _showShield;
        const uint BCM_SETSHIELD = 0x0000160C;
        private const string ERRORSHOWINGSHIELD="Error showing the Vista UAC shield icon";

        /// <summary>
        /// Creates a new instance of ShieldButton
        /// </summary>
        public ShieldButton()
            : base()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShowShield = true;
        }

        /// <summary>
        /// Indicates whether to show the shield logo or not
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031")]
        public bool ShowShield
        {
            get { return _showShield; }
            set
            {
                _showShield = value;
                try
                {
                    NativeMethods.SendMessage(new HandleRef(this, this.Handle), BCM_SETSHIELD, IntPtr.Zero, new IntPtr(_showShield ? 1 : 0));
                }
                catch(Exception e)
                {
                    Logger.Instance.Error(ERRORSHOWINGSHIELD,e);
                }
            }
        }

    }
}
