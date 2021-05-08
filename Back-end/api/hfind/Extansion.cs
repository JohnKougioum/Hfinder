using hfind.Dtos;
using hfind.Entities;

namespace hfind
{
    public static class Extensions{
        public static HouseDto AsDto(this House House){
            return new HouseDto
            {
                  Id = House.Id,
                  SellRent = House.SellRent,
                  Price = House.Price,
                 CreatedDate = House.CreatedDate
     
        };
    }
}
}