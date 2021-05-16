using Microsoft.AspNetCore.Mvc;
using hfind.Repositories;
using System.Collections.Generic;
using hfind.Entities;
using System;
using System.Linq;
using hfind.Dtos;
using System.Threading.Tasks;
using rest.Infra;

namespace hfind.Controllers
{
[ApiController]
[Route("Users")]
public class Userscontroller : ControllerBase 
{
    private readonly UUsersRepository repository;
    public Userscontroller(UUsersRepository repository)
    {
        this.repository = repository;
    }
     [HttpGet("get/")]
   public async Task<ActionResult<UserDto>> GetUserAsync(Guid Id)
    {
      var User = await repository.GetUserAsync(Id);
      if(User is null)
      {
        return NotFound();
      }
      return User.AsDto();
    }
    [HttpPost("register/")]
    public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUserDto UserDto){
     
        User User = new(){
            Id =Guid.NewGuid(),
            Username = UserDto.Username,
            Password = UserDto.Password,
            Email = UserDto.Email,
            Firstname = UserDto.Firstname,
            Lastname = UserDto.Lastname,
            Phone = UserDto.Phone,
            Type = UserDto.Type,
            CreatedDateUser = DateTimeOffset.UtcNow
              };
    
          await repository.CreateUserAsync(User);
          var usr = CreatedAtAction(nameof(GetUserAsync), new {Id = User.Id}, User.AsDto());
            if (usr != null){

                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
                                    .AddSubject(User.Username)
                                    .AddIssuer("issuerTest")
                                    .AddAudience("bearerTest")
                                    .AddClaim("MembershipId", "111")
                                    .AddExpiry(1)
                                    .Build();

                return Ok(token.Value);

            }else
                return Unauthorized();
        }
     [HttpPut("{Id}")]
    public async Task<ActionResult> UpdateUserAsync(Guid Id,UpdateUserDto UserDto){
      var existingUser = await repository.GetUserAsync(Id);
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
     [HttpPost("login/")]
   public async Task<ActionResult> LoginUserAsync(LoginUserDto User)
    {
      var usr = await repository.GetUserAsync(User.Username , User.Password);
      if (usr != null){

                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
                                    .AddSubject(Convert.ToString(User.Username))
                                    .AddIssuer("issuerTest")
                                    .AddAudience("bearerTest")
                                    .AddClaim("MembershipId", "111")
                                    .AddExpiry(1)
                                    .Build();

                return Ok(token.Value);

            }else
                return Unauthorized();
        }
    }
  }