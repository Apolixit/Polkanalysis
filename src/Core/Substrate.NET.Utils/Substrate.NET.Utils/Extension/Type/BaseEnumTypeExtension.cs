using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Types.Base.Abstraction;

namespace Substrate.NET.Utils
{
    public static class BaseEnumTypeExtension
    {
        public static Enum? GetValue(this IBaseEnum sender)
        {
            var prp = sender.GetType().GetProperty("Value");
            return (Enum?)prp?.GetValue(sender);
        }

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
    }
}
