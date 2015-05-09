using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Extensions;
using Assert = Xunit.Assert;

namespace FuzzyString.Tests
{
    public class LongestCommonSubstringTests
    {
        [Fact]
        public void WhenLCSChanges_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string target = "k123vin456";

            var result = kevin.LongestCommonSubstring(target);
            Assert.Equal("vin", result);
        }

        [Theory]
        [InlineData(0, 0.33333333333333331)]
        [InlineData(0.1, 0.53333333333333333)]
        [InlineData(0.25, 0.83333333333333326)]
        public void WhenSimilarStrings_ShouldReturnExpectedValue(double pValue, double expectedValue)
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var result = ComparisonMetrics.JaroWinklerDistanceWithPrefixScale(kevin, kevyn, pValue);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 0)]
        [InlineData(0.25, 0)]
        public void WhenDifferentStrings_ShouldReturnExpectedValue(double pValue, double expectedValue)
        {
            const string kevin = "kevin";
            const string abcxyz123 = "abcxyz123";

            var result = ComparisonMetrics.JaroWinklerDistanceWithPrefixScale(kevin, abcxyz123, pValue);
            Assert.Equal(expectedValue, result);
        }
    }
}
