using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public abstract class Personnes : BaseModel
    {
        //public string Civilite { get; set; }

        [Required(ErrorMessage ="Le champ {0} est obligatoire")]
        [Display(Name ="Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "DateDeNaissance")]
        public DateTime DateDeNaissance { get; set; }

        public int Age { get; set; }

        public int CivilityID { get; set; }
        [ForeignKey("CivilityID")]
        public Civilite Civilite { get; set; }
    }
}