# مرحله 1: ساخت (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore "PaymentGateway.API\PaymentGateway.API.csproj"
RUN dotnet build "PaymentGateway.API\PaymentGateway.API.csproj" -c Release -o /app/build
RUN dotnet publish "PaymentGateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PaymentGateway.API.dll"]