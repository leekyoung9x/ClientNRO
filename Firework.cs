// Decompiled with JetBrains decompiler
// Type: Firework
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Firework
{
  public int w;
  public int h;
  public int v;
  public int x0;
  public int x;
  public int y;
  public int y0;
  public int angle;
  public int t;
  public int cl = 16711680;
  private float a;
  private long last;
  private long delay = 150;
  private bool act = true;
  private int[] arr_x = new int[2];
  private int[] arr_y = new int[2];

  public Firework(int x0, int y0, int v, int angle, int cl)
  {
    this.y0 = y0;
    this.x0 = x0;
    this.a = 1f;
    this.v = v;
    this.angle = angle;
    this.w = GameCanvas.w;
    this.h = GameCanvas.h;
    this.last = this.time();
    for (int index = 0; index < 2; ++index)
    {
      this.arr_x[index] = x0;
      this.arr_y[index] = y0;
    }
    this.cl = cl;
  }

  public void preDraw()
  {
    if (this.time() - this.last < this.delay)
      return;
    ++this.t;
    this.last = this.time();
    this.arr_x[1] = this.arr_x[0];
    this.arr_y[1] = this.arr_y[0];
    this.arr_x[0] = this.x;
    this.arr_y[0] = this.y;
    this.x = Res.cos((int) ((double) this.angle * System.Math.PI / 180.0)) * this.v * this.t + this.x0;
    this.y = (int) ((double) (this.v * Res.sin((int) ((double) this.angle * System.Math.PI / 180.0)) * this.t) - (double) this.a * (double) this.t * (double) this.t / 2.0) + this.y0;
  }

  public void paint(mGraphics g)
  {
    this.Drawline(g, this.w - this.x, this.h - this.y, this.cl);
    for (int index = 0; index < 2; ++index)
      this.Drawline(g, this.w - this.arr_x[index], this.h - this.arr_y[index], this.cl);
    if (!this.act)
      return;
    this.preDraw();
  }

  public long time() => mSystem.currentTimeMillis();

  public void Drawline(mGraphics g, int x, int y, int color)
  {
    g.setColor(color);
    g.fillRect(x, y, 1, 2);
  }
}
