using System;

namespace ProjectEulerCS
{
  class Program
  {
    static void printAndWait(string s)
    {
      Console.WriteLine(s);

      Console.WriteLine("Hit any key to continue.");
      Console.ReadKey();
    }

    static void Main(string[] args)
    {
      printAndWait(Problem45.Answer.ToString());
    }
  }
}
