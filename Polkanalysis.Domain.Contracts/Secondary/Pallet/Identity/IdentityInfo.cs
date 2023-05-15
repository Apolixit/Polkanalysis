using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity.Enums;
using System.Text;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity
{
    public class IdentityInfo : BaseType
    {
        public EnumData Display { get; set; }
        public EnumData Legal { get; set; }
        public EnumData Web { get; set; }
        public EnumData Riot { get; set; }
        public EnumData Email { get; set; }
        public BaseOpt<FlexibleNameable> PgpFingerprint { get; set; }
        public EnumData Twitter { get; set; }
        public EnumData Image { get; set; }
        public BaseVec<BaseTuple<EnumData, EnumData>> Additional { get; set; }

        public IdentityInfo() { }

        public IdentityInfo From(
            string? display, 
            string? legal, 
            string? web, 
            string? riot,
            string? email, 
            string? pgpFingerprint, 
            string? twitter,
            string? image,
            BaseVec<BaseTuple<EnumData, EnumData>> additional)
        {
            var nameableFingerprint = pgpFingerprint == null ? 
                null : 
                new FlexibleNameable(Utils.Bytes2HexString(Encoding.Default.GetBytes(pgpFingerprint)));

            Create(
                BuildEnumData(display),   
                BuildEnumData(legal),   
                BuildEnumData(web),   
                BuildEnumData(riot),   
                BuildEnumData(email),
                new BaseOpt<FlexibleNameable>(nameableFingerprint),   
                BuildEnumData(twitter),   
                BuildEnumData(image),
                additional
            );
            //var displayEnumData = new EnumData();
            //displayEnumData.Create(Data.)

            return this;
        }

        public IdentityInfo(EnumData display, EnumData legal, EnumData web, EnumData riot, EnumData email, BaseOpt<FlexibleNameable> pgpFingerprint, EnumData twitter, EnumData image, BaseVec<BaseTuple<EnumData, EnumData>> additional)
        {
            Create(display, legal, web, riot, email, pgpFingerprint, twitter, image, additional);
        }

        // Return adapter data enum from given string
        private Data CalcData(string? value)
        {
            if(value ==  null) return Data.None;

            return value.Length switch
            {
                0 => Data.Raw0,
                1 => Data.Raw1,
                2 => Data.Raw2,
                3 => Data.Raw3,
                4 => Data.Raw4,
                5 => Data.Raw5,
                6 => Data.Raw6,
                7 => Data.Raw7,
                8 => Data.Raw8,
                9 => Data.Raw9,
                10 => Data.Raw10,
                11 => Data.Raw11,
                12 => Data.Raw12,
                13 => Data.Raw13,
                14 => Data.Raw14,
                15 => Data.Raw15,
                16 => Data.Raw16,
                17 => Data.Raw17,
                18 => Data.Raw18,
                19 => Data.Raw19,
                20 => Data.Raw20,
                21 => Data.Raw21,
                22 => Data.Raw22,
                23 => Data.Raw23,
                24 => Data.Raw24,
                25 => Data.Raw25,
                26 => Data.Raw26,
                27 => Data.Raw27,
                28 => Data.Raw28,
                29 => Data.Raw29,
                30 => Data.Raw30,
                31 => Data.Raw31,
                32 => Data.Raw32,
                _ => Data.Raw32,
            };
        }

        private EnumData BuildEnumData(string? value)
        {
            var nameable = new FlexibleNameable(string.Empty);
            if (!string.IsNullOrEmpty(value))
                nameable = new FlexibleNameable(Utils.Bytes2HexString(Encoding.Default.GetBytes(value)));

            return new EnumData(CalcData(value), nameable);
        }

        public void Create(EnumData display, EnumData legal, EnumData web, EnumData riot, EnumData email, BaseOpt<FlexibleNameable> pgpFingerprint, EnumData twitter, EnumData image, BaseVec<BaseTuple<EnumData, EnumData>> additional)
        {
            Display = display;
            Legal = legal;
            Web = web;
            Riot = riot;
            Email = email;
            PgpFingerprint = pgpFingerprint;
            Twitter = twitter;
            Image = image;
            Additional = additional;

            Bytes = Encode();

            TypeSize = Display.TypeSize + Legal.TypeSize + Web.TypeSize + Riot.TypeSize + Email.TypeSize + PgpFingerprint.TypeSize + Twitter.TypeSize + Image.TypeSize + Additional.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Additional.Encode());
            result.AddRange(Display.Encode());
            result.AddRange(Legal.Encode());
            result.AddRange(Web.Encode());
            result.AddRange(Riot.Encode());
            result.AddRange(Email.Encode());
            result.AddRange(PgpFingerprint.Encode());
            result.AddRange(Image.Encode());
            result.AddRange(Twitter.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Additional = new BaseVec<BaseTuple<EnumData, EnumData>>();
            Additional.Decode(byteArray, ref p);
            Display = new EnumData();
            Display.Decode(byteArray, ref p);
            Legal = new EnumData();
            Legal.Decode(byteArray, ref p);
            Web = new EnumData();
            Web.Decode(byteArray, ref p);
            Riot = new EnumData();
            Riot.Decode(byteArray, ref p);
            Email = new EnumData();
            Email.Decode(byteArray, ref p);
            PgpFingerprint = new BaseOpt<FlexibleNameable>();
            PgpFingerprint.Decode(byteArray, ref p);
            Image = new EnumData();
            Image.Decode(byteArray, ref p);
            Twitter = new EnumData();
            Twitter.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
