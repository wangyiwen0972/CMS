//Filename: UpdateLocationNotAvailabeException.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 7/16/2007 4:33:28 PM
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
    /// Represents an exception that happens when the update location is not available
    /// </summary>
    [Serializable]
    public class UpdateLocationNotAvailableException : System.Exception
    {
        #region Private Variables

        #endregion

        #region Constructors

        /// <summary>
        ///		UpdateLocationNotAvailableException constructor
		/// </summary>
        public UpdateLocationNotAvailableException()
            : base()
		{

		}

		/// <summary>
        ///		UpdateLocationNotAvailableException constructor
		/// </summary>
		/// <param name="message">
		///		The error message for the exception.
		/// </param>
		public UpdateLocationNotAvailableException(string message) : base(message)
		{
		}


		/// <summary>
        ///		UpdateLocationNotAvailableException constructor
		/// </summary>
		/// <param name="message">
		///		The error message for the exception.
		/// </param>
		/// <param name="innerException">
		///		The inner exception to include.
		/// </param>
        public UpdateLocationNotAvailableException(string message, Exception innerException)
            :
            base(message, innerException)
        {
        }


        		/// <summary>
        ///		UpdateLocationNotAvailableException constructor
		/// </summary>
		/// <param name="info">
		///		Serialization information.
		/// </param>
		/// <param name="context">
		///		Stream context.
		/// </param>
        protected UpdateLocationNotAvailableException(SerializationInfo info,
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
