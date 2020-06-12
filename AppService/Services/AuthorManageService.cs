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
    public class AuthorManageService
    {
        private UnitOfWork UoW = new UnitOfWork();

        public List<AuthorDTO> Get()
        {
            List<AuthorDTO> authorsDTO = new List<AuthorDTO>();

            foreach (var author in UoW.AuthorRepo.GetAll())
            {

                authorsDTO.Add(new AuthorDTO
                {
                    Id = author.Id,
                    FirstName= author.FirstName,
                    LastName= author.LastName,
                    Description = author.Description,
                    ActiveFrom = author.ActiveFrom,
                    ActiveTo = author.ActiveTo,
                    BookCount= author.BookCount,
                    Rating= author.Rating
                });

            }

            return authorsDTO;

        }

        public AuthorDTO GetById(int Id)
        {
            AuthorDTO authorDTO = new AuthorDTO();

            Author author = UoW.AuthorRepo.GetById(Id);

            if (author != null)
            {
                authorDTO = new AuthorDTO
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Description = author.Description,
                    ActiveFrom = author.ActiveFrom,
                    ActiveTo = author.ActiveTo,
                    BookCount = author.BookCount,
                    Rating = author.Rating
                };
            }

            return authorDTO;
        }

        public bool Save(AuthorDTO authorDTO)
        {
            if (authorDTO == null)
            {
                return false;
            }

            Author author = new Author
            {
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName,
                Description = authorDTO.Description,
                ActiveFrom = authorDTO.ActiveFrom,
                ActiveTo = authorDTO.ActiveTo,
                BookCount = authorDTO.BookCount,
                Rating = authorDTO.Rating
            };

            try
            {
                UoW.AuthorRepo.Insert(author);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(AuthorDTO authorDTO)
        {

            if (authorDTO == null)
            {
                return false;
            }

            Author author = new Author
            {
                Id = authorDTO.Id,
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName,
                Description = authorDTO.Description,
                ActiveFrom = authorDTO.ActiveFrom,
                ActiveTo = authorDTO.ActiveTo,
                BookCount = authorDTO.BookCount,
                Rating= authorDTO.Rating
            };

            try
            {

                UoW.AuthorRepo.Update(author);
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
                Author author = UoW.AuthorRepo.GetById(id);
                UoW.AuthorRepo.Delete(author);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAuthorBookInfo(AuthorDTO author)
        {

            if(author==null)
            {
                return false;
            }

            author.BookCount = UoW.BookRepo.GetAll(u => u.AuthorId == author.Id).Count();

            if (Update(author))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
