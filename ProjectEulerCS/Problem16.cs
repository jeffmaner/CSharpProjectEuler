using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEulerCS {
  class Problem16 {
    // What is the sum of the digits of the number 2^1000?
    //
    // 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    //
    // What is the sum of the digits of the number 2^1000?

    private static int getAnswer() {
      BigInteger n = BigInteger.Pow(2, 1000);
      var cs = n.ToString().ToCharArray();
      var ns = cs.Select(c => System.Int32.Parse(c.ToString()));

      return ns.Sum(); // 1366.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
