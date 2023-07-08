#Note: check .dockerignore file is your having any issues with copying content

FROM  mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY */Keyify.Web.csproj ./ 
RUN dotnet restore

COPY . ./
RUN dotnet publish Keyify.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80 443
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Keyify.Web.dll"]