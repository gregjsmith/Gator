using System;
using System.Collections.Generic;
using Gator.Commands;
using Gator.IO;
using Ninject;
using Ninject.Modules;

namespace Gator
{
    public class App
    {
        public static string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";

        public static string BaseMigrationsDirectory = WorkingDirectory + @"migrations";

        public static string DbJsonCfgFile = WorkingDirectory + "database.json";

        
        public void Boot()
        {
            _kernel = new StandardKernel(new GatorModule());

            _rules = new List<Func<string[], string>>();
            _rules.AddRange(new BasicRules());
            _rules.AddRange(new InitRules());
            _rules.AddRange(new MakeRules());
        }


        public IGatorCommand GetCommand(string[] args)
        {
            if (_rules == null || _kernel == null)
            {
                throw new InvalidOperationException("Can't get a command yet - call Boot() first.");
            }

            foreach (var rule in _rules)
            {
                string name = rule(args);

                if (!string.IsNullOrWhiteSpace(name))
                {
                    var svc = _kernel.Get<IGatorCommand>(name: name);
                    if (svc is IArgs)
                    {
                        svc.GetType().GetProperty("Args").SetValue(svc, args);
                    }

                    return svc;
                }
            }

            throw new InvalidOperationException("Arguments  '" + string.Join(" ", args) + "' are not valid");
        }


        public T GetService<T>(string name)
        {
            return _kernel.Get<T>(name);
        }

        public T GetService<T>()
        {
            return _kernel.Get<T>();
        }

        private List<Func<string[], string>> _rules;
        private IKernel _kernel;

        private class GatorModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IDirectory>().To<DirectorySystem>();
                Bind<IFile>().To<FileSystem>();
                Bind<IGatorCommand>().To<Help>().Named(CommandType.Help);
                Bind<IGatorCommand>().To<Initialize>().Named(CommandType.Init);
                Bind<IGatorCommand>().To<MakeHelp>().Named(CommandType.MakeHelp);
                Bind<IGatorCommand>().To<Make>().Named(CommandType.Make);
            }
        }
    }
}