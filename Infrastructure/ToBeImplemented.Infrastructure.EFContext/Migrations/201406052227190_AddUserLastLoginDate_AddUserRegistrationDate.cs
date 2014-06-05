namespace ToBeImplemented.Infrastructure.EFContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLastLoginDate_AddUserRegistrationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RegisterDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastLoginDateTime", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastLoginDateTime");
            DropColumn("dbo.Users", "RegisterDateTime");
        }
    }
}
