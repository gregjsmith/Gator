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
            if (File.Exists(App.DbJsonCfgFile))
            {
                throw new GatorException("Warning -- Application already exists at this location");
            }

            var cfg = new DbConfig { type = "unspecified", connectionString = "", currentVersion = "0.0.0" };

            File.AppendAllText(App.DbJsonCfgFile, JsonConvert.SerializeObject(cfg, Formatting.Indented, new IsoDateTimeConverter()));

            Directory.CreateDirectory(App.BaseMigrationsDirectory);

            Console.WriteLine("Database config file and versions directory created.");
        }
    }
}