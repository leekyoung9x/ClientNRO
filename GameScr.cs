// Decompiled with JetBrains decompiler
// Type: GameScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.g;
using System;

public class GameScr : mScreen, IChatable
{
  public static bool isPaintOther = false;
  public static MyVector textTime = new MyVector(string.Empty);
  public static bool isLoadAllData = false;
  public static GameScr instance;
  public static int gW;
  public static int gH;
  public static int gW2;
  public static int gssw;
  public static int gssh;
  public static int gH34;
  public static int gW3;
  public static int gH3;
  public static int gH23;
  public static int gW23;
  public static int gH2;
  public static int csPadMaxH;
  public static int cmdBarH;
  public static int gW34;
  public static int gW6;
  public static int gH6;
  public static int cmx;
  public static int cmy;
  public static int cmdx;
  public static int cmdy;
  public static int cmvx;
  public static int cmvy;
  public static int cmtoX;
  public static int cmtoY;
  public static int cmxLim;
  public static int cmyLim;
  public static int gssx;
  public static int gssy;
  public static int gssxe;
  public static int gssye;
  public Command cmdback;
  public Command cmdBag;
  public Command cmdSkill;
  public Command cmdTiemnang;
  public Command cmdtrangbi;
  public Command cmdInfo;
  public Command cmdFocus;
  public Command cmdFire;
  public static int d;
  public static int hpPotion;
  public static SkillPaint[] sks;
  public static Arrowpaint[] arrs;
  public static DartInfo[] darts;
  public static Part[] parts;
  public static EffectCharPaint[] efs;
  public static int lockTick;
  private int moveUp;
  private int moveDow;
  private int idTypeTask;
  private bool isstarOpen;
  private bool isChangeSkill;
  public static MyVector vClan = new MyVector();
  public static MyVector vPtMap = new MyVector();
  public static MyVector vFriend = new MyVector();
  public static MyVector vEnemies = new MyVector();
  public static MyVector vCharInMap = new MyVector();
  public static MyVector vItemMap = new MyVector();
  public static MyVector vMobAttack = new MyVector();
  public static MyVector vSet = new MyVector();
  public static MyVector vMob = new MyVector();
  public static MyVector vNpc = new MyVector();
  public static MyVector vFlag = new MyVector();
  public static NClass[] nClasss;
  public static int indexSize = 28;
  public static int indexTitle = 0;
  public static int indexSelect = 0;
  public static int indexRow = -1;
  public static int indexRowMax;
  public static int indexMenu = 0;
  public Item itemFocus;
  public ItemOptionTemplate[] iOptionTemplates;
  public SkillOptionTemplate[] sOptionTemplates;
  private static Scroll scrInfo = new Scroll();
  public static Scroll scrMain = new Scroll();
  public static MyVector vItemUpGrade = new MyVector();
  public static bool isTypeXu;
  public static bool isViewNext;
  public static bool isViewClanMemOnline = false;
  public static bool isViewClanInvite = true;
  public static bool isChop;
  public static string titleInputText = string.Empty;
  public static int tickMove;
  public static bool isPaintAlert = false;
  public static bool isPaintTask = false;
  public static bool isPaintTeam = false;
  public static bool isPaintFindTeam = false;
  public static bool isPaintFriend = false;
  public static bool isPaintEnemies = false;
  public static bool isPaintItemInfo = false;
  public static bool isHaveSelectSkill = false;
  public static bool isPaintSkill = false;
  public static bool isPaintInfoMe = false;
  public static bool isPaintStore = false;
  public static bool isPaintNonNam = false;
  public static bool isPaintNonNu = false;
  public static bool isPaintAoNam = false;
  public static bool isPaintAoNu = false;
  public static bool isPaintGangTayNam = false;
  public static bool isPaintGangTayNu = false;
  public static bool isPaintQuanNam = false;
  public static bool isPaintQuanNu = false;
  public static bool isPaintGiayNam = false;
  public static bool isPaintGiayNu = false;
  public static bool isPaintLien = false;
  public static bool isPaintNhan = false;
  public static bool isPaintNgocBoi = false;
  public static bool isPaintPhu = false;
  public static bool isPaintWeapon = false;
  public static bool isPaintStack = false;
  public static bool isPaintStackLock = false;
  public static bool isPaintGrocery = false;
  public static bool isPaintGroceryLock = false;
  public static bool isPaintUpGrade = false;
  public static bool isPaintConvert = false;
  public static bool isPaintUpGradeGold = false;
  public static bool isPaintUpPearl = false;
  public static bool isPaintBox = false;
  public static bool isPaintSplit = false;
  public static bool isPaintCharInMap = false;
  public static bool isPaintTrade = false;
  public static bool isPaintZone = false;
  public static bool isPaintMessage = false;
  public static bool isPaintClan = false;
  public static bool isRequestMember = false;
  public static Char currentCharViewInfo;
  public static long[] exps;
  public static int[] crystals;
  public static int[] upClothe;
  public static int[] upAdorn;
  public static int[] upWeapon;
  public static int[] coinUpCrystals;
  public static int[] coinUpClothes;
  public static int[] coinUpAdorns;
  public static int[] coinUpWeapons;
  public static int[] maxPercents;
  public static int[] goldUps;
  public int tMenuDelay;
  public int zoneCol = 6;
  public int[] zones;
  public int[] pts;
  public int[] numPlayer;
  public int[] maxPlayer;
  public int[] rank1;
  public int[] rank2;
  public string[] rankName1;
  public string[] rankName2;
  public int typeTrade;
  public int typeTradeOrder;
  public int coinTrade;
  public int coinTradeOrder;
  public int timeTrade;
  public int indexItemUse = -1;
  public int cLastFocusID = -1;
  public int cPreFocusID = -1;
  public bool isLockKey;
  public static int[] tasks;
  public static int[] mapTasks;
  public static Image imgRoomStat;
  public static Image frBarPow0;
  public static Image frBarPow1;
  public static Image frBarPow2;
  public static Image frBarPow20;
  public static Image frBarPow21;
  public static Image frBarPow22;
  public MyVector texts;
  public string textsTitle;
  public static sbyte vcData;
  public static sbyte vcMap;
  public static sbyte vcSkill;
  public static sbyte vcItem;
  public static sbyte vsData;
  public static sbyte vsMap;
  public static sbyte vsSkill;
  public static sbyte vsItem;
  public static sbyte vcTask;
  public static Image imgArrow;
  public static Image imgArrow2;
  public static Image imgChat;
  public static Image imgChat2;
  public static Image imgMenu;
  public static Image imgFocus;
  public static Image imgFocus2;
  public static Image imgSkill;
  public static Image imgSkill2;
  public static Image imgHP1;
  public static Image imgHP2;
  public static Image imgHP3;
  public static Image imgHP4;
  public static Image imgFire0;
  public static Image imgFire1;
  public static Image imgLbtn;
  public static Image imgLbtnFocus;
  public static Image imgLbtn2;
  public static Image imgLbtnFocus2;
  public static Image imgAnalog1;
  public static Image imgAnalog2;
  public string tradeName = string.Empty;
  public string tradeItemName = string.Empty;
  public int timeLengthMap;
  public int timeStartMap;
  public static sbyte typeViewInfo = 0;
  public static sbyte typeActive = 0;
  public static InfoMe info1 = new InfoMe();
  public static InfoMe info2 = new InfoMe();
  public static Image imgPanel;
  public static Image imgPanel2;
  public static Image imgHP;
  public static Image imgMP;
  public static Image imgSP;
  public static Image imgHPLost;
  public static Image imgMPLost;
  public Mob mobCapcha;
  public MagicTree magicTree;
  public static int countEff;
  public static GamePad gamePad = new GamePad();
  public static Image imgChatPC;
  public static Image imgChatsPC2;
  public static int isAnalog = 0;
  public static bool isUseTouch;
  public const int numSkill = 10;
  public const int numSkill_2 = 5;
  public static Skill[] keySkill = new Skill[10];
  public static Skill[] onScreenSkill = new Skill[10];
  public Command cmdMenu;
  public static int firstY;
  public static int wSkill;
  public static long deltaTime;
  public bool isPointerDowning;
  public bool isChangingCameraMode;
  private int ptLastDownX;
  private int ptLastDownY;
  private int ptFirstDownX;
  private int ptFirstDownY;
  private int ptDownTime;
  private bool disableSingleClick;
  public long lastSingleClick;
  public bool clickMoving;
  public bool clickOnTileTop;
  public bool clickMovingRed;
  private int clickToX;
  private int clickToY;
  private int lastClickCMX;
  private int lastClickCMY;
  private int clickMovingP1;
  private int clickMovingTimeOut;
  private long lastMove;
  public static bool isNewClanMessage;
  private long lastFire;
  private long lastUsePotion;
  public int auto;
  public int dem;
  private string strTam = string.Empty;
  private int a;
  public bool isFreez;
  public bool isUseFreez;
  public static Image imgTrans;
  public bool isRongThanXuatHien;
  public bool isRongNamek;
  public bool isSuperPower;
  public int tPower;
  public int xPower;
  public int yPower;
  public int dxPower;
  public bool activeRongThan;
  public bool isMeCallRongThan;
  public int mautroi;
  public int mapRID;
  public int zoneRID;
  public int bgRID = -1;
  public static int tam = 0;
  public static bool isAutoPlay;
  public static bool canAutoPlay;
  public static bool isChangeZone;
  private int timeSkill;
  private int nSkill;
  private int selectedIndexSkill = -1;
  private Skill lastSkill;
  private bool doSeleckSkillFlag;
  public string strCapcha;
  private long longPress;
  private int move;
  public bool flareFindFocus;
  private int flareTime;
  public int keyTouchSkill = -1;
  private long lastSendUpdatePostion;
  public static long lastTick;
  public static long currTick;
  private int timeAuto;
  public static long lastXS;
  public static long currXS;
  public static int secondXS;
  public int runArrow;
  public static int isPaintRada;
  public static Image imgNut;
  public static Image imgNutF;
  public int[] keyCapcha;
  public static Image imgCapcha;
  public string keyInput;
  public static int disXC;
  public static bool isPaint = true;
  public static int shock_scr;
  private static int[] shock_x = new int[4]{ 3, -3, 3, -3 };
  private static int[] shock_y = new int[4]{ 3, -3, -3, 3 };
  private int tDoubleDelay;
  public static Image arrow;
  private static int yTouchBar;
  private static int xC;
  private static int yC;
  private static int xL;
  private static int yL;
  public int xR;
  public int yR;
  private static int xU;
  private static int yU;
  private static int xF;
  private static int yF;
  public static int xHP;
  public static int yHP;
  private static int xTG;
  private static int yTG;
  public static int[] xS;
  public static int[] yS;
  public static int xSkill;
  public static int ySkill;
  public static int padSkill;
  public int dMP;
  public int twMp;
  public bool isInjureMp;
  public int dHP;
  public int twHp;
  public bool isInjureHp;
  private long curr;
  private long last;
  private int secondVS;
  private int[] idVS = new int[2]{ -1, -1 };
  public static string[] flyTextString;
  public static int[] flyTextX;
  public static int[] flyTextY;
  public static int[] flyTextYTo;
  public static int[] flyTextDx;
  public static int[] flyTextDy;
  public static int[] flyTextState;
  public static int[] flyTextColor;
  public static int[] flyTime;
  public static int[] splashX;
  public static int[] splashY;
  public static int[] splashState;
  public static int[] splashF;
  public static int[] splashDir;
  public static Image[] imgSplash;
  public static int cmdBarX;
  public static int cmdBarY;
  public static int cmdBarW;
  public static int cmdBarLeftW;
  public static int cmdBarRightW;
  public static int cmdBarCenterW;
  public static int hpBarX;
  public static int hpBarY;
  public static int hpBarW;
  public static int spBarW;
  public static int mpBarW;
  public static int expBarW;
  public static int lvPosX;
  public static int moneyPosX;
  public static int hpBarH;
  public static int girlHPBarY;
  public static Image[] imgCmdBar;
  private int imgScrW;
  public static int popupY;
  public static int popupX;
  public static int isborderIndex;
  public static int isselectedRow;
  private static Image imgNolearn;
  public int cmxp;
  public int cmvxp;
  public int cmdxp;
  public int cmxLimp;
  public int cmyLimp;
  public int cmyp;
  public int cmvyp;
  public int cmdyp;
  private int indexTiemNang;
  private string alertURL;
  private string fnick;
  public static int xstart;
  public static int ystart;
  public static int popupW = 140;
  public static int popupH = 160;
  public static int cmySK;
  public static int cmtoYSK;
  public static int cmdySK;
  public static int cmvySK;
  public static int cmyLimSK;
  public static int columns = 6;
  public static int rows;
  private int totalRowInfo;
  private int ypaintKill;
  private int ylimUp;
  private int ylimDow;
  private int yPaint;
  public static int indexEff = 0;
  public static EffectCharPaint effUpok;
  public static int inforX;
  public static int inforY;
  public static int inforW;
  public static int inforH;
  public Command cmdDead;
  public static bool notPaint = false;
  public static bool isPing = false;
  public static int INFO = 0;
  public static int STORE = 1;
  public static int ZONE = 2;
  public static int UPGRADE = 3;
  private int Hitem = 30;
  private int maxSizeRow = 5;
  private int isTranKyNang;
  private bool isTran;
  private int cmY_Old;
  private int cmX_Old;
  public PopUpYesNo popUpYesNo;
  public static MyVector vChatVip = new MyVector();
  public static int vBig;
  public bool isFireWorks;
  public int[] winnumber;
  public int[] randomNumber;
  public int[] tMove;
  public int[] moveCount;
  public int[] delayMove;
  public int moveIndex;
  private bool isWin;
  private string strFinish;
  private int tShow;
  private int xChatVip;
  private int currChatWidth;
  private bool startChat;
  public sbyte percentMabu;
  public bool mabuEff;
  public int tMabuEff;
  public static bool isPaintChatVip;
  public static sbyte mabuPercent;
  public static sbyte isNewMember;
  private string yourNumber = string.Empty;
  private string[] strPaint;
  public static Image imgHP_NEW;
  public static InfoPhuBan phuban_Info;
  public static FrameImage fra_PVE_Bar_0;
  public static FrameImage fra_PVE_Bar_1;
  public static Image imgVS;
  public static Image imgBall;
  public static Image imgKhung;

  public GameScr()
  {
    if (GameCanvas.w == 128 || GameCanvas.h <= 208)
      GameScr.indexSize = 20;
    this.cmdback = new Command(string.Empty, 11021);
    this.cmdMenu = new Command("menu", 11000);
    this.cmdFocus = new Command(string.Empty, 11001);
    this.cmdMenu.img = GameScr.imgMenu;
    this.cmdMenu.w = mGraphics.getImageWidth(this.cmdMenu.img) + 20;
    this.cmdMenu.isPlaySoundButton = false;
    this.cmdFocus.img = GameScr.imgFocus;
    if (GameCanvas.isTouch)
    {
      this.cmdMenu.x = 0;
      this.cmdMenu.y = 50;
      this.cmdFocus = (Command) null;
    }
    else
    {
      this.cmdMenu.x = 0;
      this.cmdMenu.y = GameScr.gH - 30;
      this.cmdFocus.x = GameScr.gW - 32;
      this.cmdFocus.y = GameScr.gH - 32;
    }
    this.right = this.cmdFocus;
    GameScr.isPaintRada = 1;
    if (!GameCanvas.isTouch)
      return;
    GameScr.isHaveSelectSkill = true;
  }

  public static void loadBg()
  {
    GameScr.fra_PVE_Bar_0 = new FrameImage(mSystem.loadImage("/mainImage/i_pve_bar_0.png"), 6, 15);
    GameScr.fra_PVE_Bar_1 = new FrameImage(mSystem.loadImage("/mainImage/i_pve_bar_1.png"), 38, 21);
    GameScr.imgVS = mSystem.loadImage("/mainImage/i_vs.png");
    GameScr.imgBall = mSystem.loadImage("/mainImage/i_charlife.png");
    GameScr.imgHP_NEW = mSystem.loadImage("/mainImage/i_hp.png");
    GameScr.imgKhung = mSystem.loadImage("/mainImage/i_khung.png");
    GameScr.imgLbtn = GameCanvas.loadImage("/mainImage/myTexture2dbtnl.png");
    GameScr.imgLbtnFocus = GameCanvas.loadImage("/mainImage/myTexture2dbtnlf.png");
    GameScr.imgLbtn2 = GameCanvas.loadImage("/mainImage/myTexture2dbtnl2.png");
    GameScr.imgLbtnFocus2 = GameCanvas.loadImage("/mainImage/myTexture2dbtnlf2.png");
    GameScr.imgPanel = GameCanvas.loadImage("/mainImage/myTexture2dpanel.png");
    GameScr.imgPanel2 = GameCanvas.loadImage("/mainImage/panel2.png");
    GameScr.imgHP = GameCanvas.loadImage("/mainImage/myTexture2dHP.png");
    GameScr.imgSP = GameCanvas.loadImage("/mainImage/SP.png");
    GameScr.imgHPLost = GameCanvas.loadImage("/mainImage/myTexture2dhpLost.png");
    GameScr.imgMPLost = GameCanvas.loadImage("/mainImage/myTexture2dmpLost.png");
    GameScr.imgMP = GameCanvas.loadImage("/mainImage/myTexture2dMP.png");
    GameScr.imgSkill = GameCanvas.loadImage("/mainImage/myTexture2dskill.png");
    GameScr.imgSkill2 = GameCanvas.loadImage("/mainImage/myTexture2dskill2.png");
    GameScr.imgMenu = GameCanvas.loadImage("/mainImage/myTexture2dmenu.png");
    GameScr.imgFocus = GameCanvas.loadImage("/mainImage/myTexture2dfocus.png");
    GameScr.imgChatPC = GameCanvas.loadImage("/pc/chat.png");
    GameScr.imgChatsPC2 = GameCanvas.loadImage("/pc/chat2.png");
    if (GameCanvas.isTouch)
    {
      GameScr.imgArrow = GameCanvas.loadImage("/mainImage/myTexture2darrow.png");
      GameScr.imgArrow2 = GameCanvas.loadImage("/mainImage/myTexture2darrow2.png");
      GameScr.imgChat = GameCanvas.loadImage("/mainImage/myTexture2dchat.png");
      GameScr.imgChat2 = GameCanvas.loadImage("/mainImage/myTexture2dchat2.png");
      GameScr.imgFocus2 = GameCanvas.loadImage("/mainImage/myTexture2dfocus2.png");
      GameScr.imgHP1 = GameCanvas.loadImage("/mainImage/myTexture2dPea0.png");
      GameScr.imgHP2 = GameCanvas.loadImage("/mainImage/myTexture2dPea1.png");
      GameScr.imgAnalog1 = GameCanvas.loadImage("/mainImage/myTexture2danalog1.png");
      GameScr.imgAnalog2 = GameCanvas.loadImage("/mainImage/myTexture2danalog2.png");
      GameScr.imgHP3 = GameCanvas.loadImage("/mainImage/myTexture2dPea2.png");
      GameScr.imgHP4 = GameCanvas.loadImage("/mainImage/myTexture2dPea3.png");
      GameScr.imgFire0 = GameCanvas.loadImage("/mainImage/myTexture2dfirebtn0.png");
      GameScr.imgFire1 = GameCanvas.loadImage("/mainImage/myTexture2dfirebtn1.png");
    }
    GameScr.flyTextX = new int[5];
    GameScr.flyTextY = new int[5];
    GameScr.flyTextDx = new int[5];
    GameScr.flyTextDy = new int[5];
    GameScr.flyTextState = new int[5];
    GameScr.flyTextString = new string[5];
    GameScr.flyTextYTo = new int[5];
    GameScr.flyTime = new int[5];
    GameScr.flyTextColor = new int[8];
    for (int index = 0; index < 5; ++index)
      GameScr.flyTextState[index] = -1;
    sbyte[] numArray1 = Rms.loadRMS("NRdataVersion");
    sbyte[] numArray2 = Rms.loadRMS("NRmapVersion");
    sbyte[] numArray3 = Rms.loadRMS("NRskillVersion");
    sbyte[] numArray4 = Rms.loadRMS("NRitemVersion");
    if (numArray1 != null)
      GameScr.vcData = numArray1[0];
    if (numArray2 != null)
      GameScr.vcMap = numArray2[0];
    if (numArray3 != null)
      GameScr.vcSkill = numArray3[0];
    if (numArray4 != null)
      GameScr.vcItem = numArray4[0];
    GameScr.imgNut = GameCanvas.loadImage("/mainImage/myTexture2dnut.png");
    GameScr.imgNutF = GameCanvas.loadImage("/mainImage/myTexture2dnutF.png");
    MobCapcha.init();
    GameScr.isAnalog = Rms.loadRMSInt("analog") != 1 ? 0 : 1;
    GameScr.gamePad = new GamePad();
    GameScr.arrow = GameCanvas.loadImage("/mainImage/myTexture2darrow3.png");
    GameScr.imgTrans = GameCanvas.loadImage("/bg/trans.png");
    GameScr.imgRoomStat = GameCanvas.loadImage("/mainImage/myTexture2dstat.png");
    GameScr.frBarPow0 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor20.png");
    GameScr.frBarPow1 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor21.png");
    GameScr.frBarPow2 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor22.png");
    GameScr.frBarPow20 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor00.png");
    GameScr.frBarPow21 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor01.png");
    GameScr.frBarPow22 = GameCanvas.loadImage("/mainImage/myTexture2dlineColor02.png");
  }

  public void initSelectChar()
  {
    this.readPart();
    SmallImage.init();
  }

  public static void paintOngMauPercent(
    Image img0,
    Image img1,
    Image img2,
    float x,
    float y,
    int size,
    float pixelPercent,
    mGraphics g)
  {
    int clipX = g.getClipX();
    int clipY = g.getClipY();
    int clipWidth = g.getClipWidth();
    int clipHeight = g.getClipHeight();
    g.setClip((int) x, (int) y, (int) pixelPercent, 13);
    int num = size / 15 - 2;
    for (int index = 0; index < num; ++index)
      g.drawImage(img1, x + (float) ((index + 1) * 15), y, 0);
    g.drawImage(img0, x, y, 0);
    g.drawImage(img1, (float) ((double) x + (double) size - 30.0), y, 0);
    g.drawImage(img2, (float) ((double) x + (double) size - 15.0), y, 0);
    g.setClip(clipX, clipY, clipWidth, clipHeight);
  }

  public void initTraining()
  {
    if (!CreateCharScr.isCreateChar)
      return;
    CreateCharScr.isCreateChar = false;
    this.right = (Command) null;
  }

  public bool isMapDocNhan() => TileMap.mapID >= 53 && TileMap.mapID <= 62;

  public bool isMapFize() => TileMap.mapID >= 63;

  public override void switchToMe()
  {
    GameScr.vChatVip.removeAllElements();
    ServerListScreen.isWait = false;
    if (BackgroudEffect.isHaveRain())
      SoundMn.gI().rain();
    LoginScr.isContinueToLogin = false;
    Char.isLoadingMap = false;
    if (!GameScr.isPaintOther)
      Service.gI().finishLoadMap();
    if (TileMap.isTrainingMap())
      this.initTraining();
    GameScr.info1.isUpdate = true;
    GameScr.info2.isUpdate = true;
    this.resetButton();
    GameScr.isLoadAllData = true;
    GameScr.isPaintOther = false;
    base.switchToMe();
  }

  public static int getMaxExp(int level)
  {
    int maxExp = 0;
    for (int index = 0; index <= level; ++index)
      maxExp += (int) GameScr.exps[index];
    return maxExp;
  }

  public static void resetAllvector()
  {
    GameScr.vCharInMap.removeAllElements();
    Teleport.vTeleport.removeAllElements();
    GameScr.vItemMap.removeAllElements();
    Effect2.vEffect2.removeAllElements();
    Effect2.vAnimateEffect.removeAllElements();
    Effect2.vEffect2Outside.removeAllElements();
    Effect2.vEffectFeet.removeAllElements();
    Effect2.vEffect3.removeAllElements();
    GameScr.vMobAttack.removeAllElements();
    GameScr.vMob.removeAllElements();
    GameScr.vNpc.removeAllElements();
    Char.myCharz().vMovePoints.removeAllElements();
  }

  public void loadSkillShortcut()
  {
  }

  public void onOSkill(sbyte[] oSkillID)
  {
    Cout.println("GET onScreenSkill!");
    GameScr.onScreenSkill = new Skill[10];
    if (oSkillID == null)
    {
      this.loadDefaultonScreenSkill();
    }
    else
    {
      for (int index1 = 0; index1 < oSkillID.Length; ++index1)
      {
        for (int index2 = 0; index2 < Char.myCharz().vSkillFight.size(); ++index2)
        {
          Skill skill = (Skill) Char.myCharz().vSkillFight.elementAt(index2);
          if ((int) skill.template.id == (int) oSkillID[index1])
          {
            GameScr.onScreenSkill[index1] = skill;
            break;
          }
        }
      }
    }
  }

  public void onKSkill(sbyte[] kSkillID)
  {
    Cout.println("GET KEYSKILL!");
    GameScr.keySkill = new Skill[10];
    if (kSkillID == null)
    {
      this.loadDefaultKeySkill();
    }
    else
    {
      for (int index1 = 0; index1 < kSkillID.Length; ++index1)
      {
        for (int index2 = 0; index2 < Char.myCharz().vSkillFight.size(); ++index2)
        {
          Skill skill = (Skill) Char.myCharz().vSkillFight.elementAt(index2);
          if ((int) skill.template.id == (int) kSkillID[index1])
          {
            GameScr.keySkill[index1] = skill;
            break;
          }
        }
      }
    }
  }

  public void onCSkill(sbyte[] cSkillID)
  {
    Cout.println("GET CURRENTSKILL!");
    if (cSkillID == null || cSkillID.Length == 0)
    {
      if (Char.myCharz().vSkillFight.size() > 0)
        Char.myCharz().myskill = (Skill) Char.myCharz().vSkillFight.elementAt(0);
    }
    else
    {
      for (int index = 0; index < Char.myCharz().vSkillFight.size(); ++index)
      {
        Skill skill = (Skill) Char.myCharz().vSkillFight.elementAt(index);
        if ((int) skill.template.id == (int) cSkillID[0])
        {
          Char.myCharz().myskill = skill;
          break;
        }
      }
    }
    if (Char.myCharz().myskill == null)
      return;
    Service.gI().selectSkill((int) Char.myCharz().myskill.template.id);
    this.saveRMSCurrentSkill(Char.myCharz().myskill.template.id);
  }

  private void loadDefaultonScreenSkill()
  {
    Cout.println("LOAD DEFAULT ONmScreen SKILL");
    for (int index = 0; index < GameScr.onScreenSkill.Length && index < Char.myCharz().vSkillFight.size(); ++index)
    {
      Skill skill = (Skill) Char.myCharz().vSkillFight.elementAt(index);
      GameScr.onScreenSkill[index] = skill;
    }
    this.saveonScreenSkillToRMS();
  }

  private void loadDefaultKeySkill()
  {
    Cout.println("LOAD DEFAULT KEY SKILL");
    for (int index = 0; index < GameScr.keySkill.Length && index < Char.myCharz().vSkillFight.size(); ++index)
    {
      Skill skill = (Skill) Char.myCharz().vSkillFight.elementAt(index);
      GameScr.keySkill[index] = skill;
    }
    this.saveKeySkillToRMS();
  }

  public void doSetOnScreenSkill(SkillTemplate skillTemplate)
  {
    Skill skill = Char.myCharz().getSkill(skillTemplate);
    MyVector menuItems = new MyVector();
    for (int index = 0; index < 10; ++index)
    {
      object[] p = new object[2]
      {
        (object) skill,
        (object) (index.ToString() + string.Empty)
      };
      menuItems.addElement((object) new Command(mResources.into_place + (object) (index + 1), 11120, (object) p));
    }
    GameCanvas.menu.startAt(menuItems, 0);
  }

  public void doSetKeySkill(SkillTemplate skillTemplate)
  {
    Cout.println("DO SET KEY SKILL");
    Skill skill = Char.myCharz().getSkill(skillTemplate);
    string[] strArray = !TField.isQwerty ? mResources.key_skill : mResources.key_skill_qwerty;
    MyVector menuItems = new MyVector();
    for (int index = 0; index < 10; ++index)
    {
      object[] p = new object[2]
      {
        (object) skill,
        (object) (index.ToString() + string.Empty)
      };
      menuItems.addElement((object) new Command(strArray[index], 11121, (object) p));
    }
    GameCanvas.menu.startAt(menuItems, 0);
  }

  public void saveonScreenSkillToRMS()
  {
    sbyte[] skill = new sbyte[GameScr.onScreenSkill.Length];
    for (int index = 0; index < GameScr.onScreenSkill.Length; ++index)
      skill[index] = GameScr.onScreenSkill[index] != null ? GameScr.onScreenSkill[index].template.id : (sbyte) -1;
    Service.gI().changeOnKeyScr(skill);
  }

