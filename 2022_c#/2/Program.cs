using coffee;
class Launcher
{
  static int Main(string[] args)
  {
    int result = 0;
    if (File.Exists(args[0]))
    {
      // result = (new LutGamer()).playFirstPart(File.OpenText(args[0]));
      result = (new LutGamer()).playSecondPart(File.OpenText(args[0]));
    }
    Console.WriteLine("Result is: " + result);
    return result;
  }
}