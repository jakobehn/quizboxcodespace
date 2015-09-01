Param(
  [string]$buildNumber = $env:BUILD_BUILDNUMBER,
  [regex]$pattern = "\d+\.\d+\.\d+\.\d+",
  [string]$key,
  [string]$name
)
  
$version = "1.0"
if ($buildNumber -match $pattern -ne $true) {
    Write-Verbose "Could not extract a version from [$buildNumber] using pattern [$pattern]" -Verbose
} else {
    $version = $Matches[0]
}
 
Write-Verbose "Using args: begin /v:$version /k:$key /n:$name" -Verbose
$cmd = "c:\SonarQube\bin\MSBuild.SonarQube.Runner.exe"
 
& $cmd begin /v:$version /k:$key /n:$name