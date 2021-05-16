using System;
using MongoDB.Bson.Serialization.Attributes;

namespace hfind.Entities
{
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
        public string LikedHouses { get; init;}
        public DateTimeOffset CreatedDateUser { get; init; }

       
        
    }
}