using BusinessLogic;
using static BusinessLogic.Whoosh;

namespace TestBusinesLogic
{
    public class TestFindCorrectScooter
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestReadScooter()
        {
            Transport.Add(new Scooter(1, 1, 1, 50));
            var checkScooter = ReadScooter("1a");
            Assert.That(checkScooter);
        }

        [Test]
        public void TestCurrentSamokat()
        {
            Transport.Add(new Scooter(1, 1, 1, 50));
            ReadScooter("1a");
            Scooter testcScooter = new Scooter(1, 1, 1, 50);
            Assert.That(
                testcScooter.Number == CurrentSamokat.Number && 
                testcScooter.Charge == CurrentSamokat.Charge &&
                testcScooter.Costs == CurrentSamokat.Costs &&
                testcScooter.Speed == CurrentSamokat.Speed &&
                testcScooter.Index == CurrentSamokat.Index
            );
        }
    }
}