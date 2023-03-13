// Decompiled with JetBrains decompiler
// Type: Res
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Res
{
  private static short[] sinz = new short[91]
  {
    (short) 0,
    (short) 18,
    (short) 36,
    (short) 54,
    (short) 71,
    (short) 89,
    (short) 107,
    (short) 125,
    (short) 143,
    (short) 160,
    (short) 178,
    (short) 195,
    (short) 213,
    (short) 230,
    (short) 248,
    (short) 265,
    (short) 282,
    (short) 299,
    (short) 316,
    (short) 333,
    (short) 350,
    (short) 367,
    (short) 384,
    (short) 400,
    (short) 416,
    (short) 433,
    (short) 449,
    (short) 465,
    (short) 481,
    (short) 496,
    (short) 512,
    (short) 527,
    (short) 543,
    (short) 558,
    (short) 573,
    (short) 587,
    (short) 602,
    (short) 616,
    (short) 630,
    (short) 644,
    (short) 658,
    (short) 672,
    (short) 685,
    (short) 698,
    (short) 711,
    (short) 724,
    (short) 737,
    (short) 749,
    (short) 761,
    (short) 773,
    (short) 784,
    (short) 796,
    (short) 807,
    (short) 818,
    (short) 828,
    (short) 839,
    (short) 849,
    (short) 859,
    (short) 868,
    (short) 878,
    (short) 887,
    (short) 896,
    (short) 904,
    (short) 912,
    (short) 920,
    (short) 928,
    (short) 935,
    (short) 943,
    (short) 949,
    (short) 956,
    (short) 962,
    (short) 968,
    (short) 974,
    (short) 979,
    (short) 984,
    (short) 989,
    (short) 994,
    (short) 998,
    (short) 1002,
    (short) 1005,
    (short) 1008,
    (short) 1011,
    (short) 1014,
    (short) 1016,
    (short) 1018,
    (short) 1020,
    (short) 1022,
    (short) 1023,
    (short) 1023,
    (short) 1024,
    (short) 1024
  };
  private static short[] cosz;
  private static int[] tanz;
  public static int count;
  public static bool isIcon;
  public static bool isBig;
  public static MyVector debug = new MyVector();
  public static MyRandom r = new MyRandom();

  public static void init()
  {
    Res.cosz = new short[91];
    Res.tanz = new int[91];
    for (int index = 0; index <= 90; ++index)
    {
      Res.cosz[index] = Res.sinz[90 - index];
      Res.tanz[index] = Res.cosz[index] != (short) 0 ? ((int) Res.sinz[index] << 10) / (int) Res.cosz[index] : int.MaxValue;
    }
  }

  public static int sin(int a)
  {
    a = Res.fixangle(a);
    if (a >= 0 && a < 90)
      return (int) Res.sinz[a];
    if (a >= 90 && a < 180)
      return (int) Res.sinz[180 - a];
    return a >= 180 && a < 270 ? (int) -Res.sinz[a - 180] : (int) -Res.sinz[360 - a];
  }

  public static int cos(int a)
  {
    a = Res.fixangle(a);
    if (a >= 0 && a < 90)
      return (int) Res.cosz[a];
    if (a >= 90 && a < 180)
      return (int) -Res.cosz[180 - a];
    return a >= 180 && a < 270 ? (int) -Res.cosz[a - 180] : (int) Res.cosz[360 - a];
  }

  public static int tan(int a)
  {
    a = Res.fixangle(a);
    if (a >= 0 && a < 90)
      return Res.tanz[a];
    if (a >= 90 && a < 180)
      return -Res.tanz[180 - a];
    return a >= 180 && a < 270 ? Res.tanz[a - 180] : -Res.tanz[360 - a];
  }

  public static int atan(int a)
  {
    for (int index = 0; index <= 90; ++index)
    {
      if (Res.tanz[index] >= a)
        return index;
    }
    return 0;
  }

  public static int angle(int dx, int dy)
  {
    int num;
    if (dx != 0)
    {
      num = Res.atan(Math.abs((dy << 10) / dx));
      if (dy >= 0 && dx < 0)
        num = 180 - num;
      if (dy < 0 && dx < 0)
        num = 180 + num;
      if (dy < 0 && dx >= 0)
        num = 360 - num;
    }
    else
      num = dy <= 0 ? 270 : 90;
    return num;
  }

  public static int fixangle(int angle)
  {
    if (angle >= 360)
      angle -= 360;
    if (angle < 0)
      angle += 360;
    return angle;
  }

  public static void outz(string s)
  {
  }

  public static void outz2(string s)
  {
  }

  public static void onScreenDebug(string s)
  {
  }

  public static void paintOnScreenDebug(mGraphics g)
  {
  }

  public static void updateOnScreenDebug()
  {
  }

  public static string changeString(string str) => str;

  public static string replace(string _text, string _searchStr, string _replacementStr) => _text.Replace(_searchStr, _replacementStr);

  public static int xetVX(int goc, int d) => Res.cos(Res.fixangle(goc)) * d >> 10;

  public static int xetVY(int goc, int d) => Res.sin(Res.fixangle(goc)) * d >> 10;

  public static int random(int a, int b) => a == b ? a : a + Res.r.nextInt(b - a);

  public static int random(int a) => Res.r.nextInt(a);

  public static int random_Am_0(int a)
  {
    int num = 0;
    while (num == 0)
      num = Res.r.nextInt() % a;
    return num;
  }

  public static int s2tick(int currentTimeMillis)
  {
    int num = currentTimeMillis * 16 / 1000;
    if (currentTimeMillis * 16 % 1000 >= 5)
      ++num;
    return num;
  }

  public static int distance(int x1, int y1, int x2, int y2) => Res.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

  public static int sqrt(int a)
  {
    if (a <= 0)
      return 0;
    int num1 = (a + 1) / 2;
    int num2;
    do
    {
      num2 = num1;
      num1 = num1 / 2 + a / (2 * num1);
    }
    while (Math.abs(num2 - num1) > 1);
    return num1;
  }

  public static int rnd(int a) => Res.r.nextInt(a);

  public static int abs(int i) => i > 0 ? i : -i;

  public static bool inRect(int x1, int y1, int width, int height, int x2, int y2) => x2 >= x1 && x2 <= x1 + width && y2 >= y1 && y2 <= y1 + height;

  public static string[] split(string original, string separator, int count)
  {
    int length = original.IndexOf(separator);
    string[] strArray;
    if (length >= 0)
    {
      strArray = Res.split(original.Substring(length + separator.Length), separator, count + 1);
    }
    else
    {
      strArray = new string[count + 1];
      length = original.Length;
    }
    strArray[count] = original.Substring(0, length);
    return strArray;
  }

  public static string formatNumber(long number)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    empty1 = string.Empty;
    string str1;
    if (number >= 1000000000L)
    {
      string billion = mResources.billion;
      long num = number % 1000000000L / 100000000L;
      number /= 1000000000L;
      string str2 = number.ToString() + string.Empty;
      if (num > 0L)
        str1 = str2 + "," + (object) num + billion;
      else
        str1 = str2 + billion;
    }
    else if (number >= 1000000L)
    {
      string million = mResources.million;
      long num = number % 1000000L / 100000L;
      number /= 1000000L;
      string str3 = number.ToString() + string.Empty;
      if (num > 0L)
        str1 = str3 + "," + (object) num + million;
      else
        str1 = str3 + million;
    }
    else
      str1 = number.ToString() + string.Empty;
    return str1;
  }

  public static string formatNumber2(long number)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    empty1 = string.Empty;
    string str1;
    if (number >= 1000000000L)
    {
      string billion = mResources.billion;
      long num = number % 1000000000L / 10000000L;
      number /= 1000000000L;
      string str2 = number.ToString() + string.Empty;
      if (num >= 10L)
      {
        if (num % 10L == 0L)
          num /= 10L;
        str1 = str2 + "," + (object) num + billion;
      }
      else if (num > 0L)
        str1 = str2 + ",0" + (object) num + billion;
      else
        str1 = str2 + billion;
    }
    else if (number >= 1000000L)
    {
      string million = mResources.million;
      long num = number % 1000000L / 10000L;
      number /= 1000000L;
      string str3 = number.ToString() + string.Empty;
      if (num >= 10L)
      {
        if (num % 10L == 0L)
          num /= 10L;
        str1 = str3 + "," + (object) num + million;
      }
      else if (num > 0L)
        str1 = str3 + ",0" + (object) num + million;
      else
        str1 = str3 + million;
    }
    else if (number >= 10000L)
    {
      string str4 = "k";
      long num = number % 1000L / 10L;
      number /= 1000L;
      string str5 = number.ToString() + string.Empty;
      if (num >= 10L)
      {
        if (num % 10L == 0L)
          num /= 10L;
        str1 = str5 + "," + (object) num + str4;
      }
      else if (num > 0L)
        str1 = str5 + ",0" + (object) num + str4;
      else
        str1 = str5 + str4;
    }
    else
      str1 = number.ToString() + string.Empty;
    return str1;
  }
}
