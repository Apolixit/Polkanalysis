# Polkanalysis Infrastructure Database

This project is responsible for the database layer of the Polkanalysis infrastructure. 
It is a PostgreSQL database that stores all the data that is collected from the Polkadot network.

## Database migration
To create a new migration, open "Package manager console"
Set "Polkanalysis.Worker" as the startup project
Select "Polkanalysis.Infrastructure.Database" as the default project
Run the following command:
```
add-migration XXXX
```
Where XXXX is the name of the migration

Start a front project (the migration will be automatically applied)

