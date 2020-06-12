using AppService.DTOs;
using AppService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookSiteService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        #region Login

        private LoginManageService loginService = new LoginManageService(); 

        public UserDTO CheckAccount(string Username , string Password)
        {
            return loginService.CheckAccount(Username, Password);
        }

        #endregion

        #region User

        private UserManageService userService = new UserManageService();
        
        public List<UserDTO> GetUsers()
        {
            return userService.Get();
        }

        public UserDTO GetUserById(int id)
        {
            return userService.GetById(id);
        }

        public string PostUser(UserDTO userDTO)
        {
            if (!userService.Save(userDTO))
                return "User is not inserted";

            return "User is inserted";
        }

        public string PutUser(UserDTO userDTO)
        {
            if (!userService.Update(userDTO))
            {
                return "User is not updated";
            }


            return "User is updated";
        }

        public string DeleteUser(int id)
        {
            if (!userService.Delete(id))
                return "User is not deleted";

            return "User is deleted";
        }

        public string SetUserStatus(UserDTO userDTO , bool status)
        {
            if(!userService.SetUserStatus(userDTO, status))
            {
                return "User status wasn't set";
            }

            return "User status was set";
        }

        #endregion

        #region Book

        private BookManageService bookService = new BookManageService();

        public List<BookDTO> GetBooks()
        {
            return bookService.Get();
        }

        public BookDTO GetBookById(int id)
        {
            return bookService.GetById(id);
        }

        public string PostBook(BookDTO bookDTO)
        {
            if (!bookService.Save(bookDTO))
                return "Book is not inserted";

            return "Book is inserted";
        }

        public string PutBook(BookDTO bookDTO)
        {
            if (!bookService.Update(bookDTO))
            {
                return "Book is not updated";
            }

            return "Book is updated";
        }

        public string DeleteBook(int id)
        {
            if (!bookService.Delete(id))
                return "Book is not deleted";

            return "Book is deleted";
        }

        #endregion

        #region Author

        private AuthorManageService authorService = new AuthorManageService();

        public List<AuthorDTO> GetAuthors()
        {
            return authorService.Get();
        }

        public AuthorDTO GetAuthorById(int id)
        {
            return authorService.GetById(id);
        }

        public string PostAuthor(AuthorDTO authorDTO)
        {
            if (!authorService.Save(authorDTO))
                return "Author is not inserted";

            return "Author is inserted";
        }

        public string PutAuthor(AuthorDTO authorDTO)
        {
            if (!authorService.Update(authorDTO))
            {
                return "Author is not updated";
            }

            return "Author is updated";
        }

        public string DeleteAuthor(int id)
        {
            if (!authorService.Delete(id))
                return "Author is not deleted";
            
            return "Author is deleted";
        }

        public string UpdateAuthorBookInfo(AuthorDTO author)
        {
            if (!authorService.UpdateAuthorBookInfo(author))
            {
                return "Author's Book Info wasn't Updated";
            }

            return "Author's Book Info was Updated";
        }

        #endregion

        #region Genre

        private GenreManageService genreService = new GenreManageService();

        public List<GenreDTO> GetGenres()
        {
            return genreService.Get();
        }

        public GenreDTO GetGenreById(int id)
        {
            return genreService.GetById(id);
        }

        public string PostGenre(GenreDTO genreDTO)
        {
            if (!genreService.Save(genreDTO))
                return "Genre is not inserted";

            return "Genre is inserted";
        }

        public string PutGenre(GenreDTO genreDTO)
        {
            if (!genreService.Update(genreDTO))
            {
                return "Genre is not updated";
            }

            return "Genre is updated";
        }

        public string DeleteGenre(int id)
        {
            if (!genreService.Delete(id))
                return "Genre is not deleted";

            return "Genre is deleted";
        }

        public string UpdateGenreBookInfo(GenreDTO genre)
        {
            if (!genreService.UpdateGenreBookInfo(genre))
            {
                return "Genre's Book Info wasn't Updated";
            }

            return "Genre's Book Info was Updated";
        }

        #endregion

        #region Role

        private RoleManageService roleService = new RoleManageService();

        public List<RoleDTO> GetRoles()
        {
            return roleService.Get();
        }

        public RoleDTO GetRoleById(int id)
        {
            return roleService.GetById(id);
        }

        public string PostRole(RoleDTO roleDTO)
        {
            if (!roleService.Save(roleDTO))
                return "Role is not inserted";

            return "Role is inserted";
        }

        public string PutRole(RoleDTO roleDTO)
        {
            if (!roleService.Update(roleDTO))
            {
                return "Role is not updated";
            }

            return "Role is updated";
        }

        public string DeleteRole(int id)
        {
            if (!roleService.Delete(id))
                return "Role is not deleted";

            return "Role is deleted";
        }

        public string UpdateRoleUserInfo(RoleDTO role)
        {
            if (!roleService.UpdateRoleUserInfo(role))
            {
                return "Role's User Info wasn't Updated";
            }
            return "Role's User Info was Updated";
        }

        #endregion

        #region UserToBook

        private UserToBookManageService UtBService = new UserToBookManageService();

        public List<UserToBookDTO> GetBooksByUserId(int Id)
        {
            return UtBService.GetBooksByUserId(Id);
        }

        public List<UserToBookDTO> GetUsersByBookId(int Id)
        {
            return UtBService.GetUsersByBookId(Id);
        }

        public string AddBookToUser(UserToBookDTO userToBookDTO)
        {
            if (!UtBService.Save(userToBookDTO))
            {
                return "Book wasn't added to User";
            }

            return "Book was added to User";
        }

        public string RemoveBookFromUser(int Id)
        {
            if (!UtBService.Delete(Id))
            {
                return "Book wasn't removed from User";
            }

            return "Book was removed from Ueer";
        }

        #endregion

        #region Friend

        private FriendManageService friendService = new FriendManageService();

        public List<FriendDTO> GetFriendsByUserId(int Id)
        {
            return friendService.GetByUserId(Id);
        }

        public string PostFriend(FriendDTO friendDTO)
        {
            if (!friendService.Save(friendDTO))
            {
                return "Friendship wasn't created";
            }

            return "Friendship was created";
        }

        public string DeleteFriend(int Id)
        {
            if (!friendService.Delete(Id))
            {
                return "Friend wasn't removed from User";
            }

            return "Friend was removed from User";
        }

        #endregion

        #region FriendRequest

        private FriendRequestManageService friendRequestService = new FriendRequestManageService();

        public List<FriendRequestDTO> GetFriendRequestByUserId(int Id)
        {
            return friendRequestService.GetByUserId(Id);
        }

        public string PostFriendRequest(FriendRequestDTO friendRequestDTO)
        {
            if (!friendRequestService.Save(friendRequestDTO))
            {
                return "Friend Request wasn't made";
            }

            return "Friend Request made";
        }

        public string DeleteFriendRequest(int Id)
        {
            if (!friendRequestService.Delete(Id))
            {
                return "FriendRequest wasn't declined";
            }

            return "Friend was declined";
        }

        #endregion

    }
}
