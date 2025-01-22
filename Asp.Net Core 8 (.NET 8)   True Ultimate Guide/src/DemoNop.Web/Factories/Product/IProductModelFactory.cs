using DemoNop.Core.Domain.Entities;

namespace DemoNop.Web.Factories
{
    public interface IProductModelFactory
    {
        Task<IList<Product>> GetAllAsync();
    }
}
