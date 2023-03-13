// Decompiled with JetBrains decompiler
// Type: CrackBallScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class CrackBallScr : mScreen
{
  public static CrackBallScr instance;
  private BallInfo[] listBall;
  private byte step;
  private byte typePrice;
  private int rO;
  private int xO;
  private int yO;
  private int angle;
  private int iAngle;
  private int iDot;
  private int yTo;
  private int indexSelect;
  private int indexSkillSelect;
  private int numTicket;
  private int xP;
  private int yP;
  private int wP;
  private int hP;
  private int price;
  private int cost;
  private int countFr;
  private int countKame;
  private int frame;
  private int vp;
  private int[] xArg;
  private int[] yArg;
  private int[] xDot;
  private int[] yDot;
  private short[] idItem;
  private long timeStart;
  private long timeKame;
  private bool isKame;
  private bool isCanSkill;
  private bool isSendSv;
  private short idTicket;
  private static int ySkill;
  private static int[] xSkill;
  private static FrameImage fraImgKame;
  private static FrameImage fraImgKame_1;
  private static FrameImage fraImgKame_2;
  private static Image imgX;
  private static Image imgReplay;
  private byte[] fr = new byte[21]
  {
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 19,
    (byte) 20
  };
  private byte[] nFrame = new byte[12]
  {
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 2,
    (byte) 2,
    (byte) 2,
    (byte) 3,
    (byte) 3,
    (byte) 3
  };

  public CrackBallScr()
  {
    CrackBallScr.xSkill = new int[2];
    CrackBallScr.xSkill[0] = 16;
    CrackBallScr.ySkill = GameCanvas.h - 41;
    CrackBallScr.xSkill[1] = GameCanvas.w - 40;
    CrackBallScr.fraImgKame = new FrameImage(GameCanvas.loadImage("/e/e_1.png"), 30, 30);
    CrackBallScr.fraImgKame_1 = new FrameImage(GameCanvas.loadImage("/e/e_0.png"), 68, 65);
    CrackBallScr.fraImgKame_2 = new FrameImage(GameCanvas.loadImage("/e/e_2.png"), 66, 70);
    CrackBallScr.imgReplay = GameCanvas.loadImage("/e/nut2.png");
    CrackBallScr.imgX = GameCanvas.loadImage("/e/nut3.png");
    this.wP = 230;
    this.xP = GameCanvas.hw - this.wP / 2;
    this.hP = 40;
    this.yP = -this.hP;
  }

  public static CrackBallScr gI()
  {
    if (CrackBallScr.instance == null)
      CrackBallScr.instance = new CrackBallScr();
    return CrackBallScr.instance;
  }

  public void SetCrackBallScr(short[] idImage, byte typePrice, int price, short idTicket)
  {
    if (idImage == null || idImage.Length <= 0)
      return;
    this.yTo = Char.myCharz().cy - 10;
    this.setAuraItem();
    this.listBall = new BallInfo[idImage.Length];
    for (int index = 0; index < this.listBall.Length; ++index)
    {
      this.listBall[index] = new BallInfo();
      this.listBall[index].idImg = (int) idImage[index];
      this.listBall[index].count = index * 25;
      this.listBall[index].yTo = -999;
      this.listBall[index].vx = Res.random(2, 5);
      this.listBall[index].dir = Res.random(-1, 2);
      this.listBall[index].SetChar();
    }
    this.isCanSkill = false;
    this.isKame = false;
    this.isSendSv = false;
    this.timeStart = GameCanvas.timeNow + (long) Res.random(1000, 2000);
    this.step = (byte) 0;
    this.indexSelect = -1;
    this.indexSkillSelect = -1;
    this.typePrice = typePrice;
    this.price = price;
    this.cost = 0;
    Char.myCharz().moveTo(470, 408, 1);
    Char.myCharz().cdir = 2;
    Char.myCharz().statusMe = 1;
    this.countFr = 0;
    this.countKame = 0;
    this.frame = 0;
    this.vp = 0;
    this.yP = -this.hP;
    this.idTicket = idTicket;
    this.numTicket = 0;
    this.checkNumTicket();
    this.switchToMe();
    SoundMn.gI().hoisinh();
  }

  private void setAuraItem()
  {
    this.rO = GameCanvas.hh / 3 + 10;
    if (this.rO > 50)
      this.rO = 50;
    this.xO = 360;
    GameScr.cmx = GameScr.cmxLim / 2;
    this.yO = GameScr.cmy + GameCanvas.hh / 3 + 30;
    this.iDot = 175;
    this.angle = 0;
    this.iAngle = 360 / this.iDot;
    this.xArg = new int[this.iDot];
    this.yArg = new int[this.iDot];
    this.xDot = new int[this.iDot];
    this.yDot = new int[this.iDot];
    this.setDotPosition();
  }

  private void setDotPosition()
  {
    if (GameCanvas.lowGraphic)
      return;
    for (int index = 0; index < this.yArg.Length; ++index)
    {
      this.yArg[index] = Res.abs(this.rO * Res.sin(this.angle) / 1024);
      this.xArg[index] = Res.abs(this.rO * Res.cos(this.angle) / 1024);
      if (this.angle < 90)
      {
        this.xDot[index] = this.xO + this.xArg[index];
        this.yDot[index] = this.yO - this.yArg[index];
      }
      else if (this.angle >= 90 && this.angle < 180)
      {
        this.xDot[index] = this.xO - this.xArg[index];
        this.yDot[index] = this.yO - this.yArg[index];
      }
      else if (this.angle >= 180 && this.angle < 270)
      {
        this.xDot[index] = this.xO - this.xArg[index];
        this.yDot[index] = this.yO + this.yArg[index];
      }
      else
      {
        this.xDot[index] = this.xO + this.xArg[index];
        this.yDot[index] = this.yO + this.yArg[index];
      }
      this.angle += this.iAngle;
    }
  }

  public void perform(int idAction, object p)
  {
  }

  public override void update()
  {
    try
    {
      this.cost = this.price * (int) this.checkNum();
      this.checkNumTicket();
      GameScr.gI().update();
      if (this.timeStart - GameCanvas.timeNow > 0L)
      {
        for (int index = 0; index < this.listBall.Length; ++index)
        {
          this.listBall[index].count += 2;
          if (this.listBall[index].count >= this.iDot)
            this.listBall[index].count = 0;
          this.listBall[index].x = this.xDot[this.listBall[index].count];
          this.listBall[index].y = this.yDot[this.listBall[index].count];
        }
      }
      else
      {
        if (this.step == (byte) 0)
          this.step = (byte) 1;
        if (this.step == (byte) 1)
        {
          for (int index = 0; index < this.listBall.Length; ++index)
          {
            if (this.listBall[index].yTo != -999 && !this.listBall[index].isDone)
            {
              if (this.listBall[index].y < this.listBall[index].yTo)
              {
                if (this.listBall[index].vy < 0)
                  this.listBall[index].vy = 0;
                if (this.listBall[index].y + this.listBall[index].vy > this.listBall[index].yTo)
                  this.listBall[index].y = this.listBall[index].yTo;
                else
                  this.listBall[index].y += this.listBall[index].vy;
                ++this.listBall[index].vy;
              }
              else
              {
                if (this.listBall[index].vy > 0)
                  this.listBall[index].vy = 0;
                this.listBall[index].y += this.listBall[index].vy;
                --this.listBall[index].vy;
              }
              if (this.listBall[index].y == this.listBall[index].yTo)
              {
                EffecMn.addEff(new Effect(19, this.listBall[index].x - 5, this.listBall[index].y + 25, 2, 1, -1));
                SoundMn.gI().charFall();
                this.listBall[index].isDone = true;
                if (!this.isCanSkill)
                  this.isCanSkill = true;
              }
            }
          }
        }
        if (this.step == (byte) 2)
        {
          for (int index = 0; index < this.listBall.Length; ++index)
          {
            if (!this.listBall[index].isDone)
            {
              if (this.listBall[index].y > -10)
              {
                if (this.listBall[index].vy > 0)
                  this.listBall[index].vy = 0;
                this.listBall[index].y += this.listBall[index].vy;
                --this.listBall[index].vy;
                this.listBall[index].x += this.listBall[index].vx * this.listBall[index].dir;
                this.listBall[index].vx -= 3;
              }
              if (this.listBall[index].y == -10)
                this.listBall[index].isPaint = false;
            }
          }
          ++this.countFr;
          if (this.countFr > this.fr.Length - 1)
          {
            this.countFr = this.fr.Length - 1;
            this.isKame = true;
            SoundMn.gI().newKame();
            if (!this.isSendSv && this.timeKame - GameCanvas.timeNow < 0L)
            {
              Service.gI().SendCrackBall((byte) 2, (byte) ((uint) this.checkTicket() + (uint) this.checkNum()));
              this.isSendSv = true;
            }
          }
          Char.myCharz().cf = (int) this.fr[this.countFr];
          ++this.countKame;
          if (this.countKame > 5)
            this.countKame = 0;
          this.frame = (int) this.nFrame[this.countKame];
        }
        if (this.step == (byte) 3)
        {
          if (this.countKame <= 5)
            this.countKame = 5;
          ++this.countKame;
          if (this.countKame > this.nFrame.Length - 1)
          {
            this.countKame = this.nFrame.Length - 1;
            this.step = (byte) 4;
            this.isKame = false;
            int index1 = 0;
            for (int index2 = 0; index2 < this.listBall.Length; ++index2)
            {
              if (this.listBall[index2].isDone && !this.listBall[index2].isSetImg)
              {
                this.listBall[index2].idImg = (int) this.idItem[index1];
                this.listBall[index2].isSetImg = true;
                ++index1;
              }
            }
          }
          this.frame = (int) this.nFrame[this.countKame];
        }
        if (this.step == (byte) 4)
        {
          for (int index = 0; index < this.listBall.Length; ++index)
          {
            if (this.listBall[index].isPaint)
              this.listBall[index].xTo = Char.myCharz().cx;
          }
          this.step = (byte) 5;
        }
        if (this.step != (byte) 5)
          return;
        ++this.vp;
        if (this.yP < GameCanvas.hh / 3)
        {
          if (this.yP + this.vp > GameCanvas.hh / 3)
            this.yP = GameCanvas.hh / 3;
          else
            this.yP += this.vp;
        }
        for (int index = 0; index < this.listBall.Length; ++index)
        {
          if (this.listBall[index].isPaint)
          {
            if (this.listBall[index].x < this.listBall[index].xTo)
            {
              if (this.listBall[index].vx < 0)
                this.listBall[index].vx = 0;
              if (this.listBall[index].x + this.listBall[index].vx > this.listBall[index].xTo)
                this.listBall[index].x = this.listBall[index].xTo;
              else
                this.listBall[index].x += this.listBall[index].vx;
              ++this.listBall[index].vx;
            }
            else
            {
              if (this.listBall[index].vx > 0)
                this.listBall[index].vx = 0;
              this.listBall[index].x += this.listBall[index].vx;
              --this.listBall[index].vx;
            }
            if (this.listBall[index].x == this.listBall[index].xTo)
              this.listBall[index].isPaint = false;
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public override void updateKey()
  {
    if (InfoDlg.isLock)
      return;
    if (GameCanvas.isTouch && !ChatTextField.gI().isShow && !GameCanvas.menu.showMenu)
      this.updateKeyTouchControl();
    for (int index = 1; index < 8; ++index)
    {
      if (GameCanvas.keyPressed[index])
      {
        GameCanvas.keyPressed[index] = false;
        this.doClickBall(index - 1);
      }
    }
    if (GameCanvas.keyPressed[12])
    {
      GameCanvas.keyPressed[12] = false;
      this.doClickSkill(0);
    }
    if (GameCanvas.keyPressed[13])
    {
      GameCanvas.keyPressed[13] = false;
      this.doClickSkill(1);
    }
    GameCanvas.clearKeyPressed();
  }

  private void updateKeyTouchControl()
  {
    if (this.step == (byte) 1 && GameCanvas.isPointerClick)
    {
      for (int index = 0; index < this.listBall.Length; ++index)
      {
        if (GameCanvas.isPointerHoldIn(this.listBall[index].x - 20 - GameScr.cmx, this.listBall[index].y - 10 - GameScr.cmy, 30, 30) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          this.doClickBall(index);
      }
    }
    if (!GameCanvas.isPointerClick)
      return;
    for (int index = 0; index < CrackBallScr.xSkill.Length; ++index)
    {
      if (GameCanvas.isPointerHoldIn(CrackBallScr.xSkill[index], CrackBallScr.ySkill, 36, 36) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
        this.doClickSkill(index);
    }
  }

  private void doClickBall(int index)
  {
    if (this.listBall[index].isDone)
      return;
    SoundMn.gI().getItem();
    long num = this.typePrice != (byte) 0 ? (long) Char.myCharz().checkLuong() : Char.myCharz().xu;
    if ((int) this.checkTicket() >= this.numTicket && num < (long) (this.cost + this.price))
    {
      string s = mResources.not_enough_money_1 + " " + (this.typePrice != (byte) 0 ? mResources.LUONG : mResources.XU);
      GameScr.info1.addInfo(s, 0);
    }
    else
    {
      this.indexSelect = index;
      this.listBall[this.indexSelect].yTo = this.yTo + Res.random(-3, 3);
    }
  }

  private void doClickSkill(int index)
  {
    if (this.indexSkillSelect != index)
      this.indexSkillSelect = index;
    else if (index == 0)
    {
      if (this.step < (byte) 2)
      {
        if ((int) this.checkTicket() + (int) this.checkNum() <= 0)
          return;
        this.step = (byte) 2;
        SoundMn.gI().gong();
        Char.myCharz().setSkillPaint(GameScr.sks[13], 0);
        this.timeKame = GameCanvas.timeNow + (long) Res.random(2000, 3000);
      }
      else
      {
        if (this.yP != GameCanvas.hh / 3)
          return;
        Service.gI().SendCrackBall(this.typePrice, (byte) 0);
      }
    }
    else
    {
      GameScr.gI().isRongThanXuatHien = false;
      GameScr.gI().switchToMe();
    }
  }

  public override void paint(mGraphics g)
  {
    try
    {
      GameScr.gI().paint(g);
      g.translate(-GameScr.cmx, -GameScr.cmy);
      g.translate(0, GameCanvas.transY);
      for (int index = 0; index < this.listBall.Length; ++index)
      {
        if (this.listBall[index].isPaint && this.listBall[index].y > this.listBall[index].yTo - 20)
          g.drawImage(TileMap.bong, this.listBall[index].x, this.listBall[index].yTo + 7, mGraphics.VCENTER | mGraphics.HCENTER);
      }
      for (int index = 0; index < this.listBall.Length; ++index)
      {
        if (this.listBall[index].isPaint)
          SmallImage.drawSmallImage(g, this.listBall[index].idImg, this.listBall[index].x, this.listBall[index].y, 0, mGraphics.VCENTER | mGraphics.HCENTER);
      }
      if (this.isKame)
      {
        if (CrackBallScr.fraImgKame != null)
        {
          int num = Char.myCharz().cx - CrackBallScr.fraImgKame.frameWidth - 28;
          for (int index = 0; index < GameCanvas.w / CrackBallScr.fraImgKame.frameWidth + 1; ++index)
            CrackBallScr.fraImgKame.drawFrame(this.frame, num - index * (CrackBallScr.fraImgKame.frameWidth - 1), Char.myCharz().cy - CrackBallScr.fraImgKame.frameHeight / 2 - 12 + 2, 0, 0, g);
        }
        if (CrackBallScr.fraImgKame_1 != null)
        {
          int num = Char.myCharz().cx - CrackBallScr.fraImgKame_1.frameWidth - 10;
          CrackBallScr.fraImgKame_1.drawFrame(this.frame, num - 5, Char.myCharz().cy - CrackBallScr.fraImgKame_1.frameHeight / 2 - 12, 0, 0, g);
        }
      }
      GameScr.resetTranslate(g);
      int w1 = 240;
      int x1 = GameCanvas.w - w1;
      int y = 15;
      g.setColor(13524492);
      g.fillRect(x1, y - 15, w1, 15);
      g.drawImage(Panel.imgXu, x1 + 11, y - 7, 3);
      g.drawImage(Panel.imgLuong, x1 + 90, y - 8, 3);
      mFont.tahoma_7_yellow.drawString(g, Char.myCharz().xuStr + string.Empty, x1 + 24, y - 13, mFont.LEFT, mFont.tahoma_7_grey);
      mFont.tahoma_7_yellow.drawString(g, Char.myCharz().luongStr + string.Empty, x1 + 100, y - 13, mFont.LEFT, mFont.tahoma_7_grey);
      g.drawImage(Panel.imgLuongKhoa, x1 + 150, y - 7, 3);
      mFont.tahoma_7_yellow.drawString(g, Char.myCharz().luongKhoaStr + string.Empty, x1 + 160, y - 13, mFont.LEFT, mFont.tahoma_7_grey);
      g.drawImage(Panel.imgTicket, x1 + 200, y - 7, 3);
      mFont.tahoma_7_yellow.drawString(g, this.numTicket.ToString() + string.Empty, x1 + 210, y - 13, mFont.LEFT, mFont.tahoma_7_grey);
      if (this.step < (byte) 4)
      {
        int w2 = w1 / 2 + 20;
        int x2 = GameCanvas.w - w2;
        g.setColor(11837316);
        g.fillRect(x2, y, w2, 15);
        if (this.typePrice == (byte) 0)
        {
          g.drawImage(Panel.imgXu, x2 + 21, y + 8, 3);
        }
        else
        {
          g.drawImage(Panel.imgLuongKhoa, x2 + 21, y + 7, 3);
          g.drawImage(Panel.imgLuong, x2 + 18, y + 7, 3);
        }
        mFont.tahoma_7_red.drawString(g, " -" + (object) this.cost, x2 + 30, y + 2, mFont.LEFT, mFont.tahoma_7_grey);
        g.drawImage(Panel.imgTicket, x2 + 80, y + 7, 3);
        mFont.tahoma_7_red.drawString(g, " -" + (object) this.checkTicket(), x2 + 90, y + 2, mFont.LEFT, mFont.tahoma_7_grey);
      }
      g.drawImage(GameScr.imgSkill, CrackBallScr.xSkill[0], CrackBallScr.ySkill, 0);
      if (this.indexSkillSelect == 0)
        g.drawImage(GameScr.imgSkill2, CrackBallScr.xSkill[0], CrackBallScr.ySkill, 0);
      if (this.step < (byte) 3)
        SmallImage.drawSmallImage(g, 540, CrackBallScr.xSkill[0] + 14, CrackBallScr.ySkill + 14, 0, StaticObj.VCENTER_HCENTER);
      else
        g.drawImage(CrackBallScr.imgReplay, CrackBallScr.xSkill[0] + 14 - 10, CrackBallScr.ySkill + 14 - 10, 0);
      g.drawImage(GameScr.imgSkill, CrackBallScr.xSkill[1], CrackBallScr.ySkill, 0);
      if (this.indexSkillSelect == 1)
        g.drawImage(GameScr.imgSkill2, CrackBallScr.xSkill[1], CrackBallScr.ySkill, 0);
      g.drawImage(CrackBallScr.imgX, CrackBallScr.xSkill[1] + 14 - 10, CrackBallScr.ySkill + 14 - 10, 0);
      if (this.step <= (byte) 3)
        return;
      GameCanvas.paintz.paintFrameSimple(this.xP, this.yP, this.wP, this.hP, g);
      int num1 = GameCanvas.hw - this.idItem.Length * 30 / 2;
      for (int index = 0; index < this.idItem.Length; ++index)
        SmallImage.drawSmallImage(g, (int) this.idItem[index], num1 + 5 + index * 30, this.yP + 10, 0, 0);
    }
    catch (Exception ex)
    {
    }
  }

  public void DoneCrackBallScr(short[] idImage)
  {
    this.step = (byte) 3;
    this.idItem = idImage;
  }

  public override void switchToMe()
  {
    GameScr.isPaintOther = true;
    GameScr.gI().isRongThanXuatHien = true;
    base.switchToMe();
  }

  private byte checkTicket()
  {
    byte num = 0;
    for (int index = 0; index < this.listBall.Length; ++index)
    {
      if (this.listBall[index].isDone)
        ++num;
    }
    if ((int) num > this.numTicket)
      num = (byte) this.numTicket;
    return num;
  }

  private byte checkNum()
  {
    byte num1 = 0;
    for (int index = 0; index < this.listBall.Length; ++index)
    {
      if (this.listBall[index].isDone)
        ++num1;
    }
    byte num2 = (byte) ((uint) num1 - (uint) this.checkTicket());
    if (num2 <= (byte) 0)
      num2 = (byte) 0;
    return num2;
  }

  private void checkNumTicket()
  {
    for (int index = 0; index < Char.myCharz().arrItemBag.Length; ++index)
    {
      if (Char.myCharz().arrItemBag[index] != null && (int) Char.myCharz().arrItemBag[index].template.id == (int) this.idTicket)
      {
        this.numTicket = Char.myCharz().arrItemBag[index].quantity;
        break;
      }
    }
  }
}
