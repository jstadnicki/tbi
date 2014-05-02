namespace ToBeImplemented.Infrastructure.EFContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        AuthorId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ConceptId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Concepts", t => t.ConceptId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.ConceptId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Concepts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        EditCount = c.Long(nullable: false),
                        VoteUp = c.Long(nullable: false),
                        VoteDown = c.Long(nullable: false),
                        DisplayCount = c.Long(nullable: false),
                        AuthorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: false)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserConceptVotes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConceptId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ConceptsTags",
                c => new
                    {
                        ConceptId = c.Long(nullable: false),
                        TagId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConceptId, t.TagId })
                .ForeignKey("dbo.Concepts", t => t.ConceptId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ConceptId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.PasswordResets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Token = c.String(),
                        UserId = c.Long(nullable: false),
                        ExpirationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConceptsTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ConceptsTags", "ConceptId", "dbo.Concepts");
            DropForeignKey("dbo.UserConceptVotes", "UserId", "dbo.Users");
            DropForeignKey("dbo.TagConcepts", "Concept_Id", "dbo.Concepts");
            DropForeignKey("dbo.TagConcepts", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Comments", "ConceptId", "dbo.Concepts");
            DropForeignKey("dbo.Concepts", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Users");
            DropIndex("dbo.TagConcepts", new[] { "Concept_Id" });
            DropIndex("dbo.TagConcepts", new[] { "Tag_Id" });
            DropIndex("dbo.ConceptsTags", new[] { "TagId" });
            DropIndex("dbo.ConceptsTags", new[] { "ConceptId" });
            DropIndex("dbo.UserConceptVotes", new[] { "UserId" });
            DropIndex("dbo.Concepts", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "ConceptId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropTable("dbo.TagConcepts");
            DropTable("dbo.PasswordResets");
            DropTable("dbo.ConceptsTags");
            DropTable("dbo.UserConceptVotes");
            DropTable("dbo.Tags");
            DropTable("dbo.Concepts");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
