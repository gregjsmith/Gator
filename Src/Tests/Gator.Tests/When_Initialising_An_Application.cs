using Gator.Commands;
using Gator.IO;
using Moq;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_Initialising_An_Application
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
        public void A_Database_json_file_is_created_at_the_application_root_directory()
        {
            var init = new Initialize(_fs.Object, Mock.Of<IDirectory>());

            init.Execute();

            _fs.Verify(m => m.CreateWithContent(It.Is<string>(s => s.Contains(App.DbJsonCfgFile)), It.IsAny<string>()),
                       Times.Once());
        }


        [Test]
        public void The_database_json_file_holds_database_level_metadata()
        {
            var init = new Initialize(_fs.Object, _ds.Object);

            init.Execute();

            _fs.Verify(
                m =>
                m.CreateWithContent(It.IsAny<string>(), It.Is<string>(s => s.Contains(@"""type"": ""unspecified"""))),
                Times.Once());
            _fs.Verify(
                m =>
                m.CreateWithContent(It.IsAny<string>(), It.Is<string>(s => s.Contains(@"""connectionString"": """""))),
                Times.Once());
            _fs.Verify(
                m =>
                m.CreateWithContent(It.IsAny<string>(), It.Is<string>(s => s.Contains(@"""currentVersion"": ""0.0.0"""))),
                Times.Once());
            _fs.Verify(
                m =>
                m.CreateWithContent(It.IsAny<string>(), It.Is<string>(s => s.Contains(@"""lastMigration"": ""none"""))),
                Times.Once());

        }

        [Test]
        public void A_Root_versions_directory_is_created_within_the_working_directory()
        {
            var init = new Initialize(_fs.Object, _ds.Object);

            init.Execute();

            _ds.Verify(m => m.Create(App.BaseMigrationsDirectory), Times.Once());
        }

        [Test]
        [ExpectedException(typeof (GatorException))]
        public void Application_not_created_Again_when_it_has_already_been_initialized()
        {
            _fs.Setup(m => m.Exists(App.DbJsonCfgFile)).Returns(true);

            var init = new Initialize(_fs.Object, _ds.Object);

            init.Execute();
        }
    }
}
