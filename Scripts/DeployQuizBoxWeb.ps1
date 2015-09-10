[CmdletBinding()]

param(
	[Parameter(Position=1)]
	[string]$publishUrl,
		[Parameter(Position=2)]
	[string]$userName,
		[Parameter(Position=3)]
	[string]$password
)

.\QBox.Web.deploy.cmd /Y "/M:$publishUrl" /u:$userName /p:$password /a:Basic

