using System.Linq;
using System.Numerics;

namespace ProjectEulerCS {
  class Problem15 {
    // Starting in the top left corner in a 20 by 20 grid, how many routes are there
    // to the bottom right corner?


    // From http://theburningmonk.com/2010/09/project-euler-problem-15-solution/:

    private static BigInteger product(BigInteger x, BigInteger y) {
      return x*y;
    }

    private static BigInteger factorial(BigInteger n) {
      return Ancillary.naturalsB(1,n).Aggregate(product);
    }

    private static BigInteger combo(BigInteger n, BigInteger k) {
      return factorial(n) / (factorial(k) * factorial(n - k));
    }

    private static BigInteger getAnswer() {
      return combo(40, 20); // 137846528820.
    }

    public static BigInteger Answer {
      get { return getAnswer(); }
    }
  }
}
