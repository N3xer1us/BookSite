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
    public class UserToBookManageService
    {

        private UnitOfWork UoW = new UnitOfWork();

        public List<UserToBookDTO> GetBooksByUserId(int Id)
        {

            List<UserToBookDTO> userBooksDTO = new List<UserToBookDTO>();

            foreach (var userToBook in UoW.UserToBookRepo.GetAll(u => u.UserId == Id))
            {

                userBooksDTO.Add(new UserToBookDTO
                {
                    Id = userToBook.Id,
                    Book = new BookDTO
                    {
                        Id = userToBook.Book.Id,
                        Title = userToBook.Book.Title,
                        bookAuthor = new AuthorDTO
                        {
                            Id = userToBook.Book.AuthorId,
                            FirstName = userToBook.Book.BookAuthor.FirstName,
                            LastName = userToBook.Book.BookAuthor.LastName,
                            Description = userToBook.Book.BookAuthor.Description,
                            ActiveFrom = userToBook.Book.BookAuthor.ActiveFrom,
                            ActiveTo = userToBook.Book.BookAuthor.ActiveTo,
                            BookCount = userToBook.Book.BookAuthor.BookCount,
                            Rating = userToBook.Book.BookAuthor.Rating
                        },
                        bookGenre = new GenreDTO
                        {
                            Id = userToBook.Book.GenreId,
                            GenreName = userToBook.Book.BookGenre.GenreName,
                            Description = userToBook.Book.BookGenre.Description,
                            BookCount = userToBook.Book.BookGenre.BookCount,
                            Rating = userToBook.Book.BookGenre.Rating,
                            LastUpdated = userToBook.Book.BookGenre.LastUpdated
                        },
                        Description = userToBook.Book.Description,
                        DateAdded = userToBook.Book.DateAdded,
                        Price = userToBook.Book.Price,
                        Rating = userToBook.Book.Rating
                    }
                });

            }

            return userBooksDTO;

        }

        public List<UserToBookDTO> GetUsersByBookId(int Id)
        {

            List<UserToBookDTO> bookUsersDTO = new List<UserToBookDTO>();

            foreach (var userToBook in UoW.UserToBookRepo.GetAll(u => u.BookId == Id))
            {

                bookUsersDTO.Add(new UserToBookDTO
                {
                    Id = userToBook.Id,
                    bookUser = new UserDTO
                    {
                        Id = userToBook.User.Id,
                        Username = userToBook.User.Username,
                        FirstName = userToBook.User.FirstName,
                        LastName = userToBook.User.LastName,
                        Email = userToBook.User.Email,
                        DOB = userToBook.User.DOB,
                        userRole = new RoleDTO
                        {
                            Id = userToBook.User.UserRole.Id,
                            RoleName = userToBook.User.UserRole.RoleName,
                            RoleDescription = userToBook.User.UserRole.RoleDescription,
                            UserCount = userToBook.User.UserRole.UserCount
                        },
                        isOnline = userToBook.User.isOnline
                    }
                });

            }

            return bookUsersDTO;

        }

        public bool Save(UserToBookDTO userToBookDTO)
        {
            if (userToBookDTO == null)
            {
                return false;
            }

            UserToBook userToBook = new UserToBook
            {
                UserId= userToBookDTO.bookUser.Id,
                BookId = userToBookDTO.Book.Id
            };

            try
            {
                UoW.UserToBookRepo.Insert(userToBook);
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
                UserToBook userToBook = UoW.UserToBookRepo.GetById(id);
                UoW.UserToBookRepo.Delete(userToBook);
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
