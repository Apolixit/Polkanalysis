using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot
{
    internal class DelegateSystemChainTests : PolkadotIntegrationTest
    {
        /// <summary>
        /// https://people-polkadot.subscan.io/block/540668
        /// </summary>
        /// <returns></returns>
        public async Task GetAssociatedHashFromOtherChain_WithValidBlockNumber_ShouldSucceedAsync()
        {
            var res = await _delegateSystemChain.GetAssociatedHashFromOtherChainAsync(
                _peopleChainService.AjunaClient,
                _peopleChainService.BlockchainName,
                540668,
                CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value, Is.EqualTo("0x357d1d4b7e35f1ebc1786acf83112ea7b85aebd7075c550bd3d1d0c5742be7f8"));
        }

        [Test]
        public void GetAssociatedHashFromOtherChain_WithInvalidBlockNumber_ShouldFail()
        {
            Assert.ThrowsAsync<InvalidDataFromSystemParachainException>(async () => await _delegateSystemChain.GetAssociatedHashFromOtherChainAsync(
                _peopleChainService.AjunaClient,
                _peopleChainService.BlockchainName,
                0,
                CancellationToken.None));
        }

        //[Test]
        //public async Task CurrentBlockForSystemChain_FromDatabase_ShouldSucceedAsync()
        //{
        //    _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
        //    {
        //        BlockchainName = "PeopleChain",
        //        BlockNumber = 1000,
        //        BlockDate = new DateTime(2024, 01, 01, 01, 00, 00),
        //        BlockHash = "don't care",
        //        EventsCount = 0,
        //        ExtrinsicsCount = 0,
        //        LogsCount = 0,
        //        ValidatorAddress = "don't care"
        //    });
        //    _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
        //    {
        //        BlockchainName = "PeopleChain",
        //        BlockNumber = 1001,
        //        BlockDate = new DateTime(2024, 01, 01, 01, 00, 12),
        //        BlockHash = "don't care",
        //        EventsCount = 0,
        //        ExtrinsicsCount = 0,
        //        LogsCount = 0,
        //        ValidatorAddress = "don't care"
        //    });
        //    _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
        //    {
        //        BlockchainName = "PeopleChain",
        //        BlockNumber = 1002,
        //        BlockDate = new DateTime(2024, 01, 01, 01, 00, 25), // A bit more than 12s
        //        BlockHash = "don't care",
        //        EventsCount = 0,
        //        ExtrinsicsCount = 0,
        //        LogsCount = 0,
        //        ValidatorAddress = "don't care"
        //    });
        //    _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
        //    {
        //        BlockchainName = "PeopleChain",
        //        BlockNumber = 1003,
        //        BlockDate = new DateTime(2024, 01, 01, 01, 00, 40), // More than 12s
        //        BlockHash = "don't care",
        //        EventsCount = 0,
        //        ExtrinsicsCount = 0,
        //        LogsCount = 0,
        //        ValidatorAddress = "don't care"
        //    });
        //    _substrateDbContext.SaveChanges();

        //    //_substrateService.AjunaClient.GetStorageAsync<U64>(Arg.Any<string>(), "blockHashFromPolkadot", CancellationToken.None).Returns();

        //    var res = await _delegateSystemChain.CurrentBlockForSystemChainAsync(
        //        _peopleChainService.AjunaClient, 
        //        "PeopleChain",
        //        "Polkadot", 
        //        CancellationToken.None);

        //    Assert.That(res, Is.EqualTo(1002));
        //}
    }
}
