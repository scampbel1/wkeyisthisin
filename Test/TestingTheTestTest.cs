using NUnit.Framework;

namespace Test
{
    public class TestingTheTestTest
    {
        [Test]
        public void TwoPlusTwo_ReturnsFour()
        {
            //Arrange
            int expected = 4;
            int result;

            //Act
            result = 2 + 2;

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}