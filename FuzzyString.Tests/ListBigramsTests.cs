using System;

using System.Collections.Generic;
using Xunit;

namespace FuzzyString.Tests
{

    public class ListBigramsTests
    {
        [Fact]
        public void WhenSourceIsEmptyString_ReturnsEmptyList()
        {
            var result = "".ListBigrams();
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void WhenSourceIsOneCharacter_ReturnsEmptyList()
        {
            var result = "1".ListBigrams();
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void WhenSourceIsTwoCharacters_ReturnsSource()
        {
            var result = "12".ListBigrams();
            Assert.Equal(new[] { "12" }, result);
        }

        [Fact]
        public void WhenSourceIsThreeCharacters_ReturnsTwoGrams()
        {
            var result = "123".ListBigrams();
            Assert.Equal(new[] { "12", "23" }, result);
        }

        [Fact]
        public void WhenSourceIsFourCharacters_ReturnsThreeGrams()
        {
            var result = "1234".ListBigrams();
            Assert.Equal(new[] { "12", "23", "34" }, result);
        }
    }
}
