FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /App
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./SharedKernal ./SharedKernal
COPY ./NuGet.Config .
# Copy everything
COPY ./Billing.BackGroundJobs ./Billing.BackGroundJobs
COPY ./Billing.Application ./Billing.Application
COPY ./Billing.Domain ./Billing.Domain
COPY ./Billing.Infrastructure ./Billing.Infrastructure
COPY ./Billing.Persistence ./Billing.Persistence
WORKDIR ./Billing.BackGroundJobs
RUN dotnet build -c Release -o /App
# Build and publish a release
FROM build AS publish 
RUN dotnet publish -c Release -o /App

# Build runtime image
FROM base AS final 
WORKDIR /App
COPY --from=publish /App .
ENTRYPOINT ["dotnet", "Billing.BackGroundJobs.dll"]