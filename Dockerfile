# base
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine

# args
ARG name_project=RedocPro

# files
WORKDIR /app
COPY . .

# dotnet
RUN dotnet tool install --global dotnet-dev-certs
RUN dotnet dev-certs https --clean && dotnet dev-certs https -ep /https/aspnetapp.pfx -p password --trust
RUN dotnet restore
RUN dotnet build --configuration Debug

# node js
RUN apk add --no-cache nodejs npm
RUN npm install -g redoc-cli@latest
RUN npm install -g openapi-to-postmanv2

# command
CMD dotnet run --no-restore --no-build --project RedocPro/RedocPro.csproj --configuration Debug & sleep 20 && \
    echo "Run the API" && \
    PID=$(pgrep -f "dotnet run --no-restore --no-build --project RedocPro/RedocPro.csproj --configuration Debug") && \
    files=$(find ./swagger_files -name "swaggerv*.json") && \
    for file in $files; do \
      version=$(basename "$file" .json | sed 's/version_//') && \
      echo "Building and Redoc documentation $version" && \
      redoc-cli bundle "$file" --output "./docs/$version/index.html" ; \
      echo "Building the Postman collection version $version" && \
      openapi2postmanv2 -s "$file" -o "./docs/$version/postman_collection.json"  && \
        (Get-Content -Raw -Path "./docs/$version/postman_collection.json") | ForEach-Object {  $_ -replace '^', '{"collection":' } | Set-Content -Path "./Docs/$version/postman_collection.json"  && \
      Add-Content -Path "./docs/$version/postman_collection.json" -Value "}"; \ 
    done && \
    kill "$PID"
