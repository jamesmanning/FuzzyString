using System;

using Xunit;

namespace FuzzyString.Tests
{

    public class SplitIntoIndividualElementsTests
    {
        [Fact]
        public void WhenSourceIsEmpty_ShouldReturnEmptyArray()
        {
            var result = Operations.SplitIntoIndividualElements("");
            Assert.Equal(0, result.Length);
        }

        [Fact]
        public void WhenSourceIsOneCharacter_ShouldReturnArrayWithOneString()
        {
            var result = Operations.SplitIntoIndividualElements("1");
            Assert.Equal(new[] { "1" }, result);
        }

        [Fact]
        public void WhenSourceIsFiveCharacters_ShouldReturnArrayWithFiveStrings()
        {
            var result = Operations.SplitIntoIndividualElements("12345");
            Assert.Equal(new[] { "1", "2", "3", "4", "5" }, result);
        }
    }
}
