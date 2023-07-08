# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the source code and build the application
COPY . .
RUN dotnet build -c Release --no-restore

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish -c Release --no-build -o /app/publish

# Stage 3: Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
EXPOSE 80 443

# Copy the published output from the previous stage
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Keyify.Web.dll"]
