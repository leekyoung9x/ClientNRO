// Decompiled with JetBrains decompiler
// Type: MobCapcha
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class MobCapcha
{
  public static Image imgMob;
  public static int cmtoY;
  public static int cmy;
  public static int cmdy;
  public static int cmvy;
  public static int cmyLim;
  public static int cmtoX;
  public static int cmx;
  public static int cmdx;
  public static int cmvx;
  public static int cmxLim;
  public static bool explode;
  public static int delay;
  public static bool isCreateMob;
  public static int tF;
  public static int f;
  public static int dir;
  public static bool isAttack;

  public static void init() => MobCapcha.imgMob = GameCanvas.loadImage("/mainImage/myTexture2dmobCapcha.png");

  public static void paint(mGraphics g, int x, int y)
  {
    if (!MobCapcha.isAttack)
    {
      if (GameCanvas.gameTick % 3 == 0)
      {
        if (Char.myCharz().cdir == 1)
          MobCapcha.cmtoX = x - 20 - GameScr.cmx;
        if (Char.myCharz().cdir == -1)
          MobCapcha.cmtoX = x + 20 - GameScr.cmx;
      }
      MobCapcha.cmtoY = Char.myCharz().cy - 40 - GameScr.cmy;
    }
    else
    {
      ++MobCapcha.delay;
      if (MobCapcha.delay == 5)
      {
        MobCapcha.isAttack = false;
        MobCapcha.delay = 0;
      }
      MobCapcha.cmtoX = x - GameScr.cmx;
      MobCapcha.cmtoY = y - GameScr.cmy;
    }
    MobCapcha.dir = MobCapcha.cmx <= x - GameScr.cmx ? 1 : -1;
    g.drawImage(GameScr.imgCapcha, MobCapcha.cmx, MobCapcha.cmy - 40, 3);
    PopUp.paintPopUp(g, MobCapcha.cmx - 25, MobCapcha.cmy - 70, 50, 20, 16777215, false);
    mFont.tahoma_7b_dark.drawString(g, GameScr.gI().keyInput, MobCapcha.cmx, MobCapcha.cmy - 65, 2);
    if (MobCapcha.isCreateMob)
    {
      MobCapcha.isCreateMob = false;
      EffecMn.addEff(new Effect(18, MobCapcha.cmx + GameScr.cmx, MobCapcha.cmy + GameScr.cmy, 2, 10, -1));
    }
    if (MobCapcha.explode)
    {
      MobCapcha.explode = false;
      EffecMn.addEff(new Effect(18, MobCapcha.cmx + GameScr.cmx, MobCapcha.cmy + GameScr.cmy, 2, 10, -1));
      GameScr.gI().mobCapcha = (Mob) null;
      MobCapcha.cmtoX = -GameScr.cmx;
      MobCapcha.cmtoY = -GameScr.cmy;
    }
    g.drawRegion(MobCapcha.imgMob, 0, MobCapcha.f * 40, 40, 40, MobCapcha.dir != 1 ? 2 : 0, MobCapcha.cmx, MobCapcha.cmy + 3 + (GameCanvas.gameTick % 10 <= 5 ? 0 : 1), 3);
    MobCapcha.moveCamera();
  }

  public static void moveCamera()
  {
    if (MobCapcha.cmy != MobCapcha.cmtoY)
    {
      MobCapcha.cmvy = MobCapcha.cmtoY - MobCapcha.cmy << 2;
      MobCapcha.cmdy += MobCapcha.cmvy;
      MobCapcha.cmy += MobCapcha.cmdy >> 4;
      MobCapcha.cmdy &= 15;
    }
    if (MobCapcha.cmx != MobCapcha.cmtoX)
    {
      MobCapcha.cmvx = MobCapcha.cmtoX - MobCapcha.cmx << 2;
      MobCapcha.cmdx += MobCapcha.cmvx;
      MobCapcha.cmx += MobCapcha.cmdx >> 4;
      MobCapcha.cmdx &= 15;
    }
    ++MobCapcha.tF;
    if (MobCapcha.tF != 5)
      return;
    MobCapcha.tF = 0;
    ++MobCapcha.f;
    if (MobCapcha.f <= 2)
      return;
    MobCapcha.f = 0;
  }
}
