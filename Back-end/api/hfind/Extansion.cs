using hfind.Dtos;
using hfind.Entities;

namespace hfind
{
    public static class Extensions{
        public static HouseDto AsDto(this House House){
            return new HouseDto
            {
                  UserId = House.UserId,  
                  Id = House.Id,
                  SellRent = House.SellRent,
                  Price = House.Price,
                  Location = House.Location,
                  Address = House.Address,
                  Floor = House.Floor,
                  Sm = House.Sm,
                  Type = House.Type,
                  Rooms = House.Rooms,
                  CreatedDate = House.CreatedDate
     
        };
    }
    public static UserDto AsDto(this User User)
    {
        return new UserDto
        {
         UserId = User.UserId,
          Username = User.Username,
          Password = User.Password,
          Email = User.Email,
          Firstname = User.Firstname,
          Lastname = User.Lastname,
          Phone  = User.Phone,
          Type = User.Type,
          CreatedDateUser = User.CreatedDateUser
        };
    }
}
}