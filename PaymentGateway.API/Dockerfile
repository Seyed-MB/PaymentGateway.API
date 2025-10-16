# مرحله 1: ساخت (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# کپی کردن کل سورس
COPY . .

# ساخت پروژه
RUN dotnet restore "PaymentGateway.API.csproj"
RUN dotnet build "PaymentGateway.API.csproj" -c Release -o /app/build

# انتشار (Publish)
RUN dotnet publish "PaymentGateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false


# مرحله 2: ران‌تایم (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PaymentGateway.API.dll"]
