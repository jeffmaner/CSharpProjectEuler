﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem12 {
    // What is the value of the first triangle number to have over five hundred
    // divisors?
    //
    // The sequence of triangle numbers is generated by adding the natural numbers.
    // So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first
    // ten terms would be:
    //
    // 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    //
    // Let us list the factors of the first seven triangle numbers:
    //
    //     1: 1
    //     3: 1,3
    //     6: 1,2,3,6
    //    10: 1,2,5,10
    //    15: 1,3,5,15
    //    21: 1,3,7,21
    //    28: 1,2,4,7,14,28
    // 
    // We can see that 28 is the first triangle number to have over five divisors.
    // 
    // What is the value of the first triangle number to have over five hundred divisors?

    private static long triangle(long n) {
      return Ancillary.naturalsL(1L, n).Sum();
    }

    private static List<long> factors(long n) {
      long m = (long)Math.Sqrt((double)n);
      var ns = Ancillary.naturalsL(1, m);
      var fs = ns.Where(d => n%d==0L);

      return fs.SelectMany(d => new List<long>(new long[] { d, n/d })).ToList();
    }

    private static long getAnswer() {
      bool found = false;
      long n = 1, t = 0;

      while (!found) {
        t = triangle(n);

        found = factors(t).Count >= 500;

        n++;
      }

      return t; // 76576500.
    }
    // Not terribly efficient.

    // Here's the "naive" answer from http://www.mathblog.dk/triangle-number-with-more-than-500-divisors/:
    private static long getAnswer1() {
      long n = 0, i = 1;

      while (numberOfDivisors(n) < 500) {
        n+=i;
        i++;
      }

      return n; // 76576500.
    }

    private static long numberOfDivisors(long n) {
      long nod = 0;
      long sqrt = (int)Math.Sqrt(n);

      for (int i=1; i<=sqrt; i++) {
        if (n%i==0)
          nod += 2;
      }
      // Correction if the number is a perfect square.
      if (sqrt*sqrt == n)
        nod--;

      return nod;
    }
    // Pretty slow, still. He goes on to improve his algorithm and speed it up.

    public static long Answer {
      get { return getAnswer(); }
    }
  }
}
