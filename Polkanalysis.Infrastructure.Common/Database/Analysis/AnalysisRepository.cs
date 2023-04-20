using Microsoft.Extensions.Logging;
using Npgsql;
using Polkanalysis.Domain.Contracts;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Infrastructure.Common.Database.Analysis.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Database.Analysis;
using Polkanalysis.Infrastructure.Contracts.Model;
using SqlKata.Compilers;
using SqlKata.Execution;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Polkanalysis.Infrastructure.Common.Database.Analysis
{
    public abstract class AnalysisRepository : IDatabaseInsert
    {
        protected readonly IDatabaseConfiguration _dataBaseConfiguration;
        protected readonly ILogger<AnalysisRepository> _logger;
        protected readonly IBlockchainMapping _mapping;
        protected NpgsqlConnection _connection;

        protected Compiler _compiler;
        protected QueryFactory _db;
        protected abstract string TableName { get;}

        protected AnalysisRepository(
            IDatabaseConfiguration dataBaseConfiguration,
            IBlockchainMapping mapping,
            ILogger<AnalysisRepository> logger)
        {
            _dataBaseConfiguration = dataBaseConfiguration;
            _logger = logger;
            _mapping = mapping;

            //_connection = new NpgsqlConnection(_dataBaseConfiguration.ConnectionString);

            _compiler = new PostgresCompiler();
        }

        protected abstract Task InternalInsertAsync(
            EventsDatabaseModel eventModel,
            IType data,
            CancellationToken token);

        public async Task InsertAsync(
            EventsDatabaseModel eventModel,
            IType data,
            CancellationToken token)
        {
            using(_connection = new NpgsqlConnection(_dataBaseConfiguration.ConnectionString))
            {
                await _connection.OpenAsync();

                try
                {
                    _db = new QueryFactory(_connection, _compiler);
                    await InternalInsertAsync(eventModel, data, token);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while trying to insert in database");
                }
            }

            //await _connection.OpenAsync();
            //await using var transaction = await _connection.BeginTransactionAsync();

            //try
            //{
            //    await InternalInsertAsync(eventModel, data, token);
            //    await transaction.CommitAsync(token);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Error while trying to insert in database");
            //}
            //finally
            //{
            //    await _connection.CloseAsync();
            //}
        }
    }
}
