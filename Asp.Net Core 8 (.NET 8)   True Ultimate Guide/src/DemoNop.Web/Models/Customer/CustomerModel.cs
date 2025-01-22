using DemoNop.Web.Framework.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoNop.Web.Models
{
    public class CustomerModel : BaseNopEntityModel
    {
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
