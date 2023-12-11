using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

public class Hachage
{
    public static async Task<Hashtable> CreateHashTableFromMongoDB()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("ProjetMongoDB");
        var collection = database.GetCollection<BsonDocument>("admin");

        var ht = new Hashtable();

        var documents = await collection.Find(new BsonDocument()).ToListAsync();

        int i = 1;
        foreach (var document in documents)
        {
            var clage_90 = document["clage_90"].AsInt32.ToString();
            ht.Add("clage_" + i.ToString("000"), clage_90);
            i++;
        }

        return ht;
    }
}