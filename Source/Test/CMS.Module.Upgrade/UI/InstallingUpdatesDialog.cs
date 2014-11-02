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
    /// Displays an installing updates dialog with a progress bar
    /// </summary>
    public partial class InstallingUpdatesDialog : Form
    {
        #region Private Variables
        private BackgroundWorker worker = new BackgroundWorker();
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a new instance of InstallingUpdatesDialog
        /// </summary>
        public InstallingUpdatesDialog()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Creates a new instance of InstallingUpdatesDialog
        /// </summary>
        /// <param name="handler">Handler to the worker process to exceute while this form is diplayed</param>
        public InstallingUpdatesDialog(DoWorkEventHandler handler)
        {
            worker.DoWork += handler;
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the load event of this form
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void InstallingUpdatesDialog_Load(object sender, EventArgs e)
        {
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the worker completed event of the worker process associated with this form
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}