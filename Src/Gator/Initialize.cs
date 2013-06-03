using System;
using System.IO;
using Gator.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gator
{
    public class Initialize : IGatorCommand
    {
        private readonly IFile _fs;
        private readonly IDirectory _ds;

        public Initialize(IFile fs, IDirectory ds)
        {
            _fs = fs;
            _ds = ds;
        }

        public void Execute()
        {
            if (_fs.Exists(App.DbJsonCfgFile))
            {
                throw new GatorException("Warning -- Application already exists at this location");
            }

            var cfg = new DbConfig { type = "unspecified", connectionString = "", currentVersion = "0.0.0" };

            _fs.CreateWithContent(App.DbJsonCfgFile, JsonConvert.SerializeObject(cfg, Formatting.Indented, new IsoDateTimeConverter()));

            _ds.Create(App.BaseMigrationsDirectory);

            Console.WriteLine("Database config file and versions directory created.");
        }
    }
}