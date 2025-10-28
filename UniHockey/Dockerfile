FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /src/UniHockey

# Copy repository files into the image
COPY . .

# Publish the app into /app
RUN dotnet publish -c Release -o /app

WORKDIR /app

# Listen on port80
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "UniHockey.dll"]
