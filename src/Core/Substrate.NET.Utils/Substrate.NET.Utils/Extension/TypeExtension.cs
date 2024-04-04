using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static T Instanciate<T>(this Type sender)
        {
            object? destinationInstance = Activator.CreateInstance(sender);

            if (destinationInstance is null)
                throw new InvalidOperationException($"Cannot create instance of {sender}");

            var destination = (T)destinationInstance;
            if (destination is null)
                throw new InvalidCastException($"Unable to cast {sender.Name} to {nameof(IBaseEnum)}");

            return destination;
        }
    }
}
