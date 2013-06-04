using Gator.Commands;
using Gator.IO;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_registering_all_services
    {
        [Test]
        public void Get_Help()
        {
            var app = new App();

            app.Boot();

            var cmd = app.GetService<IGatorCommand>(CommandType.Help);

            Assert.IsInstanceOf<Help>(cmd);
        }

        [Test]
        public void Get_FileSystem()
        {
            var app = new App();

            app.Boot();

            var fs = app.GetService<IFile>();

            Assert.IsInstanceOf<FileSystem>(fs);
        }

        [Test]
        public void Get_DirectorySystem()
        {
            var app = new App();

            app.Boot();

            var ds = app.GetService<IDirectory>();

            Assert.IsInstanceOf<DirectorySystem>(ds);
        }

        [Test]
        public void Get_Initialize()
        {
            var app = new App();

            app.Boot();

            var cmd = app.GetService<IGatorCommand>(CommandType.Init);

            Assert.IsInstanceOf<Initialize>(cmd);
        }

        [Test]
        public void Get_Make()
        {
            var app = new App();
            app.Boot();

            var cmd = app.GetService<IGatorCommand>(CommandType.Make);
        }
    }
}
