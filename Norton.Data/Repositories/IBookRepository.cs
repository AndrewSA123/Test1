using Norton.Abstractions;
using Norton.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Norton.Data.Repositories
{
    public interface IBookRepository
    {
        IList<Book> GetBooks();
        Book GetBookById(int id);
        // Below, for the input params, this could be a different model "CreateBook" if the
        // values of book were nullable and some could be removed from the front end and populated via the server.
        Book AddBook(Book book);
        // Same comment as above, if some values of the book are not changable, change this to a model without those values.
        Book UpdateBook(Book book); 
        void DeleteBook(int id);
    }
}
