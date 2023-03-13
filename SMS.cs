// Decompiled with JetBrains decompiler
// Type: SMS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Threading;
using UnityEngine;

public class SMS
{
  private const int INTERVAL = 5;
  private const int MAXTIME = 500;
  private static int status;
  private static int _result;
  private static string _to;
  private static string _content;
  private static bool f;
  private static int time;
  public static bool sendEnable;
  private static int time0;

  public static int send(string content, string to) => Thread.CurrentThread.Name == Main.mainThreadName ? SMS.__send(content, to) : SMS._send(content, to);

  private static int _send(string content, string to)
  {
    if (SMS.status != 0)
    {
      for (int index = 0; index < 500; ++index)
      {
        Thread.Sleep(5);
        if (SMS.status == 0)
          break;
      }
      if (SMS.status != 0)
      {
        Cout.LogError("CANNOT SEND SMS " + content + " WHEN SENDING " + SMS._content);
        return -1;
      }
    }
    SMS._content = content;
    SMS._to = to;
    SMS._result = -1;
    SMS.status = 2;
    int num;
    for (num = 0; num < 500; ++num)
    {
      Thread.Sleep(5);
      if (SMS.status == 0)
        break;
    }
    if (num == 500)
    {
      Debug.LogError((object) ("TOO LONG FOR SEND SMS " + content));
      SMS.status = 0;
    }
    else
      Debug.Log((object) ("Send SMS " + content + " done in " + (object) (num * 5) + "ms"));
    return SMS._result;
  }

  private static int __send(string content, string to)
  {
    int n = iOSPlugins.Check();
    Cout.println("vao sms ko " + (object) n);
    if (n >= 0)
    {
      SMS.f = true;
      SMS.sendEnable = true;
      iOSPlugins.SMSsend(to, content, n);
      Screen.orientation = ScreenOrientation.AutoRotation;
    }
    return n;
  }

  public static void update()
  {
    if ((double) Time.time - (double) SMS.time > 1.0)
      ++SMS.time;
    if (SMS.f)
      SMS.OnSMS();
    if (SMS.status != 2)
      return;
    SMS.status = 1;
    try
    {
      SMS._result = SMS.__send(SMS._content, SMS._to);
    }
    catch (Exception ex)
    {
      Debug.Log((object) "CANNOT SEND SMS");
    }
    SMS.status = 0;
  }

  private static void OnSMS()
  {
    if (SMS.sendEnable)
    {
      if (iOSPlugins.checkRotation() == 1)
        Screen.orientation = ScreenOrientation.LandscapeLeft;
      else if (iOSPlugins.checkRotation() == -1)
        Screen.orientation = ScreenOrientation.Portrait;
      else if (iOSPlugins.checkRotation() == 0)
        Screen.orientation = ScreenOrientation.AutoRotation;
      else if (iOSPlugins.checkRotation() == 2)
        Screen.orientation = ScreenOrientation.LandscapeRight;
      else if (iOSPlugins.checkRotation() == 3)
        Screen.orientation = ScreenOrientation.PortraitUpsideDown;
      if (SMS.time0 < 5)
      {
        ++SMS.time0;
      }
      else
      {
        iOSPlugins.Send();
        SMS.sendEnable = false;
        SMS.time0 = 0;
      }
    }
    if (iOSPlugins.unpause() != 1)
      return;
    Screen.orientation = ScreenOrientation.LandscapeLeft;
    if (SMS.time0 < 5)
    {
      ++SMS.time0;
    }
    else
    {
      SMS.f = false;
      iOSPlugins.back();
      SMS.time0 = 0;
    }
  }
}
