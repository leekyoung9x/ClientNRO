// Decompiled with JetBrains decompiler
// Type: GameCanvas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.g;
using System;
using UnityEngine;

public class GameCanvas : IActionListener
{
  public static long timeNow = 0;
  public static bool open3Hour;
  public static bool lowGraphic = false;
  public static bool isMoveNumberPad = true;
  public static bool isLoading;
  public static bool isTouch = false;
  public static bool isTouchControl;
  public static bool isTouchControlSmallScreen;
  public static bool isTouchControlLargeScreen;
  public static bool isConnectFail;
  public static GameCanvas instance;
  public static bool bRun;
  public static bool[] keyPressed = new bool[30];
  public static bool[] keyReleased = new bool[30];
  public static bool[] keyHold = new bool[30];
  public static bool isPointerDown;
  public static bool isPointerClick;
  public static bool isPointerJustRelease;
  public static bool isPointerMove;
  public static int px;
  public static int py;
  public static int pxFirst;
  public static int pyFirst;
  public static int pxLast;
  public static int pyLast;
  public static int pxMouse;
  public static int pyMouse;
  public static Position[] arrPos = new Position[4];
  public static int gameTick;
  public static int taskTick;
  public static bool isEff1;
  public static bool isEff2;
  public static long timeTickEff1;
  public static long timeTickEff2;
  public static int w;
  public static int h;
  public static int hw;
  public static int hh;
  public static int wd3;
  public static int hd3;
  public static int w2d3;
  public static int h2d3;
  public static int w3d4;
  public static int h3d4;
  public static int wd6;
  public static int hd6;
  public static mScreen currentScreen;
  public static Menu menu = new Menu();
  public static Panel panel;
  public static Panel panel2;
  public static LoginScr loginScr;
  public static RegisterScreen registerScr;
  public static Dialog currentDialog;
  public static MsgDlg msgdlg;
  public static InputDlg inputDlg;
  public static MyVector currentPopup = new MyVector();
  public static int requestLoseCount;
  public static MyVector listPoint;
  public static Paint paintz;
  public static bool isGetResFromServer;
  public static Image[] imgBG;
  public static int skyColor;
  public static int curPos = 0;
  public static int[] bgW;
  public static int[] bgH;
  public static int planet = 0;
  private mGraphics g = new mGraphics();
  public static Image img12;
  public static Image[] imgBlue = new Image[7];
  public static Image[] imgViolet = new Image[7];
  public static bool isPlaySound = true;
  private static int clearOldData;
  public static int timeOpenKeyBoard;
  public static bool isFocusPanel2;
  public bool isPaintCarret;
  public static MyVector debugUpdate;
  public static MyVector debugPaint;
  public static MyVector debugSession;
  private static bool isShowErrorForm = false;
  public static bool paintBG;
  public static int gsskyHeight;
  public static int gsgreenField1Y;
  public static int gsgreenField2Y;
  public static int gshouseY;
  public static int gsmountainY;
  public static int bgLayer0y;
  public static int bgLayer1y;
  public static Image imgCloud;
  public static Image imgSun;
  public static Image imgSun2;
  public static Image imgClear;
  public static Image[] imgBorder = new Image[3];
  public static Image[] imgSunSpec = new Image[3];
  public static int borderConnerW;
  public static int borderConnerH;
  public static int borderCenterW;
  public static int borderCenterH;
  public static int[] cloudX;
  public static int[] cloudY;
  public static int sunX;
  public static int sunY;
  public static int sunX2;
  public static int sunY2;
  public static int[] layerSpeed;
  public static int[] moveX;
  public static int[] moveXSpeed;
  public static bool isBoltEff;
  public static bool boltActive;
  public static int tBolt;
  public static int typeBg = -1;
  public static int transY;
  public static int[] yb = new int[5];
  public static int[] colorTop;
  public static int[] colorBotton;
  public static int yb1;
  public static int yb2;
  public static int yb3;
  public static int nBg = 0;
  public static int lastBg = -1;
  public static int[] bgRain = new int[3]{ 1, 4, 11 };
  public static int[] bgRainFont = new int[1]{ -1 };
  public static Image imgCaycot;
  public static Image tam;
  public static int typeBackGround = -1;
  public static int saveIDBg = -10;
  public static bool isLoadBGok;
  private static long lastTimePress = 0;
  public static int keyAsciiPress;
  public static int pXYScrollMouse;
  private static Image imgSignal;
  public static MyVector flyTexts = new MyVector();
  public int longTime;
  public static bool isPointerJustDown = false;
  private int count = 1;
  public static bool csWait;
  public static MyRandom r = new MyRandom();
  public static bool isBlackScreen;
  public static int[] bgSpeed;
  public static int cmdBarX;
  public static int cmdBarY;
  public static int cmdBarW;
  public static int cmdBarH;
  public static int cmdBarLeftW;
  public static int cmdBarRightW;
  public static int cmdBarCenterW;
  public static int hpBarX;
  public static int hpBarY;
  public static int hpBarW;
  public static int expBarW;
  public static int lvPosX;
  public static int moneyPosX;
  public static int hpBarH;
  public static int girlHPBarY;
  public int timeOut;
  public int[] dustX;
  public int[] dustY;
  public int[] dustState;
  public static int[] wsX;
  public static int[] wsY;
  public static int[] wsState;
  public static int[] wsF;
  public static Image[] imgWS;
  public static Image imgShuriken;
  public static Image[][] imgDust;
  public static bool isResume;
  public static ServerListScreen serverScreen;
  public static ServerScr serverScr;
  public bool resetToLoginScr;

  public GameCanvas()
  {
    switch (Rms.loadRMSInt("languageVersion"))
    {
      case -1:
        Rms.saveRMSInt("languageVersion", 2);
        goto case 2;
      case 2:
        GameCanvas.clearOldData = Rms.loadRMSInt(GameMidlet.VERSION);
        if (GameCanvas.clearOldData != 1)
        {
          Main.main.doClearRMS();
          Rms.saveRMSInt(GameMidlet.VERSION, 1);
        }
        this.initGame();
        break;
      default:
        Main.main.doClearRMS();
        Rms.saveRMSInt("languageVersion", 2);
        goto case 2;
    }
  }

  public static string getPlatformName() => "Pc platform xxx";

  public void initGame()
  {
    MotherCanvas.instance.setChildCanvas(this);
    GameCanvas.w = MotherCanvas.instance.getWidthz();
    GameCanvas.h = MotherCanvas.instance.getHeightz();
    GameCanvas.hw = GameCanvas.w / 2;
    GameCanvas.hh = GameCanvas.h / 2;
    GameCanvas.isTouch = true;
    if (GameCanvas.w >= 240)
      GameCanvas.isTouchControl = true;
    if (GameCanvas.w < 320)
      GameCanvas.isTouchControlSmallScreen = true;
    if (GameCanvas.w >= 320)
      GameCanvas.isTouchControlLargeScreen = true;
    GameCanvas.msgdlg = new MsgDlg();
    if (GameCanvas.h <= 160)
    {
      Paint.hTab = 15;
      mScreen.cmdH = 17;
    }
    GameScr.d = (GameCanvas.w <= GameCanvas.h ? GameCanvas.h : GameCanvas.w) + 20;
    GameCanvas.instance = this;
    mFont.init();
    mScreen.ITEM_HEIGHT = mFont.tahoma_8b.getHeight() + 8;
    this.initPaint();
    this.loadDust();
    this.loadWaterSplash();
    GameCanvas.panel = new Panel();
    GameCanvas.imgShuriken = GameCanvas.loadImage("/mainImage/myTexture2df.png");
    int num = Rms.loadRMSInt("clienttype");
    if (num != -1)
    {
      if (num > 7)
        Rms.saveRMSInt("clienttype", mSystem.clientType);
      else
        mSystem.clientType = num;
    }
    if (mSystem.clientType == 7 && (Rms.loadRMSString("fake") == null || Rms.loadRMSString("fake") == string.Empty))
      GameCanvas.imgShuriken = GameCanvas.loadImage("/mainImage/wait.png");
    GameCanvas.imgClear = GameCanvas.loadImage("/mainImage/myTexture2der.png");
    GameCanvas.img12 = GameCanvas.loadImage("/mainImage/12+.png");
    GameCanvas.debugUpdate = new MyVector();
    GameCanvas.debugPaint = new MyVector();
    GameCanvas.debugSession = new MyVector();
    for (int index = 0; index < 3; ++index)
      GameCanvas.imgBorder[index] = GameCanvas.loadImage("/mainImage/myTexture2dbd" + (object) index + ".png");
    GameCanvas.borderConnerW = mGraphics.getImageWidth(GameCanvas.imgBorder[0]);
    GameCanvas.borderConnerH = mGraphics.getImageHeight(GameCanvas.imgBorder[0]);
    GameCanvas.borderCenterW = mGraphics.getImageWidth(GameCanvas.imgBorder[1]);
    GameCanvas.borderCenterH = mGraphics.getImageHeight(GameCanvas.imgBorder[1]);
    Panel.graphics = Rms.loadRMSInt("lowGraphic");
    GameCanvas.lowGraphic = Rms.loadRMSInt("lowGraphic") == 1;
    GameScr.isPaintChatVip = Rms.loadRMSInt("serverchat") != 1;
    Char.isPaintAura = Rms.loadRMSInt("isPaintAura") == 1;
    Res.init();
    SmallImage.loadBigImage();
    Panel.WIDTH_PANEL = 176;
    if (Panel.WIDTH_PANEL > GameCanvas.w)
      Panel.WIDTH_PANEL = GameCanvas.w;
    InfoMe.gI().loadCharId();
    Command.btn0left = GameCanvas.loadImage("/mainImage/btn0left.png");
    Command.btn0mid = GameCanvas.loadImage("/mainImage/btn0mid.png");
    Command.btn0right = GameCanvas.loadImage("/mainImage/btn0right.png");
    Command.btn1left = GameCanvas.loadImage("/mainImage/btn1left.png");
    Command.btn1mid = GameCanvas.loadImage("/mainImage/btn1mid.png");
    Command.btn1right = GameCanvas.loadImage("/mainImage/btn1right.png");
    GameCanvas.serverScreen = new ServerListScreen();
    GameCanvas.img12 = GameCanvas.loadImage("/mainImage/12+.png");
    for (int index = 0; index < 7; ++index)
    {
      GameCanvas.imgBlue[index] = GameCanvas.loadImage("/effectdata/blue/" + (object) index + ".png");
      GameCanvas.imgViolet[index] = GameCanvas.loadImage("/effectdata/violet/" + (object) index + ".png");
    }
    ServerListScreen.createDeleteRMS();
    GameCanvas.serverScr = new ServerScr();
  }

  public static GameCanvas gI() => GameCanvas.instance;

  public void initPaint() => GameCanvas.paintz = new Paint();

  public static void closeKeyBoard()
  {
    mGraphics.addYWhenOpenKeyBoard = 0;
    GameCanvas.timeOpenKeyBoard = 0;
    Main.closeKeyBoard();
  }

