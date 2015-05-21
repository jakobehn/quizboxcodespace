#test comment
function CreateBinDirectory()
{
	# If binary output directory exists, make sure it is empty
	# If it does not exist, create one
	# (this happens when 'Clean workspace' build process parameter is set to True)
	if ([IO.Directory]::Exists($Env:TF_BUILD_BINARIESDIRECTORY)) 
	{ 
		$DeletePath = $Env:TF_BUILD_BINARIESDIRECTORY + "\*"
		Write-Verbose "$Env:TF_BUILD_BINARIESDIRECTORY exists."
		if(-not $Disable)
		{
			Write-Verbose "Ready to delete $DeletePath"
			Remove-Item $DeletePath -recurse
			Write-Verbose "Files deleted."
		}	
	} 
	else
	{ 
		Write-Verbose "$Env:TF_BUILD_BINARIESDIRECTORY does not exist."
		
		if(-not $Disable)
		{
			Write-Verbose "Ready to create it."
			[IO.Directory]::CreateDirectory($Env:TF_BUILD_BINARIESDIRECTORY) | Out-Null
			Write-Verbose "Directory created."
		}
	} 
}

CreateBinDirectory

$sourcePath = "$Env:TF_BUILD_SOURCESDIRECTORY\Source\QBox.Web\bin\_PublishedWebsites\*.*"
$destinationPath = "$Env:TF_BUILD_BINARIESDIRECTORY\"

Write-Verbose -Verbose ("Copying web deploy package files " + $sourcePath + " to " + $destinationPath)
Copy-Item -Verbose $sourcePath $destinationPath -Recurse

$sourcePath = "$Env:TF_BUILD_SOURCESDIRECTORY\Source\QBox.Api\bin\_PublishedWebsites\*.*"
$destinationPath = "$Env:TF_BUILD_BINARIESDIRECTORY\"

Write-Verbose -Verbose ("Copying web deploy package files " + $sourcePath + " to " + $destinationPath)
Copy-Item -Verbose $sourcePath $destinationPath -Recurse

#Copy deployment script
$sourcePath = "$Env:TF_BUILD_SOURCESDIRECTORY\Source\QBox.Web\Deploy\*.ps1"
$destinationPath = "$Env:TF_BUILD_BINARIESDIRECTORY\QBox.Web_Package\"
Write-Verbose -Verbose ("Copying ps1 files " + $sourcePath + " to " + $destinationPath)
Copy-Item -Verbose $sourcePath $destinationPath -Recurse

$sourcePath = "$Env:TF_BUILD_SOURCESDIRECTORY\Source\QBox.Web\Deploy\*.ps1"
$destinationPath = "$Env:TF_BUILD_BINARIESDIRECTORY\QBox.Api_Package\"
Write-Verbose -Verbose ("Copying ps1 files " + $sourcePath + " to " + $destinationPath)
Copy-Item -Verbose $sourcePath $destinationPath -Recurse

$dacpacDestinationPath = Join-Path $Env:TF_BUILD_BINARIESDIRECTORY "QBox.Database\"

if (-not [IO.Directory]::Exists($dacpacDestinationPath) )
{
		[IO.Directory]::CreateDirectory($dacpacDestinationPath) | Out-Null
}

$sourcePath = "$Env:TF_BUILD_SOURCESDIRECTORY\Source\QBox.Web\Deploy\DeployDatabase.ps1"
Write-Verbose -Verbose ("Copying ps1 files " + $sourcePath + " to " + $dacpacDestinationPath)
Copy-Item -Verbose $sourcePath $dacpacDestinationPath -Recurse


$sourcePath = "$Env:TF_BUILD_SOURCESDIRECTORY\Source\QBox.Database\bin\release\*.dacpac"
Write-Verbose -Verbose ("Copying ps1 files " + $sourcePath + " to " + $dacpacDestinationPath)
Copy-Item -Verbose $sourcePath $dacpacDestinationPath -Recurse
