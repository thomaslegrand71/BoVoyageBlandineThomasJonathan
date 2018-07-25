namespace BoVoyageBlandineThomasJonathan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DossierReservations", "SolvaviliteCompteBancaire", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Civilites", "Label", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ConseillerClienteles", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.ConseillerClienteles", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.ConseillerClienteles", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Destinations", "Pays", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.DossierReservations", "NumeroCarteBancaire", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Participants", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Visiteurs", "Nom", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Visiteurs", "Prenom", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Clients", "ConfirmedPassword");
            DropColumn("dbo.ConseillerClienteles", "ConfirmedPassword");
            DropColumn("dbo.DossierReservations", "SolvabiliteCompteBancaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DossierReservations", "SolvabiliteCompteBancaire", c => c.Boolean(nullable: false));
            AddColumn("dbo.ConseillerClienteles", "ConfirmedPassword", c => c.String());
            AddColumn("dbo.Clients", "ConfirmedPassword", c => c.String());
            AlterColumn("dbo.Visiteurs", "Prenom", c => c.String(maxLength: 50));
            AlterColumn("dbo.Visiteurs", "Nom", c => c.String(maxLength: 50));
            AlterColumn("dbo.Participants", "Nom", c => c.String(maxLength: 50));
            AlterColumn("dbo.DossierReservations", "NumeroCarteBancaire", c => c.String(maxLength: 16));
            AlterColumn("dbo.Destinations", "Pays", c => c.String(maxLength: 50));
            AlterColumn("dbo.ConseillerClienteles", "Nom", c => c.String(maxLength: 50));
            AlterColumn("dbo.ConseillerClienteles", "Password", c => c.String());
            AlterColumn("dbo.ConseillerClienteles", "Mail", c => c.String());
            AlterColumn("dbo.Clients", "Nom", c => c.String(maxLength: 50));
            AlterColumn("dbo.Clients", "Password", c => c.String());
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Civilites", "Label", c => c.String());
            DropColumn("dbo.DossierReservations", "SolvaviliteCompteBancaire");
        }
    }
}
