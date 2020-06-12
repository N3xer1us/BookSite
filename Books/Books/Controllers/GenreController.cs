using Books.ServiceReference1;
using Books.ViewModels.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class GenreController : Controller
    {
        public ActionResult Index(IndexVM items)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            items.Page = (items.Page==0? 1: items.Page);

            List<GenreDTO> Genres = service.GetGenres().ToList();

            if (!String.IsNullOrEmpty(items.Search))
                Genres = Genres.Where(u => u.GenreName.Contains(items.Search)).ToList();

            items.Genres = Genres;

            items.PageCount = (int)Math.Ceiling(items.Genres.Count() / (double)5);

            items.Genres = items.Genres.Skip((items.Page - 1) * 5).Take(5).ToList();

            return View(items);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            GenreDTO genre = new GenreDTO()
            {
                GenreName = item.GenreName,
                Description = item.Description,
                BookCount =0,
                Rating = item.Rating,
                LastUpdated= null
            };

            service.PostGenre(genre);

            return RedirectToAction("Index", "Genre");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            GenreDTO item = service.GetGenreById(Id);

            GenreVM genre = new GenreVM()
            {
                Id = item.Id,
                GenreName = item.GenreName,
                Description = item.Description,
                BookCount = item.BookCount,
                Rating = item.Rating,
                LastUpdated = item.LastUpdated
            };

            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(GenreVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            GenreDTO genre = new GenreDTO()
            {
                Id = item.Id,
                GenreName = item.GenreName,
                Description = item.Description,
                BookCount = item.BookCount,
                Rating = item.Rating,
                LastUpdated = item.LastUpdated
            };

            service.PutGenre(genre);

            return RedirectToAction("Index", "Genre");
        }

        public ActionResult Delete(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();
            service.DeleteGenre(Id);

            return RedirectToAction("Index", "Genre");
        }

        public ActionResult Display(int Id)
        {

            Service1Client service = new Service1Client();

            service.UpdateGenreBookInfo(service.GetGenreById(Id));

            GenreDTO genre = service.GetGenreById(Id);

            DisplayVM model = new DisplayVM
            {
                Id = genre.Id,
                GenreName = genre.GenreName,
                Description = genre.Description,
                Rating = genre.Rating,
                LastUpdated = genre.LastUpdated,
                BookCount = genre.BookCount
            };

            return View(model);

        }

    }
}