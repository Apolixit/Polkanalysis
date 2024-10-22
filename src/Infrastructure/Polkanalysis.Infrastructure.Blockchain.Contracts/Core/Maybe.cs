using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Reflection;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core
{
    /// <summary>
    /// Class use to handle unmapped events from NetApiExt
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Maybe<T> : BaseType
        where T : IType, new()
    {
        public Maybe() { }

        public Maybe(T value)
        {
            Value = value;
            HasBeenMapped = new Bool(true);
        }

        public Maybe(T value, IType core) : this(core)
        {
            Value = value;
            HasBeenMapped = new Bool(true);
        }

        public Maybe(IType core)
        {
            Core = core;
            setCoreData();

            HasBeenMapped = new Bool(false);
        }

        private void setCoreData()
        {
            CoreType = Core.GetType();
            CoreAssemblyName = new Str(CoreType.Assembly.FullName);
            CoreTypeName = new Str(CoreType.FullName);
        }

        /// <summary>
        /// The mapped value (from Domain)
        /// </summary>
        public T? Value { get; set; }

        /// <summary>
        /// The core value (from ApiExt)
        /// </summary>
        public IType Core { get; set; }

        public Bool HasBeenMapped { get; set; }

        public override int TypeSize
        {
            get
            {
                return HasBeenMapped.Value ? Value!.TypeSize : Core.TypeSize;
            }
            set
            {
                if (HasBeenMapped)
                {
                    Value!.TypeSize = value;
                }
                else
                {
                    Core.TypeSize = value;
                }
            }
        }
        public Type CoreType { get; private set; }
        public Str CoreAssemblyName { get; private set; }
        public Str CoreTypeName { get; private set; }
        public Type DestinationType => typeof(T);

        public override byte[] Encode()
        {
            var result = new List<byte>();

            result.AddRange(HasBeenMapped.Encode());
            
            if(Core is not null)
            {
                result.AddRange(CoreAssemblyName.Encode());
                result.AddRange(CoreTypeName.Encode());
                result.AddRange(Core.Encode());
            } else
            {
                CoreAssemblyName = new Str("Unknown");
                result.AddRange(CoreAssemblyName.Encode());
            }

            if (HasBeenMapped)
                result.AddRange(Value!.Encode());

            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            HasBeenMapped = new Bool();
            HasBeenMapped.Decode(byteArray, ref p);

            CoreAssemblyName = new Str();
            CoreAssemblyName.Decode(byteArray, ref p);

            if(CoreAssemblyName.Value != "Unknown")
            {
                CoreTypeName = new Str();
                CoreTypeName.Decode(byteArray, ref p);

                try
                {
                    Assembly assembly = Assembly.Load(CoreAssemblyName.Value);
                    Type? enumType = assembly.GetType(CoreTypeName.Value);

                    Core = (IType?)Activator.CreateInstance(enumType);
                    Core.Decode(byteArray, ref p);
                } catch(Exception)
                {

                }
            }

            if (HasBeenMapped)
            {
                Value = new T();
                Value.Decode(byteArray, ref p);
            }
            TypeSize = p - start;
        }
    }
}
