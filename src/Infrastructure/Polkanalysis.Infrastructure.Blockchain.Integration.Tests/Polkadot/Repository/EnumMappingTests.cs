using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Test;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository
{
    

    public class EnumMappingTests
    {
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

            var res1 = PolkadotMapping.Instance.Map<BaseEnum<SubstrateEnum1>, BaseEnum<DomainSubstrateEnum>>(se1);
            Assert.That(res1.Value, Is.EqualTo(DomainSubstrateEnum.PrimaryAndSecondaryPlainSlots));

            var res2_1 = PolkadotMapping.Instance.Map<BaseEnum<SubstrateEnum2>, BaseEnum<DomainSubstrateEnum>>(se2_1);
            Assert.That(res2_1.Value, Is.EqualTo(DomainSubstrateEnum.PrimarySlots));

            var res2_2 = PolkadotMapping.Instance.Map<BaseEnum<SubstrateEnum2>, BaseEnum<DomainSubstrateEnum>>(se2_2);
            Assert.That(res2_2.Value, Is.EqualTo(DomainSubstrateEnum.AnotherOne));

            var res3 = PolkadotMapping.Instance.Map<BaseEnum<SubstrateEnum3>, BaseEnum<DomainSubstrateEnum>>(se3);
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

            var res1 = TestMapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se1);
            Assert.That(res1.Value, Is.EqualTo(DomainSubstrateEnum.PrimaryAndSecondaryPlainSlots));

            var res2_1 = TestMapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se2_1);
            Assert.That(res2_1.Value, Is.EqualTo(DomainSubstrateEnum.PrimarySlots));

            var res2_2 = TestMapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se2_2);
            Assert.That(res2_2.Value, Is.EqualTo(DomainSubstrateEnum.AnotherOne));

            var res3 = TestMapper.MapEnum<EnumDomainSubstrateEnum, DomainSubstrateEnum>(se3);
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

            var res1 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se1_1);
            Assert.Multiple(() => {
                Assert.That(res1.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res1.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res1.Value2.Encode(), Is.EqualTo(new BaseVoid().Encode()));
                Assert.That(res1.GetValues().Encode(), Is.EqualTo(new BaseVoid().Encode()));
            });

            var res2 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se1_2);
            Assert.Multiple(() => {
                Assert.That(res2.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res2.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res2.Value2.As<U32>().Value, Is.EqualTo(4));
                Assert.That(res2.GetValues().As<U32>().Value, Is.EqualTo(4));
            });

            var res3 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se2_1);
            Assert.Multiple(() =>
            {
                Assert.That(res3.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome3));
                Assert.That(res3.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome3));
                Assert.That(res3.Value2.As<Bool>().Value, Is.True);
                Assert.That(res3.GetValues().As<Bool>().Value, Is.True);
            });

            var res4 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se2_2);
            Assert.Multiple(() => {
                Assert.That(res4.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That(res4.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That((int)res4.Value2.As<U128>().Value, Is.EqualTo(10));
                Assert.That((int)res4.GetValues().As<U128>().Value, Is.EqualTo(10));
            });

            var res5 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_1);
            Assert.Multiple(() => {
                Assert.That(res5.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res5.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome1));
                Assert.That(res5.Value2.Encode(), Is.EqualTo(new BaseVoid().Encode()));
                Assert.That(res5.GetValues().Encode(), Is.EqualTo(new BaseVoid().Encode()));
            });

            var res6 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_2);
            Assert.Multiple(() => {
                Assert.That(res6.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res6.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome2));
                Assert.That(res6.Value2.As<U32>().Value, Is.EqualTo(5));
                Assert.That(res6.GetValues().As<U32>().Value, Is.EqualTo(5));
            });

            var res7 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_3);
            Assert.Multiple(() => {
                Assert.That(res7.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That(res7.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome4));
                Assert.That((int)res7.Value2.As<U128>().Value, Is.EqualTo(11));
                Assert.That((int)res7.GetValues().As<U128>().Value, Is.EqualTo(11));
            });

            var res8 = TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(se3_4);
            Assert.Multiple(() => {
                Assert.That(res8.Value, Is.EqualTo(SubstrateEnumExtDomain.Awesome5));
                Assert.That(res8.GetEnum(), Is.EqualTo(SubstrateEnumExtDomain.Awesome5));
                Assert.That(res8.Value2.Encode(), Is.EqualTo(new BaseVoid().Encode()));
                Assert.That(res8.GetValues().Encode(), Is.EqualTo(new BaseVoid().Encode()));
            });
        }

        [Test]
        public void VersionnedCoreEnumExt_WhenSourceEnumIsMissingFromDestinationEnum_ShouldFail()
        {
            var enum3 = new EnumSubstrateEnumExt4Error();
            enum3.Create(SubstrateEnumExt4Error.Awesome10, new U32(4));

            Assert.Throws<MissingMappingException>(() => 
            TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(enum3));
        }

        [Test]
        public void VersionnedCoreEnumExt_WhenDestinationTypeIsSmallerThanSourceType_ShouldFail()
        {
            var enum1 = new EnumSubstrateEnumExt4Error();
            enum1.Create(SubstrateEnumExt4Error.Awesome1, new U32(10));

            Assert.Throws<InvalidTypeSizeException>(() =>
            TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(enum1));
        }

        [Test]
        public void VersionnedCoreEnumExt_WhenDestinationTypeIsLargerThanSourceType_ShouldFail()
        {
            var enum2 = new EnumSubstrateEnumExt4Error();
            enum2.Create(SubstrateEnumExt4Error.Awesome2, new BaseVoid());

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            TestMapper.MapEnum<EnumSubstrateEnumExtDomain, SubstrateEnumExtDomain>(enum2));
        }
    }
}
