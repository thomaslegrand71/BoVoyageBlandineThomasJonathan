using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class DossierReservation : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [StringLength(16, ErrorMessage = "{0} invalide.")]
        [Display(Name = "Numéro de carte bancaire")]
        public string NumeroCarteBancaire { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Prix total")]
        [DataType(DataType.Currency)]
        public int PrixTotal { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Nombre de participants")]
        [Range(0, 9)]
        public int NombreDeVoyageurs { get; set; }

        [Display(Name = "Solvabilité du compte")]
        public bool SolvaviliteCompteBancaire { get; set; }

        public int IdVoyage { get; set; }
        [ForeignKey("IdVoyage")]
        public Voyage Voyage { get; set; }

        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        public int IdConseillerClientele { get; set; }
        [ForeignKey("IdConseillerClientele")]
        public ConseillerClientele ConseillerClientele { get; set; }

        //public int IdAssurance { get; set; }
        //[ForeignKey("IdAssurance")]
        [Display(Name = "Assurancde Annulation souscrite")]
        public bool AssuranceAnnulation { get; set; }

        public int IdParticipant { get; set; }
        [ForeignKey("IdParticipant")]
        public Participant Participants { get; set; }
    }
}