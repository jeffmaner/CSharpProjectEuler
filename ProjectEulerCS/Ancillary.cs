using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEulerCS {
  public static class Ancillary {
    public static List<long> naturalsL(long start, long end) {
      List<long> ns = new List<long>();

      for (long n=start; n<=end; n++)
        ns.Add(n);

      return ns;
    }

    public static List<BigInteger> naturalsB(BigInteger start, BigInteger end) {
      List<BigInteger> ns = new List<BigInteger>();

      for (BigInteger n=start; n<=end; n++)
        ns.Add(n);

      return ns;
    }

    // I like an extension method defined at http://blog.functionalfun.net/2008/04/project-euler-problem-4.html.
    public static IEnumerable To(this int first, int last) {
      return Enumerable.Range(first, last-first);
    }
    // Hmph. This doesn't work like I need it to.

    // This would be handy for data types bigger than int.
    public static IEnumerable To(this long first, long last) {
      for (long n=first; n<=last; n++)
        yield return n;
    }
    // Hmph. This doesn't work like I need it to.

    /// <summary>
    /// Use the Sieve of Eratosthenes to generate primes up to upperLimit.
    /// </summary>
    /// <remarks>Source: http://www.mathblog.dk/sum-of-all-primes-below-2000000-problem-10/. </remarks>
    public static int[] ESieve(int upperLimit) {
      int sieveBound = (int)(upperLimit - 1) / 2;
      int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

      BitArray primeBits = new BitArray(sieveBound + 1, true);

      for (int i = 1; i<=upperSqrt; i++)
        if (primeBits.Get(i))
          for (int j = i * 2 * (i+1); j<=sieveBound; j += 2 * i + 1)
            primeBits.Set(j, false);

      List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
      numbers.Add(2);

      for (int i=1; i<=sieveBound; i++)
        if (primeBits.Get(i))
          numbers.Add(2 * i + 1);

      return numbers.ToArray();
    }
  }
}
