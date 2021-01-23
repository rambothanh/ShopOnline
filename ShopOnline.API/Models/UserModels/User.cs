using System.ComponentModel.DataAnnotations.Schema;
using ShopOnline.API.Models;
using System.Collections.Generic;


namespace ShopOnline.API.Models.UserModels {
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } = ShopOnline.API.Models.UserModels.Role.User;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<ShopOnline.API.Models.TodoItem>  TodoItems { get; set; }
    }
}
