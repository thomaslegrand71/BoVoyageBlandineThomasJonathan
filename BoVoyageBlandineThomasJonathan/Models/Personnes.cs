using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Personnes : BaseModel
    {
        public string Civilite { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public int Age { get; set; }
    }
}