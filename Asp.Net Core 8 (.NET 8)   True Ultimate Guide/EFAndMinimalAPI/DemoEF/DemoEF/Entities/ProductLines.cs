using Microsoft.Extensions.Hosting;

namespace DemoEF.Entities
{
    public class ProductLines
    {
        public string? ProductLine { get; set; }
        public string? TextDescription { get; set; }
        public string? HtmlDescription { get; set; }
        public string? Image { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();

    }
}
