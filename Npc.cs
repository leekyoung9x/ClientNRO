// Decompiled with JetBrains decompiler
// Type: Npc
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Npc : Char
{
  public const sbyte BINH_KHI = 0;
  public const sbyte PHONG_CU = 1;
  public const sbyte TRANG_SUC = 2;
  public const sbyte DUOC_PHAM = 3;
  public const sbyte TAP_HOA = 4;
  public const sbyte THU_KHO = 5;
  public const sbyte DA_LUYEN = 6;
  public NpcTemplate template;
  public int npcId;
  public bool isFocus = true;
  public static NpcTemplate[] arrNpcTemplate;
  public int sys;
  public bool isHide;
  private int duaHauIndex;
  private int dyEff;
  public static bool mabuEff;
  public static int tMabuEff;
  private static int[] shock_x = new int[4]{ 1, -1, 1, -1 };
  private static int[] shock_y = new int[4]{ 1, -1, -1, 1 };
  public static int shock_scr;
  public int[] duahau;
  public new int seconds;
  public new long last;
  public new long cur;
  public int idItem;

  public Npc(int npcId, int status, int cx, int cy, int templateId, int avatar)
  {
    this.isShadown = true;
    this.npcId = npcId;
    this.avatar = avatar;
    this.cx = cx;
    this.cy = cy;
    this.xSd = cx;
    this.ySd = cy;
    this.statusMe = status;
    if (npcId != -1)
      this.template = Npc.arrNpcTemplate[templateId];
    if (templateId == 23 || templateId == 42)
      this.ch = 45;
    if (templateId == 51)
    {
      this.isShadown = false;
      this.duaHauIndex = status;
    }
    if (this.template == null)
      return;
    if (this.template.name == null)
      this.template.name = string.Empty;
    this.template.name = Res.changeString(this.template.name);
  }

  public void setStatus(sbyte s, int sc)
  {
    this.duaHauIndex = (int) s;
    this.last = this.cur = mSystem.currentTimeMillis();
    this.seconds = sc;
  }

  public static void clearEffTask()
  {
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
    {
      Npc npc = (Npc) GameScr.vNpc.elementAt(index);
      npc.effTask = (EffectCharPaint) null;
      npc.indexEffTask = -1;
    }
  }

  public override void update()
  {
    if (this.template.npcTemplateId == 51)
    {
      this.cur = mSystem.currentTimeMillis();
      if (this.cur - this.last >= 1000L)
      {
        --this.seconds;
        this.last = this.cur;
        if (this.seconds < 0)
          this.seconds = 0;
      }
    }
    if (this.isShadown)
      this.updateShadown();
    if (this.effTask == null)
    {
      sbyte[] numArray = new sbyte[7]
      {
        (sbyte) -1,
        (sbyte) 9,
        (sbyte) 9,
        (sbyte) 10,
        (sbyte) 10,
        (sbyte) 11,
        (sbyte) 11
      };
      if (Char.myCharz().ctaskId >= 9 && Char.myCharz().ctaskId <= 10 && Char.myCharz().nClass.classId > 0 && (int) numArray[Char.myCharz().nClass.classId] == this.template.npcTemplateId)
      {
        if (Char.myCharz().taskMaint == null)
        {
          this.effTask = GameScr.efs[57];
          this.indexEffTask = 0;
        }
        else if (Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.index + 1 == Char.myCharz().taskMaint.subNames.Length)
        {
          this.effTask = GameScr.efs[62];
          this.indexEffTask = 0;
        }
      }
      else
      {
        sbyte taskNpcId = GameScr.getTaskNpcId();
        if (Char.myCharz().taskMaint == null && (int) taskNpcId == this.template.npcTemplateId)
          this.indexEffTask = 0;
        else if (Char.myCharz().taskMaint != null && (int) taskNpcId == this.template.npcTemplateId)
        {
          if (Char.myCharz().taskMaint.index + 1 == Char.myCharz().taskMaint.subNames.Length)
            this.effTask = GameScr.efs[98];
          else
            this.effTask = GameScr.efs[98];
          this.indexEffTask = 0;
        }
      }
    }
    base.update();
    if (TileMap.mapID != 51)
      return;
    if (this.cx > Char.myCharz().cx)
      this.cdir = -1;
    else
      this.cdir = 1;
    if (this.template.npcTemplateId % 2 != 0)
      return;
    if (this.cf == 1)
      this.cf = 0;
    else
      this.cf = 1;
  }

  public void paintHead(mGraphics g, int xStart, int yStart)
  {
    Part part = GameScr.parts[this.template.headId];
    if (this.cdir == 1)
      SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[this.cf][0][0]].id, GameCanvas.w - 31 - g.getTranslateX(), 2 - g.getTranslateY(), 0, 0);
    else
      SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[this.cf][0][0]].id, GameCanvas.w - 31 - g.getTranslateX(), 2 - g.getTranslateY(), 2, 24);
  }

  public override void paint(mGraphics g)
  {
    if (Char.isLoadingMap || this.isHide || !this.isPaint() || this.statusMe == 15)
      return;
    if (this.cTypePk != (sbyte) 0)
    {
      base.paint(g);
    }
    else
    {
      if (this.template == null)
        return;
      if (this.template.npcTemplateId != 4 && this.template.npcTemplateId != 51 && this.template.npcTemplateId != 50)
        g.drawImage(TileMap.bong, this.cx, this.cy, 3);
      if (this.template.npcTemplateId == 3)
      {
        SmallImage.drawSmallImage(g, 265, this.cx, this.cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
        if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this) && ChatPopup.currChatPopup == null)
          g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch + 4, mGraphics.BOTTOM | mGraphics.HCENTER);
        this.dyEff = 60;
      }
      else if (this.template.npcTemplateId != 4)
      {
        if (this.template.npcTemplateId == 50 || this.template.npcTemplateId == 51)
        {
          if (this.duahau != null)
          {
            if (this.template.npcTemplateId == 50 && Npc.mabuEff)
            {
              ++Npc.tMabuEff;
              if (GameCanvas.gameTick % 3 == 0)
                EffecMn.addEff(new Effect(19, this.cx + Res.random(-50, 50), this.cy, 2, 1, -1));
              if (GameCanvas.gameTick % 15 == 0)
                EffecMn.addEff(new Effect(18, this.cx + Res.random(-5, 5), this.cy + Res.random(-90, 0), 2, 1, -1));
              if (Npc.tMabuEff == 100)
                GameScr.gI().activeSuperPower(this.cx, this.cy);
              if (Npc.tMabuEff == 110)
              {
                Npc.mabuEff = false;
                this.template.npcTemplateId = 4;
              }
            }
            int num = 0;
            if (SmallImage.imgNew[this.duahau[this.duaHauIndex]] != null && SmallImage.imgNew[this.duahau[this.duaHauIndex]].img != null)
              num = mGraphics.getImageHeight(SmallImage.imgNew[this.duahau[this.duaHauIndex]].img);
            SmallImage.drawSmallImage(g, this.duahau[this.duaHauIndex], this.cx + Res.random(-1, 1), this.cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
            if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this))
            {
              if (ChatPopup.currChatPopup == null)
                g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch - 9 + 16 - num, mGraphics.BOTTOM | mGraphics.HCENTER);
              mFont.tahoma_7b_white.drawString(g, NinjaUtil.getTime(this.seconds), this.cx, this.cy - this.ch - 16 - mFont.tahoma_7.getHeight() - 20 - num + 16, mFont.CENTER, mFont.tahoma_7b_dark);
            }
            else
              mFont.tahoma_7b_white.drawString(g, NinjaUtil.getTime(this.seconds), this.cx, this.cy - this.ch - 8 - mFont.tahoma_7.getHeight() - 20 - num + 16, mFont.CENTER, mFont.tahoma_7b_dark);
          }
        }
        else if (this.template.npcTemplateId == 6)
        {
          SmallImage.drawSmallImage(g, 545, this.cx, this.cy + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
          if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this) && ChatPopup.currChatPopup == null)
            g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch - 9, mGraphics.BOTTOM | mGraphics.HCENTER);
          mFont.tahoma_7b_white.drawString(g, TileMap.zoneID.ToString() + string.Empty, this.cx, this.cy - this.ch + 19 - mFont.tahoma_7.getHeight(), mFont.CENTER);
        }
        else
        {
          int headId = this.template.headId;
          int legId = this.template.legId;
          int bodyId = this.template.bodyId;
          Part part1 = GameScr.parts[headId];
          Part part2 = GameScr.parts[legId];
          Part part3 = GameScr.parts[bodyId];
          if (this.cdir == 1)
          {
            SmallImage.drawSmallImage(g, (int) part1.pi[Char.CharInfo[this.cf][0][0]].id, this.cx + Char.CharInfo[this.cf][0][1] + (int) part1.pi[Char.CharInfo[this.cf][0][0]].dx, this.cy - Char.CharInfo[this.cf][0][2] + (int) part1.pi[Char.CharInfo[this.cf][0][0]].dy, 0, 0);
            SmallImage.drawSmallImage(g, (int) part2.pi[Char.CharInfo[this.cf][1][0]].id, this.cx + Char.CharInfo[this.cf][1][1] + (int) part2.pi[Char.CharInfo[this.cf][1][0]].dx, this.cy - Char.CharInfo[this.cf][1][2] + (int) part2.pi[Char.CharInfo[this.cf][1][0]].dy, 0, 0);
            SmallImage.drawSmallImage(g, (int) part3.pi[Char.CharInfo[this.cf][2][0]].id, this.cx + Char.CharInfo[this.cf][2][1] + (int) part3.pi[Char.CharInfo[this.cf][2][0]].dx, this.cy - Char.CharInfo[this.cf][2][2] + (int) part3.pi[Char.CharInfo[this.cf][2][0]].dy, 0, 0);
          }
          else
          {
            SmallImage.drawSmallImage(g, (int) part1.pi[Char.CharInfo[this.cf][0][0]].id, this.cx - Char.CharInfo[this.cf][0][1] - (int) part1.pi[Char.CharInfo[this.cf][0][0]].dx, this.cy - Char.CharInfo[this.cf][0][2] + (int) part1.pi[Char.CharInfo[this.cf][0][0]].dy, 2, 24);
            SmallImage.drawSmallImage(g, (int) part2.pi[Char.CharInfo[this.cf][1][0]].id, this.cx - Char.CharInfo[this.cf][1][1] - (int) part2.pi[Char.CharInfo[this.cf][1][0]].dx, this.cy - Char.CharInfo[this.cf][1][2] + (int) part2.pi[Char.CharInfo[this.cf][1][0]].dy, 2, 24);
            SmallImage.drawSmallImage(g, (int) part3.pi[Char.CharInfo[this.cf][2][0]].id, this.cx - Char.CharInfo[this.cf][2][1] - (int) part3.pi[Char.CharInfo[this.cf][2][0]].dx, this.cy - Char.CharInfo[this.cf][2][2] + (int) part3.pi[Char.CharInfo[this.cf][2][0]].dy, 2, 24);
          }
          if (TileMap.mapID != 51)
          {
            int num1 = 15;
            if (this.template.npcTemplateId == 47)
              num1 = 47;
            if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this))
            {
              if (ChatPopup.currChatPopup == null)
                g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.cx, this.cy - this.ch - (num1 - 8), mGraphics.BOTTOM | mGraphics.HCENTER);
            }
            else
            {
              int num2 = 8;
              if (this.template.npcTemplateId == 47)
                num2 = 40;
            }
          }
          this.dyEff = 65;
        }
      }
      if (this.indexEffTask < 0 || this.effTask == null || this.cTypePk != (sbyte) 0)
        return;
      SmallImage.drawSmallImage(g, this.effTask.arrEfInfo[this.indexEffTask].idImg, this.cx + this.effTask.arrEfInfo[this.indexEffTask].dx, this.cy + this.effTask.arrEfInfo[this.indexEffTask].dy - this.dyEff, 0, mGraphics.VCENTER | mGraphics.HCENTER);
      if (GameCanvas.gameTick % 2 != 0)
        return;
      ++this.indexEffTask;
      if (this.indexEffTask < this.effTask.arrEfInfo.Length)
        return;
      this.indexEffTask = 0;
    }
  }

  public void paintName(mGraphics g)
  {
    if (Char.isLoadingMap || this.isHide || !this.isPaint() || this.statusMe == 15 || this.template == null)
      return;
    if (this.template.npcTemplateId == 3)
    {
      if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this))
        mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - 5, mFont.CENTER, mFont.tahoma_7_grey);
      else
        mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - 3 - mFont.tahoma_7.getHeight(), mFont.CENTER, mFont.tahoma_7_grey);
      this.dyEff = 60;
    }
    else
    {
      if (this.template.npcTemplateId == 4)
        return;
      if (this.template.npcTemplateId == 50 || this.template.npcTemplateId == 51)
      {
        if (this.duahau == null)
          return;
        int num = 0;
        if (SmallImage.imgNew[this.duahau[this.duaHauIndex]] != null && SmallImage.imgNew[this.duahau[this.duaHauIndex]].img != null)
          num = mGraphics.getImageHeight(SmallImage.imgNew[this.duahau[this.duaHauIndex]].img);
        if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this))
          mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - num, mFont.CENTER, mFont.tahoma_7_grey);
        else
          mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - 8 - mFont.tahoma_7.getHeight() - num + 16, mFont.CENTER, mFont.tahoma_7_grey);
      }
      else if (this.template.npcTemplateId == 6)
      {
        if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this))
          mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - 16, mFont.CENTER, mFont.tahoma_7_grey);
        else
          mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - 8 - mFont.tahoma_7.getHeight(), mFont.CENTER, mFont.tahoma_7_grey);
      }
      else
      {
        if (TileMap.mapID != 51)
        {
          int num1 = 15;
          if (this.template.npcTemplateId == 47)
            num1 = 47;
          if (Char.myCharz().npcFocus != null && Char.myCharz().npcFocus.Equals((object) this))
          {
            if (TileMap.mapID != 113)
              mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - mFont.tahoma_7.getHeight() - num1, mFont.CENTER, mFont.tahoma_7_grey);
          }
          else
          {
            int num2 = 8;
            if (this.template.npcTemplateId == 47)
              num2 = 40;
            if (TileMap.mapID != 113)
              mFont.tahoma_7_yellow.drawString(g, this.template.name, this.cx, this.cy - this.ch - num2 - mFont.tahoma_7.getHeight(), mFont.CENTER, mFont.tahoma_7_grey);
          }
        }
        this.dyEff = 65;
      }
    }
  }

  public new void hide()
  {
    this.statusMe = 15;
    Char.chatPopup = (ChatPopup) null;
  }
}
