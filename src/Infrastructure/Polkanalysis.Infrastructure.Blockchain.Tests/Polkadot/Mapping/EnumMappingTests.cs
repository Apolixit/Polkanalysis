using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_arithmetic.fixed_point;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Mapping
{
    public class EnumMappingTests : PolkadotRepositoryMock
    {
        #region Mock

        #region BaseEnum
        public enum SubstrateEnum1
        {
            PrimarySlots = 0,
            PrimaryAndSecondaryPlainSlots = 1,
            PrimaryAndSecondaryVRFSlots = 2
        }

        public sealed class EnumSubstrateEnum1 : BaseEnum<SubstrateEnum1>
        {
        }

        public enum SubstrateEnum2
        {
            PrimarySlots = 0,
            PrimaryAndSecondaryPlainSlots = 1,
            PrimaryAndSecondaryVRFSlots = 2,
            AnotherOne = 3,
        }

        public sealed class EnumSubstrateEnum2 : BaseEnum<SubstrateEnum2>
        {
        }

        public enum SubstrateEnum3
        {
            PrimaryAndSecondaryPlainSlots = 0,
            AnotherOne = 1,
            TheFourth = 2
        }

        public sealed class EnumSubstrateEnum3 : BaseEnum<SubstrateEnum3>
        {
        }

        public enum DomainSubstrateEnum
        {
            PrimarySlots = 0,
            PrimaryAndSecondaryPlainSlots = 1,
            PrimaryAndSecondaryVRFSlots = 2,
            AnotherOne = 3,
            TheFourth = 4
        }

        public sealed class EnumDomainSubstrateEnum : BaseEnum<DomainSubstrateEnum>
        {
        }

        #endregion

        #region BaseEnumExt
        public enum SubstrateEnumExt1
        {
            Awesome1 = 0,
            Awesome2 = 1,
            Awesome3 = 2
        }

        public sealed class EnumSubstrateEnumExt1 : BaseEnumExt<SubstrateEnumExt1, BaseVoid, U32, Bool>
        {
        }

        public enum SubstrateEnumExt2
        {
            Awesome1 = 0,
            Awesome3 = 1,
            Awesome4 = 2,
        }

        public sealed class EnumSubstrateEnumExt2 : BaseEnumExt<SubstrateEnumExt2, BaseVoid, Bool, U128>
        {
        }

        public enum SubstrateEnumExt3
        {
            Awesome2 = 0,
            Awesome5 = 1,
            Awesome4 = 2,
            Awesome1 = 3,
        }

        public sealed class EnumSubstrateEnumExt3 : BaseEnumExt<SubstrateEnumExt3, U32, BaseVoid, U128, BaseVoid>
        {
        }

        public enum SubstrateEnumExt4Error
        {
            Awesome1 = 0,
            Awesome2 = 1,
            Awesome3 = 2,
            Awesome4 = 3,
            Awesome10 = 4,
        }

        public sealed class EnumSubstrateEnumExt4Error : BaseEnumExt<SubstrateEnumExt4Error, U32, BaseVoid, U128, BaseVoid, U32>
        {
        }

        public enum SubstrateEnumExtDomain
        {
            Awesome1 = 0,
            Awesome2 = 1,
            Awesome4 = 2,
            Awesome3 = 3,
            Awesome5 = 4,
        }

        public sealed class EnumSubstrateEnumExtDomain : BaseEnumExt<SubstrateEnumExtDomain, BaseVoid, U32, U128, Bool, BaseVoid>
        {
        }
        #endregion

        #endregion

        private readonly IBlockchainMapping _mapper;

        public EnumMappingTests()
        {
            _mapper = new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>());
        }

        [Test]
        public void VersionnedCoreBaseEnum_ToMappedEnum_ShouldSucceed()
        {
            var se1 = new BaseEnum<SubstrateEnum1>();
            se1.Create(SubstrateEnum1.PrimaryAndSecondaryPlainSlots);

            var se2_1 = new EnumSubstrateEnum2();
            se2_1.Create(SubstrateEnum2.PrimarySlots);

            var se2_2 = new EnumSubstrateEnum2();
            se2_2.Create(SubstrateEnum2.AnotherOne);

            var se3 = new EnumSubstrateEnum3();
            se3.Create(SubstrateEnum3.TheFourth);

            var res1 = _mapper.Map<BaseEnum<SubstrateEnum1>, BaseEnum<DomainSubstrateEnum>>(se1);
            Assert.That(res1.Value, Is.EqualTo(DomainSubstrateEnum.PrimaryAndSecondaryPlainSlots));

            var res2_1 = _mapper.Map<BaseEnum<SubstrateEnum2>, BaseEnum<DomainSubstrateEnum>>(se2_1);
            Assert.That(res2_1.Value, Is.EqualTo(DomainSubstrateEnum.PrimarySlots));

            var res2_2 = _mapper.Map<BaseEnum<SubstrateEnum2>, BaseEnum<DomainSubstrateEnum>>(se2_2);
            Assert.That(res2_2.Value, Is.EqualTo(DomainSubstrateEnum.AnotherOne));

            var res3 = _mapper.Map<BaseEnum<SubstrateEnum3>, BaseEnum<DomainSubstrateEnum>>(se3);
            Assert.That(res3.Value, Is.EqualTo(DomainSubstrateEnum.TheFourth));
        }

        [Test]
        public void VersionnedCoreEnum_ToMappedEnum_ShouldSucceed()
        {
            var se1 = new EnumSubstrateEnum1();
            se1.Create(SubstrateEnum1.PrimaryAndSecondaryPlainSlots);

            var se2_1 = new EnumSubstrateEnum2();
            se2_1.Create(SubstrateEnum2.PrimarySlots);

            var se2_2 = new EnumSubstrateEnum2();
            se2_2.Create(SubstrateEnum2.AnotherOne);

            var se3 = new EnumSubstrateEnum3();
            se3.Create(SubstrateEnum3.TheFourth);

            var res1 = _mapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se1);
            Assert.That(res1.Value, Is.EqualTo(DomainSubstrateEnum.PrimaryAndSecondaryPlainSlots));

            var res2_1 = _mapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se2_1);
            Assert.That(res2_1.Value, Is.EqualTo(DomainSubstrateEnum.PrimarySlots));

            var res2_2 = _mapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se2_2);
            Assert.That(res2_2.Value, Is.EqualTo(DomainSubstrateEnum.AnotherOne));

            var res3 = _mapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se3);
            Assert.That(res3.Value, Is.EqualTo(DomainSubstrateEnum.TheFourth));
        }

        [Test]
        public void VersionnedCoreEnumExt_ToMappedEnum_ShouldSucceed()
        {
            var se1_1 = new EnumSubstrateEnumExt1();
            se1_1.Create(SubstrateEnumExt1.Awesome1, new BaseVoid());

            var se1_2 = new EnumSubstrateEnumExt1();
            se1_2.Create(SubstrateEnumExt1.Awesome2, new U32(4));

            var se2_1 = new EnumSubstrateEnumExt2();
            se2_1.Create(SubstrateEnumExt2.Awesome3, new Bool(true));

            var se2_2 = new EnumSubstrateEnumExt2();
            se2_2.Create(SubstrateEnumExt2.Awesome4, new U128(10));

            var se3_1 = new EnumSubstrateEnumExt3();
            se3_1.Create(SubstrateEnumExt3.Awesome1, new BaseVoid());

            var se3_2 = new EnumSubstrateEnumExt3();
            se3_2.Create(SubstrateEnumExt3.Awesome2, new U32(5));

            var se3_3 = new EnumSubstrateEnumExt3();
            se3_3.Create(SubstrateEnumExt3.Awesome4, new U128(11));

            var se3_4 = new EnumSubstrateEnumExt3();
            se3_4.Create(SubstrateEnumExt3.Awesome5, new BaseVoid());

            var res1 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se1_1);
            Assert.Multiple(() =>
            {
                Assert.That(res1.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res1.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res1.Value2.Encode(), Is.EqualTo(new BaseVoid().Encode()));
                Assert.That(res1.GetValues().Encode(), Is.EqualTo(new BaseVoid().Encode()));
            });

            var res2 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se1_2);
            Assert.Multiple(() =>
            {
                Assert.That(res2.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res2.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res2.Value2.As<U32>().Value, Is.EqualTo(4));
                Assert.That(res2.GetValues().As<U32>().Value, Is.EqualTo(4));
            });

            var res3 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se2_1);
            Assert.Multiple(() =>
            {
                Assert.That(res3.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome3));
                Assert.That(res3.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome3));
                Assert.That(res3.Value2.As<Bool>().Value, Is.True);
                Assert.That(res3.GetValues().As<Bool>().Value, Is.True);
            });

            var res4 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se2_2);
            Assert.Multiple(() =>
            {
                Assert.That(res4.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That(res4.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That((int)res4.Value2.As<U128>().Value, Is.EqualTo(10));
                Assert.That((int)res4.GetValues().As<U128>().Value, Is.EqualTo(10));
            });

            var res5 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_1);
            Assert.Multiple(() =>
            {
                Assert.That(res5.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res5.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res5.Value2.Encode(), Is.EqualTo(new BaseVoid().Encode()));
                Assert.That(res5.GetValues().Encode(), Is.EqualTo(new BaseVoid().Encode()));
            });

            var res6 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_2);
            Assert.Multiple(() =>
            {
                Assert.That(res6.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res6.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res6.Value2.As<U32>().Value, Is.EqualTo(5));
                Assert.That(res6.GetValues().As<U32>().Value, Is.EqualTo(5));
            });

            var res7 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_3);
            Assert.Multiple(() =>
            {
                Assert.That(res7.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That(res7.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That((int)res7.Value2.As<U128>().Value, Is.EqualTo(11));
                Assert.That((int)res7.GetValues().As<U128>().Value, Is.EqualTo(11));
            });

            var res8 = _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_4);
            Assert.Multiple(() =>
            {
                Assert.That(res8.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome5));
                Assert.That(res8.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome5));
                Assert.That(res8.Value2.Encode(), Is.EqualTo(new BaseVoid().Encode()));
                Assert.That(res8.GetValues().Encode(), Is.EqualTo(new BaseVoid().Encode()));
            });

            var res9 = (EnumSubstrateEnumExtDomain?)_mapper.MapEnum(se3_3, typeof(EnumSubstrateEnumExtDomain));
            Assert.That(res9, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(res9.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That(res9.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That((int)res9.Value2.As<U128>().Value, Is.EqualTo(11));
                Assert.That((int)res9.GetValues().As<U128>().Value, Is.EqualTo(11));
            });
        }

        [Test]
        public void VersionnedCoreEnumExt_WhenSourceEnumIsMissingFromDestinationEnum_ShouldFail()
        {
            var enum3 = new EnumSubstrateEnumExt4Error();
            enum3.Create(SubstrateEnumExt4Error.Awesome10, new U32(4));

            Assert.Throws<MissingMappingException>(() =>
            _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(enum3));
        }

        [Test]
        public void VersionnedCoreEnumExt_WhenDestinationTypeIsSmallerThanSourceType_ShouldFail()
        {
            var enum1 = new EnumSubstrateEnumExt4Error();
            enum1.Create(SubstrateEnumExt4Error.Awesome1, new U32(10));

            Assert.Throws<InvalidTypeSizeException>(() =>
            _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(enum1));
        }

        [Test]
        public void VersionnedCoreEnumExt_WhenDestinationTypeIsLargerThanSourceType_ShouldFail()
        {
            var enum2 = new EnumSubstrateEnumExt4Error();
            enum2.Create(SubstrateEnumExt4Error.Awesome2, new BaseVoid());

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            _mapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(enum2));
        }

        [Test]
        public void EnumExtTest_Test()
        {

            var se1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_balances.pallet.EnumError();
            se1.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_balances.pallet.Error.VestingBalance);

            //var res1 = _mapper.MapEnum<Contracts.Pallet.Balances.Enums.EnumError, Contracts.Pallet.Balances.Enums.Error>(se1);
            //Assert.That(res1.Value, Is.EqualTo(Contracts.Pallet.Balances.Enums.Error.VestingBalance));

            //var res2 = (Contracts.Pallet.Balances.Enums.EnumError)_mapper.MapEnum(se1, typeof(Contracts.Pallet.Balances.Enums.EnumError));
            //Assert.That(res2.Value, Is.EqualTo(Contracts.Pallet.Balances.Enums.Error.VestingBalance));

            var res3 = _mapper.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_balances.pallet.EnumError, Contracts.Pallet.Balances.Enums.EnumError>(se1);
            Assert.That(res3.Value, Is.EqualTo(Contracts.Pallet.Balances.Enums.Error.VestingBalance));

            var accountId32 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32();
            accountId32.Create("0x17316829C406A05CD9CDB8D5DE5FB23D26B3672F8CBCA1FCC6538833589A121A");
            var coreRes = new BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32, U128>(accountId32, new U128(10));
            var se2 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_balances.pallet.EnumEvent();
            se2.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_balances.pallet.Event.Endowed, coreRes);

            var domainRes = new BaseTuple<SubstrateAccount, U128>(new SubstrateAccount("1XQn94kWaMVJG16AWPKGmYFERfttsjZq4ompSTz2jxHK6uL"), new U128(10));
            var res4 = _mapper.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_balances.pallet.EnumEvent, Contracts.Pallet.Balances.Enums.EnumEvent>(se2);
            Assert.That(res4.Value, Is.EqualTo(Contracts.Pallet.Balances.Enums.Event.Endowed));
            Assert.That(res4.GetValues().Encode(), Is.EqualTo(domainRes.Encode()));
        }
    }

}
