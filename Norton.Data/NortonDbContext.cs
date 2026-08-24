using Microsoft.EntityFrameworkCore;
using Norton.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Norton.Data
{
    public class NortonDbContext : DbContext
    {
        public NortonDbContext(DbContextOptions<NortonDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
