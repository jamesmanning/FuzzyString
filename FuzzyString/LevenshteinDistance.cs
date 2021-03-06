﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    { 
        public static int LevenshteinDistance(this string source, string target)
        {
            if (source.Length == 0)
            {
                return target.Length;
            }
            if (target.Length == 0)
            {
                return source.Length;
            }

            int distance;

            if (source[source.Length - 1] == target[target.Length - 1])
            {
                distance = 0;
            }
            else
            {
                distance = 1;
            }

            var sourceWithLastCharacterRemoved = source.Substring(0, source.Length - 1);
            var targetWithLastCharacterRemoved = target.Substring(0, target.Length - 1);
            return Math.Min(Math.Min(LevenshteinDistance(sourceWithLastCharacterRemoved, target) + 1,
                                     LevenshteinDistance(source, targetWithLastCharacterRemoved)) + 1,
                                     LevenshteinDistance(sourceWithLastCharacterRemoved, targetWithLastCharacterRemoved) + distance);
        }

        public static double NormalizedLevenshteinDistance(this string source, string target)
        {
            int unnormalizedLevenshteinDistance = source.LevenshteinDistance(target);

            return unnormalizedLevenshteinDistance - source.LevenshteinDistanceLowerBounds(target);
        }

        public static int LevenshteinDistanceUpperBounds(this string source, string target)
        {
            // If the two strings are the same length then the Hamming Distance is the upper bounds of the Levenshtein Distance.
            if (source.Length == target.Length)
            {
                return source.HammingDistance(target);
            }

            // Otherwise, the upper bound is the length of the longer string.
            return Math.Max(source.Length, target.Length);
        }

        public static int LevenshteinDistanceLowerBounds(this string source, string target)
        {
            // the lower bounds is the difference in length.
            return Math.Abs(source.Length - target.Length);
        }
    }
}
