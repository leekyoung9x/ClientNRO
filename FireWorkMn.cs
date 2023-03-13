// Decompiled with JetBrains decompiler
// Type: FireWorkMn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class FireWorkMn
{
  private int x;
  private int y;
  private int goc = 1;
  private int n = 360;
  private MyRandom rd = new MyRandom();
  private MyVector fw = new MyVector();
  private int[] color = new int[8]
  {
    16711680,
    16776960,
    65280,
    16777215,
    (int) byte.MaxValue,
    (int) ushort.MaxValue,
    15790320,
    12632256
  };

  public FireWorkMn(int x, int y, int goc, int n)
  {
    this.x = x;
    this.y = y;
    this.goc = goc;
    this.n = n;
    for (int index = 0; index < n; ++index)
      this.fw.addElement((object) new Firework(x, y, Math.abs(this.rd.nextInt() % 8) + 3, index * goc, this.color[Math.abs(this.rd.nextInt() % this.color.Length)]));
  }

  public void paint(mGraphics g)
  {
    for (int index = 0; index < this.fw.size(); ++index)
    {
      Firework firework = (Firework) this.fw.elementAt(index);
      if (firework.y < -200)
        this.fw.removeElementAt(index);
      firework.paint(g);
    }
  }
}
