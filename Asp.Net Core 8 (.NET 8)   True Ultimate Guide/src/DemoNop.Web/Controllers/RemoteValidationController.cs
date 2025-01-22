using DemoNop.Services.User;
using DemoNop.Web.Factories;
using DemoNop.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DemoNop.Web.Controllers
{
    public class RemoteValidationController : BaseController
    {
        #region Properties
        private readonly IUserInfoFactory _userinfoFactory;
        private readonly IUserInfoService _userInfoService;
        #endregion Properties

        #region Ctor
        public RemoteValidationController(
            IUserInfoFactory userinfoFactory,
            IUserInfoService userInfoService)
        {
            _userinfoFactory = userinfoFactory;
            _userInfoService = userInfoService;
        }
        #endregion Ctor
        [HttpPost]
        public async Task<JsonResult> IsEmailAvailable(string Email)
        {
            var users = await _userinfoFactory.PrepareUserInfoList();
            //Check the Email in the Database
            return Json(!users.Any(x => x.Email == Email));
        }
    }
}
