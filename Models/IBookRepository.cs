namespace Mission011_Sorensen.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
