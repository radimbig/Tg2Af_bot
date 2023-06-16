using System.Text.Json;

namespace Telegram2A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> keyValuePairs = new Dictionary<string,string>();

            keyValuePairs.Add("Ubisoft", "asdasd");
            keyValuePairs.Add("Steam", "lllll");

            string Json = JsonSerializer.Serialize(keyValuePairs, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            if (!File.Exists("database.json"))
            {
                File.Create("database.json");
            }
            using(var wr = new StreamWriter("database.json"))
            {
                wr.Write(Json);
                wr.Flush();
            }
        }

    }
}