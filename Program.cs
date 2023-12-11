using System.Collections;
using System;
using System.Threading.Tasks;

class Program
{
    // Global index
    static string globalIndex = "";

    static async Task Main(string[] args)
    {
        //await Data.AddData();
        //await Index.CreateIndexes();
        //await Index.QueryData();
        await Hachage.CreateHashTableFromMongoDB();

        //Console.WriteLine("Enter the index you want to search for: ");
        //globalIndex = Console.ReadLine();
    }
}