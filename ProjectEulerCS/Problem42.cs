using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerCS {
  class Problem42 {
    // How many triangle words does the list of common English words contain?
    //
    // The nth term of the sequence of triangle numbers is given by, t[n] = ½n(n+1); so the first ten triangle
    // numbers are:
    //
    // 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    //
    // By converting each letter in a word to a number corresponding to its alphabetical position and adding
    // these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t[10].
    // If the word value is a triangle number then we shall call the word a triangle word.
    //
    // Using Problem42.txt, a 16K text file containing nearly two-thousand common English words, how many are
    // triangle words?

    private const string path = @"C:\Users\TGHG\Documents\Visual Studio 2010\Projects\ProjectEulerCS\ProjectEulerCS\Problem42.txt";

    private static int wordValue(string word) {
      return word.ToCharArray().Select(c => (int)c - 64).Sum(); // 64 = Asc('A') - 1.
    }

    private static int T(int n) {
      return n*(n+1)/2;
    }

    private static int getAnswer() {
      string[] words = File.ReadAllText(path).Replace("\"", "").Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries);
      int[] wordValues = words.Select(wordValue).ToArray();
      int maxWordValue = wordValues.Max();

      return Enumerable.Range(1, maxWordValue)
        .Select(T)
        .Select(t => wordValues
          .Where(n => t==n).Count()).Sum(); // 162.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
