namespace Talent.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Login = c.String(),
                        Password = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        VkId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhotoLink = c.String(),
                        Project = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        FriendId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FriendId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.FriendId)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.UserInterests",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        InterestId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.InterestId })
                .ForeignKey("dbo.Interests", t => t.InterestId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.InterestId);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        TitleRu = c.String(),
                        TitleEn = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Synonyms",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Text = c.String(),
                        Interest_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interests", t => t.Interest_Id)
                .Index(t => t.Interest_Id);
            
            CreateTable(
                "dbo.UserSkills",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        SkillId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.SkillId })
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserSkills", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.UserInterests", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserInterests", "InterestId", "dbo.Interests");
            DropForeignKey("dbo.Synonyms", "Interest_Id", "dbo.Interests");
            DropForeignKey("dbo.UserUsers", "FriendId", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "UserId", "dbo.Users");
            DropIndex("dbo.UserSkills", new[] { "SkillId" });
            DropIndex("dbo.UserSkills", new[] { "UserId" });
            DropIndex("dbo.Synonyms", new[] { "Interest_Id" });
            DropIndex("dbo.UserInterests", new[] { "InterestId" });
            DropIndex("dbo.UserInterests", new[] { "UserId" });
            DropIndex("dbo.UserUsers", new[] { "FriendId" });
            DropIndex("dbo.UserUsers", new[] { "UserId" });
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropTable("dbo.Skills");
            DropTable("dbo.UserSkills");
            DropTable("dbo.Synonyms");
            DropTable("dbo.Interests");
            DropTable("dbo.UserInterests");
            DropTable("dbo.UserUsers");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
