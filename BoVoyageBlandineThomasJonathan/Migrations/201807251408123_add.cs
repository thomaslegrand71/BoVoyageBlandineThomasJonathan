namespace BoVoyageBlandineThomasJonathan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DossierReservations", "SolvabiliteCompteBancaire", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Agences", "Nom", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.DossierReservations", "SolvaviliteCompteBancaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DossierReservations", "SolvaviliteCompteBancaire", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Agences", "Nom", c => c.String(maxLength: 50));
            DropColumn("dbo.DossierReservations", "SolvabiliteCompteBancaire");
        }
    }
}
