using System;
using System.Text;

namespace ProjectEulerCS {
  class Problem24 {
    // What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    //
    // A permutation is an ordered arrangement of objects. For example, 3124 is one
    // possible permutation of the digits 1, 2, 3 and 4. If all of the permutations
    // are listed numerically or alphabetically, we call it lexicographic order. The
    // lexicographic permutations of 0, 1 and 2 are:
    //
    // 012   021   102   120   201   210
    //
    // What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

    // This time I cannot figure out what the F# solution is doing or how it works. So I turned to
    // http://www.mathblog.dk/project-euler-24-millionth-lexicographic-permutation/, and found a
    // fascinating, though still somewhat inscrutible, solution in the comments. It's also much
    // faster than the F# solution--blindingly fast.
    //
    // He bases his code on an amazing paper about permutations at
    // http://msdn.microsoft.com/en-us/library/Aa302371.

    private static string getAnwer() {
      int n = 1000000 - 1;
      int f = 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1; // Probably faster than Enumerable.Range(1, 9).Aggregate(product);.

      int[] factoid = new int[10];

      for (int i=9; i>0; i--) {
        factoid[i] = n/f;
        n %= f;
        f /= i;
      }

      for (int i=1; i<10; i++)
        for (int j=i-1; j>=0; j--)
          if (factoid[j] >= factoid[i]) factoid[j]++;

      StringBuilder sb = new StringBuilder();
      for (int i=9; i>=0; i--)
        sb.Append(factoid[i].ToString());

      return sb.ToString(); // 2783915460.
    }
    // "1000000 can be represented as 2662512110 in the Factorial number system. Then we walk through each digit
    // in that number from right to left. We increment every digit in the output number that is greater [than] or
    // equal to the current digit, and then we prepend the current digit to the output number. The output
    // number after each step:
    // 0
    // 10
    // 120
    // 2130
    // 13240
    // 513240
    // 2614350
    // 62714350
    // 672814350
    // 2783915460"
    //
    // Wow.

    public static string Answer {
      get { return getAnwer(); }
    }

    // I feel so wrong not using LINQ! :)
  }
}
