@echo off

::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Set all variables to be local
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
setlocal

echo --------------------------------------------------------------------------
echo Info: Building Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll
echo Type: %_buildType%
echo --------------------------------------------------------------------------
echo.


::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Create variables
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
set _updateShare="C:\DxEditor Update Share"


::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Build the Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
echo --------------------------------------------------------------------------
echo Info: Cleaning Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll
echo --------------------------------------------------------------------------
msbuild .\UpdateFramework\Main\UpdateFramework.csproj /t:Clean /p:Configuration=%_buildType% /nologo
echo.

echo --------------------------------------------------------------------------
echo Info: Building Build the Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll
echo --------------------------------------------------------------------------
msbuild .\UpdateFramework\Main\UpdateFramework.csproj /t:Build /p:Configuration=%_buildType% /nologo
echo.

echo --------------------------------------------------------------------------
echo Info: Copying the Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll
echo --------------------------------------------------------------------------
copy .\UpdateFramework\Main\bin\%_buildType%\Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll %_targetPath%\Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll
copy .\UpdateFramework\Main\bin\%_buildType%\Microsoft.STB.WSDUA.DxEditor.UpdateFramework.pdb %_targetPath%\Microsoft.STB.WSDUA.DxEditor.UpdateFramework.pdb
copy .\UpdateFramework\Main\bin\%_buildType%\Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll.config %_targetPath%\Microsoft.STB.WSDUA.DxEditor.UpdateFramework.dll.config



::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Remove an existing update share directory
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
echo --------------------------------------------------------------------------
echo Info: Removing the update share directory
echo --------------------------------------------------------------------------
IF EXIST %_updateShare% rmdir %_updateShare% /s /q
echo.

::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Create the update share directory
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
echo --------------------------------------------------------------------------
echo Info: Creating the update share directory
echo       - %_updateShare%
echo --------------------------------------------------------------------------
mkdir %_updateShare%
mkdir %_updateShare%\Tools
mkdir %_updateShare%\"Data Source Provider"
echo.


echo --------------------------------------------------------------------------
echo Info: Copying version files
echo --------------------------------------------------------------------------
copy .\UpdateFramework\Main\version.xml %_targetPath%\version.xml
copy .\UpdateFramework\Main\version.xml %_targetPath%\Tools\version.xml
copy .\UpdateFramework\Main\version.xml %_targetPath%\Schemas\DDUE\version.xml
copy .\UpdateFramework\Main\version.xml %_targetPath%\"Data Source Provider"\version.xml
echo.


echo --------------------------------------------------------------------------
echo Info: updating update share
echo --------------------------------------------------------------------------
copy .\UpdateFramework\Main\UpdateManifest.xml %_updateShare%\UpdateManifest.xml
copy .\UpdateFramework\Main\UpdateManifest.xml %_updateShare%\Tools\UpdateManifest.xml
copy .\UpdateFramework\Main\UpdateManifest.xml %_updateShare%\"Data Source Provider\UpdateManifest.xml"

echo.
echo.