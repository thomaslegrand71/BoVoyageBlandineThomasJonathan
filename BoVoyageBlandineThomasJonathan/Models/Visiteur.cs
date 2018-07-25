using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Visiteur : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Nom")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Prénom")]
        [StringLength(50)]
        public string Prenom { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
          ErrorMessage = "L'adresse mail n'est pas au bon format")]
        //[ExistingMailUser(ErrorMessage = "Le mail existe déjà.")]
        public string Mail { get; set; }

        [StringLength(10)]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Demande { get; set; }
    }
}