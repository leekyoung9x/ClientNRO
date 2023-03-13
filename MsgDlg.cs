// Decompiled with JetBrains decompiler
// Type: MsgDlg
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class MsgDlg : Dialog
{
  public string[] info;
  public bool isWait;
  private int h;
  private int padLeft;
  private long time = -1;

  public MsgDlg()
  {
    this.padLeft = 35;
    if (GameCanvas.w <= 176)
      this.padLeft = 10;
    if (GameCanvas.w <= 320)
      return;
    this.padLeft = 80;
  }

  public void pleasewait()
  {
    this.setInfo(mResources.PLEASEWAIT, (Command) null, (Command) null, (Command) null);
    GameCanvas.currentDialog = (Dialog) this;
    this.time = mSystem.currentTimeMillis() + 5000L;
  }

  public override void show()
  {
    GameCanvas.currentDialog = (Dialog) this;
    this.time = -1L;
  }

  public void setInfo(string info)
  {
    this.info = mFont.tahoma_8b.splitFontArray(info, GameCanvas.w - (this.padLeft * 2 + 20));
    this.h = 80;
    if (this.info.Length < 5)
      return;
    this.h = this.info.Length * mFont.tahoma_8b.getHeight() + 20;
  }

  public void setInfo(string info, Command left, Command center, Command right)
  {
    this.info = mFont.tahoma_8b.splitFontArray(info, GameCanvas.w - (this.padLeft * 2 + 20));
    this.left = left;
    this.center = center;
    this.right = right;
    this.h = 80;
    if (this.info.Length >= 5)
      this.h = this.info.Length * mFont.tahoma_8b.getHeight() + 20;
    if (GameCanvas.isTouch)
    {
      if (left != null)
      {
        this.left.x = GameCanvas.w / 2 - 68 - 5;
        this.left.y = GameCanvas.h - 50;
      }
      if (right != null)
      {
        this.right.x = GameCanvas.w / 2 + 5;
        this.right.y = GameCanvas.h - 50;
      }
      if (center != null)
      {
        this.center.x = GameCanvas.w / 2 - 35;
        this.center.y = GameCanvas.h - 50;
      }
    }
    this.isWait = false;
    this.time = -1L;
  }

  public override void paint(mGraphics g)
  {
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    if (LoginScr.isContinueToLogin)
      return;
    int y1 = GameCanvas.h - this.h - 38;
    int w = GameCanvas.w - this.padLeft * 2;
    GameCanvas.paintz.paintPopUp(this.padLeft, y1, w, this.h, g);
    int num = y1 + (this.h - this.info.Length * mFont.tahoma_8b.getHeight()) / 2 - 2;
    if (this.isWait)
    {
      num += 8;
      GameCanvas.paintShukiren(GameCanvas.hw, num - 12, g);
    }
    int index = 0;
    int y2 = num;
    while (index < this.info.Length)
    {
      mFont.tahoma_7b_dark.drawString(g, this.info[index], GameCanvas.hw, y2, 2);
      ++index;
      y2 += mFont.tahoma_8b.getHeight();
    }
    base.paint(g);
  }

  public override void update()
  {
    base.update();
    if (this.time == -1L || mSystem.currentTimeMillis() <= this.time)
      return;
    GameCanvas.endDlg();
  }
}
