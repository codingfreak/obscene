Push-Location "$PSScriptRoot/../src/Ui/Ui.FormsApp"
try {
    dotnet publish -c Release -r win-x64 -o ../../../artifacts/publish --sc true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
}
finally {
    Pop-Location
}