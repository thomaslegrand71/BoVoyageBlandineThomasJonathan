using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Agence : BaseModel
    {
        [StringLength(50, ErrorMessage ="Le champ {0} contient trop de caractères.")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name ="Raison sociale de l'agence")]
        public string Nom { get; set; }
    }
}