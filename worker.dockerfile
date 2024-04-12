#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
COPY ["src/Infrastructure/Assemblies/Polkanalysis.Polkadot.NetApiExt.dll", "src/Infrastructure/Assemblies/"]
COPY ["src/Core/Substrate.NetApi/Substrate.NetApi.csproj", "src/Core/Substrate.NetApi/"]
COPY ["src/Applications/Polkanalysis.Worker/Polkanalysis.Worker.csproj", "src/Applications/Polkanalysis.Worker/"]
COPY ["src/Core/Polkanalysis.Common/Polkanalysis.Common.csproj", "src/Core/Polkanalysis.Common/"]
COPY ["src/Core/Polkanalysis.Configuration.Extensions/Polkanalysis.Configuration.Extensions.csproj", "src/Core/Polkanalysis.Configuration.Extensions/"]
COPY ["src/Core/Substrate.NET.Utils/Substrate.NET.Utils/Substrate.NET.Utils.csproj", "src/Core/Substrate.NET.Utils/Substrate.NET.Utils/"]
COPY ["src/Domain/Polkanalysis.Domain/Polkanalysis.Domain.csproj", "src/Domain/Polkanalysis.Domain/"]
COPY ["src/Infrastructure/Polkanalysis.Infrastructure.Blockchain/Polkanalysis.Infrastructure.Blockchain.csproj", "src/Infrastructure/Polkanalysis.Infrastructure.Blockchain/"]

RUN dotnet restore "src/Applications/Polkanalysis.Worker/Polkanalysis.Worker.csproj"
COPY . .
WORKDIR "/src/Applications/Polkanalysis.Worker/"
RUN dotnet build "Polkanalysis.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Polkanalysis.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polkanalysis.Worker.dll"]