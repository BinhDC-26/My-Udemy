using AutoMapper.Internal;
using DemoNop.Core.Domain.Entities;
using DemoNop.Services;
using DemoNop.Web.Factories;
using DemoNop.Web.Framework.Controllers;
using DemoNop.Web.Infrastructure.AutoMapper.Extensions;
using DemoNop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoNop.Web.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly ICustomerService _customerService;
        #region Ctor
        public CustomerController(ICustomerModelFactory customerFactory, ICustomerService customerService)
        {
            _customerModelFactory = customerFactory;
            _customerService = customerService;
        }
        #endregion Ctor

        #region Methods

        [HttpGet]
        public virtual async Task<ObjectResult> List()
        {
                var list = await _customerModelFactory.PrepareCustomerList();
                return Ok(list);
        }

        [HttpGet("{id}", Name = "getcustomer")]
        public virtual ObjectResult GetCustomer(int id)
        {
            var list = _customerModelFactory.PrepareCustomerById(id);
            return Ok(list);
        }

        [HttpPost]
        public virtual async Task<ObjectResult> Insert(CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                var customerEntity = customerModel.ToEntity<Customer>();
                await _customerService.InsertCustomer(customerEntity);
                return Ok(customerEntity.ToModel<CustomerModel>());
            }
            else
            {
                return (ObjectResult)ValidationProblem();
            }
        }

        [HttpPost]
        public virtual async Task<ObjectResult> Update(CustomerModel customerModel)
    {
            if (ModelState.IsValid)
            {
                var customerEntity = customerModel.ToEntity<Customer>();
                await _customerService.UpdateCustomer(customerEntity);
                return Ok(customerEntity.ToModel<CustomerModel>()); ;
            }
            else
            {
                return (ObjectResult)ValidationProblem();
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<ObjectResult> Delete(int id)
        {
            await _customerService.DeleteCustomer(id);
            return Ok(id);
        }
        #endregion Methods

    }
}
