using DemoNop.Core;
using DemoNop.Core.Domain.Entities;
using DemoNop.Services.User;
using DemoNop.Web.Factories;
using DemoNop.Web.Framework.Controllers;
using DemoNop.Web.Infrastructure.AutoMapper.Extensions;
using DemoNop.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoNop.Web.Controllers
{
    public class LoginController : BaseController
    {
        #region Properties
        private readonly IConfiguration _config;
        private readonly IUserInfoService _userInfoService;
        private readonly IUserInfoFactory _userInfoFactory;
        #endregion Properties

        #region Ctor
        public LoginController(IConfiguration config,
            IUserInfoService userInfoService,
            IUserInfoFactory userInfoFactory)
        {
            _config = config;
            _userInfoService = userInfoService;
            _userInfoFactory = userInfoFactory;
        }
        #endregion Ctor

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginModel loginModel)
        {
            IActionResult response = Unauthorized();

           var userLogin = _userInfoFactory.AuthenticateUser(loginModel);

            if (userLogin != null)
            {
                var tokenString = GenerateJSONWebToken(userLogin);
                response = Ok(new { token = tokenString });
            }

            return response;
        }


        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserInfoModel model)
        {
            return Ok();
        }
        #endregion Methods

        #region Utilities
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(UserInfoModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"].ToString()));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new Claim[] { 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),//Jwt unique ID
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),//Subject
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),//Issued at
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserName??string.Empty),
                new Claim(ClaimTypes.Email, userInfo.Email??string.Empty)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:expired_minute"])),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion Utilities
    }
}
