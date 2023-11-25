using System;
using System.Collections.Generic;

class Rectangle {
    public int a;
    public int b;
    public string col;

    public Rectangle(int aVal, int bVal, string colVal)
    {
      a = aVal;
      b = bVal;
      col = colVal;
    }

    public override int GetHashCode() {
        int hash = 83;
        hash *= 103 + a.GetHashCode();
        hash *= 103 + b.GetHashCode();
        return hash;
    }
}

class RectangleEqualityComparer:  EqualityComparer<Rectangle>
{
  private int comparisonType;

  public RectangleEqualityComparer(int type)
  {
    comparisonType = type;
  }

  public override bool Equals(Rectangle x, Rectangle y)
  {
    switch (comparisonType)
    {
      case 1:
        return CheckSidesEquality(x, y) && CheckColorsEquality(x, y);
      case 2:
        return CheckSidesEquality(x, y);
      case 3:
        return CheckColorsEquality(x, y) && (CheckSidesEquality(x, y) || CheckReverseSidesEquality(x, y));
      case 4:
        return CheckSidesEquality(x, y) || CheckReverseSidesEquality(x, y);
      default: 
        Console.WriteLine("de");
        return false;
    }
  }
  
  public override int GetHashCode(Rectangle r) {
    return r.GetHashCode();
  }

  private bool CheckSidesEquality(Rectangle x, Rectangle y)
  {
    return x.a == y.a && x.b == y.b;
  }

  private bool CheckReverseSidesEquality(Rectangle x, Rectangle y) => x.a == y.b && x.b == y.a;
  private bool CheckColorsEquality(Rectangle x, Rectangle y) => x.col == y.col;
}

class RectangleCollection {
    HashSet<Rectangle> r1 = new HashSet<Rectangle>(new RectangleEqualityComparer(1));
    HashSet<Rectangle> r2 = new HashSet<Rectangle>(new RectangleEqualityComparer(2));
    HashSet<Rectangle> r3 = new HashSet<Rectangle>(new RectangleEqualityComparer(3));
    HashSet<Rectangle> r4 = new HashSet<Rectangle>(new RectangleEqualityComparer(4));

    public void Add(Rectangle r)
    {
      r1.Add(r);
      r2.Add(r);
      r3.Add(r);
      r4.Add(r);
    }

    public void Count()
    {
      Console.WriteLine($"{r1.Count} {r2.Count} {r3.Count} {r4.Count}");
    }
    
    public void Present(Rectangle rect)
    {
      Console.WriteLine($"{isPresent(r1, rect)} {isPresent(r2, rect)} {isPresent(r3, rect)} {isPresent(r4, rect)}");
    }

    private string isPresent(HashSet<Rectangle> p, Rectangle r)
    {
      return p.Contains(r) ? "YES" : "NO";
    }
}

class Solution {
  public static RectangleCollection rectangleCollection = new RectangleCollection();

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
            rectangleCollection.Add(rect);
            break;
          case "COUNT":
            rectangleCollection.Count();
            break;
          case "PRESENT":
            rectangleCollection.Present(rect);
            break;
        }
  }
}