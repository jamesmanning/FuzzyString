using System;

using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace FuzzyString.Tests
{

    public class CalculateComparisonAverageTests
    {
        [Fact]
        public void WhenSimilarString_AndMultipleOptions_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive,
            };

            Assert.Equal(0.23333333333333334, kevin.CalculateComparisonAverage(kevyn, options));
        }

        [Theory]
        [InlineData(FuzzyStringComparisonOptions.UseHammingDistance,               0.2)]
        [InlineData(FuzzyStringComparisonOptions.UseJaccardDistance,               0.33333333333333337)]
        [InlineData(FuzzyStringComparisonOptions.UseJaroDistance,                  0.33333333333333331)]
        [InlineData(FuzzyStringComparisonOptions.UseJaroWinklerDistance,           0.53333333333333333)]
        [InlineData(FuzzyStringComparisonOptions.UseLevenshteinDistance,           1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubsequence,      0.19999999999999996)]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubstring,        0.4)]
        [InlineData(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance, 0.2)]
        [InlineData(FuzzyStringComparisonOptions.UseOverlapCoefficient,            0.19999999999999996)]
        [InlineData(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity,   0.19999999999999996)]
        [InlineData(FuzzyStringComparisonOptions.UseSorensenDiceDistance,          0.19999999999999996)]
        [InlineData(FuzzyStringComparisonOptions.UseTanimotoCoefficient,           0.33333333333333337)]
        public void WhenSimilarString_AndSingleComparisonOption_ShouldReturnExpectedValue(
            FuzzyStringComparisonOptions fuzzyStringComparisonOption, double expectedValue)
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                fuzzyStringComparisonOption,
            };

            var result = kevin.CalculateComparisonAverage(kevyn, options);
            Assert.Equal(expectedValue, result);
        }
    }
}
