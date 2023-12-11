using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

class Data
{
    public static async Task AddData()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("ProjetMongoDB");
        var collection = database.GetCollection<BsonDocument>("admin");

        using (var reader = new StreamReader("C:\\Users\\chape\\OneDrive - De Vinci\\benoit esilv\\Cloud Programming\\CloudProgrammingTP\\CloudProgramming\\covid-hosp-txad-age-fra-2023-06-30-16h29.csv"))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" }))
        {
            var records = csv.GetRecords<dynamic>();
            foreach (var record in records)
            {
                var document = new BsonDocument
            {
                { "fra", record.fra },
                { "jour", DateTime.Parse(record.jour) },
                { "clage_90", int.Parse(record.clage_90) },
                { "PourAvec", int.Parse(record.PourAvec) },
                { "tx_indic_7J_DC", record.tx_indic_7J_DC },
                { "tx_indic_7J_hosp", record.tx_indic_7J_hosp },
                { "tx_indic_7J_SC", record.tx_indic_7J_SC },
                { "tx_prev_hosp", record.tx_prev_hosp },
                { "tx_prev_SC", record.tx_prev_SC }
            };
                await collection.InsertOneAsync(document);
            }
        }
    }
}