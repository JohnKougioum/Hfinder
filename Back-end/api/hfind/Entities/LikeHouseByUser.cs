
using System;

namespace hfind.Entities
{
    public record LikeHouseByUser
    {
        public Guid Id { get; init; }
        public string UId { get; init; }
          public string HId { get; init; }

    }


}