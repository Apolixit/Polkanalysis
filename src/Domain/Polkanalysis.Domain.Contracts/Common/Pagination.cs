using Polkanalysis.Domain.Contracts.Settings;

namespace Polkanalysis.Domain.Contracts.Common
{
    public class Pagination
    {
        public Pagination() { }

        public Pagination(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageSize { get; set; } = Constants.DefaultPageSize;
        public int PageNumber { get; set; } = Constants.DefaultPageNumber;

        public static Pagination Default => new Pagination();
    }
}
