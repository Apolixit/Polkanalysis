﻿using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.System;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Events.System
{
    public class SystemNewAccountRepository : EventDatabaseRepository, IDatabaseGet<SystemNewAccountModel>
    {
        public SystemNewAccountRepository(
            SubstrateDbContext context,
            ISubstrateRepository substrateNodeRepository,
            IBlockchainMapping mapping,
            ILogger<SystemNewAccountRepository> logger) : base(context, substrateNodeRepository, mapping, logger)
        {
        }
        public async Task<bool> IsAlreadyExistsAsync(SystemNewAccountModel eventModel, CancellationToken token)
        {
            return await _context.EventSystemNewAccount.AnyAsync(x => x.Equals(eventModel), token);
        }

        public Task<IEnumerable<SystemNewAccountModel>> GetAllAsync(CancellationToken token)
        {
            return Task.FromResult(_context.EventSystemNewAccount ?? Enumerable.Empty<SystemNewAccountModel>());
        }

        protected override async Task<bool> BuildRequestInsertAsync(EventModel eventModel, IType data, CancellationToken token)
        {
            var convertedData = _mapping.Mapper.Map<SubstrateAccount>(data);

            var account = convertedData.ToStringAddress();

            var model = new SystemNewAccountModel(
                eventModel.BlockchainName,
                eventModel.BlockId,
                eventModel.BlockDate,
                eventModel.EventId,
                eventModel.ModuleName,
                eventModel.ModuleEvent,
                account);

            if (await IsAlreadyExistsAsync(model, token))
            {
                _logger.LogWarning($"{model} already exists in database !");
                return false;
            }

            _context.EventSystemNewAccount.Add(model);
            return true;
        }

        
    }
}