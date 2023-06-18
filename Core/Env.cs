using System.Text.Json.Nodes;

namespace Telegram2A.Core
{
    public static class Env
    {
        public static string GetToken()
        {
            string PathToEnv = "env.json";

            if (!File.Exists(PathToEnv))
            {
                throw new Exception("No env.json file, please create env.json and put your telegram bot token to key token in json formatin");
            }
            string envText;
            using (var r = new StreamReader(PathToEnv))
            {
                envText = r.ReadToEnd();
            }
            var json = JsonNode.Parse(envText);
            if (json == null)
            {
                throw new Exception("Something wrong with env.json file, check envEXAPLE.json");
            }
            var token = (string?)json["token"];
            if (token == null)
            {
                throw new Exception("Can`t find token value");
            }
            return token;
        }
    }
}
