using System.ComponentModel.DataAnnotations;

namespace backend.auth 
{
    public class UserModel
    {
        [Key]
        public int Id {get; set;}

        [Required]
        public required string Email {get; set;} = string.Empty;

        [Required]
        public required string PasswordHash {get; set;} = string.Empty;
    }
}