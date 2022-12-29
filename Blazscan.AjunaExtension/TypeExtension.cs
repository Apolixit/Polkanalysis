using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Polkadot.NetApiExt.Generated.Model.primitive_types;

namespace Blazscan.AjunaExtension
{
    public static class TypeExtension
    {
        public static Enum? GetValue(this BaseEnumType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            return (Enum?)prp?.GetValue(sender);
        }

        public static IType? GetValue2(this BaseEnumType sender)
        {
            var prp = sender.GetType().GetProperty("Value2");
            return (IType?)prp?.GetValue(sender);
        }

        public static T GetValue<T>(this BaseEnum<T> sender) where T : Enum
        {
            var prp = sender.GetType().GetProperty("Value");
            return (T)prp?.GetValue(sender);
        }

        public static T GetValue<T>(this BasePrim<T> sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            return (T)prp.GetValue(sender);
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

        public static H256? GetValue(this H256 sender)
        {
            return sender;
        }

        public static object[]? GetValueArray(this IType sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            if (prp != null)
                return (object[])prp.GetValue(sender);
            else
                return null;
        }
    }
}
