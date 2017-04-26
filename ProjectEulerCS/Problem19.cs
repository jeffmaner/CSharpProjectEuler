using System;
using System.Linq;

namespace ProjectEulerCS {
  class Problem19 {
    // How many Sundays fell on the first of the month during the twentieth century?
    //
    // You are given the following information, but you may prefer to do some research for yourself.
    // 
    //     * 1 Jan 1900 was a Monday.
    //     * Thirty days has September,
    //       April, June and November.
    //       All the rest have thirty-one,
    //       Saving February alone,
    //       Which has twenty-eight, rain or shine.
    //       And on leap years, twenty-nine.
    //     * A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
    // 
    // How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?


    // From http://theburningmonk.com/2010/09/project-euler-problem-19-solution/:

    private static int getAnswer() {
      var years = Enumerable.Range(1901, 99); // 1901 to 2000.
      var months = Enumerable.Range(1, 12);

      var firstDays = years.SelectMany(y => months.Select(m => new DateTime(y, m, 1)));
      var sundays = firstDays.Where(d => d.DayOfWeek == DayOfWeek.Sunday);

      return sundays.Count(); // 170. F# reports 171...
    }

    public static int Answer {
      get { return getAnswer(); }
    }
  }
}
