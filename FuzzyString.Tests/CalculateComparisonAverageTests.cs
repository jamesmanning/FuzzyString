using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuzzyString.Tests
{
    [TestClass]
    public class CalculateComparisonAverageTests
    {
        [TestMethod]
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

            Assert.AreEqual(0.23333333333333334, kevin.CalculateComparisonAverage(kevyn, options));
        }

        [TestMethod]
        public void WhenSimilarString_UseJaroDistance_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaroDistance,
            };

            Assert.AreEqual(0.33333333333333331, kevin.CalculateComparisonAverage(kevyn, options));
        }

        [TestMethod]
        public void WhenSimilarString_UseJaroWinklerDistance_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseJaroWinklerDistance,
            };

            Assert.AreEqual(0.53333333333333333, kevin.CalculateComparisonAverage(kevyn, options));
        }

        [TestMethod]
        public void WhenSimilarString_UseLevenshteinDistance_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseLevenshteinDistance,
            };

            Assert.AreEqual(1.0, kevin.CalculateComparisonAverage(kevyn, options));
        }

        [TestMethod]
        public void WhenSimilarString_UseLongestCommonSubstring_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseLongestCommonSubstring,
            };

            Assert.AreEqual(0.4, kevin.CalculateComparisonAverage(kevyn, options));
        }

        [TestMethod]
        public void WhenSimilarString_UseSorensenDiceDistance_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseSorensenDiceDistance,
            };

            Assert.AreEqual(0.19999999999999996, kevin.CalculateComparisonAverage(kevyn, options));
        }

        [TestMethod]
        public void WhenSimilarString_UseRatcliffObershelpSimilarity_ShouldReturnExpectedValue()
        {
            const string kevin = "kevin";
            const string kevyn = "kevyn";

            var options = new List<FuzzyStringComparisonOptions>
            {
                FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity,
            };

            Assert.AreEqual(0.19999999999999996, kevin.CalculateComparisonAverage(kevyn, options));
        }
    }
}
