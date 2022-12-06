using coffee;

class Launcher
{
  static int Main(string[] args)
  {
    int result = 0;
    // BackPack bp = new BackPack();
    ThePack tp = new ThePack();
    string ln;
    if (File.Exists(args[0]))
    {
      StreamReader r = File.OpenText(args[0]);
      while ((ln = r.ReadLine()) != null)
      {
        // Console.WriteLine("In: {0}", ln);
        // result += tp.analyse(ln);
        result += tp.analyseGroup(new string[] { ln, r.ReadLine(), r.ReadLine() });
      }
    }
    Console.WriteLine("Result is: " + result);
    return result;
  }
}