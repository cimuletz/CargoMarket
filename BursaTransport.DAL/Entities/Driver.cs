using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Entities
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<DriverCompany> DriverCompanies { get; set; }
        public virtual ICollection<DriverTransport> Transports { get; set; }

    }
}
