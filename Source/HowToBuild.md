Readme for Building the eBay SDK for .NET
-----------------------------------------

To build the SDK, please use the sections below, in the order they are presented.

References to "SDKInstallDir" and to "SDK Installation Directory" refer to the top-level SDK directory (for example, C:\\Program Files\\eBay\\eBay .NET SDK v615 Full Release).

Building the SDK initially requires that you:

*   Install Microsoft Visual Studio(VS2005 or VS2008) on your computer
*   Delete any bin and obj folders that were created with previous versions of Microsoft Visual Studio

### Generate a Strong Name Key

1.  Confirm that your Path variable includes the folder of the Microsoft .NET Framework Strong Name Utility (e.g., C:\\Program Files\\Microsoft Visual Studio 8\\SDK\\v2.0\\Bin).
  
  
4.  Run the following BAT file:  
    SDKInstallDir\\Source\\GenSNKey.bat  
      
    This will generate a Strong Name key to sign the generated components. If you prefer not to use GenSNKey.bat, then in a Command window, at \\SDKInstallDir\\Source, run the following command:  
    `sn -k eBay.snk`.
  
  

### Use a WSDL to Generate Code Stubs

1.  Follow the code generation instructions in the Readme file in the following folder: SDKInstallDir\\Tools.
  
  
4.  Confirm that code stubs were generated at SDKInstallDir\\Source\\eBay.Service.SDK\\Core\\Soap\\WebService.cs.

Corresponding NAnt command: **nant GenProxy**

### Use the Solution File to Build the SDK

Note: These instructions assume you are creating a Release build. If you are creating a Debug build, please substitute "Debug" for "Release."

1.  Use Microsoft Visual Studio to open DOTNET.SOAP.sln (located at SDKInstallDir\\Source\\DOTNET.SOAP.sln). If prompted, use the Visual Studio Conversion Wizard to update the solution and create backup files.
  
  
4.  Build the eBay.Service project.
  
  
7.  Confirm that the eBay.Service.dll file was generated in SDKInstallDir\\Source\\eBay.Service.SDK\\bin\\Release.
  
  
10.  Confirm that the _eBay.Service_ reference in the eBay.Service.SDK.Attribute and Helper projects is correct. It should point to SDKInstallDir\\Source\\eBay.Service.SDK\\bin\\Release\\eBay.Service.dll.  
      
    If the Reference is incorrect, update it to point to SDKInstallDir\\Source\\eBay.Service.SDK\\bin\\Release\\eBay.Service.dll.
  
  
13.  Build the whole DOTNET.SOAP solution.  
    

Corresponding NAnt command: **nant BuildSourceInRelease**

### Copy the Built Files to the SDK Installation Directory

1.  In the SDKInstallDir\\Source folder, run CopyRelease.bat.  
      
    
2.  Use date stamps to confirm that the recently-built files were copied to the SDK installation directory.
  

Corresponding NAnt command: **nant CopyLibraryInRelease**

Note: SDK samples (located at SDKInstallDir\\Samples) reference the built files in the SDK installation directory.