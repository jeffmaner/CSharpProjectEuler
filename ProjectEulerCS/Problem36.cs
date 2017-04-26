using System.Linq;

namespace ProjectEulerCS {
  class Problem36 {
    // Find the sum of all numbers less than one million, which are palindromic in base 10 and base 2.
    //
    // The decimal number, 585 = 1001001001 (base 2) (binary), is palindromic in both bases.
    //
    // Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
    //
    // (Please note that the palindromic number, in either base, may not include leading zeros.)

    // My functional implementation of Math Blog's awesome reversal of an integer without converting it to a
    // string and list first.
    private static int reversed(int k, int m, int b) {
      return k>0 ? reversed(k/b, b*m + k%b, b) : m;
    }

    private static bool isPalindrome(int b, int n) {
      //Func<int, int, int> reversed = (k, m) => k>0 ? reversed(k/b, b*m + k%b) : m;
      //return n==reversed(n, 0);
      return n==reversed(n, 0, b);
    }

    private static bool isPalB10(int n) {
      return isPalindrome(10, n); // Can't Curry in C#.
    }

    private static bool isPalB2(int n) {
      return isPalindrome(2, n); // Can't Curry in C#.
    }

    private static int getAnswer() {
      return Enumerable.Range(1, 1000000).Where(n => isPalB10(n) && isPalB2(n)).Sum(); // 872187.
    }


    // From http://www.mathblog.dk/project-euler-36-palindromic-base-10-2/:

    // Creating palindromic numbers reduces the search space from one million numbers to under 2000.
    private static int createPalindrome(int input, int b, bool isOdd) {
      int n = input;
      int p = input;
      if (isOdd) n/=b;

      while (n>0) {
        p = p*b + (n%b);
        n /= b;
      }

      return p;
    }

    // I don't understand it, but here goes...
    private static int getAnswer1() {
      const int limit = 1000000;
      int result = 0;
      int number;

      for (int j=0; j<2; j++) {
        bool isOdd = (j%2==0);
        int i = 1;
        while ((number = createPalindrome(i, 10, isOdd)) < limit) {
          if (isPalindrome(2, number))
            result += number;
          i++;
        }
      }

      return result; // 872187.
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
