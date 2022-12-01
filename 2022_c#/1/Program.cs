using System;
using System.IO;

class A {
  static int Main(string[ ] args) {
    int totalCals = 0;
    if (File.Exists(args[0])) {
      using (StreamReader r = File.OpenText(args[0])) {
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
              Console.WriteLine("Das hat nicht geklappt!");
              return -1;
            }
          }
        }

      }
    }
    Console.WriteLine("Max is: " + totalCals);
    return totalCals;
  }
}