using DemoNop.Core.Domain.Entities;
using DemoNop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IList<Product>> GetAllAsync()
        {
            return _productRepository.GetAllAsync();
        }
    }
}
