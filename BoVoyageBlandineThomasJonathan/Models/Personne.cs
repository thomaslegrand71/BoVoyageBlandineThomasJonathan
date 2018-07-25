using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public abstract class Personne : BaseModel
    {
        //public string Civilite { get; set; }

        [Display(Name ="Nom")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Nom { get; set; }

        [Display(Name = "Prenom")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Prenom { get; set; }

        [StringLength(200)]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [StringLength(10)]
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