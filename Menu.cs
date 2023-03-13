// Decompiled with JetBrains decompiler
// Type: Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Menu
{
  public bool showMenu;
  public MyVector menuItems;
  public int menuSelectedItem;
  public int menuX;
  public int menuY;
  public int menuW;
  public int menuH;
  public static int[] menuTemY;
  public static int cmtoX;
  public static int cmx;
  public static int cmdy;
  public static int cmvy;
  public static int cmxLim;
  public static int xc;
  private Command left = new Command(mResources.SELECT, 0);
  private Command right = new Command(mResources.CLOSE, 0, GameCanvas.w - 71, GameCanvas.h - mScreen.cmdH + 1);
  private Command center;
  public static Image imgMenu1;
  public static Image imgMenu2;
  private bool disableClose;
  public int tDelay;
  public int w;
  private int pa;
  private bool trans;
  private int pointerDownTime;
  private int pointerDownFirstX;
  private int[] pointerDownLastX = new int[3];
  private bool pointerIsDowning;
  private bool isDownWhenRunning;
  private bool wantUpdateList;
  private int waitToPerform;
  private int cmRun;
  private bool touch;
  private bool close;
  private int cmvx;
  private int cmdx;
  private bool isClose;
  public bool[] isNotClose;

  public static void loadBg()
  {
    Menu.imgMenu1 = GameCanvas.loadImage("/mainImage/myTexture2dbtMenu1.png");
    Menu.imgMenu2 = GameCanvas.loadImage("/mainImage/myTexture2dbtMenu2.png");
  }

  public void startWithoutCloseButton(MyVector menuItems, int pos)
  {
    this.startAt(menuItems, pos);
    this.disableClose = true;
  }

  public void startAt(MyVector menuItems, int x, int y)
  {
    this.startAt(menuItems, 0);
    this.menuX = x;
    this.menuY = y;
    while (this.menuY + this.menuH > GameCanvas.h)
      this.menuY -= 2;
  }

  public void startAt(MyVector menuItems, int pos)
  {
    if (this.showMenu)
      return;
    this.isClose = false;
    this.touch = false;
    this.close = false;
    this.tDelay = 0;
    if (menuItems.size() == 1)
    {
      this.menuSelectedItem = 0;
      Command command = (Command) menuItems.elementAt(0);
      if (command != null && command.caption.Equals(mResources.saying))
      {
        command.performAction();
        this.showMenu = false;
        InfoDlg.showWait();
        return;
      }
    }
    SoundMn.gI().openMenu();
    this.isNotClose = new bool[menuItems.size()];
    for (int index = 0; index < this.isNotClose.Length; ++index)
      this.isNotClose[index] = false;
    this.disableClose = false;
    ChatPopup.currChatPopup = (ChatPopup) null;
    Effect2.vEffect2.removeAllElements();
    Effect2.vEffect2Outside.removeAllElements();
    InfoDlg.hide();
    if (menuItems.size() == 0)
      return;
    this.menuItems = menuItems;
    this.menuW = 60;
    this.menuH = 60;
    for (int index = 0; index < menuItems.size(); ++index)
    {
      Command command = (Command) menuItems.elementAt(index);
      command.isPlaySoundButton = false;
      mFont.tahoma_7_yellow.getWidth(command.caption);
      command.subCaption = mFont.tahoma_7_yellow.splitFontArray(command.caption, this.menuW - 10);
      Res.outz("c caption= " + command.caption);
    }
    Menu.menuTemY = new int[menuItems.size()];
    this.menuX = (GameCanvas.w - menuItems.size() * this.menuW) / 2;
    if (this.menuX < 1)
      this.menuX = 1;
    this.menuY = GameCanvas.h - this.menuH - (Paint.hTab + 1) - 1;
    if (GameCanvas.isTouch)
      this.menuY -= 3;
    this.menuY += 27;
    for (int index = 0; index < Menu.menuTemY.Length; ++index)
      Menu.menuTemY[index] = GameCanvas.h;
    this.showMenu = true;
    this.menuSelectedItem = 0;
    Menu.cmxLim = this.menuItems.size() * this.menuW - GameCanvas.w;
    if (Menu.cmxLim < 0)
      Menu.cmxLim = 0;
    Menu.cmtoX = 0;
    Menu.cmx = 0;
    Menu.xc = 50;
    this.w = menuItems.size() * this.menuW - 1;
    if (this.w > GameCanvas.w - 2)
      this.w = GameCanvas.w - 2;
    if (!GameCanvas.isTouch || Main.isPC)
      return;
    this.menuSelectedItem = -1;
  }

  public bool isScrolling() => !this.isClose && Menu.menuTemY[Menu.menuTemY.Length - 1] > this.menuY || this.isClose && Menu.menuTemY[Menu.menuTemY.Length - 1] < GameCanvas.h;

  public void updateMenuKey()
  {
    if (GameScr.gI().activeRongThan && GameScr.gI().isUseFreez || !this.showMenu || this.isScrolling())
      return;
    bool flag1 = false;
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21] || GameCanvas.keyPressed[!Main.isPC ? 4 : 23])
    {
      flag1 = true;
      --this.menuSelectedItem;
      if (this.menuSelectedItem < 0)
        this.menuSelectedItem = this.menuItems.size() - 1;
    }
    else if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22] || GameCanvas.keyPressed[!Main.isPC ? 6 : 24])
    {
      flag1 = true;
      ++this.menuSelectedItem;
      if (this.menuSelectedItem > this.menuItems.size() - 1)
        this.menuSelectedItem = 0;
    }
    else if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
    {
      if (this.center != null)
      {
        if (this.center.idAction > 0)
        {
          if (this.center.actionListener == GameScr.gI())
            GameScr.gI().actionPerform(this.center.idAction, this.center.p);
          else
            this.perform(this.center.idAction, this.center.p);
        }
      }
      else
        this.waitToPerform = 2;
    }
    else if (GameCanvas.keyPressed[12] && !GameScr.gI().isRongThanMenu())
    {
      if (this.isScrolling())
        return;
      if (this.left.idAction > 0)
        this.perform(this.left.idAction, this.left.p);
      else
        this.waitToPerform = 2;
      SoundMn.gI().buttonClose();
    }
    else if (!GameScr.gI().isRongThanMenu() && !this.disableClose && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.right)))
    {
      if (this.isScrolling())
        return;
      if (!this.close)
        this.close = true;
      this.isClose = true;
      SoundMn.gI().buttonClose();
    }
    if (flag1)
    {
      Menu.cmtoX = this.menuSelectedItem * this.menuW + this.menuW - GameCanvas.w / 2;
      if (Menu.cmtoX > Menu.cmxLim)
        Menu.cmtoX = Menu.cmxLim;
      if (Menu.cmtoX < 0)
        Menu.cmtoX = 0;
      if (this.menuSelectedItem == this.menuItems.size() - 1 || this.menuSelectedItem == 0)
        Menu.cmx = Menu.cmtoX;
    }
    bool flag2 = true;
    if (GameCanvas.panel.cp != null && GameCanvas.panel.cp.isClip)
    {
      if (!GameCanvas.isPointerHoldIn(GameCanvas.panel.cp.cx, 0, GameCanvas.panel.cp.sayWidth + 2, GameCanvas.panel.cp.ch))
      {
        flag2 = true;
      }
      else
      {
        flag2 = false;
        GameCanvas.panel.cp.updateKey();
      }
    }
    if (!this.disableClose && GameCanvas.isPointerJustRelease && !GameCanvas.isPointer(this.menuX, this.menuY, this.w, this.menuH) && !this.pointerIsDowning && !GameScr.gI().isRongThanMenu() && flag2)
    {
      if (this.isScrolling())
        return;
      this.pointerDownTime = this.pointerDownFirstX = 0;
      this.pointerIsDowning = false;
      GameCanvas.clearAllPointerEvent();
      Res.outz("menu select= " + (object) this.menuSelectedItem);
      this.isClose = true;
      this.close = true;
      SoundMn.gI().buttonClose();
    }
    else
    {
      if (GameCanvas.isPointerDown)
      {
        if (!this.pointerIsDowning && GameCanvas.isPointer(this.menuX, this.menuY, this.w, this.menuH))
        {
          for (int index = 0; index < this.pointerDownLastX.Length; ++index)
            this.pointerDownLastX[0] = GameCanvas.px;
          this.pointerDownFirstX = GameCanvas.px;
          this.pointerIsDowning = true;
          this.isDownWhenRunning = this.cmRun != 0;
          this.cmRun = 0;
        }
        else if (this.pointerIsDowning)
        {
          ++this.pointerDownTime;
          if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.px && !this.isDownWhenRunning)
          {
            this.pointerDownFirstX = -1000;
            this.menuSelectedItem = (Menu.cmtoX + GameCanvas.px - this.menuX) / this.menuW;
          }
          int num = GameCanvas.px - this.pointerDownLastX[0];
          if (num != 0 && this.menuSelectedItem != -1)
            this.menuSelectedItem = -1;
          for (int index = this.pointerDownLastX.Length - 1; index > 0; --index)
            this.pointerDownLastX[index] = this.pointerDownLastX[index - 1];
          this.pointerDownLastX[0] = GameCanvas.px;
          Menu.cmtoX -= num;
          if (Menu.cmtoX < 0)
            Menu.cmtoX = 0;
          if (Menu.cmtoX > Menu.cmxLim)
            Menu.cmtoX = Menu.cmxLim;
          if (Menu.cmx < 0 || Menu.cmx > Menu.cmxLim)
            num /= 2;
          Menu.cmx -= num;
          this.wantUpdateList = Menu.cmx < -(GameCanvas.h / 3);
        }
      }
      if (GameCanvas.isPointerJustRelease && this.pointerIsDowning)
      {
        int i = GameCanvas.px - this.pointerDownLastX[0];
        GameCanvas.isPointerJustRelease = false;
        if (Res.abs(i) < 20 && Res.abs(GameCanvas.px - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
        {
          this.cmRun = 0;
          Menu.cmtoX = Menu.cmx;
          this.pointerDownFirstX = -1000;
          this.menuSelectedItem = (Menu.cmtoX + GameCanvas.px - this.menuX) / this.menuW;
          this.pointerDownTime = 0;
          this.waitToPerform = 10;
        }
        else if (this.menuSelectedItem != -1 && this.pointerDownTime > 5)
        {
          this.pointerDownTime = 0;
          this.waitToPerform = 1;
        }
        else if (this.menuSelectedItem == -1 && !this.isDownWhenRunning)
        {
          if (Menu.cmx < 0)
            Menu.cmtoX = 0;
          else if (Menu.cmx > Menu.cmxLim)
          {
            Menu.cmtoX = Menu.cmxLim;
          }
          else
          {
            int num = GameCanvas.px - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
            this.cmRun = -(num <= 10 ? (num >= -10 ? 0 : -10) : 10) * 100;
          }
        }
        this.pointerIsDowning = false;
        this.pointerDownTime = 0;
        GameCanvas.isPointerJustRelease = false;
      }
      GameCanvas.clearKeyPressed();
      GameCanvas.clearKeyHold();
    }
  }

  public void moveCamera()
  {
    if (this.cmRun != 0 && !this.pointerIsDowning)
    {
      Menu.cmtoX += this.cmRun / 100;
      if (Menu.cmtoX < 0)
        Menu.cmtoX = 0;
      else if (Menu.cmtoX > Menu.cmxLim)
        Menu.cmtoX = Menu.cmxLim;
      else
        Menu.cmx = Menu.cmtoX;
      this.cmRun = this.cmRun * 9 / 10;
      if (this.cmRun < 100 && this.cmRun > -100)
        this.cmRun = 0;
    }
    if (Menu.cmx == Menu.cmtoX || this.pointerIsDowning)
      return;
    this.cmvx = Menu.cmtoX - Menu.cmx << 2;
    this.cmdx += this.cmvx;
    Menu.cmx += this.cmdx >> 4;
    this.cmdx &= 15;
  }

  public void paintMenu(mGraphics g)
  {
    if (GameScr.gI().activeRongThan && GameScr.gI().isUseFreez)
      return;
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    g.translate(-Menu.cmx, 0);
    for (int index1 = 0; index1 < this.menuItems.size(); ++index1)
    {
      if (index1 == this.menuSelectedItem)
        g.drawImage(Menu.imgMenu2, this.menuX + index1 * this.menuW + 1, Menu.menuTemY[index1], 0);
      else
        g.drawImage(Menu.imgMenu1, this.menuX + index1 * this.menuW + 1, Menu.menuTemY[index1], 0);
      string[] strArray = ((Command) this.menuItems.elementAt(index1)).subCaption;
      if (strArray == null)
        strArray = new string[1]
        {
          ((Command) this.menuItems.elementAt(index1)).caption
        };
      int num = Menu.menuTemY[index1] + (this.menuH - strArray.Length * 14) / 2 + 1;
      for (int index2 = 0; index2 < strArray.Length; ++index2)
      {
        if (index1 == this.menuSelectedItem)
          mFont.tahoma_7b_green2.drawString(g, strArray[index2], this.menuX + index1 * this.menuW + this.menuW / 2, num + index2 * 14, 2);
        else
          mFont.tahoma_7b_dark.drawString(g, strArray[index2], this.menuX + index1 * this.menuW + this.menuW / 2, num + index2 * 14, 2);
      }
    }
    g.translate(-g.getTranslateX(), -g.getTranslateY());
  }

  public void doCloseMenu()
  {
    Res.outz("CLOSE MENU");
    this.isClose = false;
    this.showMenu = false;
    InfoDlg.hide();
    if (this.close)
    {
      GameCanvas.panel.cp = (ChatPopup) null;
      Char.chatPopup = (ChatPopup) null;
      if (GameCanvas.panel2 == null || GameCanvas.panel2.cp == null)
        return;
      GameCanvas.panel2.cp = (ChatPopup) null;
    }
    else
    {
      if (!this.touch)
        return;
      GameCanvas.panel.cp = (ChatPopup) null;
      if (GameCanvas.panel2 != null && GameCanvas.panel2.cp != null)
        GameCanvas.panel2.cp = (ChatPopup) null;
      if (this.menuSelectedItem < 0)
        return;
      Command command = (Command) this.menuItems.elementAt(this.menuSelectedItem);
      if (command == null)
        return;
      SoundMn.gI().buttonClose();
      command.performAction();
    }
  }

  public void performSelect()
  {
    InfoDlg.hide();
    if (this.menuSelectedItem < 0)
      return;
    ((Command) this.menuItems.elementAt(this.menuSelectedItem))?.performAction();
  }

  public void updateMenu()
  {
    this.moveCamera();
    if (!this.isClose)
    {
      ++this.tDelay;
      for (int index = 0; index < Menu.menuTemY.Length; ++index)
      {
        if (Menu.menuTemY[index] > this.menuY)
        {
          int num = Menu.menuTemY[index] - this.menuY >> 1;
          if (num < 1)
            num = 1;
          if (this.tDelay > index)
            Menu.menuTemY[index] -= num;
        }
      }
      if (Menu.menuTemY[Menu.menuTemY.Length - 1] <= this.menuY)
        this.tDelay = 0;
    }
    else
    {
      ++this.tDelay;
      for (int index = 0; index < Menu.menuTemY.Length; ++index)
      {
        if (Menu.menuTemY[index] < GameCanvas.h)
        {
          int num = (GameCanvas.h - Menu.menuTemY[index] >> 1) + 2;
          if (num < 1)
            num = 1;
          if (this.tDelay > index)
            Menu.menuTemY[index] += num;
        }
      }
      if (Menu.menuTemY[Menu.menuTemY.Length - 1] >= GameCanvas.h)
      {
        this.tDelay = 0;
        this.doCloseMenu();
      }
    }
    if (Menu.xc != 0)
    {
      Menu.xc >>= 1;
      if (Menu.xc < 0)
        Menu.xc = 0;
    }
    if (this.isScrolling() || this.waitToPerform <= 0)
      return;
    --this.waitToPerform;
    if (this.waitToPerform != 0)
      return;
    if (this.menuSelectedItem >= 0 && !this.isNotClose[this.menuSelectedItem])
    {
      this.isClose = true;
      this.touch = true;
      GameCanvas.panel.cp = (ChatPopup) null;
    }
    else
      this.performSelect();
  }

  public void perform(int idAction, object p)
  {
  }
}
