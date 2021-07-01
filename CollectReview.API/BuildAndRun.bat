cd %cd%
dotnet build --configuration Release
dotnet dev-certs https --trust
start dotnet run bin\Release\net5.0\CollectReview.API.dll
start http://localhost:5000/swagger/index.html