using System.ComponentModel.DataAnnotations;

namespace ShoesApp.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
