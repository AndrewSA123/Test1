using Norton.Abstractions.Models;
using Norton.Data.Repositories;
using Norton.Services;

namespace Norton_Tech_Test.Services
{
    public class BookService(IBookRepository repo) : IBookService
    {
        public Book AddBook(Book book)
        {
            return repo.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            repo.DeleteBook(id);
        }

        public Book GetBookById(int id)
        {
            return repo.GetBookById(id);
        }

        public IList<Book> GetBooks()
        {
            return repo.GetBooks();
        }

        public Book UpdateBook(UpdateBook book)
        {
            return repo.UpdateBook(book);
        }
    }
}
