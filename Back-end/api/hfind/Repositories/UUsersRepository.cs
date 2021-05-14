
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;

namespace hfind.Repositories
{

    public interface UUsersRepository 
    {
     Task<User> GetUserAsync(Guid UserId);
     Task<User> GetUser(string Username, string Password,string Email, string Firstname,string Lastname, int Phone, int Type);
        Task UpdateUserAsync(User User);
       Task CreateUserAsync(User User);
    }
}