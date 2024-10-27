FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /App
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./SharedKernal ./SharedKernal
# Copy everything
COPY ./Users.Api ./Users.Api
COPY ./Users.Application ./Users.Application
COPY ./Users.Domain ./Users.Domain
COPY ./Users.Infrastructure ./Users.Infrastructur
COPY ./Users.Persistence ./Users.Persistence
WORKDIR ./Users.Api
RUN dotnet build -c Release -o /App
# Build and publish a release
FROM build AS publish 
RUN dotnet publish -c Release -o /App

# Build runtime image
FROM base AS final 
WORKDIR /App
COPY --from=publish /App .
ENTRYPOINT ["dotnet", "Users.Api.dll"]