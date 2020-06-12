using Books.ServiceReference1;
using Books.ViewModels.FriendRequests;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class FriendsController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            model.Page = (model.Page == 0 ? 1 : model.Page);

            Service1Client service = new Service1Client();

            UserDTO current = (UserDTO)Session["loggedUser"];

            List<FriendRequestDTO> FriendRequests = service.GetFriendRequestByUserId(current.Id).ToList();

            if (!String.IsNullOrEmpty(model.SearchName))
            {
               FriendRequests = FriendRequests.Where(u => u.Sender.Username.Contains(model.SearchName)).ToList();
            }

            model.FriendRequests = FriendRequests;

            model.PageCount = (int)Math.Ceiling(model.FriendRequests.Count()/(double)5);

            model.FriendRequests = model.FriendRequests.Skip((model.Page - 1) * 5).Take(5).ToList();

            return View(model);
        }

        public ActionResult ShowAll(FriendsVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            model.Page = (model.Page == 0 ? 1 : model.Page);

            Service1Client service = new Service1Client();

            UserDTO current = service.GetUserById(model.Id);

            List<FriendDTO> Friends = service.GetFriendsByUserId(current.Id).ToList();

            if (!String.IsNullOrEmpty(model.SearchName))
            {
                Friends = Friends.Where(u => u.Friend.Username.Contains(model.SearchName)).ToList();
            }

            model.Friends = Friends;

            model.PageCount = (int)Math.Ceiling(model.Friends.Count() / (double)5);

            model.Friends = model.Friends.Skip((model.Page - 1) * 5).Take(5).ToList();

            model.User = current;

            return View(model);
        }

        [HttpGet]
        public ActionResult FriendRequest(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Service1Client service = new Service1Client();

            UserDTO friend = service.GetUserById(Id);

            FriendRequestVM model = new FriendRequestVM()
            {
                FriendId = Id,
                Name = friend.Username
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult FriendRequest(FriendRequestVM item)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserDTO current = (UserDTO)Session["loggedUser"];

            Service1Client service = new Service1Client();

            FriendRequestDTO request = new FriendRequestDTO()
            {
                Sender = service.GetUserById(current.Id),
                Receiver = service.GetUserById(item.FriendId),
                Message = item.Message,
                SentOn = DateTime.UtcNow
            };

            service.PostFriendRequest(request);

            return RedirectToAction("Index", "User");
        }

        public ActionResult Unfriend(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserDTO currentUser = (UserDTO)Session["loggedUser"];

            Service1Client service = new Service1Client();

            FriendDTO unfriend = service.GetFriendsByUserId(currentUser.Id).Where(u=>u.Friend.Id == Id).FirstOrDefault();

            service.DeleteFriend(unfriend.Id);

            FriendDTO unfriend2 = service.GetFriendsByUserId(Id).Where(u =>u.User.Id == currentUser.Id).FirstOrDefault();

            service.DeleteFriend(unfriend2.Id);

            return RedirectToAction("UserProfile", "Home");
        }

        public ActionResult Accept(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserDTO currentUser = (UserDTO)Session["loggedUser"];

            Service1Client service = new Service1Client();

            FriendRequestDTO accepted = service.GetFriendRequestByUserId(currentUser.Id)
                                                .Where(u => u.Sender.Id == Id).FirstOrDefault();

            FriendDTO friend = new FriendDTO()
            {
                User = service.GetUserById(Id),
                Friend = service.GetUserById(currentUser.Id),
                CreatedOn = DateTime.UtcNow
                
            };

            service.PostFriend(friend);

            FriendDTO friend2 = new FriendDTO()
            {
                User = service.GetUserById(currentUser.Id),
                Friend = service.GetUserById(Id),
                CreatedOn = DateTime.UtcNow
            };

            service.PostFriend(friend2);

            service.DeleteFriendRequest(accepted.Id);

            return RedirectToAction("Index", "Friends");
        }

        public ActionResult Refuse(int Id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserDTO currentUser = (UserDTO)Session["loggedUser"];

            Service1Client service = new Service1Client();

            FriendRequestDTO refused = service.GetFriendRequestByUserId(currentUser.Id)
                                                .Where(u => u.Sender.Id == Id).FirstOrDefault();

            service.DeleteFriendRequest(refused.Id);

            return RedirectToAction("Index", "Friends");
        }
    }
}