using NUnit.Framework;

namespace Gator.Tests
{
    public class When_handling_arguments
    {
        [Test]
        public void When_first_is_init_then_initialize()
        {
            var cmd = "init".Split(' ').Handle();

            Assert.IsInstanceOf<Initialize>(cmd);

        }
    }
}
