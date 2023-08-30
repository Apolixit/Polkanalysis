using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils
{
    public static class TypeExtension
    {
        public static byte[]? GetBytes(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Bytes");
            if (prp != null)
                return (byte[])prp.GetValue(sender);
            else
                return null;
        }

        public static object? GetValue(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            if (prp != null)
                return prp.GetValue(sender);
            else
                return null;
        }

        public static object? GetValue(this IType sender, string propName)
        {
            var prp = sender.GetType().GetProperty(propName);
            if (prp != null)
                return prp.GetValue(sender);
            else
                return null;
        }

        public static object[]? GetValueArray(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            if (prp != null)
                return (object[])prp.GetValue(sender);
            else
                return null;
        }

        public static T As<T>(this IType sender)
        {
            if(sender is T typed)
            {
                return typed;
            }

            throw new InvalidCastException();
        }
    }
}
