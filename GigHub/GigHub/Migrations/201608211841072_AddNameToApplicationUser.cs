using System.Data.Entity.Migrations;

namespace GigHub.Migrations
{
    public partial class AddNameToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(false, 100));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}