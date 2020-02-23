using System;
using FluentAssertions;
using Xunit;
using FluentAssertions.Common;

namespace CashlessRegistration.Shared.UnitTests
{
    public partial class IntArrayExtensionsTests
    {
        [Fact]
        public void RotateToRightShouldReturnsExpectedResults()
        {
            const int numberOfRotations = 2;

            //Action and asserts for each case
            for (var inputIndex = 0; inputIndex < _rotateToRightInputs.Count - 1; inputIndex++)
                _rotateToRightInputs[inputIndex].RotateToRight(numberOfRotations).IsSameOrEqualTo(_rotateToRightExpectedOutputs[inputIndex]);
        }

        [Fact]
        public void RotateToRightShouldThrowExceptionWhenSourceIsNull()
        {
            //Setup
            int[] source = null;

            //Action
            Action action = () => source.RotateToRight(2);

            //Asserts
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RotateToRightShouldThrowExceptionWhenSourceLengthIsLessThanTwo()
        {
            //Setup
            var sourceWithNoElements = new int[] { };
            var sourceWithOneElement = new[] { 1 };

            //Action
            Action actionWithNoElements = () => sourceWithNoElements.RotateToRight(4);
            Action actionWithOneElement = () => sourceWithOneElement.RotateToRight(4);

            //Asserts
            actionWithNoElements.Should().Throw<ArgumentOutOfRangeException>();
            actionWithOneElement.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void RotateToRightShouldThrowExceptionWhenNumberOfRotationsIsLessThanOrEqualZero()
        {
            //Action
            Action actionToZero = () => _rotateToRightInputs[0].RotateToRight(0);
            Action actionToNegative = () => _rotateToRightInputs[0].RotateToRight(-1);

            //Asserts
            actionToZero.Should().Throw<ArgumentOutOfRangeException>();
            actionToNegative.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
