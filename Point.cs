// Decompiled with JetBrains decompiler
// Type: Point
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Point
{
  public byte type;
  public int x;
  public int y;
  public int g;
  public int v;
  public int vMax;
  public int w;
  public int h;
  public int color;
  public int limitY;
  public int vx;
  public int vy;
  public int x2;
  public int y2;
  public int toX;
  public int toY;
  public int dis;
  public int f;
  public int ftam;
  public int fRe;
  public int frame;
  public int maxframe;
  public int fSmall;
  public int goc;
  public int gocT_Arc;
  public int idir;
  public int dirThrow;
  public int dir;
  public int dir_nguoc;
  public int idSkill;
  public int id;
  public int levelPaint;
  public int num_per_frame = 1;
  public int life;
  public int goc_Arc;
  public int vx1000;
  public int vy1000;
  public int va;
  public int x1000;
  public int y1000;
  public int vX1000;
  public int vY1000;
  public long time;
  public long timecount;
  public MyVector vecEffPoint;
  public string name;
  public string info;
  public bool isRemove;
  public bool isSmall;
  public bool isPaint;
  public bool isChange;
  public static FrameImage[] FraEffInMap;
  public FrameImage fraImgEff;

  public Point()
  {
  }

  public Point(int x, int y)
  {
    this.x = x;
    this.y = y;
  }

  public Point(int x, int y, int goc)
  {
    this.x = x;
    this.y = y;
    this.goc = goc;
  }

  public void update()
  {
    ++this.f;
    this.x += this.vx;
    this.y += this.vy;
  }

  public void update_not_f()
  {
    this.x += this.vx;
    this.y += this.vy;
  }

  public void paint(mGraphics g)
  {
    if (this.isRemove)
      return;
    int num = 0;
    if (this.isSmall && this.f >= this.fSmall)
      num = 1;
    Point.FraEffInMap[this.color].drawFrame(this.frame / 2 + num, this.x, this.y, this.dis, 3, g);
  }

  public void updateInMap()
  {
    ++this.f;
    if (this.maxframe > 1)
    {
      ++this.frame;
      if (this.frame / 2 >= this.maxframe)
        this.frame = 0;
    }
    if (this.f < this.fRe)
      return;
    this.isRemove = true;
  }
}
