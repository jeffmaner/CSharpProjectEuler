using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCS {
  class Problem40 {
    // Finding the nth digit of the fractional part of the irrational number.
    //
    // An irrational decimal fraction is created by concatenating the positive integers:
    //
    // 0.12345678910[1]112131415161718192021...
    //
    // It can be seen that the 12th digit of the fractional part is 1.
    //
    // If d[n] represents the nth digit of the fractional part, find the value of the following expression.
    //
    // d[1] × d[10] × d[100] × d[1000] × d[10000] × d[100000] × d[1000000]


    // Based on http://theburningmonk.com/2010/09/project-euler-problem-40-solution/:

    private static int getAnswer() {
      var naturals = Enumerable.Range(1, 1000000); // This limit seems arbitrary, but it works.
      var fraction = naturals.SelectMany(x => x.ToString().ToCharArray().Select(c => c.ToString()));

      Func<int, int> d = n => Int32.Parse(fraction.ElementAt(n-1));

      Func<int, int, int> product = (x, y) => x*y;

      return Enumerable.Range(0, 7)
        .Select(n => d((int)Math.Pow((double)10, (double)n)))
        .Aggregate(product); // 210.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
