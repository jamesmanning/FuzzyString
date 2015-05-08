using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuzzyString.Tests
{
    [TestClass]
    public class ListBigramsTests
    {
        [TestMethod]
        public void WhenSourceIsEmptyString_ReturnsEmptyList()
        {
            var result = "".ListBigrams();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenSourceIsOneCharacter_ReturnsEmptyList()
        {
            var result = "1".ListBigrams();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenSourceIsTwoCharacters_ReturnsSource()
        {
            var result = "12".ListBigrams();
            CollectionAssert.AreEqual(new[] { "12" }, result);
        }

        [TestMethod]
        public void WhenSourceIsThreeCharacters_ReturnsTwoGrams()
        {
            var result = "123".ListBigrams();
            CollectionAssert.AreEqual(new[] { "12", "23" }, result);
        }

        [TestMethod]
        public void WhenSourceIsFourCharacters_ReturnsThreeGrams()
        {
            var result = "1234".ListBigrams();
            CollectionAssert.AreEqual(new[] { "12", "23", "34" }, result);
        }
    }
}
