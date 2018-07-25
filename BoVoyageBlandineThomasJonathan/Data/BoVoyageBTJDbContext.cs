using BoVoyageBlandineThomasJonathan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Data
{
    public class BoVoyageBTJDbContext : DbContext
    {
        public BoVoyageBTJDbContext() : base("BoVoyageBTJ")
        {
        }

        

        public DbSet<Agence> Agences { get; set; }

        public DbSet<Civilite> Civilites { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ConseillerClientele> ConseillersClientele { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<DossierReservation> DossierReservation { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Visiteur> Visiteurs { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<VoyageFile> VoyageFiles { get; set; }


    }
}