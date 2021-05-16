using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace hfind.Repositories

{

    public class MongoDbLikeHouseByUserRepository : LLikeHouseByUserRepository

    {
           private const string databaseName = "hfind";
        private const string collectionName = "LikedHouse";
        
        private readonly IMongoCollection<LikeHouseByUser> itemsCollection;
        private readonly FilterDefinitionBuilder<LikeHouseByUser> filterBuilder = Builders<LikeHouseByUser>.Filter;
    
      public MongoDbLikeHouseByUserRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<LikeHouseByUser>(collectionName);

            
            
        }

        public async Task CreateLikeHouseAsync(LikeHouseByUser LikeHouseByUser)
        {
            await itemsCollection.InsertOneAsync(LikeHouseByUser);
        }

        public async Task DeleteLikeHouseAsync(string UId,string HId)
        {
            var filter = filterBuilder.Eq(LikeHouseByUser => LikeHouseByUser.HId, HId);
            filter &= filterBuilder.Eq(LikeHouseByUser => LikeHouseByUser.HId ,HId);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<LikeHouseByUser>> GetLikedHouseAsync(string UId, int page)
        {   var filter = filterBuilder.Eq(LikeHouseByUser => LikeHouseByUser.UId, UId);
            return await itemsCollection.Find(filter).Limit(page).ToListAsync();
        }

        public async Task<LikeHouseByUser> GetLikedHouseAsync(string UId,string HId)
        {
            var filter = filterBuilder.Eq(LikeHouseByUser => LikeHouseByUser.UId, UId);
             filter &= filterBuilder.Eq(LikeHouseByUser => LikeHouseByUser.HId ,HId);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }
    }
}
