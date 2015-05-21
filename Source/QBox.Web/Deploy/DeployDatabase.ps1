$path = ${env:ProgramFiles(x86)} + "\Microsoft SQL Server\120\DAC\bin\SqlPackage.exe”
$dacpacFullPath = join-path $applicationPath $dacpac

$output = & $path /Action:Publish /SourceFile:"$dacpacFullPath" /TargetDatabaseName:$Database /TargetServerName:$TargetServer /TargetUser:$UserName /TargetPassword:$Password 2>&1 

Write-Verbose ($output | Out-String) -Verbose