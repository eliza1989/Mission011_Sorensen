//Create Pagination info that create page information variables and calcultes the number of pages necessary

using System.Diagnostics.Contracts;

namespace Mission011_Sorensen.Models.ViewModels
{
    public class PaginationInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)(Math.Ceiling((decimal) TotalItems/ItemsPerPage));
    }
}
