using System;

namespace Gator
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                var app = new App();
                app.Boot();

                var cmd = app.GetCommand(args);

                cmd.Execute();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }
    }
}
