// Decompiled with JetBrains decompiler
// Type: mSystem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Text;
using UnityEngine;

public class mSystem
{
  public static bool isTest;
  public static string strAdmob;
  public static bool loadAdOk;
  public static string publicID;
  public static string android_pack;
  public static int clientType = 4;
  public static sbyte LANGUAGE;
  public static sbyte curINAPP;
  public static sbyte maxINAPP = 5;
  public const int JAVA = 1;
  public const int ANDROID = 2;
  public const int IP_JB = 3;
  public const int PC = 4;
  public const int IP_APPSTORE = 5;
  public const int WINDOWS_PHONE = 6;
  public const int GOOGLE_PLAY = 7;
  public static mSystem instance;

  public static void resetCurInapp() => mSystem.curINAPP = (sbyte) 0;

  public static void LogCMD(string st)
  {
  }

  public static string getTimeCountDown(
    long timeStart,
    int secondCount,
    bool isOnlySecond,
    bool isShortText)
  {
    string timeCountDown = string.Empty;
    long num1 = (timeStart + (long) (secondCount * 1000) - mSystem.currentTimeMillis()) / 1000L;
    if (num1 <= 0L)
      return string.Empty;
    long num2 = 0;
    long num3 = 0;
    long num4 = num1 / 60L;
    long num5 = num1;
    if (isOnlySecond)
      return num5.ToString() + string.Empty;
    if (num1 >= 86400L)
    {
      num2 = num1 / 86400L;
      num3 = num1 % 86400L / 3600L;
    }
    else if (num1 >= 3600L)
    {
      num3 = num1 / 3600L;
      num4 = num1 % 3600L / 60L;
    }
    else if (num1 >= 60L)
    {
      num4 = num1 / 60L;
      num5 = num1 % 60L;
    }
    else
      num5 = num1;
    if (isShortText)
    {
      if (num2 > 0L)
        return num2.ToString() + "d";
      if (num3 > 0L)
        return num3.ToString() + "h";
      if (num4 > 0L)
        return num4.ToString() + "m";
      if (num5 > 0L)
        return num5.ToString() + "s";
    }
    if (num2 > 0L)
    {
      if (num2 >= 10L)
      {
        if (num3 < 1L)
          timeCountDown = num2.ToString() + "d";
        else if (num3 < 10L)
          timeCountDown = num2.ToString() + "d0" + (object) num3 + "h";
        else
          timeCountDown = num2.ToString() + "d" + (object) num3 + "h";
      }
      else if (num2 < 10L)
      {
        if (num3 < 1L)
          timeCountDown = num2.ToString() + "d";
        else if (num3 < 10L)
          timeCountDown = num2.ToString() + "d0" + (object) num3 + "h";
        else
          timeCountDown = num2.ToString() + "d" + (object) num3 + "h";
      }
    }
    else if (num3 > 0L)
    {
      if (num3 >= 10L)
      {
        if (num4 < 1L)
          timeCountDown = num3.ToString() + "h";
        else if (num4 < 10L)
          timeCountDown = num3.ToString() + "h0" + (object) num4 + "m";
        else
          timeCountDown = num3.ToString() + "h" + (object) num4 + "m";
      }
      else if (num3 < 10L)
      {
        if (num4 < 1L)
          timeCountDown = num3.ToString() + "h";
        else if (num4 < 10L)
          timeCountDown = num3.ToString() + "h0" + (object) num4 + "m";
        else
          timeCountDown = num3.ToString() + "h" + (object) num4 + "m";
      }
    }
    else if (num4 > 0L)
    {
      if (num4 >= 10L)
      {
        if (num5 >= 10L)
          timeCountDown = num4.ToString() + "m" + (object) num5 + string.Empty;
        else if (num5 < 10L)
          timeCountDown = num4.ToString() + "m0" + (object) num5 + string.Empty;
      }
      else if (num4 < 10L)
      {
        if (num5 >= 10L)
          timeCountDown = num4.ToString() + "m" + (object) num5 + string.Empty;
        else if (num5 < 10L)
          timeCountDown = num4.ToString() + "m0" + (object) num5 + string.Empty;
      }
    }
    else
      timeCountDown = num5 >= 10L ? num5.ToString() + string.Empty : "0" + (object) num5 + string.Empty;
    return timeCountDown;
  }

