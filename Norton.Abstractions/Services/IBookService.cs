using Norton.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Norton.Abstractions.Services
{
    public interface IBookService
    {
        IList<Book> GetBooks();

        Book GetBookById(int id);

        Book AddBook(Book book);

        Book UpdateBook(Book book);

        void DeleteBook(int id);
    }
}