  public void saveKeySkillToRMS()
  {
    sbyte[] skill = new sbyte[GameScr.keySkill.Length];
    for (int index = 0; index < GameScr.keySkill.Length; ++index)
      skill[index] = GameScr.keySkill[index] != null ? GameScr.keySkill[index].template.id : (sbyte) -1;
    Service.gI().changeOnKeyScr(skill);
  }

  public void saveRMSCurrentSkill(sbyte id)
  {
  }

  public void addSkillShortcut(Skill skill)
  {
    Cout.println("ADD SKILL SHORTCUT TO SKILL " + (object) skill.template.id);
    for (int index = 0; index < GameScr.onScreenSkill.Length; ++index)
    {
      if (GameScr.onScreenSkill[index] == null)
      {
        GameScr.onScreenSkill[index] = skill;
        break;
      }
    }
    for (int index = 0; index < GameScr.keySkill.Length; ++index)
    {
      if (GameScr.keySkill[index] == null)
      {
        GameScr.keySkill[index] = skill;
        break;
      }
    }
    if (Char.myCharz().myskill == null)
      Char.myCharz().myskill = skill;
    this.saveKeySkillToRMS();
    this.saveonScreenSkillToRMS();
  }

  public bool isBagFull()
  {
    for (int index = Char.myCharz().arrItemBag.Length - 1; index >= 0; --index)
    {
      if (Char.myCharz().arrItemBag[index] == null)
        return false;
    }
    return true;
  }

  public void createConfirm(string[] menu, Npc npc)
  {
    this.resetButton();
    this.isLockKey = true;
    this.left = new Command(menu[0], 130011, (object) npc);
    this.right = new Command(menu[1], 130012, (object) npc);
  }

  public void createMenu(string[] menu, Npc npc)
  {
    MyVector menuItems = new MyVector();
    for (int index = 0; index < menu.Length; ++index)
      menuItems.addElement((object) new Command(menu[index], 11057, (object) npc));
    GameCanvas.menu.startAt(menuItems, 2);
  }

  public void readPart()
  {
    DataInputStream dataInputStream = (DataInputStream) null;
    try
    {
      dataInputStream = new DataInputStream(Rms.loadRMS("NR_part"));
      int length = (int) dataInputStream.readShort();
      GameScr.parts = new Part[length];
      for (int index1 = 0; index1 < length; ++index1)
      {
        int type = (int) dataInputStream.readByte();
        GameScr.parts[index1] = new Part(type);
        for (int index2 = 0; index2 < GameScr.parts[index1].pi.Length; ++index2)
        {
          GameScr.parts[index1].pi[index2] = new PartImage();
          GameScr.parts[index1].pi[index2].id = dataInputStream.readShort();
          GameScr.parts[index1].pi[index2].dx = dataInputStream.readByte();
          GameScr.parts[index1].pi[index2].dy = dataInputStream.readByte();
        }
      }
    }
    catch (Exception ex)
    {
      Cout.LogError("LOI TAI readPart " + ex.ToString());
    }
    finally
    {
      try
      {
        dataInputStream.close();
      }
      catch (Exception ex)
      {
        Cout.LogError("LOI TAI readPart 2" + ex.ToString());
      }
    }
  }

  public void readEfect()
  {
    DataInputStream dataInputStream = (DataInputStream) null;
    try
    {
      dataInputStream = new DataInputStream(Rms.loadRMS("NR_effect"));
      int length = (int) dataInputStream.readShort();
      GameScr.efs = new EffectCharPaint[length];
      for (int index1 = 0; index1 < length; ++index1)
      {
        GameScr.efs[index1] = new EffectCharPaint();
        GameScr.efs[index1].idEf = (int) dataInputStream.readShort();
        GameScr.efs[index1].arrEfInfo = new EffectInfoPaint[(int) dataInputStream.readByte()];
        for (int index2 = 0; index2 < GameScr.efs[index1].arrEfInfo.Length; ++index2)
        {
          GameScr.efs[index1].arrEfInfo[index2] = new EffectInfoPaint();
          GameScr.efs[index1].arrEfInfo[index2].idImg = (int) dataInputStream.readShort();
          GameScr.efs[index1].arrEfInfo[index2].dx = (int) dataInputStream.readByte();
          GameScr.efs[index1].arrEfInfo[index2].dy = (int) dataInputStream.readByte();
        }
      }
    }
    catch (Exception ex)
    {
    }
    finally
    {
      try
      {
        dataInputStream.close();
      }
      catch (Exception ex)
      {
        Cout.LogError("Loi ham Eff: " + ex.ToString());
      }
    }
  }

  public void readArrow()
  {
    DataInputStream dataInputStream = (DataInputStream) null;
    try
    {
      dataInputStream = new DataInputStream(Rms.loadRMS("NR_arrow"));
      int length = (int) dataInputStream.readShort();
      GameScr.arrs = new Arrowpaint[length];
      for (int index = 0; index < length; ++index)
      {
        GameScr.arrs[index] = new Arrowpaint();
        GameScr.arrs[index].id = (int) dataInputStream.readShort();
        GameScr.arrs[index].imgId[0] = (int) dataInputStream.readShort();
        GameScr.arrs[index].imgId[1] = (int) dataInputStream.readShort();
        GameScr.arrs[index].imgId[2] = (int) dataInputStream.readShort();
      }
    }
    catch (Exception ex)
    {
    }
    finally
    {
      try
      {
        dataInputStream.close();
      }
      catch (Exception ex)
      {
        Cout.LogError("Loi ham readArrow: " + ex.ToString());
      }
    }
  }

  public void readDart()
  {
    DataInputStream dataInputStream = (DataInputStream) null;
    try
    {
      dataInputStream = new DataInputStream(Rms.loadRMS("NR_dart"));
      int length1 = (int) dataInputStream.readShort();
      GameScr.darts = new DartInfo[length1];
      for (int index1 = 0; index1 < length1; ++index1)
      {
        GameScr.darts[index1] = new DartInfo();
        GameScr.darts[index1].id = dataInputStream.readShort();
        GameScr.darts[index1].nUpdate = dataInputStream.readShort();
        GameScr.darts[index1].va = (int) dataInputStream.readShort() * 256;
        GameScr.darts[index1].xdPercent = dataInputStream.readShort();
        int length2 = (int) dataInputStream.readShort();
        GameScr.darts[index1].tail = new short[length2];
        for (int index2 = 0; index2 < length2; ++index2)
          GameScr.darts[index1].tail[index2] = dataInputStream.readShort();
        int length3 = (int) dataInputStream.readShort();
        GameScr.darts[index1].tailBorder = new short[length3];
        for (int index3 = 0; index3 < length3; ++index3)
          GameScr.darts[index1].tailBorder[index3] = dataInputStream.readShort();
        int length4 = (int) dataInputStream.readShort();
        GameScr.darts[index1].xd1 = new short[length4];
        for (int index4 = 0; index4 < length4; ++index4)
          GameScr.darts[index1].xd1[index4] = dataInputStream.readShort();
        int length5 = (int) dataInputStream.readShort();
        GameScr.darts[index1].xd2 = new short[length5];
        for (int index5 = 0; index5 < length5; ++index5)
          GameScr.darts[index1].xd2[index5] = dataInputStream.readShort();
        int length6 = (int) dataInputStream.readShort();
        GameScr.darts[index1].head = new short[length6][];
        for (int index6 = 0; index6 < length6; ++index6)
        {
          short length7 = dataInputStream.readShort();
          GameScr.darts[index1].head[index6] = new short[(int) length7];
          for (int index7 = 0; index7 < (int) length7; ++index7)
            GameScr.darts[index1].head[index6][index7] = dataInputStream.readShort();
        }
        int length8 = (int) dataInputStream.readShort();
        GameScr.darts[index1].headBorder = new short[length8][];
        for (int index8 = 0; index8 < length8; ++index8)
        {
          short length9 = dataInputStream.readShort();
          GameScr.darts[index1].headBorder[index8] = new short[(int) length9];
          for (int index9 = 0; index9 < (int) length9; ++index9)
            GameScr.darts[index1].headBorder[index8][index9] = dataInputStream.readShort();
        }
      }
    }
    catch (Exception ex)
    {
      Cout.LogError("Loi ham ReadDart: " + ex.ToString());
    }
    finally
    {
      try
      {
        dataInputStream.close();
      }
      catch (Exception ex)
      {
        Cout.LogError("Loi ham reaaDart: " + ex.ToString());
      }
    }
  }

