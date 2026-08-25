
using Norton.Abstractions.Models;

namespace Norton.Services
{
    public interface IBookService
    {
        IList<Book> GetBooks();

        Book GetBookById(int id);

        Book AddBook(Book book);

        Book UpdateBook(UpdateBook book);

        void DeleteBook(int id);
    }
}
