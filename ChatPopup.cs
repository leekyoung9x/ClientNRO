// Decompiled with JetBrains decompiler
// Type: ChatPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class ChatPopup : Effect2, IActionListener
{
  public int sayWidth = 100;
  public int delay;
  public int sayRun;
  public string[] says;
  public int cx;
  public int cy;
  public int ch;
  public int cmx;
  public int cmy;
  public int lim;
  public Npc c;
  private bool outSide;
  public static long curr;
  public static long last;
  private int currentLine;
  private string[] lines;
  public Command cmdNextLine;
  public Command cmdMsg1;
  public Command cmdMsg2;
  public static ChatPopup currChatPopup;
  public static ChatPopup serverChatPopUp;
  public static string nextMultiChatPopUp;
  public static Npc nextChar;
  public bool isShopDetail;
  public sbyte starSlot;
  public sbyte maxStarSlot;
  public static Scroll scr;
  public static bool isHavePetNpc;
  public int mH;
  public static int performDelay;
  public int dx;
  public int dy;
  public int second;
  public static int numSlot = 7;
  private int nMaxslot_duoi;
  private int nMaxslot_tren;
  private int nslot_duoi;
  private Image imgStar;
  public int strY;
  private int iconID;
  public bool isClip;
  public static int cmyText;
  private int pxx;
  private int pyy;

  public static void addNextPopUpMultiLine(string strNext, Npc next)
  {
    ChatPopup.nextMultiChatPopUp = strNext;
    ChatPopup.nextChar = next;
    if (ChatPopup.currChatPopup != null)
      return;
    ChatPopup.addChatPopupMultiLine(ChatPopup.nextMultiChatPopUp, 100000, ChatPopup.nextChar);
    ChatPopup.nextMultiChatPopUp = (string) null;
    ChatPopup.nextChar = (Npc) null;
  }

  public static void addBigMessage(string chat, int howLong, Npc c)
  {
    string[] strArray = new string[1]{ chat };
    if (c.charID != 5 && GameScr.info1.isDone)
      GameScr.info1.isUpdate = false;
    Char.isLockKey = true;
    ChatPopup.serverChatPopUp = ChatPopup.addChatPopup(strArray[0], howLong, c);
    ChatPopup.serverChatPopUp.strY = 5;
    ChatPopup.serverChatPopUp.cx = GameCanvas.w / 2 - ChatPopup.serverChatPopUp.sayWidth / 2 - 1;
    ChatPopup.serverChatPopUp.cy = GameCanvas.h - 20 - ChatPopup.serverChatPopUp.ch;
    ChatPopup.serverChatPopUp.currentLine = 0;
    ChatPopup.serverChatPopUp.lines = strArray;
    ChatPopup.scr = new Scroll();
    int length = ChatPopup.serverChatPopUp.says.Length;
    ChatPopup.scr.setStyle(length, 12, ChatPopup.serverChatPopUp.cx, ChatPopup.serverChatPopUp.cy - ChatPopup.serverChatPopUp.strY + 12, ChatPopup.serverChatPopUp.sayWidth + 2, ChatPopup.serverChatPopUp.ch - 25, true, 1);
    SoundMn.gI().openDialog();
  }

  public static void addChatPopupMultiLine(string chat, int howLong, Npc c)
  {
    string[] strArray = Res.split(chat, "\n", 0);
    Char.isLockKey = true;
    ChatPopup.currChatPopup = ChatPopup.addChatPopup(strArray[0], howLong, c);
    ChatPopup.currChatPopup.currentLine = 0;
    ChatPopup.currChatPopup.lines = strArray;
    string close = mResources.CONTINUE;
    if (strArray.Length == 1)
      close = mResources.CLOSE;
    ChatPopup.currChatPopup.cmdNextLine = new Command(close, (IActionListener) ChatPopup.currChatPopup, 8000, (object) null);
    ChatPopup.currChatPopup.cmdNextLine.x = GameCanvas.w / 2 - 35;
    ChatPopup.currChatPopup.cmdNextLine.y = GameCanvas.h - 35;
    SoundMn.gI().openDialog();
  }

  public static ChatPopup addChatPopupWithIcon(string chat, int howLong, Npc c, int idIcon)
  {
    ChatPopup.performDelay = 10;
    ChatPopup o = new ChatPopup();
    o.sayWidth = GameCanvas.w - 30 - (!GameCanvas.menu.showMenu ? 0 : GameCanvas.menu.menuX);
    if (o.sayWidth > 320)
      o.sayWidth = 320;
    if (chat.Length < 10)
      o.sayWidth = 64;
    if (GameCanvas.w == 128)
      o.sayWidth = 128;
    o.says = mFont.tahoma_7_red.splitFontArray(chat, o.sayWidth - 10);
    o.delay = howLong;
    o.c = c;
    o.iconID = idIcon;
    Char.chatPopup = o;
    o.ch = 15 - o.sayRun + o.says.Length * 12 + 10;
    if (o.ch > GameCanvas.h - 80)
      o.ch = GameCanvas.h - 80;
    o.mH = 10;
    if (GameCanvas.menu.showMenu)
      o.mH = 0;
    Effect2.vEffect2.addElement((object) o);
    ChatPopup.isHavePetNpc = false;
    if (c != null && c.charID == 5)
    {
      ChatPopup.isHavePetNpc = true;
      GameScr.info1.addInfo(string.Empty, 1);
    }
    ChatPopup.curr = ChatPopup.last = mSystem.currentTimeMillis();
    o.ch += 15;
    return o;
  }

  public static ChatPopup addChatPopup(string chat, int howLong, Npc c)
  {
    ChatPopup.performDelay = 10;
    ChatPopup o = new ChatPopup();
    o.sayWidth = GameCanvas.w - 30 - (!GameCanvas.menu.showMenu ? 0 : GameCanvas.menu.menuX);
    if (o.sayWidth > 320)
      o.sayWidth = 320;
    if (chat.Length < 10)
      o.sayWidth = 64;
    if (GameCanvas.w == 128)
      o.sayWidth = 128;
    o.says = mFont.tahoma_7_red.splitFontArray(chat, o.sayWidth - 10);
    o.delay = howLong;
    o.c = c;
    Char.chatPopup = o;
    o.ch = 15 - o.sayRun + o.says.Length * 12 + 10;
    if (o.ch > GameCanvas.h - 80)
      o.ch = GameCanvas.h - 80;
    o.mH = 10;
    if (GameCanvas.menu.showMenu)
      o.mH = 0;
    Effect2.vEffect2.addElement((object) o);
    ChatPopup.isHavePetNpc = false;
    if (c != null && c.charID == 5)
    {
      ChatPopup.isHavePetNpc = true;
      GameScr.info1.addInfo(string.Empty, 1);
    }
    ChatPopup.curr = ChatPopup.last = mSystem.currentTimeMillis();
    return o;
  }

  public override void update()
  {
    if (ChatPopup.scr != null)
    {
      GameScr.info1.isUpdate = false;
      ChatPopup.scr.updatecm();
    }
    else
      GameScr.info1.isUpdate = true;
    if (GameCanvas.menu.showMenu)
    {
      this.strY = 0;
      this.cx = GameCanvas.w / 2 - this.sayWidth / 2 - 1;
      this.cy = GameCanvas.menu.menuY - this.ch;
    }
    else
    {
      this.strY = 0;
      if (GameScr.gI().right != null || GameScr.gI().left != null || GameScr.gI().center != null || this.cmdNextLine != null || this.cmdMsg1 != null)
      {
        this.strY = 5;
        this.cx = GameCanvas.w / 2 - this.sayWidth / 2 - 1;
        this.cy = GameCanvas.h - 20 - this.ch;
      }
      else
      {
        this.cx = GameCanvas.w / 2 - this.sayWidth / 2 - 1;
        this.cy = GameCanvas.h - 5 - this.ch;
      }
    }
    if (this.delay > 0)
      --this.delay;
    if (ChatPopup.performDelay > 0)
      --ChatPopup.performDelay;
    if (this.sayRun > 1)
      --this.sayRun;
    if ((this.c == null || Char.chatPopup == null || Char.chatPopup == this) && (this.c == null || Char.chatPopup != null) && this.delay != 0)
      return;
    Effect2.vEffect2Outside.removeElement((object) this);
    Effect2.vEffect2.removeElement((object) this);
  }

  public override void paint(mGraphics g)
  {
    if (GameScr.gI().activeRongThan && GameScr.gI().isUseFreez)
      return;
    GameCanvas.resetTrans(g);
    int cx = this.cx;
    int cy = this.cy;
    int w = this.sayWidth + 2;
    int ch = this.ch;
    if ((cx <= 0 || cy <= 0) && !GameCanvas.panel.isShow)
      return;
    PopUp.paintPopUp(g, cx, cy, w, ch, 16777215, false);
    if (this.c != null)
      SmallImage.drawSmallImage(g, this.c.avatar, this.cx + 14, this.cy, 0, StaticObj.BOTTOM_LEFT);
    if (this.iconID != 0)
      SmallImage.drawSmallImage(g, this.iconID, this.cx + w / 2, this.cy + this.ch - 15, 0, StaticObj.VCENTER_HCENTER);
    if (ChatPopup.scr != null)
    {
      g.setClip(cx, cy, w, ch - 16);
      g.translate(0, -ChatPopup.scr.cmy);
    }
    int tx = 0;
    int ty = 0;
    if (this.isClip)
    {
      tx = g.getTranslateX();
      ty = g.getTranslateY();
      g.setClip(cx, cy + 1, w, ch - 17);
      g.translate(0, -ChatPopup.cmyText);
    }
    int num1 = -1;
    for (int index = 0; index < this.says.Length; ++index)
    {
      if (this.says[index].StartsWith("--"))
      {
        g.setColor(0);
        g.fillRect(cx + 10, this.cy + this.sayRun + index * 12 + 6, w - 20, 1);
      }
      else
      {
        mFont mFont = mFont.tahoma_7;
        int align = 2;
        string say = this.says[index];
        int num2;
        if (this.says[index].StartsWith("|"))
        {
          string[] strArray = Res.split(this.says[index], "|", 0);
          if (strArray.Length == 3)
            say = strArray[2];
          if (strArray.Length == 4)
          {
            say = strArray[3];
            align = int.Parse(strArray[2]);
          }
          num2 = int.Parse(strArray[1]);
          num1 = num2;
        }
        else
          num2 = num1;
        switch (num2 + 1)
        {
          case 0:
            mFont = mFont.tahoma_7;
            break;
          case 1:
            mFont = mFont.tahoma_7b_dark;
            break;
          case 2:
            mFont = mFont.tahoma_7b_green;
            break;
          case 3:
            mFont = mFont.tahoma_7b_blue;
            break;
          case 4:
            mFont = mFont.tahoma_7_red;
            break;
          case 5:
            mFont = mFont.tahoma_7_green;
            break;
          case 6:
            mFont = mFont.tahoma_7_blue;
            break;
          case 8:
            mFont = mFont.tahoma_7b_red;
            break;
          case 9:
            mFont = mFont.tahoma_7b_yellow;
            break;
        }
        if (this.says[index].StartsWith("<"))
        {
          string[] strArray = Res.split(Res.split(this.says[index], "<", 0)[1], ">", 1);
          if (this.second == 0)
          {
            this.second = int.Parse(strArray[1]);
          }
          else
          {
            ChatPopup.curr = mSystem.currentTimeMillis();
            if (ChatPopup.curr - ChatPopup.last >= 1000L)
            {
              ChatPopup.last = ChatPopup.curr;
              --this.second;
            }
          }
          string st = this.second.ToString() + " " + strArray[2];
          mFont.drawString(g, st, this.cx + this.sayWidth / 2, this.cy + this.sayRun + index * 12 - this.strY + 12, align);
        }
        else
        {
          if (align == 2)
            mFont.drawString(g, say, this.cx + this.sayWidth / 2, this.cy + this.sayRun + index * 12 - this.strY + 12, align);
          if (align == 1)
            mFont.drawString(g, say, this.cx + this.sayWidth - 5, this.cy + this.sayRun + index * 12 - this.strY + 12, align);
        }
      }
    }
    if (this.isClip)
    {
      GameCanvas.resetTrans(g);
      g.translate(tx, ty);
    }
    if (this.maxStarSlot > (sbyte) 4)
    {
      this.nMaxslot_tren = ((int) this.maxStarSlot + 1) / 2;
      this.nMaxslot_duoi = (int) this.maxStarSlot - this.nMaxslot_tren;
      for (int index = 0; index < this.nMaxslot_tren; ++index)
        g.drawImage(Panel.imgMaxStar, cx + w / 2 - this.nMaxslot_tren * 20 / 2 + index * 20 + mGraphics.getImageWidth(Panel.imgMaxStar), cy + ch - 17, 3);
      for (int index = 0; index < this.nMaxslot_duoi; ++index)
        g.drawImage(Panel.imgMaxStar, cx + w / 2 - this.nMaxslot_duoi * 20 / 2 + index * 20 + mGraphics.getImageWidth(Panel.imgMaxStar), cy + ch - 8, 3);
      if (this.starSlot > (sbyte) 0)
      {
        this.imgStar = Panel.imgStar;
        if ((int) this.starSlot >= this.nMaxslot_tren)
        {
          this.nslot_duoi = (int) this.starSlot - this.nMaxslot_tren;
          for (int index = 0; index < this.nMaxslot_tren; ++index)
            g.drawImage(this.imgStar, cx + w / 2 - this.nMaxslot_tren * 20 / 2 + index * 20 + mGraphics.getImageWidth(this.imgStar), cy + ch - 17, 3);
          for (int index = 0; index < this.nslot_duoi; ++index)
          {
            if (index + this.nMaxslot_tren >= ChatPopup.numSlot)
              this.imgStar = Panel.imgStar8;
            g.drawImage(this.imgStar, cx + w / 2 - this.nMaxslot_duoi * 20 / 2 + index * 20 + mGraphics.getImageWidth(this.imgStar), cy + ch - 8, 3);
          }
        }
        else
        {
          for (int index = 0; index < (int) this.starSlot; ++index)
            g.drawImage(this.imgStar, cx + w / 2 - this.nMaxslot_tren * 20 / 2 + index * 20 + mGraphics.getImageWidth(this.imgStar), cy + ch - 17, 3);
        }
      }
    }
    else
    {
      for (int index = 0; index < (int) this.maxStarSlot; ++index)
        g.drawImage(Panel.imgMaxStar, cx + w / 2 - (int) this.maxStarSlot * 20 / 2 + index * 20 + mGraphics.getImageWidth(Panel.imgMaxStar), cy + ch - 13, 3);
      if (this.starSlot > (sbyte) 0)
      {
        for (int index = 0; index < (int) this.starSlot; ++index)
          g.drawImage(Panel.imgStar, cx + w / 2 - (int) this.maxStarSlot * 20 / 2 + index * 20 + mGraphics.getImageWidth(Panel.imgStar), cy + ch - 13, 3);
      }
    }
    this.paintCmd(g);
  }

  public void paintRada(mGraphics g, int cmyText)
  {
    int cx = this.cx;
    int cy = this.cy;
    int sayWidth = this.sayWidth;
    int ch = this.ch;
    int translateX = g.getTranslateX();
    int translateY = g.getTranslateY();
    g.translate(0, -cmyText);
    if ((cx <= 0 || cy <= 0) && !GameCanvas.panel.isShow)
      return;
    int num1 = -1;
    for (int index = 0; index < this.says.Length; ++index)
    {
      if (this.says[index].StartsWith("--"))
      {
        g.setColor(16777215);
        g.fillRect(cx + 10, this.cy + this.sayRun + index * 12 - 6, sayWidth - 20, 1);
      }
      else
      {
        mFont mFont = mFont.tahoma_7_white;
        int align = 2;
        string say = this.says[index];
        int num2;
        if (this.says[index].StartsWith("|"))
        {
          string[] strArray = Res.split(this.says[index], "|", 0);
          if (strArray.Length == 3)
            say = strArray[2];
          if (strArray.Length == 4)
          {
            say = strArray[3];
            align = int.Parse(strArray[2]);
          }
          num2 = int.Parse(strArray[1]);
          num1 = num2;
        }
        else
          num2 = num1;
        switch (num2 + 1)
        {
          case 0:
            mFont = mFont.tahoma_7_white;
            break;
          case 1:
            mFont = mFont.tahoma_7b_white;
            break;
          case 2:
            mFont = mFont.tahoma_7b_green;
            break;
          case 3:
            mFont = mFont.tahoma_7b_red;
            break;
        }
        if (this.says[index].StartsWith("<"))
        {
          string[] strArray = Res.split(Res.split(this.says[index], "<", 0)[1], ">", 1);
          if (this.second == 0)
          {
            this.second = int.Parse(strArray[1]);
          }
          else
          {
            ChatPopup.curr = mSystem.currentTimeMillis();
            if (ChatPopup.curr - ChatPopup.last >= 1000L)
            {
              ChatPopup.last = ChatPopup.curr;
              --this.second;
            }
          }
          string st = this.second.ToString() + " " + strArray[2];
          mFont.drawString(g, st, this.cx + this.sayWidth / 2, this.cy + this.sayRun + index * 12 - this.strY, align);
        }
        else
        {
          if (align == 2)
            mFont.drawString(g, say, this.cx + this.sayWidth / 2, this.cy + this.sayRun + index * 12 - this.strY, align);
          if (align == 1)
            mFont.drawString(g, say, this.cx + this.sayWidth - 5, this.cy + this.sayRun + index * 12 - this.strY, align);
        }
      }
    }
    GameCanvas.resetTrans(g);
    g.translate(translateX, translateY);
  }

  private void doKeyText(int type)
  {
    ChatPopup.cmyText += 12 * type;
    if (ChatPopup.cmyText < 0)
      ChatPopup.cmyText = 0;
    if (ChatPopup.cmyText <= this.lim)
      return;
    ChatPopup.cmyText = this.lim;
  }

  public void updateKey()
  {
    if (this.isClip)
    {
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
      if (GameCanvas.isPointerHoldIn(this.cx, 0, this.sayWidth + 2, this.ch))
      {
        if (GameCanvas.isPointerMove)
        {
          if (this.pyy == 0)
            this.pyy = GameCanvas.py;
          this.pxx = this.pyy - GameCanvas.py;
          if (this.pxx != 0)
          {
            ChatPopup.cmyText += this.pxx;
            this.pyy = GameCanvas.py;
          }
          if (ChatPopup.cmyText < 0)
            ChatPopup.cmyText = 0;
          if (ChatPopup.cmyText > this.lim)
            ChatPopup.cmyText = this.lim;
        }
        else
        {
          this.pyy = 0;
          this.pyy = 0;
        }
      }
    }
    if (ChatPopup.scr != null)
    {
      if (GameCanvas.isTouch)
        ChatPopup.scr.updateKey();
      if (GameCanvas.keyHold[!Main.isPC ? 2 : 21])
      {
        ChatPopup.scr.cmtoY -= 12;
        if (ChatPopup.scr.cmtoY < 0)
          ChatPopup.scr.cmtoY = 0;
      }
      if (GameCanvas.keyHold[!Main.isPC ? 8 : 22])
      {
        GameCanvas.keyPressed[!Main.isPC ? 8 : 22] = false;
        ChatPopup.scr.cmtoY += 12;
        if (ChatPopup.scr.cmtoY > ChatPopup.scr.cmyLim)
          ChatPopup.scr.cmtoY = ChatPopup.scr.cmyLim;
      }
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.center))
    {
      GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
      mScreen.keyTouch = -1;
      if (this.cmdNextLine != null)
        this.cmdNextLine.performAction();
      else if (this.cmdMsg1 != null)
        this.cmdMsg1.performAction();
      else if (this.cmdMsg2 != null)
        this.cmdMsg2.performAction();
    }
    if (ChatPopup.scr != null && ChatPopup.scr.pointerIsDowning)
      return;
    if (this.cmdMsg1 != null && (GameCanvas.keyPressed[12] || GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(this.cmdMsg1)))
    {
      GameCanvas.keyPressed[12] = false;
      GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
      GameCanvas.isPointerClick = false;
      GameCanvas.isPointerJustRelease = false;
      this.cmdMsg1.performAction();
      mScreen.keyTouch = -1;
    }
    if (this.cmdMsg2 == null || !GameCanvas.keyPressed[13] && !mScreen.getCmdPointerLast(this.cmdMsg2))
      return;
    GameCanvas.keyPressed[13] = false;
    GameCanvas.isPointerClick = false;
    GameCanvas.isPointerJustRelease = false;
    this.cmdMsg2.performAction();
    mScreen.keyTouch = -1;
  }

  public void paintCmd(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    GameCanvas.paintz.paintTabSoft(g);
    if (this.cmdNextLine != null)
      GameCanvas.paintz.paintCmdBar(g, (Command) null, this.cmdNextLine, (Command) null);
    if (this.cmdMsg1 == null)
      return;
    GameCanvas.paintz.paintCmdBar(g, this.cmdMsg1, (Command) null, this.cmdMsg2);
  }

  public void perform(int idAction, object p)
  {
    if (idAction == 1000)
    {
      try
      {
        GameMidlet.instance.platformRequest((string) p);
      }
      catch (Exception ex)
      {
      }
      if (!Main.isPC)
        GameMidlet.instance.notifyDestroyed();
      else
        idAction = 1001;
      GameCanvas.endDlg();
    }
    if (idAction == 1001)
    {
      ChatPopup.scr = (Scroll) null;
      Char.chatPopup = (ChatPopup) null;
      ChatPopup.serverChatPopUp = (ChatPopup) null;
      GameScr.info1.isUpdate = true;
      Char.isLockKey = false;
      if (ChatPopup.isHavePetNpc)
      {
        GameScr.info1.info.time = 0;
        GameScr.info1.info.info.speed = 10;
      }
    }
    if (idAction != 8000 || ChatPopup.performDelay > 0)
      return;
    int index1 = ChatPopup.currChatPopup.currentLine + 1;
    if (index1 >= ChatPopup.currChatPopup.lines.Length)
    {
      Char.chatPopup = (ChatPopup) null;
      ChatPopup.currChatPopup = (ChatPopup) null;
      GameScr.info1.isUpdate = true;
      Char.isLockKey = false;
      if (ChatPopup.nextMultiChatPopUp != null)
      {
        ChatPopup.addChatPopupMultiLine(ChatPopup.nextMultiChatPopUp, 100000, ChatPopup.nextChar);
        ChatPopup.nextMultiChatPopUp = (string) null;
        ChatPopup.nextChar = (Npc) null;
      }
      else
      {
        if (!ChatPopup.isHavePetNpc)
          return;
        GameScr.info1.info.time = 0;
        for (int index2 = 0; index2 < GameScr.info1.info.infoWaitToShow.size(); ++index2)
        {
          if (((InfoItem) GameScr.info1.info.infoWaitToShow.elementAt(index2)).speed == 10000000)
            ((InfoItem) GameScr.info1.info.infoWaitToShow.elementAt(index2)).speed = 10;
        }
      }
    }
    else
    {
      ChatPopup chatPopup = ChatPopup.addChatPopup(ChatPopup.currChatPopup.lines[index1], ChatPopup.currChatPopup.delay, ChatPopup.currChatPopup.c);
      chatPopup.currentLine = index1;
      chatPopup.lines = ChatPopup.currChatPopup.lines;
      chatPopup.cmdNextLine = ChatPopup.currChatPopup.cmdNextLine;
      ChatPopup.currChatPopup = chatPopup;
    }
  }
}
