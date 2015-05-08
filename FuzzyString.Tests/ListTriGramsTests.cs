using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuzzyString.Tests
{
    [TestClass]
    public class ListTriGramsTests
    {
        [TestMethod]
        public void WhenSourceIsEmptyString_ReturnsEmptyList()
        {
            var result = "".ListTriGrams();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenSourceIsOneCharacter_ReturnsEmptyList()
        {
            var result = "1".ListTriGrams();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenSourceIsTwoCharacters_ReturnsEmptyList()
        {
            var result = "12".ListTriGrams();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenSourceIsThreeCharacters_ReturnsSource()
        {
            var result = "123".ListTriGrams();
            CollectionAssert.AreEqual(new[] { "123" }, result);
        }

        [TestMethod]
        public void WhenSourceIsFourCharacters_ReturnsTwoGrams()
        {
            var result = "1234".ListTriGrams();
            CollectionAssert.AreEqual(new[] { "123", "234" }, result);
        }
    }
}
