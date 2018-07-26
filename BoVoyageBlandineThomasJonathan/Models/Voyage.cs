using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Voyage : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Date de l'aller")]
        [DataType(DataType.Date)]
        public DateTime DateAller { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Date du retour")]
        [DataType(DataType.Date)]
        public DateTime DateRetour { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Places disponibles")]
        [Range(0, 9)]
        public int PlacesDisponibles { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Tarif tout compris")]
        [DataType(DataType.Currency)]
        public decimal TarifToutCompris { get; set; }


        public int IdAgence { get; set; }
        [Display(Name = "Agence de voyage")]
        [ForeignKey("IdAgence")]
        public Agence Agence { get; set; }


        public int IdDestination { get; set; }
        [Display(Name = "Destination")]
        [ForeignKey("IdDestination")]
        public Destination Destination { get; set; }      

        public ICollection<VoyageFile> Files { get; set; }
    }
}