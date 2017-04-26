using System.Linq;

namespace ProjectEulerCS {
  class Problem06 {
    // What is the difference between the sum of the squares and the square of the sums?

    // The sum of the squares of the first ten natural numbers is,
    // 1^2 + 2^2 + ... + 10^2 = 385
    //
    // The square of the sum of the first ten natural numbers is,
    // (1 + 2 + ... + 10)^2 = 552 = 3025
    //
    // Hence the difference between the sum of the squares of the first ten natural
    // numbers and the square of the sum is 3025 − 385 = 2640.
    //
    // Find the difference between the sum of the squares of the first one hundred
    // natural numbers and the square of the sum.

    private static int sqr(int n) {
      return n*n;
    }

    private static int getAnswer() {
      var ns = Enumerable.Range(1, 100);

      int s1 = ns.Select(sqr).Sum(); // Sum of squares.
      int s2 = sqr(ns.Sum());        // Square of sum.

      return s2 - s1; // 25164150.
    }

    // I like the final solution at http://www.mathblog.dk/project-euler-problem-6/
    // because he calls in number theory.
    private static int getAnswer1() {
      const int N = 100;
      
      int sum = N * (N+1)/ 2;
      int squared = (N * (N + 1) * (2 * N + 1)) / 6;

      return sum * sum - squared; // 25164150.
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
