using DemoNop.Core.Domain.Entities;
using DemoNop.Services;

namespace DemoNop.Web.Factories
{
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly IProductService _productService;
        public ProductModelFactory(IProductService productService)
        {
            _productService = productService;
        }

        public Task<IList<Product>> GetAllAsync()
        {
            return _productService.GetAllAsync();
        }
    }
}
