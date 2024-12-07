# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Applications/Polkanalysis.Api/Polkanalysis.Api.csproj", "src/Applications/Polkanalysis.Api/"]
COPY ["src/Core/Polkanalysis.Common/Polkanalysis.Common.csproj", "src/Core/Polkanalysis.Common/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.Contracts/Polkanalysis.Infrastructure.Blockchain.Contracts.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.Contracts/"]
COPY ["src/Core/Polkanalysis.Configuration.Contracts/Polkanalysis.Configuration.Contracts.csproj", "src/Core/Polkanalysis.Configuration.Contracts/"]
COPY ["src/Core/Substrate.NET.Utils/Substrate.NET.Utils/Substrate.NET.Utils.csproj", "src/Core/Substrate.NET.Utils/Substrate.NET.Utils/"]
COPY ["src/Infrastructure/Substrate.NetApi/Substrate.NetApi.csproj", "src/Infrastructure/Substrate.NetApi/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Database/Polkanalysis.Infrastructure.Database.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Database/"]
COPY ["src/Domain/Polkanalysis.Domain.Contracts/Polkanalysis.Domain.Contracts.csproj", "src/Domain/Polkanalysis.Domain.Contracts/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Database.Contracts/Polkanalysis.Infrastructure.Database.Contracts.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Database.Contracts/"]
COPY ["src/Core/Polkanalysis.Configuration.Extensions/Polkanalysis.Configuration.Extensions.csproj", "src/Core/Polkanalysis.Configuration.Extensions/"]
COPY ["src/Domain/Polkanalysis.Domain/Polkanalysis.Domain.csproj", "src/Domain/Polkanalysis.Domain/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.Polkadot/Polkanalysis.Infrastructure.Blockchain.Polkadot.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.Polkadot/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.Mythos/Polkanalysis.Infrastructure.Blockchain.Mythos.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.Mythos/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Blockchain/Polkanalysis.Infrastructure.Blockchain.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Blockchain/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.PeopleChain/Polkanalysis.Infrastructure.Blockchain.PeopleChain.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Blockchain.PeopleChain/"]
RUN dotnet restore "./src/Applications/Polkanalysis.Api/Polkanalysis.Api.csproj"
COPY . .
WORKDIR "/src/src/Applications/Polkanalysis.Api"
RUN dotnet build "./Polkanalysis.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Polkanalysis.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polkanalysis.Api.dll"]