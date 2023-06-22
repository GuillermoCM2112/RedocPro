# Generar Changelog
git log --pretty=format:"- %s" > CHANGELOG.md

# Generación de Postman
npm i -g openapi-to-postmanv2
openapi2postmanv2 -s ./swagger_files/swagger.json -o ./postman_collection.json
(Get-Content -Raw -Path "./postman_collection.json") | ForEach-Object {
    $_ -replace '^', '{"collection":'
} | Set-Content -Path "./postman_collection.json"
Add-Content -Path "./postman_collection.json" -Value "}"

# Actualizar colección de Postman
npm install -g newman
curl -X PUT -H "Content-Type: application/json" -H "X-Api-Key: $env:POSTMAN_API_KEY" -d @(Get-Content -Raw -Path "./postman_collection.json") "https://api.postman.com/collections/27712020-db7469c0-0df4-4bb8-bf0f-c04c59dde495"

# Creación de Snippets
npm install -g openapi-snippet-cli
openapi-snippet ./swagger_files/swagger.json -o ./swagger.yaml
openapi-snippet ./swagger.yaml -t java -o ./swagger_files/swagger.json

# Actualizar de rama
git checkout main
if ((git status -s).Length -gt 0) {
    git stash
    git pull origin main
    git stash apply
    git add .
    git -c user.name="Guillermo Coba Montoya" -c user.email="guillermo.coba@digitalfemsa.com" commit -m "[SPPP-000]: Actualización de recursos"
    git push origin main
} else {
    Write-Output "No hay cambios para actualizar en la rama main"
}
