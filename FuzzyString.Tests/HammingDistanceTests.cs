using System;

using System.Collections.Generic;
using Xunit;

namespace FuzzyString.Tests
{

    public class HammingDistanceTests
    {
        private static readonly List<FuzzyStringComparisonOptions> HammingDistanceComparisonOptions = new List<FuzzyStringComparisonOptions>
        {
            FuzzyStringComparisonOptions.UseHammingDistance
        };

        [Fact]
        public void WhenStrongComparisonOfStringsWithOnlyOneCharacterMatching_ShouldReturnFalse()
        {
            var strongComparisonResult = "x123456789".ApproximatelyEquals("xjdklcjkdm", HammingDistanceComparisonOptions, FuzzyStringComparisonTolerance.Strong);
            Assert.False(strongComparisonResult);
        }
    }
}
