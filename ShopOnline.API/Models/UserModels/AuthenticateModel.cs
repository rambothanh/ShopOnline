using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Models.UserModels
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}