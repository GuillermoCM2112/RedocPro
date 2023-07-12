#!/bin/bash

# Set environment variables copied from container
source /app/set_env.sh;

# Run your dotnet console app
dotnet run --no-restore --no-build --project /app/RedocPro/RedocPro.csproj --configuration Debug & sleep 20 && \
    echo "Run the API" && \
    PID=$(pgrep -f "dotnet run --no-restore --no-build --project /app/RedocPro/RedocPro.csproj --configuration Debug") && \
    files=$(find /app/swagger_files -name "swaggerv*.json") && \
    for file in $files; do \
      version=$(basename "$file" .json | sed 's/version_//') && \
      echo "Building and Redoc documentation $version" && \
      redoc-cli bundle "$file" --output "/app/docs/$version/index.html" ; \
      echo "Building the Postman collection version $version" && \
      openapi2postmanv2 -s "$file" -o "/app/docs/$version/postman_collection.json"  && \
        (Get-Content -Raw -Path "/app/docs/$version/postman_collection.json") | ForEach-Object {  $_ -replace '^', '{"collection":' } | Set-Content -Path "/app/Docs/$version/postman_collection.json"  && \
      Add-Content -Path "/app/docs/$version/postman_collection.json" -Value "}"; \ 
    done && \
    kill "$PID"