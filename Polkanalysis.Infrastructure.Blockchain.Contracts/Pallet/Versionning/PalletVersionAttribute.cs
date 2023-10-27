namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Versionning
{
    /// <summary>
    /// Define pallet version
    /// What is very important, is when blockEnd is not set, it should be equal to uint.MaxValue
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class PalletVersionAttribute : Attribute
    {
        public PalletVersionAttribute(string blockchainName, string name, uint blockStart, uint blockEnd)
        {
            BlockchainName = blockchainName;
            StorageName = name;
            BlockStart = blockStart;
            BlockEnd = blockEnd;
        }

        public string BlockchainName { get; set; }
        public string StorageName { get; set; }
        public uint BlockStart { get; set; }
        public uint BlockEnd { get; set; }
    }
}
