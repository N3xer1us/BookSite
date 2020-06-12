using Books.ServiceReference1;
using Books.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index(IndexVM items)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();


            items.Page = (items.Page == 0 ? 1: items.Page);

            List<BookDTO> Books = service.GetBooks().ToList();

            if (!String.IsNullOrEmpty(items.SearchTitle))
                Books = Books.Where(u => u.Title.Contains(items.SearchTitle)).ToList();
            if (items.AuthorId != 0)
                Books = Books.Where(u => u.bookAuthor.Id == items.AuthorId).ToList();
            if (items.GenreId != 0)
                Books = Books.Where(u => u.bookGenre.Id == items.GenreId).ToList();

            items.Books = Books;

            items.PageCount = (int)Math.Ceiling(items.Books.Count()/(double)5);

            items.Books = items.Books.Skip((items.Page-1)* 5).Take(5).ToList();

            return View(items);
        }

        public ActionResult Display(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            BookDTO item = service.GetBookById(Id);
            AuthorDTO author = service.GetAuthorById(item.bookAuthor.Id);
            GenreDTO genre = service.GetGenreById(item.bookGenre.Id);


            List<UserToBookDTO> items = service.GetUsersByBookId(item.Id).ToList();

            DisplayVM book = new DisplayVM()
            {
                Id = item.Id,
                Title = item.Title,
                Author = author.FirstName +" "+ author.LastName,
                Genre = genre.GenreName,
                Description = item.Description,
                DateAdded = item.DateAdded,
                Price = item.Price,
                Rating = item.Rating,
                Users = items
            };

            //ViewData["users"] = Users;

            return View(book);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            BookVM model = new BookVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
            {

                return View(item);
            }

            Service1Client service = new Service1Client();

            BookDTO book = new BookDTO()
            {
                Title = item.Title,
                bookAuthor = service.GetAuthorById(item.AuthorId),
                bookGenre = service.GetGenreById(item.GenreId),
                Description = item.Description,
                DateAdded = DateTime.UtcNow,
                Price = item.Price,
                Rating = item.Rating
            };

            service.PostBook(book);

            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            BookDTO item = service.GetBookById(Id);
            AuthorDTO author = service.GetAuthorById(item.bookAuthor.Id);
            GenreDTO genre = service.GetGenreById(item.bookGenre.Id);

            BookVM book = new BookVM()
            {
                Id = item.Id,
                Title = item.Title,
                AuthorId = item.bookAuthor.Id,
                GenreId = item.bookGenre.Id,
                Description = item.Description,
                DateAdded = item.DateAdded,
                Price = item.Price,
                Rating = item.Rating
            };

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BookVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            BookDTO user = new BookDTO()
            {
                Id = item.Id,
                Title = item.Title,
                bookAuthor = service.GetAuthorById(item.AuthorId),
                bookGenre = service.GetGenreById(item.GenreId),
                Description = item.Description,
                DateAdded = item.DateAdded,
                Price = item.Price,
                Rating = item.Rating
            };

            service.PutBook(user);

            return RedirectToAction("Index", "Book");
        }

        public ActionResult Delete(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();
            
            service.DeleteBook(Id);

            return RedirectToAction("Index", "Book");
        }

        public ActionResult Download(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserDTO current = (UserDTO)Session["loggedUser"];

            Service1Client service = new Service1Client();

            UserToBookDTO download = new UserToBookDTO()
            {
                bookUser = service.GetUserById(current.Id),
                Book = service.GetBookById(Id)
            };

            service.AddBookToUser(download);

            return RedirectToAction("Index", "Book");
        }

        
    }
}