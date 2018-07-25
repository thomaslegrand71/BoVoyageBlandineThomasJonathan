using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageBlandineThomasJonathan.Models
{
    public class VoyageFile : BaseModel
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}