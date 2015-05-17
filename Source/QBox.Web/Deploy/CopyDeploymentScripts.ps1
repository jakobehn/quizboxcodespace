$sourcePath = "$(TF_BUILD_SOURCESDIRECTORY)\Source\QBox.Web\Deploy\*.ps1"
$destinationPath = "$Env:TF_BUILD_BINARIESDIRECTORY\Deploy"

Write-Verbose -Verbose ("Copying ps1 files " + $sourcePath + " to " + $destinationPath)

Copy-Item -Verbose $SourcePath $destinationPath

