// Decompiled with JetBrains decompiler
// Type: Assets.src.g.RegisterScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

namespace Assets.src.g
{
  public class RegisterScreen : mScreen, IActionListener
  {
    public TField tfUser;
    public TField tfNgay;
    public TField tfThang;
    public TField tfNam;
    public TField tfDiachi;
    public TField tfCMND;
    public TField tfNgayCap;
    public TField tfNoiCap;
    public TField tfSodt;
    public static bool isContinueToLogin = false;
    private int focus;
    private int wC;
    private int yL;
    private int defYL;
    public bool isCheck;
    public bool isRes;
    private Command cmdLogin;
    private Command cmdCheck;
    private Command cmdFogetPass;
    private Command cmdRes;
    private Command cmdMenu;
    private Command cmdBackFromRegister;
    public string listFAQ = string.Empty;
    public string titleFAQ;
    public string subtitleFAQ;
    private string numSupport = string.Empty;
    private string strUser;
    private string strPass;
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
    private int xP;
    private int yP;
    private int wP;
    private int hP;
    private string passRe = string.Empty;
    public bool isFAQ;
    private int tipid = -1;
    public bool isLogin2;
    private int v = 2;
    private int g;
    private int ylogo = -40;
    private int dir = 1;
    public static bool isLoggingIn;

