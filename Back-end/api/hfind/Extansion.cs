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
                  HeatingType = House.HeatingType,
                  Type = House.Type,
                  Description = House.Description,
                  Beds = House.Beds,
                  Baths = House.Baths,
                  Report = House.Report,
                  CreatedDate = House.CreatedDate
     
        };
    }
    public static UserDto AsDto(this User User)
    {
        return new UserDto
        {
         Id = User.Id,
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
     public static LikeHouseByUserDto AsDto(this LikeHouseByUser LikeHouseByUser)
    {
        return new LikeHouseByUserDto
        {
         UId =LikeHouseByUser.UId,
         HId = LikeHouseByUser.HId
        };
    }
}
}