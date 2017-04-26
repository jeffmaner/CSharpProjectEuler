using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem07 {
    // Find the 10001st prime.
    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    //
    // What is the 10 001st prime number?

    // Again, I find the functional approach to solving the problem far more
    // palatable than the iterative approach.

    // From http://theburningmonk.com/2010/09/project-euler-problem-7-solution/:

    private static List<int> factors(int n) {
      int m = (int)Math.Sqrt((double)n);

      var ns = Enumerable.Range(2, m);

      return ns.Where(d => n%d==0).ToList();
    }

    private static bool isPrime(int n) {
      return factors(n).Count == 0;
    }

    private static int getAnswer() {
      bool found = false; // Whether the 10,000th prime has been found.
      int c = 0;          // Counter.
      int n = 1;          // Natural number.

      while (!found) {
        if (isPrime(n)) {
          c++;
          found = c==10001;
        }

        n++;
      }

      return n-1; // 104743.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
