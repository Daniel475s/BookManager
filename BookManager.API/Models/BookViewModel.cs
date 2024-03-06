namespace BookManager.API.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int YearOfPublication { get; set; }
    }
}
