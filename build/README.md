# Build automation

This directory contains everything related to automated builds. The idea is that we publish obscene as a single file
which will contain the runtime and the custom assemblies. This is known as a self-contained executable.

## Usage

First you need to set the value for the signing key file to an env-var by `$env:CERT_PASSWORD='YOUR-PASSWORD'`. Also you need to recover your PFX file from the secret storage.

Just run `./build/publish.ps1`. After this you will get the executable in `/build/artifacts`.
