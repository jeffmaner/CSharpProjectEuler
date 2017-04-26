using System;
using System.Linq;
using System.Numerics;

namespace ProjectEulerCS {
  class Problem20 {
    // Find the sum of digits in 100!
    //
    // n! means n × (n − 1) × ... × 3 × 2 × 1
    //
    // For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    // and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    //
    // Find the sum of the digits in the number 100!

    private static BigInteger product(BigInteger x, BigInteger y) {
      return x*y;
    }

    private static BigInteger factorial(BigInteger n) {
      return Ancillary.naturalsB(1, n).Aggregate(product);
    }

    private static int getAnswer() {
      BigInteger n = factorial(100);
      var ds = n.ToString().ToCharArray().Select(c => Int32.Parse(c.ToString()));

      return ds.Sum(); // 648.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
