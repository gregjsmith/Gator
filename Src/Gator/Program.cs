using System;

namespace Gator
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var cmd = args.Handle();

            cmd.Execute();

                
            if (args[0] == "init")
            {
                
            }
        }
    }



    public class App
    {
        public static string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";
    }
}
