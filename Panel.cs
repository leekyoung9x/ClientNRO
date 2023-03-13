// Decompiled with JetBrains decompiler
// Type: Panel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.g;
using System;
using UnityEngine;

public class Panel : IActionListener, IChatable
{
  public bool isShow;
  public int X;
  public int Y;
  public int W;
  public int H;
  public int ITEM_HEIGHT;
  public int TAB_W;
  public int TAB_W_NEW;
  public int cmtoY;
  public int cmy;
  public int cmdy;
  public int cmvy;
  public int cmyLim;
  public int xc;
  public int[] cmyLast;
  public int cmtoX;
  public int cmx;
  public int cmxLim;
  public int cmxMap;
  public int cmyMap;
  public int cmxMapLim;
  public int cmyMapLim;
  public int cmyQuest;
  public static Image imgBantay;
  public static Image imgX;
  public static Image imgMap;
  public TabClanIcon tabIcon;
  public MyVector vItemCombine;
  public int moneyGD;
  public int friendMoneyGD;
  public bool isLock;
  public bool isFriendLock;
  public bool isAccept;
  public bool isFriendAccep;
  public string topName;
  public ChatTextField chatTField;
  public static string specialInfo;
  public static short spearcialImage;
  public static Image imgStar;
  public static Image imgMaxStar;
  public static Image imgStar8;
  public static Image imgNew;
  public static Image imgXu;
  public static Image imgTicket;
  public static Image imgLuong;
  public static Image imgLuongKhoa;
  private static Image imgUp;
  private static Image imgDown;
  private int pa1;
  private int pa2;
  private bool trans;
  private int pX;
  private int pY;
  private Command left;
  public int type;
  public int currentTabIndex;
  public int startTabPos;
  public int[] lastTabIndex;
  public string[][] currentTabName;
  private int[] currClanOption;
  public int mainTabPos;
  public int shopTabPos;
  public int boxTabPos;
  public string[][] mainTabName;
  public string[] mapNames;
  public string[] planetNames;
  public static string[] strTool = new string[7]
  {
    mResources.gameInfo,
    mResources.change_flag,
    mResources.change_zone,
    mResources.chat_world,
    mResources.account,
    mResources.option,
    mResources.change_account
  };
  public static string[] strCauhinh = new string[4]
  {
    !GameCanvas.isPlaySound ? mResources.turnOnSound : mResources.turnOffSound,
    mResources.increase_vga,
    mResources.analog,
    mGraphics.zoomLevel <= 1 ? mResources.x2Screen : mResources.x1Screen
  };
  public static string[] strAccount = new string[5]
  {
    mResources.inventory_Pass,
    mResources.friend,
    mResources.enemy,
    mResources.msg,
    mResources.charger
  };
  public static string[] strAuto = new string[1]
  {
    mResources.useGem
  };
  public static int graphics = 0;
  public string[][] shopTabName;
  public int[] maxPageShop;
  public int[] currPageShop;
  private static string[][] boxTabName = new string[2][]
  {
    mResources.chestt,
    mResources.inventory
  };
  private static string[][] boxCombine = new string[2][]
  {
    mResources.combine,
    mResources.inventory
  };
  private static string[][] boxZone = new string[1][]
  {
    mResources.zonee
  };
  private static string[][] boxMap = new string[1][]
  {
    mResources.mapp
  };
  private static string[][] boxGD = new string[3][]
  {
    mResources.inventory,
    mResources.item_give,
    mResources.item_receive
  };
  private static string[][] boxPet = mResources.petMainTab;
  public string[][][] tabName;
  private static sbyte BOX_BAG = 0;
  private static sbyte BAG_BOX = 1;
  private static sbyte BOX_BODY = 2;
  private static sbyte BODY_BOX = 3;
  private static sbyte BAG_BODY = 4;
  private static sbyte BODY_BAG = 5;
  private static sbyte BAG_PET = 6;
  private static sbyte PET_BAG = 7;
  public int hasUse;
  public int hasUseBag;
  public int currentListLength;
  private int[] lastSelect;
  public static int[] mapIdTraidat = new int[16]
  {
    21,
    0,
    1,
    2,
    24,
    3,
    4,
    5,
    6,
    27,
    28,
    29,
    30,
    42,
    47,
    46
  };
  public static int[] mapXTraidat = new int[16]
  {
    39,
    42,
    105,
    93,
    61,
    93,
    142,
    165,
    210,
    100,
    165,
    220,
    233,
    10,
    125,
    125
  };
  public static int[] mapYTraidat = new int[16]
  {
    28,
    60,
    48,
    96,
    88,
    131,
    136,
    95,
    32,
    200,
    189,
    167,
    120,
    110,
    20,
    20
  };
  public static int[] mapIdNamek = new int[14]
  {
    22,
    7,
    8,
    9,
    25,
    11,
    12,
    13,
    10,
    31,
    32,
    33,
    34,
    43
  };
  public static int[] mapXNamek = new int[14]
  {
    55,
    30,
    93,
    80,
    24,
    149,
    219,
    220,
    233,
    170,
    148,
    195,
    148,
    10
  };
  public static int[] mapYNamek = new int[14]
  {
    136,
    84,
    69,
    34,
    25,
    42,
    32,
    110,
    192,
    70,
    106,
    156,
    210,
    57
  };
  public static int[] mapIdSaya = new int[14]
  {
    23,
    14,
    15,
    16,
    26,
    17,
    18,
    20,
    19,
    35,
    36,
    37,
    38,
    44
  };
  public static int[] mapXSaya = new int[14]
  {
    90,
    95,
    144,
    234,
    231,
    122,
    176,
    158,
    205,
    54,
    105,
    159,
    231,
    27
  };
  public static int[] mapYSaya = new int[14]
  {
    10,
    43,
    20,
    36,
    69,
    87,
    112,
    167,
    160,
    151,
    173,
    207,
    194,
    29
  };
  public static int[][] mapId = new int[3][]
  {
    Panel.mapIdTraidat,
    Panel.mapIdNamek,
    Panel.mapIdSaya
  };
  public static int[][] mapX = new int[3][]
  {
    Panel.mapXTraidat,
    Panel.mapXNamek,
    Panel.mapXSaya
  };
  public static int[][] mapY = new int[3][]
  {
    Panel.mapYTraidat,
    Panel.mapYNamek,
    Panel.mapYSaya
  };
  public Item currItem;
  public Clan currClan;
  public ClanMessage currMess;
  public Member currMem;
  public Clan[] clans;
  public MyVector member;
  public MyVector myMember;
  public MyVector logChat;
  public MyVector vPlayerMenu;
  public MyVector vFriend;
  public MyVector vMyGD;
  public MyVector vFriendGD;
  public MyVector vTop;
  public MyVector vEnemy;
  public MyVector vFlag;
  public Command cmdClose;
  public static bool CanNapTien = false;
  public static int WIDTH_PANEL = 240;
  private int position;
  public Char charMenu;
  private bool isThachDau;
  public int typeShop;
  public int xScroll;
  public int yScroll;
  public int wScroll;
  public int hScroll;
  public ChatPopup cp;
  public int idIcon;
  public int[] partID;
  private int timeShow;
  public bool isBoxClan;
  public int w;
  private int pa;
  public int selected;
  private int cSelected;
  private int newSelected;
  private bool isClanOption;
  public bool isSearchClan;
  public bool isMessage;
  public bool isViewMember;
  public const int TYPE_MAIN = 0;
  public const int TYPE_SHOP = 1;
  public const int TYPE_BOX = 2;
  public const int TYPE_ZONE = 3;
  public const int TYPE_MAP = 4;
  public const int TYPE_CLANS = 5;
  public const int TYPE_INFOMATION = 6;
  public const int TYPE_BODY = 7;
  public const int TYPE_MESS = 8;
  public const int TYPE_ARCHIVEMENT = 9;
  public const int PLAYER_MENU = 10;
  public const int TYPE_FRIEND = 11;
  public const int TYPE_COMBINE = 12;
  public const int TYPE_GIAODICH = 13;
  public const int TYPE_MAPTRANS = 14;
  public const int TYPE_TOP = 15;
  public const int TYPE_ENEMY = 16;
  public const int TYPE_KIGUI = 17;
  public const int TYPE_FLAG = 18;
  public const int TYPE_OPTION = 19;
  public const int TYPE_ACCOUNT = 20;
  public const int TYPE_PET_MAIN = 21;
  public const int TYPE_AUTO = 22;
  public const int TYPE_GAMEINFO = 23;
  public const int TYPE_GAMEINFOSUB = 24;
  public const int TYPE_SPEACIALSKILL = 25;
  private int pointerDownTime;
  private int pointerDownFirstX;
  private int[] pointerDownLastX;
  private bool pointerIsDowning;
  private bool isDownWhenRunning;
  private bool wantUpdateList;
  private int waitToPerform;
  private int cmRun;
  private int keyTouchLock;
  private int keyToundGD;
  private int keyTouchCombine;
  private int keyTouchMapButton;
  public int indexMouse;
  private bool justRelease;
  private int keyTouchTab;
  public string[][] clansOption;
  public string clanInfo;
  public string clanReport;
  private bool isHaveClan;
  private Scroll scroll;
  private int cmvx;
  private int cmdx;
  private bool isSelectPlayerMenu;
  private string[] strStatus;
  private int currentButtonPress;
  private int[] zoneColor;
  public string[] combineInfo;
  public string[] combineTopInfo;
  public static int[] color1 = new int[3]
  {
    2327248,
    8982199,
    16713222
  };
  public static int[] color2 = new int[3]
  {
    4583423,
    16719103,
    16714764
  };
  private bool isUp;
  private int compare;
  public static string strWantToBuy = string.Empty;
  public int xstart;
  public int ystart;
  public int popupW;
  public int popupH;
  public int cmySK;
  public int cmtoYSK;
  public int cmdySK;
  public int cmvySK;
  public int cmyLimSK;
  public int popupY;
  public int popupX;
  public int isborderIndex;
  public int isselectedRow;
  public int indexSize;
  public int indexTitle;
  public int indexSelect;
  public int indexRow;
  public int indexRowMax;
  public int indexMenu;
  public int columns;
  public int rows;
  public int inforX;
  public int inforY;
  public int inforW;
  public int inforH;
  private int yPaint;
  private int xMap;
  private int yMap;
  private int xMapTask;
  private int yMapTask;
  private int xMove;
  private int yMove;
  public static bool isPaintMap = true;
  public bool isClose;
  private int infoSelect;
  public static MyVector vGameInfo = new MyVector(string.Empty);
  public static string[] contenInfo;
  public bool isViewChatServer;
  private int currInfoItem;
  public Char charInfo;
  private bool isChangeZone;
  private bool isKiguiXu;
  private bool isKiguiLuong;
  private int delayKigui;
  public sbyte combineSuccess;
  public int idNPC;
  public int xS;
  public int yS;
  private int rS;
  private int angleS;
  private int angleO;
  private int iAngleS;
  private int iDotS;
  private int speed;
  private int[] xArgS;
  private int[] yArgS;
  private int[] xDotS;
  private int[] yDotS;
  private int time;
  private int typeCombine;
  private int countUpdate;
  private int countR;
  private int countWait;
  private bool isSpeedCombine;
  private bool isCompleteEffCombine;
  private bool isPaintCombine;
  public bool isDoneCombine;
  public short iconID1;
  public short iconID2;
  public short iconID3;
  public short[] iconID;
  public string[][] speacialTabName;
  public static int[] sizeUpgradeEff = new int[3]{ 2, 1, 1 };
  public static int nsize = 1;
  public const sbyte COLOR_WHITE = 0;
  public const sbyte COLOR_GREEN = 1;
  public const sbyte COLOR_PURPLE = 2;
  public const sbyte COLOR_ORANGE = 3;
  public const sbyte COLOR_BLUE = 4;
  public const sbyte COLOR_YELLOW = 5;
  public const sbyte COLOR_RED = 6;
  public const sbyte COLOR_BLACK = 7;
  public static int[][] colorUpgradeEffect = new int[7][]
  {
    new int[6]
    {
      16777215,
      15000805,
      13487823,
      11711155,
      9671828,
      7895160
    },
    new int[6]{ 61952, 58624, 52224, 45824, 39168, 32768 },
    new int[6]
    {
      13500671,
      12058853,
      10682572,
      9371827,
      7995545,
      6684800
    },
    new int[6]
    {
      16744192,
      15037184,
      13395456,
      11753728,
      10046464,
      8404992
    },
    new int[6]{ 37119, 33509, 28108, 24499, 21145, 17536 },
    new int[6]
    {
      16776192,
      15063040,
      12635136,
      11776256,
      10063872,
      8290304
    },
    new int[6]
    {
      16711680,
      15007744,
      13369344,
      11730944,
      10027008,
      8388608
    }
  };
  public const int color_item_white = 15987701;
  public const int color_item_green = 2786816;
  public const int color_item_purple = 7078041;
  public const int color_item_orange = 12537346;
  public const int color_item_blue = 1269146;
  public const int color_item_yellow = 13279744;
  public const int color_item_red = 11599872;
  public const int color_item_black = 2039326;
  private Image imgo_0;
  private Image imgo_1;
  private Image imgo_2;
  private Image imgo_3;
  public const int numItem = 20;
  public const sbyte INVENTORY_TAB = 1;
  public sbyte size_tab;

  public Panel()
  {
    string[][][] strArray = new string[27][][]
    {
      null,
      null,
      Panel.boxTabName,
      Panel.boxZone,
      Panel.boxMap,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      null
    };
    strArray[7] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[8] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[9] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[10] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[11] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[12] = Panel.boxCombine;
    strArray[13] = Panel.boxGD;
    strArray[14] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[15] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[16] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[17] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[18] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[19] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[20] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[21] = Panel.boxPet;
    strArray[22] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[23] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[24] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[25] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    strArray[26] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    this.tabName = strArray;
    this.logChat = new MyVector();
    this.vPlayerMenu = new MyVector();
    this.vFriend = new MyVector();
    this.vMyGD = new MyVector();
    this.vFriendGD = new MyVector();
    this.vTop = new MyVector();
    this.vEnemy = new MyVector();
    this.vFlag = new MyVector();
    this.typeShop = -1;
    this.pointerDownLastX = new int[3];
    this.keyTouchLock = -1;
    this.keyToundGD = -1;
    this.keyTouchCombine = -1;
    this.keyTouchMapButton = -1;
    this.indexMouse = -1;
    this.keyTouchTab = -1;
    this.clanInfo = string.Empty;
    this.clanReport = string.Empty;
    this.strStatus = new string[6]
    {
      mResources.follow,
      mResources.defend,
      mResources.attack,
      mResources.gohome,
      mResources.fusion,
      mResources.fusionForever
    };
    this.zoneColor = new int[3]{ 43520, 14743570, 14155776 };
    this.popupW = 140;
    this.popupH = 160;
    this.indexSize = 28;
    this.indexRow = -1;
    this.columns = 6;
    this.combineSuccess = (sbyte) -1;
    this.isCompleteEffCombine = true;
    this.isDoneCombine = true;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.init();
    this.cmdClose = new Command(string.Empty, (IActionListener) this, 1003, (object) null);
    this.cmdClose.img = GameCanvas.loadImage("/mainImage/myTexture2dbtX.png");
    this.cmdClose.cmdClosePanel = true;
  }

  public static void loadBg()
  {
    Panel.imgMap = GameCanvas.loadImage("/img/map" + (object) TileMap.planetID + ".png");
    Panel.imgBantay = GameCanvas.loadImage("/mainImage/myTexture2dbantay.png");
    Panel.imgX = GameCanvas.loadImage("/mainImage/myTexture2dbtX.png");
    Panel.imgXu = GameCanvas.loadImage("/mainImage/myTexture2dimgMoney.png");
    Panel.imgLuong = GameCanvas.loadImage("/mainImage/myTexture2dimgDiamond.png");
    Panel.imgLuongKhoa = GameCanvas.loadImage("/mainImage/luongkhoa.png");
    Panel.imgUp = GameCanvas.loadImage("/mainImage/myTexture2dup.png");
    Panel.imgDown = GameCanvas.loadImage("/mainImage/myTexture2ddown.png");
    Panel.imgStar = GameCanvas.loadImage("/mainImage/star.png");
    Panel.imgMaxStar = GameCanvas.loadImage("/mainImage/starE.png");
    Panel.imgStar8 = GameCanvas.loadImage("/mainImage/star8.png");
    Panel.imgNew = GameCanvas.loadImage("/mainImage/new.png");
    Panel.imgTicket = GameCanvas.loadImage("/mainImage/ticket12.png");
  }

  public void init()
  {
    this.pX = GameCanvas.pxLast + this.cmxMap;
    this.pY = GameCanvas.pyLast + this.cmyMap;
    this.lastTabIndex = new int[this.tabName.Length];
    for (int index = 0; index < this.lastTabIndex.Length; ++index)
      this.lastTabIndex[index] = -1;
  }

  public int getXMap()
  {
    for (int index = 0; index < Panel.mapId[(int) TileMap.planetID].Length; ++index)
    {
      if (TileMap.mapID == Panel.mapId[(int) TileMap.planetID][index])
        return Panel.mapX[(int) TileMap.planetID][index];
    }
    return -1;
  }

  public int getYMap()
  {
    for (int index = 0; index < Panel.mapId[(int) TileMap.planetID].Length; ++index)
    {
      if (TileMap.mapID == Panel.mapId[(int) TileMap.planetID][index])
        return Panel.mapY[(int) TileMap.planetID][index];
    }
    return -1;
  }

  public int getXMapTask()
  {
    if (Char.myCharz().taskMaint == null)
      return -1;
    for (int index = 0; index < Panel.mapId[(int) TileMap.planetID].Length; ++index)
    {
      if (GameScr.mapTasks[Char.myCharz().taskMaint.index] == Panel.mapId[(int) TileMap.planetID][index])
        return Panel.mapX[(int) TileMap.planetID][index];
    }
    return -1;
  }

  public int getYMapTask()
  {
    if (Char.myCharz().taskMaint == null)
      return -1;
    for (int index = 0; index < Panel.mapId[(int) TileMap.planetID].Length; ++index)
    {
      if (GameScr.mapTasks[Char.myCharz().taskMaint.index] == Panel.mapId[(int) TileMap.planetID][index])
        return Panel.mapY[(int) TileMap.planetID][index];
    }
    return -1;
  }

  private void setType(int position)
  {
    this.typeShop = -1;
    this.W = Panel.WIDTH_PANEL;
    this.H = GameCanvas.h;
    this.X = 0;
    this.Y = 0;
    this.ITEM_HEIGHT = 24;
    this.position = position;
    switch (position)
    {
      case 0:
        this.xScroll = 2;
        this.yScroll = 80;
        this.wScroll = this.W - 4;
        this.hScroll = this.H - 96;
        this.cmx = this.wScroll;
        this.cmtoX = 0;
        this.X = 0;
        break;
      case 1:
        this.wScroll = this.W - 4;
        this.xScroll = GameCanvas.w - this.wScroll;
        this.yScroll = 80;
        this.hScroll = this.H - 96;
        this.X = this.xScroll - 2;
        this.cmx = -(GameCanvas.w + this.W);
        this.cmtoX = GameCanvas.w - this.W;
        break;
    }
    this.TAB_W = this.W / 5 - 1;
    this.currentTabIndex = 0;
    this.currentTabName = this.tabName[this.type];
    if (this.currentTabName.Length < 5)
      this.TAB_W += 5;
    this.startTabPos = this.xScroll + this.wScroll / 2 - this.currentTabName.Length * this.TAB_W / 2;
    this.lastSelect = new int[this.currentTabName.Length];
    this.cmyLast = new int[this.currentTabName.Length];
    for (int index = 0; index < this.currentTabName.Length; ++index)
      this.lastSelect[index] = !GameCanvas.isTouch ? 0 : -1;
    if (this.lastTabIndex[this.type] != -1)
      this.currentTabIndex = this.lastTabIndex[this.type];
    if (this.currentTabIndex < 0)
      this.currentTabIndex = 0;
    if (this.currentTabIndex > this.currentTabName.Length - 1)
      this.currentTabIndex = this.currentTabName.Length - 1;
    this.scroll = (Scroll) null;
  }

  public void setTypeMapTrans()
  {
    this.type = 14;
    this.setType(0);
    this.setTabMapTrans();
    this.cmx = this.cmtoX = 0;
  }

  public void setTypeInfomatioin()
  {
    this.type = 6;
    this.cmx = this.wScroll;
    this.cmtoX = 0;
  }

  public void setTypeMap()
  {
    if (GameScr.gI().isMapFize() || !Panel.isPaintMap)
      return;
    if (Hint.isOnTask(2, 0))
    {
      Hint.isViewMap = true;
      GameScr.info1.addInfo(mResources.go_to_quest, 0);
    }
    this.type = 4;
    this.currentTabName = this.tabName[this.type];
    this.startTabPos = this.xScroll + this.wScroll / 2 - this.currentTabName.Length * this.TAB_W / 2;
    this.cmx = this.cmtoX = 0;
    this.setTabMap();
  }

  public void setTypeArchivement()
  {
    this.currentListLength = Char.myCharz().arrArchive.Length;
    this.setType(0);
    this.type = 9;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = 0;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  public void setTypeKiGuiOnly()
  {
    this.type = 17;
    this.setType(1);
    this.setTabKiGui();
    this.typeShop = 2;
    this.currentTabIndex = 0;
  }

  public void setTabKiGui()
  {
    this.ITEM_HEIGHT = 24;
    this.currentListLength = Char.myCharz().arrItemShop[4].Length;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  public void setTypeBodyOnly()
  {
    this.type = 7;
    this.setType(1);
    this.setTabInventory(true);
    this.currentTabIndex = 0;
  }

  public void addChatMessage(InfoItem info)
  {
    this.logChat.insertElementAt((object) info, 0);
    if (this.logChat.size() <= 20)
      return;
    this.logChat.removeElementAt(this.logChat.size() - 1);
  }

  public void addPlayerMenu(Command pm) => this.vPlayerMenu.addElement((object) pm);

  public void setTabPlayerMenu()
  {
    this.ITEM_HEIGHT = 24;
    this.currentListLength = this.vPlayerMenu.size();
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  public void setTypeFlag()
  {
    this.type = 18;
    this.setType(0);
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.setTabFlag();
  }

  public void setTabFlag()
  {
    this.currentListLength = this.vFlag.size();
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    if (this.selected > this.currentListLength - 1)
      this.selected = this.currentListLength - 1;
    this.cmx = this.cmtoX = 0;
  }

  public void setTypePlayerMenu(Char c)
  {
    this.type = 10;
    this.setType(0);
    this.setTabPlayerMenu();
    this.charMenu = c;
  }

  public void setTypeFriend()
  {
    this.type = 11;
    this.setType(0);
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.setTabFriend();
  }

  public void setTypeEnemy()
  {
    this.type = 16;
    this.setType(0);
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.setTabEnemy();
  }

  public void setTypeTop(sbyte t)
  {
    this.type = 15;
    this.setType(0);
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.setTabTop();
    this.isThachDau = t != (sbyte) 0;
  }

  public void setTabTop()
  {
    this.currentListLength = this.vTop.size();
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    if (this.selected > this.currentListLength - 1)
      this.selected = this.currentListLength - 1;
    this.cmx = this.cmtoX = 0;
  }

  public void setTabFriend()
  {
    this.currentListLength = this.vFriend.size();
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    if (this.selected > this.currentListLength - 1)
      this.selected = this.currentListLength - 1;
    this.cmx = this.cmtoX = 0;
  }

  public void setTabEnemy()
  {
    this.currentListLength = this.vEnemy.size();
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    if (this.selected > this.currentListLength - 1)
      this.selected = this.currentListLength - 1;
    this.cmx = this.cmtoX = 0;
  }

  public void setTypeMessage()
  {
    this.type = 8;
    this.setType(0);
    this.setTabMessage();
    this.currentTabIndex = 0;
  }

  public void setTypeLockInventory()
  {
    this.type = 8;
    this.setType(0);
    this.setTabMessage();
    this.currentTabIndex = 0;
  }

  public void setTypeShop(int typeShop)
  {
    this.type = 1;
    this.setType(0);
    this.setTabShop();
    this.currentTabIndex = 0;
    this.typeShop = typeShop;
  }

  public void setTypeBox()
  {
    this.type = 2;
    if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
      Panel.boxTabName = new string[1][]
      {
        mResources.chestt
      };
    else
      Panel.boxTabName = new string[2][]
      {
        mResources.chestt,
        mResources.inventory
      };
    this.tabName[2] = Panel.boxTabName;
    this.setType(0);
    if (this.currentTabIndex == 0)
      this.setTabBox();
    if (this.currentTabIndex == 1)
      this.setTabInventory(true);
    if (GameCanvas.w <= 2 * Panel.WIDTH_PANEL)
      return;
    GameCanvas.panel2 = new Panel();
    GameCanvas.panel2.tabName[7] = new string[1][]
    {
      new string[1]{ string.Empty }
    };
    GameCanvas.panel2.setTypeBodyOnly();
    GameCanvas.panel2.show();
  }

  public void setTypeCombine()
  {
    this.type = 12;
    if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
      Panel.boxCombine = new string[1][]
      {
        mResources.combine
      };
    else
      Panel.boxCombine = new string[2][]
      {
        mResources.combine,
        mResources.inventory
      };
    this.tabName[this.type] = Panel.boxCombine;
    this.setType(0);
    if (this.currentTabIndex == 0)
      this.setTabCombine();
    if (this.currentTabIndex == 1)
      this.setTabInventory(true);
    if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
    {
      GameCanvas.panel2 = new Panel();
      GameCanvas.panel2.tabName[7] = new string[1][]
      {
        new string[1]{ string.Empty }
      };
      GameCanvas.panel2.setTypeBodyOnly();
      GameCanvas.panel2.show();
    }
    this.combineSuccess = (sbyte) -1;
    this.isDoneCombine = true;
  }

  public void setTabCombine()
  {
    this.currentListLength = this.vItemCombine.size() + 1;
    this.ITEM_HEIGHT = 24;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 9;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  public void setTypeAuto()
  {
    this.type = 22;
    this.setType(0);
    this.setTabAuto();
    this.cmx = this.cmtoX = 0;
  }

  private void setTabAuto()
  {
    this.currentListLength = Panel.strAuto.Length;
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy <= this.cmyLim)
      return;
    this.cmy = this.cmtoY = this.cmyLim;
  }

  public void setTypePetMain()
  {
    this.type = 21;
    Panel.boxPet = GameCanvas.panel2 == null ? mResources.petMainTab : mResources.petMainTab2;
    this.tabName[21] = Panel.boxPet;
    if (Char.myCharz().cgender == 1)
      this.strStatus = new string[6]
      {
        mResources.follow,
        mResources.defend,
        mResources.attack,
        mResources.gohome,
        mResources.fusion,
        mResources.fusionForever
      };
    else
      this.strStatus = new string[5]
      {
        mResources.follow,
        mResources.defend,
        mResources.attack,
        mResources.gohome,
        mResources.fusion
      };
    this.setType(2);
    if (this.currentTabIndex == 0)
      this.setTabPetInventory();
    if (this.currentTabIndex == 1)
      this.setTabPetStatus();
    if (this.currentTabIndex != 2)
      return;
    this.setTabInventory(true);
  }

  public void setTypeMain()
  {
    this.type = 0;
    this.setType(0);
    if (this.currentTabIndex == 1)
      this.setTabInventory(true);
    if (this.currentTabIndex == 2)
      this.setTabSkill();
    if (this.currentTabIndex == 3)
    {
      if (this.mainTabName.Length == 4)
        this.setTabTool();
      else
        this.setTabClans();
    }
    if (this.currentTabIndex != 4)
      return;
    this.setTabTool();
  }

  public void setTypeZone()
  {
    this.type = 3;
    this.setType(0);
    this.setTabZone();
    this.cmx = this.cmtoX = 0;
  }

  public void addItemDetail(Item item)
  {
    this.cp = new ChatPopup();
    string empty = string.Empty;
    string str1 = string.Empty;
    if ((int) item.template.gender != Char.myCharz().cgender)
    {
      if (item.template.gender == (sbyte) 0)
        str1 = str1 + "\n|7|1|" + mResources.from_earth;
      else if (item.template.gender == (sbyte) 1)
        str1 = str1 + "\n|7|1|" + mResources.from_namec;
      else if (item.template.gender == (sbyte) 2)
        str1 = str1 + "\n|7|1|" + mResources.from_sayda;
    }
    string str2 = string.Empty;
    if (item.itemOption != null)
    {
      for (int index = 0; index < item.itemOption.Length; ++index)
      {
        if (item.itemOption[index].optionTemplate.id == 72)
          str2 = " [+" + (object) item.itemOption[index].param + "]";
      }
    }
    bool flag = false;
    if (item.itemOption != null)
    {
      for (int index = 0; index < item.itemOption.Length; ++index)
      {
        if (item.itemOption[index].optionTemplate.id == 41)
        {
          flag = true;
          if (item.itemOption[index].param == 1)
            str1 = str1 + "|0|1|" + item.template.name + str2;
          if (item.itemOption[index].param == 2)
            str1 = str1 + "|2|1|" + item.template.name + str2;
          if (item.itemOption[index].param == 3)
            str1 = str1 + "|8|1|" + item.template.name + str2;
          if (item.itemOption[index].param == 4)
            str1 = str1 + "|7|1|" + item.template.name + str2;
        }
      }
    }
    if (!flag)
      str1 = str1 + "|0|1|" + item.template.name + str2;
    if (item.itemOption != null)
    {
      for (int index = 0; index < item.itemOption.Length; ++index)
      {
        if (item.itemOption[index].optionTemplate.name.StartsWith("$"))
        {
          string optiongColor = item.itemOption[index].getOptiongColor();
          if (item.itemOption[index].param == 1)
            str1 = str1 + "\n|1|1|" + optiongColor;
          if (item.itemOption[index].param == 0)
            str1 = str1 + "\n|0|1|" + optiongColor;
        }
        else
        {
          string optionString = item.itemOption[index].getOptionString();
          if (!optionString.Equals(string.Empty) && item.itemOption[index].optionTemplate.id != 72)
          {
            if (item.itemOption[index].optionTemplate.id == 102)
            {
              this.cp.starSlot = (sbyte) item.itemOption[index].param;
              Res.outz("STAR SLOT= " + (object) this.cp.starSlot);
            }
            else if (item.itemOption[index].optionTemplate.id == 107)
            {
              this.cp.maxStarSlot = (sbyte) item.itemOption[index].param;
              Res.outz("STAR SLOT= " + (object) this.cp.maxStarSlot);
            }
            else
              str1 = str1 + "\n|1|1|" + optionString;
          }
        }
      }
    }
    string str3;
    if (this.currItem.template.strRequire > 1)
    {
      string str4 = mResources.pow_request + ": " + (object) this.currItem.template.strRequire;
      if ((long) this.currItem.template.strRequire > Char.myCharz().cPower)
        str3 = str1 + "\n|3|1|" + str4 + "\n|3|1|" + mResources.your_pow + ": " + (object) Char.myCharz().cPower;
      else
        str3 = str1 + "\n|6|1|" + str4;
    }
    else
      str3 = str1 + "\n|6|1|";
    this.currItem.compare = this.getCompare(this.currItem);
    string chat = str3 + "\n--" + "\n|6|" + item.template.description;
    if (!item.reason.Equals(string.Empty))
    {
      if (!item.template.description.Equals(string.Empty))
        chat += "\n--";
      chat = chat + "\n|2|" + item.reason;
    }
    if (this.cp.maxStarSlot > (sbyte) 0)
      chat += "\n\n";
    this.popUpDetailInit(this.cp, chat);
    this.idIcon = (int) item.template.iconID;
    this.partID = (int[]) null;
    this.charInfo = (Char) null;
  }

  public void popUpDetailInit(ChatPopup cp, string chat)
  {
    cp.isClip = false;
    cp.sayWidth = 180;
    cp.cx = 3 + this.X - (this.X != 0 ? Res.abs(cp.sayWidth - this.W) + 8 : 0);
    cp.says = mFont.tahoma_7_red.splitFontArray(chat, cp.sayWidth - 10);
    cp.delay = 10000000;
    cp.c = (Npc) null;
    cp.sayRun = 7;
    cp.ch = 15 - cp.sayRun + cp.says.Length * 12 + 10;
    if (cp.ch > GameCanvas.h - 80)
    {
      cp.ch = GameCanvas.h - 80;
      cp.lim = cp.says.Length * 12 - cp.ch + 17;
      if (cp.lim < 0)
        cp.lim = 0;
      ChatPopup.cmyText = 0;
      cp.isClip = true;
    }
    cp.cy = GameCanvas.menu.menuY - cp.ch;
    while (cp.cy < 10)
    {
      ++cp.cy;
      ++GameCanvas.menu.menuY;
    }
    cp.mH = 0;
    cp.strY = 10;
  }

  public void popUpDetailInitArray(ChatPopup cp, string[] chat)
  {
    cp.sayWidth = 160;
    cp.cx = 3 + this.X;
    cp.says = chat;
    cp.delay = 10000000;
    cp.c = (Npc) null;
    cp.sayRun = 7;
    cp.ch = 15 - cp.sayRun + cp.says.Length * 12 + 10;
    cp.cy = GameCanvas.menu.menuY - cp.ch;
    cp.mH = 0;
    cp.strY = 10;
  }

  public void addMessageDetail(ClanMessage cm)
  {
    this.cp = new ChatPopup();
    string str = "|0|" + cm.playerName + "\n|1|" + Member.getRole((int) cm.role);
    for (int index = 0; index < this.myMember.size(); ++index)
    {
      Member member = (Member) this.myMember.elementAt(index);
      if (cm.playerId == member.ID)
      {
        str = str + "\n|5|" + mResources.clan_capsuledonate + ": " + (object) member.clanPoint + "\n|5|" + mResources.clan_capsuleself + ": " + (object) member.curClanPoint + "\n|4|" + mResources.give_pea + ": " + (object) member.donate + mResources.time + "\n|4|" + mResources.receive_pea + ": " + (object) member.receive_donate + mResources.time;
        this.partID = new int[3]
        {
          (int) member.head,
          (int) member.leg,
          (int) member.body
        };
        break;
      }
    }
    string chat = str + "\n--";
    for (int index = 0; index < cm.chat.Length; ++index)
      chat = chat + "\n" + cm.chat[index];
    if (cm.type == 1)
      chat = chat + "\n|6|" + mResources.received + " " + (object) cm.recieve + "/" + (object) cm.maxCap;
    this.popUpDetailInit(this.cp, chat);
    this.charInfo = (Char) null;
  }

  public void addThachDauDetail(TopInfo t)
  {
    string chat = "|0|1|" + t.name + "\n|1|Top " + (object) t.rank + "\n|1|" + t.info + "\n|2|" + t.info2;
    this.cp = new ChatPopup();
    this.popUpDetailInit(this.cp, chat);
    this.partID = new int[3]
    {
      t.headID,
      (int) t.leg,
      (int) t.body
    };
    this.currItem = (Item) null;
    this.charInfo = (Char) null;
  }

  public void addClanMemberDetail(Member m)
  {
    string str1 = "|0|1|" + m.name;
    string str2 = "\n|2|1|";
    if (m.role == (sbyte) 0)
      str2 = "\n|7|1|";
    if (m.role == (sbyte) 1)
      str2 = "\n|1|1|";
    if (m.role == (sbyte) 2)
      str2 = "\n|0|1|";
    string chat = str1 + str2 + Member.getRole((int) m.role) + "\n|2|1|" + mResources.power + ": " + m.powerPoint + "\n--" + "\n|5|" + mResources.clan_capsuledonate + ": " + (object) m.clanPoint + "\n|5|" + mResources.clan_capsuleself + ": " + (object) m.curClanPoint + "\n|4|" + mResources.give_pea + ": " + (object) m.donate + mResources.time + "\n|4|" + mResources.receive_pea + ": " + (object) m.receive_donate + mResources.time + "\n|6|" + mResources.join_date + ": " + m.joinTime;
    this.cp = new ChatPopup();
    this.popUpDetailInit(this.cp, chat);
    this.partID = new int[3]
    {
      (int) m.head,
      (int) m.leg,
      (int) m.body
    };
    this.currItem = (Item) null;
    this.charInfo = (Char) null;
  }

  public void addClanDetail(Clan cl)
  {
    string str = "|0|" + cl.name;
    foreach (string splitFont in mFont.tahoma_7_green.splitFontArray(cl.slogan, this.wScroll - 60))
      str = str + "\n|2|" + splitFont;
    string chat = str + "\n--" + "\n|7|" + mResources.clan_leader + ": " + cl.leaderName + "\n|1|" + mResources.power_point + ": " + cl.powerPoint + "\n|4|" + mResources.member + ": " + (object) cl.currMember + "/" + (object) cl.maxMember + "\n|4|" + mResources.level + ": " + (object) cl.level + "\n|4|" + mResources.clan_birthday + ": " + NinjaUtil.getDate(cl.date);
    this.cp = new ChatPopup();
    this.popUpDetailInit(this.cp, chat);
    this.idIcon = (int) ClanImage.getClanImage((sbyte) cl.imgID).idImage[0];
    this.currItem = (Item) null;
  }

  public void addSkillDetail(SkillTemplate tp, Skill skill, Skill nextSkill)
  {
    string str1 = "|0|" + tp.name;
    for (int index = 0; index < tp.description.Length; ++index)
      str1 = str1 + "\n|4|" + tp.description[index];
    string str2 = str1 + "\n--";
    string chat;
    if (skill != null)
    {
      string str3 = str2 + "\n|2|" + mResources.cap_do + ": " + (object) skill.point + "\n|5|" + NinjaUtil.replace(tp.damInfo, "#", skill.damage.ToString() + string.Empty) + "\n|5|" + mResources.KI_consume + (object) skill.manaUse + (tp.manaUseType != 1 ? (object) string.Empty : (object) "%") + "\n|5|" + mResources.speed + ": " + (object) skill.coolDown + mResources.milisecond + "\n--";
      if (skill.point == tp.maxPoint)
        chat = str3 + "\n|0|" + mResources.max_level_reach;
      else
        chat = str3 + "\n|1|" + mResources.next_level_require + Res.formatNumber(nextSkill.powRequire) + " " + mResources.potential + "\n|4|" + NinjaUtil.replace(tp.damInfo, "#", nextSkill.damage.ToString() + string.Empty);
    }
    else
      chat = str2 + "\n|2|" + mResources.not_learn + "\n|1|" + mResources.learn_require + Res.formatNumber(nextSkill.powRequire) + " " + mResources.potential + "\n|4|" + NinjaUtil.replace(tp.damInfo, "#", nextSkill.damage.ToString() + string.Empty) + "\n|4|" + mResources.KI_consume + (object) nextSkill.manaUse + (tp.manaUseType != 1 ? (object) string.Empty : (object) "%") + "\n|4|" + mResources.speed + ": " + (object) nextSkill.coolDown + mResources.milisecond;
    this.currItem = (Item) null;
    this.partID = (int[]) null;
    this.charInfo = (Char) null;
    this.cp = new ChatPopup();
    this.popUpDetailInit(this.cp, chat);
    this.idIcon = 0;
  }

  public void show()
  {
    if (GameCanvas.isTouch)
    {
      this.cmdClose.x = 156;
      this.cmdClose.y = 3;
    }
    else
    {
      this.cmdClose.x = GameCanvas.w - 19;
      this.cmdClose.y = GameCanvas.h - 19;
    }
    this.cmdClose.isPlaySoundButton = false;
    ChatPopup.currChatPopup = (ChatPopup) null;
    InfoDlg.hide();
    this.timeShow = 20;
    this.isShow = true;
    this.isClose = false;
    SoundMn.gI().panelOpen();
    if (!this.isTypeShop())
      return;
    Char.myCharz().setPartOld();
  }

  public void chatTFUpdateKey()
  {
    if (this.chatTField == null || !this.chatTField.isShow)
      return;
    if (this.chatTField.left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(this.chatTField.left)) && this.chatTField.left != null)
      this.chatTField.left.performAction();
    if (this.chatTField.right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.chatTField.right)) && this.chatTField.right != null)
      this.chatTField.right.performAction();
    if (this.chatTField.center != null && (GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(this.chatTField.center)) && this.chatTField.center != null)
      this.chatTField.center.performAction();
    if (this.chatTField.isShow && GameCanvas.keyAsciiPress != 0)
    {
      this.chatTField.keyPressed(GameCanvas.keyAsciiPress);
      GameCanvas.keyAsciiPress = 0;
    }
    GameCanvas.clearKeyHold();
    GameCanvas.clearKeyPressed();
  }

