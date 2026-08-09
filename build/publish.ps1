Push-Location "$PSScriptRoot/../src/Ui/Ui.FormsApp"
try {
    dotnet publish -c Release -r win-x64 -o ../../../build/artifacts --sc true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
    Remove-Item ../../../build/artifacts/*.pdb
}
finally {
    Pop-Location
}