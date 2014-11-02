//Filename: Constants.cs
//
//Description:
//Contains the constants used by the updateframework project
//
//Creator: v-ragene
//Creation Date: 5/22/2007 11:52:46 AM
//--------------------------------------------------------------------------
//Change History:
//
//Version       Date        Author          Description
//
//  1           5/22/07     v-ragene         Initial Version.
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    public static class UpdateFrameworkConstants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string UPDATEMANIFESTFILENAME="UpdateManifest.xml";
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string LOCALVERSIONMANIFESTFILENAME="Version.xml";
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string LOCALINTALLATIONSCHEMASFOLDERNAME ="Schemas";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string SCHEMASFOLDERNAME = "Schemas";

        //Sections
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string CORESECTIONNAME = "Core";
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string DATASOURCEPROVIDERSECTIONNAME = "Data Source Provider";
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string TOOLSSECTIONNAME = "Tools";
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string DXSTUDIOSCHEMASSECTIONNAME = "DxStudio Schemas";

        //Exception Handling
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string PREFIXADDITIONALINFO = "AdvancedInformation.";
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string PREFIXHELPLINK = "HelpLink.Advanced.";

        //Used to be passed as a parameter from the launcher to uacoperations
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string LAUNCHERCODE = "AB2AFFBD39784ad2B2DDA4CAD9D65EDC";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const string ERRORCONNECTINGTOUPDATELOCATIONMESSAGE = "Unable to check for updates. Error connecting to update location.";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const int DAYSTOKEEPFILESINLOG = 30;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const int UPDATEFREQUENCYMAX = 10080;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1705:LongAcronymsShouldBePascalCased", MessageId = "Member")]
        public const int UPDATEFREQUENCYMIN = 0;
    }
}
