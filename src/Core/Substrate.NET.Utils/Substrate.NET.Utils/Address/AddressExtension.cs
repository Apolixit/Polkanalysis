using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils.Address
{
    public static class AddressExtension
    {
        public static bool IsValidAccountAddress(string address)
        {
            try
            {
                _ = NetApi.Utils.GetPublicKeyFrom(address);
                return true;
            } catch(Exception _)
            {
                return false;
            }
        }

        public static bool IsValidPublicKey(string publicKey)
        {
            try
            {
                var account = new AccountId(publicKey);
                return account.Bytes.Length > 0;
            }
            catch (Exception _)
            {
                return false;
            }
        }
    }
}