    public RegisterScreen(sbyte haveName)
    {
      this.yLog = 130;
      TileMap.bgID = (int) (sbyte) (mSystem.currentTimeMillis() % 9L);
      if (TileMap.bgID == 5 || TileMap.bgID == 6)
        TileMap.bgID = 4;
      GameScr.loadCamera(true, -1, -1);
      GameScr.cmx = 100;
      GameScr.cmy = 200;
      this.defYL = GameCanvas.h <= 200 ? GameCanvas.hh - 65 : GameCanvas.hh - 80;
      this.resetLogo();
      this.wC = GameCanvas.w < 200 ? 140 : 160;
      this.yt = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;
      if (GameCanvas.h <= 160)
        this.yt = 20;
      this.tfSodt = new TField();
      this.tfSodt.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.tfSodt.width = 220;
      this.tfSodt.height = mScreen.ITEM_HEIGHT + 2;
      this.tfSodt.name = "Số điện thoại/ địa chỉ email";
      if (haveName == (sbyte) 1)
        this.tfSodt.setText("01234567890");
      this.tfUser = new TField();
      this.tfUser.width = 220;
      this.tfUser.height = mScreen.ITEM_HEIGHT + 2;
      this.tfUser.isFocus = true;
      this.tfUser.name = "Họ và tên";
      if (haveName == (sbyte) 1)
        this.tfUser.setText("Nguyễn Văn A");
      this.tfUser.setIputType(TField.INPUT_TYPE_ANY);
      this.tfNgay = new TField();
      this.tfNgay.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.tfNgay.width = 70;
      this.tfNgay.height = mScreen.ITEM_HEIGHT + 2;
      this.tfNgay.name = "Ngày sinh";
      if (haveName == (sbyte) 1)
        this.tfNgay.setText("01");
      this.tfThang = new TField();
      this.tfThang.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.tfThang.width = 70;
      this.tfThang.height = mScreen.ITEM_HEIGHT + 2;
      this.tfThang.name = "Tháng sinh";
      if (haveName == (sbyte) 1)
        this.tfThang.setText("01");
      this.tfNam = new TField();
      this.tfNam.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.tfNam.width = 70;
      this.tfNam.height = mScreen.ITEM_HEIGHT + 2;
      this.tfNam.name = "Năm sinh";
      if (haveName == (sbyte) 1)
        this.tfNam.setText("1990");
      this.tfDiachi = new TField();
      this.tfDiachi.setIputType(TField.INPUT_TYPE_ANY);
      this.tfDiachi.width = 220;
      this.tfDiachi.height = mScreen.ITEM_HEIGHT + 2;
      this.tfDiachi.name = "Địa chỉ đăng ký thường trú";
      if (haveName == (sbyte) 1)
        this.tfDiachi.setText("123 đường số 1, Quận 1, TP.HCM");
      this.tfCMND = new TField();
      this.tfCMND.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.tfCMND.width = 220;
      this.tfCMND.height = mScreen.ITEM_HEIGHT + 2;
      this.tfCMND.name = "Số Chứng minh nhân dân hoặc số hộ chiếu";
      if (haveName == (sbyte) 1)
        this.tfCMND.setText("123456789");
      this.tfNgayCap = new TField();
      this.tfNgayCap.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.tfNgayCap.width = 220;
      this.tfNgayCap.height = mScreen.ITEM_HEIGHT + 2;
      this.tfNgayCap.name = "Ngày cấp";
      if (haveName == (sbyte) 1)
        this.tfNgayCap.setText("01/01/2005");
      this.tfNoiCap = new TField();
      this.tfNoiCap.setIputType(TField.INPUT_TYPE_ANY);
      this.tfNoiCap.width = 220;
      this.tfNoiCap.height = mScreen.ITEM_HEIGHT + 2;
      this.tfNoiCap.name = "Nơi cấp";
      if (haveName == (sbyte) 1)
        this.tfNoiCap.setText("TP.HCM");
      this.yt += 35;
      this.isCheck = true;
      this.focus = 0;
      this.cmdLogin = new Command(GameCanvas.w <= 200 ? mResources.login2 : mResources.login, (IActionListener) GameCanvas.instance, 888393, (object) null);
      this.cmdCheck = new Command(mResources.remember, (IActionListener) this, 2001, (object) null);
      this.cmdRes = new Command(mResources.register, (IActionListener) this, 2002, (object) null);
      this.cmdBackFromRegister = new Command(mResources.CANCEL, (IActionListener) this, 10021, (object) null);
      this.left = this.cmdMenu = new Command(mResources.MENU, (IActionListener) this, 2003, (object) null);
      if (GameCanvas.isTouch)
      {
        this.cmdLogin.x = GameCanvas.w / 2 - 100;
        this.cmdMenu.x = GameCanvas.w / 2 - mScreen.cmdW - 8;
        if (GameCanvas.h >= 200)
        {
          this.cmdLogin.y = GameCanvas.h / 2 - 40;
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
      this.yLog = 5;
      this.lY = GameCanvas.w < 200 ? this.tfUser.y - 30 : this.yLog - 30;
      this.tfUser.x = this.xLog + 10;
      this.tfUser.y = this.yLog + 20;
      this.cmdOK = new Command(mResources.OK, (IActionListener) this, 2008, (object) null);
      this.cmdOK.x = 260;
      this.cmdOK.y = GameCanvas.h - 60;
      this.cmdFogetPass = new Command("Thoát", (IActionListener) this, 1003, (object) null);
      this.cmdFogetPass.x = 260;
      this.cmdFogetPass.y = GameCanvas.h - 30;
      if (GameCanvas.w < 250)
      {
        this.cmdOK.x = GameCanvas.w / 2 - 80;
        this.cmdFogetPass.x = GameCanvas.w / 2 + 10;
        this.cmdFogetPass.y = this.cmdOK.y = GameCanvas.h - 25;
      }
      this.center = this.cmdOK;
      this.left = this.cmdFogetPass;
    }

    public new void switchToMe()
    {
      Res.outz("Res switch");
      SoundMn.gI().stopAll();
      this.focus = 0;
      this.tfUser.isFocus = true;
      this.tfNgay.isFocus = false;
      if (GameCanvas.isTouch)
      {
        this.tfUser.isFocus = false;
        this.focus = -1;
      }
      base.switchToMe();
    }

    protected void doMenu()
    {
      MyVector menuItems = new MyVector("vMenu Login");
      menuItems.addElement((object) new Command(mResources.registerNewAcc, (IActionListener) this, 2004, (object) null));
      if (!this.isLogin2)
        menuItems.addElement((object) new Command(mResources.selectServer, (IActionListener) this, 1004, (object) null));
      menuItems.addElement((object) new Command(mResources.forgetPass, (IActionListener) this, 1003, (object) null));
      menuItems.addElement((object) new Command(mResources.website, (IActionListener) this, 1005, (object) null));
      if (Rms.loadRMSInt("lowGraphic") == 1)
        menuItems.addElement((object) new Command(mResources.increase_vga, (IActionListener) this, 10041, (object) null));
      else
        menuItems.addElement((object) new Command(mResources.decrease_vga, (IActionListener) this, 10042, (object) null));
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
        if (this.tfNgay.getText().Equals(string.Empty))
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
            GameCanvas.msgdlg.setInfo(mResources.plsCheckAcc + (num != 1 ? mResources.email + ": " : mResources.phone + ": ") + this.tfUser.getText() + "\n" + mResources.password + ": " + this.tfNgay.getText(), new Command(mResources.ACCEPT, (IActionListener) this, 4000, (object) null), (Command) null, new Command(mResources.NO, (IActionListener) GameCanvas.instance, 8882, (object) null));
          GameCanvas.currentDialog = (Dialog) GameCanvas.msgdlg;
        }
      }
    }

