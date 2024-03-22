//Create the IQueariable to get info from the database

namespace Mission011_Sorensen.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
