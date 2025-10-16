# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj first for caching
COPY ["PaymentGateway.API.csproj", "./"]
RUN dotnet restore "PaymentGateway.API.csproj"

# Copy all source files
COPY . ./
RUN dotnet build "PaymentGateway.API.csproj" -c Release -o /app/build
RUN dotnet publish "PaymentGateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PaymentGateway.API.dll"]
