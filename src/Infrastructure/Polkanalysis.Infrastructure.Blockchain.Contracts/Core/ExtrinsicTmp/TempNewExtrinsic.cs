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
        CompactInteger.Decode(memory.ToArray(), ref p);
        int num = 1;
        byte b = memory.Slice(p, num).ToArray()[0];
        Signed = b >= 128;
        TransactionVersion = (byte)(b - (Signed ? 128 : 0));
        p += num;
        if (Signed)
        {
            num = 1;
            _ = memory.Slice(p, num).ToArray()[0];
            p += num;
            num = 32;
            byte[] publicKey = memory.Slice(p, num).ToArray();
            p += num;
            num = 1;
            byte keyType = memory.Slice(p, num).ToArray()[0];
            p += num;
            Account account = new Account();
            account.Create((KeyType)keyType, publicKey);
            Account = account;
            num = 64;
            Signature = memory.Slice(p, num).ToArray();
            p += num;
            num = 1;
            byte[] array = memory.Slice(p, num).ToArray();
            if (array[0] != 0)
            {
                num = 2;
                array = memory.Slice(p, num).ToArray();
            }

            Era = Era.Decode(array);
            p += num;
            Nonce = CompactInteger.Decode(memory.ToArray(), ref p);
            Charge = chargeType;
            Charge.Decode(memory.ToArray(), ref p);
            CheckMetadataHash = new TempCheckMetadataHash();
            CheckMetadataHash.Decode(memory.ToArray(), ref p);
        }

        num = 2;
        byte[] array2 = memory.Slice(p, num).ToArray();
        p += num;
        byte[] parameters = memory.Slice(p).ToArray();
        Method = new Method(array2[0], array2[1], parameters);
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
        TransactionVersion = 4;
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
        List<byte> list = new List<byte>();
        byte item = (byte)((Signed ? 128 : 0) + TransactionVersion);
        list.Add(item);
        if (Signed)
        {
            list.AddRange(Account.Encode());
            list.Add(Account.KeyTypeByte);
            list.AddRange(Signature);
            list.AddRange(Era.Encode());
            list.AddRange(Nonce.Encode());
            list.AddRange(Charge.Encode());
            list.AddRange(CheckMetadataHash.EncodeExtra());
        }

        list.AddRange(Method.Encode());
        list.InsertRange(0, new CompactInteger(list.Count).Encode());
        return list.ToArray();
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