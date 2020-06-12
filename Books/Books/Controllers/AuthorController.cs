using Books.ServiceReference1;
using Books.ViewModels.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class AuthorController : Controller
    {
        public ActionResult Index(IndexVM items)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            items.Page = (items.Page == 0 ? 1 : items.Page);

            Service1Client service = new Service1Client();

            List<AuthorDTO> Authors = service.GetAuthors().ToList();

            if (!String.IsNullOrEmpty(items.Search))
                Authors = Authors.Where(u=>u.FirstName.Contains(items.Search)|| u.LastName.Contains(items.Search)).ToList();

            items.Authors = Authors;

            items.PageCount = (int)Math.Ceiling(items.Authors.Count() / (double)5);

            items.Authors = items.Authors.Skip((items.Page - 1) * 5).Take(5).ToList();

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
        public ActionResult Create(AuthorVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            AuthorDTO author = new AuthorDTO()
            {
               FirstName= item.FirstName,
               LastName= item.LastName,
               Description = item.Description,
               ActiveFrom= item.ActiveFrom,
               ActiveTo = item.ActiveTo,
               BookCount = 0,
               Rating = item.Rating
            };

            service.PostAuthor(author);

            return RedirectToAction("Index", "Author");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            AuthorDTO item = service.GetAuthorById(Id);

            AuthorVM author = new AuthorVM()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Description = item.Description,
                ActiveFrom = item.ActiveFrom,
                ActiveTo = item.ActiveTo,
                BookCount = item.BookCount,
                Rating = item.Rating
            };

            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(AuthorVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            AuthorDTO author = new AuthorDTO()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Description = item.Description,
                ActiveFrom = item.ActiveFrom,
                ActiveTo = item.ActiveTo,
                BookCount = item.BookCount,
                Rating = item.Rating
            };

            service.PutAuthor(author);

            return RedirectToAction("Index", "Author");
        }

        public ActionResult Delete(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();
            service.DeleteAuthor(Id);

            return RedirectToAction("Index", "Author");
        }

        public ActionResult Display(int Id)
        {

            Service1Client service = new Service1Client();

            service.UpdateAuthorBookInfo(service.GetAuthorById(Id));

            AuthorDTO author = service.GetAuthorById(Id);

            DisplayVM model = new DisplayVM
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Description = author.Description,
                Rating = author.Rating,
                ActiveFrom = author.ActiveFrom,
                ActiveTo = author.ActiveTo,
                BookCount = author.BookCount
            };

            return View(model);
        }

    }
}