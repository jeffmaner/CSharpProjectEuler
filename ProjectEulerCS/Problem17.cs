using System;
using System.Linq;

namespace ProjectEulerCS {
  class Problem17 {
    // How many letters would be needed to write all the numbers in words from 1 to 1000?
    //
    // If the numbers 1 to 5 are written out in words: one, two, three, four, five,
    // then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    //
    // If all the numbers from 1 to 1000 (one thousand) inclusive were written out
    // in words, how many letters would be used?
    //
    // NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and
    // forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20
    // letters. The use of "and" when writing out numbers is in compliance with British
    // usage.


    // I'm intrigued by the answer at http://fsharp-euler.wikispaces.com/euler+017:

    private static int letterCount(int n) {
      // This is so much prettier if F# and VB.
      switch (n) {
        case 0: return 0;
        case 1:
        case 2:
        case 6:
        case 10: return 3;
        case 4:
        case 5:
        case 9: return 4;
        case 3:
        case 7:
        case 8:
        case 40:
        case 50:
        case 60: return 5;
        case 11:
        case 12:
        case 20:
        case 30:
        case 80:
        case 90: return 6;
        case 15:
        case 16:
        case 70: return 7;
        case 13:
        case 14:
        case 18:
        case 19: return 8;
        case 17: return 9;
        default: throw new Exception("Failed with " + n.ToString());
      }
    }

    private static int numberLength(int n) {
      // This is so much prettier F# and VB.
      if (n==1000)
        return 11; // 11 = 3 + 8 = Len("one") + Len("thousand").
      else {
        if (n<=20)
          return letterCount(n);
        else {
          if (n<100) {
            int tens = (int)Math.Floor((double)n/10)*10;
            int ones = n%10;

            return letterCount(tens) + letterCount(ones);
          }
          else {
            int hundreds = (int)Math.Floor((double)n/100);

            if (n%100==0)
              return letterCount(hundreds) + 7; // 7 = Len("hundred").
            else
              return letterCount(hundreds) + 10 + numberLength(n%100); // 10 = 7 + 3 = Len("hundred") + Len("And").
          }
        }
      }
    }

    private static int getAnswer() {
      var ns = Enumerable.Range(1, 1000);
      return ns.Select(numberLength).Sum(); // 21124.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
