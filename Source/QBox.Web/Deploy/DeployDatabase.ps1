$path = ${env:ProgramFiles(x86)} + "\Microsoft SQL Server\120\DAC\bin\SqlPackage.exe”
$dacpacFullPath = join-path $applicationPath $DBdacpac

Write-Verbose -Verbose ("Running $path /Action:Publish /SourceFile:$dacpacFullPath /TargetDatabaseName:$DBDatabase /TargetServerName:$DBTargetServer /TargetUser:$DBUserName /TargetPassword:$DBPassword")

$output = & $path /Action:Publish /SourceFile:"$dacpacFullPath" /TargetDatabaseName:$DBDatabase /TargetServerName:$DBTargetServer /TargetUser:$DBUserName /TargetPassword:$DBPassword 2>&1 

Write-Verbose ($output | Out-String) -Verbose