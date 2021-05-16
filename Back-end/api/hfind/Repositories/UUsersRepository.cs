
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;

namespace hfind.Repositories
{

    public interface UUsersRepository 
    {
     Task<User> GetUserAsync(Guid Id);
      Task<User> GetUserAsync(string Username ,string Password);
        Task UpdateUserAsync(User user);
       Task CreateUserAsync(User User);
       Task LoginUserAsync(string Username ,string Password);
       
    }
}