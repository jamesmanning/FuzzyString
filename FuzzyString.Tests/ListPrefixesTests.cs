using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuzzyString.Tests
{
    [TestClass]
    public class ListPrefixesTests
    {
        [TestMethod]
        public void WhenSourceIsEmptyString_ShouldReturnEmptyList()
        {
            var result = "".ListPrefixes();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenSourceIsOneCharacter_ShouldReturnOneEntry()
        {
            var result = "1".ListPrefixes();
            CollectionAssert.AreEqual(new[] { "1" }, result);
        }

        [TestMethod]
        public void WhenSourceIsTwoCharacters_ShouldReturnTwoEntries()
        {
            var result = "12".ListPrefixes();
            CollectionAssert.AreEqual(new[] { "1", "12" }, result);
        }

        [TestMethod]
        public void WhenSourceIsSixCharacters_ShouldReturnSixEntries()
        {
            var result = "123456".ListPrefixes();
            CollectionAssert.AreEqual(new[] { "1", "12", "123", "1234", "12345", "123456" }, result);
        }
    }
}
