using DemoNop.Core;
using DemoNop.Core.Domain.Entities;
using DemoNop.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace DemoNop.Services.User
{
    public class UserInfoService : IUserInfoService
    {
        #region Properties
        private readonly IRepository<UserInfo> _userInfoRepo;
        #endregion Properties

        #region Ctor
        public UserInfoService(IRepository<UserInfo> userInfoRepo) {
            _userInfoRepo = userInfoRepo;
        }
        #endregion Ctor

        #region Methods
        public async Task<IList<UserInfo>> GetUserInfoListAsync()
        {
            return await _userInfoRepo.GetAllAsync();
        }

        /// <summary>
        /// Get UserInfos by UserName
        /// </summary>
        /// <param name="userName">User UserName</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the customers
        /// </returns>
        public virtual IList<UserInfo> GetUsersByUserNameAsync(string? userName = null)
        {
            if (string.IsNullOrEmpty(userName))
                return new List<UserInfo>();

            var query = from c in _userInfoRepo.Table
                        where userName.Contains(c.UserName ?? string.Empty)
                        select c;
            var users = query.ToList();

            return users;
        }

        /// <summary>
        /// Get User by UserName
        /// </summary>
        /// <param name="userName">User UserName</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the UserInfo
        /// </returns>
        public virtual UserInfo? GetUserByUserName(string? userName = null)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            var query = from c in _userInfoRepo.Table
                        where userName == c.UserName
                        select c;
            var users = query.ToList().FirstOrDefault();

            return users;
        }

        public async Task UserInfoCreate(UserInfo? userInfo = null)
        {
            await _userInfoRepo.InsertAsync(userInfo);
        }
       
        public async Task UserInfoUpdate(UserInfo? userInfo = null)
        {
            await _userInfoRepo.UpdateAsync(userInfo);
        }

        public async Task UserInfoDelete(UserInfo? userInfo = null)
        {
            await _userInfoRepo.DeleteAsync(userInfo);
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public UserInfo? AuthenticateUser(string? userName, string? password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) return null;

            var userEntity = GetUserByUserName(userName);
            if (userEntity != null &&
                (userEntity.UserName == userName
                && userEntity.Password == password))
            {
                return userEntity;
            }

            return null;
        }
        #endregion Methods

        #region Utilities

        #endregion Utilities
    }
}
