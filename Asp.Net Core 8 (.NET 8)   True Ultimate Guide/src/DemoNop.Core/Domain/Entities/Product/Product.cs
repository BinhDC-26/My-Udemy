using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Core.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }
    }
}
