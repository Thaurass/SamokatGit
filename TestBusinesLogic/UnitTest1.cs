using BusinessLogic;
using static BusinessLogic.Whoosh;

namespace TestBusinesLogic
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestReadScooter()
        {
            Transport.Add(new Scooter(1, 1, 1, 50));
            var checkScooter = Whoosh.ReadScooter("1a");
            Assert.That(checkScooter);
        }
    }
}