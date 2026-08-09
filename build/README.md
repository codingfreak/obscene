# Build automation

This directory contains everything related to automated builds. The idea is that we publish obscene as a single file
which will contain the runtime and the custom assemblies. This is known as a self-contained executable.

## Usage

Just run `./build/publish.ps1`. After this you will get the executable in `/build/artifacts`.
