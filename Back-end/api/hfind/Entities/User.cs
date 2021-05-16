using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace hfind.Entities
{
  // [BsonKnownTypes(typeof(LikeHouse))]
    public record User
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public string Firstname { get; init;}
        public string Lastname { get; init;}
        public int Phone { get; init;}
        public int Type { get; init;}
      //  public IEnumerable<LikeHouse> LikedHouses { get; init;}
        public DateTimeOffset CreatedDateUser { get; init; }
    //  public record LikeHouse : User
    //  {
    //    private string Idh { get; init;}
    //  }

}
}