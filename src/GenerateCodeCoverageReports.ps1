$cwd = Get-Location

if (Test-Path env:APPVEYOR_BUILD_FOLDER) {
    Set-Location $env:APPVEYOR_BUILD_FOLDER\src
}

$opencover = (Resolve-Path "packages/OpenCover.*/tools/OpenCover.Console.exe" -ErrorAction Stop).ToString()
$xunit = (Resolve-Path "packages/xunit.runner.console.*/tools/xunit.console.exe" -ErrorAction Stop).ToString()
$reportgenerator = (Resolve-Path "packages/ReportGenerator.*/tools/ReportGenerator.exe" -ErrorAction Stop).ToString()
$configuration = "Debug"

if (Test-Path env:CONFIGURATION) {
    $configuration = $env:CONFIGURATION
}

if (!(Test-Path .\CodeCoverage)) {
	mkdir CodeCoverage
}

& $opencover `
 -target:$xunit "-targetargs:"".\CoreLogic.Services.Wvs.Tests\bin\$configuration\CoreLogic.Services.Wvs.Tests.dll"" -nologo -noshadow" `
 -filter:"+[*]* -[*.Tests]* -[xunit*]*" `
 -excludebyattribute:"System.Diagnostics.DebuggerHiddenAttribute;System.Diagnostics.DebuggerNonUserCodeAttribute;System.Runtime.CompilerServices.CompilerGeneratedAttribute;System.CodeDom.Compiler.GeneratedCodeAttribute;System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute" `
 -coverbytest:* `
 -skipautoprops `
 -register:user `
 -output:.\CodeCoverage\OpenCover.xml

& $reportgenerator `
 -reports:.\CodeCoverage\OpenCover.xml `
 -targetdir:.\CodeCoverage\ReportGenerator `
 -reporttypes:"Html;MHtml;badges"

Set-Location $cwd