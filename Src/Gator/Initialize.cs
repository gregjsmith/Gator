using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gator
{
    public class Initialize : IGatorCommand
    {
        public void Execute()
        {
            if (File.Exists(App.WorkingDirectory + "database.json"))
            {
                throw new GatorException("Warning -- Application already exists at this location");
            }
            var cfg = new DbConfig { type = "unspecified", connectionString = "", currentVersion = "none" };

            File.AppendAllText(App.WorkingDirectory + "database.json",
                               JsonConvert.SerializeObject(cfg, Formatting.Indented, new IsoDateTimeConverter()));

            Directory.CreateDirectory(App.WorkingDirectory + "versions");

            Console.WriteLine("Database config file and versions directory created.");
        }
    }
}