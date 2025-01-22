using DemoNop.Core.Domain.Entities;
using DemoNop.Web.Models;

namespace DemoNop.Web.Factories
{
    public interface IUserInfoFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IList<UserInfoModel>> PrepareUserInfoList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserInfoModel PrepareUserInfoById(int id);

        UserInfoModel? FindUserInfoByUserName(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfoModel"></param>
        /// <returns></returns>
        UserInfo PrepareUserInfoCreate(UserInfoModel userInfoModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        UserInfoModel? AuthenticateUser(LoginModel loginModel);
    }
}
