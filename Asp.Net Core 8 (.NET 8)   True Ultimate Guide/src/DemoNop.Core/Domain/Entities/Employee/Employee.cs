using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Core.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Photo { get; set; }
        public string? Notes { get; set; }
    }
}
