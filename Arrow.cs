// Decompiled with JetBrains decompiler
// Type: Arrow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Arrow
{
  public int life;
  public int ax;
  public int ay;
  public int axTo;
  public int ayTo;
  public int avx;
  public int avy;
  public int adx;
  public int ady;
  public Char charBelong;
  public Arrowpaint arrp;
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

  public Arrow(Char charBelong, Arrowpaint arrp)
  {
    this.charBelong = charBelong;
    this.arrp = arrp;
  }

  public void update()
  {
    if (this.charBelong.mobFocus == null && this.charBelong.charFocus == null)
    {
      this.endMe();
    }
    else
    {
      if (this.charBelong.mobFocus != null)
      {
        this.axTo = this.charBelong.mobFocus.x;
        this.ayTo = this.charBelong.mobFocus.y - this.charBelong.mobFocus.h / 4;
      }
      else if (this.charBelong.charFocus != null)
      {
        this.axTo = this.charBelong.charFocus.cx;
        this.ayTo = this.charBelong.charFocus.cy - this.charBelong.charFocus.ch / 4;
      }
      int num1 = this.axTo - this.ax;
      int num2 = this.ayTo - this.ay;
      int num3 = 5;
      int num4 = 4;
      if (num1 + num2 < 60)
        num4 = 3;
      else if (num1 + num2 < 30)
        num4 = 2;
      if (this.ax != this.axTo)
      {
        if (num1 > 0 && num1 < num3)
          this.ax = this.axTo;
        else if (num1 < 0 && num1 > -num3)
        {
          this.ax = this.axTo;
        }
        else
        {
          this.avx = this.axTo - this.ax << 2;
          this.adx += this.avx;
          this.ax += this.adx >> num4;
          this.adx &= 15;
        }
      }
      if (this.ay != this.ayTo)
      {
        if (num2 > 0 && num2 < num3)
          this.ay = this.ayTo;
        else if (num2 < 0 && num2 > -num3)
        {
          this.ay = this.ayTo;
        }
        else
        {
          this.avy = this.ayTo - this.ay << 2;
          this.ady += this.avy;
          this.ay += this.ady >> num4;
          this.ady &= 15;
        }
      }
      int num5 = 0;
      int num6 = 0;
      int num7 = 0;
      int num8 = 0;
      if (this.charBelong.mobFocus != null)
      {
        num5 = this.axTo - this.charBelong.mobFocus.w / 4;
        num7 = this.axTo + this.charBelong.mobFocus.w / 4;
        num6 = this.ayTo - this.charBelong.mobFocus.h / 4;
        num8 = this.ayTo + this.charBelong.mobFocus.h / 4;
      }
      else if (this.charBelong.charFocus != null)
      {
        num5 = this.axTo - this.charBelong.charFocus.cw / 4;
        num7 = this.axTo + this.charBelong.charFocus.cw / 4;
        num6 = this.ayTo - this.charBelong.charFocus.ch / 4;
        num8 = this.ayTo + this.charBelong.charFocus.ch / 4;
      }
      if (this.life > 0)
        --this.life;
      if (this.life != 0 && (this.ax < num5 || this.ax > num7 || this.ay < num6 || this.ay > num8))
        return;
      this.endMe();
    }
  }

  private void endMe()
  {
    this.charBelong.arr = (Arrow) null;
    this.ax = this.ay = this.axTo = this.ayTo = this.avx = this.avy = this.adx = this.ady = 0;
    this.charBelong.setAttack();
    if (!this.charBelong.me)
      return;
    this.charBelong.saveLoadPreviousSkill();
  }

  public void paint(mGraphics g)
  {
    int dirIndexFromAngle = Arrow.findDirIndexFromAngle(Res.angle(this.axTo - this.ax, -(this.ayTo - this.ay)));
    SmallImage.drawSmallImage(g, this.arrp.imgId[(int) Arrow.FRAME[dirIndexFromAngle]], this.ax, this.ay, Arrow.TRANSFORM[dirIndexFromAngle], mGraphics.VCENTER | mGraphics.HCENTER);
  }

  public static int findDirIndexFromAngle(int angle)
  {
    for (int index = 0; index < Arrow.ARROWINDEX.Length - 1; ++index)
    {
      if (angle >= Arrow.ARROWINDEX[index] && angle <= Arrow.ARROWINDEX[index + 1])
        return index >= 16 ? 0 : index;
    }
    return 0;
  }
}
