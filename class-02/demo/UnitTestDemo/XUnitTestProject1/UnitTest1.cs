using UnitTestDemo;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanReturn1()
        {
            Assert.Equal("1", FizzBuzz.Convert(1));
        }

        [Fact]
        public void CanReturn2()
        {
            Assert.Equal("2", FizzBuzz.Convert(2));
        }

        [Fact]
        public void CanReturnFizzfor3()
        {
            Assert.Equal("Fizz", FizzBuzz.Convert(3));
        }

        //Do THIS TEST FIRST to override other number tests
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]


		public void NumberTests(int value, string expectedResult)
        {
            //we don't set value.ToString(), to close to implementation
            Assert.Equal(expectedResult, FizzBuzz.Convert(value));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]

        public void FizzTest(int value)
        {
            Assert.Equal("Fizz", FizzBuzz.Convert(value));
        }


        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void BuzzTest(int value)
        {
            Assert.Equal("Buzz", FizzBuzz.Convert(value));
        }


        [Theory]
        [InlineData(15)]
        [InlineData(30)]

        public void FizzBuzzTests(int value)
        {
            Assert.Equal("FizzBuzz", FizzBuzz.Convert(value));
        }

    }

}
