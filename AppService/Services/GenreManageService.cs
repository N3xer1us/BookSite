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
    public class GenreManageService
    {

        private UnitOfWork UoW = new UnitOfWork();

        public List<GenreDTO> Get()
        {
            List<GenreDTO> genresDTO = new List<GenreDTO>();

            foreach (var genre in UoW.GenreRepo.GetAll())
            {

                genresDTO.Add(new GenreDTO
                {
                    Id= genre.Id,
                    GenreName= genre.GenreName,
                    Description = genre.Description,
                    BookCount = genre.BookCount,
                    Rating = genre.Rating,
                    LastUpdated = genre.LastUpdated
                });

            }

            return genresDTO;

        }

        public GenreDTO GetById(int Id)
        {
            GenreDTO genreDTO = new GenreDTO();

            Genre genre = UoW.GenreRepo.GetById(Id);

            if (genre != null)
            {
                genreDTO = new GenreDTO
                {
                    Id= genre.Id,
                    GenreName = genre.GenreName,
                    Description = genre.Description,
                    BookCount = genre.BookCount,
                    Rating = genre.Rating,
                    LastUpdated = genre.LastUpdated
                };
            }

            return genreDTO;
        }

        public bool Save(GenreDTO genreDTO)
        {
            if (genreDTO == null)
            {
                return false;
            }

            Genre genre = new Genre
            {
                GenreName = genreDTO.GenreName,
                Description = genreDTO.Description,
                BookCount = genreDTO.BookCount,
                Rating = genreDTO.Rating,
                LastUpdated = genreDTO.LastUpdated
            };

            try
            {
                UoW.GenreRepo.Insert(genre);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(GenreDTO genreDTO)
        {

            if (genreDTO == null)
            {
                return false;
            }

            Genre genre = new Genre
            {
                Id = genreDTO.Id,
                GenreName = genreDTO.GenreName,
                Description = genreDTO.Description,
                BookCount = genreDTO.BookCount,
                Rating = genreDTO.Rating,
                LastUpdated = genreDTO.LastUpdated
            };

            try
            {

                UoW.GenreRepo.Update(genre);
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
                Genre genre = UoW.GenreRepo.GetById(id);
                UoW.GenreRepo.Delete(genre);
                UoW.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateGenreBookInfo(GenreDTO genre)
        {

            if(genre == null)
            {
                return false;
            }

            genre.BookCount = UoW.BookRepo.GetAll(u => u.GenreId == genre.Id).Count();
            genre.LastUpdated = DateTime.UtcNow;

            if (Update(genre))
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
