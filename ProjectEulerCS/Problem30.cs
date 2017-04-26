using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem30 {
    // Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    //
    // Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
    //
    //    1634 = 1^4 + 6^4 + 3^4 + 4^4
    //    8208 = 8^4 + 2^4 + 0^4 + 8^4
    //    9474 = 9^4 + 4^4 + 7^4 + 4^4
    //
    // As 1 = 1^4 is not a sum it is not included.
    //
    // The sum of these numbers is 1634 + 8208 + 9474 = 19316.
    //
    // Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.


    // From http://www.mathblog.dk/project-euler-30-sum-numbers-that-can-be-written-as-the-sum-fifth-powers-digits/:

    private static int getAnswer() {
      // "We need to find a number x*(9^5) which gives us an x digit number. We can do this by hand. Since
      // 9^5 = 59,049, we need at least 5 digits. 5*(9^5) = 295,245, so with 5 digits we can make a 6-digit
      // number. 6*(9^5) = 354,294. So 355,000 seems like a reasonable upper bound to use." Interesting.

      int result = 0;

      for (int i=2; i<354294; i++) {
        int sumOfPowers = 0;
        int number = i;
        while (number > 0) {
          int d = number % 10; // I think this is an interesting way to get the digit,
          number /= 10;        // contrasted with casting the number to a String.

          int temp = d;           // Why loop here instead of just inlining
          for (int j=1; j<5; j++) // d*d*d*d*d?
            temp *= d;
          sumOfPowers += temp;
        }

        if (sumOfPowers == i)
          result += i;
      }

      return result; // 443839.
    }


    // From http://fsharp-euler.wikispaces.com/euler+030:

    private static int digitSum(Func<int, int> f, int n) {
      return n.ToString().Select(c => f(Int32.Parse(c.ToString()))).Sum();
    }

    private static int getAnswer1() {
      return Enumerable.Range(2, 354293)
        .Select(x => new Tuple<int, int>(x, x))
        .Select(t => new Tuple<int, int>(t.Item1, digitSum((x => x*x*x*x*x), t.Item2)))
        .Where(t => t.Item1 == t.Item2)
        .Select(t => t.Item1)
        .Sum(); // 443839.
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
