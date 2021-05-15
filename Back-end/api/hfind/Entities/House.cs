using System;

namespace hfind.Entities
{
    public record House
    {
        public string UserId { get; init; }

        public Guid Id { get; init; }
        public int SellRent { get; init; }
        public decimal Price { get; init; }
        public string Location { get; init; }
        public string Address { get; init; }
        public int Floor {get; init;}
        public int Sm {get; init;}
        public int Type {get; init;}
        public int Beds {get; init;} 
        public int Baths {get; init;} 
        public int HeatingType {get; init;}
        public string Description {get; init;}
        public int Report {get; init;}
        public DateTimeOffset CreatedDate { get; init; }


    }
}