if (!$env:CERT_PASSWORD) {
    throw "CERT_PASSWORD env variable not set."
}
Push-Location "$PSScriptRoot/../src/Ui/Ui.FormsApp"
try {
    dotnet publish -c Release -r win-x64 `
        -o ../../../build/artifacts `
        --sc true `
        /p:PublishSingleFile=true `
        /p:IncludeNativeLibrariesForSelfExtract=true `
        /p:SigningCert=../../../obscene.pfx `
        /p:SigningPassword=$env:CERT_PASSWORD
    Remove-Item ../../../build/artifacts/*.pdb
}
finally {
    Pop-Location
}