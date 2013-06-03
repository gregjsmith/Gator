using Gator.IO;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_registering_all_services
    {
        [Test]
        public void Can_Get_a_Help_type()
        {
            var app = new App();

            app.Boot();

            var cmd = app.GetService<IGatorCommand>(CommandType.Help);

            Assert.IsInstanceOf<Help>(cmd);
        }

        [Test]
        public void Get_FileSystem_Instance()
        {
            var app = new App();

            app.Boot();

            var fs = app.GetService<IFile>();

            Assert.IsInstanceOf<FileSystem>(fs);
        }

        [Test]
        public void Get_DirectorySystem_Instance()
        {
            var app = new App();

            app.Boot();

            var ds = app.GetService<IDirectory>();

            Assert.IsInstanceOf<DirectorySystem>(ds);
        }

        [Test]
        public void Can_Get_an_Initialise_type()
        {
            var app = new App();

            app.Boot();

            var cmd = app.GetService<IGatorCommand>(CommandType.Init);

            Assert.IsInstanceOf<Initialize>(cmd);
        }
    }
}
