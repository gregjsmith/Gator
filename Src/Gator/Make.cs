using System;
using Gator.IO;
using Newtonsoft.Json;

namespace Gator
{
    public class Make : IGatorCommand, IArgs
    {
        private readonly IFile _fs;
        private readonly IDirectory _ds;
        private MakeArgs _args;

        public Make(IFile fs, IDirectory ds)
        {
            _fs = fs;
            _ds = ds;
        }

        public string[] Args { set {_args = new MakeArgs(value);} }

        public void Execute()
        {
            var dir = App.BaseMigrationsDirectory + @"\" + _args.Name;

            if (_ds.Exists(dir))
            {
                throw new GatorException("Warning -- A migration with that name already exists - exiting");
            }
            
            _ds.Create(dir);

            var cfg = new MigrationConfig {created = DateTime.Now, versionNumber = "0.0.0"};

            _fs.CreateWithContent(dir + "/version.json", JsonConvert.SerializeObject(cfg));
        }
    }
}