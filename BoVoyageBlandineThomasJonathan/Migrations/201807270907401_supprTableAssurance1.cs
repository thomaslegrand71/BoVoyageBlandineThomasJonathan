namespace BoVoyageBlandineThomasJonathan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supprTableAssurance1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DossierReservations", "AssuranceAnnulation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DossierReservations", "AssuranceAnnulation", c => c.String());
        }
    }
}
