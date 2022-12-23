namespace coffee
{

public class T_Section
{
  int start;
  int end;

  public T_Section()
  {
    start = -1;
    end = -1;
  }

  public void newvalues(string inp)
  {
    int pos = inp.IndexOf("-");
    start = Int32.Parse(inp.Substring(0, pos));
    end = Int32.Parse(inp.Substring(pos + 1));
    //Console.WriteLine("I: {0}\nS: {1}\nE: {2}", inp, start, end);
  }

  public int contains(T_Section other)
  {
    return this.start <= other.start && this.end >=other.end ? 1 : 0;
  }

  public int isequal(T_Section other)
  {
    return this.start == other.start && this.end ==other.end ? 1 : 0;
  }

  public int overlaps(T_Section other)
  {
    T_Section l, r;
    if (this.start < other.start)
    {
      l = this; r = other;
    } else if (this.start == other.start)
    {
      if (this.end <= other.end)
      {
        l = this; r = other;
      } else
      {
        l = other; r = this;
      }
    } else
    {
      l = other; r = this;
    }

    return l.start < r.start && l.end >= r.start && l.end < r.end ? 1 : 0;
  }

  public override string ToString()
  {
    return start + "-" + end;
  }
}

public class Launcher
{
  public static bool contains(T_Section a, T_Section b)
  {
    return false;
  }

  public static int Main(string[] args)
  {
    int result = 0, pos = 0, t = 0;
    T_Section a = new T_Section(), b = new T_Section();
    string ln;
    if (File.Exists(args[0]))
    {
      StreamReader r = File.OpenText(args[0]);
      while ((ln = r.ReadLine()) != null)
      {
        pos = ln.IndexOf(",");
        a.newvalues(ln.Substring(0,pos));
        b.newvalues(ln.Substring(pos + 1));
        // Part   ONE (not checked which interval comes first) + TWO (checked)
        result += a.contains(b) + b.contains(a) - a.isequal(b) + a.overlaps(b);
      }
    }

    Console.WriteLine("Result is: " + result);
    return result;
  }
}
}