  public static string numberTostring2(int aa)
  {
    try
    {
      string str1 = string.Empty;
      string str2 = string.Empty;
      string str3 = aa.ToString() + string.Empty;
      if (str3.Equals(string.Empty))
        return str1;
      if (str3[0] == '-')
      {
        str2 = "-";
        str3 = str3.Substring(1);
      }
      for (int index = str3.Length - 1; index >= 0; --index)
        str1 = (str3.Length - 1 - index) % 3 != 0 || str3.Length - 1 - index <= 0 ? str3[index].ToString() + str1 : str3[index].ToString() + "." + str1;
      return str2 + str1;
    }
    catch (Exception ex)
    {
      return aa.ToString() + string.Empty;
    }
  }

  public static string numberTostring(long number)
  {
    string str1 = string.Empty + (object) number;
    bool flag = false;
    try
    {
      string empty = string.Empty;
      if (number < 0L)
      {
        flag = true;
        number = -number;
        str1 = string.Empty + (object) number;
      }
      string str2;
      int length;
      if (number >= 1000000000L)
      {
        str2 = "b";
        number /= 1000000000L;
        length = (string.Empty + (object) number).Length;
      }
      else if (number >= 1000000L)
      {
        str2 = "m";
        number /= 1000000L;
        length = (string.Empty + (object) number).Length;
      }
      else if (number >= 1000L)
      {
        str2 = "k";
        number /= 1000L;
        length = (string.Empty + (object) number).Length;
      }
      else
        return flag ? "-" + str1 : str1;
      int num = int.Parse(str1.Substring(length, 2));
      str1 = num != 0 ? (num % 10 != 0 ? str1.Substring(0, length) + "," + str1.Substring(length, 2) + str2 : str1.Substring(0, length) + "," + str1.Substring(length, 1) + str2) : str1.Substring(0, length) + str2;
    }
    catch (Exception ex)
    {
    }
    return flag ? "-" + str1 : str1;
  }

  public static void callHotlinePC() => Application.OpenURL("http://ngocrongonline.com/");

  public static void callHotlineJava()
  {
  }

  public static void callHotlineIphone()
  {
  }

  public static void callHotlineWindowsPhone()
  {
  }

  public static void closeBanner()
  {
  }

  public static void showBanner()
  {
  }

  public static void createAdmob()
  {
  }

  public static void checkAdComlete()
  {
  }

  public static void paintPopUp2(mGraphics g, int x, int y, int w, int h) => g.fillRect(x, y, w + 10, h, 0, 90);

  public static void arraycopy(sbyte[] scr, int scrPos, sbyte[] dest, int destPos, int lenght) => Array.Copy((Array) scr, scrPos, (Array) dest, destPos, lenght);

  public static void arrayReplace(
    sbyte[] scr,
    int scrPos,
    ref sbyte[] dest,
    int destPos,
    int lenght)
  {
    if (scr == null || dest == null || scrPos + lenght > scr.Length)
      return;
    sbyte[] numArray = new sbyte[dest.Length + lenght];
    for (int index = 0; index < destPos; ++index)
      numArray[index] = dest[index];
    for (int index = destPos; index < destPos + lenght; ++index)
      numArray[index] = scr[scrPos + index - destPos];
    for (int index = destPos + lenght; index < numArray.Length; ++index)
      numArray[index] = dest[destPos + index - lenght];
  }

  public static long currentTimeMillis() => (DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks) / 10000L;

  public static void freeData()
  {
    Resources.UnloadUnusedAssets();
    GC.Collect();
  }

  public static sbyte[] convertToSbyte(byte[] scr)
  {
    sbyte[] numArray = new sbyte[scr.Length];
    for (int index = 0; index < scr.Length; ++index)
      numArray[index] = (sbyte) scr[index];
    return numArray;
  }

