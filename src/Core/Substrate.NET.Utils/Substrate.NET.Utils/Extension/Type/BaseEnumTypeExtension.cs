using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;

namespace Substrate.NET.Utils
{
    public static class BaseEnumTypeExtension
    {
        public static Enum? GetEnumValue(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            var e = (Enum?)prp?.GetValue(sender);

            return e;
        }

        public static IType GetValue2(this IType sender)
        {
            if (sender is BaseEnumType)
            {
                var value2 = (IType?)sender.GetType().GetProperty("Value2")?.GetValue(sender);
                return value2 ?? new BaseVoid();
            } else if(sender.GetType().BaseType?.Name == "BaseEnum`1")
            {
                return new BaseVoid();
            }

            throw new InvalidCastException($"[Extension GetValue2()] Unable to cast {sender.GetType().FullName} to {typeof(IType).FullName}");
        }
    }
}
