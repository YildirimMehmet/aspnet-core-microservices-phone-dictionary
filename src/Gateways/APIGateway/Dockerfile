FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Gateways/APIGateway/APIGateway.csproj", "Gateways/APIGateway/"]
COPY ["PhoneDirectory.Shared/PhoneDirectory.Shared.csproj", "PhoneDirectory.Shared/"]
RUN dotnet restore "Gateways/APIGateway/APIGateway.csproj"
COPY . .
WORKDIR "/src/Gateways/APIGateway"
RUN dotnet build "APIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIGateway.dll"]
