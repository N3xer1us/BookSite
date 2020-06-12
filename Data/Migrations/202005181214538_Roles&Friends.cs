namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesFriends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Message = c.String(maxLength: 255),
                        SentOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.SenderId, cascadeDelete: false)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FriendId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 20),
                        RoleDescription = c.String(),
                        UserCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "FriendId", "dbo.Users");
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.Users");
            DropForeignKey("dbo.FriendRequests", "ReceiverId", "dbo.Users");
            DropIndex("dbo.Friends", new[] { "FriendId" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.FriendRequests", new[] { "ReceiverId" });
            DropIndex("dbo.FriendRequests", new[] { "SenderId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Friends");
            DropTable("dbo.FriendRequests");
        }
    }
}
