using System;
using System.Numerics;

namespace ProjectEulerCS {
  class Problem25 {
    // What is the first term in the Fibonacci sequence to contain 1000 digits?

    private static BigInteger f(BigInteger i, BigInteger m, BigInteger n) {
      BigInteger limit = BigInteger.Pow(BigInteger.Parse("10"), 999);

      if (n>limit)
        return i;
      else
        return f(i+BigInteger.One, n, (m+n));
    }

    // Interesting solution in the comments to http://theburningmonk.com/2010/09/project-euler-problem-25-solution/.
    private static int getAnswer() {
      return (int)f(BigInteger.Parse("2"), BigInteger.One, BigInteger.One); // 4782.
    }

    // Interesting solution from http://www.mathblog.dk/project-euler-25-fibonacci-sequence-1000-digits/.
    private static int getAnswer1() {
      int i = 0, c = 2;
      BigInteger limit = BigInteger.Pow(10, 999);
      BigInteger[] fib = new BigInteger[3];

      fib[0] = 1;
      fib[2] = 1;

      while (fib[i] <= limit) {
        i = (i+1) % 3;
        c++;
        fib[i] = fib[(i+1)%3] + fib[(i+2)%3];
      }

      return c; // 4782.
    }

    // Per http://www.mathblog.dk/project-euler-25-fibonacci-sequence-1000-digits/,
    // as the Fibonacci numbers become large enough, they converge to F(n) = Rnd((phi^n)/sqrt(5)).
    // (It looks much cooler in Latex). Assuming that the first Fibonacci number with 1000 digits
    // is large enough for the series to have converged, we need to find the smallest integer n
    // which fulfills the inequality (phi^n)/sqrt(5) > 10^999. Taking log on both sides and
    // isolating n gives the Return statement.
    private static int getAnswer2() {
      double phi = 1.618; // Golden Ratio.
      return (int)((Math.Log(10) * 999 + Math.Log(5) / 2) / Math.Log(phi)); // 4782.
    }

    public static int Answer {
      get { return getAnswer2(); }
    }
  }
}
