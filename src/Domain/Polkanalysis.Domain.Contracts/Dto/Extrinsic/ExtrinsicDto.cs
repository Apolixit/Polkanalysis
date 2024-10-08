using Polkanalysis.Domain.Contracts.Dto.User;

namespace Polkanalysis.Domain.Contracts.Dto.Extrinsic
{
    public class ExtrinsicDto
    {
        public required string ExtrinsicId { get; set; }
        public required uint Index { get; set; }
        public required uint BlockNumber { get; set; }
        public LifetimeDto? Lifetime { get; set; }
        public required string Hash { get; set; }
        public required string CallEventName { get; set; }
        public required string PalletName { get; set; }
        public AccountDto? Caller { get; set; }
        public double? EstimatedFees { get; set; }
        public double? RealFees { get; set; }
        public int Nonce { get; set; }
        public ExtrinsicStatusDto Status { get; set; }

        /// <summary>
        /// Decoded extrinsic displayed as a tree
        /// </summary>
        //public required INode Decoded { get; set; }
    }

    public class ExtrinsicStatusDto
    {
        protected ExtrinsicStatusDto() { }

        public static ExtrinsicStatusDto Success()
        {
            return new ExtrinsicStatusDto()
            {
                Status = ExtrinsicStatus.Success
            };
        }

        public static ExtrinsicStatusDto Error(string message)
        {
            return new ExtrinsicStatusDto()
            {
                Status = ExtrinsicStatus.Failed,
                Message = message
            };
        }

        public static ExtrinsicStatusDto System()
        {
            return new ExtrinsicStatusDto()
            {
                Status = ExtrinsicStatus.System
            };
        }

        public ExtrinsicStatus Status { get; set; }
        public string Message { get; set; } = string.Empty;

        public enum ExtrinsicStatus
        {
            System,
            Success,
            Failed
        }
    }
    
}
