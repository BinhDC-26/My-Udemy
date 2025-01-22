using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Core.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ShipperID { get; set; }
    }
}
