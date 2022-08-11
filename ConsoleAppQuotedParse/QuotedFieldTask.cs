using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleAppQuotedParse
{
    public class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            string pattern = "(\'|\")([^\"]*)(\'|\")";
            string pattern1 = "([\\\"]).*([\\\"])";
            Regex regex = new Regex(pattern1);
            MatchCollection collection = regex.Matches(line);
            string str = collection.ToString();
            /*StringBuilder str = new StringBuilder();
            char[] charsToTrim = { '\'', '\"', '\\' };
            string test = line.Substring(startIndex);
            string withoutScopes = test.Trim(charsToTrim).Replace("\\", string.Empty);*/
            return new Token(line, startIndex, line.Length - startIndex);
        }
    }
}
