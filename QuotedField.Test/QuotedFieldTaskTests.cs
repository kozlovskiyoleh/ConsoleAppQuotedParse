using NUnit.Framework;
using ConsoleAppQuotedParse;
namespace QuotedField.Test
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)] //success
        [TestCase("'a'", 0, "a", 3)]//success
        [TestCase("\"abc\"", 0, "abc", 5)]//success
        [TestCase("b \"a'\"", 2, "a'", 4)]//not success
        [TestCase("'", 0, "", 1)]//success
        [TestCase("\"", 0, "", 1)]//success
        [TestCase(@"'a\' b\'", 0, "a' b'", 8)]//success
        [TestCase(@"'a\' b'xx", 0, "a' b", 7)]//succes
        [TestCase(@"'\'\''xx", 0, "''", 6)]//success
        [TestCase("'a\"\"'", 0, "a\"\"", 5)]//not success
        [TestCase("\"abc\"asas", 0, "abc", 5)]//succes
        [TestCase("sx\"a'\"", 2, "a'", 4)]//success
        [TestCase("'a' b'", 0, "a", 3)]//success
        [TestCase("'a", 0, "a", 2)]//not success
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }
}