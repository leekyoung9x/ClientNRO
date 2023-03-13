// Decompiled with JetBrains decompiler
// Type: Assets.src.g.PetFollow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

namespace Assets.src.g
{
  public class PetFollow
  {
    public short smallID;
    public Info info = new Info();
    public int dir;
    public int f;
    public int tF;
    public int cmtoY;
    public int cmy;
    public int cmdy;
    public int cmvy;
    public int cmyLim;
    public int cmtoX;
    public int cmx;
    public int cmdx;
    public int cmvx;
    public int cmxLim;
    public int fimg = -1;
    public int wimg;
    public int himg;
    private int[] frame = new int[4]{ 0, 1, 2, 1 };
    private int count;

    public PetFollow() => this.f = Res.random(0, 3);

    public void SetImg(int fimg, int[] frameNew, int wimg, int himg)
    {
      if (fimg < 1)
        return;
      this.fimg = fimg;
      this.frame = frameNew;
      this.wimg = wimg;
      this.himg = himg;
    }

    public void paint(mGraphics g)
    {
      int w = 32;
      int h = 32;
      int num = GameCanvas.gameTick % 10 <= 5 ? 0 : 1;
      if (this.fimg > 0)
      {
        w = this.wimg;
        h = this.himg;
        num = 0;
      }
      SmallImage.drawSmallImage(g, (int) this.smallID, this.f, this.cmx, this.cmy + 3 + num, w, h, this.dir != 1 ? 2 : 0, StaticObj.VCENTER_HCENTER);
    }

    public void update()
    {
      this.moveCamera();
      if (GameCanvas.gameTick % 3 == 0)
      {
        this.f = this.frame[this.count];
        ++this.count;
      }
      if (this.count < this.frame.Length)
        return;
      this.count = 0;
    }

    public void remove() => ServerEffect.addServerEffect(60, this.cmx, this.cmy + 3 + (GameCanvas.gameTick % 10 <= 5 ? 0 : 1), 1);

    public void moveCamera()
    {
      if (this.cmy != this.cmtoY)
      {
        this.cmvy = this.cmtoY - this.cmy << 2;
        this.cmdy += this.cmvy;
        this.cmy += this.cmdy >> 4;
        this.cmdy &= 15;
      }
      if (this.cmx == this.cmtoX)
        return;
      this.cmvx = this.cmtoX - this.cmx << 2;
      this.cmdx += this.cmvx;
      this.cmx += this.cmdx >> 4;
      this.cmdx &= 15;
    }
  }
}
