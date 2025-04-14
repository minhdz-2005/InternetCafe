using System.ComponentModel.DataAnnotations;

namespace InternetCafe.Models {
    public class Account {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [MaxLength(50)]
        [MinLength(8, ErrorMessage = "The username must be at least 8 characters")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your password")]
        [MaxLength(50)]
        [MinLength(8 , ErrorMessage = "The password must be at least 8 characters")]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public Account() {}

        public Account(string username, string password, string role) {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
