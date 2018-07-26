using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Destination : BaseModel
    {
        [StringLength(50)]
        [Required(ErrorMessage = "La valeur {0} est obligatoire.")]
        public string Pays { get; set; }

        [StringLength(50)]
        public string Continent { get; set;  }


        [StringLength(50)]
        public string Region { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}