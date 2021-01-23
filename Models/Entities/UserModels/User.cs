using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Models.Entities.UserModels {
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } = Models.Entities.UserModels.Role.User;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public ICollection<ShopOnline.API.Models.TodoItem>  TodoItems { get; set; }
    }
}
