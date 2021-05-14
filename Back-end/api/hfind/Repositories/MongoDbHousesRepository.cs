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
        
        private readonly IMongoCollection<House> itemsCollection;
        private readonly FilterDefinitionBuilder<House> filterBuilder = Builders<House>.Filter;
    
      public MongoDbHousesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<House>(collectionName);

            
            
        }
        public async Task CreateHouseAsync(House House)
        {
           await itemsCollection.InsertOneAsync(House);
        }

        public async Task DeleteHouseAsync(Guid id)
        {
            var filter = filterBuilder.Eq(House => House.Id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<House> GetHouseAsync(Guid id)
        {
            
            var filter = filterBuilder.Eq(House => House.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<House>> GetHouseAsync(int page )
        {
            int limit=4;

            int skipCount = (page - 1) * limit;

            return await itemsCollection.Find(new BsonDocument()).Skip(skipCount).Limit(limit).ToListAsync();
        }

        public async Task UpdateHouseAsync(House House)
        {
            var filter = filterBuilder.Eq(existingHouse => existingHouse.Id, House.Id);
            await itemsCollection.ReplaceOneAsync(filter, House);
        }
      public async Task<IEnumerable<House>> GetSellRentLocationAsync(string Location, int SellRent,int page)
        {
            int limit=4;

            int skipCount = (page - 1) * limit;

            var filter = filterBuilder.Eq(House => House.Location , Location);
            filter &= filterBuilder.Eq(House => House.SellRent ,SellRent);
           return await itemsCollection.Find(filter).Skip(skipCount).Limit(limit).ToListAsync();
        }
      public async Task<IEnumerable<House>> GetUserAddsAsync(string User,int page)
        {
            int limit=4;

            int skipCount = (page - 1) * limit;

            var filter = filterBuilder.Eq(House => House.UserId , User);
           return await itemsCollection.Find(filter).Skip(skipCount).Limit(limit).ToListAsync();
        }
     public async Task<IEnumerable<House>> GetHouseLocAsync(String Location)
        {
            var filter = filterBuilder.Eq(House => House.Location, Location);
           return await itemsCollection.Find(filter).ToListAsync();
            //return await HousesCollection.Find(new BsonDocument(),filer).ToListAsync();
        }

        //   public async Task<User> GetUserAsync(Guid UserId)
        // {
        //    var filter = filterBuilder.Eq(User => User.UserId, UserId);
        //     return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        // }

      
        // public async Task UpdateUserAsync(User User)
        // {
        //    var filter = filterBuilder.Eq(existingUser => existingUser.Id, User.UserId);
        //     await  itemsCollection.ReplaceOneAsync(filter, User);
        // }
        // public async Task CreateUserAsync(User User)
        // {
        //    await itemsCollection.InsertOneAsync(User);
        // }

        
    }
}
