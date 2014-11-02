//Filename: Helper.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 7/12/2007 1:30:40 PM
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
using System.Reflection;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Contains general helper methods to the update framework
    /// </summary>
    internal static class UpdateFrameworkHelper
    {
        #region Private Variables

        #endregion

        #region Constructors

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the path of the executing assembly
        /// </summary>
        /// <returns>Path of the executing assembly, excluding the filename</returns>
        internal static string GetExecutingAssemblyPath()
        {
            Assembly assm = Assembly.GetExecutingAssembly();
            string path = assm.Location;
            path = path.Substring(0, path.LastIndexOf("\\"));

            return path;
        }

        #endregion

        #region Helper Functions

        #endregion

    }
}
