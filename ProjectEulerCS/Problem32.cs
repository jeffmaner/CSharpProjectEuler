using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem32 {
    // Find the sum of all numbers that can be written as pandigital products.
    //
    // We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n
    // exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    //
    // The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand,
    // multiplier, and product is 1 through 9 pandigital.
    //
    // Find the sum of all products whose multiplicand/multiplier/product identity can be written
    // as a 1 through 9 pandigital.
    // HINT: Some products can be obtained in more than one way so be sure to only include it once
    // in your sum.


    // From http://www.mathblog.dk/project-euler-32-pandigital-products/.

    private static bool isPandigitalI(long n) {
      int digits = 0;
      int count = 0;
      int tmp;

      while (n>0) {
        tmp = digits;
        digits = digits | 1 << (int)((n%10) - 1);
        if (tmp == digits)
          return false;

        count++;
        n /= 10;
      }
      return digits == (1 << count) - 1;
    }

    private static long concat(long a, long b) {
      long c = b;
      while (c>0) {
        a *= 10;
        c /= 10;
      }
      return a+b;
    }

    private static long getAnswer() {
      List<long> products = new List<long>();
      long sum = 0;
      long prod, compiled;

      for (long m=2; m<100; m++) {
        long nbegin = (m>9) ? 123 : 1234;
        long nend = 10000 / m + 1;

        for (long n=nbegin; n<nend; n++) {
          prod = m*n;
          compiled = concat(concat(prod, n), m);
          if (compiled >= 1E8 &&
              compiled <  1E9 &&
              isPandigitalI(compiled))
            if (!products.Contains(prod))
              products.Add(prod);
        }
      }

      for (int i=0; i<products.Count; i++)
        sum += products[i];

      return sum; // 45228.
    }


    // I like the solution at http://theburningmonk.com/2010/09/project-euler-problem-32-solution/.
    // I don't follow his discussion of the limits from 1000 to 9999, but he gives a justification.

    private static bool isPandigitalF(int n) {
      int upperBound = (int)Math.Sqrt((double)n);

      return Enumerable.Range(2, upperBound-1)
        .Where(x => n%x==0)
        .Select(x => x.ToString() + (n/x).ToString() + n.ToString())
        .Any(s => Enumerable.Range(1, 9)
          .Select(x => x.ToString())
          .All(x => s.Contains(x) && s.IndexOf(x) == s.LastIndexOf(x)));
    }

    private static int getAnswer1() {
      return Enumerable.Range(1000, 8999).Where(isPandigitalF).Sum(); // 45228.
    }

    public static long Answer {
      get { return getAnswer1(); }
    }
  }
}
