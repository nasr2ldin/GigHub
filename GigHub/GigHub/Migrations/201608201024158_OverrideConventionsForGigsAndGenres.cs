using System.Data.Entity.Migrations;

namespace GigHub.Migrations
{
    public partial class OverrideConventionsForGigsAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] {"Artist_Id"});
            DropIndex("dbo.Gigs", new[] {"Genre_Id"});
            AlterColumn("dbo.Genres", "Name", c => c.String(false, 255));
            AlterColumn("dbo.Gigs", "Venue", c => c.String(false, 255));
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(false, 128));
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte(false));
            CreateIndex("dbo.Gigs", "Artist_Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", true);
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] {"Genre_Id"});
            DropIndex("dbo.Gigs", new[] {"Artist_Id"});
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigs", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Gigs", "Genre_Id");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}