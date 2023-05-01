using Microsoft.Extensions.Logging;
using Npgsql;
using Polkanalysis.Infrastructure.Contracts;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Polkanalysis.Infrastructure.Contracts.Model;

namespace Polkanalysis.Infrastructure.Common.Database
{
    public class EventAggregateRepository : IEventAggregateRepository
    {
        //private readonly IDatabaseConfiguration _dataBaseConfiguration;
        //private readonly ILogger<IEventAggregateRepository> _logger;
        //private NpgsqlConnection connection;
        //private const string TableName = "BlockchainEvents";
        //public EventAggregateRepository(
        //    IDatabaseConfiguration dataBaseConfiguration,
        //    ILogger<IEventAggregateRepository> logger)
        //{
        //    _dataBaseConfiguration = dataBaseConfiguration;
        //    _logger = logger;
        //    connection = new NpgsqlConnection(_dataBaseConfiguration.ConnectionString);
        //    connection.Open();
        //}

        public async Task<IEnumerable<EventModel>> GetAllAsync(CancellationToken token)
        {
            //string select = $"Select * From {TableName}";

            //var blockchainEvents = await connection.QueryAsync<EventsDatabaseModel>(select);
            //return blockchainEvents;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventModel>> GetEventsByModuleNameAsync(string moduleName, CancellationToken token)
        {
            //string select = $"Select * From {TableName} where moduleName = @moduleName";

            //var queryArg = new { ModuleName = moduleName};

            //var blockchainEvents = await connection.QueryAsync<EventsDatabaseModel>(select, queryArg);
            //return blockchainEvents;
            throw new NotImplementedException();
        }

        public async Task AddAsync(EventModel eventModel, CancellationToken token)
        {
            throw new NotImplementedException();
            //string insert = $"Insert Into {TableName} (blockchainName, blockId, moduleName, eventName) Values (@blockchain, @id, @module, @moduleEvent)";

            //var queryArgument = new
            //{
            //    blockchain = eventModel.BlockchainName,
            //    id = eventModel.BlockId,
            //    module = eventModel.ModuleName,
            //    moduleEvent = eventModel.EventName 
            //};

            //try
            //{
            //    var nbRows = await connection.ExecuteAsync(insert, queryArgument);
            //    _logger.LogTrace($"Insert {nbRows} in database");
            //} catch(Exception ex)
            //{
            //    _logger.LogError(ex, "");
            //}
        }
    }
}
