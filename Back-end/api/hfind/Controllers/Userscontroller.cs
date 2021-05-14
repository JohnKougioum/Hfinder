using Microsoft.AspNetCore.Mvc;
using hfind.Repositories;
using System.Collections.Generic;
using hfind.Entities;
using System;
using System.Linq;
using hfind.Dtos;
using System.Threading.Tasks;
using rest.Controllers;
using rest.Infra;

namespace hfind.Controllers
{
[ApiController]
[Route("Users")]
public class Userscontroller : ControllerBase , IHttpActionResult
{
    private readonly UUsersRepository repository;
    public Userscontroller(UUsersRepository repository)
    {
        this.repository = repository;
    }
     [HttpGet("get/")]
   public async Task<ActionResult<UserDto>> GetUserAsync(Guid UserId)
    {
      var User = await repository.GetUserAsync(UserId);
      if(User is null)
      {
        return NotFound();
      }
      return User.AsDto();
    }
    // [HttpPost("register/")]
    // public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody]User User){
    //   var usr = await repository.GetUser(
    //   //  new User = UserDto;
    //   );
    //         if (usr != null){

    //             var token = new JwtTokenBuilder()
    //                                 .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
    //                                 .AddSubject( User.Username)
    //                                 .AddIssuer("issuerTest")
    //                                 .AddAudience("bearerTest")
    //                                 .AddClaim("MembershipId", "111")
    //                                 .AddExpiry(1)
    //                                 .Build();

    //             return Ok(token.Value);

    //         }else
    //             return Unauthorized();
    //     }
    //     await repository.CreateUserAsync(User);
    //     var CreatedUser = CreatedAtAction(nameof(GetUserAsync), new {UserId = User.UserId}, User.AsDto());
    //     if(!CreatedUser.Successed)
    //     {
    //       return BadRequest(new AuthFailedResponse{

    //         Erros = AuthFailedResponse.Erros
    //       });
    //     }
    //     return Ok(new AuthResponse
    //     {
    //       Token = AuthResponse.Token
    //     });
       
    // }
     [HttpPut("{UserId}")]
    public async Task<ActionResult> UpdateUserAsync(Guid UserId,UpdateUserDto UserDto){
      var existingUser = await repository.GetUserAsync(UserId);
      if (existingUser is null)
      {
        return NotFound();

      }
      User updatedUser = existingUser with{
          Username = UserDto.Username,
          Password = UserDto.Password,
          Email = UserDto.Email,
          Firstname = UserDto.Firstname,
          Lastname = UserDto.Lastname,
          Phone  = UserDto.Phone
      };
      await repository.UpdateUserAsync(updatedUser);
      return NoContent();
    }
  }
}