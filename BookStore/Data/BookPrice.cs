using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    public class BookPrice
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int BookId { get; set; }

        public int CurrencyId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [ForeignKey("CurrencyId")]
        public CurrencyType CurrencyType { get; set; }
        
       
    }
    
}
