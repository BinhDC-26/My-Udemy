using DemoNop.Core;
using DemoNop.Core.Domain.Entities;
using DemoNop.Services.User;
using DemoNop.Web.Infrastructure.AutoMapper.Extensions;
using DemoNop.Web.Models;
using Serilog;
using System.Linq;
using System.Text;

namespace DemoNop.Web.Factories
{
    public class UserInfoFactory : IUserInfoFactory
    {
        #region Properties
        private readonly IUserInfoService _userInfoService;
        #endregion Properties

        #region Ctor
        public UserInfoFactory(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        #endregion Ctor

        #region Methods
        public async Task<IList<UserInfoModel>> PrepareUserInfoList()
        {
            var userEntitys = await _userInfoService.GetUserInfoListAsync();
            var models = userEntitys.Select(c => c.ToModel<UserInfoModel>());
            return models.ToList();
        }

        public UserInfoModel PrepareUserInfoById(int id)
        {
            throw new NotImplementedException();
        }

        public UserInfoModel? FindUserInfoByUserName(string userName)
        {
            var userEntity =  _userInfoService.GetUserByUserName(userName);

            return userEntity?.ToModel<UserInfoModel>();
        }

        public UserInfo PrepareUserInfoCreate(UserInfoModel userInfoModel)
        {
            var userEntity = userInfoModel.ToEntity<UserInfo>();

            userEntity.Password = HashHelper.CreateHash(Encoding.UTF8.GetBytes(userInfoModel.Password?.ToLowerInvariant() ?? string.Empty), CommonHelper.PasswordHashAlgorithm);
            userEntity.CreatedDate = DateTime.UtcNow;

            return userEntity;

        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public UserInfoModel? AuthenticateUser(LoginModel loginModel)
        {
            string passwordHash = HashHelper.CreateHash(Encoding.UTF8.GetBytes(loginModel.Password?.ToLowerInvariant() ?? string.Empty), CommonHelper.PasswordHashAlgorithm);
            var userEntity =  _userInfoService.AuthenticateUser(loginModel.Username, passwordHash);
            return userEntity?.ToModel<UserInfoModel>();
        }
        #endregion Methods
    }
}
