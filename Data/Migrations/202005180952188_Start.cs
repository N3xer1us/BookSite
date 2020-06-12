namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Description = c.String(maxLength: 255),
                        ActiveFrom = c.DateTime(),
                        ActiveTo = c.DateTime(),
                        BookCount = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        AuthorId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        Description = c.String(maxLength: 255),
                        DateAdded = c.DateTime(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(maxLength: 30),
                        Description = c.String(maxLength: 255),
                        BookCount = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        LastUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 30),
                        Password = c.String(maxLength: 30),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Email = c.String(maxLength: 30),
                        DOB = c.DateTime(),
                        isOnline = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserToBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserToBooks", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToBooks", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.UserToBooks", new[] { "BookId" });
            DropIndex("dbo.UserToBooks", new[] { "UserId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.UserToBooks");
            DropTable("dbo.Users");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
