$cwd = Get-Location

$root = Split-Path -Parent $PSScriptRoot
$src = $PSScriptRoot

#if (Test-Path env:APPVEYOR_BUILD_FOLDER) {
#    Set-Location $env:APPVEYOR_BUILD_FOLDER\src
#}

$opencover = (Resolve-Path "$src/packages/OpenCover.*/tools/OpenCover.Console.exe" -ErrorAction Stop).ToString()
$xunit = (Resolve-Path "$src/packages/xunit.runner.console.*/tools/xunit.console.exe" -ErrorAction Stop).ToString()
$reportgenerator = (Resolve-Path "$src/packages/ReportGenerator.*/tools/ReportGenerator.exe" -ErrorAction Stop).ToString()
$configuration = "Debug"

if (Test-Path env:CONFIGURATION) {
    $configuration = $env:CONFIGURATION
}

if (!(Test-Path "$root/CodeCoverage")) {
	mkdir "$root/CodeCoverage"
}

& $opencover `
 -target:$xunit "-targetargs:""$src\CoreLogic.Services.Wvs.Tests\bin\$configuration\CoreLogic.Services.Wvs.Tests.dll"" -nologo -noshadow" `
 -filter:"+[*]* -[*.Tests]* -[xunit*]*" `
 -excludebyattribute:"System.Diagnostics.DebuggerHiddenAttribute;System.Diagnostics.DebuggerNonUserCodeAttribute;System.Runtime.CompilerServices.CompilerGeneratedAttribute;System.CodeDom.Compiler.GeneratedCodeAttribute;System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute" `
 -coverbytest:* `
 -skipautoprops `
 -register:user `
 -output:"$root\CodeCoverage\OpenCover.xml"

if ($LASTEXITCODE -ne 0) {
    throw "Error generating code coverage."
}

& $reportgenerator `
 -reports:"$root\CodeCoverage\OpenCover.xml" `
 -targetdir:"$root\CodeCoverage\ReportGenerator" `
 -reporttypes:"Html;MHtml;badges"

if ($LASTEXITCODE -ne 0) {
    throw "Error generating code coverage reports."
}

#Set-Location $cwd