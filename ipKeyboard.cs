// Decompiled with JetBrains decompiler
// Type: ipKeyboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class ipKeyboard
{
  private static TouchScreenKeyboard tk;
  public static int TEXT;
  public static int NUMBERIC = 1;
  public static int PASS = 2;
  private static Command act;

  public static void openKeyBoard(string caption, int type, string text, Command action)
  {
    ipKeyboard.act = action;
    TouchScreenKeyboardType t = type == 0 || type == 2 ? TouchScreenKeyboardType.ASCIICapable : TouchScreenKeyboardType.NumberPad;
    TouchScreenKeyboard.hideInput = false;
    ipKeyboard.tk = TouchScreenKeyboard.Open(text, t, false, false, type == 2, false, caption);
  }

  public static void update()
  {
    try
    {
      if (ipKeyboard.tk == null || !ipKeyboard.tk.done)
        return;
      if (ipKeyboard.act != null)
        ipKeyboard.act.perform(ipKeyboard.tk.text);
      ipKeyboard.tk.text = string.Empty;
      ipKeyboard.tk = (TouchScreenKeyboard) null;
    }
    catch (Exception ex)
    {
    }
  }
}
