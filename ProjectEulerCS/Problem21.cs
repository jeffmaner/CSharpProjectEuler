using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem21 {
    // Evaluate the sum of all amicable pairs under 10000.
    //
    // Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    // If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    //
    // For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    //
    // Evaluate the sum of all the amicable numbers under 10000.


    // I can barely wrap my head around this problem, so I'm going straight to my sources...

    // From http://theburningmonk.com/2010/09/project-euler-problem-21-solution/:

    private static List<int> findDivisors(int n) {
      int upperBound = (int)Math.Sqrt((double)n);

      // ns is the range of Naturals from 1 to upper bound.
      var ns = Enumerable.Range(1, upperBound);

      // ms is ns where x is a divisor of n.
      var ms = ns.Where(x => n%x==0);

      // xs is the list of factors of n.
      var xs = ms.SelectMany(x => new List<int>(new List<int>() {x, n/x}));

      // ys is the list of factors of n except for n itself.
      var ys = xs.Where(x => x != n);

      return ys.ToList();
    }

    private static int d(int n) {
      return findDivisors(n).Sum();
    }

    private static int getAnswer() {
      List<Tuple<int, int>> dList = new List<Tuple<int, int>>();
      
      for(int n = 1; n<10000; n++) {
        dList.Add(new Tuple<int, int> (n, d(n)));
      }

      // This is much more elegant in F#...
      var ns = dList.Where(a => dList.Exists(b => b.Item1 == a.Item2 && a.Item1 == b.Item2 && a.Item1 != b.Item1));
      var ms = ns.Select(t => t.Item1);

      return ms.Sum(); // 31626.
    }

    // http://www.mathblog.dk/project-euler-21-sum-of-amicable-pairs/ has a pretty cool solution,
    // if you're looking for an iterative approach that is also not brute force.

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
