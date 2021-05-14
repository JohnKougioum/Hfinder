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

        public Task<User> GetUser(Guid UserId ,string Username, string Password, string Email, string Firstname, string Lastname, int Phone, int Type, DateTimeOffset CreatedDateUser)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(Guid UserId)
        {
            var filter = filterBuilder.Eq(User => User.UserId, UserId);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(User User)
        {
             var filter = filterBuilder.Eq(existingUser => existingUser.UserId, User.UserId);
            await itemsCollection.ReplaceOneAsync(filter, User);
        }
    }
}