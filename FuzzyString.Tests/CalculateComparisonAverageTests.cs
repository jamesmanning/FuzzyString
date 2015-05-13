using System;

using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace FuzzyString.Tests
{

    public class CalculateComparisonAverageTests
    {
        [Fact]
        public void WhenNoTestsChosen_ShouldReturnOne()
        {
            const string kevin = "kevin";

            var options = new FuzzyStringComparisonOptions[0];

            var result = kevin.CalculateComparisonAverage(kevin, options);
            Assert.Equal(1, result);
        }

        [Fact]
        public void WhenMatchingStrings_AndMultipleOptions_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";

            var options = new[]
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive,
            };

            var result = kevin.CalculateComparisonAverage(kevin, options);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(FuzzyStringComparisonOptions.UseHammingDistance,               0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseJaccardDistance,               0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseJaroDistance,                  1.0)] // TODO: this seems broken
        [InlineData(FuzzyStringComparisonOptions.UseJaroWinklerDistance,           1.0)] // TODO: this seems broken
        [InlineData(FuzzyStringComparisonOptions.UseLevenshteinDistance,           0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubsequence,      0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubstring,        0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance, 0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseOverlapCoefficient,            0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity,   0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseSorensenDiceDistance,          0.0)]
        [InlineData(FuzzyStringComparisonOptions.UseTanimotoCoefficient,           0.0)]
        public void WhenMatchingStrings_AndSingleComparisonOption_ShouldReturnExpectedValue(
            FuzzyStringComparisonOptions fuzzyStringComparisonOption, double expectedValue)
        {
            const string kevin = "kevin";

            var options = new[]
            {
                fuzzyStringComparisonOption,
            };

            var result = kevin.CalculateComparisonAverage(kevin, options);
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void WhenSimilarString_AndMultipleOptions_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new[]
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive,
            };

            var result = kevin.CalculateComparisonAverage(kevyn, options);
            Assert.Equal(0.23333333333333334, result);
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

            var options = new[]
            {
                fuzzyStringComparisonOption,
            };

            var result = kevin.CalculateComparisonAverage(kevyn, options);
            Assert.Equal(expectedValue, result, 15);
        }

        [Fact]
        public void WhenDifferentString_AndMultipleOptions_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string abcxyz123 = "abcxyz123";

            var options = new[]
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive,
            };

            var result = kevin.CalculateComparisonAverage(abcxyz123, options);
            Assert.Equal(1.0, result);
        }

        [Theory]
        [InlineData(FuzzyStringComparisonOptions.UseHammingDistance,               1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseJaccardDistance,               1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseJaroDistance,                  0.0)] // TODO: this seems broken
        [InlineData(FuzzyStringComparisonOptions.UseJaroWinklerDistance,           0.0)] // TODO: this seems broken
        [InlineData(FuzzyStringComparisonOptions.UseLevenshteinDistance,           1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubsequence,      1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubstring,        1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance, 1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseOverlapCoefficient,            1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity,   1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseSorensenDiceDistance,          1.0)]
        [InlineData(FuzzyStringComparisonOptions.UseTanimotoCoefficient,           1.0)]
        public void WhenDifferentString_AndSingleComparisonOption_ShouldReturnExpectedValue(
            FuzzyStringComparisonOptions fuzzyStringComparisonOption, double expectedValue)
        {
            const string kevin = "kevin";
            const string abcxyz123 = "abcxyz123";

            var options = new[]
            {
                fuzzyStringComparisonOption,
            };

            var result = kevin.CalculateComparisonAverage(abcxyz123, options);
            Assert.Equal(expectedValue, result);
        }
    }
}
