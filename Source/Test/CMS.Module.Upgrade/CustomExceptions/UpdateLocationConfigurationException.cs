//Filename: UpdateLocationConfigurationErrorException.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 7/19/2007 10:50:33 AM
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
using System.Runtime.Serialization;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Represents an exception that happens when the update location is not properly configured
    /// </summary>
    [Serializable]
    public class UpdateLocationConfigurationException : System.Exception
    {
        #region Private Variables

        #endregion

        #region Constructors

        /// <summary>
        ///		UpdateLocationConfigurationException constructor
        /// </summary>
        public UpdateLocationConfigurationException()
            : base()
        {

        }

        /// <summary>
        ///		UpdateLocationConfigurationException constructor
        /// </summary>
        /// <param name="message">
        ///		The error message for the exception.
        /// </param>
        public UpdateLocationConfigurationException(string message)
            : base(message)
        {
        }


        /// <summary>
        ///		UpdateLocationConfigurationException constructor
        /// </summary>
        /// <param name="message">
        ///		The error message for the exception.
        /// </param>
        /// <param name="innerException">
        ///		The inner exception to include.
        /// </param>
        public UpdateLocationConfigurationException(string message, Exception innerException)
            :
            base(message, innerException)
        {
        }


        /// <summary>
        ///		UpdateLocationConfigurationException constructor
        /// </summary>
        /// <param name="info">
        ///		Serialization information.
        /// </param>
        /// <param name="context">
        ///		Stream context.
        /// </param>
        protected UpdateLocationConfigurationException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Public Methods

        #endregion

        #region Helper Functions

        #endregion

    }
}
