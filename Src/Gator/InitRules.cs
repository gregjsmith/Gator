using System;
using System.Collections;
using System.Collections.Generic;

namespace Gator
{
    public class InitRules : IEnumerable<Func<string[], string>>
    {
        private IEnumerable<Func<string[], string>> Rules()
        {
            Func<string[], string> initOnly = args =>
                {
                    if (args.Length == 1 && args[0] == "init")
                    {
                        return CommandType.Init;
                    }
                    return null;
                };

            return new List<Func<string[], string>>{initOnly};

        }
        public IEnumerator<Func<string[], string>> GetEnumerator()
        {
            return Rules().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class MakeRules : IEnumerable<Func<string[], string>>
    {
        private IEnumerable<Func<string[], string>> Rules()
        {
            Func<string[], string> makeOnly = args =>
            {
                if (args.Length == 1 && args[0] == "make")
                {
                    return CommandType.MakeHelp;
                }
                return null;
            };

            Func<string[], string> makePlusName = args =>
            {
                if (args.Length == 2 && args[0] == "make")
                {
                    return CommandType.Make;
                }
                return null;
            };


            return new List<Func<string[], string>> { makeOnly, makePlusName };

        }
        public IEnumerator<Func<string[], string>> GetEnumerator()
        {
            return Rules().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}