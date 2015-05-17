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

Write-Verbose -verbose 'Publishing web site'
Publish-AzureWebsiteProject -Verbose -Name QBox-dev -Package $applicationPath\QBox.Web.zip

Write-Verbose -verbose 'Deployment done!'