  public void update()
  {
    if (GameCanvas.gameTick % 5 == 0)
      GameCanvas.timeNow = mSystem.currentTimeMillis();
    Res.updateOnScreenDebug();
    try
    {
      if (TouchScreenKeyboard.visible)
      {
        ++GameCanvas.timeOpenKeyBoard;
        if (GameCanvas.timeOpenKeyBoard > (!Main.isWindowsPhone ? 10 : 5))
          mGraphics.addYWhenOpenKeyBoard = 94;
      }
      else
      {
        mGraphics.addYWhenOpenKeyBoard = 0;
        GameCanvas.timeOpenKeyBoard = 0;
      }
      GameCanvas.debugUpdate.removeAllElements();
      long num = mSystem.currentTimeMillis();
      if (num - GameCanvas.timeTickEff1 >= 780L && !GameCanvas.isEff1)
      {
        GameCanvas.timeTickEff1 = num;
        GameCanvas.isEff1 = true;
      }
      else
        GameCanvas.isEff1 = false;
      if (num - GameCanvas.timeTickEff2 >= 7800L && !GameCanvas.isEff2)
      {
        GameCanvas.timeTickEff2 = num;
        GameCanvas.isEff2 = true;
      }
      else
        GameCanvas.isEff2 = false;
      if (GameCanvas.taskTick > 0)
        --GameCanvas.taskTick;
      ++GameCanvas.gameTick;
      if (GameCanvas.gameTick > 10000)
      {
        if (mSystem.currentTimeMillis() - GameCanvas.lastTimePress > 20000L && GameCanvas.currentScreen == GameCanvas.loginScr)
          GameMidlet.instance.exit();
        GameCanvas.gameTick = 0;
      }
      if (GameCanvas.currentScreen != null)
      {
        if (ChatPopup.serverChatPopUp != null)
        {
          ChatPopup.serverChatPopUp.update();
          ChatPopup.serverChatPopUp.updateKey();
        }
        else if (ChatPopup.currChatPopup != null)
        {
          ChatPopup.currChatPopup.update();
          ChatPopup.currChatPopup.updateKey();
        }
        else if (GameCanvas.currentDialog != null)
        {
          GameCanvas.debug("B", 0);
          GameCanvas.currentDialog.update();
        }
        else if (GameCanvas.menu.showMenu)
        {
          GameCanvas.debug("C", 0);
          GameCanvas.menu.updateMenu();
          GameCanvas.debug("D", 0);
          GameCanvas.menu.updateMenuKey();
        }
        else if (GameCanvas.panel.isShow)
        {
          GameCanvas.panel.update();
          if (GameCanvas.isPointer(GameCanvas.panel.X, GameCanvas.panel.Y, GameCanvas.panel.W, GameCanvas.panel.H))
            GameCanvas.isFocusPanel2 = false;
          if (GameCanvas.panel2 != null && GameCanvas.panel2.isShow)
          {
            GameCanvas.panel2.update();
            if (GameCanvas.isPointer(GameCanvas.panel2.X, GameCanvas.panel2.Y, GameCanvas.panel2.W, GameCanvas.panel2.H))
              GameCanvas.isFocusPanel2 = true;
          }
          if (GameCanvas.panel2 != null)
          {
            if (GameCanvas.isFocusPanel2)
              GameCanvas.panel2.updateKey();
            else
              GameCanvas.panel.updateKey();
          }
          else
            GameCanvas.panel.updateKey();
          if (GameCanvas.panel.chatTField != null && GameCanvas.panel.chatTField.isShow)
            GameCanvas.panel.chatTFUpdateKey();
          else if (GameCanvas.panel2 != null && GameCanvas.panel2.chatTField != null && GameCanvas.panel2.chatTField.isShow)
            GameCanvas.panel2.chatTFUpdateKey();
          else if (GameCanvas.isPointer(GameCanvas.panel.X, GameCanvas.panel.Y, GameCanvas.panel.W, GameCanvas.panel.H) && GameCanvas.panel2 != null || GameCanvas.panel2 == null)
            GameCanvas.panel.updateKey();
          else if (GameCanvas.panel2 != null && GameCanvas.panel2.isShow && GameCanvas.isPointer(GameCanvas.panel2.X, GameCanvas.panel2.Y, GameCanvas.panel2.W, GameCanvas.panel2.H))
            GameCanvas.panel2.updateKey();
          if (GameCanvas.isPointer(GameCanvas.panel.X + GameCanvas.panel.W, GameCanvas.panel.Y, GameCanvas.w - GameCanvas.panel.W * 2, GameCanvas.panel.H) && GameCanvas.isPointerJustRelease && GameCanvas.panel.isDoneCombine)
            GameCanvas.panel.hide();
        }
        GameCanvas.debug("E", 0);
        if (!GameCanvas.isLoading)
          GameCanvas.currentScreen.update();
        GameCanvas.debug("F", 0);
        if (!GameCanvas.panel.isShow && ChatPopup.serverChatPopUp == null)
          GameCanvas.currentScreen.updateKey();
        Hint.update();
        SoundMn.gI().update();
      }
      GameCanvas.debug("Ix", 0);
      Timer.update();
      GameCanvas.debug("Hx", 0);
      InfoDlg.update();
      GameCanvas.debug("G", 0);
      if (this.resetToLoginScr)
      {
        this.resetToLoginScr = false;
        this.doResetToLoginScr((mScreen) GameCanvas.serverScreen);
      }
      GameCanvas.debug("Zzz", 0);
      if (Controller.isConnectOK)
      {
        if (Controller.isMain)
        {
          GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
          GameMidlet.PORT = (int) ServerListScreen.port[ServerListScreen.ipSelect];
          Cout.println("Connect ok");
          ServerListScreen.testConnect = 2;
          Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
          Rms.saveIP(GameMidlet.IP + ":" + (object) GameMidlet.PORT);
          Service.gI().setClientType();
          Service.gI().androidPack();
        }
        else
        {
          Service.gI().setClientType2();
          Service.gI().androidPack2();
        }
        Controller.isConnectOK = false;
      }
      if (Controller.isDisconnected)
      {
        Debug.Log((object) "disconnect");
        if (!Controller.isMain)
        {
          if (GameCanvas.currentScreen == GameCanvas.serverScreen && !Service.reciveFromMainSession)
            GameCanvas.serverScreen.cancel();
          if (GameCanvas.currentScreen == GameCanvas.loginScr && !Service.reciveFromMainSession)
            this.onDisconnected();
        }
        else
          this.onDisconnected();
        Controller.isDisconnected = false;
      }
      if (Controller.isConnectionFail)
      {
        Debug.Log((object) "connect fail");
        if (!Controller.isMain)
        {
          if (GameCanvas.currentScreen == GameCanvas.serverScreen && ServerListScreen.isGetData && !Service.reciveFromMainSession)
            GameCanvas.serverScreen.cancel();
          if (GameCanvas.currentScreen == GameCanvas.loginScr && !Service.reciveFromMainSession)
            this.onConnectionFail();
        }
        else
          this.onConnectionFail();
        Controller.isConnectionFail = false;
      }
      if (!Main.isResume)
        return;
      Main.isResume = false;
      if (GameCanvas.currentDialog == null || GameCanvas.currentDialog.left == null || GameCanvas.currentDialog.left.actionListener == null)
        return;
      GameCanvas.currentDialog.left.performAction();
    }
    catch (Exception ex)
    {
    }
  }

  public void onDisconnected()
  {
    if (Controller.isConnectionFail)
      Controller.isConnectionFail = false;
    GameCanvas.isResume = true;
    Session_ME.gI().clearSendingMessage();
    Session_ME2.gI().clearSendingMessage();
    if (Controller.isLoadingData)
    {
      GameCanvas.instance.resetToLoginScrz();
      GameCanvas.startOK(mResources.pls_restart_game_error, 8885, (object) null);
      Controller.isDisconnected = false;
    }
    else
    {
      Char.isLoadingMap = false;
      if (Controller.isMain)
        ServerListScreen.testConnect = 0;
      GameCanvas.instance.resetToLoginScrz();
      if (Main.typeClient == 6)
      {
        if (GameCanvas.currentScreen != GameCanvas.serverScreen && GameCanvas.currentScreen != GameCanvas.loginScr)
          GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
      }
      else
        GameCanvas.startOKDlg(mResources.maychutathoacmatsong);
      mSystem.endKey();
    }
  }

  public void onConnectionFail()
  {
    if (GameCanvas.currentScreen.Equals((object) SplashScr.instance))
    {
      if (ServerListScreen.hasConnected != null)
      {
        if (!ServerListScreen.hasConnected[0])
        {
          ServerListScreen.hasConnected[0] = true;
          ServerListScreen.ipSelect = 0;
          GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
          Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
          GameCanvas.connect();
        }
        else if (!ServerListScreen.hasConnected[2])
        {
          ServerListScreen.hasConnected[2] = true;
          ServerListScreen.ipSelect = 2;
          GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
          Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
          GameCanvas.connect();
        }
        else
          GameCanvas.startOK(mResources.pls_restart_game_error, 8885, (object) null);
      }
      else
        GameCanvas.startOK(mResources.pls_restart_game_error, 8885, (object) null);
    }
    else
    {
      Session_ME.gI().clearSendingMessage();
      Session_ME2.gI().clearSendingMessage();
      ServerListScreen.isWait = false;
      if (Controller.isLoadingData)
      {
        GameCanvas.startOK(mResources.pls_restart_game_error, 8885, (object) null);
        Controller.isConnectionFail = false;
      }
      else
      {
        GameCanvas.isResume = true;
        LoginScr.isContinueToLogin = false;
        if (GameCanvas.loginScr != null)
          GameCanvas.instance.resetToLoginScrz();
        else
          GameCanvas.loginScr = new LoginScr();
        LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
        if (GameCanvas.currentScreen != GameCanvas.serverScreen)
          GameCanvas.startOK(mResources.lost_connection + LoginScr.serverName, 888395, (object) null);
        else
          GameCanvas.endDlg();
        Char.isLoadingMap = false;
        if (Controller.isMain)
          ServerListScreen.testConnect = 0;
        mSystem.endKey();
      }
    }
  }

  public static bool isWaiting() => InfoDlg.isShow || GameCanvas.msgdlg != null && GameCanvas.msgdlg.info.Equals((object) mResources.PLEASEWAIT) || Char.isLoadingMap || LoginScr.isContinueToLogin;

  public static void connect()
  {
    if (Session_ME.gI().isConnected())
      return;
    GameMidlet.IP = "127.0.0.1";
    GameMidlet.PORT = 14445;
    Session_ME.gI().connect(GameMidlet.IP, GameMidlet.PORT);
  }

  public static void connect2()
  {
    if (Session_ME2.gI().isConnected())
      return;
    Res.outz("IP2= " + GameMidlet.IP2 + " PORT 2= " + (object) GameMidlet.PORT2);
    Session_ME2.gI().connect(GameMidlet.IP2, GameMidlet.PORT2);
  }

  public static void resetTrans(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
  }

  public void initGameCanvas()
  {
    GameCanvas.debug("SP2i1", 0);
    GameCanvas.w = MotherCanvas.instance.getWidthz();
    GameCanvas.h = MotherCanvas.instance.getHeightz();
    GameCanvas.debug("SP2i2", 0);
    GameCanvas.hw = GameCanvas.w / 2;
    GameCanvas.hh = GameCanvas.h / 2;
    GameCanvas.wd3 = GameCanvas.w / 3;
    GameCanvas.hd3 = GameCanvas.h / 3;
    GameCanvas.w2d3 = 2 * GameCanvas.w / 3;
    GameCanvas.h2d3 = 2 * GameCanvas.h / 3;
    GameCanvas.w3d4 = 3 * GameCanvas.w / 4;
    GameCanvas.h3d4 = 3 * GameCanvas.h / 4;
    GameCanvas.wd6 = GameCanvas.w / 6;
    GameCanvas.hd6 = GameCanvas.h / 6;
    GameCanvas.debug("SP2i3", 0);
    mScreen.initPos();
    GameCanvas.debug("SP2i4", 0);
    GameCanvas.debug("SP2i5", 0);
    GameCanvas.inputDlg = new InputDlg();
    GameCanvas.debug("SP2i6", 0);
    GameCanvas.listPoint = new MyVector();
    GameCanvas.debug("SP2i7", 0);
  }

