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

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
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

        [Display(Name = "Date de Naissance")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateDeNaissance { get; set; }

        public int Age { get
            
                {
                    return DateTime.Now.Year - DateDeNaissance.Year -
                             (DateTime.Now.Month > DateDeNaissance.Month ? 1 :
                             DateTime.Now.Day < DateDeNaissance.Day ? 1 : 0);
                }
            }

        [Required(ErrorMessage = "Civilité obligatoire")]
        [Display(Name = "Civilité")]
        public int CivilityID { get; set; }

        [ForeignKey("CivilityID")]
        public Civilite Civilite { get; set; }
    }
}
