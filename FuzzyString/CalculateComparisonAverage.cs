using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static double CalculateComparisonAverage(this string source, string target, params FuzzyStringComparisonOptions[] options)
        {
            var comparisonResults = new List<double>();

            if (!options.Contains(FuzzyStringComparisonOptions.CaseSensitive))
            {
                source = source.Capitalize();
                target = target.Capitalize();
            }

            // Min: 0    Max: source.Length = target.Length
            if (options.Contains(FuzzyStringComparisonOptions.UseHammingDistance))
            {
                var maxLength = Math.Max(source.Length, target.Length);
                comparisonResults.Add(Convert.ToDouble(source.HammingDistance(target)) / Convert.ToDouble(maxLength));
            }

            // Min: 0    Max: 1
            if (options.Contains(FuzzyStringComparisonOptions.UseJaccardDistance))
            {
                comparisonResults.Add(source.JaccardDistance(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(FuzzyStringComparisonOptions.UseJaroDistance))
            {
                comparisonResults.Add(source.JaroDistance(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(FuzzyStringComparisonOptions.UseJaroWinklerDistance))
            {
                comparisonResults.Add(source.JaroWinklerDistance(target));
            }

            // Min: 0    Max: LevenshteinDistanceUpperBounds - LevenshteinDistanceLowerBounds
            // Min: LevenshteinDistanceLowerBounds    Max: LevenshteinDistanceUpperBounds
            if (options.Contains(FuzzyStringComparisonOptions.UseNormalizedLevenshteinDistance))
            {
                comparisonResults.Add(Convert.ToDouble(source.NormalizedLevenshteinDistance(target))/
                                      Convert.ToDouble((Math.Max(source.Length, target.Length) -
                                                        source.LevenshteinDistanceLowerBounds(target))));
            }
            else if (options.Contains(FuzzyStringComparisonOptions.UseLevenshteinDistance))
            {
                var upperBound = source.LevenshteinDistanceUpperBounds(target);
                if (upperBound == 0)
                {
                    comparisonResults.Add(0);
                }
                else
                {
                    comparisonResults.Add(Convert.ToDouble(source.LevenshteinDistance(target)) /
                                          Convert.ToDouble(upperBound));
                }
            }

            if (options.Contains(FuzzyStringComparisonOptions.UseLongestCommonSubsequence))
            {
                var shorterStringLength = Math.Min(source.Length, target.Length);
                var longestSubsequenceLength = source.LongestCommonSubsequence(target).Length;
                comparisonResults.Add(1 -
                                      Convert.ToDouble(longestSubsequenceLength)/
                                                       Convert.ToDouble(shorterStringLength));
            }

            if (options.Contains(FuzzyStringComparisonOptions.UseLongestCommonSubstring))
            {
                var longestSubstringLength = source.LongestCommonSubstring(target).Length;
                var shorterStringLength = Math.Min(source.Length, target.Length);
                comparisonResults.Add(1 -
                                      Convert.ToDouble(longestSubstringLength)/
                                                       Convert.ToDouble(shorterStringLength));
            }

            // Min: 0    Max: 1
            if (options.Contains(FuzzyStringComparisonOptions.UseSorensenDiceDistance))
            {
                comparisonResults.Add(source.SorensenDiceDistance(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(FuzzyStringComparisonOptions.UseOverlapCoefficient))
            {
                comparisonResults.Add(1 - source.OverlapCoefficient(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(FuzzyStringComparisonOptions.UseRatcliffObershelpSimilarity))
            {
                comparisonResults.Add(1 - source.RatcliffObershelpSimilarity(target));
            }

            // Min: 0    Max: 1
            if (options.Contains(FuzzyStringComparisonOptions.UseTanimotoCoefficient))
            {
                comparisonResults.Add(1 - source.TanimotoCoefficient(target));
            }

            // with no tests chosen, default to saying the strings are different via a 1.0 score
            if (comparisonResults.Count == 0)
            {
                return 1.0;
            }

            return comparisonResults.Average();
        }
    }
}
