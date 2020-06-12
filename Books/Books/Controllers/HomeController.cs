using Books.ServiceReference1;
using Books.ViewModels.Home;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                Service1Client service = new Service1Client();
                
                UserDTO loggedUser = service.CheckAccount(user.Username, user.Password);

                if (loggedUser == null)
                     ModelState.AddModelError("AuthError", "Incorrect username or password");
                else
                {
                    service.SetUserStatus(loggedUser, true);

                    Session["loggedUser"] = service.GetUserById(loggedUser.Id);                  
                }
                     
                
            }

            if(!ModelState.IsValid)
                return View(user);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Service1Client service = new Service1Client();

            UserDTO loggedUser = (UserDTO)Session["loggedUser"];

            service.SetUserStatus(loggedUser, false);
            Session["loggedUser"] = null;
           

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateVM item)
        {   
            if (!ModelState.IsValid)
                return View(item);

            Service1Client service = new Service1Client();

            RoleDTO Role = service.GetRoleById(4);

            UserDTO user = new UserDTO()
            {
                Username = item.Username,
                Password = item.Password,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                DOB = item.DOB,
                userRole = service.GetRoleById(4),
                isOnline = false
            };

            service.PostUser(user);

            return RedirectToAction("Login", "Home");
        }

        public ActionResult UserProfile()
        {
            if (Session["loggedUser"] == null)
               return RedirectToAction("Login", "Home");

            UserDTO user = (UserDTO)Session["loggedUser"];

            Service1Client service = new Service1Client();

            List<UserToBookDTO> books = service.GetBooksByUserId(user.Id).ToList();

            List<FriendDTO> friends = service.GetFriendsByUserId(user.Id).ToList();

            ProfileVM profile = new ProfileVM()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.userRole.RoleName,
                DOB = user.DOB,
                isOnline = user.isOnline,
                Books = books,
                Friends = friends
            };


            return View(profile);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserDTO user = (UserDTO)Session["loggedUser"];

            EditVM item = new EditVM()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email= user.Email,
                RoleId= user.userRole.Id,
                DOB = user.DOB,
                isOnline = true
            };

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(EditVM item)
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
                Email= item.Email,
                userRole= service.GetRoleById(4),
                DOB = item.DOB,
                isOnline = true
            };
         

            if (((UserDTO)Session["loggedUser"]).Password != user.Password)
            {
                ModelState.AddModelError("wrongPass", "Wrong Password");
                return View(item);
            }
            
            service.PutUser(user);

            return RedirectToAction("UserProfile", "Home");
        }

        public ActionResult Remove(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            UserDTO current = (UserDTO)Session["loggedUser"];

            service.RemoveBookFromUser(Id);
    
            return RedirectToAction("UserProfile", "Home");
        }
    }
}