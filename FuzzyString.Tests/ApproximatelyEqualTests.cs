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
                FuzzyStringComparisonOptions.CaseSensitive
            };

            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Weak));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Normal));
            Assert.IsTrue(kevin.ApproximatelyEquals(kevyn, options, FuzzyStringComparisonTolerance.Strong));
        }
    }
}
