// Decompiled with JetBrains decompiler
// Type: PlayerDart
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class PlayerDart
{
  public Char charBelong;
  public DartInfo info;
  public MyVector darts = new MyVector();
  public int angle;
  public int vx;
  public int vy;
  public int va;
  public int x;
  public int y;
  public int z;
  private int life;
  private int dx;
  private int dy;
  public bool isActive = true;
  public bool isSpeedUp;
  public SkillPaint skillPaint;

  public PlayerDart(Char charBelong, int dartType, SkillPaint sp, int x, int y)
  {
    this.skillPaint = sp;
    this.charBelong = charBelong;
    this.info = GameScr.darts[dartType];
    this.va = this.info.va;
    this.x = x;
    this.y = y;
    IMapObject mapObject = charBelong.mobFocus != null ? (IMapObject) charBelong.mobFocus : (IMapObject) charBelong.charFocus;
    this.setAngle(Res.angle(mapObject.getX() - x, mapObject.getY() - y));
  }

  public void setAngle(int angle)
  {
    this.angle = angle;
    this.vx = this.va * Res.cos(angle) >> 10;
    this.vy = this.va * Res.sin(angle) >> 10;
  }

  public void update()
  {
    if (!this.isActive)
      return;
    if (this.charBelong.mobFocus == null && this.charBelong.charFocus == null)
    {
      this.endMe();
    }
    else
    {
      IMapObject mapObject = this.charBelong.mobFocus != null ? (IMapObject) this.charBelong.mobFocus : (IMapObject) this.charBelong.charFocus;
      for (int index = 0; index < (int) this.info.nUpdate; ++index)
      {
        if (this.info.tail.Length > 0)
          this.darts.addElement((object) new SmallDart(this.x, this.y));
        int num1 = this.charBelong.getX() <= mapObject.getX() ? -10 : 10;
        this.dx = mapObject.getX() + num1 - this.x;
        this.dy = mapObject.getY() - mapObject.getH() / 2 - this.y;
        ++this.life;
        if (Res.abs(this.dx) < 20 && Res.abs(this.dy) < 20)
        {
          if (this.charBelong.charFocus != null && this.charBelong.charFocus.me)
            this.charBelong.charFocus.doInjure(this.charBelong.charFocus.damHP, 0, this.charBelong.charFocus.isCrit, this.charBelong.charFocus.isMob);
          this.endMe();
          return;
        }
        int num2 = Res.angle(this.dx, this.dy);
        if (Math.abs(num2 - this.angle) < 90 || this.dx * this.dx + this.dy * this.dy > 4096)
          this.angle = Math.abs(num2 - this.angle) >= 15 ? (num2 - this.angle >= 0 && num2 - this.angle < 180 || num2 - this.angle < -180 ? Res.fixangle(this.angle + 15) : Res.fixangle(this.angle - 15)) : num2;
        if (!this.isSpeedUp && this.va < 8192)
          this.va += 1024;
        this.vx = this.va * Res.cos(this.angle) >> 10;
        this.vy = this.va * Res.sin(this.angle) >> 10;
        this.dx += this.vx;
        this.x += this.dx >> 10;
        this.dx &= 1023;
        this.dy += this.vy;
        this.y += this.dy >> 10;
        this.dy &= 1023;
      }
      for (int index = 0; index < this.darts.size(); ++index)
      {
        SmallDart smallDart = (SmallDart) this.darts.elementAt(index);
        ++smallDart.index;
        if (smallDart.index >= this.info.tail.Length)
          this.darts.removeElementAt(index);
      }
    }
  }

  private void endMe()
  {
    if (!this.charBelong.isUseSkillAfterCharge && this.x >= GameScr.cmx && this.x <= GameScr.cmx + GameCanvas.w)
      SoundMn.gI().explode_1();
    this.charBelong.setAttack();
    if (this.charBelong.me)
      this.charBelong.saveLoadPreviousSkill();
    if (this.charBelong.isUseSkillAfterCharge)
    {
      this.charBelong.isUseSkillAfterCharge = false;
      if (this.charBelong.isLockMove && this.charBelong.me && this.charBelong.statusMe != 14 && this.charBelong.statusMe != 5)
        this.charBelong.isLockMove = false;
      GameScr.gI().activeSuperPower(this.x, this.y);
    }
    this.charBelong.dart = (PlayerDart) null;
    this.charBelong.isCreateDark = false;
    this.charBelong.skillPaint = (SkillPaint) null;
    this.charBelong.skillPaintRandomPaint = (SkillPaint) null;
  }

  public void paint(mGraphics g)
  {
    if (!this.isActive)
      return;
    int dirIndexFromAngle = MonsterDart.findDirIndexFromAngle(360 - this.angle);
    int index1 = (int) MonsterDart.FRAME[dirIndexFromAngle];
    int transform = MonsterDart.TRANSFORM[dirIndexFromAngle];
    for (int index2 = this.darts.size() / 2; index2 < this.darts.size(); ++index2)
    {
      SmallDart smallDart = (SmallDart) this.darts.elementAt(index2);
      SmallImage.drawSmallImage(g, (int) this.info.tailBorder[smallDart.index], smallDart.x, smallDart.y, 0, 3);
    }
    int index3 = GameCanvas.gameTick % this.info.headBorder.Length;
    SmallImage.drawSmallImage(g, (int) this.info.headBorder[index3][index1], this.x, this.y, transform, 3);
    for (int index4 = 0; index4 < this.darts.size(); ++index4)
    {
      SmallDart smallDart = (SmallDart) this.darts.elementAt(index4);
      SmallImage.drawSmallImage(g, (int) this.info.tail[smallDart.index], smallDart.x, smallDart.y, 0, 3);
    }
    SmallImage.drawSmallImage(g, (int) this.info.head[index3][index1], this.x, this.y, transform, 3);
    for (int index5 = 0; index5 < this.darts.size(); ++index5)
    {
      SmallDart smallDart = (SmallDart) this.darts.elementAt(index5);
      if (Res.abs(MonsterDart.r.nextInt(100)) < (int) this.info.xdPercent)
        SmallImage.drawSmallImage(g, GameCanvas.gameTick % 2 != 0 ? (int) this.info.xd2[smallDart.index] : (int) this.info.xd1[smallDart.index], smallDart.x, smallDart.y, 0, 3);
    }
    g.setColor(16711680);
  }
}
