using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Common.Repository.Pallet.System
{
    internal static class SystemStorageAbstractTests
    {
        public static async Task GetAllAccounts_ShouldWorkAsync(ISubstrateService _substrateService, int nb)
        {
            var query = await _substrateService.Storage.System.AccountsQueryAsync(CancellationToken.None);
            var res = await query.Take(nb).ExecuteAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.LessThanOrEqualTo(nb));

            var addressAccount = res.Select(x => x.Item1.ToStringAddress());
            Assert.That(addressAccount.Distinct().Count(), Is.EqualTo(res.Count));
        }
    }
}
