using DemoNop.Web.Framework.Models;

namespace DemoNop.Web.Models
{
    public class ProductModel : BaseNopEntityModel
    {
        public string? ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? Unit { get; set; }
        public decimal? Price { get; set; }
    }
}
