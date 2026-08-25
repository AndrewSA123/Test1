using AutoMapper;
using Microsoft.Data.SqlClient;
using Norton.Abstractions.Models;
using Norton.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Norton.Data.Repositories
{
    public class BookRepository(string connectionString, IMapper mapper) : IBookRepository
    {
        private static List<BookEdm> books = new List<BookEdm>()
        {
            new() { Id = 1, Title = "Title 1", Author = "Author 1", Genre = "Fiction", Price = 9.99m, PublishedDate = DateTimeOffset.UtcNow },
            new() { Id = 2, Title = "Title 2", Author = "Author 2", Genre = "Sci-Fi", Price = 432, PublishedDate = DateTimeOffset.UtcNow.AddDays(-2) },
            new() { Id = 3, Title = "Title 3", Author = "Author 3", Genre = "Romanticy", Price = 2, PublishedDate = DateTimeOffset.UtcNow.AddDays(5) }
        };

        public Book AddBook(Book book)
        {
            var query = "INSERT INTO dbo.Book (Title, Author, PublishedDate, Genre, Price)" +
                "VALUES (@Title, @Author, @PublishedDate, @Genre, @Price)";

            var connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddBookParams(command, book);

                // Simulate execution
                // connection.Open();
                // var inserted = (int)command.ExecuteScalar();
                // return GetBookById(inserted);
            }

            // only here to simulate insertion
            var edm = mapper.Map<BookEdm>(book);
            edm.Id = books.OrderByDescending(x => x.Id).First().Id + 1;
            books.Add(edm);
            return book;
        }

        public void DeleteBook(int id)
        {
            var query = "DELETE FROM sbo.Book where Id = @Id";

            var connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                //Simulate
                // connection.Open();
                // command.ExecuteNonQuery();
            }
        }

        public Book GetBookById(int id)
        {
            const string query = "SELECT Title, Author, PublishedDate, Genre, Price FROM dbo.Book WHERE Id = @Id";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            // Simulate
            // connection.Open();
            // using var reader = command.ExecuteReader();

            // var newBook = new Book()
            // {
            //    Title = reader.GetString(reader.GetOrdinal("Title")),
            //    Author = reader.GetString(reader.GetOrdinal("Author")),
            //    PublishedDate = new DateTimeOffset(reader.GetDateTime(reader.GetOrdinal("PublishedDate"))),
            //    Genre = reader.GetString(reader.GetOrdinal("Genre")),
            //    Price = reader.GetDecimal(reader.GetOrdinal("Price"))
            // };

            // return newBook;

            return mapper.Map<Book>(books.Find(x => x.Id == id));
        }

        public IList<Book> GetBooks()
        {
            const string sql = @"SELECT Title, Author, PublishedDate, Genre, Price 
                                  FROM dbo.Book";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            // Simulate
            // connection.Open();
            // using var reader = command.ExecuteReader();
            // var books = new List<Book>();
            // while (reader.Read())
            // {
            //     books.Add(MapToBook(reader));
            // }
            // return books;

            return mapper.Map<IList<Book>>(books);
        }

        public Book UpdateBook(UpdateBook book)
        {
            var query = "UPDATE dbo.Book SET TITLE = @Title, Author = @Author, PublishedDate = @PublishedDate, Genre = @Genre, Price = @Price WHERE Id = @Id";

            var connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddBookParams(command, book);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = book.Id;

                // Simulate execution
                // connection.Open();
                // return GetBookById(book.Id);
            }

            // only here to simulate update
            mapper.Map(book, books.Find(x => x.Id == book.Id));
            return book;
        }

        private static void AddBookParams(SqlCommand command, Book book)
        {
            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = book.Title;
            command.Parameters.Add("@Author", SqlDbType.NVarChar).Value = book.Author;
            command.Parameters.Add("@PublishedDate", SqlDbType.Date).Value = book.PublishedDate;
            command.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = book.Genre;
            command.Parameters.Add("@Price", SqlDbType.Decimal).Value = book.Price;
        }
    }
}
