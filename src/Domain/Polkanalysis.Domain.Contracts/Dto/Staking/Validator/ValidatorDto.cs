using Polkanalysis.Domain.Contracts.Dto.User;

namespace Polkanalysis.Domain.Contracts.Dto.Staking.Validator
{
    public class ValidatorDto
    {
        public required UserIdentityDto StashAddress { get; set; }
        public required UserIdentityDto ControllerAddress { get; set; }
        public required UserIdentityDto RewardAddress { get; set; }
        public GlobalStatusDto.AliveStatusDto Status { get; set; }
        public required double SelfBonded { get; set; }
        public required double TotalBonded { get; set; }
        public required double Commission { get; set; }
        public required IEnumerable<PublicDto> SessionKey { get; set; }
    }
}
