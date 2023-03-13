// Decompiled with JetBrains decompiler
// Type: MagicTree
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class MagicTree : Npc, IActionListener
{
  public static Image imgMagicTree;
  public static Image pea = GameCanvas.loadImage("/mainImage/myTexture2dhatdau.png");
  public int id;
  public int level;
  public int x;
  public int y;
  public int currPeas;
  public int remainPeas;
  public int maxPeas;
  public new string strInfo;
  public string name;
  public int timeToRecieve;
  public bool isUpdate;
  public int[] peaPostionX;
  public int[] peaPostionY;
  private int num;
  public PopUp p;
  public bool isUpdateTree;
  public static bool isPaint = true;
  public bool isPeasEffect;
  public new int seconds;
  public new long last;
  public new long cur;
  private int wPopUp;
  private bool waitToUpdate;
  private int delay;

  public MagicTree(int npcId, int status, int cx, int cy, int templateId, int iconId)
    : base(npcId, status, cx, cy, templateId, iconId)
  {
    this.p = new PopUp(string.Empty, 0, 0);
    this.p.command = new Command((string) null, (IActionListener) this, 1, (object) null);
    PopUp.addPopUp(this.p);
  }

  public override void paint(mGraphics g)
  {
    if (this.id == 0)
      return;
    SmallImage.drawSmallImage(g, this.id, this.cx, this.cy, 0, StaticObj.BOTTOM_HCENTER);
    if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this))
    {
      g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - SmallImage.smallImg[this.id][4] - 1, mGraphics.BOTTOM | mGraphics.HCENTER);
      if (this.name != null)
        mFont.tahoma_7b_white.drawString(g, this.name, this.cx, this.cy - SmallImage.smallImg[this.id][4] - 20, mFont.CENTER, mFont.tahoma_7_grey);
    }
    else if (this.name != null)
      mFont.tahoma_7b_white.drawString(g, this.name, this.cx, this.cy - SmallImage.smallImg[this.id][4] - 17, mFont.CENTER, mFont.tahoma_7_grey);
    try
    {
      for (int index = 0; index < this.currPeas; ++index)
        g.drawImage(MagicTree.pea, this.cx + this.peaPostionX[index] - SmallImage.smallImg[this.id][3] / 2, this.cy + this.peaPostionY[index] - SmallImage.smallImg[this.id][4], 0);
    }
    catch (Exception ex)
    {
    }
    if (this.indexEffTask < 0 || this.effTask == null || this.cTypePk != (sbyte) 0)
      return;
    SmallImage.drawSmallImage(g, this.effTask.arrEfInfo[this.indexEffTask].idImg, this.cx + this.effTask.arrEfInfo[this.indexEffTask].dx + SmallImage.smallImg[this.id][3] / 2 + 5, this.cy - 15 + this.effTask.arrEfInfo[this.indexEffTask].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
    if (GameCanvas.gameTick % 2 != 0)
      return;
    ++this.indexEffTask;
    if (this.indexEffTask < this.effTask.arrEfInfo.Length)
      return;
    this.indexEffTask = 0;
  }

  public override void update()
  {
    this.p.isPaint = MagicTree.isPaint;
    this.cur = mSystem.currentTimeMillis();
    if (this.cur - this.last >= 1000L)
    {
      --this.seconds;
      this.last = this.cur;
      if (this.seconds < 0)
        this.seconds = 0;
    }
    if (!this.isUpdate)
    {
      if (this.currPeas < this.maxPeas && this.seconds == 0)
        this.waitToUpdate = true;
    }
    else if (this.seconds == 0)
    {
      this.isUpdate = false;
      this.waitToUpdate = true;
    }
    if (this.waitToUpdate)
    {
      ++this.delay;
      if (this.delay == 20)
      {
        this.delay = 0;
        this.waitToUpdate = false;
        Service.gI().getMagicTree((sbyte) 2);
      }
    }
    this.num = this.peaPostionX == null ? 0 : this.peaPostionX.Length * this.currPeas / this.maxPeas;
    if (this.isUpdateTree)
    {
      this.isUpdateTree = false;
      if (this.seconds >= 0 && this.currPeas < this.maxPeas || this.seconds >= 0 && this.isUpdate || this.isPeasEffect)
        this.p.updateXYWH(new string[2]
        {
          this.isUpdate ? mResources.UPGRADING : this.currPeas.ToString() + "/" + (object) this.maxPeas,
          NinjaUtil.getTime(this.seconds)
        }, this.cx, this.cy - 20 - SmallImage.smallImg[this.id][4]);
      else if (this.currPeas == this.maxPeas && !this.isUpdate)
        this.p.updateXYWH(new string[2]
        {
          mResources.can_harvest,
          this.currPeas.ToString() + "/" + (object) this.maxPeas
        }, this.cx, this.cy - 20 - SmallImage.smallImg[this.id][4]);
    }
    if (this.seconds >= 0 && this.currPeas < this.maxPeas || this.seconds >= 0 && this.isUpdate)
      this.p.says[this.p.says.Length - 1] = NinjaUtil.getTime(this.seconds);
    if (this.isPeasEffect)
    {
      this.p.isPaint = false;
      ServerEffect.addServerEffect(98, this.cx + this.peaPostionX[this.currPeas - 1] - SmallImage.smallImg[this.id][3] / 2, this.cy + this.peaPostionY[this.currPeas - 1] - SmallImage.smallImg[this.id][4], 1);
      --this.currPeas;
      if (GameCanvas.gameTick % 2 == 0)
        SoundMn.gI().HP_MPup();
      if (this.currPeas == this.remainPeas)
      {
        this.p.isPaint = true;
        this.isUpdateTree = true;
        this.isPeasEffect = false;
      }
    }
    base.update();
  }

  public void perform(int idAction, object p)
  {
    if (idAction != 1)
      return;
    Service.gI().magicTree((sbyte) 1);
  }
}
