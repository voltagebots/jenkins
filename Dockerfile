# Dockerfile
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /usr/app

# copy csproj and restore as distinct layers
COPY . /usr/app/
RUN dotnet restore /usr/app/GrocedyAPI/GrocedyAPI.csproj
RUN curl -fsSLO https://get.docker/builds/Linux/x86_64/docker-17.04.0-ce.tgz \
  && tar xzvf docker-17.04.0-ce.tgz \
  && mv docker/docker /usr/local/bin \
  && rm -r docker docker-17.04.0-ce.tgz

# copy everything else and build app
RUN dotnet publish /usr/app/GrocedyAPI/GrocedyAPI.csproj -c Release -o out --no-restore
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /usr/app

# final stage/image
COPY --from=build /usr/app/out .
RUN ls /usr/app/GrocedyAPI
RUN ls
ENTRYPOINT ["dotnet", "GrocedyAPI.dll"]





