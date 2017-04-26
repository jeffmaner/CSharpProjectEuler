using System;
using System.Collections;
using System.Linq;

namespace ProjectEulerCS {
  class Problem04 {
    // A palindromic number reads the same both ways. The largest palindrome made
    // from the product of two 2-digit numbers is 9009 = 91 × 99.
    //
    // Find the largest palindrome made from the product of two 3-digit numbers.

    // Based on http://theburningmonk.com/2010/09/project-euler-problem-4-solution/.

    private static bool isPalindrome(int n) {
      var cs = n.ToString().ToCharArray();
      var sc = cs.Reverse().ToArray();

      return cs.SequenceEqual(sc);
    }

    private static int getAnswer() {
      // Get three-digit numbers.
      var ns = Enumerable.Range(100, 899);

      // Get products of cartesian product of ns x ns.
      var ps = ns.SelectMany(x => ns.Select(y => x*y));

      // Get maximum of those products that are palindromes.
      return ps.Where(isPalindrome).Max(); // 906609.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
