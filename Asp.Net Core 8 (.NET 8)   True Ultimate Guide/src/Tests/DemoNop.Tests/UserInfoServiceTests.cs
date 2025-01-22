using DemoNop.Core;
using DemoNop.Core.Domain.Entities;
using DemoNop.Services.User;
using DemoNop.Web.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace DemoNop.Tests
{
    public class UserInfoServiceTests
    {
        private readonly IUserInfoService _userInfoService;
        public UserInfoServiceTests(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [Fact]
        public async Task GetUserInfosSuccess()
        {
            var users = await _userInfoService.GetUserInfoListAsync();
            Assert.NotNull(users);
        }

        //UserInfo Insert
        [Fact]
        public async Task InsertUserInfoSuccess()
        {
            var entityCreate = new UserInfo()
            {
                DisplayName = "UserInfoServiceTests",
                UserName = "userTest",
                Password = "20150601",
                CreatedDate = DateTime.Now,
                Email = "email@ssv.vn",
            };
            await _userInfoService.UserInfoCreate(entityCreate);
            Assert.True(entityCreate.Id > 0, "create userinfo record fail.");
        }
        [Fact]
        public async Task InsertUserInfo_Throws_ArgumentNullException()
        {
           await Assert.ThrowsAsync<ArgumentNullException>(async ()=> await _userInfoService.UserInfoCreate(null));
        }
        [Fact]
        public async Task InsertUserInfo_DuplicateKey()
        {
            var entityCreate = new UserInfo()
            {
                Id= 1,
                DisplayName = "UserInfoServiceTests",
                UserName = "userTest",
                Password = "20150601",
                CreatedDate = DateTime.Now,
                Email = "email@ssv.vn",
            };
            await _userInfoService.UserInfoCreate(entityCreate);
            Assert.True(entityCreate.Id > 0, "create userinfo record fail.");
        }
    }
}
