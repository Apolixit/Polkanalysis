using Substrate.NetApi.Model.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Helpers
{
    public class SubstrateHelper
    {
        public static string getChangesetData(StorageChangeSet storageChangeSet)
        {
            if (storageChangeSet.Changes == null
                    || storageChangeSet.Changes.Length == 0
                    || storageChangeSet.Changes[0].Length < 2)
            {
                throw new System.Exception("Couldn't update account information. Please check 'CallBackAccountChange'");
            }


            var hexString = storageChangeSet.Changes[0][1];

            return hexString;
        }
    }
}
