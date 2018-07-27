namespace BoVoyageBlandineThomasJonathan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVoyagefile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoyageFiles", "Voyage_Id", "dbo.Voyages");
            DropIndex("dbo.VoyageFiles", new[] { "Voyage_Id" });
            RenameColumn(table: "dbo.VoyageFiles", name: "Voyage_Id", newName: "VoyageID");
            AlterColumn("dbo.VoyageFiles", "Name", c => c.String(nullable: false, maxLength: 254));
            AlterColumn("dbo.VoyageFiles", "ContentType", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.VoyageFiles", "Content", c => c.Binary(nullable: false));
            AlterColumn("dbo.VoyageFiles", "VoyageID", c => c.Int(nullable: false));
            CreateIndex("dbo.VoyageFiles", "VoyageID");
            AddForeignKey("dbo.VoyageFiles", "VoyageID", "dbo.Voyages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoyageFiles", "VoyageID", "dbo.Voyages");
            DropIndex("dbo.VoyageFiles", new[] { "VoyageID" });
            AlterColumn("dbo.VoyageFiles", "VoyageID", c => c.Int());
            AlterColumn("dbo.VoyageFiles", "Content", c => c.Binary());
            AlterColumn("dbo.VoyageFiles", "ContentType", c => c.String());
            AlterColumn("dbo.VoyageFiles", "Name", c => c.String());
            RenameColumn(table: "dbo.VoyageFiles", name: "VoyageID", newName: "Voyage_Id");
            CreateIndex("dbo.VoyageFiles", "Voyage_Id");
            AddForeignKey("dbo.VoyageFiles", "Voyage_Id", "dbo.Voyages", "Id");
        }
    }
}
