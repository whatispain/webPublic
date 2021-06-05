using System;
using System.Collections.Generic;
using System.Linq;

namespace web5laba
{
    public static class MagicWords
    {
        public static IEnumerable<String> GetUniq(this List<string> defWords)
        {
            var uniqWord = defWords.Distinct();
            var filtered = uniqWord.Skip(1);
            return filtered;
        }
    }
}
