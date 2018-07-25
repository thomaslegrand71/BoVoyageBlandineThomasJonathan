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
        [StringLength(16)]
        public string NumeroCarteBancaire { get; set; }

        public int PrixTotal { get; set; }

        public int NombreDeVoyageurs { get; set; }

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

        public int IdAssurance { get; set; }
        [ForeignKey("IdAssurance")]
        public Assurance Assurance { get; set; }

        public int IdParticipant { get; set; }
        [ForeignKey("IdParticipant")]
        public Participant Participants { get; set; }
    }
}