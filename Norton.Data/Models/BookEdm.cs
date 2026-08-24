using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Norton.Data.Models
{
    public class BookEdm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string Author { get; set; } = string.Empty;

        public DateTimeOffset PublishedDate { get; set; }

        public string Genre { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
