using Microsoft.Data.SqlClient;
using Norton.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Norton.Data.Repositories
{
    public class BookRepository(string connectionString) : IBookRepository
    {
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

            return new Book { Title = "Sample Title", Author = "Sample Author", Genre = "Fiction", Price = 9.99m, PublishedDate = DateTimeOffset.UtcNow };
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

            return new List<Book>
            {
                new() { Title = "Title 1", Author = "Author 1", Genre = "Fiction", Price = 9.99m, PublishedDate = DateTimeOffset.UtcNow },
                new() { Title = "Title 2", Author = "Author 2", Genre = "Sci-Fi", Price = 432, PublishedDate = DateTimeOffset.UtcNow.AddDays(-2) },
                new() { Title = "Title 3", Author = "Author 3", Genre = "Romanticy", Price = 2, PublishedDate = DateTimeOffset.UtcNow.AddDays(5) }
            };
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
