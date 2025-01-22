using DemoNop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Services.User
{
    public interface IUserInfoService
    {
        Task<IList<UserInfo>> GetUserInfoListAsync();

        IList<UserInfo> GetUsersByUserNameAsync(string? userName = null);

        UserInfo? GetUserByUserName(string? userName = null);

        Task UserInfoCreate(UserInfo? userInfo = null);

        Task UserInfoUpdate(UserInfo? userInfo = null);

        Task UserInfoDelete(UserInfo? userInfo = null);

        UserInfo? AuthenticateUser(string? userName, string? password);
    }
}
