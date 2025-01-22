using DemoNop.Core.Domain.Entities;

namespace DemoNop.Services
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetAllCustomersAsync();

        Customer GetCustomerById (int id);

        Task InsertCustomer(Customer customer);

        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(int id);
    }
}
