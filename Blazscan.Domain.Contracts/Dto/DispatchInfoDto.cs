using Blazscan.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch;

namespace Blazscan.Domain.Contracts
{
    public class DispatchInfoDto
    {
        public Pays PaysFee { get; set; }
        public DispatchClass Class { get; set; }
        public ulong Weight { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is DispatchInfoDto dto &&
                   PaysFee == dto.PaysFee &&
                   Class == dto.Class &&
                   Weight == dto.Weight;
        }
    }
}
