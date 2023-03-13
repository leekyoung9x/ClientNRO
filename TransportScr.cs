// Decompiled with JetBrains decompiler
// Type: TransportScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class TransportScr : mScreen, IActionListener
{
  public static TransportScr instance;
  public static Image ship;
  public static Image taungam;
  public sbyte type;
  public int speed = 5;
  public int[] posX;
  public int[] posY;
  public int[] posX2;
  public int[] posY2;
  private int cmx;
  private int n = 20;
  public short time;
  public short maxTime;
  public long last;
  public long curr;
  private bool isSpeed;
  private bool transNow;
  private int currSpeed;

  public TransportScr()
  {
    this.posX = new int[this.n];
    this.posY = new int[this.n];
    for (int index = 0; index < this.n; ++index)
    {
      this.posX[index] = Res.random(0, GameCanvas.w);
      this.posY[index] = index * (GameCanvas.h / this.n);
    }
    this.posX2 = new int[this.n];
    this.posY2 = new int[this.n];
    for (int index = 0; index < this.n; ++index)
    {
      this.posX2[index] = Res.random(0, GameCanvas.w);
      this.posY2[index] = index * (GameCanvas.h / this.n);
    }
  }

  public static TransportScr gI()
  {
    if (TransportScr.instance == null)
      TransportScr.instance = new TransportScr();
    return TransportScr.instance;
  }

  public override void switchToMe()
  {
    if (TransportScr.ship == null)
      TransportScr.ship = GameCanvas.loadImage("/mainImage/myTexture2dfutherShip.png");
    if (TransportScr.taungam == null)
      TransportScr.taungam = GameCanvas.loadImage("/mainImage/taungam.png");
    this.isSpeed = false;
    this.transNow = false;
    if (Char.myCharz().checkLuong() > 0 && this.type == (sbyte) 0)
      this.center = new Command(mResources.faster, (IActionListener) this, 1, (object) null);
    else
      this.center = (Command) null;
    this.currSpeed = 0;
    base.switchToMe();
  }

  public override void paint(mGraphics g)
  {
    g.setColor(this.type != (sbyte) 0 ? 3056895 : 0);
    g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
    for (int index = 0; index < this.n; ++index)
    {
      g.setColor(this.type != (sbyte) 0 ? 11140863 : 14802654);
      g.fillRect(this.posX[index], this.posY[index], 10, 2);
    }
    if (this.type == (sbyte) 0)
      g.drawRegion(TransportScr.ship, 0, 0, 72, 95, 7, this.cmx + this.currSpeed, GameCanvas.h / 2, 3);
    if (this.type == (sbyte) 1)
      g.drawRegion(TransportScr.taungam, 0, 0, 144, 79, 2, this.cmx + this.currSpeed, GameCanvas.h / 2, 3);
    for (int index = 0; index < this.n; ++index)
    {
      g.setColor(this.type != (sbyte) 0 ? 7536127 : 14935011);
      g.fillRect(this.posX2[index], this.posY2[index], 18, 3);
    }
    base.paint(g);
  }

  public override void update()
  {
    if (this.type == (sbyte) 0)
    {
      if (!this.isSpeed)
        this.currSpeed = GameCanvas.w / 2 * (int) this.time / (int) this.maxTime;
    }
    else
      this.currSpeed += 2;
    Controller.isStopReadMessage = false;
    this.cmx = (((GameCanvas.w / 2 + this.cmx) / 2 + this.cmx) / 2 + this.cmx) / 2;
    if (this.type == (sbyte) 1)
      this.cmx = 0;
    for (int index = 0; index < this.n; ++index)
    {
      this.posX[index] -= this.speed / 2;
      if (this.posX[index] < -20)
        this.posX[index] = GameCanvas.w;
    }
    for (int index = 0; index < this.n; ++index)
    {
      this.posX2[index] -= this.speed;
      if (this.posX2[index] < -20)
        this.posX2[index] = GameCanvas.w;
    }
    if (GameCanvas.gameTick % 3 == 0)
      this.speed += !this.isSpeed ? 1 : 2;
    if (this.speed > (!this.isSpeed ? 25 : 80))
      this.speed = !this.isSpeed ? 25 : 80;
    this.curr = mSystem.currentTimeMillis();
    if (this.curr - this.last >= 1000L)
    {
      ++this.time;
      this.last = this.curr;
    }
    if (this.isSpeed)
      this.currSpeed += 3;
    if (this.currSpeed >= GameCanvas.w / 2 + 30 && !this.transNow)
    {
      this.transNow = true;
      Service.gI().transportNow();
    }
    base.update();
  }

  public override void updateKey() => base.updateKey();

  public void perform(int idAction, object p)
  {
    if (idAction == 1)
      GameCanvas.startYesNoDlg(mResources.fasterQuestion, new Command(mResources.YES, (IActionListener) this, 2, (object) null), new Command(mResources.NO, (IActionListener) this, 3, (object) null));
    if (idAction == 2 && Char.myCharz().checkLuong() > 0)
    {
      this.isSpeed = true;
      GameCanvas.endDlg();
      this.center = (Command) null;
    }
    if (idAction != 3)
      return;
    GameCanvas.endDlg();
  }
}
