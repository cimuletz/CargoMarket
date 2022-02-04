using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal MaxVolume { get; set; }
        public int? DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
