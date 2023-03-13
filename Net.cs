// Decompiled with JetBrains decompiler
// Type: Net
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

internal class Net
{
  public static WWW www;
  public static Command h;

  public static void update()
  {
    if (Net.www == null || !Net.www.isDone)
      return;
    string str = string.Empty;
    if (Net.www.error == null || Net.www.error.Equals(string.Empty))
      str = Net.www.text;
    Net.www = (WWW) null;
    if (Net.h == null)
      return;
    Net.h.perform(str);
  }

  public static void connectHTTP(string link, Command h)
  {
    if (Net.www != null)
      Cout.LogError("GET HTTP BUSY");
    Net.www = new WWW(link);
    Net.h = h;
  }

  public static void connectHTTP2(string link, Command h)
  {
    Net.h = h;
    if (link == null)
      return;
    h.perform(link);
  }
}
