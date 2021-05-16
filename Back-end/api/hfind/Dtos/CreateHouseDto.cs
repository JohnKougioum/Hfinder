using System.ComponentModel.DataAnnotations;

namespace hfind.Dtos
{
    
    public record CreateHouseDto{
      public string UserId  { get; init;}
     [Required]
      public int SellRent  { get; init;}
      [Required]
    public string Location { get; init;}
     public string Address { get; init; }
        public int Floor {get; init;}
        public int Sm {get; init;}
        public int Type {get; init;}
      public int Beds {get; init;} 
        public int Baths {get; init;}
        public int HeatingType {get; init;}
        public string Description {get; init;}
    [Required]
    public double Price { get; init;}

    }
}
