using DemoNop.Core.Domain.Entities;
using DemoNop.Data;

namespace DemoNop.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository) {
            _customerRepository = customerRepository;
        }

        public Task<IList<Customer>> GetAllCustomersAsync()
        {
            return _customerRepository.GetAllAsync();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public async Task InsertCustomer(Customer customer)
        {
           await _customerRepository.InsertAsync(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
           await _customerRepository.UpdateAsync(customer);
        }
        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.DeleteAsync(_customerRepository.GetById(id));
        }
    }
}
