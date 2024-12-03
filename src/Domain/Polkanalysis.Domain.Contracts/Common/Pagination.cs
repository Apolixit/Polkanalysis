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

        public int PageSize { get; set; } = ConstantsPagination.DefaultPageSize;
        public int PageNumber { get; set; } = ConstantsPagination.DefaultPageNumber;

        public static Pagination Default => new Pagination();
    }
}
