using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyString
{
    public static partial class ComparisonMetrics
    {
        public static bool ApproximatelyEquals(this string source, string target, FuzzyStringComparisonTolerance tolerance, params FuzzyStringComparisonOptions[] options)
        {
            var comparisonAverage = CalculateComparisonAverage(source, target, options);

            switch (tolerance)
            {
                case FuzzyStringComparisonTolerance.Strong:
                    return comparisonAverage < 0.25;
                case FuzzyStringComparisonTolerance.Normal:
                    return comparisonAverage < 0.5;
                case FuzzyStringComparisonTolerance.Weak:
                    return comparisonAverage < 0.75;
                case FuzzyStringComparisonTolerance.Manual:
                    return comparisonAverage > 0.6;
                default:
                    return false;
            }
        }
    }
}
