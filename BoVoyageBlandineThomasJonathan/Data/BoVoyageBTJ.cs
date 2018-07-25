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
        public BoVoyageBTJDbContext() : base("BoVoyageBTJdb")
        {
        }

        public DbSet<Destination> Destinations { get; set; }

        
    }
}