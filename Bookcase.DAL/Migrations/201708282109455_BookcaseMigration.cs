namespace Bookcase.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class BookcaseMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        PublishingHouse = c.String(nullable: false, maxLength: 50),
                        Year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookEntityAuthorEntities",
                c => new
                    {
                        BookEntity_Id = c.Int(nullable: false),
                        AuthorEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookEntity_Id, t.AuthorEntity_Id })
                .ForeignKey("dbo.BookEntities", t => t.BookEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.AuthorEntities", t => t.AuthorEntity_Id, cascadeDelete: true)
                .Index(t => t.BookEntity_Id)
                .Index(t => t.AuthorEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookEntityAuthorEntities", "AuthorEntity_Id", "dbo.AuthorEntities");
            DropForeignKey("dbo.BookEntityAuthorEntities", "BookEntity_Id", "dbo.BookEntities");
            DropIndex("dbo.BookEntityAuthorEntities", new[] { "AuthorEntity_Id" });
            DropIndex("dbo.BookEntityAuthorEntities", new[] { "BookEntity_Id" });
            DropTable("dbo.BookEntityAuthorEntities");
            DropTable("dbo.BookEntities");
            DropTable("dbo.AuthorEntities");
        }
    }
}
