using System;

namespace EnhancedApiResponse
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int PreviousPage => CurrentPage - 1;
        public int NextPage => CurrentPage + 1;
        public int StartRecord => (CurrentPage - 1) * PageSize + 1;
        public int EndRecord => Math.Min(CurrentPage * PageSize, TotalRecords);
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