  public void start()
  {
  }

  public int getWidth() => (int) ScaleGUI.WIDTH;

  public int getHeight() => (int) ScaleGUI.HEIGHT;

  public static void debug(string s, int type)
  {
  }

  public void doResetToLoginScr(mScreen screen)
  {
    try
    {
      SoundMn.gI().stopAll();
      LoginScr.isContinueToLogin = false;
      TileMap.lastType = TileMap.bgType = 0;
      Char.clearMyChar();
      GameScr.clearGameScr();
      GameScr.resetAllvector();
      InfoDlg.hide();
      GameScr.info1.hide();
      GameScr.info2.hide();
      GameScr.info2.cmdChat = (Command) null;
      Hint.isShow = false;
      ChatPopup.currChatPopup = (ChatPopup) null;
      Controller.isStopReadMessage = false;
      GameScr.loadCamera(true, -1, -1);
      GameScr.cmx = 100;
      GameCanvas.panel.currentTabIndex = 0;
      GameCanvas.panel.selected = !GameCanvas.isTouch ? 0 : -1;
      GameCanvas.panel.init();
      GameCanvas.panel2 = (Panel) null;
      GameScr.isPaint = true;
      ClanMessage.vMessage.removeAllElements();
      GameScr.textTime.removeAllElements();
      GameScr.vClan.removeAllElements();
      GameScr.vFriend.removeAllElements();
      GameScr.vEnemies.removeAllElements();
      TileMap.vCurrItem.removeAllElements();
      BackgroudEffect.vBgEffect.removeAllElements();
      EffecMn.vEff.removeAllElements();
      Effect.newEff.removeAllElements();
      GameCanvas.menu.showMenu = false;
      GameCanvas.panel.vItemCombine.removeAllElements();
      GameCanvas.panel.isShow = false;
      if (GameCanvas.panel.tabIcon != null)
        GameCanvas.panel.tabIcon.isShow = false;
      if (mGraphics.zoomLevel == 1)
        SmallImage.clearHastable();
      Session_ME.gI().close();
      Session_ME2.gI().close();
      screen.switchToMe();
    }
    catch (Exception ex)
    {
      Cout.println("Loi tai doResetToLoginScr " + ex.ToString());
    }
  }

  public static void showErrorForm(int type, string moreInfo)
  {
  }

  public static void paintCloud(mGraphics g)
  {
  }

  public static void updateBG()
  {
  }

  public static void fillRect(mGraphics g, int color, int x, int y, int w, int h, int detalY)
  {
    g.setColor(color);
    int num = GameScr.cmy;
    if (num > GameCanvas.h)
      num = GameCanvas.h;
    g.fillRect(x, y - (detalY == 0 ? 0 : num >> detalY), w, h + (detalY == 0 ? 0 : num >> detalY));
  }

  public static void paintBackgroundtLayer(
    mGraphics g,
    int layer,
    int deltaY,
    int color1,
    int color2)
  {
    try
    {
      int layer1 = layer - 1;
      if (layer1 == GameCanvas.imgBG.Length - 1 && (GameScr.gI().isRongThanXuatHien || GameScr.gI().isFireWorks))
      {
        g.setColor(GameScr.gI().mautroi);
        g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
        if (GameCanvas.typeBg == 2 || GameCanvas.typeBg == 4 || GameCanvas.typeBg == 7)
        {
          GameCanvas.drawSun1(g);
          GameCanvas.drawSun2(g);
        }
        if (!GameScr.gI().isFireWorks || GameCanvas.lowGraphic)
          return;
        FireWorkEff.paint(g);
      }
      else
      {
        if (GameCanvas.imgBG == null || GameCanvas.imgBG[layer1] == null)
          return;
        if (GameCanvas.moveX[layer1] != 0)
          GameCanvas.moveX[layer1] += GameCanvas.moveXSpeed[layer1];
        int num = GameScr.cmy;
        if (num > GameCanvas.h)
          num = GameCanvas.h;
        if (GameCanvas.layerSpeed[layer1] != 0)
        {
          for (int x = -((GameScr.cmx + GameCanvas.moveX[layer1] >> GameCanvas.layerSpeed[layer1]) % GameCanvas.bgW[layer1]); x < GameScr.gW; x += GameCanvas.bgW[layer1])
            g.drawImage(GameCanvas.imgBG[layer1], x, GameCanvas.yb[layer1] - (deltaY <= 0 ? 0 : num >> deltaY), 0);
        }
        else
        {
          for (int x = 0; x < GameScr.gW; x += GameCanvas.bgW[layer1])
            g.drawImage(GameCanvas.imgBG[layer1], x, GameCanvas.yb[layer1] - (deltaY <= 0 ? 0 : num >> deltaY), 0);
        }
        if (color1 != -1)
        {
          if (layer1 == GameCanvas.nBg - 1)
            GameCanvas.fillRect(g, color1, 0, -(num >> deltaY), GameScr.gW, GameCanvas.yb[layer1], deltaY);
          else
            GameCanvas.fillRect(g, color1, 0, GameCanvas.yb[layer1 - 1] + GameCanvas.bgH[layer1 - 1], GameScr.gW, GameCanvas.yb[layer1] - (GameCanvas.yb[layer1 - 1] + GameCanvas.bgH[layer1 - 1]), deltaY);
        }
        if (color2 != -1)
        {
          if (layer1 == 0)
            GameCanvas.fillRect(g, color2, 0, GameCanvas.yb[layer1] + GameCanvas.bgH[layer1], GameScr.gW, GameScr.gH - (GameCanvas.yb[layer1] + GameCanvas.bgH[layer1]), deltaY);
          else
            GameCanvas.fillRect(g, color2, 0, GameCanvas.yb[layer1] + GameCanvas.bgH[layer1], GameScr.gW, GameCanvas.yb[layer1 - 1] - (GameCanvas.yb[layer1] + GameCanvas.bgH[layer1]) + 80, deltaY);
        }
        if (GameCanvas.currentScreen == GameScr.instance)
        {
          if (layer == 1 && GameCanvas.typeBg == 11)
            g.drawImage(GameCanvas.imgSun2, -(GameScr.cmx >> GameCanvas.layerSpeed[0]) + 400, GameCanvas.yb[0] + 30 - (num >> 2), StaticObj.BOTTOM_HCENTER);
          if (layer == 1 && GameCanvas.typeBg == 13)
          {
            g.drawImage(GameCanvas.imgBG[1], -(GameScr.cmx >> GameCanvas.layerSpeed[0]) + 200, GameCanvas.yb[0] - (num >> 3) + 30, 0);
            g.drawRegion(GameCanvas.imgBG[1], 0, 0, GameCanvas.bgW[1], GameCanvas.bgH[1], 2, -(GameScr.cmx >> GameCanvas.layerSpeed[0]) + 200 + GameCanvas.bgW[1], GameCanvas.yb[0] - (num >> 3) + 30, 0);
          }
          if (layer == 3 && TileMap.mapID == 1)
          {
            for (int index = 0; index < TileMap.pxh / mGraphics.getImageHeight(GameCanvas.imgCaycot); ++index)
              g.drawImage(GameCanvas.imgCaycot, -(GameScr.cmx >> GameCanvas.layerSpeed[2]) + 300, index * mGraphics.getImageHeight(GameCanvas.imgCaycot) - (num >> 3), 0);
          }
        }
        int x1 = -(GameScr.cmx + GameCanvas.moveX[layer1] >> GameCanvas.layerSpeed[layer1]);
        EffecMn.paintBackGroundUnderLayer(g, x1, GameCanvas.yb[layer1] + GameCanvas.bgH[layer1] - (num >> deltaY), layer1);
      }
    }
    catch (Exception ex)
    {
      Cout.LogError("Loi ham paint bground: " + ex.ToString());
    }
  }

  public static void drawSun1(mGraphics g)
  {
    if (GameCanvas.imgSun != null)
      g.drawImage(GameCanvas.imgSun, GameCanvas.sunX, GameCanvas.sunY, 0);
    if (!GameCanvas.isBoltEff)
      return;
    if (GameCanvas.gameTick % 200 == 0)
      GameCanvas.boltActive = true;
    if (!GameCanvas.boltActive)
      return;
    ++GameCanvas.tBolt;
    if (GameCanvas.tBolt == 10)
    {
      GameCanvas.tBolt = 0;
      GameCanvas.boltActive = false;
    }
    if (GameCanvas.tBolt % 2 != 0)
      return;
    g.setColor(16777215);
    g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
  }

  public static void drawSun2(mGraphics g)
  {
    if (GameCanvas.imgSun2 == null)
      return;
    g.drawImage(GameCanvas.imgSun2, GameCanvas.sunX2, GameCanvas.sunY2, 0);
  }

  public static bool isHDVersion() => mGraphics.zoomLevel > 1;

