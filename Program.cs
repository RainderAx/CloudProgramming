using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using MongoDB.Bson;
using MongoDB.Driver;
class Program
{
    static async Task Main(string[] args)
    {
        await Data.AddData();
        await Index.CreateIndexes();
    }
}
