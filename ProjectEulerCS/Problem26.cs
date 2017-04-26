using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEulerCS {
  class Problem26 {
    // Find the value of d < 1000 for which 1/d contains the longest recurring cycle.
    //
    // A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with
    // denominators 2 to 10 are given:
    //
    //    1/2	= 	0.5
    //    1/3	= 	0.(3)
    //    1/4	= 	0.25
    //    1/5	= 	0.2
    //    1/6	= 	0.1(6)
    //    1/7	= 	0.(142857)
    //    1/8	= 	0.125
    //    1/9	= 	0.(1)
    //    1/10	= 	0.1
    //
    // Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit
    // recurring cycle.
    //
    // Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.


    // From http://theburningmonk.com/2010/09/project-euler-problem-26-solution/:

    private static int cycleLength(BigInteger n) {
      if (n%2==0)
        return cycleLength(n/2);
      else
        if (n%5==0)
          return cycleLength(n/5);
        else
          return Enumerable.Range(1, 999).Where(x => (BigInteger.Pow(10, x) - 1) % n == 0).First();
    }

    private static int getAnswer() {
      return Ancillary.naturalsB(1,999).Max(x => cycleLength(x)); // 982.
    }

    // From http://www.mathblog.dk/project-euler-26-find-the-value-of-d-1000-for-which-1d-contains-the-longest-recurring-cycle/.

    private static int getAnswer1() {
      int sequenceLength = 0;

      for (int i=1000; i>1; i--) {
        if (sequenceLength >= i)
          break;

        int[] foundRemainders = new int[i];
        int value = 1;
        int position = 0;

        while (foundRemainders[value] == 0 && value != 0) {
          foundRemainders[value] = position;
          value *= 10;
          value %= i;
          position++;
        }

        if (position - foundRemainders[value] > sequenceLength)
          sequenceLength = position - foundRemainders[value];
      }

      return sequenceLength; // 982.
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
