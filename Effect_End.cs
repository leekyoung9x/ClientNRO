// Decompiled with JetBrains decompiler
// Type: Effect_End
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class Effect_End
{
  public const short End_String_Lose = 0;
  public const short End_String_Win = 1;
  public const short End_String_Draw = 2;
  public const short End_FireWork = 3;
  public const sbyte Lvlpaint_All = -1;
  public const sbyte Lvlpaint_Front = 0;
  public const sbyte Lvlpaint_Mid = 1;
  public const sbyte Lvlpaint_Behind = 2;
  private MyVector VecEffEnd = new MyVector("EffectEnd VecEffEnd");
  public byte[] nFrame = new byte[10];
  public int id = -1;
  public int typeEffect;
  public int typeSub;
  public FrameImage fraImgEff;
  public FrameImage fraImgSubEff;
  public int fRemove;
  public int fMove;
  public int x;
  public int y;
  public int dir;
  public int dir_nguoc;
  public int levelPaint;
  public int f;
  public int vx;
  public int vy;
  public int x1000;
  public int y1000;
  public int vx1000;
  public int vy1000;
  public int dy_throw;
  public long time;
  public bool isRemove;
  public bool isAddSub;
  public static short[][] arrInfoEff = new short[9][]
  {
    new short[3]{ (short) 68, (short) 264, (short) 4 },
    new short[3]{ (short) 30, (short) 120, (short) 4 },
    new short[3]{ (short) 66, (short) 280, (short) 4 },
    new short[3]{ (short) 0, (short) 0, (short) 1 },
    new short[3]{ (short) 111, (short) 68, (short) 2 },
    new short[3]{ (short) 90, (short) 68, (short) 2 },
    new short[3]{ (short) 125, (short) 68, (short) 2 },
    new short[3]{ (short) 47, (short) 282, (short) 6 },
    new short[2]
  };

  public Effect_End(int type, int subtype, int x, int y, int levelPaint, int dir)
  {
    this.f = 0;
    this.typeEffect = type;
    this.typeSub = subtype;
    this.x = x;
    this.y = y;
    this.levelPaint = levelPaint;
    this.dir = dir;
    this.dir_nguoc = dir != 0 ? 0 : 2;
    this.time = mSystem.currentTimeMillis();
    this.isRemove = this.isAddSub = false;
    this.create_Effect();
  }

  public static Image getImage(int id)
  {
    if (id < 0)
      return (Image) null;
    string path = "/e/e_" + (object) id + ".png";
    Image image = (Image) null;
    try
    {
      image = mSystem.loadImage(path);
    }
    catch (Exception ex)
    {
    }
    return image;
  }

  public static void setSoundSkill_END(int x, int y, int typeEffect)
  {
    try
    {
      int x1 = x;
      int y1 = y;
      int id = -1;
      Res.random(3);
      if (id < 0)
        return;
      SoundMn.playSound(x1, y1, id, SoundMn.volume);
    }
    catch (Exception ex)
    {
    }
  }

  public void create_Effect()
  {
    Effect_End.setSoundSkill_END(this.x, this.y, this.typeEffect);
    switch (this.typeEffect)
    {
      case 0:
      case 1:
      case 2:
        this.set_End_String(this.typeEffect);
        break;
      case 3:
        this.set_FireWork();
        break;
    }
  }

  public void update()
  {
    ++this.f;
    switch (this.typeEffect)
    {
      case 0:
      case 1:
      case 2:
        this.upd_End_String();
        break;
      case 3:
        this.upd_FireWork();
        break;
    }
  }

  public void paint(mGraphics g)
  {
    try
    {
      if (this.isRemove || this.f < 0)
        return;
      switch (this.typeEffect)
      {
        case 0:
        case 1:
        case 2:
          this.pnt_End_String(g);
          break;
        case 3:
          this.pnt_FireWork(g);
          break;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void removeEff() => this.isRemove = true;

  private void set_End_String(int typeEffect)
  {
    switch (typeEffect)
    {
      case 0:
        this.fraImgEff = new FrameImage(4);
        break;
      case 1:
        this.fraImgEff = new FrameImage(5);
        break;
      case 2:
        this.fraImgEff = new FrameImage(6);
        break;
    }
    this.fRemove = 100;
    this.dy_throw = GameCanvas.h / 3 + 10;
    this.vy = 10;
    this.y1000 = 0;
    this.isAddSub = false;
  }

  private void upd_End_String()
  {
    this.x = GameCanvas.hw;
    this.y = this.y1000;
    if (this.f > this.fRemove)
      this.removeEff();
    ++this.vy;
    if (this.vy > 15)
      this.vy = 15;
    if (this.y1000 + this.vy < this.dy_throw)
    {
      this.y1000 += this.vy;
    }
    else
    {
      this.y1000 = this.dy_throw;
      if (this.isAddSub)
        return;
      this.isAddSub = true;
      if (this.typeSub == -1)
        return;
      GameScr.addEffectEnd(this.typeSub, 0, this.x, this.y, this.levelPaint, 0);
    }
  }

  private void pnt_End_String(mGraphics g)
  {
    if (this.fraImgEff == null)
      return;
    this.fraImgEff.drawFrame(this.f / 5 % this.fraImgEff.nFrame, this.x, this.y, 0, 33, g);
  }

  private void set_FireWork()
  {
    int num1 = Res.random(3, 5);
    this.fRemove = 90;
    for (int index = 0; index < num1; ++index)
    {
      Point o = new Point();
      o.x = this.x + Res.random_Am_0(4);
      o.y = this.y + Res.random_Am_0(5);
      if (this.typeSub == 0)
      {
        o.fRe = Res.random(10);
        int num2 = 1;
        if (index % 2 == 0)
          num2 = -1;
        o.x = this.x + Res.random((int) Effect_End.arrInfoEff[5][0] / 2) * num2;
        o.y = this.y - Res.random((int) Effect_End.arrInfoEff[5][1] / 2);
        o.fraImgEff = new FrameImage(7);
      }
      this.VecEffEnd.addElement((object) o);
    }
  }

  private void upd_FireWork()
  {
    for (int index = 0; index < this.VecEffEnd.size(); ++index)
    {
      Point point = (Point) this.VecEffEnd.elementAt(index);
      point.update();
      if (point.f == point.fRe)
        SoundMn.playSound(point.x, point.y, SoundMn.FIREWORK, SoundMn.volume);
      if (point.f - point.fRe > point.fraImgEff.nFrame * 3 - 1)
      {
        point.f = 0;
        if (this.typeSub == 0)
        {
          point.fRe = Res.random(10);
          int num = 1;
          if (index % 2 == 0)
            num = -1;
          point.x = this.x + Res.random((int) Effect_End.arrInfoEff[5][0] / 2) * num;
          point.y = this.y - Res.random((int) Effect_End.arrInfoEff[5][1] / 2);
        }
      }
    }
    if (this.f < this.fRemove)
      return;
    this.removeEff();
  }

  private void pnt_FireWork(mGraphics g)
  {
    for (int index = 0; index < this.VecEffEnd.size(); ++index)
    {
      Point point = (Point) this.VecEffEnd.elementAt(index);
      if (point.f - point.fRe > -1 && point.fraImgEff != null)
        point.fraImgEff.drawFrame((point.f - point.fRe) / 3 % point.fraImgEff.nFrame, point.x, point.y, 0, 3, g);
    }
  }
}
