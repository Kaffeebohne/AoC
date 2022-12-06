namespace coffee
{
  public class ThePack
  {
    string m_comp1, m_comp2;
    int r = 0;
    public int analyse(string inventory)
    {
      int totalItems = inventory.Length;
      m_comp1 = inventory.Substring(0, totalItems / 2);
      m_comp2 = inventory.Substring(totalItems / 2);
      //   Console.WriteLine("Splittet into: \n{0}\n{1}", m_comp1, m_comp2);
      int[] seen = new int[52];
      for (int i = 0; i < 52; ++i)
      {
        seen[i] = 0;
      }
      int p;
      for (int i = 0; i < totalItems / 2; ++i)
      {
        p = ((byte)m_comp1[i]);
        seen[p >= 'a' && p <= 'z' ? p - 'a' : p - 'A' + 'z' - 'a' + 1] |= 1;
        p = ((byte)m_comp2[i]);
        seen[p >= 'a' && p <= 'z' ? p - 'a' : p - 'A' + 'z' - 'a' + 1] |= 2;
      }

      for (int i = 0; i < 52; ++i)
      {
        if (seen[i] == 3)
        {
          r = i < 26 ? i + 'a' : i + 'A' - 26;
          ++i;
          //   Console.WriteLine("{0}({1})", i, (char)r);
          r = i;
        }
      }

      return r;
    }

    public int analyseGroup(string[] inventories)
    {
      int r = 0;
      int[] seen = new int[52];
      for (int i = 0; i < 52; ++i)
      {
        seen[i] = 0;
      }

      int p;
      for (int i = 0; i < inventories.Length; ++i)
      {
        // Console.WriteLine("{0}: {1}", i, inventories[i]);
        for (int j = 0; j < inventories[i].Length; ++j)
        {
          p = inventories[i][j];
          seen[p >= 'a' && p <= 'z' ? p - 'a' : p - 'A' + 'z' - 'a' + 1] |= 1 << i;
        }
      }

      int checkval = (1 << inventories.Length) - 1;
      for (int i = 0; i < 52; ++i)
      {
        if (seen[i] == checkval)
        {
          r = i < 26 ? i + 'a' : i + 'A' - 26;
          ++i;
          //   Console.WriteLine("{0}({1})", i, (char)r);
          r = i;
        }
      }
      //   Console.WriteLine("########################");
      return r;
    }

  }
}