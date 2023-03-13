// Decompiled with JetBrains decompiler
// Type: NinjaUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class NinjaUtil
{
  public static void onLoadMapComplete() => GameCanvas.endDlg();

  public void onLoading() => GameCanvas.startWaitDlg(mResources.downloading_data);

  public static int randomNumber(int max) => new MyRandom().nextInt(max);

  public static sbyte[] readByteArray(Message msg)
  {
    try
    {
      sbyte[] data = new sbyte[msg.reader().readInt()];
      msg.reader().read(ref data);
      return data;
    }
    catch (Exception ex)
    {
      Cout.LogError("LOI DOC readByteArray NINJAUTIL");
    }
    return (sbyte[]) null;
  }

  public static sbyte[] readByteArray(myReader dos)
  {
    try
    {
      sbyte[] data = new sbyte[dos.readInt()];
      dos.read(ref data);
      return data;
    }
    catch (Exception ex)
    {
      Cout.LogError("LOI DOC readByteArray dos  NINJAUTIL");
    }
    return (sbyte[]) null;
  }

  public static string replace(string text, string regex, string replacement) => text.Replace(regex, replacement);

  public static string numberTostring(string number)
  {
    string str1 = string.Empty;
    string str2 = string.Empty;
    if (number.Equals(string.Empty))
      return str1;
    if (number[0] == '-')
    {
      str2 = "-";
      number = number.Substring(1);
    }
    for (int index = number.Length - 1; index >= 0; --index)
      str1 = (number.Length - 1 - index) % 3 != 0 || number.Length - 1 - index <= 0 ? number[index].ToString() + str1 : number[index].ToString() + "." + str1;
    return str2 + str1;
  }

  public static string getDate(int second)
  {
    DateTime universalTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Add(new TimeSpan((long) second * 1000L * 10000L)).ToUniversalTime();
    int hour = universalTime.Hour;
    int minute = universalTime.Minute;
    return universalTime.Day.ToString() + "/" + (object) universalTime.Month + "/" + (object) universalTime.Year + " " + (object) hour + "h";
  }

  public static string getDate2(long second)
  {
    DateTime universalTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Add(new TimeSpan((second + 25200000L) * 10000L)).ToUniversalTime();
    return universalTime.Hour.ToString() + "h" + (object) universalTime.Minute + "m";
  }

  public static string getTime(int timeRemainS)
  {
    int num1 = 0;
    if (timeRemainS > 60)
    {
      num1 = timeRemainS / 60;
      timeRemainS %= 60;
    }
    int num2 = 0;
    if (num1 > 60)
    {
      num2 = num1 / 60;
      num1 %= 60;
    }
    int num3 = 0;
    if (num2 > 24)
    {
      num3 = num2 / 24;
      num2 %= 24;
    }
    string empty = string.Empty;
    string time;
    if (num3 > 0)
      time = empty + (object) num3 + "d" + (object) num2 + "h";
    else if (num2 > 0)
    {
      time = empty + (object) num2 + "h" + (object) num1 + "'";
    }
    else
    {
      string str = (num1 <= 9 ? empty + "0" + (object) num1 : empty + (object) num1) + ":";
      time = timeRemainS <= 9 ? str + "0" + (object) timeRemainS : str + (object) timeRemainS;
    }
    return time;
  }

  public static string getMoneys(long m)
  {
    string moneys = string.Empty;
    long num1 = m / 1000L + 1L;
    for (int index = 0; (long) index < num1; ++index)
    {
      if (m >= 1000L)
      {
        long num2 = m % 1000L;
        moneys = num2 != 0L ? (num2 >= 10L ? (num2 >= 100L ? "." + (object) num2 + moneys : ".0" + (object) num2 + moneys) : ".00" + (object) num2 + moneys) : ".000" + moneys;
        m /= 1000L;
      }
      else
      {
        moneys = m.ToString() + moneys;
        break;
      }
    }
    return moneys;
  }

  public static string getTimeAgo(int timeRemainS)
  {
    int num1 = 0;
    if (timeRemainS > 60)
    {
      num1 = timeRemainS / 60;
      timeRemainS %= 60;
    }
    int num2 = 0;
    if (num1 > 60)
    {
      num2 = num1 / 60;
      num1 %= 60;
    }
    int num3 = 0;
    if (num2 > 24)
    {
      num3 = num2 / 24;
      num2 %= 24;
    }
    string empty = string.Empty;
    string timeAgo;
    if (num3 > 0)
      timeAgo = empty + (object) num3 + "d" + (object) num2 + "h";
    else if (num2 > 0)
    {
      timeAgo = empty + (object) num2 + "h" + (object) num1 + "'";
    }
    else
    {
      if (num1 == 0)
        num1 = 1;
      timeAgo = empty + (object) num1 + "ph";
    }
    return timeAgo;
  }

  public static string[] split(string original, string separator)
  {
    MyVector myVector = new MyVector();
    for (int length = original.IndexOf(separator); length >= 0; length = original.IndexOf(separator))
    {
      myVector.addElement((object) original.Substring(0, length));
      original = original.Substring(length + separator.Length);
    }
    myVector.addElement((object) original);
    string[] strArray = new string[myVector.size()];
    if (myVector.size() > 0)
    {
      for (int index = 0; index < myVector.size(); ++index)
        strArray[index] = (string) myVector.elementAt(index);
    }
    return strArray;
  }
}
