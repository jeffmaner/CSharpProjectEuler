using System.Linq;

namespace ProjectEulerCS {
  class Problem14 {
    // Find the longest sequence using a starting number under one million.
    //
    // The following iterative sequence is defined for the set of positive integers:
    //
    // n → n/2 (n is even)
    // n → 3n + 1 (n is odd)
    //
    // Using the rule above and starting with 13, we generate the following sequence:
    // 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    //
    // It can be seen that this sequence (starting at 13 and finishing at 1) contains
    // 10 terms. Although it has not been proved yet (Collatz Problem), it is thought
    // that all starting numbers finish at 1.
    //
    // Which starting number, under one million, produces the longest chain?
    //
    // NOTE: Once the chain starts the terms are allowed to go above one million.

    // From http://theburningmonk.com/2010/09/project-euler-problem-14-solution/:

    private static long nextNumber(long n) {
      if (n%2L==0L)
        return n/2L;
      else
        return 3L*n + 1L;
    }

    private static long findSequenceLength(long n) {
      long count = 1L, current = n;

      while (current > 1L) {
        current = nextNumber(current);
        count++;
      }

      return count;
    }

    private static long getAnswer() {
      var ns = Ancillary.naturalsL(1L, 999999L);
      return ns.Select(findSequenceLength).Max(); // 525! F# says 837799!
    }
    // The problem seems to be that I don't understand what F# is doing. I thought
    // Seq.maxBy f xs <=> Seq.map f xs |> Seq.max
    // but that's not the case.

    public static long Answer {
      get { return getAnswer(); }
    }
  }
}
