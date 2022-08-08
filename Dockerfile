FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /source
COPY . .
RUN dotnet restore "./BooksServer.API/BooksServer.API.csproj" --disable-parallel
RUN dotnet publish "./BooksServer.API/BooksServer.API.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "BooksServer.API.dll","--urls=http://+:5000"]