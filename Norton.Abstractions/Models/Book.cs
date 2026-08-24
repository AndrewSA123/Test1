namespace Norton.Abstractions.Models
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateTimeOffset PublishedDate { get; set; }

        public string Genre { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
