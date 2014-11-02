//Filename: UpdateResult.cs
//
//Description:
//<A brief description of the module, its purpose and functionality.>
//
//Creator: v-ragene
//Creation Date: 7/16/2007 1:23:49 PM
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

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    /// <summary>
    /// Represents the result of an update operation
    /// </summary>
    public enum UpdateResult
    {
        UpdatesInstalled = 0,
        NoUpdates,
        UserRefused,
        ErrorConnecting,
        Error,
        UserRefusedUacElevation,
        RequiredUpdatesFailed,
        Abort
    }
}
