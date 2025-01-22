using DemoNop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllAsync();
    }
}
