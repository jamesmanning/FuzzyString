using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzyString.Tests
{
    [TestClass]
    public class MergeIndividualElementsIntoStringTests
    {
        [TestMethod]
        public void WhenEmptySource_ShouldReturnEmptyString()
        {
            var result = Operations.MergeIndividualElementsIntoString(new string[0]);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void WhenOneItemInSource_ShouldReturnOriginalItem()
        {
            var result = Operations.MergeIndividualElementsIntoString(new [] { "foo" });
            Assert.AreEqual("foo", result);
        }

        [TestMethod]
        public void WhenFiveItemsInSource_ShouldReturnConcatenatedVersion()
        {
            var result = Operations.MergeIndividualElementsIntoString(new[] { "foo", "bar", "baz", "123", "456" });
            Assert.AreEqual("foobarbaz123456", result);
        }
    }
}
