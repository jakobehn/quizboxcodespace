Write-Verbose "Checking if site already exists"
if( Test-AzureName -Website QBox-dev)
{
	Write-Verbose 'Site already exists'
}
else
{
	Write-Verbose 'Creating web site'
	New-AzureWebsite -Name QBox-dev -Location "North Europe"
}

Write-Verbose 'Publishing web site'
Publish-AzureWebsiteProject -Name QBox-dev -Package $applicationPath\QBox.Web.zip

Write-Verbose 'Deployment done!'