  public static sbyte[] convertToSbyte(string scr) => mSystem.convertToSbyte(new ASCIIEncoding().GetBytes(scr));

  public static byte[] convetToByte(sbyte[] scr)
  {
    byte[] numArray = new byte[scr.Length];
    for (int index = 0; index < scr.Length; ++index)
      numArray[index] = scr[index] <= (sbyte) 0 ? (byte) ((uint) scr[index] + 256U) : (byte) scr[index];
    return numArray;
  }

  public static char[] ToCharArray(sbyte[] scr)
  {
    char[] charArray = new char[scr.Length];
    for (int index = 0; index < scr.Length; ++index)
      charArray[index] = (char) scr[index];
    return charArray;
  }

  public static int currentHour() => DateTime.Now.Hour;

  public static void println(object str) => Debug.Log(str);

  public static void gcc()
  {
    Resources.UnloadUnusedAssets();
    GC.Collect();
  }

  public static mSystem gI()
  {
    if (mSystem.instance == null)
      mSystem.instance = new mSystem();
    return mSystem.instance;
  }

  public static void onConnectOK() => Controller.isConnectOK = true;

  public static void onConnectionFail() => Controller.isConnectionFail = true;

  public static void onDisconnected() => Controller.isDisconnected = true;

  public static void exitWP()
  {
  }

  public static void paintFlyText(mGraphics g)
  {
    for (int index = 0; index < 5; ++index)
    {
      if (GameScr.flyTextState[index] != -1 && GameCanvas.isPaint(GameScr.flyTextX[index], GameScr.flyTextY[index]))
      {
        if (GameScr.flyTextColor[index] == mFont.RED)
          mFont.bigNumber_red.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER);
        else if (GameScr.flyTextColor[index] == mFont.YELLOW)
          mFont.bigNumber_yellow.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER);
        else if (GameScr.flyTextColor[index] == mFont.GREEN)
          mFont.bigNumber_green.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER);
        else if (GameScr.flyTextColor[index] == mFont.FATAL)
          mFont.bigNumber_yellow.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER, mFont.bigNumber_black);
        else if (GameScr.flyTextColor[index] == mFont.FATAL_ME)
          mFont.bigNumber_green.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER, mFont.bigNumber_black);
        else if (GameScr.flyTextColor[index] == mFont.MISS)
          mFont.bigNumber_While.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER, mFont.tahoma_7_grey);
        else if (GameScr.flyTextColor[index] == mFont.ORANGE)
          mFont.bigNumber_orange.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER);
        else if (GameScr.flyTextColor[index] == mFont.ADDMONEY)
          mFont.bigNumber_yellow.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER, mFont.bigNumber_black);
        else if (GameScr.flyTextColor[index] == mFont.MISS_ME)
          mFont.bigNumber_While.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER, mFont.bigNumber_black);
        else if (GameScr.flyTextColor[index] == mFont.HP)
          mFont.bigNumber_red.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER, mFont.bigNumber_black);
        else if (GameScr.flyTextColor[index] == mFont.MP)
          mFont.bigNumber_blue.drawStringBorder(g, GameScr.flyTextString[index], GameScr.flyTextX[index], GameScr.flyTextY[index], mFont.CENTER, mFont.bigNumber_black);
      }
    }
  }

  public static void endKey()
  {
  }

  public static FrameImage getFraImage(string nameImg)
  {
    FrameImage fraImage = (FrameImage) null;
    MainImage mainImage = (MainImage) null ?? ImgByName.getImagePath(nameImg, ImgByName.hashImagePath);
    if (mainImage.img != null)
    {
      int height = mainImage.img.getHeight() / (int) mainImage.nFrame;
      if (height < 1)
        height = 1;
      fraImage = new FrameImage(mainImage.img, mainImage.img.getWidth(), height);
    }
    return fraImage;
  }

  public static Image loadImage(string path) => GameCanvas.loadImage(path);
}
