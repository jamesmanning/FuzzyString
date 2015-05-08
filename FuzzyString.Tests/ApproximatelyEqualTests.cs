using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuzzyString.Tests
{
    [TestClass]
    public class ApproximatelyEqualTests
    {
        [TestMethod]
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

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [TestMethod]
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

            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Manual));
        }

        [TestMethod]
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

            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, (FuzzyStringComparisonTolerance)999));
        }

        [TestMethod]
        public void WhenSimilarString_ShouldReturnTrueForJaroDistanceAndWeakAndNormal_FalseForStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaroDistance,
            };

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [TestMethod]
        public void WhenSimilarString_ShouldReturnTrueForJaroWinklerDistanceAndWeak_FalseForNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaroWinklerDistance,
            };

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [TestMethod]
        public void WhenSimilarString_ShouldReturnFalseForLevenshteinDistanceAndWeakAndNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseLevenshteinDistance,
            };

            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [TestMethod]
        public void WhenSimilarString_ShouldReturnTrueForLongestCommonSubstringAndAndWeakAndNormal_FalseForStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseLongestCommonSubstring,
            };

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsFalse(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [TestMethod]
        public void WhenSimilarString_ShouldReturnTrueForSorensenDiceDistanceAndWeakAndNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseSorensenDiceDistance,
            };

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }

        [TestMethod]
        public void WhenSimilarString_ShouldReturnTrueForRatcliffObershelpSimilarityAndWeakAndNormalAndStrong()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity,
            };

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }
    }
}
