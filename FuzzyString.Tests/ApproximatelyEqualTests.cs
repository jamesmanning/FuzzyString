using System;

using System.Collections.Generic;
using Xunit;

namespace FuzzyString.Tests
{

    public class ApproximatelyEqualTests
    {
        [Fact]
        public void WhenSimilarString_ShouldReturnTrueForWeakAndNormalAndStrong()
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

            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnFalseForManual()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive
            };

            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Manual));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnFalseForInvalidFuzzyStringComparisonTolerance()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaccardDistance,
                FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance,
                FuzzyStringComparisonOptions.UseOverlapCoefficient,
                FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
                FuzzyStringComparisonOptions.CaseSensitive
            };

            Assert.False(kevin.ApproximatelyEquals(kevyn, options, (FuzzyStringComparisonTolerance)999));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnTrueForJaroDistanceAndWeakAndNormal_FalseForStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaroDistance,
            };

            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnTrueForJaroWinklerDistanceAndWeak_FalseForNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaroWinklerDistance,
            };

            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnFalseForLevenshteinDistanceAndWeakAndNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseLevenshteinDistance,
            };

            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnTrueForLongestCommonSubstringAndAndWeakAndNormal_FalseForStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseLongestCommonSubstring,
            };

            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.False(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnTrueForSorensenDiceDistanceAndWeakAndNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseSorensenDiceDistance,
            };

            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [Fact]
        public void WhenSimilarString_ShouldReturnTrueForRatcliffObershelpSimilarityAndWeakAndNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity,
            };

            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.True(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }
    }
}
