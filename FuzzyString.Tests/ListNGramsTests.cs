using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuzzyString.Tests
{
    [TestClass]
    public class ListNGramsTests
    {
        [TestMethod]
        public void WhenNIsLargerThanLength_ShouldReturnEmptyList()
        {
            var result = "123456".ListNGrams(7);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenNIsEqualToLength_ShouldReturnSourceString()
        {
            var result = "123456".ListNGrams(6);
            CollectionAssert.AreEqual(new[] { "123456" }, result);
        }

        [TestMethod]
        public void WhenNIsOneLessThanLength_ShouldReturnTwoGrams()
        {
            var result = "123456".ListNGrams(5);
            CollectionAssert.AreEqual(new[] { "12345", "23456" }, result);
        }

        [TestMethod]
        public void WhenNIsTwoLessThanLength_ShouldReturnThreeGrams()
        {
            var result = "123456".ListNGrams(4);
            CollectionAssert.AreEqual(new[] { "1234", "2345", "3456" }, result);
        }
    }
}
