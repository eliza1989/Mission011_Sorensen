
//Create the ViewModel for the book list that allows the IQuearable for the data to be passed along with pagination info
namespace Mission011_Sorensen.Models.ViewModels
{
    public class BookListViewModel
    {
        public IQueryable<Book> Books { get; set; }

        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    }
}
