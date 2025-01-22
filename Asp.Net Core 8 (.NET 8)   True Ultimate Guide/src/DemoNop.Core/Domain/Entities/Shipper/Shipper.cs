using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Core.Domain.Entities
{
    public class Shipper : BaseEntity
    {
        public string? ShipperName { get; set; }
        public string? Phone { get; set; }
    }
}
