using System;
using System.Collections;
using System.Collections.Generic;

namespace Gator
{
    public class BasicRules : IEnumerable<Func<string[], string>>
    {
        private static IEnumerable<Func<string[], string>> Rules()
        {
            Func<string[], string> blank = args =>
                {
                    if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
                    {
                        return CommandType.Help;
                    }

                    return null;
                };


            Func<string[], string> help = args =>
                {
                    if (args.Length == 1 && args[0] == "help")
                    {
                        return CommandType.Help;
                    }
                    return null;
                };


            return new List<Func<string[], string>>{blank, help};
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