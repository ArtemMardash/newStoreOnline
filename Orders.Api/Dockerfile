FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /App
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./SharedKernal ./SharedKernal
# Copy everything
COPY ./Orders.Api ./Orders.Api
COPY ./Orders.Application ./Orders.Application
COPY ./Orders.Domain ./Orders.Domain
COPY ./Orders.Infrastructure ./Orders.Infrastructure
COPY ./Orders.Persistence ./Orders.Persistence
WORKDIR ./Orders.Api
RUN dotnet build -c Release -o /App
# Build and publish a release
FROM build AS publish 
RUN dotnet publish -c Release -o /App

# Build runtime image
FROM base AS final 
WORKDIR /App
COPY --from=publish /App .
ENTRYPOINT ["dotnet", "Orders.Api.dll"]