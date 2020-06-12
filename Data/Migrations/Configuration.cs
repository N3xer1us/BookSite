namespace Data.Migrations
{
    using Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.BookSiteDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.BookSiteDBContext context)
        {
            if (context.Roles.Count() <= 0)
            {
                Role role = new Role()
                {
                    RoleName = "Owner",
                    RoleDescription = "Can make admins"
                };

                context.Roles.Add(role);
                context.SaveChanges();

                Role role1 = new Role()
                {
                    RoleName = "Admin",
                    RoleDescription = "Can make moderators"
                };

                context.Roles.Add(role1);
                context.SaveChanges();

                Role role2 = new Role()
                {
                    RoleName = "Moderator",
                    RoleDescription = "Can add books"
                };

                context.Roles.Add(role2);
                context.SaveChanges();

                Role role3 = new Role()
                {
                    RoleName = "User",
                    RoleDescription = "Can't do anything"
                };

                context.Roles.Add(role3);
                context.SaveChanges();
            }

            if (context.Users.Count() <= 0)
            {
                User user = new User()
                {
                    Username = "owner",
                    Password = "ownerpass",
                    FirstName = "Site",
                    LastName = "Owner",
                    UserRole = context.Roles.Where(u => u.Id == 1).FirstOrDefault(),
                    Email = "owner@mail.com",
                    DOB = DateTime.Parse("01/01/1999"),
                    isOnline = false
                };

                context.Users.Add(user);
                context.SaveChanges();
            }



            if (context.Authors.Count() <= 0)
            {
                Author author = new Author()
                {
                    FirstName = "Author1",
                    LastName = "1",
                    ActiveFrom = DateTime.Parse("01/01/1950"),
                    ActiveTo = DateTime.Parse("01/01/1980"),
                    Description = "1",
                    Rating = 3.8,
                    BookCount = 0
                };

                context.Authors.Add(author);



                Author author1 = new Author()
                {
                    FirstName = "Author2",
                    LastName = "2",
                    ActiveFrom = DateTime.Parse("01/01/1970"),
                    ActiveTo = DateTime.Parse("01/01/1980"),
                    Description = "2",
                    Rating = 3.3,
                    BookCount = 0
                };

                context.Authors.Add(author1);

                context.SaveChanges();
            }

            if (context.Genres.Count() <= 0)
            {
                Genre genre = new Genre()
                {
                    GenreName = "Genre1",
                    Description = "1",
                    Rating= 5,
                    BookCount= 0
                };

                context.Genres.Add(genre);


                Genre genre1 = new Genre()
                {
                    GenreName = "Genre2",
                    Description = "2",
                    Rating= 3,
                    BookCount =0
                };

                context.Genres.Add(genre1);

                context.SaveChanges();
            }

            if (context.Books.Count() <= 0)
            {
                Book book = new Book()
                {
                    Title = "Book1",
                    AuthorId = 1,
                    GenreId = 1,
                    Description = "Book1",
                    Price = 10,
                    Rating = 4.7,
                    DateAdded = DateTime.UtcNow
                };

                context.Books.Add(book);
                context.SaveChanges();

                Book book1 = new Book()
                {
                    Title = "Book2",
                    AuthorId = 1,
                    GenreId = 1,
                    Description = "Book2",
                    Price = 16,
                    Rating = 4.3,
                    DateAdded = DateTime.UtcNow
                };

                context.Books.Add(book1);
                context.SaveChanges();

                Book book2 = new Book()
                {
                    Title = "Book3",
                    AuthorId = 1,
                    GenreId = 1,
                    Description = "Book3",
                    Price = 20,
                    Rating = 3.4,
                    DateAdded = DateTime.UtcNow
                };

                context.Books.Add(book2);
                context.SaveChanges();
            }
        }
    }
    
}
