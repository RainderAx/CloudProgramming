using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

class Index
{
    public static async Task CreateIndexes()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("ProjetMongoDB");
        var collection = database.GetCollection<BsonDocument>("admin");

        // Création d'index
        var clage90IndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("clage_90");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(clage90IndexKeys));

        var jourIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("jour");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(jourIndexKeys));

        var tx_indic_7J_DCIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("tx_indic_7J_DC");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(tx_indic_7J_DCIndexKeys));

        var tx_indic_7J_hospIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("tx_indic_7J_hosp");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(tx_indic_7J_hospIndexKeys));

        var tx_indic_7J_SCIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("tx_indic_7J_SC");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(tx_indic_7J_SCIndexKeys));

        var tx_prev_hospIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("tx_prev_hosp");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(tx_prev_hospIndexKeys));

        var tx_prev_SCIndexKeys = Builders<BsonDocument>.IndexKeys.Ascending("tx_prev_SC");
        await collection.Indexes.CreateOneAsync(new CreateIndexModel<BsonDocument>(tx_prev_SCIndexKeys));
    }

    public static async Task QueryData()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("ProjetMongoDB");
        var collection = database.GetCollection<BsonDocument>("admin");

        var filterBuilder = Builders<BsonDocument>.Filter;
        var filter = filterBuilder.Eq("clage_90", 0) & filterBuilder.Gte("tx_indic_7J_DC", "5");

        var documents = await collection.Find(filter).ToListAsync();

        foreach (var document in documents)
        {
            Console.WriteLine(document.ToString());
        }
    }
}