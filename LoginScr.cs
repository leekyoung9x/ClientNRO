// Decompiled with JetBrains decompiler
// Type: LoginScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class LoginScr : mScreen, IActionListener
{
  public TField tfUser;
  public TField tfPass;
  public static bool isContinueToLogin = false;
  private int focus;
  private int wC;
  private int yL;
  private int defYL;
  public bool isCheck;
  public bool isRes;
  public Command cmdLogin;
  public Command cmdCheck;
  public Command cmdFogetPass;
  public Command cmdRes;
  public Command cmdMenu;
  public Command cmdBackFromRegister;
  public string listFAQ = string.Empty;
  public string titleFAQ;
  public string subtitleFAQ;
  private string numSupport = string.Empty;
  public static bool isLocal = false;
  public static bool isUpdateAll;
  public static bool isUpdateData;
  public static bool isUpdateMap;
  public static bool isUpdateSkill;
  public static bool isUpdateItem;
  public static string serverName;
  public static Image imgTitle;
  public int plX;
  public int plY;
  public int lY;
  public int lX;
  public int logoDes;
  public int lineX;
  public int lineY;
  public static int[] bgId = new int[5]{ 0, 8, 2, 6, 9 };
  public static bool isTryGetIPFromWap;
  public static short timeLogin;
  public static long lastTimeLogin;
  public static long currTimeLogin;
  private int yt;
  private Command cmdSelect;
  private Command cmdOK;
  private int xLog;
  private int yLog;
  public static GameMidlet m;
  private int yy = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;
  private int freeAreaHeight;
  private int xP;
  private int yP;
  private int wP;
  private int hP;
  private int t = 20;
  private bool isRegistering;
  private string passRe = string.Empty;
  public bool isFAQ;
  private int tipid = -1;
  public bool isLogin2;
  private int v = 2;
  private int g;
  private int ylogo = -40;
  private int dir = 1;
  private Command cmdCallHotline;
  public static bool isLoggingIn;

  public LoginScr()
  {
    this.yLog = GameCanvas.hh - 30;
    TileMap.bgID = (int) (sbyte) (mSystem.currentTimeMillis() % 9L);
    if (TileMap.bgID == 5 || TileMap.bgID == 6)
      TileMap.bgID = 4;
    GameScr.loadCamera(true, -1, -1);
    GameScr.cmx = 100;
    GameScr.cmy = 200;
    Main.closeKeyBoard();
    this.defYL = GameCanvas.h <= 200 ? GameCanvas.hh - 65 : GameCanvas.hh - 80;
    this.resetLogo();
    this.wC = GameCanvas.w < 200 ? 140 : 160;
    this.yt = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;
    if (GameCanvas.h <= 160)
      this.yt = 20;
    this.tfUser = new TField();
    this.tfUser.y = GameCanvas.hh - mScreen.ITEM_HEIGHT - 9;
    this.tfUser.width = this.wC;
    this.tfUser.height = mScreen.ITEM_HEIGHT + 2;
    this.tfUser.isFocus = true;
    this.tfUser.setIputType(TField.INPUT_TYPE_ANY);
    this.tfUser.name = (mResources.language != (sbyte) 2 ? mResources.phone + "/" : string.Empty) + mResources.email;
    this.tfPass = new TField();
    this.tfPass.y = GameCanvas.hh - 4;
    this.tfPass.setIputType(TField.INPUT_TYPE_PASSWORD);
    this.tfPass.width = this.wC;
    this.tfPass.height = mScreen.ITEM_HEIGHT + 2;
    this.yt += 35;
    this.isCheck = true;
    switch (Rms.loadRMSInt("check"))
    {
      case 1:
        this.isCheck = true;
        break;
      case 2:
        this.isCheck = false;
        break;
    }
    this.tfUser.setText(Rms.loadRMSString("acc"));
    this.tfPass.setText(Rms.loadRMSString("pass"));
    if (this.cmdCallHotline == null)
    {
      this.cmdCallHotline = new Command("Gọi hotline", (IActionListener) this, 13, (object) null);
      this.cmdCallHotline.x = GameCanvas.w - 75;
      this.cmdCallHotline.y = mSystem.clientType != 1 || GameCanvas.isTouch ? 2 + 6 : GameCanvas.h - 20;
    }
    this.focus = 0;
    this.cmdLogin = new Command(GameCanvas.w <= 200 ? mResources.login2 : mResources.login, (IActionListener) GameCanvas.instance, 888393, (object) null);
    this.cmdCheck = new Command(mResources.remember, (IActionListener) this, 2001, (object) null);
    this.cmdRes = new Command(mResources.register, (IActionListener) this, 2002, (object) null);
    this.cmdBackFromRegister = new Command(mResources.CANCEL, (IActionListener) this, 10021, (object) null);
    this.left = this.cmdMenu = new Command(mResources.MENU, (IActionListener) this, 2003, (object) null);
    this.freeAreaHeight = this.tfUser.y - 2 * this.tfUser.height;
    if (GameCanvas.isTouch)
    {
      this.cmdLogin.x = GameCanvas.w / 2 + 8;
      this.cmdMenu.x = GameCanvas.w / 2 - mScreen.cmdW - 8;
      if (GameCanvas.h >= 200)
      {
        this.cmdLogin.y = this.yLog + 110;
        this.cmdMenu.y = this.yLog + 110;
      }
      this.cmdBackFromRegister.x = GameCanvas.w / 2 + 3;
      this.cmdBackFromRegister.y = this.yLog + 110;
      this.cmdRes.x = GameCanvas.w / 2 - 84;
      this.cmdRes.y = this.cmdMenu.y;
    }
    this.wP = 170;
    this.hP = !this.isRes ? 100 : 110;
    this.xP = GameCanvas.hw - this.wP / 2;
    this.yP = this.tfUser.y - 15;
    int num1 = 4;
    int num2 = num1 * 32 + 23 + 33;
    if (num2 >= GameCanvas.w)
      num2 = (num1 - 1) * 32 + 23 + 33;
    this.xLog = GameCanvas.w / 2 - num2 / 2;
    this.yLog = GameCanvas.hh - 30;
    this.lY = GameCanvas.w < 200 ? this.tfUser.y - 30 : this.yLog - 30;
    this.tfUser.x = this.xLog + 10;
    this.tfUser.y = this.yLog + 20;
    this.cmdOK = new Command(mResources.OK, (IActionListener) this, 2008, (object) null);
    this.cmdOK.x = GameCanvas.w / 2 - 84;
    this.cmdOK.y = this.cmdLogin.y;
    this.cmdFogetPass = new Command(mResources.forgetPass, (IActionListener) this, 1003, (object) null);
    this.cmdFogetPass.x = GameCanvas.w / 2 + 3;
    this.cmdFogetPass.y = this.cmdLogin.y;
    this.center = this.cmdOK;
    this.left = this.cmdFogetPass;
  }

  public static void getServerLink()
  {
    try
    {
      if (LoginScr.isTryGetIPFromWap)
        return;
      Net.connectHTTP(ServerListScreen.linkGetHost, new Command()
      {
        actionChat = (ActionChat) (str =>
        {
          try
          {
            if (str == null || str == string.Empty)
              return;
            Rms.saveIP(str);
            if (!str.Contains(":"))
              return;
            int length = str.IndexOf(":");
            string host = str.Substring(0, length);
            string s = str.Substring(length + 1);
            GameMidlet.IP = host;
            GameMidlet.PORT = int.Parse(s);
            Session_ME.gI().connect(host, int.Parse(s));
            LoginScr.isTryGetIPFromWap = true;
          }
          catch (Exception ex)
          {
          }
        })
      });
    }
    catch (Exception ex)
    {
    }
  }

  public override void switchToMe()
  {
    this.isRegistering = false;
    SoundMn.gI().stopAll();
    this.tfUser.isFocus = true;
    this.tfPass.isFocus = false;
    if (GameCanvas.isTouch)
      this.tfUser.isFocus = false;
    GameCanvas.loadBG(0);
    base.switchToMe();
  }

  public void setUserPass()
  {
    string text1 = Rms.loadRMSString("acc");
    if (text1 != null && !text1.Equals(string.Empty))
      this.tfUser.setText(text1);
    string text2 = Rms.loadRMSString("pass");
    if (text2 == null || text2.Equals(string.Empty))
      return;
    this.tfPass.setText(text2);
  }

  public void updateTfWhenOpenKb()
  {
  }

  protected void doMenu()
  {
    MyVector menuItems = new MyVector();
    menuItems.addElement((object) new Command(mResources.registerNewAcc, (IActionListener) this, 2004, (object) null));
    if (!this.isLogin2)
      menuItems.addElement((object) new Command(mResources.selectServer, (IActionListener) this, 1004, (object) null));
    menuItems.addElement((object) new Command(mResources.forgetPass, (IActionListener) this, 1003, (object) null));
    menuItems.addElement((object) new Command(mResources.website, (IActionListener) this, 1005, (object) null));
    if (Main.isPC)
      menuItems.addElement((object) new Command(mResources.EXIT, (IActionListener) GameCanvas.instance, 8885, (object) null));
    GameCanvas.menu.startAt(menuItems, 0);
  }

  protected void doRegister()
  {
    if (this.tfUser.getText().Equals(string.Empty))
    {
      GameCanvas.startOKDlg(mResources.userBlank);
    }
    else
    {
      this.tfUser.getText().ToCharArray();
      if (this.tfPass.getText().Equals(string.Empty))
        GameCanvas.startOKDlg(mResources.passwordBlank);
      else if (this.tfUser.getText().Length < 5)
      {
        GameCanvas.startOKDlg(mResources.accTooShort);
      }
      else
      {
        string info = (string) null;
        int num;
        if (mResources.language == (sbyte) 2)
        {
          if (this.tfUser.getText().IndexOf("@") == -1 || this.tfUser.getText().IndexOf(".") == -1)
            info = mResources.emailInvalid;
          num = 0;
        }
        else
        {
          try
          {
            long.Parse(this.tfUser.getText());
            if (this.tfUser.getText().Length < 8 || this.tfUser.getText().Length > 12 || !this.tfUser.getText().StartsWith("0") && !this.tfUser.getText().StartsWith("84"))
              info = mResources.phoneInvalid;
            num = 1;
          }
          catch (Exception ex)
          {
            if (this.tfUser.getText().IndexOf("@") == -1 || this.tfUser.getText().IndexOf(".") == -1)
              info = mResources.emailInvalid;
            num = 0;
          }
        }
        if (info != null)
          GameCanvas.startOKDlg(info);
        else
          GameCanvas.msgdlg.setInfo(mResources.plsCheckAcc + (num != 1 ? mResources.email + ": " : mResources.phone + ": ") + this.tfUser.getText() + "\n" + mResources.password + ": " + this.tfPass.getText(), new Command(mResources.ACCEPT, (IActionListener) this, 4000, (object) null), (Command) null, new Command(mResources.NO, (IActionListener) GameCanvas.instance, 8882, (object) null));
        GameCanvas.currentDialog = (Dialog) GameCanvas.msgdlg;
      }
    }
  }

  protected void doRegister(string user)
  {
    this.isFAQ = false;
    GameCanvas.startWaitDlg(mResources.CONNECTING);
    GameCanvas.connect();
    GameCanvas.startWaitDlg(mResources.REGISTERING);
    this.passRe = this.tfPass.getText();
    Service.gI().requestRegister(user, this.tfPass.getText(), Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect), Rms.loadRMSString("passAo" + (object) ServerListScreen.ipSelect), GameMidlet.VERSION);
    Rms.saveRMSString("acc", user);
    Rms.saveRMSString("pass", this.tfPass.getText());
    this.t = 20;
    this.isRegistering = true;
  }

  public void doViewFAQ()
  {
    if (!this.listFAQ.Equals(string.Empty) || this.listFAQ.Equals(string.Empty))
      ;
    if (!Session_ME.connected)
    {
      this.isFAQ = true;
      GameCanvas.connect();
    }
    GameCanvas.startWaitDlg();
  }

  protected void doSelectServer()
  {
    MyVector menuItems = new MyVector();
    if (LoginScr.isLocal)
      menuItems.addElement((object) new Command("Server LOCAL", (IActionListener) this, 20004, (object) null));
    menuItems.addElement((object) new Command("Server Bokken", (IActionListener) this, 20001, (object) null));
    menuItems.addElement((object) new Command("Server Shuriken", (IActionListener) this, 20002, (object) null));
    menuItems.addElement((object) new Command("Server Tessen (mới)", (IActionListener) this, 20003, (object) null));
    GameCanvas.menu.startAt(menuItems, 0);
    if (this.loadIndexServer() == -1 || GameCanvas.isTouch)
      return;
    GameCanvas.menu.menuSelectedItem = this.loadIndexServer();
  }

  protected void saveIndexServer(int index) => Rms.saveRMSInt("indServer", index);

  protected int loadIndexServer() => Rms.loadRMSInt("indServer");

  public void doLogin()
  {
    string username = Rms.loadRMSString("acc");
    string pass = Rms.loadRMSString("pass");
    this.isLogin2 = (username == null || username.Equals(string.Empty)) && Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect) != null && !Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect).Equals(string.Empty);
    if ((username == null || username.Equals(string.Empty)) && this.isLogin2)
    {
      username = Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect);
      pass = "a";
    }
    if (username == null || pass == null || GameMidlet.VERSION == null || username.Equals(string.Empty))
      return;
    if (pass.Equals(string.Empty))
    {
      this.focus = 1;
      this.tfUser.isFocus = false;
      this.tfPass.isFocus = true;
      if (GameCanvas.isTouch)
        return;
      this.right = this.tfPass.cmdClear;
    }
    else
    {
      GameCanvas.connect();
      Res.outz("ccccccc " + username + " " + pass + " " + GameMidlet.VERSION + " " + (object) (sbyte) (!this.isLogin2 ? 0 : 1));
      Service.gI().login(username, pass, GameMidlet.VERSION, !this.isLogin2 ? (sbyte) 0 : (sbyte) 1);
      if (Session_ME.connected)
        GameCanvas.startWaitDlg();
      else
        GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
      this.focus = 0;
      if (this.isLogin2)
        return;
      this.actRegisterLeft();
    }
  }

  public void savePass()
  {
    if (this.isCheck)
    {
      Rms.saveRMSInt("check", 1);
      Rms.saveRMSString("acc", this.tfUser.getText().ToLower().Trim());
      Rms.saveRMSString("pass", this.tfPass.getText().ToLower().Trim());
    }
    else
    {
      Rms.saveRMSInt("check", 2);
      Rms.saveRMSString("acc", string.Empty);
      Rms.saveRMSString("pass", string.Empty);
    }
  }

  public override void update()
  {
    if (Main.isWindowsPhone && this.isRegistering)
    {
      if (this.t < 0)
      {
        GameCanvas.endDlg();
        Session_ME.gI().close();
        GameCanvas.serverScreen.switchToMe();
        this.isRegistering = false;
      }
      else
        --this.t;
    }
    if (LoginScr.timeLogin > (short) 0)
    {
      GameCanvas.startWaitDlg();
      LoginScr.currTimeLogin = mSystem.currentTimeMillis();
      if (LoginScr.currTimeLogin - LoginScr.lastTimeLogin >= 1000L)
      {
        --LoginScr.timeLogin;
        if (LoginScr.timeLogin == (short) 0)
        {
          Session_ME.gI().close();
          GameCanvas.loginScr.doLogin();
        }
        LoginScr.lastTimeLogin = LoginScr.currTimeLogin;
      }
    }
    if (this.isLogin2 && !this.isRes)
    {
      this.tfUser.name = (mResources.language != (sbyte) 2 ? mResources.phone + "/" : string.Empty) + mResources.email;
      this.tfPass.name = mResources.password;
      this.tfUser.isPaintCarret = false;
      this.tfPass.isPaintCarret = false;
      this.tfUser.update();
      this.tfPass.update();
    }
    else
    {
      this.tfUser.name = (mResources.language != (sbyte) 2 ? mResources.phone + "/" : string.Empty) + mResources.email;
      this.tfPass.name = mResources.password;
      this.tfUser.update();
      this.tfPass.update();
    }
    if (TouchScreenKeyboard.visible)
      mGraphics.addYWhenOpenKeyBoard = 50;
    for (int index = 0; index < Effect2.vEffect2.size(); ++index)
      ((Effect2) Effect2.vEffect2.elementAt(index)).update();
    if (LoginScr.isUpdateAll && !LoginScr.isUpdateData && !LoginScr.isUpdateItem && !LoginScr.isUpdateMap && !LoginScr.isUpdateSkill)
    {
      LoginScr.isUpdateAll = false;
      mSystem.gcc();
      Service.gI().finishUpdate();
    }
    ++GameScr.cmx;
    if (GameScr.cmx > GameCanvas.w * 3 + 100)
      GameScr.cmx = 100;
    if (ChatPopup.currChatPopup != null)
      return;
    GameCanvas.debug("LGU1", 0);
    GameCanvas.debug("LGU2", 0);
    GameCanvas.debug("LGU3", 0);
    this.updateLogo();
    GameCanvas.debug("LGU4", 0);
    GameCanvas.debug("LGU5", 0);
    if (this.g >= 0)
    {
      this.ylogo += this.dir * this.g;
      this.g += this.dir * this.v;
      if (this.g <= 0)
        this.dir *= -1;
      if (this.ylogo > 0)
      {
        this.dir *= -1;
        this.g -= 2 * this.v;
      }
    }
    GameCanvas.debug("LGU6", 0);
    if (this.tipid >= 0 && GameCanvas.gameTick % 100 == 0)
      this.doChangeTip();
    if (this.isLogin2 && !this.isRes)
    {
      this.tfUser.isPaintCarret = false;
      this.tfPass.isPaintCarret = false;
      this.tfUser.update();
      this.tfPass.update();
    }
    else
    {
      this.tfUser.name = (mResources.language != (sbyte) 2 ? mResources.phone + "/" : string.Empty) + mResources.email;
      this.tfPass.name = mResources.password;
      this.tfUser.update();
      this.tfPass.update();
    }
    if (GameCanvas.isTouch)
    {
      if (this.isRes)
      {
        this.center = this.cmdRes;
        this.left = this.cmdBackFromRegister;
      }
      else
      {
        this.center = this.cmdOK;
        this.left = this.cmdFogetPass;
      }
    }
    else if (this.isRes)
    {
      this.center = this.cmdRes;
      this.left = this.cmdBackFromRegister;
    }
    else
    {
      this.center = this.cmdOK;
      this.left = this.cmdFogetPass;
    }
    if (!Main.isPC && !TouchScreenKeyboard.visible && !Main.isMiniApp && !Main.isWindowsPhone)
    {
      string str1 = this.tfUser.getText().ToLower().Trim();
      string str2 = this.tfPass.getText().ToLower().Trim();
      if (!str1.Equals(string.Empty) && !str2.Equals(string.Empty))
        this.doLogin();
      Main.isMiniApp = true;
    }
    this.updateTfWhenOpenKb();
  }

  private void doChangeTip()
  {
    ++this.tipid;
    if (this.tipid >= mResources.tips.Length)
      this.tipid = 0;
    if (GameCanvas.currentDialog != GameCanvas.msgdlg || !GameCanvas.msgdlg.isWait)
      return;
    GameCanvas.msgdlg.setInfo(mResources.tips[this.tipid]);
  }

  public void updateLogo()
  {
    if (this.defYL == this.yL)
      return;
    this.yL += this.defYL - this.yL >> 1;
  }

  public override void keyPress(int keyCode)
  {
    if (this.tfUser.isFocus)
      this.tfUser.keyPressed(keyCode);
    else if (this.tfPass.isFocus)
      this.tfPass.keyPressed(keyCode);
    base.keyPress(keyCode);
  }

  public override void unLoad() => base.unLoad();

  public override void paint(mGraphics g)
  {
    GameCanvas.debug("PLG1", 1);
    GameCanvas.paintBGGameScr(g);
    GameCanvas.debug("PLG2", 2);
    int y = this.tfUser.y - 50;
    if (GameCanvas.h <= 220)
      y += 5;
    mFont.tahoma_7_white.drawString(g, "v" + GameMidlet.VERSION, GameCanvas.w - 2, 17, 1, mFont.tahoma_7_grey);
    if (mSystem.clientType == 1 && !GameCanvas.isTouch)
      mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
    else
      mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, 2, 1, mFont.tahoma_7_grey);
    if (ChatPopup.currChatPopup != null || ChatPopup.serverChatPopUp != null)
      return;
    if (GameCanvas.currentDialog == null)
    {
      int h = 105;
      int w = GameCanvas.w < 200 ? 160 : 180;
      PopUp.paintPopUp(g, this.xLog, this.yLog - 10, w, h, -1, true);
      if (GameCanvas.h > 160 && LoginScr.imgTitle != null)
        g.drawImage(LoginScr.imgTitle, GameCanvas.hw, y, 3);
      GameCanvas.debug("PLG4", 1);
      int num1 = 4;
      int num2 = num1 * 32 + 23 + 33;
      if (num2 >= GameCanvas.w)
        num2 = (num1 - 1) * 32 + 23 + 33;
      this.xLog = GameCanvas.w / 2 - num2 / 2;
      this.tfUser.x = this.xLog + 10;
      this.tfUser.y = this.yLog + 20;
      this.tfPass.x = this.xLog + 10;
      this.tfPass.y = this.yLog + 55;
      this.tfUser.paint(g);
      this.tfPass.paint(g);
      int num3 = 0;
      if (GameCanvas.w >= 176)
      {
        num3 = 50;
      }
      else
      {
        mFont.tahoma_7b_green2.drawString(g, mResources.acc + ":", this.tfUser.x - 35, this.tfUser.y + 7, 0);
        mFont.tahoma_7b_green2.drawString(g, mResources.pwd + ":", this.tfPass.x - 35, this.tfPass.y + 7, 0);
        mFont.tahoma_7b_green2.drawString(g, mResources.server + ":" + LoginScr.serverName, GameCanvas.w / 2, this.tfPass.y + 32, 2);
        num3 = 0;
      }
    }
    base.paint(g);
  }

  public override void updateKey()
  {
    if (GameCanvas.isTouch)
    {
      if (this.cmdCallHotline != null && this.cmdCallHotline.isPointerPressInside())
        this.cmdCallHotline.performAction();
    }
    else if (mSystem.clientType == 1 && GameCanvas.keyPressed[13])
    {
      GameCanvas.keyPressed[13] = false;
      this.cmdCallHotline.performAction();
    }
    if (LoginScr.isContinueToLogin)
      return;
    if (!GameCanvas.isTouch)
    {
      if (this.tfUser.isFocus)
        this.right = this.tfUser.cmdClear;
      else
        this.right = this.tfPass.cmdClear;
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21])
    {
      --this.focus;
      if (this.focus < 0)
        this.focus = 1;
    }
    else if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22] || GameCanvas.keyPressed[16])
    {
      ++this.focus;
      if (this.focus > 1)
        this.focus = 0;
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21] || GameCanvas.keyPressed[!Main.isPC ? 8 : 22] || GameCanvas.keyPressed[16])
    {
      GameCanvas.clearKeyPressed();
      if (!this.isLogin2 || this.isRes)
      {
        if (this.focus == 1)
        {
          this.tfUser.isFocus = false;
          this.tfPass.isFocus = true;
        }
        else if (this.focus == 0)
        {
          this.tfUser.isFocus = true;
          this.tfPass.isFocus = false;
        }
        else
        {
          this.tfUser.isFocus = false;
          this.tfPass.isFocus = false;
        }
      }
    }
    if (GameCanvas.isTouch)
    {
      if (this.isRes)
      {
        this.center = this.cmdRes;
        this.left = this.cmdBackFromRegister;
      }
      else
      {
        this.center = this.cmdOK;
        this.left = this.cmdFogetPass;
      }
    }
    else if (this.isRes)
    {
      this.center = this.cmdRes;
      this.left = this.cmdBackFromRegister;
    }
    else
    {
      this.center = this.cmdOK;
      this.left = this.cmdFogetPass;
    }
    if (GameCanvas.isPointerJustRelease && (!this.isLogin2 || this.isRes))
    {
      if (GameCanvas.isPointerHoldIn(this.tfUser.x, this.tfUser.y, this.tfUser.width, this.tfUser.height))
        this.focus = 0;
      else if (GameCanvas.isPointerHoldIn(this.tfPass.x, this.tfPass.y, this.tfPass.width, this.tfPass.height))
        this.focus = 1;
    }
    if (Main.isPC && GameCanvas.keyPressed[!Main.isPC ? 5 : 25] && this.right != null)
      this.right.performAction();
    base.updateKey();
    GameCanvas.clearKeyPressed();
  }

  public void resetLogo() => this.yL = -50;

  public void perform(int idAction, object p)
  {
    switch (idAction)
    {
      case 1000:
        try
        {
          GameMidlet.instance.platformRequest((string) p);
        }
        catch (Exception ex)
        {
        }
        GameCanvas.endDlg();
        break;
      case 1001:
        GameCanvas.endDlg();
        this.isRes = false;
        break;
      case 1002:
        GameCanvas.startWaitDlg();
        string username = Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect);
        if (username == null || username.Equals(string.Empty))
        {
          Service.gI().login2(string.Empty);
          break;
        }
        GameCanvas.loginScr.isLogin2 = true;
        GameCanvas.connect();
        Service.gI().setClientType();
        Service.gI().login(username, string.Empty, GameMidlet.VERSION, (sbyte) 1);
        break;
      case 1003:
        GameCanvas.startOKDlg(mResources.goToWebForPassword);
        break;
      case 1004:
        ServerListScreen.doUpdateServer();
        GameCanvas.serverScreen.switchToMe();
        break;
      case 1005:
        try
        {
          GameMidlet.instance.platformRequest("http://ngocrongonline.com");
          break;
        }
        catch (Exception ex)
        {
          break;
        }
      case 2000:
        break;
      case 2001:
        if (this.isCheck)
        {
          this.isCheck = false;
          break;
        }
        this.isCheck = true;
        break;
      case 2002:
        this.doRegister();
        break;
      case 2003:
        this.doMenu();
        break;
      case 2004:
        this.actRegister();
        break;
      case 2008:
        Rms.saveRMSString("acc", this.tfUser.getText().Trim());
        Rms.saveRMSString("pass", this.tfPass.getText().Trim());
        if (ServerListScreen.loadScreen)
        {
          GameCanvas.serverScreen.switchToMe();
          break;
        }
        GameCanvas.serverScreen.show2();
        break;
      default:
        if (idAction != 10041)
        {
          if (idAction != 10042)
          {
            if (idAction != 13)
            {
              if (idAction != 4000)
              {
                if (idAction != 10021)
                  break;
                this.actRegisterLeft();
                break;
              }
              this.doRegister(this.tfUser.getText());
              break;
            }
            switch (mSystem.clientType)
            {
              case 1:
                mSystem.callHotlineJava();
                return;
              case 2:
                return;
              case 3:
              case 5:
                mSystem.callHotlineIphone();
                return;
              case 4:
                mSystem.callHotlinePC();
                return;
              case 6:
                mSystem.callHotlineWindowsPhone();
                return;
              default:
                return;
            }
          }
          else
          {
            Rms.saveRMSInt("lowGraphic", 1);
            GameCanvas.startOK(mResources.plsRestartGame, 8885, (object) null);
            break;
          }
        }
        else
        {
          Rms.saveRMSInt("lowGraphic", 0);
          GameCanvas.startOK(mResources.plsRestartGame, 8885, (object) null);
          break;
        }
    }
  }

  public void actRegisterLeft()
  {
    if (this.isLogin2)
    {
      this.doLogin();
    }
    else
    {
      this.isRes = false;
      this.tfPass.isFocus = false;
      this.tfUser.isFocus = true;
      this.left = this.cmdMenu;
    }
  }

  public void actRegister()
  {
    GameCanvas.endDlg();
    this.isRes = true;
    this.tfPass.isFocus = false;
    this.tfUser.isFocus = true;
  }

  public void backToRegister()
  {
    if (GameCanvas.loginScr.isLogin2)
    {
      GameCanvas.startYesNoDlg(mResources.note, new Command(mResources.YES, (IActionListener) GameCanvas.panel, 10019, (object) null), new Command(mResources.NO, (IActionListener) GameCanvas.panel, 10020, (object) null));
    }
    else
    {
      if (Main.isWindowsPhone)
        GameMidlet.isBackWindowsPhone = true;
      GameCanvas.instance.resetToLoginScr = false;
      GameCanvas.instance.doResetToLoginScr((mScreen) GameCanvas.loginScr);
      Session_ME.gI().close();
    }
  }
}
