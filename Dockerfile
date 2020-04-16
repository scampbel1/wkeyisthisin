##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["Keyify.csproj", ""]
#RUN dotnet restore "./Keyify.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "Keyify.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Keyify.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Keyify.dll"]


#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
#
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#COPY ./src/AspMVC/publish .
#
#ENTRYPOINT ["dotnet", "Keyify.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Keyify.dll"]