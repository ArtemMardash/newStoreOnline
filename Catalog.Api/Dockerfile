FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /App
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./SharedKernal ./SharedKernal
# Copy everything
COPY ./Catalog.Api ./Catalog.Api
COPY ./Catalog.Application ./Catalog.Application
COPY ./Catalog.Domain ./Catalog.Domain
COPY ./Catalog.Infrastructure ./Catalog.Infrastructure
COPY ./Catalog.Persistence ./Catalog.Persistence
WORKDIR ./Catalog.Api
RUN dotnet build -c Release -o /App
# Build and publish a release
FROM build AS publish 
RUN dotnet publish -c Release -o /App

# Build runtime image
FROM base AS final 
WORKDIR /App
COPY --from=publish /App .
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]