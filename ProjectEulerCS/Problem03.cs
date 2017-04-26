using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem03 {
    // Problem 3:
    // Find the largest prime factor of a composite number.
    //
    // The prime factors of 13195 are 5, 7, 13 and 29.
    //
    // What is the largest prime factor of the number 600851475143?

    // From http://www.mathblog.dk/project-euler-problem-3/:
    private static long getAnswer() {
      const long numm = 600851475143;
      long newnumm = numm;
      long largestFact = 0;
      int counter = 2;

      while (counter * counter < newnumm) {
        if (newnumm % counter == 0) {
          newnumm = newnumm / counter;
          largestFact = counter;
        }
        else {
          counter++;
        }
      }

      if (newnumm > largestFact) { // the remainder is a prime number
        largestFact = newnumm;
      }

      return largestFact;
    }
    // I am so totally over imperative programming. This is *so* ugly and incomprehensible!

    // My translation of the burning monk's f# solution.


    /// <summary>
    /// Generates a sequence of integral numbers within the range specified.
    /// </summary>
    public static IEnumerable<long> i(long first, long last) {
      for (long n=first; n<=last; n++)
        yield return n;
    }

    /// <summary>
    /// Does d evenly divide n?
    /// </summary>
    private static bool divides(long n, long d) {
      return (n%d)==0L;
    }

    private static long bound(long n) {
      return (long)Math.Sqrt((double)n);
    }

    /// <summary>
    /// Generates the factors of n.
    /// </summary>
    private static IEnumerable<long> factors(long n) {
      long m = bound(n); // m is upper bound of search space.
      return i(2L, m).Where(x => divides(n, x));
    }

    /// <summary>
    /// Indicates whether n is prime.
    /// </summary>
    private static bool prime(long n) {
      return factors(n).Count() == 0;
    }

    /// <summary>
    /// Returns the maximum prime factor of n.
    /// </summary>
    private static long mpf(long n) {
      long m = bound(n); // m is upper bound of search space.
      return i(2L,m).Where(x => divides(n, x)).Where(prime).Max();
    }

    private static long getAnswer1() {
      return mpf(600851475143L); // 6857.
    }

    public static long Answer {
      get { return getAnswer1(); }
    }
  }
}
