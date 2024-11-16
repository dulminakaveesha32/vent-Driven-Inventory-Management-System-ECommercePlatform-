# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything from the current directory to the container's working directory
COPY . . 

# Restore NuGet packages
RUN dotnet restore OrderService.csproj

# Build the app and publish it to the /app/publish directory
RUN dotnet publish OrderService.csproj -c Release -o /app/publish

# Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish .

# Expose the port the app will run on
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "OrderService.dll"]
