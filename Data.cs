using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using MongoDB.Bson;
using MongoDB.Driver;

class Data
{
    public static async Task AddData()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("TestMongoDB");
        var collection = database.GetCollection<BsonDocument>("admin");

        //Read the CSV file
        using (var reader = new StreamReader("C:\\Users\\chape\\OneDrive - De Vinci\\benoit esilv\\Covid.csv"))
        using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var records = csv.GetRecords<dynamic>();
            int count = 0;

            foreach (var record in records)
            {
                if (count >= 100) break;

                var document = new BsonDocument(record);
                await collection.InsertOneAsync(document);
                count++;
            }
        }
    }
}