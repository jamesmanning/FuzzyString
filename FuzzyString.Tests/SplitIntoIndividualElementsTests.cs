using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzyString.Tests
{
    [TestClass]
    public class SplitIntoIndividualElementsTests
    {
        [TestMethod]
        public void WhenSourceIsEmpty_ShouldReturnEmptyArray()
        {
            var result = Operations.SplitIntoIndividualElements("");
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void WhenSourceIsOneCharacter_ShouldReturnArrayWithOneString()
        {
            var result = Operations.SplitIntoIndividualElements("1");
            CollectionAssert.AreEqual(new[] { "1" }, result);
        }

        [TestMethod]
        public void WhenSourceIsFiveCharacters_ShouldReturnArrayWithFiveStrings()
        {
            var result = Operations.SplitIntoIndividualElements("12345");
            CollectionAssert.AreEqual(new[] { "1", "2", "3", "4", "5" }, result);
        }
    }
}
