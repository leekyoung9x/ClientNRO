// Decompiled with JetBrains decompiler
// Type: RadarScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RadarScr : mScreen
{
  public const sbyte SUBCMD_ALL = 0;
  public const sbyte SUBCMD_USE = 1;
  public const sbyte SUBCMD_LEVEL = 2;
  public const sbyte SUBCMD_AMOUNT = 3;
  public const sbyte SUBCMD_AURA = 4;
  public static RadarScr instance;
  public static bool TYPE_UI;
  public static FrameImage fraImgFocus;
  public static FrameImage fraImgFocusNone;
  public static FrameImage fraEff;
  private static Image imgUI;
  private static Image imgUIText;
  private static Image imgArrow_Left;
  private static Image imgArrow_Right;
  private static Image imgArrow_Down;
  private static Image imgLock;
  private static Image imgUse_0;
  private static Image imgUse;
  private static Image imgBack;
  private static Image imgChange;
  private static Image imgBar_0;
  private static Image imgBar_1;
  private static Image imgPro_0;
  private static Image imgPro_1;
  private static Image[] imgRank;
  public static int xUi;
  public static int yUi;
  public static int wUi;
  public static int hUi;
  public static int xMon;
  public static int yMon;
  public static int xText;
  public static int yText;
  public static int wText;
  public static int cmyText;
  public static int hText;
  public static int yCmd;
  public static int[] xCmd = new int[0];
  public static int[] dxCmd = new int[0];
  private static int[][] xyArrow;
  private static int[][] xyItem;
  private static int[] index = new int[5]{ -2, -1, 0, 1, 2 };
  private int dyArrow;
  private int[] dxArrow;
  private int page;
  private int maxpage;
  private int indexFocus;
  public static MyVector list;
  public static MyVector listUse;
  private static int num;
  private static int numMax;
  private Info_RadaScr focus_card;
  private int pxx;
  private int pyy;
  private int xClip;
  private int wClip;
  private int yClip;
  private int hClip;

  public RadarScr()
  {
    RadarScr.TYPE_UI = true;
    Image img1 = mSystem.loadImage("/radar/17.png");
    Image img2 = mSystem.loadImage("/radar/3.png");
    Image img3 = mSystem.loadImage("/radar/23.png");
    RadarScr.fraImgFocus = new FrameImage(img1, 28, 28);
    RadarScr.fraImgFocusNone = new FrameImage(img2, 30, 30);
    RadarScr.fraEff = new FrameImage(img3, 11, 11);
    RadarScr.imgUI = mSystem.loadImage("/radar/0.png");
    RadarScr.imgArrow_Left = mSystem.loadImage("/radar/1.png");
    RadarScr.imgArrow_Right = mSystem.loadImage("/radar/2.png");
    RadarScr.imgUIText = mSystem.loadImage("/radar/17.png");
    RadarScr.imgArrow_Down = mSystem.loadImage("/radar/4.png");
    RadarScr.imgLock = mSystem.loadImage("/radar/5.png");
    RadarScr.imgUse_0 = mSystem.loadImage("/radar/6.png");
    RadarScr.imgRank = new Image[7];
    for (int index = 0; index < 7; ++index)
      RadarScr.imgRank[index] = mSystem.loadImage("/radar/" + (object) (index + 7) + ".png");
    RadarScr.imgUse = mSystem.loadImage("/radar/14.png");
    RadarScr.imgBack = mSystem.loadImage("/radar/15.png");
    RadarScr.imgChange = mSystem.loadImage("/radar/16.png");
    RadarScr.imgUIText = mSystem.loadImage("/radar/18.png");
    RadarScr.imgBar_1 = mSystem.loadImage("/radar/19.png");
    RadarScr.imgPro_0 = mSystem.loadImage("/radar/20.png");
    RadarScr.imgPro_1 = mSystem.loadImage("/radar/21.png");
    RadarScr.imgBar_0 = mSystem.loadImage("/radar/22.png");
    RadarScr.wUi = 200;
    RadarScr.hUi = 219;
    RadarScr.xUi = GameCanvas.hw - (RadarScr.wUi + 40) / 2;
    RadarScr.yUi = GameCanvas.hh - RadarScr.hUi / 2;
    RadarScr.xText = RadarScr.xUi + RadarScr.wUi - 81;
    RadarScr.yText = RadarScr.yUi + 29;
    RadarScr.wText = 120;
    RadarScr.hText = 80;
    RadarScr.xyArrow = new int[3][]
    {
      new int[2]
      {
        RadarScr.xUi + 34,
        RadarScr.yUi + RadarScr.hUi - 42
      },
      new int[2]
      {
        RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgArrow_Down.getWidth() / 2,
        RadarScr.yUi + RadarScr.hUi / 2 + 33
      },
      new int[2]
      {
        RadarScr.xUi + RadarScr.wUi - 41,
        RadarScr.yUi + RadarScr.hUi - 42
      }
    };
    RadarScr.xyItem = new int[5][]
    {
      new int[2]
      {
        RadarScr.xUi + 25,
        RadarScr.yUi + RadarScr.hUi - 82
      },
      new int[2]
      {
        RadarScr.xUi + 57,
        RadarScr.yUi + RadarScr.hUi - 62
      },
      new int[2]
      {
        RadarScr.xUi + RadarScr.wUi / 2 - 14,
        RadarScr.yUi + RadarScr.hUi - 102
      },
      new int[2]
      {
        RadarScr.xUi + RadarScr.wUi - 57 - 28,
        RadarScr.yUi + RadarScr.hUi - 62
      },
      new int[2]
      {
        RadarScr.xUi + RadarScr.wUi - 25 - 28,
        RadarScr.yUi + RadarScr.hUi - 82
      }
    };
    this.dxArrow = new int[2];
    this.dyArrow = 0;
    RadarScr.xMon = RadarScr.xUi + 73;
    RadarScr.yMon = RadarScr.yUi + RadarScr.hUi / 2 + 5;
    RadarScr.yCmd = RadarScr.yUi + RadarScr.hUi - 22;
    RadarScr.xCmd = new int[3]
    {
      RadarScr.xUi + RadarScr.wUi / 2 - 8 - 80,
      RadarScr.xUi + RadarScr.wUi / 2 - 8,
      RadarScr.xUi + RadarScr.wUi / 2 - 8 + 80
    };
    RadarScr.dxCmd = new int[3];
    this.yClip = RadarScr.yText + 10 + 70;
    this.hClip = 0;
    RadarScr.list = new MyVector();
    RadarScr.listUse = new MyVector();
    this.page = 1;
    this.maxpage = 2;
  }

  public static RadarScr gI()
  {
    if (RadarScr.instance == null)
      RadarScr.instance = new RadarScr();
    return RadarScr.instance;
  }

  public void SetRadarScr(MyVector list, int num, int numMax)
  {
    RadarScr.list = list;
    RadarScr.SetNum(num, numMax);
    this.page = 1;
    this.indexFocus = 2;
    this.listIndex();
    RadarScr.TYPE_UI = true;
    RadarScr.SetListUse();
    if (RadarScr.TYPE_UI)
      this.maxpage = list.size() / 5 + (list.size() % 5 <= 0 ? 0 : 1);
    else
      this.maxpage = RadarScr.listUse.size() / 5 + (RadarScr.listUse.size() % 5 <= 0 ? 0 : 1);
  }

  public static void SetNum(int num, int numMax)
  {
    RadarScr.num = num;
    RadarScr.numMax = numMax;
  }

  public static void SetListUse()
  {
    RadarScr.listUse = new MyVector(string.Empty);
    for (int index = 0; index < RadarScr.list.size(); ++index)
    {
      Info_RadaScr o = (Info_RadaScr) RadarScr.list.elementAt(index);
      if (o != null && o.isUse == (sbyte) 1)
        RadarScr.listUse.addElement((object) o);
    }
  }

  public void listIndex()
  {
    MyVector myVector = RadarScr.listUse;
    if (RadarScr.TYPE_UI)
      myVector = RadarScr.list;
    int num1 = (this.page - 1) * 5;
    int num2 = num1 + 5;
    for (int index = num1; index < num2; ++index)
    {
      if (index >= myVector.size())
      {
        RadarScr.index[index - num1] = -1;
      }
      else
      {
        Info_RadaScr infoRadaScr = (Info_RadaScr) myVector.elementAt(index);
        if (infoRadaScr != null)
          RadarScr.index[index - num1] = infoRadaScr.id;
      }
    }
    RadarScr.cmyText = 0;
    RadarScr.hText = 0;
    SoundMn.gI().radarItem();
  }

  public override void update()
  {
    try
    {
      if (RadarScr.hText < 80)
      {
        RadarScr.hText += 4;
        if (RadarScr.hText > 80)
          RadarScr.hText = 80;
      }
      this.focus_card = Info_RadaScr.GetInfo(RadarScr.listUse, RadarScr.index[this.indexFocus]);
      if (RadarScr.TYPE_UI)
        this.focus_card = Info_RadaScr.GetInfo(RadarScr.list, RadarScr.index[this.indexFocus]);
      GameScr.gI().update();
      if (GameCanvas.gameTick % 10 < 6)
      {
        if (GameCanvas.gameTick % 2 == 0)
          --this.dyArrow;
      }
      else
        this.dyArrow = 0;
      if (this.focus_card == null)
        return;
      this.hClip = (int) this.focus_card.amount * 100 / (int) this.focus_card.max_amount * RadarScr.imgBar_1.getHeight() / 100;
      this.wClip = RadarScr.num * 100 / RadarScr.list.size() * RadarScr.imgPro_1.getWidth() / 100;
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("-upd-radaScr-null: " + ex.ToString()));
    }
  }

  public override void updateKey()
  {
    if (InfoDlg.isLock)
      return;
    if (GameCanvas.isTouch && !ChatTextField.gI().isShow && !GameCanvas.menu.showMenu)
      this.updateKeyTouchControl();
    if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22])
    {
      GameCanvas.keyPressed[!Main.isPC ? 8 : 22] = false;
      this.doKeyText(1);
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21])
    {
      GameCanvas.keyPressed[!Main.isPC ? 2 : 21] = false;
      this.doKeyText(-1);
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 4 : 23])
    {
      GameCanvas.keyPressed[!Main.isPC ? 4 : 23] = false;
      this.doKeyItem(1);
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 6 : 24])
    {
      GameCanvas.keyPressed[!Main.isPC ? 6 : 24] = false;
      this.doKeyItem(0);
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
    {
      GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
      this.doClickUse(1);
    }
    if (GameCanvas.keyPressed[13])
      this.doClickUse(2);
    if (GameCanvas.keyPressed[12])
    {
      GameCanvas.keyPressed[12] = false;
      this.doClickUse(0);
    }
    GameCanvas.clearKeyPressed();
  }

  private void doChangeUI()
  {
    RadarScr.TYPE_UI = !RadarScr.TYPE_UI;
    this.page = 1;
    this.indexFocus = 0;
    this.maxpage = !RadarScr.TYPE_UI ? RadarScr.listUse.size() / 5 + (RadarScr.listUse.size() % 5 <= 0 ? 0 : 1) : RadarScr.list.size() / 5 + (RadarScr.list.size() % 5 <= 0 ? 0 : 1);
    this.listIndex();
  }

  private void updateKeyTouchControl()
  {
    if (GameCanvas.isPointerClick)
    {
      for (int focus = 0; focus < 5; ++focus)
      {
        if (GameCanvas.isPointerHoldIn(RadarScr.xyItem[focus][0], RadarScr.xyItem[focus][1], 30, 30) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease && focus != this.indexFocus)
          this.doClickItem(focus);
      }
      if (GameCanvas.isPointerHoldIn(RadarScr.xyArrow[0][0] - 5, RadarScr.xyArrow[0][1] - 5, 20, 20))
      {
        if (GameCanvas.isPointerDown)
          this.dxArrow[0] = 1;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
        {
          this.doClickArrow(0);
          this.dxArrow[0] = 0;
        }
      }
      if (GameCanvas.isPointerHoldIn(RadarScr.xyArrow[2][0] - 5, RadarScr.xyArrow[2][1] - 5, 20, 20))
      {
        if (GameCanvas.isPointerDown)
          this.dxArrow[1] = 1;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
        {
          this.doClickArrow(1);
          this.dxArrow[1] = 0;
        }
      }
      for (int i = 0; i < RadarScr.xCmd.Length; ++i)
      {
        if (GameCanvas.isPointerHoldIn(RadarScr.xCmd[i] - 5, RadarScr.yCmd - 5, 20, 20))
        {
          if (GameCanvas.isPointerDown)
            RadarScr.dxCmd[i] = 1;
          if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          {
            this.doClickUse(i);
            RadarScr.dxCmd[i] = 0;
          }
        }
      }
    }
    else
    {
      RadarScr.dxCmd[0] = 0;
      RadarScr.dxCmd[1] = 0;
      RadarScr.dxCmd[2] = 0;
      this.dxArrow[0] = 0;
      this.dxArrow[1] = 0;
    }
    if (!GameCanvas.isPointerHoldIn(RadarScr.xText, 0, RadarScr.wText, RadarScr.yText + RadarScr.hText))
      return;
    if (GameCanvas.isPointerMove)
    {
      if (this.pyy == 0)
        this.pyy = GameCanvas.py;
      this.pxx = this.pyy - GameCanvas.py;
      if (this.pxx != 0)
      {
        RadarScr.cmyText += this.pxx;
        this.pyy = GameCanvas.py;
      }
      if (RadarScr.cmyText < 0)
        RadarScr.cmyText = 0;
      if (RadarScr.cmyText <= this.focus_card.cp.lim)
        return;
      RadarScr.cmyText = this.focus_card.cp.lim;
    }
    else
    {
      this.pyy = 0;
      this.pyy = 0;
    }
  }

  private void doClickUse(int i)
  {
    switch (i)
    {
      case 0:
        this.doChangeUI();
        break;
      case 1:
        if (this.focus_card != null)
        {
          Service.gI().SendRada(1, this.focus_card.id);
          break;
        }
        break;
      case 2:
        GameScr.gI().switchToMe();
        break;
    }
    SoundMn.gI().radarClick();
  }

  private void doClickArrow(int dir)
  {
    this.maxpage = !RadarScr.TYPE_UI ? RadarScr.listUse.size() / 5 + (RadarScr.listUse.size() % 5 <= 0 ? 0 : 1) : RadarScr.list.size() / 5 + (RadarScr.list.size() % 5 <= 0 ? 0 : 1);
    int page = this.page;
    int num;
    if (dir == 0)
    {
      if (this.page == 1)
        return;
      num = page - 1;
      if (num < 1)
        num = 1;
    }
    else
    {
      if (this.page == this.maxpage)
        return;
      num = page + 1;
      if (num > this.maxpage)
        num = this.maxpage;
    }
    if (num == this.page)
      return;
    this.page = num;
    this.listIndex();
  }

  private void doClickItem(int focus)
  {
    this.indexFocus = focus;
    this.listIndex();
  }

  private void doKeyText(int type)
  {
    RadarScr.cmyText += 12 * type;
    if (RadarScr.cmyText < 0)
      RadarScr.cmyText = 0;
    if (RadarScr.cmyText <= this.focus_card.cp.lim)
      return;
    RadarScr.cmyText = this.focus_card.cp.lim;
  }

  private void doKeyItem(int type)
  {
    int indexFocus = this.indexFocus;
    int page = this.page;
    int num = type != 0 ? indexFocus - 1 : indexFocus + 1;
    if (num >= RadarScr.index.Length)
    {
      if (this.page < this.maxpage)
      {
        num = 0;
        ++page;
      }
      else
        num = RadarScr.index.Length - 1;
    }
    if (num < 0)
    {
      if (this.page > 1)
      {
        num = RadarScr.index.Length - 1;
        --page;
      }
      else
        num = 0;
    }
    if (num != this.indexFocus)
    {
      this.indexFocus = num;
      RadarScr.cmyText = 0;
      RadarScr.hText = 0;
    }
    if (page == this.page)
      return;
    this.page = page;
    this.listIndex();
  }

  public override void paint(mGraphics g)
  {
    try
    {
      GameScr.gI().paint(g);
      g.translate(-GameScr.cmx, -GameScr.cmy);
      g.translate(0, GameCanvas.transY);
      GameScr.resetTranslate(g);
      g.drawImage(RadarScr.imgUI, RadarScr.xUi, RadarScr.yUi, 0);
      g.drawImage(RadarScr.imgPro_0, RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgPro_0.getWidth() / 2, RadarScr.yUi - RadarScr.imgPro_0.getHeight() / 2 - 2, 0);
      g.setClip(RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgPro_0.getWidth() / 2 + 13, RadarScr.yUi - RadarScr.imgPro_0.getHeight() / 2 + 3, this.wClip, RadarScr.imgPro_0.getHeight());
      g.drawImage(RadarScr.imgPro_1, RadarScr.xUi + RadarScr.wUi / 2 - RadarScr.imgPro_0.getWidth() / 2 + 13, RadarScr.yUi - RadarScr.imgPro_0.getHeight() / 2 + 3, 0);
      GameScr.resetTranslate(g);
      g.drawImage(RadarScr.imgChange, RadarScr.xCmd[0], RadarScr.yCmd + RadarScr.dxCmd[0], 0);
      g.drawImage(RadarScr.imgUse_0, RadarScr.xCmd[1], RadarScr.yCmd + RadarScr.dxCmd[1], 0);
      g.drawImage(RadarScr.imgBack, RadarScr.xCmd[2], RadarScr.yCmd + RadarScr.dxCmd[2], 0);
      if (RadarScr.TYPE_UI)
        g.drawRegion(RadarScr.imgUse, 0, 0, 17, 17, 0, RadarScr.xCmd[1], RadarScr.yCmd + RadarScr.dxCmd[1], 0);
      else
        g.drawRegion(RadarScr.imgUse, 0, 0, 17, 17, 1, RadarScr.xCmd[1], RadarScr.yCmd + RadarScr.dxCmd[1], 0);
      if (this.focus_card != null)
      {
        g.setClip(RadarScr.xUi + 30, RadarScr.yUi + 13, RadarScr.wUi - 60, RadarScr.hUi / 2);
        this.focus_card.paintInfo(g, RadarScr.xMon, RadarScr.yMon);
        GameScr.resetTranslate(g);
        mFont.tahoma_7b_yellow.drawString(g, (this.focus_card.level <= (sbyte) 0 ? " " : "Lv." + (object) this.focus_card.level + " ") + this.focus_card.name, RadarScr.xUi + RadarScr.wUi / 2, RadarScr.yUi + 15, 2);
        mFont.tahoma_7_white.drawString(g, "no." + (object) this.focus_card.no, RadarScr.xUi + 30, RadarScr.yText - 2, 0);
        g.drawImage(RadarScr.imgBar_0, RadarScr.xUi + 36, RadarScr.yText + 10, 0);
        g.setClip(RadarScr.xUi + 36, this.yClip - this.hClip, 7, this.hClip);
        g.drawImage(RadarScr.imgBar_1, RadarScr.xUi + 36, RadarScr.yText + 10, 0);
        GameScr.resetTranslate(g);
        g.drawImage(RadarScr.imgRank[(int) this.focus_card.rank], RadarScr.xUi + 39 - 5 + 14, RadarScr.yText + 12, 0);
      }
      g.setClip(RadarScr.xText, RadarScr.yText, RadarScr.wText + 5, RadarScr.hText + 8);
      if (this.focus_card != null)
        g.drawImage(RadarScr.imgUIText, RadarScr.xText, RadarScr.yText, 0);
      GameScr.resetTranslate(g);
      g.setClip(RadarScr.xText, RadarScr.yText + 1, RadarScr.wText, RadarScr.hText + 5);
      if (this.focus_card != null && this.focus_card.cp != null)
      {
        if (this.focus_card.cp.says == null)
          return;
        this.focus_card.cp.paintRada(g, RadarScr.cmyText);
      }
      GameScr.resetTranslate(g);
      if (!RadarScr.TYPE_UI && RadarScr.listUse.size() > 5 || RadarScr.TYPE_UI)
      {
        if (this.page > 1)
          g.drawImage(RadarScr.imgArrow_Left, RadarScr.xyArrow[0][0], RadarScr.xyArrow[0][1] + this.dxArrow[0], 0);
        if (this.page < this.maxpage)
          g.drawImage(RadarScr.imgArrow_Right, RadarScr.xyArrow[2][0], RadarScr.xyArrow[2][1] + this.dxArrow[1], 0);
      }
      for (int index = 0; index < RadarScr.index.Length; ++index)
      {
        int num1 = 0;
        int num2 = 0;
        int idx = 0;
        if (index == this.indexFocus)
        {
          num1 = this.dyArrow;
          num2 = -10;
          idx = 1;
          g.drawImage(RadarScr.imgArrow_Down, RadarScr.xyItem[index][0] + 10, RadarScr.xyItem[index][1] + this.dyArrow + 29 + num2, 0);
        }
        Info_RadaScr info = Info_RadaScr.GetInfo(RadarScr.listUse, RadarScr.index[index]);
        if (RadarScr.TYPE_UI)
          info = Info_RadaScr.GetInfo(RadarScr.list, RadarScr.index[index]);
        if (info != null)
        {
          RadarScr.fraImgFocus.drawFrame((int) info.rank, RadarScr.xyItem[index][0], RadarScr.xyItem[index][1] + num1 + num2, 0, 0, g);
          SmallImage.drawSmallImage(g, info.idIcon, RadarScr.xyItem[index][0] + 14, RadarScr.xyItem[index][1] + 14 + num1 + num2, 0, StaticObj.VCENTER_HCENTER);
          info.paintEff(g, RadarScr.xyItem[index][0], RadarScr.xyItem[index][1] + num1 + num2);
          if (info.level == (sbyte) 0)
            g.drawImage(RadarScr.imgLock, RadarScr.xyItem[index][0], RadarScr.xyItem[index][1] + num1 + num2, 0);
          if (index == this.indexFocus)
            RadarScr.fraImgFocus.drawFrame(7, RadarScr.xyItem[index][0], RadarScr.xyItem[index][1] + num1 + num2, 0, 0, g);
          if (info.isUse == (sbyte) 1)
            RadarScr.fraImgFocus.drawFrame(8, RadarScr.xyItem[index][0], RadarScr.xyItem[index][1] + num1 + num2, 0, 0, g);
        }
        else
          RadarScr.fraImgFocusNone.drawFrame(idx, RadarScr.xyItem[index][0] - 1, RadarScr.xyItem[index][1] - 1 + num1 + num2, 0, 0, g);
      }
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("-pnt-radaScr-null: " + ex.ToString()));
    }
  }

  public override void switchToMe()
  {
    GameScr.isPaintOther = true;
    base.switchToMe();
  }
}
