using System;
using System.IO;

class A {

  static int part1(string file) {
    int totalCals = 0;
    using (StreamReader r = File.OpenText(file)) {
      string line;
      int currVal, cumSum = 0;

      while ((line = r.ReadLine()) != null) {
        if (line == "") {
          totalCals = cumSum > totalCals ? cumSum : totalCals;
          cumSum = 0;
        } else {
          try {
            currVal = Int32.Parse(line);
            cumSum += currVal;
          } catch (Exception e) {
            Console.WriteLine("Sorry dude, your elf is cheating on calories!");
            return -1;
          }
        }
      }
      totalCals = cumSum > totalCals ? cumSum : totalCals;
    }
    return totalCals;
  }

  static int part2(string file) {
    int[] totalCals = {0,0,0};
    int I = totalCals.Length;
    int swap;
    int i, j;
    using (StreamReader r = File.OpenText(file)) {
      string line;
      int currVal, cumSum = 0;
      while ((line = r.ReadLine()) != null) {
        if (line == "") {
          swap = 0;
          for (i = 0; i < I; ++i) {
            if (cumSum > totalCals[i]) {
              swap = totalCals[i];
              totalCals[i] = cumSum;
              break;
            }
          }
          for (j = I - 1; swap > 0 && j > (i + 1); --j) {
            totalCals[j] = totalCals[j - 1];
          }
          totalCals[j] = swap > totalCals[j] ? swap : totalCals[j];
          cumSum = 0;
        } else {
          try {
            currVal = Int32.Parse(line);
            cumSum += currVal;
          } catch (Exception e) {
            Console.WriteLine("Sorry dude, your elf is cheating on calories!");
            return -1;
          }
        }
      }
      
      swap = 0;
      for (i = 0; i < I; ++i) {
        if (cumSum > totalCals[i]) {
          swap = totalCals[i];
          totalCals[i] = cumSum;
          break;
        }
      }
      for (j = I - 1; swap > 0 && j > (i + 1); --j) {
        totalCals[j] = totalCals[j - 1];
      }
      totalCals[j] = swap > totalCals[j] ? swap : totalCals[j];
      cumSum = 0;
    }
    
    return totalCals.Sum();
  }

  static int Main(string[ ] args) {
    int totalCals = 0;
    if (File.Exists(args[0])) {
      //totalCals = part1(args[0]);
      totalCals = part2(args[0]);
    }
    Console.WriteLine("Max is: " + totalCals);
    return totalCals;
  }
}
