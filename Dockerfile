FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /src

COPY ["Orcamentaria.ServiceName.API/Orcamentaria.ServiceName.API.csproj", "Orcamentaria.ServiceName.API/"]
COPY ["Orcamentaria.ServiceName.Application/Orcamentaria.ServiceName.Application.csproj", "Orcamentaria.ServiceName.Application/"]
COPY ["Orcamentaria.ServiceName.Domain/Orcamentaria.ServiceName.Domain.csproj", "Orcamentaria.ServiceName.Domain/"]
COPY ["Orcamentaria.ServiceName.Infrastructure/Orcamentaria.ServiceName.Infrastructure.csproj", "Orcamentaria.ServiceName.Infrastructure/"]

COPY nuget.config ./
COPY local-packages ./local-packages

RUN dotnet restore "Orcamentaria.ServiceName.API/Orcamentaria.ServiceName.API.csproj"

COPY . .

WORKDIR "/src/Orcamentaria.ServiceName.API"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Orcamentaria.ServiceName.API.dll"]
# ENV ASPNETCORE_URLS=http://+:5000
# EXPOSE 5000