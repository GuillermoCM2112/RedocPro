#!/bin/bash

# Set environment variables copied from container
source /app/set_env.sh;

echo "#############################################################"
echo "Running the API"
dotnet run --no-restore --no-build --project /app/RedocPro/RedocPro.csproj --configuration Debug &
sleep 20
PID=$(pgrep -f "dotnet run --no-restore --no-build --project /app/RedocPro/RedocPro.csproj --configuration Debug")
files=$(find /app/swagger_files -name "swaggerv*.json")
for file in $files; do
  version=$(basename "$file" .json | sed 's/version_//')
  echo "#############################################################"
  echo "Building and Redoc documentation $version"
  redoc-cli bundle "$file" --output "/app/docs/$version/index.html"
  echo "#############################################################"
  echo "Building the Postman collection version $version "
  openapi2postmanv2 -s "$file" -o "/app/docs/$version/postman_collection.json" 
  content=$(cat "/app/docs/$version/postman_collection.json")
  content=$(echo "$content" | sed '1s/^/{"collection":/')
  content=$(echo "$content" | sed '$s/$/}/')
  echo "$content" > "/app/docs/$version/postman_collection.json"
done
echo "#############################################################"
echo "Stopping the API"
kill "$PID"