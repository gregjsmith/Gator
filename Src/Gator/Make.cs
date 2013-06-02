using System;
using System.IO;
using Newtonsoft.Json;

namespace Gator
{
    public class Make : IGatorCommand
    {
        private MakeArgs _args;

        public Make(string[] args)
        {
            _args = new MakeArgs(args);
        }

        public void Execute()
        {
            var dir = App.BaseMigrationsDirectory + @"\" + _args.Name;

            if (Directory.Exists(dir))
            {
                throw new GatorException("Warning -- A migration with that name already exists - exiting");
            }
            
            Directory.CreateDirectory(dir);

            var cfg = new MigrationConfig {created = DateTime.Now, versionNumber = "0.0.0"};

            File.WriteAllText(dir + "/version.json", JsonConvert.SerializeObject(cfg));

        }
    }
}