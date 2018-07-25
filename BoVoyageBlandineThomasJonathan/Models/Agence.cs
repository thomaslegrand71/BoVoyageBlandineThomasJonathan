using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Agence : BaseModel
    {
        [StringLength(50)]
        [Required]
        public string Nom { get; set; }
    }
}