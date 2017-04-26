using System;
using System.Linq;

namespace ProjectEulerCS {
  class Problem10 {
    // Calculate the sum of all the primes below two million.
    // The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    // 
    // Find the sum of all the primes below two million.

    // From http://fsharp-euler.wikispaces.com/euler+010:

    private static bool isPrime(int n) {
      if (n<=1)
        return false;
      else {
        int m = (int)Math.Sqrt((double)n);
        var ns = Enumerable.Range(2, m);

        return ns.Where(d => n%d==0).Count() == 0;
      }
    }

    private static long getAnswer() {
      var ns = Enumerable.Range(1, 2000000);

      var ps = ns.Where(isPrime).Select(n => (long)n);

      return ps.Sum(); // 142913828920.
    }
    // Takes a long time to run.
    // C# returns 142913828920. VB returns 142913828917. F# returns 142913828922.
    // F# runs faster, though it's still kind of slow.
    // I looked at generating prime numbers on the internet, and I couldn't find
    // anything simple enough for my tastes.

    public static long Answer {
      get { return getAnswer(); }
    }
  }
}
