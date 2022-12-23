using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types.Metadata;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.NetApiExt.Generated;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Test.Runtime
{
    public class PalletBuilderUnitTest
    {
        protected readonly ISubstrateNodeRepository _substrateRepository;
        private readonly IPalletBuilder _palletBuilder;

        public PalletBuilderUnitTest()
        {
            _substrateRepository = Substitute.For<ISubstrateNodeRepository>();
            _substrateRepository.Client.Returns(
                new SubstrateClientExt(default, default));

            //_substrateRepository.Client.IsConnected.Returns(true);
            //_substrateRepository.Client.ConnectAsync().ReturnsForAnyArgs(Task.CompletedTask);

            _palletBuilder = Substitute.For<IPalletBuilder>();
        }

        [Test]
        public void Build_InvalidPalletName_ShouldFailed()
        {
            //var runtimeMetadata = new RuntimeMetadata();
            var runtimeMetadata = Substitute.For<RuntimeMetadata>();
            //var runtimeMetadata = Arg.Any<RuntimeMetadata>();
            //var metadata = new MetaData(runtimeMetadata, "unknown");
            var metadata = Substitute.For<MetaData>(runtimeMetadata, "unknown");
            //_substrateRepository.Client.MetaData.Returns(Substitute.For<MetaData>(Arg.Any<RuntimeMetadata>()));
            _substrateRepository.Client.MetaData.Returns(metadata);
            _substrateRepository.Client.MetaData.NodeMetadata.Modules.Returns(new Dictionary<uint, PalletModule>());

            var mockMethod = Substitute.For<Method>((byte)0, (byte)0);
            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildCall("WrongName", mockMethod));
            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildEvent("WrongName", mockMethod));
            Assert.Throws<ArgumentException>(() => _palletBuilder.BuildError("WrongName", mockMethod));
        }
    }
}
