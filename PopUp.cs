// Decompiled with JetBrains decompiler
// Type: PopUp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class PopUp
{
  public static MyVector vPopups = new MyVector();
  public int sayWidth;
  public int sayRun;
  public string[] says;
  public int cx;
  public int cy;
  public int cw;
  public int ch;
  public static int f;
  public static int tF;
  public static int dir;
  public bool isWayPoint;
  public int tDelay;
  private int timeDelay;
  public Command command;
  public bool isPaint = true;
  public bool isHide;
  public static Image goc;
  public static Image imgPopUp;
  public static Image imgPopUp2;
  public Image imgFocus;
  public Image imgUnFocus;

  public PopUp(string info, int x, int y)
  {
    this.sayWidth = 100;
    if (info.Length < 10)
      this.sayWidth = 60;
    if (GameCanvas.w == 128)
      this.sayWidth = 128;
    this.says = mFont.tahoma_7b_dark.splitFontArray(info, this.sayWidth - 10);
    this.sayRun = 7;
    this.cx = x - this.sayWidth / 2 - 1;
    this.cy = y - 15 + this.sayRun - this.says.Length * 12 - 10;
    this.cw = this.sayWidth + 2;
    this.ch = (this.says.Length + 1) * 12 + 1;
    while (this.cw % 10 != 0)
      ++this.cw;
    while (this.ch % 10 != 0)
      ++this.ch;
    if (x >= 0 && x <= 24)
      this.cx += this.cw / 2 + 30;
    if (x <= TileMap.tmw * 24 && x >= TileMap.tmw * 24 - 24)
      this.cx -= this.cw / 2 + 6;
    while (this.cx <= 30)
      this.cx += 2;
    while (this.cx + this.cw >= TileMap.tmw * 24 - 30)
      this.cx -= 2;
  }

  public static void loadBg()
  {
    if (PopUp.goc == null)
      PopUp.goc = GameCanvas.loadImage("/mainImage/myTexture2dbd3.png");
    if (PopUp.imgPopUp == null)
      PopUp.imgPopUp = GameCanvas.loadImage("/mainImage/myTexture2dimgPopup.png");
    if (PopUp.imgPopUp2 != null)
      return;
    PopUp.imgPopUp2 = GameCanvas.loadImage("/mainImage/myTexture2dimgPopup2.png");
  }

  public void updateXYWH(string[] info, int x, int y)
  {
    this.sayWidth = 0;
    for (int index = 0; index < info.Length; ++index)
    {
      if (this.sayWidth < mFont.tahoma_7b_dark.getWidth(info[index]))
        this.sayWidth = mFont.tahoma_7b_dark.getWidth(info[index]);
    }
    this.sayWidth += 20;
    this.says = info;
    this.sayRun = 7;
    this.cx = x - this.sayWidth / 2 - 1;
    this.cy = y - 15 + this.sayRun - this.says.Length * 12 - 10;
    this.cw = this.sayWidth + 2;
    this.ch = (this.says.Length + 1) * 12 + 1;
    while (this.cw % 10 != 0)
      ++this.cw;
    while (this.ch % 10 != 0)
      ++this.ch;
    if (x >= 0 && x <= 24)
      this.cx += this.cw / 2 + 30;
    if (x <= TileMap.tmw * 24 && x >= TileMap.tmw * 24 - 24)
      this.cx -= this.cw / 2 + 6;
    while (this.cx <= 30)
      this.cx += 2;
    while (this.cx + this.cw >= TileMap.tmw * 24 - 30)
      this.cx -= 2;
  }

  public static void addPopUp(int x, int y, string info) => PopUp.vPopups.addElement((object) new PopUp(info, x, y));

  public static void addPopUp(PopUp p) => PopUp.vPopups.addElement((object) p);

  public static void removePopUp(PopUp p) => PopUp.vPopups.removeElement((object) p);

  public void paintClipPopUp(mGraphics g, int x, int y, int w, int h, int color, bool isFocus)
  {
    if (color == 1)
      g.fillRect(x, y, w, h, 16777215, 90);
    else
      g.fillRect(x, y, w, h, 0, 77);
  }

  public static void paintPopUp(
    mGraphics g,
    int x,
    int y,
    int w,
    int h,
    int color,
    bool isButton)
  {
    if (!isButton)
    {
      g.setColor(0);
      g.fillRect(x + 6, y, w - 14 + 1, h);
      g.fillRect(x, y + 6, w, h - 12 + 1);
      g.setColor(color);
      g.fillRect(x + 6, y + 1, w - 12, h - 2);
      g.fillRect(x + 1, y + 6, w - 2, h - 12);
      g.drawRegion(PopUp.goc, 0, 0, 7, 6, 0, x, y, 0);
      g.drawRegion(PopUp.goc, 0, 0, 7, 6, 2, x + w - 7, y, 0);
      g.drawRegion(PopUp.goc, 0, 0, 7, 6, 1, x, y + h - 6, 0);
      g.drawRegion(PopUp.goc, 0, 0, 7, 6, 3, x + w - 7, y + h - 6, 0);
    }
    else
    {
      Image image = color != 1 ? PopUp.imgPopUp : PopUp.imgPopUp2;
      g.drawRegion(image, 0, 0, 10, 10, 0, x, y, 0);
      g.drawRegion(image, 0, 20, 10, 10, 0, x + w - 10, y, 0);
      g.drawRegion(image, 0, 50, 10, 10, 0, x, y + h - 10, 0);
      g.drawRegion(image, 0, 70, 10, 10, 0, x + w - 10, y + h - 10, 0);
      int num1 = (w - 20) % 10 != 0 ? (w - 20) / 10 + 1 : (w - 20) / 10;
      int num2 = (h - 20) % 10 != 0 ? (h - 20) / 10 + 1 : (h - 20) / 10;
      for (int index = 0; index < num1; ++index)
        g.drawRegion(image, 0, 10, 10, 10, 0, x + 10 + index * 10, y, 0);
      for (int index = 0; index < num2; ++index)
        g.drawRegion(image, 0, 30, 10, 10, 0, x, y + 10 + index * 10, 0);
      for (int index = 0; index < num1; ++index)
        g.drawRegion(image, 0, 60, 10, 10, 0, x + 10 + index * 10, y + h - 10, 0);
      for (int index = 0; index < num2; ++index)
        g.drawRegion(image, 0, 40, 10, 10, 0, x + w - 10, y + 10 + index * 10, 0);
      g.setColor(color != 1 ? 16770503 : 12052656);
      g.fillRect(x + 10, y + 10, w - 20, h - 20);
    }
  }

  public void paint(mGraphics g)
  {
    if (!this.isPaint || this.says == null || ChatPopup.currChatPopup != null || this.isHide)
      return;
    this.paintClipPopUp(g, this.cx, this.cy - GameCanvas.transY, this.cw, this.ch, this.timeDelay != 0 ? 1 : 0, true);
    for (int index = 0; index < this.says.Length; ++index)
      (this.timeDelay != 0 ? mFont.tahoma_7b_green2 : mFont.tahoma_7b_white).drawString(g, this.says[index], this.cx + this.cw / 2, this.cy + (this.ch / 2 - this.says.Length * 12 / 2) + index * 12 - GameCanvas.transY, 2);
  }

  private void update()
  {
    if (Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.taskId == (short) 0)
      this.isHide = this.cx + this.cw < GameScr.cmx || this.cx > GameCanvas.w + GameScr.cmx || this.cy + this.ch < GameScr.cmy || this.cy > GameCanvas.h + GameScr.cmy;
    if (Char.myCharz().taskMaint == null || Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.taskId != (short) 0)
      this.isHide = this.cx + this.cw / 2 < Char.myCharz().cx - 100 || this.cx + this.cw / 2 > Char.myCharz().cx + 100 || this.cy + this.ch < GameScr.cmy || this.cy > GameCanvas.h + GameScr.cmy;
    if (this.timeDelay > 0)
    {
      --this.timeDelay;
      if (this.timeDelay == 0 && this.command != null)
        this.command.performAction();
    }
    if (!this.isWayPoint)
      return;
    if (Char.myCharz().taskMaint != null)
    {
      if (Char.myCharz().taskMaint.taskId == (short) 0)
      {
        if (Char.myCharz().taskMaint.index == 0)
          this.isPaint = false;
        if (Char.myCharz().taskMaint.index == 1)
          this.isPaint = true;
        if (Char.myCharz().taskMaint.index <= 1 || Char.myCharz().taskMaint.index >= 6)
          return;
        this.isPaint = false;
      }
      else
      {
        if (this.isPaint)
          return;
        ++this.tDelay;
        if (this.tDelay != 50)
          return;
        this.isPaint = true;
      }
    }
    else
    {
      if (this.isPaint)
        return;
      Hint.isPaint = false;
      ++this.tDelay;
      if (this.tDelay != 50)
        return;
      this.isPaint = true;
      Hint.isPaint = true;
    }
  }

  public void doClick(int timeDelay) => this.timeDelay = timeDelay;

  public static void paintAll(mGraphics g)
  {
    for (int index = 0; index < PopUp.vPopups.size(); ++index)
      ((PopUp) PopUp.vPopups.elementAt(index)).paint(g);
  }

  public static void updateAll()
  {
    for (int index = 0; index < PopUp.vPopups.size(); ++index)
      ((PopUp) PopUp.vPopups.elementAt(index)).update();
  }
}
