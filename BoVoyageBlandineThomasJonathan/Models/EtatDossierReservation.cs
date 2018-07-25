using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public enum EtatDossierReservation : byte
    {
        enAttente = 0,
        enCours = 1,
        refusee = 2,
        acceptee = 3
    }
}