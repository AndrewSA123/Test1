using System;
using System.Collections.Generic;
using System.Text;

namespace Norton.Data.Models
{
    public class BookEdm
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTimeOffset PublishedDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
