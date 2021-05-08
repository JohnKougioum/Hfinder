using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace hfind.Repositories
{
    public class MongoDbHousesRepository : HHousesRepository
    {
        private const string databaseName = "hifind";
        private const string collectionName = "Houses";
        private readonly IMongoCollection<House> HousesCollection;
        private readonly FilterDefinitionBuilder<House> filterBuilder = Builders<House>.Filter;

        public MongoDbHousesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            HousesCollection = database.GetCollection<House>(collectionName);
        }

        public async Task CreateHouseAsync(House House)
        {
          await HousesCollection.InsertOneAsync(House);
        }

        public async Task DeleteHouseAsync(Guid id)
        {
            var filter = filterBuilder.Eq(House => House.Id, id);
            await HousesCollection.DeleteOneAsync(filter);
        }

        public async Task<House> GetHouseAsync(Guid id)
        {
            var filter = filterBuilder.Eq(House => House.Id, id);
            return await HousesCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<House>> GetHouseAsync()
        {
            return await HousesCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateHouseAsync(House House)
        {
            var filter = filterBuilder.Eq(existingHouse => existingHouse.Id, House.Id);
            await HousesCollection.ReplaceOneAsync(filter, House);
        }
      public async Task<IEnumerable<House>> GetSellRentAsync(int SellRent)
        {
             var filter = filterBuilder.Eq(House => House.SellRent, SellRent);
            return await HousesCollection.Find(filter).ToListAsync();
        }

      //      public async Task<House> GetRentAsync(int SellRent)
      //   {
         //    var filter = filterBuilder.Eq(House => House.SellRent, SellRent);
        //     return await HousesCollection.Find(filter).SingleOrDefaultAsync();
      //   }
    }
}
// [HttpGet("{SellRent}")]
   //    public async Task<ActionResult<HouseDto>> GetRentRentAsync()
 //    {
 //       var rent = (await repository.GetRentAsync())
  //                .Select(House => House.SellRent);
      
  //     if(rent is null)
  //     {
  //       return NotFound();
 //      }
// 
   //    return House.AsDto();
  //   }
   //   public async Task<House> GetSellRentAsync()
    //      {
    //         var filter = filterBuilder.Eq("SellRent", 0) ;
    //          return await HousesCollection.Find(filter).SingleOrDefaultAsync();
    //    }