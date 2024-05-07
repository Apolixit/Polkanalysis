using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

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

        public static T GetValue<T>(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            if (prp != null && prp.GetValue(sender) is T prpType) return prpType;

            throw new InvalidCastException($"Unable to cast {sender.GetType().FullName} to {typeof(T).FullName}");
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

        public static T[] GetValueArray<T>(this IType sender)
            where T : IType
        {
            var prp = sender.GetType().GetProperty("Value");
            if (prp != null && prp.GetValue(sender) is T[] prpType) return prpType;

            throw new InvalidCastException($"Unable to cast {sender.GetType().FullName} to {typeof(T).FullName}");
        }

        public static T As<T>(this IType sender)
        {
            if (sender is T typed)
            {
                return typed;
            }

            throw new InvalidCastException($"Unable to cast {sender.GetType().FullName} to {typeof(T).FullName}");
        }

        /// <summary>
        /// Cast the data to the specified enum GetValue2 type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static U CastToEnumValues<T, U>(this IType data)
            where T : BaseEnumType
            where U : IType
            => data.As<T>().GetValue2().As<U>();

        public static T Instanciate<T>(this Type sender)
        {
            object? destinationInstance = Activator.CreateInstance(sender);

            if (destinationInstance is null)
                throw new InvalidOperationException($"Cannot create instance of {sender}");

            var destination = (T?)destinationInstance;
            if (destination is null)
                throw new InvalidCastException($"Unable to cast {sender.Name} to {nameof(T)}");

            return destination!;
        }
    }
}
