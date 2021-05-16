
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

       Task<IEnumerable<House>> GetSellRentLocationAsync(string Location, int SellRent, int page,double startPrice, double endPrice, int startSm, int endSm, int Beds, int Baths);
       Task<IEnumerable<House>> GetUserAddsAsync(string User, int page,string Location, int SellRent,  double startPrice, double endPrice, int startSm, int endSm, int Beds, int Baths);
       //   Task<House> GetRentAsync(int SellRent);
        Task CreateHouseAsync(House house);
        Task UpdateHouseAsync(House house);
        Task ReportHouseAsync(House house);
        Task DeleteHouseAsync(Guid id);
       Task<IEnumerable<House>> GetHouseLocAsync(string RegRegionion);
       Task<IEnumerable<House>> GetHouseReportAsync(int Report);
    }
}