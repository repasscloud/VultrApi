#!/bin/zsh

# Clean up
rm -rf obj bin
dotnet clean

# Build
dotnet publish -c Release -p:PublishSingleFile=true --self-contained true

# Execute
./bin/Release/net6.0/*/publish/VultrApi