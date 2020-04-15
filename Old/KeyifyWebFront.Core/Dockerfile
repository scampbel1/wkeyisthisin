FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /

COPY . .

RUN dotnet restore

RUN dotnet publish -o /publish

ENTRYPOINT ["dotnet", "KeyifyWebFront.Core.dll"]