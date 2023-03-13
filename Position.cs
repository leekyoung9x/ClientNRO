// Decompiled with JetBrains decompiler
// Type: Position
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Position
{
  public int x;
  public int y;
  public int anchor;
  public int g;
  public int v;
  public int w;
  public int h;
  public int color;
  public int limitY;
  public Layer layer;
  public short yTo;
  public short xTo;
  public short distant;

  public Position()
  {
    this.x = 0;
    this.y = 0;
  }

  public Position(int x, int y, int anchor)
  {
    this.x = x;
    this.y = y;
    this.anchor = anchor;
  }

  public Position(int x, int y)
  {
    this.x = x;
    this.y = y;
  }

  public void setPosTo(int xT, int yT)
  {
    this.xTo = (short) xT;
    this.yTo = (short) yT;
    this.distant = (short) Res.distance(this.x, this.y, (int) this.xTo, (int) this.yTo);
  }

  public int translate()
  {
    if (this.x == (int) this.xTo && this.y == (int) this.yTo)
      return -1;
    if (Math.abs(((int) this.xTo - this.x) / 2) <= 1 && Math.abs(((int) this.yTo - this.y) / 2) <= 1)
    {
      this.x = (int) this.xTo;
      this.y = (int) this.yTo;
      return 0;
    }
    if (this.x != (int) this.xTo)
      this.x += ((int) this.xTo - this.x) / 2;
    if (this.y != (int) this.yTo)
      this.y += ((int) this.yTo - this.y) / 2;
    return Res.distance(this.x, this.y, (int) this.xTo, (int) this.yTo) <= (int) this.distant / 5 ? 2 : 1;
  }

  public void update() => this.layer.update();

  public void paint(mGraphics g) => this.layer.paint(g, this.x, this.y);
}
