#----------------------------------------------------------------------
# STAGE 1: Build & Publish (Uses the large SDK image)
#----------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 1. Set the working directory inside the container for the source code
# We use /src/UniHockey as the project's root for easier restore/publish.
WORKDIR /src/UniHockey

# 2. Copy the minimal files needed for 'restore' first (faster caching)
# We assume UniHockey.csproj is in the current build context's root.
# NOTE: The previous file contained incorrect escaped characters. They are removed now.
COPY UniHockey.csproj .

# If your project references a solution file, you must copy it too:
# COPY UniHockey.sln .

# The restore step should target the project file or the current directory.
RUN dotnet restore UniHockey.csproj

# 3. Copy the rest of the source code (cache bust if code changes)
COPY . .

# 4. We don't need to change WORKDIR as we are already in the project directory.

# 5. Build and publish the application
# We publish the output to the /app folder within the build container.
RUN dotnet publish UniHockey.csproj -c Release -o /app /p:UseAppHost=false

#----------------------------------------------------------------------
# STAGE 2: Runtime (Uses the minimal ASP.NET Runtime image)
#----------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# 1. Set the working directory for the final application files
WORKDIR /app

# 2. Copy only the published output from the 'build' stage
# This results in a much smaller final production image size.
COPY --from=build /app .

# 3. Listen on the standard ASP.NET Core port (8080)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# 4. Define the application entry point
# NOTE: Removed incorrect escaped characters from the ENTRYPOINT
ENTRYPOINT ["dotnet", "UniHockey.dll"]