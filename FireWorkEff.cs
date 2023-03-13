// Decompiled with JetBrains decompiler
// Type: FireWorkEff
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class FireWorkEff
{
  private static int w;
  private static int h;
  private static MyRandom r = new MyRandom();
  private static MyVector mg = new MyVector();
  private static int f = 17;
  private static int x;
  private static int y;
  private static int ag;
  private static int x0;
  private static int y0;
  private static int t;
  private static int v;
  private static int ymax = 269;
  private static float a;
  private static int[] mang_x = new int[3];
  private static int[] mang_y = new int[3];
  private static bool st = false;
  private static long last = 0;
  private static long delay = 150;

  public static void preDraw()
  {
    if (FireWorkEff.st)
      FireWorkEff.animate();
    if (FireWorkEff.t <= 32 || !FireWorkEff.st)
      return;
    FireWorkEff.st = false;
    FireWorkEff.mg.removeAllElements();
    FireWorkEff.mg.addElement((object) new FireWorkMn(Res.random(50, GameCanvas.w - 50), Res.random(GameCanvas.h - 100, GameCanvas.h), 5, 72));
  }

  public static void paint(mGraphics g)
  {
    FireWorkEff.preDraw();
    g.setColor(0);
    g.fillRect(0, 0, FireWorkEff.w, FireWorkEff.h);
    g.setColor(16711680);
    for (int index = 0; index < FireWorkEff.mg.size(); ++index)
      ((FireWorkMn) FireWorkEff.mg.elementAt(index)).paint(g);
    if (FireWorkEff.st)
      return;
    FireWorkEff.keyPressed(-(Math.abs(FireWorkEff.r.nextInt() % 3) + 5));
  }

  public static void keyPressed(int k)
  {
    if (k == -5 && !FireWorkEff.st)
    {
      FireWorkEff.x0 = FireWorkEff.w / 2;
      FireWorkEff.ag = 80;
      FireWorkEff.st = true;
      FireWorkEff.add();
    }
    else if (k == -7 && !FireWorkEff.st)
    {
      FireWorkEff.ag = 60;
      FireWorkEff.x0 = 0;
      FireWorkEff.st = true;
      FireWorkEff.add();
    }
    else
    {
      if (k != -6 || FireWorkEff.st)
        return;
      FireWorkEff.ag = 120;
      FireWorkEff.x0 = FireWorkEff.w;
      FireWorkEff.st = true;
      FireWorkEff.add();
    }
  }

  public static void add()
  {
    FireWorkEff.y0 = 0;
    FireWorkEff.v = 16;
    FireWorkEff.t = 0;
    FireWorkEff.a = 0.0f;
    for (int index = 0; index < 3; ++index)
    {
      FireWorkEff.mang_y[index] = 0;
      FireWorkEff.mang_x[index] = FireWorkEff.x0;
    }
    FireWorkEff.st = true;
  }

  public static void animate()
  {
    FireWorkEff.mang_y[2] = FireWorkEff.mang_y[1];
    FireWorkEff.mang_x[2] = FireWorkEff.mang_x[1];
    FireWorkEff.mang_y[1] = FireWorkEff.mang_y[0];
    FireWorkEff.mang_x[1] = FireWorkEff.mang_x[0];
    FireWorkEff.mang_y[0] = FireWorkEff.y;
    FireWorkEff.mang_x[0] = FireWorkEff.x;
    FireWorkEff.x = Res.cos((int) ((double) FireWorkEff.ag * System.Math.PI / 180.0)) * FireWorkEff.v * FireWorkEff.t + FireWorkEff.x0;
    FireWorkEff.y = (int) ((double) (FireWorkEff.v * Res.sin((int) ((double) FireWorkEff.ag * System.Math.PI / 180.0)) * FireWorkEff.t) - (double) FireWorkEff.a * (double) FireWorkEff.t * (double) FireWorkEff.t / 2.0) + FireWorkEff.y0;
    if (FireWorkEff.time() - FireWorkEff.last < FireWorkEff.delay)
      return;
    ++FireWorkEff.t;
    FireWorkEff.last = FireWorkEff.time();
  }

  public static long time() => mSystem.currentTimeMillis();
}
