using System.Linq;

namespace ProjectEulerCS {
  class Problem28 {
    // What is the sum of both diagonals in a 1001 by 1001 spiral?
    //
    // Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed
    // as follows:
    //
    // [21] 22 23 24 [25]
    // 20  [7]  8  [9] 10
    // 19  6  [1]  2 11
    // 18  [5]  4  [3] 12
    // [17] 16 15 14 [13]
    //
    // It can be verified that the sum of the numbers on the diagonals is 101.
    //
    // What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?

    // From http://theburningmonk.com/2010/09/project-euler-problem-28-solution/:

    private static int sumDiagonals(int n, int m, int total, int max) {
      if (n==1)
        return sumDiagonals(n+1, m, 1, 1);
      else
        if (n>m)
          return total;
        else
          if (n%2==0)
            return sumDiagonals(n+1, m, total, max);
          else {
            var newValues = Enumerable.Range(1, 4).Select(x => max + x*(n-1));
            int newMax    = newValues.Max();
            int newTotal  = total + newValues.Sum();

            return sumDiagonals(n+1, m, newTotal, newMax);
          }
    }

    private static int getAnswer() {
      return sumDiagonals(1, 1001, 0, 0); // 669171001.
    }


    // From http://fsharp-euler.wikispaces.com/euler+028:

    private static int collect(int depth, int start, int acc) {
      const int n = 1001;

      if (depth > n/2)
        return acc;
      else
        return collect(depth+1, start + 8*depth, acc + 4*start + 20*depth);
    }

    private static int getAnswer1() {
      return collect(1, 1, 1); // 669171001.
    }


    // See http://www.mathblog.dk/project-euler-28-sum-diagonals-spiral/ for a great discussion of calculating
    // the answer analytically without any code!


    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
