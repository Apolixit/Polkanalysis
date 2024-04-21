using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;

namespace Substrate.NET.Utils
{
    public static class BaseEnumTypeExtension
    {
        //public static Enum GetEnumValue(this BaseEnumType sender)
        //    => GetEnumValue(sender);

        public static Enum? GetEnumValue(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            var e = (Enum?)prp?.GetValue(sender);

            //if (e is null)
            //    throw new InvalidCastException($"Unable to cast {sender.GetType().FullName} to {typeof(Enum).FullName}");

            return e;
        }

        //public static Enum? GetValue(this BaseEnumType sender)
        //{
        //    var prp = sender.GetType().GetProperty("Value");
        //    return (Enum?)prp?.GetValue(sender);
        //}

        //public static IType GetValue2(this BaseEnumType sender)
        //    => GetValue2(sender);

        public static IType GetValue2(this IType sender)
        {
            //IType? casted = null;
            if (sender is BaseEnumType)
            {
                var value2 = (IType?)sender.GetType().GetProperty("Value2")?.GetValue(sender);
                return value2 ?? new BaseVoid();
            } else if(sender.GetType().BaseType?.Name == "BaseEnum`1")
            {
                return new BaseVoid();
            }

            throw new InvalidCastException($"[Extension GetValue2()] Unable to cast {sender.GetType().FullName} to {typeof(IType).FullName}");
            //if (casted is null) 
            //    throw new InvalidCastException($"[Extension GetValue2()] Unable to cast {sender.GetType().FullName} to {typeof(IType).FullName}");

            //return casted;
        }

        //public static T GetValue<T>(this BaseEnum<T> sender) where T : Enum
        //{
        //    var prp = sender.GetType().GetProperty("Value");
        //    return (T)prp?.GetValue(sender);
        //}
    }
}
