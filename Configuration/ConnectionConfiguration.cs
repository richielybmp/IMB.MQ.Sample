
using System.Text.Json;

namespace IMB.MQ.Sample.Configuration
{

    internal class ConnectionConfiguration
    {
        public string Channel { get; set; }
        public string Hostname { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string UserId { get; set; }


        public ConnectionConfiguration() { }

        public static ConnectionConfiguration Load()
        {
            ConnectionConfiguration config = null;

            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");

            if (!File.Exists(jsonFilePath))
            {
                jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");
            }

            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);

                config = JsonSerializer.Deserialize<ConnectionConfiguration>(jsonString);

            }

            return config;
        }

        public override string ToString()
        {
            return $"host = {Hostname} / port = {Port} / channel = {Channel} / user = {UserId} / password = {Password}";
        }
    }
}