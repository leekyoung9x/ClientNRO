// Decompiled with JetBrains decompiler
// Type: ServerScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ServerScr : mScreen, IActionListener
{
  private int mainSelect;
  private Command[] vecServer;
  private Command cmdCheck;
  public const int icmd = 100;
  private int wc;
  private int hc;
  private int w2c;
  private int numw;
  private int numh;

  public ServerScr()
  {
    TileMap.bgID = (int) (byte) ((ulong) mSystem.currentTimeMillis() % 9UL);
    if (TileMap.bgID == 5 || TileMap.bgID == 6)
      TileMap.bgID = 4;
    GameScr.loadCamera(true, -1, -1);
    GameScr.cmx = 100;
    GameScr.cmy = 200;
  }

  public override void switchToMe()
  {
    SoundMn.gI().stopAll();
    base.switchToMe();
    this.vecServer = new Command[ServerListScreen.nameServer.Length];
    for (int index = 0; index < ServerListScreen.nameServer.Length; ++index)
      this.vecServer[index] = new Command(ServerListScreen.nameServer[index], (IActionListener) this, 100 + index, (object) null);
    this.mainSelect = ServerListScreen.ipSelect;
    this.w2c = 5;
    this.wc = 76;
    this.hc = mScreen.cmdH;
    this.numw = 2;
    if (GameCanvas.w > 3 * (this.wc + this.w2c))
      this.numw = 3;
    this.numh = this.vecServer.Length / this.numw + (this.vecServer.Length % this.numw != 0 ? 1 : 0);
    for (int index = 0; index < this.vecServer.Length; ++index)
    {
      if (this.vecServer[index] != null)
      {
        int num1 = GameCanvas.hw - this.numw * (this.wc + this.w2c) / 2 + index % this.numw * (this.wc + this.w2c);
        int num2 = GameCanvas.hh - this.numh * (this.hc + this.w2c) / 2 + index / this.numw * (this.hc + this.w2c);
        this.vecServer[index].x = num1;
        this.vecServer[index].y = num2;
      }
    }
    if (GameCanvas.isTouch)
      return;
    this.cmdCheck = new Command(mResources.SELECT, (IActionListener) this, 99, (object) null);
    this.center = this.cmdCheck;
  }

  public override void update()
  {
    ++GameScr.cmx;
    if (GameScr.cmx > GameCanvas.w * 3 + 100)
      GameScr.cmx = 100;
    for (int index = 0; index < this.vecServer.Length; ++index)
    {
      if (!GameCanvas.isTouch)
        this.vecServer[index].isFocus = index == this.mainSelect && GameCanvas.gameTick % 10 < 4;
      else if (this.vecServer[index] != null && this.vecServer[index].isPointerPressInside())
        this.vecServer[index].performAction();
    }
  }

  public override void paint(mGraphics g)
  {
    GameCanvas.paintBGGameScr(g);
    for (int index = 0; index < this.vecServer.Length; ++index)
    {
      if (this.vecServer[index] != null)
        this.vecServer[index].paint(g);
    }
    base.paint(g);
  }

  public override void updateKey()
  {
    base.updateKey();
    int index = this.mainSelect % this.numw;
    int num = this.mainSelect / this.numw;
    if (GameCanvas.keyPressed[4])
    {
      if (index > 0)
        --this.mainSelect;
      GameCanvas.keyPressed[4] = false;
    }
    else if (GameCanvas.keyPressed[6])
    {
      if (index < this.numw - 1)
        ++this.mainSelect;
      GameCanvas.keyPressed[6] = false;
    }
    else if (GameCanvas.keyPressed[2])
    {
      if (num > 0)
        this.mainSelect -= this.numw;
      GameCanvas.keyPressed[2] = false;
    }
    else if (GameCanvas.keyPressed[8])
    {
      if (num < this.numh - 1)
        this.mainSelect += this.numw;
      GameCanvas.keyPressed[8] = false;
    }
    if (this.mainSelect < 0)
      this.mainSelect = 0;
    if (this.mainSelect >= this.vecServer.Length)
      this.mainSelect = this.vecServer.Length - 1;
    if (GameCanvas.keyPressed[5])
    {
      this.vecServer[index].performAction();
      GameCanvas.keyPressed[5] = false;
    }
    GameCanvas.clearKeyPressed();
  }

  public void perform(int idAction, object p)
  {
    if (idAction == 99)
    {
      ServerListScreen.ipSelect = this.mainSelect;
      GameCanvas.serverScreen.selectServer();
      GameCanvas.serverScreen.switchToMe();
    }
    else
    {
      ServerListScreen.ipSelect = idAction - 100;
      GameCanvas.serverScreen.selectServer();
      GameCanvas.serverScreen.switchToMe();
    }
  }
}
