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
[Route("Like")]
public class LikeHousesController : ControllerBase 
{
     private readonly LLikeHouseByUserRepository repository;
     public LikeHousesController(LLikeHouseByUserRepository repository)
    {
        this.repository = repository;
    }
    [HttpGet("getlike/")]
    public async Task<IEnumerable<LikeHouseByUserDto>> GetLikedHouseAsync(string UId ,int page)
    {
              var houses = (await repository.GetLikedHouseAsync(UId,page))
                 .Select(LikeHouseByUser => LikeHouseByUser.AsDto());
     return houses;
    }
     
    [HttpPost("like/")]
    public async Task<ActionResult<LikeHouseByUserDto>> CreateLikeHouseAsync(CreateLikeahouseDto LikeHouseByUserDto){
        LikeHouseByUser LikeHouseByUser = new(){
           Id = Guid.NewGuid(),
            UId =LikeHouseByUserDto.UId,
            HId =LikeHouseByUserDto.HId
             };
        await repository.CreateLikeHouseAsync(LikeHouseByUser);
        return CreatedAtAction(nameof(GetLikedHouseAsync), new {HId = LikeHouseByUser.HId}, LikeHouseByUser.AsDto());
    }
      [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteLikeHouseAsync(string UId,string HId){
     var existingHouse =  await repository.GetLikedHouseAsync(UId,HId);
      if (existingHouse is null)
      {
        return NotFound();

      }
     await repository.DeleteLikeHouseAsync(UId,HId);
      return NoContent();

    }
    [HttpGet("id/")]
   public async Task<ActionResult<LikeHouseByUserDto>> GetLikedHouseAsync(string UId,string HId)
    {
      var LikeHouseByUser = await repository.GetLikedHouseAsync(UId,HId);
      if(LikeHouseByUser is null)
      {
        return NotFound();
      }
      return LikeHouseByUser.AsDto();
    }
}
}