  public void updateKey()
  {
    if (this.chatTField != null && this.chatTField.isShow || !GameCanvas.panel.isDoneCombine || InfoDlg.isShow)
      return;
    if (this.tabIcon != null && this.tabIcon.isShow)
    {
      this.tabIcon.updateKey();
    }
    else
    {
      if (this.isClose || !this.isShow)
        return;
      if (this.cmdClose.isPointerPressInside())
      {
        this.cmdClose.performAction();
      }
      else
      {
        if (GameCanvas.keyPressed[13])
        {
          if (this.type == 4)
          {
            this.setTypeMain();
            this.cmx = this.cmtoX = 0;
          }
          else
          {
            this.hide();
            return;
          }
        }
        if (GameCanvas.keyPressed[12] || GameCanvas.keyPressed[!Main.isPC ? 5 : 25])
        {
          if (this.left.idAction > 0)
            this.perform(this.left.idAction, this.left.p);
          else
            this.waitToPerform = 2;
        }
        if (this.Equals((object) GameCanvas.panel) && GameCanvas.panel2 == null && GameCanvas.isPointerJustRelease && !GameCanvas.isPointer(this.X, this.Y, this.W, this.H) && !this.pointerIsDowning)
        {
          this.hide();
        }
        else
        {
          if (!this.isClanOption)
            this.updateKeyInTabBar();
          switch (this.type)
          {
            case 0:
              if (this.currentTabIndex == 0)
              {
                this.updateKeyQuest();
                GameCanvas.clearKeyPressed();
                return;
              }
              if (this.currentTabIndex == 1)
                this.updateKeyInventory();
              if (this.currentTabIndex == 2)
                this.updateKeySkill();
              if (this.currentTabIndex == 3)
              {
                if (this.mainTabName.Length == 4)
                  this.updateKeyTool();
                else
                  this.updateKeyClans();
              }
              if (this.currentTabIndex == 4)
              {
                this.updateKeyTool();
                break;
              }
              break;
            case 1:
            case 17:
            case 25:
              if (this.currentTabIndex < this.currentTabName.Length - (GameCanvas.panel2 == null ? 1 : 0) && this.type != 17)
              {
                this.updateKeyScrollView();
                break;
              }
              if (this.typeShop == 0)
              {
                this.updateKeyInventory();
                break;
              }
              this.updateKeyScrollView();
              break;
            case 2:
              this.updateKeyInventory();
              break;
            case 3:
              this.updateKeyScrollView();
              break;
            case 4:
              this.updateKeyMap();
              GameCanvas.clearKeyPressed();
              return;
            case 7:
              this.updateKeyInventory();
              break;
            case 8:
              this.updateKeyScrollView();
              break;
            case 9:
              this.updateKeyScrollView();
              break;
            case 10:
              this.updateKeyScrollView();
              break;
            case 11:
            case 16:
              this.updateKeyScrollView();
              break;
            case 12:
              this.updateKeyCombine();
              break;
            case 13:
              this.updateKeyGiaoDich();
              break;
            case 14:
              this.updateKeyScrollView();
              break;
            case 15:
              this.updateKeyScrollView();
              break;
            case 18:
              this.updateKeyScrollView();
              break;
            case 19:
              this.updateKeyOption();
              break;
            case 20:
              this.updateKeyOption();
              break;
            case 21:
              if (this.currentTabIndex == 0)
                this.updateKeyScrollView();
              if (this.currentTabIndex == 1)
                this.updateKeyPetStatus();
              if (this.currentTabIndex == 2)
              {
                this.updateKeyScrollView();
                break;
              }
              break;
            case 22:
              this.updateKeyAuto();
              break;
            case 23:
            case 24:
              this.updateKeyScrollView();
              break;
          }
          GameCanvas.clearKeyHold();
          for (int index = 0; index < GameCanvas.keyPressed.Length; ++index)
            GameCanvas.keyPressed[index] = false;
        }
      }
    }
  }

  private void updateKeyAuto()
  {
  }

  private void updateKeyPetStatus() => this.updateKeyScrollView();

  private void updateKeyPetSkill()
  {
  }

  private void keyGiaodich() => this.updateKeyScrollView();

  private void updateKeyGiaoDich()
  {
    if (this.currentTabIndex == 0)
    {
      if (this.Equals((object) GameCanvas.panel))
        this.updateKeyInventory();
      if (this.Equals((object) GameCanvas.panel2))
        this.keyGiaodich();
    }
    if (this.currentTabIndex != 1 && this.currentTabIndex != 2)
      return;
    this.keyGiaodich();
  }

  private void updateKeyTool() => this.updateKeyScrollView();

  private void updateKeySkill() => this.updateKeyScrollView();

  private void updateKeyClanIcon() => this.updateKeyScrollView();

