using DemoNop.Core.Domain.Entities;
using DemoNop.Services;
using DemoNop.Web.Infrastructure.AutoMapper.Extensions;
using DemoNop.Web.Models;
using System.Runtime.InteropServices;

namespace DemoNop.Web.Factories
{
    public class CustomerModelFactory : ICustomerModelFactory
    {
        #region Properties
        private readonly ICustomerService _customerService;
        #endregion Properties

        #region Ctor
        public CustomerModelFactory(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion Ctor

        #region Methods
        public Task<IList<Customer>> PrepareCustomerList()
        {
            return _customerService.GetAllCustomersAsync();
        }

        public CustomerModel PrepareCustomerById(int id)
        {
            var customerModel = _customerService.GetCustomerById(id).ToModel<CustomerModel>();
            return customerModel;
        }
        #endregion Methods
    }
}
