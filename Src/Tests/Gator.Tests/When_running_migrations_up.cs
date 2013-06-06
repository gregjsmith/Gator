using System.Linq;
using Gator.Commands;
using Moq;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_Migrating_the_database
    {
        [Test]
        public void All_pending_Up_when_no_direction_or_top_specified()
        {
            var mig1 = new Migration {UpSql = "select * from tubes", Config = new MigrationConfig()};
            var mig2 = new Migration {UpSql = "drop * from loltubes", Config = new MigrationConfig()};

            var migs = new[] {mig1, mig2};

            var repo = new Mock<IMigrationRepository>();
            repo.Setup(m => m.GetAll()).Returns(migs);


            var db = new Mock<IDatabase>();

            var migrator = new Migrator(repo.Object, db.Object);

            migrator.Execute();

            db.Verify(m => m.Execute(It.Is<string>(s => s.Contains("select * from tubes"))), Times.Once());
            db.Verify(m => m.Execute(It.Is<string>(s => s.Contains("drop * from loltubes"))), Times.Once());
        }

        [Test]
        public void Only_those_to_the_top_when_top_is_specified()
        {
            
        }
    }

    public enum Direction
    {
        Up
    }

    public class Migrator : IGatorCommand
    {
        private readonly IMigrationRepository _repo;
        private readonly IDatabase _db;
        private Direction _direction;

        public Migrator(IMigrationRepository repo, IDatabase db, Direction direction = Direction.Up)
        {
            _repo = repo;
            _db = db;
            _direction = direction;
        }


        public void Execute()
        {
            var migrations = _repo.GetAll().OrderBy(m => m.Config.created).ToList();

            string sql = "";

            if (_direction == Direction.Up)
            {
                foreach (var migration in migrations)
                {
                    sql += migration.UpSql;
                }
            }

            _db.Execute(sql);
        }
    }

    public interface IDatabase
    {
        void Execute(string sql);
    }

    public class Migration : IMigration
    { 
        public MigrationConfig Config { get; set; }
        public string UpSql { get; set; }
        public string DownSql { get; set; }
    }

    public interface IMigration
    {
        MigrationConfig Config { get; }
        string UpSql { get; set; }
        string DownSql { get; set; }
    }

    public class MigrationsRepository : IMigrationRepository
    {
        public Migration[] GetAll()
        {
            return new[]{new Migration()} ;
        }
    }

    public interface IMigrationRepository
    {
        Migration[] GetAll();
    }
}
