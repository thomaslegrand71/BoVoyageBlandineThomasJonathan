using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class DossiersReservation : BaseModel
    {
        public string NumeroCarteBancaire { get; set; }

        public int PrixTotal { get; set; }


        public int NombreDeVoyageurs { get; set; }

        public int IDClientReservant { get; set; }

        public bool SolvaviliteCompteBancaire { get; set; }
    }
}