  public void readSkill()
  {
    DataInputStream dataInputStream = (DataInputStream) null;
    try
    {
      dataInputStream = new DataInputStream(Rms.loadRMS("NR_skill"));
      int num = (int) dataInputStream.readShort();
      GameScr.sks = new SkillPaint[Skills.skills.size()];
      for (int index1 = 0; index1 < num; ++index1)
      {
        short index2 = dataInputStream.readShort();
        Res.outz("skill id= " + (object) index2);
        if (index2 == (short) 1111)
          index2 = (short) (num - 1);
        GameScr.sks[(int) index2] = new SkillPaint();
        GameScr.sks[(int) index2].id = (int) index2;
        GameScr.sks[(int) index2].effectHappenOnMob = (int) dataInputStream.readShort();
        if (GameScr.sks[(int) index2].effectHappenOnMob <= 0)
          GameScr.sks[(int) index2].effectHappenOnMob = 80;
        GameScr.sks[(int) index2].numEff = (int) dataInputStream.readByte();
        GameScr.sks[(int) index2].skillStand = new SkillInfoPaint[(int) dataInputStream.readByte()];
        for (int index3 = 0; index3 < GameScr.sks[(int) index2].skillStand.Length; ++index3)
        {
          GameScr.sks[(int) index2].skillStand[index3] = new SkillInfoPaint();
          GameScr.sks[(int) index2].skillStand[index3].status = (int) dataInputStream.readByte();
          GameScr.sks[(int) index2].skillStand[index3].effS0Id = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].e0dx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].e0dy = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].effS1Id = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].e1dx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].e1dy = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].effS2Id = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].e2dx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].e2dy = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].arrowId = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].adx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillStand[index3].ady = (int) dataInputStream.readShort();
        }
        GameScr.sks[(int) index2].skillfly = new SkillInfoPaint[(int) dataInputStream.readByte()];
        for (int index4 = 0; index4 < GameScr.sks[(int) index2].skillfly.Length; ++index4)
        {
          GameScr.sks[(int) index2].skillfly[index4] = new SkillInfoPaint();
          GameScr.sks[(int) index2].skillfly[index4].status = (int) dataInputStream.readByte();
          GameScr.sks[(int) index2].skillfly[index4].effS0Id = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].e0dx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].e0dy = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].effS1Id = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].e1dx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].e1dy = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].effS2Id = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].e2dx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].e2dy = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].arrowId = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].adx = (int) dataInputStream.readShort();
          GameScr.sks[(int) index2].skillfly[index4].ady = (int) dataInputStream.readShort();
        }
      }
    }
    catch (Exception ex)
    {
      Cout.LogError("Loi ham readSkill: " + ex.ToString());
    }
    finally
    {
      try
      {
        dataInputStream.close();
      }
      catch (Exception ex)
      {
        Cout.LogError("Loi ham readskill: " + ex.ToString());
      }
    }
  }

  public static GameScr gI()
  {
    if (GameScr.instance == null)
      GameScr.instance = new GameScr();
    return GameScr.instance;
  }

  public static void clearGameScr() => GameScr.instance = (GameScr) null;

  public void loadGameScr()
  {
    GameScr.loadSplash();
    Res.init();
    this.loadInforBar();
  }

  public void doMenuInforMe()
  {
    GameScr.scrMain.clear();
    GameScr.scrInfo.clear();
    GameScr.isViewNext = false;
    this.cmdBag = new Command(mResources.MENUME[0], 1100011);
    this.cmdSkill = new Command(mResources.MENUME[1], 1100012);
    this.cmdTiemnang = new Command(mResources.MENUME[2], 1100013);
    this.cmdInfo = new Command(mResources.MENUME[3], 1100014);
    this.cmdtrangbi = new Command(mResources.MENUME[4], 1100015);
    MyVector menuItems = new MyVector();
    menuItems.addElement((object) this.cmdBag);
    menuItems.addElement((object) this.cmdSkill);
    menuItems.addElement((object) this.cmdTiemnang);
    menuItems.addElement((object) this.cmdInfo);
    menuItems.addElement((object) this.cmdtrangbi);
    GameCanvas.menu.startAt(menuItems, 3);
  }

  public void doMenusynthesis()
  {
    MyVector menuItems = new MyVector();
    menuItems.addElement((object) new Command(mResources.SYNTHESIS[0], 110002));
    menuItems.addElement((object) new Command(mResources.SYNTHESIS[1], 1100032));
    menuItems.addElement((object) new Command(mResources.SYNTHESIS[2], 1100033));
    GameCanvas.menu.startAt(menuItems, 3);
  }

  public static void loadCamera(bool fullmScreen, int cx, int cy)
  {
    GameScr.gW = GameCanvas.w;
    GameScr.cmdBarH = 39;
    GameScr.gH = GameCanvas.h;
    GameScr.cmdBarW = GameScr.gW;
    GameScr.cmdBarX = 0;
    GameScr.cmdBarY = GameCanvas.h - Paint.hTab - GameScr.cmdBarH;
    GameScr.girlHPBarY = 0;
    GameScr.csPadMaxH = GameCanvas.h / 6;
    if (GameScr.csPadMaxH < 48)
      GameScr.csPadMaxH = 48;
    GameScr.gW2 = GameScr.gW >> 1;
    GameScr.gH2 = GameScr.gH >> 1;
    GameScr.gW3 = GameScr.gW / 3;
    GameScr.gH3 = GameScr.gH / 3;
    GameScr.gW23 = GameScr.gH - 120;
    GameScr.gH23 = GameScr.gH * 2 / 3;
    GameScr.gW34 = 3 * GameScr.gW / 4;
    GameScr.gH34 = 3 * GameScr.gH / 4;
    GameScr.gW6 = GameScr.gW / 6;
    GameScr.gH6 = GameScr.gH / 6;
    GameScr.gssw = GameScr.gW / (int) TileMap.size + 2;
    GameScr.gssh = GameScr.gH / (int) TileMap.size + 2;
    if (GameScr.gW % 24 != 0)
      ++GameScr.gssw;
    GameScr.cmxLim = (TileMap.tmw - 1) * (int) TileMap.size - GameScr.gW;
    GameScr.cmyLim = (TileMap.tmh - 1) * (int) TileMap.size - GameScr.gH;
    if (cx == -1 && cy == -1)
    {
      GameScr.cmx = GameScr.cmtoX = Char.myCharz().cx - GameScr.gW2 + GameScr.gW6 * Char.myCharz().cdir;
      GameScr.cmy = GameScr.cmtoY = Char.myCharz().cy - GameScr.gH23;
    }
    else
    {
      GameScr.cmx = GameScr.cmtoX = cx - GameScr.gW23 + GameScr.gW6 * Char.myCharz().cdir;
      GameScr.cmy = GameScr.cmtoY = cy - GameScr.gH23;
    }
    GameScr.firstY = GameScr.cmy;
    if (GameScr.cmx < 24)
      GameScr.cmx = GameScr.cmtoX = 24;
    if (GameScr.cmx > GameScr.cmxLim)
      GameScr.cmx = GameScr.cmtoX = GameScr.cmxLim;
    if (GameScr.cmy < 0)
      GameScr.cmy = GameScr.cmtoY = 0;
    if (GameScr.cmy > GameScr.cmyLim)
      GameScr.cmy = GameScr.cmtoY = GameScr.cmyLim;
    GameScr.gssx = GameScr.cmx / (int) TileMap.size - 1;
    if (GameScr.gssx < 0)
      GameScr.gssx = 0;
    GameScr.gssy = GameScr.cmy / (int) TileMap.size;
    GameScr.gssxe = GameScr.gssx + GameScr.gssw;
    GameScr.gssye = GameScr.gssy + GameScr.gssh;
    if (GameScr.gssy < 0)
      GameScr.gssy = 0;
    if (GameScr.gssye > TileMap.tmh - 1)
      GameScr.gssye = TileMap.tmh - 1;
    TileMap.countx = (GameScr.gssxe - GameScr.gssx) * 4;
    if (TileMap.countx > TileMap.tmw)
      TileMap.countx = TileMap.tmw;
    TileMap.county = (GameScr.gssye - GameScr.gssy) * 4;
    if (TileMap.county > TileMap.tmh)
      TileMap.county = TileMap.tmh;
    TileMap.gssx = (Char.myCharz().cx - 2 * GameScr.gW) / (int) TileMap.size;
    if (TileMap.gssx < 0)
      TileMap.gssx = 0;
    TileMap.gssxe = TileMap.gssx + TileMap.countx;
    if (TileMap.gssxe > TileMap.tmw)
      TileMap.gssxe = TileMap.tmw;
    TileMap.gssy = (Char.myCharz().cy - 2 * GameScr.gH) / (int) TileMap.size;
    if (TileMap.gssy < 0)
      TileMap.gssy = 0;
    TileMap.gssye = TileMap.gssy + TileMap.county;
    if (TileMap.gssye > TileMap.tmh)
      TileMap.gssye = TileMap.tmh;
    ChatTextField.gI().parentScreen = (IChatable) GameScr.instance;
    ChatTextField.gI().tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
    ChatTextField.gI().initChatTextField();
    if (GameCanvas.isTouch)
    {
      GameScr.yTouchBar = GameScr.gH - 88;
      GameScr.xC = GameScr.gW - 40;
      GameScr.yC = 2;
      if (GameCanvas.w <= 240)
      {
        GameScr.xC = GameScr.gW - 35;
        GameScr.yC = 5;
      }
      GameScr.xF = GameScr.gW - 55;
      GameScr.yF = GameScr.yTouchBar + 35;
      GameScr.xTG = GameScr.gW - 37;
      GameScr.yTG = GameScr.yTouchBar - 1;
      if (GameCanvas.w >= 450)
      {
        GameScr.yTG -= 12;
        GameScr.yHP -= 7;
        GameScr.xF -= 10;
        GameScr.yF -= 5;
        GameScr.xTG -= 10;
      }
    }
    GameScr.setSkillBarPosition();
    GameScr.disXC = GameCanvas.w <= 200 ? 30 : 40;
    if (Rms.loadRMSInt("viewchat") == -1)
      GameCanvas.panel.isViewChatServer = true;
    else
      GameCanvas.panel.isViewChatServer = Rms.loadRMSInt("viewchat") == 1;
  }

  public static void setSkillBarPosition()
  {
    Skill[] skillArray = !GameCanvas.isTouch ? GameScr.keySkill : GameScr.onScreenSkill;
    GameScr.xS = new int[skillArray.Length];
    GameScr.yS = new int[skillArray.Length];
    if (GameCanvas.isTouchControlSmallScreen && GameScr.isUseTouch)
    {
      GameScr.xSkill = 23;
      GameScr.ySkill = 52;
      GameScr.padSkill = 5;
      for (int index = 0; index < GameScr.xS.Length; ++index)
      {
        GameScr.xS[index] = index * (25 + GameScr.padSkill);
        GameScr.yS[index] = GameScr.ySkill;
        if (GameScr.xS.Length > 5 && index >= GameScr.xS.Length / 2)
        {
          GameScr.xS[index] = (index - GameScr.xS.Length / 2) * (25 + GameScr.padSkill);
          GameScr.yS[index] = GameScr.ySkill - 32;
        }
      }
      GameScr.xHP = skillArray.Length * (25 + GameScr.padSkill);
      GameScr.yHP = GameScr.ySkill;
    }
    else
    {
      GameScr.wSkill = 30;
      if (GameCanvas.w <= 320)
      {
        GameScr.ySkill = GameScr.gH - GameScr.wSkill - 6;
        GameScr.xSkill = GameScr.gW2 - skillArray.Length * GameScr.wSkill / 2 - 25;
      }
      else
      {
        GameScr.wSkill = 40;
        GameScr.xSkill = 10;
        GameScr.ySkill = GameCanvas.h - GameScr.wSkill + 7;
      }
      for (int index = 0; index < GameScr.xS.Length; ++index)
      {
        GameScr.xS[index] = index * GameScr.wSkill;
        GameScr.yS[index] = GameScr.ySkill;
        if (GameScr.xS.Length > 5 && index >= GameScr.xS.Length / 2)
        {
          GameScr.xS[index] = (index - GameScr.xS.Length / 2) * GameScr.wSkill;
          GameScr.yS[index] = GameScr.ySkill - 32;
        }
      }
      GameScr.xHP = skillArray.Length * GameScr.wSkill;
      GameScr.yHP = GameScr.ySkill;
    }
    if (!GameCanvas.isTouch)
      return;
    GameScr.xSkill = 17;
    GameScr.ySkill = GameCanvas.h - 40;
    if (GameScr.gamePad.isSmallGamePad && GameScr.isAnalog == 1)
    {
      GameScr.xHP = skillArray.Length * GameScr.wSkill;
      GameScr.yHP = GameScr.ySkill;
    }
    else
    {
      GameScr.xHP = GameCanvas.w - 45;
      GameScr.yHP = GameCanvas.h - 45;
    }
    GameScr.setTouchBtn();
    for (int index = 0; index < GameScr.xS.Length; ++index)
    {
      GameScr.xS[index] = index * GameScr.wSkill;
      GameScr.yS[index] = GameScr.ySkill;
      if (GameScr.xS.Length > 5 && index >= GameScr.xS.Length / 2)
      {
        GameScr.xS[index] = (index - GameScr.xS.Length / 2) * GameScr.wSkill;
        GameScr.yS[index] = GameScr.ySkill - 32;
      }
    }
  }

  private static void updateCamera()
  {
    if (GameScr.isPaintOther)
      return;
    if (GameScr.cmx != GameScr.cmtoX || GameScr.cmy != GameScr.cmtoY)
    {
      GameScr.cmvx = GameScr.cmtoX - GameScr.cmx << 2;
      GameScr.cmvy = GameScr.cmtoY - GameScr.cmy << 2;
      GameScr.cmdx += GameScr.cmvx;
      GameScr.cmx += GameScr.cmdx >> 4;
      GameScr.cmdx &= 15;
      GameScr.cmdy += GameScr.cmvy;
      GameScr.cmy += GameScr.cmdy >> 4;
      GameScr.cmdy &= 15;
      if (GameScr.cmx < 24)
        GameScr.cmx = 24;
      if (GameScr.cmx > GameScr.cmxLim)
        GameScr.cmx = GameScr.cmxLim;
      if (GameScr.cmy < 0)
        GameScr.cmy = 0;
      if (GameScr.cmy > GameScr.cmyLim)
        GameScr.cmy = GameScr.cmyLim;
    }
    GameScr.gssx = GameScr.cmx / (int) TileMap.size - 1;
    if (GameScr.gssx < 0)
      GameScr.gssx = 0;
    GameScr.gssy = GameScr.cmy / (int) TileMap.size;
    GameScr.gssxe = GameScr.gssx + GameScr.gssw;
    GameScr.gssye = GameScr.gssy + GameScr.gssh;
    if (GameScr.gssy < 0)
      GameScr.gssy = 0;
    if (GameScr.gssye > TileMap.tmh - 1)
      GameScr.gssye = TileMap.tmh - 1;
    TileMap.gssx = (Char.myCharz().cx - 2 * GameScr.gW) / (int) TileMap.size;
    if (TileMap.gssx < 0)
      TileMap.gssx = 0;
    TileMap.gssxe = TileMap.gssx + TileMap.countx;
    if (TileMap.gssxe > TileMap.tmw)
    {
      TileMap.gssxe = TileMap.tmw;
      TileMap.gssx = TileMap.gssxe - TileMap.countx;
    }
    TileMap.gssy = (Char.myCharz().cy - 2 * GameScr.gH) / (int) TileMap.size;
    if (TileMap.gssy < 0)
      TileMap.gssy = 0;
    TileMap.gssye = TileMap.gssy + TileMap.county;
    if (TileMap.gssye > TileMap.tmh)
    {
      TileMap.gssye = TileMap.tmh;
      TileMap.gssy = TileMap.gssye - TileMap.county;
    }
    GameScr.scrMain.updatecm();
    GameScr.scrInfo.updatecm();
  }

  public bool testAct()
  {
    for (sbyte index = 2; index < (sbyte) 9; index += (sbyte) 2)
    {
      if (GameCanvas.keyHold[(int) index])
        return false;
    }
    return true;
  }

  public void clanInvite(string strInvite, int clanID, int code)
  {
    ClanObject p = new ClanObject();
    p.code = code;
    p.clanID = clanID;
    this.startYesNoPopUp(strInvite, new Command(mResources.YES, 12002, (object) p), new Command(mResources.NO, 12003, (object) p));
  }

  public void playerMenu(Char c)
  {
    this.auto = 0;
    GameCanvas.clearKeyHold();
    if (Char.myCharz().charFocus.charID < 0 || Char.myCharz().charID < 0)
      return;
    MyVector vPlayerMenu = GameCanvas.panel.vPlayerMenu;
    if (vPlayerMenu.size() > 0)
      return;
    if (Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.taskId > (short) 1)
    {
      vPlayerMenu.addElement((object) new Command(mResources.make_friend, 11112, (object) Char.myCharz().charFocus));
      vPlayerMenu.addElement((object) new Command(mResources.trade, 11113, (object) Char.myCharz().charFocus));
    }
    if (Char.myCharz().clan != null && Char.myCharz().role < (sbyte) 2 && Char.myCharz().charFocus.clanID == -1)
      vPlayerMenu.addElement((object) new Command(mResources.CHAR_ORDER[4], 110391));
    if (Char.myCharz().charFocus.statusMe != 14 && Char.myCharz().charFocus.statusMe != 5)
    {
      if (Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.taskId >= (short) 14)
        vPlayerMenu.addElement((object) new Command(mResources.CHAR_ORDER[0], 2003));
    }
    else if (Char.myCharz().myskill.template.type != 4)
      ;
    if (Char.myCharz().clan != null && Char.myCharz().clan.ID == Char.myCharz().charFocus.clanID && Char.myCharz().charFocus.statusMe != 14 && Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.taskId >= (short) 14)
      vPlayerMenu.addElement((object) new Command(mResources.CHAR_ORDER[1], 2004));
    int length = Char.myCharz().nClass.skillTemplates.Length;
    for (int index = 0; index < length; ++index)
    {
      SkillTemplate skillTemplate = Char.myCharz().nClass.skillTemplates[index];
      Skill skill = Char.myCharz().getSkill(skillTemplate);
      if (skill != null && skillTemplate.isBuffToPlayer() && skill.point >= 1)
        vPlayerMenu.addElement((object) new Command(skillTemplate.name, 12004, (object) skill));
    }
  }

  public bool isAttack()
  {
    if (this.checkClickToBotton((IMapObject) Char.myCharz().charFocus) || this.checkClickToBotton((IMapObject) Char.myCharz().mobFocus) || this.checkClickToBotton((IMapObject) Char.myCharz().npcFocus) || ChatTextField.gI().isShow || InfoDlg.isLock || Char.myCharz().isLockAttack || Char.isLockKey)
      return false;
    if (Char.myCharz().myskill != null && Char.myCharz().myskill.template.id == (sbyte) 6 && Char.myCharz().itemFocus != null)
    {
      this.pickItem();
      return false;
    }
    if (Char.myCharz().myskill != null && Char.myCharz().myskill.template.type == 2 && Char.myCharz().npcFocus == null && Char.myCharz().myskill.template.id != (sbyte) 6)
      return this.checkSkillValid();
    if (Char.myCharz().skillPaint != null || Char.myCharz().mobFocus == null && Char.myCharz().npcFocus == null && Char.myCharz().charFocus == null && Char.myCharz().itemFocus == null)
      return false;
    if (Char.myCharz().mobFocus != null)
    {
      if (Char.myCharz().mobFocus.isBigBoss() && Char.myCharz().mobFocus.status == 4)
      {
        Char.myCharz().mobFocus = (Mob) null;
        Char.myCharz().currentMovePoint = (MovePoint) null;
      }
      GameScr.isAutoPlay = true;
      if (!this.isMeCanAttackMob(Char.myCharz().mobFocus))
      {
        Res.outz("can not attack");
        return false;
      }
      if (this.mobCapcha != null || Char.myCharz().myskill == null || Char.myCharz().isSelectingSkillUseAlone() || Char.myCharz().mobFocus.status == 1 || Char.myCharz().mobFocus.status == 0 || Char.myCharz().myskill.template.type == 4 || !this.checkSkillValid())
        return false;
      Char.myCharz().cdir = Char.myCharz().cx >= Char.myCharz().mobFocus.getX() ? -1 : 1;
      int num1 = Math.abs(Char.myCharz().cx - Char.myCharz().mobFocus.getX());
      int num2 = Math.abs(Char.myCharz().cy - Char.myCharz().mobFocus.getY());
      Char.myCharz().cvx = 0;
      if (num1 <= Char.myCharz().myskill.dx && num2 <= Char.myCharz().myskill.dy)
      {
        if (Char.myCharz().myskill.template.id == (sbyte) 20)
          return true;
        if (num2 > num1 && Res.abs(Char.myCharz().cy - Char.myCharz().mobFocus.getY()) > 30 && Char.myCharz().mobFocus.getTemplate().type == (sbyte) 4)
        {
          Char.myCharz().currentMovePoint = new MovePoint(Char.myCharz().cx + Char.myCharz().cdir, Char.myCharz().mobFocus.getY());
          Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) null, 8002, (object) null);
          GameCanvas.clearKeyHold();
          GameCanvas.clearKeyPressed();
          return false;
        }
        int num3 = 20;
        bool flag1 = false;
        if (Char.myCharz().mobFocus is BigBoss || Char.myCharz().mobFocus is BigBoss2)
          flag1 = true;
        if (Char.myCharz().myskill.dx > 100)
        {
          num3 = 60;
          if (num1 < 20)
            Char.myCharz().createShadow(Char.myCharz().cx, Char.myCharz().cy, 10);
        }
        bool flag2 = false;
        if ((TileMap.tileTypeAtPixel(Char.myCharz().cx, Char.myCharz().cy + 3) & 2) == 2)
        {
          int num4 = Char.myCharz().cx <= Char.myCharz().mobFocus.getX() ? -1 : 1;
          if ((TileMap.tileTypeAtPixel(Char.myCharz().mobFocus.getX() + num3 * num4, Char.myCharz().cy + 3) & 2) != 2)
            flag2 = true;
        }
        if (num1 <= num3 && !flag2)
        {
          if (num1 < 30)
          {
            if (Char.myCharz().cx > Char.myCharz().mobFocus.getX())
            {
              Char.myCharz().cx = Char.myCharz().mobFocus.getX() + num3 + (!flag1 ? 0 : 30);
              Char.myCharz().cdir = -1;
            }
            else
            {
              Char.myCharz().cx = Char.myCharz().mobFocus.getX() - num3 - (!flag1 ? 0 : 30);
              Char.myCharz().cdir = 1;
            }
            Service.gI().charMove();
          }
          else
          {
            int num5 = Char.myCharz().cx <= Char.myCharz().mobFocus.getX() ? -num3 : num3;
            Char.myCharz().currentMovePoint = new MovePoint(Char.myCharz().cx + num5, Char.myCharz().cy);
            Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) null, 8002, (object) null);
            GameCanvas.clearKeyHold();
            GameCanvas.clearKeyPressed();
            return false;
          }
        }
        GameCanvas.clearKeyHold();
        GameCanvas.clearKeyPressed();
        return true;
      }
      bool flag = false;
      if (Char.myCharz().mobFocus is BigBoss || Char.myCharz().mobFocus is BigBoss2)
        flag = true;
      int num6 = (Char.myCharz().myskill.dx - (!flag ? 20 : 50)) * (Char.myCharz().cx <= Char.myCharz().mobFocus.getX() ? -1 : 1);
      if (num1 <= Char.myCharz().myskill.dx)
        num6 = 0;
      Char.myCharz().currentMovePoint = new MovePoint(Char.myCharz().mobFocus.getX() + num6, Char.myCharz().mobFocus.getY());
      Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) null, 8002, (object) null);
      GameCanvas.clearKeyHold();
      GameCanvas.clearKeyPressed();
      return false;
    }
    if (Char.myCharz().npcFocus != null)
    {
      if (Char.myCharz().npcFocus.isHide)
        return false;
      Char.myCharz().cdir = Char.myCharz().cx >= Char.myCharz().npcFocus.cx ? -1 : 1;
      if (Char.myCharz().cx < Char.myCharz().npcFocus.cx)
        Char.myCharz().npcFocus.cdir = -1;
      else
        Char.myCharz().npcFocus.cdir = 1;
      int num7 = Math.abs(Char.myCharz().cx - Char.myCharz().npcFocus.cx);
      if (Math.abs(Char.myCharz().cy - Char.myCharz().npcFocus.cy) > 40)
        Char.myCharz().cy = Char.myCharz().npcFocus.cy - 40;
      if (num7 < 60)
      {
        GameCanvas.clearKeyHold();
        GameCanvas.clearKeyPressed();
        if (this.tMenuDelay == 0 && (Char.myCharz().taskMaint == null || Char.myCharz().taskMaint.taskId != (short) 0 || (Char.myCharz().taskMaint.index >= 4 || Char.myCharz().npcFocus.template.npcTemplateId != 4) && (Char.myCharz().taskMaint.index >= 3 || Char.myCharz().npcFocus.template.npcTemplateId != 3)))
        {
          this.tMenuDelay = 50;
          InfoDlg.showWait();
          Service.gI().charMove();
          Service.gI().openMenu(Char.myCharz().npcFocus.template.npcTemplateId);
        }
      }
      else
      {
        int num8 = (20 + Res.r.nextInt(20)) * (Char.myCharz().cx <= Char.myCharz().npcFocus.cx ? -1 : 1);
        Char.myCharz().currentMovePoint = new MovePoint(Char.myCharz().npcFocus.cx + num8, Char.myCharz().cy);
        Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) null, 8002, (object) null);
        GameCanvas.clearKeyHold();
        GameCanvas.clearKeyPressed();
      }
      return false;
    }
    if (Char.myCharz().charFocus != null)
    {
      if (this.mobCapcha != null)
        return false;
      Char.myCharz().cdir = Char.myCharz().cx >= Char.myCharz().charFocus.cx ? -1 : 1;
      int num9 = Math.abs(Char.myCharz().cx - Char.myCharz().charFocus.cx);
      int num10 = Math.abs(Char.myCharz().cy - Char.myCharz().charFocus.cy);
      if (Char.myCharz().isMeCanAttackOtherPlayer(Char.myCharz().charFocus) || Char.myCharz().isSelectingSkillBuffToPlayer())
      {
        if (Char.myCharz().myskill == null || !this.checkSkillValid())
          return false;
        Char.myCharz().cdir = Char.myCharz().cx >= Char.myCharz().charFocus.cx ? -1 : 1;
        Char.myCharz().cvx = 0;
        if (num9 <= Char.myCharz().myskill.dx && num10 <= Char.myCharz().myskill.dy)
        {
          if (Char.myCharz().myskill.template.id == (sbyte) 20)
            return true;
          int num11 = 20;
          if (Char.myCharz().myskill.dx > 60)
          {
            num11 = 60;
            if (num9 < 20)
              Char.myCharz().createShadow(Char.myCharz().cx, Char.myCharz().cy, 10);
          }
          bool flag = false;
          if ((TileMap.tileTypeAtPixel(Char.myCharz().cx, Char.myCharz().cy + 3) & 2) == 2)
          {
            int num12 = Char.myCharz().cx <= Char.myCharz().charFocus.cx ? -1 : 1;
            if ((TileMap.tileTypeAtPixel(Char.myCharz().charFocus.cx + num11 * num12, Char.myCharz().cy + 3) & 2) != 2)
              flag = true;
          }
          if (num9 <= num11 && !flag)
          {
            if (Char.myCharz().cx > Char.myCharz().charFocus.cx)
            {
              Char.myCharz().cx = Char.myCharz().charFocus.cx + num11;
              Char.myCharz().cdir = -1;
            }
            else
            {
              Char.myCharz().cx = Char.myCharz().charFocus.cx - num11;
              Char.myCharz().cdir = 1;
            }
            Service.gI().charMove();
          }
          GameCanvas.clearKeyHold();
          GameCanvas.clearKeyPressed();
          return true;
        }
        int num13 = (Char.myCharz().myskill.dx - 20) * (Char.myCharz().cx <= Char.myCharz().charFocus.cx ? -1 : 1);
        if (num9 <= Char.myCharz().myskill.dx)
          num13 = 0;
        Char.myCharz().currentMovePoint = new MovePoint(Char.myCharz().charFocus.cx + num13, Char.myCharz().charFocus.cy);
        Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) null, 8002, (object) null);
        GameCanvas.clearKeyHold();
        GameCanvas.clearKeyPressed();
        return false;
      }
      if (num9 < 60 && num10 < 40)
      {
        this.playerMenu(Char.myCharz().charFocus);
        if (!GameCanvas.isTouch && Char.myCharz().charFocus.charID >= 0 && TileMap.mapID != 51 && TileMap.mapID != 52 && this.popUpYesNo == null)
        {
          GameCanvas.panel.setTypePlayerMenu(Char.myCharz().charFocus);
          GameCanvas.panel.show();
          Service.gI().getPlayerMenu(Char.myCharz().charFocus.charID);
          Service.gI().messagePlayerMenu(Char.myCharz().charFocus.charID);
        }
      }
      else
      {
        int num14 = (20 + Res.r.nextInt(20)) * (Char.myCharz().cx <= Char.myCharz().charFocus.cx ? -1 : 1);
        Char.myCharz().currentMovePoint = new MovePoint(Char.myCharz().charFocus.cx + num14, Char.myCharz().charFocus.cy);
        Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) null, 8002, (object) null);
        GameCanvas.clearKeyHold();
        GameCanvas.clearKeyPressed();
      }
      return false;
    }
    if (Char.myCharz().itemFocus == null)
      return true;
    this.pickItem();
    return false;
  }

  public bool isMeCanAttackMob(Mob m)
  {
    if (m == null)
      return false;
    if (Char.myCharz().cTypePk == (sbyte) 5)
      return true;
    if (Char.myCharz().isAttacPlayerStatus() && !m.isMobMe || Char.myCharz().mobMe != null && m.Equals((object) Char.myCharz().mobMe))
      return false;
    Char charInMap = GameScr.findCharInMap(m.mobId);
    return charInMap == null || charInMap.cTypePk == (sbyte) 5 || Char.myCharz().isMeCanAttackOtherPlayer(charInMap);
  }

  private bool checkSkillValid()
  {
    if (Char.myCharz().myskill != null && (Char.myCharz().myskill.template.manaUseType != 1 && Char.myCharz().cMP < Char.myCharz().myskill.manaUse || Char.myCharz().myskill.template.manaUseType == 1 && Char.myCharz().cMP < Char.myCharz().cMPFull * Char.myCharz().myskill.manaUse / 100))
    {
      GameScr.info1.addInfo(mResources.NOT_ENOUGH_MP, 0);
      this.auto = 0;
      return false;
    }
    if (Char.myCharz().myskill != null && (Char.myCharz().myskill.template.maxPoint <= 0 || Char.myCharz().myskill.point != 0))
      return true;
    GameCanvas.startOKDlg(mResources.SKILL_FAIL);
    return false;
  }

  private bool checkSkillValid2() => (Char.myCharz().myskill == null || (Char.myCharz().myskill.template.manaUseType == 1 || Char.myCharz().cMP >= Char.myCharz().myskill.manaUse) && (Char.myCharz().myskill.template.manaUseType != 1 || Char.myCharz().cMP >= Char.myCharz().cMPFull * Char.myCharz().myskill.manaUse / 100)) && Char.myCharz().myskill != null && (Char.myCharz().myskill.template.maxPoint <= 0 || Char.myCharz().myskill.point != 0);

  public void resetButton()
  {
    GameCanvas.menu.showMenu = false;
    ChatTextField.gI().close();
    ChatTextField.gI().center = (Command) null;
    this.isLockKey = false;
    this.typeTrade = 0;
    GameScr.indexMenu = 0;
    GameScr.indexSelect = 0;
    this.indexItemUse = -1;
    GameScr.indexRow = -1;
    GameScr.indexRowMax = 0;
    GameScr.indexTitle = 0;
    this.typeTrade = this.typeTradeOrder = 0;
    mSystem.endKey();
    if (Char.myCharz().cHP <= 0 || Char.myCharz().statusMe == 14 || Char.myCharz().statusMe == 5)
    {
      if (Char.myCharz().meDead)
      {
        this.cmdDead = new Command(mResources.DIES[0], 11038);
        this.center = this.cmdDead;
        Char.myCharz().cHP = 0;
      }
      GameScr.isHaveSelectSkill = false;
    }
    else
      GameScr.isHaveSelectSkill = true;
    GameScr.scrMain.clear();
  }

  public override void keyPress(int keyCode) => base.keyPress(keyCode);

  public override void updateKey()
  {
    if (Controller.isStopReadMessage || Char.myCharz().isTeleport || InfoDlg.isLock)
      return;
    if (GameCanvas.isTouch && !ChatTextField.gI().isShow && !GameCanvas.menu.showMenu)
      this.updateKeyTouchControl();
    this.checkAuto();
    GameCanvas.debug("F2", 0);
    if (ChatPopup.currChatPopup != null)
    {
      Command cmdNextLine = ChatPopup.currChatPopup.cmdNextLine;
      if ((GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(cmdNextLine)) && cmdNextLine != null)
      {
        GameCanvas.isPointerJustRelease = false;
        GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
        mScreen.keyTouch = -1;
        cmdNextLine?.performAction();
      }
    }
    else if (!ChatTextField.gI().isShow)
    {
      if ((GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.left)) && this.left != null)
      {
        GameCanvas.isPointerJustRelease = false;
        GameCanvas.isPointerClick = false;
        GameCanvas.keyPressed[12] = false;
        mScreen.keyTouch = -1;
        if (this.left != null)
          this.left.performAction();
      }
      if ((GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.right)) && this.right != null)
      {
        GameCanvas.isPointerJustRelease = false;
        GameCanvas.isPointerClick = false;
        GameCanvas.keyPressed[13] = false;
        mScreen.keyTouch = -1;
        if (this.right != null)
          this.right.performAction();
      }
      if ((GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.center)) && this.center != null)
      {
        GameCanvas.isPointerJustRelease = false;
        GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
        mScreen.keyTouch = -1;
        if (this.center != null)
          this.center.performAction();
      }
    }
    else
    {
      if (ChatTextField.gI().left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(ChatTextField.gI().left)) && ChatTextField.gI().left != null)
        ChatTextField.gI().left.performAction();
      if (ChatTextField.gI().right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(ChatTextField.gI().right)) && ChatTextField.gI().right != null)
        ChatTextField.gI().right.performAction();
      if (ChatTextField.gI().center != null && (GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(ChatTextField.gI().center)) && ChatTextField.gI().center != null)
        ChatTextField.gI().center.performAction();
    }
    GameCanvas.debug("F6", 0);
    this.updateKeyAlert();
    GameCanvas.debug("F7", 0);
    if (Char.myCharz().currentMovePoint != null)
    {
      for (int index = 0; index < GameCanvas.keyPressed.Length; ++index)
      {
        if (GameCanvas.keyPressed[index])
        {
          Char.myCharz().currentMovePoint = (MovePoint) null;
          break;
        }
      }
    }
    GameCanvas.debug("F8", 0);
    if (ChatTextField.gI().isShow && GameCanvas.keyAsciiPress != 0)
    {
      ChatTextField.gI().keyPressed(GameCanvas.keyAsciiPress);
      GameCanvas.keyAsciiPress = 0;
    }
    else if (this.isLockKey)
    {
      GameCanvas.clearKeyHold();
      GameCanvas.clearKeyPressed();
    }
    else
    {
      if (GameCanvas.menu.showMenu || this.isOpenUI() || Char.isLockKey)
        return;
      if (GameCanvas.keyPressed[10])
      {
        GameCanvas.keyPressed[10] = false;
        this.doUseHP();
        GameCanvas.clearKeyPressed();
      }
      if (GameCanvas.keyPressed[11] && this.mobCapcha == null)
      {
        if (this.popUpYesNo != null)
          this.popUpYesNo.cmdYes.performAction();
        else if (GameScr.info2.info.info != null && GameScr.info2.info.info.charInfo != null)
        {
          GameCanvas.panel.setTypeMessage();
          GameCanvas.panel.show();
        }
        GameCanvas.keyPressed[11] = false;
        GameCanvas.clearKeyPressed();
      }
      if (GameCanvas.keyAsciiPress != 0 && TField.isQwerty && GameCanvas.keyAsciiPress == 32)
      {
        this.doUseHP();
        GameCanvas.keyAsciiPress = 0;
        GameCanvas.clearKeyPressed();
      }
      if (GameCanvas.keyAsciiPress != 0 && this.mobCapcha == null && TField.isQwerty && GameCanvas.keyAsciiPress == 121)
      {
        if (this.popUpYesNo != null)
        {
          this.popUpYesNo.cmdYes.performAction();
          GameCanvas.keyAsciiPress = 0;
          GameCanvas.clearKeyPressed();
        }
        else if (GameScr.info2.info.info != null && GameScr.info2.info.info.charInfo != null)
        {
          GameCanvas.panel.setTypeMessage();
          GameCanvas.panel.show();
          GameCanvas.keyAsciiPress = 0;
          GameCanvas.clearKeyPressed();
        }
      }
      if (GameCanvas.keyPressed[10] && this.mobCapcha == null)
      {
        GameCanvas.keyPressed[10] = false;
        GameScr.info2.doClick(10);
        GameCanvas.clearKeyPressed();
      }
      this.checkDrag();
      if (!Char.myCharz().isFlyAndCharge)
        this.checkClick();
      if (Char.myCharz().cmdMenu != null && Char.myCharz().cmdMenu.isPointerPressInside())
        Char.myCharz().cmdMenu.performAction();
      if (Char.myCharz().skillPaint != null)
        return;
      if (GameCanvas.keyAsciiPress != 0)
      {
        if (this.mobCapcha == null)
        {
          if (TField.isQwerty)
          {
            if (GameCanvas.keyPressed[1])
            {
              if (GameScr.keySkill[0] != null)
                this.doSelectSkill(GameScr.keySkill[0], true);
            }
            else if (GameCanvas.keyPressed[2])
            {
              if (GameScr.keySkill[1] != null)
                this.doSelectSkill(GameScr.keySkill[1], true);
            }
            else if (GameCanvas.keyPressed[3])
            {
              if (GameScr.keySkill[2] != null)
                this.doSelectSkill(GameScr.keySkill[2], true);
            }
            else if (GameCanvas.keyPressed[4])
            {
              if (GameScr.keySkill[3] != null)
                this.doSelectSkill(GameScr.keySkill[3], true);
            }
            else if (GameCanvas.keyPressed[5])
            {
              if (GameScr.keySkill[4] != null)
                this.doSelectSkill(GameScr.keySkill[4], true);
            }
            else if (GameCanvas.keyPressed[6])
            {
              if (GameScr.keySkill[5] != null)
                this.doSelectSkill(GameScr.keySkill[5], true);
            }
            else if (GameCanvas.keyPressed[7])
            {
              if (GameScr.keySkill[6] != null)
                this.doSelectSkill(GameScr.keySkill[6], true);
            }
            else if (GameCanvas.keyPressed[8])
            {
              if (GameScr.keySkill[7] != null)
                this.doSelectSkill(GameScr.keySkill[7], true);
            }
            else if (GameCanvas.keyPressed[9])
            {
              if (GameScr.keySkill[8] != null)
                this.doSelectSkill(GameScr.keySkill[8], true);
            }
            else if (GameCanvas.keyPressed[0])
            {
              if (GameScr.keySkill[9] != null)
                this.doSelectSkill(GameScr.keySkill[9], true);
            }
            else if (GameCanvas.keyAsciiPress == 114)
              ChatTextField.gI().startChat((IChatable) this, string.Empty);
          }
          else if (!GameCanvas.isMoveNumberPad)
          {
            ChatTextField.gI().startChat(GameCanvas.keyAsciiPress, (IChatable) this, string.Empty);
          }
          else
          {
            switch (GameCanvas.keyAsciiPress)
            {
              case 48:
                ChatTextField.gI().startChat((IChatable) this, string.Empty);
                break;
              case 55:
                if (GameScr.keySkill[0] != null)
                {
                  this.doSelectSkill(GameScr.keySkill[0], true);
                  break;
                }
                break;
              case 56:
                if (GameScr.keySkill[1] != null)
                {
                  this.doSelectSkill(GameScr.keySkill[1], true);
                  break;
                }
                break;
              case 57:
                if (GameScr.keySkill[!Main.isPC ? 2 : 21] != null)
                {
                  this.doSelectSkill(GameScr.keySkill[2], true);
                  break;
                }
                break;
            }
          }
        }
        else
        {
          char[] charArray = this.keyInput.ToCharArray();
          MyVector myVector = new MyVector();
          for (int index = 0; index < charArray.Length; ++index)
            myVector.addElement((object) (charArray[index].ToString() + string.Empty));
          myVector.removeElementAt(0);
          string o = ((char) GameCanvas.keyAsciiPress).ToString() + string.Empty;
          if (o.Equals(string.Empty) || o == null || o.Equals("\n"))
            o = "-";
          myVector.insertElementAt((object) o, myVector.size());
          this.keyInput = string.Empty;
          for (int index = 0; index < myVector.size(); ++index)
            this.keyInput += ((string) myVector.elementAt(index)).ToUpper();
          Service.gI().mobCapcha((char) GameCanvas.keyAsciiPress);
        }
        GameCanvas.keyAsciiPress = 0;
      }
      if (Char.myCharz().statusMe == 1)
      {
        GameCanvas.debug("F10", 0);
        if (!this.doSeleckSkillFlag)
        {
          if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
          {
            GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
            this.doFire(false, false);
          }
          else if (GameCanvas.keyHold[!Main.isPC ? 2 : 21])
          {
            if (!Char.myCharz().isLockMove)
              this.setCharJump(0);
          }
          else if (GameCanvas.keyHold[1] && this.mobCapcha == null)
          {
            if (!Main.isPC)
            {
              Char.myCharz().cdir = -1;
              if (!Char.myCharz().isLockMove)
                this.setCharJump(-4);
            }
          }
          else if (GameCanvas.keyHold[!Main.isPC ? 5 : 25] && this.mobCapcha == null)
          {
            if (!Main.isPC)
            {
              Char.myCharz().cdir = 1;
              if (!Char.myCharz().isLockMove)
                this.setCharJump(4);
            }
          }
          else if (GameCanvas.keyHold[!Main.isPC ? 4 : 23])
          {
            GameScr.isAutoPlay = false;
            Char.myCharz().isAttack = false;
            if (Char.myCharz().cdir == 1)
              Char.myCharz().cdir = -1;
            else if (!Char.myCharz().isLockMove)
            {
              if (Char.myCharz().cx - Char.myCharz().cxSend != 0)
                Service.gI().charMove();
              Char.myCharz().statusMe = 2;
              Char.myCharz().cvx = -Char.myCharz().cspeed;
            }
            Char.myCharz().holder = false;
          }
          else if (GameCanvas.keyHold[!Main.isPC ? 6 : 24])
          {
            GameScr.isAutoPlay = false;
            Char.myCharz().isAttack = false;
            if (Char.myCharz().cdir == -1)
              Char.myCharz().cdir = 1;
            else if (!Char.myCharz().isLockMove)
            {
              if (Char.myCharz().cx - Char.myCharz().cxSend != 0)
                Service.gI().charMove();
              Char.myCharz().statusMe = 2;
              Char.myCharz().cvx = Char.myCharz().cspeed;
            }
            Char.myCharz().holder = false;
          }
        }
      }
      else if (Char.myCharz().statusMe == 2)
      {
        GameCanvas.debug("F11", 0);
        if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
        {
          GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
          this.doFire(false, true);
        }
        else if (GameCanvas.keyHold[!Main.isPC ? 2 : 21])
        {
          if (Char.myCharz().cx - Char.myCharz().cxSend != 0 || Char.myCharz().cy - Char.myCharz().cySend != 0)
            Service.gI().charMove();
          Char.myCharz().cvy = -10;
          Char.myCharz().statusMe = 3;
          Char.myCharz().cp1 = 0;
        }
        else if (GameCanvas.keyHold[1] && this.mobCapcha == null)
        {
          if (Main.isPC)
          {
            if (Char.myCharz().cx - Char.myCharz().cxSend != 0 || Char.myCharz().cy - Char.myCharz().cySend != 0)
              Service.gI().charMove();
            Char.myCharz().cdir = -1;
            Char.myCharz().cvy = -10;
            Char.myCharz().cvx = -4;
            Char.myCharz().statusMe = 3;
            Char.myCharz().cp1 = 0;
          }
        }
        else if (GameCanvas.keyHold[3] && this.mobCapcha == null)
        {
          if (!Main.isPC)
          {
            if (Char.myCharz().cx - Char.myCharz().cxSend != 0 || Char.myCharz().cy - Char.myCharz().cySend != 0)
              Service.gI().charMove();
            Char.myCharz().cdir = 1;
            Char.myCharz().cvy = -10;
            Char.myCharz().cvx = 4;
            Char.myCharz().statusMe = 3;
            Char.myCharz().cp1 = 0;
          }
        }
        else if (GameCanvas.keyHold[!Main.isPC ? 4 : 23])
        {
          GameScr.isAutoPlay = false;
          if (Char.myCharz().cdir == 1)
            Char.myCharz().cdir = -1;
          else
            Char.myCharz().cvx = -Char.myCharz().cspeed + Char.myCharz().cBonusSpeed;
        }
        else if (GameCanvas.keyHold[!Main.isPC ? 6 : 24])
        {
          GameScr.isAutoPlay = false;
          if (Char.myCharz().cdir == -1)
            Char.myCharz().cdir = 1;
          else
            Char.myCharz().cvx = Char.myCharz().cspeed + Char.myCharz().cBonusSpeed;
        }
      }
      else if (Char.myCharz().statusMe == 3)
      {
        GameScr.isAutoPlay = false;
        GameCanvas.debug("F12", 0);
        if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
        {
          GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
          this.doFire(false, true);
        }
        if (GameCanvas.keyHold[!Main.isPC ? 4 : 23] || GameCanvas.keyHold[1] && this.mobCapcha == null)
        {
          if (Char.myCharz().cdir == 1)
            Char.myCharz().cdir = -1;
          else
            Char.myCharz().cvx = -Char.myCharz().cspeed;
        }
        else if (GameCanvas.keyHold[!Main.isPC ? 6 : 24] || GameCanvas.keyHold[3] && this.mobCapcha == null)
        {
          if (Char.myCharz().cdir == -1)
            Char.myCharz().cdir = 1;
          else
            Char.myCharz().cvx = Char.myCharz().cspeed;
        }
        if ((GameCanvas.keyHold[!Main.isPC ? 2 : 21] || (GameCanvas.keyHold[1] || GameCanvas.keyHold[3]) && this.mobCapcha == null) && Char.myCharz().canFly && Char.myCharz().cMP > 0 && Char.myCharz().cp1 < 8 && Char.myCharz().cvy > -4)
        {
          ++Char.myCharz().cp1;
          Char.myCharz().cvy = -7;
        }
      }
      else if (Char.myCharz().statusMe == 4)
      {
        GameCanvas.debug("F13", 0);
        if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
        {
          GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
          this.doFire(false, true);
        }
        if (GameCanvas.keyHold[!Main.isPC ? 2 : 21] && Char.myCharz().cMP > 0 && Char.myCharz().canFly)
        {
          GameScr.isAutoPlay = false;
          if ((Char.myCharz().cx - Char.myCharz().cxSend != 0 || Char.myCharz().cy - Char.myCharz().cySend != 0) && (Res.abs(Char.myCharz().cx - Char.myCharz().cxSend) > 96 || Res.abs(Char.myCharz().cy - Char.myCharz().cySend) > 24))
            Service.gI().charMove();
          Char.myCharz().cvy = -10;
          Char.myCharz().statusMe = 3;
          Char.myCharz().cp1 = 0;
        }
        if (GameCanvas.keyHold[!Main.isPC ? 4 : 23])
        {
          GameScr.isAutoPlay = false;
          if (Char.myCharz().cdir == 1)
          {
            Char.myCharz().cdir = -1;
          }
          else
          {
            ++Char.myCharz().cp1;
            Char.myCharz().cvx = -Char.myCharz().cspeed;
            if (Char.myCharz().cp1 > 5 && Char.myCharz().cvy > 6)
            {
              Char.myCharz().statusMe = 10;
              Char.myCharz().cp1 = 0;
              Char.myCharz().cvy = 0;
            }
          }
        }
        else if (GameCanvas.keyHold[!Main.isPC ? 6 : 24])
        {
          GameScr.isAutoPlay = false;
          if (Char.myCharz().cdir == -1)
          {
            Char.myCharz().cdir = 1;
          }
          else
          {
            ++Char.myCharz().cp1;
            Char.myCharz().cvx = Char.myCharz().cspeed;
            if (Char.myCharz().cp1 > 5 && Char.myCharz().cvy > 6)
            {
              Char.myCharz().statusMe = 10;
              Char.myCharz().cp1 = 0;
              Char.myCharz().cvy = 0;
            }
          }
        }
      }
      else if (Char.myCharz().statusMe == 10)
      {
        GameCanvas.debug("F14", 0);
        if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
        {
          GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
          this.doFire(false, true);
        }
        if (Char.myCharz().canFly && Char.myCharz().cMP > 0)
        {
          if (GameCanvas.keyHold[!Main.isPC ? 2 : 21])
          {
            GameScr.isAutoPlay = false;
            if ((Char.myCharz().cx - Char.myCharz().cxSend != 0 || Char.myCharz().cy - Char.myCharz().cySend != 0) && (Res.abs(Char.myCharz().cx - Char.myCharz().cxSend) > 96 || Res.abs(Char.myCharz().cy - Char.myCharz().cySend) > 24))
              Service.gI().charMove();
            Char.myCharz().cvy = -10;
            Char.myCharz().statusMe = 3;
            Char.myCharz().cp1 = 0;
          }
          else if (GameCanvas.keyHold[!Main.isPC ? 4 : 23])
          {
            GameScr.isAutoPlay = false;
            if (Char.myCharz().cdir == 1)
              Char.myCharz().cdir = -1;
            else
              Char.myCharz().cvx = -(Char.myCharz().cspeed + 1);
          }
          else if (GameCanvas.keyHold[!Main.isPC ? 6 : 24])
          {
            if (Char.myCharz().cdir == -1)
              Char.myCharz().cdir = 1;
            else
              Char.myCharz().cvx = Char.myCharz().cspeed + 1;
          }
        }
      }
      else if (Char.myCharz().statusMe == 7)
      {
        GameCanvas.debug("F15", 0);
        if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
          GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
        if (GameCanvas.keyHold[!Main.isPC ? 4 : 23])
        {
          GameScr.isAutoPlay = false;
          if (Char.myCharz().cdir == 1)
            Char.myCharz().cdir = -1;
          else
            Char.myCharz().cvx = -Char.myCharz().cspeed + 2;
        }
        else if (GameCanvas.keyHold[!Main.isPC ? 6 : 24])
        {
          GameScr.isAutoPlay = false;
          if (Char.myCharz().cdir == -1)
            Char.myCharz().cdir = 1;
          else
            Char.myCharz().cvx = Char.myCharz().cspeed - 2;
        }
      }
      GameCanvas.debug("F17", 0);
      if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22] && GameCanvas.keyAsciiPress != 56)
      {
        GameCanvas.keyPressed[!Main.isPC ? 8 : 22] = false;
        Char.myCharz().delayFall = 0;
      }
      if (GameCanvas.keyPressed[10])
      {
        GameCanvas.keyPressed[10] = false;
        this.doUseHP();
      }
      GameCanvas.debug("F20", 0);
      GameCanvas.clearKeyPressed();
      GameCanvas.debug("F23", 0);
      this.doSeleckSkillFlag = false;
    }
  }

  public bool isVsMap() => true;

  private void checkDrag()
  {
    if (GameScr.isAnalog == 1 || GameScr.gamePad.disableCheckDrag())
      return;
    Char.myCharz().cmtoChar = true;
    if (GameScr.isUseTouch)
      return;
    if (GameCanvas.isPointerJustDown)
    {
      GameCanvas.isPointerJustDown = false;
      this.isPointerDowning = true;
      this.ptDownTime = 0;
      this.ptLastDownX = this.ptFirstDownX = GameCanvas.px;
      this.ptLastDownY = this.ptFirstDownY = GameCanvas.py;
    }
    if (this.isPointerDowning)
    {
      int num1 = GameCanvas.px - this.ptLastDownX;
      int num2 = GameCanvas.py - this.ptLastDownY;
      if (!this.isChangingCameraMode && (Res.abs(GameCanvas.px - this.ptFirstDownX) > 15 || Res.abs(GameCanvas.py - this.ptFirstDownY) > 15))
        this.isChangingCameraMode = true;
      this.ptLastDownX = GameCanvas.px;
      this.ptLastDownY = GameCanvas.py;
      ++this.ptDownTime;
      if (this.isChangingCameraMode)
      {
        Char.myCharz().cmtoChar = false;
        GameScr.cmx -= num1;
        GameScr.cmy -= num2;
        if (GameScr.cmx < 24)
        {
          int num3 = (24 - GameScr.cmx) / 3;
          if (num3 != 0)
            GameScr.cmx += num1 - num1 / num3;
        }
        if (GameScr.cmx < (!this.isVsMap() ? 0 : 24))
          GameScr.cmx = !this.isVsMap() ? 0 : 24;
        if (GameScr.cmx > GameScr.cmxLim)
        {
          int num4 = (GameScr.cmx - GameScr.cmxLim) / 3;
          if (num4 != 0)
            GameScr.cmx += num1 - num1 / num4;
        }
        if (GameScr.cmx > GameScr.cmxLim + (!this.isVsMap() ? 24 : 0))
          GameScr.cmx = GameScr.cmxLim + (!this.isVsMap() ? 24 : 0);
        if (GameScr.cmy < 0)
        {
          int num5 = -GameScr.cmy / 3;
          if (num5 != 0)
            GameScr.cmy += num2 - num2 / num5;
        }
        if (GameScr.cmy < -(!this.isVsMap() ? 24 : 0))
          GameScr.cmy = -(!this.isVsMap() ? 24 : 0);
        if (GameScr.cmy > GameScr.cmyLim)
          GameScr.cmy = GameScr.cmyLim;
        GameScr.cmtoX = GameScr.cmx;
        GameScr.cmtoY = GameScr.cmy;
      }
    }
    if (!this.isPointerDowning || !GameCanvas.isPointerJustRelease)
      return;
    this.isPointerDowning = false;
    this.isChangingCameraMode = false;
    if (Res.abs(GameCanvas.px - this.ptFirstDownX) <= 15 && Res.abs(GameCanvas.py - this.ptFirstDownY) <= 15)
      return;
    GameCanvas.isPointerJustRelease = false;
  }

  private void checkClick()
  {
    if (this.isCharging())
      return;
    if (this.popUpYesNo != null && this.popUpYesNo.cmdYes != null && this.popUpYesNo.cmdYes.isPointerPressInside())
    {
      this.popUpYesNo.cmdYes.performAction();
    }
    else
    {
      if (this.checkClickToCapcha())
        return;
      long num = mSystem.currentTimeMillis();
      if (this.lastSingleClick != 0L && num - this.lastSingleClick > 300L)
      {
        this.lastSingleClick = 0L;
        GameCanvas.isPointerJustDown = false;
        if (!this.disableSingleClick)
        {
          this.checkSingleClick();
          GameCanvas.isPointerJustRelease = false;
        }
      }
      if (!GameCanvas.isPointerJustRelease)
        return;
      this.disableSingleClick = this.checkSingleClickEarly();
      if (num - this.lastSingleClick < 300L)
      {
        this.lastSingleClick = 0L;
        this.checkDoubleClick();
      }
      else
      {
        this.lastSingleClick = num;
        this.lastClickCMX = GameScr.cmx;
        this.lastClickCMY = GameScr.cmy;
      }
      GameCanvas.isPointerJustRelease = false;
    }
  }

  private IMapObject findClickToItem(int px, int py)
  {
    IMapObject clickToItem = (IMapObject) null;
    int num1 = 0;
    int num2 = 30;
    MyVector[] myVectorArray = new MyVector[4]
    {
      GameScr.vMob,
      GameScr.vNpc,
      GameScr.vItemMap,
      GameScr.vCharInMap
    };
    for (int index1 = 0; index1 < myVectorArray.Length; ++index1)
    {
      for (int index2 = 0; index2 < myVectorArray[index1].size(); ++index2)
      {
        IMapObject mapObject = (IMapObject) myVectorArray[index1].elementAt(index2);
        if (!mapObject.isInvisible())
        {
          if (mapObject is Mob)
          {
            Mob mob = (Mob) mapObject;
            if (mob.isMobMe && mob.Equals((object) Char.myCharz().mobMe))
              continue;
          }
          int x = mapObject.getX();
          int y = mapObject.getY();
          int w = mapObject.getW();
          int h = mapObject.getH();
          if (this.inRectangle(px, py, x - w / 2 - num2, y - h - num2, w + num2 * 2, h + num2 * 2))
          {
            if (clickToItem == null)
            {
              clickToItem = mapObject;
              num1 = Res.abs(px - x) + Res.abs(py - y);
              if (index1 == 1)
                return clickToItem;
            }
            else
            {
              int num3 = Res.abs(px - x) + Res.abs(py - y);
              if (num3 < num1)
              {
                clickToItem = mapObject;
                num1 = num3;
              }
            }
          }
        }
      }
    }
    return clickToItem;
  }

  private bool inRectangle(int xClick, int yClick, int x, int y, int w, int h) => xClick >= x && xClick <= x + w && yClick >= y && yClick <= y + h;

  private bool checkSingleClickEarly()
  {
    int num1 = GameCanvas.px + GameScr.cmx;
    int num2 = GameCanvas.py + GameScr.cmy;
    Char.myCharz().cancelAttack();
    IMapObject clickToItem = this.findClickToItem(num1, num2);
    if (clickToItem == null)
      return false;
    if (Char.myCharz().isAttacPlayerStatus() && Char.myCharz().charFocus != null && !clickToItem.Equals((object) Char.myCharz().charFocus) && !clickToItem.Equals((object) Char.myCharz().charFocus.mobMe) && clickToItem is Char)
    {
      Char @char = (Char) clickToItem;
      if (@char.cTypePk != (sbyte) 5 && !@char.isAttacPlayerStatus())
      {
        this.checkClickMoveTo(num1, num2);
        return false;
      }
    }
    if ((Char.myCharz().mobFocus == clickToItem || Char.myCharz().itemFocus == clickToItem) && !Main.isPC)
    {
      this.doDoubleClickToObj(clickToItem);
      return true;
    }
    if (TileMap.mapID == 51 && clickToItem.Equals((object) Char.myCharz().npcFocus))
    {
      this.checkClickMoveTo(num1, num2);
      return false;
    }
    if (Char.myCharz().skillPaint != null || Char.myCharz().arr != null || Char.myCharz().dart != null || Char.myCharz().skillInfoPaint() != null)
      return false;
    Char.myCharz().focusManualTo((object) clickToItem);
    clickToItem.stopMoving();
    return false;
  }

  private void checkDoubleClick()
  {
    int num1 = GameCanvas.px + this.lastClickCMX;
    int num2 = GameCanvas.py + this.lastClickCMY;
    int cy = Char.myCharz().cy;
    if (this.isLockKey)
      return;
    IMapObject clickToItem = this.findClickToItem(num1, num2);
    if (clickToItem != null)
    {
      if (clickToItem is Mob && !this.isMeCanAttackMob((Mob) clickToItem))
      {
        this.checkClickMoveTo(num1, num2);
      }
      else
      {
        if (this.checkClickToBotton(clickToItem) || !clickToItem.Equals((object) Char.myCharz().npcFocus) && this.mobCapcha != null)
          return;
        if (Char.myCharz().isAttacPlayerStatus() && Char.myCharz().charFocus != null && !clickToItem.Equals((object) Char.myCharz().charFocus) && !clickToItem.Equals((object) Char.myCharz().charFocus.mobMe) && clickToItem is Char)
        {
          Char @char = (Char) clickToItem;
          if (@char.cTypePk != (sbyte) 5 && !@char.isAttacPlayerStatus())
          {
            this.checkClickMoveTo(num1, num2);
            return;
          }
        }
        if (TileMap.mapID == 51 && clickToItem.Equals((object) Char.myCharz().npcFocus))
          this.checkClickMoveTo(num1, num2);
        else
          this.doDoubleClickToObj(clickToItem);
      }
    }
    else
    {
      if (this.checkClickToPopup(num1, num2) || this.checkClipTopChatPopUp(num1, num2) || Main.isPC)
        return;
      this.checkClickMoveTo(num1, num2);
    }
  }

  private bool checkClickToBotton(IMapObject Object)
  {
    if (Object == null)
      return false;
    int y = Object.getY();
    int cy = Char.myCharz().cy;
    if (y < cy)
    {
      while (y < cy)
      {
        cy -= 5;
        if (TileMap.tileTypeAt(Char.myCharz().cx, cy, 8192))
        {
          this.auto = 0;
          Char.myCharz().cancelAttack();
          Char.myCharz().currentMovePoint = (MovePoint) null;
          return true;
        }
      }
    }
    return false;
  }

  private void doDoubleClickToObj(IMapObject obj)
  {
    if (!obj.Equals((object) Char.myCharz().npcFocus) && this.mobCapcha != null || this.checkClickToBotton(obj))
      return;
    this.checkEffToObj(obj);
    Char.myCharz().cancelAttack();
    Char.myCharz().currentMovePoint = (MovePoint) null;
    Char.myCharz().cvx = Char.myCharz().cvy = 0;
    obj.stopMoving();
    this.auto = 10;
    this.doFire(false, true);
    this.clickToX = obj.getX();
    this.clickToY = obj.getY();
    this.clickOnTileTop = false;
    this.clickMoving = true;
    this.clickMovingRed = true;
    this.clickMovingTimeOut = 20;
    this.clickMovingP1 = 30;
  }

  private void checkSingleClick()
  {
    int xClick = GameCanvas.px + this.lastClickCMX;
    int yClick = GameCanvas.py + this.lastClickCMY;
    if (this.isLockKey || this.checkClickToPopup(xClick, yClick) || this.checkClipTopChatPopUp(xClick, yClick))
      return;
    this.checkClickMoveTo(xClick, yClick);
  }

  private bool checkClipTopChatPopUp(int xClick, int yClick)
  {
    if (this.Equals((object) GameScr.info2) && GameScr.gI().popUpYesNo != null || GameScr.info2.info.info == null || GameScr.info2.info.info.charInfo == null)
      return false;
    int x = Res.abs(GameScr.info2.cmx) + GameScr.info2.info.X - 40;
    int y = Res.abs(GameScr.info2.cmy) + GameScr.info2.info.Y;
    if (!this.inRectangle(xClick - GameScr.cmx, yClick - GameScr.cmy, x, y, 200, GameScr.info2.info.H))
      return false;
    GameScr.info2.doClick(10);
    return true;
  }

  private bool checkClickToPopup(int xClick, int yClick)
  {
    for (int index = 0; index < PopUp.vPopups.size(); ++index)
    {
      PopUp popUp = (PopUp) PopUp.vPopups.elementAt(index);
      if (this.inRectangle(xClick, yClick, popUp.cx, popUp.cy, popUp.cw, popUp.ch))
      {
        if (popUp.cy <= 24 && TileMap.isInAirMap() && Char.myCharz().cTypePk != (sbyte) 0)
          return false;
        if (popUp.isPaint)
        {
          popUp.doClick(10);
          return true;
        }
      }
    }
    return false;
  }

  private void checkClickMoveTo(int xClick, int yClick)
  {
    if (GameScr.gamePad.disableClickMove())
      return;
    Char.myCharz().cancelAttack();
    if (xClick < TileMap.pxw && xClick > TileMap.pxw - 32)
      Char.myCharz().currentMovePoint = new MovePoint(TileMap.pxw, yClick);
    else if (xClick < 32 && xClick > 0)
      Char.myCharz().currentMovePoint = new MovePoint(0, yClick);
    else if (xClick < TileMap.pxw && xClick > TileMap.pxw - 48)
      Char.myCharz().currentMovePoint = new MovePoint(TileMap.pxw, yClick);
    else if (xClick < 48 && xClick > 0)
    {
      Char.myCharz().currentMovePoint = new MovePoint(0, yClick);
    }
    else
    {
      this.clickToX = xClick;
      this.clickToY = yClick;
      this.clickOnTileTop = false;
      Char.myCharz().delayFall = 0;
      int num = !Char.myCharz().canFly || Char.myCharz().cMP <= 0 ? 1000 : 0;
      if (this.clickToY > Char.myCharz().cy && Res.abs(this.clickToX - Char.myCharz().cx) < 12)
        return;
      for (int index = 0; index < 60 + num && this.clickToY + index < TileMap.pxh - 24; index += 24)
      {
        if (TileMap.tileTypeAt(this.clickToX, this.clickToY + index, 2))
        {
          this.clickToY = TileMap.tileYofPixel(this.clickToY + index);
          this.clickOnTileTop = true;
          break;
        }
      }
      for (int index = 0; index < 40 + num; index += 24)
      {
        if (TileMap.tileTypeAt(this.clickToX, this.clickToY - index, 2))
        {
          this.clickToY = TileMap.tileYofPixel(this.clickToY - index);
          this.clickOnTileTop = true;
          break;
        }
      }
      this.clickMoving = true;
      this.clickMovingRed = false;
      this.clickMovingP1 = !this.clickOnTileTop ? 30 : (yClick >= this.clickToY ? this.clickToY : yClick);
      Char.myCharz().delayFall = 0;
      if (!this.clickOnTileTop && this.clickToY < Char.myCharz().cy - 50)
        Char.myCharz().delayFall = 20;
      this.clickMovingTimeOut = 30;
      this.auto = 0;
      if (Char.myCharz().holder)
        Char.myCharz().removeHoleEff();
      Char.myCharz().currentMovePoint = new MovePoint(this.clickToX, this.clickToY);
      Char.myCharz().cdir = Char.myCharz().cx - Char.myCharz().currentMovePoint.xEnd <= 0 ? 1 : -1;
      Char.myCharz().endMovePointCommand = (Command) null;
      GameScr.isAutoPlay = false;
    }
  }

  private void checkAuto()
  {
    long num = mSystem.currentTimeMillis();
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21] || GameCanvas.keyPressed[!Main.isPC ? 4 : 23] || GameCanvas.keyPressed[!Main.isPC ? 6 : 24] || GameCanvas.keyPressed[1] || GameCanvas.keyPressed[3])
    {
      this.auto = 0;
      GameScr.isAutoPlay = false;
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25] && !this.isPaintPopup())
    {
      if (this.auto == 0)
      {
        if (num - this.lastFire < 800L && this.checkSkillValid2() && (Char.myCharz().mobFocus != null || Char.myCharz().charFocus != null && Char.myCharz().isMeCanAttackOtherPlayer(Char.myCharz().charFocus)))
        {
          Res.outz("toi day");
          this.auto = 10;
          GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
        }
      }
      else
      {
        this.auto = 0;
        GameCanvas.keyPressed[!Main.isPC ? 4 : 23] = GameCanvas.keyPressed[!Main.isPC ? 6 : 24] = false;
      }
      this.lastFire = num;
    }
    if (GameCanvas.gameTick % 5 == 0 && this.auto > 0 && Char.myCharz().currentMovePoint == null)
    {
      if (Char.myCharz().myskill != null && (Char.myCharz().myskill.template.isUseAlone() || Char.myCharz().myskill.paintCanNotUseSkill))
        return;
      if (Char.myCharz().mobFocus != null && Char.myCharz().mobFocus.status != 1 && Char.myCharz().mobFocus.status != 0 && Char.myCharz().charFocus == null || Char.myCharz().charFocus != null && Char.myCharz().isMeCanAttackOtherPlayer(Char.myCharz().charFocus))
      {
        if (Char.myCharz().myskill.paintCanNotUseSkill)
          return;
        this.doFire(false, true);
      }
    }
    if (this.auto <= 1)
      return;
    --this.auto;
  }

  public void doUseHP()
  {
    if (Char.myCharz().stone || Char.myCharz().blindEff || Char.myCharz().holdEffID > 0)
      return;
    long num = mSystem.currentTimeMillis();
    if (num - this.lastUsePotion < 10000L)
      return;
    if (!Char.myCharz().doUsePotion())
    {
      GameScr.info1.addInfo(mResources.HP_EMPTY, 0);
    }
    else
    {
      ServerEffect.addServerEffect(11, Char.myCharz(), 5);
      ServerEffect.addServerEffect(104, Char.myCharz(), 4);
      this.lastUsePotion = num;
      SoundMn.gI().eatPeans();
    }
  }

  public void activeSuperPower(int x, int y)
  {
    if (this.isSuperPower)
      return;
    SoundMn.gI().bigeExlode();
    this.isSuperPower = true;
    this.tPower = 0;
    this.dxPower = 0;
    this.xPower = x - GameScr.cmx;
    this.yPower = y - GameScr.cmy;
  }

  public void activeRongThanEff(bool isMe)
  {
    this.activeRongThan = true;
    this.isUseFreez = true;
    this.isMeCallRongThan = true;
    if (!isMe)
      return;
    EffecMn.addEff(new Effect(20, Char.myCharz().cx, Char.myCharz().cy - 77, 2, 8, 1));
  }

  public void hideRongThanEff()
  {
    this.activeRongThan = false;
    this.isUseFreez = true;
    this.isMeCallRongThan = false;
  }

  public void doiMauTroi()
  {
    this.isRongThanXuatHien = true;
    this.mautroi = mGraphics.blendColor(0.4f, 0, GameCanvas.colorTop[GameCanvas.colorTop.Length - 1]);
  }

  public void callRongThan(int x, int y)
  {
    Res.outz("VE RONG THAN O VI TRI x= " + (object) x + " y=" + (object) y);
    this.doiMauTroi();
    EffecMn.addEff(new Effect(!this.isRongNamek ? 17 : 25, x, y - 77, 2, -1, 1));
  }

  public void hideRongThan()
  {
    this.isRongThanXuatHien = false;
    EffecMn.removeEff(17);
    if (!this.isRongNamek)
      return;
    this.isRongNamek = false;
    EffecMn.removeEff(25);
  }

  private void autoPlay()
  {
    if (this.timeSkill > 0)
      --this.timeSkill;
    if (!GameScr.canAutoPlay || GameScr.isChangeZone || Char.myCharz().statusMe == 14 || Char.myCharz().statusMe == 5 || Char.myCharz().isCharge || Char.myCharz().isFlyAndCharge || Char.myCharz().isUseChargeSkill())
      return;
    bool flag1 = false;
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      Mob mob = (Mob) GameScr.vMob.elementAt(index);
      if (mob.status != 0 && mob.status != 1)
        flag1 = true;
    }
    if (!flag1)
      return;
    bool flag2 = false;
    for (int index = 0; index < Char.myCharz().arrItemBag.Length; ++index)
    {
      Item obj = Char.myCharz().arrItemBag[index];
      if (obj != null && obj.template.type == (sbyte) 6)
      {
        flag2 = true;
        break;
      }
    }
    if (!flag2 && GameCanvas.gameTick % 150 == 0)
      Service.gI().requestPean();
    if (Char.myCharz().cHP <= Char.myCharz().cHPFull * 20 / 100 || Char.myCharz().cMP <= Char.myCharz().cMPFull * 20 / 100)
      this.doUseHP();
    if (Char.myCharz().mobFocus == null || Char.myCharz().mobFocus != null && Char.myCharz().mobFocus.isMobMe)
    {
      for (int index = 0; index < GameScr.vMob.size(); ++index)
      {
        Mob mob = (Mob) GameScr.vMob.elementAt(index);
        if (mob.status != 0 && mob.status != 1 && mob.hp > 0 && !mob.isMobMe)
        {
          Char.myCharz().cx = mob.x;
          Char.myCharz().cy = mob.y;
          Char.myCharz().mobFocus = mob;
          Service.gI().charMove();
          Res.outz("focus 1 con bossssssssssssssssssssssssssssssssssssssssssssssssss");
          break;
        }
      }
    }
    else if (Char.myCharz().mobFocus.hp <= 0 || Char.myCharz().mobFocus.status == 1 || Char.myCharz().mobFocus.status == 0)
      Char.myCharz().mobFocus = (Mob) null;
    if (Char.myCharz().mobFocus == null || this.timeSkill != 0 || Char.myCharz().skillInfoPaint() != null && Char.myCharz().indexSkill < Char.myCharz().skillInfoPaint().Length && Char.myCharz().dart != null && Char.myCharz().arr != null)
      return;
    Skill skill = (Skill) null;
    if (GameCanvas.isTouch)
    {
      for (int index = 0; index < GameScr.onScreenSkill.Length; ++index)
      {
        if (GameScr.onScreenSkill[index] != null && !GameScr.onScreenSkill[index].paintCanNotUseSkill && GameScr.onScreenSkill[index].template.id != (sbyte) 10 && GameScr.onScreenSkill[index].template.id != (sbyte) 11 && GameScr.onScreenSkill[index].template.id != (sbyte) 14 && GameScr.onScreenSkill[index].template.id != (sbyte) 23 && GameScr.onScreenSkill[index].template.id != (sbyte) 7 && Char.myCharz().skillInfoPaint() == null)
        {
          int num = GameScr.onScreenSkill[index].template.manaUseType != 2 ? (GameScr.onScreenSkill[index].template.manaUseType == 1 ? GameScr.onScreenSkill[index].manaUse * Char.myCharz().cMPFull / 100 : GameScr.onScreenSkill[index].manaUse) : 1;
          if (Char.myCharz().cMP >= num)
          {
            if (skill == null)
              skill = GameScr.onScreenSkill[index];
            else if (skill.coolDown < GameScr.onScreenSkill[index].coolDown)
              skill = GameScr.onScreenSkill[index];
          }
        }
      }
      if (skill == null)
        return;
      this.doSelectSkill(skill, true);
      this.doDoubleClickToObj((IMapObject) Char.myCharz().mobFocus);
    }
    else
    {
      for (int index = 0; index < GameScr.keySkill.Length; ++index)
      {
        if (GameScr.keySkill[index] != null && !GameScr.keySkill[index].paintCanNotUseSkill && GameScr.keySkill[index].template.id != (sbyte) 10 && GameScr.keySkill[index].template.id != (sbyte) 11 && GameScr.keySkill[index].template.id != (sbyte) 14 && GameScr.keySkill[index].template.id != (sbyte) 23 && GameScr.keySkill[index].template.id != (sbyte) 7 && Char.myCharz().skillInfoPaint() == null)
        {
          int num = GameScr.keySkill[index].template.manaUseType != 2 ? (GameScr.keySkill[index].template.manaUseType == 1 ? GameScr.keySkill[index].manaUse * Char.myCharz().cMPFull / 100 : GameScr.keySkill[index].manaUse) : 1;
          if (Char.myCharz().cMP >= num)
          {
            if (skill == null)
              skill = GameScr.keySkill[index];
            else if (skill.coolDown < GameScr.keySkill[index].coolDown)
              skill = GameScr.keySkill[index];
          }
        }
      }
      if (skill == null)
        return;
      this.doSelectSkill(skill, true);
      this.doDoubleClickToObj((IMapObject) Char.myCharz().mobFocus);
    }
  }

  private void doFire(bool isFireByShortCut, bool skipWaypoint)
  {
    ++GameScr.tam;
    Waypoint waypoint1 = Char.myCharz().isInEnterOfflinePoint();
    Waypoint waypoint2 = Char.myCharz().isInEnterOnlinePoint();
    if (!skipWaypoint && waypoint1 != null && (Char.myCharz().mobFocus == null || Char.myCharz().mobFocus != null && Char.myCharz().mobFocus.templateId == 0))
      waypoint1.popup.command.performAction();
    else if (!skipWaypoint && waypoint2 != null && (Char.myCharz().mobFocus == null || Char.myCharz().mobFocus != null && Char.myCharz().mobFocus.templateId == 0))
    {
      waypoint2.popup.command.performAction();
    }
    else
    {
      if (TileMap.mapID == 51 && Char.myCharz().npcFocus != null || Char.myCharz().statusMe == 14)
        return;
      Char.myCharz().cvx = Char.myCharz().cvy = 0;
      if (Char.myCharz().isSelectingSkillUseAlone() && Char.myCharz().focusToAttack())
      {
        if (this.checkSkillValid())
        {
          Char.myCharz().currentFireByShortcut = isFireByShortCut;
          Char.myCharz().useSkillNotFocus();
        }
      }
      else if (this.isAttack())
      {
        if (Char.myCharz().isUseChargeSkill() && Char.myCharz().focusToAttack())
        {
          if (this.checkSkillValid())
          {
            Char.myCharz().currentFireByShortcut = isFireByShortCut;
            Char.myCharz().sendUseChargeSkill();
          }
          else
            Char.myCharz().stopUseChargeSkill();
        }
        else
        {
          bool flag = TileMap.tileTypeAt(Char.myCharz().cx, Char.myCharz().cy, 2);
          Char.myCharz().setSkillPaint(GameScr.sks[(int) Char.myCharz().myskill.skillId], !flag ? 1 : 0);
          if (flag)
            Char.myCharz().delayFall = 20;
          Char.myCharz().currentFireByShortcut = isFireByShortCut;
        }
      }
      if (!Char.myCharz().isSelectingSkillBuffToPlayer())
        return;
      this.auto = 0;
    }
  }

  private void askToPick()
  {
    Npc npc = new Npc(5, 0, -100, 100, 5, GameScr.info1.charId[Char.myCharz().cgender][2]);
    string nhatvatpham = mResources.nhatvatpham;
    string[] menu = new string[2]
    {
      mResources.YES,
      mResources.NO
    };
    npc.idItem = 673;
    GameScr.gI().createMenu(menu, npc);
    ChatPopup.addChatPopupWithIcon(nhatvatpham, 100000, npc, 5820);
  }

  private void pickItem()
  {
    if (Char.myCharz().itemFocus == null)
      return;
    Char.myCharz().cdir = Char.myCharz().cx >= Char.myCharz().itemFocus.x ? -1 : 1;
    int num1 = Math.abs(Char.myCharz().cx - Char.myCharz().itemFocus.x);
    int num2 = Math.abs(Char.myCharz().cy - Char.myCharz().itemFocus.y);
    if (num1 <= 40 && num2 < 40)
    {
      GameCanvas.clearKeyHold();
      GameCanvas.clearKeyPressed();
      if (Char.myCharz().itemFocus.template.id != (short) 673)
        Service.gI().pickItem(Char.myCharz().itemFocus.itemMapID);
      else
        this.askToPick();
    }
    else
    {
      Char.myCharz().currentMovePoint = new MovePoint(Char.myCharz().itemFocus.x, Char.myCharz().itemFocus.y);
      Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) null, 8002, (object) null);
      GameCanvas.clearKeyHold();
      GameCanvas.clearKeyPressed();
    }
  }

  public bool isCharging() => Char.myCharz().isFlyAndCharge || Char.myCharz().isUseSkillAfterCharge || Char.myCharz().isStandAndCharge || Char.myCharz().isWaitMonkey || this.isSuperPower || Char.myCharz().isFreez;

  public void doSelectSkill(Skill skill, bool isShortcut)
  {
    if (Char.myCharz().isCreateDark || this.isCharging() || Char.myCharz().taskMaint.taskId <= (short) 1)
      return;
    Char.myCharz().myskill = skill;
    if (this.lastSkill != skill && this.lastSkill != null)
    {
      Service.gI().selectSkill((int) skill.template.id);
      this.saveRMSCurrentSkill(skill.template.id);
      this.resetButton();
      this.lastSkill = skill;
      this.selectedIndexSkill = -1;
      GameScr.gI().auto = 0;
    }
    else if (Char.myCharz().isSelectingSkillUseAlone())
    {
      Res.outz("use skill not focus");
      this.doUseSkillNotFocus(skill);
      this.lastSkill = skill;
    }
    else
    {
      this.selectedIndexSkill = -1;
      if (skill == null)
        return;
      Res.outz("only select skill");
      if (this.lastSkill != skill)
      {
        Service.gI().selectSkill((int) skill.template.id);
        this.saveRMSCurrentSkill(skill.template.id);
        this.resetButton();
      }
      if (Char.myCharz().charFocus == null && Char.myCharz().isSelectingSkillBuffToPlayer())
        return;
      if (Char.myCharz().focusToAttack())
      {
        this.doFire(isShortcut, true);
        this.doSeleckSkillFlag = true;
      }
      this.lastSkill = skill;
    }
  }

  public void doUseSkill(Skill skill, bool isShortcut)
  {
    if ((TileMap.mapID == 112 || TileMap.mapID == 113) && Char.myCharz().cTypePk == (sbyte) 0)
      return;
    if (Char.myCharz().isSelectingSkillUseAlone())
    {
      Res.outz("HERE");
      this.doUseSkillNotFocus(skill);
    }
    else
    {
      this.selectedIndexSkill = -1;
      if (skill == null)
        return;
      Service.gI().selectSkill((int) skill.template.id);
      this.saveRMSCurrentSkill(skill.template.id);
      this.resetButton();
      Char.myCharz().myskill = skill;
      this.doFire(isShortcut, true);
    }
  }

  public void doUseSkillNotFocus(Skill skill)
  {
    if ((TileMap.mapID == 112 || TileMap.mapID == 113) && Char.myCharz().cTypePk == (sbyte) 0 || !this.checkSkillValid())
      return;
    this.selectedIndexSkill = -1;
    if (skill == null)
      return;
    Service.gI().selectSkill((int) skill.template.id);
    this.saveRMSCurrentSkill(skill.template.id);
    this.resetButton();
    Char.myCharz().myskill = skill;
    Char.myCharz().useSkillNotFocus();
    Char.myCharz().currentFireByShortcut = true;
    this.auto = 0;
  }

  public void sortSkill()
  {
    for (int index1 = 0; index1 < Char.myCharz().vSkillFight.size() - 1; ++index1)
    {
      Skill skill1 = (Skill) Char.myCharz().vSkillFight.elementAt(index1);
      for (int index2 = index1 + 1; index2 < Char.myCharz().vSkillFight.size(); ++index2)
      {
        Skill skill2 = (Skill) Char.myCharz().vSkillFight.elementAt(index2);
        if ((int) skill2.template.id < (int) skill1.template.id)
        {
          Skill skill3 = skill2;
          Skill skill4 = skill1;
          skill1 = skill3;
          Char.myCharz().vSkillFight.setElementAt((object) skill1, index1);
          Char.myCharz().vSkillFight.setElementAt((object) skill4, index2);
        }
      }
    }
  }

  public void updateKeyTouchCapcha()
  {
    if (this.isNotPaintTouchControl())
      return;
    for (int index1 = 0; index1 < this.strCapcha.Length; ++index1)
    {
      this.keyCapcha[index1] = -1;
      if (GameCanvas.isTouchControl)
      {
        int x = (GameCanvas.w - this.strCapcha.Length * GameScr.disXC) / 2;
        int w = this.strCapcha.Length * GameScr.disXC;
        int y = GameCanvas.h - 40;
        int disXc = GameScr.disXC;
        if (GameCanvas.isPointerHoldIn(x, y, w, disXc))
        {
          int num = (GameCanvas.px - x) / GameScr.disXC;
          if (index1 == num)
            this.keyCapcha[index1] = 1;
          if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease && index1 == num)
          {
            char[] charArray = this.keyInput.ToCharArray();
            MyVector myVector = new MyVector();
            for (int index2 = 0; index2 < charArray.Length; ++index2)
              myVector.addElement((object) (charArray[index2].ToString() + string.Empty));
            myVector.removeElementAt(0);
            myVector.insertElementAt((object) (this.strCapcha[index1].ToString() + string.Empty), myVector.size());
            this.keyInput = string.Empty;
            for (int index3 = 0; index3 < myVector.size(); ++index3)
              this.keyInput += ((string) myVector.elementAt(index3)).ToUpper();
            Service.gI().mobCapcha(this.strCapcha[index1]);
          }
        }
      }
    }
  }

  public bool checkClickToCapcha()
  {
    if (this.mobCapcha == null)
      return false;
    int x = (GameCanvas.w - 5 * GameScr.disXC) / 2;
    int w = 5 * GameScr.disXC;
    int y = GameCanvas.h - 40;
    int disXc = GameScr.disXC;
    return GameCanvas.isPointerHoldIn(x, y, w, disXc);
  }

  public void checkMouseChat()
  {
    if (GameCanvas.isMouseFocus(GameScr.xC, GameScr.yC, 34, 34))
    {
      if (TileMap.isOfflineMap())
        return;
      mScreen.keyMouse = 15;
    }
    else if (GameCanvas.isMouseFocus(GameScr.xHP, GameScr.yHP, 40, 40))
    {
      if (Char.myCharz().statusMe == 14)
        return;
      mScreen.keyMouse = 10;
    }
    else if (GameCanvas.isMouseFocus(GameScr.xF, GameScr.yF, 40, 40))
    {
      if (Char.myCharz().statusMe == 14)
        return;
      mScreen.keyMouse = 5;
    }
    else if (this.cmdMenu != null && GameCanvas.isMouseFocus(this.cmdMenu.x, this.cmdMenu.y, this.cmdMenu.w / 2, this.cmdMenu.h))
      mScreen.keyMouse = 1;
    else
      mScreen.keyMouse = -1;
  }

  private void updateKeyTouchControl()
  {
    if (this.isNotPaintTouchControl())
      return;
    mScreen.keyTouch = -1;
    if (GameCanvas.isTouchControl)
    {
      if (GameCanvas.isPointerHoldIn(0, 0, 60, 50) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
      {
        if (Char.myCharz().cmdMenu != null)
          Char.myCharz().cmdMenu.performAction();
        Char.myCharz().currentMovePoint = (MovePoint) null;
        GameCanvas.clearAllPointerEvent();
        this.flareFindFocus = true;
        this.flareTime = 5;
        return;
      }
      if (Main.isPC)
        this.checkMouseChat();
      if (!TileMap.isOfflineMap() && GameCanvas.isPointerHoldIn(GameScr.xC, GameScr.yC, 34, 34))
      {
        mScreen.keyTouch = 15;
        GameCanvas.isPointerJustDown = false;
        this.isPointerDowning = false;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
        {
          ChatTextField.gI().startChat((IChatable) this, string.Empty);
          SoundMn.gI().buttonClick();
          Char.myCharz().currentMovePoint = (MovePoint) null;
          GameCanvas.clearAllPointerEvent();
          return;
        }
      }
      if (Char.myCharz().cmdMenu != null && GameCanvas.isPointerHoldIn(Char.myCharz().cmdMenu.x - 17, Char.myCharz().cmdMenu.y - 17, 34, 34))
      {
        mScreen.keyTouch = 20;
        GameCanvas.isPointerJustDown = false;
        this.isPointerDowning = false;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
        {
          GameCanvas.clearAllPointerEvent();
          Char.myCharz().cmdMenu.performAction();
          return;
        }
      }
      this.updateGamePad();
      if ((GameScr.isAnalog != 0 ? (GameCanvas.isPointerHoldIn(GameScr.xHP, GameScr.yHP, 34, 34) ? 1 : 0) : (GameCanvas.isPointerHoldIn(GameScr.xHP, GameScr.yHP, 40, 40) ? 1 : 0)) != 0 && Char.myCharz().statusMe != 14 && this.mobCapcha == null)
      {
        mScreen.keyTouch = 10;
        GameCanvas.isPointerJustDown = false;
        this.isPointerDowning = false;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
        {
          GameCanvas.keyPressed[10] = true;
          int num;
          GameCanvas.isPointerJustRelease = (num = 0) != 0;
          GameCanvas.isPointerJustDown = num != 0;
          GameCanvas.isPointerClick = num != 0;
        }
      }
    }
    if (this.mobCapcha != null)
      this.updateKeyTouchCapcha();
    else if (GameScr.isHaveSelectSkill)
    {
      if (this.isCharging())
        return;
      this.keyTouchSkill = -1;
      bool flag = false;
      if (GameScr.onScreenSkill.Length > 5 && (GameCanvas.isPointerHoldIn(GameScr.xSkill + GameScr.xS[0] - GameScr.wSkill / 2 + 12, GameScr.yS[0] - GameScr.wSkill / 2 + 12, 5 * GameScr.wSkill, GameScr.wSkill) || GameCanvas.isPointerHoldIn(GameScr.xSkill + GameScr.xS[5] - GameScr.wSkill / 2 + 12, GameScr.yS[5] - GameScr.wSkill / 2 + 12, 5 * GameScr.wSkill, GameScr.wSkill)))
        flag = true;
      if (flag || GameCanvas.isPointerHoldIn(GameScr.xSkill + GameScr.xS[0] - GameScr.wSkill / 2 + 12, GameScr.yS[0] - GameScr.wSkill / 2 + 12, 5 * GameScr.wSkill, GameScr.wSkill) || !GameCanvas.isTouchControl && GameCanvas.isPointerHoldIn(GameScr.xSkill + GameScr.xS[0] - GameScr.wSkill / 2 + 12, GameScr.yS[0] - GameScr.wSkill / 2 + 12, GameScr.wSkill, GameScr.onScreenSkill.Length * GameScr.wSkill))
      {
        GameCanvas.isPointerJustDown = false;
        this.isPointerDowning = false;
        int num1 = (GameCanvas.pxLast - (GameScr.xSkill + GameScr.xS[0] - GameScr.wSkill / 2 + 12)) / GameScr.wSkill;
        if (flag && GameCanvas.pyLast < GameScr.yS[0])
          num1 += 5;
        this.keyTouchSkill = num1;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
        {
          int num2;
          GameCanvas.isPointerJustRelease = (num2 = 0) != 0;
          GameCanvas.isPointerJustDown = num2 != 0;
          GameCanvas.isPointerClick = num2 != 0;
          this.selectedIndexSkill = num1;
          if (GameScr.indexSelect < 0)
            GameScr.indexSelect = 0;
          if (!Main.isPC)
          {
            if (this.selectedIndexSkill > GameScr.onScreenSkill.Length - 1)
              this.selectedIndexSkill = GameScr.onScreenSkill.Length - 1;
          }
          else if (this.selectedIndexSkill > GameScr.keySkill.Length - 1)
            this.selectedIndexSkill = GameScr.keySkill.Length - 1;
          Skill skill = Main.isPC ? GameScr.keySkill[this.selectedIndexSkill] : GameScr.onScreenSkill[this.selectedIndexSkill];
          if (skill != null)
            this.doSelectSkill(skill, true);
        }
      }
    }
    if (!GameCanvas.isPointerJustRelease)
      return;
    if (GameCanvas.keyHold[1] || GameCanvas.keyHold[!Main.isPC ? 2 : 21] || GameCanvas.keyHold[3] || GameCanvas.keyHold[!Main.isPC ? 4 : 23] || GameCanvas.keyHold[!Main.isPC ? 6 : 24])
      GameCanvas.isPointerJustRelease = false;
    GameCanvas.keyHold[1] = false;
    GameCanvas.keyHold[!Main.isPC ? 2 : 21] = false;
    GameCanvas.keyHold[3] = false;
    GameCanvas.keyHold[!Main.isPC ? 4 : 23] = false;
    GameCanvas.keyHold[!Main.isPC ? 6 : 24] = false;
  }

  public void setCharJumpAtt()
  {
    Char.myCharz().cvy = -10;
    Char.myCharz().statusMe = 3;
    Char.myCharz().cp1 = 0;
  }

  public void setCharJump(int cvx)
  {
    if (Char.myCharz().cx - Char.myCharz().cxSend != 0 || Char.myCharz().cy - Char.myCharz().cySend != 0)
      Service.gI().charMove();
    Char.myCharz().cvy = -10;
    Char.myCharz().cvx = cvx;
    Char.myCharz().statusMe = 3;
    Char.myCharz().cp1 = 0;
  }

  public void updateOpen()
  {
    if (!this.isstarOpen)
      return;
    if (this.moveUp > -3)
      this.moveUp -= 4;
    else
      this.moveUp = -2;
    if (this.moveDow < GameCanvas.h + 3)
      this.moveDow += 4;
    else
      this.moveDow = GameCanvas.h + 2;
    if (this.moveUp > -2 || this.moveDow < GameCanvas.h + 2)
      return;
    this.isstarOpen = false;
  }

  public void initCreateCommand()
  {
  }

  public void checkCharFocus()
  {
  }

  public void updateXoSo()
  {
    if (this.tShow == 0)
      return;
    GameScr.currXS = mSystem.currentTimeMillis();
    if (GameScr.currXS - GameScr.lastXS > 1000L)
    {
      GameScr.lastXS = mSystem.currentTimeMillis();
      ++GameScr.secondXS;
    }
    if (GameScr.secondXS > 20)
    {
      for (int index = 0; index < this.winnumber.Length; ++index)
        this.randomNumber[index] = this.winnumber[index];
      --this.tShow;
      if (this.tShow != 0)
        return;
      this.yourNumber = string.Empty;
      GameScr.info1.addInfo(this.strFinish, 0);
      GameScr.secondXS = 0;
    }
    else if (this.moveIndex > this.winnumber.Length - 1)
    {
      --this.tShow;
      if (this.tShow != 0)
        return;
      this.yourNumber = string.Empty;
      GameScr.info1.addInfo(this.strFinish, 0);
    }
    else
    {
      if (this.moveIndex < this.randomNumber.Length)
      {
        if (this.tMove[this.moveIndex] == 15)
        {
          if (this.randomNumber[this.moveIndex] == this.winnumber[this.moveIndex] - 1)
            this.delayMove[this.moveIndex] = 10;
          if (this.randomNumber[this.moveIndex] == this.winnumber[this.moveIndex])
          {
            this.tMove[this.moveIndex] = -1;
            ++this.moveIndex;
          }
        }
        else if (GameCanvas.gameTick % 5 == 0)
          ++this.tMove[this.moveIndex];
      }
      for (int index = 0; index < this.winnumber.Length; ++index)
      {
        if (this.tMove[index] != -1)
        {
          ++this.moveCount[index];
          if (this.moveCount[index] > this.tMove[index] + this.delayMove[index])
          {
            this.moveCount[index] = 0;
            ++this.randomNumber[index];
            if (this.randomNumber[index] >= 10)
              this.randomNumber[index] = 0;
          }
        }
      }
    }
  }

  public override void update()
  {
    if (GameCanvas.keyPressed[16])
    {
      GameCanvas.keyPressed[16] = false;
      Char.myCharz().findNextFocusByKey();
    }
    if (GameCanvas.keyPressed[13] && !GameCanvas.panel.isShow)
    {
      GameCanvas.keyPressed[13] = false;
      Char.myCharz().findNextFocusByKey();
    }
    if (GameCanvas.keyPressed[17])
    {
      GameCanvas.keyPressed[17] = false;
      Char.myCharz().searchItem();
      if (Char.myCharz().itemFocus != null)
        this.pickItem();
    }
    if (GameCanvas.gameTick % 100 == 0 && TileMap.mapID == 137)
      GameScr.shock_scr = 30;
    if (GameScr.isAutoPlay && GameCanvas.gameTick % 20 == 0)
      this.autoPlay();
    this.updateXoSo();
    mSystem.checkAdComlete();
    SmallImage.update();
    try
    {
      if (LoginScr.isContinueToLogin)
        LoginScr.isContinueToLogin = false;
      if (GameScr.tickMove == 1)
        GameScr.lastTick = mSystem.currentTimeMillis();
      if (GameScr.tickMove == 100)
      {
        GameScr.tickMove = 0;
        GameScr.currTick = mSystem.currentTimeMillis();
        int second = (int) (GameScr.currTick - GameScr.lastTick) / 1000;
        Service.gI().checkMMove(second);
      }
      if (GameScr.lockTick > 0)
      {
        --GameScr.lockTick;
        if (GameScr.lockTick == 0)
          Controller.isStopReadMessage = false;
      }
      this.checkCharFocus();
      GameCanvas.debug("E1", 0);
      GameScr.updateCamera();
      GameCanvas.debug("E2", 0);
      ChatTextField.gI().update();
      GameCanvas.debug("E3", 0);
      for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
        ((Char) GameScr.vCharInMap.elementAt(index)).update();
      for (int index = 0; index < Teleport.vTeleport.size(); ++index)
        ((Teleport) Teleport.vTeleport.elementAt(index)).update();
      Char.myCharz().update();
      if (Char.myCharz().statusMe != 1)
        ;
      if (this.popUpYesNo != null)
        this.popUpYesNo.update();
      EffecMn.update();
      GameCanvas.debug("E5x", 0);
      for (int index = 0; index < GameScr.vMob.size(); ++index)
        ((Mob) GameScr.vMob.elementAt(index)).update();
      GameCanvas.debug("E6", 0);
      for (int index = 0; index < GameScr.vNpc.size(); ++index)
        ((Char) GameScr.vNpc.elementAt(index)).update();
      this.nSkill = GameScr.onScreenSkill.Length;
      for (int index = GameScr.onScreenSkill.Length - 1; index >= 0; --index)
      {
        if (GameScr.onScreenSkill[index] != null)
        {
          this.nSkill = index + 1;
          break;
        }
        --this.nSkill;
      }
      if (this.nSkill == 1 && GameCanvas.isTouch)
        GameScr.xSkill = -200;
      else if (GameScr.xSkill < 0)
        GameScr.setSkillBarPosition();
      GameCanvas.debug("E7", 0);
      GameCanvas.gI().updateDust();
      GameCanvas.debug("E8", 0);
      GameScr.updateFlyText();
      PopUp.updateAll();
      GameScr.updateSplash();
      this.updateSS();
      GameCanvas.updateBG();
      GameCanvas.debug("E9", 0);
      this.updateClickToArrow();
      GameCanvas.debug("E10", 0);
      for (int index = 0; index < GameScr.vItemMap.size(); ++index)
        ((ItemMap) GameScr.vItemMap.elementAt(index)).update();
      GameCanvas.debug("E11", 0);
      GameCanvas.debug("E13", 0);
      for (int index = Effect2.vRemoveEffect2.size() - 1; index >= 0; --index)
      {
        Effect2.vEffect2.removeElement(Effect2.vRemoveEffect2.elementAt(index));
        Effect2.vRemoveEffect2.removeElementAt(index);
      }
      for (int index = 0; index < Effect2.vEffect2.size(); ++index)
        ((Effect2) Effect2.vEffect2.elementAt(index)).update();
      for (int index = 0; index < Effect2.vEffect2Outside.size(); ++index)
        ((Effect2) Effect2.vEffect2Outside.elementAt(index)).update();
      for (int index = 0; index < Effect2.vAnimateEffect.size(); ++index)
        ((Effect2) Effect2.vAnimateEffect.elementAt(index)).update();
      for (int index = 0; index < Effect2.vEffectFeet.size(); ++index)
        ((Effect2) Effect2.vEffectFeet.elementAt(index)).update();
      for (int index = 0; index < Effect2.vEffect3.size(); ++index)
        ((Effect2) Effect2.vEffect3.elementAt(index)).update();
      BackgroudEffect.updateEff();
      GameScr.info1.update();
      GameScr.info2.update();
      GameCanvas.debug("E15", 0);
      if (GameScr.currentCharViewInfo != null && !GameScr.currentCharViewInfo.Equals((object) Char.myCharz()))
        GameScr.currentCharViewInfo.update();
      ++this.runArrow;
      if (this.runArrow > 3)
        this.runArrow = 0;
      if (this.isInjureHp)
      {
        ++this.twHp;
        if (this.twHp == 20)
        {
          this.twHp = 0;
          this.isInjureHp = false;
        }
      }
      else if (this.dHP > Char.myCharz().cHP)
      {
        int num = this.dHP - Char.myCharz().cHP >> 1;
        if (num < 1)
          num = 1;
        this.dHP -= num;
      }
      else
        this.dHP = Char.myCharz().cHP;
      if (this.isInjureMp)
      {
        ++this.twMp;
        if (this.twMp == 20)
        {
          this.twMp = 0;
          this.isInjureMp = false;
        }
      }
      else if (this.dMP > Char.myCharz().cMP)
      {
        int num = this.dMP - Char.myCharz().cMP >> 1;
        if (num < 1)
          num = 1;
        this.dMP -= num;
      }
      else
        this.dMP = Char.myCharz().cMP;
      if (this.tMenuDelay > 0)
        --this.tMenuDelay;
      if (this.isRongThanMenu())
      {
        int num = 100;
        while (this.yR - num < GameScr.cmy)
          --GameScr.cmy;
      }
      for (int index = 0; index < Char.vItemTime.size(); ++index)
        ((ItemTime) Char.vItemTime.elementAt(index)).update();
      for (int index = 0; index < GameScr.textTime.size(); ++index)
        ((ItemTime) GameScr.textTime.elementAt(index)).update();
      this.updateChatVip();
    }
    catch (Exception ex)
    {
    }
    if (GameCanvas.gameTick % 4000 == 1000)
      GameScr.checkRemoveImage();
    EffectManager.update();
  }

  public void updateKeyChatPopUp()
  {
  }

  public bool isRongThanMenu() => this.isMeCallRongThan;

  public void paintEffect(mGraphics g)
  {
    for (int index = 0; index < Effect2.vEffect2.size(); ++index)
    {
      Effect2 effect2 = (Effect2) Effect2.vEffect2.elementAt(index);
      if (!(effect2 is ChatPopup))
        effect2.paint(g);
    }
    if (!GameCanvas.lowGraphic)
    {
      for (int index = 0; index < Effect2.vAnimateEffect.size(); ++index)
        ((Effect2) Effect2.vAnimateEffect.elementAt(index)).paint(g);
    }
    for (int index = 0; index < Effect2.vEffect2Outside.size(); ++index)
      ((Effect2) Effect2.vEffect2Outside.elementAt(index)).paint(g);
  }

  public void paintBgItem(mGraphics g, int layer)
  {
    for (int index = 0; index < TileMap.vCurrItem.size(); ++index)
    {
      BgItem bgItem = (BgItem) TileMap.vCurrItem.elementAt(index);
      if (bgItem.idImage != (short) -1 && (int) bgItem.layer == layer)
        bgItem.paint(g);
    }
    if (TileMap.mapID != 48 || layer != 3 || GameCanvas.bgW == null || GameCanvas.bgW[0] == 0)
      return;
    for (int index = 0; index < TileMap.pxw / GameCanvas.bgW[0] + 1; ++index)
      g.drawImage(GameCanvas.imgBG[0], index * GameCanvas.bgW[0], TileMap.pxh - GameCanvas.bgH[0] - 70, 0);
  }

  public void paintBlackSky(mGraphics g)
  {
    if (GameCanvas.lowGraphic)
      return;
    g.fillTrans(GameScr.imgTrans, 0, 0, GameCanvas.w, GameCanvas.h);
  }

  public void paintCapcha(mGraphics g)
  {
    MobCapcha.paint(g, Char.myCharz().cx, Char.myCharz().cy);
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    if (GameCanvas.menu.showMenu || GameCanvas.panel.isShow || ChatPopup.currChatPopup != null || !GameCanvas.isTouch)
      return;
    for (int index = 0; index < this.strCapcha.Length; ++index)
    {
      int x = (GameCanvas.w - this.strCapcha.Length * GameScr.disXC) / 2 + index * GameScr.disXC + GameScr.disXC / 2;
      if (this.keyCapcha[index] == -1)
      {
        g.drawImage(GameScr.imgNut, x, GameCanvas.h - 25, 3);
        mFont.tahoma_7b_dark.drawString(g, this.strCapcha[index].ToString() + string.Empty, x, GameCanvas.h - 30, 2);
      }
      else
      {
        g.drawImage(GameScr.imgNutF, x, GameCanvas.h - 25, 3);
        mFont.tahoma_7b_green2.drawString(g, this.strCapcha[index].ToString() + string.Empty, x, GameCanvas.h - 30, 2);
      }
    }
  }

  public override void paint(mGraphics g)
  {
    GameScr.countEff = 0;
    if (!GameScr.isPaint)
      return;
    GameCanvas.debug("PA1", 1);
    if (this.isFreez || this.isUseFreez && ChatPopup.currChatPopup == null)
    {
      ++this.dem;
      if (this.dem < 30 && this.dem >= 0 && GameCanvas.gameTick % 4 == 0 || this.dem >= 30 && this.dem <= 50 && GameCanvas.gameTick % 3 == 0 || this.dem > 50)
      {
        g.setColor(16777215);
        g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
        if (this.dem <= 50)
          return;
        if (this.isUseFreez)
        {
          this.isUseFreez = false;
          this.dem = 0;
          if (this.activeRongThan)
            this.callRongThan(this.xR, this.yR);
          else
            this.hideRongThan();
        }
        this.paintInfoBar(g);
        g.translate(-GameScr.cmx, -GameScr.cmy);
        g.translate(0, GameCanvas.transY);
        Char.myCharz().paint(g);
        mSystem.paintFlyText(g);
        GameScr.resetTranslate(g);
        this.paintSelectedSkill(g);
        return;
      }
    }
    GameCanvas.debug("PA2", 1);
    GameCanvas.paintBGGameScr(g);
    if ((this.isRongThanXuatHien || this.isFireWorks) && TileMap.bgID != 3)
      this.paintBlackSky(g);
    GameCanvas.debug("PA3", 1);
    if (GameScr.shock_scr > 0)
    {
      g.translate(-GameScr.cmx + GameScr.shock_x[GameScr.shock_scr % GameScr.shock_x.Length], -GameScr.cmy + GameScr.shock_y[GameScr.shock_scr % GameScr.shock_y.Length]);
      --GameScr.shock_scr;
    }
    else
      g.translate(-GameScr.cmx, -GameScr.cmy);
    if (this.isSuperPower)
    {
      int tx = GameCanvas.gameTick % 3 != 0 ? -3 : 3;
      g.translate(tx, 0);
    }
    BackgroudEffect.paintBehindTileAll(g);
    EffecMn.paintLayer1(g);
    TileMap.paintTilemap(g);
    TileMap.paintOutTilemap(g);
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char @char = (Char) GameScr.vCharInMap.elementAt(index);
      if (@char.isMabuHold && TileMap.mapID == 128)
        @char.paintHeadWithXY(g, @char.cx, @char.cy, 0);
    }
    if (Char.myCharz().isMabuHold && TileMap.mapID == 128)
      Char.myCharz().paintHeadWithXY(g, Char.myCharz().cx, Char.myCharz().cy, 0);
    this.paintBgItem(g, 2);
    if (Char.myCharz().cmdMenu != null && GameCanvas.isTouch)
    {
      if (mScreen.keyTouch == 20)
        g.drawImage(GameScr.imgChat2, Char.myCharz().cmdMenu.x + GameScr.cmx, Char.myCharz().cmdMenu.y + GameScr.cmy, mGraphics.HCENTER | mGraphics.VCENTER);
      else
        g.drawImage(GameScr.imgChat, Char.myCharz().cmdMenu.x + GameScr.cmx, Char.myCharz().cmdMenu.y + GameScr.cmy, mGraphics.HCENTER | mGraphics.VCENTER);
    }
    GameCanvas.debug("PA4", 1);
    GameCanvas.debug("PA5", 1);
    BackgroudEffect.paintBackAll(g);
    EffectManager.lowEffects.paintAll(g);
    for (int index = 0; index < Effect2.vEffectFeet.size(); ++index)
      ((Effect2) Effect2.vEffectFeet.elementAt(index)).paint(g);
    for (int index = 0; index < Teleport.vTeleport.size(); ++index)
      ((Teleport) Teleport.vTeleport.elementAt(index)).paintHole(g);
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
    {
      Npc npc = (Npc) GameScr.vNpc.elementAt(index);
      if (npc.cHP > 0)
        npc.paintShadow(g);
    }
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
      ((Char) GameScr.vNpc.elementAt(index)).paint(g);
    g.translate(0, GameCanvas.transY);
    GameCanvas.debug("PA7", 1);
    GameCanvas.debug("PA8", 1);
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char @char = (Char) null;
      try
      {
        @char = (Char) GameScr.vCharInMap.elementAt(index);
      }
      catch (Exception ex)
      {
        Cout.LogError("Loi ham paint char gamesc: " + ex.ToString());
      }
      if (@char != null && (!GameCanvas.panel.isShow || !GameCanvas.panel.isTypeShop()) && @char.isShadown)
        @char.paintShadow(g);
    }
    Char.myCharz().paintShadow(g);
    EffecMn.paintLayer2(g);
    for (int index = 0; index < GameScr.vMob.size(); ++index)
      ((Mob) GameScr.vMob.elementAt(index)).paint(g);
    for (int index = 0; index < Teleport.vTeleport.size(); ++index)
      ((Teleport) Teleport.vTeleport.elementAt(index)).paint(g);
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char @char = (Char) null;
      try
      {
        @char = (Char) GameScr.vCharInMap.elementAt(index);
      }
      catch (Exception ex)
      {
      }
      if (@char != null && (!GameCanvas.panel.isShow || !GameCanvas.panel.isTypeShop()))
        @char.paint(g);
    }
    Char.myCharz().paint(g);
    if (Char.myCharz().skillPaint != null && Char.myCharz().skillInfoPaint() != null && Char.myCharz().indexSkill < Char.myCharz().skillInfoPaint().Length)
    {
      Char.myCharz().paintCharWithSkill(g);
      Char.myCharz().paintMount2(g);
    }
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char @char = (Char) null;
      try
      {
        @char = (Char) GameScr.vCharInMap.elementAt(index);
      }
      catch (Exception ex)
      {
        Cout.LogError("Loi ham paint char gamescr: " + ex.ToString());
      }
      if (@char != null && (!GameCanvas.panel.isShow || !GameCanvas.panel.isTypeShop()) && @char.skillPaint != null && @char.skillInfoPaint() != null && @char.indexSkill < @char.skillInfoPaint().Length)
      {
        @char.paintCharWithSkill(g);
        @char.paintMount2(g);
      }
    }
    for (int index = 0; index < GameScr.vItemMap.size(); ++index)
      ((ItemMap) GameScr.vItemMap.elementAt(index)).paint(g);
    g.translate(0, -GameCanvas.transY);
    GameCanvas.debug("PA9", 1);
    GameScr.paintSplash(g);
    GameCanvas.debug("PA10", 1);
    GameCanvas.debug("PA11", 1);
    GameCanvas.debug("PA13", 1);
    this.paintEffect(g);
    EffectManager.midEffects.paintAll(g);
    this.paintBgItem(g, 3);
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
      ((Npc) GameScr.vNpc.elementAt(index)).paintName(g);
    EffecMn.paintLayer3(g);
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
    {
      Npc npc = (Npc) GameScr.vNpc.elementAt(index);
      if (npc.chatInfo != null && npc != null)
        npc.chatInfo.paint(g, npc.cx, npc.cy - npc.ch - GameCanvas.transY, npc.cdir);
    }
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char @char = (Char) null;
      try
      {
        @char = (Char) GameScr.vCharInMap.elementAt(index);
      }
      catch (Exception ex)
      {
      }
      if (@char != null && @char.chatInfo != null)
        @char.chatInfo.paint(g, @char.cx, @char.cy - @char.ch, @char.cdir);
    }
    if (Char.myCharz().chatInfo != null)
      Char.myCharz().chatInfo.paint(g, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch, Char.myCharz().cdir);
    BackgroudEffect.paintFrontAll(g);
    for (int index = 0; index < TileMap.vCurrItem.size(); ++index)
    {
      BgItem bgItem = (BgItem) TileMap.vCurrItem.elementAt(index);
      if (bgItem.idImage != (short) -1 && bgItem.layer > (sbyte) 3)
        bgItem.paint(g);
    }
    PopUp.paintAll(g);
    if (TileMap.mapID == 120)
    {
      if (this.percentMabu != (sbyte) 100)
      {
        int w = (int) this.percentMabu * mGraphics.getImageWidth(GameScr.imgHPLost) / 100;
        int percentMabu = (int) this.percentMabu;
        g.drawImage(GameScr.imgHPLost, TileMap.pxw / 2 - mGraphics.getImageWidth(GameScr.imgHPLost) / 2, 220, 0);
        g.setClip(TileMap.pxw / 2 - mGraphics.getImageWidth(GameScr.imgHPLost) / 2, 220, w, 10);
        g.drawImage(GameScr.imgHP, TileMap.pxw / 2 - mGraphics.getImageWidth(GameScr.imgHPLost) / 2, 220, 0);
        g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
      }
      if (this.mabuEff)
      {
        ++this.tMabuEff;
        if (GameCanvas.gameTick % 3 == 0)
          EffecMn.addEff(new Effect(19, Res.random(TileMap.pxw / 2 - 50, TileMap.pxw / 2 + 50), 340, 2, 1, -1));
        if (GameCanvas.gameTick % 15 == 0)
          EffecMn.addEff(new Effect(18, Res.random(TileMap.pxw / 2 - 5, TileMap.pxw / 2 + 5), Res.random(300, 320), 2, 1, -1));
        if (this.tMabuEff == 100)
          this.activeSuperPower(TileMap.pxw / 2, 300);
        if (this.tMabuEff == 110)
        {
          this.tMabuEff = 0;
          this.mabuEff = false;
        }
      }
    }
    BackgroudEffect.paintFog(g);
    bool flag = true;
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
    {
      if (((BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index)).typeEff == 0)
      {
        flag = false;
        break;
      }
    }
    if (mGraphics.zoomLevel <= 1 || Main.isIpod || Main.isIphone4)
      flag = false;
    if (flag && !this.isRongThanXuatHien)
    {
      int num1 = TileMap.pxw / (mGraphics.getImageWidth(TileMap.imgLight) + 50);
      if (num1 <= 0)
        num1 = 1;
      if (TileMap.tileID != 28)
      {
        for (int index = 0; index < num1; ++index)
        {
          int num2 = 100 + index * (mGraphics.getImageWidth(TileMap.imgLight) + 50) - GameScr.cmx / 2;
          int y = -20;
          int imageWidth = mGraphics.getImageWidth(TileMap.imgLight);
          if (num2 + imageWidth >= GameScr.cmx && num2 <= GameScr.cmx + GameCanvas.w && y + mGraphics.getImageHeight(TileMap.imgLight) >= GameScr.cmy && y <= GameScr.cmy + GameCanvas.h)
            g.drawImage(TileMap.imgLight, 100 + index * (mGraphics.getImageWidth(TileMap.imgLight) + 50) - GameScr.cmx / 2, y, 0);
        }
      }
    }
    mSystem.paintFlyText(g);
    GameCanvas.debug("PA14", 1);
    GameCanvas.debug("PA15", 1);
    GameCanvas.debug("PA16", 1);
    this.paintArrowPointToNPC(g);
    GameCanvas.debug("PA17", 1);
    if (!GameScr.isPaintOther && GameScr.isPaintRada == 1 && !GameCanvas.panel.isShow)
      this.paintInfoBar(g);
    GameScr.resetTranslate(g);
    if (!GameScr.isPaintOther)
    {
      if (GameCanvas.open3Hour)
      {
        if (GameCanvas.w > 250)
        {
          g.drawImage(GameCanvas.img12, 160, 6, 0);
          mFont.tahoma_7_white.drawString(g, "Dành cho người chơi trên 12 tuổi.", 180, 2, 0);
          mFont.tahoma_7_white.drawString(g, "Chơi quá 180 phút mỗi ngày ", 180, 12, 0);
          mFont.tahoma_7_white.drawString(g, "sẽ hại sức khỏe.", 180, 22, 0);
        }
        else
        {
          g.drawImage(GameCanvas.img12, 5, GameCanvas.h - 67, 0);
          mFont.tahoma_7_white.drawString(g, "Dành cho người chơi trên 12 tuổi.", 25, GameCanvas.h - 70, 0);
          mFont.tahoma_7_white.drawString(g, "Chơi quá 180 phút mỗi ngày sẽ hại sức khỏe.", 25, GameCanvas.h - 60, 0);
        }
      }
      GameCanvas.debug("PA21", 1);
      GameCanvas.debug("PA18", 1);
      g.translate(-g.getTranslateX(), -g.getTranslateY());
      if ((TileMap.mapID == 128 || TileMap.mapID == (int) sbyte.MaxValue) && GameScr.mabuPercent != (sbyte) 0)
      {
        int x = 30;
        int num = 200;
        g.setColor(0);
        g.fillRect(x - 27, num - 112, 54, 8);
        g.setColor(16711680);
        g.setClip(x - 25, num - 110, (int) GameScr.mabuPercent, 4);
        g.fillRect(x - 25, num - 110, 50, 4);
        g.setClip(0, 0, 3000, 3000);
        mFont.tahoma_7b_white.drawString(g, "Mabu", x, num - 112 + 10, 2, mFont.tahoma_7b_dark);
      }
      if (Char.myCharz().isFusion)
      {
        ++Char.myCharz().tFusion;
        if (GameCanvas.gameTick % 3 == 0)
        {
          g.setColor(16777215);
          g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
        }
        if (Char.myCharz().tFusion >= 100)
          Char.myCharz().fusionComplete();
      }
      for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
      {
        Char c = (Char) null;
        try
        {
          c = (Char) GameScr.vCharInMap.elementAt(index);
        }
        catch (Exception ex)
        {
        }
        if (c != null && c.isFusion && Char.isCharInScreen(c))
        {
          ++c.tFusion;
          if (GameCanvas.gameTick % 3 == 0)
          {
            g.setColor(16777215);
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
          }
          if (c.tFusion >= 100)
            c.fusionComplete();
        }
      }
      GameCanvas.paintz.paintTabSoft(g);
      GameCanvas.debug("PA19", 1);
      GameCanvas.debug("PA20", 1);
      GameScr.resetTranslate(g);
      this.paintSelectedSkill(g);
      GameCanvas.debug("PA22", 1);
      GameScr.resetTranslate(g);
      if (GameCanvas.isTouch && GameCanvas.isTouchControl)
        this.paintTouchControl(g);
      GameScr.resetTranslate(g);
      this.paintChatVip(g);
      if (!GameCanvas.panel.isShow && GameCanvas.currentDialog == null && ChatPopup.currChatPopup == null && ChatPopup.serverChatPopUp == null && GameCanvas.currentScreen.Equals((object) GameScr.instance))
      {
        base.paint(g);
        if (mScreen.keyMouse == 1 && this.cmdMenu != null)
          g.drawImage(ItemMap.imageFlare, this.cmdMenu.x + 7, this.cmdMenu.y + 15, 3);
      }
      GameScr.resetTranslate(g);
      int num3 = 100 + (Char.vItemTime.size() == 0 ? 0 : GameScr.textTime.size() * 12);
      if (Char.myCharz().clan != null)
      {
        int num4 = 0;
        int num5 = 0;
        int num6 = (GameCanvas.h - 100 - 60) / 12;
        for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
        {
          Char @char = (Char) GameScr.vCharInMap.elementAt(index);
          if (@char.clanID != -1 && @char.clanID == Char.myCharz().clan.ID)
          {
            if (@char.isOutX() && @char.cx < Char.myCharz().cx)
            {
              int num7 = num6;
              if (Char.vItemTime.size() != 0)
                num7 -= GameScr.textTime.size();
              if (num4 <= num7)
              {
                mFont.tahoma_7_green.drawString(g, @char.cName, 20, num3 - 12 + num4 * 12, mFont.LEFT, mFont.tahoma_7_grey);
                @char.paintHp(g, 10, num3 + num4 * 12 - 5);
                ++num4;
              }
            }
            else if (@char.isOutX() && @char.cx > Char.myCharz().cx && num5 <= num6)
            {
              mFont.tahoma_7_green.drawString(g, @char.cName, GameCanvas.w - 25, num3 - 12 + num5 * 12, mFont.RIGHT, mFont.tahoma_7_grey);
              @char.paintHp(g, GameCanvas.w - 15, num3 + num5 * 12 - 5);
              ++num5;
            }
          }
        }
      }
      ChatTextField.gI().paint(g);
      if (GameScr.isNewClanMessage && !GameCanvas.panel.isShow && GameCanvas.gameTick % 4 == 0)
        g.drawImage(ItemMap.imageFlare, this.cmdMenu.x + 15, this.cmdMenu.y + 30, mGraphics.BOTTOM | mGraphics.HCENTER);
      if (this.isSuperPower)
      {
        this.dxPower += 5;
        if (this.tPower >= 0)
          this.tPower += this.dxPower;
        Res.outz("x power= " + (object) this.xPower);
        if (this.tPower < 0)
        {
          --this.tPower;
          if (this.tPower == -20)
          {
            this.isSuperPower = false;
            this.tPower = 0;
            this.dxPower = 0;
          }
        }
        else if ((this.xPower - this.tPower > 0 || this.tPower < TileMap.pxw) && this.tPower > 0)
        {
          g.setColor(16777215);
          if (!GameCanvas.lowGraphic)
            g.fillArg(0, 0, GameCanvas.w, GameCanvas.h, 0, 0);
          else
            g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
        }
        else
          this.tPower = -1;
      }
      for (int index = 0; index < Char.vItemTime.size(); ++index)
        ((ItemTime) Char.vItemTime.elementAt(index)).paint(g, this.cmdMenu.x + 32 + index * 24, 55);
      for (int index = 0; index < GameScr.textTime.size(); ++index)
        ((ItemTime) GameScr.textTime.elementAt(index)).paintText(g, this.cmdMenu.x + (Char.vItemTime.size() == 0 ? 25 : 5), (Char.vItemTime.size() == 0 ? 45 : 90) + index * 12);
      this.paintXoSo(g);
      if (mResources.language == (sbyte) 1)
      {
        long second = mSystem.currentTimeMillis() + GameScr.deltaTime;
        mFont.tahoma_7b_white.drawString(g, NinjaUtil.getDate2(second), 10, GameCanvas.h - 65, 0, mFont.tahoma_7b_dark);
      }
      if (!this.yourNumber.Equals(string.Empty))
      {
        for (int index = 0; index < this.strPaint.Length; ++index)
          mFont.tahoma_7b_white.drawString(g, this.strPaint[index], 5, 85 + index * 18, 0, mFont.tahoma_7b_dark);
      }
    }
    int num8 = 0;
    int w1 = GameCanvas.hw;
    if (w1 > 200)
      w1 = 200;
    this.paintPhuBanBar(g, num8 + GameCanvas.w / 2, 0, w1);
    EffectManager.hiEffects.paintAll(g);
  }

  private void paintXoSo(mGraphics g)
  {
    if (this.tShow == 0)
      return;
    string str = string.Empty;
    for (int index = 0; index < this.winnumber.Length; ++index)
      str = str + (object) this.randomNumber[index] + " ";
    PopUp.paintPopUp(g, 20, 45, 95, 35, 16777215, false);
    mFont.tahoma_7b_dark.drawString(g, mResources.kquaVongQuay, 68, 50, 2);
    mFont.tahoma_7b_dark.drawString(g, str + string.Empty, 68, 65, 2);
  }

  private void checkEffToObj(IMapObject obj)
  {
    if (obj == null || this.tDoubleDelay > 0)
      return;
    this.tDoubleDelay = 10;
    int x = obj.getX();
    int num = Res.abs(Char.myCharz().cx - x);
    int loopCount = num > 80 ? (num <= 80 || num > 200 ? (num <= 200 || num > 400 ? 4 : 3) : 2) : 1;
    Res.outz("nLoop= " + (object) loopCount);
    if (obj.Equals((object) Char.myCharz().mobFocus) || obj.Equals((object) Char.myCharz().charFocus) && Char.myCharz().isMeCanAttackOtherPlayer(Char.myCharz().charFocus))
    {
      ServerEffect.addServerEffect(135, obj.getX(), obj.getY(), loopCount);
    }
    else
    {
      if (!obj.Equals((object) Char.myCharz().npcFocus) && !obj.Equals((object) Char.myCharz().itemFocus) && !obj.Equals((object) Char.myCharz().charFocus))
        return;
      ServerEffect.addServerEffect(136, obj.getX(), obj.getY(), loopCount);
    }
  }

  private void updateClickToArrow()
  {
    if (this.tDoubleDelay > 0)
      --this.tDoubleDelay;
    if (!this.clickMoving)
      return;
    this.clickMoving = false;
    IMapObject clickToItem = this.findClickToItem(this.clickToX, this.clickToY);
    if (clickToItem != null && (clickToItem == null || !clickToItem.Equals((object) Char.myCharz().npcFocus) || TileMap.mapID != 51))
      return;
    ServerEffect.addServerEffect(134, this.clickToX, this.clickToY + GameCanvas.transY / 2, 3);
  }

  private void paintWaypointArrow(mGraphics g)
  {
    int num = 10;
    Task taskMaint = Char.myCharz().taskMaint;
    if (taskMaint != null && taskMaint.taskId == (short) 0 && (taskMaint.index != 1 && taskMaint.index < 6 || taskMaint.index == 0))
      return;
    for (int index = 0; index < TileMap.vGo.size(); ++index)
    {
      Waypoint waypoint = (Waypoint) TileMap.vGo.elementAt(index);
      if (waypoint.minY == (short) 0 || (int) waypoint.maxY >= TileMap.pxh - 24)
      {
        if ((int) waypoint.maxY <= TileMap.pxh / 2)
        {
          int x = (int) waypoint.minX + ((int) waypoint.maxX - (int) waypoint.minX) / 2;
          int y = (int) waypoint.minY + ((int) waypoint.maxY - (int) waypoint.minY) / 2 + this.runArrow;
          if (GameCanvas.isTouch)
            y = (int) waypoint.maxY + ((int) waypoint.maxY - (int) waypoint.minY) + this.runArrow + num;
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 6, x, y, StaticObj.VCENTER_HCENTER);
        }
        else if ((int) waypoint.minY >= TileMap.pxh / 2)
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 4, (int) waypoint.minX + ((int) waypoint.maxX - (int) waypoint.minX) / 2, (int) waypoint.minY - 12 - this.runArrow, StaticObj.VCENTER_HCENTER);
      }
      else if (waypoint.minX >= (short) 0 && waypoint.minX < (short) 24)
      {
        if (!GameCanvas.isTouch)
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 2, (int) waypoint.maxX + 12 + this.runArrow, (int) waypoint.maxY - 12, StaticObj.VCENTER_HCENTER);
        else
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 2, (int) waypoint.maxX + 12 + this.runArrow, (int) waypoint.maxY - 32, StaticObj.VCENTER_HCENTER);
      }
      else if ((int) waypoint.minX <= TileMap.tmw * 24 && (int) waypoint.minX >= TileMap.tmw * 24 - 48)
      {
        if (!GameCanvas.isTouch)
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 0, (int) waypoint.minX - 12 - this.runArrow, (int) waypoint.maxY - 12, StaticObj.VCENTER_HCENTER);
        else
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 0, (int) waypoint.minX - 12 - this.runArrow, (int) waypoint.maxY - 32, StaticObj.VCENTER_HCENTER);
      }
      else
        g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 4, (int) waypoint.minX + ((int) waypoint.maxX - (int) waypoint.minX) / 2, (int) waypoint.maxY - 48 - this.runArrow, StaticObj.VCENTER_HCENTER);
    }
  }

  public static Npc findNPCInMap(short id)
  {
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
    {
      Npc npcInMap = (Npc) GameScr.vNpc.elementAt(index);
      if (npcInMap.template.npcTemplateId == (int) id)
        return npcInMap;
    }
    return (Npc) null;
  }

  public static Char findCharInMap(int charId)
  {
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char charInMap = (Char) GameScr.vCharInMap.elementAt(index);
      if (charInMap.charID == charId)
        return charInMap;
    }
    return (Char) null;
  }

  public static Mob findMobInMap(sbyte mobIndex) => (Mob) GameScr.vMob.elementAt((int) mobIndex);

  public static Mob findMobInMap(int mobId)
  {
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      Mob mobInMap = (Mob) GameScr.vMob.elementAt(index);
      if (mobInMap.mobId == mobId)
        return mobInMap;
    }
    return (Mob) null;
  }

  public static Npc getNpcTask()
  {
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
    {
      Npc npcTask = (Npc) GameScr.vNpc.elementAt(index);
      if (npcTask.template.npcTemplateId == (int) GameScr.getTaskNpcId())
        return npcTask;
    }
    return (Npc) null;
  }

  private void paintArrowPointToNPC(mGraphics g)
  {
    try
    {
      if (ChatPopup.currChatPopup != null)
        return;
      int taskNpcId = (int) GameScr.getTaskNpcId();
      if (taskNpcId == -1)
        return;
      Npc npc1 = (Npc) null;
      for (int index = 0; index < GameScr.vNpc.size(); ++index)
      {
        Npc npc2 = (Npc) GameScr.vNpc.elementAt(index);
        if (npc2.template.npcTemplateId == taskNpcId)
        {
          if (npc1 == null)
            npc1 = npc2;
          else if (Res.abs(npc2.cx - Char.myCharz().cx) < Res.abs(npc1.cx - Char.myCharz().cx))
            npc1 = npc2;
        }
      }
      if (npc1 == null || npc1.statusMe == 15 || npc1.cx > GameScr.cmx && npc1.cx < GameScr.cmx + GameScr.gW && npc1.cy > GameScr.cmy && npc1.cy < GameScr.cmy + GameScr.gH || GameCanvas.gameTick % 10 < 5)
        return;
      int i1 = npc1.cx - Char.myCharz().cx;
      int i2 = npc1.cy - Char.myCharz().cy;
      int x = 0;
      int y = 0;
      int num = 0;
      if (i1 > 0 && i2 >= 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = GameScr.gW - 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 0;
        }
        else
        {
          x = GameScr.gW / 2;
          y = GameScr.gH - 10;
          num = 5;
        }
      }
      else if (i1 >= 0 && i2 < 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = GameScr.gW - 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 0;
        }
        else
        {
          x = GameScr.gW / 2;
          y = 10;
          num = 6;
        }
      }
      if (i1 < 0 && i2 >= 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 3;
        }
        else
        {
          x = GameScr.gW / 2;
          y = GameScr.gH - 10;
          num = 5;
        }
      }
      else if (i1 <= 0 && i2 < 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 3;
        }
        else
        {
          x = GameScr.gW / 2;
          y = 10;
          num = 6;
        }
      }
      GameScr.resetTranslate(g);
      g.drawRegion(GameScr.arrow, 0, 0, 13, 16, num, x, y, StaticObj.VCENTER_HCENTER);
    }
    catch (Exception ex)
    {
      Cout.LogError("Loi ham arrow to npc: " + ex.ToString());
    }
  }

  public static void resetTranslate(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.setClip(0, -200, GameCanvas.w, 200 + GameCanvas.h);
  }

  private void paintTouchControl(mGraphics g)
  {
    if (this.isNotPaintTouchControl())
      return;
    GameScr.resetTranslate(g);
    if (!TileMap.isOfflineMap() && !this.isVS())
    {
      if (mScreen.keyTouch == 15 || mScreen.keyMouse == 15)
        g.drawImage(!Main.isPC ? GameScr.imgChat2 : GameScr.imgChatsPC2, GameScr.xC + 17, GameScr.yC + 17 + mGraphics.addYWhenOpenKeyBoard, mGraphics.HCENTER | mGraphics.VCENTER);
      else
        g.drawImage(!Main.isPC ? GameScr.imgChat : GameScr.imgChatPC, GameScr.xC + 17, GameScr.yC + 17 + mGraphics.addYWhenOpenKeyBoard, mGraphics.HCENTER | mGraphics.VCENTER);
    }
    if (GameScr.isUseTouch)
      ;
  }

  public void paintImageBarRight(mGraphics g, Char c)
  {
    int w1 = c.cHP * GameScr.hpBarW / c.cHPFull;
    int w2 = c.cMP * GameScr.mpBarW;
    int w3 = this.dHP * GameScr.hpBarW / c.cHPFull;
    int w4 = this.dMP * GameScr.mpBarW;
    g.setClip(GameCanvas.w / 2 + 58 - mGraphics.getImageWidth(GameScr.imgPanel), 0, 95, 100);
    g.drawRegion(GameScr.imgPanel, 0, 0, mGraphics.getImageWidth(GameScr.imgPanel), mGraphics.getImageHeight(GameScr.imgPanel), 2, GameCanvas.w / 2 + 60, 0, mGraphics.RIGHT | mGraphics.TOP);
    g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.hpBarW + GameScr.hpBarW - w3, 5, w3, 10);
    g.drawImage(GameScr.imgHPLost, GameCanvas.w / 2 + 60 - 83, 5, mGraphics.RIGHT | mGraphics.TOP);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.hpBarW + GameScr.hpBarW - w1, 5, w1, 10);
    g.drawImage(GameScr.imgHP, GameCanvas.w / 2 + 60 - 83, 5, mGraphics.RIGHT | mGraphics.TOP);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.mpBarW + GameScr.hpBarW - w4, 20, w4, 6);
    g.drawImage(GameScr.imgMPLost, GameCanvas.w / 2 + 60 - 83, 20, mGraphics.RIGHT | mGraphics.TOP);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    g.setClip(GameCanvas.w / 2 + 60 - 83 - GameScr.mpBarW + GameScr.hpBarW - w2, 20, w2, 6);
    g.drawImage(GameScr.imgMP, GameCanvas.w / 2 + 60 - 83, 20, mGraphics.RIGHT | mGraphics.TOP);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
  }

  private void paintImageBar(mGraphics g, bool isLeft, Char c)
  {
    if (c == null)
      return;
    int w1;
    int w2;
    int w3;
    int w4;
    if (c.charID == Char.myCharz().charID)
    {
      w1 = this.dHP * GameScr.hpBarW / c.cHPFull;
      w2 = this.dMP * GameScr.mpBarW / c.cMPFull;
      w3 = c.cHP * GameScr.hpBarW / c.cHPFull;
      w4 = c.cMP * GameScr.mpBarW / c.cMPFull;
    }
    else
    {
      w1 = c.dHP * GameScr.hpBarW / c.cHPFull;
      w2 = c.perCentMp * GameScr.mpBarW / 100;
      w3 = c.cHP * GameScr.hpBarW / c.cHPFull;
      w4 = c.perCentMp * GameScr.mpBarW / 100;
    }
    if (Char.myCharz().secondPower > (short) 0)
    {
      int w5 = (int) Char.myCharz().powerPoint * GameScr.spBarW / (int) Char.myCharz().maxPowerPoint;
      g.drawImage(GameScr.imgPanel2, 58, 29, 0);
      g.setClip(83, 31, w5, 10);
      g.drawImage(GameScr.imgSP, 83, 31, 0);
      g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
      mFont.tahoma_7_white.drawString(g, Char.myCharz().strInfo + ":" + (object) Char.myCharz().powerPoint + "/" + (object) Char.myCharz().maxPowerPoint, 115, 29, 2);
    }
    if (c.charID != Char.myCharz().charID)
      g.setClip(mGraphics.getImageWidth(GameScr.imgPanel) - 95, 0, 95, 100);
    g.drawImage(GameScr.imgPanel, 0, 0, 0);
    if (isLeft)
      g.setClip(83, 5, w1, 10);
    else
      g.setClip(83 + GameScr.hpBarW - w1, 5, w1, 10);
    g.drawImage(GameScr.imgHPLost, 83, 5, 0);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    if (isLeft)
      g.setClip(83, 5, w3, 10);
    else
      g.setClip(83 + GameScr.hpBarW - w3, 5, w3, 10);
    g.drawImage(GameScr.imgHP, 83, 5, 0);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    if (isLeft)
      g.setClip(83, 20, w2, 6);
    else
      g.setClip(83 + GameScr.mpBarW - w2, 20, w2, 6);
    g.drawImage(GameScr.imgMPLost, 83, 20, 0);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    if (isLeft)
      g.setClip(83, 20, w2, 6);
    else
      g.setClip(83 + GameScr.mpBarW - w4, 20, w4, 6);
    g.drawImage(GameScr.imgMP, 83, 20, 0);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    if (Char.myCharz().cMP != 0 || GameCanvas.gameTick % 10 <= 5)
      return;
    g.setClip(83, 20, 2, 6);
    g.drawImage(GameScr.imgMPLost, 83, 20, 0);
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
  }

  public void getInjure()
  {
  }

  public void starVS()
  {
    this.curr = this.last = mSystem.currentTimeMillis();
    this.secondVS = 180;
  }

  private Char findCharVS1()
  {
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char charVs1 = (Char) GameScr.vCharInMap.elementAt(index);
      if (charVs1.cTypePk != (sbyte) 0)
        return charVs1;
    }
    return (Char) null;
  }

  private Char findCharVS2()
  {
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      Char charVs2 = (Char) GameScr.vCharInMap.elementAt(index);
      if (charVs2.cTypePk != (sbyte) 0 && charVs2 != this.findCharVS1())
        return charVs2;
    }
    return (Char) null;
  }

  private void paintInfoBar(mGraphics g)
  {
    GameScr.resetTranslate(g);
    if (TileMap.mapID == 130 && this.findCharVS1() != null && this.findCharVS2() != null)
    {
      g.translate(GameCanvas.w / 2 - 62, 0);
      this.paintImageBar(g, true, this.findCharVS1());
      g.translate(-(GameCanvas.w / 2 - 65), 0);
      this.paintImageBarRight(g, this.findCharVS2());
      this.findCharVS1().paintHeadWithXY(g, 15, 20, 0);
      this.findCharVS2().paintHeadWithXY(g, GameCanvas.w - 15, 20, 2);
    }
    else if (this.isVS() && Char.myCharz().charFocus != null)
    {
      g.translate(GameCanvas.w / 2 - 62, 0);
      this.paintImageBar(g, true, Char.myCharz().charFocus);
      g.translate(-(GameCanvas.w / 2 - 65), 0);
      this.paintImageBarRight(g, Char.myCharz());
      Char.myCharz().paintHeadWithXY(g, 15, 20, 0);
      Char.myCharz().charFocus.paintHeadWithXY(g, GameCanvas.w - 15, 20, 2);
    }
    else if (GameScr.ispaintPhubangBar() && GameScr.isSmallScr())
    {
      GameScr.paintHPBar_NEW(g, 1, 1, Char.myCharz());
    }
    else
    {
      this.paintImageBar(g, true, Char.myCharz());
      if (Char.myCharz().isInEnterOfflinePoint() != null || Char.myCharz().isInEnterOnlinePoint() != null)
        mFont.tahoma_7_green2.drawString(g, mResources.enter, this.imgScrW / 2, 8 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
      else if (Char.myCharz().mobFocus != null)
      {
        if (Char.myCharz().mobFocus.getTemplate() != null)
          mFont.tahoma_7b_green2.drawString(g, Char.myCharz().mobFocus.getTemplate().name, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
        if (Char.myCharz().mobFocus.templateId != 0)
          mFont.tahoma_7b_green2.drawString(g, NinjaUtil.getMoneys((long) Char.myCharz().mobFocus.hp) + string.Empty, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
      }
      else if (Char.myCharz().npcFocus != null)
      {
        mFont.tahoma_7b_green2.drawString(g, Char.myCharz().npcFocus.template.name, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
        if (Char.myCharz().npcFocus.template.npcTemplateId == 4)
          mFont.tahoma_7b_green2.drawString(g, GameScr.gI().magicTree.currPeas.ToString() + "/" + (object) GameScr.gI().magicTree.maxPeas, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
      }
      else if (Char.myCharz().charFocus != null)
      {
        mFont.tahoma_7b_green2.drawString(g, Char.myCharz().charFocus.cName, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
        mFont.tahoma_7b_green2.drawString(g, NinjaUtil.getMoneys((long) Char.myCharz().charFocus.cHP) + string.Empty, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
      }
      else
      {
        mFont.tahoma_7b_green2.drawString(g, Char.myCharz().cName, this.imgScrW / 2, 9 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
        mFont.tahoma_7b_green2.drawString(g, NinjaUtil.getMoneys(Char.myCharz().cPower) + string.Empty, this.imgScrW / 2, 22 + mGraphics.addYWhenOpenKeyBoard, mFont.CENTER);
      }
    }
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    if (this.isVS() && this.secondVS > 0)
    {
      this.curr = mSystem.currentTimeMillis();
      if (this.curr - this.last >= 1000L)
      {
        this.last = mSystem.currentTimeMillis();
        --this.secondVS;
      }
      mFont.tahoma_7b_white.drawString(g, this.secondVS.ToString() + string.Empty, GameCanvas.w / 2, 13, 2, mFont.tahoma_7b_dark);
    }
    if (!this.flareFindFocus)
      return;
    g.drawImage(ItemMap.imageFlare, 40, 35, mGraphics.BOTTOM | mGraphics.HCENTER);
    --this.flareTime;
    if (this.flareTime >= 0)
      return;
    this.flareTime = 0;
    this.flareFindFocus = false;
  }

  public bool isVS() => TileMap.isVoDaiMap() && (Char.myCharz().cTypePk != (sbyte) 0 || TileMap.mapID == 130 && this.findCharVS1() != null && this.findCharVS2() != null);

  private void paintSelectedSkill(mGraphics g)
  {
    if (this.mobCapcha != null)
    {
      this.paintCapcha(g);
    }
    else
    {
      if (GameCanvas.currentDialog != null || ChatPopup.currChatPopup != null || GameCanvas.menu.showMenu || this.isPaintPopup() || GameCanvas.panel.isShow || Char.myCharz().taskMaint.taskId == (short) 0 || ChatTextField.gI().isShow || GameCanvas.currentScreen == MoneyCharge.instance)
        return;
      long num1 = mSystem.currentTimeMillis() - this.lastUsePotion;
      int num2 = 0;
      if (num1 < 10000L)
        num2 = (int) (num1 * 20L / 10000L);
      if (!GameCanvas.isTouch)
      {
        g.drawImage(mScreen.keyTouch != 10 ? GameScr.imgSkill : GameScr.imgSkill2, GameScr.xSkill + GameScr.xHP - 1, GameScr.yHP - 1, 0);
        SmallImage.drawSmallImage(g, 542, GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3, 0, 0);
        mFont.number_gray.drawString(g, string.Empty + (object) GameScr.hpPotion, GameScr.xSkill + GameScr.xHP + 22, GameScr.yHP + 15, 1);
        if (num1 < 10000L)
        {
          g.setColor(2721889);
          int num3 = (int) (num1 * 20L / 10000L);
          g.fillRect(GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3 + num3, 20, 20 - num3);
        }
      }
      else if (Char.myCharz().statusMe != 14)
      {
        if (GameScr.gamePad.isSmallGamePad)
        {
          if (GameScr.isAnalog != 1)
          {
            g.setColor(9670800);
            g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10, 22, 20);
            g.setColor(16777215);
            g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10 + (num2 == 0 ? 0 : 20 - num2), 22, num2 == 0 ? 20 : num2);
            g.drawImage(mScreen.keyTouch != 10 ? GameScr.imgHP1 : GameScr.imgHP2, GameScr.xHP, GameScr.yHP, 0);
            mFont.tahoma_7_red.drawString(g, string.Empty + (object) GameScr.hpPotion, GameScr.xHP + 20, GameScr.yHP + 15, 2);
          }
          else if (GameScr.isAnalog == 1)
          {
            g.drawImage(mScreen.keyTouch != 10 ? GameScr.imgSkill : GameScr.imgSkill2, GameScr.xSkill + GameScr.xHP - 1, GameScr.yHP - 1, 0);
            SmallImage.drawSmallImage(g, 542, GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3, 0, 0);
            mFont.number_gray.drawString(g, string.Empty + (object) GameScr.hpPotion, GameScr.xSkill + GameScr.xHP + 22, GameScr.yHP + 13, 1);
            if (num1 < 10000L)
            {
              g.setColor(2721889);
              int num4 = (int) (num1 * 20L / 10000L);
              g.fillRect(GameScr.xSkill + GameScr.xHP + 3, GameScr.yHP + 3 + num4, 20, 20 - num4);
            }
          }
        }
        else if (!GameScr.gamePad.isSmallGamePad)
        {
          if (GameScr.isAnalog != 1)
          {
            g.setColor(9670800);
            g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10, 22, 20);
            g.setColor(16777215);
            g.fillRect(GameScr.xHP + 9, GameScr.yHP + 10 + (num2 == 0 ? 0 : 20 - num2), 22, num2 == 0 ? 20 : num2);
            g.drawImage(mScreen.keyTouch != 10 ? GameScr.imgHP1 : GameScr.imgHP2, GameScr.xHP, GameScr.yHP, 0);
            mFont.tahoma_7_red.drawString(g, string.Empty + (object) GameScr.hpPotion, GameScr.xHP + 20, GameScr.yHP + 15, 2);
          }
          else
          {
            g.setColor(9670800);
            g.fillRect(GameScr.xHP + 10, GameScr.yHP + 10, 20, 18);
            g.setColor(16777215);
            g.fillRect(GameScr.xHP + 10, GameScr.yHP + 10 + (num2 == 0 ? 0 : 20 - num2), 20, num2 == 0 ? 18 : num2);
            g.drawImage(mScreen.keyTouch != 10 ? GameScr.imgHP3 : GameScr.imgHP4, GameScr.xHP + 20, GameScr.yHP + 20, mGraphics.HCENTER | mGraphics.VCENTER);
            mFont.tahoma_7_red.drawString(g, string.Empty + (object) GameScr.hpPotion, GameScr.xHP + 20, GameScr.yHP + 15, 2);
          }
        }
      }
      if (GameScr.isHaveSelectSkill)
      {
        Skill[] skillArray = Main.isPC ? GameScr.keySkill : GameScr.onScreenSkill;
        if (mScreen.keyTouch != 10)
          ;
        if (!GameCanvas.isTouch)
        {
          g.setColor(11152401);
          g.fillRect(GameScr.xSkill + GameScr.xHP + 2, GameScr.yHP - 10, 20, 10);
          mFont.tahoma_7_white.drawString(g, "*", GameScr.xSkill + GameScr.xHP + 12, GameScr.yHP - 8, mFont.CENTER);
        }
        int num5 = !Main.isPC ? this.nSkill : skillArray.Length;
        for (int index = 0; index < num5; ++index)
        {
          if (Main.isPC)
          {
            string[] strArray1;
            if (TField.isQwerty)
              strArray1 = new string[10]
              {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "0"
              };
            else
              strArray1 = new string[5]
              {
                "7",
                "8",
                "9",
                "10",
                "11"
              };
            string[] strArray2 = strArray1;
            int num6 = -13;
            if (num5 > 5 && index < 5)
              num6 = 27;
            mFont.tahoma_7b_dark.drawString(g, strArray2[index], GameScr.xSkill + GameScr.xS[index] + 14, GameScr.yS[index] + num6, mFont.CENTER);
            mFont.tahoma_7b_white.drawString(g, strArray2[index], GameScr.xSkill + GameScr.xS[index] + 14, GameScr.yS[index] + num6 + 1, mFont.CENTER);
          }
          Skill skill = skillArray[index];
          if (skill != Char.myCharz().myskill)
            g.drawImage(GameScr.imgSkill, GameScr.xSkill + GameScr.xS[index] - 1, GameScr.yS[index] - 1, 0);
          if (skill != null)
          {
            if (skill == Char.myCharz().myskill)
            {
              g.drawImage(GameScr.imgSkill2, GameScr.xSkill + GameScr.xS[index] - 1, GameScr.yS[index] - 1, 0);
              if (GameCanvas.isTouch && !Main.isPC)
                g.drawRegion(Mob.imgHP, 0, 12, 9, 6, 0, GameScr.xSkill + GameScr.xS[index] + 8, GameScr.yS[index] - 7, 0);
            }
            skill.paint(GameScr.xSkill + GameScr.xS[index] + 13, GameScr.yS[index] + 13, g);
            if (index == this.selectedIndexSkill && !this.isPaintUI() && GameCanvas.gameTick % 10 > 5 || index == this.keyTouchSkill)
              g.drawImage(ItemMap.imageFlare, GameScr.xSkill + GameScr.xS[index] + 13, GameScr.yS[index] + 14, 3);
          }
        }
      }
      this.paintGamePad(g);
    }
  }

  public void paintOpen(mGraphics g)
  {
    if (!this.isstarOpen)
      return;
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.fillRect(0, 0, GameCanvas.w, this.moveUp);
    g.setColor(10275899);
    g.fillRect(0, this.moveUp - 1, GameCanvas.w, 1);
    g.fillRect(0, this.moveDow + 1, GameCanvas.w, 1);
  }

  public static void startFlyText(string flyString, int x, int y, int dx, int dy, int color)
  {
    int index1 = -1;
    for (int index2 = 0; index2 < 5; ++index2)
    {
      if (GameScr.flyTextState[index2] == -1)
      {
        index1 = index2;
        break;
      }
    }
    if (index1 == -1)
      return;
    GameScr.flyTextColor[index1] = color;
    GameScr.flyTextString[index1] = flyString;
    GameScr.flyTextX[index1] = x;
    GameScr.flyTextY[index1] = y;
    GameScr.flyTextDx[index1] = dx;
    GameScr.flyTextDy[index1] = dy >= 0 ? 5 : -5;
    GameScr.flyTextState[index1] = 0;
    GameScr.flyTime[index1] = 0;
    GameScr.flyTextYTo[index1] = 10;
    for (int index3 = 0; index3 < 5; ++index3)
    {
      if (GameScr.flyTextState[index3] != -1 && index1 != index3 && GameScr.flyTextDy[index1] < 0 && Res.abs(GameScr.flyTextX[index1] - GameScr.flyTextX[index3]) <= 20 && GameScr.flyTextYTo[index1] == GameScr.flyTextYTo[index3])
        GameScr.flyTextYTo[index1] += 10;
    }
  }

  public static void updateFlyText()
  {
    for (int index = 0; index < 5; ++index)
    {
      if (GameScr.flyTextState[index] != -1)
      {
        if (GameScr.flyTextState[index] > GameScr.flyTextYTo[index])
        {
          ++GameScr.flyTime[index];
          if (GameScr.flyTime[index] == 25)
          {
            GameScr.flyTime[index] = 0;
            GameScr.flyTextState[index] = -1;
            GameScr.flyTextYTo[index] = 0;
            GameScr.flyTextDx[index] = 0;
            GameScr.flyTextX[index] = 0;
          }
        }
        else
        {
          GameScr.flyTextState[index] += Res.abs(GameScr.flyTextDy[index]);
          GameScr.flyTextX[index] += GameScr.flyTextDx[index];
          GameScr.flyTextY[index] += GameScr.flyTextDy[index];
        }
      }
    }
  }

  public static void loadSplash()
  {
    if (GameScr.imgSplash == null)
    {
      GameScr.imgSplash = new Image[3];
      for (int index = 0; index < 3; ++index)
        GameScr.imgSplash[index] = GameCanvas.loadImage("/e/sp" + (object) index + ".png");
    }
    GameScr.splashX = new int[2];
    GameScr.splashY = new int[2];
    GameScr.splashState = new int[2];
    GameScr.splashF = new int[2];
    GameScr.splashDir = new int[2];
    GameScr.splashState[0] = GameScr.splashState[1] = -1;
  }

  public static bool startSplash(int x, int y, int dir)
  {
    int index = GameScr.splashState[0] != -1 ? 1 : 0;
    if (GameScr.splashState[index] != -1)
      return false;
    GameScr.splashState[index] = 0;
    GameScr.splashDir[index] = dir;
    GameScr.splashX[index] = x;
    GameScr.splashY[index] = y;
    return true;
  }

  public static void updateSplash()
  {
    for (int index = 0; index < 2; ++index)
    {
      if (GameScr.splashState[index] != -1)
      {
        ++GameScr.splashState[index];
        GameScr.splashX[index] += GameScr.splashDir[index] << 2;
        --GameScr.splashY[index];
        if (GameScr.splashState[index] >= 6)
          GameScr.splashState[index] = -1;
        else
          GameScr.splashF[index] = (GameScr.splashState[index] >> 1) % 3;
      }
    }
  }

  public static void paintSplash(mGraphics g)
  {
    for (int index = 0; index < 2; ++index)
    {
      if (GameScr.splashState[index] != -1)
      {
        if (GameScr.splashDir[index] == 1)
          g.drawImage(GameScr.imgSplash[GameScr.splashF[index]], GameScr.splashX[index], GameScr.splashY[index], 3);
        else
          g.drawRegion(GameScr.imgSplash[GameScr.splashF[index]], 0, 0, mGraphics.getImageWidth(GameScr.imgSplash[GameScr.splashF[index]]), mGraphics.getImageHeight(GameScr.imgSplash[GameScr.splashF[index]]), 2, GameScr.splashX[index], GameScr.splashY[index], 3);
      }
    }
  }

  private void loadInforBar()
  {
    this.imgScrW = 84;
    GameScr.hpBarW = 66;
    GameScr.mpBarW = 59;
    GameScr.hpBarX = 52;
    GameScr.hpBarY = 10;
    GameScr.spBarW = 61;
    GameScr.expBarW = GameScr.gW - 61;
  }

  public void updateSS()
  {
    if (GameScr.indexMenu == -1)
      return;
    if (GameScr.cmySK != GameScr.cmtoYSK)
    {
      GameScr.cmvySK = GameScr.cmtoYSK - GameScr.cmySK << 2;
      GameScr.cmdySK += GameScr.cmvySK;
      GameScr.cmySK += GameScr.cmdySK >> 4;
      GameScr.cmdySK &= 15;
    }
    if (Math.abs(GameScr.cmtoYSK - GameScr.cmySK) < 15 && GameScr.cmySK < 0)
      GameScr.cmtoYSK = 0;
    if (Math.abs(GameScr.cmtoYSK - GameScr.cmySK) >= 15 || GameScr.cmySK <= GameScr.cmyLimSK)
      return;
    GameScr.cmtoYSK = GameScr.cmyLimSK;
  }

  public void updateKeyAlert()
  {
    if (!GameScr.isPaintAlert || GameCanvas.currentDialog != null)
      return;
    bool flag = false;
    if (GameCanvas.keyPressed[Key.NUM8])
    {
      ++GameScr.indexRow;
      if (GameScr.indexRow >= this.texts.size())
        GameScr.indexRow = 0;
      flag = true;
    }
    else if (GameCanvas.keyPressed[Key.NUM2])
    {
      --GameScr.indexRow;
      if (GameScr.indexRow < 0)
        GameScr.indexRow = this.texts.size() - 1;
      flag = true;
    }
    if (flag)
    {
      GameScr.scrMain.moveTo(GameScr.indexRow * GameScr.scrMain.ITEM_SIZE);
      GameCanvas.clearKeyHold();
      GameCanvas.clearKeyPressed();
    }
    if (GameCanvas.isTouch)
    {
      ScrollResult scrollResult = GameScr.scrMain.updateKey();
      if (scrollResult.isDowning || scrollResult.isFinish)
      {
        GameScr.indexRow = scrollResult.selected;
        flag = true;
      }
    }
    if (!flag || GameScr.indexRow < 0 || GameScr.indexRow >= this.texts.size())
      return;
    string str1 = (string) this.texts.elementAt(GameScr.indexRow);
    int num1 = -1;
    this.fnick = (string) null;
    this.alertURL = (string) null;
    this.center = (Command) null;
    ChatTextField.gI().center = (Command) null;
    int startIndex1;
    if ((startIndex1 = str1.IndexOf("http://")) >= 0)
    {
      Cout.println("currentLine: " + str1);
      this.alertURL = str1.Substring(startIndex1);
      this.center = new Command(mResources.open_link, 12000);
      if (GameCanvas.isTouch)
        return;
      ChatTextField.gI().center = new Command(mResources.open_link, (IActionListener) null, 12000, (object) null);
    }
    else
    {
      if ((num1 = str1.IndexOf("@")) < 0)
        return;
      string str2 = str1.Substring(2).Trim();
      int startIndex2 = str2.IndexOf("@");
      string str3 = str2.Substring(startIndex2);
      int num2 = str3.IndexOf(" ");
      int length = num2 > 0 ? num2 + startIndex2 : startIndex2 + str3.Length;
      this.fnick = str2.Substring(startIndex2 + 1, length);
      if (!this.fnick.Equals(string.Empty) && !this.fnick.Equals(Char.myCharz().cName))
      {
        this.center = new Command(mResources.SELECT, 12009, (object) this.fnick);
        if (GameCanvas.isTouch)
          return;
        ChatTextField.gI().center = new Command(mResources.SELECT, (IActionListener) null, 12009, (object) this.fnick);
      }
      else
      {
        this.fnick = (string) null;
        this.center = (Command) null;
      }
    }
  }

  public bool isPaintPopup() => GameScr.isPaintItemInfo || GameScr.isPaintInfoMe || GameScr.isPaintStore || GameScr.isPaintWeapon || GameScr.isPaintNonNam || GameScr.isPaintNonNu || GameScr.isPaintAoNam || GameScr.isPaintAoNu || GameScr.isPaintGangTayNam || GameScr.isPaintGangTayNu || GameScr.isPaintQuanNam || GameScr.isPaintQuanNu || GameScr.isPaintGiayNam || GameScr.isPaintGiayNu || GameScr.isPaintLien || GameScr.isPaintNhan || GameScr.isPaintNgocBoi || GameScr.isPaintPhu || GameScr.isPaintStack || GameScr.isPaintStackLock || GameScr.isPaintGrocery || GameScr.isPaintGroceryLock || GameScr.isPaintUpGrade || GameScr.isPaintConvert || GameScr.isPaintSplit || GameScr.isPaintUpPearl || GameScr.isPaintBox || GameScr.isPaintTrade || GameScr.isPaintAlert || GameScr.isPaintZone || GameScr.isPaintTeam || GameScr.isPaintClan || GameScr.isPaintFindTeam || GameScr.isPaintTask || GameScr.isPaintFriend || GameScr.isPaintEnemies || GameScr.isPaintCharInMap || GameScr.isPaintMessage;

  public bool isNotPaintTouchControl() => !GameCanvas.isTouchControl && GameCanvas.currentScreen == GameScr.gI() || !GameCanvas.isTouch || ChatTextField.gI().isShow || InfoDlg.isShow || GameCanvas.currentDialog != null || ChatPopup.currChatPopup != null || GameCanvas.menu.showMenu || GameCanvas.panel.isShow || this.isPaintPopup();

  public bool isPaintUI() => GameScr.isPaintStore || GameScr.isPaintWeapon || GameScr.isPaintNonNam || GameScr.isPaintNonNu || GameScr.isPaintAoNam || GameScr.isPaintAoNu || GameScr.isPaintGangTayNam || GameScr.isPaintGangTayNu || GameScr.isPaintQuanNam || GameScr.isPaintQuanNu || GameScr.isPaintGiayNam || GameScr.isPaintGiayNu || GameScr.isPaintLien || GameScr.isPaintNhan || GameScr.isPaintNgocBoi || GameScr.isPaintPhu || GameScr.isPaintStack || GameScr.isPaintStackLock || GameScr.isPaintGrocery || GameScr.isPaintGroceryLock || GameScr.isPaintUpGrade || GameScr.isPaintConvert || GameScr.isPaintSplit || GameScr.isPaintUpPearl || GameScr.isPaintBox || GameScr.isPaintTrade;

  public bool isOpenUI() => GameScr.isPaintItemInfo || GameScr.isPaintInfoMe || GameScr.isPaintStore || GameScr.isPaintNonNam || GameScr.isPaintNonNu || GameScr.isPaintAoNam || GameScr.isPaintAoNu || GameScr.isPaintGangTayNam || GameScr.isPaintGangTayNu || GameScr.isPaintQuanNam || GameScr.isPaintQuanNu || GameScr.isPaintGiayNam || GameScr.isPaintGiayNu || GameScr.isPaintLien || GameScr.isPaintNhan || GameScr.isPaintNgocBoi || GameScr.isPaintPhu || GameScr.isPaintWeapon || GameScr.isPaintStack || GameScr.isPaintStackLock || GameScr.isPaintGrocery || GameScr.isPaintGroceryLock || GameScr.isPaintUpGrade || GameScr.isPaintConvert || GameScr.isPaintUpPearl || GameScr.isPaintBox || GameScr.isPaintSplit || GameScr.isPaintTrade;

  public static void setPopupSize(int w, int h)
  {
    if (GameCanvas.w == 128 || GameCanvas.h <= 208)
    {
      w = 126;
      h = 160;
    }
    GameScr.indexTitle = 0;
    GameScr.popupW = w;
    GameScr.popupH = h;
    GameScr.popupX = GameScr.gW2 - w / 2;
    GameScr.popupY = GameScr.gH2 - h / 2;
    if (GameCanvas.isTouch && !GameScr.isPaintZone && !GameScr.isPaintTeam && !GameScr.isPaintClan && !GameScr.isPaintCharInMap && !GameScr.isPaintFindTeam && !GameScr.isPaintFriend && !GameScr.isPaintEnemies && !GameScr.isPaintTask && !GameScr.isPaintMessage)
    {
      if (GameCanvas.h <= 240)
        GameScr.popupY -= 10;
      if (GameCanvas.isTouch && !GameCanvas.isTouchControlSmallScreen && GameCanvas.currentScreen is GameScr)
      {
        GameScr.popupW = 310;
        GameScr.popupX = GameScr.gW / 2 - GameScr.popupW / 2;
        if (GameScr.isPaintInfoMe && GameScr.indexMenu > 0)
        {
          GameScr.popupW = w;
          GameScr.popupX = GameScr.gW2 - w / 2;
        }
      }
    }
    if (GameScr.popupY < -10)
      GameScr.popupY = -10;
    if (GameCanvas.h > 208 && GameScr.popupY < 0)
      GameScr.popupY = 0;
    if (GameCanvas.h != 208 || GameScr.popupY >= 10)
      return;
    GameScr.popupY = 10;
  }

  public static void loadImg() => TileMap.loadTileImage();

  public void paintTitle(mGraphics g, string title, bool arrow)
  {
    int x = GameScr.gW / 2;
    g.setColor(Paint.COLORDARK);
    g.fillRoundRect(x - mFont.tahoma_8b.getWidth(title) / 2 - 12, GameScr.popupY + 4, mFont.tahoma_8b.getWidth(title) + 22, 24, 6, 6);
    if ((GameScr.indexTitle == 0 || GameCanvas.isTouch) && arrow)
    {
      SmallImage.drawSmallImage(g, 989, x - mFont.tahoma_8b.getWidth(title) / 2 - 15 - 7 - (GameCanvas.gameTick % 8 > 3 ? 0 : 2), GameScr.popupY + 16, 2, StaticObj.VCENTER_HCENTER);
      SmallImage.drawSmallImage(g, 989, x + mFont.tahoma_8b.getWidth(title) / 2 + 15 + 5 + (GameCanvas.gameTick % 8 > 3 ? 0 : 2), GameScr.popupY + 16, 0, StaticObj.VCENTER_HCENTER);
    }
    if (GameScr.indexTitle == 0)
      g.setColor(Paint.COLORFOCUS);
    else
      g.setColor(Paint.COLORBORDER);
    g.drawRoundRect(x - mFont.tahoma_8b.getWidth(title) / 2 - 12, GameScr.popupY + 4, mFont.tahoma_8b.getWidth(title) + 22, 24, 6, 6);
    mFont.tahoma_8b.drawString(g, title, x, GameScr.popupY + 9, 2);
  }

  public static int getTaskMapId() => Char.myCharz().taskMaint != null ? GameScr.mapTasks[Char.myCharz().taskMaint.index] : -1;

  public static sbyte getTaskNpcId()
  {
    sbyte taskNpcId = 0;
    if (Char.myCharz().taskMaint == null)
      taskNpcId = (sbyte) -1;
    else if (Char.myCharz().taskMaint.index <= GameScr.tasks.Length - 1)
      taskNpcId = (sbyte) GameScr.tasks[Char.myCharz().taskMaint.index];
    return taskNpcId;
  }

  public void refreshTeam()
  {
  }

  public void onChatFromMe(string text, string to)
  {
    Res.outz("CHAT");
    if (!GameScr.isPaintMessage || GameCanvas.isTouch)
      ChatTextField.gI().isShow = false;
    if (to.Equals(mResources.chat_player))
    {
      if (GameScr.info2.playerID == Char.myCharz().charID)
        return;
      Service.gI().chatPlayer(text, GameScr.info2.playerID);
    }
    else
    {
      if (text.Equals(string.Empty))
        return;
      Service.gI().chat(text);
    }
  }

  public void onCancelChat()
  {
    if (!GameScr.isPaintMessage)
      return;
    GameScr.isPaintMessage = false;
    ChatTextField.gI().center = (Command) null;
  }

  public void openWeb(string strLeft, string strRight, string url, string title, string str)
  {
    GameScr.isPaintAlert = true;
    this.isLockKey = true;
    GameScr.indexRow = 0;
    GameScr.setPopupSize(175, 200);
    this.textsTitle = title;
    this.texts = mFont.tahoma_7.splitFontVector(str, GameScr.popupW - 30);
    this.center = (Command) null;
    this.left = new Command(strLeft, 11068, (object) url);
    this.right = new Command(strRight, 11069);
  }

  public void sendSms(
    string strLeft,
    string strRight,
    short port,
    string syntax,
    string title,
    string str)
  {
    GameScr.isPaintAlert = true;
    this.isLockKey = true;
    GameScr.indexRow = 0;
    GameScr.setPopupSize(175, 200);
    this.textsTitle = title;
    this.texts = mFont.tahoma_7.splitFontVector(str, GameScr.popupW - 30);
    this.center = (Command) null;
    MyVector myVector = new MyVector();
    myVector.addElement((object) (string.Empty + (object) port));
    myVector.addElement((object) syntax);
    this.left = new Command(strLeft, 11074);
    this.right = new Command(strRight, 11075);
  }

  public void actMenu()
  {
    GameCanvas.panel.setTypeMain();
    GameCanvas.panel.show();
  }

  public void openUIZone(Message message)
  {
    InfoDlg.hide();
    try
    {
      this.zones = new int[(int) message.reader().readByte()];
      this.pts = new int[this.zones.Length];
      this.numPlayer = new int[this.zones.Length];
      this.maxPlayer = new int[this.zones.Length];
      this.rank1 = new int[this.zones.Length];
      this.rankName1 = new string[this.zones.Length];
      this.rank2 = new int[this.zones.Length];
      this.rankName2 = new string[this.zones.Length];
      for (int index = 0; index < this.zones.Length; ++index)
      {
        this.zones[index] = (int) message.reader().readByte();
        this.pts[index] = (int) message.reader().readByte();
        this.numPlayer[index] = (int) message.reader().readByte();
        this.maxPlayer[index] = (int) message.reader().readByte();
        if (message.reader().readByte() == (sbyte) 1)
        {
          this.rankName1[index] = message.reader().readUTF();
          this.rank1[index] = message.reader().readInt();
          this.rankName2[index] = message.reader().readUTF();
          this.rank2[index] = message.reader().readInt();
        }
      }
    }
    catch (Exception ex)
    {
      Cout.LogError("Loi ham OPEN UIZONE " + ex.ToString());
    }
    GameCanvas.panel.setTypeZone();
    GameCanvas.panel.show();
  }

  public void showViewInfo()
  {
    GameScr.indexMenu = 3;
    GameScr.isPaintInfoMe = true;
    GameScr.setPopupSize(175, 200);
  }

  private void actDead()
  {
    MyVector menuItems = new MyVector();
    menuItems.addElement((object) new Command(mResources.DIES[1], 110381));
    menuItems.addElement((object) new Command(mResources.DIES[2], 110382));
    menuItems.addElement((object) new Command(mResources.DIES[3], 110383));
    GameCanvas.menu.startAt(menuItems, 3);
  }

  public void startYesNoPopUp(string info, Command cmdYes, Command cmdNo)
  {
    this.popUpYesNo = new PopUpYesNo();
    this.popUpYesNo.setPopUp(info, cmdYes, cmdNo);
  }

  public void player_vs_player(int playerId, int xu, string info, sbyte typePK)
  {
    Char charInMap = GameScr.findCharInMap(playerId);
    if (charInMap == null)
      return;
    if (typePK == (sbyte) 3)
      this.startYesNoPopUp(info, new Command(mResources.OK, 2000, (object) charInMap), new Command(mResources.CLOSE, 2009, (object) charInMap));
    if (typePK != (sbyte) 4)
      return;
    this.startYesNoPopUp(info, new Command(mResources.OK, 2005, (object) charInMap), new Command(mResources.CLOSE, 2009, (object) charInMap));
  }

  public void giaodich(int playerID)
  {
    Char charInMap = GameScr.findCharInMap(playerID);
    if (charInMap == null)
      return;
    this.startYesNoPopUp(charInMap.cName + mResources.want_to_trade, new Command(mResources.YES, 11114, (object) charInMap), new Command(mResources.NO, 2009, (object) charInMap));
  }

  public void getFlagImage(int charID, sbyte cflag)
  {
    if (GameScr.vFlag.size() == 0)
    {
      Service.gI().getFlag((sbyte) 2, cflag);
      Res.outz("getFlag1");
    }
    else if (charID == Char.myCharz().charID)
    {
      Res.outz("my cflag: isme");
      if (Char.myCharz().isGetFlagImage(cflag))
      {
        Res.outz("my cflag: true");
        for (int index = 0; index < GameScr.vFlag.size(); ++index)
        {
          PKFlag pkFlag = (PKFlag) GameScr.vFlag.elementAt(index);
          if (pkFlag != null && (int) pkFlag.cflag == (int) cflag)
          {
            Res.outz("my cflag: cflag==");
            Char.myCharz().flagImage = pkFlag.IDimageFlag;
          }
        }
      }
      else
      {
        if (Char.myCharz().isGetFlagImage(cflag))
          return;
        Res.outz("my cflag: false");
        Service.gI().getFlag((sbyte) 2, cflag);
      }
    }
    else
    {
      Res.outz("my cflag: not me");
      if (GameScr.findCharInMap(charID) == null)
        return;
      if (GameScr.findCharInMap(charID).isGetFlagImage(cflag))
      {
        Res.outz("my cflag: true");
        for (int index = 0; index < GameScr.vFlag.size(); ++index)
        {
          PKFlag pkFlag = (PKFlag) GameScr.vFlag.elementAt(index);
          if (pkFlag != null && (int) pkFlag.cflag == (int) cflag)
          {
            Res.outz("my cflag: cflag==");
            GameScr.findCharInMap(charID).flagImage = pkFlag.IDimageFlag;
          }
        }
      }
      else
      {
        if (GameScr.findCharInMap(charID).isGetFlagImage(cflag))
          return;
        Res.outz("my cflag: false");
        Service.gI().getFlag((sbyte) 2, cflag);
      }
    }
  }

  public void actionPerform(int idAction, object p)
  {
    Cout.println("PERFORM WITH ID = " + (object) idAction);
    switch (idAction)
    {
      case 2000:
        this.popUpYesNo = (PopUpYesNo) null;
        GameCanvas.endDlg();
        if ((Char) p == null)
        {
          Service.gI().player_vs_player((sbyte) 1, (sbyte) 3, -1);
          break;
        }
        Service.gI().player_vs_player((sbyte) 1, (sbyte) 3, ((Char) p).charID);
        Service.gI().charMove();
        break;
      case 2001:
        GameCanvas.endDlg();
        break;
      case 2003:
        GameCanvas.endDlg();
        InfoDlg.showWait();
        Service.gI().player_vs_player((sbyte) 0, (sbyte) 3, Char.myCharz().charFocus.charID);
        break;
      case 2004:
        GameCanvas.endDlg();
        Service.gI().player_vs_player((sbyte) 0, (sbyte) 4, Char.myCharz().charFocus.charID);
        break;
      case 2005:
        GameCanvas.endDlg();
        this.popUpYesNo = (PopUpYesNo) null;
        if ((Char) p == null)
        {
          Service.gI().player_vs_player((sbyte) 1, (sbyte) 4, -1);
          break;
        }
        Service.gI().player_vs_player((sbyte) 1, (sbyte) 4, ((Char) p).charID);
        break;
      case 2006:
        GameCanvas.endDlg();
        Service.gI().player_vs_player((sbyte) 2, (sbyte) 4, Char.myCharz().charFocus.charID);
        break;
      case 2007:
        GameCanvas.endDlg();
        GameMidlet.instance.exit();
        break;
      case 2009:
        this.popUpYesNo = (PopUpYesNo) null;
        break;
      default:
        switch (idAction - 11111)
        {
          case 0:
            if (Char.myCharz().charFocus == null)
              return;
            InfoDlg.showWait();
            if (GameCanvas.panel.vPlayerMenu.size() <= 0)
              this.playerMenu(Char.myCharz().charFocus);
            GameCanvas.panel.setTypePlayerMenu(Char.myCharz().charFocus);
            GameCanvas.panel.show();
            Service.gI().getPlayerMenu(Char.myCharz().charFocus.charID);
            Service.gI().messagePlayerMenu(Char.myCharz().charFocus.charID);
            return;
          case 1:
            Char char1 = (Char) p;
            Service.gI().friend((sbyte) 1, char1.charID);
            return;
          case 2:
            Char char2 = (Char) p;
            if (char2 == null)
              return;
            Service.gI().giaodich((sbyte) 0, char2.charID, (sbyte) -1, -1);
            return;
          case 3:
            this.popUpYesNo = (PopUpYesNo) null;
            GameCanvas.endDlg();
            Char char3 = (Char) p;
            if (char3 == null)
              return;
            Service.gI().giaodich((sbyte) 1, char3.charID, (sbyte) -1, -1);
            return;
          case 4:
            if (Char.myCharz().charFocus == null)
              return;
            InfoDlg.showWait();
            Service.gI().playerMenuAction(Char.myCharz().charFocus.charID, (short) Char.myCharz().charFocus.menuSelect);
            return;
          case 9:
            object[] objArray1 = (object[]) p;
            Skill skill1 = (Skill) objArray1[0];
            int index1 = int.Parse((string) objArray1[1]);
            for (int index2 = 0; index2 < GameScr.onScreenSkill.Length; ++index2)
            {
              if (GameScr.onScreenSkill[index2] == skill1)
                GameScr.onScreenSkill[index2] = (Skill) null;
            }
            GameScr.onScreenSkill[index1] = skill1;
            this.saveonScreenSkillToRMS();
            return;
          case 10:
            object[] objArray2 = (object[]) p;
            Skill skill2 = (Skill) objArray2[0];
            int index3 = int.Parse((string) objArray2[1]);
            for (int index4 = 0; index4 < GameScr.keySkill.Length; ++index4)
            {
              if (GameScr.keySkill[index4] == skill2)
                GameScr.keySkill[index4] = (Skill) null;
            }
            GameScr.keySkill[index3] = skill2;
            this.saveKeySkillToRMS();
            return;
          default:
            switch (idAction - 12000)
            {
              case 0:
                Service.gI().getClan((sbyte) 1, (sbyte) -1, (string) null);
                return;
              case 1:
                GameCanvas.endDlg();
                return;
              case 2:
                GameCanvas.endDlg();
                ClanObject clanObject1 = (ClanObject) p;
                Service.gI().clanInvite((sbyte) 1, -1, clanObject1.clanID, clanObject1.code);
                this.popUpYesNo = (PopUpYesNo) null;
                return;
              case 3:
                ClanObject clanObject2 = (ClanObject) p;
                GameCanvas.endDlg();
                Service.gI().clanInvite((sbyte) 2, -1, clanObject2.clanID, clanObject2.code);
                this.popUpYesNo = (PopUpYesNo) null;
                return;
              case 4:
                this.doUseSkill((Skill) p, true);
                Char.myCharz().saveLoadPreviousSkill();
                return;
              default:
                switch (idAction - 11000)
                {
                  case 0:
                    this.actMenu();
                    return;
                  case 1:
                    Char.myCharz().findNextFocusByKey();
                    return;
                  case 2:
                    GameCanvas.panel.hide();
                    return;
                  default:
                    if (idAction != 1)
                    {
                      if (idAction != 2)
                      {
                        switch (idAction - 11057)
                        {
                          case 0:
                            Effect2.vEffect2Outside.removeAllElements();
                            Effect2.vEffect2.removeAllElements();
                            Npc npc = (Npc) p;
                            if (npc.idItem == 0)
                            {
                              Service.gI().confirmMenu((short) npc.template.npcTemplateId, (sbyte) GameCanvas.menu.menuSelectedItem);
                              return;
                            }
                            if (GameCanvas.menu.menuSelectedItem != 0)
                              return;
                            Service.gI().pickItem(npc.idItem);
                            return;
                          case 2:
                            this.doUseSkill(GameScr.onScreenSkill[this.selectedIndexSkill], false);
                            this.center = (Command) null;
                            return;
                          default:
                            switch (idAction - 110001)
                            {
                              case 0:
                                GameCanvas.panel.setTypeMain();
                                GameCanvas.panel.show();
                                return;
                              case 3:
                                GameCanvas.menu.showMenu = false;
                                return;
                              default:
                                if (idAction != 110382)
                                {
                                  if (idAction != 110383)
                                  {
                                    if (idAction != 8002)
                                    {
                                      if (idAction != 11038)
                                      {
                                        if (idAction != 11067)
                                        {
                                          if (idAction != 110391)
                                          {
                                            if (idAction != 888351)
                                              return;
                                            Service.gI().petStatus((sbyte) 5);
                                            GameCanvas.endDlg();
                                            return;
                                          }
                                          Service.gI().clanInvite((sbyte) 0, Char.myCharz().charFocus.charID, -1, -1);
                                          return;
                                        }
                                        if (TileMap.zoneID != GameScr.indexSelect)
                                        {
                                          Service.gI().requestChangeZone(GameScr.indexSelect, this.indexItemUse);
                                          InfoDlg.showWait();
                                          return;
                                        }
                                        GameScr.info1.addInfo(mResources.ZONE_HERE, 0);
                                        return;
                                      }
                                      this.actDead();
                                      return;
                                    }
                                    this.doFire(false, true);
                                    GameCanvas.clearKeyHold();
                                    GameCanvas.clearKeyPressed();
                                    return;
                                  }
                                  Service.gI().wakeUpFromDead();
                                  return;
                                }
                                Service.gI().returnTownFromDead();
                                return;
                            }
                        }
                      }
                      else
                      {
                        GameCanvas.menu.showMenu = false;
                        return;
                      }
                    }
                    else
                    {
                      GameCanvas.endDlg();
                      return;
                    }
                }
            }
        }
    }
  }

  private static void setTouchBtn()
  {
    if (GameScr.isAnalog == 0)
      return;
    GameScr.xTG = GameScr.xF = GameCanvas.w - 45;
    if (GameScr.gamePad.isLargeGamePad)
    {
      GameScr.xSkill = GameScr.gamePad.wZone + 20;
      GameScr.wSkill = 35;
      GameScr.xHP = GameScr.xF - 45;
    }
    else if (GameScr.gamePad.isMediumGamePad)
      GameScr.xHP = GameScr.xF - 45;
    GameScr.yF = GameCanvas.h - 45;
    GameScr.yTG = GameScr.yF - 45;
  }

  private void updateGamePad()
  {
    if (GameScr.isAnalog == 0 || Char.myCharz().statusMe == 14)
      return;
    if (GameCanvas.isPointerHoldIn(GameScr.xF, GameScr.yF, 40, 40))
    {
      mScreen.keyTouch = 5;
      if (GameCanvas.isPointerJustRelease)
      {
        GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = true;
        int num;
        GameCanvas.isPointerJustRelease = (num = 0) != 0;
        GameCanvas.isPointerJustDown = num != 0;
        GameCanvas.isPointerClick = num != 0;
      }
    }
    GameScr.gamePad.update();
    if (!GameCanvas.isPointerHoldIn(GameScr.xTG, GameScr.yTG, 34, 34))
      return;
    mScreen.keyTouch = 13;
    GameCanvas.isPointerJustDown = false;
    this.isPointerDowning = false;
    if (!GameCanvas.isPointerClick || !GameCanvas.isPointerJustRelease)
      return;
    Char.myCharz().findNextFocusByKey();
    int num1;
    GameCanvas.isPointerJustRelease = (num1 = 0) != 0;
    GameCanvas.isPointerJustDown = num1 != 0;
    GameCanvas.isPointerClick = num1 != 0;
  }

  private void paintGamePad(mGraphics g)
  {
    if (GameScr.isAnalog == 0 || Char.myCharz().statusMe == 14)
      return;
    g.drawImage(mScreen.keyTouch == 5 || mScreen.keyMouse == 5 ? GameScr.imgFire1 : GameScr.imgFire0, GameScr.xF + 20, GameScr.yF + 20, mGraphics.HCENTER | mGraphics.VCENTER);
    GameScr.gamePad.paint(g);
    g.drawImage(mScreen.keyTouch != 13 ? GameScr.imgFocus : GameScr.imgFocus2, GameScr.xTG + 20, GameScr.yTG + 20, mGraphics.HCENTER | mGraphics.VCENTER);
  }

  public void showWinNumber(string num, string finish)
  {
    string str = num;
    this.winnumber = new int[str.Length];
    this.randomNumber = new int[str.Length];
    this.tMove = new int[str.Length];
    this.moveCount = new int[str.Length];
    this.delayMove = new int[str.Length];
    for (int index = 0; index < str.Length; ++index)
    {
      this.winnumber[index] = (int) (short) str[index];
      this.randomNumber[index] = Res.random(0, 11);
      this.tMove[index] = 1;
      this.delayMove[index] = 0;
    }
    this.tShow = 100;
    this.moveIndex = 0;
    this.strFinish = finish;
    GameScr.lastXS = GameScr.currXS = mSystem.currentTimeMillis();
  }

  public void chatVip(string chatVip)
  {
    if (!this.startChat)
    {
      this.currChatWidth = mFont.tahoma_7b_yellowSmall.getWidth(chatVip);
      this.xChatVip = GameCanvas.w;
      this.startChat = true;
    }
    if (chatVip.StartsWith("!"))
    {
      chatVip = chatVip.Substring(1, chatVip.Length);
      this.isFireWorks = true;
    }
    GameScr.vChatVip.addElement((object) chatVip);
  }

  public void clearChatVip()
  {
    GameScr.vChatVip.removeAllElements();
    this.xChatVip = GameCanvas.w;
    this.startChat = false;
  }

  public void paintChatVip(mGraphics g)
  {
    if (GameScr.vChatVip.size() == 0 || !GameScr.isPaintChatVip)
      return;
    g.setClip(0, GameCanvas.h - 13, GameCanvas.w, 15);
    g.fillRect(0, GameCanvas.h - 13, GameCanvas.w, 15, 0, 90);
    string st = (string) GameScr.vChatVip.elementAt(0);
    mFont.tahoma_7b_yellow.drawString(g, st, this.xChatVip, GameCanvas.h - 13, 0, mFont.tahoma_7b_dark);
  }

  public void updateChatVip()
  {
    if (!this.startChat)
      return;
    this.xChatVip -= 2;
    if (this.xChatVip >= -this.currChatWidth)
      return;
    this.xChatVip = GameCanvas.w;
    GameScr.vChatVip.removeElementAt(0);
    if (GameScr.vChatVip.size() == 0)
    {
      this.isFireWorks = false;
      this.startChat = false;
    }
    else
      this.currChatWidth = mFont.tahoma_7b_white.getWidth((string) GameScr.vChatVip.elementAt(0));
  }

  public void showYourNumber(string strNum)
  {
    this.yourNumber = strNum;
    this.strPaint = mFont.tahoma_7.splitFontArray(this.yourNumber, 500);
  }

  public static void checkRemoveImage() => ImgByName.checkDelHash(ImgByName.hashImagePath, 10, false);

  public static void StartServerPopUp(string strMsg)
  {
    GameCanvas.endDlg();
    int num = 1139;
    Npc c = new Npc(-1, 0, 0, 0, 0, 0);
    c.avatar = num;
    ChatPopup.addBigMessage(strMsg, 100000, c);
    ChatPopup.serverChatPopUp.cmdMsg1 = new Command(mResources.CLOSE, (IActionListener) ChatPopup.serverChatPopUp, 1001, (object) null);
    ChatPopup.serverChatPopUp.cmdMsg1.x = GameCanvas.w / 2 - 35;
    ChatPopup.serverChatPopUp.cmdMsg1.y = GameCanvas.h - 35;
  }

  public static bool ispaintPhubangBar() => TileMap.mapPhuBang() && GameScr.phuban_Info.type_PB == 0;

  public void paintPhuBanBar(mGraphics g, int x, int y, int w)
  {
    if (GameScr.phuban_Info == null || GameScr.isPaintOther || GameScr.isPaintRada != 1 || GameCanvas.panel.isShow || !GameScr.ispaintPhubangBar())
      return;
    if (w < GameScr.fra_PVE_Bar_1.frameWidth + GameScr.fra_PVE_Bar_0.frameWidth * 4)
      w = GameScr.fra_PVE_Bar_1.frameWidth + GameScr.fra_PVE_Bar_0.frameWidth * 4;
    if (x > GameCanvas.w - w / 2)
      x = GameCanvas.w - w / 2;
    if (x < mGraphics.getImageWidth(GameScr.imgKhung) + w / 2 + 10)
      x = mGraphics.getImageWidth(GameScr.imgKhung) + w / 2 + 10;
    int frameHeight = GameScr.fra_PVE_Bar_0.frameHeight;
    int y1 = y + frameHeight + GameScr.imgBall.getHeight() / 2 + 2;
    int frameWidth = GameScr.fra_PVE_Bar_1.frameWidth;
    int num1 = w / 2 - frameWidth / 2;
    int x1 = x - w / 2;
    int x2 = x + frameWidth / 2;
    int y2 = y + 3;
    int num2 = num1 - GameScr.fra_PVE_Bar_0.frameWidth;
    int num3 = num2 / GameScr.fra_PVE_Bar_0.frameWidth;
    if (num2 % GameScr.fra_PVE_Bar_0.frameWidth > 0)
      ++num3;
    for (int index = 0; index < num3; ++index)
    {
      if (index < num3 - 1)
        GameScr.fra_PVE_Bar_0.drawFrame(1, x1 + GameScr.fra_PVE_Bar_0.frameWidth + index * GameScr.fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
      else
        GameScr.fra_PVE_Bar_0.drawFrame(1, x1 + num2, y2, 0, 0, g);
      if (index < num3 - 1)
        GameScr.fra_PVE_Bar_0.drawFrame(1, x2 + index * GameScr.fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
      else
        GameScr.fra_PVE_Bar_0.drawFrame(1, x2 + num2 - GameScr.fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
    }
    GameScr.fra_PVE_Bar_0.drawFrame(0, x1, y2, 2, 0, g);
    GameScr.fra_PVE_Bar_0.drawFrame(0, x2 + num2, y2, 0, 0, g);
    if (GameScr.phuban_Info.pointTeam1 > 0)
    {
      int idx1 = 2;
      int idx2 = 3;
      if (GameScr.phuban_Info.color_1 == 4)
      {
        idx1 = 4;
        idx2 = 5;
      }
      int w1 = GameScr.phuban_Info.pointTeam1 * num1 / GameScr.phuban_Info.maxPoint;
      if (w1 < 0)
        w1 = 0;
      if (w1 > num1)
        w1 = num1;
      g.setClip(x1 + num1 - w1, y2, w1, frameHeight);
      for (int index = 0; index < num3; ++index)
      {
        if (index < num3 - 1)
          GameScr.fra_PVE_Bar_0.drawFrame(idx2, x1 + GameScr.fra_PVE_Bar_0.frameWidth + index * GameScr.fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
        else
          GameScr.fra_PVE_Bar_0.drawFrame(idx2, x1 + num2, y2, 0, 0, g);
      }
      GameScr.fra_PVE_Bar_0.drawFrame(idx1, x1, y2, 2, 0, g);
      GameCanvas.resetTrans(g);
    }
    if (GameScr.phuban_Info.pointTeam2 > 0)
    {
      int idx3 = 2;
      int idx4 = 3;
      if (GameScr.phuban_Info.color_2 == 4)
      {
        idx3 = 4;
        idx4 = 5;
      }
      int w2 = GameScr.phuban_Info.pointTeam2 * num1 / GameScr.phuban_Info.maxPoint;
      if (w2 < 0)
        w2 = 0;
      if (w2 > num1)
        w2 = num1;
      g.setClip(x2, y2, w2, frameHeight);
      for (int index = 0; index < num3; ++index)
      {
        if (index < num3 - 1)
          GameScr.fra_PVE_Bar_0.drawFrame(idx4, x2 + index * GameScr.fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
        else
          GameScr.fra_PVE_Bar_0.drawFrame(idx4, x2 + num2 - GameScr.fra_PVE_Bar_0.frameWidth, y2, 0, 0, g);
      }
      GameScr.fra_PVE_Bar_0.drawFrame(idx3, x2 + num2, y2, 0, 0, g);
      GameCanvas.resetTrans(g);
    }
    GameScr.fra_PVE_Bar_1.drawFrame(0, x - frameWidth / 2, y, 0, 0, g);
    string timeCountDown = mSystem.getTimeCountDown(GameScr.phuban_Info.timeStart, (int) GameScr.phuban_Info.timeSecond, true, false);
    mFont.tahoma_7b_yellow.drawString(g, timeCountDown, x + 1, y + GameScr.fra_PVE_Bar_1.frameHeight / 2 - mFont.tahoma_7b_green2.getHeight() / 2, 2);
    Panel.setTextColor(GameScr.phuban_Info.color_1, 1).drawString(g, GameScr.phuban_Info.nameTeam1, x - 5, y1 + 5, 1);
    Panel.setTextColor(GameScr.phuban_Info.color_2, 1).drawString(g, GameScr.phuban_Info.nameTeam2, x + 5, y1 + 5, 0);
    if (GameScr.phuban_Info.type_PB != 0)
    {
      int y3 = y + frameHeight / 2 - 2;
      mFont.bigNumber_While.drawString(g, string.Empty + (object) GameScr.phuban_Info.pointTeam1, x1 + num1 / 2, y3, 2);
      mFont.bigNumber_While.drawString(g, string.Empty + (object) GameScr.phuban_Info.pointTeam2, x2 + num1 / 2, y3, 2);
    }
    g.drawImage(GameScr.imgVS, x, y + GameScr.fra_PVE_Bar_1.frameHeight + 2, 3);
    if (GameScr.phuban_Info.type_PB != 0)
      return;
    GameScr.paintChienTruong_Life(g, GameScr.phuban_Info.maxLife, GameScr.phuban_Info.color_1, GameScr.phuban_Info.lifeTeam1, x - 13, GameScr.phuban_Info.color_2, GameScr.phuban_Info.lifeTeam2, x + 13, y1);
  }

  public static void paintChienTruong_Life(
    mGraphics g,
    int maxLife,
    int cl1,
    int lifeTeam1,
    int x1,
    int cl2,
    int lifeTeam2,
    int x2,
    int y)
  {
    if (GameScr.imgBall == null)
      return;
    int h0 = GameScr.imgBall.getHeight() / 2;
    for (int index = 0; index < maxLife; ++index)
    {
      int num = 0;
      if (index < lifeTeam1)
        num = 1;
      g.drawRegion(GameScr.imgBall, 0, num * h0, GameScr.imgBall.getWidth(), h0, 0, x1 - index * (h0 + 1), y, mGraphics.VCENTER | mGraphics.HCENTER);
    }
    for (int index = 0; index < maxLife; ++index)
    {
      int num = 0;
      if (index < lifeTeam2)
        num = 1;
      g.drawRegion(GameScr.imgBall, 0, num * h0, GameScr.imgBall.getWidth(), h0, 0, x2 + index * (h0 + 1), y, mGraphics.VCENTER | mGraphics.HCENTER);
    }
  }

  public static void paintHPBar_NEW(mGraphics g, int x, int y, Char c)
  {
    g.drawImage(GameScr.imgKhung, x, y, 0);
    int x1 = x + 3;
    int y1 = y + 19;
    int width = GameScr.imgHP_NEW.getWidth();
    int num = GameScr.imgHP_NEW.getHeight() / 2;
    int w0_1 = c.cHP * width / c.cHPFull;
    if (w0_1 <= 0)
      w0_1 = 1;
    else if (w0_1 > width)
      w0_1 = width;
    g.drawRegion(GameScr.imgHP_NEW, 0, num, w0_1, num, 0, x1, y1, 0);
    int w0_2 = c.cMP * width / c.cMPFull;
    if (w0_2 <= 0)
      w0_2 = 1;
    else if (w0_2 > width)
      w0_2 = width;
    g.drawRegion(GameScr.imgHP_NEW, 0, 0, w0_2, num, 0, x1, y1 + 6, 0);
    int x2 = x + GameScr.imgKhung.getWidth() / 2 + 1;
    int y2 = y1 + 13;
    mFont.tahoma_7_green2.drawString(g, c.cName, x2, y + 4, 2);
    if (c.mobFocus != null)
    {
      if (c.mobFocus.getTemplate() == null)
        return;
      mFont.tahoma_7_green2.drawString(g, c.mobFocus.getTemplate().name, x2, y2, 2);
    }
    else if (c.npcFocus != null)
    {
      mFont.tahoma_7_green2.drawString(g, c.npcFocus.template.name, x2, y2, 2);
    }
    else
    {
      if (c.charFocus == null)
        return;
      mFont.tahoma_7_green2.drawString(g, c.charFocus.cName, x2, y2, 2);
    }
  }

  public static void addEffectEnd(int type, int subtype, int x, int y, int levelPaint, int dir) => GameScr.addEffect2Vector(new Effect_End(type, subtype, x, y, levelPaint, dir));

  public static void addEffect2Vector(Effect_End eff)
  {
    if (eff.levelPaint == 0)
      EffectManager.addHiEffect(eff);
    else if (eff.levelPaint == 1)
      EffectManager.addMidEffects(eff);
    else
      EffectManager.addLowEffect(eff);
  }

  public static bool setIsInScreen(int x, int y, int wOne, int hOne) => x >= GameScr.cmx - wOne && x <= GameScr.cmx + GameCanvas.w + wOne && y >= GameScr.cmy - hOne && y <= GameScr.cmy + GameCanvas.h + hOne * 3 / 2;

  public static bool isSmallScr() => GameCanvas.w <= 320;
}
