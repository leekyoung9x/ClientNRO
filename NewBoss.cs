// Decompiled with JetBrains decompiler
// Type: NewBoss
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class NewBoss : Mob, IMapObject
{
  public static Image shadowBig = mSystem.loadImage("/mainImage/shadowBig.png");
  public int xTo;
  public int yTo;
  public bool haftBody;
  public bool change;
  public new int xSd;
  public new int ySd;
  private int wCount;
  public new bool isShadown = true;
  private int tick;
  private int frame;
  public new static Image imgHP = mSystem.loadImage("/mainImage/myTexture2dmobHP.png");
  private bool wy;
  private int wt;
  private int fy;
  private int ty;
  public new int typeSuperEff;
  private Char focus;
  private bool flyUp;
  private bool flyDown;
  private int dy;
  public bool changePos;
  private int tShock;
  public new bool isBusyAttackSomeOne = true;
  private int tA;
  private Char[] charAttack;
  private int[] dameHP;
  private sbyte type;
  private int ff;
  private sbyte[] cou = new sbyte[2]
  {
    (sbyte) -1,
    (sbyte) 1
  };
  public new Char injureBy;
  public new bool injureThenDie;
  public new Mob mobToAttack;
  public new int forceWait;
  public new bool blindEff;
  public new bool sleepEff;
  private int[][] frameArr = new int[17][]
  {
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 }
  };
  public const sbyte stand = 0;
  public const sbyte moveFra = 1;
  public const sbyte attack1 = 2;
  public const sbyte attack2 = 3;
  public const sbyte attack3 = 4;
  public const sbyte attack4 = 5;
  public const sbyte attack5 = 6;
  public const sbyte attack6 = 7;
  public const sbyte attack7 = 8;
  public const sbyte attack8 = 9;
  public const sbyte attack9 = 10;
  public const sbyte attack10 = 11;
  public const sbyte hurt = 12;
  public const sbyte die = 13;
  public const sbyte fly = 14;
  public const sbyte adddame = 15;
  public const sbyte typeEff = 16;

  public NewBoss(int id, short px, short py, int templateID, int hp, int maxHp, int s)
  {
    this.mobId = id;
    this.x = this.xFirst = (int) px + 20;
    this.y = this.yFirst = (int) py;
    this.xTo = this.x;
    this.yTo = this.y;
    this.maxHp = maxHp;
    this.hp = hp;
    this.templateId = templateID;
    if (Mob.arrMobTemplate[this.templateId].data == null)
      Service.gI().requestModTemplate(this.templateId);
    this.status = 2;
    this.frameArr = (int[][]) null;
  }

  public new void setBody(short id)
  {
    this.changBody = true;
    this.smallBody = id;
  }

  public new void clearBody() => this.changBody = false;

  public new static bool isExistNewMob(string id)
  {
    for (int index = 0; index < Mob.newMob.size(); ++index)
    {
      if (((string) Mob.newMob.elementAt(index)).Equals(id))
        return true;
    }
    return false;
  }

  public new void checkFrameTick(int[] array)
  {
    ++this.tick;
    if (this.tick > array.Length - 1)
      this.tick = 0;
    this.frame = array[this.tick];
  }

  public void updateShadown()
  {
    int num = 0;
    this.xSd = this.x;
    if (TileMap.tileTypeAt(this.x, this.y, 2))
    {
      this.ySd = this.y;
    }
    else
    {
      this.ySd = this.y;
      while (num < 30)
      {
        ++num;
        this.ySd += 24;
        if (TileMap.tileTypeAt(this.xSd, this.ySd, 2))
        {
          if (this.ySd % 24 == 0)
            break;
          this.ySd -= this.ySd % 24;
          break;
        }
      }
    }
  }

  private void paintShadow(mGraphics g)
  {
    int size = (int) TileMap.size;
    if ((TileMap.mapID < 114 || TileMap.mapID > 120) && TileMap.mapID != (int) sbyte.MaxValue && TileMap.mapID != 128)
    {
      if (TileMap.tileTypeAt(this.xSd + size / 2, this.ySd + 1, 4))
        g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, size, 100);
      else if (TileMap.tileTypeAt((this.xSd - size / 2) / size, (this.ySd + 1) / size) == 0)
        g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, 100, 100);
      else if (TileMap.tileTypeAt((this.xSd + size / 2) / size, (this.ySd + 1) / size) == 0)
        g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, size, 100);
      else if (TileMap.tileTypeAt(this.xSd - size / 2, this.ySd + 1, 8))
        g.setClip(this.xSd / 24 * size, (this.ySd - 30) / size * size, size, 100);
    }
    g.drawImage(NewBoss.shadowBig, this.xSd, this.ySd - 5, 3);
    g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
  }

  public new void updateSuperEff()
  {
  }

  public override void update()
  {
    if (this.frameArr == null && Mob.arrMobTemplate[this.templateId].data != null)
      this.GetFrame();
    if (this.frameArr == null || !this.isUpdate())
      return;
    this.updateShadown();
    switch (this.status)
    {
      case 0:
      case 1:
        this.updateDead();
        break;
      case 2:
        this.updateMobStandWait();
        break;
      case 3:
        this.updateMobAttack();
        break;
      case 4:
        this.updateMobFly();
        break;
      case 5:
        this.timeStatus = 0;
        this.updateMobWalk();
        break;
      case 6:
        this.timeStatus = 0;
        ++this.p1;
        this.y += this.p1;
        if (this.y < this.yFirst)
          break;
        this.y = this.yFirst;
        this.p1 = 0;
        this.status = 5;
        break;
      case 7:
        this.updateInjure();
        break;
    }
  }

  private void updateDead()
  {
    ++this.tick;
    if (this.tick > this.frameArr[13].Length - 1)
      this.tick = this.frameArr[13].Length - 1;
    this.frame = this.frameArr[13][this.tick];
    if (this.x == this.xTo && this.y == this.yTo)
      return;
    this.x += (this.xTo - this.x) / 4;
    this.y += (this.yTo - this.y) / 4;
  }

  private void updateMobFly()
  {
  }

  public new void setAttack(Char cFocus)
  {
    this.isBusyAttackSomeOne = true;
    this.mobToAttack = (Mob) null;
    this.cFocus = cFocus;
    this.p1 = 0;
    this.p2 = 0;
    this.status = 3;
    this.tick = 0;
    int cx = cFocus.cx;
    int cy = cFocus.cy;
    if (Res.abs(cx - this.x) < this.w * 2 && Res.abs(cy - this.y) < this.h * 2)
    {
      if (this.x < cx)
        this.x = cx - this.w;
      else
        this.x = cx + this.w;
      this.p3 = 0;
    }
    else
      this.p3 = 1;
  }

  private void updateInjure()
  {
  }

  private void updateMobStandWait()
  {
    this.checkFrameTick(this.frameArr[0]);
    if (this.x == this.xTo && this.y == this.yTo)
      return;
    this.x += (this.xTo - this.x) / 4;
    this.y += (this.yTo - this.y) / 4;
  }

  public void setFly()
  {
    this.status = 4;
    this.flyUp = true;
  }

  public void setAttack(Char[] cAttack, int[] dame, sbyte type, sbyte dir)
  {
    this.charAttack = cAttack;
    this.dameHP = dame;
    this.type = type;
    this.dir = (int) dir;
    this.status = 3;
    if (this.x == this.xTo && this.y == this.yTo)
      return;
    this.x += (this.xTo - this.x) / 4;
    this.y += (this.yTo - this.y) / 4;
  }

  public new void updateMobAttack()
  {
    if (this.tick == this.frameArr[(int) this.type + 1].Length - 1)
      this.status = 2;
    this.checkFrameTick(this.frameArr[(int) this.type + 1]);
    if (this.tick != this.frameArr[15][(int) this.type - 1])
      return;
    for (int index = 0; index < this.charAttack.Length; ++index)
    {
      this.charAttack[index].doInjure(this.dameHP[index], 0, false, false);
      ServerEffect.addServerEffect(this.frameArr[16][(int) this.type - 1], this.charAttack[index].cx, this.charAttack[index].cy, 1);
    }
  }

  public new void updateMobWalk()
  {
    this.checkFrameTick(this.frameArr[1]);
    sbyte speed = Mob.arrMobTemplate[this.templateId].speed;
    int num = (int) speed;
    if (Res.abs(this.x - this.xTo) < (int) speed)
      num = Res.abs(this.x - this.xTo);
    this.x += this.x >= this.xTo ? -num : num;
    this.y = this.yTo;
    if (this.x < this.xTo)
      this.dir = 1;
    else if (this.x > this.xTo)
      this.dir = -1;
    if (Res.abs(this.x - this.xTo) > 1)
      return;
    this.x = this.xTo;
    this.status = 2;
  }

  public new bool isPaint() => this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameScr.gW && this.y >= GameScr.cmy && this.y <= GameScr.cmy + GameScr.gH + 30 && this.status != 0;

  public new bool isUpdate() => this.status != 0;

  public override void paint(mGraphics g)
  {
    if (Mob.arrMobTemplate[this.templateId].data == null)
      return;
    if (this.isShadown)
      this.paintShadow(g);
    g.translate(0, GameCanvas.transY);
    Mob.arrMobTemplate[this.templateId].data.paintFrame(g, this.frame, this.x, this.y + this.fy, this.dir != 1 ? 1 : 0, 2);
    g.translate(0, -GameCanvas.transY);
    int w = (int) ((long) this.hp * 50L / (long) this.maxHp);
    if (w == 0)
      return;
    int y = this.y - this.h - 5;
    g.setColor(0);
    g.fillRect(this.x - 27, y - 2, 54, 8);
    g.setColor(16711680);
    g.fillRect(this.x - 25, y, w, 4);
  }

  public new int getHPColor() => 16711680;

  public new void startDie()
  {
    this.hp = 0;
    this.injureThenDie = true;
    this.hp = 0;
    this.status = 1;
    this.p1 = -3;
    this.p2 = -this.dir;
    this.p3 = 0;
  }

  public new void attackOtherMob(Mob mobToAttack)
  {
    this.mobToAttack = mobToAttack;
    this.isBusyAttackSomeOne = true;
    this.cFocus = (Char) null;
    this.p1 = 0;
    this.p2 = 0;
    this.status = 3;
    this.tick = 0;
    int x = mobToAttack.x;
    int y = mobToAttack.y;
    if (Res.abs(x - this.x) < this.w * 2 && Res.abs(y - this.y) < this.h * 2)
    {
      if (this.x < x)
        this.x = x - this.w;
      else
        this.x = x + this.w;
      this.p3 = 0;
    }
    else
      this.p3 = 1;
  }

  public new int getX() => this.x;

  public new int getY() => this.y;

  public new int getH() => this.h;

  public new int getW() => this.w;

  public new void stopMoving()
  {
    if (this.status != 5)
      return;
    this.status = 2;
    this.p1 = this.p2 = this.p3 = 0;
    this.forceWait = 50;
  }

  public new bool isInvisible() => this.status == 0 || this.status == 1;

  public new void removeHoldEff()
  {
    if (this.holdEffID == 0)
      return;
    this.holdEffID = 0;
  }

  public new void removeBlindEff() => this.blindEff = false;

  public new void removeSleepEff() => this.sleepEff = false;

  public void move(short xMoveTo, short yMoveTo)
  {
    if (yMoveTo != (short) -1)
    {
      if (Res.distance(this.x, this.y, this.xTo, this.yTo) > 100)
      {
        this.x = (int) xMoveTo;
        this.y = (int) yMoveTo;
        this.status = 2;
      }
      else
      {
        this.xTo = (int) xMoveTo;
        this.yTo = (int) yMoveTo;
        this.status = 5;
      }
    }
    else
    {
      this.xTo = (int) xMoveTo;
      this.status = 5;
    }
  }

  public new void GetFrame()
  {
    this.frameArr = (int[][]) Controller.frameHT_NEWBOSS.get((object) (this.templateId.ToString() + string.Empty));
    this.w = Mob.arrMobTemplate[this.templateId].data.width;
    this.h = Mob.arrMobTemplate[this.templateId].data.height;
  }

  public void setDie() => this.status = 0;
}
