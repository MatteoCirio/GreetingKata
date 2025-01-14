using System;
using Xunit;
using GreetingKata;

namespace GreetingKataTests
{
    public class GreetingTests
    {
        [Fact]
        public void Greet_WithNullOrEmptyNames_ReturnsDefaultGreeting()
        {
            var result = Greeting.Greet(null);
            Assert.Equal("Hello, my friend.", result);

            var result2 = Greeting.Greet(new string[] { });
            Assert.Equal("Hello, my friend.", result2);
        }

        [Fact]
        public void Greet_WithOneNormalName_ReturnsSingleNameGreeting()
        {
            var result = Greeting.Greet(new string[] { "John" });
            Assert.Equal("Hello John", result);
        }

        [Fact]
        public void Greet_WithTwoNormalNames_ReturnsTwoNamesGreeting()
        {
            var result = Greeting.Greet(new string[] { "John", "Jane" });
            Assert.Equal("Hello John and Jane", result);
        }

        [Fact]
        public void Greet_WithMoreThanTwoNormalNames_ReturnsCommaSeparatedGreeting()
        {
            var result = Greeting.Greet(new string[] { "John", "Jane", "Mary" });
            Assert.Equal("Hello John, Jane and Mary", result);
        }

        [Fact]
        public void Greet_WithShoutedName_ReturnsShoutedGreeting()
        {
            var result = Greeting.Greet(new string[] { "John", "JANE" });
            Assert.Equal("Hello John and HELLO JANE!", result);
        }

        [Fact]
        public void Greet_WithMultipleShoutedNames_ReturnsShoutedGreeting()
        {
            var result = Greeting.Greet(new string[] { "John", "JANE", "MARY" });
            Assert.Equal("Hello John and HELLO JANE AND MARY!", result);
        }

        [Fact]
        public void Greet_WithMixedNormalAndShoutedNames_ReturnsCombinedGreeting()
        {
            var result = Greeting.Greet(new string[] { "John", "JANE", "Mary" });
            Assert.Equal("Hello John and Mary and HELLO JANE!", result);
        }

        [Fact]
        public void Greet_WithNamesContainingCommas_ReturnsCorrectGreeting()
        {
            var result = Greeting.Greet(new string[] { "John", "JANE, MARY" });
            Assert.Equal("Hello John and HELLO JANE AND MARY!", result);
        }

        [Fact]
        public void TestGreet_WithCommaAndQuotes()
        {
            var result = Greeting.Greet(new string[] { "\"John\", \"Jane\"", "Alice", "BOB" });
            Assert.Equal("Hello John, Jane and Alice and HELLO BOB!", result);
        }
    }
}
