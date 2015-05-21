function CreateWebSite([string]$site)
{
	Write-Verbose -verbose "Checking if $site already exists"
	if( Test-AzureName -Website "$site")
	{
		Write-Verbose -verbose "Site $site already exists"
	}
	else
	{
		Write-Verbose -verbose "Creating $site"
		New-AzureWebsite -Name "$site" -Location "North Europe"
	}
}

function PublishWebSite([string]$deployCmd, [string]$pubUrl, [string]$usr, [string]$pwd)
{
	$pathToDeployCmd = join-path $applicationPath $deployCmd
	Write-Verbose -Verbose ("Running $pathToDeployCmd /y /m:$pubUrl /u:$usr /p:$pwd /a:Basic")
	$output = & $pathToDeployCmd /y /m:$pubUrl /u:$usr /p:$pwd /a:Basic  2>&1 

	Write-Verbose ($output | Out-String) -Verbose
}

$startTime = Get-Date
Write-Verbose -Verbose "Starting deployment at $startTime"

CreateWebSite "$siteName"


Write-Verbose -Verbose 'Setting environment specific variables'

$paramFiles=get-childitem "$applicationPath" "*.SetParameters.xml" -rec -Verbose
foreach ($file in $paramFiles)
{
	(Get-Content $file.PSPath) | 
	Foreach-Object {
		$_ -replace "__APIURL__", "$APIURL"
		$_ -replace "__DBTargetServer__", "$DBTargetServer"
		$_ -replace "__DBDatabase__", "$DBDatabase"
		$_ -replace "__DBUserName__", "$DBUserName"
		$_ -replace "__DBPassword__", "$DBPassword"

	} | 
	Set-Content $file.PSPath
}

PublishWebSite "$publishProfile.deploy.cmd" $publishUrl $publishUser $publishPassword

$endTime = Get-Date
Write-Verbose -Verbose "Finished deployment at $endTime"

