// Decompiled with JetBrains decompiler
// Type: EffectPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class EffectPanel : Effect2
{
  public EffectCharPaint eff;
  private int i0;
  private int dx0;
  private int dy0;
  private int x;
  private int y;
  private Char c;
  private Mob m;
  private short loopCount;
  private long endTime;
  private int trans;

  public static void addServerEffect(int id, int cx, int cy, int loopCount) => Effect2.vEffect3.addElement((object) new EffectPanel()
  {
    eff = GameScr.efs[id - 1],
    x = cx,
    y = cy,
    loopCount = (short) loopCount
  });

  public override void paint(mGraphics g)
  {
    if (mGraphics.zoomLevel == 1)
      ++GameScr.countEff;
    if (GameScr.countEff >= 8)
      return;
    if (this.c != null)
    {
      this.x = this.c.cx;
      this.y = this.c.cy + GameCanvas.transY;
    }
    if (this.m != null)
    {
      this.x = this.m.x;
      this.y = this.m.y + GameCanvas.transY;
    }
    int x = this.x + this.dx0 + this.eff.arrEfInfo[this.i0].dx;
    int y = this.y + this.dy0 + this.eff.arrEfInfo[this.i0].dy;
    SmallImage.drawSmallImage(g, this.eff.arrEfInfo[this.i0].idImg, x, y, this.trans, mGraphics.VCENTER | mGraphics.HCENTER);
  }

  public override void update()
  {
    if (this.endTime != 0L)
    {
      ++this.i0;
      if (this.i0 >= this.eff.arrEfInfo.Length)
        this.i0 = 0;
      if (mSystem.currentTimeMillis() - this.endTime > 0L)
        Effect2.vEffect3.removeElement((object) this);
    }
    else
    {
      ++this.i0;
      if (this.i0 >= this.eff.arrEfInfo.Length)
      {
        --this.loopCount;
        if (this.loopCount <= (short) 0)
          Effect2.vEffect3.removeElement((object) this);
        else
          this.i0 = 0;
      }
    }
    if (GameCanvas.gameTick % 11 != 0 || this.c == null || this.c == Char.myCharz() || GameScr.vCharInMap.contains((object) this.c))
      return;
    Effect2.vEffect3.removeElement((object) this);
  }
}
