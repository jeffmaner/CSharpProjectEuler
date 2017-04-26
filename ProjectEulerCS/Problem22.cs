using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEulerCS {
  class Problem22 {
    // What is the total of all the name scores in the file of first names?
    //
    // Using names.txt, a 46K text file containing over five-thousand first names,
    // begin by sorting it into alphabetical order. Then working out the alphabetical
    // value for each name, multiply this value by its alphabetical position in the
    // list to obtain a name score.
    //
    // For example, when the list is sorted into alphabetical order, COLIN, which is
    // worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would
    // obtain a score of 938 × 53 = 49714.
    //
    // What is the total of all the name scores in the file?


    // Based on the solution at http://theburningmonk.com/2010/09/project-euler-problem-22-solution/.

    private const string path = @"C:\Users\TGHG\Documents\Visual Studio 2010\Projects\ProjectEulerCS\ProjectEulerCS\names.txt";

    /// <summary>
    /// Given that A = 1, B = 2, C = 3, ... Z = 26, return the sum of the letters in s.
    /// </summary>
    private static int stringSum(string s) {
      return s.Sum(c => (int)c - 64); // 64 = (int)"A" - 1.
    }

    private static int score(string s, int i) {
      return stringSum(s) * i;
    }

    private static int getAnswer() {
      string text = File.ReadAllText(path).Replace("\"", "");
      List<string> names = text.Split(',').ToList();
      names.Sort();

      var scores = names.Zip(Enumerable.Range(1, names.Count), (n, i) => score(n, i));

      return scores.Sum(); // 871198282.
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
