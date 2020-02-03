using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaStreamProject.Models
{
    public class User
    {
        public User() { }
        public User(string login, string password, int? role)
        {
            Login = login;
            Password = password;
            Role = role;

        }
        [Key]
        public int Id { get; set; }
        [MinLength(2)]
        [Required]
        public string Login { get; set; }
        [MinLength(2)]
        [Required]
        public string Password { get; set; }
        // Champ int Role Nullable avec le ? (User : null et Admin : 1)
        public int? Role { get; set; }
        


    }
}