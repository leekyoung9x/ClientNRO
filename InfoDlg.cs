// Decompiled with JetBrains decompiler
// Type: InfoDlg
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class InfoDlg
{
  public static bool isShow;
  private static string title;
  private static string subtitke;
  public static int delay;
  public static bool isLock;

  public static void show(string title, string subtitle, int delay)
  {
    if (title == null)
      return;
    InfoDlg.isShow = true;
    InfoDlg.title = title;
    InfoDlg.subtitke = subtitle;
    InfoDlg.delay = delay;
  }

  public static void showWait()
  {
    InfoDlg.show(mResources.PLEASEWAIT, (string) null, 1000);
    InfoDlg.isLock = true;
  }

  public static void showWait(string str)
  {
    InfoDlg.show(str, (string) null, 700);
    InfoDlg.isLock = true;
  }

  public static void paint(mGraphics g)
  {
    if (!InfoDlg.isShow || InfoDlg.isLock && InfoDlg.delay > 4990 || GameScr.isPaintAlert)
      return;
    int y = 10;
    GameCanvas.paintz.paintPopUp(GameCanvas.hw - 75, y, 150, 55, g);
    if (InfoDlg.isLock)
    {
      GameCanvas.paintShukiren(GameCanvas.hw - mFont.tahoma_8b.getWidth(InfoDlg.title) / 2 - 10, y + 28, g);
      mFont.tahoma_8b.drawString(g, InfoDlg.title, GameCanvas.hw + 5, y + 21, 2);
    }
    else if (InfoDlg.subtitke != null)
    {
      mFont.tahoma_8b.drawString(g, InfoDlg.title, GameCanvas.hw, y + 13, 2);
      mFont.tahoma_7_green2.drawString(g, InfoDlg.subtitke, GameCanvas.hw, y + 30, 2);
    }
    else
      mFont.tahoma_8b.drawString(g, InfoDlg.title, GameCanvas.hw, y + 21, 2);
  }

  public static void update()
  {
    if (InfoDlg.delay <= 0)
      return;
    --InfoDlg.delay;
    if (InfoDlg.delay != 0)
      return;
    InfoDlg.hide();
  }

  public static void hide()
  {
    InfoDlg.title = string.Empty;
    InfoDlg.subtitke = (string) null;
    InfoDlg.isLock = false;
    InfoDlg.delay = 0;
    InfoDlg.isShow = false;
  }
}
