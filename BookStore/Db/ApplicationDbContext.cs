using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Db
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
            new CurrencyType() { Id=1,Currency="INR",Description="indian INR"},
            new CurrencyType() { Id = 2, Currency = "DINAR", Description = "Dubai Dinar" },
            new CurrencyType() { Id = 3, Currency = "Rand", Description = "South Africa" },
            new CurrencyType() { Id = 4, Currency = "Doller", Description = "Usa Doller" },
            new CurrencyType() { Id = 5, Currency = "EURO", Description = "Asu euro" }
            );

            modelBuilder.Entity<Language>().HasData(

                new Language() { Id = 1, Title = "MARATHI", Description = "indian " },
                                new Language() { Id = 2, Title = "HINDI", Description = "indian " },

                                                new Language() { Id = 3, Title = "URDU", Description = "indian " },

                                                                new Language() { Id = 4, Title = "KANNDA", Description = "indian " }


                );
        }


        public DbSet<Book> Books { get; set; }

        public DbSet<BookPrice> BookPrices { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<CurrencyType> CurrencyTypes { get; set; }


        public DbSet<Author> Author { get; set; }

    }
}
