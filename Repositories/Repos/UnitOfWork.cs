using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class UnitOfWork
    {

        #region PrivateRepos
        private BookSiteDBContext db = new BookSiteDBContext();
        private BaseRepo<User> userRepo;
        private BaseRepo<Book> bookRepo;
        private BaseRepo<Author> authorRepo;
        private BaseRepo<Genre> genreRepo;
        private BaseRepo<Role> roleRepo;
        private BaseRepo<UserToBook> userToBookRepo;
        private BaseRepo<Friend> friendRepo;
        private BaseRepo<FriendRequest> friendRequestRepo;
        #endregion

        #region PublicRepos
        public BaseRepo<User> UserRepo
        {
            get
            {

                if (this.userRepo == null)
                {
                    this.userRepo = new BaseRepo<User>(db);
                }
                return userRepo;
            }
        }
        public BaseRepo<Book> BookRepo
        {
            get
            {
                if (this.bookRepo == null)
                {
                    this.bookRepo = new BaseRepo<Book>(db) ;
                }
                return bookRepo;
            }
        }
        public BaseRepo<Author> AuthorRepo
        {
            get
            {
                if (this.authorRepo == null)
                {
                    this.authorRepo = new BaseRepo<Author>(db);
                }
                return authorRepo;
            }
        }
        public BaseRepo<Genre> GenreRepo
        {
            get
            {
                if (this.genreRepo == null)
                {
                    this.genreRepo = new BaseRepo<Genre>(db);
                }
                return genreRepo;
            }
        }
        public BaseRepo<Role> RoleRepo
        {
            get
            {
                if (this.roleRepo == null)
                {
                    this.roleRepo = new BaseRepo<Role>(db);
                }
                return roleRepo;
            }
        }
        public BaseRepo<UserToBook> UserToBookRepo
        {
            get
            {
                if(this.userToBookRepo==null)
                {
                    this.userToBookRepo = new BaseRepo<UserToBook>(db);
                }
                return userToBookRepo;
            }
        }
        public BaseRepo<Friend> FriendRepo
        {
            get
            {
                if (this.friendRepo == null)
                {
                    this.friendRepo = new BaseRepo<Friend>(db);
                }
                return friendRepo;
            }
        }
        public BaseRepo<FriendRequest> FriendRequestRepo 
        {
            get
            {
                if (this.friendRequestRepo == null)
                {
                    this.friendRequestRepo = new BaseRepo<FriendRequest>(db);
                }
                return friendRequestRepo;
            }
        }
        #endregion

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
