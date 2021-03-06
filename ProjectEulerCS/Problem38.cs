﻿namespace ProjectEulerCS {
  class Problem38 {
    // What is the largest 1 to 9 pandigital that can be formed by multiplying a fixed number by 1, 2, 3, ... ?
    //
    // Take the number 192 and multiply it by each of 1, 2, and 3:
    //
    //    192 × 1 = 192
    //    192 × 2 = 384
    //    192 × 3 = 576
    //
    // By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the
    // concatenated product of 192 and (1,2,3)
    //
    // The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital,
    // 918273645, which is the concatenated product of 9 and (1,2,3,4,5).
    //
    // What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an
    // integer with (1,2, ... , n) where n > 1?


    // Great analysis of the solution space at http://www.mathblog.dk/project-euler-38-pandigital-multiplying-fixed-number/:
    // First of all, the fixed number must contain less than five digits, since n has to be greater than 1.
    //
    // Second thing to note in our analysis is that we are given a candidate which starts with nine, so the fixed
    // number we need to find needs to start with 9 as well, which gives us some properties to use in the
    // analysis.
    //
    // If the fixed number id two digits, we won't be able to generate a nine-digit number, since n=3 yields an
    // eight-digit number and n=4 yields an 11 digit number. Same goes for three-digit numbers where we end at
    // seven or 11 digits in the result. That leaves us with a four-digit number, starting with nine.
    //
    // So already we can limit the search to numbers between 9123 and 9876, a mere 753 numbers.
    //
    // We can rather easily limit it a bit more. If the second digit is >4 then we get a carry over which
    // results in the multiplying by 2 part will yield 19xxx instead of 18xxx and thus we have two 9s which
    // are not possible solutions. Furthermore, none of the digits can be 1 since we will end up with a solution
    // candidate with 1s in it. (I don't follow this paragraph).
    //
    // So the solution space can be shrunk to numbers between 9234 and 9487, which means we would need to check
    // 253 solutions. (And yet his code goes from *9387* to 9234, rather than *9487*. Don't get that, either.)


    // I'm not crazy about any of the code at my functional sources. I love the code at Math Blog, but it's
    // imperative and relies heavily on mutation.


    private static long concat(long a, long b) {
      long c = b;
      while (c > 0) {
        a *= 10;
        c /= 10;
      }
      return a + b;
    }

    private static bool isPandigital(long n) {
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

    private static long getAnswer() {
      long result = 0;
      for (long i = 9387; i >= 9234; i--) {
        result = concat(i, 2*i);
        if (isPandigital(result))
          break;
      }

      return result; // 932718654.
    }

    public static long Answer {
      get { return getAnswer(); }
    }
  }
}
