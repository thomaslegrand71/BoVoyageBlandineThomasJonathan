namespace BoVoyageBlandineThomasJonathan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MajDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Civilites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmedPassword = c.String(),
                        Nom = c.String(maxLength: 50),
                        Prenom = c.String(maxLength: 50),
                        Adresse = c.String(maxLength: 200),
                        Telephone = c.String(maxLength: 10),
                        DateDeNaissance = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        CivilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Civilites", t => t.CivilityID, cascadeDelete: false)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.ConseillerClienteles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Password = c.String(),
                        ConfirmedPassword = c.String(),
                        Nom = c.String(maxLength: 50),
                        Prenom = c.String(maxLength: 50),
                        Adresse = c.String(maxLength: 200),
                        Telephone = c.String(maxLength: 10),
                        DateDeNaissance = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        CivilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Civilites", t => t.CivilityID, cascadeDelete: false)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.DossierReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroCarteBancaire = c.String(maxLength: 16),
                        PrixTotal = c.Int(nullable: false),
                        NombreDeVoyageurs = c.Int(nullable: false),
                        SolvaviliteCompteBancaire = c.Boolean(nullable: false),
                        IdVoyage = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                        IdConseillerClientele = c.Int(nullable: false),
                        IdAssurance = c.Int(nullable: false),
                        IdParticipant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assurances", t => t.IdAssurance, cascadeDelete: false)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: false)
                .ForeignKey("dbo.ConseillerClienteles", t => t.IdConseillerClientele, cascadeDelete: false)
                .ForeignKey("dbo.Participants", t => t.IdParticipant, cascadeDelete: false)
                .ForeignKey("dbo.Voyages", t => t.IdVoyage, cascadeDelete: false)
                .Index(t => t.IdVoyage)
                .Index(t => t.IdClient)
                .Index(t => t.IdConseillerClientele)
                .Index(t => t.IdAssurance)
                .Index(t => t.IdParticipant);
            
            CreateTable(
                "dbo.Assurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Annulation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nom = c.String(maxLength: 50),
                        Prenom = c.String(maxLength: 50),
                        Adresse = c.String(maxLength: 200),
                        Telephone = c.String(maxLength: 10),
                        DateDeNaissance = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        CivilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Civilites", t => t.CivilityID, cascadeDelete: false)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAller = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                        PlacesDisponibles = c.Int(nullable: false),
                        TarifToutCompris = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdAgence = c.Int(nullable: false),
                        IdDestination = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agences", t => t.IdAgence, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.IdDestination, cascadeDelete: false)
                .Index(t => t.IdAgence)
                .Index(t => t.IdDestination);
            
            CreateTable(
                "dbo.VoyageFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        Voyage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voyages", t => t.Voyage_Id)
                .Index(t => t.Voyage_Id);
            
            CreateTable(
                "dbo.Visiteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 50),
                        Prenom = c.String(maxLength: 50),
                        Mail = c.String(),
                        Telephone = c.String(maxLength: 10),
                        Demande = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DossierReservations", "IdVoyage", "dbo.Voyages");
            DropForeignKey("dbo.VoyageFiles", "Voyage_Id", "dbo.Voyages");
            DropForeignKey("dbo.Voyages", "IdDestination", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "IdAgence", "dbo.Agences");
            DropForeignKey("dbo.DossierReservations", "IdParticipant", "dbo.Participants");
            DropForeignKey("dbo.Participants", "CivilityID", "dbo.Civilites");
            DropForeignKey("dbo.DossierReservations", "IdConseillerClientele", "dbo.ConseillerClienteles");
            DropForeignKey("dbo.DossierReservations", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.DossierReservations", "IdAssurance", "dbo.Assurances");
            DropForeignKey("dbo.ConseillerClienteles", "CivilityID", "dbo.Civilites");
            DropForeignKey("dbo.Clients", "CivilityID", "dbo.Civilites");
            DropIndex("dbo.VoyageFiles", new[] { "Voyage_Id" });
            DropIndex("dbo.Voyages", new[] { "IdDestination" });
            DropIndex("dbo.Voyages", new[] { "IdAgence" });
            DropIndex("dbo.Participants", new[] { "CivilityID" });
            DropIndex("dbo.DossierReservations", new[] { "IdParticipant" });
            DropIndex("dbo.DossierReservations", new[] { "IdAssurance" });
            DropIndex("dbo.DossierReservations", new[] { "IdConseillerClientele" });
            DropIndex("dbo.DossierReservations", new[] { "IdClient" });
            DropIndex("dbo.DossierReservations", new[] { "IdVoyage" });
            DropIndex("dbo.ConseillerClienteles", new[] { "CivilityID" });
            DropIndex("dbo.Clients", new[] { "CivilityID" });
            DropTable("dbo.Visiteurs");
            DropTable("dbo.VoyageFiles");
            DropTable("dbo.Voyages");
            DropTable("dbo.Participants");
            DropTable("dbo.Assurances");
            DropTable("dbo.DossierReservations");
            DropTable("dbo.ConseillerClienteles");
            DropTable("dbo.Clients");
            DropTable("dbo.Civilites");
            DropTable("dbo.Agences");
        }
    }
}
