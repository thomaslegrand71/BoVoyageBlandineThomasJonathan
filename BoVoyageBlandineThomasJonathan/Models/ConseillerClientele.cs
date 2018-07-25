using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class ConseillerClientele : Personne //héritage de personnes directement (tous les champs intéressants? )
    {
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
           ErrorMessage = "L'adresse mail n'est pas au bon format")]
        public string Mail { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*\\W).{6,}$",
        ErrorMessage = "Le mot de passe doit contenir au minimum 6 caractères, un caractère en minuscule, un caractère en majuscule, un chiffre et un caractère spécial")]
        public string Password { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*\\W).{6,}$",
        ErrorMessage = "Le mot de passe doit contenir au minimum 6 caractères, un caractère en minuscule, un caractère en majuscule, un chiffre et un caractère spécial")]
        public string ConfirmedPassword { get; set; }
    }
}