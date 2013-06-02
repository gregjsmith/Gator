using System.Diagnostics;

namespace Gator.Tests
{
    public class TestEnvironment
    {
        protected void HardDelete(string path)
        {
            Process.Start("cmd", "/C rd " + path + " /Q /S");
        }
    }
}