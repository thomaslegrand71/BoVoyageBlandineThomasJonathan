namespace BoVoyageBlandineThomasJonathan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supprTableAssurance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DossierReservations", "IdAssurance", "dbo.Assurances");
            DropIndex("dbo.DossierReservations", new[] { "IdAssurance" });
            AddColumn("dbo.DossierReservations", "AssuranceAnnulation", c => c.String());
            DropColumn("dbo.DossierReservations", "IdAssurance");
            DropTable("dbo.Assurances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Assurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Annulation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DossierReservations", "IdAssurance", c => c.Int(nullable: false));
            DropColumn("dbo.DossierReservations", "AssuranceAnnulation");
            CreateIndex("dbo.DossierReservations", "IdAssurance");
            AddForeignKey("dbo.DossierReservations", "IdAssurance", "dbo.Assurances", "Id", cascadeDelete: true);
        }
    }
}
