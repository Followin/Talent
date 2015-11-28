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
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Skills",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InterestUsers",
                c => new
                    {
                        Interest_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Interest_Id, t.User_Id })
                .ForeignKey("dbo.Interests", t => t.Interest_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Interest_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SkillUsers",
                c => new
                    {
                        Skill_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.User_Id })
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Skill_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SkillUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SkillUsers", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.InterestUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.InterestUsers", "Interest_Id", "dbo.Interests");
            DropForeignKey("dbo.Synonyms", "Interest_Id", "dbo.Interests");
            DropIndex("dbo.SkillUsers", new[] { "User_Id" });
            DropIndex("dbo.SkillUsers", new[] { "Skill_Id" });
            DropIndex("dbo.InterestUsers", new[] { "User_Id" });
            DropIndex("dbo.InterestUsers", new[] { "Interest_Id" });
            DropIndex("dbo.Synonyms", new[] { "Interest_Id" });
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropTable("dbo.SkillUsers");
            DropTable("dbo.InterestUsers");
            DropTable("dbo.Skills");
            DropTable("dbo.Synonyms");
            DropTable("dbo.Interests");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
