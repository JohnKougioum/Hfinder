using System;
namespace hfind.Dtos
{

 public record HouseDto
 {
    public Guid Id { get; init; }
    public int SellRent { get; init; }
    public decimal Price { get; init; }
    public String Region { get; init; }
    public  DateTimeOffset CreatedDate { get; init; }
    
 }

}