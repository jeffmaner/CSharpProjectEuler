using System;
using System.Linq;

namespace ProjectEulerCS {
  class Problem34 {
    // Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    //
    // 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
    //
    // Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    //
    // Note: as 1! = 1 and 2! = 2 are not sums they are not included.


    // From http://www.mathblog.dk/project-euler-34-factorial-digits/:

    private static int factorial(int n) {
      Func<int,int,int> product = (x,y) => x*y;
      return n==0 ? 1 : Enumerable.Range(1, n).Aggregate(product);
    }

    private static int getAnswer() {
      int result = 0;

      // Cache factorial values we'll need.
      int[] facts = new int[10];
      for (int i=0; i<10; i++)
        facts[i] = factorial(i);

      for (int i=10; i<2540161; i++) {
        int sumOfFacts = 0;
        int number = i;
        while (number>0) {
          int d = number % 10;
          number /= 10;
          sumOfFacts += facts[d];
        }
        if (sumOfFacts==i)
          result += i;
      }

      return result; // 40730.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
