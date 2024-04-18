using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;

namespace Substrate.NET.Utils
{
    public static class BaseEnumTypeExtension
    {
        public static Enum GetEnumValue(this BaseEnumType sender)
            => GetEnumValue(sender);

        public static Enum? GetEnumValue(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            var e = (Enum?)prp?.GetValue(sender);

            if (e is null)
                throw new InvalidCastException($"Unable to cast {sender.GetType().FullName} to {typeof(Enum).FullName}");

            return e;
        }

        public static Enum? GetValue(this BaseEnumType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            return (Enum?)prp?.GetValue(sender);
        }

        public static IType GetValue2(this BaseEnumType sender)
            => GetValue2(sender);

        public static IType GetValue2(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value2");
            var casted = (IType?)prp?.GetValue(sender);

            if(casted is null) 
                throw new InvalidCastException($"Unable to cast {sender.GetType().FullName} to {typeof(IType).FullName}");

            return (IType)casted;
        }

        public static T GetValue<T>(this BaseEnum<T> sender) where T : Enum
        {
            var prp = sender.GetType().GetProperty("Value");
            return (T)prp?.GetValue(sender);
        }
    }
}
