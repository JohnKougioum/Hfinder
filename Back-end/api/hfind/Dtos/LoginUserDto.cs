
using System.ComponentModel.DataAnnotations;

namespace hfind.Dtos
{
 public record LoginUserDto
 {

        public string Id {get; init;}
       [Required]
        public string Username { get; init; }
        [Required]
        public string Password { get; init; }
        }

}