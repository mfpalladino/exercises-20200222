using System;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace CashlessRegistration.Shared.UnitTests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToIntArrayShouldReturnExpectedResult()
        {
            //Setup
            const string source = "123";

            //Action
            var array = source.ToIntArray();

            //Asserts
            array.Should().IsSameOrEqualTo(new[] {1, 2, 3});
        }

        [Fact]
        public void ToIntArrayShouldThrowExceptionWhenSourceIsNullOrEmpty()
        {
            //Setup
            string nullSource = null;
            const string emptySource = "";

            //Action
            Action nullAction = () => nullSource.ToIntArray();
            Action emptyAction = () => emptySource.ToIntArray();

            //Asserts
            nullAction.Should().Throw<ArgumentNullException>();
            emptyAction.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToIntArrayShouldThrowExceptionWhenSourceDoesNotContainsOnlyDigits()
        {
            //Setup
            const string source = "123a";

            //Action
            Action action = () => source.ToIntArray();

            //Asserts
            action.Should().Throw<ArgumentException>();
        }
    }
}
