
using System;

namespace hfind.Entities
{
    public record LikeHouseByUser
    {
        public string UId { get; init; }
        public string HId { get; init; }
        public DateTimeOffset CreatedDateLike { get; init; }
    }


}