using System;
using System.Collections.Generic;

class Rectangle {
    public int a;
    public int b;
    public string col;

    public Rectangle(int aVal, int bVal, string colVal) {
      a = aVal;
      b = bVal;
      col = colVal;
    }

    public override int GetHashCode() {
        int hash = 83;
        hash *= 103 + a.GetHashCode();
        hash *= 103 + b.GetHashCode();
        hash *= 103 + col.GetHashCode();
        return hash;
    }

    public override bool Equals(object obj) {
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }

      Rectangle r = (Rectangle)obj;
      
      bool equalityCheck = a == r.a && b == r.b && col == r.col;
      bool reverseEqualityCheck = a == r.b && b == r.a && col == r.col;

      return equalityCheck || reverseEqualityCheck;
    }
}

class Solution {
  public static HashSet<Rectangle> dataSet = new HashSet<Rectangle>();

  public static void Main(string[] args) {
      int number = Convert.ToInt32(Console.ReadLine()); 
      
      for (int  i = 0; i < number; i++) {
        string[] line = Console.ReadLine().Split();
        string operation = line[0];
        if (line.Length > 1) {
          int a = int.Parse(line[1]);
          int b = int.Parse(line[2]);
          string col = line[3];
          Rectangle rect = new Rectangle(a,b,col);
          ProcessOperation(operation, rect);
        } else {
          ProcessOperation(operation, new Rectangle(0, 0, ""));
        }
      }
  }

  public static void ProcessOperation(string operation, Rectangle rect) {
     switch (operation) {
          case "ADD":
            dataSet.Add(rect);
            break;
          case "COUNT":
            Console.WriteLine(dataSet.Count);
            break;
          case "PRESENT":
            if (dataSet.Contains(rect)) {
              Console.WriteLine("YES");
            }  else {
              Console.WriteLine("NO");
            }
            break;
        }
  }
}
