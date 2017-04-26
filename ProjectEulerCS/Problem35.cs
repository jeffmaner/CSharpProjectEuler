using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem35 {
    // How many circular primes are there below one million?
    //
    // The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
    //
    // There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
    //
    // How many circular primes are there below one million?

    private static List<int> ESieve(int limit) {
      List<int> ps = new List<int>();

      ps.Add(2); // First prime.

      HashSet<int> knownComposits = new HashSet<int>();
      for (int i = 3; i<limit; i+=2) { // Loop through all odd numbers--evens can't be primes.
        if (!knownComposits.Contains(i))
          ps.Add(i); // If it's not in our list, then it's a prime.

        // Add all multiples of i to our sieve, starting at i and incrementing by i.
        for (int j = i; j<limit; j+=i)
          knownComposits.Add(j);
      }

      return ps;
    }

    private static SortedSet<int> primes = new SortedSet<int>(ESieve(1000000));

    private static bool isPrime(int n) {
      return primes.Contains(n);
    }

    // The following is based on http://fsharp-euler.wikispaces.com/euler+035:

    // For use by isCircular().
    private static bool isc(int x, int i, int n) {
      if (isPrime(x))
        if (i==n)
          return true;
        else
          return isc(Int32.Parse((x%10).ToString() + (x/10).ToString()), i+1, n);
      else
        return false;
    }

    private static bool isCircular(int x) {
      return isc(x, 1, x.ToString().Length);
    }

    private static int getAnswer() {
      return Enumerable.Range(1, 1000000).Where(isCircular).Count(); // 55.
    }


    // Based on http://www.mathblog.dk/project-euler-35-circular-primes/:

    private static int CheckCircularPrimes(int prime) {
      int multiplier = 1;
      int number = prime;
      int count = 0;
      int d;

      // Count the digits and check for even numbers.
      while (number>0) {
        d = number % 10;
        if (d%2 == 0 || d==5) { // I like this checking for even digits and five--pretty clever.
          primes.Remove(prime);
          return 0;
        }
        number /= 10;
        multiplier *= 10;
        count++;
      }
      multiplier /= 10;

      // Rotate the number and check if each result is prime.
      number = prime;
      List<int> foundCircularPrimes = new List<int>();

      for (int i=0; i<count; i++) {
        if (primes.Contains(number)) {
          foundCircularPrimes.Add(number);
          primes.Remove(number);
        }
        else if (!foundCircularPrimes.Contains(number)) {
          return 0;
        }

        d = number % 10;
        number = d * multiplier + number / 10;
      }

      return foundCircularPrimes.Count;
    }

    private static int getAnswer1() {
      int noCircularPrimes = 2;

      // Special cases:
      primes.Remove(2);
      primes.Remove(5);

      while (primes.Count>0)
        noCircularPrimes += CheckCircularPrimes(primes.Min);

      return noCircularPrimes; // 55.
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
