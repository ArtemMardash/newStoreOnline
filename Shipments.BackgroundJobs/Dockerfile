FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /App
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./SharedKernal ./SharedKernal
# Copy everything
COPY ./Shipments.BackgroundJobs ./Shipments.BackgroundJobs
COPY ./Shipments.Application ./Shipments.Application
COPY ./Shipments.Infrastructure ./Shipments.Infrastructure
COPY ./Shipments.Persistence ./Shipments.Persistence
WORKDIR ./Shipments.BackgroundJobs
RUN dotnet build -c Release -o /App
# Build and publish a release
FROM build AS publish 
RUN dotnet publish -c Release -o /App

# Build runtime image
FROM base AS final 
WORKDIR /App
COPY --from=publish /App .
ENTRYPOINT ["dotnet", "Shipments.BackgroundJobs.dll"]