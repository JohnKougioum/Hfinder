using System;

namespace hfind.Dtos
{
    public record LikeHouseByUserDto
    {
        public string UId { get; init; }
        public string HId { get; init; }
    }


}