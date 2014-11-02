//Filename: UpdateFrameworkException.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 9/27/2007 4:02:45 PM
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
    /// Represents a generic update framework
    /// </summary>
    [Serializable]
    public class UpdateFrameworkException : System.Exception
    {
        #region Private Variables

        #endregion

        #region Constructors

        /// <summary>
        ///		UpdateFrameworkException constructor
        /// </summary>
        public UpdateFrameworkException()
            : base()
        {

        }

        /// <summary>
        ///		UpdateFrameworkException constructor
        /// </summary>
        /// <param name="message">
        ///		The error message for the exception.
        /// </param>
        public UpdateFrameworkException(string message)
            : base(message)
        {
        }


        /// <summary>
        ///		UpdateFrameworkException constructor
        /// </summary>
        /// <param name="message">
        ///		The error message for the exception.
        /// </param>
        /// <param name="innerException">
        ///		The inner exception to include.
        /// </param>
        public UpdateFrameworkException(string message, Exception innerException)
            :
            base(message, innerException)
        {
        }


        /// <summary>
        ///		UpdateFrameworkException constructor
        /// </summary>
        /// <param name="info">
        ///		Serialization information.
        /// </param>
        /// <param name="context">
        ///		Stream context.
        /// </param>
        protected UpdateFrameworkException(SerializationInfo info,
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
