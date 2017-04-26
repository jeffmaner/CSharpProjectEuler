using System.Linq;

namespace ProjectEulerCS {
  class Problem41 {
    // What is the largest n-digit pandigital prime that exists?
    //
    // We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once.
    // For example, 2143 is a 4-digit pandigital and is also prime.
    //
    // What is the largest n-digit pandigital prime that exists?


    // The solution at the Burning Monk took 14 minutes to run! So I'll skip that one here.

    private static bool isPandigitalF(int n) {
      string s = n.ToString();

      return Enumerable.Range(1, s.Length)
        .Select(d => d.ToString())
        .All(d => s.Contains(d) && s.IndexOf(d) == s.LastIndexOf(d));
    }

    private static bool isPandigitalI(int n) {
      int digits = 0;
      int count = 0;
      int tmp;

      while (n>0) {
        tmp = digits;
        digits = digits | 1 << (int)((n%10) - 1); // The minus one is there to make one fill the first bit and so on.
        if (tmp == digits)
          return false;

        count++;
        n /= 10;
      }

      return digits == (1 << count) - 1;
    }

    // I'll go ahead and take advantage of an optimization found at Math Blog.
    // At http://www.mathblog.dk/project-euler-41-pandigital-prime/ he notes that all pandigital numbers except
    // for the four-digit and seven-digit ones are divisible by three, and are therefore not prime. So he sets
    // the maximum number to check at 7654321 instead of 987654321, which significantly speeds up the discovery
    // process.
    //
    // 1+2+3+4+5+6+7+8+9 = 45
    // 1+2+3+4+5+6+7+8 = 36
    // 1+2+3+4+5+6+7 = 28
    // 1+2+3+4+5+6 = 21
    // 1+2+3+4+5 = 15
    // 1+2+3+4 = 10
    // 1+2+3 = 6
    // 1+2 = 3

    private static int getAnswer() {
      return Ancillary.ESieve(7654321).Where(isPandigitalF).Max(); // 7652413.
    }

    private static int getAnswer1() {
      return Ancillary.ESieve(7654321).Where(isPandigitalI).Max(); // 7652413.
    }


    // Based on http://www.mathblog.dk/project-euler-41-pandigital-prime/:

    private static int getAnswer2() {
      int[] ps = Ancillary.ESieve(7654321);
      int r = 0;

      for (int i = ps.Length-1; i>-1; i--)
        if (isPandigitalF(ps[i])) {
          r = ps[i];
          break;
        }

      return r; // 7652413.
    }

    private static int getAnswer3() {
      int[] ps = Ancillary.ESieve(7654321);
      int r = 0;

      for (int i = ps.Length-1; i>-1; i--)
        if (isPandigitalI(ps[i])) {
          r = ps[i];
          break;
        }

      return r; // 7652413.
    }

    public static int Answer {
      get { return getAnswer3(); }
    }
  }
}
