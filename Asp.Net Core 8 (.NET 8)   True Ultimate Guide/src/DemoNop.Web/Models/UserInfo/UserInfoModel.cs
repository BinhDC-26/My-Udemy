using DemoNop.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoNop.Web.Models
{
    public class UserInfoModel : BaseNopEntityModel
    {
        [Required]
        public string? DisplayName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Remote("IsEmailAvailable", "RemoteValidation", 
            HttpMethod = "POST", ErrorMessage = "Email ID already in use.")]
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
