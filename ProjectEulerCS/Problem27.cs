using System;

namespace ProjectEulerCS {
  class Problem27 {
    // Find a quadratic formula that produces the maximum number of primes for consecutive values of n.
    //
    // Euler published the remarkable quadratic formula:
    //
    // n² + n + 41
    //
    // It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However,
    // when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41,
    // 41² + 41 + 41 is clearly divisible by 41.
    //
    // Using computers, the incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for
    // the consecutive values n = 0 to 79. The product of the coefficients, −79 and 1601, is −126479.
    //
    // Considering quadratics of the form:
    //
    //    n² + an + b, where |a| < 1000 and |b| < 1000
    //
    //    where |n| is the modulus/absolute value of n
    //    e.g. |11| = 11 and |−4| = 4
    //
    // Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum
    // number of primes for consecutive values of n, starting with n = 0.


    // From http://www.mathblog.dk/project-euler-27-quadratic-formula-primes-consecutive-values/:

    private static int[] primes = Ancillary.ESieve(87400); // Where did this limit come from?

    private static bool isPrime(int n) {
      int i=0;
      while (primes[i] <= n) {
        if (primes[i] == n)
          return true;
        i++;
      }
      return false;
    }

    private static int getAnswer() {
      int aMax = 0, bMax = 0, nMax = 0;

      for (int a = -1000; a<=1000; a++) {
        for (int b = -1000; b<=1000; b++) {
          int n = 0;
          while (isPrime(Math.Abs(n*n + a*n + b)))
            n++;

          if (n>nMax) {
            aMax = a;
            bMax = b;
            nMax = n;
          }
        }
      }

      return aMax*bMax; // -59231.
    }

    // After a brief, good discussion of the solution space, he comes up with the following optimized version:
    private static int getAnswer1() {
      int aMax = 0, bMax = 0, nMax = 0;
      int[] bPos = Ancillary.ESieve(1000);

      for (int a = -999; a<1001; a+=2) {
        for (int i = 1; i<bPos.Length; i++) {
          for (int j = 0; j<2; j++) {
            int n = 0;
            int sign = (j==0) ? 1 : -1;
            int aodd = (i%2==0) ? -1 : 0; // Making a even if b is even.
            while (isPrime(Math.Abs(n*n + (a+aodd)*n + sign*bPos[i])))
              n++;

            if (n>nMax) {
              aMax = a;
              bMax = bPos[i];
              nMax = n;
            }
          }
        }
      }

      return aMax*bMax; // -59231, and faster.
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
