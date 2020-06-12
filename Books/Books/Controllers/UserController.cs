using Books.ServiceReference1;
using Books.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(IndexVM items)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            items.Page = (items.Page == 0 ? 1 : items.Page);

            Service1Client service = new Service1Client();

            List<UserDTO> Users = service.GetUsers().ToList(); 

            if(!String.IsNullOrEmpty(items.Search))
                Users = Users.Where(u => u.Username.Contains(items.Search)).ToList();

            items.Users = Users;

            items.PageCount = (int)Math.Ceiling(items.Users.Count()/(double)5);

            items.Users = items.Users.Skip((items.Page - 1) * 5).Take(5).ToList();

            return View(items);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserVM model = new UserVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            UserDTO user = new UserDTO()
            {
                Username = item.Username,
                Password = item.Password,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                DOB = item.DOB,
                userRole = service.GetRoleById(item.RoleId),
                isOnline = false
            };

            service.PostUser(user);

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            UserDTO item= service.GetUserById(Id);
            
            UserVM user = new UserVM()
            {
                Id = item.Id,
                Username = item.Username,
                Password = item.Password,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                DOB = item.DOB,
                RoleId = item.userRole.Id,
                isOnline = false
            };

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            UserDTO user = new UserDTO()
            {
                Id = item.Id,
                Username = item.Username,
                Password = item.Password,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                DOB = item.DOB,
                userRole = service.GetRoleById(item.RoleId),
                isOnline = item.isOnline
            };

            service.PutUser(user);

            return RedirectToAction("Index", "User");
        }

        public ActionResult Delete(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();
            service.DeleteUser(Id);

            return RedirectToAction("Index", "User");
        }

        public ActionResult UserProfile(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            UserDTO currentUser = (UserDTO)Session["loggedUser"];

            UserDTO user = service.GetUserById(Id);

            List<UserToBookDTO> books = service.GetBooksByUserId(currentUser.Id).ToList();

            List<FriendDTO> friends = service.GetFriendsByUserId(currentUser.Id).Take(5).ToList();

            ProfileVM profile = new ProfileVM()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DOB = user.DOB,
                Role = user.userRole.RoleName,
                isOnline = user.isOnline,
                Books = books,
                Friends = friends
            };

            return View(profile);
        }

        public ActionResult Roles(IndexVM items)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            items.Page = (items.Page == 0 ? 1 : items.Page);

            List<UserDTO> Users = service.GetUsers().ToList();

            if (!String.IsNullOrEmpty(items.Search))
                Users = Users.Where(u => u.Username.Contains(items.Search)).ToList();

            items.Users = Users;

            items.PageCount = (int)Math.Ceiling(items.Users.Count()/(double)5);

            items.Users = items.Users.Skip((items.Page - 1) * 5).Take(5).ToList();

            return View(items);
        }

        public ActionResult ChangeRole(int Id, int Role)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            UserDTO user = service.GetUserById(Id);

            if (user.userRole.Id != Role)
            {
                user.userRole.Id = Role;
                service.PutUser(user);
            }

            return RedirectToAction("Roles", "User");
        }
    }
}