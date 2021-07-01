cd %cd%
dotnet build --configuration Release
dotnet dev-certs https --trust
start dotnet run bin\Release\net5.0\ExposeReview.API.dll
start "" http://localhost:5010/swagger/index.html