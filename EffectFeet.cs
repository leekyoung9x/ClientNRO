// Decompiled with JetBrains decompiler
// Type: EffectFeet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class EffectFeet : Effect2
{
  private int x;
  private int y;
  private int trans;
  private long endTime;
  private bool isF;
  public static Image imgFeet1 = GameCanvas.loadImage("/mainImage/myTexture2dmove-1.png");
  public static Image imgFeet3 = GameCanvas.loadImage("/mainImage/myTexture2dmove-3.png");

  public static void addFeet(int cx, int cy, int ctrans, int timeLengthInSecond, bool isCF) => Effect2.vEffectFeet.addElement((object) new EffectFeet()
  {
    x = cx,
    y = cy,
    trans = ctrans,
    isF = isCF,
    endTime = (mSystem.currentTimeMillis() + (long) (timeLengthInSecond * 1000))
  });

  public override void update()
  {
    if (mSystem.currentTimeMillis() - this.endTime <= 0L)
      return;
    Effect2.vEffectFeet.removeElement((object) this);
  }

  public override void paint(mGraphics g)
  {
    int size = (int) TileMap.size;
    if (TileMap.tileTypeAt(this.x + size / 2, this.y + 1, 4))
      g.setClip(this.x / size * size, (this.y - 30) / size * size, size, 100);
    else if (TileMap.tileTypeAt((this.x - size / 2) / size, (this.y + 1) / size) == 0)
      g.setClip(this.x / size * size, (this.y - 30) / size * size, 100, 100);
    else if (TileMap.tileTypeAt((this.x + size / 2) / size, (this.y + 1) / size) == 0)
      g.setClip(this.x / size * size, (this.y - 30) / size * size, size, 100);
    else if (TileMap.tileTypeAt(this.x - size / 2, this.y + 1, 8))
      g.setClip(this.x / 24 * size, (this.y - 30) / size * size, size, 100);
    g.drawRegion(!this.isF ? EffectFeet.imgFeet3 : EffectFeet.imgFeet1, 0, 0, EffectFeet.imgFeet1.getWidth(), EffectFeet.imgFeet1.getHeight(), this.trans, this.x, this.y, mGraphics.BOTTOM | mGraphics.HCENTER);
    g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
  }
}
