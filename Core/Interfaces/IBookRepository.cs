using Core.Models;

namespace Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetByISBN(string isbn);
    }
}
