using System;

using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace FuzzyString.Tests
{

    public class ApproximatelyEqualTests
    {
        [Fact]
        public void WhenNoTestsChosen_ShouldReturnFalse()
        {
            const string kevin = "kevin";

            var options = new FuzzyStringComparisonOptions[0];

            Assert.False(kevin.ApproximatelyEquals(kevin, FuzzyStringComparisonTolerance.Weak, options));
        }

        [Fact]
        public void WhenSimilarString_AndMultipleComparisonOptions_ShouldReturnTrueForWeakAndNormalAndStrong()
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

            Assert.True(kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Weak, options));
            Assert.True(kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Normal, options));
            Assert.True(kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Strong, options));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnFalseForManual()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new[]
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive
            };

            Assert.False(kevin.ApproximatelyEquals(kevyn, FuzzyStringComparisonTolerance.Manual, options));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnFalseForInvalidFuzzyStringComparisonTolerance()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new[]
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive
            };

            Assert.False(kevin.ApproximatelyEquals(kevyn, (FuzzyStringComparisonTolerance)999, options));
        }

        [Theory]
        [InlineData(FuzzyStringComparisonOptions.UseHammingDistance              , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseHammingDistance              , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseHammingDistance              , FuzzyStringComparisonTolerance.Strong, true )]

        [InlineData(FuzzyStringComparisonOptions.UseJaccardDistance              , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseJaccardDistance              , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseJaccardDistance              , FuzzyStringComparisonTolerance.Strong, false)]

        [InlineData(FuzzyStringComparisonOptions.UseJaroDistance                 , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseJaroDistance                 , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseJaroDistance                 , FuzzyStringComparisonTolerance.Strong, false)]

        [InlineData(FuzzyStringComparisonOptions.UseJaroWinklerDistance          , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseJaroWinklerDistance          , FuzzyStringComparisonTolerance.Normal, false)]
        [InlineData(FuzzyStringComparisonOptions.UseJaroWinklerDistance          , FuzzyStringComparisonTolerance.Strong, false)]

        [InlineData(FuzzyStringComparisonOptions.UseLevenshteinDistance          , FuzzyStringComparisonTolerance.Weak  , false)]
        [InlineData(FuzzyStringComparisonOptions.UseLevenshteinDistance          , FuzzyStringComparisonTolerance.Normal, false)]
        [InlineData(FuzzyStringComparisonOptions.UseLevenshteinDistance          , FuzzyStringComparisonTolerance.Strong, false)]

        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubsequence     , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubsequence     , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubsequence     , FuzzyStringComparisonTolerance.Strong, true )]

        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubstring       , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubstring       , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseLongestCommonSubstring       , FuzzyStringComparisonTolerance.Strong, false)]

        [InlineData(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance, FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance, FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance, FuzzyStringComparisonTolerance.Strong, true )]

        [InlineData(FuzzyStringComparisonOptions.UseOverlapCoefficient           , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseOverlapCoefficient           , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseOverlapCoefficient           , FuzzyStringComparisonTolerance.Strong, true )]

        [InlineData(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity  , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity  , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity  , FuzzyStringComparisonTolerance.Strong, true )]

        [InlineData(FuzzyStringComparisonOptions.UseSorensenDiceDistance         , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseSorensenDiceDistance         , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseSorensenDiceDistance         , FuzzyStringComparisonTolerance.Strong, true )]

        [InlineData(FuzzyStringComparisonOptions.UseTanimotoCoefficient          , FuzzyStringComparisonTolerance.Weak  , true )]
        [InlineData(FuzzyStringComparisonOptions.UseTanimotoCoefficient          , FuzzyStringComparisonTolerance.Normal, true )]
        [InlineData(FuzzyStringComparisonOptions.UseTanimotoCoefficient          , FuzzyStringComparisonTolerance.Strong, false)]
        public void WhenSimilarString_ShouldReturnExpectedValue(FuzzyStringComparisonOptions fuzzyStringComparisonOption, FuzzyStringComparisonTolerance fuzzyStringComparisonTolerance, bool expectedValue)
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new[]
            {
                fuzzyStringComparisonOption,
            };

            var result = kevin.ApproximatelyEquals(kevyn, fuzzyStringComparisonTolerance, options);
            Assert.Equal(expectedValue, result);
        }
    }
}
