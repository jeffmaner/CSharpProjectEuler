using System;
using System.IO;
using System.Linq;

namespace ProjectEulerCS {
  class Problem18 {
    // Find the maximum sum travelling from the top of the triangle to the base.
    //
    // By starting at the top of the triangle below and moving to adjacent numbers
    // on the row below, the maximum total from top to bottom is 23.
    // 
    // 3
    // 7 4
    // 2 4 6
    // 8 5 9 3
    // 
    // That is, 3 + 7 + 4 + 9 = 23.
    // 
    // Find the maximum total from top to bottom of the triangle below:
    // 
    // 75
    // 95 64
    // 17 47 82
    // 18 35 87 10
    // 20 04 82 47 65
    // 19 01 23 75 03 34
    // 88 02 77 73 07 63 67
    // 99 65 04 28 06 16 70 92
    // 41 41 26 56 83 40 80 70 33
    // 41 48 72 33 47 32 37 16 94 29
    // 53 71 44 65 25 43 91 52 97 51 14
    // 70 11 33 28 77 73 17 78 39 68 17 57
    // 91 71 52 38 17 14 91 43 58 50 27 29 48
    // 63 66 04 68 89 53 67 30 73 16 69 87 40 31
    // 04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
    // 
    // NOTE: As there are only 16384 routes, it is possible to solve this problem by
    // trying every route. However, Problem 67, is the same challenge with a triangle
    // containing one-hundred rows; it cannot be solved by brute force, and requires
    // a clever method! ;o)


    // Having read the great discussion on of the problem on
    // http://theburningmonk.com/2010/09/project-euler-problem-18-solution/, I like
    // http://fsharp-euler.wikispaces.com/euler+018:'s solution (translated to VB, then to C#).

    private static int getAnswer() {
      int[][] tri = new int[15][]; // This sucks!
      tri[0] = new int[] { 75 };
      tri[1] = new int[] { 95, 64 };
      tri[2] = new int[] { 17, 47, 82 };
      tri[3] = new int[] { 18, 35, 87, 10 };
      tri[4] = new int[] { 20, 4, 82, 47, 65 };
      tri[5] = new int[] { 19, 1, 23, 75, 3, 34 };
      tri[6] = new int[] { 88, 2, 77, 73, 7, 63, 67 };
      tri[7] = new int[] { 99, 65, 4, 28, 6, 16, 70, 92 };
      tri[8] = new int[] { 41, 41, 26, 56, 83, 40, 80, 70, 33 };
      tri[9] = new int[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 };
      tri[10] = new int[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 };
      tri[11] = new int[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 };
      tri[12] = new int[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 };
      tri[13] = new int[] { 63, 66, 4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 };
      tri[14] = new int[] { 4, 62, 98, 27, 23, 9, 70, 98, 73, 93, 38, 53, 60, 4, 23 };

      int n = tri.Length;

      for (int i=1; i<n; i++) {
        tri[i][0] = tri[i][0] + tri[i-1][0];
        tri[i][i] = tri[i][i] + tri[i-1][i-1];

        for (int j=1; j<i; j++)
          tri[i][j] = tri[i][j] + Math.Max(tri[i-1][j-1], tri[i-1][j]);
      }

      return tri[n-1].Max(); // 1074.
    }


    // I like the simplicity of the algorithm at http://www.mathblog.dk/project-euler-18/:

    private static int[,] readInput(string filename) {
      string line;
      string[] linePieces;
      int lines = 0;

      StreamReader r = new StreamReader(filename);
      while ((line = r.ReadLine()) != null) {
        lines++;
      }

      int[,] inputTriangle = new int[lines, lines];
      r.BaseStream.Seek(0, SeekOrigin.Begin);
      
      int j = 0;
      while ((line = r.ReadLine()) != null) {
        linePieces = line.Split(' ');
        for (int i = 0; i < linePieces.Length; i++) {
          inputTriangle[j, i] = int.Parse(linePieces[i]);
        }
        j++;
      }
      r.Close();
      return inputTriangle;
    }

    private static int getAnswer1() {
      string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\input.txt";
      int[,] inputTriangle = readInput(filename);
      int lines = inputTriangle.GetLength(0);

      for (int i = lines - 2; i >= 0; i--) {
        for (int j = 0; j <= i; j++) {
          inputTriangle[i, j] += Math.Max(inputTriangle[i+1, j], inputTriangle[i+1, j+1]);
        }
      }

      return inputTriangle[0, 0]; // Is this the right thing to return?
    }

    public static int Answer {
      get { return getAnswer1(); }
    }
  }
}
