[CmdletBinding()]

param(
	[Parameter(Position=1)]
	[string]$workingDirectory
)

if( $workingDirectoru)
{
	Write-Verbose -Verbose "Setting working directory to " + $workingDirectory
	Set-Location $workingDirectory
}

qbox.api.deploy.cmd /Y