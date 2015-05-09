using System;

using System.Collections.Generic;
using Xunit;

namespace FuzzyString.Tests
{

    public class ListPrefixesTests
    {
        [Fact]
        public void WhenSourceIsEmptyString_ShouldReturnEmptyList()
        {
            var result = "".ListPrefixes();
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void WhenSourceIsOneCharacter_ShouldReturnOneEntry()
        {
            var result = "1".ListPrefixes();
            Assert.Equal(new[] { "1" }, result);
        }

        [Fact]
        public void WhenSourceIsTwoCharacters_ShouldReturnTwoEntries()
        {
            var result = "12".ListPrefixes();
            Assert.Equal(new[] { "1", "12" }, result);
        }

        [Fact]
        public void WhenSourceIsSixCharacters_ShouldReturnSixEntries()
        {
            var result = "123456".ListPrefixes();
            Assert.Equal(new[] { "1", "12", "123", "1234", "12345", "123456" }, result);
        }
    }
}