  public static void paintBGGameScr(mGraphics g)
  {
    if (!GameCanvas.isLoadBGok)
    {
      g.setColor(0);
      g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
    }
    if (Char.isLoadingMap)
      return;
    int gW = GameScr.gW;
    int gH = GameScr.gH;
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    try
    {
      if (GameCanvas.paintBG)
      {
        if (GameCanvas.currentScreen == GameScr.gI())
        {
          if (TileMap.mapID == 137 || TileMap.mapID == 115 || TileMap.mapID == 117 || TileMap.mapID == 118 || TileMap.mapID == 120 || TileMap.isMapDouble)
          {
            g.setColor(0);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
            return;
          }
          if (TileMap.mapID == 138)
          {
            g.setColor(6776679);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
            return;
          }
        }
        switch (GameCanvas.typeBg)
        {
          case 0:
            GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
            GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            break;
          case 1:
            GameCanvas.paintBackgroundtLayer(g, 4, 6, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 3, 3, -1, -1);
            GameCanvas.fillRect(g, GameCanvas.colorTop[2], 0, -(GameScr.cmy >> 5), gW, GameCanvas.yb[2], 5);
            GameCanvas.fillRect(g, GameCanvas.colorBotton[2], 0, GameCanvas.yb[2] + GameCanvas.bgH[2] - (GameScr.cmy >> 3), gW, 70, 3);
            GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
            break;
          case 2:
            GameCanvas.paintBackgroundtLayer(g, 5, 10, GameCanvas.colorTop[4], GameCanvas.colorBotton[4]);
            GameCanvas.paintBackgroundtLayer(g, 4, 8, -1, GameCanvas.colorTop[2]);
            GameCanvas.paintBackgroundtLayer(g, 3, 5, -1, GameCanvas.colorBotton[2]);
            GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
            GameCanvas.paintCloud(g);
            break;
          case 3:
            int num1 = GameScr.cmy - (325 - GameScr.gH23);
            g.translate(0, -num1);
            GameCanvas.fillRect(g, GameScr.gI().isRongThanXuatHien || GameScr.gI().isFireWorks ? GameScr.gI().mautroi : GameCanvas.colorTop[2], 0, num1 - (GameScr.cmy >> 3), gW, GameCanvas.yb[2] - num1 + (GameScr.cmy >> 3) + 100, 2);
            GameCanvas.paintBackgroundtLayer(g, 3, 2, -1, GameCanvas.colorBotton[2]);
            GameCanvas.paintBackgroundtLayer(g, 2, 0, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 1, 0, -1, GameCanvas.colorBotton[0]);
            g.translate(0, -g.getTranslateY());
            break;
          case 4:
            GameCanvas.paintBackgroundtLayer(g, 4, 7, GameCanvas.colorTop[3], -1);
            GameCanvas.paintBackgroundtLayer(g, 3, 3, -1, !GameCanvas.isHDVersion() ? GameCanvas.colorTop[1] : GameCanvas.colorBotton[2]);
            GameCanvas.paintBackgroundtLayer(g, 2, 2, GameCanvas.colorTop[1], GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
            break;
          case 5:
            GameCanvas.paintBackgroundtLayer(g, 4, 15, GameCanvas.colorTop[3], -1);
            GameCanvas.drawSun1(g);
            g.translate(100, 10);
            GameCanvas.drawSun1(g);
            g.translate(-100, -10);
            GameCanvas.drawSun2(g);
            GameCanvas.paintBackgroundtLayer(g, 3, 10, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 2, 6, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 1, 4, -1, -1);
            g.translate(0, 27);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, -1);
            g.translate(0, 20);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            g.translate(-g.getTranslateX(), -g.getTranslateY());
            break;
          case 6:
            GameCanvas.paintBackgroundtLayer(g, 5, 10, GameCanvas.colorTop[4], GameCanvas.colorBotton[4]);
            GameCanvas.drawSun1(g);
            GameCanvas.drawSun2(g);
            g.translate(60, 40);
            GameCanvas.drawSun2(g);
            g.translate(-60, -40);
            GameCanvas.paintBackgroundtLayer(g, 4, 7, -1, GameCanvas.colorBotton[3]);
            BackgroudEffect.paintFarAll(g);
            GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            break;
          case 7:
            GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
            GameCanvas.paintBackgroundtLayer(g, 3, 5, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 2, 4, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 1, 3, -1, GameCanvas.colorBotton[0]);
            break;
          case 8:
            GameCanvas.paintBackgroundtLayer(g, 4, 8, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
            GameCanvas.drawSun1(g);
            GameCanvas.drawSun2(g);
            GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
            GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, GameCanvas.colorBotton[1]);
            if ((TileMap.mapID >= 92 && TileMap.mapID <= 96 || TileMap.mapID == 51 || TileMap.mapID == 52) && GameCanvas.currentScreen != GameCanvas.loginScr)
              break;
            GameCanvas.paintBackgroundtLayer(g, 1, 1, -1, GameCanvas.colorBotton[0]);
            break;
          case 9:
            GameCanvas.paintBackgroundtLayer(g, 4, 8, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
            GameCanvas.drawSun1(g);
            GameCanvas.drawSun2(g);
            g.translate(-80, 20);
            GameCanvas.drawSun2(g);
            g.translate(80, -20);
            BackgroudEffect.paintFarAll(g);
            GameCanvas.paintBackgroundtLayer(g, 3, 5, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, -1);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            break;
          case 10:
            int num2 = GameScr.cmy - (380 - GameScr.gH23);
            g.translate(0, -num2);
            GameCanvas.fillRect(g, !GameScr.gI().isRongThanXuatHien ? GameCanvas.colorTop[1] : GameScr.gI().mautroi, 0, num2 - (GameScr.cmy >> 2), gW, GameCanvas.yb[1] - num2 + (GameScr.cmy >> 2) + 100, 2);
            GameCanvas.paintBackgroundtLayer(g, 2, 2, -1, GameCanvas.colorBotton[1]);
            GameCanvas.drawSun1(g);
            GameCanvas.drawSun2(g);
            GameCanvas.paintBackgroundtLayer(g, 1, 0, -1, -1);
            g.translate(0, -g.getTranslateY());
            break;
          case 11:
            GameCanvas.paintBackgroundtLayer(g, 3, 6, GameCanvas.colorTop[2], GameCanvas.colorBotton[2]);
            GameCanvas.drawSun1(g);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            break;
          case 12:
            g.setColor(9161471);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
            GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, 14417919);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, 14417919);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, 14417919);
            GameCanvas.paintCloud(g);
            break;
          case 13:
            g.setColor(15268088);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
            GameCanvas.paintBackgroundtLayer(g, 1, 5, -1, 15268088);
            break;
          case 15:
            g.setColor(2631752);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            break;
          case 16:
            GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
            for (int index = 0; index < GameCanvas.imgSunSpec.Length; ++index)
              g.drawImage(GameCanvas.imgSunSpec[index], GameCanvas.cloudX[index], GameCanvas.cloudY[index], 33);
            GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            break;
          default:
            GameCanvas.fillRect(g, GameCanvas.colorBotton[3], 0, GameCanvas.yb[3] + GameCanvas.bgH[3], GameScr.gW, GameCanvas.yb[2] + GameCanvas.bgH[2], 6);
            GameCanvas.paintBackgroundtLayer(g, 4, 6, GameCanvas.colorTop[3], GameCanvas.colorBotton[3]);
            GameCanvas.drawSun1(g);
            GameCanvas.paintBackgroundtLayer(g, 3, 4, -1, GameCanvas.colorBotton[2]);
            GameCanvas.paintBackgroundtLayer(g, 2, 3, -1, GameCanvas.colorBotton[1]);
            GameCanvas.paintBackgroundtLayer(g, 1, 2, -1, GameCanvas.colorBotton[0]);
            break;
        }
      }
      else
      {
        g.setColor(2315859);
        g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
        if (GameCanvas.tam != null)
        {
          for (int x = -((GameScr.cmx >> 2) % mGraphics.getImageWidth(GameCanvas.tam)); x < GameScr.gW; x += mGraphics.getImageWidth(GameCanvas.tam))
            g.drawImage(GameCanvas.tam, x, (GameScr.cmy >> 3) + GameCanvas.h / 2 - 50, 0);
        }
        g.setColor(5084791);
        g.fillRect(0, (GameScr.cmy >> 3) + GameCanvas.h / 2 - 50 + mGraphics.getImageHeight(GameCanvas.tam), gW, GameCanvas.h);
      }
    }
    catch (Exception ex)
    {
      g.setColor(0);
      g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
    }
  }

  public static void resetBg()
  {
  }

  public static void getYBackground(int typeBg)
  {
    try
    {
      int gH23 = GameScr.gH23;
      switch (typeBg)
      {
        case 0:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 70;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 20;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 30;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 50;
          break;
        case 1:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 120;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 40;
          GameCanvas.yb[2] = GameCanvas.yb[1] - 90;
          GameCanvas.yb[3] = GameCanvas.yb[2] - 25;
          break;
        case 2:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 150;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 60;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 40;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] - 10;
          GameCanvas.yb[4] = GameCanvas.yb[3] - GameCanvas.bgH[4];
          break;
        case 3:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 10;
          GameCanvas.yb[1] = GameCanvas.yb[0] + 80;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 10;
          break;
        case 4:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 130;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1];
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 20;
          GameCanvas.yb[3] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 80;
          break;
        case 5:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 40;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 10;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 15;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 50;
          break;
        case 6:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 100;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 30;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 10;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 15;
          GameCanvas.yb[4] = GameCanvas.yb[3] - GameCanvas.bgH[4] + 15;
          break;
        case 7:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 20;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 15;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 20;
          GameCanvas.yb[3] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 10;
          break;
        case 8:
          GameCanvas.yb[0] = gH23 - 103 + 150;
          if (TileMap.mapID == 103)
            GameCanvas.yb[0] -= 100;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 10;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 40;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 10;
          break;
        case 9:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 100;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 22;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 50;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3];
          break;
        case 10:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] - 45;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] - 10;
          break;
        case 11:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 60;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 5;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] - 15;
          break;
        case 12:
          GameCanvas.yb[0] = gH23 + 40;
          GameCanvas.yb[1] = GameCanvas.yb[0] - 40;
          GameCanvas.yb[2] = GameCanvas.yb[1] - 40;
          break;
        case 13:
          GameCanvas.yb[0] = gH23 - 80;
          GameCanvas.yb[1] = GameCanvas.yb[0];
          break;
        case 15:
          GameCanvas.yb[0] = gH23 - 20;
          GameCanvas.yb[1] = GameCanvas.yb[0] - 80;
          break;
        case 16:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 75;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 50;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 50;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 90;
          break;
        default:
          GameCanvas.yb[0] = gH23 - GameCanvas.bgH[0] + 75;
          GameCanvas.yb[1] = GameCanvas.yb[0] - GameCanvas.bgH[1] + 50;
          GameCanvas.yb[2] = GameCanvas.yb[1] - GameCanvas.bgH[2] + 50;
          GameCanvas.yb[3] = GameCanvas.yb[2] - GameCanvas.bgH[3] + 90;
          break;
      }
    }
    catch (Exception ex)
    {
      int gH23 = GameScr.gH23;
      for (int index = 0; index < GameCanvas.yb.Length; ++index)
        GameCanvas.yb[index] = 1;
    }
  }

  public static void loadBG(int typeBG)
  {
    try
    {
      GameCanvas.isLoadBGok = true;
      BackgroudEffect.yfog = GameCanvas.typeBg != 12 ? TileMap.pxh - 160 : TileMap.pxh - 100;
      BackgroudEffect.clearImage();
      GameCanvas.randomRaintEff(typeBG);
      if (TileMap.lastBgID == typeBG && TileMap.lastType == TileMap.bgType || typeBG == -1)
        return;
      GameCanvas.transY = 12;
      TileMap.lastBgID = (int) (sbyte) typeBG;
      TileMap.lastType = (int) (sbyte) TileMap.bgType;
      GameCanvas.layerSpeed = new int[5]{ 1, 2, 3, 7, 8 };
      GameCanvas.moveX = new int[5];
      GameCanvas.moveXSpeed = new int[5];
      GameCanvas.typeBg = typeBG;
      GameCanvas.isBoltEff = false;
      GameScr.firstY = GameScr.cmy;
      GameCanvas.imgBG = (Image[]) null;
      GameCanvas.imgCloud = (Image) null;
      GameCanvas.imgSun = (Image) null;
      GameCanvas.imgCaycot = (Image) null;
      GameScr.firstY = -1;
      switch (GameCanvas.typeBg)
      {
        case 0:
          GameCanvas.imgCaycot = GameCanvas.loadImageRMS("/bg/caycot.png");
          GameCanvas.layerSpeed = new int[4]{ 1, 3, 5, 7 };
          GameCanvas.nBg = 4;
          if (TileMap.bgType == 2)
          {
            GameCanvas.transY = 8;
            break;
          }
          break;
        case 1:
          GameCanvas.transY = 7;
          GameCanvas.nBg = 4;
          break;
        case 2:
          GameCanvas.moveX = new int[5]{ 0, 0, 1, 0, 0 };
          GameCanvas.moveXSpeed = new int[5]
          {
            0,
            0,
            2,
            0,
            0
          };
          GameCanvas.nBg = 5;
          break;
        case 3:
          GameCanvas.nBg = 3;
          break;
        case 4:
          BackgroudEffect.addEffect(3);
          GameCanvas.moveX = new int[5]{ 0, 1, 0, 0, 0 };
          GameCanvas.moveXSpeed = new int[5]
          {
            0,
            1,
            0,
            0,
            0
          };
          GameCanvas.nBg = 4;
          break;
        case 5:
          GameCanvas.nBg = 4;
          break;
        case 6:
          GameCanvas.moveX = new int[5]{ 1, 0, 0, 0, 0 };
          GameCanvas.moveXSpeed = new int[5]
          {
            2,
            0,
            0,
            0,
            0
          };
          GameCanvas.nBg = 5;
          break;
        case 7:
          GameCanvas.nBg = 4;
          break;
        case 8:
          GameCanvas.transY = 8;
          GameCanvas.nBg = 4;
          break;
        case 9:
          BackgroudEffect.addEffect(9);
          GameCanvas.nBg = 4;
          break;
        case 10:
          GameCanvas.nBg = 2;
          break;
        case 11:
          GameCanvas.transY = 7;
          GameCanvas.layerSpeed[2] = 0;
          GameCanvas.nBg = 3;
          break;
        case 12:
          GameCanvas.moveX = new int[5]{ 1, 1, 0, 0, 0 };
          GameCanvas.moveXSpeed = new int[5]
          {
            2,
            1,
            0,
            0,
            0
          };
          GameCanvas.nBg = 3;
          break;
        case 13:
          GameCanvas.nBg = 2;
          break;
        case 15:
          Res.outz("HELL");
          GameCanvas.nBg = 2;
          break;
        case 16:
          GameCanvas.layerSpeed = new int[4]{ 1, 3, 5, 7 };
          GameCanvas.nBg = 4;
          break;
        default:
          GameCanvas.layerSpeed = new int[4]{ 1, 3, 5, 7 };
          GameCanvas.nBg = 4;
          break;
      }
      if (typeBG <= 16)
      {
        GameCanvas.skyColor = StaticObj.SKYCOLOR[GameCanvas.typeBg];
      }
      else
      {
        try
        {
          string path = "/bg/b" + (object) GameCanvas.typeBg + (object) 3 + ".png";
          if (TileMap.bgType != 0)
            path = "/bg/b" + (object) GameCanvas.typeBg + (object) 3 + "-" + (object) TileMap.bgType + ".png";
          int[] data = new int[1];
          Image img = GameCanvas.loadImageRMS(path);
          img.getRGB(ref data, 0, 1, mGraphics.getRealImageWidth(img) / 2, 0, 1, 1);
          GameCanvas.skyColor = data[0];
        }
        catch (Exception ex)
        {
          GameCanvas.skyColor = StaticObj.SKYCOLOR[StaticObj.SKYCOLOR.Length - 1];
        }
      }
      GameCanvas.colorTop = new int[StaticObj.SKYCOLOR.Length];
      GameCanvas.colorBotton = new int[StaticObj.SKYCOLOR.Length];
      for (int index = 0; index < StaticObj.SKYCOLOR.Length; ++index)
      {
        GameCanvas.colorTop[index] = StaticObj.SKYCOLOR[index];
        GameCanvas.colorBotton[index] = StaticObj.SKYCOLOR[index];
      }
      if (GameCanvas.lowGraphic)
      {
        GameCanvas.tam = GameCanvas.loadImageRMS("/bg/b63.png");
      }
      else
      {
        GameCanvas.imgBG = new Image[GameCanvas.nBg];
        GameCanvas.bgW = new int[GameCanvas.nBg];
        GameCanvas.bgH = new int[GameCanvas.nBg];
        GameCanvas.colorBotton = new int[GameCanvas.nBg];
        GameCanvas.colorTop = new int[GameCanvas.nBg];
        if (TileMap.bgType == 100)
        {
          GameCanvas.imgBG[0] = GameCanvas.loadImageRMS("/bg/b100.png");
          GameCanvas.imgBG[1] = GameCanvas.loadImageRMS("/bg/b100.png");
          GameCanvas.imgBG[2] = GameCanvas.loadImageRMS("/bg/b82-1.png");
          GameCanvas.imgBG[3] = GameCanvas.loadImageRMS("/bg/b93.png");
          for (int index = 0; index < GameCanvas.nBg; ++index)
          {
            if (GameCanvas.imgBG[index] != null)
            {
              int[] data1 = new int[1];
              GameCanvas.imgBG[index].getRGB(ref data1, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[index]) / 2, 0, 1, 1);
              GameCanvas.colorTop[index] = data1[0];
              int[] data2 = new int[1];
              GameCanvas.imgBG[index].getRGB(ref data2, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[index]) / 2, mGraphics.getRealImageHeight(GameCanvas.imgBG[index]) - 1, 1, 1);
              GameCanvas.colorBotton[index] = data2[0];
              GameCanvas.bgW[index] = mGraphics.getImageWidth(GameCanvas.imgBG[index]);
              GameCanvas.bgH[index] = mGraphics.getImageHeight(GameCanvas.imgBG[index]);
            }
            else if (GameCanvas.nBg > 1)
            {
              GameCanvas.imgBG[index] = GameCanvas.loadImageRMS("/bg/b" + (object) GameCanvas.typeBg + "0.png");
              GameCanvas.bgW[index] = mGraphics.getImageWidth(GameCanvas.imgBG[index]);
              GameCanvas.bgH[index] = mGraphics.getImageHeight(GameCanvas.imgBG[index]);
            }
          }
        }
        else
        {
          for (int index = 0; index < GameCanvas.nBg; ++index)
          {
            string path = "/bg/b" + (object) GameCanvas.typeBg + (object) index + ".png";
            if (TileMap.bgType != 0)
              path = "/bg/b" + (object) GameCanvas.typeBg + (object) index + "-" + (object) TileMap.bgType + ".png";
            GameCanvas.imgBG[index] = GameCanvas.loadImageRMS(path);
            if (GameCanvas.imgBG[index] != null)
            {
              int[] data3 = new int[1];
              GameCanvas.imgBG[index].getRGB(ref data3, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[index]) / 2, 0, 1, 1);
              GameCanvas.colorTop[index] = data3[0];
              int[] data4 = new int[1];
              GameCanvas.imgBG[index].getRGB(ref data4, 0, 1, mGraphics.getRealImageWidth(GameCanvas.imgBG[index]) / 2, mGraphics.getRealImageHeight(GameCanvas.imgBG[index]) - 1, 1, 1);
              GameCanvas.colorBotton[index] = data4[0];
              GameCanvas.bgW[index] = mGraphics.getImageWidth(GameCanvas.imgBG[index]);
              GameCanvas.bgH[index] = mGraphics.getImageHeight(GameCanvas.imgBG[index]);
            }
            else if (GameCanvas.nBg > 1)
            {
              GameCanvas.imgBG[index] = GameCanvas.loadImageRMS("/bg/b" + (object) GameCanvas.typeBg + "0.png");
              GameCanvas.bgW[index] = mGraphics.getImageWidth(GameCanvas.imgBG[index]);
              GameCanvas.bgH[index] = mGraphics.getImageHeight(GameCanvas.imgBG[index]);
            }
          }
        }
        GameCanvas.getYBackground(GameCanvas.typeBg);
        GameCanvas.cloudX = new int[5]
        {
          GameScr.gW / 2 - 40,
          GameScr.gW / 2 + 40,
          GameScr.gW / 2 - 100,
          GameScr.gW / 2 - 80,
          GameScr.gW / 2 - 120
        };
        GameCanvas.cloudY = new int[5]
        {
          130,
          100,
          150,
          140,
          80
        };
        GameCanvas.imgSunSpec = (Image[]) null;
        switch (GameCanvas.typeBg)
        {
          case 0:
label_70:
            GameCanvas.paintBG = false;
            if (GameCanvas.paintBG)
              break;
            GameCanvas.paintBG = true;
            break;
          case 2:
            GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun0.png");
            GameCanvas.sunX = GameScr.gW / 2 + 50;
            GameCanvas.sunY = GameCanvas.yb[4] - 40;
            goto case 0;
          case 4:
            GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun2.png");
            GameCanvas.sunX = GameScr.gW / 2 + 30;
            GameCanvas.sunY = GameCanvas.yb[3];
            goto case 0;
          case 6:
            GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun5" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
            GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun6" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
            GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
            GameCanvas.sunY = GameCanvas.yb[4];
            GameCanvas.sunX2 = GameCanvas.sunX - 100;
            GameCanvas.sunY2 = GameCanvas.yb[4] + 20;
            goto case 0;
          case 7:
            GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun3" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
            GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun4" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
            GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
            GameCanvas.sunY = GameCanvas.yb[3] - 80;
            GameCanvas.sunX2 = GameCanvas.sunX - 100;
            GameCanvas.sunY2 = GameCanvas.yb[3] - 30;
            goto case 0;
          default:
            if (typeBG == 5)
            {
              GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun8" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
              GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun7" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
              GameCanvas.sunX = GameScr.gW / 2 - 50;
              GameCanvas.sunY = GameCanvas.yb[3] + 20;
              GameCanvas.sunX2 = GameScr.gW / 2 + 20;
              GameCanvas.sunY2 = GameCanvas.yb[3] - 30;
              goto case 0;
            }
            else if (GameCanvas.typeBg == 8 && TileMap.mapID < 90)
            {
              GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun9" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
              GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun10" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
              GameCanvas.sunX = GameScr.gW / 2 - 30;
              GameCanvas.sunY = GameCanvas.yb[3] + 60;
              GameCanvas.sunX2 = GameScr.gW / 2 + 20;
              GameCanvas.sunY2 = GameCanvas.yb[3] + 10;
              goto case 0;
            }
            else
            {
              switch (typeBG)
              {
                case 9:
                  GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun11" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
                  GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun12" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
                  GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
                  GameCanvas.sunY = GameCanvas.yb[4] + 20;
                  GameCanvas.sunX2 = GameCanvas.sunX - 80;
                  GameCanvas.sunY2 = GameCanvas.yb[4] + 40;
                  goto label_70;
                case 10:
                  GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun13" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
                  GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/sun14" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
                  GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
                  GameCanvas.sunY = GameCanvas.yb[1] - 30;
                  GameCanvas.sunX2 = GameCanvas.sunX - 80;
                  GameCanvas.sunY2 = GameCanvas.yb[1];
                  goto label_70;
                case 11:
                  GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun15" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
                  GameCanvas.imgSun2 = GameCanvas.loadImageRMS("/bg/b113" + (TileMap.bgType != 0 ? "-" + (object) TileMap.bgType : string.Empty) + ".png");
                  GameCanvas.sunX = GameScr.gW / 2 - 30;
                  GameCanvas.sunY = GameCanvas.yb[2] - 30;
                  goto label_70;
                case 12:
                  GameCanvas.cloudY = new int[5]
                  {
                    200,
                    170,
                    220,
                    150,
                    250
                  };
                  goto label_70;
                case 16:
                  GameCanvas.cloudX = new int[7]
                  {
                    90,
                    170,
                    250,
                    320,
                    400,
                    450,
                    500
                  };
                  GameCanvas.cloudY = new int[7]
                  {
                    GameCanvas.yb[2] + 5,
                    GameCanvas.yb[2] - 20,
                    GameCanvas.yb[2] - 50,
                    GameCanvas.yb[2] - 30,
                    GameCanvas.yb[2] - 50,
                    GameCanvas.yb[2],
                    GameCanvas.yb[2] - 40
                  };
                  GameCanvas.imgSunSpec = new Image[7];
                  for (int index = 0; index < GameCanvas.imgSunSpec.Length; ++index)
                  {
                    int num = 161;
                    if (index == 0 || index == 2 || index == 3 || index == 2 || index == 6)
                      num = 160;
                    GameCanvas.imgSunSpec[index] = GameCanvas.loadImageRMS("/bg/sun" + (object) num + ".png");
                  }
                  goto label_70;
                default:
                  GameCanvas.imgCloud = (Image) null;
                  GameCanvas.imgSun = (Image) null;
                  GameCanvas.imgSun2 = (Image) null;
                  GameCanvas.imgSun = GameCanvas.loadImageRMS("/bg/sun" + (object) typeBG + (TileMap.bgType != 0 ? (object) ("-" + (object) TileMap.bgType) : (object) string.Empty) + ".png");
                  GameCanvas.sunX = GameScr.gW - GameScr.gW / 3;
                  GameCanvas.sunY = GameCanvas.yb[2] - 30;
                  goto label_70;
              }
            }
        }
      }
    }
    catch (Exception ex)
    {
      GameCanvas.isLoadBGok = false;
    }
  }

  private static void randomRaintEff(int typeBG)
  {
    for (int index = 0; index < GameCanvas.bgRain.Length; ++index)
    {
      if (typeBG == GameCanvas.bgRain[index] && Res.random(0, 2) == 0)
      {
        BackgroudEffect.addEffect(0);
        break;
      }
    }
  }

  public void keyPressedz(int keyCode)
  {
    GameCanvas.lastTimePress = mSystem.currentTimeMillis();
    if (keyCode >= 48 && keyCode <= 57 || keyCode >= 65 && keyCode <= 122 || keyCode == 10 || keyCode == 8 || keyCode == 13 || keyCode == 32 || keyCode == 31)
      GameCanvas.keyAsciiPress = keyCode;
    this.mapKeyPress(keyCode);
  }

  public void mapKeyPress(int keyCode)
  {
    if (GameCanvas.currentDialog != null)
    {
      GameCanvas.currentDialog.keyPress(keyCode);
      GameCanvas.keyAsciiPress = 0;
    }
    else
    {
      GameCanvas.currentScreen.keyPress(keyCode);
      switch (keyCode)
      {
        case 48:
          GameCanvas.keyHold[0] = true;
          GameCanvas.keyPressed[0] = true;
          break;
        case 49:
          if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
            break;
          GameCanvas.keyHold[1] = true;
          GameCanvas.keyPressed[1] = true;
          break;
        case 50:
          if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
            break;
          GameCanvas.keyHold[2] = true;
          GameCanvas.keyPressed[2] = true;
          break;
        case 51:
          if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
            break;
          GameCanvas.keyHold[3] = true;
          GameCanvas.keyPressed[3] = true;
          break;
        case 52:
          if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
            break;
          GameCanvas.keyHold[4] = true;
          GameCanvas.keyPressed[4] = true;
          break;
        case 53:
          if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
            break;
          GameCanvas.keyHold[5] = true;
          GameCanvas.keyPressed[5] = true;
          break;
        case 54:
          if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
            break;
          GameCanvas.keyHold[6] = true;
          GameCanvas.keyPressed[6] = true;
          break;
        case 55:
          GameCanvas.keyHold[7] = true;
          GameCanvas.keyPressed[7] = true;
          break;
        case 56:
          if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
            break;
          GameCanvas.keyHold[8] = true;
          GameCanvas.keyPressed[8] = true;
          break;
        case 57:
          GameCanvas.keyHold[9] = true;
          GameCanvas.keyPressed[9] = true;
          break;
        default:
          switch (keyCode + 8)
          {
            case 0:
              GameCanvas.keyHold[14] = true;
              GameCanvas.keyPressed[14] = true;
              return;
            case 1:
label_38:
              GameCanvas.keyHold[13] = true;
              GameCanvas.keyPressed[13] = true;
              return;
            case 2:
label_37:
              GameCanvas.keyHold[12] = true;
              GameCanvas.keyPressed[12] = true;
              return;
            case 3:
label_22:
              switch (GameCanvas.currentScreen)
              {
                case GameScr _:
                case CrackBallScr _:
                  if (Char.myCharz().isAttack)
                  {
                    GameCanvas.clearKeyHold();
                    GameCanvas.clearKeyPressed();
                    return;
                  }
                  break;
              }
              GameCanvas.keyHold[25] = true;
              GameCanvas.keyPressed[25] = true;
              GameCanvas.keyHold[15] = true;
              GameCanvas.keyPressed[15] = true;
              return;
            case 4:
              switch (GameCanvas.currentScreen)
              {
                case GameScr _:
                case CrackBallScr _:
                  if (Char.myCharz().isAttack)
                  {
                    GameCanvas.clearKeyHold();
                    GameCanvas.clearKeyPressed();
                    return;
                  }
                  break;
              }
              GameCanvas.keyHold[24] = true;
              GameCanvas.keyPressed[24] = true;
              return;
            case 5:
              switch (GameCanvas.currentScreen)
              {
                case GameScr _:
                case CrackBallScr _:
                  if (Char.myCharz().isAttack)
                  {
                    GameCanvas.clearKeyHold();
                    GameCanvas.clearKeyPressed();
                    return;
                  }
                  break;
              }
              GameCanvas.keyHold[23] = true;
              GameCanvas.keyPressed[23] = true;
              return;
            case 6:
label_10:
              switch (GameCanvas.currentScreen)
              {
                case GameScr _:
                case CrackBallScr _:
                  if (Char.myCharz().isAttack)
                  {
                    GameCanvas.clearKeyHold();
                    GameCanvas.clearKeyPressed();
                    return;
                  }
                  break;
              }
              GameCanvas.keyHold[22] = true;
              GameCanvas.keyPressed[22] = true;
              return;
            case 7:
label_6:
              switch (GameCanvas.currentScreen)
              {
                case GameScr _:
                case CrackBallScr _:
                  if (Char.myCharz().isAttack)
                  {
                    GameCanvas.clearKeyHold();
                    GameCanvas.clearKeyPressed();
                    return;
                  }
                  break;
              }
              GameCanvas.keyHold[21] = true;
              GameCanvas.keyPressed[21] = true;
              return;
            default:
              switch (keyCode)
              {
                case -39:
                  goto label_10;
                case -38:
                  goto label_6;
                case -26:
                  GameCanvas.keyHold[16] = true;
                  GameCanvas.keyPressed[16] = true;
                  return;
                case -22:
                  goto label_38;
                case -21:
                  goto label_37;
                case 10:
                  goto label_22;
                case 35:
                  GameCanvas.keyHold[11] = true;
                  GameCanvas.keyPressed[11] = true;
                  return;
                case 42:
                  GameCanvas.keyHold[10] = true;
                  GameCanvas.keyPressed[10] = true;
                  return;
                case 113:
                  GameCanvas.keyHold[17] = true;
                  GameCanvas.keyPressed[17] = true;
                  return;
                default:
                  return;
              }
          }
      }
    }
  }

  public void keyReleasedz(int keyCode)
  {
    GameCanvas.keyAsciiPress = 0;
    this.mapKeyRelease(keyCode);
  }

  public void mapKeyRelease(int keyCode)
  {
    switch (keyCode)
    {
      case 48:
        GameCanvas.keyHold[0] = false;
        GameCanvas.keyReleased[0] = true;
        break;
      case 49:
        if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
          break;
        GameCanvas.keyHold[1] = false;
        GameCanvas.keyReleased[1] = true;
        break;
      case 50:
        if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
          break;
        GameCanvas.keyHold[2] = false;
        GameCanvas.keyReleased[2] = true;
        break;
      case 51:
        if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
          break;
        GameCanvas.keyHold[3] = false;
        GameCanvas.keyReleased[3] = true;
        break;
      case 52:
        if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
          break;
        GameCanvas.keyHold[4] = false;
        GameCanvas.keyReleased[4] = true;
        break;
      case 53:
        if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
          break;
        GameCanvas.keyHold[5] = false;
        GameCanvas.keyReleased[5] = true;
        break;
      case 54:
        if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
          break;
        GameCanvas.keyHold[6] = false;
        GameCanvas.keyReleased[6] = true;
        break;
      case 55:
        GameCanvas.keyHold[7] = false;
        GameCanvas.keyReleased[7] = true;
        break;
      case 56:
        if (GameCanvas.currentScreen != CrackBallScr.instance && (GameCanvas.currentScreen != GameScr.instance || !GameCanvas.isMoveNumberPad || ChatTextField.gI().isShow))
          break;
        GameCanvas.keyHold[8] = false;
        GameCanvas.keyReleased[8] = true;
        break;
      case 57:
        GameCanvas.keyHold[9] = false;
        GameCanvas.keyReleased[9] = true;
        break;
      default:
        switch (keyCode + 8)
        {
          case 0:
            GameCanvas.keyHold[14] = false;
            return;
          case 1:
label_21:
            GameCanvas.keyHold[13] = false;
            GameCanvas.keyReleased[13] = true;
            return;
          case 2:
label_20:
            GameCanvas.keyHold[12] = false;
            GameCanvas.keyReleased[12] = true;
            return;
          case 3:
label_8:
            GameCanvas.keyHold[25] = false;
            GameCanvas.keyReleased[25] = true;
            GameCanvas.keyHold[15] = true;
            GameCanvas.keyPressed[15] = true;
            return;
          case 4:
            GameCanvas.keyHold[24] = false;
            return;
          case 5:
            GameCanvas.keyHold[23] = false;
            return;
          case 6:
label_5:
            GameCanvas.keyHold[22] = false;
            return;
          case 7:
label_4:
            GameCanvas.keyHold[21] = false;
            return;
          default:
            switch (keyCode)
            {
              case -39:
                goto label_5;
              case -38:
                goto label_4;
              case -26:
                GameCanvas.keyHold[16] = false;
                return;
              case -22:
                goto label_21;
              case -21:
                goto label_20;
              case 10:
                goto label_8;
              case 35:
                GameCanvas.keyHold[11] = false;
                GameCanvas.keyReleased[11] = true;
                return;
              case 42:
                GameCanvas.keyHold[10] = false;
                GameCanvas.keyReleased[10] = true;
                return;
              case 113:
                GameCanvas.keyHold[17] = false;
                GameCanvas.keyReleased[17] = true;
                return;
              default:
                return;
            }
        }
    }
  }

  public void pointerMouse(int x, int y)
  {
    GameCanvas.pxMouse = x;
    GameCanvas.pyMouse = y;
  }

  public void scrollMouse(int a)
  {
    GameCanvas.pXYScrollMouse = a;
    if (GameCanvas.panel == null || !GameCanvas.panel.isShow)
      return;
    GameCanvas.panel.updateScroolMouse(a);
  }

  public void pointerDragged(int x, int y)
  {
    if (Res.abs(x - GameCanvas.pxLast) >= 10 || Res.abs(y - GameCanvas.pyLast) >= 10)
    {
      GameCanvas.isPointerClick = false;
      GameCanvas.isPointerDown = true;
      GameCanvas.isPointerMove = true;
    }
    GameCanvas.px = x;
    GameCanvas.py = y;
    ++GameCanvas.curPos;
    if (GameCanvas.curPos > 3)
      GameCanvas.curPos = 0;
    GameCanvas.arrPos[GameCanvas.curPos] = new Position(x, y);
  }

  public static bool isHoldPress() => mSystem.currentTimeMillis() - GameCanvas.lastTimePress >= 800L;

  public void pointerPressed(int x, int y)
  {
    GameCanvas.isPointerJustRelease = false;
    GameCanvas.isPointerJustDown = true;
    GameCanvas.isPointerDown = true;
    GameCanvas.isPointerClick = true;
    GameCanvas.isPointerMove = false;
    GameCanvas.lastTimePress = mSystem.currentTimeMillis();
    GameCanvas.pxFirst = x;
    GameCanvas.pyFirst = y;
    GameCanvas.pxLast = x;
    GameCanvas.pyLast = y;
    GameCanvas.px = x;
    GameCanvas.py = y;
  }

  public void pointerReleased(int x, int y)
  {
    GameCanvas.isPointerDown = false;
    GameCanvas.isPointerJustRelease = true;
    GameCanvas.isPointerMove = false;
    mScreen.keyTouch = -1;
    GameCanvas.px = x;
    GameCanvas.py = y;
  }

  public static bool isPointerHoldIn(int x, int y, int w, int h) => (GameCanvas.isPointerDown || GameCanvas.isPointerJustRelease) && GameCanvas.px >= x && GameCanvas.px <= x + w && GameCanvas.py >= y && GameCanvas.py <= y + h;

  public static bool isMouseFocus(int x, int y, int w, int h) => GameCanvas.pxMouse >= x && GameCanvas.pxMouse <= x + w && GameCanvas.pyMouse >= y && GameCanvas.pyMouse <= y + h;

  public static void clearKeyPressed()
  {
    for (int index = 0; index < GameCanvas.keyPressed.Length; ++index)
      GameCanvas.keyPressed[index] = false;
    GameCanvas.isPointerJustRelease = false;
  }

  public static void clearKeyHold()
  {
    for (int index = 0; index < GameCanvas.keyHold.Length; ++index)
      GameCanvas.keyHold[index] = false;
  }

  public static void checkBackButton()
  {
    if (ChatPopup.serverChatPopUp != null || ChatPopup.currChatPopup != null)
      return;
    GameCanvas.startYesNoDlg(mResources.DOYOUWANTEXIT, new Command(mResources.YES, (IActionListener) GameCanvas.instance, 8885, (object) null), new Command(mResources.NO, (IActionListener) GameCanvas.instance, 8882, (object) null));
  }

  public void paintChangeMap(mGraphics g)
  {
    GameCanvas.resetTrans(g);
    g.setColor(0);
    g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
    g.drawImage(LoginScr.imgTitle, GameCanvas.w / 2, GameCanvas.h / 2 - 24, StaticObj.BOTTOM_HCENTER);
    GameCanvas.paintShukiren(GameCanvas.hw, GameCanvas.h / 2 + 24, g);
    mFont.tahoma_7b_white.drawString(g, mResources.PLEASEWAIT + (LoginScr.timeLogin <= (short) 0 ? string.Empty : " " + (object) LoginScr.timeLogin + "s"), GameCanvas.w / 2, GameCanvas.h / 2, 2);
  }

  public void paint(mGraphics gx)
  {
    try
    {
      GameCanvas.debugPaint.removeAllElements();
      GameCanvas.debug("PA", 1);
      if (GameCanvas.currentScreen != null)
        GameCanvas.currentScreen.paint(this.g);
      GameCanvas.debug("PB", 1);
      this.g.translate(-this.g.getTranslateX(), -this.g.getTranslateY());
      this.g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
      if (GameCanvas.panel.isShow)
      {
        GameCanvas.panel.paint(this.g);
        if (GameCanvas.panel2 != null && GameCanvas.panel2.isShow)
          GameCanvas.panel2.paint(this.g);
        if (GameCanvas.panel.chatTField != null && GameCanvas.panel.chatTField.isShow)
          GameCanvas.panel.chatTField.paint(this.g);
        if (GameCanvas.panel2 != null && GameCanvas.panel2.chatTField != null && GameCanvas.panel2.chatTField.isShow)
          GameCanvas.panel2.chatTField.paint(this.g);
      }
      Res.paintOnScreenDebug(this.g);
      InfoDlg.paint(this.g);
      if (GameCanvas.currentDialog != null)
      {
        GameCanvas.debug("PC", 1);
        GameCanvas.currentDialog.paint(this.g);
      }
      else if (GameCanvas.menu.showMenu)
      {
        GameCanvas.debug("PD", 1);
        GameCanvas.menu.paintMenu(this.g);
      }
      GameScr.info1.paint(this.g);
      GameScr.info2.paint(this.g);
      if (GameScr.gI().popUpYesNo != null)
        GameScr.gI().popUpYesNo.paint(this.g);
      if (ChatPopup.currChatPopup != null)
        ChatPopup.currChatPopup.paint(this.g);
      Hint.paint(this.g);
      if (ChatPopup.serverChatPopUp != null)
        ChatPopup.serverChatPopUp.paint(this.g);
      for (int index = 0; index < Effect2.vEffect2.size(); ++index)
      {
        Effect2 effect2 = (Effect2) Effect2.vEffect2.elementAt(index);
        if (effect2 is ChatPopup && !effect2.Equals((object) ChatPopup.currChatPopup) && !effect2.Equals((object) ChatPopup.serverChatPopUp))
          effect2.paint(this.g);
      }
      if (Char.isLoadingMap || LoginScr.isContinueToLogin || ServerListScreen.waitToLogin || ServerListScreen.isWait)
        this.paintChangeMap(this.g);
      GameCanvas.debug("PE", 1);
      GameCanvas.resetTrans(this.g);
      EffecMn.paintLayer4(this.g);
      if (mResources.language != (sbyte) 0 || !GameCanvas.open3Hour || GameCanvas.isLoading)
        return;
      if (GameCanvas.currentScreen == GameCanvas.loginScr || GameCanvas.currentScreen == GameCanvas.serverScreen || GameCanvas.currentScreen == GameCanvas.serverScr)
        this.g.drawImage(GameCanvas.img12, 5, 5, 0);
      if (GameCanvas.currentScreen != CreateCharScr.instance)
        return;
      this.g.drawImage(GameCanvas.img12, 5, 20, 0);
    }
    catch (Exception ex)
    {
    }
  }

  public static void endDlg()
  {
    if (GameCanvas.inputDlg != null)
      GameCanvas.inputDlg.tfInput.setMaxTextLenght(500);
    GameCanvas.currentDialog = (Dialog) null;
    InfoDlg.hide();
  }

  public static void startOKDlg(string info)
  {
    GameCanvas.closeKeyBoard();
    GameCanvas.msgdlg.setInfo(info, (Command) null, new Command(mResources.OK, (IActionListener) GameCanvas.instance, 8882, (object) null), (Command) null);
    GameCanvas.currentDialog = (Dialog) GameCanvas.msgdlg;
  }

  public static void startWaitDlg(string info)
  {
    GameCanvas.closeKeyBoard();
    GameCanvas.msgdlg.setInfo(info, (Command) null, new Command(mResources.CANCEL, (IActionListener) GameCanvas.instance, 8882, (object) null), (Command) null);
    GameCanvas.currentDialog = (Dialog) GameCanvas.msgdlg;
    GameCanvas.msgdlg.isWait = true;
  }

  public static void startOKDlg(string info, bool isError)
  {
    GameCanvas.closeKeyBoard();
    GameCanvas.msgdlg.setInfo(info, (Command) null, new Command(mResources.CANCEL, (IActionListener) GameCanvas.instance, 8882, (object) null), (Command) null);
    GameCanvas.currentDialog = (Dialog) GameCanvas.msgdlg;
    GameCanvas.msgdlg.isWait = true;
  }

  public static void startWaitDlg()
  {
    GameCanvas.closeKeyBoard();
    Char.isLoadingMap = true;
  }

  public void openWeb(string strLeft, string strRight, string url, string str)
  {
    GameCanvas.msgdlg.setInfo(str, new Command(strLeft, (IActionListener) this, 8881, (object) url), (Command) null, new Command(strRight, (IActionListener) this, 8882, (object) null));
    GameCanvas.currentDialog = (Dialog) GameCanvas.msgdlg;
  }

  public static void startOK(string info, int actionID, object p)
  {
    GameCanvas.closeKeyBoard();
    GameCanvas.msgdlg.setInfo(info, (Command) null, new Command(mResources.OK, (IActionListener) GameCanvas.instance, actionID, p), (Command) null);
    GameCanvas.msgdlg.show();
  }

  public static void startYesNoDlg(string info, int iYes, object pYes, int iNo, object pNo)
  {
    GameCanvas.closeKeyBoard();
    GameCanvas.msgdlg.setInfo(info, new Command(mResources.YES, (IActionListener) GameCanvas.instance, iYes, pYes), new Command(string.Empty, (IActionListener) GameCanvas.instance, iYes, pYes), new Command(mResources.NO, (IActionListener) GameCanvas.instance, iNo, pNo));
    GameCanvas.msgdlg.show();
  }

  public static void startYesNoDlg(string info, Command cmdYes, Command cmdNo)
  {
    GameCanvas.closeKeyBoard();
    GameCanvas.msgdlg.setInfo(info, cmdYes, (Command) null, cmdNo);
    GameCanvas.msgdlg.show();
  }

  public static string getMoneys(int m)
  {
    string moneys = string.Empty;
    int num1 = m / 1000 + 1;
    for (int index = 0; index < num1; ++index)
    {
      if (m >= 1000)
      {
        int num2 = m % 1000;
        moneys = num2 != 0 ? (num2 >= 10 ? (num2 >= 100 ? "." + (object) num2 + moneys : ".0" + (object) num2 + moneys) : ".00" + (object) num2 + moneys) : ".000" + moneys;
        m /= 1000;
      }
      else
      {
        moneys = m.ToString() + moneys;
        break;
      }
    }
    return moneys;
  }

  public static int getX(int start, int w) => (GameCanvas.px - start) / w;

  public static int getY(int start, int w) => (GameCanvas.py - start) / w;

  protected void sizeChanged(int w, int h)
  {
  }

  public static bool isGetResourceFromServer() => true;

  public static Image loadImageRMS(string path)
  {
    path = Main.res + "/x" + (object) mGraphics.zoomLevel + path;
    path = GameCanvas.cutPng(path);
    Image image = (Image) null;
    try
    {
      image = Image.createImage(path);
    }
    catch (Exception ex1)
    {
      try
      {
        string[] strArray = Res.split(path, "/", 0);
        sbyte[] imageData = Rms.loadRMS("x" + (object) mGraphics.zoomLevel + strArray[strArray.Length - 1]);
        if (imageData != null)
          image = Image.createImage(imageData, 0, imageData.Length);
      }
      catch (Exception ex2)
      {
        Cout.LogError("Loi ham khong tim thay a: " + ex1.ToString());
      }
    }
    return image;
  }

  public static Image loadImage(string path)
  {
    path = Main.res + "/x" + (object) mGraphics.zoomLevel + path;
    path = GameCanvas.cutPng(path);
    Image image = (Image) null;
    try
    {
      image = Image.createImage(path);
    }
    catch (Exception ex)
    {
    }
    return image;
  }

  public static string cutPng(string str)
  {
    string str1 = str;
    if (str.Contains(".png"))
      str1 = str.Replace(".png", string.Empty);
    return str1;
  }

  public static int random(int a, int b) => a + GameCanvas.r.nextInt(b - a);

  public bool startDust(int dir, int x, int y)
  {
    if (GameCanvas.lowGraphic)
      return false;
    int index = dir != 1 ? 1 : 0;
    if (this.dustState[index] != -1)
      return false;
    this.dustState[index] = 0;
    this.dustX[index] = x;
    this.dustY[index] = y;
    return true;
  }

  public void loadWaterSplash()
  {
    if (GameCanvas.lowGraphic)
      return;
    GameCanvas.imgWS = new Image[3];
    for (int index = 0; index < 3; ++index)
      GameCanvas.imgWS[index] = GameCanvas.loadImage("/e/w" + (object) index + ".png");
    GameCanvas.wsX = new int[2];
    GameCanvas.wsY = new int[2];
    GameCanvas.wsState = new int[2];
    GameCanvas.wsF = new int[2];
    GameCanvas.wsState[0] = GameCanvas.wsState[1] = -1;
  }

  public bool startWaterSplash(int x, int y)
  {
    if (GameCanvas.lowGraphic)
      return false;
    int index = GameCanvas.wsState[0] != -1 ? 1 : 0;
    if (GameCanvas.wsState[index] != -1)
      return false;
    GameCanvas.wsState[index] = 0;
    GameCanvas.wsX[index] = x;
    GameCanvas.wsY[index] = y;
    return true;
  }

  public void updateWaterSplash()
  {
    if (GameCanvas.lowGraphic)
      return;
    for (int index = 0; index < 2; ++index)
    {
      if (GameCanvas.wsState[index] != -1)
      {
        --GameCanvas.wsY[index];
        if (GameCanvas.gameTick % 2 == 0)
        {
          ++GameCanvas.wsState[index];
          if (GameCanvas.wsState[index] > 2)
            GameCanvas.wsState[index] = -1;
          else
            GameCanvas.wsF[index] = GameCanvas.wsState[index];
        }
      }
    }
  }

  public void updateDust()
  {
    if (GameCanvas.lowGraphic)
      return;
    for (int index = 0; index < 2; ++index)
    {
      if (this.dustState[index] != -1)
      {
        ++this.dustState[index];
        if (this.dustState[index] >= 5)
          this.dustState[index] = -1;
        if (index == 0)
          --this.dustX[index];
        else
          ++this.dustX[index];
        --this.dustY[index];
      }
    }
  }

  public static bool isPaint(int x, int y) => x >= GameScr.cmx && x <= GameScr.cmx + GameScr.gW && y >= GameScr.cmy && y <= GameScr.cmy + GameScr.gH + 30;

  public void paintDust(mGraphics g)
  {
    if (GameCanvas.lowGraphic)
      return;
    for (int index = 0; index < 2; ++index)
    {
      if (this.dustState[index] != -1 && GameCanvas.isPaint(this.dustX[index], this.dustY[index]))
        g.drawImage(GameCanvas.imgDust[index][this.dustState[index]], this.dustX[index], this.dustY[index], 3);
    }
  }

  public void loadDust()
  {
    if (GameCanvas.lowGraphic)
      return;
    if (GameCanvas.imgDust == null)
    {
      GameCanvas.imgDust = new Image[2][];
      for (int index = 0; index < GameCanvas.imgDust.Length; ++index)
        GameCanvas.imgDust[index] = new Image[5];
      for (int index1 = 0; index1 < 2; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          GameCanvas.imgDust[index1][index2] = GameCanvas.loadImage("/e/d" + (object) index1 + (object) index2 + ".png");
      }
    }
    this.dustX = new int[2];
    this.dustY = new int[2];
    this.dustState = new int[2];
    this.dustState[0] = this.dustState[1] = -1;
  }

  public static void paintShukiren(int x, int y, mGraphics g) => g.drawRegion(GameCanvas.imgShuriken, 0, Main.f * 16, 16, 16, 0, x, y, mGraphics.HCENTER | mGraphics.VCENTER);

  public void resetToLoginScrz() => this.resetToLoginScr = true;

  public static bool isPointer(int x, int y, int w, int h) => (GameCanvas.isPointerDown || GameCanvas.isPointerJustRelease) && GameCanvas.px >= x && GameCanvas.px <= x + w && GameCanvas.py >= y && GameCanvas.py <= y + h;

  public void perform(int idAction, object p)
  {
    switch (idAction)
    {
      case 88810:
        int playerMapId = (int) p;
        GameCanvas.endDlg();
        Service.gI().acceptInviteTrade(playerMapId);
        break;
      case 88811:
        GameCanvas.endDlg();
        Service.gI().cancelInviteTrade();
        break;
      case 88814:
        Item[] items = (Item[]) p;
        GameCanvas.endDlg();
        Service.gI().crystalCollectLock(items);
        break;
      case 88815:
        break;
      case 88817:
        ChatPopup.addChatPopup(string.Empty, 1, Char.myCharz().npcFocus);
        Service.gI().menu(Char.myCharz().npcFocus.template.npcTemplateId, GameCanvas.menu.menuSelectedItem, 0);
        break;
      case 88818:
        short menuId1 = (short) p;
        Service.gI().textBoxId(menuId1, GameCanvas.inputDlg.tfInput.getText());
        GameCanvas.endDlg();
        break;
      case 88819:
        short menuId2 = (short) p;
        Service.gI().menuId(menuId2);
        break;
      case 88820:
        string[] strArray = (string[]) p;
        if (Char.myCharz().npcFocus == null)
          break;
        int menuSelectedItem = GameCanvas.menu.menuSelectedItem;
        if (strArray.Length > 1)
        {
          MyVector menuItems = new MyVector();
          for (int index = 0; index < strArray.Length - 1; ++index)
            menuItems.addElement((object) new Command(strArray[index + 1], (IActionListener) GameCanvas.instance, 88821, (object) menuSelectedItem));
          GameCanvas.menu.startAt(menuItems, 3);
          break;
        }
        ChatPopup.addChatPopup(string.Empty, 1, Char.myCharz().npcFocus);
        Service.gI().menu(Char.myCharz().npcFocus.template.npcTemplateId, menuSelectedItem, 0);
        break;
      case 88821:
        int menuId3 = (int) p;
        ChatPopup.addChatPopup(string.Empty, 1, Char.myCharz().npcFocus);
        Service.gI().menu(Char.myCharz().npcFocus.template.npcTemplateId, menuId3, GameCanvas.menu.menuSelectedItem);
        break;
      case 88822:
        ChatPopup.addChatPopup(string.Empty, 1, Char.myCharz().npcFocus);
        Service.gI().menu(Char.myCharz().npcFocus.template.npcTemplateId, GameCanvas.menu.menuSelectedItem, 0);
        break;
      case 88823:
        GameCanvas.startOKDlg(mResources.SENTMSG);
        break;
      case 88824:
        GameCanvas.startOKDlg(mResources.NOSENDMSG);
        break;
      case 88825:
        GameCanvas.startOKDlg(mResources.sendMsgSuccess, false);
        break;
      case 88826:
        GameCanvas.startOKDlg(mResources.cannotSendMsg, false);
        break;
      case 88827:
        GameCanvas.startOKDlg(mResources.sendGuessMsgSuccess);
        break;
      case 88828:
        GameCanvas.startOKDlg(mResources.sendMsgFail);
        break;
      case 88829:
        string text1 = GameCanvas.inputDlg.tfInput.getText();
        if (text1.Equals(string.Empty))
          break;
        Service.gI().changeName(text1, (int) p);
        InfoDlg.showWait();
        break;
      case 88836:
        GameCanvas.inputDlg.tfInput.setMaxTextLenght(6);
        GameCanvas.inputDlg.show(mResources.INPUT_PRIVATE_PASS, new Command(mResources.ACCEPT, (IActionListener) GameCanvas.instance, 888361, (object) null), TField.INPUT_TYPE_NUMERIC);
        break;
      case 88837:
        string text2 = GameCanvas.inputDlg.tfInput.getText();
        GameCanvas.endDlg();
        try
        {
          Service.gI().openLockAccProtect(int.Parse(text2.Trim()));
          break;
        }
        catch (Exception ex)
        {
          Cout.println("Loi tai 88837 " + ex.ToString());
          break;
        }
      case 88839:
        string text3 = GameCanvas.inputDlg.tfInput.getText();
        GameCanvas.endDlg();
        if (text3.Length >= 6)
        {
          if (!text3.Equals(string.Empty))
          {
            try
            {
              GameCanvas.startYesNoDlg(mResources.cancelAccountProtection, 888391, (object) text3, 8882, (object) null);
              break;
            }
            catch (Exception ex)
            {
              GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_2);
              break;
            }
          }
        }
        GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_1);
        break;
      default:
        switch (idAction - 8881)
        {
          case 0:
            string url = (string) p;
            try
            {
              GameMidlet.instance.platformRequest(url);
            }
            catch (Exception ex)
            {
            }
            GameCanvas.currentDialog = (Dialog) null;
            return;
          case 1:
            InfoDlg.hide();
            GameCanvas.currentDialog = (Dialog) null;
            return;
          case 3:
            GameCanvas.endDlg();
            GameCanvas.loginScr.switchToMe();
            return;
          case 4:
            GameMidlet.instance.exit();
            return;
          case 5:
            GameCanvas.endDlg();
            string name = (string) p;
            Service.gI().addFriend(name);
            return;
          case 6:
            GameCanvas.endDlg();
            int charId1 = (int) p;
            Service.gI().addPartyAccept(charId1);
            return;
          case 7:
            int charId2 = (int) p;
            Service.gI().addPartyCancel(charId2);
            GameCanvas.endDlg();
            return;
          case 8:
            string str = (string) p;
            GameCanvas.endDlg();
            Service.gI().acceptPleaseParty(str);
            return;
          default:
            switch (idAction - 888391)
            {
              case 0:
                string s = (string) p;
                GameCanvas.endDlg();
                Service.gI().clearAccProtect(int.Parse(s));
                return;
              case 1:
                Service.gI().menu(4, GameCanvas.menu.menuSelectedItem, 0);
                return;
              case 2:
                if (GameCanvas.loginScr == null)
                  GameCanvas.loginScr = new LoginScr();
                GameCanvas.loginScr.doLogin();
                Main.closeKeyBoard();
                return;
              case 3:
                GameCanvas.endDlg();
                return;
              case 4:
                GameCanvas.endDlg();
                return;
              case 5:
                GameCanvas.endDlg();
                return;
              case 6:
                return;
              default:
                if (idAction != 999)
                {
                  if (idAction != 9000)
                  {
                    if (idAction != 9999)
                    {
                      if (idAction != 101023)
                      {
                        if (idAction != 888361)
                          return;
                        string text4 = GameCanvas.inputDlg.tfInput.getText();
                        GameCanvas.endDlg();
                        if (text4.Length >= 6)
                        {
                          if (!text4.Equals(string.Empty))
                          {
                            try
                            {
                              Service.gI().activeAccProtect(int.Parse(text4));
                              return;
                            }
                            catch (Exception ex)
                            {
                              GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_2);
                              Cout.println("Loi tai 888361 Gamescavas " + ex.ToString());
                              return;
                            }
                          }
                        }
                        GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_1);
                        return;
                      }
                      Main.numberQuit = 0;
                      return;
                    }
                    GameCanvas.endDlg();
                    GameCanvas.connect();
                    Service.gI().setClientType();
                    if (GameCanvas.loginScr == null)
                      GameCanvas.loginScr = new LoginScr();
                    GameCanvas.loginScr.doLogin();
                    return;
                  }
                  GameCanvas.endDlg();
                  SplashScr.imgLogo = (Image) null;
                  SmallImage.loadBigRMS();
                  mSystem.gcc();
                  ServerListScreen.bigOk = true;
                  ServerListScreen.loadScreen = true;
                  GameScr.gI().loadGameScr();
                  if (GameCanvas.currentScreen == GameCanvas.loginScr)
                    return;
                  GameCanvas.serverScreen.switchToMe2();
                  return;
                }
                mSystem.closeBanner();
                GameCanvas.endDlg();
                return;
            }
        }
    }
  }

  public static void clearAllPointerEvent()
  {
    GameCanvas.isPointerClick = false;
    GameCanvas.isPointerDown = false;
    GameCanvas.isPointerJustDown = false;
    GameCanvas.isPointerJustRelease = false;
    GameScr.gI().lastSingleClick = 0L;
    GameScr.gI().isPointerDowning = false;
  }

  public static void backToRegister()
  {
  }
}
