# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copy project file and restore dependencies
COPY ["ProductService.csproj", "ProductService/"]
RUN dotnet restore "ProductService/ProductService.csproj"

# Copy the rest of the application files
COPY / ProductService
WORKDIR /src/ProductService

# Build and publish the app
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Build a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/publish .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "ProductService.dll"]
