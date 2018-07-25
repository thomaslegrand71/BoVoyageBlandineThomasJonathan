using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using BoVoyageBlandineThomasJonathan.Data;


namespace Roomy.Utils.Validators
{
    public class ExistingMailConseillerClientele : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            using (BoVoyageBTJDbContext db = new BoVoyageBTJDbContext())
            {
                return !db.ConseillersClientele.Any(x => x.Mail == value.ToString());
            }
        }
    }
}