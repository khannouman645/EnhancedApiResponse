using System;

namespace EnhancedApiResponse
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);
    }

    public static class PaginationHelper
    {
        public static object GenerateMetadata(int currentPage, int pageSize, int totalRecords)
        {
            return new PaginationMetadata
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }
    }
}
