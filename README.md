# Polkanalysis
[![License:MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![DOTNET](https://img.shields.io/badge/Framework-NET_7_/_ASP_NET_Core_Blazor_/_NET_MAUI-green)](https://learn.microsoft.com/fr-fr/dotnet/core)
[![SubstrateGaming](https://img.shields.io/badge/Substrate_Gaming-Substrate.NET.Toolchain-blue)](https://github.com/SubstrateGaming)


Polkanalysis is a Substrate-based blockchain explorer written in .NET.  
It provide front end application and display aggregated data from the blockchain.

## Developpement state
__This application is under heavy developpement. It plans to be release Q1 2024 !__

The application currently support :
* [Polkadot](https://polkadot.network)
* [Kusama](https://kusama.network/)

For more information about the project, please check the Roadmap

## Run project
You can start everything with :
```
docker-compose up -d
```

### Details
They are 3 docker compose file in the project
#### Run the entire application with every project :
```
docker-compose up -d
```

This command is going to run :
* Blazor web application
* ASP.NET Core API
* Hosted background service
* A PostgreSQL database
* A Elasticsearch + Kibana application to have a friend application logs view

#### Run only the background worker :
```
docker-compose -f docker-compose-worker up -d
```

This command is going to run :
* Hosted background service
* A PostgreSQL database

#### Run only front app :
```
docker-compose -f docker-compose-webapp up -d
```

This command is going to run :
* Blazor web application
* ASP.NET Core API
* A PostgreSQL database




