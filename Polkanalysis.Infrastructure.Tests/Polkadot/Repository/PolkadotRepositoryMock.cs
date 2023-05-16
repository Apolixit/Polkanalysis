using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using System.Text;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Tests.Polkadot.Repository
{
    public abstract class PolkadotRepositoryMock
    {
        protected PolkadotRepository _substrateRepository;

        public const string MockAddress = "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS";
        public const string MockAddress2 = "13b9d23v1Hke7pcVk8G4gh3TBckDtrwFZUnqPkHezq4praEY";
        public const string PublicSr25519_Signature_1 = "0x66F60202B962C40E58FCF3481F5773DC178B9FE096F81511EAA4C7BAD20E6120";
        public const string PublicSr25519_Signature_2 = "0x9C40155989F6072E82CABA245D7DB7E40A60F866B403257976B89ABA6BE2B55B";

        public Func<string, U8[]> PublicSr25519_Signature_U8Array =>
            (string signature) =>
            Utils.HexToByteArray(signature).Select(x => new U8(x)).ToArray();

        #region Storage simple test case
        public static IList<U64> U64TestCase => new List<U64>() {
               new U64(0),
               new U64(1),
               new U64(10),
               new U64(100),
               new U64(1000000)
        };

        public static IList<U32> U32TestCase => new List<U32>() {
               new U32(0),
               new U32(1),
               new U32(10),
               new U32(100),
               new U32(1000000)
        };

        public static IList<U128> U128TestCase => new List<U128>() {
               new U128(0),
               new U128(1),
               new U128(10),
               new U128(100),
               new U128(1000000)
        };
        #endregion

        [SetUp]
        public void Setup()
        {
            var polkadotRepository = new PolkadotRepository(
                Substitute.For<ISubstrateEndpoint>(),
                Substitute.For<ILogger<PolkadotRepository>>()
                );

            // Mock a part of Substrate Client call
            polkadotRepository.PolkadotClient = Substitute.ForPartsOf<SubstrateClientExt>(
                new Uri("wss://rpc.polkadot.io"), 
                ChargeTransactionPayment.Default());

            // Allow unit test to mock GetStorageAsyncCall
            polkadotRepository.PolkadotClient.WhenForAnyArgs(x => x.GetStorageAsync<U32>(
                Arg.Any<string>(), 
                Arg.Any<string>(), 
                Arg.Is(CancellationToken.None))).DoNotCallBase();
            
            _substrateRepository = polkadotRepository;
        }

        public void BuildRepository()
        {
            var polkadotRepository = new PolkadotRepository(
                Substitute.For<ISubstrateEndpoint>(),
                Substitute.For<ILogger<PolkadotRepository>>()
                );

            _substrateRepository = polkadotRepository;
        }

        /// <summary>
        /// Mock a storage call
        /// </summary>
        /// <typeparam name="T">Data result</typeparam>
        /// <param name="expectedResult">Expected result from GetStorageAsync call and after mapping</param>
        /// <param name="storageCall">Storage function to call</param>
        /// <returns></returns>
        protected Task MockStorageCallAsync<T>(T expectedResult, Func<CancellationToken, Task<T>> storageCall)
            where T : IType, new()
            => MockStorageCallAsync(expectedResult, expectedResult, storageCall);

        /// <summary>
        /// Mock a storage call
        /// </summary>
        /// <typeparam name="R">Type return by Ajuna NetApiExt</typeparam>
        /// <typeparam name="T">Type mapped to Domain.Contracts</typeparam>
        /// <param name="storageResult">Storage result (data return by GetStorageAsync call)</param>
        /// <param name="expectedResult">Object after mapping</param>
        /// <param name="storageCall">Storage function to call</param>
        /// <returns></returns>
        protected async Task MockStorageCallAsync<R, T>(
            R storageResult, 
            T expectedResult, 
            Func<CancellationToken, Task<T>> storageCall)
            where R : IType, new()
            where T : IType, new()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<R>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(storageResult);

            var res = await storageCall(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Encode(), Is.EqualTo(expectedResult.Encode()));
        }

        /// <summary>
        /// Mock a storage call
        /// </summary>
        /// <typeparam name="I">Input parameter type</typeparam>
        /// <typeparam name="T">Data result</typeparam>
        /// <param name="input">Input params</param>
        /// <param name="expectedResult">Expected result from GetStorageAsync call and after mapping</param>
        /// <param name="storageCall">Storage function to call</param>
        /// <returns></returns>
        protected async Task MockStorageCallWithInputAsync<I,T>(I input, T expectedResult, Func<I, CancellationToken, Task<T>> storageCall)
            where I : IType, new()
            where T : IType, new()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<T>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(expectedResult);

            var res = await storageCall(input, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Encode(), Is.EqualTo(expectedResult.Encode()));
        }

        /// <summary>
        /// Mock a storage call
        /// </summary>
        /// <typeparam name="I">Input parameter type</typeparam>
        /// <typeparam name="R">Type return by Ajuna NetApiExt</typeparam>
        /// <typeparam name="T">Type mapped to Domain.Contracts</typeparam>
        /// <param name="input">Input params</param>
        /// <param name="storageResult">Storage result (data return by GetStorageAsync call)</param>
        /// <param name="expectedResult">Object after mapping</param>
        /// <param name="storageCall">Storage function to call</param>
        /// <returns></returns>
        protected async Task MockStorageCallWithInputAsync<I, R, T>(
            I input, 
            R storageResult, 
            T expectedResult, 
            Func<I, CancellationToken, Task<T>> storageCall)
            where I : IType, new()
            where R : IType, new()
            where T : IType, new()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<R>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(storageResult);

            var res = await storageCall(input, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Encode(), Is.EqualTo(expectedResult.Encode()));
        }

        /// <summary>
        /// Mock a storage call and force it to return null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storageCall">Function to call</param>
        /// <returns></returns>

        protected async Task<T> MockStorageCallNullAsync<T>(Func<CancellationToken, Task<T>> storageCall)
            where T : IType, new()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<T>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(default(T));

            var res = await storageCall(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.GetBytes(), Is.Null);
            return res;
        }

        protected async Task<T> MockStorageCallNullAsync<R, T>(Func<CancellationToken, Task<T>> storageCall)
            where R : IType, new()
            where T : IType, new()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<R>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(default(R));

            var res = await storageCall(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.GetBytes(), Is.Null);
            return res;
        }

        protected async Task<T> MockStorageCallNullWithInputAsync<I, R, T>(I input, Func<I, CancellationToken, Task<T>> storageCall)
            where I : IType, new()
            where R : IType, new()
            where T : IType, new()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<R>(
                Arg.Any<string>(),
                Arg.Any<string>(),
                CancellationToken.None).Returns(default(R));

            var res = await storageCall(input, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.GetBytes(), Is.Null);
            return res;
        }
        protected async Task<T> MockStorageCallNullWithInputAsync<I, T>(I input, Func<I, CancellationToken, Task<T>> storageCall)
            where T : IType, new()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<T>(
                Arg.Any<string>(),
                Arg.Any<string>(),
                CancellationToken.None).Returns(default(T));

            var res = await storageCall(input, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.GetBytes(), Is.Null);
            return res;
        }
    }
}
