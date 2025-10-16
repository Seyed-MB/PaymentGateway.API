# 1. انتخاب base image دات‌نت Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
# تنظیم پورت داخل کانتینر
ENV ASPNETCORE_URLS=http://+:8080

# 2. ساخت پروژه با SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PaymentGateway.API/PaymentGateway.API.csproj", "PaymentGateway.API/"]
RUN dotnet restore "PaymentGateway.API/PaymentGateway.API.csproj"
COPY . .
WORKDIR "/src/PaymentGateway.API"
RUN dotnet build "PaymentGateway.API.csproj" -c Release -o /app/build

# 3. Publish پروژه
FROM build AS publish
RUN dotnet publish "PaymentGateway.API.csproj" -c Release -o /app/publish

# 4. Copy به base و تعیین entrypoint
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "PaymentGateway.API.dll"]
