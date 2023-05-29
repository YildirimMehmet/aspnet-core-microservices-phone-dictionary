FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Contact/Contact.API/Contact.API.csproj", "Services/Contact/Contact.API/"]
COPY ["PhoneDirectory.Shared/PhoneDirectory.Shared.csproj", "PhoneDirectory.Shared/"]
COPY ["Services/Contact/Contact.Application/Contact.Application.csproj", "Services/Contact/Contact.Application/"]
COPY ["Services/Contact/Contact.Domain/Contact.Domain.csproj", "Services/Contact/Contact.Domain/"]
COPY ["Services/Contact/Contact.Infrastructure/Contact.Infrastructure.csproj", "Services/Contact/Contact.Infrastructure/"]
COPY ["PhoneDirectory.EntityFramework/PhoneDirectory.EntityFramework.csproj", "PhoneDirectory.EntityFramework/"]
COPY ["Services/Contact/Contact.Shared/Contact.Shared.csproj", "Services/Contact/Contact.Shared/"]
COPY ["Services/Report/Report.Shared/Report.Shared.csproj", "Services/Report/Report.Shared/"]
RUN dotnet restore "Services/Contact/Contact.API/Contact.API.csproj"
COPY . .
WORKDIR "/src/Services/Contact/Contact.API"
RUN dotnet build "Contact.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contact.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.API.dll"]
