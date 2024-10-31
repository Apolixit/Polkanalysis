using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;

//
// Summary:
//     Extrinsic
public class TempNewExtrinsic : IExtrinsic
{
    //
    // Summary:
    //     Signed
    public bool Signed { get; set; }

    //
    // Summary:
    //     Transaction Version
    public byte TransactionVersion { get; set; }

    //
    // Summary:
    //     Account
    public Account Account { get; set; }

    //
    // Summary:
    //     Era
    public Era Era { get; set; }

    //
    // Summary:
    //     Nonce
    public CompactInteger Nonce { get; set; }

    //
    // Summary:
    //     Charge
    public ChargeType Charge { get; set; }

    //
    // Summary:
    //     Method
    public Method Method { get; set; }

    //
    // Summary:
    //     CheckMetadataHash
    public TempCheckMetadataHash CheckMetadataHash { get; set; }

    //
    // Summary:
    //     Signature
    public byte[] Signature { get; set; }

    //
    // Summary:
    //     Initializes a new instance of the Substrate.NetApi.Model.Extrinsics.Extrinsic
    //     class.
    //
    // Parameters:
    //   str:
    //     The string.
    //
    //   chargeType:
    public TempNewExtrinsic(string str, ChargeType chargeType)
        : this(Utils.HexToByteArray(str).AsMemory(), chargeType)
    {
    }

    //
    // Summary:
    //     Initializes a new instance of the Substrate.NetApi.Model.Extrinsics.Extrinsic
    //     class.
    //
    // Parameters:
    //   memory:
    //
    //   chargeType:
    internal TempNewExtrinsic(Memory<byte> memory, ChargeType chargeType)
    {
        int p = 0;
        int m;

        // length
        _ = CompactInteger.Decode(memory.ToArray(), ref p);

        // signature version
        m = 1;
        var _signatureVersion = memory.Slice(p, m).ToArray()[0];
        Signed = _signatureVersion >= 0x80;
        TransactionVersion = (byte)(_signatureVersion - (Signed ? 0x80 : 0x00));
        p += m;

        // this part is for signed extrinsics
        if (Signed)
        {
            // start bytes
            m = 1;
            _ = memory.Slice(p, m).ToArray()[0];
            p += m;

            // sender public key
            m = 32;
            var _senderPublicKey = memory.Slice(p, m).ToArray();
            p += m;

            // sender public key type
            m = 1;
            var _senderPublicKeyType = memory.Slice(p, m).ToArray()[0];
            p += m;

            var account = new Account();
            account.Create((KeyType)_senderPublicKeyType, _senderPublicKey);
            Account = account;

            // signature
            m = 64;
            Signature = memory.Slice(p, m).ToArray();
            p += m;

            // era
            m = 1;
            var era = memory.Slice(p, m).ToArray();
            if (era[0] != 0)
            {
                m = 2;
                era = memory.Slice(p, m).ToArray();
            }
            Era = Era.Decode(era);
            p += m;

            // nonce
            Nonce = CompactInteger.Decode(memory.ToArray(), ref p);

            // charge type
            Charge = chargeType;
            Charge.Decode(memory.ToArray(), ref p);

            CheckMetadataHash = new TempCheckMetadataHash();
            CheckMetadataHash.Decode(memory.ToArray(), ref p);
        }

        // method
        m = 2;
        var method = memory.Slice(p, m).ToArray();
        p += m;

        // parameters
        var parameter = memory.Slice(p).ToArray();

        Method = new Method(method[0], method[1], parameter);
    }

    //
    // Summary:
    //     Initializes a new instance of the Substrate.NetApi.Model.Extrinsics.Extrinsic
    //     class.
    //
    // Parameters:
    //   signed:
    //     if set to true [signed].
    //
    //   account:
    //     The account.
    //
    //   nonce:
    //     The nonce.
    //
    //   method:
    //     The method.
    //
    //   era:
    //     The era.
    //
    //   charge:
    public TempNewExtrinsic(bool signed, Account account, CompactInteger nonce, Method method, Era era, ChargeType charge)
    {
        Signed = signed;
        TransactionVersion = Constants.ExtrinsicVersion;
        Account = account;
        Era = era;
        Nonce = nonce;
        Charge = charge;
        CheckMetadataHash = new TempCheckMetadataHash();
        Method = method;
    }

    //
    // Summary:
    //     Encodes this instance.
    public byte[] Encode()
    {
        var result = new List<byte>();

        var signatureVersion = (byte)((Signed ? 0x80 : 0x00) + TransactionVersion);
        result.Add(signatureVersion);

        if (Signed)
        {
            result.AddRange(Account.Encode());
            result.Add(Account.KeyTypeByte);
            result.AddRange(Signature);
            result.AddRange(Era.Encode());
            result.AddRange(Nonce.Encode());
            result.AddRange(Charge.Encode());
            result.AddRange(CheckMetadataHash.EncodeExtra());
        }

        result.AddRange(Method.Encode());

        var length = new CompactInteger(result.Count);
        result.InsertRange(0, length.Encode());

        return result.ToArray();
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ExtrinsicNewJsonConverter : JsonConverter<TempNewExtrinsic>
{
    private readonly ChargeType _chargeType;

    public ExtrinsicNewJsonConverter(ChargeType chargeType)
    {
        _chargeType = chargeType;
    }

    /// <summary>Reads the JSON representation of the object.</summary>
    /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
    /// <param name="hasExistingValue">The existing value has a value.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>The object value.</returns>
    public override TempNewExtrinsic ReadJson(JsonReader reader, Type objectType, TempNewExtrinsic existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        return new TempNewExtrinsic((string)reader.Value, _chargeType);
    }

    /// <summary>Writes the JSON representation of the object.</summary>
    /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <exception cref="NotImplementedException"></exception>
    public override void WriteJson(JsonWriter writer, TempNewExtrinsic value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}