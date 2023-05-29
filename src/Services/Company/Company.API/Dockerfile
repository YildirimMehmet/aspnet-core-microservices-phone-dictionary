FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Company/Company.API/Company.API.csproj", "Services/Company/Company.API/"]
COPY ["Services/Company/Company.Application/Company.Application.csproj", "Services/Company/Company.Application/"]
COPY ["Services/Company/Company.Domain/Company.Domain.csproj", "Services/Company/Company.Domain/"]
COPY ["PhoneDirectory.Shared/PhoneDirectory.Shared.csproj", "PhoneDirectory.Shared/"]
COPY ["Services/Company/Company.Infrastructure/Company.Infrastructure.csproj", "Services/Company/Company.Infrastructure/"]
COPY ["PhoneDirectory.EntityFramework/PhoneDirectory.EntityFramework.csproj", "PhoneDirectory.EntityFramework/"]
RUN dotnet restore "Services/Company/Company.API/Company.API.csproj"
COPY . .
WORKDIR "/src/Services/Company/Company.API"
RUN dotnet build "Company.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company.API.dll"]
