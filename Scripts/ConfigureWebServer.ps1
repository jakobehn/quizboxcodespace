Configuration QuizBoxApiWebSite
{
	Import-DSCResource -ModuleName xWebAdministration

	Node $env:COMPUTERNAME
	{
		WindowsFeature WebServerRole
		{
			Ensure = "Present" 
			Name = "Web-Server"
		}

		WindowsFeature AspNet45
		{
			Ensure = "Present" 
			Name = "Web-Asp-Net45"
		}

		xWebAppPool QuizBoxApiAppPool
		{
			Ensure = "Present"
			Name = "QuizBoxApi"
			State = "Started"
			DependsOn = "[WindowsFeature]WebServerRole"
		}


		xWebsite QuizBoxApiSite
		{
			Ensure = "Present"
			Name = "QuizBoxApi"
			PhysicalPath = $DestinationPath
			State = "Started"
			ApplicationPool = "QuizBoxApi"
			BindingInfo     = MSFT_xWebBindingInformation 
			{  
				Protocol              = "HTTP" 
				Port                  = 80
			}  
 
			DependsOn = "[WindowsFeature]WebServerRole"
		}
   }
}
#Copy DSC modules into system modules folder
$customModulesDirectory = Join-Path $env:SystemDrive "\Program Files\WindowsPowerShell\Modules"
$customModuleSrc = Join-Path $applicationPath "xWebAdministration"

Copy-Item -Verbose -Force -Recurse -Path $customModuleSrc -Destination $customModulesDirectory
QuizBoxApiWebSite -Verbose