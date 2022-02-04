using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Entities
{
    public class DriverTransport
    {
        [Key]
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; } // arrival date for a certain transport
        public decimal Price { get; set; }
        public int? DriverId { get; set; }
        public virtual Driver Driver { get; set; }

    }
}
