using System;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;

namespace CashlessRegistration.Shared.UnitTests
{
    public partial class IntArrayExtensionsShould
    {
        [Fact]
        public void FindByAbsoluteDifferenceReturnExpectedResults()
        {
            const int absoluteDifferenceToFint = 4;

            //Action and asserts for each case
            for (var inputIndex = 0; inputIndex < _findByAbsoluteDifferenceInputs.Count - 1; inputIndex++)
                _findByAbsoluteDifferenceInputs[inputIndex].FindByAbsoluteDifference(absoluteDifferenceToFint).IsSameOrEqualTo(_findByAbsoluteDifferenceExpectedOutputs[inputIndex]);
        }

        [Fact]
        public void FindByAbsoluteDifferenceThrowExceptionWhenSourceIsNull()
        {
            //Setup
            int[] source = null;

            //Action
            Action action = () => source.FindByAbsoluteDifference(4);

            //Asserts
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FindByAbsoluteDifferenceThrowExceptionWhenSourceLengthIsLessThanTwo()
        {
            //Setup
            var sourceWithNoElements = new int[]{};
            var sourceWithOneElement = new[] {1};

            //Action
            Action actionWithNoElements = () => sourceWithNoElements.FindByAbsoluteDifference(4);
            Action actionWithOneElement = () => sourceWithOneElement.FindByAbsoluteDifference(4);

            //Asserts
            actionWithNoElements.Should().Throw<ArgumentOutOfRangeException>();
            actionWithOneElement.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void FindByAbsoluteDifferenceThrowExceptionWhenAbsoluteDifferenceIsLessThanZero()
        {
            //Action
            Action actionToFindNegativeAbsoluteDifference = () => _findByAbsoluteDifferenceInputs[0].FindByAbsoluteDifference(-1);

            //Asserts
            actionToFindNegativeAbsoluteDifference.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