  public void setTabGiaoDich(bool isMe)
  {
    this.currentListLength = !isMe ? this.vFriendGD.size() + 3 : this.vMyGD.size() + 3;
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy <= this.cmyLim)
      return;
    this.cmy = this.cmtoY = this.cmyLim;
  }

  public void setTypeGiaoDich(Char cGD)
  {
    this.type = 13;
    this.tabName[this.type] = Panel.boxGD;
    this.isAccept = false;
    this.isLock = false;
    this.isFriendLock = false;
    this.vMyGD.removeAllElements();
    this.vFriendGD.removeAllElements();
    this.moneyGD = 0;
    this.friendMoneyGD = 0;
    if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
    {
      GameCanvas.panel2 = new Panel();
      GameCanvas.panel2.type = 13;
      GameCanvas.panel2.tabName[this.type] = new string[1][]
      {
        mResources.item_receive
      };
      GameCanvas.panel2.setType(1);
      GameCanvas.panel2.setTabGiaoDich(false);
      GameCanvas.panel.tabName[this.type] = new string[2][]
      {
        mResources.inventory,
        mResources.item_give
      };
      GameCanvas.panel2.show();
      GameCanvas.panel2.charMenu = cGD;
    }
    if (this.Equals((object) GameCanvas.panel))
      this.setType(0);
    if (this.currentTabIndex == 0)
      this.setTabInventory(true);
    if (this.currentTabIndex == 1)
      this.setTabGiaoDich(true);
    if (this.currentTabIndex == 2)
      this.setTabGiaoDich(false);
    this.charMenu = cGD;
  }

  private void paintGiaoDich(mGraphics g, bool isMe)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    MyVector myVector = !isMe ? this.vFriendGD : this.vMyGD;
    for (int index1 = 0; index1 < this.currentListLength; ++index1)
    {
      int x = this.xScroll + 36;
      int y1 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w1 = this.wScroll - 36;
      int h1 = this.ITEM_HEIGHT - 1;
      int xScroll = this.xScroll;
      int y2 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w2 = 34;
      int h2 = this.ITEM_HEIGHT - 1;
      if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        if (index1 == this.currentListLength - 1)
        {
          if (isMe)
          {
            g.setColor(15196114);
            g.fillRect(xScroll, y1, this.wScroll, h1);
            if (!this.isLock)
            {
              if (!this.isFriendLock)
                mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.not_lock_trade, this.xScroll + this.wScroll / 2, y1 + h1 / 2 - 4, mFont.CENTER);
              else
                mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.locked_trade, this.xScroll + this.wScroll / 2, y1 + h1 / 2 - 4, mFont.CENTER);
            }
            else if (this.isFriendLock)
            {
              g.setColor(15196114);
              g.fillRect(xScroll, y1, this.wScroll, h1);
              g.drawImage(index1 != this.selected ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, y1 + 2, StaticObj.TOP_RIGHT);
              (index1 != this.selected ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, mResources.done, this.xScroll + this.wScroll - 22, y1 + 7, 2);
              mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.locked_trade, this.xScroll + 5, y1 + h1 / 2 - 4, mFont.LEFT);
            }
            else
              mFont.tahoma_7_grey.drawString(g, mResources.opponent + mResources.not_lock_trade, this.xScroll + this.wScroll / 2, y1 + h1 / 2 - 4, mFont.CENTER);
          }
        }
        else if (index1 == this.currentListLength - 2)
        {
          if (isMe)
          {
            g.setColor(15196114);
            g.fillRect(xScroll, y1, this.wScroll, h1);
            if (!this.isAccept)
            {
              if (!this.isLock)
              {
                g.drawImage(index1 != this.selected ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, y1 + 2, StaticObj.TOP_RIGHT);
                (index1 != this.selected ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, mResources.mlock, this.xScroll + this.wScroll - 22, y1 + 7, 2);
                mFont.tahoma_7_grey.drawString(g, mResources.you + mResources.not_lock_trade, this.xScroll + 5, y1 + h1 / 2 - 4, mFont.LEFT);
              }
              else
              {
                g.drawImage(index1 != this.selected ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, y1 + 2, StaticObj.TOP_RIGHT);
                (index1 != this.selected ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, mResources.CANCEL, this.xScroll + this.wScroll - 22, y1 + 7, 2);
                mFont.tahoma_7_grey.drawString(g, mResources.you + mResources.locked_trade, this.xScroll + 5, y1 + h1 / 2 - 4, mFont.LEFT);
              }
            }
          }
          else if (!this.isFriendLock)
            mFont.tahoma_7b_dark.drawString(g, mResources.not_lock_trade_upper, this.xScroll + this.wScroll / 2, y1 + h1 / 2 - 4, mFont.CENTER);
          else
            mFont.tahoma_7b_dark.drawString(g, mResources.locked_trade_upper, this.xScroll + this.wScroll / 2, y1 + h1 / 2 - 4, mFont.CENTER);
        }
        else if (index1 == this.currentListLength - 3)
        {
          if (this.isLock)
            g.setColor(13748667);
          else
            g.setColor(index1 != this.selected ? 15196114 : 16383818);
          g.fillRect(x, y1, w1, h1);
          if (this.isLock)
            g.setColor(13748667);
          else
            g.setColor(index1 != this.selected ? 9993045 : 7300181);
          g.fillRect(xScroll, y2, w2, h2);
          g.drawImage(Panel.imgXu, xScroll + w2 / 2, y2 + h2 / 2, 3);
          mFont.tahoma_7_green2.drawString(g, NinjaUtil.getMoneys(!isMe ? (long) this.friendMoneyGD : (long) this.moneyGD) + " " + mResources.XU, x + 5, y1 + 11, 0);
          mFont.tahoma_7_green.drawString(g, mResources.money_trade, x + 5, y1, 0);
        }
        else
        {
          if (myVector.size() == 0)
            return;
          if (this.isLock)
            g.setColor(13748667);
          else
            g.setColor(index1 != this.selected ? 15196114 : 16383818);
          g.fillRect(x, y1, w1, h1);
          if (this.isLock)
            g.setColor(13748667);
          else
            g.setColor(index1 != this.selected ? 9993045 : 9541120);
          Item obj = (Item) myVector.elementAt(index1);
          if (obj != null)
          {
            for (int index2 = 0; index2 < obj.itemOption.Length; ++index2)
            {
              if (obj.itemOption[index2].optionTemplate.id == 72 && obj.itemOption[index2].param > 0)
              {
                sbyte colorItemUpgrade = Panel.GetColor_Item_Upgrade(obj.itemOption[index2].param);
                if (Panel.GetColor_ItemBg((int) colorItemUpgrade) != -1)
                {
                  if (this.isLock)
                    g.setColor(13748667);
                  else
                    g.setColor(index1 != this.selected ? Panel.GetColor_ItemBg((int) colorItemUpgrade) : Panel.GetColor_ItemBg((int) colorItemUpgrade));
                }
              }
            }
          }
          g.fillRect(xScroll, y2, w2, h2);
          if (obj != null)
          {
            string str = string.Empty;
            mFont mFont1 = mFont.tahoma_7_green2;
            if (obj.itemOption != null)
            {
              for (int index3 = 0; index3 < obj.itemOption.Length; ++index3)
              {
                if (obj.itemOption[index3].optionTemplate.id == 72)
                  str = " [+" + (object) obj.itemOption[index3].param + "]";
                if (obj.itemOption[index3].optionTemplate.id == 41)
                {
                  if (obj.itemOption[index3].param == 1)
                    mFont1 = Panel.GetFont(0);
                  else if (obj.itemOption[index3].param == 2)
                    mFont1 = Panel.GetFont(2);
                  else if (obj.itemOption[index3].param == 3)
                    mFont1 = Panel.GetFont(8);
                  else if (obj.itemOption[index3].param == 4)
                    mFont1 = Panel.GetFont(7);
                }
              }
            }
            mFont1.drawString(g, obj.template.name + str, x + 5, y1 + 1, 0);
            string st = string.Empty;
            if (obj.itemOption != null)
            {
              if (obj.itemOption.Length > 0 && obj.itemOption[0] != null)
                st += obj.itemOption[0].getOptionString();
              mFont mFont2 = mFont.tahoma_7_blue;
              if (obj.compare < 0 && obj.template.type != (sbyte) 5)
                mFont2 = mFont.tahoma_7_red;
              if (obj.itemOption.Length > 1)
              {
                for (int index4 = 1; index4 < obj.itemOption.Length; ++index4)
                {
                  if (obj.itemOption[index4] != null && obj.itemOption[index4].optionTemplate.id != 102 && obj.itemOption[index4].optionTemplate.id != 107)
                    st = st + "," + obj.itemOption[index4].getOptionString();
                }
              }
              mFont2.drawString(g, st, x + 5, y1 + 11, mFont.LEFT);
            }
            SmallImage.drawSmallImage(g, (int) obj.template.iconID, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
            if (obj.itemOption != null)
            {
              for (int index5 = 0; index5 < obj.itemOption.Length; ++index5)
                this.paintOptItem(g, obj.itemOption[index5].optionTemplate.id, obj.itemOption[index5].param, xScroll, y2, w2, h2);
              for (int index6 = 0; index6 < obj.itemOption.Length; ++index6)
                this.paintOptSlotItem(g, obj.itemOption[index6].optionTemplate.id, obj.itemOption[index6].param, xScroll, y2, w2, h2);
            }
            if (obj.quantity > 1)
              mFont.tahoma_7_yellow.drawString(g, string.Empty + (object) obj.quantity, xScroll + w2, y2 + h2 - mFont.tahoma_7_yellow.getHeight(), 1);
          }
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void updateKeyMap()
  {
    if (GameCanvas.keyHold[!Main.isPC ? 2 : 21])
    {
      this.yMove -= 5;
      this.cmyMap = this.yMove - (this.yScroll + this.hScroll / 2);
      if (this.yMove < this.yScroll)
        this.yMove = this.yScroll;
    }
    if (GameCanvas.keyHold[!Main.isPC ? 8 : 22])
    {
      this.yMove += 5;
      this.cmyMap = this.yMove - (this.yScroll + this.hScroll / 2);
      if (this.yMove > this.yScroll + 200)
        this.yMove = this.yScroll + 200;
    }
    if (GameCanvas.keyHold[!Main.isPC ? 4 : 23])
    {
      this.xMove -= 5;
      this.cmxMap = this.xMove - this.wScroll / 2;
      if (this.xMove < 16)
        this.xMove = 16;
    }
    if (GameCanvas.keyHold[!Main.isPC ? 6 : 24])
    {
      this.xMove += 5;
      this.cmxMap = this.xMove - this.wScroll / 2;
      if (this.xMove > 250)
        this.xMove = 250;
    }
    if (GameCanvas.isPointerDown)
    {
      this.pointerIsDowning = true;
      if (!this.trans)
      {
        this.pa1 = this.cmxMap;
        this.pa2 = this.cmyMap;
        this.trans = true;
      }
      this.cmxMap = this.pa1 + (GameCanvas.pxLast - GameCanvas.px);
      this.cmyMap = this.pa2 + (GameCanvas.pyLast - GameCanvas.py);
    }
    if (GameCanvas.isPointerJustRelease)
    {
      this.trans = false;
      GameCanvas.pxLast = GameCanvas.px;
      GameCanvas.pyLast = GameCanvas.py;
      this.pX = GameCanvas.pxLast + this.cmxMap;
      this.pY = GameCanvas.pyLast + this.cmyMap;
    }
    if (GameCanvas.isPointerClick)
      this.pointerIsDowning = false;
    if (this.cmxMap < 0)
      this.cmxMap = 0;
    if (this.cmxMap > this.cmxMapLim)
      this.cmxMap = this.cmxMapLim;
    if (this.cmyMap < 0)
      this.cmyMap = 0;
    if (this.cmyMap <= this.cmyMapLim)
      return;
    this.cmyMap = this.cmyMapLim;
  }

  private void updateKeyCombine()
  {
    if (this.currentTabIndex == 0)
    {
      this.updateKeyScrollView();
      this.keyTouchCombine = -1;
      if (this.selected == this.vItemCombine.size() && GameCanvas.isPointerClick)
      {
        GameCanvas.isPointerClick = false;
        this.keyTouchCombine = 1;
      }
    }
    if (this.currentTabIndex != 1)
      return;
    this.updateKeyScrollView();
  }

  private void updateKeyQuest()
  {
    if (GameCanvas.keyHold[!Main.isPC ? 2 : 21])
      this.cmyQuest -= 5;
    if (GameCanvas.keyHold[!Main.isPC ? 8 : 22])
      this.cmyQuest += 5;
    if (this.cmyQuest < 0)
      this.cmyQuest = 0;
    int num1 = this.indexRowMax * 12 - (this.hScroll - 60);
    if (num1 < 0)
      num1 = 0;
    if (this.cmyQuest > num1)
      this.cmyQuest = num1;
    if (this.scroll != null)
    {
      if (!GameCanvas.isTouch)
        this.scroll.cmy = this.cmyQuest;
      this.scroll.updateKey();
    }
    int num2 = this.xScroll + this.wScroll / 2 - 35;
    int num3 = this.yScroll + this.hScroll - (GameCanvas.h <= 300 ? 15 : 20) - 15;
    int px = GameCanvas.px;
    int py = GameCanvas.py;
    this.keyTouchMapButton = -1;
    if (!Panel.isPaintMap || GameScr.gI().isMapDocNhan() || px < num2 || px > num2 + 70 || py < num3 || py > num3 + 30 || this.scroll != null && this.scroll.pointerIsDowning)
      return;
    this.keyTouchMapButton = 1;
    if (!GameCanvas.isPointerJustRelease)
      return;
    SoundMn.gI().buttonClick();
    this.waitToPerform = 2;
    GameCanvas.clearAllPointerEvent();
  }

  private void getCurrClanOtion()
  {
    this.isClanOption = false;
    if (this.type != 0 || this.mainTabName.Length != 5 || this.currentTabIndex != 3)
      return;
    this.isClanOption = false;
    if (this.selected == 0)
    {
      this.currClanOption = new int[this.clansOption.Length];
      for (int index = 0; index < this.currClanOption.Length; ++index)
        this.currClanOption[index] = index;
      if (this.isViewMember)
        return;
      this.isClanOption = true;
    }
    else
    {
      if (this.selected == 1 || this.isSearchClan || this.selected <= 0)
        return;
      this.currClanOption = new int[1];
      for (int index = 0; index < this.currClanOption.Length; ++index)
        this.currClanOption[index] = index;
      this.isClanOption = true;
    }
  }

  private void updateKeyClansOption()
  {
    if (this.currClanOption == null)
      return;
    if (GameCanvas.keyPressed[!Main.isPC ? 4 : 23])
    {
      this.currMess = this.getCurrMessage();
      --this.cSelected;
      if (this.selected == 0 && this.cSelected < 0)
        this.cSelected = this.currClanOption.Length - 1;
      if (this.selected <= 1 || !this.isMessage || this.currMess.option == null || this.cSelected >= 0)
        return;
      this.cSelected = this.currMess.option.Length - 1;
    }
    else
    {
      if (!GameCanvas.keyPressed[!Main.isPC ? 6 : 24])
        return;
      this.currMess = this.getCurrMessage();
      ++this.cSelected;
      if (this.selected == 0 && this.cSelected > this.currClanOption.Length - 1)
        this.cSelected = 0;
      if (this.selected <= 1 || !this.isMessage || this.currMess.option == null || this.cSelected <= this.currMess.option.Length - 1)
        return;
      this.cSelected = 0;
    }
  }

  private void updateKeyClans()
  {
    this.updateKeyScrollView();
    this.updateKeyClansOption();
  }

  private void checkOptionSelect()
  {
    if (this.type != 0 || this.currentTabIndex != 3 || this.mainTabName.Length != 5 || this.selected == -1)
      return;
    int num = 0;
    if (this.selected == 0)
    {
      num = this.xScroll + this.wScroll / 2 - this.clansOption.Length * this.TAB_W / 2;
      this.cSelected = (GameCanvas.px - num) / this.TAB_W;
    }
    else
    {
      this.currMess = this.getCurrMessage();
      if (this.currMess != null && this.currMess.option != null)
      {
        num = this.xScroll + this.wScroll - 2 - this.currMess.option.Length * 40;
        this.cSelected = (GameCanvas.px - num) / 40;
      }
    }
    if (GameCanvas.px >= num)
      return;
    this.cSelected = -1;
  }

  public void updateScroolMouse(int a)
  {
    bool flag = false;
    if (GameCanvas.pxMouse > this.wScroll)
      return;
    if (this.indexMouse == -1)
      this.indexMouse = this.selected;
    if (a > 0)
    {
      this.indexMouse -= a;
      flag = true;
    }
    else if (a < 0)
    {
      this.indexMouse += -a;
      flag = true;
    }
    if (this.indexMouse < 0)
      this.indexMouse = 0;
    if (!flag)
      return;
    this.cmtoY = this.indexMouse * 12;
    if (this.cmtoY > this.cmyLim)
      this.cmtoY = this.cmyLim;
    if (this.cmtoY >= 0)
      return;
    this.cmtoY = 0;
  }

  private void updateKeyScrollView()
  {
    if (this.currentListLength <= 0)
      return;
    bool flag = false;
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21])
    {
      flag = true;
      --this.selected;
      if (this.type == 24)
      {
        this.selected -= 2;
        if (this.selected < 0)
          this.selected = 0;
      }
      else if (this.selected < 0)
      {
        if (this.Equals((object) GameCanvas.panel) && this.typeShop == 2 && this.currentTabIndex <= 3 && this.maxPageShop[this.currentTabIndex] > 1)
        {
          InfoDlg.showWait();
          if (this.currPageShop[this.currentTabIndex] <= 0)
          {
            Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, this.maxPageShop[this.currentTabIndex] - 1, -1);
            return;
          }
          Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, this.currPageShop[this.currentTabIndex] - 1, -1);
          return;
        }
        this.selected = this.currentListLength - 1;
        if (this.isClanOption)
          this.selected = -1;
        if (this.size_tab > (sbyte) 0)
          this.selected = -1;
      }
      this.lastSelect[this.currentTabIndex] = this.selected;
      this.cSelected = 0;
      this.getCurrClanOtion();
    }
    else if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22])
    {
      flag = true;
      ++this.selected;
      if (this.type == 24)
      {
        this.selected += 2;
        if (this.selected > this.currentListLength - 1)
          this.selected = this.currentListLength - 1;
      }
      else if (this.selected > this.currentListLength - 1)
      {
        if (this.Equals((object) GameCanvas.panel) && this.typeShop == 2 && this.currentTabIndex <= 3 && this.maxPageShop[this.currentTabIndex] > 1)
        {
          InfoDlg.showWait();
          if (this.currPageShop[this.currentTabIndex] >= this.maxPageShop[this.currentTabIndex] - 1)
          {
            Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, 0, -1);
            return;
          }
          Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, this.currPageShop[this.currentTabIndex] + 1, -1);
          return;
        }
        this.selected = 0;
      }
      this.lastSelect[this.currentTabIndex] = this.selected;
      this.cSelected = 0;
      this.getCurrClanOtion();
    }
    if (flag)
    {
      this.cmtoY = this.selected * this.ITEM_HEIGHT - this.hScroll / 2;
      if (this.cmtoY > this.cmyLim)
        this.cmtoY = this.cmyLim;
      if (this.cmtoY < 0)
        this.cmtoY = 0;
      if (this.selected == this.currentListLength || this.selected == 0)
        this.cmy = this.cmtoY;
    }
    if (GameCanvas.isPointerDown)
    {
      this.justRelease = false;
      if (!this.pointerIsDowning && GameCanvas.isPointer(this.xScroll, this.yScroll, this.wScroll, this.hScroll))
      {
        for (int index = 0; index < this.pointerDownLastX.Length; ++index)
          this.pointerDownLastX[0] = GameCanvas.py;
        this.pointerDownFirstX = GameCanvas.py;
        this.pointerIsDowning = true;
        this.isDownWhenRunning = this.cmRun != 0;
        this.cmRun = 0;
      }
      else if (this.pointerIsDowning)
      {
        ++this.pointerDownTime;
        if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning)
        {
          this.pointerDownFirstX = -1000;
          this.selected = (this.cmtoY + GameCanvas.py - this.yScroll) / this.ITEM_HEIGHT;
          if (this.selected >= this.currentListLength)
            this.selected = -1;
          this.checkOptionSelect();
        }
        else
          this.indexMouse = -1;
        int num = GameCanvas.py - this.pointerDownLastX[0];
        if (num != 0 && this.selected != -1)
        {
          this.selected = -1;
          this.cSelected = -1;
        }
        for (int index = this.pointerDownLastX.Length - 1; index > 0; --index)
          this.pointerDownLastX[index] = this.pointerDownLastX[index - 1];
        this.pointerDownLastX[0] = GameCanvas.py;
        this.cmtoY -= num;
        if (this.cmtoY < 0)
          this.cmtoY = 0;
        if (this.cmtoY > this.cmyLim)
          this.cmtoY = this.cmyLim;
        if (this.cmy < 0 || this.cmy > this.cmyLim)
          num /= 2;
        this.cmy -= num;
        this.wantUpdateList = this.cmy < -(GameCanvas.h / 3);
      }
    }
    if (!GameCanvas.isPointerJustRelease || !this.pointerIsDowning)
      return;
    this.justRelease = true;
    int i = GameCanvas.py - this.pointerDownLastX[0];
    GameCanvas.isPointerJustRelease = false;
    if (Res.abs(i) < 20 && Res.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
    {
      this.cmRun = 0;
      this.cmtoY = this.cmy;
      this.pointerDownFirstX = -1000;
      this.selected = (this.cmtoY + GameCanvas.py - this.yScroll) / this.ITEM_HEIGHT;
      if (this.selected >= this.currentListLength)
        this.selected = -1;
      this.checkOptionSelect();
      this.pointerDownTime = 0;
      this.waitToPerform = 10;
      SoundMn.gI().panelClick();
    }
    else if (this.selected != -1 && this.pointerDownTime > 5)
    {
      this.pointerDownTime = 0;
      this.waitToPerform = 1;
    }
    else if (this.selected == -1 && !this.isDownWhenRunning)
    {
      if (this.cmy < 0)
        this.cmtoY = 0;
      else if (this.cmy > this.cmyLim)
      {
        this.cmtoY = this.cmyLim;
      }
      else
      {
        int num = GameCanvas.py - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
        this.cmRun = -(num <= 10 ? (num >= -10 ? 0 : -10) : 10) * 100;
      }
    }
    this.pointerIsDowning = false;
    this.pointerDownTime = 0;
    GameCanvas.isPointerJustRelease = false;
  }

  public string subArray(string[] str) => (string) null;

  private void updateKeyInTabBar()
  {
    if (this.scroll != null && this.scroll.pointerIsDowning || this.pointerIsDowning)
      return;
    int currentTabIndex = this.currentTabIndex;
    if (!this.IsTabOption())
    {
      if (GameCanvas.keyPressed[!Main.isPC ? 6 : 24])
      {
        ++this.currentTabIndex;
        if (this.currentTabIndex >= this.currentTabName.Length)
        {
          if (GameCanvas.panel2 != null)
          {
            this.currentTabIndex = this.currentTabName.Length - 1;
            GameCanvas.isFocusPanel2 = true;
          }
          else
            this.currentTabIndex = 0;
        }
        this.selected = this.lastSelect[this.currentTabIndex];
        this.lastTabIndex[this.type] = this.currentTabIndex;
      }
      if (GameCanvas.keyPressed[!Main.isPC ? 4 : 23])
      {
        --this.currentTabIndex;
        if (this.currentTabIndex < 0)
          this.currentTabIndex = this.currentTabName.Length - 1;
        if (GameCanvas.isFocusPanel2)
          GameCanvas.isFocusPanel2 = false;
        this.selected = this.lastSelect[this.currentTabIndex];
        this.lastTabIndex[this.type] = this.currentTabIndex;
      }
    }
    this.keyTouchTab = -1;
    for (int index = 0; index < this.currentTabName.Length; ++index)
    {
      if (GameCanvas.isPointer(this.startTabPos + index * this.TAB_W, 52, this.TAB_W - 1, 25))
      {
        this.keyTouchTab = index;
        if (GameCanvas.isPointerJustRelease)
        {
          this.currentTabIndex = index;
          this.lastTabIndex[this.type] = index;
          GameCanvas.isPointerJustRelease = false;
          this.selected = this.lastSelect[this.currentTabIndex];
          if (currentTabIndex == this.currentTabIndex && this.cmRun == 0)
          {
            this.cmtoY = 0;
            this.selected = !GameCanvas.isTouch ? 0 : -1;
            break;
          }
          break;
        }
      }
    }
    if (currentTabIndex == this.currentTabIndex)
      return;
    this.size_tab = (sbyte) 0;
    SoundMn.gI().panelClick();
    switch (this.type)
    {
      case 0:
        if (this.currentTabIndex == 0)
          this.setTabTask();
        if (this.currentTabIndex == 1)
          this.setTabInventory(true);
        if (this.currentTabIndex == 2)
          this.setTabSkill();
        if (this.currentTabIndex == 3)
        {
          if (this.mainTabName.Length > 4)
            this.setTabClans();
          else
            this.setTabTool();
        }
        if (this.currentTabIndex == 4)
        {
          this.setTabTool();
          break;
        }
        break;
      case 1:
        this.setTabShop();
        break;
      case 2:
        if (this.currentTabIndex == 0)
          this.setTabBox();
        if (this.currentTabIndex == 1)
        {
          this.setTabInventory(true);
          break;
        }
        break;
      case 3:
        this.setTabZone();
        break;
      case 12:
        if (this.currentTabIndex == 0)
          this.setTabCombine();
        if (this.currentTabIndex == 1)
        {
          this.setTabInventory(true);
          break;
        }
        break;
      case 13:
        if (this.currentTabIndex == 0)
        {
          if (this.Equals((object) GameCanvas.panel))
            this.setTabInventory(true);
          else if (this.Equals((object) GameCanvas.panel2))
            this.setTabGiaoDich(false);
        }
        if (this.currentTabIndex == 1)
          this.setTabGiaoDich(true);
        if (this.currentTabIndex == 2)
        {
          this.setTabGiaoDich(false);
          break;
        }
        break;
      case 21:
        if (this.currentTabIndex == 0)
          this.setTabPetInventory();
        if (this.currentTabIndex == 1)
          this.setTabPetStatus();
        if (this.currentTabIndex == 2)
        {
          this.setTabInventory(true);
          break;
        }
        break;
      case 25:
        this.setTabSpeacialSkill();
        break;
    }
    this.selected = this.lastSelect[this.currentTabIndex];
  }

  private void setTabPetStatus()
  {
    this.currentListLength = this.strStatus.Length;
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy <= this.cmyLim)
      return;
    this.cmy = this.cmtoY = this.cmyLim;
  }

  private void setTabPetSkill()
  {
  }

  private void setTabTool()
  {
    SoundMn.gI().getSoundOption();
    this.currentListLength = Panel.strTool.Length;
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy <= this.cmyLim)
      return;
    this.cmy = this.cmtoY = this.cmyLim;
  }

  public void initTabClans()
  {
    if (this.isSearchClan)
    {
      this.currentListLength = this.clans != null ? this.clans.Length + 2 : 2;
      this.clanInfo = mResources.clan_list;
    }
    else if (this.isViewMember)
    {
      this.clanReport = string.Empty;
      this.currentListLength = (this.member != null ? this.member.size() : this.myMember.size()) + 2;
      this.clanInfo = mResources.member + " " + (this.currClan == null ? Char.myCharz().clan.name : this.currClan.name);
    }
    else if (this.isMessage)
    {
      this.currentListLength = ClanMessage.vMessage.size() + 2;
      this.clanInfo = mResources.msg;
      this.clanReport = string.Empty;
    }
    if (Char.myCharz().clan == null)
      this.clansOption = new string[2][]
      {
        mResources.findClan,
        mResources.createClan
      };
    else if (!this.isViewMember)
    {
      if (this.myMember.size() > 1)
        this.clansOption = new string[3][]
        {
          mResources.chatClan,
          mResources.request_pea2,
          mResources.memberr
        };
      else
        this.clansOption = new string[1][]
        {
          mResources.memberr
        };
    }
    else if (Char.myCharz().role > (sbyte) 0)
      this.clansOption = new string[2][]
      {
        mResources.msgg,
        mResources.leaveClan
      };
    else if (this.myMember.size() > 1)
      this.clansOption = new string[4][]
      {
        mResources.msgg,
        mResources.leaveClan,
        mResources.khau_hieuu,
        mResources.bieu_tuongg
      };
    else
      this.clansOption = new string[3][]
      {
        mResources.msgg,
        mResources.khau_hieuu,
        mResources.bieu_tuongg
      };
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy <= this.cmyLim)
      return;
    this.cmy = this.cmtoY = this.cmyLim;
  }

  public void setTabClans()
  {
    GameScr.isNewClanMessage = false;
    this.ITEM_HEIGHT = 24;
    if (this.lastSelect != null && this.lastSelect[3] == 0)
      this.lastSelect[3] = -1;
    this.currentListLength = 2;
    if (Char.myCharz().clan != null)
    {
      this.isMessage = true;
      this.isViewMember = false;
      this.isSearchClan = false;
    }
    else
    {
      this.isMessage = false;
      this.isViewMember = false;
      this.isSearchClan = true;
    }
    if (Char.myCharz().clan != null)
      this.currentListLength = ClanMessage.vMessage.size() + 2;
    this.initTabClans();
    this.cSelected = -1;
    if (this.chatTField == null)
    {
      this.chatTField = new ChatTextField();
      this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
      this.chatTField.initChatTextField();
      this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
    }
    if (Char.myCharz().clan == null)
    {
      this.clanReport = mResources.findingClan;
      Service.gI().searchClan(string.Empty);
    }
    this.selected = this.lastSelect[this.currentTabIndex];
    if (!GameCanvas.isTouch)
      return;
    this.selected = -1;
  }

  public void initLogMessage()
  {
    this.currentListLength = this.logChat.size() + 1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.cmx = this.cmtoX = 0;
  }

  private void setTabMessage()
  {
    this.ITEM_HEIGHT = 24;
    this.initLogMessage();
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  public void setTabShop()
  {
    this.ITEM_HEIGHT = 24;
    this.currentListLength = this.currentTabIndex != this.currentTabName.Length - 1 || GameCanvas.panel2 != null || this.typeShop == 2 ? Char.myCharz().arrItemShop[this.currentTabIndex].Length : this.checkCurrentListLength(Char.myCharz().arrItemBody.Length + Char.myCharz().arrItemBag.Length);
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  private void setTabSkill()
  {
    this.ITEM_HEIGHT = 30;
    this.currentListLength = Char.myCharz().nClass.skillTemplates.Length + 6;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmyLim;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  private void setTabMapTrans()
  {
    this.ITEM_HEIGHT = 24;
    this.currentListLength = this.mapNames.Length;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    this.cmy = this.cmtoY = 0;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  private void setTabZone()
  {
    this.ITEM_HEIGHT = 24;
    this.currentListLength = GameScr.gI().zones.Length;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    this.cmy = this.cmtoY = 0;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  private void setTabBox()
  {
    this.currentListLength = this.checkCurrentListLength(Char.myCharz().arrItemBox.Length);
    this.ITEM_HEIGHT = 24;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 9;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  private void setTabPetInventory()
  {
    this.ITEM_HEIGHT = 30;
    this.currentListLength = Char.myPetz().arrItemBody.Length + Char.myPetz().arrPetSkill.Length;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = 0;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  private void setTabInventory(bool resetSelect)
  {
    this.currentListLength = this.checkCurrentListLength(Char.myCharz().arrItemBody.Length + Char.myCharz().arrItemBag.Length);
    this.ITEM_HEIGHT = 24;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = 0;
    if (!resetSelect)
      return;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  private void setTabMap()
  {
    if (!Panel.isPaintMap)
      return;
    if ((int) TileMap.lastPlanetId != (int) TileMap.planetID)
    {
      Res.outz("LOAD TAM HINH");
      Panel.imgMap = GameCanvas.loadImageRMS("/img/map" + (object) TileMap.planetID + ".png");
      TileMap.lastPlanetId = TileMap.planetID;
    }
    this.cmxMap = this.getXMap() - this.wScroll / 2;
    this.cmyMap = this.getYMap() + this.yScroll - (this.yScroll + this.hScroll / 2);
    this.pa1 = this.cmxMap;
    this.pa2 = this.cmyMap;
    this.cmxMapLim = 250 - this.wScroll;
    this.cmyMapLim = 220 - this.hScroll;
    if (this.cmxMapLim < 0)
      this.cmxMapLim = 0;
    if (this.cmyMapLim < 0)
      this.cmyMapLim = 0;
    for (int index = 0; index < Panel.mapId[(int) TileMap.planetID].Length; ++index)
    {
      if (TileMap.mapID == Panel.mapId[(int) TileMap.planetID][index])
      {
        this.xMove = Panel.mapX[(int) TileMap.planetID][index] + this.xScroll;
        this.yMove = Panel.mapY[(int) TileMap.planetID][index] + this.yScroll + 5;
        break;
      }
    }
    this.xMap = this.getXMap() + this.xScroll;
    this.yMap = this.getYMap() + this.yScroll;
    this.xMapTask = this.getXMapTask() + this.xScroll;
    this.yMapTask = this.getYMapTask() + this.yScroll;
    Resources.UnloadUnusedAssets();
    GC.Collect();
  }

  private void setTabTask() => this.cmyQuest = 0;

  public void moveCamera()
  {
    if (this.timeShow > 0)
      --this.timeShow;
    if (this.justRelease && this.Equals((object) GameCanvas.panel) && this.typeShop == 2 && this.maxPageShop[this.currentTabIndex] > 1)
    {
      if (this.cmy < -50)
      {
        InfoDlg.showWait();
        this.justRelease = false;
        if (this.currPageShop[this.currentTabIndex] <= 0)
          Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, this.maxPageShop[this.currentTabIndex] - 1, -1);
        else
          Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, this.currPageShop[this.currentTabIndex] - 1, -1);
      }
      else if (this.cmy > this.cmyLim + 50)
      {
        this.justRelease = false;
        InfoDlg.showWait();
        if (this.currPageShop[this.currentTabIndex] >= this.maxPageShop[this.currentTabIndex] - 1)
          Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, 0, -1);
        else
          Service.gI().kigui((sbyte) 4, -1, (sbyte) this.currentTabIndex, this.currPageShop[this.currentTabIndex] + 1, -1);
      }
    }
    if (this.cmx != this.cmtoX && !this.pointerIsDowning)
    {
      this.cmvx = this.cmtoX - this.cmx << 2;
      this.cmdx += this.cmvx;
      this.cmx += this.cmdx >> 3;
      this.cmdx &= 15;
    }
    if (Math.abs(this.cmtoX - this.cmx) < 10)
      this.cmx = this.cmtoX;
    if (this.isClose)
    {
      this.isClose = false;
      this.cmtoX = this.wScroll;
    }
    if (this.cmtoX >= this.wScroll - 10 && this.cmx >= this.wScroll - 10 && this.position == 0)
    {
      this.isShow = false;
      this.cleanCombine();
      if (this.isChangeZone)
      {
        this.isChangeZone = false;
        if (Char.myCharz().cHP > 0 && Char.myCharz().statusMe != 14)
        {
          InfoDlg.showWait();
          if (this.type == 3)
            Service.gI().requestChangeZone(this.selected, -1);
          else if (this.type == 14)
            Service.gI().requestMapSelect(this.selected);
        }
      }
      if (this.isSelectPlayerMenu)
      {
        this.isSelectPlayerMenu = false;
        ((Command) this.vPlayerMenu.elementAt(this.selected)).performAction();
      }
      this.vPlayerMenu.removeAllElements();
      this.charMenu = (Char) null;
    }
    if (this.cmRun != 0 && !this.pointerIsDowning)
    {
      this.cmtoY += this.cmRun / 100;
      if (this.cmtoY < 0)
        this.cmtoY = 0;
      else if (this.cmtoY > this.cmyLim)
        this.cmtoY = this.cmyLim;
      else
        this.cmy = this.cmtoY;
      this.cmRun = this.cmRun * 9 / 10;
      if (this.cmRun < 100 && this.cmRun > -100)
        this.cmRun = 0;
    }
    if (this.cmy != this.cmtoY && !this.pointerIsDowning)
    {
      this.cmvy = this.cmtoY - this.cmy << 2;
      this.cmdy += this.cmvy;
      this.cmy += this.cmdy >> 4;
      this.cmdy &= 15;
    }
    this.cmyLast[this.currentTabIndex] = this.cmy;
  }

  public void paintDetail(mGraphics g)
  {
    if (this.cp == null || this.cp.says == null)
      return;
    this.cp.paint(g);
    int x = this.cp.cx + 13;
    int y = this.cp.cy + 11;
    if (this.type == 15)
    {
      x += 5;
      y += 26;
    }
    if (this.type == 0 && this.currentTabIndex == 3)
    {
      if (this.isSearchClan)
        x -= 5;
      else if (this.partID != null || this.charInfo != null)
      {
        x = this.cp.cx + 21;
        y = this.cp.cy + 40;
      }
    }
    if (this.partID != null)
    {
      Part part1 = GameScr.parts[this.partID[0]];
      Part part2 = GameScr.parts[this.partID[1]];
      Part part3 = GameScr.parts[this.partID[2]];
      SmallImage.drawSmallImage(g, (int) part1.pi[Char.CharInfo[0][0][0]].id, x + Char.CharInfo[0][0][1] + (int) part1.pi[Char.CharInfo[0][0][0]].dx, y - Char.CharInfo[0][0][2] + (int) part1.pi[Char.CharInfo[0][0][0]].dy, 0, 0);
      SmallImage.drawSmallImage(g, (int) part2.pi[Char.CharInfo[0][1][0]].id, x + Char.CharInfo[0][1][1] + (int) part2.pi[Char.CharInfo[0][1][0]].dx, y - Char.CharInfo[0][1][2] + (int) part2.pi[Char.CharInfo[0][1][0]].dy, 0, 0);
      SmallImage.drawSmallImage(g, (int) part3.pi[Char.CharInfo[0][2][0]].id, x + Char.CharInfo[0][2][1] + (int) part3.pi[Char.CharInfo[0][2][0]].dx, y - Char.CharInfo[0][2][2] + (int) part3.pi[Char.CharInfo[0][2][0]].dy, 0, 0);
    }
    else if (this.charInfo != null)
      this.charInfo.paintCharBody(g, x + 5, y + 25, 1, 0, true);
    else if (this.idIcon != -1)
      SmallImage.drawSmallImage(g, this.idIcon, x, y, 0, 3);
    if (this.currItem == null || this.currItem.template.type == (sbyte) 5)
      return;
    if (this.currItem.compare > 0)
    {
      g.drawImage(Panel.imgUp, x - 7, y + 13, 3);
      mFont.tahoma_7b_green.drawString(g, Res.abs(this.currItem.compare).ToString() + string.Empty, x + 1, y + 8, 0);
    }
    else
    {
      if (this.currItem.compare >= 0 || this.currItem.compare == -1)
        return;
      g.drawImage(Panel.imgDown, x - 7, y + 13, 3);
      mFont.tahoma_7b_red.drawString(g, Res.abs(this.currItem.compare).ToString() + string.Empty, x + 1, y + 8, 0);
    }
  }

  public void paintTop(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    g.setColor(0);
    if (this.currentListLength == 0)
      return;
    int num1 = (this.cmy + this.hScroll) / 24 + 1;
    if (num1 < this.hScroll / 24 + 1)
      num1 = this.hScroll / 24 + 1;
    if (num1 > this.currentListLength)
      num1 = this.currentListLength;
    int num2 = this.cmy / 24;
    if (num2 >= num1)
      num2 = num1 - 1;
    if (num2 < 0)
      num2 = 0;
    for (int index = num2; index < num1; ++index)
    {
      int xScroll = this.xScroll;
      int y1 = this.yScroll + index * this.ITEM_HEIGHT;
      int w1 = 24;
      int h1 = this.ITEM_HEIGHT - 1;
      int x = this.xScroll + w1;
      int y2 = this.yScroll + index * this.ITEM_HEIGHT;
      int w2 = this.wScroll - w1;
      int h2 = this.ITEM_HEIGHT - 1;
      g.setColor(index != this.selected ? 15196114 : 16383818);
      g.fillRect(x, y2, w2, h2);
      g.setColor(index != this.selected ? 9993045 : 9541120);
      g.fillRect(xScroll, y1, w1, h1);
      TopInfo topInfo = (TopInfo) this.vTop.elementAt(index);
      if (topInfo.headICON != -1)
      {
        SmallImage.drawSmallImage(g, topInfo.headICON, xScroll, y1, 0, 0);
      }
      else
      {
        Part part = GameScr.parts[topInfo.headID];
        SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, xScroll + (int) part.pi[Char.CharInfo[0][0][0]].dx, y1 + h2 - 1, 0, mGraphics.BOTTOM | mGraphics.LEFT);
      }
      g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
      if (topInfo.pId != Char.myCharz().charID)
        mFont.tahoma_7b_green.drawString(g, topInfo.name, x + 5, y2, 0);
      else
        mFont.tahoma_7b_red.drawString(g, topInfo.name, x + 5, y2, 0);
      mFont.tahoma_7_blue.drawString(g, topInfo.info, x + w2 - 5, y2 + 11, 1);
      mFont.tahoma_7_green2.drawString(g, mResources.rank + ": " + (object) topInfo.rank + string.Empty, x + 5, y2 + 11, 0);
    }
    this.paintScrollArrow(g);
  }

  public void paint(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY() + mGraphics.addYWhenOpenKeyBoard);
    g.translate(-this.cmx, 0);
    g.translate(this.X, this.Y);
    if (GameCanvas.panel.combineSuccess != (sbyte) -1)
    {
      if (!this.Equals((object) GameCanvas.panel))
        return;
      this.paintCombineEff(g);
    }
    else
    {
      GameCanvas.paintz.paintFrameSimple(this.X, this.Y, this.W, this.H, g);
      this.paintTopInfo(g);
      this.paintBottomMoneyInfo(g);
      this.paintTab(g);
      switch (this.type)
      {
        case 0:
          if (this.currentTabIndex == 0)
            this.paintTask(g);
          if (this.currentTabIndex == 1)
            this.paintInventory(g);
          if (this.currentTabIndex == 2)
            this.paintSkill(g);
          if (this.currentTabIndex == 3)
          {
            if (this.mainTabName.Length == 4)
              this.paintTools(g);
            else
              this.paintClans(g);
          }
          if (this.currentTabIndex == 4)
          {
            this.paintTools(g);
            break;
          }
          break;
        case 1:
          this.paintShop(g);
          break;
        case 2:
          if (this.currentTabIndex == 0)
            this.paintBox(g);
          if (this.currentTabIndex == 1)
          {
            this.paintInventory(g);
            break;
          }
          break;
        case 3:
          this.paintZone(g);
          break;
        case 4:
          this.paintMap(g);
          break;
        case 7:
          this.paintInventory(g);
          break;
        case 8:
          this.paintLogChat(g);
          break;
        case 9:
          this.paintArchivement(g);
          break;
        case 10:
          this.paintPlayerMenu(g);
          break;
        case 11:
          this.paintFriend(g);
          break;
        case 12:
          if (this.currentTabIndex == 0)
            this.paintCombine(g);
          if (this.currentTabIndex == 1)
          {
            this.paintInventory(g);
            break;
          }
          break;
        case 13:
          if (this.currentTabIndex == 0)
          {
            if (this.Equals((object) GameCanvas.panel))
              this.paintInventory(g);
            else
              this.paintGiaoDich(g, false);
          }
          if (this.currentTabIndex == 1)
            this.paintGiaoDich(g, true);
          if (this.currentTabIndex == 2)
          {
            this.paintGiaoDich(g, false);
            break;
          }
          break;
        case 14:
          this.paintMapTrans(g);
          break;
        case 15:
          this.paintTop(g);
          break;
        case 16:
          this.paintEnemy(g);
          break;
        case 17:
          this.paintShop(g);
          break;
        case 18:
          this.paintFlagChange(g);
          break;
        case 19:
          this.paintOption(g);
          break;
        case 20:
          this.paintAccount(g);
          break;
        case 21:
          if (this.currentTabIndex == 0)
            this.paintPetInventory(g);
          if (this.currentTabIndex == 1)
            this.paintPetStatus(g);
          if (this.currentTabIndex == 2)
          {
            this.paintInventory(g);
            break;
          }
          break;
        case 22:
          this.paintAuto(g);
          break;
        case 23:
          this.paintGameInfo(g);
          break;
        case 24:
          this.paintGameSubInfo(g);
          break;
        case 25:
          this.paintSpeacialSkill(g);
          break;
      }
      GameScr.resetTranslate(g);
      this.paintDetail(g);
      if (this.cmx == this.cmtoX)
        this.cmdClose.paint(g);
      if (this.tabIcon == null || !this.tabIcon.isShow)
        return;
      this.tabIcon.paint(g);
    }
  }

  private void paintShop(mGraphics g)
  {
    if (this.type == 1 && this.currentTabIndex == this.currentTabName.Length - 1 && GameCanvas.panel2 == null && this.typeShop != 2)
    {
      this.paintInventory(g);
    }
    else
    {
      g.setColor(16711680);
      g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
      if (this.typeShop == 2 && this.Equals((object) GameCanvas.panel))
      {
        if (this.currentTabIndex <= 3 && GameCanvas.isTouch)
        {
          if (this.cmy < -50)
            GameCanvas.paintShukiren(this.xScroll + this.wScroll / 2, this.yScroll + 30, g);
          else if (this.cmy < 0)
            mFont.tahoma_7_grey.drawString(g, mResources.getDown, this.xScroll + this.wScroll / 2, this.yScroll + 15, 2);
          else if (this.cmyLim >= 0)
          {
            if (this.cmy > this.cmyLim + 50)
              GameCanvas.paintShukiren(this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - 30, g);
            else if (this.cmy > this.cmyLim)
              mFont.tahoma_7_grey.drawString(g, mResources.getUp, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - 25, 2);
          }
        }
        if (Char.myCharz().arrItemShop[this.currentTabIndex].Length == 0 && this.type != 17)
        {
          mFont.tahoma_7_grey.drawString(g, mResources.notYetSell, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - 10, 2);
          return;
        }
      }
      g.translate(0, -this.cmy);
      Item[] objArray = Char.myCharz().arrItemShop[this.currentTabIndex];
      if (this.typeShop == 2 && (this.currentTabIndex == 4 || this.type == 17))
      {
        objArray = Char.myCharz().arrItemShop[4];
        if (objArray.Length == 0)
        {
          mFont.tahoma_7_grey.drawString(g, mResources.notYetSell, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - 10, 2);
          return;
        }
      }
      int length = objArray.Length;
      for (int index1 = 0; index1 < length; ++index1)
      {
        int x = this.xScroll + 26;
        int y1 = this.yScroll + index1 * this.ITEM_HEIGHT;
        int w1 = this.wScroll - 26;
        int h1 = this.ITEM_HEIGHT - 1;
        int xScroll = this.xScroll;
        int y2 = this.yScroll + index1 * this.ITEM_HEIGHT;
        int w2 = 24;
        int h2 = this.ITEM_HEIGHT - 1;
        if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
        {
          g.setColor(index1 != this.selected ? 15196114 : 16383818);
          g.fillRect(x, y1, w1, h1);
          g.setColor(index1 != this.selected ? 9993045 : 9541120);
          g.fillRect(xScroll, y2, w2, h2);
          Item obj = objArray[index1];
          if (obj != null)
          {
            string str = string.Empty;
            mFont mFont1 = mFont.tahoma_7_green2;
            if (obj.isMe != (sbyte) 0 && this.typeShop == 2 && this.currentTabIndex <= 3 && !this.Equals((object) GameCanvas.panel2))
              mFont1 = mFont.tahoma_7b_green;
            if (obj.itemOption != null)
            {
              for (int index2 = 0; index2 < obj.itemOption.Length; ++index2)
              {
                if (obj.itemOption[index2].optionTemplate.id == 72)
                  str = " [+" + (object) obj.itemOption[index2].param + "]";
                if (obj.itemOption[index2].optionTemplate.id == 41)
                {
                  if (obj.itemOption[index2].param == 1)
                    mFont1 = Panel.GetFont(0);
                  else if (obj.itemOption[index2].param == 2)
                    mFont1 = Panel.GetFont(2);
                  else if (obj.itemOption[index2].param == 3)
                    mFont1 = Panel.GetFont(8);
                  else if (obj.itemOption[index2].param == 4)
                    mFont1 = Panel.GetFont(7);
                }
              }
            }
            mFont1.drawString(g, obj.template.name + str, x + 5, y1 + 1, 0);
            string empty = string.Empty;
            if (obj.itemOption != null && obj.itemOption.Length >= 1)
            {
              if (obj.itemOption[0] != null && obj.itemOption[0].optionTemplate.id != 102 && obj.itemOption[0].optionTemplate.id != 107)
                empty += obj.itemOption[0].getOptionString();
              mFont mFont2 = mFont.tahoma_7_blue;
              if (obj.compare < 0 && obj.template.type != (sbyte) 5)
                mFont2 = mFont.tahoma_7_red;
              if (this.typeShop == 2 && obj.itemOption.Length > 1 && obj.buyType != (sbyte) -1)
                empty += string.Empty;
              if (this.typeShop != 2 || this.typeShop == 2 && obj.buyType <= (sbyte) 1)
                mFont2.drawString(g, empty, x + 5, y1 + 11, 0);
            }
            if (obj.buySpec > 0)
            {
              SmallImage.drawSmallImage(g, (int) obj.iconSpec, x + w1 - 7, y1 + 9, 0, 3);
              mFont.tahoma_7b_blue.drawString(g, Res.formatNumber((long) obj.buySpec), x + w1 - 15, y1 + 1, mFont.RIGHT);
            }
            if (obj.buyCoin != 0 || obj.buyGold != 0)
            {
              if (this.typeShop != 2 && obj.powerRequire == 0L)
              {
                if (obj.buyCoin > 0 && obj.buyGold > 0)
                {
                  if (obj.buyCoin > 0)
                  {
                    g.drawImage(Panel.imgXu, x + w1 - 7, y1 + 7, 3);
                    mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber((long) obj.buyCoin), x + w1 - 15, y1 + 1, mFont.RIGHT);
                  }
                  if (obj.buyGold > 0)
                  {
                    g.drawImage(Panel.imgLuong, x + w1 - 7, y1 + 7 + 11, 3);
                    mFont.tahoma_7b_green.drawString(g, Res.formatNumber((long) obj.buyGold), x + w1 - 15, y1 + 12, mFont.RIGHT);
                  }
                }
                else
                {
                  if (obj.buyCoin > 0)
                  {
                    g.drawImage(Panel.imgXu, x + w1 - 7, y1 + 7, 3);
                    mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber((long) obj.buyCoin), x + w1 - 15, y1 + 1, mFont.RIGHT);
                  }
                  if (obj.buyGold > 0)
                  {
                    g.drawImage(Panel.imgLuong, x + w1 - 7, y1 + 7, 3);
                    mFont.tahoma_7b_green.drawString(g, Res.formatNumber((long) obj.buyGold), x + w1 - 15, y1 + 1, mFont.RIGHT);
                  }
                }
              }
              if (this.typeShop == 2 && this.currentTabIndex <= 3 && !this.Equals((object) GameCanvas.panel2))
              {
                if (obj.buyCoin > 0 && obj.buyGold > 0)
                {
                  if (obj.buyCoin > 0)
                  {
                    g.drawImage(Panel.imgXu, x + w1 - 7, y1 + 7, 3);
                    mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber2((long) obj.buyCoin), x + w1 - 15, y1 + 1, mFont.RIGHT);
                  }
                  if (obj.buyGold > 0)
                  {
                    g.drawImage(Panel.imgLuong, x + w1 - 7, y1 + 7 + 11, 3);
                    mFont.tahoma_7b_green.drawString(g, Res.formatNumber2((long) obj.buyGold), x + w1 - 15, y1 + 12, mFont.RIGHT);
                  }
                }
                else
                {
                  if (obj.buyCoin > 0)
                  {
                    g.drawImage(Panel.imgXu, x + w1 - 7, y1 + 7, 3);
                    mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber2((long) obj.buyCoin), x + w1 - 15, y1 + 1, mFont.RIGHT);
                  }
                  if (obj.buyGold > 0)
                  {
                    g.drawImage(Panel.imgLuong, x + w1 - 7, y1 + 7, 3);
                    mFont.tahoma_7b_green.drawString(g, Res.formatNumber2((long) obj.buyGold), x + w1 - 15, y1 + 1, mFont.RIGHT);
                  }
                }
              }
            }
            SmallImage.drawSmallImage(g, (int) obj.template.iconID, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
            if (obj.quantity > 1)
              mFont.tahoma_7_yellow.drawString(g, string.Empty + (object) obj.quantity, xScroll + w2, y2 + h2 - mFont.tahoma_7_yellow.getHeight(), 1);
            if (obj.newItem && GameCanvas.gameTick % 10 > 5)
              g.drawImage(Panel.imgNew, xScroll + w2 / 2, y1 + 19, 3);
          }
          if (this.typeShop == 2 && (this.Equals((object) GameCanvas.panel2) || this.currentTabIndex == 4) && obj.buyType != (sbyte) 0)
          {
            if (obj.buyType == (sbyte) 1)
            {
              mFont.tahoma_7_green.drawString(g, mResources.dangban, x + w1 - 5, y1 + 1, mFont.RIGHT);
              if (obj.buyCoin != -1)
              {
                g.drawImage(Panel.imgXu, x + w1 - 7, y1 + 19, 3);
                mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber2((long) obj.buyCoin), x + w1 - 15, y1 + 13, mFont.RIGHT);
              }
              else if (obj.buyGold != -1)
              {
                g.drawImage(Panel.imgLuongKhoa, x + w1 - 7, y1 + 17, 3);
                mFont.tahoma_7b_red.drawString(g, Res.formatNumber2((long) obj.buyGold), x + w1 - 15, y1 + 11, mFont.RIGHT);
              }
            }
            else if (obj.buyType == (sbyte) 2)
            {
              mFont.tahoma_7b_blue.drawString(g, mResources.daban, x + w1 - 5, y1 + 1, mFont.RIGHT);
              if (obj.buyCoin != -1)
              {
                g.drawImage(Panel.imgXu, x + w1 - 7, y1 + 17, 3);
                mFont.tahoma_7b_yellow.drawString(g, Res.formatNumber2((long) obj.buyCoin), x + w1 - 15, y1 + 11, mFont.RIGHT);
              }
              else if (obj.buyGold != -1)
              {
                g.drawImage(Panel.imgLuongKhoa, x + w1 - 7, y1 + 17, 3);
                mFont.tahoma_7b_red.drawString(g, Res.formatNumber2((long) obj.buyGold), x + w1 - 15, y1 + 11, mFont.RIGHT);
              }
            }
          }
        }
      }
      this.paintScrollArrow(g);
    }
  }

  private void paintAuto(mGraphics g)
  {
  }

  private void paintPetStatus(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index = 0; index < this.strStatus.Length; ++index)
    {
      int xScroll = this.xScroll;
      int y = this.yScroll + index * this.ITEM_HEIGHT;
      int w = this.wScroll - 1;
      int h = this.ITEM_HEIGHT - 1;
      if (y - this.cmy <= this.yScroll + this.hScroll && y - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(xScroll, y, w, h);
        mFont.tahoma_7b_dark.drawString(g, this.strStatus[index], this.xScroll + this.wScroll / 2, y + 6, mFont.CENTER);
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintPetSkill()
  {
  }

  private void paintPetInventory(mGraphics g)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    Item[] arrItemBody = Char.myPetz().arrItemBody;
    Skill[] arrPetSkill = Char.myPetz().arrPetSkill;
    for (int index1 = 0; index1 < arrItemBody.Length + arrPetSkill.Length; ++index1)
    {
      bool flag = index1 < arrItemBody.Length;
      int index2 = index1;
      int index3 = index1 - arrItemBody.Length;
      int x = this.xScroll + 36;
      int y1 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w1 = this.wScroll - 36;
      int h1 = this.ITEM_HEIGHT - 1;
      int xScroll = this.xScroll;
      int y2 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w2 = 34;
      int h2 = this.ITEM_HEIGHT - 1;
      if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        Item obj = !flag ? (Item) null : arrItemBody[index2];
        g.setColor(index1 != this.selected ? (!flag ? 15723751 : 15196114) : 16383818);
        g.fillRect(x, y1, w1, h1);
        g.setColor(index1 != this.selected ? (!flag ? 11837316 : 9993045) : 9541120);
        if (obj != null)
        {
          for (int index4 = 0; index4 < obj.itemOption.Length; ++index4)
          {
            if (obj.itemOption[index4].optionTemplate.id == 72 && obj.itemOption[index4].param > 0)
            {
              sbyte colorItemUpgrade = Panel.GetColor_Item_Upgrade(obj.itemOption[index4].param);
              if (Panel.GetColor_ItemBg((int) colorItemUpgrade) != -1)
                g.setColor(index1 != this.selected ? Panel.GetColor_ItemBg((int) colorItemUpgrade) : Panel.GetColor_ItemBg((int) colorItemUpgrade));
            }
          }
        }
        g.fillRect(xScroll, y2, w2, h2);
        if (obj != null && obj.isSelect && GameCanvas.panel.type == 12)
        {
          g.setColor(index1 != this.selected ? 6047789 : 7040779);
          g.fillRect(xScroll, y2, w2, h2);
        }
        if (obj != null)
        {
          string str = string.Empty;
          mFont mFont1 = mFont.tahoma_7_green2;
          if (obj.itemOption != null)
          {
            for (int index5 = 0; index5 < obj.itemOption.Length; ++index5)
            {
              if (obj.itemOption[index5].optionTemplate.id == 72)
                str = " [+" + (object) obj.itemOption[index5].param + "]";
              if (obj.itemOption[index5].optionTemplate.id == 41)
              {
                if (obj.itemOption[index5].param == 1)
                  mFont1 = Panel.GetFont(0);
                else if (obj.itemOption[index5].param == 2)
                  mFont1 = Panel.GetFont(2);
                else if (obj.itemOption[index5].param == 3)
                  mFont1 = Panel.GetFont(8);
                else if (obj.itemOption[index5].param == 4)
                  mFont1 = Panel.GetFont(7);
              }
            }
          }
          mFont1.drawString(g, obj.template.name + str, x + 5, y1 + 1, 0);
          string st = string.Empty;
          if (obj.itemOption != null)
          {
            if (obj.itemOption.Length > 0 && obj.itemOption[0] != null && obj.itemOption[0].optionTemplate.id != 102 && obj.itemOption[0].optionTemplate.id != 107)
              st += obj.itemOption[0].getOptionString();
            mFont mFont2 = mFont.tahoma_7_blue;
            if (obj.compare < 0 && obj.template.type != (sbyte) 5)
              mFont2 = mFont.tahoma_7_red;
            if (obj.itemOption.Length > 1)
            {
              for (int index6 = 1; index6 < 2; ++index6)
              {
                if (obj.itemOption[index6] != null && obj.itemOption[index6].optionTemplate.id != 102 && obj.itemOption[index6].optionTemplate.id != 107)
                  st = st + "," + obj.itemOption[index6].getOptionString();
              }
            }
            mFont2.drawString(g, st, x + 5, y1 + 11, mFont.LEFT);
          }
          SmallImage.drawSmallImage(g, (int) obj.template.iconID, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
          if (obj.itemOption != null)
          {
            for (int index7 = 0; index7 < obj.itemOption.Length; ++index7)
              this.paintOptItem(g, obj.itemOption[index7].optionTemplate.id, obj.itemOption[index7].param, xScroll, y2, w2, h2);
            for (int index8 = 0; index8 < obj.itemOption.Length; ++index8)
              this.paintOptSlotItem(g, obj.itemOption[index8].optionTemplate.id, obj.itemOption[index8].param, xScroll, y2, w2, h2);
          }
          if (obj.quantity > 1)
            mFont.tahoma_7_yellow.drawString(g, string.Empty + (object) obj.quantity, xScroll + w2, y2 + h2 - mFont.tahoma_7_yellow.getHeight(), 1);
        }
        else if (!flag)
        {
          Skill skill = arrPetSkill[index3];
          g.drawImage(GameScr.imgSkill, xScroll + w2 / 2, y2 + h2 / 2, 3);
          if (skill.template != null)
          {
            mFont.tahoma_7_blue.drawString(g, skill.template.name, x + 5, y1 + 1, 0);
            mFont.tahoma_7_green2.drawString(g, mResources.level + ": " + (object) skill.point + string.Empty, x + 5, y1 + 11, 0);
            SmallImage.drawSmallImage(g, skill.template.iconId, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
          }
          else
          {
            mFont.tahoma_7_green2.drawString(g, skill.moreInfo, x + 5, y1 + 5, 0);
            SmallImage.drawSmallImage(g, GameScr.efs[98].arrEfInfo[0].idImg, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
          }
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintScrollArrow(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    if (this.cmy > 24 && this.currentListLength > 0 || this.Equals((object) GameCanvas.panel) && this.typeShop == 2 && this.maxPageShop[this.currentTabIndex] > 1)
      g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 1, this.xScroll + this.wScroll - 12, this.yScroll + 3, 0);
    if ((this.cmy >= this.cmyLim || this.currentListLength <= 0) && (!this.Equals((object) GameCanvas.panel) || this.typeShop != 2 || this.maxPageShop[this.currentTabIndex] <= 1))
      return;
    g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.xScroll + this.wScroll - 12, this.yScroll + this.hScroll - 8, 0);
  }

  private void paintTools(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index1 = 0; index1 < Panel.strTool.Length; ++index1)
    {
      int xScroll = this.xScroll;
      int y = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w = this.wScroll - 1;
      int h = this.ITEM_HEIGHT - 1;
      if (y - this.cmy <= this.yScroll + this.hScroll && y - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index1 != this.selected ? 15196114 : 16383818);
        g.fillRect(xScroll, y, w, h);
        mFont.tahoma_7b_dark.drawString(g, Panel.strTool[index1], this.xScroll + this.wScroll / 2, y + 6, mFont.CENTER);
        if (Panel.strTool[index1].Equals(mResources.gameInfo))
        {
          for (int index2 = 0; index2 < Panel.vGameInfo.size(); ++index2)
          {
            if (!((GameInfo) Panel.vGameInfo.elementAt(index2)).hasRead)
            {
              if (GameCanvas.gameTick % 20 > 10)
              {
                g.drawImage(Panel.imgNew, xScroll + 10, y + 10, 3);
                break;
              }
              break;
            }
          }
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintGameSubInfo(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index = 0; index < Panel.contenInfo.Length; ++index)
    {
      int xScroll = this.xScroll;
      int num1 = this.yScroll + index * 15;
      int num2 = this.wScroll - 1;
      int num3 = this.ITEM_HEIGHT - 1;
      if (num1 - this.cmy <= this.yScroll + this.hScroll && num1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
        mFont.tahoma_7b_dark.drawString(g, Panel.contenInfo[index], this.xScroll + 5, num1 + 6, mFont.LEFT);
    }
    this.paintScrollArrow(g);
  }

  private void paintGameInfo(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index = 0; index < Panel.vGameInfo.size(); ++index)
    {
      GameInfo gameInfo = (GameInfo) Panel.vGameInfo.elementAt(index);
      int xScroll = this.xScroll;
      int y = this.yScroll + index * this.ITEM_HEIGHT;
      int w = this.wScroll - 1;
      int h = this.ITEM_HEIGHT - 1;
      if (y - this.cmy <= this.yScroll + this.hScroll && y - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(xScroll, y, w, h);
        mFont.tahoma_7b_dark.drawString(g, gameInfo.main, this.xScroll + this.wScroll / 2, y + 6, mFont.CENTER);
        if (!gameInfo.hasRead && GameCanvas.gameTick % 20 > 10)
          g.drawImage(Panel.imgNew, xScroll + 10, y + 10, 3);
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintSkill(mGraphics g)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    int length = Char.myCharz().nClass.skillTemplates.Length;
    for (int index1 = 0; index1 < length + 6; ++index1)
    {
      int x = this.xScroll + 30;
      int y1 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w = this.wScroll - 30;
      int h = this.ITEM_HEIGHT - 1;
      int xScroll = this.xScroll;
      int y2 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int num1 = this.ITEM_HEIGHT - 1;
      if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index1 != this.selected ? 15196114 : 16383818);
        if (index1 == 5)
          g.setColor(index1 != this.selected ? 16765060 : 16776068);
        g.fillRect(x, y1, w, h);
        g.drawImage(GameScr.imgSkill, xScroll, y2, 0);
        if (index1 == 0)
        {
          SmallImage.drawSmallImage(g, 567, xScroll + 4, y2 + 4, 0, 0);
          string st = mResources.HP + " " + mResources.root + ": " + NinjaUtil.getMoneys((long) Char.myCharz().cHPGoc);
          mFont.tahoma_7b_blue.drawString(g, st, x + 5, y1 + 3, 0);
          mFont.tahoma_7_green2.drawString(g, NinjaUtil.getMoneys((long) (Char.myCharz().cHPGoc + 1000)) + " " + mResources.potential + ": " + mResources.increase + " " + (object) Char.myCharz().hpFrom1000TiemNang, x + 5, y1 + 15, 0);
        }
        if (index1 == 1)
        {
          SmallImage.drawSmallImage(g, 569, xScroll + 4, y2 + 4, 0, 0);
          string st = mResources.KI + " " + mResources.root + ": " + NinjaUtil.getMoneys((long) Char.myCharz().cMPGoc);
          mFont.tahoma_7b_blue.drawString(g, st, x + 5, y1 + 3, 0);
          mFont.tahoma_7_green2.drawString(g, NinjaUtil.getMoneys((long) (Char.myCharz().cMPGoc + 1000)) + " " + mResources.potential + ": " + mResources.increase + " " + (object) Char.myCharz().mpFrom1000TiemNang, x + 5, y1 + 15, 0);
        }
        if (index1 == 2)
        {
          SmallImage.drawSmallImage(g, 568, xScroll + 4, y2 + 4, 0, 0);
          string st = mResources.hit_point + " " + mResources.root + ": " + NinjaUtil.getMoneys((long) Char.myCharz().cDamGoc);
          mFont.tahoma_7b_blue.drawString(g, st, x + 5, y1 + 3, 0);
          mFont.tahoma_7_green2.drawString(g, NinjaUtil.getMoneys((long) (Char.myCharz().cDamGoc * 100)) + " " + mResources.potential + ": " + mResources.increase + " " + (object) Char.myCharz().damFrom1000TiemNang, x + 5, y1 + 15, 0);
        }
        if (index1 == 3)
        {
          SmallImage.drawSmallImage(g, 721, xScroll + 4, y2 + 4, 0, 0);
          string st = mResources.armor + " " + mResources.root + ": " + NinjaUtil.getMoneys((long) Char.myCharz().cDefGoc);
          mFont.tahoma_7b_blue.drawString(g, st, x + 5, y1 + 3, 0);
          mFont.tahoma_7_green2.drawString(g, NinjaUtil.getMoneys((long) (500000 + Char.myCharz().cDefGoc * 100000)) + " " + mResources.potential + ": " + mResources.increase + " " + (object) Char.myCharz().defFrom1000TiemNang, x + 5, y1 + 15, 0);
        }
        if (index1 == 4)
        {
          SmallImage.drawSmallImage(g, 719, xScroll + 4, y2 + 4, 0, 0);
          string st = mResources.critical + " " + mResources.root + ": " + (object) Char.myCharz().cCriticalGoc + "%";
          long num2 = 50000000;
          for (int index2 = 0; index2 < Char.myCharz().cCriticalGoc; ++index2)
            num2 *= 5L;
          mFont.tahoma_7b_blue.drawString(g, st, x + 5, y1 + 3, 0);
          long m = num2;
          mFont.tahoma_7_green2.drawString(g, NinjaUtil.getMoneys(m) + " " + mResources.potential + ": " + mResources.increase + " " + (object) Char.myCharz().criticalFrom1000Tiemnang, x + 5, y1 + 15, 0);
        }
        if (index1 == 5)
        {
          if (Panel.specialInfo != null)
          {
            SmallImage.drawSmallImage(g, (int) Panel.spearcialImage, xScroll + 4, y2 + 4, 0, 0);
            string[] strArray = mFont.tahoma_7.splitFontArray(Panel.specialInfo, 120);
            for (int index3 = 0; index3 < strArray.Length; ++index3)
              mFont.tahoma_7_green2.drawString(g, strArray[index3], x + 5, y1 + 3 + index3 * 12, 0);
          }
          else
            mFont.tahoma_7_green2.drawString(g, string.Empty, x + 5, y1 + 9, 0);
        }
        if (index1 >= 6)
        {
          int index4 = index1 - 6;
          SkillTemplate skillTemplate = Char.myCharz().nClass.skillTemplates[index4];
          SmallImage.drawSmallImage(g, skillTemplate.iconId, xScroll + 4, y2 + 4, 0, 0);
          Skill skill1 = Char.myCharz().getSkill(skillTemplate);
          if (skill1 != null)
          {
            mFont.tahoma_7b_blue.drawString(g, skillTemplate.name, x + 5, y1 + 3, 0);
            mFont.tahoma_7_blue.drawString(g, mResources.level + ": " + (object) skill1.point, x + w - 5, y1 + 3, mFont.RIGHT);
            if (skill1.point == skillTemplate.maxPoint)
            {
              mFont.tahoma_7_green2.drawString(g, mResources.max_level_reach, x + 5, y1 + 15, 0);
            }
            else
            {
              Skill skill2 = skillTemplate.skills[skill1.point];
              mFont.tahoma_7_green2.drawString(g, mResources.level + " " + (object) (skill1.point + 1) + " " + mResources.need + " " + Res.formatNumber2(skill2.powRequire) + " " + mResources.potential, x + 5, y1 + 15, 0);
            }
          }
          else
          {
            Skill skill3 = skillTemplate.skills[0];
            mFont.tahoma_7b_green.drawString(g, skillTemplate.name, x + 5, y1 + 3, 0);
            mFont.tahoma_7_green2.drawString(g, mResources.need_upper + " " + Res.formatNumber2(skill3.powRequire) + " " + mResources.potential_to_learn, x + 5, y1 + 15, 0);
          }
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintMapTrans(mGraphics g)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index = 0; index < this.mapNames.Length; ++index)
    {
      int num1 = this.xScroll + 36;
      int y = this.yScroll + index * this.ITEM_HEIGHT;
      int num2 = this.wScroll - 36;
      int h = this.ITEM_HEIGHT - 1;
      int xScroll = this.xScroll;
      int num3 = this.yScroll + index * this.ITEM_HEIGHT;
      int num4 = this.ITEM_HEIGHT - 1;
      if (y - this.cmy <= this.yScroll + this.hScroll && y - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(this.xScroll, y, this.wScroll, h);
        mFont.tahoma_7b_blue.drawString(g, this.mapNames[index], 5, y + 1, 0);
        mFont.tahoma_7_grey.drawString(g, this.planetNames[index], 5, y + 11, 0);
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintZone(mGraphics g)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    int[] zones = GameScr.gI().zones;
    int[] pts = GameScr.gI().pts;
    for (int index = 0; index < pts.Length; ++index)
    {
      int x = this.xScroll + 36;
      int y1 = this.yScroll + index * this.ITEM_HEIGHT;
      int w1 = this.wScroll - 36;
      int h1 = this.ITEM_HEIGHT - 1;
      int xScroll = this.xScroll;
      int y2 = this.yScroll + index * this.ITEM_HEIGHT;
      int w2 = 34;
      int h2 = this.ITEM_HEIGHT - 1;
      if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(x, y1, w1, h1);
        g.setColor(this.zoneColor[pts[index]]);
        g.fillRect(xScroll, y2, w2, h2);
        if (zones[index] != -1)
        {
          if (pts[index] != 1)
            mFont.tahoma_7_yellow.drawString(g, zones[index].ToString() + string.Empty, xScroll + w2 / 2, y1 + 6, mFont.CENTER);
          else
            mFont.tahoma_7_grey.drawString(g, zones[index].ToString() + string.Empty, xScroll + w2 / 2, y1 + 6, mFont.CENTER);
          mFont.tahoma_7_green2.drawString(g, GameScr.gI().numPlayer[index].ToString() + "/" + (object) GameScr.gI().maxPlayer[index], x + 5, y1 + 6, 0);
        }
        if (GameScr.gI().rankName1[index] != null)
        {
          mFont.tahoma_7_grey.drawString(g, GameScr.gI().rankName1[index] + "(Top " + (object) GameScr.gI().rank1[index] + ")", x + w1 - 2, y1 + 1, mFont.RIGHT);
          mFont.tahoma_7_grey.drawString(g, GameScr.gI().rankName2[index] + "(Top " + (object) GameScr.gI().rank2[index] + ")", x + w1 - 2, y1 + 11, mFont.RIGHT);
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintSpeacialSkill(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    g.setColor(0);
    if (this.currentListLength == 0)
      return;
    int num1 = (this.cmy + this.hScroll) / 24 + 1;
    if (num1 < this.hScroll / 24 + 1)
      num1 = this.hScroll / 24 + 1;
    if (num1 > this.currentListLength)
      num1 = this.currentListLength;
    int num2 = this.cmy / 24;
    if (num2 >= num1)
      num2 = num1 - 1;
    if (num2 < 0)
      num2 = 0;
    for (int index1 = num2; index1 < num1; ++index1)
    {
      int xScroll = this.xScroll;
      int y1 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w1 = 24;
      int h1 = this.ITEM_HEIGHT - 1;
      int x = this.xScroll + w1;
      int y2 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w2 = this.wScroll - w1;
      int h2 = this.ITEM_HEIGHT - 1;
      g.setColor(index1 != this.selected ? 15196114 : 16383818);
      g.fillRect(x, y2, w2, h2);
      g.setColor(index1 != this.selected ? 9993045 : 9541120);
      g.fillRect(xScroll, y1, w1, h1);
      SmallImage.drawSmallImage(g, (int) Char.myCharz().imgSpeacialSkill[this.currentTabIndex][index1], xScroll + w1 / 2, y1 + h1 / 2, 0, 3);
      string[] strArray = mFont.tahoma_7_grey.splitFontArray(Char.myCharz().infoSpeacialSkill[this.currentTabIndex][index1], 140);
      for (int index2 = 0; index2 < strArray.Length; ++index2)
        mFont.tahoma_7_grey.drawString(g, strArray[index2], x + 5, y2 + 1 + index2 * 11, 0);
    }
    this.paintScrollArrow(g);
  }

  private void paintBox(mGraphics g)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    try
    {
      Item[] arrItemBox = Char.myCharz().arrItemBox;
      this.currentListLength = this.checkCurrentListLength(arrItemBox.Length);
      int num1 = arrItemBox.Length / 20 + (arrItemBox.Length % 20 <= 0 ? 0 : 1);
      this.TAB_W_NEW = this.wScroll / num1;
      for (int select = 0; select < this.currentListLength; ++select)
      {
        int x = this.xScroll + 36;
        int y1 = this.yScroll + select * this.ITEM_HEIGHT;
        int w1 = this.wScroll - 36;
        int h1 = this.ITEM_HEIGHT - 1;
        int xScroll = this.xScroll;
        int y2 = this.yScroll + select * this.ITEM_HEIGHT;
        int w2 = 34;
        int h2 = this.ITEM_HEIGHT - 1;
        if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
        {
          if (select == 0)
          {
            for (int index = 0; index < num1; ++index)
            {
              int num2 = index != this.newSelected || this.selected != 0 ? 0 : (GameCanvas.gameTick % 10 >= 7 ? 0 : -1);
              g.setColor(index != this.newSelected ? 15723751 : 16383818);
              g.fillRect(this.xScroll + index * this.TAB_W_NEW, y1 + 9 + num2, this.TAB_W_NEW - 1, 14);
              mFont.tahoma_7_grey.drawString(g, string.Empty + (object) index, this.xScroll + index * this.TAB_W_NEW + this.TAB_W_NEW / 2, this.yScroll + 11 + num2, mFont.CENTER);
            }
          }
          else
          {
            g.setColor(select != this.selected ? 15196114 : 16383818);
            g.fillRect(x, y1, w1, h1);
            g.setColor(select != this.selected ? 9993045 : 9541120);
            int inventorySelectBody = this.GetInventorySelect_body(select, this.newSelected);
            Item obj = arrItemBox[inventorySelectBody];
            if (obj != null)
            {
              for (int index = 0; index < obj.itemOption.Length; ++index)
              {
                if (obj.itemOption[index].optionTemplate.id == 72 && obj.itemOption[index].param > 0)
                {
                  sbyte colorItemUpgrade = Panel.GetColor_Item_Upgrade(obj.itemOption[index].param);
                  if (Panel.GetColor_ItemBg((int) colorItemUpgrade) != -1)
                    g.setColor(select != this.selected ? Panel.GetColor_ItemBg((int) colorItemUpgrade) : Panel.GetColor_ItemBg((int) colorItemUpgrade));
                }
              }
            }
            g.fillRect(xScroll, y2, w2, h2);
            if (obj != null)
            {
              string str = string.Empty;
              mFont mFont1 = mFont.tahoma_7_green2;
              if (obj.itemOption != null)
              {
                for (int index = 0; index < obj.itemOption.Length; ++index)
                {
                  if (obj.itemOption[index].optionTemplate.id == 72)
                    str = " [+" + obj.itemOption[index].getOptionString() + "]";
                  if (obj.itemOption[index].optionTemplate.id == 41)
                  {
                    if (obj.itemOption[index].param == 1)
                      mFont1 = Panel.GetFont(0);
                    else if (obj.itemOption[index].param == 2)
                      mFont1 = Panel.GetFont(2);
                    else if (obj.itemOption[index].param == 3)
                      mFont1 = Panel.GetFont(8);
                    else if (obj.itemOption[index].param == 4)
                      mFont1 = Panel.GetFont(7);
                  }
                }
              }
              mFont1.drawString(g, obj.template.name + str, x + 5, y1 + 1, 0);
              string st = string.Empty;
              if (obj.itemOption != null)
              {
                if (obj.itemOption.Length > 0 && obj.itemOption[0] != null)
                  st += obj.itemOption[0].getOptionString();
                mFont mFont2 = mFont.tahoma_7_blue;
                if (obj.compare < 0 && obj.template.type != (sbyte) 5)
                  mFont2 = mFont.tahoma_7_red;
                if (obj.itemOption.Length > 1)
                {
                  for (int index = 1; index < obj.itemOption.Length; ++index)
                  {
                    if (obj.itemOption[index] != null && obj.itemOption[index].optionTemplate.id != 102 && obj.itemOption[index].optionTemplate.id != 107)
                      st = st + "," + obj.itemOption[index].getOptionString();
                  }
                }
                mFont2.drawString(g, st, x + 5, y1 + 11, mFont.LEFT);
              }
              SmallImage.drawSmallImage(g, (int) obj.template.iconID, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
              if (obj.itemOption != null)
              {
                for (int index = 0; index < obj.itemOption.Length; ++index)
                  this.paintOptItem(g, obj.itemOption[index].optionTemplate.id, obj.itemOption[index].param, xScroll, y2, w2, h2);
                for (int index = 0; index < obj.itemOption.Length; ++index)
                  this.paintOptSlotItem(g, obj.itemOption[index].optionTemplate.id, obj.itemOption[index].param, xScroll, y2, w2, h2);
              }
              if (obj.quantity > 1)
                mFont.tahoma_7_yellow.drawString(g, string.Empty + (object) obj.quantity, xScroll + w2, y2 + h2 - mFont.tahoma_7_yellow.getHeight(), 1);
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
    this.paintScrollArrow(g);
  }

  public Member getCurrMember()
  {
    if (this.selected < 2)
      return (Member) null;
    if (this.selected > (this.member == null ? this.myMember.size() : this.member.size()) + 1)
      return (Member) null;
    return this.member != null ? (Member) this.member.elementAt(this.selected - 2) : (Member) this.myMember.elementAt(this.selected - 2);
  }

  public ClanMessage getCurrMessage()
  {
    if (this.selected < 2)
      return (ClanMessage) null;
    return this.selected > ClanMessage.vMessage.size() + 1 ? (ClanMessage) null : (ClanMessage) ClanMessage.vMessage.elementAt(this.selected - 2);
  }

  public Clan getCurrClan()
  {
    if (this.selected < 2)
      return (Clan) null;
    return this.selected > this.clans.Length + 1 ? (Clan) null : this.clans[this.selected - 2];
  }

  private void paintLogChat(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    g.setColor(0);
    if (this.logChat.size() == 0)
      mFont.tahoma_7_green2.drawString(g, mResources.no_msg, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2 + 24, 2);
    for (int index = 0; index < this.currentListLength; ++index)
    {
      int xScroll = this.xScroll;
      int y1 = this.yScroll + index * this.ITEM_HEIGHT;
      int w1 = 24;
      int h1 = this.ITEM_HEIGHT - 1;
      int x = this.xScroll + w1;
      int y2 = this.yScroll + index * this.ITEM_HEIGHT;
      int w2 = this.wScroll - w1;
      int h2 = this.ITEM_HEIGHT - 1;
      if (index == 0)
      {
        g.setColor(15196114);
        g.fillRect(xScroll, y2, this.wScroll, h2);
        g.drawImage(index != this.selected ? GameScr.imgLbtn2 : GameScr.imgLbtnFocus2, this.xScroll + this.wScroll - 5, y2 + 2, StaticObj.TOP_RIGHT);
        (index != this.selected ? mFont.tahoma_7b_dark : mFont.tahoma_7b_green2).drawString(g, !this.isViewChatServer ? mResources.on : mResources.off, this.xScroll + this.wScroll - 22, y2 + 7, 2);
        mFont.tahoma_7_grey.drawString(g, !this.isViewChatServer ? mResources.onPlease : mResources.offPlease, this.xScroll + 5, y2 + h2 / 2 - 4, mFont.LEFT);
      }
      else
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(x, y2, w2, h2);
        g.setColor(index != this.selected ? 9993045 : 9541120);
        g.fillRect(xScroll, y1, w1, h1);
        InfoItem infoItem = (InfoItem) this.logChat.elementAt(index - 1);
        if (infoItem.charInfo.headICON != -1)
        {
          SmallImage.drawSmallImage(g, infoItem.charInfo.headICON, xScroll, y1, 0, 0);
        }
        else
        {
          Part part = GameScr.parts[infoItem.charInfo.head];
          SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, xScroll + (int) part.pi[Char.CharInfo[0][0][0]].dx, y1 + (int) part.pi[Char.CharInfo[0][0][0]].dy, 0, 0);
        }
        g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
        mFont tahoma7bDark = mFont.tahoma_7b_dark;
        mFont.tahoma_7b_green2.drawString(g, infoItem.charInfo.cName, x + 5, y2, 0);
        if (!infoItem.isChatServer)
          mFont.tahoma_7_blue.drawString(g, Res.split(infoItem.s, "|", 0)[2], x + 5, y2 + 11, 0);
        else
          mFont.tahoma_7_red.drawString(g, Res.split(infoItem.s, "|", 0)[2], x + 5, y2 + 11, 0);
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintFlagChange(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    g.setColor(0);
    for (int index = 0; index < this.currentListLength; ++index)
    {
      int x = this.xScroll + 26;
      int y1 = this.yScroll + index * this.ITEM_HEIGHT;
      int w1 = this.wScroll - 26;
      int h1 = this.ITEM_HEIGHT - 1;
      int xScroll = this.xScroll;
      int y2 = this.yScroll + index * this.ITEM_HEIGHT;
      int w2 = 24;
      int h2 = this.ITEM_HEIGHT - 1;
      if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(x, y1, w1, h1);
        g.setColor(index != this.selected ? 9993045 : 9541120);
        g.fillRect(xScroll, y2, w2, h2);
        Item obj = (Item) this.vFlag.elementAt(index);
        if (obj != null)
        {
          mFont.tahoma_7_green2.drawString(g, obj.template.name, x + 5, y1 + 1, 0);
          string empty = string.Empty;
          if (obj.itemOption != null && obj.itemOption.Length >= 1)
          {
            if (obj.itemOption[0] != null && obj.itemOption[0].optionTemplate.id != 102 && obj.itemOption[0].optionTemplate.id != 107)
              empty += obj.itemOption[0].getOptionString();
            mFont.tahoma_7_blue.drawString(g, empty, x + 5, y1 + 11, 0);
            SmallImage.drawSmallImage(g, (int) obj.template.iconID, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
          }
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintEnemy(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    g.setColor(0);
    if (this.currentListLength == 0)
    {
      mFont.tahoma_7_green2.drawString(g, mResources.no_enemy, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
    }
    else
    {
      for (int index = 0; index < this.currentListLength; ++index)
      {
        int xScroll = this.xScroll;
        int y1 = this.yScroll + index * this.ITEM_HEIGHT;
        int w1 = 24;
        int h1 = this.ITEM_HEIGHT - 1;
        int x = this.xScroll + w1;
        int y2 = this.yScroll + index * this.ITEM_HEIGHT;
        int w2 = this.wScroll - w1;
        int h2 = this.ITEM_HEIGHT - 1;
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(x, y2, w2, h2);
        g.setColor(index != this.selected ? 9993045 : 9541120);
        g.fillRect(xScroll, y1, w1, h1);
        InfoItem infoItem = (InfoItem) this.vEnemy.elementAt(index);
        if (infoItem.charInfo.headICON != -1)
        {
          SmallImage.drawSmallImage(g, infoItem.charInfo.headICON, xScroll, y1, 0, 0);
        }
        else
        {
          Part part = GameScr.parts[infoItem.charInfo.head];
          SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, xScroll + (int) part.pi[Char.CharInfo[0][0][0]].dx, y1 + 3 + (int) part.pi[Char.CharInfo[0][0][0]].dy, 0, 0);
        }
        g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
        if (infoItem.isOnline)
        {
          mFont.tahoma_7b_green.drawString(g, infoItem.charInfo.cName, x + 5, y2, 0);
          mFont.tahoma_7_blue.drawString(g, infoItem.s, x + 5, y2 + 11, 0);
        }
        else
        {
          mFont.tahoma_7_grey.drawString(g, infoItem.charInfo.cName, x + 5, y2, 0);
          mFont.tahoma_7_grey.drawString(g, infoItem.s, x + 5, y2 + 11, 0);
        }
      }
      this.paintScrollArrow(g);
    }
  }

  private void paintFriend(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    g.setColor(0);
    if (this.currentListLength == 0)
    {
      mFont.tahoma_7_green2.drawString(g, mResources.no_friend, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
    }
    else
    {
      for (int index = 0; index < this.currentListLength; ++index)
      {
        int xScroll = this.xScroll;
        int y1 = this.yScroll + index * this.ITEM_HEIGHT;
        int w1 = 24;
        int h1 = this.ITEM_HEIGHT - 1;
        int x = this.xScroll + w1;
        int y2 = this.yScroll + index * this.ITEM_HEIGHT;
        int w2 = this.wScroll - w1;
        int h2 = this.ITEM_HEIGHT - 1;
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(x, y2, w2, h2);
        g.setColor(index != this.selected ? 9993045 : 9541120);
        g.fillRect(xScroll, y1, w1, h1);
        InfoItem infoItem = (InfoItem) this.vFriend.elementAt(index);
        if (infoItem.charInfo.headICON != -1)
        {
          SmallImage.drawSmallImage(g, infoItem.charInfo.headICON, xScroll, y1, 0, 0);
        }
        else
        {
          Part part = GameScr.parts[infoItem.charInfo.head];
          SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, xScroll + (int) part.pi[Char.CharInfo[0][0][0]].dx, y1 + 3 + (int) part.pi[Char.CharInfo[0][0][0]].dy, 0, 0);
        }
        g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
        if (infoItem.isOnline)
        {
          mFont.tahoma_7b_green.drawString(g, infoItem.charInfo.cName, x + 5, y2, 0);
          mFont.tahoma_7_blue.drawString(g, infoItem.s, x + 5, y2 + 11, 0);
        }
        else
        {
          mFont.tahoma_7_grey.drawString(g, infoItem.charInfo.cName, x + 5, y2, 0);
          mFont.tahoma_7_grey.drawString(g, infoItem.s, x + 5, y2 + 11, 0);
        }
      }
      this.paintScrollArrow(g);
    }
  }

  public void paintPlayerMenu(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index = 0; index < this.vPlayerMenu.size(); ++index)
    {
      int xScroll = this.xScroll;
      int y = this.yScroll + index * this.ITEM_HEIGHT;
      int w = this.wScroll - 1;
      int h = this.ITEM_HEIGHT - 1;
      if (y - this.cmy <= this.yScroll + this.hScroll && y - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        Command command = (Command) this.vPlayerMenu.elementAt(index);
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(xScroll, y, w, h);
        if (command.caption2.Equals(string.Empty))
        {
          mFont.tahoma_7b_dark.drawString(g, command.caption, this.xScroll + this.wScroll / 2, y + 6, mFont.CENTER);
        }
        else
        {
          mFont.tahoma_7b_dark.drawString(g, command.caption, this.xScroll + this.wScroll / 2, y + 1, mFont.CENTER);
          mFont.tahoma_7b_dark.drawString(g, command.caption2, this.xScroll + this.wScroll / 2, y + 11, mFont.CENTER);
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintClans(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(-this.cmx, -this.cmy);
    g.setColor(0);
    int num1 = this.xScroll + this.wScroll / 2 - this.clansOption.Length * this.TAB_W / 2;
    if (this.currentListLength == 2)
    {
      mFont.tahoma_7_green2.drawString(g, this.clanReport, this.xScroll + this.wScroll / 2, this.yScroll + 24 + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
      if (this.isMessage && this.myMember.size() == 1)
      {
        for (int index = 0; index < mResources.clanEmpty.Length; ++index)
          mFont.tahoma_7b_dark.drawString(g, mResources.clanEmpty[index], this.xScroll + this.wScroll / 2, this.yScroll + 24 + this.hScroll / 2 - mResources.clanEmpty.Length * 12 / 2 + index * 12, mFont.CENTER);
      }
    }
    for (int index1 = 0; index1 < this.currentListLength; ++index1)
    {
      int xScroll = this.xScroll;
      int y1 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w1 = 24;
      int h1 = this.ITEM_HEIGHT - 1;
      int x = this.xScroll + w1;
      int y2 = this.yScroll + index1 * this.ITEM_HEIGHT;
      int w2 = this.wScroll - w1;
      int h2 = this.ITEM_HEIGHT - 1;
      if (y2 - this.cmy <= this.yScroll + this.hScroll && y2 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        switch (index1)
        {
          case 0:
            for (int index2 = 0; index2 < this.clansOption.Length; ++index2)
            {
              g.setColor(index2 != this.cSelected || index1 != this.selected ? 15723751 : 16383818);
              g.fillRect(num1 + index2 * this.TAB_W, y2, this.TAB_W - 1, 23);
              for (int index3 = 0; index3 < this.clansOption[index2].Length; ++index3)
                mFont.tahoma_7_grey.drawString(g, this.clansOption[index2][index3], num1 + index2 * this.TAB_W + this.TAB_W / 2, this.yScroll + index3 * 11, mFont.CENTER);
            }
            continue;
          case 1:
            g.setColor(index1 != this.selected ? 15196114 : 16383818);
            g.fillRect(this.xScroll, y2, this.wScroll, h2);
            if (this.clanInfo != null)
            {
              mFont.tahoma_7b_dark.drawString(g, this.clanInfo, this.xScroll + this.wScroll / 2, y2 + 6, mFont.CENTER);
              continue;
            }
            continue;
          default:
            if (this.isSearchClan)
            {
              if (this.clans != null && this.clans.Length != 0)
              {
                g.setColor(index1 != this.selected ? 15196114 : 16383818);
                g.fillRect(x, y2, w2, h2);
                g.setColor(index1 != this.selected ? 9993045 : 9541120);
                g.fillRect(xScroll, y1, w1, h1);
                if (ClanImage.isExistClanImage(this.clans[index1 - 2].imgID))
                {
                  if (ClanImage.getClanImage((sbyte) this.clans[index1 - 2].imgID).idImage != null)
                    SmallImage.drawSmallImage(g, (int) ClanImage.getClanImage((sbyte) this.clans[index1 - 2].imgID).idImage[0], xScroll + w1 / 2, y1 + h1 / 2, 0, StaticObj.VCENTER_HCENTER);
                }
                else
                {
                  ClanImage cm = new ClanImage();
                  cm.ID = this.clans[index1 - 2].imgID;
                  if (!ClanImage.isExistClanImage(cm.ID))
                    ClanImage.addClanImage(cm);
                }
                mFont.tahoma_7b_green2.drawString(g, this.clans[index1 - 2].name, x + 5, y2, 0);
                g.setClip(x, y2, w2 - 10, h2);
                mFont.tahoma_7_blue.drawString(g, this.clans[index1 - 2].slogan, x + 5, y2 + 11, 0);
                g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
                mFont.tahoma_7_green2.drawString(g, this.clans[index1 - 2].currMember.ToString() + "/" + (object) this.clans[index1 - 2].maxMember, x + w2 - 5, y2, mFont.RIGHT);
                continue;
              }
              continue;
            }
            if (this.isViewMember)
            {
              g.setColor(index1 != this.selected ? 15196114 : 16383818);
              g.fillRect(x, y2, w2, h2);
              g.setColor(index1 != this.selected ? 9993045 : 9541120);
              g.fillRect(xScroll, y1, w1, h1);
              Member member = this.member == null ? (Member) this.myMember.elementAt(index1 - 2) : (Member) this.member.elementAt(index1 - 2);
              if (member.headICON != (short) -1)
              {
                SmallImage.drawSmallImage(g, (int) member.headICON, xScroll, y1, 0, 0);
              }
              else
              {
                Part part = GameScr.parts[(int) member.head];
                SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, xScroll + (int) part.pi[Char.CharInfo[0][0][0]].dx, y1 + 3 + (int) part.pi[Char.CharInfo[0][0][0]].dy, 0, 0);
              }
              g.setClip(this.xScroll, this.yScroll + this.cmy, this.wScroll, this.hScroll);
              mFont mFont = mFont.tahoma_7b_dark;
              if (member.role == (sbyte) 0)
                mFont = mFont.tahoma_7b_red;
              else if (member.role == (sbyte) 1)
                mFont = mFont.tahoma_7b_green;
              else if (member.role == (sbyte) 2)
                mFont = mFont.tahoma_7b_green2;
              mFont.drawString(g, member.name, x + 5, y2, 0);
              mFont.tahoma_7_blue.drawString(g, mResources.power + ": " + member.powerPoint, x + 5, y2 + 11, 0);
              SmallImage.drawSmallImage(g, 7223, x + w2 - 7, y2 + 12, 0, 3);
              mFont.tahoma_7_blue.drawString(g, string.Empty + (object) member.clanPoint, x + w2 - 15, y2 + 6, mFont.RIGHT);
              continue;
            }
            if (this.isMessage && ClanMessage.vMessage.size() != 0)
            {
              ClanMessage clanMessage = (ClanMessage) ClanMessage.vMessage.elementAt(index1 - 2);
              g.setColor(index1 != this.selected || clanMessage.option != null ? 15196114 : 16383818);
              g.fillRect(xScroll, y1, w2 + w1, h2);
              clanMessage.paint(g, xScroll, y1);
              if (clanMessage.option != null)
              {
                int num2 = this.xScroll + this.wScroll - 2 - clanMessage.option.Length * 40;
                for (int index4 = 0; index4 < clanMessage.option.Length; ++index4)
                {
                  if (index4 == this.cSelected && index1 == this.selected)
                  {
                    g.drawImage(GameScr.imgLbtnFocus2, num2 + index4 * 40 + 20, y2 + h2 / 2, StaticObj.VCENTER_HCENTER);
                    mFont.tahoma_7b_green2.drawString(g, clanMessage.option[index4], num2 + index4 * 40 + 20, y2 + 6, mFont.CENTER);
                  }
                  else
                  {
                    g.drawImage(GameScr.imgLbtn2, num2 + index4 * 40 + 20, y2 + h2 / 2, StaticObj.VCENTER_HCENTER);
                    mFont.tahoma_7b_dark.drawString(g, clanMessage.option[index4], num2 + index4 * 40 + 20, y2 + 6, mFont.CENTER);
                  }
                }
                continue;
              }
              continue;
            }
            continue;
        }
      }
    }
    this.paintScrollArrow(g);
  }

  private void paintArchivement(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    g.setColor(0);
    if (this.currentListLength == 0)
    {
      mFont.tahoma_7_green2.drawString(g, mResources.no_mission, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - mFont.tahoma_7.getHeight() / 2, 2);
    }
    else
    {
      if (Char.myCharz().arrArchive == null || Char.myCharz().arrArchive.Length != this.currentListLength)
        return;
      for (int index = 0; index < this.currentListLength; ++index)
      {
        int xScroll = this.xScroll;
        int y = this.yScroll + index * this.ITEM_HEIGHT;
        int wScroll = this.wScroll;
        int h = this.ITEM_HEIGHT - 1;
        Archivement archivement = Char.myCharz().arrArchive[index];
        g.setColor(index != this.selected || (archivement.isRecieve || archivement.isFinish) && (!archivement.isRecieve || !archivement.isFinish) ? 15196114 : 16383818);
        g.fillRect(xScroll, y, wScroll, h);
        if (archivement != null)
        {
          if (!archivement.isFinish)
          {
            mFont.tahoma_7.drawString(g, archivement.info1, xScroll + 5, y, 0);
            mFont.tahoma_7_green.drawString(g, archivement.money.ToString() + " " + mResources.RUBY, xScroll + wScroll - 5, y, mFont.RIGHT);
            mFont.tahoma_7_red.drawString(g, archivement.info2, xScroll + 5, y + 11, 0);
          }
          else if (archivement.isFinish && !archivement.isRecieve)
          {
            mFont.tahoma_7.drawString(g, archivement.info1, xScroll + 5, y, 0);
            mFont.tahoma_7_blue.drawString(g, mResources.reward_mission + (object) archivement.money + " " + mResources.RUBY, xScroll + 5, y + 11, 0);
            if (index == this.selected)
            {
              mFont.tahoma_7b_green2.drawString(g, mResources.receive_upper, xScroll + wScroll - 20, y + 6, mFont.CENTER);
              mFont.tahoma_7b_dark.drawString(g, mResources.receive_upper, xScroll + wScroll - 20, y + 6, mFont.CENTER);
            }
            else
            {
              g.drawImage(GameScr.imgLbtn2, xScroll + wScroll - 20, y + h / 2, StaticObj.VCENTER_HCENTER);
              mFont.tahoma_7b_dark.drawString(g, mResources.receive_upper, xScroll + wScroll - 20, y + 6, mFont.CENTER);
            }
          }
          else if (archivement.isFinish && archivement.isRecieve)
          {
            mFont.tahoma_7_green.drawString(g, archivement.info1, xScroll + 5, y, 0);
            mFont.tahoma_7_green.drawString(g, archivement.info2, xScroll + 5, y + 11, 0);
          }
        }
      }
      this.paintScrollArrow(g);
    }
  }

  private void paintCombine(mGraphics g)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    if (this.vItemCombine.size() == 0)
    {
      if (this.combineInfo == null)
        return;
      for (int index = 0; index < this.combineInfo.Length; ++index)
        mFont.tahoma_7b_dark.drawString(g, this.combineInfo[index], this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll / 2 - this.combineInfo.Length * 14 / 2 + index * 14 + 5, 2);
    }
    else
    {
      for (int index1 = 0; index1 < this.vItemCombine.size() + 1; ++index1)
      {
        int x = this.xScroll + 36;
        int y1 = this.yScroll + index1 * this.ITEM_HEIGHT;
        int w1 = this.wScroll - 36;
        int h1 = this.ITEM_HEIGHT - 1;
        int xScroll = this.xScroll;
        int y2 = this.yScroll + index1 * this.ITEM_HEIGHT;
        int w2 = 34;
        int h2 = this.ITEM_HEIGHT - 1;
        if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
        {
          if (index1 == this.vItemCombine.size())
          {
            if (this.vItemCombine.size() > 0)
            {
              if (!GameCanvas.isTouch && index1 == this.selected)
              {
                g.setColor(16383818);
                g.fillRect(xScroll, y1, this.wScroll, h1 + 2);
              }
              if (index1 == this.selected && this.keyTouchCombine == 1 || !GameCanvas.isTouch && index1 == this.selected)
              {
                g.drawImage(GameScr.imgLbtnFocus, this.xScroll + this.wScroll / 2, y1 + h1 / 2 + 1, StaticObj.VCENTER_HCENTER);
                mFont.tahoma_7b_green2.drawString(g, mResources.UPGRADE, this.xScroll + this.wScroll / 2, y1 + h1 / 2 - 4, mFont.CENTER);
              }
              else
              {
                g.drawImage(GameScr.imgLbtn, this.xScroll + this.wScroll / 2, y1 + h1 / 2 + 1, StaticObj.VCENTER_HCENTER);
                mFont.tahoma_7b_dark.drawString(g, mResources.UPGRADE, this.xScroll + this.wScroll / 2, y1 + h1 / 2 - 4, mFont.CENTER);
              }
            }
          }
          else
          {
            g.setColor(index1 != this.selected ? 15196114 : 16383818);
            g.fillRect(x, y1, w1, h1);
            g.setColor(index1 != this.selected ? 9993045 : 9541120);
            Item obj = (Item) this.vItemCombine.elementAt(index1);
            if (obj != null)
            {
              for (int index2 = 0; index2 < obj.itemOption.Length; ++index2)
              {
                if (obj.itemOption[index2].optionTemplate.id == 72 && obj.itemOption[index2].param > 0)
                {
                  sbyte colorItemUpgrade = Panel.GetColor_Item_Upgrade(obj.itemOption[index2].param);
                  if (Panel.GetColor_ItemBg((int) colorItemUpgrade) != -1)
                    g.setColor(index1 != this.selected ? Panel.GetColor_ItemBg((int) colorItemUpgrade) : Panel.GetColor_ItemBg((int) colorItemUpgrade));
                }
              }
            }
            g.fillRect(xScroll, y2, w2, h2);
            if (obj != null)
            {
              string str = string.Empty;
              mFont mFont1 = mFont.tahoma_7_green2;
              if (obj.itemOption != null)
              {
                for (int index3 = 0; index3 < obj.itemOption.Length; ++index3)
                {
                  if (obj.itemOption[index3].optionTemplate.id == 72)
                    str = " [+" + (object) obj.itemOption[index3].param + "]";
                  if (obj.itemOption[index3].optionTemplate.id == 41)
                  {
                    if (obj.itemOption[index3].param == 1)
                      mFont1 = Panel.GetFont(0);
                    else if (obj.itemOption[index3].param == 2)
                      mFont1 = Panel.GetFont(2);
                    else if (obj.itemOption[index3].param == 3)
                      mFont1 = Panel.GetFont(8);
                    else if (obj.itemOption[index3].param == 4)
                      mFont1 = Panel.GetFont(7);
                  }
                }
              }
              mFont1.drawString(g, obj.template.name + str, x + 5, y1 + 1, 0);
              string st = string.Empty;
              if (obj.itemOption != null)
              {
                if (obj.itemOption.Length > 0 && obj.itemOption[0] != null && obj.itemOption[0].optionTemplate.id != 102 && obj.itemOption[0].optionTemplate.id != 107)
                  st += obj.itemOption[0].getOptionString();
                mFont mFont2 = mFont.tahoma_7_blue;
                if (obj.compare < 0 && obj.template.type != (sbyte) 5)
                  mFont2 = mFont.tahoma_7_red;
                if (obj.itemOption.Length > 1)
                {
                  for (int index4 = 1; index4 < obj.itemOption.Length; ++index4)
                  {
                    if (obj.itemOption[index4] != null && obj.itemOption[index4].optionTemplate.id != 102 && obj.itemOption[index4].optionTemplate.id != 107)
                      st = st + "," + obj.itemOption[index4].getOptionString();
                  }
                }
                mFont2.drawString(g, st, x + 5, y1 + 11, mFont.LEFT);
              }
              SmallImage.drawSmallImage(g, (int) obj.template.iconID, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
              if (obj.itemOption != null)
              {
                for (int index5 = 0; index5 < obj.itemOption.Length; ++index5)
                  this.paintOptItem(g, obj.itemOption[index5].optionTemplate.id, obj.itemOption[index5].param, xScroll, y2, w2, h2);
                for (int index6 = 0; index6 < obj.itemOption.Length; ++index6)
                  this.paintOptSlotItem(g, obj.itemOption[index6].optionTemplate.id, obj.itemOption[index6].param, xScroll, y2, w2, h2);
              }
              if (obj.quantity > 1)
                mFont.tahoma_7_yellow.drawString(g, string.Empty + (object) obj.quantity, xScroll + w2, y2 + h2 - mFont.tahoma_7_yellow.getHeight(), 1);
            }
          }
        }
      }
      this.paintScrollArrow(g);
    }
  }

  private void paintInventory(mGraphics g)
  {
    g.setColor(16711680);
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    try
    {
      Item[] arrItemBody = Char.myCharz().arrItemBody;
      Item[] arrItemBag = Char.myCharz().arrItemBag;
      this.currentListLength = this.checkCurrentListLength(arrItemBody.Length + arrItemBag.Length);
      int num1 = (arrItemBody.Length + arrItemBag.Length) / 20 + ((arrItemBody.Length + arrItemBag.Length) % 20 <= 0 ? 0 : 1);
      this.TAB_W_NEW = this.wScroll / num1;
      for (int select = 0; select < this.currentListLength; ++select)
      {
        int x = this.xScroll + 36;
        int y1 = this.yScroll + select * this.ITEM_HEIGHT;
        int w1 = this.wScroll - 36;
        int h1 = this.ITEM_HEIGHT - 1;
        int xScroll = this.xScroll;
        int y2 = this.yScroll + select * this.ITEM_HEIGHT;
        int w2 = 34;
        int h2 = this.ITEM_HEIGHT - 1;
        if (y1 - this.cmy <= this.yScroll + this.hScroll && y1 - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
        {
          if (select == 0)
          {
            for (int index = 0; index < num1; ++index)
            {
              int num2 = index != this.newSelected || this.selected != 0 ? 0 : (GameCanvas.gameTick % 10 >= 7 ? 0 : -1);
              g.setColor(index != this.newSelected ? 15723751 : 16383818);
              g.fillRect(this.xScroll + index * this.TAB_W_NEW, y1 + 9 + num2, this.TAB_W_NEW - 1, 14);
              mFont.tahoma_7_grey.drawString(g, string.Empty + (object) index, this.xScroll + index * this.TAB_W_NEW + this.TAB_W_NEW / 2, this.yScroll + 11 + num2, mFont.CENTER);
            }
          }
          else
          {
            bool inventorySelectIsbody = this.GetInventorySelect_isbody(select, this.newSelected, Char.myCharz().arrItemBody);
            int inventorySelectBody = this.GetInventorySelect_body(select, this.newSelected);
            int inventorySelectBag = this.GetInventorySelect_bag(select, this.newSelected, Char.myCharz().arrItemBody);
            g.setColor(select != this.selected ? (!inventorySelectIsbody ? 15723751 : 15196114) : 16383818);
            g.fillRect(x, y1, w1, h1);
            g.setColor(select != this.selected ? (!inventorySelectIsbody ? 11837316 : 9993045) : 9541120);
            Item obj = !inventorySelectIsbody ? arrItemBag[inventorySelectBag] : arrItemBody[inventorySelectBody];
            if (obj != null)
            {
              for (int index = 0; index < obj.itemOption.Length; ++index)
              {
                if (obj.itemOption[index].optionTemplate.id == 72 && obj.itemOption[index].param > 0)
                {
                  sbyte colorItemUpgrade = Panel.GetColor_Item_Upgrade(obj.itemOption[index].param);
                  if (Panel.GetColor_ItemBg((int) colorItemUpgrade) != -1)
                    g.setColor(select != this.selected ? Panel.GetColor_ItemBg((int) colorItemUpgrade) : Panel.GetColor_ItemBg((int) colorItemUpgrade));
                }
              }
            }
            g.fillRect(xScroll, y2, w2, h2);
            if (obj != null && obj.isSelect && GameCanvas.panel.type == 12)
            {
              g.setColor(select != this.selected ? 6047789 : 7040779);
              g.fillRect(xScroll, y2, w2, h2);
            }
            if (obj != null)
            {
              string str = string.Empty;
              mFont mFont1 = mFont.tahoma_7_green2;
              if (obj.itemOption != null)
              {
                for (int index = 0; index < obj.itemOption.Length; ++index)
                {
                  if (obj.itemOption[index].optionTemplate.id == 72)
                    str = " [+" + (object) obj.itemOption[index].param + "]";
                  if (obj.itemOption[index].optionTemplate.id == 41)
                  {
                    if (obj.itemOption[index].param == 1)
                      mFont1 = Panel.GetFont(0);
                    else if (obj.itemOption[index].param == 2)
                      mFont1 = Panel.GetFont(2);
                    else if (obj.itemOption[index].param == 3)
                      mFont1 = Panel.GetFont(8);
                    else if (obj.itemOption[index].param == 4)
                      mFont1 = Panel.GetFont(7);
                  }
                }
              }
              mFont1.drawString(g, obj.template.name + str, x + 5, y1 + 1, 0);
              string st = string.Empty;
              if (obj.itemOption != null)
              {
                if (obj.itemOption.Length > 0 && obj.itemOption[0] != null && obj.itemOption[0].optionTemplate.id != 102 && obj.itemOption[0].optionTemplate.id != 107)
                  st += obj.itemOption[0].getOptionString();
                mFont mFont2 = mFont.tahoma_7_blue;
                if (obj.compare < 0 && obj.template.type != (sbyte) 5)
                  mFont2 = mFont.tahoma_7_red;
                if (obj.itemOption.Length > 1)
                {
                  for (int index = 1; index < 2; ++index)
                  {
                    if (obj.itemOption[index] != null && obj.itemOption[index].optionTemplate.id != 102 && obj.itemOption[index].optionTemplate.id != 107)
                      st = st + "," + obj.itemOption[index].getOptionString();
                  }
                }
                mFont2.drawString(g, st, x + 5, y1 + 11, mFont.LEFT);
              }
              SmallImage.drawSmallImage(g, (int) obj.template.iconID, xScroll + w2 / 2, y2 + h2 / 2, 0, 3);
              if (obj.itemOption != null)
              {
                for (int index = 0; index < obj.itemOption.Length; ++index)
                  this.paintOptItem(g, obj.itemOption[index].optionTemplate.id, obj.itemOption[index].param, xScroll, y2, w2, h2);
                for (int index = 0; index < obj.itemOption.Length; ++index)
                  this.paintOptSlotItem(g, obj.itemOption[index].optionTemplate.id, obj.itemOption[index].param, xScroll, y2, w2, h2);
              }
              if (obj.quantity > 1)
                mFont.tahoma_7_yellow.drawString(g, string.Empty + (object) obj.quantity, xScroll + w2, y2 + h2 - mFont.tahoma_7_yellow.getHeight(), 1);
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
    this.paintScrollArrow(g);
  }

  private void paintTab(mGraphics g)
  {
    if (this.type == 23 || this.type == 24)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.gameInfo, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 20)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.account, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 22)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.autoFunction, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 19)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.option, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 18)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.change_flag, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 13 && this.Equals((object) GameCanvas.panel2))
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.item_receive2, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 12 && GameCanvas.panel2 != null)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.UPGRADE, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 11)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.friend, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 16)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.enemy, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 15)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, this.topName, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 2 && GameCanvas.panel2 != null)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.chest, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 9)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.achievement_mission, this.xScroll + this.wScroll / 2, 59, mFont.CENTER);
    }
    else if (this.type == 3)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.select_zone, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
    }
    else if (this.type == 14)
    {
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
      mFont.tahoma_7b_dark.drawString(g, mResources.select_map, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
    }
    else if (this.type == 4)
    {
      mFont.tahoma_7b_dark.drawString(g, mResources.map, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
    }
    else if (this.type == 7)
    {
      mFont.tahoma_7b_dark.drawString(g, mResources.trangbi, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
    }
    else if (this.type == 17)
    {
      mFont.tahoma_7b_dark.drawString(g, mResources.kigui, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
    }
    else if (this.type == 8)
    {
      mFont.tahoma_7b_dark.drawString(g, mResources.msg, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
    }
    else if (this.type == 10)
    {
      mFont.tahoma_7b_dark.drawString(g, mResources.wat_do_u_want, this.startTabPos + this.TAB_W / 2, 59, mFont.CENTER);
      g.setColor(13524492);
      g.fillRect(this.X + 1, 78, this.W - 2, 1);
    }
    else
    {
      if (this.currentTabIndex == 3 && this.mainTabName.Length != 4)
        g.translate(-this.cmx, 0);
      for (int index = 0; index < this.currentTabName.Length; ++index)
      {
        g.setColor(index != this.currentTabIndex ? 16773296 : 6805896);
        PopUp.paintPopUp(g, this.startTabPos + index * this.TAB_W, 52, this.TAB_W - 1, 25, index != this.currentTabIndex ? 0 : 1, true);
        if (index == this.keyTouchTab)
          g.drawImage(ItemMap.imageFlare, this.startTabPos + index * this.TAB_W + this.TAB_W / 2, 62, 3);
        mFont mFont = index != this.currentTabIndex ? mFont.tahoma_7_grey : mFont.tahoma_7_green2;
        if (!this.currentTabName[index][1].Equals(string.Empty))
        {
          mFont.drawString(g, this.currentTabName[index][0], this.startTabPos + index * this.TAB_W + this.TAB_W / 2, 53, mFont.CENTER);
          mFont.drawString(g, this.currentTabName[index][1], this.startTabPos + index * this.TAB_W + this.TAB_W / 2, 64, mFont.CENTER);
        }
        else
          mFont.drawString(g, this.currentTabName[index][0], this.startTabPos + index * this.TAB_W + this.TAB_W / 2, 59, mFont.CENTER);
        if (this.type == 0 && this.currentTabName.Length == 5 && GameScr.isNewClanMessage && GameCanvas.gameTick % 4 == 0)
          g.drawImage(ItemMap.imageFlare, this.startTabPos + 3 * this.TAB_W + this.TAB_W / 2, 77, mGraphics.BOTTOM | mGraphics.HCENTER);
      }
      g.setColor(13524492);
      g.fillRect(1, 78, this.W - 2, 1);
    }
  }

  private void paintBottomMoneyInfo(mGraphics g)
  {
    if (this.type == 13 && (this.currentTabIndex == 2 || this.Equals((object) GameCanvas.panel2)))
      return;
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    g.setColor(11837316);
    g.fillRect(this.X + 1, this.H - 15, this.W - 2, 14);
    g.setColor(13524492);
    g.fillRect(this.X + 1, this.H - 15, this.W - 2, 1);
    g.drawImage(Panel.imgXu, this.X + 11, this.H - 7, 3);
    g.drawImage(Panel.imgLuong, this.X + 75, this.H - 8, 3);
    mFont.tahoma_7_yellow.drawString(g, Char.myCharz().xuStr + string.Empty, this.X + 24, this.H - 13, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, Char.myCharz().luongStr + string.Empty, this.X + 85, this.H - 13, mFont.LEFT, mFont.tahoma_7_grey);
    g.drawImage(Panel.imgLuongKhoa, this.X + 130, this.H - 8, 3);
    mFont.tahoma_7_yellow.drawString(g, Char.myCharz().luongKhoaStr + string.Empty, this.X + 140, this.H - 13, mFont.LEFT, mFont.tahoma_7_grey);
  }

  private void paintClanInfo(mGraphics g)
  {
    if (Char.myCharz().clan == null)
    {
      SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), 25, 50, 0, 33);
      mFont.tahoma_7b_white.drawString(g, mResources.not_join_clan, (this.wScroll - 50) / 2 + 50, 20, mFont.CENTER);
    }
    else if (!this.isViewMember)
    {
      Clan clan = Char.myCharz().clan;
      if (clan == null)
        return;
      SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), 25, 50, 0, 33);
      mFont.tahoma_7b_white.drawString(g, clan.name, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
      mFont.tahoma_7_yellow.drawString(g, mResources.achievement_point + ": " + clan.powerPoint, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
      mFont.tahoma_7_yellow.drawString(g, mResources.clan_point + ": " + (object) clan.clanPoint, 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
      mFont.tahoma_7_yellow.drawString(g, mResources.level + ": " + (object) clan.level, 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
      TextInfo.paint(g, clan.slogan, 60, 38, this.wScroll - 70, this.ITEM_HEIGHT, mFont.tahoma_7_yellow);
    }
    else
    {
      Clan clan = this.currClan == null ? Char.myCharz().clan : this.currClan;
      SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), 25, 51, 0, 33);
      mFont.tahoma_7b_white.drawString(g, clan.name, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
      mFont.tahoma_7_yellow.drawString(g, mResources.member + ": " + (object) clan.currMember + "/" + (object) clan.maxMember, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
      mFont.tahoma_7_yellow.drawString(g, mResources.clan_leader + ": " + clan.leaderName, 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
      TextInfo.paint(g, clan.slogan, 60, 38, this.wScroll - 70, this.ITEM_HEIGHT, mFont.tahoma_7_yellow);
    }
  }

  private void paintToolInfo(mGraphics g)
  {
    mFont.tahoma_7b_white.drawString(g, mResources.dragon_ball + " " + GameMidlet.VERSION, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
    mFont.tahoma_7_yellow.drawString(g, mResources.character + ": " + Char.myCharz().cName, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.account_server + " " + ServerListScreen.nameServer[ServerListScreen.ipSelect] + ":", 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, !GameCanvas.loginScr.tfUser.getText().Equals(string.Empty) ? GameCanvas.loginScr.tfUser.getText() : mResources.not_register_yet, 60, 39, mFont.LEFT, mFont.tahoma_7_grey);
  }

  private void paintGiaoDichInfo(mGraphics g)
  {
    mFont.tahoma_7_yellow.drawString(g, mResources.select_item, 60, 4, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.lock_trade, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.wait_opp_lock_trade, 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.press_done, 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
  }

  private void paintMyInfo(mGraphics g) => this.paintCharInfo(g, Char.myCharz());

  private void paintPetInfo(mGraphics g)
  {
    mFont.tahoma_7_yellow.drawString(g, mResources.power + ": " + NinjaUtil.getMoneys(Char.myPetz().cPower), this.X + 60, 4, mFont.LEFT, mFont.tahoma_7_grey);
    if (Char.myPetz().cPower > 0L)
      mFont.tahoma_7_yellow.drawString(g, !Char.myPetz().me ? Char.myPetz().currStrLevel : Char.myPetz().getStrLevel(), this.X + 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
    if (Char.myPetz().cDamFull > 0)
      mFont.tahoma_7_yellow.drawString(g, mResources.hit_point + " :" + (object) Char.myPetz().cDamFull, this.X + 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
    if (Char.myPetz().cMaxStamina > (short) 0)
    {
      mFont.tahoma_7_yellow.drawString(g, mResources.vitality, this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
      g.drawImage(GameScr.imgMPLost, this.X + 100, 41, 0);
      int w = Char.myPetz().cStamina * mGraphics.getImageWidth(GameScr.imgMP) / (int) Char.myPetz().cMaxStamina;
      g.setClip(100, this.X + 41, w, 20);
      g.drawImage(GameScr.imgMP, this.X + 100, 41, 0);
    }
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
  }

  private void paintCharInfo(mGraphics g, Char c)
  {
    mFont.tahoma_7b_white.drawString(g, (GameScr.isNewMember == (sbyte) 1 ? "       " : string.Empty) + c.cName, this.X + 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
    if (GameScr.isNewMember == (sbyte) 1)
      SmallImage.drawSmallImage(g, 5427, this.X + 55, 4, 0, 0);
    if (c.cMaxStamina > (short) 0)
    {
      mFont.tahoma_7_yellow.drawString(g, mResources.vitality, this.X + 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
      g.drawImage(GameScr.imgMPLost, this.X + 95, 19, 0);
      int w = c.cStamina * mGraphics.getImageWidth(GameScr.imgMP) / (int) c.cMaxStamina;
      g.setClip(95, this.X + 19, w, 20);
      g.drawImage(GameScr.imgMP, this.X + 95, 19, 0);
    }
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    if (c.cPower > 0L)
      mFont.tahoma_7_yellow.drawString(g, !c.me ? c.currStrLevel : c.getStrLevel(), this.X + 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.power + ": " + NinjaUtil.getMoneys(c.cPower), this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
  }

  private void paintZoneInfo(mGraphics g)
  {
    mFont.tahoma_7b_white.drawString(g, mResources.zone + " " + (object) TileMap.zoneID, 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
    mFont.tahoma_7_yellow.drawString(g, TileMap.mapName, 60, 16, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7b_white.drawString(g, TileMap.zoneID.ToString() + string.Empty, 25, 27, mFont.CENTER);
  }

  public int getCompare(Item item)
  {
    if (item == null)
      return -1;
    if (!item.isTypeBody())
      return 0;
    if (item.itemOption == null)
      return -1;
    ItemOption itemOption = item.itemOption[0];
    if (itemOption.optionTemplate.id == 22)
    {
      itemOption.optionTemplate = GameScr.gI().iOptionTemplates[6];
      itemOption.param *= 1000;
    }
    if (itemOption.optionTemplate.id == 23)
    {
      itemOption.optionTemplate = GameScr.gI().iOptionTemplates[7];
      itemOption.param *= 1000;
    }
    Item obj1 = (Item) null;
    for (int index = 0; index < Char.myCharz().arrItemBody.Length; ++index)
    {
      Item obj2 = Char.myCharz().arrItemBody[index];
      if (itemOption.optionTemplate.id == 22)
      {
        itemOption.optionTemplate = GameScr.gI().iOptionTemplates[6];
        itemOption.param *= 1000;
      }
      if (itemOption.optionTemplate.id == 23)
      {
        itemOption.optionTemplate = GameScr.gI().iOptionTemplates[7];
        itemOption.param *= 1000;
      }
      if (obj2 != null && obj2.itemOption != null && (int) obj2.template.type == (int) item.template.type)
      {
        obj1 = obj2;
        break;
      }
    }
    if (obj1 == null)
    {
      Res.outz("5");
      this.isUp = true;
      return itemOption.param;
    }
    int compare = obj1 == null || obj1.itemOption == null ? itemOption.param : itemOption.param - obj1.itemOption[0].param;
    this.isUp = compare >= 0;
    return compare;
  }

  private void paintMapInfo(mGraphics g)
  {
    mFont.tahoma_7b_white.drawString(g, mResources.MENUGENDER[(int) TileMap.planetID], 60, 4, mFont.LEFT);
    string str = string.Empty;
    if (TileMap.mapID >= 135 && TileMap.mapID <= 138)
      str = " " + mResources.tang + (object) TileMap.zoneID;
    mFont.tahoma_7_yellow.drawString(g, TileMap.mapName + str, 60, 16, mFont.LEFT);
    mFont.tahoma_7b_white.drawString(g, mResources.quest_place + ": ", 60, 27, mFont.LEFT);
    if (GameScr.getTaskMapId() >= 0 && GameScr.getTaskMapId() <= TileMap.mapNames.Length - 1)
      mFont.tahoma_7_yellow.drawString(g, TileMap.mapNames[GameScr.getTaskMapId()], 60, 38, mFont.LEFT);
    else
      mFont.tahoma_7_yellow.drawString(g, mResources.random, 60, 38, mFont.LEFT);
  }

  private void paintShopInfo(mGraphics g)
  {
    if (this.currentTabIndex == this.currentTabName.Length - 1 && GameCanvas.panel2 == null)
      this.paintMyInfo(g);
    else if (this.selected < 0)
    {
      if (this.typeShop != 2)
      {
        mFont.tahoma_7_white.drawString(g, mResources.say_hello, this.X + 60, 14, 0);
        mFont.tahoma_7_white.drawString(g, Panel.strWantToBuy, this.X + 60, 26, 0);
      }
      else
      {
        mFont.tahoma_7_white.drawString(g, mResources.say_hello, this.X + 60, 5, 0);
        mFont.tahoma_7_white.drawString(g, Panel.strWantToBuy, this.X + 60, 17, 0);
        mFont.tahoma_7_white.drawString(g, mResources.page + " " + (object) (this.currPageShop[this.currentTabIndex] + 1) + "/" + (object) this.maxPageShop[this.currentTabIndex], this.X + 60, 29, 0);
      }
    }
    else
    {
      if (this.currentTabIndex < 0 || this.currentTabIndex > Char.myCharz().arrItemShop.Length - 1 || this.selected < 0 || this.selected > Char.myCharz().arrItemShop[this.currentTabIndex].Length - 1)
        return;
      Item obj = Char.myCharz().arrItemShop[this.currentTabIndex][this.selected];
      if (obj == null)
        return;
      if (this.Equals((object) GameCanvas.panel) && this.currentTabIndex <= 3 && this.typeShop == 2)
        mFont.tahoma_7b_white.drawString(g, mResources.page + " " + (object) (this.currPageShop[this.currentTabIndex] + 1) + "/" + (object) this.maxPageShop[this.currentTabIndex], this.X + 55, 4, 0);
      mFont.tahoma_7b_white.drawString(g, obj.template.name, this.X + 55, 24, 0);
      string st = mResources.pow_request + " " + Res.formatNumber((long) obj.template.strRequire);
      if ((long) obj.template.strRequire > Char.myCharz().cPower)
        mFont.tahoma_7_yellow.drawString(g, st, this.X + 55, 35, 0);
      else
        mFont.tahoma_7_green.drawString(g, st, this.X + 55, 35, 0);
    }
  }

  private void paintItemBoxInfo(mGraphics g)
  {
    string st = mResources.used + ": " + (object) this.hasUse + "/" + (object) Char.myCharz().arrItemBox.Length + " " + mResources.place;
    mFont.tahoma_7b_white.drawString(g, mResources.chest, 60, 4, 0);
    mFont.tahoma_7_yellow.drawString(g, st, 60, 16, 0);
  }

  private void paintSkillInfo(mGraphics g)
  {
    mFont.tahoma_7_white.drawString(g, "Top " + (object) Char.myCharz().rank, this.X + 45 + (this.W - 50) / 2, 2, mFont.CENTER);
    mFont.tahoma_7_yellow.drawString(g, mResources.potential_point, this.X + 45 + (this.W - 50) / 2, 14, mFont.CENTER);
    mFont.tahoma_7_white.drawString(g, string.Empty + NinjaUtil.getMoneys(Char.myCharz().cTiemNang), this.X + (GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2) + 45 + (this.W - 50) / 2, 26, mFont.CENTER);
    mFont.tahoma_7_yellow.drawString(g, mResources.active_point + ": " + NinjaUtil.getMoneys(Char.myCharz().cNangdong), this.X + (GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2) + 45 + (this.W - 50) / 2, 38, mFont.CENTER);
  }

  private void paintItemBodyBagInfo(mGraphics g)
  {
    mFont.tahoma_7_yellow.drawString(g, mResources.HP + ": " + (object) Char.myCharz().cHP + " / " + (object) Char.myCharz().cHPFull, this.X + 60, 2, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.KI + ": " + (object) Char.myCharz().cMP + " / " + (object) Char.myCharz().cMPFull, this.X + 60, 14, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.hit_point + ": " + (object) Char.myCharz().cDamFull, this.X + 60, 26, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.armor + ": " + (object) Char.myCharz().cDefull + ", " + mResources.critical + ": " + (object) Char.myCharz().cCriticalFull + "%", this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
  }

  private void paintTopInfo(mGraphics g)
  {
    g.setClip(this.X + 1, this.Y, this.W - 2, this.yScroll - 2);
    g.setColor(9993045);
    g.fillRect(this.X, this.Y, this.W - 2, 50);
    switch (this.type)
    {
      case 0:
        if (this.currentTabIndex == 0)
        {
          SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
          this.paintMyInfo(g);
        }
        if (this.currentTabIndex == 1)
        {
          SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
          this.paintItemBodyBagInfo(g);
        }
        if (this.currentTabIndex == 2)
        {
          SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
          this.paintSkillInfo(g);
        }
        if (this.currentTabIndex == 3)
        {
          if (this.mainTabName.Length == 5)
          {
            this.paintClanInfo(g);
          }
          else
          {
            SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
            this.paintToolInfo(g);
          }
        }
        if (this.currentTabIndex != 4)
          break;
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintToolInfo(g);
        break;
      case 1:
        if (this.currentTabIndex == this.currentTabName.Length - 1 && GameCanvas.panel2 == null)
          SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        else
          SmallImage.drawSmallImage(g, Char.myCharz().npcFocus.avatar, this.X + 25, 50, 0, 33);
        this.paintShopInfo(g);
        break;
      case 2:
        if (this.currentTabIndex == 0)
        {
          SmallImage.drawSmallImage(g, 526, this.X + 25, 50, 0, 33);
          this.paintItemBoxInfo(g);
        }
        if (this.currentTabIndex != 1)
          break;
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintItemBodyBagInfo(g);
        break;
      case 3:
        SmallImage.drawSmallImage(g, 561, this.X + 25, 50, 0, 33);
        this.paintZoneInfo(g);
        break;
      case 4:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMapInfo(g);
        break;
      case 7:
      case 17:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
      case 8:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
      case 9:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
      case 10:
        if (this.charMenu == null)
          break;
        SmallImage.drawSmallImage(g, this.charMenu.avatarz(), this.X + 25, 50, 0, 33);
        this.paintCharInfo(g, this.charMenu);
        break;
      case 11:
      case 16:
      case 23:
      case 24:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
      case 12:
        if (this.currentTabIndex == 0)
        {
          int id = 1410;
          for (int index = 0; index < GameScr.vNpc.size(); ++index)
          {
            Npc npc = (Npc) GameScr.vNpc.elementAt(index);
            if (npc.template.npcTemplateId == this.idNPC)
              id = npc.avatar;
          }
          SmallImage.drawSmallImage(g, id, this.X + 25, 50, 0, 33);
          this.paintCombineInfo(g);
        }
        if (this.currentTabIndex != 1)
          break;
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
      case 13:
        if (this.currentTabIndex == 0 || this.currentTabIndex == 1)
        {
          if (this.Equals((object) GameCanvas.panel))
          {
            SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
            this.paintGiaoDichInfo(g);
          }
          if (this.Equals((object) GameCanvas.panel2) && this.charMenu != null)
          {
            SmallImage.drawSmallImage(g, this.charMenu.avatarz(), this.X + 25, 50, 0, 33);
            this.paintCharInfo(g, this.charMenu);
          }
        }
        if (this.currentTabIndex != 2 || this.charMenu == null)
          break;
        SmallImage.drawSmallImage(g, this.charMenu.avatarz(), this.X + 25, 50, 0, 33);
        this.paintCharInfo(g, this.charMenu);
        break;
      case 14:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMapInfo(g);
        break;
      case 15:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
      case 18:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
      case 19:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintToolInfo(g);
        break;
      case 20:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintToolInfo(g);
        break;
      case 21:
        if (this.currentTabIndex == 0)
        {
          SmallImage.drawSmallImage(g, Char.myPetz().avatarz(), this.X + 25, 50, 0, 33);
          this.paintPetInfo(g);
        }
        if (this.currentTabIndex == 1)
        {
          SmallImage.drawSmallImage(g, Char.myPetz().avatarz(), this.X + 25, 50, 0, 33);
          this.paintPetStatusInfo(g);
        }
        if (this.currentTabIndex != 2)
          break;
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintItemBodyBagInfo(g);
        break;
      case 22:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintToolInfo(g);
        break;
      case 25:
        SmallImage.drawSmallImage(g, Char.myCharz().avatarz(), this.X + 25, 50, 0, 33);
        this.paintMyInfo(g);
        break;
    }
  }

  private string getStatus(int status)
  {
    switch (status)
    {
      case 0:
        return mResources.follow;
      case 1:
        return mResources.defend;
      case 2:
        return mResources.attack;
      case 3:
        return mResources.gohome;
      default:
        return "aaa";
    }
  }

  private void paintPetStatusInfo(mGraphics g)
  {
    mFont.tahoma_7b_white.drawString(g, "HP: " + (object) Char.myPetz().cHP + "/" + (object) Char.myPetz().cHPFull, this.X + 60, 4, mFont.LEFT, mFont.tahoma_7b_dark);
    mFont.tahoma_7b_white.drawString(g, "MP: " + (object) Char.myPetz().cMP + "/" + (object) Char.myPetz().cMPFull, this.X + 60, 16, mFont.LEFT, mFont.tahoma_7b_dark);
    mFont.tahoma_7_yellow.drawString(g, mResources.critical + ": " + (object) Char.myPetz().cCriticalFull + "   " + mResources.armor + ": " + (object) Char.myPetz().cDefull, this.X + 60, 27, mFont.LEFT, mFont.tahoma_7_grey);
    mFont.tahoma_7_yellow.drawString(g, mResources.status + " :" + this.strStatus[(int) Char.myPetz().petStatus], this.X + 60, 38, mFont.LEFT, mFont.tahoma_7_grey);
  }

  private void paintCombineInfo(mGraphics g)
  {
    if (this.combineTopInfo == null)
      return;
    for (int index = 0; index < this.combineTopInfo.Length; ++index)
      mFont.tahoma_7_white.drawString(g, this.combineTopInfo[index], this.X + 45 + (this.W - 50) / 2, 5 + index * 14, mFont.CENTER);
  }

  private void paintInfomation(mGraphics g)
  {
  }

  public void paintMap(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(-this.cmxMap, -this.cmyMap);
    g.drawImage(Panel.imgMap, this.xScroll, this.yScroll, 0);
    int head = Char.myCharz().head;
    Part part = GameScr.parts[head];
    SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, this.xMap, this.yMap + 5, 0, 3);
    int align1 = mFont.CENTER;
    if (this.xMap <= 40)
      align1 = mFont.LEFT;
    if (this.xMap >= 220)
      align1 = mFont.RIGHT;
    mFont.tahoma_7b_yellow.drawString(g, TileMap.mapName, this.xMap, this.yMap - 12, align1, mFont.tahoma_7_grey);
    int index1 = -1;
    if (GameScr.getTaskMapId() != -1)
    {
      for (int index2 = 0; index2 < Panel.mapId[(int) TileMap.planetID].Length; ++index2)
      {
        if (Panel.mapId[(int) TileMap.planetID][index2] == GameScr.getTaskMapId())
        {
          index1 = index2;
          break;
        }
        index1 = 4;
      }
      if (GameCanvas.gameTick % 4 > 0)
        g.drawImage(ItemMap.imageFlare, this.xScroll + Panel.mapX[(int) TileMap.planetID][index1], this.yScroll + Panel.mapY[(int) TileMap.planetID][index1], 3);
    }
    if (!GameCanvas.isTouch)
    {
      g.drawImage(Panel.imgBantay, this.xMove, this.yMove, StaticObj.TOP_RIGHT);
      for (int index3 = 0; index3 < Panel.mapX[(int) TileMap.planetID].Length; ++index3)
      {
        int x = Panel.mapX[(int) TileMap.planetID][index3] + this.xScroll;
        int num = Panel.mapY[(int) TileMap.planetID][index3] + this.yScroll;
        if (Res.inRect(x - 15, num - 15, 30, 30, this.xMove, this.yMove))
        {
          int align2 = mFont.CENTER;
          if (x <= 20)
            align2 = mFont.LEFT;
          if (x >= 220)
            align2 = mFont.RIGHT;
          mFont.tahoma_7b_yellow.drawString(g, TileMap.mapNames[Panel.mapId[(int) TileMap.planetID][index3]], x, num - 12, align2, mFont.tahoma_7_grey);
          break;
        }
      }
    }
    else if (!this.trans)
    {
      for (int index4 = 0; index4 < Panel.mapX[(int) TileMap.planetID].Length; ++index4)
      {
        int x = Panel.mapX[(int) TileMap.planetID][index4] + this.xScroll;
        int y = Panel.mapY[(int) TileMap.planetID][index4] + this.yScroll;
        if (Res.inRect(x - 15, y - 15, 30, 30, this.pX, this.pY))
        {
          int align3 = mFont.CENTER;
          if (x <= 30)
            align3 = mFont.LEFT;
          if (x >= 220)
            align3 = mFont.RIGHT;
          g.drawImage(Panel.imgBantay, x, y, StaticObj.TOP_RIGHT);
          mFont.tahoma_7b_yellow.drawString(g, TileMap.mapNames[Panel.mapId[(int) TileMap.planetID][index4]], x, y - 12, align3, mFont.tahoma_7_grey);
          break;
        }
      }
    }
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    if (index1 == -1)
      return;
    if (Panel.mapX[(int) TileMap.planetID][index1] + this.xScroll < this.cmxMap)
      g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 5, this.xScroll + 5, this.yScroll + this.hScroll / 2 - 4, 0);
    if (this.cmxMap + this.wScroll < Panel.mapX[(int) TileMap.planetID][index1] + this.xScroll)
      g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 6, this.xScroll + this.wScroll - 5, this.yScroll + this.hScroll / 2 - 4, StaticObj.TOP_RIGHT);
    if (Panel.mapY[(int) TileMap.planetID][index1] < this.cmyMap)
      g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 1, this.xScroll + this.wScroll / 2, this.yScroll + 5, StaticObj.TOP_CENTER);
    if (Panel.mapY[(int) TileMap.planetID][index1] <= this.cmyMap + this.hScroll)
      return;
    g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - 5, StaticObj.BOTTOM_HCENTER);
  }

  public void paintTask(mGraphics g)
  {
    int num = GameCanvas.h <= 300 ? 15 : 20;
    if (Panel.isPaintMap && !GameScr.gI().isMapDocNhan() && !GameScr.gI().isMapFize())
    {
      g.drawImage(this.keyTouchMapButton != 1 ? GameScr.imgLbtn : GameScr.imgLbtnFocus, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - num, 3);
      mFont.tahoma_7b_dark.drawString(g, mResources.map, this.xScroll + this.wScroll / 2, this.yScroll + this.hScroll - (num + 5), mFont.CENTER);
    }
    this.xstart = this.xScroll + 5;
    this.ystart = this.yScroll + 14;
    this.yPaint = this.ystart;
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll - 35);
    if (this.scroll != null)
    {
      if (this.scroll.cmy > 0)
        g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 1, this.xScroll + this.wScroll - 12, this.yScroll + 3, 0);
      if (this.scroll.cmy < this.scroll.cmyLim)
        g.drawRegion(Mob.imgHP, 0, 0, 9, 6, 0, this.xScroll + this.wScroll - 12, this.yScroll + this.hScroll - 45, 0);
      g.translate(0, -this.scroll.cmy);
    }
    this.indexRowMax = 0;
    if (this.indexMenu == 0)
    {
      bool flag = false;
      if (Char.myCharz().taskMaint != null)
      {
        for (int index = 0; index < Char.myCharz().taskMaint.names.Length; ++index)
        {
          mFont.tahoma_7_grey.drawString(g, Char.myCharz().taskMaint.names[index], this.xScroll + this.wScroll / 2, this.yPaint - 5 + index * 12, mFont.CENTER);
          ++this.indexRowMax;
        }
        this.yPaint += (Char.myCharz().taskMaint.names.Length - 1) * 12;
        int index1 = 0;
        string empty = string.Empty;
        for (int index2 = 0; index2 < Char.myCharz().taskMaint.subNames.Length; ++index2)
        {
          if (Char.myCharz().taskMaint.subNames[index2] != null)
          {
            index1 = index2;
            string st = "- " + Char.myCharz().taskMaint.subNames[index2];
            if (Char.myCharz().taskMaint.counts[index2] != (short) -1)
            {
              if (Char.myCharz().taskMaint.index == index2)
              {
                if (Char.myCharz().taskMaint.counts[index2] != (short) 1)
                  st = st + " (" + (object) Char.myCharz().taskMaint.count + "/" + (object) Char.myCharz().taskMaint.counts[index2] + ")";
                if ((int) Char.myCharz().taskMaint.count == (int) Char.myCharz().taskMaint.counts[index2])
                {
                  mFont.tahoma_7.drawString(g, st, this.xstart + 5, this.yPaint += 12, 0);
                }
                else
                {
                  mFont tahoma7Grey = mFont.tahoma_7_grey;
                  if (!flag)
                  {
                    flag = true;
                    mFont tahoma7Blue = mFont.tahoma_7_blue;
                    tahoma7Blue.drawString(g, st, this.xstart + 5 + (tahoma7Blue != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), this.yPaint += 12, 0);
                  }
                  else
                    tahoma7Grey.drawString(g, "- ...", this.xstart + 5 + (tahoma7Grey != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), this.yPaint += 12, 0);
                }
              }
              else if (Char.myCharz().taskMaint.index > index2)
              {
                if (Char.myCharz().taskMaint.counts[index2] != (short) 1)
                  st = st + " (" + (object) Char.myCharz().taskMaint.counts[index2] + "/" + (object) Char.myCharz().taskMaint.counts[index2] + ")";
                mFont.tahoma_7_white.drawString(g, st, this.xstart + 5, this.yPaint += 12, 0);
              }
              else
              {
                if (Char.myCharz().taskMaint.counts[index2] != (short) 1)
                  st = st + " 0/" + (object) Char.myCharz().taskMaint.counts[index2];
                mFont tahoma7Grey = mFont.tahoma_7_grey;
                if (!flag)
                {
                  flag = true;
                  mFont tahoma7Blue = mFont.tahoma_7_blue;
                  tahoma7Blue.drawString(g, st, this.xstart + 5 + (tahoma7Blue != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), this.yPaint += 12, 0);
                }
                else
                  tahoma7Grey.drawString(g, "- ...", this.xstart + 5 + (tahoma7Grey != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), this.yPaint += 12, 0);
              }
            }
            else if (Char.myCharz().taskMaint.index > index2)
            {
              mFont.tahoma_7_white.drawString(g, st, this.xstart + 5, this.yPaint += 12, 0);
            }
            else
            {
              mFont tahoma7Grey = mFont.tahoma_7_grey;
              if (!flag)
              {
                flag = true;
                mFont tahoma7Blue = mFont.tahoma_7_blue;
                tahoma7Blue.drawString(g, st, this.xstart + 5 + (tahoma7Blue != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), this.yPaint += 12, 0);
              }
              else
                tahoma7Grey.drawString(g, "- ...", this.xstart + 5 + (tahoma7Grey != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), this.yPaint += 12, 0);
            }
            ++this.indexRowMax;
          }
          else if (Char.myCharz().taskMaint.index <= index2)
          {
            string st = "- " + Char.myCharz().taskMaint.subNames[index1];
            mFont mFont = mFont.tahoma_7_grey;
            if (!flag)
            {
              flag = true;
              mFont = mFont.tahoma_7_blue;
            }
            mFont.drawString(g, st, this.xstart + 5 + (mFont != mFont.tahoma_7_blue || GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), this.yPaint += 12, 0);
          }
        }
        this.yPaint += 5;
        for (int index3 = 0; index3 < Char.myCharz().taskMaint.details.Length; ++index3)
        {
          mFont.tahoma_7_green2.drawString(g, Char.myCharz().taskMaint.details[index3], this.xstart + 5, this.yPaint += 12, 0);
          ++this.indexRowMax;
        }
      }
      else
      {
        int taskMapId = GameScr.getTaskMapId();
        sbyte taskNpcId = GameScr.getTaskNpcId();
        string empty = string.Empty;
        string src;
        if (taskMapId == -3 || taskNpcId == (sbyte) -3)
          src = mResources.DES_TASK[3];
        else if (Char.myCharz().taskMaint == null && Char.myCharz().ctaskId == 9 && Char.myCharz().nClass.classId == 0)
        {
          src = mResources.TASK_INPUT_CLASS;
        }
        else
        {
          if (taskNpcId < (sbyte) 0 || taskMapId < 0)
            return;
          src = mResources.DES_TASK[0] + Npc.arrNpcTemplate[(int) taskNpcId].name + mResources.DES_TASK[1] + TileMap.mapNames[taskMapId] + mResources.DES_TASK[2];
        }
        string[] strArray = mFont.tahoma_7_white.splitFontArray(src, 150);
        for (int index = 0; index < strArray.Length; ++index)
        {
          if (index == 0)
            mFont.tahoma_7_white.drawString(g, strArray[index], this.xstart + 5, this.yPaint = this.ystart, 0);
          else
            mFont.tahoma_7_white.drawString(g, strArray[index], this.xstart + 5, this.yPaint += 12, 0);
        }
      }
    }
    else if (this.indexMenu == 1)
    {
      this.yPaint = this.ystart - 12;
      for (int index = 0; index < Char.myCharz().taskOrders.size(); ++index)
      {
        TaskOrder taskOrder = (TaskOrder) Char.myCharz().taskOrders.elementAt(index);
        mFont.tahoma_7_white.drawString(g, taskOrder.name, this.xstart + 5, this.yPaint += 12, 0);
        if (taskOrder.count == (int) taskOrder.maxCount)
          mFont.tahoma_7_white.drawString(g, (taskOrder.taskId != 0 ? (object) mResources.KILLBOSS : (object) mResources.KILL).ToString() + " " + Mob.arrMobTemplate[taskOrder.killId].name + " (" + (object) taskOrder.count + "/" + (object) taskOrder.maxCount + ")", this.xstart + 5, this.yPaint += 12, 0);
        else
          mFont.tahoma_7_blue.drawString(g, (taskOrder.taskId != 0 ? (object) mResources.KILLBOSS : (object) mResources.KILL).ToString() + " " + Mob.arrMobTemplate[taskOrder.killId].name + " (" + (object) taskOrder.count + "/" + (object) taskOrder.maxCount + ")", this.xstart + 5, this.yPaint += 12, 0);
        this.indexRowMax += 3;
        this.inforW = this.popupW - 25;
        this.paintMultiLine(g, mFont.tahoma_7_grey, taskOrder.description, this.xstart + 5, this.yPaint += 12, 0);
        this.yPaint += 12;
      }
    }
    if (this.scroll != null)
      return;
    this.scroll = new Scroll();
    this.scroll.setStyle(this.indexRowMax, 12, this.xScroll, this.yScroll, this.wScroll, this.hScroll - num - 40, true, 1);
  }

  public void paintMultiLine(
    mGraphics g,
    mFont f,
    string[] arr,
    string str,
    int x,
    int y,
    int align)
  {
    for (int index = 0; index < arr.Length; ++index)
    {
      string st = arr[index];
      if (st.StartsWith("c"))
      {
        if (st.StartsWith("c0"))
        {
          st = st.Substring(2);
          f = mFont.tahoma_7b_dark;
        }
        else if (st.StartsWith("c1"))
        {
          st = st.Substring(2);
          f = mFont.tahoma_7b_yellow;
        }
        else if (st.StartsWith("c2"))
        {
          st = st.Substring(2);
          f = mFont.tahoma_7b_green;
        }
      }
      if (index == 0)
      {
        f.drawString(g, st, x, y, align);
      }
      else
      {
        if (index < this.indexRow + 30 && index > this.indexRow - 30)
          f.drawString(g, st, x, y += 12, align);
        else
          y += 12;
        this.yPaint += 12;
        ++this.indexRowMax;
      }
    }
  }

  public void paintMultiLine(mGraphics g, mFont f, string str, int x, int y, int align)
  {
    int num = !GameCanvas.isTouch || GameCanvas.w < 320 ? 10 : 20;
    string[] strArray = f.splitFontArray(str, this.inforW - num);
    for (int index = 0; index < strArray.Length; ++index)
    {
      if (index == 0)
      {
        f.drawString(g, strArray[index], x, y, align);
      }
      else
      {
        if (index < this.indexRow + 15 && index > this.indexRow - 15)
          f.drawString(g, strArray[index], x, y += 12, align);
        else
          y += 12;
        this.yPaint += 12;
        ++this.indexRowMax;
      }
    }
  }

  public void cleanCombine()
  {
    for (int index = 0; index < this.vItemCombine.size(); ++index)
      ((Item) this.vItemCombine.elementAt(index)).isSelect = false;
    this.vItemCombine.removeAllElements();
  }

  public void hideNow()
  {
    if (this.timeShow > 0)
    {
      this.isClose = false;
    }
    else
    {
      if (this.isTypeShop())
        Char.myCharz().resetPartTemp();
      if (this.chatTField != null && this.type == 13 && this.chatTField.isShow)
        this.chatTField = (ChatTextField) null;
      if (this.type == 13 && !this.isAccept)
        Service.gI().giaodich((sbyte) 3, -1, (sbyte) -1, -1);
      Res.outz("HIDE PANELLLLLLLLLLLLLLLLLLLLLL");
      SoundMn.gI().buttonClose();
      GameScr.isPaint = true;
      TileMap.lastPlanetId = (sbyte) -1;
      Panel.imgMap = (Image) null;
      mSystem.gcc();
      this.isClanOption = false;
      this.isClose = true;
      this.cleanCombine();
      Hint.clickNpc();
      GameCanvas.panel2 = (Panel) null;
      GameCanvas.clearAllPointerEvent();
      GameCanvas.clearKeyPressed();
      this.pointerDownTime = this.pointerDownFirstX = 0;
      this.pointerIsDowning = false;
      this.isShow = false;
      if (Char.myCharz().cHP > 0 && Char.myCharz().statusMe != 14 && Char.myCharz().statusMe != 5 || !Char.myCharz().meDead)
        return;
      Command command = new Command(mResources.DIES[0], 11038, (object) GameScr.gI());
      GameScr.gI().center = command;
      Char.myCharz().cHP = 0;
    }
  }

  public void hide()
  {
    if (this.timeShow > 0)
    {
      this.isClose = false;
    }
    else
    {
      if (this.isTypeShop())
        Char.myCharz().resetPartTemp();
      if (this.chatTField != null && this.type == 13 && this.chatTField.isShow)
        this.chatTField = (ChatTextField) null;
      if (this.type == 13 && !this.isAccept)
        Service.gI().giaodich((sbyte) 3, -1, (sbyte) -1, -1);
      if (this.type == 15)
        Service.gI().sendThachDau(-1);
      SoundMn.gI().buttonClose();
      GameScr.isPaint = true;
      TileMap.lastPlanetId = (sbyte) -1;
      if (Panel.imgMap != null)
      {
        Panel.imgMap.texture = (Texture2D) null;
        Panel.imgMap = (Image) null;
      }
      mSystem.gcc();
      this.isClanOption = false;
      if (this.type != 4)
      {
        if (this.type == 24)
          this.setTypeGameInfo();
        else if (this.type == 23)
          this.setTypeMain();
        else if (this.type == 3 || this.type == 14)
        {
          if (this.isChangeZone)
          {
            this.isClose = true;
          }
          else
          {
            this.setTypeMain();
            this.cmx = this.cmtoX = 0;
          }
        }
        else if (this.type == 18 || this.type == 19 || this.type == 20 || this.type == 21)
        {
          this.setTypeMain();
          this.cmx = this.cmtoX = 0;
        }
        else if (this.type == 8 || this.type == 11 || this.type == 16)
        {
          this.setTypeAccount();
          this.cmx = this.cmtoX = 0;
        }
        else
          this.isClose = true;
      }
      else
      {
        this.setTypeMain();
        this.cmx = this.cmtoX = 0;
      }
      Hint.clickNpc();
      GameCanvas.panel2 = (Panel) null;
      GameCanvas.clearAllPointerEvent();
      GameCanvas.clearKeyPressed();
      GameCanvas.isFocusPanel2 = false;
      this.pointerDownTime = this.pointerDownFirstX = 0;
      this.pointerIsDowning = false;
      if (Char.myCharz().cHP > 0 && Char.myCharz().statusMe != 14 && Char.myCharz().statusMe != 5 || !Char.myCharz().meDead)
        return;
      Command command = new Command(mResources.DIES[0], 11038, (object) GameScr.gI());
      GameScr.gI().center = command;
      Char.myCharz().cHP = 0;
    }
  }

  public void update()
  {
    if (this.chatTField != null && this.chatTField.isShow)
      this.chatTField.update();
    else if (this.isKiguiXu)
    {
      ++this.delayKigui;
      if (this.delayKigui != 10)
        return;
      this.delayKigui = 0;
      this.isKiguiXu = false;
      this.chatTField.tfChat.setText(string.Empty);
      this.chatTField.strChat = mResources.kiguiXuchat + " ";
      this.chatTField.tfChat.name = mResources.input_money;
      this.chatTField.to = string.Empty;
      this.chatTField.isShow = true;
      this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.chatTField.tfChat.setMaxTextLenght(9);
      if (GameCanvas.isTouch)
        this.chatTField.tfChat.doChangeToTextBox();
      if (Main.isWindowsPhone)
        this.chatTField.tfChat.strInfo = this.chatTField.strChat;
      if (Main.isPC)
        return;
      this.chatTField.startChat2((IChatable) this, string.Empty);
    }
    else if (this.isKiguiLuong)
    {
      ++this.delayKigui;
      if (this.delayKigui != 10)
        return;
      this.delayKigui = 0;
      this.isKiguiLuong = false;
      this.chatTField.tfChat.setText(string.Empty);
      this.chatTField.strChat = mResources.kiguiLuongchat + "  ";
      this.chatTField.tfChat.name = mResources.input_money;
      this.chatTField.to = string.Empty;
      this.chatTField.isShow = true;
      this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
      this.chatTField.tfChat.setMaxTextLenght(9);
      if (GameCanvas.isTouch)
        this.chatTField.tfChat.doChangeToTextBox();
      if (Main.isWindowsPhone)
        this.chatTField.tfChat.strInfo = this.chatTField.strChat;
      if (Main.isPC)
        return;
      this.chatTField.startChat2((IChatable) this, string.Empty);
    }
    else
    {
      if (this.scroll != null)
        this.scroll.updatecm();
      if (this.tabIcon != null && this.tabIcon.isShow)
      {
        this.tabIcon.update();
      }
      else
      {
        this.moveCamera();
        if (this.waitToPerform > 0)
        {
          --this.waitToPerform;
          if (this.waitToPerform == 0)
          {
            this.lastSelect[this.currentTabIndex] = this.selected;
            switch (this.type)
            {
              case 0:
                this.doFireMain();
                break;
              case 1:
              case 17:
                this.doFireShop();
                break;
              case 2:
                this.doFireBox();
                break;
              case 3:
                this.doFireZone();
                break;
              case 4:
                this.doFireMap();
                break;
              case 7:
                if (this.Equals((object) GameCanvas.panel2) && GameCanvas.panel.type == 2)
                {
                  this.doFireBox();
                  return;
                }
                this.doFireInventory();
                break;
              case 8:
                this.doFireLogMessage();
                break;
              case 9:
                this.doFireArchivement();
                break;
              case 10:
                this.doFirePlayerMenu();
                break;
              case 11:
                this.doFireFriend();
                break;
              case 12:
                this.doFireCombine();
                break;
              case 13:
                this.doFireGiaoDich();
                break;
              case 14:
                this.doFireMapTrans();
                break;
              case 15:
                this.doFireTop();
                break;
              case 16:
                this.doFireEnemy();
                break;
              case 18:
                this.doFireChangeFlag();
                break;
              case 19:
                this.doFireOption();
                break;
              case 20:
                this.doFireAccount();
                break;
              case 21:
                this.doFirePetMain();
                break;
              case 22:
                this.doFireAuto();
                break;
              case 23:
                this.doFireGameInfo();
                break;
              case 25:
                this.doSpeacialSkill();
                break;
            }
          }
        }
        for (int index = 0; index < ClanMessage.vMessage.size(); ++index)
          ((ClanMessage) ClanMessage.vMessage.elementAt(index)).update();
        this.updateCombineEff();
      }
    }
  }

  private void doSpeacialSkill()
  {
  }

  private void doFireGameInfo()
  {
    if (this.selected == -1)
      return;
    this.infoSelect = this.selected;
    ((GameInfo) Panel.vGameInfo.elementAt(this.infoSelect)).hasRead = true;
    Rms.saveRMSInt(((GameInfo) Panel.vGameInfo.elementAt(this.infoSelect)).id.ToString() + string.Empty, 1);
    this.setTypeGameSubInfo();
  }

  private void doFireAuto()
  {
  }

  private void doFirePetMain()
  {
    if (this.currentTabIndex == 0)
    {
      if (this.selected == -1 || this.selected > Char.myPetz().arrItemBody.Length - 1)
        return;
      MyVector menuItems = new MyVector(string.Empty);
      this.currItem = Char.myPetz().arrItemBody[this.selected];
      if (this.currItem != null)
      {
        menuItems.addElement((object) new Command(mResources.MOVEOUT, (IActionListener) this, 2006, (object) this.currItem));
        GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
        this.addItemDetail(this.currItem);
      }
      else
        this.cp = (ChatPopup) null;
    }
    if (this.currentTabIndex == 1)
      this.doFirePetStatus();
    if (this.currentTabIndex != 2)
      return;
    this.doFireInventory();
  }

  private void doFirePetStatus()
  {
    if (this.selected == -1)
      return;
    if (this.selected == 5)
    {
      GameCanvas.startYesNoDlg(mResources.sure_fusion, new Command(mResources.YES, 888351), new Command(mResources.NO, 2001));
    }
    else
    {
      Service.gI().petStatus((sbyte) this.selected);
      if (this.selected >= 4)
        return;
      Char.myPetz().petStatus = (sbyte) this.selected;
    }
  }

  private void doFireTop()
  {
    if (this.selected < -1)
      return;
    if (this.isThachDau)
    {
      Service.gI().sendTop(this.topName, (sbyte) this.selected);
    }
    else
    {
      MyVector menuItems = new MyVector(string.Empty);
      menuItems.addElement((object) new Command(mResources.CHAR_ORDER[0], (IActionListener) this, 9999, (object) (TopInfo) this.vTop.elementAt(this.selected)));
      GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
      this.addThachDauDetail((TopInfo) this.vTop.elementAt(this.selected));
    }
  }

  private void doFireMapTrans() => this.doFireZone();

  private void doFireGiaoDich()
  {
    if (this.currentTabIndex == 0 && this.Equals((object) GameCanvas.panel))
    {
      this.doFireInventory();
    }
    else
    {
      if (this.currentTabIndex == 0 && this.Equals((object) GameCanvas.panel2) || this.currentTabIndex == 2)
      {
        this.currItem = !this.Equals((object) GameCanvas.panel2) ? (Item) GameCanvas.panel.vFriendGD.elementAt(this.selected) : (Item) GameCanvas.panel2.vFriendGD.elementAt(this.selected);
        Res.outz2("toi day select= " + (object) this.selected);
        MyVector menuItems = new MyVector();
        menuItems.addElement((object) new Command(mResources.CLOSE, (IActionListener) this, 8000, (object) this.currItem));
        if (this.currItem != null)
        {
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addItemDetail(this.currItem);
        }
        else
          this.cp = (ChatPopup) null;
      }
      if (this.currentTabIndex == 1)
      {
        if (this.selected == this.currentListLength - 3)
        {
          if (this.isLock)
            return;
          this.putMoney();
        }
        else if (this.selected == this.currentListLength - 2)
        {
          if (!this.isAccept)
          {
            this.isLock = !this.isLock;
            if (this.isLock)
            {
              Service.gI().giaodich((sbyte) 5, -1, (sbyte) -1, -1);
            }
            else
            {
              this.hide();
              InfoDlg.showWait();
              Service.gI().giaodich((sbyte) 3, -1, (sbyte) -1, -1);
            }
          }
          else
            this.isAccept = false;
        }
        else if (this.selected == this.currentListLength - 1)
        {
          if (this.isLock && !this.isAccept && this.isFriendLock)
            GameCanvas.startYesNoDlg(mResources.do_u_sure_to_trade, new Command(mResources.YES, (IActionListener) this, 7002, (object) null), new Command(mResources.NO, (IActionListener) this, 4005, (object) null));
        }
        else
        {
          if (this.isLock)
            return;
          this.currItem = (Item) GameCanvas.panel.vMyGD.elementAt(this.selected);
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.CLOSE, (IActionListener) this, 8000, (object) this.currItem));
          if (this.currItem != null)
          {
            GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
            this.addItemDetail(this.currItem);
          }
          else
            this.cp = (ChatPopup) null;
        }
      }
      if (!GameCanvas.isTouch)
        return;
      this.selected = -1;
    }
  }

  private void doFireCombine()
  {
    if (this.currentTabIndex == 0)
    {
      if (this.selected == -1 || this.vItemCombine.size() == 0)
        return;
      if (this.selected == this.vItemCombine.size())
      {
        this.keyTouchCombine = -1;
        this.selected = !GameCanvas.isTouch ? 0 : -1;
        InfoDlg.showWait();
        Service.gI().combine((sbyte) 1, this.vItemCombine);
        return;
      }
      if (this.selected > this.vItemCombine.size() - 1)
        return;
      this.currItem = (Item) GameCanvas.panel.vItemCombine.elementAt(this.selected);
      MyVector menuItems = new MyVector();
      menuItems.addElement((object) new Command(mResources.GETOUT, (IActionListener) this, 6001, (object) this.currItem));
      if (this.currItem != null)
      {
        GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
        this.addItemDetail(this.currItem);
      }
      else
        this.cp = (ChatPopup) null;
    }
    if (this.currentTabIndex != 1)
      return;
    this.doFireInventory();
  }

  private void doFirePlayerMenu()
  {
    if (this.selected == -1)
      return;
    this.isSelectPlayerMenu = true;
    this.hide();
  }

  private void doFireShop()
  {
    this.currItem = (Item) null;
    if (this.selected < 0)
      return;
    MyVector menuItems = new MyVector();
    if (this.currentTabIndex < this.currentTabName.Length - (GameCanvas.panel2 == null ? 1 : 0) && this.type != 17)
    {
      this.currItem = Char.myCharz().arrItemShop[this.currentTabIndex][this.selected];
      if (this.currItem != null)
      {
        if (this.currItem.isBuySpec)
        {
          if (this.currItem.buySpec > 0)
            menuItems.addElement((object) new Command(mResources.buy_with + "\n" + Res.formatNumber2((long) this.currItem.buySpec), (IActionListener) this, 3005, (object) this.currItem));
        }
        else if (this.typeShop == 4)
        {
          menuItems.addElement((object) new Command(mResources.receive_upper, (IActionListener) this, 30001, (object) this.currItem));
          menuItems.addElement((object) new Command(mResources.DELETE, (IActionListener) this, 30002, (object) this.currItem));
          menuItems.addElement((object) new Command(mResources.receive_all, (IActionListener) this, 30003, (object) this.currItem));
        }
        else if (this.currItem.buyCoin == 0 && this.currItem.buyGold == 0)
        {
          if (this.currItem.powerRequire != 0L)
            menuItems.addElement((object) new Command(mResources.learn_with + "\n" + Res.formatNumber(this.currItem.powerRequire) + " \n" + mResources.potential, (IActionListener) this, 3004, (object) this.currItem));
          else
            menuItems.addElement((object) new Command(mResources.receive_upper + "\n" + mResources.free, (IActionListener) this, 3000, (object) this.currItem));
        }
        else if (this.typeShop == 8)
        {
          if (this.currItem.buyCoin > 0)
            menuItems.addElement((object) new Command(mResources.buy_with + "\n" + Res.formatNumber2((long) this.currItem.buyCoin) + "\n" + mResources.XU, (IActionListener) this, 30001, (object) this.currItem));
          if (this.currItem.buyGold > 0)
            menuItems.addElement((object) new Command(mResources.buy_with + "\n" + Res.formatNumber2((long) this.currItem.buyGold) + "\n" + mResources.LUONG, (IActionListener) this, 30002, (object) this.currItem));
        }
        else if (this.typeShop != 2)
        {
          if (this.currItem.buyCoin > 0)
            menuItems.addElement((object) new Command(mResources.buy_with + "\n" + Res.formatNumber2((long) this.currItem.buyCoin) + "\n" + mResources.XU, (IActionListener) this, 3000, (object) this.currItem));
          if (this.currItem.buyGold > 0)
            menuItems.addElement((object) new Command(mResources.buy_with + "\n" + Res.formatNumber2((long) this.currItem.buyGold) + "\n" + mResources.LUONG, (IActionListener) this, 3001, (object) this.currItem));
        }
        else
        {
          if (this.currItem.buyCoin != -1)
            menuItems.addElement((object) new Command(mResources.buy_with + "\n" + Res.formatNumber2((long) this.currItem.buyCoin) + "\n" + mResources.XU, (IActionListener) this, 10016, (object) this.currItem));
          if (this.currItem.buyGold != -1)
            menuItems.addElement((object) new Command(mResources.buy_with + "\n" + Res.formatNumber2((long) this.currItem.buyGold) + "\n" + mResources.LUONG, (IActionListener) this, 10017, (object) this.currItem));
        }
      }
    }
    else if (this.typeShop == 0)
    {
      if (this.selected == 0)
      {
        this.setNewSelected(Char.myCharz().arrItemBody.Length + Char.myCharz().arrItemBag.Length, false);
      }
      else
      {
        this.currItem = (Item) null;
        if (!this.GetInventorySelect_isbody(this.selected, this.newSelected, Char.myCharz().arrItemBody))
        {
          Item obj = Char.myCharz().arrItemBag[this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody)];
          if (obj != null)
            this.currItem = obj;
        }
        else
        {
          Item obj = Char.myCharz().arrItemBody[this.GetInventorySelect_body(this.selected, this.newSelected)];
          if (obj != null)
            this.currItem = obj;
        }
        if (this.currItem != null)
          menuItems.addElement((object) new Command(mResources.SALE, (IActionListener) this, 3002, (object) this.currItem));
      }
    }
    else
    {
      this.currItem = this.type != 17 ? Char.myCharz().arrItemShop[this.currentTabIndex][this.selected] : Char.myCharz().arrItemShop[4][this.selected];
      if (this.currItem.buyType == (sbyte) 0)
      {
        if (this.currItem.isHaveOption(87))
          menuItems.addElement((object) new Command(mResources.kiguiLuong, (IActionListener) this, 10013, (object) this.currItem));
        else
          menuItems.addElement((object) new Command(mResources.kiguiXu, (IActionListener) this, 10012, (object) this.currItem));
      }
      else if (this.currItem.buyType == (sbyte) 1)
      {
        menuItems.addElement((object) new Command(mResources.huykigui, (IActionListener) this, 10014, (object) this.currItem));
        menuItems.addElement((object) new Command(mResources.upTop, (IActionListener) this, 10018, (object) this.currItem));
      }
      else if (this.currItem.buyType == (sbyte) 2)
        menuItems.addElement((object) new Command(mResources.nhantien, (IActionListener) this, 10015, (object) this.currItem));
    }
    if (this.currItem != null)
    {
      Char.myCharz().setPartTemp(this.currItem.headTemp, this.currItem.bodyTemp, this.currItem.legTemp, this.currItem.bagTemp);
      GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
      this.addItemDetail(this.currItem);
    }
    else
      this.cp = (ChatPopup) null;
  }

  private void doFireArchivement()
  {
    if (this.selected < 0 || !Char.myCharz().arrArchive[this.selected].isFinish || Char.myCharz().arrArchive[this.selected].isRecieve)
      return;
    if (!GameCanvas.isTouch)
    {
      Service.gI().getArchivemnt(this.selected);
    }
    else
    {
      if (GameCanvas.px <= this.xScroll + this.wScroll - 40)
        return;
      Service.gI().getArchivemnt(this.selected);
    }
  }

  private void doFireInventory()
  {
    Res.outz("fire inventory");
    if (Char.myCharz().statusMe == 14)
    {
      GameCanvas.startOKDlg(mResources.can_not_do_when_die);
    }
    else
    {
      if (this.selected == -1)
        return;
      if (this.selected == 0)
      {
        this.setNewSelected(Char.myCharz().arrItemBody.Length + Char.myCharz().arrItemBag.Length, false);
      }
      else
      {
        this.currItem = (Item) null;
        MyVector menuItems = new MyVector();
        if (!this.GetInventorySelect_isbody(this.selected, this.newSelected, Char.myCharz().arrItemBody))
        {
          Item obj = Char.myCharz().arrItemBag[this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody)];
          if (obj != null)
          {
            this.currItem = obj;
            if (GameCanvas.panel.type == 12)
              menuItems.addElement((object) new Command(mResources.use_for_combine, (IActionListener) this, 6000, (object) this.currItem));
            else if (GameCanvas.panel.type == 13)
              menuItems.addElement((object) new Command(mResources.use_for_trade, (IActionListener) this, 7000, (object) this.currItem));
            else if (obj.isTypeBody())
            {
              menuItems.addElement((object) new Command(mResources.USE, (IActionListener) this, 2000, (object) this.currItem));
              if (Char.myCharz().havePet)
                menuItems.addElement((object) new Command(mResources.MOVEFORPET, (IActionListener) this, 2005, (object) this.currItem));
            }
            else
              menuItems.addElement((object) new Command(mResources.USE, (IActionListener) this, 2001, (object) this.currItem));
          }
        }
        else
        {
          Item obj = Char.myCharz().arrItemBody[this.GetInventorySelect_body(this.selected, this.newSelected)];
          if (obj != null)
          {
            this.currItem = obj;
            menuItems.addElement((object) new Command(mResources.GETOUT, (IActionListener) this, 2002, (object) this.currItem));
          }
        }
        if (this.currItem != null)
        {
          Char.myCharz().setPartTemp(this.currItem.headTemp, this.currItem.bodyTemp, this.currItem.legTemp, this.currItem.bagTemp);
          if (GameCanvas.panel.type != 12 && GameCanvas.panel.type != 13)
          {
            if (this.position == 0)
              menuItems.addElement((object) new Command(mResources.MOVEOUT, (IActionListener) this, 2003, (object) this.currItem));
            if (this.position == 1)
              menuItems.addElement((object) new Command(mResources.SALE, (IActionListener) this, 3002, (object) this.currItem));
          }
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addItemDetail(this.currItem);
        }
        else
          this.cp = (ChatPopup) null;
      }
    }
  }

  private void doRada()
  {
    this.hide();
    if (RadarScr.list == null || RadarScr.list.size() == 0)
    {
      Service.gI().SendRada(0, -1);
      RadarScr.gI().switchToMe();
    }
    else
      RadarScr.gI().switchToMe();
  }

  private void doFireTool()
  {
    if (this.selected < 0)
      return;
    if (SoundMn.IsDelAcc && this.selected == Panel.strTool.Length - 1)
      Service.gI().sendDelAcc();
    else if (!Char.myCharz().havePet)
    {
      switch (this.selected)
      {
        case 0:
          this.doRada();
          break;
        case 1:
          this.hide();
          Service.gI().openMenu(54);
          break;
        case 2:
          this.setTypeGameInfo();
          break;
        case 3:
          Service.gI().getFlag((sbyte) 0, (sbyte) -1);
          InfoDlg.showWait();
          break;
        case 4:
          if (Char.myCharz().statusMe == 14)
          {
            GameCanvas.startOKDlg(mResources.can_not_do_when_die);
            break;
          }
          Service.gI().openUIZone();
          break;
        case 5:
          GameCanvas.endDlg();
          if (Char.myCharz().checkLuong() < 5)
          {
            GameCanvas.startOKDlg(mResources.not_enough_luong_world_channel);
            break;
          }
          if (this.chatTField == null)
          {
            this.chatTField = new ChatTextField();
            this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
            this.chatTField.initChatTextField();
            this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
          }
          this.chatTField.strChat = mResources.world_channel_5_luong;
          this.chatTField.tfChat.name = mResources.CHAT;
          this.chatTField.to = string.Empty;
          this.chatTField.isShow = true;
          this.chatTField.tfChat.isFocus = true;
          this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
          if (Main.isWindowsPhone)
            this.chatTField.tfChat.strInfo = this.chatTField.strChat;
          if (!Main.isPC)
          {
            this.chatTField.startChat2((IChatable) this, string.Empty);
            break;
          }
          if (!GameCanvas.isTouch)
            break;
          this.chatTField.tfChat.doChangeToTextBox();
          break;
        case 6:
          this.setTypeAccount();
          break;
        case 7:
          this.setTypeOption();
          break;
        case 8:
          GameCanvas.loginScr.backToRegister();
          break;
        case 9:
          if (!GameCanvas.loginScr.isLogin2)
            break;
          SoundMn.gI().backToRegister();
          break;
      }
    }
    else
    {
      switch (this.selected)
      {
        case 0:
          this.doRada();
          break;
        case 1:
          this.hide();
          Service.gI().openMenu(54);
          break;
        case 2:
          this.setTypeGameInfo();
          break;
        case 3:
          this.doFirePet();
          break;
        case 4:
          Service.gI().getFlag((sbyte) 0, (sbyte) -1);
          InfoDlg.showWait();
          break;
        case 5:
          if (Char.myCharz().statusMe == 14)
          {
            GameCanvas.startOKDlg(mResources.can_not_do_when_die);
            break;
          }
          Service.gI().openUIZone();
          break;
        case 6:
          GameCanvas.endDlg();
          if (Char.myCharz().checkLuong() < 5)
          {
            GameCanvas.startOKDlg(mResources.not_enough_luong_world_channel);
            break;
          }
          if (this.chatTField == null)
          {
            this.chatTField = new ChatTextField();
            this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
            this.chatTField.initChatTextField();
            this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
          }
          this.chatTField.strChat = mResources.world_channel_5_luong;
          this.chatTField.tfChat.name = mResources.CHAT;
          this.chatTField.to = string.Empty;
          this.chatTField.isShow = true;
          this.chatTField.tfChat.isFocus = true;
          this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
          if (Main.isWindowsPhone)
            this.chatTField.tfChat.strInfo = this.chatTField.strChat;
          if (!Main.isPC)
          {
            this.chatTField.startChat2((IChatable) this, string.Empty);
            break;
          }
          if (!GameCanvas.isTouch)
            break;
          this.chatTField.tfChat.doChangeToTextBox();
          break;
        case 7:
          this.setTypeAccount();
          break;
        case 8:
          this.setTypeOption();
          break;
        case 9:
          GameCanvas.loginScr.backToRegister();
          break;
        case 10:
          if (!GameCanvas.loginScr.isLogin2)
            break;
          SoundMn.gI().backToRegister();
          break;
      }
    }
  }

  private void setTypeGameSubInfo()
  {
    string content = ((GameInfo) Panel.vGameInfo.elementAt(this.infoSelect)).content;
    Panel.contenInfo = mFont.tahoma_7_grey.splitFontArray(content, this.wScroll - 40);
    this.currentListLength = Panel.contenInfo.Length;
    this.ITEM_HEIGHT = 16;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.type = 24;
    this.setType(0);
  }

  private void setTypeGameInfo()
  {
    this.currentListLength = Panel.vGameInfo.size();
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.type = 23;
    this.setType(0);
  }

  private void doFirePet()
  {
    InfoDlg.showWait();
    Service.gI().petInfo();
    this.timeShow = 20;
  }

  private void searchClan()
  {
    this.chatTField.strChat = mResources.input_clan_name;
    this.chatTField.tfChat.name = mResources.clan_name;
    this.chatTField.to = string.Empty;
    this.chatTField.isShow = true;
    this.chatTField.tfChat.isFocus = true;
    this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
    if (Main.isWindowsPhone)
      this.chatTField.tfChat.strInfo = this.chatTField.strChat;
    if (Main.isPC)
      return;
    this.chatTField.startChat2((IChatable) this, string.Empty);
  }

  private void chatClan()
  {
    this.chatTField.strChat = mResources.chat_clan;
    this.chatTField.tfChat.name = mResources.CHAT;
    this.chatTField.to = string.Empty;
    this.chatTField.isShow = true;
    this.chatTField.tfChat.isFocus = true;
    this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
    if (Main.isWindowsPhone)
      this.chatTField.tfChat.strInfo = this.chatTField.strChat;
    if (Main.isPC)
      return;
    this.chatTField.startChat2((IChatable) this, string.Empty);
  }

  public void creatClan()
  {
    this.chatTField.strChat = mResources.input_clan_name_to_create;
    this.chatTField.tfChat.name = mResources.input_clan_name;
    this.chatTField.to = string.Empty;
    this.chatTField.isShow = true;
    this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
    if (Main.isWindowsPhone)
      this.chatTField.tfChat.strInfo = this.chatTField.strChat;
    if (Main.isPC)
      return;
    this.chatTField.startChat2((IChatable) this, string.Empty);
  }

  public void putMoney()
  {
    if (this.chatTField == null)
    {
      this.chatTField = new ChatTextField();
      this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
      this.chatTField.initChatTextField();
      this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
    }
    this.chatTField.strChat = mResources.input_money_to_trade;
    this.chatTField.tfChat.name = mResources.input_money;
    this.chatTField.to = string.Empty;
    this.chatTField.isShow = true;
    this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
    this.chatTField.tfChat.setMaxTextLenght(9);
    if (GameCanvas.isTouch)
      this.chatTField.tfChat.doChangeToTextBox();
    if (Main.isWindowsPhone)
      this.chatTField.tfChat.strInfo = this.chatTField.strChat;
    if (Main.isPC)
      return;
    this.chatTField.startChat2((IChatable) this, string.Empty);
  }

  public void putQuantily()
  {
    if (this.chatTField == null)
    {
      this.chatTField = new ChatTextField();
      this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
      this.chatTField.initChatTextField();
      this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
    }
    this.chatTField.strChat = mResources.input_quantity_to_trade;
    this.chatTField.tfChat.name = mResources.input_quantity;
    this.chatTField.to = string.Empty;
    this.chatTField.isShow = true;
    this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
    if (GameCanvas.isTouch)
      this.chatTField.tfChat.doChangeToTextBox();
    if (Main.isWindowsPhone)
      this.chatTField.tfChat.strInfo = this.chatTField.strChat;
    if (Main.isPC)
      return;
    this.chatTField.startChat2((IChatable) this, string.Empty);
  }

  public void chagenSlogan()
  {
    this.chatTField.strChat = mResources.input_clan_slogan;
    this.chatTField.tfChat.name = mResources.input_clan_slogan;
    this.chatTField.to = string.Empty;
    this.chatTField.isShow = true;
    this.chatTField.tfChat.isFocus = true;
    this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
    if (Main.isWindowsPhone)
      this.chatTField.tfChat.strInfo = this.chatTField.strChat;
    if (Main.isPC)
      return;
    this.chatTField.startChat2((IChatable) this, string.Empty);
  }

  public void changeIcon()
  {
    if (this.tabIcon == null)
      this.tabIcon = new TabClanIcon();
    this.tabIcon.text = this.chatTField.tfChat.getText();
    this.tabIcon.show(false);
    this.chatTField.isShow = false;
  }

  private void addFriend(InfoItem info)
  {
    string str = "|0|1|" + info.charInfo.cName + "\n";
    string chat = (!info.isOnline ? str + "|3|1|" + mResources.is_offline : str + "|4|1|" + mResources.is_online) + "\n--" + "\n|5|" + mResources.power + ": " + info.s;
    this.cp = new ChatPopup();
    this.popUpDetailInit(this.cp, chat);
    this.charInfo = info.charInfo;
    this.currItem = (Item) null;
  }

  private void doFireEnemy()
  {
    if (this.selected < 0 || this.vEnemy.size() == 0)
      return;
    MyVector menuItems = new MyVector();
    this.currInfoItem = this.selected;
    menuItems.addElement((object) new Command(mResources.REVENGE, (IActionListener) this, 10000, (object) (InfoItem) this.vEnemy.elementAt(this.currInfoItem)));
    menuItems.addElement((object) new Command(mResources.DELETE, (IActionListener) this, 10001, (object) (InfoItem) this.vEnemy.elementAt(this.currInfoItem)));
    GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
    this.addFriend((InfoItem) this.vEnemy.elementAt(this.selected));
  }

  private void doFireFriend()
  {
    if (this.selected < 0 || this.vFriend.size() == 0)
      return;
    MyVector menuItems = new MyVector();
    this.currInfoItem = this.selected;
    menuItems.addElement((object) new Command(mResources.CHAT, (IActionListener) this, 8001, (object) (InfoItem) this.vFriend.elementAt(this.currInfoItem)));
    menuItems.addElement((object) new Command(mResources.DELETE, (IActionListener) this, 8002, (object) (InfoItem) this.vFriend.elementAt(this.currInfoItem)));
    menuItems.addElement((object) new Command(mResources.den, (IActionListener) this, 8004, (object) (InfoItem) this.vFriend.elementAt(this.currInfoItem)));
    GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
    this.addFriend((InfoItem) this.vFriend.elementAt(this.selected));
  }

  private void doFireChangeFlag()
  {
    if (this.selected < 0)
      return;
    MyVector menuItems = new MyVector();
    this.currInfoItem = this.selected;
    menuItems.addElement((object) new Command(mResources.change_flag, (IActionListener) this, 10030, (object) null));
    menuItems.addElement((object) new Command(mResources.BACK, (IActionListener) this, 10031, (object) null));
    GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
  }

  private void doFireLogMessage()
  {
    if (this.selected == 0)
    {
      this.isViewChatServer = !this.isViewChatServer;
      Rms.saveRMSInt("viewchat", !this.isViewChatServer ? 0 : 1);
      if (!GameCanvas.isTouch)
        return;
      this.selected = -1;
    }
    else
    {
      if (this.selected < 0 || this.logChat.size() == 0)
        return;
      MyVector menuItems = new MyVector();
      this.currInfoItem = this.selected - 1;
      menuItems.addElement((object) new Command(mResources.CHAT, (IActionListener) this, 8001, (object) (InfoItem) this.logChat.elementAt(this.currInfoItem)));
      menuItems.addElement((object) new Command(mResources.make_friend, (IActionListener) this, 8003, (object) (InfoItem) this.logChat.elementAt(this.currInfoItem)));
      GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
      this.addLogMessage((InfoItem) this.logChat.elementAt(this.selected - 1));
    }
  }

  private void doFireClanOption()
  {
    this.partID = (int[]) null;
    this.charInfo = (Char) null;
    Res.outz("cSelect= " + (object) this.cSelected);
    if (this.selected < 0)
    {
      this.cSelected = -1;
    }
    else
    {
      if (Char.myCharz().clan == null)
      {
        if (this.selected == 0)
        {
          if (this.cSelected == 0)
            this.searchClan();
          else if (this.cSelected == 1)
          {
            InfoDlg.showWait();
            this.creatClan();
            Service.gI().getClan((sbyte) 1, (sbyte) -1, (string) null);
          }
        }
        else if (this.selected != -1)
        {
          if (this.selected == 1)
          {
            if (this.isSearchClan)
              Service.gI().searchClan(string.Empty);
            else if (this.isViewMember && this.currClan != null)
              GameCanvas.startYesNoDlg(mResources.do_u_want_join_clan + this.currClan.name, new Command(mResources.YES, (IActionListener) this, 4000, (object) this.currClan), new Command(mResources.NO, (IActionListener) this, 4005, (object) this.currClan));
          }
          else if (this.isSearchClan)
          {
            this.currClan = this.getCurrClan();
            if (this.currClan != null)
            {
              MyVector menuItems = new MyVector();
              menuItems.addElement((object) new Command(mResources.request_join_clan, (IActionListener) this, 4000, (object) this.currClan));
              menuItems.addElement((object) new Command(mResources.view_clan_member, (IActionListener) this, 4001, (object) this.currClan));
              GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
              this.addClanDetail(this.getCurrClan());
            }
          }
          else if (this.isViewMember)
          {
            this.currMem = this.getCurrMember();
            if (this.currMem != null)
            {
              MyVector menuItems = new MyVector();
              menuItems.addElement((object) new Command(mResources.CLOSE, (IActionListener) this, 8000, (object) this.currClan));
              GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
              GameCanvas.menu.startAt(menuItems, 0, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
              this.addClanMemberDetail(this.currMem);
            }
          }
        }
      }
      else if (this.selected == 0)
      {
        if (this.isMessage)
        {
          if (this.cSelected == 0)
          {
            if (this.myMember.size() > 1)
            {
              this.chatClan();
            }
            else
            {
              this.member = (MyVector) null;
              this.isSearchClan = false;
              this.isViewMember = true;
              this.isMessage = false;
              this.currentListLength = this.myMember.size() + 2;
              this.initTabClans();
            }
          }
          if (this.cSelected == 1)
            Service.gI().clanMessage(1, (string) null, -1);
          if (this.cSelected == 2)
          {
            this.member = (MyVector) null;
            this.isSearchClan = false;
            this.isViewMember = true;
            this.isMessage = false;
            this.currentListLength = this.myMember.size() + 2;
            this.initTabClans();
            this.getCurrClanOtion();
          }
        }
        else if (this.isViewMember)
        {
          if (this.cSelected == 0)
          {
            this.isSearchClan = false;
            this.isViewMember = false;
            this.isMessage = true;
            this.currentListLength = ClanMessage.vMessage.size() + 2;
            this.initTabClans();
          }
          if (this.cSelected == 1)
          {
            if (this.myMember.size() > 1)
              Service.gI().leaveClan();
            else
              this.chagenSlogan();
          }
          if (this.cSelected == 2)
          {
            if (this.myMember.size() > 1)
              this.chagenSlogan();
            else
              Service.gI().getClan((sbyte) 3, (sbyte) -1, (string) null);
          }
          if (this.cSelected == 3)
            Service.gI().getClan((sbyte) 3, (sbyte) -1, (string) null);
        }
      }
      else if (this.selected == 1)
      {
        if (this.isSearchClan)
          Service.gI().searchClan(string.Empty);
      }
      else if (this.isSearchClan)
      {
        this.currClan = this.getCurrClan();
        if (this.currClan != null)
        {
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.view_clan_member, (IActionListener) this, 4001, (object) this.currClan));
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addClanDetail(this.getCurrClan());
        }
      }
      else if (this.isViewMember)
      {
        Res.outz("TOI DAY 1");
        this.currMem = this.getCurrMember();
        if (this.currMem != null)
        {
          MyVector menuItems = new MyVector();
          Res.outz("TOI DAY 2");
          if (this.member != null)
          {
            menuItems.addElement((object) new Command(mResources.CLOSE, (IActionListener) this, 8000, (object) null));
            Res.outz("TOI DAY 3");
          }
          else if (this.myMember != null)
          {
            Res.outz("TOI DAY 4");
            Res.outz("my role= " + (object) Char.myCharz().role);
            if (Char.myCharz().charID == this.currMem.ID || Char.myCharz().role == (sbyte) 2)
              menuItems.addElement((object) new Command(mResources.CLOSE, (IActionListener) this, 8000, (object) this.currMem));
            if (Char.myCharz().role < (sbyte) 2 && Char.myCharz().charID != this.currMem.ID)
            {
              Res.outz("TOI DAY");
              if (this.currMem.role == (sbyte) 0 || this.currMem.role == (sbyte) 1)
                menuItems.addElement((object) new Command(mResources.CLOSE, (IActionListener) this, 8000, (object) this.currMem));
              if (this.currMem.role == (sbyte) 2)
                menuItems.addElement((object) new Command(mResources.create_clan_co_leader, (IActionListener) this, 5002, (object) this.currMem));
              if (Char.myCharz().role == (sbyte) 0)
              {
                menuItems.addElement((object) new Command(mResources.create_clan_leader, (IActionListener) this, 5001, (object) this.currMem));
                if (this.currMem.role == (sbyte) 1)
                  menuItems.addElement((object) new Command(mResources.disable_clan_mastership, (IActionListener) this, 5003, (object) this.currMem));
              }
            }
            if ((int) Char.myCharz().role < (int) this.currMem.role)
              menuItems.addElement((object) new Command(mResources.kick_clan_mem, (IActionListener) this, 5004, (object) this.currMem));
          }
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addClanMemberDetail(this.currMem);
        }
      }
      else if (this.isMessage)
      {
        this.currMess = this.getCurrMessage();
        if (this.currMess != null)
        {
          if (this.currMess.type == 0)
          {
            MyVector menuItems = new MyVector();
            menuItems.addElement((object) new Command(mResources.CLOSE, (IActionListener) this, 8000, (object) this.currMess));
            GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
            this.addMessageDetail(this.currMess);
          }
          else if (this.currMess.type == 1)
          {
            if (this.currMess.playerId != Char.myCharz().charID && this.cSelected != -1)
              Service.gI().clanDonate(this.currMess.id);
          }
          else if (this.currMess.type == 2 && this.currMess.option != null)
          {
            if (this.cSelected == 0)
              Service.gI().joinClan(this.currMess.id, (sbyte) 1);
            else if (this.cSelected == 1)
              Service.gI().joinClan(this.currMess.id, (sbyte) 0);
          }
        }
      }
      if (!GameCanvas.isTouch)
        return;
      this.cSelected = -1;
      this.selected = -1;
    }
  }

  private void doFireMain()
  {
    if (this.currentTabIndex == 0)
      this.setTypeMap();
    if (this.currentTabIndex == 1)
      this.doFireInventory();
    if (this.currentTabIndex == 2)
      this.doFireSkill();
    if (this.currentTabIndex == 3)
    {
      if (this.mainTabName.Length == 4)
        this.doFireTool();
      else
        this.doFireClanOption();
    }
    if (this.currentTabIndex != 4)
      return;
    this.doFireTool();
  }

  private void doFireSkill()
  {
    if (this.selected < 0)
      return;
    if (Char.myCharz().statusMe == 14)
      GameCanvas.startOKDlg(mResources.can_not_do_when_die);
    else if (this.selected == 0 || this.selected == 1 || this.selected == 2 || this.selected == 3 || this.selected == 4 || this.selected == 5)
    {
      long cTiemNang = Char.myCharz().cTiemNang;
      int cHpGoc = Char.myCharz().cHPGoc;
      int cMpGoc = Char.myCharz().cMPGoc;
      int cDamGoc = Char.myCharz().cDamGoc;
      int cDefGoc = Char.myCharz().cDefGoc;
      int cCriticalGoc = Char.myCharz().cCriticalGoc;
      int num = 1000;
      if (this.selected == 0)
      {
        if (cTiemNang < (long) (Char.myCharz().cHPGoc + num))
        {
          GameCanvas.startOKDlg(mResources.not_enough_potential_point1 + (object) Char.myCharz().cTiemNang + mResources.not_enough_potential_point2 + (object) (Char.myCharz().cHPGoc + num), false);
          return;
        }
        if (cTiemNang > (long) cHpGoc && cTiemNang < (long) (10 * (2 * (cHpGoc + num) + 180) / 2))
        {
          GameCanvas.startYesNoDlg(mResources.use_potential_point_for1 + (object) (cHpGoc + num) + mResources.use_potential_point_for2 + (object) Char.myCharz().hpFrom1000TiemNang + mResources.for_HP, new Command(mResources.increase_upper, (IActionListener) this, 9000, (object) null), new Command(mResources.CANCEL, (IActionListener) this, 4007, (object) null));
          return;
        }
        if (cTiemNang >= (long) (10 * (2 * (cHpGoc + num) + 180) / 2) && cTiemNang < (long) (100 * (2 * (cHpGoc + num) + 1980) / 2))
        {
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) Char.myCharz().hpFrom1000TiemNang + mResources.HP + "\n-" + (object) (cHpGoc + num), (IActionListener) this, 9000, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (10 * (int) Char.myCharz().hpFrom1000TiemNang) + mResources.HP + "\n-" + (object) (10 * (2 * (cHpGoc + num) + 180) / 2), (IActionListener) this, 9006, (object) null));
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addSkillDetail2(this.selected);
        }
        if (cTiemNang >= (long) (100 * (2 * (cHpGoc + num) + 1980) / 2))
        {
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) Char.myCharz().hpFrom1000TiemNang + mResources.HP + "\n-" + (object) (cHpGoc + num), (IActionListener) this, 9000, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (10 * (int) Char.myCharz().hpFrom1000TiemNang) + mResources.HP + "\n-" + (object) (10 * (2 * (cHpGoc + num) + 180) / 2), (IActionListener) this, 9006, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (100 * (int) Char.myCharz().hpFrom1000TiemNang) + mResources.HP + "\n-" + (object) (100 * (2 * (cHpGoc + num) + 1980) / 2), (IActionListener) this, 9007, (object) null));
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addSkillDetail2(this.selected);
        }
      }
      if (this.selected == 1)
      {
        if (Char.myCharz().cTiemNang < (long) (Char.myCharz().cMPGoc + num))
        {
          GameCanvas.startOKDlg(mResources.not_enough_potential_point1 + (object) Char.myCharz().cTiemNang + mResources.not_enough_potential_point2 + (object) (Char.myCharz().cMPGoc + num), false);
          return;
        }
        if (cTiemNang > (long) cMpGoc && cTiemNang < (long) (10 * (2 * (cMpGoc + num) + 180) / 2))
        {
          GameCanvas.startYesNoDlg(mResources.use_potential_point_for1 + (object) (cMpGoc + num) + mResources.use_potential_point_for2 + (object) Char.myCharz().mpFrom1000TiemNang + mResources.for_KI, new Command(mResources.increase_upper, (IActionListener) this, 9000, (object) null), new Command(mResources.CANCEL, (IActionListener) this, 4007, (object) null));
          return;
        }
        if (cTiemNang >= (long) (10 * (2 * (cMpGoc + num) + 180) / 2) && cTiemNang < (long) (100 * (2 * (cMpGoc + num) + 1980) / 2))
        {
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) Char.myCharz().mpFrom1000TiemNang + mResources.KI + "\n-" + (object) (cHpGoc + num), (IActionListener) this, 9000, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (10 * (int) Char.myCharz().mpFrom1000TiemNang) + mResources.KI + "\n-" + (object) (10 * (2 * (cHpGoc + num) + 180) / 2), (IActionListener) this, 9006, (object) null));
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addSkillDetail2(this.selected);
        }
        if (cTiemNang >= (long) (100 * (2 * (cMpGoc + num) + 1980) / 2))
        {
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) Char.myCharz().mpFrom1000TiemNang + mResources.KI + "\n-" + (object) (cMpGoc + num), (IActionListener) this, 9000, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (10 * (int) Char.myCharz().mpFrom1000TiemNang) + mResources.KI + "\n-" + (object) (10 * (2 * (cMpGoc + num) + 180) / 2), (IActionListener) this, 9006, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (100 * (int) Char.myCharz().mpFrom1000TiemNang) + mResources.KI + "\n-" + (object) (100 * (2 * (cMpGoc + num) + 1980) / 2), (IActionListener) this, 9007, (object) null));
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addSkillDetail2(this.selected);
        }
      }
      if (this.selected == 2)
      {
        if (Char.myCharz().cTiemNang < (long) (Char.myCharz().cDamGoc * (int) Char.myCharz().expForOneAdd))
        {
          GameCanvas.startOKDlg(mResources.not_enough_potential_point1 + (object) Char.myCharz().cTiemNang + mResources.not_enough_potential_point2 + (object) (cDamGoc * 100), false);
          return;
        }
        if (cTiemNang > (long) cDamGoc && cTiemNang < (long) (10 * (2 * cDamGoc + 9) / 2 * (int) Char.myCharz().expForOneAdd))
        {
          GameCanvas.startYesNoDlg(mResources.use_potential_point_for1 + (object) (cDamGoc * 100) + mResources.use_potential_point_for2 + (object) Char.myCharz().damFrom1000TiemNang + mResources.for_hit_point, new Command(mResources.increase_upper, (IActionListener) this, 9000, (object) null), new Command(mResources.CANCEL, (IActionListener) this, 4007, (object) null));
          return;
        }
        if (cTiemNang >= (long) (10 * (2 * cDamGoc + 9) / 2 * (int) Char.myCharz().expForOneAdd) && cTiemNang < (long) (100 * (2 * cDamGoc + 99) / 2 * (int) Char.myCharz().expForOneAdd))
        {
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) Char.myCharz().damFrom1000TiemNang + "\n" + mResources.hit_point + "\n-" + (object) (cDamGoc * 100), (IActionListener) this, 9000, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (10 * (int) Char.myCharz().damFrom1000TiemNang) + "\n" + mResources.hit_point + "\n-" + (object) (10 * (2 * cDamGoc + 9) / 2 * (int) Char.myCharz().expForOneAdd), (IActionListener) this, 9006, (object) null));
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addSkillDetail2(this.selected);
        }
        if (cTiemNang >= (long) (100 * (2 * cDamGoc + 99) / 2 * (int) Char.myCharz().expForOneAdd))
        {
          MyVector menuItems = new MyVector();
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) Char.myCharz().damFrom1000TiemNang + "\n" + mResources.hit_point + "\n-" + (object) (cDamGoc * 100), (IActionListener) this, 9000, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (10 * (int) Char.myCharz().damFrom1000TiemNang) + "\n" + mResources.hit_point + "\n-" + (object) (10 * (2 * cDamGoc + 9) / 2 * (int) Char.myCharz().expForOneAdd), (IActionListener) this, 9006, (object) null));
          menuItems.addElement((object) new Command(mResources.increase_upper + "\n" + (object) (100 * (int) Char.myCharz().damFrom1000TiemNang) + "\n" + mResources.hit_point + "\n-" + (object) (100 * (2 * cDamGoc + 99) / 2 * (int) Char.myCharz().expForOneAdd), (IActionListener) this, 9007, (object) null));
          GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
          this.addSkillDetail2(this.selected);
        }
      }
      if (this.selected == 3)
      {
        if (Char.myCharz().cTiemNang < (long) (50000 + Char.myCharz().cDefGoc * 1000))
        {
          GameCanvas.startOKDlg(mResources.not_enough_potential_point1 + NinjaUtil.getMoneys(Char.myCharz().cTiemNang) + mResources.not_enough_potential_point2 + NinjaUtil.getMoneys((long) (50000 + Char.myCharz().cDefGoc * 1000)), false);
        }
        else
        {
          int m = 2 * (cDefGoc + 5) / 2 * 100000;
          GameCanvas.startYesNoDlg(mResources.use_potential_point_for1 + NinjaUtil.getMoneys((long) m) + mResources.use_potential_point_for2 + (object) Char.myCharz().defFrom1000TiemNang + mResources.for_armor, new Command(mResources.increase_upper, (IActionListener) this, 9000, (object) null), new Command(mResources.CANCEL, (IActionListener) this, 4007, (object) null));
        }
      }
      else if (this.selected == 4)
      {
        long m = 50000000;
        for (int index = 0; index < Char.myCharz().cCriticalGoc; ++index)
          m *= 5L;
        if (Char.myCharz().cTiemNang < m)
          GameCanvas.startOKDlg(mResources.not_enough_potential_point1 + NinjaUtil.getMoneys(Char.myCharz().cTiemNang) + mResources.not_enough_potential_point2 + NinjaUtil.getMoneys(m), false);
        else
          GameCanvas.startYesNoDlg(mResources.use_potential_point_for1 + NinjaUtil.getMoneys(m) + mResources.use_potential_point_for2 + (object) Char.myCharz().criticalFrom1000Tiemnang + mResources.for_crit, new Command(mResources.increase_upper, (IActionListener) this, 9000, (object) null), new Command(mResources.CANCEL, (IActionListener) this, 4007, (object) null));
      }
      else
      {
        if (this.selected != 5)
          return;
        Service.gI().speacialSkill((sbyte) 0);
      }
    }
    else
    {
      int index = this.selected - 6;
      SkillTemplate skillTemplate = Char.myCharz().nClass.skillTemplates[index];
      Skill skill1 = Char.myCharz().getSkill(skillTemplate);
      Skill skill2 = (Skill) null;
      MyVector menuItems = new MyVector();
      if (skill1 != null)
      {
        if (skill1.point == skillTemplate.maxPoint)
        {
          menuItems.addElement((object) new Command(mResources.make_shortcut, (IActionListener) this, 9003, (object) skill1.template));
          menuItems.addElement((object) new Command(mResources.CLOSE, 2));
        }
        else
        {
          skill2 = skillTemplate.skills[skill1.point];
          menuItems.addElement((object) new Command(mResources.UPGRADE, (IActionListener) this, 9002, (object) skill2));
          menuItems.addElement((object) new Command(mResources.make_shortcut, (IActionListener) this, 9003, (object) skill1.template));
        }
      }
      else
      {
        skill2 = skillTemplate.skills[0];
        menuItems.addElement((object) new Command(mResources.learn, (IActionListener) this, 9004, (object) skill2));
      }
      GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
      this.addSkillDetail(skillTemplate, skill1, skill2);
    }
  }

  private void addLogMessage(InfoItem info)
  {
    string chat = "|0|1|" + info.charInfo.cName + "\n" + "\n--" + "\n|5|" + Res.split(info.s, "|", 0)[2];
    this.cp = new ChatPopup();
    this.popUpDetailInit(this.cp, chat);
    this.charInfo = info.charInfo;
    this.currItem = (Item) null;
  }

  private void addSkillDetail2(int type)
  {
    string empty = string.Empty;
    int num = 0;
    if (this.selected == 0)
      num = Char.myCharz().cHPGoc + 1000;
    if (this.selected == 1)
      num = Char.myCharz().cMPGoc + 1000;
    if (this.selected == 2)
      num = Char.myCharz().cDamGoc * (int) Char.myCharz().expForOneAdd;
    string chat = empty + "|5|2|" + mResources.USE + " " + (object) num + " " + mResources.potential;
    if (type == 0)
      chat = chat + "\n|5|2|" + mResources.to_gain_20hp;
    if (type == 1)
      chat = chat + "\n|5|2|" + mResources.to_gain_20mp;
    if (type == 2)
      chat = chat + "\n|5|2|" + mResources.to_gain_1pow;
    this.currItem = (Item) null;
    this.partID = (int[]) null;
    this.charInfo = (Char) null;
    this.idIcon = -1;
    this.cp = new ChatPopup();
    this.popUpDetailInit(this.cp, chat);
  }

  private void doFireClanIcon()
  {
  }

  private void doFireMap()
  {
    if (Panel.imgMap != null)
    {
      Panel.imgMap.texture = (Texture2D) null;
      Panel.imgMap = (Image) null;
    }
    TileMap.lastPlanetId = (sbyte) -1;
    mSystem.gcc();
    SmallImage.loadBigRMS();
    this.setTypeMain();
    this.cmx = this.cmtoX = 0;
  }

  private void doFireZone()
  {
    if (this.selected == -1)
      return;
    Res.outz("FIRE ZONE");
    this.isChangeZone = true;
    GameCanvas.panel.hide();
  }

  public void updateRequest(int recieve, int maxCap) => this.cp.says[this.cp.says.Length - 1] = mResources.received + " " + (object) recieve + "/" + (object) maxCap;

  private void doFireBox()
  {
    if (this.selected < 0)
      return;
    this.currItem = (Item) null;
    MyVector menuItems = new MyVector();
    if (this.currentTabIndex == 0 && !this.Equals((object) GameCanvas.panel2))
    {
      if (this.selected == 0)
      {
        this.setNewSelected(Char.myCharz().arrItemBox.Length, false);
      }
      else
      {
        sbyte inventorySelectBody = (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected);
        Item p = Char.myCharz().arrItemBox[(int) inventorySelectBody];
        if (p != null)
        {
          if (this.isBoxClan)
          {
            menuItems.addElement((object) new Command(mResources.GETOUT, (IActionListener) this, 1000, (object) p));
            menuItems.addElement((object) new Command(mResources.USE, (IActionListener) this, 2010, (object) p));
          }
          else if (p.isTypeBody())
            menuItems.addElement((object) new Command(mResources.GETOUT, (IActionListener) this, 1000, (object) p));
          else
            menuItems.addElement((object) new Command(mResources.GETOUT, (IActionListener) this, 1000, (object) p));
          this.currItem = p;
        }
      }
    }
    if (this.currentTabIndex == 1 || this.Equals((object) GameCanvas.panel2))
    {
      if (this.selected == 0)
      {
        this.setNewSelected(Char.myCharz().arrItemBody.Length + Char.myCharz().arrItemBag.Length, true);
      }
      else
      {
        Item[] arrItemBody = Char.myCharz().arrItemBody;
        if (!this.GetInventorySelect_isbody(this.selected, this.newSelected, arrItemBody))
        {
          sbyte inventorySelectBag = (sbyte) this.GetInventorySelect_bag(this.selected, this.newSelected, arrItemBody);
          Item p = Char.myCharz().arrItemBag[(int) inventorySelectBag];
          if (p != null)
          {
            menuItems.addElement((object) new Command(mResources.move_to_chest, (IActionListener) this, 1001, (object) p));
            if (p.isTypeBody())
              menuItems.addElement((object) new Command(mResources.USE, (IActionListener) this, 2000, (object) p));
            else
              menuItems.addElement((object) new Command(mResources.USE, (IActionListener) this, 2001, (object) p));
            this.currItem = p;
          }
        }
        else
        {
          Item p = Char.myCharz().arrItemBody[this.GetInventorySelect_body(this.selected, this.newSelected)];
          if (p != null)
          {
            menuItems.addElement((object) new Command(mResources.move_to_chest2, (IActionListener) this, 1002, (object) p));
            this.currItem = p;
          }
        }
      }
    }
    if (this.currItem != null)
    {
      Char.myCharz().setPartTemp(this.currItem.headTemp, this.currItem.bodyTemp, this.currItem.legTemp, this.currItem.bagTemp);
      if (this.isBoxClan)
        menuItems.addElement((object) new Command(mResources.MOVEOUT, (IActionListener) this, 2011, (object) this.currItem));
      GameCanvas.menu.startAt(menuItems, this.X, (this.selected + 1) * this.ITEM_HEIGHT - this.cmy + this.yScroll);
      this.addItemDetail(this.currItem);
    }
    else
      this.cp = (ChatPopup) null;
  }

  public void itemRequest(sbyte itemAction, string info, sbyte where, sbyte index)
  {
    GameCanvas.endDlg();
    GameCanvas.startYesNoDlg(info, new Command(mResources.YES, (IActionListener) this, 2004, (object) new ItemObject()
    {
      type = (int) itemAction,
      id = (int) index,
      where = (int) where
    }), new Command(mResources.NO, (IActionListener) this, 4005, (object) null));
  }

  public void saleRequest(sbyte type, string info, short id) => GameCanvas.startYesNoDlg(info, new Command(mResources.YES, (IActionListener) this, 3003, (object) new ItemObject()
  {
    type = (int) type,
    id = (int) id
  }), new Command(mResources.NO, (IActionListener) this, 4005, (object) null));

  public void perform(int idAction, object p)
  {
    if (idAction == 9999)
    {
      TopInfo topInfo = (TopInfo) p;
      Service.gI().sendThachDau(topInfo.pId);
    }
    if (idAction == 170391)
    {
      Rms.clearAll();
      if (mGraphics.zoomLevel > 1)
        Rms.saveRMSInt("levelScreenKN", 1);
      else
        Rms.saveRMSInt("levelScreenKN", 0);
      GameMidlet.instance.exit();
    }
    if (idAction == 6001)
    {
      Item o = (Item) p;
      o.isSelect = false;
      GameCanvas.panel.vItemCombine.removeElement((object) o);
      if (GameCanvas.panel.currentTabIndex == 0)
        GameCanvas.panel.setTabCombine();
    }
    if (idAction == 6000)
    {
      Item o = (Item) p;
      for (int index = 0; index < GameCanvas.panel.vItemCombine.size(); ++index)
      {
        if ((int) ((Item) GameCanvas.panel.vItemCombine.elementAt(index)).template.id == (int) o.template.id)
        {
          GameCanvas.startOKDlg(mResources.already_has_item);
          return;
        }
      }
      o.isSelect = true;
      GameCanvas.panel.vItemCombine.addElement((object) o);
      if (GameCanvas.panel.currentTabIndex == 0)
        GameCanvas.panel.setTabCombine();
    }
    if (idAction == 7000)
    {
      if (this.isLock)
      {
        GameCanvas.startOKDlg(mResources.unlock_item_to_trade);
        return;
      }
      Item obj = (Item) p;
      for (int index = 0; index < GameCanvas.panel.vMyGD.size(); ++index)
      {
        if (((Item) GameCanvas.panel.vMyGD.elementAt(index)).indexUI == obj.indexUI)
        {
          GameCanvas.startOKDlg(mResources.already_has_item);
          return;
        }
      }
      if (obj.quantity > 1)
      {
        this.putQuantily();
        return;
      }
      obj.isSelect = true;
      Item o = new Item();
      o.template = obj.template;
      o.itemOption = obj.itemOption;
      o.indexUI = obj.indexUI;
      GameCanvas.panel.vMyGD.addElement((object) o);
      Service.gI().giaodich((sbyte) 2, -1, (sbyte) o.indexUI, o.quantity);
    }
    if (idAction == 7001)
    {
      Item o = (Item) p;
      o.isSelect = false;
      GameCanvas.panel.vMyGD.removeElement((object) o);
      if (GameCanvas.panel.currentTabIndex == 1)
        GameCanvas.panel.setTabGiaoDich(true);
      Service.gI().giaodich((sbyte) 4, -1, (sbyte) o.indexUI, -1);
    }
    if (idAction == 7002)
    {
      this.isAccept = true;
      GameCanvas.endDlg();
      Service.gI().giaodich((sbyte) 7, -1, (sbyte) -1, -1);
      this.hide();
    }
    if (idAction == 8003)
    {
      InfoItem infoItem = (InfoItem) p;
      Service.gI().friend((sbyte) 1, infoItem.charInfo.charID);
      if (this.type != 8)
        ;
    }
    if (idAction == 8002)
    {
      InfoItem infoItem = (InfoItem) p;
      Service.gI().friend((sbyte) 2, infoItem.charInfo.charID);
    }
    if (idAction == 8004)
    {
      InfoItem infoItem = (InfoItem) p;
      Service.gI().gotoPlayer(infoItem.charInfo.charID);
    }
    if (idAction == 8001)
    {
      Res.outz("chat player");
      InfoItem infoItem = (InfoItem) p;
      if (this.chatTField == null)
      {
        this.chatTField = new ChatTextField();
        this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
        this.chatTField.initChatTextField();
        this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
      }
      this.chatTField.strChat = mResources.chat_player;
      this.chatTField.tfChat.name = mResources.chat_with + " " + infoItem.charInfo.cName;
      this.chatTField.to = string.Empty;
      this.chatTField.isShow = true;
      this.chatTField.tfChat.isFocus = true;
      this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
      if (Main.isWindowsPhone)
        this.chatTField.tfChat.strInfo = this.chatTField.strChat;
      if (!Main.isPC)
        this.chatTField.startChat2((IChatable) this, string.Empty);
    }
    if (idAction == 1000)
      Service.gI().getItem(Panel.BOX_BAG, (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected));
    if (idAction == 1001)
    {
      sbyte inventorySelectBag = (sbyte) this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      Service.gI().getItem(Panel.BAG_BOX, inventorySelectBag);
    }
    if (idAction == 1003)
      this.hide();
    if (idAction == 1002)
      Service.gI().getItem(Panel.BODY_BOX, (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected));
    if (idAction == 2011)
      Service.gI().useItem((sbyte) 1, (sbyte) 2, (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected), (short) -1);
    if (idAction == 2010)
    {
      Service.gI().useItem((sbyte) 0, (sbyte) 2, (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected), (short) -1);
      Item obj = (Item) p;
      if (obj != null && (obj.template.id == (short) 193 || obj.template.id == (short) 194))
        GameCanvas.panel.hide();
    }
    if (idAction == 2000)
    {
      sbyte inventorySelectBag = (sbyte) this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      Service.gI().getItem(Panel.BAG_BODY, inventorySelectBag);
    }
    if (idAction == 2001)
    {
      Res.outz("use item");
      Item obj = (Item) p;
      bool inventorySelectIsbody = this.GetInventorySelect_isbody(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      sbyte index = inventorySelectIsbody ? (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected) : (sbyte) this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      Service.gI().useItem((sbyte) 0, !inventorySelectIsbody ? (sbyte) 1 : (sbyte) 0, index, (short) -1);
      if (obj.template.id == (short) 193 || obj.template.id == (short) 194)
        GameCanvas.panel.hide();
    }
    if (idAction == 2002)
      Service.gI().getItem(Panel.BODY_BAG, (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected));
    if (idAction == 2003)
    {
      Res.outz("remove item");
      bool inventorySelectIsbody = this.GetInventorySelect_isbody(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      sbyte index = inventorySelectIsbody ? (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected) : (sbyte) this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      Service.gI().useItem((sbyte) 1, !inventorySelectIsbody ? (sbyte) 1 : (sbyte) 0, index, (short) -1);
    }
    if (idAction == 2004)
    {
      GameCanvas.endDlg();
      ItemObject itemObject = (ItemObject) p;
      sbyte where = (sbyte) itemObject.where;
      sbyte id = (sbyte) itemObject.id;
      Service.gI().useItem(itemObject.type != 0 ? (sbyte) 2 : (sbyte) 3, where, id, (short) -1);
    }
    if (idAction == 2005)
    {
      sbyte inventorySelectBag = (sbyte) this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      Service.gI().getItem(Panel.BAG_PET, inventorySelectBag);
    }
    if (idAction == 2006)
    {
      Item[] arrItemBody = Char.myPetz().arrItemBody;
      sbyte selected = (sbyte) this.selected;
      Service.gI().getItem(Panel.PET_BAG, selected);
    }
    if (idAction == 30001)
    {
      Res.outz("nhan do");
      Service.gI().buyItem((sbyte) 0, this.selected, 0);
    }
    if (idAction == 30002)
    {
      Res.outz("xoa do");
      Service.gI().buyItem((sbyte) 1, this.selected, 0);
    }
    if (idAction == 30003)
    {
      Res.outz("nhan tat");
      Service.gI().buyItem((sbyte) 2, this.selected, 0);
    }
    if (idAction == 3000)
    {
      Res.outz("mua do");
      Item obj = (Item) p;
      Service.gI().buyItem((sbyte) 0, (int) obj.template.id, 0);
    }
    if (idAction == 3001)
    {
      Item obj = (Item) p;
      GameCanvas.msgdlg.pleasewait();
      Service.gI().buyItem((sbyte) 1, (int) obj.template.id, 0);
    }
    if (idAction == 3002)
    {
      GameCanvas.endDlg();
      bool inventorySelectIsbody = this.GetInventorySelect_isbody(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      sbyte id = inventorySelectIsbody ? (sbyte) this.GetInventorySelect_body(this.selected, this.newSelected) : (sbyte) this.GetInventorySelect_bag(this.selected, this.newSelected, Char.myCharz().arrItemBody);
      Service.gI().saleItem((sbyte) 0, !inventorySelectIsbody ? (sbyte) 1 : (sbyte) 0, (short) id);
    }
    if (idAction == 3003)
    {
      GameCanvas.endDlg();
      ItemObject itemObject = (ItemObject) p;
      Service.gI().saleItem((sbyte) 1, (sbyte) itemObject.type, (short) itemObject.id);
    }
    if (idAction == 3004)
    {
      Item obj = (Item) p;
      Service.gI().buyItem((sbyte) 3, (int) obj.template.id, 0);
    }
    if (idAction == 3005)
    {
      Res.outz("mua do");
      Item obj = (Item) p;
      Service.gI().buyItem((sbyte) 3, (int) obj.template.id, 0);
    }
    if (idAction == 4000)
    {
      Clan clan = (Clan) p;
      if (clan != null)
      {
        GameCanvas.endDlg();
        Service.gI().clanMessage(2, (string) null, clan.ID);
      }
    }
    if (idAction == 4001)
    {
      Clan clan = (Clan) p;
      if (clan != null)
      {
        InfoDlg.showWait();
        this.clanReport = mResources.PLEASEWAIT;
        Service.gI().clanMember(clan.ID);
      }
    }
    if (idAction == 4005)
      GameCanvas.endDlg();
    if (idAction == 4007)
      GameCanvas.endDlg();
    if (idAction == 4006)
    {
      ClanMessage clanMessage = (ClanMessage) p;
      Service.gI().clanDonate(clanMessage.id);
    }
    if (idAction == 5001)
    {
      Member member = (Member) p;
      Service.gI().clanRemote(member.ID, (sbyte) 0);
    }
    if (idAction == 5002)
    {
      Member member = (Member) p;
      Service.gI().clanRemote(member.ID, (sbyte) 1);
    }
    if (idAction == 5003)
    {
      Member member = (Member) p;
      Service.gI().clanRemote(member.ID, (sbyte) 2);
    }
    if (idAction == 5004)
    {
      Member member = (Member) p;
      Service.gI().clanRemote(member.ID, (sbyte) -1);
    }
    if (idAction == 9000)
    {
      Service.gI().upPotential(this.selected, 1);
      GameCanvas.endDlg();
      InfoDlg.showWait();
    }
    if (idAction == 9006)
    {
      Service.gI().upPotential(this.selected, 10);
      GameCanvas.endDlg();
      InfoDlg.showWait();
    }
    if (idAction == 9007)
    {
      Service.gI().upPotential(this.selected, 100);
      GameCanvas.endDlg();
      InfoDlg.showWait();
    }
    if (idAction == 9002)
    {
      Skill skill = (Skill) p;
      GameCanvas.startOKDlg(mResources.can_buy_from_Uron1 + (object) skill.powRequire + mResources.can_buy_from_Uron2 + skill.moreInfo + mResources.can_buy_from_Uron3);
    }
    if (idAction == 9003)
    {
      if (GameCanvas.isTouch && !Main.isPC)
        GameScr.gI().doSetOnScreenSkill((SkillTemplate) p);
      else
        GameScr.gI().doSetKeySkill((SkillTemplate) p);
    }
    if (idAction == 9004)
    {
      Skill skill = (Skill) p;
      GameCanvas.startOKDlg(mResources.can_buy_from_Uron1 + (object) skill.powRequire + mResources.can_buy_from_Uron2 + skill.moreInfo + mResources.can_buy_from_Uron3);
    }
    if (idAction == 10000)
    {
      InfoItem infoItem = (InfoItem) p;
      Service.gI().enemy((sbyte) 1, infoItem.charInfo.charID);
      GameCanvas.panel.hideNow();
    }
    if (idAction == 10001)
    {
      InfoItem infoItem = (InfoItem) p;
      Service.gI().enemy((sbyte) 2, infoItem.charInfo.charID);
      InfoDlg.showWait();
    }
    if (idAction != 10021)
      ;
    if (idAction == 10012)
    {
      if (this.chatTField == null)
      {
        this.chatTField = new ChatTextField();
        this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
        this.chatTField.initChatTextField();
        this.chatTField.parentScreen = GameCanvas.panel2 != null ? (IChatable) GameCanvas.panel2 : (IChatable) GameCanvas.panel;
      }
      if (this.currItem.quantity == 1)
      {
        this.chatTField.strChat = mResources.kiguiXuchat;
        this.chatTField.tfChat.name = mResources.input_money;
      }
      else
      {
        this.chatTField.strChat = mResources.input_quantity + " ";
        this.chatTField.tfChat.name = mResources.input_quantity;
      }
      this.chatTField.tfChat.setMaxTextLenght(9);
      this.chatTField.to = string.Empty;
      this.chatTField.isShow = true;
      this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
      if (GameCanvas.isTouch)
        this.chatTField.tfChat.doChangeToTextBox();
      if (Main.isWindowsPhone)
        this.chatTField.tfChat.strInfo = this.chatTField.strChat;
      if (!Main.isPC)
        this.chatTField.startChat2((IChatable) this, string.Empty);
    }
    if (idAction == 10013)
    {
      if (this.chatTField == null)
      {
        this.chatTField = new ChatTextField();
        this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
        this.chatTField.initChatTextField();
        this.chatTField.parentScreen = GameCanvas.panel2 != null ? (IChatable) GameCanvas.panel2 : (IChatable) GameCanvas.panel;
      }
      if (this.currItem.quantity == 1)
      {
        this.chatTField.strChat = mResources.kiguiLuongchat;
        this.chatTField.tfChat.name = mResources.input_money;
      }
      else
      {
        this.chatTField.strChat = mResources.input_quantity + "  ";
        this.chatTField.tfChat.name = mResources.input_quantity;
      }
      this.chatTField.to = string.Empty;
      this.chatTField.isShow = true;
      this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
      if (GameCanvas.isTouch)
        this.chatTField.tfChat.doChangeToTextBox();
      if (Main.isWindowsPhone)
        this.chatTField.tfChat.strInfo = this.chatTField.strChat;
      if (!Main.isPC)
        this.chatTField.startChat2((IChatable) this, string.Empty);
    }
    if (idAction == 10014)
    {
      Item obj = (Item) p;
      Service.gI().kigui((sbyte) 1, obj.itemId, (sbyte) -1, -1, -1);
      InfoDlg.showWait();
    }
    if (idAction == 10015)
    {
      Item obj = (Item) p;
      Service.gI().kigui((sbyte) 2, obj.itemId, (sbyte) -1, -1, -1);
      InfoDlg.showWait();
    }
    if (idAction == 10016)
    {
      Item obj = (Item) p;
      Service.gI().kigui((sbyte) 3, obj.itemId, (sbyte) 0, obj.buyCoin, -1);
      InfoDlg.showWait();
    }
    if (idAction == 10017)
    {
      Item obj = (Item) p;
      Service.gI().kigui((sbyte) 3, obj.itemId, (sbyte) 1, obj.buyGold, -1);
      InfoDlg.showWait();
    }
    if (idAction == 10018)
    {
      Item obj = (Item) p;
      Service.gI().kigui((sbyte) 5, obj.itemId, (sbyte) -1, -1, -1);
      InfoDlg.showWait();
    }
    if (idAction == 10019)
    {
      Session_ME.gI().close();
      Rms.saveRMSString("acc", string.Empty);
      Rms.saveRMSString("pass", string.Empty);
      GameCanvas.loginScr.tfPass.setText(string.Empty);
      GameCanvas.loginScr.tfUser.setText(string.Empty);
      GameCanvas.loginScr.isLogin2 = false;
      GameCanvas.loginScr.switchToMe();
      GameCanvas.endDlg();
      this.hide();
    }
    if (idAction == 10020)
      GameCanvas.endDlg();
    if (idAction == 10030)
    {
      Service.gI().getFlag((sbyte) 1, (sbyte) this.selected);
      GameCanvas.panel.hideNow();
    }
    if (idAction == 10031)
      Session_ME.gI().close();
    if (idAction == 11000)
    {
      Service.gI().kigui((sbyte) 0, this.currItem.itemId, (sbyte) 1, this.currItem.buyRuby, 1);
      GameCanvas.endDlg();
    }
    if (idAction == 11001)
    {
      Service.gI().kigui((sbyte) 0, this.currItem.itemId, (sbyte) 1, this.currItem.buyRuby, this.currItem.quantilyToBuy);
      GameCanvas.endDlg();
    }
    if (idAction != 11002)
      return;
    this.chatTField.isShow = false;
    GameCanvas.endDlg();
  }

  public void onChatFromMe(string text, string to)
  {
    if (this.chatTField.tfChat.getText() == null || this.chatTField.tfChat.getText().Equals(string.Empty) || text.Equals(string.Empty) || text == null)
      this.chatTField.isShow = false;
    else if (this.chatTField.strChat.Equals(mResources.input_clan_name))
    {
      InfoDlg.showWait();
      this.chatTField.isShow = false;
      Service.gI().searchClan(text);
    }
    else if (this.chatTField.strChat.Equals(mResources.chat_clan))
    {
      InfoDlg.showWait();
      this.chatTField.isShow = false;
      Service.gI().clanMessage(0, text, -1);
    }
    else if (this.chatTField.strChat.Equals(mResources.input_clan_name_to_create))
    {
      if (this.chatTField.tfChat.getText() == string.Empty)
      {
        GameScr.info1.addInfo(mResources.clan_name_blank, 0);
      }
      else
      {
        if (this.tabIcon == null)
          this.tabIcon = new TabClanIcon();
        this.tabIcon.text = this.chatTField.tfChat.getText();
        this.tabIcon.show(false);
        this.chatTField.isShow = false;
      }
    }
    else if (this.chatTField.strChat.Equals(mResources.input_clan_slogan))
    {
      if (this.chatTField.tfChat.getText() == string.Empty)
      {
        GameScr.info1.addInfo(mResources.clan_slogan_blank, 0);
      }
      else
      {
        Service.gI().getClan((sbyte) 4, (sbyte) Char.myCharz().clan.imgID, this.chatTField.tfChat.getText());
        this.chatTField.isShow = false;
      }
    }
    else if (this.chatTField.strChat.Equals(mResources.input_Inventory_Pass))
    {
      try
      {
        int pass = int.Parse(this.chatTField.tfChat.getText());
        if (this.chatTField.tfChat.getText().Length != 6 || this.chatTField.tfChat.getText().Equals(string.Empty))
        {
          GameCanvas.startOKDlg(mResources.input_Inventory_Pass_wrong);
        }
        else
        {
          Service.gI().setLockInventory(pass);
          this.chatTField.isShow = false;
          this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
          this.hide();
        }
      }
      catch (Exception ex)
      {
        GameCanvas.startOKDlg(mResources.ALERT_PRIVATE_PASS_2);
      }
    }
    else if (this.chatTField.strChat.Equals(mResources.world_channel_5_luong))
    {
      if (this.chatTField.tfChat.getText().Equals(string.Empty))
        return;
      Service.gI().chatGlobal(this.chatTField.tfChat.getText());
      this.chatTField.isShow = false;
      this.hide();
    }
    else if (this.chatTField.strChat.Equals(mResources.chat_player))
    {
      this.chatTField.isShow = false;
      InfoItem infoItem = (InfoItem) null;
      if (this.type == 8)
        infoItem = (InfoItem) this.logChat.elementAt(this.currInfoItem);
      else if (this.type == 11)
        infoItem = (InfoItem) this.vFriend.elementAt(this.currInfoItem);
      if (infoItem.charInfo.charID == Char.myCharz().charID)
        return;
      Service.gI().chatPlayer(text, infoItem.charInfo.charID);
    }
    else if (this.chatTField.strChat.Equals(mResources.input_quantity_to_trade))
    {
      int num;
      try
      {
        num = int.Parse(this.chatTField.tfChat.getText());
      }
      catch (Exception ex)
      {
        GameCanvas.startOKDlg(mResources.input_quantity_wrong);
        this.chatTField.isShow = false;
        this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
        return;
      }
      if (num <= 0 || num > this.currItem.quantity)
      {
        GameCanvas.startOKDlg(mResources.input_quantity_wrong);
        this.chatTField.isShow = false;
        this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
      }
      else
      {
        this.currItem.isSelect = true;
        Item o = new Item();
        o.template = this.currItem.template;
        o.quantity = num;
        o.indexUI = this.currItem.indexUI;
        o.itemOption = this.currItem.itemOption;
        GameCanvas.panel.vMyGD.addElement((object) o);
        Service.gI().giaodich((sbyte) 2, -1, (sbyte) o.indexUI, o.quantity);
        this.chatTField.isShow = false;
        this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
      }
    }
    else if (this.chatTField.strChat == mResources.input_money_to_trade)
    {
      int num;
      try
      {
        num = int.Parse(this.chatTField.tfChat.getText());
      }
      catch (Exception ex)
      {
        GameCanvas.startOKDlg(mResources.input_money_wrong);
        this.chatTField.isShow = false;
        this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
        return;
      }
      if ((long) num > Char.myCharz().xu)
      {
        GameCanvas.startOKDlg(mResources.not_enough_money);
        this.chatTField.isShow = false;
        this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
      }
      else
      {
        this.moneyGD = num;
        Service.gI().giaodich((sbyte) 2, -1, (sbyte) -1, num);
        this.chatTField.isShow = false;
        this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);
      }
    }
    else if (this.chatTField.strChat.Equals(mResources.kiguiXuchat))
    {
      Service.gI().kigui((sbyte) 0, this.currItem.itemId, (sbyte) 0, int.Parse(this.chatTField.tfChat.getText()), 1);
      this.chatTField.isShow = false;
    }
    else if (this.chatTField.strChat.Equals(mResources.kiguiXuchat + " "))
    {
      Service.gI().kigui((sbyte) 0, this.currItem.itemId, (sbyte) 0, int.Parse(this.chatTField.tfChat.getText()), this.currItem.quantilyToBuy);
      this.chatTField.isShow = false;
    }
    else if (this.chatTField.strChat.Equals(mResources.kiguiLuongchat))
    {
      this.doNotiRuby(0);
      this.chatTField.isShow = false;
    }
    else if (this.chatTField.strChat.Equals(mResources.kiguiLuongchat + "  "))
    {
      this.doNotiRuby(1);
      this.chatTField.isShow = false;
    }
    else if (this.chatTField.strChat.Equals(mResources.input_quantity + " "))
    {
      this.currItem.quantilyToBuy = int.Parse(this.chatTField.tfChat.getText());
      if (this.currItem.quantilyToBuy > this.currItem.quantity)
      {
        GameCanvas.startOKDlg(mResources.input_quantity_wrong);
      }
      else
      {
        this.isKiguiXu = true;
        this.chatTField.isShow = false;
      }
    }
    else
    {
      if (!this.chatTField.strChat.Equals(mResources.input_quantity + "  "))
        return;
      this.currItem.quantilyToBuy = int.Parse(this.chatTField.tfChat.getText());
      if (this.currItem.quantilyToBuy > this.currItem.quantity)
      {
        GameCanvas.startOKDlg(mResources.input_quantity_wrong);
      }
      else
      {
        this.isKiguiLuong = true;
        this.chatTField.isShow = false;
      }
    }
  }

  public void onCancelChat() => this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_ANY);

  public void setCombineEff(int type)
  {
    this.typeCombine = type;
    this.rS = 90;
    if (this.typeCombine == 0)
    {
      this.iDotS = 5;
      this.angleS = this.angleO = 90;
      this.time = 2;
      for (int index = 0; index < this.vItemCombine.size(); ++index)
      {
        Item obj = (Item) this.vItemCombine.elementAt(index);
        if (obj != null)
        {
          if (obj.template.type == (sbyte) 14)
            this.iconID2 = obj.template.iconID;
          else
            this.iconID1 = obj.template.iconID;
        }
      }
    }
    else if (this.typeCombine == 1)
    {
      this.iDotS = 2;
      this.angleS = this.angleO = 0;
      this.time = 1;
      for (int index = 0; index < this.vItemCombine.size(); ++index)
      {
        Item obj = (Item) this.vItemCombine.elementAt(index);
        if (obj != null)
        {
          if (index == 0)
            this.iconID1 = obj.template.iconID;
          else
            this.iconID2 = obj.template.iconID;
        }
      }
    }
    else if (this.typeCombine == 2)
    {
      this.iDotS = 7;
      this.angleS = this.angleO = 25;
      this.time = 1;
      for (int index = 0; index < this.vItemCombine.size(); ++index)
      {
        Item obj = (Item) this.vItemCombine.elementAt(index);
        if (obj != null)
          this.iconID1 = obj.template.iconID;
      }
    }
    else if (this.typeCombine == 3)
    {
      this.xS = GameCanvas.hw;
      this.yS = GameCanvas.hh;
      this.iDotS = 1;
      this.angleS = this.angleO = 1;
      this.time = 4;
      for (int index = 0; index < this.vItemCombine.size(); ++index)
      {
        Item obj = (Item) this.vItemCombine.elementAt(index);
        if (obj != null)
          this.iconID1 = obj.template.iconID;
      }
    }
    else if (this.typeCombine == 4)
    {
      this.iDotS = this.vItemCombine.size();
      this.iconID = new short[this.iDotS];
      this.angleS = this.angleO = 25;
      this.time = 1;
      for (int index = 0; index < this.vItemCombine.size(); ++index)
      {
        Item obj = (Item) this.vItemCombine.elementAt(index);
        if (obj != null)
          this.iconID[index] = obj.template.iconID;
      }
    }
    this.speed = 1;
    this.isSpeedCombine = true;
    this.isDoneCombine = false;
    this.isCompleteEffCombine = false;
    this.iAngleS = 360 / this.iDotS;
    this.xArgS = new int[this.iDotS];
    this.yArgS = new int[this.iDotS];
    this.xDotS = new int[this.iDotS];
    this.yDotS = new int[this.iDotS];
    this.setDotStar();
    this.isPaintCombine = true;
    this.countUpdate = 10;
    this.countR = 30;
    this.countWait = 10;
    this.addTextCombineNPC(this.idNPC, mResources.combineSpell);
  }

  private void updateCombineEff()
  {
    --this.countUpdate;
    if (this.countUpdate < 0)
      this.countUpdate = 0;
    --this.countR;
    if (this.countR < 0)
      this.countR = 0;
    if (this.countUpdate != 0)
      return;
    if (!this.isCompleteEffCombine)
    {
      if (this.time > 0)
      {
        if (this.combineSuccess != (sbyte) -1)
        {
          if (this.typeCombine == 3)
          {
            if (GameCanvas.gameTick % 10 == 0)
            {
              EffecMn.addEff(new Effect(21, this.xS - 10, this.yS + 25, 4, 1, 1));
              --this.time;
            }
          }
          else
          {
            if (GameCanvas.gameTick % 2 == 0)
            {
              if (this.isSpeedCombine)
              {
                if (this.speed < 40)
                  this.speed += 2;
              }
              else if (this.speed > 10)
                this.speed -= 2;
            }
            if (this.countR == 0)
            {
              if (this.isSpeedCombine)
              {
                if (this.rS > 0)
                  this.rS -= 5;
                else if (GameCanvas.gameTick % 10 == 0)
                {
                  this.isSpeedCombine = false;
                  --this.time;
                  this.countR = 5;
                  this.countWait = 10;
                }
              }
              else if (this.rS < 90)
                this.rS += 5;
              else if (GameCanvas.gameTick % 10 == 0)
              {
                this.isSpeedCombine = true;
                this.countR = 10;
              }
            }
            this.angleS = this.angleO;
            this.angleS -= this.speed;
            if (this.angleS >= 360)
              this.angleS -= 360;
            if (this.angleS < 0)
              this.angleS = 360 + this.angleS;
            this.angleO = this.angleS;
            this.setDotStar();
          }
        }
      }
      else if (GameCanvas.gameTick % 20 == 0)
        this.isCompleteEffCombine = true;
      if (GameCanvas.gameTick % 20 != 0)
        return;
      if (this.typeCombine != 3)
        EffectPanel.addServerEffect(132, this.xS, this.yS, 2);
      EffectPanel.addServerEffect(114, this.xS, this.yS + 20, 2);
    }
    else
    {
      if (!this.isCompleteEffCombine)
        return;
      if (this.combineSuccess == (sbyte) 1)
      {
        if (this.countWait == 10)
          EffecMn.addEff(new Effect(22, this.xS - 3, this.yS + 25, 4, 1, 1));
        --this.countWait;
        if (this.countWait < 0)
          this.countWait = 0;
        if (this.rS < 300)
        {
          this.rS = Res.abs(this.rS + 10);
          if (this.rS == 20)
            this.addTextCombineNPC(this.idNPC, mResources.combineFail);
        }
        else if (GameCanvas.gameTick % 20 == 0)
        {
          if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
          {
            GameCanvas.panel2 = new Panel();
            GameCanvas.panel2.tabName[7] = new string[1][]
            {
              new string[1]{ string.Empty }
            };
            GameCanvas.panel2.setTypeBodyOnly();
            GameCanvas.panel2.show();
          }
          this.combineSuccess = (sbyte) -1;
          this.isDoneCombine = true;
          if (this.typeCombine == 4)
            GameCanvas.panel.hideNow();
        }
        this.setDotStar();
      }
      else
      {
        if (this.combineSuccess != (sbyte) 0)
          return;
        if (this.countWait == 10)
        {
          if (this.typeCombine == 2)
            EffecMn.addEff(new Effect(20, this.xS - 3, this.yS + 15, 4, 2, 1));
          else
            EffecMn.addEff(new Effect(21, this.xS - 10, this.yS + 25, 4, 1, 1));
          this.addTextCombineNPC(this.idNPC, mResources.combineSuccess);
          this.isPaintCombine = false;
        }
        if (this.isPaintCombine)
          return;
        --this.countWait;
        if (this.countWait >= -50)
          return;
        this.countWait = -50;
        if (this.typeCombine < 3 && GameCanvas.w > 2 * Panel.WIDTH_PANEL)
        {
          GameCanvas.panel2 = new Panel();
          GameCanvas.panel2.tabName[7] = new string[1][]
          {
            new string[1]{ string.Empty }
          };
          GameCanvas.panel2.setTypeBodyOnly();
          GameCanvas.panel2.show();
        }
        this.combineSuccess = (sbyte) -1;
        this.isDoneCombine = true;
        if (this.typeCombine != 4)
          return;
        GameCanvas.panel.hideNow();
      }
    }
  }

  public void paintCombineEff(mGraphics g)
  {
    GameScr.gI().paintBlackSky(g);
    this.paintCombineNPC(g);
    if (this.typeCombine == 0)
    {
      for (int index = 0; index < this.yArgS.Length; ++index)
      {
        SmallImage.drawSmallImage(g, (int) this.iconID1, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
        if (this.isPaintCombine)
          SmallImage.drawSmallImage(g, (int) this.iconID2, this.xDotS[index], this.yDotS[index], 0, mGraphics.VCENTER | mGraphics.HCENTER);
      }
    }
    else if (this.typeCombine == 1)
    {
      if (!this.isPaintCombine)
      {
        SmallImage.drawSmallImage(g, (int) this.iconID3, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
      }
      else
      {
        for (int index = 0; index < this.yArgS.Length; ++index)
        {
          SmallImage.drawSmallImage(g, (int) this.iconID1, this.xDotS[0], this.yDotS[0], 0, mGraphics.VCENTER | mGraphics.HCENTER);
          SmallImage.drawSmallImage(g, (int) this.iconID2, this.xDotS[1], this.yDotS[1], 0, mGraphics.VCENTER | mGraphics.HCENTER);
        }
      }
    }
    else if (this.typeCombine == 2)
    {
      if (!this.isPaintCombine)
      {
        SmallImage.drawSmallImage(g, (int) this.iconID3, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
      }
      else
      {
        for (int index = 0; index < this.yArgS.Length; ++index)
          SmallImage.drawSmallImage(g, (int) this.iconID1, this.xDotS[index], this.yDotS[index], 0, mGraphics.VCENTER | mGraphics.HCENTER);
      }
    }
    else if (this.typeCombine == 3)
    {
      if (!this.isPaintCombine)
        SmallImage.drawSmallImage(g, (int) this.iconID3, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
      else
        SmallImage.drawSmallImage(g, (int) this.iconID1, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
    }
    else
    {
      if (this.typeCombine != 4)
        return;
      if (!this.isPaintCombine)
      {
        if (this.iconID3 == (short) -1)
          return;
        SmallImage.drawSmallImage(g, (int) this.iconID3, this.xS, this.yS, 0, mGraphics.VCENTER | mGraphics.HCENTER);
      }
      else
      {
        for (int index = 0; index < this.iconID.Length; ++index)
          SmallImage.drawSmallImage(g, (int) this.iconID[index], this.xDotS[index], this.yDotS[index], 0, mGraphics.VCENTER | mGraphics.HCENTER);
      }
    }
  }

  private void setDotStar()
  {
    for (int index = 0; index < this.yArgS.Length; ++index)
    {
      if (this.angleS >= 360)
        this.angleS -= 360;
      if (this.angleS < 0)
        this.angleS = 360 + this.angleS;
      this.yArgS[index] = Res.abs(this.rS * Res.sin(this.angleS) / 1024);
      this.xArgS[index] = Res.abs(this.rS * Res.cos(this.angleS) / 1024);
      if (this.angleS < 90)
      {
        this.xDotS[index] = this.xS + this.xArgS[index];
        this.yDotS[index] = this.yS - this.yArgS[index];
      }
      else if (this.angleS >= 90 && this.angleS < 180)
      {
        this.xDotS[index] = this.xS - this.xArgS[index];
        this.yDotS[index] = this.yS - this.yArgS[index];
      }
      else if (this.angleS >= 180 && this.angleS < 270)
      {
        this.xDotS[index] = this.xS - this.xArgS[index];
        this.yDotS[index] = this.yS + this.yArgS[index];
      }
      else
      {
        this.xDotS[index] = this.xS + this.xArgS[index];
        this.yDotS[index] = this.yS + this.yArgS[index];
      }
      this.angleS -= this.iAngleS;
    }
  }

  public void paintCombineNPC(mGraphics g)
  {
    g.translate(-GameScr.cmx, -GameScr.cmy);
    if (this.typeCombine < 3)
    {
      for (int index = 0; index < GameScr.vNpc.size(); ++index)
      {
        Npc npc = (Npc) GameScr.vNpc.elementAt(index);
        if (npc.template.npcTemplateId == this.idNPC)
        {
          npc.paint(g);
          if (npc.chatInfo != null)
            npc.chatInfo.paint(g, npc.cx, npc.cy - npc.ch - GameCanvas.transY, npc.cdir);
        }
      }
    }
    GameCanvas.resetTrans(g);
    if (GameCanvas.gameTick % 4 == 0)
    {
      g.drawImage(ItemMap.imageFlare, this.xS - 5, this.yS + 15, mGraphics.BOTTOM | mGraphics.HCENTER);
      g.drawImage(ItemMap.imageFlare, this.xS + 5, this.yS + 15, mGraphics.BOTTOM | mGraphics.HCENTER);
      g.drawImage(ItemMap.imageFlare, this.xS, this.yS + 15, mGraphics.BOTTOM | mGraphics.HCENTER);
    }
    for (int index = 0; index < Effect2.vEffect3.size(); ++index)
      ((Effect2) Effect2.vEffect3.elementAt(index)).paint(g);
  }

  public void addTextCombineNPC(int idNPC, string text)
  {
    if (this.typeCombine >= 3)
      return;
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
    {
      Npc npc = (Npc) GameScr.vNpc.elementAt(index);
      if (npc.template.npcTemplateId == idNPC)
        npc.addInfo(text);
    }
  }

  public void setTypeOption()
  {
    this.type = 19;
    this.setType(0);
    this.setTabOption();
    this.cmx = this.cmtoX = 0;
  }

  private void setTabOption()
  {
    SoundMn.gI().getStrOption();
    this.currentListLength = Panel.strCauhinh.Length;
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy <= this.cmyLim)
      return;
    this.cmy = this.cmtoY = this.cmyLim;
  }

  private void paintOption(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index = 0; index < Panel.strCauhinh.Length; ++index)
    {
      int xScroll = this.xScroll;
      int y = this.yScroll + index * this.ITEM_HEIGHT;
      int w = this.wScroll - 1;
      int h = this.ITEM_HEIGHT - 1;
      if (y - this.cmy <= this.yScroll + this.hScroll && y - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(xScroll, y, w, h);
        mFont.tahoma_7b_dark.drawString(g, Panel.strCauhinh[index], this.xScroll + this.wScroll / 2, y + 6, mFont.CENTER);
      }
    }
    this.paintScrollArrow(g);
  }

  private void doFireOption()
  {
    if (this.selected < 0)
      return;
    switch (this.selected)
    {
      case 0:
        SoundMn.gI().HatToolOption();
        break;
      case 1:
        SoundMn.gI().AuraToolOption();
        break;
      case 2:
        SoundMn.gI().soundToolOption();
        break;
      case 3:
        if (Main.isPC)
        {
          GameCanvas.startYesNoDlg(mResources.changeSizeScreen, new Command(mResources.YES, (IActionListener) this, 170391, (object) null), new Command(mResources.NO, (IActionListener) this, 4005, (object) null));
          break;
        }
        if (GameScr.isAnalog == 0)
        {
          GameScr.isAnalog = 1;
          Rms.saveRMSInt("analog", GameScr.isAnalog);
          GameScr.setSkillBarPosition();
        }
        else
        {
          GameScr.isAnalog = 0;
          Rms.saveRMSInt("analog", GameScr.isAnalog);
          GameScr.setSkillBarPosition();
        }
        SoundMn.gI().getStrOption();
        break;
    }
  }

  public void setTypeAccount()
  {
    this.type = 20;
    this.setType(0);
    this.setTabAccount();
    this.cmx = this.cmtoX = 0;
  }

  private void setTabAccount()
  {
    if (Main.IphoneVersionApp)
    {
      Panel.strAccount = new string[4]
      {
        mResources.inventory_Pass,
        mResources.friend,
        mResources.enemy,
        mResources.msg
      };
      if (GameScr.canAutoPlay)
        Panel.strAccount = new string[5]
        {
          mResources.inventory_Pass,
          mResources.friend,
          mResources.enemy,
          mResources.msg,
          mResources.autoFunction
        };
    }
    else
    {
      Panel.strAccount = new string[5]
      {
        mResources.inventory_Pass,
        mResources.friend,
        mResources.enemy,
        mResources.msg,
        mResources.charger
      };
      if (GameScr.canAutoPlay)
        Panel.strAccount = new string[6]
        {
          mResources.inventory_Pass,
          mResources.friend,
          mResources.enemy,
          mResources.msg,
          mResources.charger,
          mResources.autoFunction
        };
      if ((mSystem.clientType == 2 || mSystem.clientType == 7) && mResources.language != (sbyte) 2)
      {
        Panel.strAccount = new string[5]
        {
          mResources.inventory_Pass,
          mResources.friend,
          mResources.enemy,
          mResources.msg,
          mResources.charger
        };
        if (GameScr.canAutoPlay)
          Panel.strAccount = new string[6]
          {
            mResources.inventory_Pass,
            mResources.friend,
            mResources.enemy,
            mResources.msg,
            mResources.charger,
            mResources.autoFunction
          };
      }
    }
    this.currentListLength = Panel.strAccount.Length;
    this.ITEM_HEIGHT = 24;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy <= this.cmyLim)
      return;
    this.cmy = this.cmtoY = this.cmyLim;
  }

  private void paintAccount(mGraphics g)
  {
    g.setClip(this.xScroll, this.yScroll, this.wScroll, this.hScroll);
    g.translate(0, -this.cmy);
    for (int index = 0; index < Panel.strAccount.Length; ++index)
    {
      int xScroll = this.xScroll;
      int y = this.yScroll + index * this.ITEM_HEIGHT;
      int w = this.wScroll - 1;
      int h = this.ITEM_HEIGHT - 1;
      if (y - this.cmy <= this.yScroll + this.hScroll && y - this.cmy >= this.yScroll - this.ITEM_HEIGHT)
      {
        g.setColor(index != this.selected ? 15196114 : 16383818);
        g.fillRect(xScroll, y, w, h);
        mFont.tahoma_7b_dark.drawString(g, Panel.strAccount[index], this.xScroll + this.wScroll / 2, y + 6, mFont.CENTER);
      }
    }
    this.paintScrollArrow(g);
  }

  private void doFireAccount()
  {
    if (this.selected < 0)
      return;
    switch (this.selected)
    {
      case 0:
        GameCanvas.endDlg();
        if (this.chatTField == null)
        {
          this.chatTField = new ChatTextField();
          this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
          this.chatTField.initChatTextField();
          this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
        }
        this.chatTField.tfChat.setText(string.Empty);
        this.chatTField.strChat = mResources.input_Inventory_Pass;
        this.chatTField.tfChat.name = mResources.input_Inventory_Pass;
        this.chatTField.to = string.Empty;
        this.chatTField.isShow = true;
        this.chatTField.tfChat.isFocus = true;
        this.chatTField.tfChat.setIputType(TField.INPUT_TYPE_NUMERIC);
        if (GameCanvas.isTouch)
          this.chatTField.tfChat.doChangeToTextBox();
        if (!Main.isPC)
          this.chatTField.startChat2((IChatable) this, string.Empty);
        if (!Main.isWindowsPhone)
          break;
        this.chatTField.tfChat.strInfo = this.chatTField.strChat;
        break;
      case 1:
        Service.gI().friend((sbyte) 0, -1);
        InfoDlg.showWait();
        break;
      case 2:
        Service.gI().enemy((sbyte) 0, -1);
        InfoDlg.showWait();
        break;
      case 3:
        this.setTypeMessage();
        if (this.chatTField != null)
          break;
        this.chatTField = new ChatTextField();
        this.chatTField.tfChat.y = GameCanvas.h - 35 - ChatTextField.gI().tfChat.height;
        this.chatTField.initChatTextField();
        this.chatTField.parentScreen = (IChatable) GameCanvas.panel;
        break;
      case 4:
        if (mResources.language == (sbyte) 2)
        {
          string url = "http://dragonball.indonaga.com/coda/?username=" + GameCanvas.loginScr.tfUser.getText();
          this.hideNow();
          try
          {
            GameMidlet.instance.platformRequest(url);
            break;
          }
          catch (Exception ex)
          {
            ex.StackTrace.ToString();
            break;
          }
        }
        else
        {
          this.hideNow();
          if (Char.myCharz().taskMaint.taskId <= (short) 10)
          {
            GameCanvas.startOKDlg(mResources.finishBomong);
            break;
          }
          MoneyCharge.gI().switchToMe();
          break;
        }
      case 5:
        this.setTypeAuto();
        break;
    }
  }

  private void updateKeyOption() => this.updateKeyScrollView();

  public void setTypeSpeacialSkill()
  {
    this.type = 25;
    this.setType(0);
    this.setTabSpeacialSkill();
    this.currentTabIndex = 0;
  }

  private void setTabSpeacialSkill()
  {
    this.ITEM_HEIGHT = 24;
    this.currentListLength = Char.myCharz().infoSpeacialSkill[this.currentTabIndex].Length;
    this.cmyLim = this.currentListLength * this.ITEM_HEIGHT - this.hScroll;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    this.cmy = this.cmtoY = this.cmyLast[this.currentTabIndex];
    if (this.cmy < 0)
      this.cmy = this.cmtoY = 0;
    if (this.cmy > this.cmyLim)
      this.cmy = this.cmtoY = this.cmyLim;
    this.selected = !GameCanvas.isTouch ? 0 : -1;
  }

  public bool isTypeShop() => this.type == 1;

  private void doNotiRuby(int type)
  {
    try
    {
      this.currItem.buyRuby = int.Parse(this.chatTField.tfChat.getText());
    }
    catch (Exception ex)
    {
      GameCanvas.startOKDlg(mResources.input_money_wrong);
      this.chatTField.isShow = false;
      return;
    }
    Command cmdYes = new Command(mResources.YES, (IActionListener) this, type != 0 ? 11001 : 11000, (object) null);
    Command cmdNo = new Command(mResources.NO, (IActionListener) this, 11002, (object) null);
    GameCanvas.startYesNoDlg(mResources.notiRuby, cmdYes, cmdNo);
  }

  public static void paintUpgradeEffect(
    int x,
    int y,
    int wItem,
    int hItem,
    int nline,
    int cl,
    mGraphics g)
  {
    try
    {
      int num = ((wItem << 1) + (hItem << 1)) / nline;
      Panel.nsize = Panel.sizeUpgradeEff.Length;
      if (nline > 4)
        Panel.nsize = 2;
      for (int index1 = 0; index1 < nline; ++index1)
      {
        for (int index2 = 0; index2 < Panel.nsize; ++index2)
        {
          int wSize = Panel.sizeUpgradeEff[index2] <= 1 ? 1 : (Panel.sizeUpgradeEff[index2] >> 1) + 1;
          int x1 = x + Panel.upgradeEffectX(num * index1, GameCanvas.gameTick - index2 * 4, wItem, hItem, wSize);
          int y1 = y + Panel.upgradeEffectY(num * index1, GameCanvas.gameTick - index2 * 4, wItem, hItem, wSize);
          g.setColor(Panel.colorUpgradeEffect[cl][index2]);
          g.fillRect(x1, y1, Panel.sizeUpgradeEff[index2], Panel.sizeUpgradeEff[index2]);
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  private static int upgradeEffectX(int dk, int tick, int wItem, int hitem, int wSize)
  {
    int num = (tick + dk) % ((wItem << 1) + (hitem << 1));
    if (0 <= num && num < wItem)
      return num % wItem;
    if (wItem <= num && num < wItem + hitem)
      return wItem - wSize;
    return wItem + hitem <= num && num < (wItem << 1) + hitem ? wItem - (num - hitem) % wItem - wSize : 0;
  }

  private static int upgradeEffectY(int dk, int tick, int wItem, int hitem, int wSize)
  {
    int num = (tick + dk) % ((wItem << 1) + (hitem << 1));
    if (0 <= num && num < wItem)
      return 0;
    if (wItem <= num && num < wItem + hitem)
      return num % wItem;
    return wItem + hitem <= num && num < (wItem << 1) + hitem ? hitem - wSize : hitem - (num - (wItem << 1)) % hitem - wSize;
  }

  public static int GetColor_ItemBg(int id)
  {
    switch (id)
    {
      case 1:
        return 2786816;
      case 2:
        return 7078041;
      case 3:
        return 12537346;
      case 4:
        return 1269146;
      case 5:
        return 13279744;
      case 6:
        return 11599872;
      default:
        return -1;
    }
  }

  public static sbyte GetColor_Item_Upgrade(int lv)
  {
    if (lv < 0)
      return 0;
    switch (lv)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
        return 0;
      case 9:
        return 4;
      case 10:
        return 1;
      case 11:
        return 5;
      case 12:
        return 3;
      case 13:
        return 2;
      default:
        return 6;
    }
  }

  public static mFont GetFont(int color)
  {
    mFont font = mFont.tahoma_7;
    switch (color + 1)
    {
      case 0:
        font = mFont.tahoma_7;
        break;
      case 1:
        font = mFont.tahoma_7b_dark;
        break;
      case 2:
        font = mFont.tahoma_7b_green;
        break;
      case 3:
        font = mFont.tahoma_7b_blue;
        break;
      case 4:
        font = mFont.tahoma_7_red;
        break;
      case 5:
        font = mFont.tahoma_7_green;
        break;
      case 6:
        font = mFont.tahoma_7_blue;
        break;
      case 8:
        font = mFont.tahoma_7b_red;
        break;
      case 9:
        font = mFont.tahoma_7b_yellow;
        break;
    }
    return font;
  }

  public void paintOptItem(mGraphics g, int idOpt, int param, int x, int y, int w, int h)
  {
    switch (idOpt)
    {
      case 34:
        if (this.imgo_0 != null)
          g.drawImage(this.imgo_0, x, y + h - this.imgo_0.getHeight());
        else
          this.imgo_0 = mSystem.loadImage("/mainImage/o_0.png");
        if (this.imgo_1 != null)
        {
          g.drawImage(this.imgo_1, x, y + h - this.imgo_1.getHeight());
          break;
        }
        this.imgo_1 = mSystem.loadImage("/mainImage/o_1.png");
        break;
      case 35:
        if (this.imgo_0 != null)
          g.drawImage(this.imgo_0, x, y + h - this.imgo_0.getHeight());
        else
          this.imgo_0 = mSystem.loadImage("/mainImage/o_0.png");
        if (this.imgo_2 != null)
        {
          g.drawImage(this.imgo_2, x, y + h - this.imgo_2.getHeight());
          break;
        }
        this.imgo_2 = mSystem.loadImage("/mainImage/o_2.png");
        break;
      case 36:
        if (this.imgo_0 != null)
          g.drawImage(this.imgo_0, x, y + h - this.imgo_0.getHeight());
        else
          this.imgo_0 = mSystem.loadImage("/mainImage/o_0.png");
        if (this.imgo_3 != null)
        {
          g.drawImage(this.imgo_3, x, y + h - this.imgo_3.getHeight());
          break;
        }
        this.imgo_3 = mSystem.loadImage("/mainImage/o_3.png");
        break;
    }
  }

  public void paintOptSlotItem(mGraphics g, int idOpt, int param, int x, int y, int w, int h)
  {
    if (idOpt != 102 || param <= ChatPopup.numSlot)
      return;
    sbyte colorItemUpgrade = Panel.GetColor_Item_Upgrade(param);
    int nline = param - ChatPopup.numSlot;
    Panel.paintUpgradeEffect(x, y, w, h, nline, (int) colorItemUpgrade, g);
  }

  public static mFont setTextColor(int id, int type)
  {
    if (type == 0)
    {
      switch (id)
      {
        case 0:
          return mFont.bigNumber_While;
        case 1:
          return mFont.bigNumber_green;
        case 3:
          return mFont.bigNumber_orange;
        case 4:
          return mFont.bigNumber_blue;
        case 5:
          return mFont.bigNumber_yellow;
        case 6:
          return mFont.bigNumber_red;
        default:
          return mFont.bigNumber_While;
      }
    }
    else
    {
      switch (id)
      {
        case 0:
          return mFont.tahoma_7b_white;
        case 1:
          return mFont.tahoma_7b_green;
        case 3:
          return mFont.tahoma_7b_yellowSmall2;
        case 4:
          return mFont.tahoma_7b_blue;
        case 5:
          return mFont.tahoma_7b_yellow;
        case 6:
          return mFont.tahoma_7b_red;
        case 7:
          return mFont.tahoma_7b_dark;
        default:
          return mFont.tahoma_7b_white;
      }
    }
  }

  private bool GetInventorySelect_isbody(int select, int subSelect, Item[] arrItem)
  {
    int num = select - 1 + subSelect * 20;
    return subSelect == 0 && num < arrItem.Length;
  }

  private int GetInventorySelect_body(int select, int subSelect) => select - 1 + subSelect * 20;

  private int GetInventorySelect_bag(int select, int subSelect, Item[] arrItem) => select - 1 + subSelect * 20 - arrItem.Length;

  private void updateKeyInvenTab()
  {
    if (this.selected < 0)
      return;
    if (GameCanvas.keyPressed[!Main.isPC ? 4 : 23])
    {
      --this.newSelected;
      if (this.newSelected >= 0)
        return;
      this.newSelected = 0;
      if (!GameCanvas.isFocusPanel2)
        return;
      GameCanvas.isFocusPanel2 = false;
      GameCanvas.panel.selected = 0;
    }
    else
    {
      if (!GameCanvas.keyPressed[!Main.isPC ? 6 : 24])
        return;
      ++this.newSelected;
      if (this.newSelected <= (int) this.size_tab - 1)
        return;
      this.newSelected = (int) this.size_tab - 1;
      if (GameCanvas.panel2 == null)
        return;
      GameCanvas.isFocusPanel2 = true;
      GameCanvas.panel2.selected = 0;
    }
  }

  private void updateKeyInventory()
  {
    this.updateKeyScrollView();
    this.updateKeyInvenTab();
  }

  private bool IsTabOption()
  {
    if (this.size_tab > (sbyte) 0)
    {
      if (this.currentTabName.Length > 1)
      {
        if (this.selected == 0)
          return true;
      }
      else if (this.selected >= 0)
        return true;
    }
    return false;
  }

  private int checkCurrentListLength(int arrLength)
  {
    int num1 = 20;
    int num2 = arrLength / 20 + (arrLength % 20 <= 0 ? 0 : 1);
    this.size_tab = (sbyte) num2;
    if (this.newSelected > num2 - 1)
      this.newSelected = num2 - 1;
    if (arrLength % 20 > 0 && this.newSelected == num2 - 1)
      num1 = arrLength % 20;
    return num1 + 1;
  }

  private void setNewSelected(int arrLength, bool resetSelect)
  {
    int num = arrLength / 20 + (arrLength % 20 <= 0 ? 0 : 1);
    int xScroll = this.xScroll;
    this.newSelected = (GameCanvas.px - xScroll) / this.TAB_W_NEW;
    if (this.newSelected > num - 1)
      this.newSelected = num - 1;
    if (GameCanvas.px < xScroll)
      this.newSelected = 0;
    this.setTabInventory(resetSelect);
  }
}
