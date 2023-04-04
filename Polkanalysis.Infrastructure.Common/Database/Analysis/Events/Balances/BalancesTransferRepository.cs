using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;
using Polkanalysis.Domain.Contracts;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Infrastructure.Contracts.Analysis;
using Polkanalysis.Infrastructure.Contracts.Analysis.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Model;
using SqlKata.Execution;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Database.Analysis.Events.Balances
{
    public class BalancesTransferRepository : AnalysisRepository, 
        IDatabaseInsert,
        IDatabaseGet<BalancesTransferModel>
    {

        protected override string TableName => "EventBalancesTransfer";

        public BalancesTransferRepository(
            IDatabaseConfiguration dataBaseConfiguration,
            IBlockchainMapping mapping,
            ILogger<AnalysisRepository> logger) : base(dataBaseConfiguration, mapping, logger)
        {
        }

        public async Task InsertAsync<T>(
            EventsDatabaseModel eventModel, 
            T data,
            CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<BaseTuple<SubstrateAccount, SubstrateAccount, U128>>(data);
            //string insert = $"Insert Into {TableName} (blockchainName, eventId, moduleName, eventName, from, to, amount, datetime) Values (@blockchain, @eventId, @moduleName, @moduleEvent, @from, @to, @amount, @datetime)";

            //var queryArgument = new
            //{
            //    blockchain = eventModel.BlockchainName,
            //    eventId = eventModel.BlockId,
            //    module = eventModel.ModuleName,
            //    moduleEvent = eventModel.EventName,
            //    from = ((SubstrateAccount)data.Value[0]).ToStringAddress(),
            //    to = ((SubstrateAccount)data.Value[1]).ToStringAddress(),
            //    amount = ((U128)data.Value[2]).Value
            //};

            try
            {
                //var nbRows = await _connection.ExecuteAsync(insert, queryArgument);
                var nbRows = await _db.Query(TableName).InsertAsync(new
                {
                    blockchain = eventModel.BlockchainName,
                    eventId = eventModel.BlockId,
                    module = eventModel.ModuleName,
                    moduleEvent = eventModel.EventName,
                    from = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress(),
                    to = ((SubstrateAccount)convertedData.Value[1]).ToStringAddress(),
                    amount = ((U128)convertedData.Value[2]).Value
                }, cancellationToken: token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
        }

        public async Task<IEnumerable<BalancesTransferModel>> GetAllAsync(CancellationToken token)
        {
            return await _db.Query(TableName)
                .GetAsync<BalancesTransferModel>(cancellationToken: token) ?? Enumerable.Empty<BalancesTransferModel>();
        }
    }
}
