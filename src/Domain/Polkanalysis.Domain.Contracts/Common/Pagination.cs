using Polkanalysis.Domain.Contracts.Settings;

namespace Polkanalysis.Domain.Contracts.Common
{
    public class Pagination
    {
        protected Pagination() { }

        public Pagination(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageSize { get; set; } = Constants.Pagination.DefaultPageSize;
        public int PageNumber { get; set; } = Constants.Pagination.DefaultPageNumber;

        public static Pagination Default => new Pagination();
    }
}
