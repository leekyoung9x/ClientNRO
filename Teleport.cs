// Decompiled with JetBrains decompiler
// Type: Teleport
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Teleport
{
  public static MyVector vTeleport = new MyVector();
  public int x;
  public int y;
  public int headId;
  public int type;
  public bool isMe;
  public int y2;
  public int id;
  public int dir;
  public int planet;
  public static Image[] maybay = new Image[5];
  public static Image hole;
  public bool isUp;
  public bool isDown;
  private bool createShip;
  public bool paintFire;
  private bool painHead;
  private int tPrepare;
  private int vy = 1;
  private int tFire;
  private int tDelayHole;
  private bool tHole;
  private bool isShock;

  public Teleport(int x, int y, int headId, int dir, int type, bool isMe, int planet)
  {
    this.x = x;
    this.y = 5;
    this.y2 = y;
    this.headId = headId;
    this.type = type;
    this.isMe = isMe;
    this.dir = dir;
    this.planet = planet;
    this.tPrepare = 0;
    int num = 0;
    while (num < 100)
    {
      ++num;
      this.y2 += 12;
      if (TileMap.tileTypeAt(x, this.y2, 2))
      {
        if (this.y2 % 24 != 0)
        {
          this.y2 -= this.y2 % 24;
          break;
        }
        break;
      }
    }
    this.isDown = true;
    if (this.planet > 2)
    {
      this.y2 += 4;
      if (Teleport.maybay[3] == null)
        Teleport.maybay[3] = GameCanvas.loadImage("/mainImage/myTexture2dmaybay4a.png");
      if (Teleport.maybay[4] == null)
        Teleport.maybay[4] = GameCanvas.loadImage("/mainImage/myTexture2dmaybay4b.png");
      if (Teleport.hole == null)
        Teleport.hole = GameCanvas.loadImage("/mainImage/hole.png");
    }
    else if (Teleport.maybay[planet] == null)
      Teleport.maybay[planet] = GameCanvas.loadImage("/mainImage/myTexture2dmaybay" + (object) (planet + 1) + ".png");
    if (x <= GameScr.cmx || x >= GameScr.cmx + GameCanvas.w || this.y2 <= 100 || SoundMn.gI().isPlayAirShip() || SoundMn.gI().isPlayRain())
      return;
    this.createShip = true;
    SoundMn.gI().airShip();
  }

  public static void addTeleport(Teleport p) => Teleport.vTeleport.addElement((object) p);

  public void paintHole(mGraphics g)
  {
    if (this.planet <= 2 || !this.tHole)
      return;
    g.drawImage(Teleport.hole, this.x, this.y2 + 20, StaticObj.BOTTOM_HCENTER);
  }

  public void paint(mGraphics g)
  {
    if (Char.isLoadingMap || this.x < GameScr.cmx || this.x > GameScr.cmx + GameCanvas.w)
      return;
    Part part = GameScr.parts[this.headId];
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    if (this.planet == 0)
    {
      num1 = 15;
      num2 = 40;
      num3 = 5;
    }
    if (this.planet == 1)
    {
      num1 = 7;
      num2 = 55;
      num3 = 20;
    }
    if (this.planet == 2)
    {
      num1 = 18;
      num2 = 52;
      num3 = 10;
    }
    if (this.painHead && this.planet < 3)
      SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, this.x + (this.dir != 1 ? -num1 : num1), this.y - num2, this.dir != 1 ? 2 : 0, StaticObj.TOP_CENTER);
    if (this.planet < 3)
      g.drawRegion(Teleport.maybay[this.planet], 0, 0, mGraphics.getImageWidth(Teleport.maybay[this.planet]), mGraphics.getImageHeight(Teleport.maybay[this.planet]), this.dir != 1 ? 0 : 2, this.x, this.y, StaticObj.BOTTOM_HCENTER);
    else if (this.isDown)
    {
      if (this.tPrepare > 10)
        g.drawRegion(Teleport.maybay[4], 0, 0, mGraphics.getImageWidth(Teleport.maybay[4]), mGraphics.getImageHeight(Teleport.maybay[4]), this.dir != 1 ? 0 : 2, this.dir != 1 ? this.x + 11 : this.x - 11, this.y + 2, StaticObj.BOTTOM_HCENTER);
      else
        g.drawRegion(Teleport.maybay[3], 0, 0, mGraphics.getImageWidth(Teleport.maybay[3]), mGraphics.getImageHeight(Teleport.maybay[3]), this.dir != 1 ? 0 : 2, this.x, this.y, StaticObj.BOTTOM_HCENTER);
    }
    else if (this.tPrepare < 20)
      g.drawRegion(Teleport.maybay[4], 0, 0, mGraphics.getImageWidth(Teleport.maybay[4]), mGraphics.getImageHeight(Teleport.maybay[4]), this.dir != 1 ? 0 : 2, this.dir != 1 ? this.x + 11 : this.x - 11, this.y + 2, StaticObj.BOTTOM_HCENTER);
    else
      g.drawRegion(Teleport.maybay[3], 0, 0, mGraphics.getImageWidth(Teleport.maybay[3]), mGraphics.getImageHeight(Teleport.maybay[3]), this.dir != 1 ? 0 : 2, this.x, this.y, StaticObj.BOTTOM_HCENTER);
  }

  public void update()
  {
    if (this.planet > 2 && this.paintFire && this.y != -80)
    {
      if (this.isDown && this.tPrepare == 0)
      {
        if (GameCanvas.gameTick % 3 == 0)
          ServerEffect.addServerEffect(1, this.x, this.y, 1, 0);
      }
      else if (this.isUp && GameCanvas.gameTick % 3 == 0)
        ServerEffect.addServerEffect(1, this.x, this.y + 16, 1, 1);
    }
    ++this.tFire;
    if (this.tFire > 3)
      this.tFire = 0;
    if (this.isDown)
    {
      this.paintFire = true;
      this.painHead = this.type != 0;
      if (this.planet < 3)
      {
        int num = this.y2 - this.y >> 3;
        if (num < 1)
        {
          num = 1;
          this.paintFire = false;
        }
        this.y += num;
      }
      else
      {
        if (GameCanvas.gameTick % 2 == 0)
          ++this.vy;
        if (this.y2 - this.y < this.vy)
        {
          this.y = this.y2;
          this.paintFire = false;
        }
        else
          this.y += this.vy;
      }
      if (this.isMe && this.type == 1 && Char.myCharz().isTeleport)
      {
        Char.myCharz().cx = this.x;
        Char.myCharz().cy = this.y - 30;
        Char.myCharz().statusMe = 4;
        GameScr.cmtoX = this.x - GameScr.gW2;
        GameScr.cmtoY = this.y - GameScr.gH23;
        GameScr.info1.isUpdate = false;
      }
      if (GameScr.findCharInMap(this.id) != null && !this.isMe && this.type == 1 && GameScr.findCharInMap(this.id).isTeleport)
      {
        GameScr.findCharInMap(this.id).cx = this.x;
        GameScr.findCharInMap(this.id).cy = this.y - 30;
        GameScr.findCharInMap(this.id).statusMe = 4;
      }
      if (Res.abs(this.y - this.y2) < 50 && TileMap.tileTypeAt(this.x, this.y, 2))
      {
        this.tHole = true;
        if (this.planet < 3)
        {
          SoundMn.gI().pauseAirShip();
          if (this.y % 24 != 0)
            this.y -= this.y % 24;
          ++this.tPrepare;
          if (this.tPrepare > 10)
          {
            this.tPrepare = 0;
            this.isDown = false;
            this.isUp = true;
            this.paintFire = false;
          }
          if (this.type == 1)
          {
            if (this.isMe)
              Char.myCharz().isTeleport = false;
            else if (GameScr.findCharInMap(this.id) != null)
              GameScr.findCharInMap(this.id).isTeleport = false;
            this.painHead = false;
          }
        }
        else
        {
          this.y = this.y2;
          if (!this.isShock)
          {
            ServerEffect.addServerEffect(92, this.x + 4, this.y + 14, 1, 0);
            GameScr.shock_scr = 10;
            this.isShock = true;
          }
          ++this.tPrepare;
          if (this.tPrepare > 30)
          {
            this.tPrepare = 0;
            this.isDown = false;
            this.isUp = true;
            this.paintFire = false;
          }
          if (this.type == 1)
          {
            if (this.isMe)
              Char.myCharz().isTeleport = false;
            else if (GameScr.findCharInMap(this.id) != null)
              GameScr.findCharInMap(this.id).isTeleport = false;
            this.painHead = false;
          }
        }
      }
    }
    else if (this.isUp)
    {
      ++this.tPrepare;
      if (this.tPrepare > 30)
      {
        int num = this.y2 + 24 - this.y >> 3;
        if (num > 30)
          num = 30;
        this.y -= num;
        this.paintFire = true;
      }
      else
      {
        if (this.tPrepare == 14 && this.createShip)
          SoundMn.gI().resumeAirShip();
        if (this.tPrepare > 0 && this.type == 0)
        {
          if (this.isMe)
          {
            Char.myCharz().isTeleport = false;
            if (Char.myCharz().statusMe != 14)
              Char.myCharz().statusMe = 3;
            Char.myCharz().cvy = -3;
          }
          else if (GameScr.findCharInMap(this.id) != null)
          {
            GameScr.findCharInMap(this.id).isTeleport = false;
            if (GameScr.findCharInMap(this.id).statusMe != 14)
              GameScr.findCharInMap(this.id).statusMe = 3;
            GameScr.findCharInMap(this.id).cvy = -3;
          }
          this.painHead = false;
        }
        if (this.tPrepare > 12 && this.type == 0)
        {
          if (this.isMe)
            Char.myCharz().isTeleport = true;
          else if (GameScr.findCharInMap(this.id) != null)
          {
            GameScr.findCharInMap(this.id).cx = this.x;
            GameScr.findCharInMap(this.id).cy = this.y;
            GameScr.findCharInMap(this.id).isTeleport = true;
          }
          this.painHead = true;
        }
      }
      if (this.isMe)
      {
        if (this.type == 0)
        {
          GameScr.cmtoX = this.x - GameScr.gW2;
          GameScr.cmtoY = this.y - GameScr.gH23;
        }
        if (this.type == 1)
          GameScr.info1.isUpdate = true;
      }
      if (this.y <= -80)
      {
        if (this.isMe && this.type == 0)
        {
          Controller.isStopReadMessage = false;
          Char.ischangingMap = true;
        }
        if (!this.isMe && GameScr.findCharInMap(this.id) != null && this.type == 0)
          GameScr.vCharInMap.removeElement((object) GameScr.findCharInMap(this.id));
        if (this.planet < 3)
        {
          Teleport.vTeleport.removeElement((object) this);
        }
        else
        {
          this.y = -80;
          ++this.tDelayHole;
          if (this.tDelayHole > 80)
          {
            this.tDelayHole = 0;
            Teleport.vTeleport.removeElement((object) this);
          }
        }
      }
    }
    if (!this.paintFire || this.planet >= 3 || Res.abs(this.y - this.y2) > 50 || GameCanvas.gameTick % 5 != 0)
      return;
    EffecMn.addEff(new Effect(19, this.x, this.y2 + 20, 2, 1, -1));
  }
}
