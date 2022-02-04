using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Entities
{
    public class ClientTransport
    {
        [Key]
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal Weight { get; set; } // weight in tons
        public decimal Volume { get; set; } // volume in m3
        public decimal Price { get; set; }
        public string Date { get; set; } // arrival date for a certain transport
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
