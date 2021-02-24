#Note: check .dockerignore file is your having any issues with copying content

FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY WebApplication/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
#EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Keyify.dll"]