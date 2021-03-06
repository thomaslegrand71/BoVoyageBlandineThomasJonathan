﻿using BoVoyageBlandineThomasJonathan.Utils.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class ConseillerClientele : Personne //héritage de personnes directement (tous les champs intéressants? )
    {
        [Display(Name = "Adresse email")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
           ErrorMessage = "L'adresse mail n'est pas au bon format")]
        [ExistingMailConseillerClientele(ErrorMessage = "Un compte existe déjà pour cette {0}.")]
        public string Mail { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*\\W).{6,}$",
        ErrorMessage = "Le mot de passe doit contenir au minimum 6 caractères, un caractère en minuscule, un caractère en majuscule, un chiffre et un caractère spécial")]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Erreur sur la {0}.")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }
    }
}