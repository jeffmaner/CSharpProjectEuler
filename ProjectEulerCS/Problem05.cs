using System.Linq;
using ProjectEulerCS;

namespace ProjectEulerCS {
  class Problem05 {
    // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    //
    // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

    // I like the solution at http://fsharp-euler.wikispaces.com/euler+005.
    // The problem asks to get the least common multiplier of 1 to 20. We use a
    // property lcm(a1, a2, ..., an) = lcm(a1, lcm(a2, ..., an) = ..., which reduces
    // the problem to solving the lcm of two numbers incrementally.

    private static long gcd(long x, long y) {
      return y==0L ? x : gcd(y, x%y);
    }

    private static long lcm(long x, long y) {
      return x*y / gcd(x, y);
    }

    private static long getAnswer() {
      return Ancillary.naturalsL(1L, 20L).Aggregate(lcm); // 232792560.
    }

    public static long Answer {
      get { return getAnswer(); }
    }
  }
}
