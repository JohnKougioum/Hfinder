
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;

namespace hfind.Repositories
{

    public interface HHousesRepository
    {
       Task<House> GetHouseAsync(Guid id);
        Task<IEnumerable<House>> GetHouseAsync();

       Task<IEnumerable<House>> GetSellRentAsync(int SellRent);
       //   Task<House> GetRentAsync(int SellRent);
        Task CreateHouseAsync(House house);
        Task UpdateHouseAsync(House house);
        Task DeleteHouseAsync(Guid id);
    }
}