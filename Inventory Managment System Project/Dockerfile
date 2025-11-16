# ===========================
# STAGE 1 — BUILD THE PROJECT
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project files
COPY . .

# Restore dependencies
RUN dotnet restore

# Publish the project
RUN dotnet publish -c Release -o /app/publish

# ===========================
# STAGE 2 — RUN THE PROJECT
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# Expose port 8080 (Render uses 10000–11000 internally, but maps automatically)
EXPOSE 8080

# Set ASP.NET Core to listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080

# Name of your DLL (MUST match what is generated)
ENTRYPOINT ["dotnet", "Inventory Managment System Project.dll"]
