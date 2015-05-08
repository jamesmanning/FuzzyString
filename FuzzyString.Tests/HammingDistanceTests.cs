using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuzzyString.Tests
{
    [TestClass]
    public class HammingDistanceTests
    {
        private static readonly List<FuzzyStringComparisonOptions> HammingDistanceComparisonOptions = new List<FuzzyStringComparisonOptions>
        {
            FuzzyStringComparisonOptions.UseHammingDistance
        };

        [TestMethod]
        public void WhenStrongComparisonOfStringsWithOnlyOneCharacterMatching_ShouldReturnFalse()
        {
            var strongComparisonResult = "x123456789".ApproximatelyEquals("xjdklcjkdm", HammingDistanceComparisonOptions, FuzzyStringComparisonTolerance.Strong);
            Assert.IsFalse(strongComparisonResult);
        }
    }
}
