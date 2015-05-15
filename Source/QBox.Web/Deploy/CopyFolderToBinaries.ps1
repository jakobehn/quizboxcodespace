param([string]$sourcePath)

if(-not $Env:TF_BUILD_BINARIESDIRECTORY)
{
	Write-Error "You must set the following environment variables"
	Write-Host '$Env:TF_BUILD_BINARIESDIRECTORY'
	exit 1
}

if (-not (Test-Path $Env:TF_BUILD_SOURCESDIRECTORY))
{
	Write-Error "TF_BUILD_SOURCESDIRECTORY does not exist: $Env:TF_BUILD_SOURCESDIRECTORY"
	exit 1
}

Write-Verbose -Verbose ("Copying " + $sourcePath + " to binaries folder " + $Env:TF_BUILD_SOURCESDIRECTORY)

Copy-Item -Verbose $SourcePath $Env:TF_BUILD_SOURCESDIRECTORY

