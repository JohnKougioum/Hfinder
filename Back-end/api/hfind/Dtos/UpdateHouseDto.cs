using System.ComponentModel.DataAnnotations;

namespace hfind.Dtos
{
    
    public record UpdateHouseDto{
    [Required]
    public int SellRent { get; init;}
    [Required]
    public decimal Price { get; init;}
 [Required]
    public string Location { get; init;}
    }
}
