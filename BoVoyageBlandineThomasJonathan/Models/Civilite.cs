using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class Civilite : BaseModel
    {
        [Required(ErrorMessage = "Nom obligatoire")]
        [StringLength(15, ErrorMessage = "Trop long")]
        [Display(Name = "Civilité")]
        public string Label { get; set; }
    }
}