//Create the EFBook Repository that inherits from IBookRepository and creates _context instance and the IQueriable
namespace Mission011_Sorensen.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookstoreContext _context;
        public EFBookRepository(BookstoreContext temp) {
            _context = temp;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
