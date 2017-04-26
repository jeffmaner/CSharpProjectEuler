using System.Linq;

namespace ProjectEulerCS {
  class Problem31 {
    // Investigating combinations of English currency denominations.
    //
    // In England the currency is made up of pound, £, and pence, p, and there are eight coins in general
    // circulation:
    //
    //    1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    //
    // It is possible to make £2 in the following way:
    //
    //    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    //
    // How many different ways can £2 be made using any number of coins?


    // The Burning Monk has the most interesting solution.
    // From http://theburningmonk.com/2010/10/project-euler-problem-31-solution/:

    private static int[] coins = {1,2,5,10,20,50,100,200};

    // See http://www.algorithmist.com/index.php/Coin_Change.
    private static int count(int n, int m) {
      if (n==0) return 1;
      if (n<0) return 0;
      if (m<=0 && n>=1) return 0;
      return count(n, m-1) + count(n-coins[m-1], m);
    }

    private static int getAnswer() {
      return count(200, coins.Count()); // 73682.
    }


    // From http://www.mathblog.dk/project-euler-31-combinations-english-currency-denominations/,
    // a Dynamic Programming solution.

    private static int getAnswer1() {
      int target = 200;
      int[] coinSizes = { 1, 2, 5, 10, 20, 50, 100, 200 };
      int[] ways = new int[target+1];
      ways[0] = 1;

      for (int i=0; i<coinSizes.Length; i++)
        for (int j=coinSizes[i]; j<=target; j++)
          ways[j] += ways[j - coinSizes[i]];

      return ways[ways.Length-1]; // 73682.
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
