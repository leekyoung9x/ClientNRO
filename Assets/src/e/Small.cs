// Decompiled with JetBrains decompiler
// Type: Assets.src.e.Small
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

namespace Assets.src.e
{
  public class Small
  {
    public Image img;
    public int id;
    public int timePaint;
    public int timeUpdate;

    public Small(Image img, int id)
    {
      this.img = img;
      this.id = id;
      this.timePaint = 0;
      this.timeUpdate = 0;
    }

    public void paint(mGraphics g, int transform, int x, int y, int anchor)
    {
      g.drawRegion(this.img, 0, 0, mGraphics.getImageWidth(this.img), mGraphics.getImageHeight(this.img), transform, x, y, anchor);
      if (GameCanvas.gameTick % 1000 != 0)
        return;
      ++this.timePaint;
      this.timeUpdate = this.timePaint;
    }

    public void paint(
      mGraphics g,
      int transform,
      int f,
      int x,
      int y,
      int w,
      int h,
      int anchor)
    {
      this.paint(g, transform, f, x, y, w, h, anchor, false);
    }

    public void paint(
      mGraphics g,
      int transform,
      int f,
      int x,
      int y,
      int w,
      int h,
      int anchor,
      bool isClip)
    {
      if (mGraphics.getImageWidth(this.img) == 1)
        return;
      g.drawRegion(this.img, 0, f * w, w, h, transform, x, y, anchor, isClip);
      if (GameCanvas.gameTick % 1000 != 0)
        return;
      ++this.timePaint;
      this.timeUpdate = this.timePaint;
    }

    public void update()
    {
      ++this.timeUpdate;
      if (this.timeUpdate - this.timePaint <= 1 || Char.myCharz().isCharBodyImageID(this.id))
        return;
      SmallImage.imgNew[this.id] = (Small) null;
    }
  }
}
