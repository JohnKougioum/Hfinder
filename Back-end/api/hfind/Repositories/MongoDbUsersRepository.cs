using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hfind.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace hfind.Repositories

{

    public class MongoDbUsersRepository : UUsersRepository

    {
           private const string databaseName = "hifind";
        private const string collectionName = "Users";
        
        private readonly IMongoCollection<User> itemsCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
    
      public MongoDbUsersRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<User>(collectionName);

            
            
        }
         public async Task CreateUserAsync(User User)
        {
           await itemsCollection.InsertOneAsync(User);
        }

        public async Task<User> GetUserAsync(Guid Id)
        {
            var filter = filterBuilder.Eq(User => User.Id, Id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<User> GetUserAsync(string Username, string Password)
        {
            var filter = filterBuilder.Eq(User => User.Username, Username);
              filter &= filterBuilder.Eq(User => User.Password, Password);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task LoginUserAsync(string Username, string Password)
        {
             var filter = filterBuilder.Eq(User => User.Username, Username);
            filter &= filterBuilder.Eq(User => User.Password, Password);
            await itemsCollection.Find(filter).SingleOrDefaultAsync();
           
          
        }

        public async Task UpdateUserAsync(User User)
        {
             var filter = filterBuilder.Eq(existingUser => existingUser.Id, User.Id);
            await itemsCollection.ReplaceOneAsync(filter, User);
        }

    
    }
}