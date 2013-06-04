# Helper script for those who want to run psake without importing the module.
# Example:
# .\psake.ps1 "default.ps1" "BuildHelloWord" "4.0" 

# Must match parameter definitions for psake.psm1/invoke-psake 
# otherwise named parameter binding fails
param(
    [Parameter(Position=0,Mandatory=0)]
    [string]$buildFile = 'build.ps1',
    [Parameter(Position=1,Mandatory=0)]
    [string[]]$taskList = @(),
    [Parameter(Position=2,Mandatory=0)]
    [string]$framework,
    [Parameter(Position=3,Mandatory=0)]
    [switch]$docs = $false,
    [Parameter(Position=4,Mandatory=0)]
    [System.Collections.Hashtable]$parameters = @{},
    [Parameter(Position=5, Mandatory=0)]
    [System.Collections.Hashtable]$properties = @{},
    [Parameter(Position=6, Mandatory=0)]
    [alias("init")]
    [scriptblock]$initialization = {},
    [Parameter(Position=7, Mandatory=0)]
    [switch]$nologo = $false,
    [Parameter(Position=8, Mandatory=0)]
    [switch]$help = $false,
    [Parameter(Position=9, Mandatory=0)]
    [string]$scriptPath = $(Split-Path -parent $MyInvocation.MyCommand.path)
)

$currentThread = [System.Threading.Thread]::CurrentThread
$invariantCulture = [System.Globalization.CultureInfo]::InvariantCulture
$currentThread.CurrentCulture = $invariantCulture
$currentThread.CurrentUICulture = $invariantCulture

# '[p]sake' is the same as 'psake' but $Error is not polluted
remove-module [p]sake
import-module psake
if ($help) {
  Get-Help Invoke-psake -full
  return
}

if (-not(test-path $buildFile)) {
    $absoluteBuildFile = (join-path $scriptPath $buildFile)
    if (test-path $absoluteBuildFile) {
        $buildFile = $absoluteBuildFile
    }
} 

invoke-psake $buildFile $taskList $framework $docs $parameters $properties $initialization $nologo
