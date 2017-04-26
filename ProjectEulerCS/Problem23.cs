using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem23 {
    // Find the sum of all the positive integers which cannot be written as the sum of
    // two abundant numbers.
    //
    // A perfect number is a number for which the sum of its proper divisors is exactly
    // equal to the number. For example, the sum of the proper divisors of 28 would be
    // 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    //
    // A number n is called deficient if the sum of its proper divisors is less than
    // n and it is called abundant if this sum exceeds n.
    //
    // As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest
    // number that can be written as the sum of two abundant numbers is 24. By
    // mathematical analysis, it can be shown that all integers greater than 28123
    // can be written as the sum of two abundant numbers. However, this upper limit
    // cannot be reduced any further by analysis even though it is known that the
    // greatest number that cannot be expressed as the sum of two abundant numbers
    // is less than this limit.
    //
    // Find the sum of all the positive integers which cannot be written as the sum
    // of two abundant numbers.

    // Based on http://theburningmonk.com/2010/09/project-euler-problem-23-solution/.

    private const int limit = 28123;

    private static List<int> findDivisors(int n) {
      int upperBound = (int)Math.Sqrt((double)n);

      var ns = Enumerable.Range(1, limit-1);
      var fs = ns.Where(x => n%x==0);
      var gs = fs.SelectMany(x => new List<int>(new List<int> { x, n/x }));
      var hs = gs.Where(x => x!=n);

      return hs.Distinct().ToList();
    }

    private static bool isAbundant(int n) {
      return findDivisors(n).Sum() > n;
    }

    private static int getAnswer() {
      var abundants = Enumerable.Range(1, limit-1).Where(isAbundant).ToList();
      var sums = abundants.SelectMany(n => abundants.Select(m => n+m))
        .Where(n => n <= limit).Distinct().ToList();

      return Enumerable.Range(1, limit).Sum() - sums.Sum(); // 4179871.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
