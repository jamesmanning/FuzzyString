using System;
using Xunit;


namespace FuzzyString.Tests
{

    public class MergeIndividualElementsIntoStringTests
    {
        [Fact]
        public void WhenEmptySource_ShouldReturnEmptyString()
        {
            var result = Operations.MergeIndividualElementsIntoString(new string[0]);
            Assert.Equal("", result);
        }

        [Fact]
        public void WhenOneItemInSource_ShouldReturnOriginalItem()
        {
            var result = Operations.MergeIndividualElementsIntoString(new [] { "foo" });
            Assert.Equal("foo", result);
        }

        [Fact]
        public void WhenFiveItemsInSource_ShouldReturnConcatenatedVersion()
        {
            var result = Operations.MergeIndividualElementsIntoString(new[] { "foo", "bar", "baz", "123", "456" });
            Assert.Equal("foobarbaz123456", result);
        }
    }
}
