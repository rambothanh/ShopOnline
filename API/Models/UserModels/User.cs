using System.ComponentModel.DataAnnotations.Schema;
using Api.Models;
using System.Collections.Generic;


namespace Api.Models.UserModels {
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } = Api.Models.UserModels.Role.User;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Api.Models.TodoItem>  TodoItems { get; set; }
    }
}
