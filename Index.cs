using MongoDB.Bson;
using MongoDB.Driver;

class Index
{
    public static async Task CreateIndexes()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("TestMongoDB");
        var collection = database.GetCollection<BsonDocument>("admin");

        // Création d'index
        var globalIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("globalKey");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(globalIndexKeys));

        var localIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("localKey");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(localIndexKeys));
    }
}