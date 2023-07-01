# Roadmap

Polkanalysis is an easy to use Substrate ecosystem explorer.  
I have for goal to increase its functionnalities linearly accross time.

This project started in December 2022, after a first proof of concept of Substrate pallet [Money Pot](https://github.com/Apolixit/pallet_money_pot) and the [Blazor Front end](https://github.com/Apolixit/moneypot_blazor)

## Functionnalities

The project will provide severals projects :
    * Blazor Web Application
    * A mobile application
    * A Blazor components projects, shared between web and mobile application
    * An Rest API
    * A business logic project (call Domain) where every substrate logic is written here
    * A PostgreSQL database with selected data to allow to easily query aggregated datas

## Schedule

> ### 1st December 2022 - 30 April 2023


| Setup good practices    | Description |
| ----------- | ----------- |
| Hexagonal architecture      | Setup new .NET hexagonal architecture to separate blockchain data feed to business logic call by front end application |
| Code coverage      | Even if I don't explicitely give percentage code coverage goal, I keep the project the most well testes as possible |

| Explorer task      | Description |
| ----------- | ----------- |
| Blocks      | Subscribe to new blocks. Display block details (block number, hash, author, timestamp) |
| Events   | Subscribe to new events. Display event details, module name, event name, parameter details |
| Extrinsics   | Display extrinsic details, module name, call name, timestamps, success or failure, parameter details |
|  |  |
| Account   | Display accout detail, free, lock and reserve balances. All extrinsics and "events" (crowdloan, transfer) linked |
| Validator   | Validator details. Stash, controller and reward account. Nominators who elected him during current era |
| Nominator   | Nominator details. Stash, controller and reward account |
| Pool member   | Display pool information. Name, current active members, rewards |
| ----------- | ----------- |
| Runtime modules   | Display module details. For each module, theirs calls functions, events that can be raised, constants, storage and errors that can be thrown |

| Blockchain Mapping      | Description |
| ----------- | ----------- |
| Polkadot      | Map every Polkadot storage / events / constants to Domain project and add unit tests for every mapping done |

> ### 1st Mai 2023 - 30 July 2023
| Front app task      | Description |
| ----------- | ----------- |
| Setup | Start Blazor server project + component front app project |
| Components      | Create shared design components for razor pages. These components are based on free template website and adapt to C# components|
| Explorer | Create block + extrinsic + events front page (listing / search / detail) |
| Staking | Create Era + Validator + Nominator + Pools front page (listing / search / detail) |
| Parachain | Create Parachain front page (listing / search / detail) |
| Account | Create Accounts front page (listing / search / detail) |
| Runtime | Create current runtime module front page (listing / search / detail) |
| API limit rate | Add API limit rate to ensure API is not spammed |

| Database     | Description |
| ----------- | ----------- |
| Events | Insert specific events in database (subsribe events are define in the code base) |
| Token price | Call Coingecko API and insert one time per day price token |
| Heavy storage | Insert heavy storage (like era stakers) in database |

| Background worker     | Description |
| ----------- | ----------- |
| Listen blockchain | Subscribe to Substrate events / storage change and insert in database |
| Query missing data | Query in the past events and storage change missed before the project start |

| Docker     | Description |
| ----------- | ----------- |
| Setup docker | Add docker file + docker compose file to easily start the projet |
| Monitoring | Add Elasticsearch and Kibana to have access to an understandable logs views and dashboard over the project |

> ### 1st September 2023 - 31 December 2023

| Mobile app     | Description |
| ----------- | ----------- |
| .NET MAUI | Start a .NET MAUI project, bind on shared library component to setup a simple mobile application |

| Blockchain Mapping      | Description |
| ----------- | ----------- |
| Kusama      | Same as Polkadot mapping but with Kusama |
| Bajun      | Same as Polkadot and Kusama mapping but with Bajun |
