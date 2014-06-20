namespace ToBeImplemented.Infrastructure.EFContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityuserintroduced : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
            DropColumn("dbo.Users", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Login", c => c.String());
            DropColumn("dbo.Users", "UserName");
        }
    }
}
