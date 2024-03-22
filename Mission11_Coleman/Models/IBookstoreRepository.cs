namespace Mission11_Coleman.Models
{
    public interface IBookstoreRepository
    {
        public IQueryable<Book> Books { get; }

    }
}
