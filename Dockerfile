# Dockerfile
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /usr/app

# copy csproj and restore as distinct layers
COPY . /usr/app/
RUN dotnet restore /usr/app/GrocedyAPI/GrocedyAPI.csproj

# copy everything else and build app
RUN dotnet publish /usr/app/GrocedyAPI/GrocedyAPI.csproj -c Release -o out --no-restore
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /usr/app

# final stage/image
COPY --from=build /usr/app/out .
RUN ls /usr/app/GrocedyAPI
RUN ls
ENTRYPOINT ["dotnet", "GrocedyAPI.dll"]





