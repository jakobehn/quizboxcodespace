$startTime = Get-Date
Write-Verbose -Verbose "Starting deployment at $startTime"

Write-Verbose -verbose "Checking if site already exists"
if( Test-AzureName -Website QBox-dev)
{
	Write-Verbose -verbose 'Site already exists'
}
else
{
	Write-Verbose -verbose 'Creating web site'
	New-AzureWebsite -Name QBox-dev -Location "North Europe"
}

Write-Verbose -verbose "Checking if api site already exists"
if( Test-AzureName -Website QBoxApi-dev)
{
	Write-Verbose -verbose 'Api site already exists'
}
else
{
	Write-Verbose -verbose 'Creating api site'
	New-AzureWebsite -Name QBoxApi-dev -Location "North Europe"
}

Write-Verbose -verbose 'Publishing api site'
Publish-AzureWebsiteProject -Verbose -Name QBoxApi-dev -Package $applicationPath\QBox.Api.zip

$endTime = Get-Date
Write-Verbose -Verbose "Finished deployment at $endTime"

