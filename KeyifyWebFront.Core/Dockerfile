FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["KeyifyWebFront.Core/KeyifyWebFront.Core.csproj", "KeyifyWebFront.Core/"]
RUN dotnet restore "KeyifyWebFront.Core/KeyifyWebFront.Core.csproj"
COPY . .
WORKDIR "/src/KeyifyWebFront.Core"
RUN dotnet build "KeyifyWebFront.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KeyifyWebFront.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KeyifyWebFront.Core.dll"]