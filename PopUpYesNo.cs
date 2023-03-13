// Decompiled with JetBrains decompiler
// Type: PopUpYesNo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class PopUpYesNo : IActionListener
{
  public Command cmdYes;
  public Command cmdNo;
  public string[] info;
  private int X;
  private int Y;
  private int W = 120;
  private int H;
  private int dem;
  private long last;
  private long curr;

  public void setPopUp(string info, Command cmdYes, Command cmdNo)
  {
    this.info = new string[1]{ info };
    this.H = 29;
    this.cmdYes = cmdYes;
    this.cmdNo = cmdNo;
    this.cmdYes.img = this.cmdNo.img = GameScr.imgNut;
    this.cmdYes.imgFocus = this.cmdNo.imgFocus = GameScr.imgNutF;
    this.cmdYes.w = mGraphics.getImageWidth(cmdYes.img);
    this.cmdNo.w = mGraphics.getImageWidth(cmdYes.img);
    this.cmdYes.h = mGraphics.getImageHeight(cmdYes.img);
    this.cmdNo.h = mGraphics.getImageHeight(cmdYes.img);
    this.last = mSystem.currentTimeMillis();
    this.dem = this.info[0].Length / 3;
    if (this.dem < 15)
      this.dem = 15;
    TextInfo.reset();
  }

  public void paint(mGraphics g)
  {
    PopUp.paintPopUp(g, this.X, this.Y, this.W, this.H + (GameCanvas.isTouch ? 0 : 10), 16777215, false);
    if (this.info == null)
      return;
    TextInfo.paint(g, this.info[0], this.X + 5, this.Y + this.H / 2 - (!GameCanvas.isTouch ? 6 : 4), this.W - 10, this.H, mFont.tahoma_7);
    if (GameCanvas.isTouch)
    {
      this.cmdYes.paint(g);
      mFont.tahoma_7_yellow.drawString(g, this.dem.ToString() + string.Empty, this.cmdYes.x + this.cmdYes.w / 2, this.cmdYes.y + this.cmdYes.h + 5, 2, mFont.tahoma_7_grey);
    }
    else if (TField.isQwerty)
      mFont.tahoma_7b_blue.drawString(g, mResources.do_accept_qwerty + (object) this.dem + ")", this.X + this.W / 2, this.Y + this.H - 6, 2);
    else
      mFont.tahoma_7b_blue.drawString(g, mResources.do_accept + (object) this.dem + ")", this.X + this.W / 2, this.Y + this.H - 6, 2);
  }

  public void update()
  {
    if (this.info == null)
      return;
    this.X = GameCanvas.w - 5 - this.W;
    this.Y = 45;
    if (GameCanvas.w - 50 > 155 + this.W)
    {
      this.X = GameCanvas.w - 55 - this.W;
      this.Y = 5;
    }
    this.cmdYes.x = this.X - 35;
    this.cmdYes.y = this.Y;
    this.curr = mSystem.currentTimeMillis();
    Res.outz("curr - last= " + (object) (this.curr - this.last));
    if (this.curr - this.last >= 1000L)
    {
      this.last = mSystem.currentTimeMillis();
      --this.dem;
    }
    if (this.dem != 0)
      return;
    GameScr.gI().popUpYesNo = (PopUpYesNo) null;
  }

  public void perform(int idAction, object p)
  {
  }
}
