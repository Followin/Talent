namespace Talent.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initTry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleRu = c.String(),
                        TitleEn = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Synonyms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Interest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interests", t => t.Interest_Id)
                .Index(t => t.Interest_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInterests",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Interest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Interest_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Interests", t => t.Interest_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Interest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInterests", "Interest_Id", "dbo.Interests");
            DropForeignKey("dbo.UserInterests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Synonyms", "Interest_Id", "dbo.Interests");
            DropIndex("dbo.UserInterests", new[] { "Interest_Id" });
            DropIndex("dbo.UserInterests", new[] { "User_Id" });
            DropIndex("dbo.Synonyms", new[] { "Interest_Id" });
            DropTable("dbo.UserInterests");
            DropTable("dbo.Users");
            DropTable("dbo.Synonyms");
            DropTable("dbo.Interests");
        }
    }
}
