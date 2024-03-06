namespace BookManager.API.Entities
{
    public class Book
    {
        public Book()
        {
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int YearOfPublication { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string title, string autor, string isbn, int yearOfPublication)
        {
            Title = title; 
            Autor = autor;
            ISBN = isbn;
            YearOfPublication = yearOfPublication;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
