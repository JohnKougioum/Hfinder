
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;

namespace hfind.Repositories
{

    public interface UUsersRepository 
    {
          Task<List<User>> GetUsers();
     Task<User> GetUserAsync(Guid UserId);
     Task<User> GetUser(Guid UserId ,string Username, string Password,string Email, string Firstname,string Lastname, int Phone, int Type,DateTimeOffset CreatedDateUser);
        Task UpdateUserAsync(User User);
       Task CreateUserAsync(User User);
    }
}