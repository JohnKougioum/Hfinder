using System.ComponentModel.DataAnnotations;

namespace hfind.Dtos
{
    
    public record CreateHouseDto{
     [Required]
      public int SellRent  { get; init;}
      [Required]
    public string Region { get; init;}
    [Required]
    public decimal Price { get; init;}

    }
}
