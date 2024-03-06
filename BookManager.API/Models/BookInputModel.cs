namespace BookManager.API.Models
{
    public class BookInputModel
    {
        public string Title { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int YearOfPublication { get; set; }
    }
}
