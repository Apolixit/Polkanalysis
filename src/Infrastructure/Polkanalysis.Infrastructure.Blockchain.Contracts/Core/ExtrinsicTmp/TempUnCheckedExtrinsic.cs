using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;

//
// Summary:
//     Unchecked Extrinsic
public class TempUnCheckedExtrinsic : TempNewExtrinsic
{
    //
    // Summary:
    //     Genesis Hash
    private Hash Genesis { get; }

    //
    // Summary:
    //     Start Era
    private Hash StartEra { get; }

    //
    // Summary:
    //     Initializes a new instance of the Substrate.NetApi.Model.Extrinsics.UnCheckedExtrinsic
    //     class.
    //
    // Parameters:
    //   signed:
    //     if set to true [signed].
    //
    //   account:
    //     The account.
    //
    //   method:
    //     The method.
    //
    //   era:
    //     The era.
    //
    //   nonce:
    //     The nonce.
    //
    //   charge:
    //
    //   genesis:
    //     The genesis.
    //
    //   startEra:
    //     The start era.
    public TempUnCheckedExtrinsic(bool signed, Account account, Method method, Era era, CompactInteger nonce, ChargeType charge, Hash genesis, Hash startEra, uint addressVersion, bool checkMetadata)
        : base(signed, account, nonce, method, era, charge)
    {
        Genesis = genesis;
        StartEra = startEra;
        AddressVersion = addressVersion;
        CheckMetadata = checkMetadata;
    }

    //
    // Summary:
    //     Gets the payload.
    //
    // Parameters:
    //   runtime:
    //     The runtime.
    public TempPayload GetPayload(RuntimeVersion runtime)
    {
        return new TempPayload(Method, new TempSignedExtensions(runtime.SpecVersion, runtime.TransactionVersion, Genesis, StartEra, Era, Nonce, Charge, CheckMetadata));
    }

    //
    // Summary:
    //     Adds the payload signature.
    //
    // Parameters:
    //   signature:
    //     The signature.
    public void AddPayloadSignature(byte[] signature)
    {
        Signature = signature;
    }

    public uint AddressVersion;

    public bool CheckMetadata;

    /// <summary>
    /// https://polkadot.js.org/docs/api/FAQ/#i-cannot-send-transactions-sending-yields-decoding-failures
    /// </summary>
    public byte[] AccountEncode()
    {
        List<byte> list = new List<byte>();
        switch (AddressVersion)
        {
            case 0u:
                return Account.Bytes;
            case 1u:
                list.Add(byte.MaxValue);
                list.AddRange(Account.Bytes);
                return list.ToArray();
            case 2u:
                list.Add(0);
                list.AddRange(Account.Bytes);
                return list.ToArray();
            default:
                throw new NotImplementedException("Unknown address version please refer to PlutoAccountBase");
        }
    }

    //
    // Summary:
    //     Encode this instance, returns the encoded bytes.
    //
    // Exceptions:
    //   T:System.NotSupportedException:
    public new byte[] Encode()
    {
        if (Signed && Signature == null)
        {
            throw new NotSupportedException("Missing payload signature for signed transaction.");
        }

        List<byte> list = new List<byte>();
        list.Add((byte)(4u | (Signed ? 128u : 0u)));
        list.AddRange(AccountEncode());
        list.Add(Account.KeyTypeByte);
        if (Signature != null)
        {
            list.AddRange(Signature);
        }

        list.AddRange(Era.Encode());
        list.AddRange(Nonce.Encode());
        list.AddRange(Charge.Encode());
        if (CheckMetadata)
        {
            list.AddRange(CheckMetadataHash.EncodeExtra());
        }
        list.AddRange(Method.Encode());
        return Utils.SizePrefixedByteArray(list);
    }
}

public static class TempUnCheckedExtrinsicHelper
{
    public static TempUnCheckedExtrinsic ToTempUnCheckedExtrinsic(this UnCheckedExtrinsic original, Payload originalPayload, uint addressVersion, bool checkMetadata)
    {
        return new TempUnCheckedExtrinsic
        (
            signed: original.Signed,
            account: original.Account,
            method: original.Method,
            era: original.Era,
            nonce: original.Nonce,
            charge: original.Charge,
            genesis: originalPayload.SignedExtension.Genesis,
            startEra: originalPayload.SignedExtension.StartEra,
            addressVersion: addressVersion,
            checkMetadata: checkMetadata
        );
    }
}