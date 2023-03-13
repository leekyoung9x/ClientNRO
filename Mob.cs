// Decompiled with JetBrains decompiler
// Type: Mob
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.g;
using System;

public class Mob : IMapObject
{
  public const sbyte TYPE_DUNG = 0;
  public const sbyte TYPE_DI = 1;
  public const sbyte TYPE_NHAY = 2;
  public const sbyte TYPE_LET = 3;
  public const sbyte TYPE_BAY = 4;
  public const sbyte TYPE_BAY_DAU = 5;
  public static MobTemplate[] arrMobTemplate;
  public const sbyte MA_INHELL = 0;
  public const sbyte MA_DEADFLY = 1;
  public const sbyte MA_STANDWAIT = 2;
  public const sbyte MA_ATTACK = 3;
  public const sbyte MA_STANDFLY = 4;
  public const sbyte MA_WALK = 5;
  public const sbyte MA_FALL = 6;
  public const sbyte MA_INJURE = 7;
  public bool changBody;
  public short smallBody;
  public bool isHintFocus;
  public string flystring;
  public int flyx;
  public int flyy;
  public int flyIndex;
  public bool isFreez;
  public int seconds;
  public long last;
  public long cur;
  public int holdEffID;
  public int hp;
  public int maxHp;
  public int x;
  public int y;
  public int dir = 1;
  public int dirV = 1;
  public int status;
  public int p1;
  public int p2;
  public int p3;
  public int xFirst;
  public int yFirst;
  public int vy;
  public int exp;
  public int w;
  public int h;
  public int hpInjure;
  public int charIndex;
  public int timeStatus;
  public int mobId;
  public bool isx;
  public bool isy;
  public bool isDisable;
  public bool isDontMove;
  public bool isFire;
  public bool isIce;
  public bool isWind;
  public bool isDie;
  public MyVector vMobMove = new MyVector();
  public bool isGo;
  public string mobName;
  public int templateId;
  public short pointx;
  public short pointy;
  public Char cFocus;
  public int dame;
  public int dameMp;
  public int sys;
  public sbyte levelBoss;
  public sbyte level;
  public bool isBoss;
  public bool isMobMe;
  public static MyVector lastMob = new MyVector();
  public static MyVector newMob = new MyVector();
  public int xSd;
  public int ySd;
  private bool isOutMap;
  private int wCount;
  public bool isShadown = true;
  private int tick;
  private int frame;
  public static Image imgHP = GameCanvas.loadImage("/mainImage/myTexture2dmobHP.png");
  private bool wy;
  private int wt;
  private int fy;
  private int ty;
  public int typeSuperEff;
  public bool isBusyAttackSomeOne = true;
  public int[] stand = new int[12]
  {
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    1,
    1,
    1,
    1
  };
  public int[] move = new int[15]
  {
    1,
    1,
    1,
    1,
    2,
    2,
    2,
    2,
    3,
    3,
    3,
    3,
    2,
    2,
    2
  };
  public int[] moveFast = new int[7]{ 1, 1, 2, 2, 3, 3, 2 };
  public int[] attack1 = new int[3]{ 4, 5, 6 };
  public int[] attack2 = new int[3]{ 7, 8, 9 };
  public int[] hurt = new int[1];
  private sbyte[] cou = new sbyte[2]
  {
    (sbyte) -1,
    (sbyte) 1
  };
  public Char injureBy;
  public bool injureThenDie;
  public Mob mobToAttack;
  public int forceWait;
  public bool blindEff;
  public bool sleepEff;
  private int[][] frameArr = new int[6][]
  {
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 },
    new int[8]{ 0, 0, 0, 0, 1, 1, 1, 1 }
  };
  private bool isGetFr = true;

  public Mob()
  {
  }

  public Mob(
    int mobId,
    bool isDisable,
    bool isDontMove,
    bool isFire,
    bool isIce,
    bool isWind,
    int templateId,
    int sys,
    int hp,
    sbyte level,
    int maxp,
    short pointx,
    short pointy,
    sbyte status,
    sbyte levelBoss)
  {
    this.isDisable = isDisable;
    this.isDontMove = isDontMove;
    this.isFire = isFire;
    this.isIce = isIce;
    this.isWind = isWind;
    this.sys = sys;
    this.mobId = mobId;
    this.templateId = templateId;
    this.hp = hp;
    this.level = level;
    this.xFirst = this.x = (int) (this.pointx = pointx);
    this.yFirst = this.y = (int) (this.pointy = pointy);
    this.status = (int) status;
    if (templateId != 70)
    {
      this.checkData();
      this.getData();
    }
    if (!Mob.isExistNewMob(templateId.ToString() + string.Empty))
      Mob.newMob.addElement((object) (templateId.ToString() + string.Empty));
    this.maxHp = maxp;
    this.levelBoss = levelBoss;
    this.isDie = false;
    this.xSd = (int) pointx;
    this.ySd = (int) pointy;
    if (this.isNewModStand())
    {
      this.stand = new int[17]
      {
        0,
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        1,
        1,
        2,
        2,
        2,
        2,
        2,
        2,
        2
      };
      this.move = new int[17]
      {
        0,
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        1,
        1,
        2,
        2,
        2,
        2,
        2,
        2,
        2
      };
      this.moveFast = new int[17]
      {
        0,
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        1,
        1,
        2,
        2,
        2,
        2,
        2,
        2,
        2
      };
      this.attack1 = new int[12]
      {
        3,
        3,
        3,
        3,
        4,
        4,
        4,
        4,
        5,
        5,
        5,
        5
      };
      this.attack2 = new int[12]
      {
        3,
        3,
        3,
        3,
        4,
        4,
        4,
        4,
        5,
        5,
        5,
        5
      };
    }
    else if (this.isNewMod())
    {
      this.stand = new int[12]
      {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        1
      };
      this.move = new int[16]
      {
        1,
        1,
        1,
        1,
        2,
        2,
        2,
        2,
        1,
        1,
        1,
        1,
        3,
        3,
        3,
        3
      };
      this.moveFast = new int[8]{ 1, 1, 2, 2, 1, 1, 3, 3 };
      this.attack1 = new int[11]
      {
        4,
        4,
        4,
        5,
        5,
        5,
        6,
        6,
        6,
        6,
        6
      };
      this.attack2 = new int[11]
      {
        7,
        7,
        7,
        8,
        8,
        8,
        9,
        9,
        9,
        9,
        9
      };
    }
    else if (this.isSpecial())
    {
      this.stand = new int[12]
      {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        1
      };
      this.move = new int[16]
      {
        2,
        2,
        3,
        3,
        2,
        2,
        4,
        4,
        2,
        2,
        3,
        3,
        2,
        2,
        4,
        4
      };
      this.moveFast = new int[8]{ 2, 2, 3, 3, 2, 2, 4, 4 };
      this.attack1 = new int[8]{ 5, 6, 7, 8, 9, 10, 11, 12 };
      this.attack2 = new int[4]{ 5, 12, 13, 14 };
    }
    else
    {
      this.stand = new int[12]
      {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        1
      };
      this.move = new int[15]
      {
        1,
        1,
        1,
        1,
        2,
        2,
        2,
        2,
        3,
        3,
        3,
        3,
        2,
        2,
        2
      };
      this.moveFast = new int[7]{ 1, 1, 2, 2, 3, 3, 2 };
      this.attack1 = new int[3]{ 4, 5, 6 };
      this.attack2 = new int[3]{ 7, 8, 9 };
    }
  }

  public bool isBigBoss()
  {
    switch (this)
    {
      case BachTuoc _:
      case BigBoss2 _:
      case BigBoss _:
        return true;
      default:
        return this is NewBoss;
    }
  }

  public void getData()
  {
    if (Mob.arrMobTemplate[this.templateId].data == null)
    {
      Mob.arrMobTemplate[this.templateId].data = new EffectData();
      string path = "/Mob/" + (object) this.templateId;
      if (MyStream.readFile(path) != null)
      {
        Mob.arrMobTemplate[this.templateId].data.readData(path + "/data");
        Mob.arrMobTemplate[this.templateId].data.img = GameCanvas.loadImage(path + "/img.png");
      }
      else
        Service.gI().requestModTemplate(this.templateId);
      Mob.lastMob.addElement((object) (this.templateId.ToString() + string.Empty));
    }
    else
    {
      this.w = Mob.arrMobTemplate[this.templateId].data.width;
      this.h = Mob.arrMobTemplate[this.templateId].data.height;
    }
  }

  public void setBody(short id)
  {
    this.changBody = true;
    this.smallBody = id;
  }

  public void clearBody() => this.changBody = false;

  public static bool isExistNewMob(string id)
  {
    for (int index = 0; index < Mob.newMob.size(); ++index)
    {
      if (((string) Mob.newMob.elementAt(index)).Equals(id))
        return true;
    }
    return false;
  }

  public void checkData()
  {
    int num = 0;
    for (int index = 0; index < Mob.arrMobTemplate.Length; ++index)
    {
      if (Mob.arrMobTemplate[index].data != null)
        ++num;
    }
    if (num < 10)
      return;
    for (int index = 0; index < Mob.arrMobTemplate.Length; ++index)
    {
      if (Mob.arrMobTemplate[index].data != null && num > 5)
        Mob.arrMobTemplate[index].data = (EffectData) null;
    }
  }

  public void checkFrameTick(int[] array)
  {
    if (this.tick > array.Length - 1)
      this.tick = 0;
    this.frame = array[this.tick];
    ++this.tick;
  }

  private void updateShadown()
  {
    int size = (int) TileMap.size;
    this.xSd = this.x;
    this.wCount = 0;
    if (this.ySd <= 0 || TileMap.tileTypeAt(this.xSd, this.ySd, 2))
      return;
    if (TileMap.tileTypeAt(this.xSd / size, this.ySd / size) == 0)
      this.isOutMap = true;
    else if (TileMap.tileTypeAt(this.xSd / size, this.ySd / size) != 0 && !TileMap.tileTypeAt(this.xSd, this.ySd, 2))
    {
      this.xSd = this.x;
      this.ySd = this.y;
      this.isOutMap = false;
    }
    while (this.isOutMap && this.wCount < 10)
    {
      ++this.wCount;
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

  private void paintShadow(mGraphics g)
  {
    int size = (int) TileMap.size;
    if (TileMap.tileTypeAt(this.xSd + size / 2, this.ySd + 1, 4))
      g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, size, 100);
    else if (TileMap.tileTypeAt((this.xSd - size / 2) / size, (this.ySd + 1) / size) == 0)
      g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, 100, 100);
    else if (TileMap.tileTypeAt((this.xSd + size / 2) / size, (this.ySd + 1) / size) == 0)
      g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, size, 100);
    else if (TileMap.tileTypeAt(this.xSd - size / 2, this.ySd + 1, 8))
      g.setClip(this.xSd / 24 * size, (this.ySd - 30) / size * size, size, 100);
    g.drawImage(TileMap.bong, this.xSd, this.ySd, 3);
    g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
  }

  public void updateSuperEff()
  {
    if (this.typeSuperEff == 0 && GameCanvas.gameTick % 25 == 0)
      ServerEffect.addServerEffect(114, this, 1);
    if (this.typeSuperEff == 1 && GameCanvas.gameTick % 4 == 0)
      ServerEffect.addServerEffect(132, this, 1);
    if (this.typeSuperEff != 2 || GameCanvas.gameTick % 7 != 0)
      return;
    ServerEffect.addServerEffect(131, this, 1);
  }

  public virtual void update()
  {
    this.GetFrame();
    if (this.blindEff && GameCanvas.gameTick % 5 == 0)
      ServerEffect.addServerEffect(113, this.x, this.y, 1);
    if (this.sleepEff && GameCanvas.gameTick % 10 == 0)
      EffecMn.addEff(new Effect(41, this.x, this.y, 3, 1, 1));
    if (!GameCanvas.lowGraphic && this.status != 1 && this.status != 0 && !GameCanvas.lowGraphic && GameCanvas.gameTick % (15 + this.mobId * 2) == 0)
    {
      for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
      {
        Char @char = (Char) GameScr.vCharInMap.elementAt(index);
        if (@char != null && @char.isFlyAndCharge && @char.cf == 32)
        {
          Char c = new Char();
          c.cx = @char.cx;
          c.cy = @char.cy - @char.ch;
          if (@char.cgender == 0)
            MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), -100, -100, c, 25);
        }
      }
      if (Char.myCharz().isFlyAndCharge && Char.myCharz().cf == 32)
      {
        Char c = new Char();
        c.cx = Char.myCharz().cx;
        c.cy = Char.myCharz().cy - Char.myCharz().ch;
        if (Char.myCharz().cgender == 0)
          MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), -100, -100, c, 25);
      }
    }
    if (this.holdEffID != 0 && GameCanvas.gameTick % 5 == 0)
      EffecMn.addEff(new Effect(this.holdEffID, this.x, this.y + 24, 3, 5, 1));
    if (this.isFreez)
    {
      if (GameCanvas.gameTick % 5 == 0)
        ServerEffect.addServerEffect(113, this.x, this.y, 1);
      long num = mSystem.currentTimeMillis();
      if (num - this.last >= 1000L)
      {
        --this.seconds;
        this.last = num;
        if (this.seconds < 0)
        {
          this.isFreez = false;
          this.seconds = 0;
        }
      }
      this.frame = !this.isTypeNewMod() ? (!this.isNewModStand() ? (!this.isNewMod() ? (!this.isSpecial() ? (GameCanvas.gameTick % 20 <= 5 ? 10 : 11) : (GameCanvas.gameTick % 20 <= 5 ? 15 : 1)) : (GameCanvas.gameTick % 20 <= 5 ? 10 : 11)) : this.attack1[GameCanvas.gameTick % this.attack1.Length]) : this.hurt[GameCanvas.gameTick % this.hurt.Length];
    }
    if (!this.isUpdate())
      return;
    if (this.isShadown)
      this.updateShadown();
    if (this.vMobMove == null && Mob.arrMobTemplate[this.templateId].rangeMove != (sbyte) 0)
      return;
    if (this.status != 3 && this.isBusyAttackSomeOne)
    {
      if (this.cFocus != null)
        this.cFocus.doInjure(this.dame, this.dameMp, false, true);
      else if (this.mobToAttack != null)
        this.mobToAttack.setInjure();
      this.isBusyAttackSomeOne = false;
    }
    if (this.levelBoss > (sbyte) 0)
      this.updateSuperEff();
    switch (this.status)
    {
      case 1:
        this.isDisable = false;
        this.isDontMove = false;
        this.isFire = false;
        this.isIce = false;
        this.isWind = false;
        this.y += this.p1;
        if (GameCanvas.gameTick % 2 == 0)
        {
          if (this.p2 > 1)
            --this.p2;
          else if (this.p2 < -1)
            ++this.p2;
        }
        this.x += this.p2;
        this.frame = !this.isTypeNewMod() ? (!this.isNewModStand() ? (!this.isNewMod() ? (!this.isSpecial() ? 11 : 15) : 11) : this.attack1[GameCanvas.gameTick % this.attack1.Length]) : this.hurt[GameCanvas.gameTick % this.hurt.Length];
        if (this.isDie)
        {
          this.isDie = false;
          if (this.isMobMe)
          {
            for (int index = 0; index < GameScr.vMob.size(); ++index)
            {
              if (((Mob) GameScr.vMob.elementAt(index)).mobId == this.mobId)
                GameScr.vMob.removeElementAt(index);
            }
          }
          this.p1 = 0;
          this.p2 = 0;
          this.x = this.y = 0;
          this.hp = this.getTemplate().hp;
          this.status = 0;
          this.timeStatus = 0;
          break;
        }
        if ((TileMap.tileTypeAtPixel(this.x, this.y) & 2) == 2)
        {
          this.p1 = this.p1 <= 4 ? -this.p1 : -4;
          if (this.p3 == 0)
            this.p3 = 16;
        }
        else
          ++this.p1;
        if (this.p3 <= 0)
          break;
        --this.p3;
        if (this.p3 != 0)
          break;
        this.isDie = true;
        break;
      case 2:
        if (this.holdEffID != 0 || this.isFreez || this.blindEff || this.sleepEff)
          break;
        this.timeStatus = 0;
        this.updateMobStandWait();
        break;
      case 3:
        if (this.holdEffID != 0 || this.blindEff || this.sleepEff || this.isFreez)
          break;
        this.updateMobAttack();
        break;
      case 4:
        if (this.holdEffID != 0 || this.blindEff || this.sleepEff || this.isFreez)
          break;
        this.timeStatus = 0;
        ++this.p1;
        if (this.p1 <= 40 + this.mobId % 5)
          break;
        this.y -= 2;
        this.status = 5;
        this.p1 = 0;
        break;
      case 5:
        if (this.holdEffID != 0 || this.blindEff || this.sleepEff)
          break;
        if (this.isFreez)
        {
          if (Mob.arrMobTemplate[this.templateId].type != (sbyte) 4)
            break;
          ++this.ty;
          ++this.wt;
          this.fy += this.wy ? -1 : 1;
          if (this.wt != 10)
            break;
          this.wt = 0;
          this.wy = !this.wy;
          break;
        }
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

  public void setInjure()
  {
    if (this.hp <= 0 || this.status == 3)
      return;
    this.timeStatus = 4;
    this.status = 7;
    if (this.getTemplate().type == (sbyte) 0 || Res.abs(this.x - this.xFirst) >= 30)
      return;
    this.x -= 10 * this.dir;
  }

  public static BigBoss getBigBoss()
  {
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      Mob bigBoss = (Mob) GameScr.vMob.elementAt(index);
      if (bigBoss is BigBoss)
        return (BigBoss) bigBoss;
    }
    return (BigBoss) null;
  }

  public static BigBoss2 getBigBoss2()
  {
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      Mob bigBoss2 = (Mob) GameScr.vMob.elementAt(index);
      if (bigBoss2 is BigBoss2)
        return (BigBoss2) bigBoss2;
    }
    return (BigBoss2) null;
  }

  public static BachTuoc getBachTuoc()
  {
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      Mob bachTuoc = (Mob) GameScr.vMob.elementAt(index);
      if (bachTuoc is BachTuoc)
        return (BachTuoc) bachTuoc;
    }
    return (BachTuoc) null;
  }

  public static NewBoss getNewBoss(sbyte idBoss)
  {
    Mob mob = (Mob) GameScr.vMob.elementAt((int) idBoss);
    return mob is NewBoss ? (NewBoss) mob : (NewBoss) null;
  }

  public static void removeBigBoss()
  {
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      Mob o = (Mob) GameScr.vMob.elementAt(index);
      if (o is BigBoss)
      {
        GameScr.vMob.removeElement((object) o);
        break;
      }
    }
  }

  public void setAttack(Char cFocus)
  {
    this.isBusyAttackSomeOne = true;
    this.mobToAttack = (Mob) null;
    this.cFocus = cFocus;
    this.p1 = 0;
    this.p2 = 0;
    this.status = 3;
    this.tick = 0;
    this.dir = cFocus.cx <= this.x ? -1 : 1;
    int cx = cFocus.cx;
    int cy = cFocus.cy;
    if (Res.abs(cx - this.x) < this.w * 2 && Res.abs(cy - this.y) < this.h * 2)
    {
      this.x = this.x >= cx ? cx + this.w : cx - this.w;
      this.p3 = 0;
    }
    else
      this.p3 = 1;
  }

  private bool isSpecial() => this.templateId >= 58 && this.templateId <= 65 || this.templateId == 67 || this.templateId == 68;

  private bool isNewMod() => this.templateId >= 73 && !this.isNewModStand();

  private bool isNewModStand() => this.templateId == 76;

  private void updateInjure()
  {
    if (!this.isBusyAttackSomeOne && GameCanvas.gameTick % 4 == 0)
      this.frame = !this.isTypeNewMod() ? (!this.isNewModStand() ? (!this.isNewMod() ? (!this.isSpecial() ? (this.frame == 10 ? 11 : 10) : (this.frame == 1 ? 15 : 1)) : (this.frame == 10 ? 11 : 10)) : this.attack1[GameCanvas.gameTick % this.attack1.Length]) : this.hurt[GameCanvas.gameTick % this.hurt.Length];
    --this.timeStatus;
    if (this.timeStatus <= 0 && (this.isTypeNewMod() || this.isNewModStand() || this.isNewMod() && this.frame == 11 || this.isSpecial() && this.frame == 15 || this.templateId < 58 && this.frame == 11))
    {
      if (this.injureBy != null && this.injureThenDie || this.hp == 0)
      {
        this.status = 1;
        this.p2 = this.injureBy.cdir << 1;
        this.p1 = -3;
        this.p3 = 0;
      }
      else
      {
        this.status = 5;
        if (this.injureBy != null)
        {
          this.dir = -this.injureBy.cdir;
          if (Res.abs(this.x - this.injureBy.cx) < 24)
            this.status = 2;
        }
        this.p1 = this.p2 = this.p3 = 0;
        this.timeStatus = 0;
      }
      this.injureBy = (Char) null;
    }
    else
    {
      if (Mob.arrMobTemplate[this.templateId].type == (sbyte) 0 || this.injureBy == null)
        return;
      int num = -this.injureBy.cdir << 1;
      if (this.x <= this.xFirst - (int) Mob.arrMobTemplate[this.templateId].rangeMove || this.x >= this.xFirst + (int) Mob.arrMobTemplate[this.templateId].rangeMove)
        return;
      this.x -= num;
    }
  }

  private void updateMobStandWait()
  {
    this.checkFrameTick(this.stand);
    switch (Mob.arrMobTemplate[this.templateId].type)
    {
      case 0:
      case 1:
      case 2:
      case 3:
        ++this.p1;
        if (this.p1 > 10 + this.mobId % 10 && (this.cFocus == null || Res.abs(this.cFocus.cx - this.x) > 80) && (this.mobToAttack == null || Res.abs(this.mobToAttack.x - this.x) > 80))
        {
          this.status = 5;
          break;
        }
        break;
      case 4:
      case 5:
        ++this.p1;
        if (this.p1 > this.mobId % 3 && (this.cFocus == null || Res.abs(this.cFocus.cx - this.x) > 80) && (this.mobToAttack == null || Res.abs(this.mobToAttack.x - this.x) > 80))
        {
          this.status = 5;
          break;
        }
        break;
    }
    if (this.cFocus != null && GameCanvas.gameTick % (10 + this.p1 % 20) == 0)
      this.dir = this.cFocus.cx <= this.x ? -1 : 1;
    else if (this.mobToAttack != null && GameCanvas.gameTick % (10 + this.p1 % 20) == 0)
      this.dir = this.mobToAttack.x <= this.x ? -1 : 1;
    if (this.forceWait <= 0)
      return;
    --this.forceWait;
    this.status = 2;
  }

  public void updateMobAttack()
  {
    int[] array = this.p3 != 0 ? this.attack2 : this.attack1;
    if (this.tick < array.Length)
    {
      this.checkFrameTick(array);
      if (this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameCanvas.w && this.p3 == 0 && GameCanvas.gameTick % 2 == 0)
        SoundMn.gI().charPunch(false, 0.05f);
    }
    if (this.p1 == 0)
    {
      int num1 = this.cFocus == null ? this.mobToAttack.x : this.cFocus.cx;
      int num2 = this.cFocus == null ? this.mobToAttack.y : this.cFocus.cy;
      if (!this.isNewMod())
      {
        if (this.x > this.xFirst + (int) Mob.arrMobTemplate[this.templateId].rangeMove)
          this.p1 = 1;
        if (this.x < this.xFirst - (int) Mob.arrMobTemplate[this.templateId].rangeMove)
          this.p1 = 1;
      }
      if ((Mob.arrMobTemplate[this.templateId].type == (sbyte) 4 || Mob.arrMobTemplate[this.templateId].type == (sbyte) 5) && !this.isDontMove)
        this.y += (num2 - this.y) / 20;
      ++this.p2;
      if (this.p2 > array.Length - 1 || this.p1 == 1)
      {
        this.p1 = 1;
        if (this.p3 == 0)
        {
          if (this.cFocus != null)
            this.cFocus.doInjure(this.dame, this.dameMp, false, true);
          else
            this.mobToAttack.setInjure();
          this.isBusyAttackSomeOne = false;
        }
        else
        {
          if (this.cFocus != null)
            MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), this.dame, this.dameMp, this.cFocus, (int) this.getTemplate().dartType);
          else
            MonsterDart.addMonsterDart(this.x + this.dir * this.w, this.y, this.checkIsBoss(), this.dame, this.dameMp, new Char()
            {
              cx = this.mobToAttack.x,
              cy = this.mobToAttack.y,
              charID = -100
            }, (int) this.getTemplate().dartType);
          this.isBusyAttackSomeOne = false;
        }
      }
      this.dir = this.x >= num1 ? -1 : 1;
    }
    else
    {
      if (this.p1 != 1)
        return;
      if (Mob.arrMobTemplate[this.templateId].type != (sbyte) 0 && !this.isDontMove && !this.isIce && !this.isWind)
      {
        this.x += (this.xFirst - this.x) / 4;
        this.y += (this.yFirst - this.y) / 4;
      }
      if (Res.abs(this.xFirst - this.x) >= 5 || Res.abs(this.yFirst - this.y) >= 5 || this.tick != array.Length)
        return;
      this.status = 2;
      this.p1 = 0;
      this.p2 = 0;
      this.tick = 0;
    }
  }

  public void updateMobWalk()
  {
    int num1 = 0;
    try
    {
      if (this.injureThenDie)
      {
        this.status = 1;
        this.p2 = this.injureBy.cdir << 3;
        this.p1 = -5;
        this.p3 = 0;
      }
      num1 = 1;
      if (this.isIce)
        return;
      if (this.isDontMove || this.isWind)
      {
        this.checkFrameTick(this.stand);
      }
      else
      {
        switch (Mob.arrMobTemplate[this.templateId].type)
        {
          case 0:
            this.frame = !this.isNewModStand() ? 0 : this.stand[GameCanvas.gameTick % this.stand.Length];
            break;
          case 1:
          case 2:
          case 3:
            num1 = 3;
            sbyte speed = Mob.arrMobTemplate[this.templateId].speed;
            if (speed == (sbyte) 1)
            {
              if (GameCanvas.gameTick % 2 == 1)
                break;
            }
            else if (speed > (sbyte) 2)
              speed += (sbyte) (this.mobId % 2);
            else if (GameCanvas.gameTick % 2 == 1)
              --speed;
            this.x += (int) speed * this.dir;
            if (this.x > this.xFirst + (int) Mob.arrMobTemplate[this.templateId].rangeMove)
              this.dir = -1;
            else if (this.x < this.xFirst - (int) Mob.arrMobTemplate[this.templateId].rangeMove)
              this.dir = 1;
            if (Res.abs(this.x - Char.myCharz().cx) < 40 && Res.abs(this.x - this.xFirst) < (int) Mob.arrMobTemplate[this.templateId].rangeMove)
            {
              this.dir = this.x <= Char.myCharz().cx ? 1 : -1;
              if (Res.abs(this.x - Char.myCharz().cx) < 20)
                this.x -= this.dir * 10;
              this.status = 2;
              this.forceWait = 20;
            }
            this.checkFrameTick(this.w <= 30 ? this.moveFast : this.move);
            break;
          case 4:
            num1 = 4;
            sbyte num2 = (sbyte) ((int) Mob.arrMobTemplate[this.templateId].speed + (int) (sbyte) (this.mobId % 2));
            this.x += (int) num2 * this.dir;
            if (GameCanvas.gameTick % 10 > 2)
              this.y += (int) num2 * this.dirV;
            sbyte num3 = (sbyte) ((int) num2 + (int) (sbyte) ((GameCanvas.gameTick + this.mobId) % 2));
            if (this.x > this.xFirst + (int) Mob.arrMobTemplate[this.templateId].rangeMove)
            {
              this.dir = -1;
              this.status = 2;
              this.forceWait = GameCanvas.gameTick % 20 + 20;
              this.p1 = 0;
            }
            else if (this.x < this.xFirst - (int) Mob.arrMobTemplate[this.templateId].rangeMove)
            {
              this.dir = 1;
              this.status = 2;
              this.forceWait = GameCanvas.gameTick % 20 + 20;
              this.p1 = 0;
            }
            if (this.y > this.yFirst + 24)
              this.dirV = -1;
            else if (this.y < this.yFirst - (20 + GameCanvas.gameTick % 10))
              this.dirV = 1;
            this.checkFrameTick(this.move);
            break;
          case 5:
            num1 = 5;
            sbyte num4 = (sbyte) ((int) Mob.arrMobTemplate[this.templateId].speed + (int) (sbyte) (this.mobId % 2));
            this.x += (int) num4 * this.dir;
            sbyte num5 = (sbyte) ((int) num4 + (int) (sbyte) ((GameCanvas.gameTick + this.mobId) % 2));
            if (GameCanvas.gameTick % 10 > 2)
              this.y += (int) num5 * this.dirV;
            if (this.x > this.xFirst + (int) Mob.arrMobTemplate[this.templateId].rangeMove)
            {
              this.dir = -1;
              this.status = 2;
              this.forceWait = GameCanvas.gameTick % 20 + 20;
              this.p1 = 0;
            }
            else if (this.x < this.xFirst - (int) Mob.arrMobTemplate[this.templateId].rangeMove)
            {
              this.dir = 1;
              this.status = 2;
              this.forceWait = GameCanvas.gameTick % 20 + 20;
              this.p1 = 0;
            }
            if (this.y > this.yFirst + 24)
              this.dirV = -1;
            else if (this.y < this.yFirst - (20 + GameCanvas.gameTick % 10))
              this.dirV = 1;
            if (!TileMap.tileTypeAt(this.x, this.y, 2))
              break;
            if (GameCanvas.gameTick % 10 > 5)
            {
              this.y = TileMap.tileYofPixel(this.y);
              this.status = 4;
              this.p1 = 0;
              this.dirV = -1;
              break;
            }
            this.dirV = -1;
            break;
        }
      }
    }
    catch (Exception ex)
    {
      Cout.println("lineee: " + (object) num1);
    }
  }

  public MobTemplate getTemplate() => Mob.arrMobTemplate[this.templateId];

  public bool isPaint() => this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameScr.gW && this.y >= GameScr.cmy && this.y <= GameScr.cmy + GameScr.gH + 30 && Mob.arrMobTemplate[this.templateId] != null && Mob.arrMobTemplate[this.templateId].data != null && Mob.arrMobTemplate[this.templateId].data.img != null && this.status != 0;

  public bool isUpdate() => Mob.arrMobTemplate[this.templateId] != null && Mob.arrMobTemplate[this.templateId].data != null && this.status != 0;

  public bool checkIsBoss() => this.isBoss || this.levelBoss > (sbyte) 0;

  public virtual void paint(mGraphics g)
  {
    if (this.isShadown && this.status != 0)
      this.paintShadow(g);
    if (!this.isPaint() || this.status == 1 && this.p3 > 0 && GameCanvas.gameTick % 3 == 0)
      return;
    g.translate(0, GameCanvas.transY);
    if (!this.changBody)
      Mob.arrMobTemplate[this.templateId].data.paintFrame(g, this.frame, this.x, this.y + this.fy, this.dir != 1 ? 1 : 0, 2);
    else
      SmallImage.drawSmallImage(g, (int) this.smallBody, this.x, this.y + this.fy - 14, 0, 3);
    g.translate(0, -GameCanvas.transY);
    if (Char.myCharz().mobFocus == null || !Char.myCharz().mobFocus.Equals((object) this) || this.status == 1)
      return;
    int num = (int) ((long) this.hp * 100L / (long) this.maxHp) / 10 - 1;
    if (num < 0)
      num = 0;
    if (num > 9)
      num = 9;
    g.drawRegion(Mob.imgHP, 0, 6 * (9 - num), 9, 6, 0, this.x, this.y - this.h - 10, 3);
  }

  public int getHPColor() => 16711680;

  public void startDie()
  {
    this.hp = 0;
    this.injureThenDie = true;
    this.hp = 0;
    this.status = 1;
    Res.outz("MOB DIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEe");
    this.p1 = -3;
    this.p2 = -this.dir;
    this.p3 = 0;
  }

  public void attackOtherMob(Mob mobToAttack)
  {
    this.mobToAttack = mobToAttack;
    this.isBusyAttackSomeOne = true;
    this.cFocus = (Char) null;
    this.p1 = 0;
    this.p2 = 0;
    this.status = 3;
    this.tick = 0;
    this.dir = mobToAttack.x <= this.x ? -1 : 1;
    int x = mobToAttack.x;
    int y = mobToAttack.y;
    if (Res.abs(x - this.x) < this.w * 2 && Res.abs(y - this.y) < this.h * 2)
    {
      this.x = this.x >= x ? x + this.w : x - this.w;
      this.p3 = 0;
    }
    else
      this.p3 = 1;
  }

  public int getX() => this.x;

  public int getY() => this.y;

  public int getH() => this.h;

  public int getW() => this.w;

  public void stopMoving()
  {
    if (this.status != 5)
      return;
    this.status = 2;
    this.p1 = this.p2 = this.p3 = 0;
    this.forceWait = 50;
  }

  public bool isInvisible() => this.status == 0 || this.status == 1;

  public void removeHoldEff()
  {
    if (this.holdEffID == 0)
      return;
    this.holdEffID = 0;
  }

  public void removeBlindEff() => this.blindEff = false;

  public void removeSleepEff() => this.sleepEff = false;

  public void GetFrame()
  {
    if (!this.isGetFr || !this.isTypeNewMod() || Mob.arrMobTemplate[this.templateId].data == null)
      return;
    this.frameArr = (int[][]) Controller.frameHT_NEWBOSS.get((object) (this.templateId.ToString() + string.Empty));
    this.stand = this.frameArr[0];
    this.move = this.frameArr[1];
    this.moveFast = this.frameArr[2];
    this.attack1 = this.frameArr[3];
    this.attack2 = this.frameArr[4];
    this.hurt = this.frameArr[5];
    this.isGetFr = false;
  }

  private bool isTypeNewMod() => Mob.arrMobTemplate[this.templateId].data != null && Mob.arrMobTemplate[this.templateId].data.typeData == 2;
}
