using DemoNop.Core.Domain.Entities;
using DemoNop.Services.User;
using DemoNop.Web.Factories;
using DemoNop.Web.Framework.Controllers;
using DemoNop.Web.Infrastructure.AutoMapper.Extensions;
using DemoNop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoNop.Web.Controllers
{
    public class UserInfoController : BaseController
    {
        #region Properties
        private readonly IUserInfoFactory _userinfoFactory;
        private readonly IUserInfoService _userInfoService;
        #endregion Properties

        #region Ctor
        public UserInfoController(
            IUserInfoFactory userinfoFactory,
            IUserInfoService userInfoService)
        {
            _userinfoFactory = userinfoFactory;
            _userInfoService = userInfoService;
        }
        #endregion Ctor

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ObjectResult> List()
        {
            var list = await _userinfoFactory.PrepareUserInfoList();
            return Ok(new ObjectResult(list));
        }

        [HttpPost]
        public virtual async Task<ObjectResult> Create(UserInfoModel userModel)
        {
            if (ModelState.IsValid)
            {
                var entityCreate = _userinfoFactory.PrepareUserInfoCreate(userModel);
                await _userInfoService.UserInfoCreate(entityCreate);
                return Ok(new ObjectResult(entityCreate.ToModel<UserInfoModel>()));
            }
            else
            {
                return (ObjectResult)ValidationProblem();
            }
            
        }

        [HttpPost]
        public virtual async Task<ObjectResult> Update(UserInfoModel user)
        {
            var userUpdated = await _userinfoFactory.PrepareUserInfoList();
            return Ok(new ObjectResult(userUpdated));
        }

        [HttpPost]
        public virtual async Task<ObjectResult> Delete(int userId)
        {
            var list = await _userinfoFactory.PrepareUserInfoList();
            return Ok(new ObjectResult(list));
        }
        #endregion Methods
    }
}
