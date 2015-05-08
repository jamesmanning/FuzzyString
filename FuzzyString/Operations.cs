using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class Operations
    {
        public static string Capitalize(this string source)
        {
            return source.ToUpper();
        }

        public static string[] SplitIntoIndividualElements(string source)
        {
            string[] stringCollection = new string[source.Length];

            for (int i = 0; i < stringCollection.Length; i++)
            {
                stringCollection[i] = source[i].ToString();
            }

            return stringCollection;
        }

        public static string MergeIndividualElementsIntoString(IEnumerable<string> source)
        {
            return String.Join("", source);
        }

        public static List<string> ListPrefixes(this string source)
        {
            return source.Select((t, i) => source.Substring(0, i)).ToList();
        }

        public static List<string> ListBigrams(this string source)
        {
            return ListNGrams(source, 2);
        }

        public static List<string> ListTriGrams(this string source)
        {
            return ListNGrams(source, 3);
        }

        public static List<string> ListNGrams(this string source, int n)
        {
            if (n > source.Length)
            {
                return new List<string>();
            }
            
            if (n == source.Length)
            {
                return new List<string> {source};
            }

            var ngrams = new List<string>();
            for (int i = 0; i < source.Length - n + 1; i++)
            {
                ngrams.Add(source.Substring(i, n));
            }

            return ngrams;
        }
    }
}
