using System;

using System.Collections.Generic;
using Xunit;

namespace FuzzyString.Tests
{

    public class ListTriGramsTests
    {
        [Fact]
        public void WhenSourceIsEmptyString_ReturnsEmptyList()
        {
            var result = "".ListTriGrams();
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void WhenSourceIsOneCharacter_ReturnsEmptyList()
        {
            var result = "1".ListTriGrams();
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void WhenSourceIsTwoCharacters_ReturnsEmptyList()
        {
            var result = "12".ListTriGrams();
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void WhenSourceIsThreeCharacters_ReturnsSource()
        {
            var result = "123".ListTriGrams();
            Assert.Equal(new[] { "123" }, result);
        }

        [Fact]
        public void WhenSourceIsFourCharacters_ReturnsTwoGrams()
        {
            var result = "1234".ListTriGrams();
            Assert.Equal(new[] { "123", "234" }, result);
        }

        [Fact]
        public void WhenSourceIsFiveCharacters_ReturnsThreeGrams()
        {
            var result = "12345".ListTriGrams();
            Assert.Equal(new[] { "123", "234", "345" }, result);
        }
    }
}
