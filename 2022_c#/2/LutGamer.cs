namespace coffee
{
  public class LutGamer
  {
    enum E_Sym : int { eDraw = 3, eWin = 6, e_Loss = 0 };

    int[] m_lut = {
        //AX                    AY                      AZ
        ((int)E_Sym.eDraw),     ((int)E_Sym.eWin),      ((int)E_Sym.e_Loss),
        //BX                    BY                      BZ
        ((int)E_Sym.e_Loss),    ((int)E_Sym.eDraw),     ((int)E_Sym.eWin),
        //CX                    CY                      CZ
        ((int)E_Sym.eWin),      ((int)E_Sym.e_Loss),    ((int)E_Sym.eDraw),
    };

    char[] m_lut2 = {
        'C', 'A', 'B',//AX AY AZ
        'A', 'B', 'C',//BX BY BZ
        'B', 'C', 'A' //CX CY CZ
    };

    public int playFirstPart(StreamReader strategyGuide)
    {
      int r = 0;
      int t, v, i;
      string ln;
      char a, b;

      while ((ln = strategyGuide.ReadLine()) != null)
      {
        // Console.WriteLine("Read: " + ln);
        a = ln.First();
        b = ln.Last();
        i = 3 * (a - 'A') + b - 'X';
        // Console.WriteLine("idx: {2}\nI: {0}\nO: {1}", a, b, i);
        t = m_lut[i]; v = b - 'X' + 1; r += t + v;
        // Console.WriteLine("t: {0}\nv: {1}\nr: {2}", t, v, r);
        // Console.WriteLine("##################");
      }

      return r;
    }

    public int playSecondPart(StreamReader strategyGuide)
    {
      int r = 0;
      string ln;
      char a, b, outcome;
      int t, v, i;

      while ((ln = strategyGuide.ReadLine()) != null)
      {
        a = ln.First(); outcome = ln.Last(); b = m_lut2[(i = 3 * (a - 'A')) + outcome - 'X'];
        // Console.WriteLine("{0} -> {1}", ln, b);
        t = m_lut[i + b - 'A']; v = b - 'A' + 1; r += t + v;
        // Console.WriteLine("t: {0}\nv: {1}\nr: {2}", t, v, r);
        // Console.WriteLine("##################");
      }

      return r;
    }
  }
}