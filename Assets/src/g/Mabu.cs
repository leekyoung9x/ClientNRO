// Decompiled with JetBrains decompiler
// Type: Assets.src.g.Mabu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

namespace Assets.src.g
{
  internal class Mabu : Char
  {
    public static EffectData data1;
    public static EffectData data2;
    private new int tick;
    private int lastDir;
    private bool addFoot;
    private Effect effEat;
    private Char focus;
    public int xTo;
    public int yTo;
    public bool haftBody;
    public bool change;
    private Char[] charAttack;
    private int[] damageAttack;
    private int dx;
    public static int[] skill1 = new int[30]
    {
      0,
      0,
      1,
      1,
      2,
      2,
      3,
      3,
      4,
      4,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5,
      5
    };
    public static int[] skill2 = new int[15]
    {
      0,
      0,
      6,
      6,
      7,
      7,
      8,
      8,
      9,
      9,
      9,
      9,
      9,
      10,
      10
    };
    public static int[] skill3 = new int[26]
    {
      0,
      0,
      1,
      1,
      2,
      2,
      3,
      3,
      4,
      4,
      5,
      5,
      6,
      6,
      7,
      7,
      8,
      8,
      9,
      9,
      10,
      10,
      11,
      11,
      12,
      12
    };
    public static int[] skill4 = new int[8]
    {
      13,
      13,
      14,
      14,
      15,
      15,
      16,
      16
    };
    public static int[][] skills = new int[4][]
    {
      Mabu.skill1,
      Mabu.skill2,
      Mabu.skill3,
      Mabu.skill4
    };
    public sbyte skillID = -1;
    private int frame;
    private int pIndex;

    public Mabu()
    {
      this.getData1();
      this.getData2();
    }

    public void eat(int id)
    {
      this.effEat = new Effect(105, this.cx, this.cy + 20, 2, 1, -1);
      EffecMn.addEff(this.effEat);
      if (id == Char.myCharz().charID)
        this.focus = Char.myCharz();
      else
        this.focus = GameScr.findCharInMap(id);
    }

    public new void checkFrameTick(int[] array)
    {
      if (this.skillID == (sbyte) 0)
      {
        if (this.tick == 11)
        {
          this.addFoot = true;
          EffecMn.addEff(new Effect(19, this.cx, this.cy + 20, 2, 1, -1));
        }
        if (this.tick >= array.Length - 1)
        {
          this.skillID = (sbyte) 2;
          return;
        }
      }
      if (this.skillID == (sbyte) 1 && this.tick == array.Length - 1)
      {
        this.skillID = (sbyte) 3;
        this.cy -= 15;
      }
      else
      {
        ++this.tick;
        if (this.tick > array.Length - 1)
          this.tick = 0;
        this.frame = array[this.tick];
      }
    }

    public void getData1()
    {
      Mabu.data1 = (EffectData) null;
      Mabu.data1 = new EffectData();
      string patch = "/x" + (object) mGraphics.zoomLevel + "/effectdata/" + (object) 102 + "/data";
      try
      {
        Mabu.data1.readData2(patch);
        Mabu.data1.img = GameCanvas.loadImage("/effectdata/" + (object) 102 + "/img.png");
      }
      catch (Exception ex)
      {
      }
    }

    public void setSkill(sbyte id, short x, short y, Char[] charHit, int[] damageHit)
    {
      this.skillID = id;
      this.xTo = (int) x;
      this.yTo = (int) y;
      this.lastDir = this.cdir;
      this.cdir = this.xTo <= this.cx ? -1 : 1;
      this.charAttack = charHit;
      this.damageAttack = damageHit;
    }

    public void getData2()
    {
      Mabu.data2 = (EffectData) null;
      Mabu.data2 = new EffectData();
      string patch = "/x" + (object) mGraphics.zoomLevel + "/effectdata/" + (object) 103 + "/data";
      try
      {
        Mabu.data2.readData2(patch);
        Mabu.data2.img = GameCanvas.loadImage("/effectdata/" + (object) 103 + "/img.png");
        Res.outz("read xong data");
      }
      catch (Exception ex)
      {
      }
    }

    public override void update()
    {
      if (this.focus != null)
      {
        if (this.effEat.t >= 30)
        {
          this.effEat.x += (this.cx - this.effEat.x) / 4;
          this.effEat.y += (this.cy - this.effEat.y) / 4;
          this.focus.cx = this.effEat.x;
          this.focus.cy = this.effEat.y;
          this.focus.isMabuHold = true;
        }
        else
        {
          this.effEat.trans = this.effEat.x <= this.focus.cx ? 0 : 1;
          this.effEat.x += (this.focus.cx - this.effEat.x) / 3;
          this.effEat.y += (this.focus.cy - this.effEat.y) / 3;
        }
      }
      if (this.skillID != (sbyte) -1)
      {
        if (this.skillID == (sbyte) 0 && this.addFoot && GameCanvas.gameTick % 2 == 0)
        {
          this.dx += this.xTo <= this.cx ? -30 : 30;
          EffecMn.addEff(new Effect(103, this.cx + this.dx, this.cy + 20, 2, 1, -1)
          {
            trans = this.xTo <= this.cx ? 1 : 0
          });
          if (this.cdir == 1 && this.cx + this.dx >= this.xTo || this.cdir == -1 && this.cx + this.dx <= this.xTo)
          {
            this.addFoot = false;
            this.skillID = (sbyte) -1;
            this.dx = 0;
            this.tick = 0;
            this.cdir = this.lastDir;
            for (int index = 0; index < this.charAttack.Length; ++index)
              this.charAttack[index].doInjure(this.damageAttack[index], 0, false, false);
          }
        }
        if (this.skillID != (sbyte) 3)
          return;
        this.xTo = this.charAttack[this.pIndex].cx;
        this.yTo = this.charAttack[this.pIndex].cy;
        this.cx += (this.xTo - this.cx) / 3;
        this.cy += (this.yTo - this.cy) / 3;
        if (GameCanvas.gameTick % 5 == 0)
          EffecMn.addEff(new Effect(19, this.cx, this.cy, 2, 1, -1));
        if (Res.abs(this.cx - this.xTo) > 20 || Res.abs(this.cy - this.yTo) > 20)
          return;
        this.cx = this.xTo;
        this.cy = this.yTo;
        this.charAttack[this.pIndex].doInjure(this.damageAttack[this.pIndex], 0, false, false);
        ++this.pIndex;
        if (this.pIndex != this.charAttack.Length)
          return;
        this.skillID = (sbyte) -1;
        this.pIndex = 0;
      }
      else
        base.update();
    }

    public override void paint(mGraphics g)
    {
      if (this.skillID != (sbyte) -1)
      {
        this.paintShadow(g);
        g.translate(0, GameCanvas.transY);
        this.checkFrameTick(Mabu.skills[(int) this.skillID]);
        if (this.skillID == (sbyte) 0 || this.skillID == (sbyte) 1)
          Mabu.data1.paintFrame(g, this.frame, this.cx, this.cy + this.fy, this.cdir != 1 ? 1 : 0, 2);
        else
          Mabu.data2.paintFrame(g, this.frame, this.cx, this.cy + this.fy, this.cdir != 1 ? 1 : 0, 2);
        g.translate(0, -GameCanvas.transY);
      }
      else
        base.paint(g);
    }
  }
}
