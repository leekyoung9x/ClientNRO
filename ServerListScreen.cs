// Decompiled with JetBrains decompiler
// Type: ServerListScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class ServerListScreen : mScreen, IActionListener
{
  public static string[] nameServer;
  public static string[] address;
  public static sbyte serverPriority;
  public static bool[] hasConnected;
  public static short[] port;
  public static int selected;
  public static bool isWait;
  public static Command cmdUpdateServer;
  public static sbyte[] language;
  private Command[] cmd;
  private Command cmdCallHotline;
  private int nCmdPlay;
  public static Command cmdDeleteRMS;
  private int lY;
  public static string smartPhoneVN = "Admin:127.0.0.1:14445:0,0,0";
  public static string javaVN = "Admin:127.0.0.1:14445:0,0,0";
  public static string smartPhoneIn;
  public static string javaIn = "Admin:127.0.0.1:14445:0,0,0";
  public static string smartPhoneE = "Admin:127.0.0.1:14445:0,0,0";
  public static string javaE = "Admin:127.0.0.1:14445:0,0,0";
  public static string linkGetHost = "http://sv1.ngocrongonline.com/game/ngocrong031_t.php";
  public static string linkDefault = ServerListScreen.javaVN;
  public const sbyte languageVersion = 2;
  public new int keyTouch = -1;
  private int tam;
  public static bool stopDownload;
  public static string linkweb = "http://ngocrongonline.com";
  public static bool waitToLogin;
  public static int tWaitToLogin;
  public static int[] lengthServer = new int[3];
  public static int ipSelect;
  public static int flagServer;
  public static bool bigOk;
  public static int percent;
  public static string strWait;
  public static int nBig;
  public static int nBg;
  public static int demPercent;
  public static int maxBg;
  public static bool isGetData = false;
  public static Command cmdDownload;
  private Command cmdStart;
  public string dataSize;
  public static int p;
  public static int testConnect = -1;
  public static bool loadScreen;

  public ServerListScreen()
  {
    int num1 = 4;
    if (num1 * 32 + 23 + 33 >= GameCanvas.w)
    {
      int num2 = (num1 - 1) * 32 + 23 + 33;
    }
    this.initCommand();
    if (!GameCanvas.isTouch)
    {
      ServerListScreen.selected = 0;
      this.processInput();
    }
    GameScr.loadCamera(true, -1, -1);
    GameScr.cmx = 100;
    GameScr.cmy = 200;
    if (this.cmdCallHotline == null)
    {
      this.cmdCallHotline = new Command("Gọi hotline", (IActionListener) this, 13, (object) null);
      this.cmdCallHotline.x = GameCanvas.w - 75;
      this.cmdCallHotline.y = mSystem.clientType != 1 || GameCanvas.isTouch ? 2 + 6 : GameCanvas.h - 20;
    }
    ServerListScreen.cmdUpdateServer = new Command();
    ServerListScreen.cmdUpdateServer.actionChat = (ActionChat) (str =>
    {
      string str1 = str;
      string str2 = str;
      if (str1 == null)
      {
        string linkDefault = ServerListScreen.linkDefault;
      }
      else
      {
        if (str1 == null && str2 != null)
        {
          if (str2.Equals(string.Empty) || str2.Length < 20)
            str2 = ServerListScreen.linkDefault;
          ServerListScreen.getServerList(str2);
        }
        if (str1 != null && str2 == null)
        {
          if (str1.Equals(string.Empty) || str1.Length < 20)
            str1 = ServerListScreen.linkDefault;
          ServerListScreen.getServerList(str1);
        }
        if (str1 == null || str2 == null)
          return;
        if (str1.Length > str2.Length)
          ServerListScreen.getServerList(str1);
        else
          ServerListScreen.getServerList(str2);
      }
    });
    this.setLinkDefault(mSystem.LANGUAGE);
  }

  public static void createDeleteRMS()
  {
    if (ServerListScreen.cmdDeleteRMS != null)
      return;
    if (GameCanvas.serverScreen == null)
      GameCanvas.serverScreen = new ServerListScreen();
    ServerListScreen.cmdDeleteRMS = new Command(string.Empty, (IActionListener) GameCanvas.serverScreen, 14, (object) null);
    ServerListScreen.cmdDeleteRMS.x = GameCanvas.w - 78;
    ServerListScreen.cmdDeleteRMS.y = GameCanvas.h - 26;
  }

  private void initCommand()
  {
    this.nCmdPlay = 0;
    string str = Rms.loadRMSString("acc");
    if (str == null)
    {
      if (Rms.loadRMS("userAo" + (object) ServerListScreen.ipSelect) != null)
        this.nCmdPlay = 1;
    }
    else if (str.Equals(string.Empty))
    {
      if (Rms.loadRMS("userAo" + (object) ServerListScreen.ipSelect) != null)
        this.nCmdPlay = 1;
    }
    else
      this.nCmdPlay = 1;
    this.cmd = new Command[mGraphics.zoomLevel <= 1 ? 4 + this.nCmdPlay : 3 + this.nCmdPlay];
    int num = GameCanvas.hh - 15 * this.cmd.Length + 28;
    for (int index = 0; index < this.cmd.Length; ++index)
    {
      switch (index)
      {
        case 0:
          this.cmd[0] = new Command(string.Empty, (IActionListener) this, 3, (object) null);
          if (str == null)
          {
            this.cmd[0].caption = mResources.playNew;
            if (Rms.loadRMS("userAo" + (object) ServerListScreen.ipSelect) != null)
            {
              this.cmd[0].caption = mResources.choitiep;
              break;
            }
            break;
          }
          if (str.Equals(string.Empty))
          {
            this.cmd[0].caption = mResources.playNew;
            if (Rms.loadRMS("userAo" + (object) ServerListScreen.ipSelect) != null)
            {
              this.cmd[0].caption = mResources.choitiep;
              break;
            }
            break;
          }
          this.cmd[0].caption = mResources.playAcc + ": " + str;
          if (this.cmd[0].caption.Length > 23)
          {
            this.cmd[0].caption = this.cmd[0].caption.Substring(0, 23);
            this.cmd[0].caption += "...";
            break;
          }
          break;
        case 1:
          if (this.nCmdPlay == 1)
          {
            this.cmd[1] = new Command(string.Empty, (IActionListener) this, 10100, (object) null);
            this.cmd[1].caption = mResources.playNew;
            break;
          }
          this.cmd[1] = new Command(mResources.change_account, (IActionListener) this, 7, (object) null);
          break;
        case 2:
          this.cmd[2] = this.nCmdPlay != 1 ? new Command(string.Empty, (IActionListener) this, 17, (object) null) : new Command(mResources.change_account, (IActionListener) this, 7, (object) null);
          break;
        case 3:
          this.cmd[3] = this.nCmdPlay != 1 ? new Command(mResources.option, (IActionListener) this, 8, (object) null) : new Command(string.Empty, (IActionListener) this, 17, (object) null);
          break;
        case 4:
          this.cmd[4] = new Command(mResources.option, (IActionListener) this, 8, (object) null);
          break;
      }
      this.cmd[index].y = num;
      this.cmd[index].setType();
      this.cmd[index].x = (GameCanvas.w - this.cmd[index].w) / 2;
      num += 30;
    }
  }

  public static void doUpdateServer()
  {
    if (ServerListScreen.cmdUpdateServer == null && GameCanvas.serverScreen == null)
      GameCanvas.serverScreen = new ServerListScreen();
    Net.connectHTTP2(ServerListScreen.linkDefault, ServerListScreen.cmdUpdateServer);
  }

  public static void getServerList(string str)
  {
    ServerListScreen.lengthServer = new int[3];
    string[] strArray1 = Res.split(str.Trim(), ",", 0);
    Res.outz("tem leng= " + (object) strArray1.Length);
    mResources.loadLanguague(sbyte.Parse(strArray1[strArray1.Length - 2]));
    ServerListScreen.nameServer = new string[strArray1.Length - 2];
    ServerListScreen.address = new string[strArray1.Length - 2];
    ServerListScreen.port = new short[strArray1.Length - 2];
    ServerListScreen.language = new sbyte[strArray1.Length - 2];
    ServerListScreen.hasConnected = new bool[2];
    for (int index = 0; index < strArray1.Length - 2; ++index)
    {
      string[] strArray2 = Res.split(strArray1[index].Trim(), ":", 0);
      ServerListScreen.nameServer[index] = strArray2[0];
      ServerListScreen.address[index] = strArray2[1];
      ServerListScreen.port[index] = short.Parse(strArray2[2]);
      ServerListScreen.language[index] = sbyte.Parse(strArray2[3].Trim());
      ++ServerListScreen.lengthServer[(int) ServerListScreen.language[index]];
    }
    ServerListScreen.serverPriority = sbyte.Parse(strArray1[strArray1.Length - 1]);
    ServerListScreen.saveIP();
    GameCanvas.endDlg();
  }

  public override void paint(mGraphics g)
  {
    if (!ServerListScreen.loadScreen)
    {
      g.setColor(0);
      g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
      if (ServerListScreen.bigOk)
        ;
    }
    else
      GameCanvas.paintBGGameScr(g);
    int y1 = 2;
    mFont.tahoma_7_white.drawString(g, "v" + GameMidlet.VERSION + "(" + (object) mGraphics.zoomLevel + ")", GameCanvas.w - 2, y1 + 15, 1, mFont.tahoma_7_grey);
    if (!ServerListScreen.isGetData || ServerListScreen.loadScreen)
    {
      if (mSystem.clientType == 1 && !GameCanvas.isTouch)
        mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
      else
        mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, y1, 1, mFont.tahoma_7_grey);
    }
    else
      mFont.tahoma_7_white.drawString(g, ServerListScreen.linkweb, GameCanvas.w - 2, y1, 1, mFont.tahoma_7_grey);
    int num = GameCanvas.w < 200 ? 160 : 180;
    if (ServerListScreen.cmdDeleteRMS != null)
      mFont.tahoma_7_white.drawString(g, mResources.xoadulieu, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
    if (GameCanvas.currentDialog == null)
    {
      if (!ServerListScreen.loadScreen)
      {
        if (!ServerListScreen.bigOk)
        {
          g.drawImage(LoginScr.imgTitle, GameCanvas.hw, GameCanvas.hh - 32, 3);
          if (!ServerListScreen.isGetData)
          {
            mFont.tahoma_7b_white.drawString(g, mResources.taidulieudechoi, GameCanvas.hw, GameCanvas.hh + 24, 2);
            if (ServerListScreen.cmdDownload != null)
              ServerListScreen.cmdDownload.paint(g);
          }
          else
          {
            if (ServerListScreen.cmdDownload != null)
              ServerListScreen.cmdDownload.paint(g);
            mFont.tahoma_7b_white.drawString(g, mResources.downloading_data + (object) ServerListScreen.percent + "%", GameCanvas.w / 2, GameCanvas.hh + 24, 2);
            GameScr.paintOngMauPercent(GameScr.frBarPow20, GameScr.frBarPow21, GameScr.frBarPow22, (float) (GameCanvas.w / 2 - 50), (float) (GameCanvas.hh + 45), 100, 100f, g);
            GameScr.paintOngMauPercent(GameScr.frBarPow0, GameScr.frBarPow1, GameScr.frBarPow2, (float) (GameCanvas.w / 2 - 50), (float) (GameCanvas.hh + 45), 100, (float) ServerListScreen.percent, g);
          }
        }
      }
      else
      {
        int y2 = GameCanvas.hh - 15 * this.cmd.Length - 15;
        if (y2 < 25)
          y2 = 25;
        if (LoginScr.imgTitle != null)
          g.drawImage(LoginScr.imgTitle, GameCanvas.hw, y2, 3);
        for (int index = 0; index < this.cmd.Length; ++index)
          this.cmd[index].paint(g);
        g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
        if (ServerListScreen.testConnect == -1)
        {
          if (GameCanvas.gameTick % 20 > 10)
            g.drawRegion(GameScr.imgRoomStat, 0, 14, 7, 7, 0, (GameCanvas.w - mFont.tahoma_7b_dark.getWidth(this.cmd[2 + this.nCmdPlay].caption) >> 1) - 10, this.cmd[2 + this.nCmdPlay].y + 10, 0);
        }
        else
          g.drawRegion(GameScr.imgRoomStat, 0, ServerListScreen.testConnect * 7, 7, 7, 0, (GameCanvas.w - mFont.tahoma_7b_dark.getWidth(this.cmd[2 + this.nCmdPlay].caption) >> 1) - 10, this.cmd[2 + this.nCmdPlay].y + 9, 0);
      }
    }
    base.paint(g);
  }

  public void selectServer()
  {
    ServerListScreen.flagServer = 30;
    GameCanvas.startWaitDlg(mResources.PLEASEWAIT);
    if (Session_ME.gI().isConnected())
      Session_ME.gI().close();
    GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
    GameMidlet.PORT = (int) ServerListScreen.port[ServerListScreen.ipSelect];
    if ((int) ServerListScreen.language[ServerListScreen.ipSelect] != (int) mResources.language)
      mResources.loadLanguague(ServerListScreen.language[ServerListScreen.ipSelect]);
    LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
    this.initCommand();
    GameCanvas.connect();
  }

  public override void update()
  {
    if (ServerListScreen.waitToLogin)
    {
      ++ServerListScreen.tWaitToLogin;
      if (ServerListScreen.tWaitToLogin == 50)
        GameCanvas.serverScreen.selectServer();
      if (ServerListScreen.tWaitToLogin == 100)
      {
        if (GameCanvas.loginScr == null)
          GameCanvas.loginScr = new LoginScr();
        GameCanvas.loginScr.doLogin();
        Service.gI().finishUpdate();
        ServerListScreen.waitToLogin = false;
      }
    }
    if (ServerListScreen.flagServer > 0)
    {
      --ServerListScreen.flagServer;
      if (ServerListScreen.flagServer == 0)
        GameCanvas.endDlg();
    }
    for (int index = 0; index < this.cmd.Length; ++index)
      this.cmd[index].isFocus = index == ServerListScreen.selected;
    ++GameScr.cmx;
    if (!ServerListScreen.loadScreen && (ServerListScreen.bigOk || ServerListScreen.percent == 100))
      ServerListScreen.cmdDownload = (Command) null;
    base.update();
  }

  private void processInput()
  {
    if (ServerListScreen.loadScreen)
      this.center = new Command(string.Empty, (IActionListener) this, this.cmd[ServerListScreen.selected].idAction, (object) null);
    else
      this.center = ServerListScreen.cmdDownload;
  }

  public static void updateDeleteData()
  {
    if (ServerListScreen.cmdDeleteRMS == null || !ServerListScreen.cmdDeleteRMS.isPointerPressInside())
      return;
    ServerListScreen.cmdDeleteRMS.performAction();
  }

  public override void updateKey()
  {
    if (GameCanvas.isTouch)
    {
      ServerListScreen.updateDeleteData();
      if (this.cmdCallHotline != null && this.cmdCallHotline.isPointerPressInside())
        this.cmdCallHotline.performAction();
      if (!ServerListScreen.loadScreen)
      {
        if (ServerListScreen.cmdDownload != null && ServerListScreen.cmdDownload.isPointerPressInside())
          ServerListScreen.cmdDownload.performAction();
        base.updateKey();
        return;
      }
      for (int index = 0; index < this.cmd.Length; ++index)
      {
        if (this.cmd[index] != null && this.cmd[index].isPointerPressInside())
          this.cmd[index].performAction();
      }
    }
    else if (ServerListScreen.loadScreen)
    {
      if (GameCanvas.keyPressed[8])
      {
        int num = mGraphics.zoomLevel <= 1 ? 4 : 2;
        GameCanvas.keyPressed[8] = false;
        ++ServerListScreen.selected;
        if (ServerListScreen.selected > num)
          ServerListScreen.selected = 0;
        this.processInput();
      }
      if (GameCanvas.keyPressed[2])
      {
        int num = mGraphics.zoomLevel <= 1 ? 4 : 2;
        GameCanvas.keyPressed[2] = false;
        --ServerListScreen.selected;
        if (ServerListScreen.selected < 0)
          ServerListScreen.selected = num;
        this.processInput();
      }
    }
    if (ServerListScreen.isWait)
      return;
    base.updateKey();
  }

  public static void saveIP()
  {
    DataOutputStream dataOutputStream = new DataOutputStream();
    try
    {
      dataOutputStream.writeByte(mResources.language);
      dataOutputStream.writeByte((sbyte) ServerListScreen.nameServer.Length);
      for (int index = 0; index < ServerListScreen.nameServer.Length; ++index)
      {
        dataOutputStream.writeUTF(ServerListScreen.nameServer[index]);
        dataOutputStream.writeUTF(ServerListScreen.address[index]);
        dataOutputStream.writeShort(ServerListScreen.port[index]);
        dataOutputStream.writeByte(ServerListScreen.language[index]);
      }
      dataOutputStream.writeByte(ServerListScreen.serverPriority);
      Rms.saveRMS("NRlink2", dataOutputStream.toByteArray());
      dataOutputStream.close();
      SplashScr.loadIP();
    }
    catch (Exception ex)
    {
    }
  }

  public static bool allServerConnected()
  {
    for (int index = 0; index < 2; ++index)
    {
      if (!ServerListScreen.hasConnected[index])
        return false;
    }
    return true;
  }

  public static void loadIP()
  {
    sbyte[] data = Rms.loadRMS("NRlink2");
    if (data == null)
    {
      ServerListScreen.getServerList(ServerListScreen.linkDefault);
    }
    else
    {
      DataInputStream dataInputStream = new DataInputStream(data);
      if (dataInputStream == null)
        return;
      try
      {
        ServerListScreen.lengthServer = new int[3];
        mResources.loadLanguague(dataInputStream.readByte());
        sbyte length = dataInputStream.readByte();
        ServerListScreen.nameServer = new string[(int) length];
        ServerListScreen.address = new string[(int) length];
        ServerListScreen.port = new short[(int) length];
        ServerListScreen.language = new sbyte[(int) length];
        for (int index = 0; index < (int) length; ++index)
        {
          ServerListScreen.nameServer[index] = dataInputStream.readUTF();
          ServerListScreen.address[index] = dataInputStream.readUTF();
          ServerListScreen.port[index] = dataInputStream.readShort();
          ServerListScreen.language[index] = dataInputStream.readByte();
          ++ServerListScreen.lengthServer[(int) ServerListScreen.language[index]];
        }
        ServerListScreen.serverPriority = dataInputStream.readByte();
        dataInputStream.close();
        SplashScr.loadIP();
      }
      catch (Exception ex)
      {
      }
    }
  }

  public override void switchToMe()
  {
    GameCanvas.connect();
    GameScr.cmy = 0;
    GameScr.cmx = 0;
    this.initCommand();
    ServerListScreen.isWait = false;
    GameCanvas.loginScr = (LoginScr) null;
    string s = Rms.loadRMSString("ResVersion");
    if ((s == null || !(s != string.Empty) ? -1 : int.Parse(s)) > 0)
    {
      ServerListScreen.loadScreen = true;
      GameCanvas.loadBG(0);
    }
    ServerListScreen.bigOk = true;
    this.cmd[2 + this.nCmdPlay].caption = mResources.server + ": " + ServerListScreen.nameServer[ServerListScreen.ipSelect];
    this.center = new Command(string.Empty, (IActionListener) this, this.cmd[ServerListScreen.selected].idAction, (object) null);
    this.cmd[1 + this.nCmdPlay].caption = mResources.change_account;
    if (this.cmd.Length == 4 + this.nCmdPlay)
      this.cmd[3 + this.nCmdPlay].caption = mResources.option;
    mSystem.resetCurInapp();
    base.switchToMe();
  }

  public void switchToMe2()
  {
    GameScr.cmy = 0;
    GameScr.cmx = 0;
    this.initCommand();
    ServerListScreen.isWait = false;
    GameCanvas.loginScr = (LoginScr) null;
    string s = Rms.loadRMSString("ResVersion");
    if ((s == null || !(s != string.Empty) ? -1 : int.Parse(s)) > 0)
    {
      ServerListScreen.loadScreen = true;
      GameCanvas.loadBG(0);
    }
    ServerListScreen.bigOk = true;
    this.cmd[2 + this.nCmdPlay].caption = mResources.server + ": " + ServerListScreen.nameServer[ServerListScreen.ipSelect];
    this.center = new Command(string.Empty, (IActionListener) this, this.cmd[ServerListScreen.selected].idAction, (object) null);
    this.cmd[1 + this.nCmdPlay].caption = mResources.change_account;
    if (this.cmd.Length == 4 + this.nCmdPlay)
      this.cmd[3 + this.nCmdPlay].caption = mResources.option;
    mSystem.resetCurInapp();
    base.switchToMe();
  }

  public void connectOk()
  {
  }

  public void cancel()
  {
    if (GameCanvas.serverScreen == null)
      GameCanvas.serverScreen = new ServerListScreen();
    ServerListScreen.demPercent = 0;
    ServerListScreen.percent = 0;
    ServerListScreen.stopDownload = true;
    GameCanvas.serverScreen.show2();
    ServerListScreen.isGetData = false;
    ServerListScreen.cmdDownload.isFocus = true;
    this.center = new Command(string.Empty, (IActionListener) this, 2, (object) null);
  }

  public void perform(int idAction, object p)
  {
    Res.outz("perform " + (object) idAction);
    if (idAction == 1000)
      GameCanvas.connect();
    if (idAction == 1 || idAction == 4)
      this.cancel();
    if (idAction == 2)
    {
      ServerListScreen.stopDownload = false;
      ServerListScreen.cmdDownload = new Command(mResources.huy, (IActionListener) this, 4, (object) null);
      ServerListScreen.cmdDownload.x = GameCanvas.w / 2 - mScreen.cmdW / 2;
      ServerListScreen.cmdDownload.y = GameCanvas.hh + 65;
      this.right = (Command) null;
      if (!GameCanvas.isTouch)
      {
        ServerListScreen.cmdDownload.x = GameCanvas.w / 2 - mScreen.cmdW / 2;
        ServerListScreen.cmdDownload.y = GameCanvas.h - mScreen.cmdH - 1;
      }
      this.center = new Command(string.Empty, (IActionListener) this, 4, (object) null);
      if (!ServerListScreen.isGetData)
      {
        Service.gI().getResource((sbyte) 1, (MyVector) null);
        if (!GameCanvas.isTouch)
        {
          ServerListScreen.cmdDownload.isFocus = true;
          this.center = new Command(string.Empty, (IActionListener) this, 4, (object) null);
        }
        ServerListScreen.isGetData = true;
      }
    }
    if (idAction == 3)
    {
      Res.outz("toi day");
      if (GameCanvas.loginScr == null)
        GameCanvas.loginScr = new LoginScr();
      GameCanvas.loginScr.switchToMe();
      bool flag1 = Rms.loadRMSString("acc") != null && !Rms.loadRMSString("acc").Equals(string.Empty);
      bool flag2 = Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect) != null && !Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect).Equals(string.Empty);
      if (!flag1 && !flag2)
      {
        GameCanvas.connect();
        string username = Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect);
        if (username == null || username.Equals(string.Empty))
        {
          Service.gI().login2(string.Empty);
        }
        else
        {
          GameCanvas.loginScr.isLogin2 = true;
          GameCanvas.connect();
          Service.gI().setClientType();
          Service.gI().login(username, string.Empty, GameMidlet.VERSION, (sbyte) 1);
        }
        if (Session_ME.connected)
          GameCanvas.startWaitDlg();
        else
          GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
      }
      else
        GameCanvas.loginScr.doLogin();
      LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
    }
    if (idAction == 10100)
    {
      if (GameCanvas.loginScr == null)
        GameCanvas.loginScr = new LoginScr();
      GameCanvas.loginScr.switchToMe();
      GameCanvas.connect();
      Service.gI().login2(string.Empty);
      Res.outz("tao user ao");
      GameCanvas.startWaitDlg();
      LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
    }
    if (idAction == 5)
    {
      ServerListScreen.doUpdateServer();
      if (ServerListScreen.nameServer.Length == 1)
        return;
      MyVector menuItems = new MyVector(string.Empty);
      for (int index = 0; index < ServerListScreen.nameServer.Length; ++index)
        menuItems.addElement((object) new Command(ServerListScreen.nameServer[index], (IActionListener) this, 6, (object) null));
      GameCanvas.menu.startAt(menuItems, 0);
      if (!GameCanvas.isTouch)
        GameCanvas.menu.menuSelectedItem = ServerListScreen.ipSelect;
    }
    if (idAction == 6)
    {
      ServerListScreen.ipSelect = GameCanvas.menu.menuSelectedItem;
      this.selectServer();
    }
    if (idAction == 7)
    {
      if (GameCanvas.loginScr == null)
        GameCanvas.loginScr = new LoginScr();
      GameCanvas.loginScr.switchToMe();
    }
    if (idAction == 8)
    {
      bool flag = Rms.loadRMSInt("lowGraphic") == 1;
      MyVector menuItems = new MyVector("cau hinh");
      menuItems.addElement((object) new Command(mResources.cauhinhthap, (IActionListener) this, 9, (object) null));
      menuItems.addElement((object) new Command(mResources.cauhinhcao, (IActionListener) this, 10, (object) null));
      GameCanvas.menu.startAt(menuItems, 0);
      GameCanvas.menu.menuSelectedItem = !flag ? 1 : 0;
    }
    if (idAction == 9)
    {
      Rms.saveRMSInt("lowGraphic", 1);
      GameCanvas.startOK(mResources.plsRestartGame, 8885, (object) null);
    }
    if (idAction == 10)
    {
      Rms.saveRMSInt("lowGraphic", 0);
      GameCanvas.startOK(mResources.plsRestartGame, 8885, (object) null);
    }
    if (idAction == 11)
    {
      if (GameCanvas.loginScr == null)
        GameCanvas.loginScr = new LoginScr();
      GameCanvas.loginScr.switchToMe();
      string username = Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect);
      if (username == null || username.Equals(string.Empty))
      {
        Service.gI().login2(string.Empty);
      }
      else
      {
        GameCanvas.loginScr.isLogin2 = true;
        GameCanvas.connect();
        Service.gI().setClientType();
        Service.gI().login(username, string.Empty, GameMidlet.VERSION, (sbyte) 1);
      }
      GameCanvas.startWaitDlg(mResources.PLEASEWAIT);
      Res.outz("tao user ao");
    }
    if (idAction == 12)
      GameMidlet.instance.exit();
    if (idAction == 13 && (!ServerListScreen.isGetData || ServerListScreen.loadScreen))
    {
      switch (mSystem.clientType)
      {
        case 1:
          mSystem.callHotlineJava();
          break;
        case 3:
        case 5:
          mSystem.callHotlineIphone();
          break;
        case 4:
          mSystem.callHotlinePC();
          break;
        case 6:
          mSystem.callHotlineWindowsPhone();
          break;
      }
    }
    if (idAction == 14)
    {
      Command cmdYes = new Command(mResources.YES, (IActionListener) GameCanvas.serverScreen, 15, (object) null);
      Command cmdNo = new Command(mResources.NO, (IActionListener) GameCanvas.serverScreen, 16, (object) null);
      GameCanvas.startYesNoDlg(mResources.deletaDataNote, cmdYes, cmdNo);
    }
    if (idAction == 15)
    {
      Rms.clearAll();
      GameCanvas.startOK(mResources.plsRestartGame, 8885, (object) null);
    }
    if (idAction == 16)
    {
      InfoDlg.hide();
      GameCanvas.currentDialog = (Dialog) null;
    }
    if (idAction != 17)
      return;
    if (GameCanvas.serverScr == null)
      GameCanvas.serverScr = new ServerScr();
    GameCanvas.serverScr.switchToMe();
  }

  public void init()
  {
    if (!ServerListScreen.loadScreen)
    {
      ServerListScreen.cmdDownload = new Command(mResources.taidulieu, (IActionListener) this, 2, (object) null);
      ServerListScreen.cmdDownload.isFocus = true;
      ServerListScreen.cmdDownload.x = GameCanvas.w / 2 - mScreen.cmdW / 2;
      ServerListScreen.cmdDownload.y = GameCanvas.hh + 45;
      if (ServerListScreen.cmdDownload.y > GameCanvas.h - 26)
        ServerListScreen.cmdDownload.y = GameCanvas.h - 26;
    }
    if (GameCanvas.isTouch)
      return;
    ServerListScreen.selected = 0;
    this.processInput();
  }

  public void show2()
  {
    GameScr.cmx = 0;
    GameScr.cmy = 0;
    this.initCommand();
    ServerListScreen.loadScreen = false;
    ServerListScreen.percent = 0;
    ServerListScreen.bigOk = false;
    ServerListScreen.isGetData = false;
    ServerListScreen.p = 0;
    ServerListScreen.demPercent = 0;
    ServerListScreen.strWait = mResources.PLEASEWAIT;
    this.init();
    base.switchToMe();
  }

  public void setLinkDefault(sbyte language)
  {
    switch (language)
    {
      case 1:
        ServerListScreen.linkDefault = ServerListScreen.javaE;
        if (mSystem.clientType == 1)
        {
          ServerListScreen.linkDefault = ServerListScreen.javaE;
          break;
        }
        ServerListScreen.linkDefault = ServerListScreen.smartPhoneE;
        break;
      case 2:
        if (mSystem.clientType == 1)
        {
          ServerListScreen.linkDefault = ServerListScreen.javaIn;
          break;
        }
        ServerListScreen.linkDefault = ServerListScreen.smartPhoneIn;
        break;
      default:
        ServerListScreen.linkDefault = ServerListScreen.javaVN;
        if (mSystem.clientType == 1)
        {
          ServerListScreen.linkDefault = ServerListScreen.javaVN;
          break;
        }
        ServerListScreen.linkDefault = ServerListScreen.smartPhoneVN;
        break;
    }
  }
}
