function CreateWebSite([string]$siteName)
{
	Write-Verbose -verbose "Checking if $siteName already exists"
	if( Test-AzureName -Website "$siteName")
	{
		Write-Verbose -verbose "Site $siteName already exists"
	}
	else
	{
		Write-Verbose -verbose "Creating $siteName"
		New-AzureWebsite -Name "$siteName" -Location "North Europe"
	}
}

function PublishWebSite([string]$deployCmd)
{
	$pathToDeployCmd = join-path $applicationPath $deployCmd
	Write-Verbose -Verbose ("Running $pathToDeployCmd /y /m:$publishUrl /u:$publishUser /p:$publishPassword /a:Basic")
	$output = & $pathToDeployCmd /y /m:$publishUrl /u:$publishUser /p:$publishPassword /a:Basic  2>&1 

	Write-Verbose ($output | Out-String) -Verbose
}

$startTime = Get-Date
Write-Verbose -Verbose "Starting deployment at $startTime"

CreateWebSite "QBox-Dev"
CreateWebSite "QBoxApi-Dev"

Write-Verbose -Verbose 'Setting environment specific variables'

$paramFiles=get-childitem "$applicationPath" "*.SetParameters.xml" -rec -Verbose
foreach ($file in $paramFiles)
{
	Write-Verbose -Verbose ("Updating token __APIURL__ in file " + $file.PSPath + " with $APIURL")
	(Get-Content $file.PSPath) | 
	Foreach-Object {$_ -replace "__APIURL__", "$APIURL"} | 
	Set-Content $file.PSPath
}

PublishWebSite "QBox.Web..cmd"
PublishWebSite "QBox.Api..cmd"

$endTime = Get-Date
Write-Verbose -Verbose "Finished deployment at $endTime"

