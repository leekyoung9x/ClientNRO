// Decompiled with JetBrains decompiler
// Type: MonsterDart
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class MonsterDart : Effect2
{
  public int va;
  private DartInfo info;
  public static MyRandom r = new MyRandom();
  public int angle;
  public int vx;
  public int vy;
  public int x;
  public int y;
  public int z;
  public int xTo;
  public int yTo;
  private int life;
  public bool isSpeedUp;
  public int dame;
  public int dameMp;
  public Char c;
  public bool isBoss;
  public MyVector darts = new MyVector();
  private int dx;
  private int dy;
  public static int[] ARROWINDEX = new int[18]
  {
    0,
    15,
    37,
    52,
    75,
    105,
    (int) sbyte.MaxValue,
    142,
    165,
    195,
    217,
    232,
    (int) byte.MaxValue,
    285,
    307,
    322,
    345,
    370
  };
  public static int[] TRANSFORM = new int[16]
  {
    0,
    0,
    0,
    7,
    6,
    6,
    6,
    2,
    2,
    3,
    3,
    4,
    5,
    5,
    5,
    1
  };
  public static sbyte[] FRAME = new sbyte[25]
  {
    (sbyte) 0,
    (sbyte) 1,
    (sbyte) 2,
    (sbyte) 1,
    (sbyte) 0,
    (sbyte) 1,
    (sbyte) 2,
    (sbyte) 1,
    (sbyte) 0,
    (sbyte) 1,
    (sbyte) 2,
    (sbyte) 1,
    (sbyte) 0,
    (sbyte) 1,
    (sbyte) 2,
    (sbyte) 1,
    (sbyte) 0,
    (sbyte) 1,
    (sbyte) 2,
    (sbyte) 1,
    (sbyte) 0,
    (sbyte) 1,
    (sbyte) 2,
    (sbyte) 1,
    (sbyte) 0
  };

  public MonsterDart(int x, int y, bool isBoss, int dame, int dameMp, Char c, int dartType)
  {
    this.info = GameScr.darts[dartType];
    this.x = x;
    this.y = y;
    this.isBoss = isBoss;
    this.dame = dame;
    this.dameMp = dameMp;
    this.c = c;
    this.va = this.info.va;
    this.setAngle(Res.angle(c.cx - x, c.cy - y));
    if (x < GameScr.cmx || x > GameScr.cmx + GameCanvas.w)
      return;
    SoundMn.gI().mobKame(dartType);
  }

  public MonsterDart(
    int x,
    int y,
    bool isBoss,
    int dame,
    int dameMp,
    int xTo,
    int yTo,
    int dartType)
  {
    this.info = GameScr.darts[dartType];
    this.x = x;
    this.y = y;
    this.isBoss = isBoss;
    this.dame = dame;
    this.dameMp = dameMp;
    this.xTo = xTo;
    this.yTo = yTo;
    this.va = this.info.va;
    this.setAngle(Res.angle(xTo - x, yTo - y));
    if (x >= GameScr.cmx && x <= GameScr.cmx + GameCanvas.w)
      SoundMn.gI().mobKame(dartType);
    this.c = (Char) null;
  }

  public void setAngle(int angle)
  {
    this.angle = angle;
    this.vx = this.va * Res.cos(angle) >> 10;
    this.vy = this.va * Res.sin(angle) >> 10;
  }

  public static void addMonsterDart(
    int x,
    int y,
    bool isBoss,
    int dame,
    int dameMp,
    Char c,
    int dartType)
  {
    Effect2.vEffect2.addElement((object) new MonsterDart(x, y, isBoss, dame, dameMp, c, dartType));
  }

  public static void addMonsterDart(
    int x,
    int y,
    bool isBoss,
    int dame,
    int dameMp,
    int xTo,
    int yTo,
    int dartType)
  {
    Effect2.vEffect2.addElement((object) new MonsterDart(x, y, isBoss, dame, dameMp, xTo, yTo, dartType));
  }

  public override void update()
  {
    for (int index = 0; index < (int) this.info.nUpdate; ++index)
    {
      if (this.info.tail.Length > 0)
        this.darts.addElement((object) new SmallDart(this.x, this.y));
      this.dx = (this.c == null ? this.xTo : this.c.cx) - this.x;
      this.dy = (this.c == null ? this.yTo : this.c.cy) - 10 - this.y;
      int num1 = 60;
      if (TileMap.mapID == 0)
        num1 = 600;
      ++this.life;
      if (this.c != null && (this.c.statusMe == 5 || this.c.statusMe == 14) || this.c == null)
      {
        this.x += ((this.c == null ? this.xTo : this.c.cx) - this.x) / 2;
        this.y += ((this.c == null ? this.yTo : this.c.cy) - this.y) / 2;
      }
      if (Res.abs(this.dx) < 16 && Res.abs(this.dy) < 16 || this.life > num1)
      {
        if (this.c != null && this.c.charID >= 0 && this.dameMp != -1)
        {
          if (this.dameMp != -100)
            this.c.doInjure(this.dame, this.dameMp, false, true);
          else
            ServerEffect.addServerEffect(80, this.c, 1);
        }
        Effect2.vEffect2.removeElement((object) this);
        if (this.dameMp != -100)
        {
          ServerEffect.addServerEffect(81, this.c, 1);
          if (this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameCanvas.w)
            SoundMn.gI().explode_2();
        }
      }
      int num2 = Res.angle(this.dx, this.dy);
      if (Math.abs(num2 - this.angle) < 90 || this.dx * this.dx + this.dy * this.dy > 4096)
        this.angle = Math.abs(num2 - this.angle) >= 15 ? (num2 - this.angle >= 0 && num2 - this.angle < 180 || num2 - this.angle < -180 ? Res.fixangle(this.angle + 15) : Res.fixangle(this.angle - 15)) : num2;
      if (!this.isSpeedUp && this.va < 8192)
        this.va += 1024;
      this.vx = this.va * Res.cos(this.angle) >> 10;
      this.vy = this.va * Res.sin(this.angle) >> 10;
      this.dx += this.vx;
      this.x += this.dx >> 10;
      this.dx &= 1023;
      this.dy += this.vy;
      this.y += this.dy >> 10;
      this.dy &= 1023;
    }
    for (int index = 0; index < this.darts.size(); ++index)
    {
      SmallDart smallDart = (SmallDart) this.darts.elementAt(index);
      ++smallDart.index;
      if (smallDart.index >= this.info.tail.Length)
        this.darts.removeElementAt(index);
    }
  }

  public static int findDirIndexFromAngle(int angle)
  {
    for (int index = 0; index < MonsterDart.ARROWINDEX.Length - 1; ++index)
    {
      if (angle >= MonsterDart.ARROWINDEX[index] && angle <= MonsterDart.ARROWINDEX[index + 1])
        return index >= 16 ? 0 : index;
    }
    return 0;
  }

  public override void paint(mGraphics g)
  {
    int dirIndexFromAngle = MonsterDart.findDirIndexFromAngle(360 - this.angle);
    int index1 = (int) MonsterDart.FRAME[dirIndexFromAngle];
    int transform = MonsterDart.TRANSFORM[dirIndexFromAngle];
    for (int index2 = this.darts.size() / 2; index2 < this.darts.size(); ++index2)
    {
      SmallDart smallDart = (SmallDart) this.darts.elementAt(index2);
      SmallImage.drawSmallImage(g, (int) this.info.tailBorder[smallDart.index], smallDart.x, smallDart.y, 0, 3);
    }
    int index3 = GameCanvas.gameTick % this.info.headBorder.Length;
    SmallImage.drawSmallImage(g, (int) this.info.headBorder[index3][index1], this.x, this.y, transform, 3);
    for (int index4 = 0; index4 < this.darts.size(); ++index4)
    {
      SmallDart smallDart = (SmallDart) this.darts.elementAt(index4);
      SmallImage.drawSmallImage(g, (int) this.info.tail[smallDart.index], smallDart.x, smallDart.y, 0, 3);
    }
    SmallImage.drawSmallImage(g, (int) this.info.head[index3][index1], this.x, this.y, transform, 3);
    for (int index5 = 0; index5 < this.darts.size(); ++index5)
    {
      SmallDart smallDart = (SmallDart) this.darts.elementAt(index5);
      if (Res.abs(MonsterDart.r.nextInt(100)) < (int) this.info.xdPercent)
        SmallImage.drawSmallImage(g, GameCanvas.gameTick % 2 != 0 ? (int) this.info.xd2[smallDart.index] : (int) this.info.xd1[smallDart.index], smallDart.x, smallDart.y, 0, 3);
    }
  }

  public static void addMonsterDart(
    int x2,
    int y2,
    bool checkIsBoss,
    int dame2,
    int dameMp2,
    Mob mobToAttack,
    sbyte dartType)
  {
    MonsterDart.addMonsterDart(x2, y2, checkIsBoss, dame2, dameMp2, mobToAttack.x, mobToAttack.y, (int) dartType);
  }
}
