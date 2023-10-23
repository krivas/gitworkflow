using ConsoleApp1;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var calcultor = new Calculator();

            Assert.AreEqual(5, calcultor.Add(2, 3));


        }
    }
}