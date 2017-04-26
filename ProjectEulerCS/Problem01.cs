using System.Linq;

namespace ProjectEulerCS
{
  class Problem01
  { // Problem 1:
    // Add all the natural numbers below one thousand that are multiples of 3 or 5.
    //
    // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6, and 9.
    // The sum of these multiples is 23.
    //
    // Find the sum of all the multiples of 3 or 5 below 1000.

    // From http://www.mathblog.dk/project-euler-problem-1/:
    private static int getAnswer()
    {
      int r=0;

      for (int i = 1; i < 1000; i++)
      {
        if (((i%3)==0) || ((i%5)==0))
          r+=i;
      }

      return r;
    }

    // My attempt, using Linq.
    private static int getAnswer1()
    {
      return Enumerable.Range(1, 999).Where(n=>((n%3==0) || (n%5==0))).Sum();
    }

    // From http://www.mathblog.dk/project-euler-problem-1/:
    private static int getAnswer2() {
      return SumDivisbleBy(3,999)+SumDivisbleBy(5,999)-SumDivisbleBy(15,999);
    }

    private static int SumDivisbleBy(int n, int p) {
      return n*(p/n)*((p/n)+1)/2;
    }

    public static int Answer
    {
      get
      {
        return getAnswer2(); // 233168.
      }
    }
  }
}
