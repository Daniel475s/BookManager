using AutoMapper;
using BookManager.API.Entities;
using BookManager.API.Models;

namespace BookManager.API.Mappers
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();

            CreateMap<BookInputModel, Book>();
        }
    }
}
