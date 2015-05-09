using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static double CalculateComparisonAverage(this string source, string target, List<FuzzyStringComparisonOptions> options)
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
                comparisonResults.Add(Convert.ToDouble(source.HammingDistance(target)) / Convert.ToDouble(target.Length));
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
                comparisonResults.Add(1 -
                                      Convert.ToDouble((source.LongestCommonSubsequence(target).Length)/
                                                       Convert.ToDouble(Math.Min(source.Length, target.Length))));
            }

            if (options.Contains(FuzzyStringComparisonOptions.UseLongestCommonSubstring))
            {
                comparisonResults.Add(1 -
                                      Convert.ToDouble((source.LongestCommonSubstring(target).Length)/
                                                       Convert.ToDouble(Math.Min(source.Length, target.Length))));
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

            return comparisonResults.Average();
        }
    }
}
