FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Report/Report.API/Report.API.csproj", "Services/Report/Report.API/"]
COPY ["PhoneDirectory.EntityFramework/PhoneDirectory.EntityFramework.csproj", "PhoneDirectory.EntityFramework/"]
COPY ["PhoneDirectory.Shared/PhoneDirectory.Shared.csproj", "PhoneDirectory.Shared/"]
COPY ["Services/Report/Report.Application/Report.Application.csproj", "Services/Report/Report.Application/"]
COPY ["Services/Report/Report.Domain/Report.Domain.csproj", "Services/Report/Report.Domain/"]
COPY ["Services/Contact/Contact.Shared/Contact.Shared.csproj", "Services/Contact/Contact.Shared/"]
COPY ["Services/Report/Report.Infrastructure/Report.Infrastructure.csproj", "Services/Report/Report.Infrastructure/"]
COPY ["Services/Report/Report.Shared/Report.Shared.csproj", "Services/Report/Report.Shared/"]
RUN dotnet restore "Services/Report/Report.API/Report.API.csproj"
COPY . .
WORKDIR "/src/Services/Report/Report.API"
RUN dotnet build "Report.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Report.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Report.API.dll"]
