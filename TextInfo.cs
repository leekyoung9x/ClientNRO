// Decompiled with JetBrains decompiler
// Type: TextInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class TextInfo
{
  public static int dx;
  public static int tx;
  public static int wStr;
  public static bool isBack;
  public static string laststring = string.Empty;

  public static void reset()
  {
    TextInfo.dx = 0;
    TextInfo.tx = 0;
    TextInfo.isBack = false;
  }

  public static void paint(mGraphics g, string str, int x, int y, int w, int h, mFont f)
  {
    if (TextInfo.wStr != f.getWidth(str) || !TextInfo.laststring.Equals(str))
    {
      TextInfo.laststring = str;
      TextInfo.dx = 0;
      TextInfo.wStr = f.getWidth(str);
      TextInfo.isBack = false;
      TextInfo.tx = 0;
    }
    g.setClip(x, y, w, h);
    if (TextInfo.wStr > w)
      f.drawString(g, str, x - TextInfo.dx, y, 0);
    else
      f.drawString(g, str, x + w / 2, y, 2);
    GameCanvas.resetTrans(g);
    if (TextInfo.wStr <= w)
      return;
    if (!TextInfo.isBack)
    {
      ++TextInfo.tx;
      if (TextInfo.tx <= 50)
        return;
      ++TextInfo.dx;
      if (TextInfo.dx < TextInfo.wStr)
        return;
      TextInfo.tx = 0;
      TextInfo.dx = -w + 30;
      TextInfo.isBack = true;
    }
    else
    {
      if (TextInfo.dx < 0)
      {
        int num = w + TextInfo.dx >> 1;
        TextInfo.dx += num;
      }
      if (TextInfo.dx > 0)
        TextInfo.dx = 0;
      if (TextInfo.dx != 0)
        return;
      ++TextInfo.tx;
      if (TextInfo.tx != 50)
        return;
      TextInfo.tx = 0;
      TextInfo.isBack = false;
    }
  }
}
