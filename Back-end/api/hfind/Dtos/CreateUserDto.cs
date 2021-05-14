using System.ComponentModel.DataAnnotations;

namespace hfind.Dtos
{
    public record CreateUserDto
        {
       [Required]
        public string Username { get; init; }
        [Required]
        public string Password { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public string Firstname { get; init;}
        [Required]
        public string Lastname { get; init;}
        [Required]
        public int Phone { get; init;}
        public int Type {get; init;}
    }
}
