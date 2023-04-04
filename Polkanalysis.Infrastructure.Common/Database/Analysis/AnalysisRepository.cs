using Microsoft.Extensions.Logging;
using Npgsql;
using Polkanalysis.Domain.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Infrastructure.Common.Database.Analysis.Events.Balances;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Database.Analysis
{
    public abstract class AnalysisRepository
    {
        protected readonly IDatabaseConfiguration _dataBaseConfiguration;
        protected readonly ILogger<AnalysisRepository> _logger;
        protected readonly IBlockchainMapping _mapping;
        protected readonly NpgsqlConnection _connection;

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

            _connection = new NpgsqlConnection(_dataBaseConfiguration.ConnectionString);
            _connection.Open();

            _compiler = new PostgresCompiler();
            _db = new QueryFactory(_connection, _compiler);
        }
    }
}
