using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata
{
    public class StorageType
    {
        public enum TypeV9
        {
            Plain,
            Map,
            DoubleMap
        }

        public enum Type
        {
            Plain,
            Map,
            DoubleMap,
            NMap
        }

        public enum ModifierV9
        {
            Optional,
            Default,
            Required
        }

        public enum Modifier
        {
            Optional,
            Default
        }

        public enum Hasher
        {
            None = -1,
            BlakeTwo128,
            BlakeTwo256,
            BlakeTwo128Concat,
            Twox128,
            Twox256,
            Twox64Concat,
            Identity
        }

        public enum HasherV9
        {
            None = -1,
            BlakeTwo128,
            BlakeTwo256,
            Twox128,
            Twox256,
            Twox64Concat,
        }

        public enum HasherV10
        {
            None = -1,
            BlakeTwo128,
            BlakeTwo256,
            BlakeTwo128Concat,
            Twox128,
            Twox256,
            Twox64Concat,
        }
    }
}
