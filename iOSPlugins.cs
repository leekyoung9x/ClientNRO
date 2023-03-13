// Decompiled with JetBrains decompiler
// Type: iOSPlugins
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class iOSPlugins
{
  public static string devide;
  public static string Myname;

  [DllImport("__Internal")]
  private static extern void _SMSsend(string tophone, string withtext, int n);

  [DllImport("__Internal")]
  private static extern int _unpause();

  [DllImport("__Internal")]
  private static extern int _checkRotation();

  [DllImport("__Internal")]
  private static extern int _back();

  [DllImport("__Internal")]
  private static extern int _Send();

  [DllImport("__Internal")]
  private static extern void _purchaseItem(string itemID, string userName, string gameID);

  public static int Check()
  {
    if (Application.platform == RuntimePlatform.IPhonePlayer)
      return iOSPlugins.checkCanSendSMS();
    iOSPlugins.devide = iPhoneSettings.generation.ToString();
    if (string.Empty + (object) iOSPlugins.devide[2] == "h" && iOSPlugins.devide.Length > 6)
    {
      iOSPlugins.Myname = SystemInfo.operatingSystem.ToString();
      string str = string.Empty + (object) iOSPlugins.Myname[10];
      return str != "2" && str != "3" ? 0 : 1;
    }
    Cout.println(iOSPlugins.devide + "  loai");
    return iOSPlugins.devide == "Unknown" && (double) ScaleGUI.WIDTH * (double) ScaleGUI.HEIGHT < 786432.0 ? 0 : -1;
  }

  public static int checkCanSendSMS() => iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation == iPhoneGeneration.iPhone4S || iPhoneSettings.generation == iPhoneGeneration.iPhone5 ? 0 : -1;

  public static void SMSsend(string phonenumber, string bodytext, int n)
  {
    if (Application.platform == RuntimePlatform.OSXEditor)
      return;
    iOSPlugins._SMSsend(phonenumber, bodytext, n);
  }

  public static void back()
  {
    if (Application.platform == RuntimePlatform.OSXEditor)
      return;
    iOSPlugins._back();
  }

  public static void Send()
  {
    if (Application.platform == RuntimePlatform.OSXEditor)
      return;
    iOSPlugins._Send();
  }

  public static int unpause() => Application.platform != RuntimePlatform.OSXEditor ? iOSPlugins._unpause() : 0;

  public static int checkRotation() => Application.platform != RuntimePlatform.OSXEditor ? iOSPlugins._checkRotation() : 0;

  public static void purchaseItem(string itemID, string userName, string gameID)
  {
    if (Application.platform == RuntimePlatform.OSXEditor)
      return;
    iOSPlugins._purchaseItem(itemID, userName, gameID);
  }
}
