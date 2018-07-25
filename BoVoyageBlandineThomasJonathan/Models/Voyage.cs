using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Voyage : BaseModel
    {
        public DateTime DateAller { get; set; }

        public DateTime DateRetour { get; set; }

        public int PlacesDisponibles { get; set; }

        public decimal TarifToutCompris { get; set; }

        public int IdAgence { get; set; }
        [ForeignKey("IdAgence")]
        public Agence Agence { get; set; }

        public int IdDestination { get; set; }
        [ForeignKey("IdDestination")]
        public Destination Destination { get; set; }      

        public ICollection<VoyageFile> Files { get; set; }
    }
}