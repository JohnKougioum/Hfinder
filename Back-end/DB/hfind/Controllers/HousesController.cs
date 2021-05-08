using Microsoft.AspNetCore.Mvc;
using hfind.Repositories;
using System.Collections.Generic;
using hfind.Entities;
using System;
using System.Linq;
using hfind.Dtos;
using System.Threading.Tasks;

namespace hfind.Controllers
{
[ApiController]
[Route("Houses")]
public class HousesController : ControllerBase 
{
    private readonly HHousesRepository repository;
    public HousesController(HHousesRepository repository)
    {
        this.repository = repository;
    }

  [HttpGet]
   public async Task<IEnumerable<HouseDto>> GetHousesAsync()
   {
     var houses = (await repository.GetHouseAsync())
                 .Select(House => House.AsDto());
     return houses;
   }
   [HttpGet("{id}")]
   public async Task<ActionResult<HouseDto>> GetHouseAsync(Guid id)
    {
      var House = await repository.GetHouseAsync(id);
      if(House is null)
      {
        return NotFound();
      }
      return House.AsDto();
    }
    [HttpPost]
    public async Task<ActionResult<HouseDto>> CreateHouseAsync(CreateHouseDto HouseDto){
        House House = new(){
          Id = Guid.NewGuid(),
          Price = HouseDto.Price,
          SellRent = HouseDto.SellRent,
          Region = HouseDto.Region,
          CreatedDate = DateTimeOffset.UtcNow
        };
        await repository.CreateHouseAsync(House);
        return CreatedAtAction(nameof(GetHouseAsync), new {id = House.Id}, House.AsDto());
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateHouseAsync(Guid id,UpdateHouseDto HouseDto){
      var existingHouse = await repository.GetHouseAsync(id);
      if (existingHouse is null)
      {
        return NotFound();

      }
      House updatedHouse = existingHouse with{
        Price = HouseDto.Price,
        SellRent = HouseDto.SellRent,
        Region = HouseDto.Region
      };
      await repository.UpdateHouseAsync(updatedHouse);
      return NoContent();
    }
    [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteHouseAsync(Guid id){
     var existingHouse =  await repository.GetHouseAsync(id);
      if (existingHouse is null)
      {
        return NotFound();

      }
     await repository.DeleteHouseAsync(id);
      return NoContent();

    }
   
  // //  public async Task<ActionResult<HouseDto>> GetSellRentAsync(int SellRent)
  //   // {
  //     var House = await repository.GetSellRentAsync(SellRent);
  //     if(House is null)
  //     {
  //       return NotFound();
  //     }
  //   }
  
    [HttpGet("/SellRent/{SellRent}")]
  
   public async Task<IEnumerable<HouseDto>> GetSellRentAsync(int SellRent)
   {
     var houses = (await repository.GetSellRentAsync(SellRent))
                 .Select(House => House.AsDto());
     return houses;
   }
  }
}

