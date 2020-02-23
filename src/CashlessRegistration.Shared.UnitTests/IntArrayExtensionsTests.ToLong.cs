using System;
using FluentAssertions;
using Xunit;

namespace CashlessRegistration.Shared.UnitTests
{
    public partial class IntArrayExtensionsTests
    {
        [Fact]
        public void ToLongShouldReturnsExpectedResults()
        {
            //Setup
            int[] input = {1,2,3,4,5,6};
            const int expectedOutput = 123456;

            //Action
            var output = input.ToLong();

            //Assert
            output.Should().Be(expectedOutput);
        }

        [Fact]
        public void ToLongShouldThrowExceptionWhenSourceIsNull()
        {
            //Setup
            int[] source = null;

            //Action
            Action action = () => source.ToLong();

            //Asserts
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToLongShouldThrowExceptionWhenSourceLengthIsZero()
        {
            //Setup
            var sourceWithNoElements = new int[] { };

            //Action
            Action actionWithNoElements = () => sourceWithNoElements.ToLong();

            //Asserts
            actionWithNoElements.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
