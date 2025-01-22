using DemoNop.Core.Domain.Entities;
using DemoNop.Web.Models;

namespace DemoNop.Web.Factories
{
    public interface ICustomerModelFactory
    {
        Task<IList<Customer>> PrepareCustomerList();

        CustomerModel PrepareCustomerById(int id);
    }
}
