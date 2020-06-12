using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BookSiteDBContext: DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserToBook> UserToBooks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        public BookSiteDBContext()
            :base("Server=DESKTOP-KP3SI83\\SQLEXPRESS;Database=BooksSiteDb;User Id=Dimitry;Password=1234;")
        {
            Users = this.Set<User>();
            Books = this.Set<Book>();
            UserToBooks = this.Set<UserToBook>();
            Authors = this.Set<Author>();
            Genres = this.Set<Genre>();
            Users = this.Set<User>();
            Roles = this.Set<Role>();
            Friends = this.Set<Friend>();
            FriendRequests = this.Set<FriendRequest>();
        }

    }
}
