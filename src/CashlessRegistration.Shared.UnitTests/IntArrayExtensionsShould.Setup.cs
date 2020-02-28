using System.Collections.Generic;

namespace CashlessRegistration.Shared.UnitTests
{
    public partial class IntArrayExtensionsShould
    {
        //TODO I would like to use test case to do this!
        private readonly List<int[]> _findByAbsoluteDifferenceInputs;
        private readonly List<int[]> _findByAbsoluteDifferenceExpectedOutputs;
        private readonly List<int[]> _findByAbsoluteDifferenceExpectedOutputsWhenDifferenceIs9;

        private readonly List<int[]> _rotateToRightInputs;
        private readonly List<int[]> _rotateToRightExpectedOutputs;


        public IntArrayExtensionsShould()
        {
            _findByAbsoluteDifferenceInputs = new List<int[]>
            {
                new[] { 1, 9, 1, 3, 4, 4, 5, 6, 5 },
                new[] { 4, 6, 5, 3, 3, 1 }
            };

            _findByAbsoluteDifferenceExpectedOutputs = new List<int[]>
            {
                new[] {1, 1, 3, 4, 4, 5, 5},
                new[] {1, 3, 3, 4, 5}
            };

            _findByAbsoluteDifferenceExpectedOutputsWhenDifferenceIs9 = new List<int[]>
            {
                new[] { 1, 1, 3, 4, 4, 5, 5, 6, 9},
                new[] { 1, 3, 3, 4, 5, 6 }
            };

            _rotateToRightInputs = new List<int[]>
            {
                new[] { 3, 4, 5 },
                new[] { 1, 2, 3 }
            };

            _rotateToRightExpectedOutputs = new List<int[]>
            {
                new[] {4, 5, 3},
                new[] {2, 3, 1}
            };
        }
    }
}
