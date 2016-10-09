
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
			DependsOn = "[WindowsFeature]WebServerRole"
		}

		WindowsFeature WebMgmtConsole
		{
			Name = "Web-Mgmt-Console"
			Ensure = "Present"
			DependsOn = "[WindowsFeature]WebServerRole"
		}

		xWebAppPool QuizBoxApiAppPool
		{
			Ensure = "Present"
			Name = "QuizBoxApi"
			State = "Started"
			DependsOn = "[WindowsFeature]AspNet45"
		}

		File WebSiteRoot 
		{
			Type = 'Directory'
			DestinationPath = $DestinationPath
			Ensure = "Present"
			DependsOn = "[xWebAppPool]QuizBoxApiAppPool"
		}

		xWebsite StopDefaultSite
		{
			Ensure = "Present"
			Name = "Default Web Site"
			PhysicalPath = "C:\inetpub\wwwroot"
			State = "Stopped"
			DependsOn = "[File]WebSiteRoot"
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
 
			DependsOn = "[xWebsite]StopDefaultSite"
		}
   }
}
QuizBoxApiWebSite -Verbose