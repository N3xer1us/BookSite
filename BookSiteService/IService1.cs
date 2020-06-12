using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookSiteService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        #region Login

        [OperationContract]
        UserDTO CheckAccount(string Username, string Password);

        #endregion

        #region User
        [OperationContract]
        List<UserDTO> GetUsers();

        [OperationContract]
        UserDTO GetUserById(int id);

        [OperationContract]
        string PostUser(UserDTO userDTO);

        [OperationContract]
        string PutUser(UserDTO userDTO);

        [OperationContract]
        string DeleteUser(int id);

        [OperationContract]
        string SetUserStatus(UserDTO userDTO, bool status);

        #endregion

        #region Book
        [OperationContract]
        List<BookDTO> GetBooks();

        [OperationContract]
        BookDTO GetBookById(int id);

        [OperationContract]
        string PostBook(BookDTO bookDTO);

        [OperationContract]
        string PutBook(BookDTO bookDTO);

        [OperationContract]
        string DeleteBook(int id);
        #endregion

        #region Author
        [OperationContract]
        List<AuthorDTO> GetAuthors();

        [OperationContract]
        AuthorDTO GetAuthorById(int id);

        [OperationContract]
        string PostAuthor(AuthorDTO authorDTO);

        [OperationContract]
        string PutAuthor(AuthorDTO authorDTO);

        [OperationContract]
        string DeleteAuthor(int id);

        [OperationContract]
        string UpdateAuthorBookInfo(AuthorDTO author);

        #endregion

        #region Genre
        [OperationContract]
        List<GenreDTO> GetGenres();

        [OperationContract]
        GenreDTO GetGenreById(int id);

        [OperationContract]
        string PostGenre(GenreDTO genreDTO);

        [OperationContract]
        string PutGenre(GenreDTO genreDTO);

        [OperationContract]
        string DeleteGenre(int id);

        [OperationContract]
        string UpdateGenreBookInfo(GenreDTO genre);

        #endregion

        #region Role

        [OperationContract]
        List<RoleDTO> GetRoles();

        [OperationContract]
        RoleDTO GetRoleById(int id);

        [OperationContract]
        string PostRole(RoleDTO roleDTO);

        [OperationContract]
        string PutRole(RoleDTO roleDTO);

        [OperationContract]
        string DeleteRole(int id);

        [OperationContract]
        string UpdateRoleUserInfo(RoleDTO role);

        #endregion

        #region UserToBook

        [OperationContract]
        List<UserToBookDTO> GetBooksByUserId(int Id);

        [OperationContract]
        List<UserToBookDTO> GetUsersByBookId(int Id);

        [OperationContract]
        string AddBookToUser(UserToBookDTO userToBookDTO);

        [OperationContract]
        string RemoveBookFromUser(int Id);

        #endregion

        #region Friend

        [OperationContract]
        List<FriendDTO> GetFriendsByUserId(int Id);

        [OperationContract]
        string PostFriend(FriendDTO friendDTO);

        [OperationContract]
        string DeleteFriend(int Id);

        #endregion

        #region FriendRequest

        [OperationContract]
        List<FriendRequestDTO> GetFriendRequestByUserId(int Id);

        [OperationContract]
        string PostFriendRequest(FriendRequestDTO friendRequestDTO);

        [OperationContract]
        string DeleteFriendRequest(int Id);

        #endregion

    }
}
