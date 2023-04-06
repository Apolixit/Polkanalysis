using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Infrastructure.Contracts.Database.Analysis;
using Polkanalysis.Infrastructure.Contracts.Database.Analysis.Events.Balances;
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
    //[LinkedEvent("Domain.Contracts.Secondary.Pallet.Balances.Enums.Event.Transfer")]
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

        public async Task InsertAsync(
            EventsDatabaseModel eventModel, 
            IType data,
            CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<BaseTuple<SubstrateAccount, SubstrateAccount, U128>>(data);

            try
            {
                var transferAmount = (double)((U128)convertedData.Value[2]).Value;

                var nbRows = await _db.Query(TableName).InsertAsync(new
                {
                    blockchainName = eventModel.BlockchainName,
                    blockId = eventModel.BlockId,
                    eventId = 0,
                    moduleName = eventModel.ModuleName,
                    eventName = eventModel.EventName,
                    from = ((SubstrateAccount)convertedData.Value[0]).ToStringAddress(),
                    to = ((SubstrateAccount)convertedData.Value[1]).ToStringAddress(),
                    amount = transferAmount
                }, cancellationToken: token);

                if (nbRows != 1)
                    throw new InvalidOperationException("Inserted rows are inconsistent");

                _logger.LogInformation($"{eventModel.EventName} successfully inserted is database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to insert in database");
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IEnumerable<BalancesTransferModel>> GetAllAsync(CancellationToken token)
        {
            return await _db.Query(TableName)
                .GetAsync<BalancesTransferModel>(cancellationToken: token) ?? Enumerable.Empty<BalancesTransferModel>();
        }
    }
}
