using AppService.DTOs;
using Data.Entities;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Services
{
   public class BookManageService
    {
        private UnitOfWork UoW = new UnitOfWork();

        public List<BookDTO> Get()
        {
            List<BookDTO> booksDTO = new List<BookDTO>();

            foreach (var book in UoW.BookRepo.GetAll())
            {

                booksDTO.Add(new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    bookAuthor = new AuthorDTO
                    {
                        Id = book.AuthorId,
                        FirstName = book.BookAuthor.FirstName,
                        LastName = book.BookAuthor.LastName,
                        Description = book.BookAuthor.Description,
                        ActiveFrom = book.BookAuthor.ActiveFrom,
                        ActiveTo = book.BookAuthor.ActiveTo,
                        BookCount = book.BookAuthor.BookCount,
                        Rating = book.BookAuthor.Rating
                    },
                    bookGenre = new GenreDTO
                    {
                        Id = book.GenreId,
                        GenreName = book.BookGenre.GenreName,
                        Description = book.BookGenre.Description,
                        BookCount = book.BookGenre.BookCount,
                        Rating = book.BookGenre.Rating,
                        LastUpdated = book.BookGenre.LastUpdated
                    },
                    Description = book.Description,
                    DateAdded = book.DateAdded,
                    Price = book.Price,
                    Rating= book.Rating
                });

            }

            return booksDTO;

        }

        public BookDTO GetById(int Id)
        {
            BookDTO bookDTO = new BookDTO();

            Book book = UoW.BookRepo.GetById(Id);

            if (book != null)
            {
                bookDTO = new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    bookAuthor = new AuthorDTO
                    {
                        Id = book.AuthorId,
                        FirstName = book.BookAuthor.FirstName,
                        LastName = book.BookAuthor.LastName,
                        Description = book.BookAuthor.Description,
                        ActiveFrom = book.BookAuthor.ActiveFrom,
                        ActiveTo = book.BookAuthor.ActiveTo,
                        BookCount = book.BookAuthor.BookCount,
                        Rating = book.BookAuthor.Rating
                    },
                    bookGenre = new GenreDTO
                    {
                        Id = book.GenreId,
                        GenreName = book.BookGenre.GenreName,
                        Description = book.BookGenre.Description,
                        BookCount = book.BookGenre.BookCount,
                        Rating = book.BookGenre.Rating,
                        LastUpdated = book.BookGenre.LastUpdated
                    },
                    Description = book.Description,
                    DateAdded = book.DateAdded,
                    Price = book.Price,
                    Rating = book.Rating
                };
            }

            return bookDTO;
        }

        public bool Save(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return false;
            }

            Book book = new Book
            {
                Title = bookDTO.Title,
                AuthorId = bookDTO.bookAuthor.Id,
                GenreId= bookDTO.bookGenre.Id,
                Description = bookDTO.Description,
                DateAdded = bookDTO.DateAdded,
                Price = bookDTO.Price,
                Rating = bookDTO.Rating
            };

            try
            {
                UoW.BookRepo.Insert(book);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BookDTO bookDTO)
        {

            if (bookDTO == null)
            {
                return false;
            }

            Book book = new Book
            {
                Id= bookDTO.Id,
                Title= bookDTO.Title,
                AuthorId = bookDTO.bookAuthor.Id,
                GenreId= bookDTO.bookGenre.Id,
                Description = bookDTO.Description,
                DateAdded= bookDTO.DateAdded,
                Price = bookDTO.Price,
                Rating= bookDTO.Rating
            };

            try
            {

                UoW.BookRepo.Update(book);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                Book book = UoW.BookRepo.GetById(id);
                UoW.BookRepo.Delete(book);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
