using System;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace CashlessRegistration.Shared.UnitTests
{
    public class StringExtensionsShould
    {
        [Fact]
        public void ToIntArrayReturnExpectedResult()
        {
            //Setup
            const string source = "123";

            //Action
            var array = source.ToIntArray();

            //Asserts
            array.Should().IsSameOrEqualTo(new[] {1, 2, 3});
        }

        [Fact]
        public void ToIntArrayThrowExceptionWhenSourceIsNullOrEmpty()
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
        public void ToIntArrayThrowExceptionWhenSourceDoesNotContainsOnlyDigits()
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
