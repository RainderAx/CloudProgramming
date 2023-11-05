using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;






collection.InsertOne(document);

class Program
{
    static async Task Main(string[] args)
    {
        var client = new MongoClient("mongodb://localhost:27017");

        var database = client.GetDatabase("TestMongoDB");
        IMongoDatabase database = client.GetDatabase("TraitementDeDonnee");

        string apiUrl = "https://explore.data.gouv.fr/?url=https%3A%2F%2Fwww.data.gouv.fr%2Ffr%2Fdatasets%2Fr%2Fe3d83ab3-dc52-4c99-abaf-8a38050cc68c";
        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            List<VotreClasseDeDonnees> donnees = JsonConvert.DeserializeObject<List<VotreClasseDeDonnees>>(json);

            IMongoCollection<VotreClasseDeDonnees> collection = database.GetCollection<VotreClasseDeDonnees>("Admin");
            await collection.InsertManyAsync(donnees);
        }
        else
        {
            Console.WriteLine("Erreur lors de la récupération des données.");
        }
    }
}
