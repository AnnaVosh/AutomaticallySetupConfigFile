FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY . .
CMD ["dotnet", "ConsoleApp.dll"]

# Build image
# docker build . -t consoleapp

# Run container on Dev
# docker run -d --env ASPNETCORE_ENVIRONMENT=Dev --name ca consoleapp

# Run container on Testing
# docker run -d --env ASPNETCORE_ENVIRONMENT=Testing --name ca consoleapp