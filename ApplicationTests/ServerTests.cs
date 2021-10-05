using Application;
using NUnit.Framework;
using Application.Models;

namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Server();
        }

        [Test]
        [TestCase("evening,1", "steak")]
        [TestCase("evening,2", "potato")]
        [TestCase("evening,3", "wine")]
        [TestCase("evening,4", "cake")]
        [TestCase("evening,2,2", "potato(x2)")]
        [TestCase("evening,1,2,3,4", "steak,potato,wine,cake")]
        [TestCase("evening,1,2,2,4", "steak,potato(x2),cake")]
        [TestCase("morning,1", "egg")]
        [TestCase("morning,2", "toast")]
        [TestCase("morning,3", "coffee")]
        [TestCase("morning,1,2,3", "egg,toast,coffee")]
        [TestCase("morning,1,2,3,3", "egg,toast,coffee(x2)")]
        public void TakeOrder_CorrectResponse_ReturnTrue(string input, string expectedOutput)
        {
            AssertEqual(input, expectedOutput);
        }


        [Test]
        [TestCase("evening,1", "steak")]
        [TestCase("EVENING,1", "steak")]
        [TestCase("morning,1", "egg")]
        [TestCase("MORNING,1", "egg")]
        public void TakeOrder_CorrectResponseWithTimeOfDayCaseChanges_ReturnTrue(string input, string expectedOutput)
        {
            AssertEqual(input, expectedOutput);
        }

        [Test]
        [TestCase("evening,,1", "steak")]
        [TestCase("morning,,2", "toast")]
        public void TakeOrder_CorrectResponseWithEmptyValues_ReturnTrue(string input, string expectedOutput)
        {
            AssertEqual(input, expectedOutput);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("evening")]
        [TestCase("evening,")]
        [TestCase("morning")]
        [TestCase("morning,")]
        [TestCase("evening,1,1,3,100")]
        [TestCase("evening,1,1,2,3")]
        [TestCase("morning,1,1,3,4")]
        [TestCase("morning,1,1,2,3")]
        public void TakeOrder_ErrorResponse_ReturnTrue(string input)
        {
            AssertEqual(input, "error");
        }

        private void AssertEqual(string input, string expectedOutput)
        {
            var actual = _sut.TakeOrder(input);
            Assert.AreEqual(expectedOutput, actual);
        }
    }
}