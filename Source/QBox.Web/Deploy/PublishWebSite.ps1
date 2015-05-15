if( Test-AzureName -Website QBox-dev)
{
	Write-Verbose 'Site already exists'
}
else
{
	New-AzureWebsite -Name QBox-dev -Location "North Europe"
}
Publish-AzureWebsiteProject -Name QBox-dev -Package $applicationPath\QBox.Web.zip
