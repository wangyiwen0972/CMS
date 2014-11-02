using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Displays a dialog notifiying the user of updates available
    /// </summary>
    public partial class UpdatesAvailableDialog : Form
    {

        #region Constructors
        /// <summary>
        /// Creates a new instance of UpdatesAvailableDialog 
        /// </summary>
        /// <param name="message">Message to notify the users of the updates available</param>
        public UpdatesAvailableDialog(string titleText, string headerText, string messageText, string okButtonText,
            string cancelButtonText)
        {
            InitializeComponent();
            this.Text = titleText;
            this.Header.Text = headerText;
            this.MessageLabel.Text = messageText;
            this.OKButton.Text = okButtonText;
            this.CancelUpdateButton.Text = cancelButtonText;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the update available message to display
        /// </summary>
        public string Message
        {
            get
            {
                return MessageLabel.Text;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the click event for the Postpone button
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Events arguments</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        /// <summary>
        /// Handles the click event for the Install button
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Events arguments</param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            Accept();
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Closes the form returning DialogResult.Cancel
        /// </summary>
        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Closes the form returning DialogResult.Ok
        /// </summary>
        private void Accept()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}