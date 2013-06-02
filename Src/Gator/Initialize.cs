using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gator
{
    public class Initialize : IGatorCommand
    {
        public void Execute()
        {
            var cfg = new DbConfig { type = "unspecified", connectionString = "", currentVersion = "none" };

            File.AppendAllText(App.WorkingDirectory + "database.json",
                               JsonConvert.SerializeObject(cfg, Formatting.Indented, new IsoDateTimeConverter()));

            Directory.CreateDirectory(App.WorkingDirectory + "versions");
        }
    }
}