    protected void doRegister(string user)
    {
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
      MyVector menuItems = new MyVector("vServer");
      if (RegisterScreen.isLocal)
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
    }

    public void savePass()
    {
    }

    public override void update()
    {
      this.tfUser.update();
      this.tfNgay.update();
      this.tfThang.update();
      this.tfNam.update();
      this.tfDiachi.update();
      this.tfCMND.update();
      this.tfNoiCap.update();
      this.tfSodt.update();
      this.tfNgayCap.update();
      for (int index = 0; index < Effect2.vEffect2.size(); ++index)
        ((Effect2) Effect2.vEffect2.elementAt(index)).update();
      if (RegisterScreen.isUpdateAll && !RegisterScreen.isUpdateData && !RegisterScreen.isUpdateItem && !RegisterScreen.isUpdateMap && !RegisterScreen.isUpdateSkill)
      {
        RegisterScreen.isUpdateAll = false;
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
      else if (this.tfNgay.isFocus)
        this.tfNgay.keyPressed(keyCode);
      else if (this.tfThang.isFocus)
        this.tfThang.keyPressed(keyCode);
      else if (this.tfNam.isFocus)
        this.tfNam.keyPressed(keyCode);
      else if (this.tfDiachi.isFocus)
        this.tfDiachi.keyPressed(keyCode);
      else if (this.tfCMND.isFocus)
        this.tfCMND.keyPressed(keyCode);
      else if (this.tfNoiCap.isFocus)
        this.tfNoiCap.keyPressed(keyCode);
      else if (this.tfSodt.isFocus)
        this.tfSodt.keyPressed(keyCode);
      else if (this.tfNgayCap.isFocus)
        this.tfNgayCap.keyPressed(keyCode);
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
      if (ChatPopup.currChatPopup != null || ChatPopup.serverChatPopUp != null)
        return;
      if (GameCanvas.currentDialog == null)
      {
        this.xLog = 5;
        int h = 233;
        if (GameCanvas.w < 260)
          this.xLog = (GameCanvas.w - 240) / 2;
        this.yLog = (GameCanvas.h - h) / 2;
        int num1 = GameCanvas.w < 200 ? 160 : 180;
        PopUp.paintPopUp(g, this.xLog, this.yLog, 240, h, -1, true);
        if (GameCanvas.h > 160 && RegisterScreen.imgTitle != null)
          g.drawImage(RegisterScreen.imgTitle, GameCanvas.hw, y, 3);
        GameCanvas.debug("PLG4", 1);
        int num2 = 4;
        if (num2 * 32 + 23 + 33 >= GameCanvas.w)
        {
          int num3 = (num2 - 1) * 32 + 23 + 33;
        }
        this.tfSodt.x = this.xLog + 10;
        this.tfSodt.y = this.yLog + 15;
        this.tfUser.x = this.tfSodt.x;
        this.tfUser.y = this.tfSodt.y + 30;
        this.tfNgay.x = this.xLog + 10;
        this.tfNgay.y = this.tfUser.y + 30;
        this.tfThang.x = this.tfNgay.x + 75;
        this.tfThang.y = this.tfNgay.y;
        this.tfNam.x = this.tfThang.x + 75;
        this.tfNam.y = this.tfThang.y;
        this.tfDiachi.x = this.tfUser.x;
        this.tfDiachi.y = this.tfNgay.y + 30;
        this.tfCMND.x = this.tfUser.x;
        this.tfCMND.y = this.tfDiachi.y + 30;
        this.tfNgayCap.x = this.tfUser.x;
        this.tfNgayCap.y = this.tfCMND.y + 30;
        this.tfNoiCap.x = this.tfUser.x;
        this.tfNoiCap.y = this.tfNgayCap.y + 30;
        this.tfUser.paint(g);
        this.tfNgay.paint(g);
        this.tfThang.paint(g);
        this.tfNam.paint(g);
        this.tfDiachi.paint(g);
        this.tfCMND.paint(g);
        this.tfNgayCap.paint(g);
        this.tfNoiCap.paint(g);
        this.tfSodt.paint(g);
        int num4 = 0;
        if (GameCanvas.w >= 176)
        {
          num4 = 50;
        }
        else
        {
          mFont.tahoma_7b_green2.drawString(g, mResources.acc + ":", this.tfUser.x - 35, this.tfUser.y + 7, 0);
          mFont.tahoma_7b_green2.drawString(g, mResources.pwd + ":", this.tfNgay.x - 35, this.tfNgay.y + 7, 0);
          mFont.tahoma_7b_green2.drawString(g, mResources.server + ": " + RegisterScreen.serverName, GameCanvas.w / 2, this.tfNgay.y + 32, 2);
          if (!this.isRes)
            ;
          num4 = 0;
        }
      }
      string version = GameMidlet.VERSION;
      g.setColor(GameCanvas.skyColor);
      g.fillRect(GameCanvas.w - 40, 4, 36, 11);
      mFont.tahoma_7_grey.drawString(g, version, GameCanvas.w - 22, 4, mFont.CENTER);
      GameCanvas.resetTrans(g);
      if (GameCanvas.currentDialog == null)
      {
        if (GameCanvas.w > 250)
        {
          mFont.tahoma_7b_white.drawString(g, "Dưới 18 tuổi", 260, 10, 0, mFont.tahoma_7b_dark);
          mFont.tahoma_7b_white.drawString(g, "chỉ có thể chơi", 260, 25, 0, mFont.tahoma_7b_dark);
          mFont.tahoma_7b_white.drawString(g, "180p 1 ngày", 260, 40, 0, mFont.tahoma_7b_dark);
        }
        else
        {
          mFont.tahoma_7b_white.drawString(g, "Dưới 18 tuổi chỉ có thể chơi", GameCanvas.w / 2, 5, 2, mFont.tahoma_7b_dark);
          mFont.tahoma_7b_white.drawString(g, "180p 1 ngày", GameCanvas.w / 2, 15, 2, mFont.tahoma_7b_dark);
        }
      }
      base.paint(g);
    }

    private void turnOffFocus()
    {
      this.tfUser.isFocus = false;
      this.tfNgay.isFocus = false;
      this.tfThang.isFocus = false;
      this.tfNam.isFocus = false;
      this.tfDiachi.isFocus = false;
      this.tfCMND.isFocus = false;
      this.tfNgayCap.isFocus = false;
      this.tfNoiCap.isFocus = false;
      this.tfSodt.isFocus = false;
    }

    private void processFocus()
    {
      this.turnOffFocus();
      switch (this.focus)
      {
        case 0:
          this.tfUser.isFocus = true;
          break;
        case 1:
          this.tfNgay.isFocus = true;
          break;
        case 2:
          this.tfThang.isFocus = true;
          break;
        case 3:
          this.tfNam.isFocus = true;
          break;
        case 4:
          this.tfDiachi.isFocus = true;
          break;
        case 5:
          this.tfCMND.isFocus = true;
          break;
        case 6:
          this.tfNgayCap.isFocus = true;
          break;
        case 7:
          this.tfNoiCap.isFocus = true;
          break;
        case 8:
          this.tfSodt.isFocus = true;
          break;
      }
    }

    public override void updateKey()
    {
      if (RegisterScreen.isContinueToLogin)
        return;
      if (!GameCanvas.isTouch)
      {
        if (this.tfUser.isFocus)
          this.right = this.tfUser.cmdClear;
        else if (this.tfNgay.isFocus)
          this.right = this.tfNgay.cmdClear;
        else if (this.tfThang.isFocus)
          this.right = this.tfThang.cmdClear;
        else if (this.tfNam.isFocus)
          this.right = this.tfNam.cmdClear;
        else if (this.tfDiachi.isFocus)
          this.right = this.tfDiachi.cmdClear;
        else if (this.tfCMND.isFocus)
          this.right = this.tfCMND.cmdClear;
        else if (this.tfNgayCap.isFocus)
          this.right = this.tfNgayCap.cmdClear;
        else if (this.tfNoiCap.isFocus)
          this.right = this.tfNoiCap.cmdClear;
        else if (this.tfSodt.isFocus)
          this.right = this.tfSodt.cmdClear;
      }
      if (GameCanvas.keyPressed[21])
      {
        --this.focus;
        if (this.focus < 0)
          this.focus = 8;
        this.processFocus();
      }
      else if (GameCanvas.keyPressed[22])
      {
        ++this.focus;
        if (this.focus > 8)
          this.focus = 0;
        this.processFocus();
      }
      if (GameCanvas.keyPressed[21] || GameCanvas.keyPressed[22])
      {
        GameCanvas.clearKeyPressed();
        if (!this.isLogin2 || this.isRes)
        {
          if (this.focus == 1)
          {
            this.tfUser.isFocus = false;
            this.tfNgay.isFocus = true;
          }
          else if (this.focus == 0)
          {
            this.tfUser.isFocus = true;
            this.tfNgay.isFocus = false;
          }
          else
          {
            this.tfUser.isFocus = false;
            this.tfNgay.isFocus = false;
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
      if (GameCanvas.isPointerJustRelease)
      {
        if (GameCanvas.isPointerHoldIn(this.tfUser.x, this.tfUser.y, this.tfUser.width, this.tfUser.height))
        {
          this.focus = 0;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfNgay.x, this.tfNgay.y, this.tfNgay.width, this.tfNgay.height))
        {
          this.focus = 1;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfThang.x, this.tfThang.y, this.tfThang.width, this.tfThang.height))
        {
          this.focus = 2;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfNam.x, this.tfNam.y, this.tfNam.width, this.tfNam.height))
        {
          this.focus = 3;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfDiachi.x, this.tfDiachi.y, this.tfDiachi.width, this.tfDiachi.height))
        {
          this.focus = 4;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfCMND.x, this.tfCMND.y, this.tfCMND.width, this.tfCMND.height))
        {
          this.focus = 5;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfNgayCap.x, this.tfNgayCap.y, this.tfNgayCap.width, this.tfNgayCap.height))
        {
          this.focus = 6;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfNoiCap.x, this.tfNoiCap.y, this.tfNoiCap.width, this.tfNoiCap.height))
        {
          this.focus = 7;
          this.processFocus();
        }
        else if (GameCanvas.isPointerHoldIn(this.tfSodt.x, this.tfSodt.y, this.tfSodt.width, this.tfSodt.height))
        {
          this.focus = 8;
          this.processFocus();
        }
      }
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
            ex.StackTrace.ToString();
          }
          GameCanvas.endDlg();
          break;
        case 1001:
          GameCanvas.endDlg();
          this.isRes = false;
          break;
        case 1002:
          break;
        case 1003:
          Session_ME.gI().close();
          GameCanvas.serverScreen.switchToMe();
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
            ex.StackTrace.ToString();
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
          if (this.tfNgay.getText().Equals(string.Empty) || this.tfThang.getText().Equals(string.Empty) || this.tfNam.getText().Equals(string.Empty) || this.tfDiachi.getText().Equals(string.Empty) || this.tfCMND.getText().Equals(string.Empty) || this.tfNgayCap.getText().Equals(string.Empty) || this.tfNoiCap.getText().Equals(string.Empty) || this.tfSodt.getText().Equals(string.Empty) || this.tfUser.getText().Equals(string.Empty))
          {
            GameCanvas.startOKDlg("Vui lòng điền đầy đủ thông tin");
            break;
          }
          GameCanvas.startOKDlg(mResources.PLEASEWAIT);
          Service.gI().charInfo(this.tfNgay.getText(), this.tfThang.getText(), this.tfNam.getText(), this.tfDiachi.getText(), this.tfCMND.getText(), this.tfNgayCap.getText(), this.tfNoiCap.getText(), this.tfSodt.getText(), this.tfUser.getText());
          break;
        default:
          if (idAction == 10041 || idAction == 10042)
            break;
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
        this.tfNgay.isFocus = false;
        this.tfUser.isFocus = true;
        this.left = this.cmdMenu;
      }
    }

    public void actRegister()
    {
      GameCanvas.endDlg();
      GameCanvas.startOKDlg(mResources.regNote);
      this.isRes = true;
      this.tfNgay.isFocus = false;
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
        GameCanvas.instance.doResetToLoginScr((mScreen) GameCanvas.loginScr);
        Session_ME.gI().close();
      }
    }
  }
}
