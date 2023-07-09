# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY Keyify.Web/*.csproj Keyify.Web/
COPY Keyify.Infrastructure/*.csproj Keyify.Infrastructure/
COPY Keyify.MusicTheory/*.csproj Keyify.MusicTheory/
COPY Keyify.Service/*.csproj Keyify.Service/
COPY Keyify.Services.Formatter/*.csproj Keyify.Services.Formatter/
COPY Keyify.Services.Models/*.csproj Keyify.Services.Models/

RUN dotnet restore Keyify.Web/Keyify.Web.csproj

# copy and build app and libraries
COPY Keyify.Web/ Keyify.Web/
COPY Keyify.Infrastructure/ Keyify.Infrastructure/
COPY Keyify.MusicTheory/ Keyify.MusicTheory/
COPY Keyify.Service/ Keyify.Service/
COPY Keyify.Services.Formatter/ Keyify.Services.Formatter/
COPY Keyify.Services.Models/ Keyify.Services.Models/

WORKDIR /source/Keyify.Web
RUN dotnet build -c release --no-restore

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
EXPOSE 80 443
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Keyify.Web.dll"]