using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts.Repository;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Test
{
    /// <summary>
    /// Test main class to be connected to endpoint
    /// </summary>
    public abstract class IntegrationTest
    {
        protected readonly ISubstrateNodeRepository _substrateRepository;
        protected readonly IConfiguration _configuration;

        public IntegrationTest()
        {
            _configuration = Substitute.For<IConfiguration>();
            //_configuration = configuration;
            _substrateRepository = Substitute.For<ISubstrateNodeRepository>();
            _substrateRepository.Client.Returns(new NetApiExt.Generated.SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default()));

            //_substrateRepository.Client.Returns(
            //    new NetApiExt.Generated.SubstrateClientExt(
            //        new Uri(_configuration["endpoint:current"]),
            //        ChargeTransactionPayment.Default()));


        }

        /// <summary>
        /// Connect to the endpoint at the beggining of test
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp]
        public virtual async Task ConnectAsync()
        {
            if (!_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.ConnectAsync();
            }
        }

        /// <summary>
        /// Close connection when tests are finished
        /// </summary>
        /// <returns></returns>
        [OneTimeTearDown]
        public virtual async Task DisconnectAsync()
        {
            if (_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.CloseAsync();
            }
        }
    }
}
