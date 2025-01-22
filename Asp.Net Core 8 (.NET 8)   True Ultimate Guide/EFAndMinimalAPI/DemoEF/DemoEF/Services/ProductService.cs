using DemoEF.Entities;
using DemoNop.Data;

namespace DemoEF.Services
{
    public class ProductService
    {
        public List<Product> GetProductEagerLoading()
        {
            var products = new List<Product>();
            using (var context = new ClassicModelsDBContext())
            {
                products = context.Products.ToList();
            }
            return products;
        }

        public List<Product> GetProductLazyLoading()
        {
            var products = new List<Product>();
            using (var context = new ClassicModelsDBContext())
            {
                products = context.Products.ToList();
            }
            return products;
        }
    }
}
