using System;

namespace hfind.Entities
{
    public record User
    {
        public Guid UserId { get; init; }
        public int SellRent { get; init; }
        public decimal Price { get; init; }
        public string Region { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}