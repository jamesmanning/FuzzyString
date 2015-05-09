using System;

using System.Collections.Generic;
using Xunit;

namespace FuzzyString.Tests
{

    public class ListNGramsTests
    {
        [Fact]
        public void WhenNIsLargerThanLength_ShouldReturnEmptyList()
        {
            var result = "123456".ListNGrams(7);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void WhenNIsEqualToLength_ShouldReturnSourceString()
        {
            var result = "123456".ListNGrams(6);
            Assert.Equal(new[] { "123456" }, result);
        }

        [Fact]
        public void WhenNIsOneLessThanLength_ShouldReturnTwoGrams()
        {
            var result = "123456".ListNGrams(5);
            Assert.Equal(new[] { "12345", "23456" }, result);
        }

        [Fact]
        public void WhenNIsTwoLessThanLength_ShouldReturnThreeGrams()
        {
            var result = "123456".ListNGrams(4);
            Assert.Equal(new[] { "1234", "2345", "3456" }, result);
        }
    }
}
