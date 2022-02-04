using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Entities
{
    public class DriverCompany
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int CompanyId { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Company Company { get; set; }

    }
}
