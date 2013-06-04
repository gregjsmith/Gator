using Gator.Commands;
using Gator.IO;
using Moq;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_making_a_migration
    {
        private Mock<IFile> _fs;
        private Mock<IDirectory> _ds;

        [SetUp]
        public void Init()
        {
            _fs = new Mock<IFile>();
            _ds = new Mock<IDirectory>();
        }

        [Test]
        public void A_migration_directory_is_created()
        {
            var make = new Make(_fs.Object, _ds.Object) {Args = "make version1".Split(' ')};

            make.Execute();

            _ds.Verify(m => m.Create(It.Is<string>(s => s.Contains(App.BaseMigrationsDirectory))), Times.Once());
            _ds.Verify(m => m.Create(It.Is<string>(s => s.Contains("version1"))), Times.Once());
        }

        [Test]
        public void A_version_json_file_is_created()
        {
            var make = new Make(_fs.Object, _ds.Object) { Args = "make version1".Split(' ') };

            make.Execute();

            _fs.Verify(m => m.CreateWithContent(It.Is<string>(s => s.Contains(App.BaseMigrationsDirectory)), It.IsAny<string>()), Times.Once());
            _fs.Verify(m => m.CreateWithContent(It.Is<string>(s => s.Contains("version.json")), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void The_Version_json_file_will_hold_metadata_about_the_migration()
        {
            var make = new Make(_fs.Object, _ds.Object) { Args = "make version1".Split(' ') };

            make.Execute();

            _fs.Verify(m => m.CreateWithContent(It.IsAny<string>(), It.Is<string>(s => s.Contains(@"""versionNumber"": ""0.0.0"""))), Times.Once());
        }

        [Test]
        [ExpectedException(typeof(GatorException))]
        public void Will_not_remake_or_overwrite_if_the_migration_already_exists()
        {
            _ds.Setup(m => m.Exists(It.IsAny<string>())).Returns(true);

            var make = new Make(_fs.Object, _ds.Object) { Args = "make version1".Split(' ') };

            make.Execute();
        }
    }
}