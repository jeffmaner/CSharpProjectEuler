using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem09 {
    // Find the only Pythagorean triplet, {a, b, c}, for which a + b + c = 1000.
    //
    // A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    // a^2 + b^2 = c^2
    // 
    // For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
    //
    // There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    // Find the product abc.

    private static int getAnswer() {
      const int p = 1000; // Perimeter of triangle.
      List<int> rs = new List<int>();

      for (int a=1; a<=p; a++) {
        for (int b=1; b<=p; b++) {
          int c = p - a - b;

          if (a*a + b*b == c*c)
            rs.Add(a*b*c);
        }
      }

      return rs.Max(); // 31875000.
    }

    // On http://www.mathblog.dk/pythagorean-triplets/, the author takes advantage
    // of a couple of properties to optimize the algorithm.
    // We could be ignorant and just let a and b loop from 1-1000, or we could
    // use the facts that a < b < c, and thus exploit that  a < p/3,
    // and a < b < p/2.
    private static int getAnswer1() {
      int a = 0, b = 0, c = 0;
      int p = 1000;
      bool found = false;

      for (a = 1; a < p / 3; a++) {
        for (b = a; b < p / 2; b++) {
          c = p - a - b;

          if (a * a + b * b == c * c) {
            found = true;
            break;
          }
        }

        if (found) {
          break;
        }
      }

      return a*b*c;
    }
    // He also comes with a sophisticatedly number-theoretic solution. Interesting,
    // but not to my tastes of simplicity and naivete! :)

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
