using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;

namespace hfind.Repositories
{

    public interface LLikeHouseByUserRepository
    {
      Task<IEnumerable<LikeHouseByUser>> GetLikedHouseAsync(string UId ,int page);
      Task CreateLikeHouseAsync(LikeHouseByUser LikeHouseByUser);
      Task DeleteLikeHouseAsync(String UId,string HId);
      Task<LikeHouseByUser> GetLikedHouseAsync(string UId,string HId);
    }
    }