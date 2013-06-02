using System.IO;
using ServiceStack.Text;

namespace Gator
{
    public class Initialize : IGatorCommand
    {
        public void Execute()
        {
            var cfg = new DbConfig { type = "unspecified", connectionString = "", currentVersion = "none" };

            File.AppendAllText(App.WorkingDirectory + "database.json", JsonSerializer.SerializeToString(cfg));

            Directory.CreateDirectory(App.WorkingDirectory + "versions");
        }
    }
}