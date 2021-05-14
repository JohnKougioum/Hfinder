
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;

namespace hfind.Repositories
{

    public interface HHousesRepository
    {
       Task<House> GetHouseAsync(Guid id);
        Task<IEnumerable<House>> GetHouseAsync(int page);

       Task<IEnumerable<House>> GetSellRentLocationAsync(string Location, int SellRent, int page);
       Task<IEnumerable<House>> GetUserAddsAsync(string User,int page);
       //   Task<House> GetRentAsync(int SellRent);
        Task CreateHouseAsync(House house);
        Task UpdateHouseAsync(House house);
        Task DeleteHouseAsync(Guid id);
       Task<IEnumerable<House>> GetHouseLocAsync(string RegRegionion);
    }
}