using DemoNop.Web.Factories;
using DemoNop.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DemoNop.Web.Controllers
{
    public class ProductController : BaseController
    {
        #region Properties
        private readonly IProductModelFactory _productFactory;
        #endregion Properties

        #region Ctor
        public ProductController(IProductModelFactory productFactory)
        {
            _productFactory = productFactory;
        }
        #endregion Ctor

        #region Methods
        [HttpGet]
        public virtual async Task<ObjectResult> List()
        {
            var list = await _productFactory.GetAllAsync();
            return Ok(list);
        }
        #endregion Methods
    }
}
