using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Assurance : BaseModel
    {
        [Display(Name = "Assurance annulation souscrite")]
        public bool Annulation { get; set;}
    }
}