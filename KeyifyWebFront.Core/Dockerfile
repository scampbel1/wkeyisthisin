FROM mcr.microsoft.com/dotnet/core/sdk:3.0

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet publish -o /publish

ENTRYPOINT ["dotnet", "/publish/KeyifyWebFront.Core.dll"]