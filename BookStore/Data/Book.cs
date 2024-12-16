namespace BookStore.Data
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public int NoOfPage { get; set; }
        
        public bool IsActive { get; set;}

        public int PageNumber { get; set; }

        public DateTime CreatedOn { get; set; }



    }
    
}
