# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore first (Docker cache optimization)
COPY ["PaymentGateway.API/PaymentGateway.API.csproj", "PaymentGateway.API/"]
RUN dotnet restore "PaymentGateway.API/PaymentGateway.API.csproj"

# Copy everything else and build/publish
COPY . .
WORKDIR "/src/PaymentGateway.API"
RUN dotnet build "PaymentGateway.API.csproj" -c Release -o /app/build
RUN dotnet publish "PaymentGateway.API.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PaymentGateway.API.dll"]
