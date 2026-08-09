if (!$env:CERT_PASSWORD) {
    throw "CERT_PASSWORD env variable not set."
}
Push-Location "$PSScriptRoot/.."
try {
    $cert = New-SelfSignedCertificate `
        -Type CodeSigningCert `
        -Subject "CN=codingfreaks" `
        -KeyAlgorithm RSA -KeyLength 3072 `
        -HashAlgorithm SHA256 `
        -CertStoreLocation Cert:\CurrentUser\My `
        -NotAfter (Get-Date).AddYears(3)
    # 2. Export to PFX with a password
    $pw = ConvertTo-SecureString -String $env:CERT_PASSWORD -Force -AsPlainText
    Export-PfxCertificate -Cert $cert -FilePath .\obscene.pfx -Password $pw
}
catch {
    Pop-Location
}