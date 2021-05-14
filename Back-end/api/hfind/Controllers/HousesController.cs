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
  //28:56
    private readonly HHousesRepository repository;
    public HousesController(HHousesRepository repository)
    {
        this.repository = repository;
    }

  [HttpGet]
   public async Task<IEnumerable<HouseDto>> GetHousesAsync(int page)
   {
     var houses = (await repository.GetHouseAsync(page))
                 .Select(House => House.AsDto());
     return houses;
   }
   [HttpGet("id/{id}")]
   public async Task<ActionResult<HouseDto>> GetHouseAsync(Guid id)
    {
      var House = await repository.GetHouseAsync(id);
      if(House is null)
      {
        return NotFound();
      }
      return House.AsDto();
    }
     [HttpGet("{Location}")]
   public async Task<IEnumerable<HouseDto>> GetHouseLocAsync(String Location)
    {
        var houses = (await repository.GetHouseLocAsync(Location))
                 .Select(House => House.AsDto());

      return houses;
    }
    [HttpPost]
    public async Task<ActionResult<HouseDto>> CreateHouseAsync(CreateHouseDto HouseDto){
        House House = new(){
          UserId = HouseDto.UserId,         
          Id = Guid.NewGuid(),
          Price = HouseDto.Price,
          SellRent = HouseDto.SellRent,
          Location = HouseDto.Location,
          Address = HouseDto.Address,
          Floor = HouseDto.Floor,
          Sm = HouseDto.Sm,
          Type = HouseDto.Type,
          Rooms = HouseDto.Rooms,
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
        Location = HouseDto.Location,
        Address = HouseDto.Address,
          Floor = HouseDto.Floor,
          Sm = HouseDto.Sm,
          Type = HouseDto.Type,
          Rooms = HouseDto.Rooms
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
   
    [HttpGet("/SellRent/{Location}")]
  
   public async Task<IEnumerable<HouseDto>> GetSellRentLocationAsync(string Location, int SellRent)
   {
     var houses = (await repository.GetSellRentLocationAsync(Location,SellRent))
                 .Select(House => House.AsDto());
     return houses;
   }
  }

}

