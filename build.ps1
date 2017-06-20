$ScriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$ConfigurationToBuild = "Debug"
$PlatformToBuild = "Any CPU"
$ToolsVersion = "/tv:14.0"
$MsBuildArguments = "/p:visualstudioversion=14.0"
$MSBuildExec = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
$projAbsPath = "$ScriptDir\TestFakes.sln"
$langversion = "Default"
$loggerArgs = "LogFile=$ScriptDir\buil.log;Verbosity=normal;Encoding=Unicode"

Write-Host "projAbsPath is $projAbsPath"
Write-Host "Clean"
& $MSBuildExec "$projAbsPath"  `
	/t:Clean `
	/p:SkipInvalidConfigurations=true `
	/p:Configuration="$ConfigurationToBuild" `
	/p:Platform="$PlatformToBuild" `
    /m:4 `
    /p:WarningLevel=0 `
    $ToolsVersion `
	$MsBuildArguments
if ($LastExitCode -ne 0) {
	throw "Project clean-up failed with exit code: $LastExitCode."
}

Write-Host "Build"
& $MSBuildExec $projAbsPath `
    /p:PreBuildEvent= `
    /p:PostBuildEvent= `
    /p:Configuration="$ConfigurationToBuild" `
    /p:Platform="$PlatformToBuild" `
	/p:langversion="$langversion" `
    /p:WarningLevel=0 `
    /p:GenerateSerializationAssemblies="Off" `
    /fl /flp:"$loggerArgs" `
    /m:4 `
    $ToolsVersion `
	$MsBuildArguments  
if ($LastExitCode -ne 0) {
    throw "Project build failed with exit code: $LastExitCode."
}