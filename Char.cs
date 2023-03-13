// Decompiled with JetBrains decompiler
// Type: Char
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.e;
using Assets.src.g;
using System;

public class Char : IMapObject
{
  public string xuStr;
  public string luongStr;
  public string luongKhoaStr;
  public long lastUpdateTime;
  public bool meLive;
  public bool isMask;
  public bool isTeleport;
  public bool isUsePlane;
  public int shadowX;
  public int shadowY;
  public int shadowLife;
  public bool isNhapThe;
  public PetFollow petFollow;
  public int rank;
  public const sbyte A_STAND = 1;
  public const sbyte A_RUN = 2;
  public const sbyte A_JUMP = 3;
  public const sbyte A_FALL = 4;
  public const sbyte A_DEADFLY = 5;
  public const sbyte A_NOTHING = 6;
  public const sbyte A_ATTK = 7;
  public const sbyte A_INJURE = 8;
  public const sbyte A_AUTOJUMP = 9;
  public const sbyte A_FLY = 10;
  public const sbyte SKILL_STAND = 12;
  public const sbyte SKILL_FALL = 13;
  public const sbyte A_DEAD = 14;
  public const sbyte A_HIDE = 15;
  public const sbyte A_RESETPOINT = 16;
  public static ChatPopup chatPopup;
  public long cPower;
  public Info chatInfo;
  public sbyte petStatus;
  public int cx = 24;
  public int cy = 24;
  public int cvx;
  public int cvy;
  public int cp1;
  public int cp2;
  public int cp3;
  public int statusMe = 5;
  public int cdir = 1;
  public int charID;
  public int cgender;
  public int ctaskId;
  public int menuSelect;
  public int cBonusSpeed;
  public int cspeed = 4;
  public int ccurrentAttack;
  public int cDamFull;
  public int cDefull;
  public int cCriticalFull;
  public int clevel;
  public int cMP;
  public int cHP;
  public int cHPNew;
  public int cMaxEXP;
  public int cHPShow;
  public int xReload;
  public int yReload;
  public int cyStartFall;
  public int saveStatus;
  public int eff5BuffHp;
  public int eff5BuffMp;
  public int cHPFull;
  public int cMPFull;
  public int cdameDown;
  public int cStr;
  public long cLevelPercent;
  public long cTiemNang;
  public long cNangdong;
  public int damHP;
  public int damMP;
  public bool isMob;
  public bool isCrit;
  public bool isDie;
  public int pointUydanh;
  public int pointNon;
  public int pointVukhi;
  public int pointAo;
  public int pointLien;
  public int pointGangtay;
  public int pointNhan;
  public int pointQuan;
  public int pointNgocboi;
  public int pointGiay;
  public int pointPhu;
  public int countFinishDay;
  public int countLoopBoos;
  public int limitTiemnangso;
  public int limitKynangso;
  public short[] potential = new short[4];
  public string cName = string.Empty;
  public int clanID;
  public sbyte ctypeClan;
  public Clan clan;
  public sbyte role;
  public int cw = 22;
  public int ch = 32;
  public int chw = 11;
  public int chh = 16;
  public Command cmdMenu;
  public bool canFly = true;
  public bool cmtoChar;
  public bool me;
  public bool cFinishedAttack;
  public bool cchistlast;
  public bool isAttack;
  public bool isAttFly;
  public int cwpt;
  public int cwplv;
  public int cf;
  public int tick;
  public static bool fallAttack;
  public bool isJump;
  public bool autoFall;
  public bool attack = true;
  public long xu;
  public int xuInBox;
  public int yen;
  public int gold_lock;
  public int luong;
  public int luongKhoa;
  public NClass nClass;
  public Command endMovePointCommand;
  public MyVector vSkill = new MyVector();
  public MyVector vSkillFight = new MyVector();
  public MyVector vEff = new MyVector();
  public Skill myskill;
  public Task taskMaint;
  public bool paintName = true;
  public Archivement[] arrArchive;
  public Item[] arrItemBag;
  public Item[] arrItemBox;
  public Item[] arrItemBody;
  public Skill[] arrPetSkill;
  public Item[][] arrItemShop;
  public string[][] infoSpeacialSkill;
  public short[][] imgSpeacialSkill;
  public short cResFire;
  public short cResIce;
  public short cResWind;
  public short cMiss;
  public short cExactly;
  public short cFatal;
  public sbyte cPk;
  public sbyte cTypePk;
  public short cReactDame;
  public short sysUp;
  public short sysDown;
  public int avatar;
  public int skillTemplateId;
  public Mob mobFocus;
  public Mob mobMe;
  public int tMobMeBorn;
  public Npc npcFocus;
  public Char charFocus;
  public ItemMap itemFocus;
  public MyVector focus = new MyVector();
  public Mob[] attMobs;
  public Char[] attChars;
  public short[] moveFast;
  public int testCharId = -9999;
  public int killCharId = -9999;
  public sbyte resultTest;
  public int countKill;
  public int countKillMax;
  public bool isInvisiblez;
  public bool isShadown = true;
  public const sbyte PK_NORMAL = 0;
  public const sbyte PK_PHE = 1;
  public const sbyte PK_BANG = 2;
  public const sbyte PK_THIDAU = 3;
  public const sbyte PK_LUYENTAP = 4;
  public const sbyte PK_TUDO = 5;
  public MyVector taskOrders = new MyVector();
  public int cStamina;
  public static short[] idHead;
  public static short[] idAvatar;
  public int exp;
  public string[] strLevel;
  public string currStrLevel;
  public static Image eyeTraiDat = GameCanvas.loadImage("/mainImage/myTexture2dmat-trai-dat.png");
  public static Image eyeNamek = GameCanvas.loadImage("/mainImage/myTexture2dmat-namek.png");
  public bool isFreez;
  public bool isCharge;
  public int seconds;
  public int freezSeconds;
  public long last;
  public long cur;
  public long lastFreez;
  public long currFreez;
  public bool isFlyUp;
  public static MyVector vItemTime = new MyVector();
  public static short ID_NEW_MOUNT = 30000;
  public short idMount;
  public bool isHaveMount;
  public bool isMountVip;
  public bool isEventMount;
  public bool isSpeacialMount;
  public static Image imgMount_TD = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi10.png");
  public static Image imgMount_NM = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi20.png");
  public static Image imgMount_NM_1 = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi21.png");
  public static Image imgMount_XD = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi30.png");
  public static Image imgMount_TD_VIP = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi11.png");
  public static Image imgMount_NM_VIP = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi22.png");
  public static Image imgMount_NM_1_VIP = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi23.png");
  public static Image imgMount_XD_VIP = GameCanvas.loadImage("/mainImage/myTexture2dthucuoi31.png");
  public static Image imgEventMount = GameCanvas.loadImage("/mainImage/myTexture2drong.png");
  public static Image imgEventMountWing = GameCanvas.loadImage("/mainImage/myTexture2dcanhrong.png");
  public sbyte[] FrameMount = new sbyte[8]
  {
    (sbyte) 0,
    (sbyte) 0,
    (sbyte) 1,
    (sbyte) 1,
    (sbyte) 2,
    (sbyte) 2,
    (sbyte) 1,
    (sbyte) 1
  };
  public int frameMount;
  public int frameNewMount;
  public int transMount;
  public int genderMount;
  public int idcharMount;
  public int xMount;
  public int yMount;
  public int dxMount;
  public int dyMount;
  public int xChar;
  public int xdis;
  public int speedMount;
  public bool isStartMount;
  public bool isMount;
  public bool isEndMount;
  public sbyte cFlag;
  public int flagImage;
  public static int[][][] CharInfo = new int[33][][]
  {
    new int[4][]
    {
      new int[3]{ 0, -13, 34 },
      new int[3]{ 1, -8, 10 },
      new int[3]{ 1, -9, 16 },
      new int[3]{ 1, -9, 45 }
    },
    new int[4][]
    {
      new int[3]{ 0, -13, 35 },
      new int[3]{ 1, -8, 10 },
      new int[3]{ 1, -9, 17 },
      new int[3]{ 1, -9, 46 }
    },
    new int[4][]
    {
      new int[3]{ 1, -10, 33 },
      new int[3]{ 2, -10, 11 },
      new int[3]{ 2, -8, 16 },
      new int[3]{ 1, -12, 49 }
    },
    new int[4][]
    {
      new int[3]{ 1, -10, 32 },
      new int[3]{ 3, -12, 10 },
      new int[3]{ 3, -11, 15 },
      new int[3]{ 1, -13, 47 }
    },
    new int[4][]
    {
      new int[3]{ 1, -10, 34 },
      new int[3]{ 4, -8, 11 },
      new int[3]{ 4, -7, 17 },
      new int[3]{ 1, -12, 47 }
    },
    new int[4][]
    {
      new int[3]{ 1, -10, 34 },
      new int[3]{ 5, -12, 11 },
      new int[3]{ 5, -9, 17 },
      new int[3]{ 1, -13, 49 }
    },
    new int[4][]
    {
      new int[3]{ 1, -10, 33 },
      new int[3]{ 6, -10, 10 },
      new int[3]{ 6, -8, 16 },
      new int[3]{ 1, -12, 47 }
    },
    new int[4][]
    {
      new int[3]{ 0, -9, 36 },
      new int[3]{ 7, -5, 17 },
      new int[3]{ 7, -11, 25 },
      new int[3]{ 1, -8, 49 }
    },
    new int[4][]
    {
      new int[3]{ 0, -7, 35 },
      new int[3]{ 0, -18, 22 },
      new int[3]{ 7, -10, 25 },
      new int[3]{ 1, -7, 48 }
    },
    new int[4][]
    {
      new int[3]{ 1, -11, 35 },
      new int[3]{ 10, -3, 25 },
      new int[3]{ 12, -10, 26 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -11, 37 },
      new int[3]{ 11, -3, 25 },
      new int[3]{ 12, -11, 27 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -14, 34 },
      new int[3]{ 12, -8, 21 },
      new int[3]{ 9, -7, 31 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -12, 35 },
      new int[3]{ 8, -5, 14 },
      new int[3]{ 8, -15, 29 },
      new int[3]{ 1, -9, 49 }
    },
    new int[4][]
    {
      new int[3]{ 1, -9, 34 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 10, -7, 19 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -13, 34 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 11, -10, 19 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -8, 32 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 2, -6, 15 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -8, 32 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 13, -12, 16 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -10, 31 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 7, -13, 20 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -11, 32 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 8, -15, 26 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -9, 33 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 14, -8, 18 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -11, 33 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 15, -6, 19 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -16, 31 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 9, -8, 28 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -14, 34 },
      new int[3]{ 1, -8, 10 },
      new int[3]{ 8, -16, 28 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -8, 36 },
      new int[3]{ 7, -5, 17 },
      new int[3]{ 0, -5, 25 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -9, 31 },
      new int[3]{ 9, -12, 9 },
      new int[3]{ 0, -6, 20 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 2, -9, 36 },
      new int[3]{ 13, -5, 17 },
      new int[3]{ 16, -11, 25 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -9, 34 },
      new int[3]{ 8, -5, 13 },
      new int[3]{ 10, -7, 19 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -13, 34 },
      new int[3]{ 8, -5, 13 },
      new int[3]{ 11, -10, 19 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -8, 32 },
      new int[3]{ 8, -5, 13 },
      new int[3]{ 2, -6, 15 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 1, -8, 32 },
      new int[3]{ 8, -5, 13 },
      new int[3]{ 13, -12, 16 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -9, 33 },
      new int[3]{ 8, -5, 13 },
      new int[3]{ 14, -8, 18 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -11, 33 },
      new int[3]{ 8, -5, 13 },
      new int[3]{ 15, -6, 19 },
      new int[3]
    },
    new int[4][]
    {
      new int[3]{ 0, -16, 32 },
      new int[3]{ 8, -5, 13 },
      new int[3]{ 9, -8, 29 },
      new int[3]
    }
  };
  public static int[] CHAR_WEAPONX = new int[11]
  {
    -2,
    -6,
    22,
    21,
    19,
    22,
    10,
    -2,
    -2,
    5,
    19
  };
  public static int[] CHAR_WEAPONY = new int[11]
  {
    9,
    22,
    25,
    17,
    26,
    37,
    36,
    49,
    50,
    52,
    36
  };
  private static Char myChar;
  private static Char myPet;
  public static int[] listAttack;
  public static int[][] listIonC;
  public int cvyJump;
  private int indexUseSkill = -1;
  public int cxSend;
  public int cySend;
  public int cdirSend = 1;
  public int cxFocus;
  public int cyFocus;
  public int cactFirst = 5;
  public MyVector vMovePoints = new MyVector();
  public static string[][] inforClass = new string[2][]
  {
    new string[4]{ "1", "1", "chiêu 1", "0" },
    new string[4]{ "2", "2", "chiêu 2", "5" }
  };
  public static int[][] inforSkill = new int[10][]
  {
    new int[12]{ 1, 0, 1, 1000, 40, 1, 0, 20, 0, 0, 0, 0 },
    new int[12]{ 2, 1, 10, 1000, 100, 1, 0, 40, 0, 0, 0, 0 },
    new int[12]{ 2, 2, 11, 800, 100, 1, 0, 45, 0, 0, 0, 0 },
    new int[12]{ 2, 3, 12, 600, 100, 1, 0, 50, 0, 0, 0, 0 },
    new int[12]{ 2, 4, 13, 500, 100, 1, 0, 55, 0, 0, 0, 0 },
    new int[12]{ 3, 1, 14, 500, 100, 1, 0, 60, 0, 0, 0, 0 },
    new int[12]{ 3, 2, 14, 500, 100, 1, 0, 60, 0, 0, 0, 0 },
    new int[12]{ 3, 3, 14, 500, 100, 1, 0, 60, 0, 0, 0, 0 },
    new int[12]{ 3, 4, 14, 500, 100, 1, 0, 60, 0, 0, 0, 0 },
    new int[12]{ 3, 5, 14, 500, 100, 1, 0, 60, 0, 0, 0, 0 }
  };
  public static bool flag;
  public static bool ischangingMap;
  public static bool isLockKey;
  public static bool isLoadingMap;
  public bool isLockMove;
  public bool isLockAttack;
  public string strInfo;
  public short powerPoint;
  public short maxPowerPoint;
  public short secondPower;
  public long lastS;
  public long currS;
  public bool havePet = true;
  public MovePoint currentMovePoint;
  public int bom;
  public int delayFall;
  private bool isSoundJump;
  public int lastFrame;
  private Effect eProtect;
  private int twHp;
  public bool isInjureHp;
  public bool changePos;
  private bool isHide;
  private bool wy;
  public int wt;
  public int fy;
  public int ty;
  private int t;
  private int fM;
  public int[] move = new int[15]
  {
    1,
    1,
    1,
    1,
    2,
    2,
    2,
    2,
    3,
    3,
    3,
    3,
    2,
    2,
    2
  };
  private string strMount = "mount_";
  public int headICON = -1;
  public int head;
  public int leg;
  public int body;
  public int bag;
  public int wp;
  public int indexEff = -1;
  public int indexEffTask = -1;
  public EffectCharPaint eff;
  public EffectCharPaint effTask;
  public int indexSkill;
  public int i0;
  public int i1;
  public int i2;
  public int dx0;
  public int dx1;
  public int dx2;
  public int dy0;
  public int dy1;
  public int dy2;
  public EffectCharPaint eff0;
  public EffectCharPaint eff1;
  public EffectCharPaint eff2;
  public Arrow arr;
  public PlayerDart dart;
  public bool isCreateDark;
  public SkillPaint skillPaint;
  public SkillPaint skillPaintRandomPaint;
  public EffectPaint[] effPaints;
  public int sType;
  public sbyte isInjure;
  public bool isUseSkillAfterCharge;
  public bool isFlyAndCharge;
  public bool isStandAndCharge;
  private bool isFlying;
  public int posDisY;
  private int chargeCount;
  private bool hasSendAttack;
  public bool isMabuHold;
  private long timeBlue;
  private int tBlue;
  private bool IsAddDust1;
  private bool IsAddDust2;
  private bool isPet;
  private bool isMiniPet;
  public int xSd;
  public int ySd;
  private bool isOutMap;
  private int fBag;
  private int statusBeforeNothing;
  private int timeFocusToMob;
  public static bool isManualFocus = false;
  private Char charHold;
  private Mob mobHold;
  private int nInjure;
  public short wdx;
  public short wdy;
  public bool isDirtyPostion;
  public Skill lastNormalSkill;
  public bool currentFireByShortcut;
  public int cDamGoc;
  public int cHPGoc;
  public int cMPGoc;
  public int cDefGoc;
  public int cCriticalGoc;
  public sbyte hpFrom1000TiemNang;
  public sbyte mpFrom1000TiemNang;
  public sbyte damFrom1000TiemNang;
  public sbyte defFrom1000TiemNang = 1;
  public sbyte criticalFrom1000Tiemnang = 1;
  public short cMaxStamina;
  public short expForOneAdd;
  public sbyte isMonkey;
  public bool isCopy;
  public bool isWaitMonkey;
  private bool isFeetEff;
  public bool meDead;
  public int holdEffID;
  public bool holder;
  public bool protectEff;
  private bool isSetPos;
  private int tpos;
  private short xPos;
  private short yPos;
  private sbyte typePos;
  private bool isMyFusion;
  public bool isFusion;
  public int tFusion;
  public bool huytSao;
  public bool blindEff;
  public bool telePortSkill;
  public bool sleepEff;
  public bool stone;
  public int perCentMp = 100;
  public int dHP;
  public int headTemp = -1;
  public int bodyTemp = -1;
  public int legTemp = -1;
  public int bagTemp = -1;
  public int wpTemp = -1;
  public MyVector vEffChar = new MyVector(nameof (vEff));
  public static FrameImage fraRedEye;
  private int fChopmat;
  private bool isAddChopMat;
  private long timeAddChopmat;
  private int[] frChopNhanh = new int[34]
  {
    -1,
    -1,
    -1,
    -1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    -1,
    -1,
    -1,
    -1
  };
  private int[] frChopCham = new int[23]
  {
    -1,
    -1,
    -1,
    -1,
    0,
    0,
    1,
    1,
    1,
    0,
    0,
    1,
    1,
    1,
    0,
    0,
    1,
    1,
    1,
    -1,
    -1,
    -1,
    -1
  };
  private int[] frEye = new int[30]
  {
    -1,
    -1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    1,
    1,
    0,
    0,
    -1,
    -1
  };
  public static int[][] Arr_Head_2Fr = new int[1][]
  {
    new int[2]{ 542, 543 }
  };
  private int fHead;
  private string strEffAura = "aura_";
  public short idAuraEff = -1;
  public static bool isPaintAura = true;
  private FrameImage fraEff;
  private FrameImage fraEffSub;
  private string strEff_Set_Item = "set_eff_";
  public short idEff_Set_Item = -1;
  private FrameImage fraHat_behind;
  private FrameImage fraHat_font;
  private FrameImage fraHat_behind_2;
  private FrameImage fraHat_font_2;
  private string strHat_behind = "hat_sau_";
  private string strHat_font = "hat_truoc_";
  private string strNgang = "ngang_";
  public short idHat = -1;
  public static int[][] hatInfo = new int[32][]
  {
    new int[2]{ 5, -7 },
    new int[2]{ 5, -7 },
    new int[2]{ 5, -8 },
    new int[2]{ 5, -7 },
    new int[2]{ 5, -6 },
    new int[2]{ 5, -8 },
    new int[2]{ 5, -7 },
    new int[2]{ 9, 0 },
    new int[2]{ 11, 1 },
    new int[2]{ 4, 0 },
    new int[2]{ 4, -1 },
    new int[2]{ 4, 8 },
    new int[2]{ 6, 5 },
    new int[2]{ 6, -6 },
    new int[2]{ 2, -5 },
    new int[2]{ 7, -8 },
    new int[2]{ 7, -6 },
    new int[2]{ 8, 0 },
    new int[2]{ 7, 5 },
    new int[2]{ 9, -7 },
    new int[2]{ 7, -3 },
    new int[2]{ 2, 8 },
    new int[2]{ 4, 5 },
    new int[2]{ 10, -5 },
    new int[2]{ 9, -5 },
    new int[2]{ 9, -5 },
    new int[2]{ 6, -6 },
    new int[2]{ 2, -5 },
    new int[2]{ 7, -8 },
    new int[2]{ 7, -6 },
    new int[2]{ 9, -7 },
    new int[2]{ 7, -3 }
  };

  public Char() => this.statusMe = 6;

  public void applyCharLevelPercent()
  {
    try
    {
      long num1 = 1;
      long num2 = 0;
      int num3 = 0;
      for (int index = GameScr.exps.Length - 1; index >= 0; --index)
      {
        if (this.cPower >= GameScr.exps[index])
        {
          num1 = index != GameScr.exps.Length - 1 ? GameScr.exps[index + 1] - GameScr.exps[index] : 1L;
          num2 = this.cPower - GameScr.exps[index];
          num3 = index;
          break;
        }
      }
      this.clevel = num3;
      this.cLevelPercent = (long) (int) (num2 * 10000L / num1);
    }
    catch (Exception ex)
    {
      Cout.LogError("Loi char level percent: " + ex.ToString());
    }
  }

  public int getdxSkill() => this.myskill != null ? this.myskill.dx : 0;

  public int getdySkill() => this.myskill != null ? this.myskill.dy : 0;

  public static void taskAction(bool isNextStep)
  {
    Task taskMaint = Char.myCharz().taskMaint;
    if (taskMaint.index > taskMaint.contentInfo.Length - 1)
      taskMaint.index = taskMaint.contentInfo.Length - 1;
    string str = taskMaint.contentInfo[taskMaint.index];
    if (str != null && !str.Equals(string.Empty))
    {
      if (str.StartsWith("#"))
      {
        string strNext = NinjaUtil.replace(str, "#", string.Empty);
        Npc next = new Npc(5, 0, -100, -100, 5, GameScr.info1.charId[Char.myCharz().cgender][2]);
        next.cx = next.cy = -100;
        next.avatar = GameScr.info1.charId[Char.myCharz().cgender][2];
        next.charID = 5;
        if (GameCanvas.currentScreen == GameScr.instance)
          ChatPopup.addNextPopUpMultiLine(strNext, next);
      }
      else if (isNextStep)
        GameScr.info1.addInfo(str, 0);
    }
    GameScr.isHaveSelectSkill = true;
    Cout.println("TASKx " + (object) Char.myCharz().taskMaint.taskId);
    Char.myCharz().canFly = Char.myCharz().taskMaint.taskId > (short) 2;
    GameScr.gI().left = (Command) null;
    if (taskMaint.taskId == (short) 0)
    {
      Hint.isViewMap = false;
      GameScr.gI().right = (Command) null;
      GameScr.isHaveSelectSkill = false;
      GameScr.gI().left = (Command) null;
      if (taskMaint.index < 4)
      {
        MagicTree.isPaint = false;
        GameScr.isPaintRada = -1;
      }
      if (taskMaint.index == 4)
      {
        GameScr.isPaintRada = 1;
        MagicTree.isPaint = true;
      }
      if (taskMaint.index >= 5)
        GameScr.gI().right = GameScr.gI().cmdFocus;
    }
    if (taskMaint.taskId == (short) 1)
      GameScr.isHaveSelectSkill = true;
    if (taskMaint.taskId >= (short) 1)
    {
      GameScr.gI().right = GameScr.gI().cmdFocus;
      GameScr.gI().left = GameScr.gI().cmdMenu;
    }
    Panel.isPaintMap = taskMaint.taskId >= (short) 0;
    GameCanvas.panel.mainTabName = taskMaint.taskId >= (short) 12 ? mResources.mainTab2 : mResources.mainTab1;
    GameCanvas.panel.tabName[0] = GameCanvas.panel.mainTabName;
    if (Char.myChar.taskMaint.taskId <= (short) 10)
      return;
    Rms.saveRMSString("fake", "aa");
  }

  public string getStrLevel() => this.strLevel[this.clevel] + "+" + (object) (this.cLevelPercent / 100L) + "." + (object) (this.cLevelPercent % 100L) + "%";

  public int avatarz() => this.getAvatar(this.head);

  public int getAvatar(int headId)
  {
    for (int index = 0; index < Char.idHead.Length; ++index)
    {
      if (headId == (int) Char.idHead[index])
        return (int) Char.idAvatar[index];
    }
    return -1;
  }

  public void setPowerInfo(string info, short p, short maxP, short sc)
  {
    this.powerPoint = p;
    this.strInfo = info;
    this.maxPowerPoint = maxP;
    this.secondPower = sc;
    this.lastS = this.currS = mSystem.currentTimeMillis();
  }

  public void addInfo(string info)
  {
    if (this.chatInfo == null)
      this.chatInfo = new Info();
    Char cInfo = (Char) null;
    this.chatInfo.addInfo(info, 0, cInfo, false);
  }

  public int getSys()
  {
    if (this.nClass.classId == 1 || this.nClass.classId == 2)
      return 1;
    if (this.nClass.classId == 3 || this.nClass.classId == 4)
      return 2;
    return this.nClass.classId == 5 || this.nClass.classId == 6 ? 3 : 0;
  }

  public static Char myCharz()
  {
    if (Char.myChar == null)
    {
      Char.myChar = new Char();
      Char.myChar.me = true;
      Char.myChar.cmtoChar = true;
    }
    return Char.myChar;
  }

  public static Char myPetz()
  {
    if (Char.myPet == null)
    {
      Char.myPet = new Char();
      Char.myPet.me = false;
    }
    return Char.myPet;
  }

  public static void clearMyChar() => Char.myChar = (Char) null;

  public void bagSort()
  {
    try
    {
      MyVector myVector = new MyVector();
      for (int index = 0; index < this.arrItemBag.Length; ++index)
      {
        Item o = this.arrItemBag[index];
        if (o != null && o.template.isUpToUp && !o.isExpires)
          myVector.addElement((object) o);
      }
      for (int index1 = 0; index1 < myVector.size(); ++index1)
      {
        Item obj1 = (Item) myVector.elementAt(index1);
        if (obj1 != null)
        {
          for (int index2 = index1 + 1; index2 < myVector.size(); ++index2)
          {
            Item obj2 = (Item) myVector.elementAt(index2);
            if (obj2 != null && obj1.template.Equals((object) obj2.template) && obj1.isLock == obj2.isLock)
            {
              obj1.quantity += obj2.quantity;
              this.arrItemBag[obj2.indexUI] = (Item) null;
              myVector.setElementAt((object) null, index2);
            }
          }
        }
      }
      for (int index3 = 0; index3 < this.arrItemBag.Length; ++index3)
      {
        if (this.arrItemBag[index3] != null)
        {
          for (int index4 = 0; index4 <= index3; ++index4)
          {
            if (this.arrItemBag[index4] == null)
            {
              this.arrItemBag[index4] = this.arrItemBag[index3];
              this.arrItemBag[index4].indexUI = index4;
              this.arrItemBag[index3] = (Item) null;
              break;
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      Cout.println("Char.bagSort()");
    }
  }

  public void boxSort()
  {
    try
    {
      MyVector myVector = new MyVector();
      for (int index = 0; index < this.arrItemBox.Length; ++index)
      {
        Item o = this.arrItemBox[index];
        if (o != null && o.template.isUpToUp && !o.isExpires)
          myVector.addElement((object) o);
      }
      for (int index1 = 0; index1 < myVector.size(); ++index1)
      {
        Item obj1 = (Item) myVector.elementAt(index1);
        if (obj1 != null)
        {
          for (int index2 = index1 + 1; index2 < myVector.size(); ++index2)
          {
            Item obj2 = (Item) myVector.elementAt(index2);
            if (obj2 != null && obj1.template.Equals((object) obj2.template) && obj1.isLock == obj2.isLock)
            {
              obj1.quantity += obj2.quantity;
              this.arrItemBox[obj2.indexUI] = (Item) null;
              myVector.setElementAt((object) null, index2);
            }
          }
        }
      }
      for (int index3 = 0; index3 < this.arrItemBox.Length; ++index3)
      {
        if (this.arrItemBox[index3] != null)
        {
          for (int index4 = 0; index4 <= index3; ++index4)
          {
            if (this.arrItemBox[index4] == null)
            {
              this.arrItemBox[index4] = this.arrItemBox[index3];
              this.arrItemBox[index4].indexUI = index4;
              this.arrItemBox[index3] = (Item) null;
              break;
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      Cout.println("Char.boxSort()");
    }
  }

  public void useItem(int indexUI)
  {
    Item obj1 = this.arrItemBag[indexUI];
    if (!obj1.isTypeBody())
      return;
    obj1.isLock = true;
    obj1.typeUI = 5;
    Item obj2 = this.arrItemBody[(int) obj1.template.type];
    this.arrItemBag[indexUI] = (Item) null;
    if (obj2 != null)
    {
      obj2.typeUI = 3;
      this.arrItemBody[(int) obj1.template.type] = (Item) null;
      obj2.indexUI = indexUI;
      this.arrItemBag[indexUI] = obj2;
    }
    obj1.indexUI = (int) obj1.template.type;
    this.arrItemBody[obj1.indexUI] = obj1;
    for (int index = 0; index < this.arrItemBody.Length; ++index)
    {
      Item obj3 = this.arrItemBody[index];
      if (obj3 != null)
      {
        if (obj3.template.type == (sbyte) 0)
          this.body = (int) obj3.template.part;
        else if (obj3.template.type == (sbyte) 1)
          this.leg = (int) obj3.template.part;
      }
    }
  }

  public Skill getSkill(SkillTemplate skillTemplate)
  {
    for (int index = 0; index < this.vSkill.size(); ++index)
    {
      if ((int) ((Skill) this.vSkill.elementAt(index)).template.id == (int) skillTemplate.id)
        return (Skill) this.vSkill.elementAt(index);
    }
    return (Skill) null;
  }

  public Waypoint isInEnterOfflinePoint()
  {
    Task taskMaint = Char.myChar.taskMaint;
    if (taskMaint != null && taskMaint.taskId == (short) 0 && taskMaint.index < 6)
      return (Waypoint) null;
    int num = TileMap.vGo.size();
    for (sbyte index = 0; (int) index < num; ++index)
    {
      Waypoint waypoint = (Waypoint) TileMap.vGo.elementAt((int) index);
      if (PopUp.vPopups.size() >= num && !((PopUp) PopUp.vPopups.elementAt((int) index)).isPaint)
        return (Waypoint) null;
      if (this.cx >= (int) waypoint.minX && this.cx <= (int) waypoint.maxX && this.cy >= (int) waypoint.minY && this.cy <= (int) waypoint.maxY && waypoint.isEnter && waypoint.isOffline)
        return waypoint;
    }
    return (Waypoint) null;
  }

  public Waypoint isInEnterOnlinePoint()
  {
    Task taskMaint = Char.myChar.taskMaint;
    if (taskMaint != null && taskMaint.taskId == (short) 0 && taskMaint.index < 6)
      return (Waypoint) null;
    int num = TileMap.vGo.size();
    for (sbyte index = 0; (int) index < num; ++index)
    {
      Waypoint waypoint = (Waypoint) TileMap.vGo.elementAt((int) index);
      if (PopUp.vPopups.size() >= num && !((PopUp) PopUp.vPopups.elementAt((int) index)).isPaint)
        return (Waypoint) null;
      if (this.cx >= (int) waypoint.minX && this.cx <= (int) waypoint.maxX && this.cy >= (int) waypoint.minY && this.cy <= (int) waypoint.maxY && waypoint.isEnter && !waypoint.isOffline)
        return waypoint;
    }
    return (Waypoint) null;
  }

  public bool isInWaypoint()
  {
    if (TileMap.isInAirMap() && this.cy >= TileMap.pxh - 48)
      return true;
    if (this.isTeleport || this.isUsePlane)
      return false;
    int num = TileMap.vGo.size();
    for (sbyte index = 0; (int) index < num; ++index)
    {
      Waypoint waypoint = (Waypoint) TileMap.vGo.elementAt((int) index);
      if ((TileMap.mapID == 47 || TileMap.isInAirMap()) && this.cy <= (int) waypoint.minY + (int) waypoint.maxY && this.cx > (int) waypoint.minX && this.cx < (int) waypoint.maxX)
        return !TileMap.isInAirMap() || this.cTypePk == (sbyte) 0;
      if (this.cx >= (int) waypoint.minX && this.cx <= (int) waypoint.maxX && this.cy >= (int) waypoint.minY && this.cy <= (int) waypoint.maxY && !waypoint.isEnter)
        return true;
    }
    return false;
  }

  public bool isPunchKickSkill() => this.skillPaint != null && (this.skillPaint.id >= 0 && this.skillPaint.id <= 6 || this.skillPaint.id >= 14 && this.skillPaint.id <= 20 || this.skillPaint.id >= 28 && this.skillPaint.id <= 34 || this.skillPaint.id >= 63 && this.skillPaint.id <= 69);

  public void soundUpdate()
  {
    if (this.me && this.statusMe == 10 && this.cf == 8 && this.ty > 20 && GameCanvas.gameTick % 20 == 0)
      SoundMn.gI().charFly();
    if (this.skillPaint == null || this.skillInfoPaint() == null || this.indexSkill >= this.skillInfoPaint().Length || !this.isPunchKickSkill() || !this.me && (this.me || this.cx < GameScr.cmx || this.cx > GameScr.cmx + GameCanvas.w) || GameCanvas.gameTick % 5 != 0)
      return;
    if (this.cf == 9 || this.cf == 10 || this.cf == 11)
      SoundMn.gI().charPunch(true, !this.me ? 0.05f : 0.1f);
    else
      SoundMn.gI().charPunch(false, !this.me ? 0.05f : 0.1f);
  }

  public void updateChargeSkill()
  {
  }

  public virtual void update()
  {
    if (this.isHide || this.isMabuHold)
      return;
    if (!this.isCopy && this.clevel < 14 || this.statusMe == 1 || this.statusMe != 6)
      ;
    if (this.petFollow != null)
    {
      if (GameCanvas.gameTick % 3 == 0)
      {
        if (Char.myCharz().cdir == 1)
          this.petFollow.cmtoX = this.cx - 20;
        if (Char.myCharz().cdir == -1)
          this.petFollow.cmtoX = this.cx + 20;
        this.petFollow.cmtoY = this.cy - 40;
        this.petFollow.dir = this.petFollow.cmx <= this.cx ? 1 : -1;
        if (this.petFollow.cmtoX < 100)
          this.petFollow.cmtoX = 100;
        if (this.petFollow.cmtoX > TileMap.pxw - 100)
          this.petFollow.cmtoX = TileMap.pxw - 100;
      }
      this.petFollow.update();
    }
    if (!this.me && this.cHP <= 0 && this.clanID != -100 && this.statusMe != 14 && this.statusMe != 5)
      this.startDie((short) this.cx, (short) this.cy);
    if (this.isInjureHp)
    {
      ++this.twHp;
      if (this.twHp == 20)
      {
        this.twHp = 0;
        this.isInjureHp = false;
      }
    }
    else if (this.dHP > this.cHP)
    {
      int num = this.dHP - this.cHP >> 1;
      if (num < 1)
        num = 1;
      this.dHP -= num;
    }
    else
      this.dHP = this.cHP;
    if (this.secondPower != (short) 0)
    {
      this.currS = mSystem.currentTimeMillis();
      if (this.currS - this.lastS >= 1000L)
      {
        this.lastS = mSystem.currentTimeMillis();
        --this.secondPower;
      }
    }
    if (!this.me && GameScr.notPaint)
      return;
    if (this.sleepEff && GameCanvas.gameTick % 10 == 0)
      EffecMn.addEff(new Effect(41, this.cx, this.cy, 3, 1, 1));
    if (this.huytSao)
    {
      this.huytSao = false;
      EffecMn.addEff(new Effect(39, this.cx, this.cy, 3, 3, 1));
    }
    if (this.blindEff && GameCanvas.gameTick % 5 == 0)
      ServerEffect.addServerEffect(113, this, 1);
    if (this.protectEff)
    {
      if (GameCanvas.gameTick % 5 == 0)
        this.eProtect = new Effect(33, this.cx, this.cy + 37, 3, 3, 1);
      if (this.eProtect != null)
      {
        this.eProtect.update();
        this.eProtect.x = this.cx;
        this.eProtect.y = this.cy + 37;
      }
    }
    if (this.charFocus != null && this.charFocus.cy < 0)
      this.charFocus = (Char) null;
    if (this.isFusion)
      ++this.tFusion;
    if (this.isNhapThe)
    {
      if (GameCanvas.gameTick % 25 == 0)
        ServerEffect.addServerEffect(114, this, 1);
    }
    if (this.isSetPos)
    {
      ++this.tpos;
      if (this.tpos != 1)
        return;
      this.tpos = 0;
      this.isSetPos = false;
      this.cx = (int) this.xPos;
      this.cy = (int) this.yPos;
      this.cp1 = this.cp2 = this.cp3 = 0;
      if (this.typePos == (sbyte) 1)
      {
        if (this.me)
        {
          this.cxSend = this.cx;
          this.cySend = this.cy;
        }
        this.currentMovePoint = (MovePoint) null;
        this.telePortSkill = false;
        ServerEffect.addServerEffect(173, this.cx, this.cy, 1);
      }
      else
        ServerEffect.addServerEffect(60, this.cx, this.cy, 1);
      if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) == 2)
        this.statusMe = 1;
      else
        this.statusMe = 4;
    }
    else
    {
      this.soundUpdate();
      if (this.stone)
        return;
      if (this.isFreez)
      {
        if (GameCanvas.gameTick % 5 == 0)
          ServerEffect.addServerEffect(113, this.cx, this.cy, 1);
        this.cf = 23;
        long num = mSystem.currentTimeMillis();
        if (num - this.lastFreez >= 1000L)
        {
          --this.freezSeconds;
          this.lastFreez = num;
          if (this.freezSeconds < 0)
          {
            this.isFreez = false;
            this.seconds = 0;
            if (this.me)
            {
              Char.myCharz().isLockMove = false;
              GameScr.gI().dem = 0;
              GameScr.gI().isFreez = false;
            }
          }
        }
        if (TileMap.tileTypeAt(this.cx / (int) TileMap.size, this.cy / (int) TileMap.size) != 0)
          return;
        ++this.ty;
        ++this.wt;
        this.fy += this.wy ? -1 : 1;
        if (this.wt != 10)
          return;
        this.wt = 0;
        this.wy = !this.wy;
      }
      else if (this.isWaitMonkey)
      {
        this.isLockMove = true;
        this.cf = 17;
        if (GameCanvas.gameTick % 5 == 0)
          ServerEffect.addServerEffect(154, this.cx, this.cy - 10, 2);
        if (GameCanvas.gameTick % 5 == 0)
          ServerEffect.addServerEffect(1, this.cx, this.cy + 10, 1);
        ++this.chargeCount;
        if (this.chargeCount != 500)
          return;
        this.isWaitMonkey = false;
        this.isLockMove = false;
      }
      else if (this.isStandAndCharge)
      {
        ++this.chargeCount;
        bool flag = !TileMap.tileTypeAt(Char.myCharz().cx, Char.myCharz().cy, 2);
        this.updateEffect();
        this.updateSkillPaint();
        this.moveFast = (short[]) null;
        this.currentMovePoint = (MovePoint) null;
        this.cf = 17;
        if (flag && this.cgender != 2)
          this.cf = 12;
        if (this.cgender == 2)
        {
          if (GameCanvas.gameTick % 3 == 0)
            ServerEffect.addServerEffect(154, this.cx, this.cy - this.ch / 2 + 10, 1);
          if (GameCanvas.gameTick % 5 == 0)
            ServerEffect.addServerEffect(114, this.cx + Res.random(-20, 20), this.cy + Res.random(-20, 20), 1);
        }
        if (this.cgender == 1)
        {
          if (GameCanvas.gameTick % 4 != 0)
            ;
          if (GameCanvas.gameTick % 2 == 0)
          {
            if (this.cdir == 1)
            {
              ServerEffect.addServerEffect(70, this.cx - 18, this.cy - this.ch / 2 + 8, 1);
              ServerEffect.addServerEffect(70, this.cx + 23, this.cy - this.ch / 2 + 15, 1);
            }
            else
            {
              ServerEffect.addServerEffect(70, this.cx + 18, this.cy - this.ch / 2 + 8, 1);
              ServerEffect.addServerEffect(70, this.cx - 23, this.cy - this.ch / 2 + 15, 1);
            }
          }
        }
        this.cur = mSystem.currentTimeMillis();
        if (this.cur - this.last > (long) this.seconds || this.cur - this.last > 10000L)
        {
          this.stopUseChargeSkill();
          if (this.me)
          {
            GameScr.gI().auto = 0;
            if (this.cgender == 2)
            {
              Char.myCharz().setAutoSkillPaint(GameScr.sks[(int) Char.myCharz().myskill.skillId], flag ? 1 : 0);
              Service.gI().skill_not_focus((sbyte) 8);
            }
            if (this.cgender == 1)
            {
              Res.outz("set skipp paint");
              this.isCreateDark = true;
              Char.myCharz().setSkillPaint(GameScr.sks[(int) Char.myCharz().myskill.skillId], flag ? 1 : 0);
            }
          }
          else if (this.cgender == 2)
            this.setAutoSkillPaint(GameScr.sks[this.skillTemplateId], flag ? 1 : 0);
          if (this.cgender == 2 && this.statusMe != 14 && this.statusMe != 5)
            GameScr.gI().activeSuperPower(this.cx, this.cy);
        }
        ++this.chargeCount;
        if (this.chargeCount != 500)
          return;
        this.stopUseChargeSkill();
      }
      else if (this.isFlyAndCharge)
      {
        this.updateEffect();
        this.updateSkillPaint();
        this.moveFast = (short[]) null;
        this.currentMovePoint = (MovePoint) null;
        ++this.posDisY;
        if (TileMap.tileTypeAt(this.cx, this.cy - this.ch, 8192))
        {
          this.stopUseChargeSkill();
        }
        else
        {
          if (this.posDisY == 20)
            this.last = mSystem.currentTimeMillis();
          if (this.posDisY > 20)
          {
            this.cur = mSystem.currentTimeMillis();
            if (this.cur - this.last > (long) this.seconds || this.cur - this.last > 10000L)
            {
              this.isFlyAndCharge = false;
              if (!this.me)
                return;
              this.isCreateDark = true;
              bool flag = TileMap.tileTypeAt(Char.myCharz().cx, Char.myCharz().cy, 2);
              this.isUseSkillAfterCharge = true;
              Char.myCharz().setSkillPaint(GameScr.sks[(int) Char.myCharz().myskill.skillId], !flag ? 1 : 0);
            }
            else
            {
              this.cf = 32;
              if (this.cgender == 0 && GameCanvas.gameTick % 3 == 0)
                ServerEffect.addServerEffect(153, this.cx, this.cy - this.ch, 2);
              ++this.chargeCount;
              if (this.chargeCount != 500)
                return;
              this.stopUseChargeSkill();
            }
          }
          else
          {
            if (this.statusMe != 14)
              this.statusMe = 3;
            this.cvy = -3;
            this.cy += this.cvy;
            this.cf = 7;
          }
        }
      }
      else
      {
        if (this.me && GameCanvas.isTouch)
        {
          if (this.charFocus != null && this.charFocus.charID >= 0 && this.charFocus.cx > 100 && this.charFocus.cx < TileMap.pxw - 100 && this.isInEnterOnlinePoint() == null && this.isInEnterOfflinePoint() == null && !this.isAttacPlayerStatus() && TileMap.mapID != 51 && TileMap.mapID != 52 && GameCanvas.panel.vPlayerMenu.size() > 0 && GameScr.gI().popUpYesNo == null)
          {
            int num1 = Math.abs(this.cx - this.charFocus.cx);
            int num2 = Math.abs(this.cy - this.charFocus.cy);
            if (num1 < 60 && num2 < 40)
            {
              if (this.cmdMenu == null)
              {
                this.cmdMenu = new Command(mResources.MENU, 11111);
                this.cmdMenu.isPlaySoundButton = false;
              }
              this.cmdMenu.x = this.charFocus.cx - GameScr.cmx;
              this.cmdMenu.y = this.charFocus.cy - this.charFocus.ch - 30 - GameScr.cmy;
            }
            else
              this.cmdMenu = (Command) null;
          }
          else
            this.cmdMenu = (Command) null;
        }
        if (this.isShadown)
          this.updateShadown();
        if (this.isTeleport)
          return;
        if (this.chatInfo != null)
          this.chatInfo.update();
        if (this.shadowLife > 0)
          --this.shadowLife;
        if (this.resultTest > (sbyte) 0 && GameCanvas.gameTick % 2 == 0)
        {
          --this.resultTest;
          if (this.resultTest == (sbyte) 30 || this.resultTest == (sbyte) 60)
            this.resultTest = (sbyte) 0;
        }
        this.updateSkillPaint();
        if (this.mobMe != null)
          this.updateMobMe();
        if (this.arr != null)
          this.arr.update();
        if (this.dart != null)
          this.dart.update();
        this.updateEffect();
        if (this.holdEffID != 0)
        {
          if (GameCanvas.gameTick % 5 != 0)
            return;
          EffecMn.addEff(new Effect(32, this.cx, this.cy + 24, 3, 5, 1));
        }
        else
        {
          if (this.blindEff || this.sleepEff)
            return;
          if (this.holder)
          {
            if (this.charHold != null && (this.charHold.statusMe == 14 || this.charHold.statusMe == 5))
              this.removeHoleEff();
            if (this.mobHold != null && this.mobHold.status == 1)
              this.removeHoleEff();
            if (this.me && this.statusMe == 2 && this.currentMovePoint != null)
            {
              this.holder = false;
              this.charHold = (Char) null;
              this.mobHold = (Mob) null;
            }
            if (TileMap.tileTypeAt(this.cx, this.cy, 2))
              this.cf = 16;
            else
              this.cf = 31;
          }
          else
          {
            if (this.cHP > 0)
            {
              for (int index = 0; index < this.vEff.size(); ++index)
              {
                EffectChar effectChar = (EffectChar) this.vEff.elementAt(index);
                if (effectChar.template.type == (sbyte) 0 || effectChar.template.type == (sbyte) 12)
                {
                  if (GameCanvas.isEff1)
                  {
                    this.cHP += (int) effectChar.param;
                    this.cMP += (int) effectChar.param;
                  }
                }
                else if (effectChar.template.type == (sbyte) 4 || effectChar.template.type == (sbyte) 17)
                {
                  if (GameCanvas.isEff1)
                    this.cHP += (int) effectChar.param;
                }
                else if (effectChar.template.type == (sbyte) 13 && GameCanvas.isEff1)
                {
                  this.cHP -= this.cHPFull * 3 / 100;
                  if (this.cHP < 1)
                    this.cHP = 1;
                }
              }
              if (this.eff5BuffHp > 0 && GameCanvas.isEff2)
                this.cHP += this.eff5BuffHp;
              if (this.eff5BuffMp > 0 && GameCanvas.isEff2)
                this.cMP += this.eff5BuffMp;
              if (this.cHP > this.cHPFull)
                this.cHP = this.cHPFull;
              if (this.cMP > this.cMPFull)
                this.cMP = this.cMPFull;
            }
            if (this.cmtoChar)
            {
              GameScr.cmtoX = this.cx - GameScr.gW2;
              GameScr.cmtoY = this.cy - GameScr.gH23;
              if (!GameCanvas.isTouchControl)
                GameScr.cmtoX += GameScr.gW6 * this.cdir;
            }
            this.tick = (this.tick + 1) % 100;
            if (this.me)
            {
              if (this.charFocus != null && !GameScr.vCharInMap.contains((object) this.charFocus))
                this.charFocus = (Char) null;
              if (this.cx < 10)
              {
                this.cvx = 0;
                this.cx = 10;
              }
              else if (this.cx > TileMap.pxw - 10)
              {
                this.cx = TileMap.pxw - 10;
                this.cvx = 0;
              }
              if (this.me && !Char.ischangingMap && this.isInWaypoint())
              {
                Service.gI().charMove();
                if (TileMap.isTrainingMap())
                {
                  Service.gI().getMapOffline();
                  Char.ischangingMap = true;
                }
                else
                  Service.gI().requestChangeMap();
                Char.isLockKey = true;
                Char.ischangingMap = true;
                GameCanvas.clearKeyHold();
                GameCanvas.clearKeyPressed();
                InfoDlg.showWait();
                return;
              }
              if (this.statusMe != 4 && Res.abs(this.cx - this.cxSend) + Res.abs(this.cy - this.cySend) >= 70 && this.cy - this.cySend <= 0 && this.me)
                Service.gI().charMove();
              if (this.isLockMove)
                this.currentMovePoint = (MovePoint) null;
              if (this.currentMovePoint != null)
              {
                if (Char.abs(this.cx - this.currentMovePoint.xEnd) <= 16 && Char.abs(this.cy - this.currentMovePoint.yEnd) <= 16)
                {
                  this.cx = (this.currentMovePoint.xEnd + this.cx) / 2;
                  this.cy = this.currentMovePoint.yEnd;
                  this.currentMovePoint = (MovePoint) null;
                  GameScr.instance.clickMoving = false;
                  this.checkPerformEndMovePointAction();
                  this.cvx = this.cvy = 0;
                  if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) == 2)
                    this.statusMe = 1;
                  else
                    this.setCharFallFromJump();
                  Service.gI().charMove();
                }
                else
                {
                  this.cdir = this.currentMovePoint.xEnd <= this.cx ? -1 : 1;
                  if (TileMap.tileTypeAt(this.cx, this.cy, 2))
                  {
                    this.statusMe = 2;
                    if (this.currentMovePoint != null)
                    {
                      this.cvx = this.cspeed * this.cdir;
                      this.cvy = 0;
                    }
                    if (Char.abs(this.cx - this.currentMovePoint.xEnd) <= 10)
                    {
                      if (this.currentMovePoint.yEnd > this.cy)
                      {
                        this.currentMovePoint = (MovePoint) null;
                        GameScr.instance.clickMoving = false;
                        this.statusMe = 1;
                        this.cvx = this.cvy = 0;
                        this.checkPerformEndMovePointAction();
                      }
                      else
                      {
                        SoundMn.gI().charJump();
                        this.cx = this.currentMovePoint.xEnd;
                        this.statusMe = 10;
                        this.cvy = -5;
                        this.cvx = 0;
                      }
                    }
                    if (this.cdir == 1)
                    {
                      if (TileMap.tileTypeAt(this.cx + this.chw, this.cy - this.chh, 4))
                      {
                        this.cvx = this.cspeed * this.cdir;
                        this.statusMe = 10;
                        this.cvy = -5;
                      }
                    }
                    else if (TileMap.tileTypeAt(this.cx - this.chw - 1, this.cy - this.chh, 8))
                    {
                      this.cvx = this.cspeed * this.cdir;
                      this.statusMe = 10;
                      this.cvy = -5;
                    }
                  }
                  else
                  {
                    if (this.currentMovePoint.yEnd < this.cy + 10)
                    {
                      this.statusMe = 10;
                      this.cvy = -5;
                      if (Char.abs(this.cy - this.currentMovePoint.yEnd) <= 10)
                      {
                        this.cy = this.currentMovePoint.yEnd;
                        this.cvy = 0;
                      }
                      this.cvx = Char.abs(this.cx - this.currentMovePoint.xEnd) > 10 ? this.cspeed * this.cdir : 0;
                    }
                    else if (TileMap.tileTypeAt(this.cx, this.cy, 2))
                    {
                      this.currentMovePoint = (MovePoint) null;
                      GameScr.instance.clickMoving = false;
                      this.statusMe = 1;
                      this.cvx = this.cvy = 0;
                      this.checkPerformEndMovePointAction();
                    }
                    else
                    {
                      if (this.statusMe == 10 || this.statusMe == 2)
                        this.cvy = 0;
                      this.statusMe = 4;
                    }
                    if (this.currentMovePoint.yEnd > this.cy)
                    {
                      if (this.cdir == 1)
                      {
                        if (TileMap.tileTypeAt(this.cx + this.chw, this.cy - this.chh, 4))
                        {
                          this.cvx = this.cvy = 0;
                          this.statusMe = 4;
                          this.currentMovePoint = (MovePoint) null;
                          GameScr.instance.clickMoving = false;
                          this.checkPerformEndMovePointAction();
                        }
                      }
                      else if (TileMap.tileTypeAt(this.cx - this.chw - 1, this.cy - this.chh, 8))
                      {
                        this.cvx = this.cvy = 0;
                        this.statusMe = 4;
                        this.currentMovePoint = (MovePoint) null;
                        GameScr.instance.clickMoving = false;
                        this.checkPerformEndMovePointAction();
                      }
                    }
                  }
                }
              }
              this.searchFocus();
            }
            else
            {
              this.checkHideCharName();
              if (this.statusMe == 1 || this.statusMe == 6)
              {
                bool flag = false;
                if (this.currentMovePoint != null)
                {
                  if (Char.abs(this.currentMovePoint.xEnd - this.cx) < 17 && Char.abs(this.currentMovePoint.yEnd - this.cy) < 25)
                  {
                    this.cx = this.currentMovePoint.xEnd;
                    this.cy = this.currentMovePoint.yEnd;
                    this.currentMovePoint = (MovePoint) null;
                    if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) == 2)
                    {
                      this.statusMe = 1;
                      this.cp3 = 0;
                      GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
                      GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
                    }
                    else
                    {
                      this.statusMe = 4;
                      this.cvy = 0;
                      this.cp1 = 0;
                    }
                    flag = true;
                  }
                  else if ((this.statusBeforeNothing == 10 || this.cf == 8) && this.vMovePoints.size() > 0)
                    flag = true;
                  else if (this.cy == this.currentMovePoint.yEnd)
                  {
                    if (this.cx != this.currentMovePoint.xEnd)
                    {
                      this.cx = (this.cx + this.currentMovePoint.xEnd) / 2;
                      this.cf = GameCanvas.gameTick % 5 + 2;
                    }
                  }
                  else if (this.cy < this.currentMovePoint.yEnd)
                  {
                    this.cf = 12;
                    this.cx = (this.cx + this.currentMovePoint.xEnd) / 2;
                    if (this.cvy < 0)
                      this.cvy = 0;
                    this.cy += this.cvy;
                    if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) == 2)
                    {
                      GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
                      GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
                    }
                    ++this.cvy;
                    if (this.cvy > 16)
                      this.cy = (this.cy + this.currentMovePoint.yEnd) / 2;
                  }
                  else
                  {
                    this.cf = 7;
                    this.cx = (this.cx + this.currentMovePoint.xEnd) / 2;
                    this.cy = (this.cy + this.currentMovePoint.yEnd) / 2;
                  }
                }
                else
                  flag = true;
                if (flag && this.vMovePoints.size() > 0)
                {
                  this.currentMovePoint = (MovePoint) this.vMovePoints.firstElement();
                  this.vMovePoints.removeElementAt(0);
                  if (this.currentMovePoint.status == 2)
                  {
                    if ((TileMap.tileTypeAtPixel(this.cx, this.cy + 12) & 2) != 2)
                    {
                      this.statusMe = 10;
                      this.cp1 = 0;
                      this.cp2 = 0;
                      this.cvx = -(this.cx - this.currentMovePoint.xEnd) / 10;
                      this.cvy = -(this.cy - this.currentMovePoint.yEnd) / 10;
                      if (this.cx - this.currentMovePoint.xEnd > 0)
                        this.cdir = -1;
                      else if (this.cx - this.currentMovePoint.xEnd < 0)
                        this.cdir = 1;
                    }
                    else
                    {
                      this.statusMe = 2;
                      if (this.cx - this.currentMovePoint.xEnd > 0)
                        this.cdir = -1;
                      else if (this.cx - this.currentMovePoint.xEnd < 0)
                        this.cdir = 1;
                      this.cvx = this.cspeed * this.cdir;
                      this.cvy = 0;
                    }
                  }
                  else if (this.currentMovePoint.status == 3)
                  {
                    if ((TileMap.tileTypeAtPixel(this.cx, this.cy + 23) & 2) != 2)
                    {
                      this.statusMe = 10;
                      this.cp1 = 0;
                      this.cp2 = 0;
                      this.cvx = -(this.cx - this.currentMovePoint.xEnd) / 10;
                      this.cvy = -(this.cy - this.currentMovePoint.yEnd) / 10;
                      if (this.cx - this.currentMovePoint.xEnd > 0)
                        this.cdir = -1;
                      else if (this.cx - this.currentMovePoint.xEnd < 0)
                        this.cdir = 1;
                    }
                    else
                    {
                      this.statusMe = 3;
                      GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
                      GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
                      if (this.cx - this.currentMovePoint.xEnd > 0)
                        this.cdir = -1;
                      else if (this.cx - this.currentMovePoint.xEnd < 0)
                        this.cdir = 1;
                      this.cvx = Char.abs(this.cx - this.currentMovePoint.xEnd) / 10 * this.cdir;
                      this.cvy = -10;
                    }
                  }
                  else if (this.currentMovePoint.status == 4)
                  {
                    this.statusMe = 4;
                    if (this.cx - this.currentMovePoint.xEnd > 0)
                      this.cdir = -1;
                    else if (this.cx - this.currentMovePoint.xEnd < 0)
                      this.cdir = 1;
                    this.cvx = Char.abs(this.cx - this.currentMovePoint.xEnd) / 9 * this.cdir;
                    this.cvy = 0;
                  }
                  else
                  {
                    this.cx = this.currentMovePoint.xEnd;
                    this.cy = this.currentMovePoint.yEnd;
                    this.currentMovePoint = (MovePoint) null;
                  }
                }
              }
            }
            switch (this.statusMe)
            {
              case 1:
                this.updateCharStand();
                break;
              case 2:
                this.updateCharRun();
                break;
              case 3:
                this.updateCharJump();
                break;
              case 4:
                this.updateCharFall();
                break;
              case 5:
                this.updateCharDeadFly();
                break;
              case 6:
                if (this.isInjure <= (sbyte) 0)
                  this.cf = 0;
                else if (this.statusBeforeNothing == 10)
                  this.cx += this.cvx;
                else if (this.cf <= 1)
                {
                  ++this.cp1;
                  this.cf = this.cp1 <= 6 ? 1 : 0;
                  if (this.cp1 > 10)
                    this.cp1 = 0;
                }
                if (this.cf != 7 && this.cf != 12 && (TileMap.tileTypeAtPixel(this.cx, this.cy + 1) & 2) != 2)
                {
                  this.cvx = 0;
                  this.cvy = 0;
                  this.statusMe = 4;
                  this.cf = 7;
                }
                if (!this.me)
                {
                  ++this.cp3;
                  if (this.cp3 > 10)
                  {
                    if ((TileMap.tileTypeAtPixel(this.cx, this.cy + 1) & 2) != 2)
                      this.cy += 5;
                    else
                      this.cf = 0;
                  }
                  if (this.cp3 > 50)
                  {
                    this.cp3 = 0;
                    this.currentMovePoint = (MovePoint) null;
                    break;
                  }
                  break;
                }
                break;
              case 9:
                this.updateCharAutoJump();
                break;
              case 10:
                this.updateCharFly();
                break;
              case 12:
                this.updateSkillStand();
                break;
              case 13:
                this.updateSkillFall();
                break;
              case 14:
                ++this.cp1;
                if (this.cp1 > 30)
                  this.cp1 = 0;
                this.cf = this.cp1 % 15 >= 5 ? 1 : 0;
                break;
              case 16:
                this.updateResetPoint();
                break;
            }
            if (this.isInjure > (sbyte) 0)
            {
              this.cf = 23;
              --this.isInjure;
            }
            if (this.wdx != (short) 0 || this.wdy != (short) 0)
            {
              this.startDie(this.wdx, this.wdy);
              this.wdx = (short) 0;
              this.wdy = (short) 0;
            }
            if (this.moveFast != null)
            {
              if (this.moveFast[0] == (short) 0)
              {
                ++this.moveFast[0];
                ServerEffect.addServerEffect(60, this, 1);
              }
              else if (this.moveFast[0] < (short) 10)
              {
                ++this.moveFast[0];
              }
              else
              {
                this.cx = (int) this.moveFast[1];
                this.cy = (int) this.moveFast[2];
                this.moveFast = (short[]) null;
                ServerEffect.addServerEffect(60, this, 1);
                if (this.me)
                {
                  if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) != 2)
                  {
                    this.statusMe = 4;
                    Char.myCharz().setAutoSkillPaint(GameScr.sks[38], 1);
                  }
                  else
                  {
                    Service.gI().charMove();
                    Char.myCharz().setAutoSkillPaint(GameScr.sks[38], 0);
                  }
                }
              }
            }
            if (this.statusMe != 10)
              this.fy = 0;
            if (this.isCharge)
            {
              this.cf = 17;
              if (GameCanvas.gameTick % 4 == 0)
                ServerEffect.addServerEffect(1, this.cx, this.cy + GameCanvas.transY, 1);
              if (this.me)
              {
                long num = mSystem.currentTimeMillis();
                if (num - this.last >= 1000L)
                {
                  Res.outz("%= " + (object) this.myskill.damage);
                  this.last = num;
                  this.cHP += this.cHPFull * (int) this.myskill.damage / 100;
                  this.cMP += this.cMPFull * (int) this.myskill.damage / 100;
                  if (this.cHP < this.cHPFull)
                    GameScr.startFlyText("+" + (object) (this.cHPFull * (int) this.myskill.damage / 100) + " " + mResources.HP, this.cx, this.cy - this.ch - 20, 0, -1, mFont.HP);
                  if (this.cMP < this.cMPFull)
                    GameScr.startFlyText("+" + (object) (this.cMPFull * (int) this.myskill.damage / 100) + " " + mResources.KI, this.cx, this.cy - this.ch - 20, 0, -2, mFont.MP);
                  Service.gI().skill_not_focus((sbyte) 2);
                }
              }
            }
            if (this.isFlyUp)
            {
              if (this.me)
              {
                Char.isLockKey = true;
                this.statusMe = 3;
                this.cvy = -8;
                if (this.cy <= TileMap.pxh - 240)
                {
                  this.isFlyUp = false;
                  Char.isLockKey = false;
                  this.statusMe = 4;
                }
              }
              else
              {
                this.statusMe = 3;
                this.cvy = -8;
                if (this.cy <= TileMap.pxh - 240)
                {
                  this.cvy = 0;
                  this.isFlyUp = false;
                  this.cvy = 0;
                  this.statusMe = 1;
                }
              }
            }
            this.updateMount();
            this.updEffChar();
            this.updateEye();
            this.updateFHead();
          }
        }
      }
    }
  }

  private void updateEffect()
  {
    if (this.effPaints != null)
    {
      for (int index = 0; index < this.effPaints.Length; ++index)
      {
        if (this.effPaints[index] != null)
        {
          if (this.effPaints[index].eMob != null)
          {
            if (!this.effPaints[index].isFly)
            {
              this.effPaints[index].eMob.setInjure();
              this.effPaints[index].eMob.injureBy = this;
              if (this.me)
                this.effPaints[index].eMob.hpInjure = Char.myCharz().cDamFull / 2 - Char.myCharz().cDamFull * NinjaUtil.randomNumber(11) / 100;
              int num = this.effPaints[index].eMob.h >> 1;
              if (this.effPaints[index].eMob.isBigBoss())
                num = this.effPaints[index].eMob.getY() + 20;
              GameScr.startSplash(this.effPaints[index].eMob.x, this.effPaints[index].eMob.y - num, this.cdir);
              this.effPaints[index].isFly = true;
            }
          }
          else if (this.effPaints[index].eChar != null && !this.effPaints[index].isFly)
          {
            if (this.effPaints[index].eChar.charID >= 0)
              this.effPaints[index].eChar.doInjure();
            GameScr.startSplash(this.effPaints[index].eChar.cx, this.effPaints[index].eChar.cy - (this.effPaints[index].eChar.ch >> 1), this.cdir);
            this.effPaints[index].isFly = true;
          }
          ++this.effPaints[index].index;
          if (this.effPaints[index].index >= this.effPaints[index].effCharPaint.arrEfInfo.Length)
            this.effPaints[index] = (EffectPaint) null;
        }
      }
    }
    if (this.indexEff >= 0 && this.eff != null && GameCanvas.gameTick % 2 == 0)
    {
      ++this.indexEff;
      if (this.indexEff >= this.eff.arrEfInfo.Length)
      {
        this.indexEff = -1;
        this.eff = (EffectCharPaint) null;
      }
    }
    if (this.indexEffTask < 0 || this.effTask == null || GameCanvas.gameTick % 2 != 0)
      return;
    ++this.indexEffTask;
    if (this.indexEffTask < this.effTask.arrEfInfo.Length)
      return;
    this.indexEffTask = -1;
    this.effTask = (EffectCharPaint) null;
  }

  private void checkPerformEndMovePointAction()
  {
    if (this.endMovePointCommand == null)
      return;
    Command movePointCommand = this.endMovePointCommand;
    this.endMovePointCommand = (Command) null;
    movePointCommand.performAction();
  }

  private void checkHideCharName()
  {
    if (GameCanvas.gameTick % 20 != 0 || this.charID < 0)
      return;
    this.paintName = true;
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
      if (@char != null && !@char.Equals((object) this) && (@char.cy == this.cy && Res.abs(@char.cx - this.cx) < 35 || this.cy - @char.cy < 32 && this.cy - @char.cy > 0 && Res.abs(@char.cx - this.cx) < 24))
        this.paintName = false;
    }
    for (int index = 0; index < GameScr.vNpc.size(); ++index)
    {
      Npc npc = (Npc) null;
      try
      {
        npc = (Npc) GameScr.vNpc.elementAt(index);
      }
      catch (Exception ex)
      {
      }
      if (npc != null && npc.cy == this.cy && Res.abs(npc.cx - this.cx) < 24)
        this.paintName = false;
    }
  }

  private void updateMobMe()
  {
    if (this.tMobMeBorn != 0)
      --this.tMobMeBorn;
    if (this.tMobMeBorn != 0)
      return;
    this.mobMe.xFirst = this.cdir != 1 ? this.cx + 30 : this.cx - 30;
    this.mobMe.yFirst = this.cy - 60;
    int num1 = this.mobMe.xFirst - this.mobMe.x;
    int num2 = this.mobMe.yFirst - this.mobMe.y;
    this.mobMe.x += num1 / 4;
    this.mobMe.y += num2 / 4;
    this.mobMe.dir = this.cdir;
  }

  private void updateSkillPaint()
  {
    if (this.statusMe == 14 || this.statusMe == 5)
      return;
    if (this.skillPaint != null && (this.charFocus != null && this.isMeCanAttackOtherPlayer(this.charFocus) && this.charFocus.statusMe == 14 || this.mobFocus != null && this.mobFocus.status == 0))
    {
      if (!this.me)
      {
        this.statusMe = (TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) != 2 ? 6 : 1;
        this.cp3 = 0;
      }
      this.indexSkill = 0;
      this.skillPaint = (SkillPaint) null;
      this.skillPaintRandomPaint = (SkillPaint) null;
      this.eff0 = this.eff1 = this.eff2 = (EffectCharPaint) null;
      this.i0 = this.i1 = this.i2 = 0;
      this.mobFocus = (Mob) null;
      this.charFocus = (Char) null;
      this.effPaints = (EffectPaint[]) null;
      this.currentMovePoint = (MovePoint) null;
      this.arr = (Arrow) null;
      if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) != 2)
        this.delayFall = 5;
    }
    if (this.skillPaint != null && this.arr == null && this.skillInfoPaint() != null && this.indexSkill >= this.skillInfoPaint().Length)
    {
      if (!this.me)
      {
        this.statusMe = (TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) != 2 ? 6 : 1;
        this.cp3 = 0;
      }
      this.indexSkill = 0;
      Res.outz("remove 2");
      this.skillPaint = (SkillPaint) null;
      this.skillPaintRandomPaint = (SkillPaint) null;
      this.eff0 = this.eff1 = this.eff2 = (EffectCharPaint) null;
      this.i0 = this.i1 = this.i2 = 0;
      this.arr = (Arrow) null;
      if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) != 2)
        this.delayFall = 5;
    }
    SkillInfoPaint[] skillInfoPaintArray1 = this.skillInfoPaint();
    if (skillInfoPaintArray1 == null || this.indexSkill < 0 || this.indexSkill > skillInfoPaintArray1.Length - 1)
      return;
    if (skillInfoPaintArray1[this.indexSkill].effS0Id != 0)
    {
      this.eff0 = GameScr.efs[skillInfoPaintArray1[this.indexSkill].effS0Id - 1];
      this.i0 = this.dx0 = this.dy0 = 0;
    }
    if (skillInfoPaintArray1[this.indexSkill].effS1Id != 0)
    {
      this.eff1 = GameScr.efs[skillInfoPaintArray1[this.indexSkill].effS1Id - 1];
      this.i1 = this.dx1 = this.dy1 = 0;
    }
    if (skillInfoPaintArray1[this.indexSkill].effS2Id != 0)
    {
      this.eff2 = GameScr.efs[skillInfoPaintArray1[this.indexSkill].effS2Id - 1];
      this.i2 = this.dx2 = this.dy2 = 0;
    }
    SkillInfoPaint[] skillInfoPaintArray2 = skillInfoPaintArray1;
    int indexSkill = this.indexSkill;
    if (skillInfoPaintArray2 != null && skillInfoPaintArray2[indexSkill] != null && indexSkill >= 0 && indexSkill <= skillInfoPaintArray2.Length - 1 && skillInfoPaintArray2[indexSkill].arrowId != 0)
    {
      int arrowId = skillInfoPaintArray2[indexSkill].arrowId;
      if (arrowId >= 100)
      {
        IMapObject mapObject = this.mobFocus != null ? (IMapObject) this.mobFocus : (IMapObject) this.charFocus;
        if (mapObject != null)
        {
          int num;
          if (Res.abs(mapObject.getX() - this.cx) > 4 * Res.abs(mapObject.getY() - this.cy))
          {
            num = 0;
          }
          else
          {
            num = mapObject.getY() >= this.cy ? 3 : -3;
            if (mapObject is BigBoss && ((BigBoss) mapObject).haftBody)
              num = -20;
          }
          this.dart = new PlayerDart(this, arrowId - 100, this.skillPaintRandomPaint, this.cx + (skillInfoPaintArray2[indexSkill].adx - 10) * this.cdir, this.cy + skillInfoPaintArray2[indexSkill].ady + num);
          if (this.myskill != null)
          {
            if (this.myskill.template.id == (sbyte) 1)
              SoundMn.gI().traidatKame();
            else if (this.myskill.template.id == (sbyte) 3)
              SoundMn.gI().namekKame();
            else if (this.myskill.template.id == (sbyte) 5)
              SoundMn.gI().xaydaKame();
            else if (this.myskill.template.id == (sbyte) 11)
              SoundMn.gI().nameLazer();
          }
        }
        else if (this.isFlyAndCharge || this.isUseSkillAfterCharge)
          this.stopUseChargeSkill();
      }
      else
      {
        Res.outz("g");
        this.arr = new Arrow(this, GameScr.arrs[arrowId - 1]);
        this.arr.life = 10;
        this.arr.ax = this.cx + skillInfoPaintArray2[indexSkill].adx;
        this.arr.ay = this.cy + skillInfoPaintArray2[indexSkill].ady;
      }
    }
    if ((this.mobFocus != null || !this.me && this.charFocus != null || this.me && this.charFocus != null && (this.isMeCanAttackOtherPlayer(this.charFocus) || this.isSelectingSkillBuffToPlayer()) && this.arr == null && this.dart == null) && this.indexSkill == skillInfoPaintArray1.Length - 1)
    {
      this.setAttack();
      if (this.me && this.myskill.template.isAttackSkill())
        this.saveLoadPreviousSkill();
    }
    if (this.me)
      return;
    IMapObject mapObject1 = (IMapObject) null;
    if (this.mobFocus != null)
      mapObject1 = (IMapObject) this.mobFocus;
    else if (this.charFocus != null)
      mapObject1 = (IMapObject) this.charFocus;
    if (mapObject1 == null)
      return;
    if (Res.abs(mapObject1.getX() - this.cx) < 10)
    {
      if (mapObject1.getX() > this.cx)
        this.cx -= 10;
      else
        this.cx += 10;
    }
    if (mapObject1.getX() > this.cx)
      this.cdir = 1;
    else
      this.cdir = -1;
  }

  public void saveLoadPreviousSkill()
  {
  }

  public void setResetPoint(int x, int y)
  {
    InfoDlg.hide();
    this.currentMovePoint = (MovePoint) null;
    int num = this.cx - x;
    if (this.cy - y == 0)
    {
      this.cx = x;
      Char.ischangingMap = false;
      Char.isLockKey = false;
    }
    else
    {
      this.statusMe = 16;
      this.cp2 = x;
      this.cp3 = y;
      this.cp1 = 0;
      Char.myCharz().cxSend = x;
      Char.myCharz().cySend = y;
    }
  }

  private void updateCharDeadFly()
  {
    this.isFreez = false;
    if (this.isCharge)
    {
      this.isCharge = false;
      SoundMn.gI().taitaoPause();
      Service.gI().skill_not_focus((sbyte) 3);
    }
    ++this.cp1;
    this.cx += (this.cp2 - this.cx) / 4;
    if (this.cp1 > 7)
      this.cy += (this.cp3 - this.cy) / 4;
    else
      this.cy += this.cp1 - 10;
    if (Res.abs(this.cp2 - this.cx) < 4 && Res.abs(this.cp3 - this.cy) < 10)
    {
      this.cx = this.cp2;
      this.cy = this.cp3;
      this.statusMe = 14;
      if (this.me)
      {
        GameScr.gI().resetButton();
        Service.gI().charMove();
      }
    }
    this.cf = 23;
  }

  private void updateResetPoint()
  {
    InfoDlg.hide();
    GameCanvas.clearAllPointerEvent();
    this.currentMovePoint = (MovePoint) null;
    ++this.cp1;
    this.cx += (this.cp2 - this.cx) / 4;
    if (this.cp1 > 7)
      this.cy += (this.cp3 - this.cy) / 4;
    else
      this.cy += this.cp1 - 10;
    if (Res.abs(this.cp2 - this.cx) < 4 && Res.abs(this.cp3 - this.cy) < 10)
    {
      this.cx = this.cp2;
      this.cy = this.cp3;
      this.statusMe = 1;
      this.cp3 = 0;
      Char.ischangingMap = false;
      Service.gI().charMove();
    }
    this.cf = 23;
  }

  public void updateSkillFall()
  {
  }

  public void updateSkillStand()
  {
    this.ty = 0;
    ++this.cp1;
    if (this.cdir == 1)
    {
      if ((TileMap.tileTypeAtPixel(this.cx + this.chw, this.cy - this.chh) & 4) == 4)
        this.cvx = 0;
    }
    else if ((TileMap.tileTypeAtPixel(this.cx - this.chw, this.cy - this.chh) & 8) == 8)
      this.cvx = 0;
    if (this.cy > this.ch && TileMap.tileTypeAt(this.cx, this.cy - this.ch + 24, 8192))
    {
      if (!TileMap.tileTypeAt(this.cx, this.cy, 2))
      {
        this.statusMe = 4;
        this.cp1 = 0;
        this.cp2 = 0;
        this.cvy = 1;
      }
      else
        this.cy = TileMap.tileYofPixel(this.cy);
    }
    this.cx += this.cvx;
    this.cy += this.cvy;
    if (this.cy < 0)
      this.cy = this.cvy = 0;
    if (this.cvy == 0)
    {
      if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) != 2)
      {
        this.statusMe = 4;
        this.cvx = (this.cspeed >> 1) * this.cdir;
        this.cp1 = this.cp2 = 0;
      }
    }
    else if (this.cvy < 0)
    {
      ++this.cvy;
      if (this.cvy == 0)
        this.cvy = 1;
    }
    else
    {
      if (this.cvy < 20 && this.cp1 % 5 == 0)
        ++this.cvy;
      if (this.cvy > 3)
        this.cvy = 3;
      if ((TileMap.tileTypeAtPixel(this.cx, this.cy + 3) & 2) == 2 && this.cy <= TileMap.tileXofPixel(this.cy + 3))
      {
        this.cvx = this.cvy = 0;
        this.cy = TileMap.tileXofPixel(this.cy + 3);
      }
    }
    if (this.cvx > 0)
    {
      --this.cvx;
    }
    else
    {
      if (this.cvx >= 0)
        return;
      ++this.cvx;
    }
  }

  public void updateCharAutoJump()
  {
    this.isFreez = false;
    if (this.isCharge)
    {
      this.isCharge = false;
      SoundMn.gI().taitaoPause();
      Service.gI().skill_not_focus((sbyte) 3);
    }
    this.cx += this.cvx * this.cdir;
    this.cy += this.cvyJump;
    ++this.cvyJump;
    this.cf = this.cp1 != 0 ? 23 : 7;
    if (this.cvyJump == -3)
      this.cf = 8;
    else if (this.cvyJump == -2)
      this.cf = 9;
    else if (this.cvyJump == -1)
      this.cf = 10;
    else if (this.cvyJump == 0)
      this.cf = 11;
    if (this.cvyJump != 0)
      return;
    this.statusMe = 6;
    this.cp3 = 0;
    ((MovePoint) this.vMovePoints.firstElement()).status = 4;
    this.isJump = true;
    this.cp1 = 0;
    this.cvy = 1;
  }

  public int getVx(int size, int dx, int dy)
  {
    if (dy > 0 && !TileMap.tileTypeAt(this.cx, this.cy, 2))
    {
      if (dx - dy <= 10)
        return 5;
      if (dx - dy <= 30)
        return 6;
      if (dx - dy <= 50)
        return 7;
      if (dx - dy <= 70)
        return 8;
    }
    if (dx <= 30)
      return 4;
    if (dx <= 160)
      return 5;
    if (dx <= 270)
      return 6;
    return dx <= 320 ? 7 : 8;
  }

  public void hide()
  {
    this.isHide = true;
    EffecMn.addEff(new Effect(107, this.cx, this.cy + 25, 3, 15, 1));
  }

  public void show()
  {
    this.isHide = false;
    EffecMn.addEff(new Effect(107, this.cx, this.cy + 25, 3, 10, 1));
  }

  public int getVy(int size, int dx, int dy)
  {
    if (dy <= 10)
      return 5;
    if (dy <= 20)
      return 6;
    if (dy <= 30)
      return 7;
    if (dy <= 40)
      return 8;
    return dy <= 50 ? 9 : 10;
  }

  public int returnAct(int xFirst, int yFirst, int xEnd, int yEnd)
  {
    int num1 = xEnd - xFirst;
    int num2 = yEnd - yFirst;
    if (num1 == 0 && num2 == 0)
      return 1;
    if (num2 == 0 && yFirst % 24 == 0 && TileMap.tileTypeAt(xFirst, yFirst, 2))
      return 2;
    if (num2 > 0 && (yFirst % 24 != 0 || !TileMap.tileTypeAt(xFirst, yFirst, 2)))
      return 4;
    this.cvy = -10;
    this.cp1 = 0;
    this.cdir = num1 <= 0 ? -1 : 1;
    this.cvx = num1 > 5 ? (num1 > 10 ? 5 : 3) : 0;
    return 9;
  }

  public void setAutoJump()
  {
    int num = ((MovePoint) this.vMovePoints.firstElement()).xEnd - this.cx;
    this.cvyJump = -10;
    this.cp1 = 0;
    this.cdir = num <= 0 ? -1 : 1;
    if (num <= 6)
      this.cvx = 0;
    else if (num <= 20)
      this.cvx = 3;
    else
      this.cvx = 5;
  }

  public void updateCharStand()
  {
    this.isSoundJump = false;
    this.isAttack = false;
    this.isAttFly = false;
    this.cvx = 0;
    this.cvy = 0;
    ++this.cp1;
    if (this.cp1 > 30)
      this.cp1 = 0;
    this.cf = this.cp1 % 15 >= 5 ? 1 : 0;
    this.updateCharInBridge();
    if (!this.me)
    {
      ++this.cp3;
      if (this.cp3 > 50)
      {
        this.cp3 = 0;
        this.currentMovePoint = (MovePoint) null;
      }
    }
    this.updateSuperEff();
    if (!this.me || GameScr.vCharInMap.size() == 0 || TileMap.mapID != 50)
      return;
    Char @char = (Char) GameScr.vCharInMap.elementAt(0);
    if (!@char.changePos)
    {
      if (@char.statusMe != 2)
        @char.moveTo(this.cx - 45, this.cy, 0);
      @char.lastUpdateTime = mSystem.currentTimeMillis();
      if (Res.abs(this.cx - 45 - @char.cx) <= 10)
        @char.changePos = true;
    }
    else
    {
      if (@char.statusMe != 2)
        @char.moveTo(this.cx + 45, this.cy, 0);
      @char.lastUpdateTime = mSystem.currentTimeMillis();
      if (Res.abs(this.cx + 45 - @char.cx) <= 10)
        @char.changePos = false;
    }
    if (GameCanvas.gameTick % 100 != 0)
      return;
    @char.addInfo("Cắc cùm cum");
  }

  public void updateSuperEff()
  {
    if (GameCanvas.panel.isShow || this.isCopy || this.isFusion || this.isSetPos || this.isPet || this.isMiniPet || this.isMonkey == (sbyte) 1)
      return;
    if (this.me)
    {
      if (Char.isPaintAura && this.idAuraEff > (short) -1)
        return;
    }
    else if (this.idAuraEff > (short) -1)
      return;
    ++this.ty;
    if (this.clevel >= 14)
      return;
    if (this.clevel >= 9 && !GameCanvas.lowGraphic && (this.ty == 40 || this.ty == 50))
    {
      GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
      GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
      this.addDustEff(1);
    }
    if (this.ty <= 50 || this.clevel < 9)
      return;
    if (this.cgender == 0)
    {
      if (GameCanvas.gameTick % 25 == 0)
        ServerEffect.addServerEffect(114, this, 1);
      if (this.clevel >= 13 && GameCanvas.gameTick % 4 == 0)
        ServerEffect.addServerEffect(132, this, 1);
    }
    if (this.cgender == 1)
    {
      if (GameCanvas.gameTick % 4 == 0)
        ServerEffect.addServerEffect(132, this, 1);
      if (this.clevel >= 13 && GameCanvas.gameTick % 7 == 0)
        ServerEffect.addServerEffect(131, this, 1);
    }
    if (this.cgender != 2)
      return;
    if (GameCanvas.gameTick % 7 == 0)
      ServerEffect.addServerEffect(131, this, 1);
    if (this.clevel < 13 || GameCanvas.gameTick % 25 != 0)
      return;
    ServerEffect.addServerEffect(114, this, 1);
  }

  public float getSoundVolumn()
  {
    if (this.me)
      return 0.1f;
    int num = Res.abs(Char.myChar.cx - this.cx);
    return num >= 0 && num <= 50 ? 0.1f : 0.05f;
  }

  public void updateCharRun()
  {
    int num1 = this.isMonkey != (sbyte) 1 || this.me ? 1 : 2;
    if (this.cx >= GameScr.cmx && this.cx <= GameScr.cmx + GameCanvas.w)
    {
      if (this.isMonkey == (sbyte) 0)
        SoundMn.gI().charRun(this.getSoundVolumn());
      else
        SoundMn.gI().monkeyRun(this.getSoundVolumn());
    }
    this.ty = 0;
    this.isFreez = false;
    if (this.isCharge)
    {
      this.isCharge = false;
      SoundMn.gI().taitaoPause();
      Service.gI().skill_not_focus((sbyte) 3);
    }
    int num2 = 0;
    if (!this.me && this.currentMovePoint != null)
      num2 = Char.abs(this.cx - this.currentMovePoint.xEnd);
    ++this.cp1;
    if (this.cp1 >= 10)
    {
      this.cp1 = 0;
      this.cBonusSpeed = 0;
    }
    this.cf = (this.cp1 >> 1) + 2;
    if ((TileMap.tileTypeAtPixel(this.cx, this.cy - 1) & 64) == 64)
      this.cx += this.cvx * num1 >> 1;
    else
      this.cx += this.cvx * num1;
    if (this.cdir == 1)
    {
      if (TileMap.tileTypeAt(this.cx + this.chw, this.cy - this.chh, 4))
      {
        if (this.me)
        {
          this.cvx = 0;
          this.cx = TileMap.tileXofPixel(this.cx + this.chw) - this.chw;
        }
        else
          this.stop();
      }
    }
    else if (TileMap.tileTypeAt(this.cx - this.chw - 1, this.cy - this.chh, 8))
    {
      if (this.me)
      {
        this.cvx = 0;
        this.cx = TileMap.tileXofPixel(this.cx - this.chw - 1) + (int) TileMap.size + this.chw;
      }
      else
        this.stop();
    }
    if (this.me)
    {
      if (this.cvx > 0)
        --this.cvx;
      else if (this.cvx < 0)
      {
        ++this.cvx;
      }
      else
      {
        if (this.cx - this.cxSend != 0 && this.me)
          Service.gI().charMove();
        this.statusMe = 1;
        this.cBonusSpeed = 0;
      }
    }
    if ((TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) != 2)
    {
      if (this.me)
      {
        if (this.cx - this.cxSend != 0 || this.cy - this.cySend != 0)
          Service.gI().charMove();
        this.cf = 7;
        this.statusMe = 4;
        this.delayFall = 0;
        this.cvx = 3 * this.cdir;
        this.cp2 = 0;
      }
      else
        this.stop();
    }
    if (!this.me && this.currentMovePoint != null && Char.abs(this.cx - this.currentMovePoint.xEnd) > num2)
      this.stop();
    GameCanvas.gI().startDust(this.cdir, this.cx - (this.cdir << 3), this.cy);
    this.updateCharInBridge();
    this.addDustEff(2);
  }

  private void stop()
  {
    this.statusMe = 6;
    this.cp3 = 0;
    this.cvx = 0;
    this.cvy = 0;
    this.cp1 = this.cp2 = 0;
  }

  public static int abs(int i) => i > 0 ? i : -i;

  public void updateCharJump()
  {
    this.setMountIsStart();
    this.ty = 0;
    this.isFreez = false;
    if (this.isCharge)
    {
      this.isCharge = false;
      SoundMn.gI().taitaoPause();
      Service.gI().skill_not_focus((sbyte) 3);
    }
    this.addDustEff(3);
    this.cx += this.cvx;
    this.cy += this.cvy;
    if (this.cy < 0)
    {
      this.cy = 0;
      this.cvy = -1;
    }
    ++this.cvy;
    if (this.cvy > 0)
      this.cvy = 0;
    if (!this.me && this.currentMovePoint != null)
    {
      int num = this.currentMovePoint.xEnd - this.cx;
      if (num > 0)
      {
        if (this.cvx > num)
          this.cvx = num;
        if (this.cvx < 0)
          this.cvx = num;
      }
      else if (num < 0)
      {
        if (this.cvx < num)
          this.cvx = num;
        if (this.cvx > 0)
          this.cvx = num;
      }
      else
        this.cvx = num;
    }
    if (this.cdir == 1)
    {
      if ((TileMap.tileTypeAtPixel(this.cx + this.chw, this.cy - 1) & 4) == 4 && this.cx <= TileMap.tileXofPixel(this.cx + this.chw) + 12)
      {
        this.cx = TileMap.tileXofPixel(this.cx + this.chw) - this.chw;
        this.cvx = 0;
      }
    }
    else if ((TileMap.tileTypeAtPixel(this.cx - this.chw, this.cy - 1) & 8) == 8 && this.cx >= TileMap.tileXofPixel(this.cx - this.chw) + 12)
    {
      this.cx = TileMap.tileXofPixel(this.cx + 24 - this.chw) + this.chw;
      this.cvx = 0;
    }
    if (this.cvy == 0)
    {
      if (!this.isAttFly)
      {
        if (this.me)
          this.setCharFallFromJump();
        else
          this.stop();
      }
      else
        this.setCharFallFromJump();
    }
    if (this.me && !Char.ischangingMap && this.isInWaypoint())
    {
      Service.gI().charMove();
      if (TileMap.isTrainingMap())
      {
        Char.ischangingMap = true;
        Service.gI().getMapOffline();
      }
      else
        Service.gI().requestChangeMap();
      Char.isLockKey = true;
      Char.ischangingMap = true;
      GameCanvas.clearKeyHold();
      GameCanvas.clearKeyPressed();
      InfoDlg.showWait();
    }
    else
    {
      if (this.statusMe != 16 && (TileMap.tileTypeAt(this.cx, this.cy - this.ch + 24, 8192) || this.cy < 0))
      {
        this.statusMe = 4;
        this.cp1 = 0;
        this.cp2 = 0;
        this.cvy = 1;
        this.delayFall = 0;
        if (this.cy < 0)
          this.cy = 0;
        this.cy = TileMap.tileYofPixel(this.cy + 25);
        GameCanvas.clearKeyHold();
      }
      if (this.cp3 < 0)
        ++this.cp3;
      this.cf = 7;
      if (this.me || this.currentMovePoint == null || this.cy >= this.currentMovePoint.yEnd)
        return;
      this.stop();
    }
  }

  public bool checkInRangeJump(int x1, int xw1, int xmob, int y1, int yh1, int ymob) => xmob <= xw1 && xmob >= x1 && ymob <= y1 && ymob >= yh1;

  public void setCharFallFromJump()
  {
    this.cyStartFall = this.cy;
    this.cp1 = 0;
    this.cp2 = 0;
    this.statusMe = 10;
    this.cvx = this.cdir << 2;
    this.cvy = 0;
    this.cy = TileMap.tileYofPixel(this.cy) + 12;
    if (!this.me || this.cx - this.cxSend == 0 && this.cy - this.cySend == 0 || Res.abs(Char.myCharz().cx - Char.myCharz().cxSend) <= 96 && Res.abs(Char.myCharz().cy - Char.myCharz().cySend) <= 24)
      return;
    Service.gI().charMove();
  }

  public void updateCharFall()
  {
    if (this.holder)
      return;
    this.ty = 0;
    if (this.cy + 4 >= TileMap.pxh)
    {
      this.statusMe = 1;
      if (this.me)
        SoundMn.gI().charFall();
      this.cvx = this.cvy = 0;
      this.cp3 = 0;
    }
    else
    {
      if (this.cy % 24 == 0 && (TileMap.tileTypeAtPixel(this.cx, this.cy) & 2) == 2)
      {
        this.delayFall = 0;
        if (this.me)
        {
          if (this.cy - this.cySend > 0)
            Service.gI().charMove();
          else if (this.cx - this.cxSend != 0 || this.cy - this.cySend < 0)
            Service.gI().charMove();
          this.cvx = this.cvy = 0;
          this.cp1 = this.cp2 = 0;
          this.statusMe = 1;
          this.cp3 = 0;
          return;
        }
        this.stop();
        this.cf = 0;
        GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
        GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
        this.addDustEff(1);
      }
      if (this.delayFall > 0)
      {
        --this.delayFall;
        if (this.delayFall % 10 > 5)
          ++this.cy;
        else
          --this.cy;
      }
      else
      {
        this.cf = this.cvy >= -4 ? 12 : 7;
        this.cx += this.cvx;
        if (!this.me && this.currentMovePoint != null)
        {
          int num = this.currentMovePoint.xEnd - this.cx;
          if (num > 0)
          {
            if (this.cvx > num)
              this.cvx = num;
            if (this.cvx < 0)
              this.cvx = num;
          }
          else if (num < 0)
          {
            if (this.cvx < num)
              this.cvx = num;
            if (this.cvx > 0)
              this.cvx = num;
          }
          else
            this.cvx = num;
        }
        ++this.cvy;
        if (this.cvy > 8)
          this.cvy = 8;
        if (this.skillPaintRandomPaint == null)
          this.cy += this.cvy;
        if (this.cdir == 1)
        {
          if ((TileMap.tileTypeAtPixel(this.cx + this.chw, this.cy - 1) & 4) == 4 && this.cx <= TileMap.tileXofPixel(this.cx + this.chw) + 12)
          {
            this.cx = TileMap.tileXofPixel(this.cx + this.chw) - this.chw;
            this.cvx = 0;
          }
        }
        else if ((TileMap.tileTypeAtPixel(this.cx - this.chw, this.cy - 1) & 8) == 8 && this.cx >= TileMap.tileXofPixel(this.cx - this.chw) + 12)
        {
          this.cx = TileMap.tileXofPixel(this.cx + 24 - this.chw) + this.chw;
          this.cvx = 0;
        }
        if (this.cvy > 3 && (this.cyStartFall == 0 || this.cyStartFall <= TileMap.tileYofPixel(this.cy + 3)) && (TileMap.tileTypeAtPixel(this.cx, this.cy + 3) & 2) == 2)
        {
          if (this.me)
          {
            this.cyStartFall = 0;
            this.cvx = this.cvy = 0;
            this.cp1 = this.cp2 = 0;
            this.cy = TileMap.tileXofPixel(this.cy + 3);
            this.statusMe = 1;
            if (this.me)
              SoundMn.gI().charFall();
            this.cp3 = 0;
            GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
            GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
            this.addDustEff(1);
            if (this.cy - this.cySend > 0)
            {
              if (!this.me)
                return;
              Service.gI().charMove();
            }
            else
            {
              if (this.cx - this.cxSend == 0 && this.cy - this.cySend >= 0 || !this.me)
                return;
              Service.gI().charMove();
            }
          }
          else
          {
            this.stop();
            this.cy = TileMap.tileXofPixel(this.cy + 3);
            this.cf = 0;
            GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
            GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
            this.addDustEff(1);
          }
        }
        else
        {
          this.cf = 12;
          if (this.me)
          {
            if (!this.isAttack)
              ;
          }
          else
          {
            if ((TileMap.tileTypeAtPixel(this.cx, this.cy + 1) & 2) == 2)
              this.cf = 0;
            if (this.currentMovePoint == null || this.cy <= this.currentMovePoint.yEnd)
              return;
            this.stop();
          }
        }
      }
    }
  }

  public void updateCharFly()
  {
    int num1 = this.isMonkey != (sbyte) 1 || this.me ? 1 : 2;
    this.setMountIsStart();
    if (this.statusMe != 16 && (TileMap.tileTypeAt(this.cx, this.cy - this.ch + 24, 8192) || this.cy < 0))
    {
      if (this.cy - this.ch < 0)
        this.cy = this.ch;
      this.cf = 7;
      this.statusMe = 4;
      this.cvx = 0;
      this.cp2 = 0;
      this.currentMovePoint = (MovePoint) null;
    }
    else
    {
      int cy = this.cy;
      ++this.cp1;
      if (this.cp1 >= 9)
      {
        this.cp1 = 0;
        if (!this.me)
          this.cvx = this.cvy = 0;
        this.cBonusSpeed = 0;
      }
      this.cf = 8;
      if (Res.abs(this.cvx) <= 4 && this.me)
      {
        if (this.currentMovePoint != null)
        {
          int num2 = Char.abs(this.cx - this.currentMovePoint.xEnd);
          int num3 = Char.abs(this.cy - this.currentMovePoint.yEnd);
          this.cf = num2 <= num3 * 10 ? (num2 <= num3 || num2 <= 48 || num3 <= 32 ? 7 : 8) : 8;
        }
        else
        {
          if (this.cvy < 0)
            this.cvy = 0;
          if (this.cvy > 16)
            this.cvy = 16;
          this.cf = 7;
        }
      }
      if (!this.me)
      {
        if (Char.abs(this.cvx) < 2)
          this.cvx = (this.cdir << 1) * num1;
        if (this.cvy != 0)
          this.cf = 7;
        if (Char.abs(this.cvx) <= 2)
        {
          ++this.cp2;
          if (this.cp2 > 32)
          {
            this.statusMe = 4;
            this.cvx = 0;
            this.cvy = 0;
          }
        }
      }
      if (this.cdir == 1)
      {
        if (TileMap.tileTypeAt(this.cx + this.chw, this.cy - 1, 4))
        {
          this.cvx = 0;
          this.cx = TileMap.tileXofPixel(this.cx + this.chw) - this.chw;
          if (this.cvy == 0)
            this.currentMovePoint = (MovePoint) null;
        }
      }
      else if (TileMap.tileTypeAt(this.cx - this.chw - 1, this.cy - 1, 8))
      {
        this.cvx = 0;
        this.cx = TileMap.tileXofPixel(this.cx - this.chw - 1) + (int) TileMap.size + this.chw;
        if (this.cvy == 0)
          this.currentMovePoint = (MovePoint) null;
      }
      this.cx += this.cvx * num1;
      this.cy += this.cvy * num1;
      if (!this.isMount && cy - this.cy == 0)
      {
        ++this.ty;
        ++this.wt;
        this.fy += this.wy ? -1 : 1;
        if (this.wt == 10)
        {
          this.wt = 0;
          this.wy = !this.wy;
        }
        if (this.ty > 20)
        {
          this.delayFall = 10;
          if (GameCanvas.gameTick % 3 == 0)
            ServerEffect.addServerEffect(111, this.cx + (this.cdir != 1 ? 27 : -17), this.cy + this.fy + 13, 1, this.cdir == 1 ? 0 : 2);
        }
      }
      if (!this.me)
        return;
      if (this.cvx > 0)
        --this.cvx;
      else if (this.cvx < 0)
        ++this.cvx;
      else if (this.cvy == 0)
      {
        this.statusMe = 4;
        this.checkDelayFallIfTooHigh();
        Service.gI().charMove();
      }
      if ((TileMap.tileTypeAtPixel(this.cx, this.cy + 20) & 2) == 2 || (TileMap.tileTypeAtPixel(this.cx, this.cy + 40) & 2) == 2)
      {
        if (this.cvy == 0)
          this.delayFall = 0;
        this.cyStartFall = 0;
        this.cvx = this.cvy = 0;
        this.cp1 = this.cp2 = 0;
        this.statusMe = 4;
        this.addDustEff(3);
      }
      if (Char.abs(this.cx - this.cxSend) <= 96 && Char.abs(this.cy - this.cySend) <= 24)
        return;
      Service.gI().charMove();
    }
  }

  public void setMount(int cid, int ctrans, int cgender)
  {
    this.idcharMount = cid;
    this.transMount = ctrans;
    this.genderMount = cgender;
    this.speedMount = 30;
    if (this.transMount < 0)
    {
      this.transMount = 0;
      this.xMount = GameScr.cmx + GameCanvas.w + 50;
      this.dxMount = -19;
    }
    else if (this.transMount == 1)
    {
      this.transMount = 2;
      this.xMount = GameScr.cmx - 100;
      this.dxMount = -33;
    }
    this.dyMount = -17;
    this.yMount = this.cy;
    this.frameMount = 0;
    this.frameNewMount = 0;
    this.isMount = false;
    this.isEndMount = false;
  }

  public void updateMount()
  {
    ++this.frameMount;
    if (this.frameMount > this.FrameMount.Length - 1)
      this.frameMount = 0;
    ++this.frameNewMount;
    if (this.frameNewMount > 1000)
      this.frameNewMount = 0;
    if (this.isStartMount && !this.isMount)
    {
      this.yMount = this.cy;
      if (this.transMount == 0)
      {
        if (this.xMount - this.cx >= this.speedMount)
        {
          this.xMount -= this.speedMount;
        }
        else
        {
          this.xMount = this.cx;
          this.isMount = true;
          this.isEndMount = false;
        }
      }
      else
      {
        if (this.transMount != 2)
          return;
        if (this.cx - this.xMount >= this.speedMount)
        {
          this.xMount += this.speedMount;
        }
        else
        {
          this.xMount = this.cx;
          this.isMount = true;
          this.isEndMount = false;
        }
      }
    }
    else if (this.isMount)
    {
      if (this.statusMe == 14 || this.ySd - this.cy < 24)
        this.setMountIsEnd();
      this.cf = this.cp1 % 15 >= 5 ? 1 : 0;
      this.transMount = this.cdir;
      this.updateSuperEff();
      if (this.transMount < 0)
      {
        this.transMount = 0;
        this.dxMount = -19;
      }
      else if (this.transMount == 1)
      {
        this.transMount = 2;
        this.dxMount = -31;
        if (this.isEventMount)
          this.dxMount = -38;
      }
      this.dyMount = this.skillInfoPaint() == null ? -17 : -15;
      this.yMount = this.cy;
      this.xMount = this.cx;
    }
    else if (this.isEndMount)
    {
      if (this.transMount == 0)
      {
        if (this.xMount > GameScr.cmx - 100)
        {
          this.xMount -= 20;
        }
        else
        {
          this.isStartMount = false;
          this.isMount = false;
          this.isEndMount = false;
        }
      }
      else
      {
        if (this.transMount != 2)
          return;
        if (this.xMount < GameScr.cmx + GameCanvas.w + 50)
        {
          this.xMount += 20;
        }
        else
        {
          this.isStartMount = false;
          this.isMount = false;
          this.isEndMount = false;
        }
      }
    }
    else
    {
      if (this.isStartMount && this.isMount && this.isEndMount)
        return;
      this.xMount = GameScr.cmx - 100;
      this.yMount = GameScr.cmy - 100;
    }
  }

  public void getMountData()
  {
    if (Mob.arrMobTemplate[50].data != null)
      return;
    Mob.arrMobTemplate[50].data = new EffectData();
    string path = "/Mob/" + (object) 50;
    if (MyStream.readFile(path) != null)
    {
      Mob.arrMobTemplate[50].data.readData(path + "/data");
      Mob.arrMobTemplate[50].data.img = GameCanvas.loadImage(path + "/img.png");
    }
    else
      Service.gI().requestModTemplate(50);
    Mob.lastMob.addElement((object) (50.ToString() + string.Empty));
  }

  public void checkFrameTick(int[] array)
  {
    ++this.t;
    if (this.t > array.Length - 1)
      this.t = 0;
    this.fM = array[this.t];
  }

  public void paintMount1(mGraphics g)
  {
    if (this.xMount <= GameScr.cmx || this.xMount >= GameScr.cmx + GameCanvas.w)
      return;
    if (this.me)
    {
      if (!this.isEndMount && !this.isStartMount && !this.isMount)
        return;
      if ((int) this.idMount >= (int) Char.ID_NEW_MOUNT)
      {
        FrameImage fraImage = mSystem.getFraImage(this.strMount + (object) ((int) this.idMount - (int) Char.ID_NEW_MOUNT) + "_0");
        fraImage?.drawFrame(this.frameNewMount / 2 % fraImage.nFrame, this.xMount, this.yMount + this.fy, this.transMount, 3, g);
      }
      else
      {
        if (this.isSpeacialMount)
          return;
        if (this.isEventMount)
          g.drawRegion(Char.imgEventMountWing, 0, (int) this.FrameMount[this.frameMount] * 60, 60, 60, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        else if (this.genderMount == 2)
        {
          if (!this.isMountVip)
            g.drawRegion(Char.imgMount_XD, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
          else
            g.drawRegion(Char.imgMount_XD_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        }
        else
        {
          if (this.genderMount != 1)
            return;
          if (!this.isMountVip)
            g.drawRegion(Char.imgMount_NM, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
          else
            g.drawRegion(Char.imgMount_NM_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        }
      }
    }
    else
    {
      if (this.me)
        return;
      if ((int) this.idMount >= (int) Char.ID_NEW_MOUNT)
      {
        FrameImage fraImage = mSystem.getFraImage(this.strMount + (object) ((int) this.idMount - (int) Char.ID_NEW_MOUNT) + "_0");
        fraImage?.drawFrame(this.frameNewMount / 2 % fraImage.nFrame, this.xMount, this.yMount + this.fy, this.transMount, 3, g);
      }
      else
      {
        if (this.isSpeacialMount)
          return;
        if (this.isEventMount)
        {
          g.drawRegion(Char.imgEventMountWing, 0, (int) this.FrameMount[this.frameMount] * 60, 60, 60, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        }
        else
        {
          if (!this.isMount)
            return;
          if (this.genderMount == 2)
          {
            if (!this.isMountVip)
              g.drawRegion(Char.imgMount_XD, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
            else
              g.drawRegion(Char.imgMount_XD_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
          }
          else
          {
            if (this.genderMount != 1)
              return;
            if (!this.isMountVip)
              g.drawRegion(Char.imgMount_NM, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
            else
              g.drawRegion(Char.imgMount_NM_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
          }
        }
      }
    }
  }

  public void paintMount2(mGraphics g)
  {
    if (this.xMount <= GameScr.cmx || this.xMount >= GameScr.cmx + GameCanvas.w)
      return;
    if (this.me)
    {
      if (!this.isEndMount && !this.isStartMount && !this.isMount)
        return;
      if ((int) this.idMount >= (int) Char.ID_NEW_MOUNT)
      {
        FrameImage fraImage = mSystem.getFraImage(this.strMount + (object) ((int) this.idMount - (int) Char.ID_NEW_MOUNT) + "_1");
        fraImage?.drawFrame(this.frameNewMount / 2 % fraImage.nFrame, this.xMount, this.yMount + this.fy, this.transMount, 3, g);
      }
      else if (this.isSpeacialMount)
      {
        this.checkFrameTick(this.move);
        if (Mob.arrMobTemplate[50] != null && Mob.arrMobTemplate[50].data != null)
          Mob.arrMobTemplate[50].data.paintFrame(g, this.fM, this.xMount + (this.cdir != 1 ? 8 : -8), this.yMount + 35, this.cdir != 1 ? 1 : 0, 0);
        else
          this.getMountData();
      }
      else if (this.isEventMount)
        g.drawRegion(Char.imgEventMount, 0, (int) this.FrameMount[this.frameMount] * 60, 60, 60, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
      else if (this.genderMount == 0)
      {
        if (!this.isMountVip)
          g.drawRegion(Char.imgMount_TD, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        else
          g.drawRegion(Char.imgMount_TD_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
      }
      else
      {
        if (this.genderMount != 1)
          return;
        if (!this.isMountVip)
          g.drawRegion(Char.imgMount_NM_1, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        else
          g.drawRegion(Char.imgMount_NM_1_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
      }
    }
    else
    {
      if (this.me)
        return;
      if ((int) this.idMount >= (int) Char.ID_NEW_MOUNT)
      {
        FrameImage fraImage = mSystem.getFraImage(this.strMount + (object) ((int) this.idMount - (int) Char.ID_NEW_MOUNT) + "_1");
        fraImage?.drawFrame(this.frameNewMount / 2 % fraImage.nFrame, this.xMount, this.yMount + this.fy, this.transMount, 3, g);
      }
      else if (this.isSpeacialMount)
      {
        this.checkFrameTick(this.move);
        if (Mob.arrMobTemplate[50] != null && Mob.arrMobTemplate[50].data != null)
          Mob.arrMobTemplate[50].data.paintFrame(g, this.fM, this.xMount + (this.cdir != 1 ? 8 : -8), this.yMount + 35, this.cdir != 1 ? 1 : 0, 0);
        else
          this.getMountData();
      }
      else
      {
        if (this.isEventMount)
          g.drawRegion(Char.imgEventMount, 0, (int) this.FrameMount[this.frameMount] * 60, 60, 60, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        if (!this.isMount)
          return;
        if (this.genderMount == 0)
        {
          if (!this.isMountVip)
            g.drawRegion(Char.imgMount_TD, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
          else
            g.drawRegion(Char.imgMount_TD_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        }
        else
        {
          if (this.genderMount != 1)
            return;
          if (!this.isMountVip)
            g.drawRegion(Char.imgMount_NM_1, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
          else
            g.drawRegion(Char.imgMount_NM_1_VIP, 0, (int) this.FrameMount[this.frameMount] * 40, 50, 40, this.transMount, this.xMount + this.dxMount, this.yMount + this.dyMount + this.fy, 0);
        }
      }
    }
  }

  public void setMountIsStart()
  {
    if (this.me)
    {
      this.isHaveMount = this.checkHaveMount();
      if (TileMap.isVoDaiMap())
        this.isHaveMount = false;
    }
    if (!this.isHaveMount)
      return;
    if (this.ySd - this.cy <= 20)
      this.xChar = this.cx;
    if (this.xdis < 100)
      this.xdis = Res.abs(this.xChar - this.cx);
    if (this.xdis < 70 || this.ySd - this.cy <= 30 || this.isStartMount || this.isEndMount)
      return;
    this.setMount(this.charID, this.cdir, this.cgender);
    this.isStartMount = true;
  }

  public void setMountIsEnd()
  {
    if (this.ySd - this.cy >= 24 || this.isEndMount)
      return;
    this.isStartMount = false;
    this.isMount = false;
    this.isEndMount = true;
    this.xdis = 0;
  }

  public bool checkHaveMount()
  {
    bool flag = false;
    short num = -1;
    Item[] arrItemBody = this.arrItemBody;
    for (int index = 0; index < arrItemBody.Length; ++index)
    {
      if (arrItemBody[index] != null && (arrItemBody[index].template.type == (sbyte) 24 || arrItemBody[index].template.type == (sbyte) 23))
      {
        num = arrItemBody[index].template.part < (short) 0 ? arrItemBody[index].template.id : (short) ((int) Char.ID_NEW_MOUNT + (int) arrItemBody[index].template.part);
        flag = true;
        break;
      }
    }
    this.isMountVip = false;
    this.isSpeacialMount = false;
    this.isEventMount = false;
    this.idMount = (short) -1;
    switch (num)
    {
      case 349:
      case 350:
      case 351:
        this.isMountVip = true;
        break;
      case 396:
        this.isEventMount = true;
        break;
      case 532:
        this.isSpeacialMount = true;
        break;
      default:
        if ((int) num >= (int) Char.ID_NEW_MOUNT)
        {
          this.idMount = num;
          break;
        }
        break;
    }
    return flag;
  }

  private void checkDelayFallIfTooHigh()
  {
    bool flag = true;
    for (int index = 0; index < 150; index += 24)
    {
      if ((TileMap.tileTypeAtPixel(this.cx, this.cy + index) & 2) == 2 || this.cy + index > TileMap.tmh * (int) TileMap.size - 24)
      {
        flag = false;
        break;
      }
    }
    if (!flag)
      return;
    this.delayFall = 40;
  }

  public void setDefaultPart()
  {
    this.setDefaultWeapon();
    this.setDefaultBody();
    this.setDefaultLeg();
  }

  public void setDefaultWeapon()
  {
    if (this.cgender != 0)
      return;
    this.wp = 0;
  }

  public void setDefaultBody()
  {
    if (this.cgender == 0)
      this.body = 57;
    else if (this.cgender == 1)
    {
      this.body = 59;
    }
    else
    {
      if (this.cgender != 2)
        return;
      this.body = 57;
    }
  }

  public void setDefaultLeg()
  {
    if (this.cgender == 0)
      this.leg = 58;
    else if (this.cgender == 1)
    {
      this.leg = 60;
    }
    else
    {
      if (this.cgender != 2)
        return;
      this.leg = 58;
    }
  }

  public bool isSelectingSkillUseAlone() => this.myskill != null && this.myskill.template.isUseAlone();

  public bool isSelectingSkillBuffToPlayer() => this.myskill != null && this.myskill.template.isBuffToPlayer();

  public bool isUseChargeSkill()
  {
    if (this.isUseSkillAfterCharge || this.myskill == null)
      return false;
    return this.myskill.template.id == (sbyte) 10 || this.myskill.template.id == (sbyte) 11;
  }

  public void setSkillPaint(SkillPaint skillPaint, int sType)
  {
    this.hasSendAttack = false;
    if (this.stone || this.me && this.myskill.template.id == (sbyte) 9 && this.cHP <= this.cHPFull / 10)
      return;
    if (this.me)
    {
      if (this.mobFocus == null && this.charFocus == null)
        this.stopUseChargeSkill();
      if (this.mobFocus != null && (this.mobFocus.status == 1 || this.mobFocus.status == 0))
        this.stopUseChargeSkill();
      if (this.charFocus != null && (this.charFocus.statusMe == 14 || this.charFocus.statusMe == 5))
        this.stopUseChargeSkill();
      if (this.myskill.template.id == (sbyte) 23 && (this.charFocus != null && this.charFocus.holdEffID != 0 || this.mobFocus != null && this.mobFocus.holdEffID != 0 || this.holdEffID != 0) || this.sleepEff || this.blindEff)
        return;
    }
    Res.outz("skill id= " + (object) skillPaint.id);
    if (this.me && this.dart != null || TileMap.isOfflineMap())
      return;
    long num = mSystem.currentTimeMillis();
    if (this.me)
    {
      if (this.isSelectingSkillBuffToPlayer() && this.charFocus == null)
        return;
      if (num - this.myskill.lastTimeUseThisSkill < (long) this.myskill.coolDown)
      {
        this.myskill.paintCanNotUseSkill = true;
        return;
      }
      this.myskill.lastTimeUseThisSkill = num;
      if (this.myskill.template.manaUseType == 2)
        this.cMP = 1;
      else if (this.myskill.template.manaUseType != 1)
        this.cMP -= this.myskill.manaUse;
      else
        this.cMP -= this.myskill.manaUse * this.cMPFull / 100;
      --Char.myCharz().cStamina;
      GameScr.gI().isInjureMp = true;
      GameScr.gI().twMp = 0;
      if (this.cMP < 0)
        this.cMP = 0;
    }
    if (this.me)
    {
      if (this.myskill.template.id == (sbyte) 7)
        SoundMn.gI().hoisinh();
      if (this.myskill.template.id == (sbyte) 6)
      {
        Service.gI().skill_not_focus((sbyte) 0);
        GameScr.gI().isUseFreez = true;
        SoundMn.gI().thaiduonghasan();
      }
      if (this.myskill.template.id == (sbyte) 8)
      {
        if (!this.isCharge)
        {
          SoundMn.gI().taitaoPause();
          Service.gI().skill_not_focus((sbyte) 1);
          this.isCharge = true;
          this.last = this.cur = mSystem.currentTimeMillis();
        }
        else
        {
          Service.gI().skill_not_focus((sbyte) 3);
          this.isCharge = false;
          SoundMn.gI().taitaoPause();
        }
      }
      if (this.myskill.template.id == (sbyte) 13)
      {
        if (this.isMonkey != (sbyte) 0)
        {
          GameScr.gI().auto = 0;
          return;
        }
        if (this.isCreateDark)
          return;
        SoundMn.gI().gong();
        Service.gI().skill_not_focus((sbyte) 6);
        this.chargeCount = 0;
        this.isWaitMonkey = true;
        return;
      }
      if (this.myskill.template.id == (sbyte) 14)
      {
        SoundMn.gI().gong();
        Service.gI().skill_not_focus((sbyte) 7);
        this.useChargeSkill(true);
      }
      if (this.myskill.template.id == (sbyte) 21)
      {
        Service.gI().skill_not_focus((sbyte) 10);
        return;
      }
      if (this.myskill.template.id == (sbyte) 12)
        Service.gI().skill_not_focus((sbyte) 8);
      if (this.myskill.template.id == (sbyte) 19)
      {
        Service.gI().skill_not_focus((sbyte) 9);
        return;
      }
    }
    if (this.isMonkey == (sbyte) 1 && skillPaint.id >= 35 && skillPaint.id <= 41)
      skillPaint = GameScr.sks[106];
    if (skillPaint.id >= 128 && skillPaint.id <= 134)
    {
      skillPaint = GameScr.sks[skillPaint.id - 65];
      if (this.charFocus != null)
      {
        this.cx = this.charFocus.cx;
        this.cy = this.charFocus.cy;
        this.currentMovePoint = (MovePoint) null;
      }
      if (this.mobFocus != null)
      {
        this.cx = this.mobFocus.x;
        this.cy = this.mobFocus.y;
        this.currentMovePoint = (MovePoint) null;
      }
      ServerEffect.addServerEffect(60, this.cx, this.cy, 1);
      this.telePortSkill = true;
    }
    if (skillPaint.id >= 107 && skillPaint.id <= 113)
    {
      skillPaint = GameScr.sks[skillPaint.id - 44];
      EffecMn.addEff(new Effect(23, this.cx, this.cy + this.ch / 2, 3, 2, 1));
    }
    this.setAutoSkillPaint(skillPaint, sType);
  }

  public void useSkillNotFocus()
  {
    GameScr.gI().auto = 0;
    Char.myCharz().setSkillPaint(GameScr.sks[(int) Char.myCharz().myskill.skillId], !TileMap.tileTypeAt(Char.myCharz().cx, Char.myCharz().cy, 2) ? 1 : 0);
  }

  public void sendUseChargeSkill()
  {
    if (this.me && (this.isFreez || this.isUsePlane))
    {
      GameScr.gI().auto = 0;
    }
    else
    {
      long num = mSystem.currentTimeMillis();
      if (this.me && num - this.myskill.lastTimeUseThisSkill < (long) this.myskill.coolDown)
      {
        this.myskill.paintCanNotUseSkill = true;
      }
      else
      {
        if (this.myskill.template.id == (sbyte) 10)
          this.useChargeSkill(false);
        if (this.myskill.template.id != (sbyte) 11)
          return;
        this.useChargeSkill(true);
      }
    }
  }

  public void stopUseChargeSkill()
  {
    this.isFlyAndCharge = false;
    this.isStandAndCharge = false;
    this.isUseSkillAfterCharge = false;
    this.isCreateDark = false;
    if (this.me && this.statusMe != 14 && this.statusMe != 5)
      this.isLockMove = false;
    GameScr.gI().auto = 0;
  }

  public void useChargeSkill(bool isGround)
  {
    if (this.isCreateDark)
      return;
    GameScr.gI().auto = 0;
    if (isGround)
    {
      if (this.isStandAndCharge)
        return;
      this.chargeCount = 0;
      this.seconds = 50000;
      this.posDisY = 0;
      this.last = mSystem.currentTimeMillis();
      if (this.me)
      {
        this.isLockMove = true;
        if (this.cgender == 1)
          Service.gI().skill_not_focus((sbyte) 4);
      }
      if (this.cgender == 1)
        SoundMn.gI().gongName();
      this.isStandAndCharge = true;
    }
    else
    {
      if (this.isFlyAndCharge)
        return;
      if (this.me)
      {
        GameScr.gI().auto = 0;
        this.isLockMove = true;
        Service.gI().skill_not_focus((sbyte) 4);
      }
      this.isUseSkillAfterCharge = false;
      this.chargeCount = 0;
      this.isFlyAndCharge = true;
      this.posDisY = 0;
      this.seconds = 50000;
      this.isFlying = TileMap.tileTypeAt(this.cx, this.cy, 2);
    }
  }

  public void setAutoSkillPaint(SkillPaint skillPaint, int sType)
  {
    this.skillPaint = skillPaint;
    Res.outz("set auto skill " + (skillPaint == null ? "null" : "!null"));
    if (skillPaint.id >= 0 && skillPaint.id <= 6)
    {
      int index = Res.random(0, skillPaint.id + 4) - 1;
      if (index < 0)
        index = 0;
      if (index > 6)
        index = 6;
      this.skillPaintRandomPaint = GameScr.sks[index];
    }
    else if (skillPaint.id >= 14 && skillPaint.id <= 20)
    {
      int num = Res.random(0, skillPaint.id - 14 + 4) - 1;
      if (num < 0)
        num = 0;
      if (num > 6)
        num = 6;
      this.skillPaintRandomPaint = GameScr.sks[num + 14];
    }
    else if (skillPaint.id >= 28 && skillPaint.id <= 34)
    {
      int num = Res.random(0, (this.isMonkey != (sbyte) 1 ? skillPaint.id : 105) - (this.isMonkey != (sbyte) 1 ? 28 : 105) + 4) - 1;
      if (num < 0)
        num = 0;
      if (num > 6)
        num = 6;
      if (this.isMonkey == (sbyte) 1)
        num = 0;
      this.skillPaintRandomPaint = GameScr.sks[num + (this.isMonkey != (sbyte) 1 ? 28 : 105)];
    }
    else if (skillPaint.id >= 63 && skillPaint.id <= 69)
    {
      int num = Res.random(0, skillPaint.id - 63 + 4) - 1;
      if (num < 0)
        num = 0;
      if (num > 6)
        num = 6;
      this.skillPaintRandomPaint = GameScr.sks[num + 63];
    }
    else if (skillPaint.id >= 107 && skillPaint.id <= 109)
    {
      int num = Res.random(0, skillPaint.id - 107 + 4) - 1;
      if (num < 0)
        num = 0;
      if (num > 6)
        num = 6;
      this.skillPaintRandomPaint = GameScr.sks[num + 107];
    }
    else
      this.skillPaintRandomPaint = skillPaint;
    this.sType = sType;
    this.indexSkill = 0;
    this.i0 = this.i1 = this.i2 = this.dx0 = this.dx1 = this.dx2 = this.dy0 = this.dy1 = this.dy2 = 0;
    this.eff0 = (EffectCharPaint) null;
    this.eff1 = (EffectCharPaint) null;
    this.eff2 = (EffectCharPaint) null;
    this.cvy = 0;
  }

  public SkillInfoPaint[] skillInfoPaint()
  {
    if (this.skillPaint == null)
      return (SkillInfoPaint[]) null;
    if (this.skillPaintRandomPaint == null)
      return (SkillInfoPaint[]) null;
    return this.sType == 0 ? this.skillPaintRandomPaint.skillStand : this.skillPaintRandomPaint.skillfly;
  }

  public void setAttack()
  {
    if (this.me)
    {
      SkillPaint skillPaint = this.skillPaintRandomPaint;
      if (this.dart != null)
        skillPaint = this.dart.skillPaint;
      if (skillPaint == null)
        return;
      MyVector vMob = new MyVector();
      MyVector vChar = new MyVector();
      if (this.charFocus != null)
        vChar.addElement((object) this.charFocus);
      else if (this.mobFocus != null)
        vMob.addElement((object) this.mobFocus);
      this.effPaints = new EffectPaint[vMob.size() + vChar.size()];
      for (int index = 0; index < vMob.size(); ++index)
      {
        this.effPaints[index] = new EffectPaint();
        this.effPaints[index].effCharPaint = GameScr.efs[skillPaint.effectHappenOnMob - 1];
        if (!this.isSelectingSkillUseAlone())
          this.effPaints[index].eMob = (Mob) vMob.elementAt(index);
      }
      for (int index = 0; index < vChar.size(); ++index)
      {
        this.effPaints[index + vMob.size()] = new EffectPaint();
        this.effPaints[index + vMob.size()].effCharPaint = GameScr.efs[skillPaint.effectHappenOnMob - 1];
        this.effPaints[index + vMob.size()].eChar = (Char) vChar.elementAt(index);
      }
      int type = 0;
      if (this.mobFocus != null)
        type = 1;
      else if (this.charFocus != null)
        type = 2;
      if (vMob.size() == 0 && vChar.size() == 0)
        this.stopUseChargeSkill();
      if (!this.me || this.isSelectingSkillUseAlone() || this.hasSendAttack)
        return;
      Service.gI().sendPlayerAttack(vMob, vChar, type);
      this.hasSendAttack = true;
    }
    else
    {
      SkillPaint skillPaint = this.skillPaintRandomPaint;
      if (this.dart != null)
        skillPaint = this.dart.skillPaint;
      if (skillPaint == null)
        return;
      if (this.attMobs != null)
      {
        this.effPaints = new EffectPaint[this.attMobs.Length];
        for (int index = 0; index < this.attMobs.Length; ++index)
        {
          this.effPaints[index] = new EffectPaint();
          this.effPaints[index].effCharPaint = GameScr.efs[skillPaint.effectHappenOnMob - 1];
          this.effPaints[index].eMob = this.attMobs[index];
        }
        this.attMobs = (Mob[]) null;
      }
      else
      {
        if (this.attChars == null)
          return;
        this.effPaints = new EffectPaint[this.attChars.Length];
        for (int index = 0; index < this.attChars.Length; ++index)
        {
          this.effPaints[index] = new EffectPaint();
          this.effPaints[index].effCharPaint = GameScr.efs[skillPaint.effectHappenOnMob - 1];
          this.effPaints[index].eChar = this.attChars[index];
        }
        this.attChars = (Char[]) null;
      }
    }
  }

  public bool isOutX() => this.cx < GameScr.cmx || this.cx > GameScr.cmx + GameScr.gW;

  public bool isPaint() => this.cy >= GameScr.cmy && this.cy <= GameScr.cmy + GameScr.gH + 30 && !this.isOutX() && !this.isSetPos && !this.isFusion;

  public void createShadow(int x, int y, int life)
  {
    this.shadowX = x;
    this.shadowY = y;
    this.shadowLife = life;
  }

  public void setMabuHold(bool m) => this.isMabuHold = m;

  public virtual void paint(mGraphics g)
  {
    if (this.isHide)
      return;
    if (this.isMabuHold)
    {
      if (!this.cmtoChar)
        return;
      GameScr.cmtoX = this.cx - GameScr.gW2;
      GameScr.cmtoY = this.cy - GameScr.gH23;
      if (GameCanvas.isTouchControl)
        return;
      GameScr.cmtoX += GameScr.gW6 * this.cdir;
    }
    else
    {
      if (!this.isPaint() || !this.me && GameScr.notPaint)
        return;
      if (this.petFollow != null)
        this.petFollow.paint(g);
      this.paintMount1(g);
      if (TileMap.isInAirMap() && this.cy >= TileMap.pxh - 48 || this.isTeleport)
        return;
      if (this.holder && GameCanvas.gameTick % 2 == 0)
      {
        g.setColor(16185600);
        if (this.charHold != null)
          g.drawLine(this.cx, this.cy - this.ch / 2, this.charHold.cx, this.charHold.cy - this.charHold.ch / 2);
        if (this.mobHold != null)
          g.drawLine(this.cx, this.cy - this.ch / 2, this.mobHold.x, this.mobHold.y - this.mobHold.h / 2);
      }
      this.paintSuperEffBehind(g);
      this.paintAuraBehind(g);
      this.paintEffBehind(g);
      this.paintEff_Lvup_behind(g);
      if (this.shadowLife > 0)
      {
        if (GameCanvas.gameTick % 2 == 0)
          this.paintCharBody(g, this.shadowX, this.shadowY, this.cdir, 25, true);
        else if (this.shadowLife > 5)
          this.paintCharBody(g, this.shadowX, this.shadowY, this.cdir, 7, true);
      }
      if (!this.isPaint() && this.skillPaint != null && (this.skillPaint.id < 70 || this.skillPaint.id > 76) && (this.skillPaint.id < 77 || this.skillPaint.id > 83))
      {
        if (this.skillPaint != null)
        {
          this.indexSkill = this.skillInfoPaint().Length;
          this.skillPaint = (SkillPaint) null;
        }
        this.effPaints = (EffectPaint[]) null;
        this.eff = (EffectCharPaint) null;
        this.effTask = (EffectCharPaint) null;
        this.indexEff = -1;
        this.indexEffTask = -1;
      }
      else
      {
        if (this.statusMe == 15 || this.moveFast != null && this.moveFast[0] > (short) 0)
          return;
        this.paintCharName_HP_MP_Overhead(g);
        if (this.skillPaint == null || this.skillInfoPaint() == null || this.indexSkill >= this.skillInfoPaint().Length)
          this.paintCharWithoutSkill(g);
        if (this.arr != null)
          this.arr.paint(g);
        if (this.dart != null)
          this.dart.paint(g);
        this.paintEffect(g);
        if (this.mobMe == null)
          ;
        this.paintMount2(g);
        this.paintEff_Lvup_front(g);
        this.paintSuperEffFront(g);
        this.paintAuraFront(g);
        this.paintEffFront(g);
      }
    }
  }

  private void paintSuperEffBehind(mGraphics g)
  {
    if (this.me)
    {
      if (Char.isPaintAura && this.idAuraEff > (short) -1)
        return;
    }
    else if (this.idAuraEff > (short) -1)
      return;
    if (this.statusMe != 1 && this.statusMe != 6 || GameCanvas.panel.isShow || mSystem.currentTimeMillis() - this.timeBlue <= 0L || this.isCopy || this.clevel < 16)
      return;
    int id = 7598;
    int num = 4;
    if (this.clevel >= 19)
      id = 7676;
    if (this.clevel >= 22)
      id = 7677;
    if (this.clevel >= 25)
      id = 7678;
    if (id == -1)
      return;
    Small small = SmallImage.imgNew[id];
    if (small == null)
    {
      SmallImage.createImage(id);
    }
    else
    {
      int y0 = GameCanvas.gameTick / 4 % num * (mGraphics.getImageHeight(small.img) / num);
      g.drawRegion(small.img, 0, y0, mGraphics.getImageWidth(small.img), mGraphics.getImageHeight(small.img) / num, 0, this.cx, this.cy + 2, mGraphics.BOTTOM | mGraphics.HCENTER);
    }
  }

  private void paintSuperEffFront(mGraphics g)
  {
    if (this.me)
    {
      if (Char.isPaintAura && this.idAuraEff > (short) -1)
        return;
    }
    else if (this.idAuraEff > (short) -1)
      return;
    if (this.statusMe == 1 || this.statusMe == 6)
    {
      if (GameCanvas.panel.isShow || mSystem.currentTimeMillis() - this.timeBlue <= 0L)
        return;
      if (this.isCopy)
      {
        if (GameCanvas.gameTick % 2 == 0)
          ++this.tBlue;
        if (this.tBlue > 6)
          this.tBlue = 0;
        g.drawImage(GameCanvas.imgViolet[this.tBlue], this.cx, this.cy + 9, mGraphics.BOTTOM | mGraphics.HCENTER);
      }
      else
      {
        if (this.clevel >= 14 && !GameCanvas.lowGraphic)
        {
          bool flag = false;
          if (mSystem.currentTimeMillis() - this.timeBlue > -1000L && this.IsAddDust1)
          {
            flag = true;
            this.IsAddDust1 = false;
          }
          if (mSystem.currentTimeMillis() - this.timeBlue > -500L && this.IsAddDust2)
          {
            flag = true;
            this.IsAddDust2 = false;
          }
          if (flag)
          {
            GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
            GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
            this.addDustEff(1);
          }
        }
        if (this.clevel == 14)
        {
          if (GameCanvas.gameTick % 2 == 0)
            ++this.tBlue;
          if (this.tBlue > 6)
            this.tBlue = 0;
          g.drawImage(GameCanvas.imgBlue[this.tBlue], this.cx, this.cy + 9, mGraphics.BOTTOM | mGraphics.HCENTER);
        }
        else if (this.clevel == 15)
        {
          if (GameCanvas.gameTick % 2 == 0)
            ++this.tBlue;
          if (this.tBlue > 6)
            this.tBlue = 0;
          g.drawImage(GameCanvas.imgViolet[this.tBlue], this.cx, this.cy + 9, mGraphics.BOTTOM | mGraphics.HCENTER);
        }
        else
        {
          if (this.clevel < 16)
            return;
          int id = -1;
          int num = 4;
          if (this.clevel >= 16 && this.clevel < 22)
          {
            id = 7599;
            num = 4;
          }
          if (id == -1)
            return;
          Small small = SmallImage.imgNew[id];
          if (small == null)
          {
            SmallImage.createImage(id);
          }
          else
          {
            int y0 = GameCanvas.gameTick / 4 % num * (mGraphics.getImageHeight(small.img) / num);
            g.drawRegion(small.img, 0, y0, mGraphics.getImageWidth(small.img), mGraphics.getImageHeight(small.img) / num, 0, this.cx, this.cy + 2, mGraphics.BOTTOM | mGraphics.HCENTER);
          }
        }
      }
    }
    else
    {
      this.timeBlue = mSystem.currentTimeMillis() + 1500L;
      this.IsAddDust1 = true;
      this.IsAddDust2 = true;
    }
  }

  private void paintEffect(mGraphics g)
  {
    if (this.effPaints != null)
    {
      for (int index = 0; index < this.effPaints.Length; ++index)
      {
        if (this.effPaints[index] != null)
        {
          if (this.effPaints[index].eMob != null)
          {
            int y = this.effPaints[index].eMob.y;
            if (this.effPaints[index].eMob is BigBoss)
              y = this.effPaints[index].eMob.y - 60;
            if (this.effPaints[index].eMob is BigBoss2)
              y = this.effPaints[index].eMob.y - 50;
            if (this.effPaints[index].eMob is BachTuoc)
              y = this.effPaints[index].eMob.y - 40;
            SmallImage.drawSmallImage(g, this.effPaints[index].getImgId(), this.effPaints[index].eMob.x, y, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
          }
          else if (this.effPaints[index].eChar != null)
            SmallImage.drawSmallImage(g, this.effPaints[index].getImgId(), this.effPaints[index].eChar.cx, this.effPaints[index].eChar.cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
        }
      }
    }
    if (this.indexEff >= 0 && this.eff != null)
      SmallImage.drawSmallImage(g, this.eff.arrEfInfo[this.indexEff].idImg, this.cx + this.eff.arrEfInfo[this.indexEff].dx, this.cy + this.eff.arrEfInfo[this.indexEff].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
    if (this.indexEffTask < 0 || this.effTask == null)
      return;
    SmallImage.drawSmallImage(g, this.effTask.arrEfInfo[this.indexEffTask].idImg, this.cx + this.effTask.arrEfInfo[this.indexEffTask].dx, this.cy + this.effTask.arrEfInfo[this.indexEffTask].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
  }

  private void paintArrowAttack(mGraphics g)
  {
  }

  public void paintHp(mGraphics g, int x, int y)
  {
    int num = this.cHP * 100 / this.cHPFull / 10 - 1;
    if (num < 0)
      num = 0;
    if (num > 9)
      num = 9;
    g.drawRegion(Mob.imgHP, 0, 6 * (9 - num), 9, 6, 0, x, y, 3);
  }

  public int getClassColor()
  {
    int classColor = 9145227;
    if (this.nClass.classId == 1 || this.nClass.classId == 2)
      classColor = 16711680;
    else if (this.nClass.classId == 3 || this.nClass.classId == 4)
      classColor = 33023;
    else if (this.nClass.classId == 5 || this.nClass.classId == 6)
      classColor = 7443811;
    return classColor;
  }

  public void paintNameInSameParty(mGraphics g)
  {
    if (this.cTypePk == (sbyte) 3 || this.cTypePk == (sbyte) 5 || !this.isPaint())
      return;
    if (Char.myCharz().charFocus == null || !Char.myCharz().charFocus.Equals((object) this))
    {
      mFont.tahoma_7_yellow.drawString(g, this.cName, this.cx, this.cy - this.ch - mFont.tahoma_7_green.getHeight() - 5, mFont.CENTER, mFont.tahoma_7_grey);
    }
    else
    {
      if (Char.myCharz().charFocus == null || !Char.myCharz().charFocus.Equals((object) this))
        return;
      mFont.tahoma_7_yellow.drawString(g, this.cName, this.cx, this.cy - this.ch - mFont.tahoma_7_green.getHeight() - 10, mFont.CENTER, mFont.tahoma_7_grey);
    }
  }

  private void paintCharName_HP_MP_Overhead(mGraphics g)
  {
    Part part = GameScr.parts[this.getFHead(this.head)];
    int num1 = Char.CharInfo[this.cf][0][2] - (int) part.pi[Char.CharInfo[this.cf][0][0]].dy + 5;
    if (this.isInvisiblez && !this.me || !this.me && TileMap.mapID == 113 && this.cy >= 360 || this.me)
      return;
    bool flag1 = Char.myChar.clan != null && this.clanID == Char.myChar.clan.ID;
    bool flag2 = this.cTypePk == (sbyte) 3 || this.cTypePk == (sbyte) 5;
    bool flag3 = this.cTypePk == (sbyte) 4;
    if (this.cName.StartsWith("$"))
    {
      this.cName = this.cName.Substring(1);
      this.isPet = true;
    }
    if (this.cName.StartsWith("#"))
    {
      this.cName = this.cName.Substring(1);
      this.isMiniPet = true;
    }
    if (Char.myCharz().charFocus != null && Char.myCharz().charFocus.Equals((object) this))
    {
      num1 += 5;
      this.paintHp(g, this.cx, this.cy - num1 + 3);
    }
    int num2 = num1 + mFont.tahoma_7_white.getHeight();
    mFont mFont = mFont.tahoma_7_whiteSmall;
    if (this.isPet || this.isMiniPet)
      mFont = mFont.tahoma_7_blue1Small;
    else if (flag2)
      mFont = mFont.nameFontRed;
    else if (flag3)
      mFont = mFont.nameFontYellow;
    else if (flag1)
      mFont = mFont.nameFontGreen;
    if ((this.paintName || flag2 || flag3) && !flag1)
    {
      if (mSystem.clientType == 1)
        mFont.drawString(g, this.cName, this.cx, this.cy - num2, mFont.CENTER, mFont.tahoma_7_greySmall);
      else
        mFont.drawString(g, this.cName, this.cx, this.cy - num2, mFont.CENTER);
      num2 += mFont.tahoma_7.getHeight();
    }
    if (!flag1)
      return;
    if (Char.myCharz().charFocus != null && Char.myCharz().charFocus.Equals((object) this))
    {
      mFont.drawString(g, this.cName, this.cx, this.cy - num2, mFont.CENTER, mFont.tahoma_7_greySmall);
    }
    else
    {
      if (this.charFocus != null)
        return;
      mFont.drawString(g, this.cName, this.cx - 10, this.cy - num2 + 3, mFont.LEFT, mFont.tahoma_7_grey);
      this.paintHp(g, this.cx - 16, this.cy - num2 + 10);
    }
  }

  public void paintShadow(mGraphics g)
  {
    if (this.isMabuHold || this.head == 377 || this.leg == 471 || this.isTeleport || this.isFlyUp)
      return;
    int size = (int) TileMap.size;
    if ((TileMap.mapID < 114 || TileMap.mapID > 120) && TileMap.mapID != (int) sbyte.MaxValue && TileMap.mapID != 128)
    {
      if (TileMap.tileTypeAt(this.xSd + size / 2, this.ySd + 1, 4))
        g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, size, 100);
      else if (TileMap.tileTypeAt((this.xSd - size / 2) / size, (this.ySd + 1) / size) == 0)
        g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, 100, 100);
      else if (TileMap.tileTypeAt((this.xSd + size / 2) / size, (this.ySd + 1) / size) == 0)
        g.setClip(this.xSd / size * size, (this.ySd - 30) / size * size, size, 100);
      else if (TileMap.tileTypeAt(this.xSd - size / 2, this.ySd + 1, 8))
        g.setClip(this.xSd / 24 * size, (this.ySd - 30) / size * size, size, 100);
    }
    g.drawImage(TileMap.bong, this.xSd, this.ySd, 3);
    g.setClip(GameScr.cmx, GameScr.cmy - GameCanvas.transY, GameScr.gW, GameScr.gH + 2 * GameCanvas.transY);
  }

  public void updateShadown()
  {
    int num = 0;
    this.xSd = this.cx;
    if (TileMap.tileTypeAt(this.cx, this.cy, 2))
    {
      this.ySd = this.cy;
    }
    else
    {
      this.ySd = this.cy;
      while (num < 30)
      {
        ++num;
        this.ySd += 24;
        if (TileMap.tileTypeAt(this.xSd, this.ySd, 2))
        {
          if (this.ySd % 24 == 0)
            break;
          this.ySd -= this.ySd % 24;
          break;
        }
      }
    }
  }

  private void paintCharWithoutSkill(mGraphics g)
  {
    try
    {
      if (this.isInvisiblez)
      {
        if (this.me)
        {
          if (GameCanvas.gameTick % 50 == 48 || GameCanvas.gameTick % 50 == 90)
            SmallImage.drawSmallImage(g, 1196, this.cx, this.cy - 18, 0, mGraphics.VCENTER | mGraphics.HCENTER);
          else
            SmallImage.drawSmallImage(g, 1195, this.cx, this.cy - 18, 0, mGraphics.VCENTER | mGraphics.HCENTER);
        }
      }
      else
        this.paintCharBody(g, this.cx, this.cy + this.fy, this.cdir, this.cf, true);
      if (!this.isLockAttack)
        return;
      SmallImage.drawSmallImage(g, 290, this.cx, this.cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
    }
    catch (Exception ex)
    {
      Cout.LogError("Loi paint char without skill: " + ex.ToString());
    }
  }

  public void paintBag(mGraphics g, short[] id, int x, int y, int dir, bool isPaintChar)
  {
    int num1 = 0;
    int num2 = 0;
    if (this.statusMe == 6)
    {
      num1 = 8;
      num2 = 17;
    }
    if (this.statusMe == 1)
    {
      if (this.cp1 % 15 < 5)
      {
        num1 = 8;
        num2 = 17;
      }
      else
      {
        num1 = 8;
        num2 = 18;
      }
    }
    if (this.statusMe == 2)
    {
      if (this.cf <= 3)
      {
        num1 = 7;
        num2 = 17;
      }
      else
      {
        num1 = 7;
        num2 = 18;
      }
    }
    if (this.statusMe == 3 || this.statusMe == 9)
    {
      num1 = 5;
      num2 = 20;
    }
    if (this.statusMe == 4)
    {
      if (this.cf == 8)
      {
        num1 = 5;
        num2 = 16;
      }
      else
      {
        num1 = 5;
        num2 = 20;
      }
    }
    if (this.statusMe == 10)
    {
      Res.outz("cf= " + (object) this.cf);
      if (this.cf == 8)
      {
        num1 = 0;
        num2 = 23;
      }
      else
      {
        num1 = 5;
        num2 = 22;
      }
    }
    if (this.isInjure > (sbyte) 0)
    {
      num1 = 5;
      num2 = 18;
    }
    if (this.skillPaint != null && this.skillInfoPaint() != null && this.indexSkill < this.skillInfoPaint().Length)
    {
      num1 = -1;
      num2 = 17;
    }
    ++this.fBag;
    if (this.fBag > 10000)
      this.fBag = 0;
    sbyte index = (sbyte) (this.fBag / 4 % id.Length);
    if (!isPaintChar)
    {
      if (id.Length == 2)
        index = (sbyte) 1;
      if (id.Length == 3)
      {
        if (id[2] >= (short) 0)
        {
          index = (sbyte) 2;
          if (GameCanvas.gameTick % 10 > 5)
            index = (sbyte) 1;
        }
        else
          index = (sbyte) 1;
      }
    }
    else if (id.Length > 1 && (index == (sbyte) 0 || index == (sbyte) 1) && this.statusMe != 1 && this.statusMe != 6)
    {
      this.fBag = 0;
      index = (sbyte) 0;
      if (GameCanvas.gameTick % 10 > 5)
        index = (sbyte) 1;
    }
    SmallImage.drawSmallImage(g, (int) id[(int) index], x + (dir != 1 ? num1 : -num1), y - num2, dir != 1 ? 2 : 0, StaticObj.VCENTER_HCENTER);
  }

  public bool isCharBodyImageID(int id)
  {
    Part part1 = GameScr.parts[this.head];
    Part part2 = GameScr.parts[this.leg];
    Part part3 = GameScr.parts[this.body];
    for (int index = 0; index < Char.CharInfo.Length; ++index)
    {
      if (id == (int) part1.pi[Char.CharInfo[index][0][0]].id || id == (int) part2.pi[Char.CharInfo[index][1][0]].id || id == (int) part3.pi[Char.CharInfo[index][2][0]].id)
        return true;
    }
    return false;
  }

  public void paintHead(mGraphics g, int cx, int cy, int look)
  {
    Part part = GameScr.parts[this.head];
    SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, cx, cy, look != 0 ? 2 : 0, mGraphics.RIGHT | mGraphics.VCENTER);
  }

  public void paintHeadWithXY(mGraphics g, int x, int y, int look)
  {
    Part part = GameScr.parts[this.head];
    SmallImage.drawSmallImage(g, (int) part.pi[Char.CharInfo[0][0][0]].id, x + Char.CharInfo[0][0][1] + (int) part.pi[Char.CharInfo[0][0][0]].dx - 3, y + 3, look, mGraphics.LEFT | mGraphics.BOTTOM);
  }

  public void paintCharBody(mGraphics g, int cx, int cy, int cdir, int cf, bool isPaintBag)
  {
    Part part1 = GameScr.parts[this.head];
    Part part2 = GameScr.parts[this.leg];
    Part part3 = GameScr.parts[this.body];
    if (this.bag >= 0 && this.statusMe != 14 && this.isMonkey == (sbyte) 0)
    {
      if (!ClanImage.idImages.containsKey((object) (this.bag.ToString() + string.Empty)))
      {
        ClanImage.idImages.put((object) (this.bag.ToString() + string.Empty), (object) new ClanImage());
        Service.gI().requestBagImage((sbyte) this.bag);
      }
      else
      {
        ClanImage clanImage = (ClanImage) ClanImage.idImages.get((object) (this.bag.ToString() + string.Empty));
        if (clanImage.idImage != null && isPaintBag)
          this.paintBag(g, clanImage.idImage, cx, cy, cdir, true);
      }
    }
    int num1 = 2;
    int anchor1 = 24;
    int anchor2 = StaticObj.TOP_RIGHT;
    int num2 = -1;
    if (cdir == 1)
    {
      num1 = 0;
      anchor1 = 0;
      anchor2 = 0;
      num2 = 1;
    }
    if (this.statusMe == 14)
    {
      if (GameCanvas.gameTick % 4 > 0)
        g.drawImage(ItemMap.imageFlare, cx, cy - this.ch - 11, mGraphics.HCENTER | mGraphics.VCENTER);
      int num3 = 0;
      if (this.head == 89 || this.head == 457 || this.head == 460 || this.head == 461 || this.head == 462 || this.head == 463 || this.head == 464 || this.head == 465 || this.head == 466)
        num3 = 15;
      SmallImage.drawSmallImage(g, 834, cx, cy - Char.CharInfo[cf][2][2] + (int) part3.pi[Char.CharInfo[cf][2][0]].dy - 2 + num3, num1, StaticObj.TOP_CENTER);
      SmallImage.drawSmallImage(g, 79, cx, cy - this.ch - 8, 0, mGraphics.HCENTER | mGraphics.BOTTOM);
      this.paintHat_behind(g, cf, cy - Char.CharInfo[cf][2][2] + (int) part3.pi[Char.CharInfo[cf][2][0]].dy);
      if (this.isHead_2Fr(this.head))
      {
        Part part4 = GameScr.parts[this.getFHead(this.head)];
        SmallImage.drawSmallImage(g, (int) part4.pi[Char.CharInfo[cf][0][0]].id, cx + (Char.CharInfo[cf][0][1] + (int) part4.pi[Char.CharInfo[cf][0][0]].dx) * num2, cy - Char.CharInfo[cf][0][2] + (int) part4.pi[Char.CharInfo[cf][0][0]].dy, num1, anchor1);
      }
      else
        SmallImage.drawSmallImage(g, (int) part1.pi[Char.CharInfo[cf][0][0]].id, cx + (Char.CharInfo[cf][0][1] + (int) part1.pi[Char.CharInfo[cf][0][0]].dx) * num2, cy - Char.CharInfo[cf][0][2] + (int) part1.pi[Char.CharInfo[cf][0][0]].dy, num1, anchor1);
      this.paintHat_front(g, cf, cy - Char.CharInfo[cf][2][2] + (int) part3.pi[Char.CharInfo[cf][2][0]].dy);
      this.paintRedEye(g, cx + (Char.CharInfo[cf][0][1] + (int) part1.pi[Char.CharInfo[cf][0][0]].dx) * num2, cy - Char.CharInfo[cf][0][2] + (int) part1.pi[Char.CharInfo[cf][0][0]].dy, num1, anchor1);
    }
    else
    {
      this.paintHat_behind(g, cf, cy - Char.CharInfo[cf][2][2] + (int) part3.pi[Char.CharInfo[cf][2][0]].dy);
      if (this.isHead_2Fr(this.head))
      {
        Part part5 = GameScr.parts[this.getFHead(this.head)];
        SmallImage.drawSmallImage(g, (int) part5.pi[Char.CharInfo[cf][0][0]].id, cx + (Char.CharInfo[cf][0][1] + (int) part5.pi[Char.CharInfo[cf][0][0]].dx) * num2, cy - Char.CharInfo[cf][0][2] + (int) part5.pi[Char.CharInfo[cf][0][0]].dy, num1, anchor1);
      }
      else
        SmallImage.drawSmallImage(g, (int) part1.pi[Char.CharInfo[cf][0][0]].id, cx + (Char.CharInfo[cf][0][1] + (int) part1.pi[Char.CharInfo[cf][0][0]].dx) * num2, cy - Char.CharInfo[cf][0][2] + (int) part1.pi[Char.CharInfo[cf][0][0]].dy, num1, anchor1);
      this.paintHat_front(g, cf, cy - Char.CharInfo[cf][2][2] + (int) part3.pi[Char.CharInfo[cf][2][0]].dy);
      SmallImage.drawSmallImage(g, (int) part2.pi[Char.CharInfo[cf][1][0]].id, cx + (Char.CharInfo[cf][1][1] + (int) part2.pi[Char.CharInfo[cf][1][0]].dx) * num2, cy - Char.CharInfo[cf][1][2] + (int) part2.pi[Char.CharInfo[cf][1][0]].dy, num1, anchor1);
      SmallImage.drawSmallImage(g, (int) part3.pi[Char.CharInfo[cf][2][0]].id, cx + (Char.CharInfo[cf][2][1] + (int) part3.pi[Char.CharInfo[cf][2][0]].dx) * num2, cy - Char.CharInfo[cf][2][2] + (int) part3.pi[Char.CharInfo[cf][2][0]].dy, num1, anchor1);
      this.paintRedEye(g, cx + (Char.CharInfo[cf][0][1] + (int) part1.pi[Char.CharInfo[cf][0][0]].dx) * num2, cy - Char.CharInfo[cf][0][2] + (int) part1.pi[Char.CharInfo[cf][0][0]].dy, num1, anchor1);
    }
    this.ch = this.isMonkey == (sbyte) 1 || this.isFusion ? 60 : Char.CharInfo[0][0][2] + (int) part1.pi[Char.CharInfo[0][0][0]].dy + 10;
    if (this.statusMe == 1 && this.charID > 0 && !this.isMask && !this.isUseChargeSkill() && !this.isWaitMonkey && this.skillPaint == null && cf != 23 && this.bag < 0 && ((GameCanvas.gameTick + this.charID) % 30 == 0 || this.isFreez))
      g.drawImage(this.cgender != 1 ? Char.eyeTraiDat : Char.eyeNamek, cx + -(this.cgender != 1 ? 2 : 2) * num2, cy - 32 + (this.cgender != 1 ? 11 : 10) - cf, anchor2);
    if (this.eProtect != null)
      this.eProtect.paint(g);
    this.paintPKFlag(g);
  }

  public void paintCharWithSkill(mGraphics g)
  {
    this.ty = 0;
    SkillInfoPaint[] skillInfoPaintArray = this.skillInfoPaint();
    this.cf = skillInfoPaintArray[this.indexSkill].status;
    this.paintCharWithoutSkill(g);
    if (this.cdir == 1)
    {
      if (this.eff0 != null)
      {
        if (this.dx0 == 0)
          this.dx0 = skillInfoPaintArray[this.indexSkill].e0dx;
        if (this.dy0 == 0)
          this.dy0 = skillInfoPaintArray[this.indexSkill].e0dy;
        SmallImage.drawSmallImage(g, this.eff0.arrEfInfo[this.i0].idImg, this.cx + this.dx0 + this.eff0.arrEfInfo[this.i0].dx, this.cy + this.dy0 + this.eff0.arrEfInfo[this.i0].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
        ++this.i0;
        if (this.i0 >= this.eff0.arrEfInfo.Length)
        {
          this.eff0 = (EffectCharPaint) null;
          this.i0 = this.dx0 = this.dy0 = 0;
        }
      }
      if (this.eff1 != null)
      {
        if (this.dx1 == 0)
          this.dx1 = skillInfoPaintArray[this.indexSkill].e1dx;
        if (this.dy1 == 0)
          this.dy1 = skillInfoPaintArray[this.indexSkill].e1dy;
        SmallImage.drawSmallImage(g, this.eff1.arrEfInfo[this.i1].idImg, this.cx + this.dx1 + this.eff1.arrEfInfo[this.i1].dx, this.cy + this.dy1 + this.eff1.arrEfInfo[this.i1].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
        ++this.i1;
        if (this.i1 >= this.eff1.arrEfInfo.Length)
        {
          this.eff1 = (EffectCharPaint) null;
          this.i1 = this.dx1 = this.dy1 = 0;
        }
      }
      if (this.eff2 != null)
      {
        if (this.dx2 == 0)
          this.dx2 = skillInfoPaintArray[this.indexSkill].e2dx;
        if (this.dy2 == 0)
          this.dy2 = skillInfoPaintArray[this.indexSkill].e2dy;
        SmallImage.drawSmallImage(g, this.eff2.arrEfInfo[this.i2].idImg, this.cx + this.dx2 + this.eff2.arrEfInfo[this.i2].dx, this.cy + this.dy2 + this.eff2.arrEfInfo[this.i2].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
        ++this.i2;
        if (this.i2 >= this.eff2.arrEfInfo.Length)
        {
          this.eff2 = (EffectCharPaint) null;
          this.i2 = this.dx2 = this.dy2 = 0;
        }
      }
    }
    else
    {
      if (this.eff0 != null)
      {
        if (this.dx0 == 0)
          this.dx0 = skillInfoPaintArray[this.indexSkill].e0dx;
        if (this.dy0 == 0)
          this.dy0 = skillInfoPaintArray[this.indexSkill].e0dy;
        SmallImage.drawSmallImage(g, this.eff0.arrEfInfo[this.i0].idImg, this.cx - this.dx0 - this.eff0.arrEfInfo[this.i0].dx, this.cy + this.dy0 + this.eff0.arrEfInfo[this.i0].dy, 2, mGraphics.VCENTER | mGraphics.HCENTER);
        ++this.i0;
        if (this.i0 >= this.eff0.arrEfInfo.Length)
        {
          this.eff0 = (EffectCharPaint) null;
          this.i0 = 0;
          this.dx0 = 0;
          this.dy0 = 0;
        }
      }
      if (this.eff1 != null)
      {
        if (this.dx1 == 0)
          this.dx1 = skillInfoPaintArray[this.indexSkill].e1dx;
        if (this.dy1 == 0)
          this.dy1 = skillInfoPaintArray[this.indexSkill].e1dy;
        SmallImage.drawSmallImage(g, this.eff1.arrEfInfo[this.i1].idImg, this.cx - this.dx1 - this.eff1.arrEfInfo[this.i1].dx, this.cy + this.dy1 + this.eff1.arrEfInfo[this.i1].dy, 2, mGraphics.VCENTER | mGraphics.HCENTER);
        ++this.i1;
        if (this.i1 >= this.eff1.arrEfInfo.Length)
        {
          this.eff1 = (EffectCharPaint) null;
          this.i1 = 0;
          this.dx1 = 0;
          this.dy1 = 0;
        }
      }
      if (this.eff2 != null)
      {
        if (this.dx2 == 0)
          this.dx2 = skillInfoPaintArray[this.indexSkill].e2dx;
        if (this.dy2 == 0)
          this.dy2 = skillInfoPaintArray[this.indexSkill].e2dy;
        SmallImage.drawSmallImage(g, this.eff2.arrEfInfo[this.i2].idImg, this.cx - this.dx2 - this.eff2.arrEfInfo[this.i2].dx, this.cy + this.dy2 + this.eff2.arrEfInfo[this.i2].dy, 2, mGraphics.VCENTER | mGraphics.HCENTER);
        ++this.i2;
        if (this.i2 >= this.eff2.arrEfInfo.Length)
        {
          this.eff2 = (EffectCharPaint) null;
          this.i2 = 0;
          this.dx2 = 0;
          this.dy2 = 0;
        }
      }
    }
    ++this.indexSkill;
  }

  public static int getIndexChar(int ID)
  {
    for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
    {
      if (((Char) GameScr.vCharInMap.elementAt(index)).charID == ID)
        return index;
    }
    return -1;
  }

  public void moveTo(int toX, int toY, int type)
  {
    if (type == 1 || Res.abs(toX - this.cx) > 100 || Res.abs(toY - this.cy) > 300)
    {
      this.createShadow(this.cx, this.cy, 10);
      this.cx = toX;
      this.cy = toY;
      this.vMovePoints.removeAllElements();
      this.statusMe = 6;
      this.cp3 = 0;
      this.currentMovePoint = (MovePoint) null;
      this.cf = 25;
    }
    else
    {
      int dir = 0;
      int act = 0;
      int num1 = toX - this.cx;
      int num2 = toY - this.cy;
      if (num1 == 0 && num2 == 0)
      {
        act = 1;
        this.cp3 = 0;
      }
      else if (num2 == 0)
      {
        act = 2;
        if (num1 > 0)
          dir = 1;
        if (num1 < 0)
          dir = -1;
      }
      else if (num2 != 0)
      {
        if (num2 < 0)
          act = 3;
        if (num2 > 0)
          act = 4;
        if (num1 < 0)
          dir = -1;
        if (num1 > 0)
          dir = 1;
      }
      this.vMovePoints.addElement((object) new MovePoint(toX, toY, act, dir));
      if (this.statusMe != 6)
        this.statusBeforeNothing = this.statusMe;
      this.statusMe = 6;
      this.cp3 = 0;
    }
  }

  public static void getcharInjure(int cID, int dx, int dy, int HP)
  {
    Char char1 = (Char) GameScr.vCharInMap.elementAt(cID);
    if (char1.vMovePoints.size() == 0)
      return;
    MovePoint movePoint = (MovePoint) char1.vMovePoints.lastElement();
    int xEnd = movePoint.xEnd + dx;
    int yEnd = movePoint.yEnd + dy;
    Char char2 = (Char) GameScr.vCharInMap.elementAt(cID);
    char2.cHP -= HP;
    if (char2.cHP < 0)
      char2.cHP = 0;
    char2.cHPShow = ((Char) GameScr.vCharInMap.elementAt(cID)).cHP - HP;
    char2.statusMe = 6;
    char2.cp3 = 0;
    char2.vMovePoints.addElement((object) new MovePoint(xEnd, yEnd, 8, char2.cdir));
  }

  public bool isMagicTree()
  {
    if (GameScr.gI().magicTree == null)
      return false;
    int x = GameScr.gI().magicTree.x;
    int y = GameScr.gI().magicTree.y;
    return this.cx > x - 30 && this.cx < x + 30 && this.cy > y - 30 && this.cy < y + 30;
  }

  public void searchItem()
  {
    int[] numArray = new int[4]{ -1, -1, -1, -1 };
    if (this.itemFocus != null)
      return;
    for (int index = 0; index < GameScr.vItemMap.size(); ++index)
    {
      ItemMap itemMap = (ItemMap) GameScr.vItemMap.elementAt(index);
      int num1 = Math.abs(Char.myCharz().cx - itemMap.x);
      int num2 = Math.abs(Char.myCharz().cy - itemMap.y);
      int num3 = num1 <= num2 ? num2 : num1;
      if (num1 <= 48 && num2 <= 48 && (this.itemFocus == null || num3 < numArray[3]))
      {
        if (GameScr.gI().auto != 0 && GameScr.gI().isBagFull())
        {
          if (itemMap.template.type == (sbyte) 9)
          {
            this.itemFocus = itemMap;
            numArray[3] = num3;
          }
        }
        else
        {
          this.itemFocus = itemMap;
          numArray[3] = num3;
        }
      }
    }
  }

  public void searchFocus()
  {
    if (Char.myCharz().skillPaint != null || Char.myCharz().arr != null || Char.myCharz().dart != null)
      this.timeFocusToMob = 200;
    else if (this.timeFocusToMob > 0)
    {
      --this.timeFocusToMob;
    }
    else
    {
      if (Char.isManualFocus && this.charFocus != null && (this.charFocus.statusMe == 15 || this.charFocus.isInvisiblez))
        this.charFocus = (Char) null;
      if (GameCanvas.gameTick % 2 == 0 || this.isMeCanAttackOtherPlayer(this.charFocus))
        return;
      int num1 = 0;
      if (this.nClass.classId == 0 || this.nClass.classId == 1 || this.nClass.classId == 3 || this.nClass.classId == 5)
        num1 = 40;
      int[] numArray = new int[4]{ -1, -1, -1, -1 };
      int num2 = GameScr.cmx - 10;
      int num3 = GameScr.cmx + GameCanvas.w + 10;
      int cmy = GameScr.cmy;
      int num4 = GameScr.cmy + GameCanvas.h - GameScr.cmdBarH + 10;
      if (Char.isManualFocus)
      {
        if (this.mobFocus != null && this.mobFocus.status != 1 && this.mobFocus.status != 0 && num2 <= this.mobFocus.x && this.mobFocus.x <= num3 && cmy <= this.mobFocus.y && this.mobFocus.y <= num4 || this.npcFocus != null && num2 <= this.npcFocus.cx && this.npcFocus.cx <= num3 && cmy <= this.npcFocus.cy && this.npcFocus.cy <= num4 || this.charFocus != null && num2 <= this.charFocus.cx && this.charFocus.cx <= num3 && cmy <= this.charFocus.cy && this.charFocus.cy <= num4 || this.itemFocus != null && num2 <= this.itemFocus.x && this.itemFocus.x <= num3 && cmy <= this.itemFocus.y && this.itemFocus.y <= num4)
          return;
        Char.isManualFocus = false;
      }
      int num5 = Char.myCharz().cx - 80;
      int num6 = Char.myCharz().cx + 80;
      int num7 = Char.myCharz().cy - 30;
      int num8 = Char.myCharz().cy + 30;
      if (this.npcFocus != null && this.npcFocus.template.npcTemplateId == 6)
      {
        num5 = Char.myCharz().cx - 20;
        num6 = Char.myCharz().cx + 20;
        num7 = Char.myCharz().cy - 10;
        num8 = Char.myCharz().cy + 10;
      }
      if (this.npcFocus == null)
      {
        for (int index = 0; index < GameScr.vNpc.size(); ++index)
        {
          Npc npc = (Npc) GameScr.vNpc.elementAt(index);
          if (npc.statusMe != 15)
          {
            int num9 = Math.abs(Char.myCharz().cx - npc.cx);
            int num10 = Math.abs(Char.myCharz().cy - npc.cy);
            int num11 = num9 <= num10 ? num10 : num9;
            num5 = Char.myCharz().cx - 80;
            num6 = Char.myCharz().cx + 80;
            num7 = Char.myCharz().cy - 30;
            num8 = Char.myCharz().cy + 30;
            if (npc.template.npcTemplateId == 6)
            {
              num5 = Char.myCharz().cx - 20;
              num6 = Char.myCharz().cx + 20;
              num7 = Char.myCharz().cy - 10;
              num8 = Char.myCharz().cy + 10;
            }
            if (num5 <= npc.cx && npc.cx <= num6 && num7 <= npc.cy && npc.cy <= num8 && (this.npcFocus == null || num11 < numArray[1]))
            {
              this.npcFocus = npc;
              numArray[1] = num11;
            }
          }
        }
      }
      else if (num5 > this.npcFocus.cx || this.npcFocus.cx > num6 || num7 > this.npcFocus.cy || this.npcFocus.cy > num8)
      {
        this.deFocusNPC();
        for (int index = 0; index < GameScr.vNpc.size(); ++index)
        {
          Npc npc = (Npc) GameScr.vNpc.elementAt(index);
          if (npc.statusMe != 15)
          {
            int num12 = Math.abs(Char.myCharz().cx - npc.cx);
            int num13 = Math.abs(Char.myCharz().cy - npc.cy);
            int num14 = num12 <= num13 ? num13 : num12;
            num5 = Char.myCharz().cx - 80;
            num6 = Char.myCharz().cx + 80;
            num7 = Char.myCharz().cy - 30;
            num8 = Char.myCharz().cy + 30;
            if (npc.template.npcTemplateId == 6)
            {
              num5 = Char.myCharz().cx - 20;
              num6 = Char.myCharz().cx + 20;
              num7 = Char.myCharz().cy - 10;
              num8 = Char.myCharz().cy + 10;
            }
            if (num5 <= npc.cx && npc.cx <= num6 && num7 <= npc.cy && npc.cy <= num8 && (this.npcFocus == null || num14 < numArray[1]))
            {
              this.npcFocus = npc;
              numArray[1] = num14;
            }
          }
        }
      }
      else
      {
        this.clearFocus(1);
        return;
      }
      if (this.itemFocus == null)
      {
        for (int index = 0; index < GameScr.vItemMap.size(); ++index)
        {
          ItemMap itemMap = (ItemMap) GameScr.vItemMap.elementAt(index);
          int num15 = Math.abs(Char.myCharz().cx - itemMap.x);
          int num16 = Math.abs(Char.myCharz().cy - itemMap.y);
          int num17 = num15 <= num16 ? num16 : num15;
          if (num15 <= 48 && num16 <= 48 && (this.itemFocus == null || num17 < numArray[3]))
          {
            if (GameScr.gI().auto != 0 && GameScr.gI().isBagFull())
            {
              if (itemMap.template.type == (sbyte) 9)
              {
                this.itemFocus = itemMap;
                numArray[3] = num17;
              }
            }
            else
            {
              this.itemFocus = itemMap;
              numArray[3] = num17;
            }
          }
        }
      }
      else if (num5 > this.itemFocus.x || this.itemFocus.x > num6 || num7 > this.itemFocus.y || this.itemFocus.y > num8)
      {
        this.itemFocus = (ItemMap) null;
        for (int index = 0; index < GameScr.vItemMap.size(); ++index)
        {
          ItemMap itemMap = (ItemMap) GameScr.vItemMap.elementAt(index);
          int num18 = Math.abs(Char.myCharz().cx - itemMap.x);
          int num19 = Math.abs(Char.myCharz().cy - itemMap.y);
          int num20 = num18 <= num19 ? num19 : num18;
          if (num5 <= itemMap.x && itemMap.x <= num6 && num7 <= itemMap.y && itemMap.y <= num8 && (this.itemFocus == null || num20 < numArray[3]))
          {
            if (GameScr.gI().auto != 0 && GameScr.gI().isBagFull())
            {
              if (itemMap.template.type == (sbyte) 9)
              {
                this.itemFocus = itemMap;
                numArray[3] = num20;
              }
            }
            else
            {
              this.itemFocus = itemMap;
              numArray[3] = num20;
            }
          }
        }
      }
      else
      {
        this.clearFocus(3);
        return;
      }
      int num21 = Char.myCharz().cx - Char.myCharz().getdxSkill() - 10;
      int num22 = Char.myCharz().cx + Char.myCharz().getdxSkill() + 10;
      int num23 = Char.myCharz().cy - Char.myCharz().getdySkill() - num1 - 20;
      int num24 = Char.myCharz().cy + Char.myCharz().getdySkill() + 20;
      if (num24 > Char.myCharz().cy + 30)
        num24 = Char.myCharz().cy + 30;
      if (this.mobFocus == null)
      {
        for (int index = 0; index < GameScr.vMob.size(); ++index)
        {
          Mob mob = (Mob) GameScr.vMob.elementAt(index);
          int num25 = Math.abs(Char.myCharz().cx - mob.x);
          int num26 = Math.abs(Char.myCharz().cy - mob.y);
          int num27 = num25 <= num26 ? num26 : num25;
          if (num21 <= mob.x && mob.x <= num22 && num23 <= mob.y && mob.y <= num24 && (this.mobFocus == null || num27 < numArray[0]))
          {
            this.mobFocus = mob;
            numArray[0] = num27;
          }
        }
      }
      else if (this.mobFocus.status == 1 || this.mobFocus.status == 0 || num21 > this.mobFocus.x || this.mobFocus.x > num22 || num23 > this.mobFocus.y || this.mobFocus.y > num24)
      {
        this.mobFocus = (Mob) null;
        for (int index = 0; index < GameScr.vMob.size(); ++index)
        {
          Mob mob = (Mob) GameScr.vMob.elementAt(index);
          int num28 = Math.abs(Char.myCharz().cx - mob.x);
          int num29 = Math.abs(Char.myCharz().cy - mob.y);
          int num30 = num28 <= num29 ? num29 : num28;
          if (num21 <= mob.x && mob.x <= num22 && num23 <= mob.y && mob.y <= num24 && (this.mobFocus == null || num30 < numArray[0]))
          {
            this.mobFocus = mob;
            numArray[0] = num30;
          }
        }
      }
      else
      {
        this.clearFocus(0);
        return;
      }
      if (this.charFocus == null)
      {
        for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
        {
          Char @char = (Char) GameScr.vCharInMap.elementAt(index);
          if (@char.statusMe != 15 && !@char.isInvisiblez && this.wdx == (short) 0 && this.wdy == (short) 0)
          {
            int num31 = Math.abs(Char.myCharz().cx - @char.cx);
            int num32 = Math.abs(Char.myCharz().cy - @char.cy);
            int num33 = num31 <= num32 ? num32 : num31;
            if (num21 <= @char.cx && @char.cx <= num22 && num23 <= @char.cy && @char.cy <= num24 && (this.charFocus == null || num33 < numArray[2]))
            {
              this.charFocus = @char;
              numArray[2] = num33;
            }
          }
        }
      }
      else if (num21 > this.charFocus.cx || this.charFocus.cx > num22 || num23 > this.charFocus.cy || this.charFocus.cy > num24 || this.charFocus.statusMe == 15 || this.charFocus.isInvisiblez)
      {
        this.charFocus = (Char) null;
        for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
        {
          Char @char = (Char) GameScr.vCharInMap.elementAt(index);
          if (@char.statusMe != 15 && !@char.isInvisiblez && this.wdx == (short) 0 && this.wdy == (short) 0)
          {
            int num34 = Math.abs(Char.myCharz().cx - @char.cx);
            int num35 = Math.abs(Char.myCharz().cy - @char.cy);
            int num36 = num34 <= num35 ? num35 : num34;
            if (num21 <= @char.cx && @char.cx <= num22 && num23 <= @char.cy && @char.cy <= num24 && (this.charFocus == null || num36 < numArray[2]))
            {
              this.charFocus = @char;
              numArray[2] = num36;
            }
          }
        }
      }
      else
      {
        this.clearFocus(2);
        return;
      }
      int index1 = -1;
      for (int index2 = 0; index2 < numArray.Length; ++index2)
      {
        if (index1 == -1)
        {
          if (numArray[index2] != -1)
            index1 = index2;
        }
        else if (numArray[index2] < numArray[index1] && numArray[index2] != -1)
          index1 = index2;
      }
      this.clearFocus(index1);
      if (!this.me || !this.isAttacPlayerStatus())
        return;
      if (this.mobFocus != null && !this.mobFocus.isMobMe)
        this.mobFocus = (Mob) null;
      this.npcFocus = (Npc) null;
      this.itemFocus = (ItemMap) null;
    }
  }

  public void clearFocus(int index)
  {
    switch (index)
    {
      case 0:
        this.deFocusNPC();
        this.charFocus = (Char) null;
        this.itemFocus = (ItemMap) null;
        break;
      case 1:
        this.mobFocus = (Mob) null;
        this.charFocus = (Char) null;
        this.itemFocus = (ItemMap) null;
        break;
      case 2:
        this.mobFocus = (Mob) null;
        this.deFocusNPC();
        this.itemFocus = (ItemMap) null;
        break;
      case 3:
        this.mobFocus = (Mob) null;
        this.deFocusNPC();
        this.charFocus = (Char) null;
        break;
    }
  }

  public static bool isCharInScreen(Char c)
  {
    int cmx = GameScr.cmx;
    int num1 = GameScr.cmx + GameCanvas.w;
    int num2 = GameScr.cmy + 10;
    int num3 = GameScr.cmy + GameScr.gH;
    return c.statusMe != 15 && !c.isInvisiblez && cmx <= c.cx && c.cx <= num1 && num2 <= c.cy && c.cy <= num3;
  }

  public bool isAttacPlayerStatus() => this.cTypePk == (sbyte) 4 || this.cTypePk == (sbyte) 3;

  public void setHoldChar(Char r)
  {
    this.cdir = this.cx >= r.cx ? -1 : 1;
    this.charHold = r;
    this.holder = true;
  }

  public void setHoldMob(Mob r)
  {
    this.cdir = this.cx >= r.x ? -1 : 1;
    this.mobHold = r;
    this.holder = true;
  }

  public void findNextFocusByKey()
  {
    Res.outz("focus size= " + (object) this.focus.size());
    if ((Char.myCharz().skillPaint != null || Char.myCharz().arr != null || Char.myCharz().dart != null || Char.myCharz().skillInfoPaint() != null) && this.focus.size() == 0)
      return;
    this.focus.removeAllElements();
    int index1 = 0;
    int num1 = GameScr.cmx + 10;
    int num2 = GameScr.cmx + GameCanvas.w - 10;
    int num3 = GameScr.cmy + 10;
    int num4 = GameScr.cmy + GameScr.gH;
    for (int index2 = 0; index2 < GameScr.vCharInMap.size(); ++index2)
    {
      Char o = (Char) GameScr.vCharInMap.elementAt(index2);
      if (o.statusMe != 15 && !o.isInvisiblez && num1 <= o.cx && o.cx <= num2 && num3 <= o.cy && o.cy <= num4 && o.charID != -114 && (TileMap.mapID != 129 || TileMap.mapID == 129 && Char.myCharz().cy > 264))
      {
        this.focus.addElement((object) o);
        if (this.charFocus != null && o.Equals((object) this.charFocus))
          index1 = this.focus.size();
      }
    }
    if (this.me && this.isAttacPlayerStatus())
    {
      Res.outz("co the tan cong nguoi");
      for (int index3 = 0; index3 < GameScr.vMob.size(); ++index3)
      {
        Mob mob = (Mob) GameScr.vMob.elementAt(index3);
        if (!GameScr.gI().isMeCanAttackMob(mob))
        {
          Res.outz("khong the tan cong quai");
          this.mobFocus = (Mob) null;
        }
        else
        {
          Res.outz("co the tan ong quai");
          this.focus.addElement((object) mob);
          if (this.mobFocus != null)
            index1 = this.focus.size();
        }
      }
      this.npcFocus = (Npc) null;
      this.itemFocus = (ItemMap) null;
      if (this.focus.size() > 0)
      {
        if (index1 >= this.focus.size())
          index1 = 0;
        this.focusManualTo(this.focus.elementAt(index1));
      }
      else
      {
        this.mobFocus = (Mob) null;
        this.deFocusNPC();
        this.charFocus = (Char) null;
        this.itemFocus = (ItemMap) null;
        Char.isManualFocus = false;
      }
    }
    else
    {
      for (int index4 = 0; index4 < GameScr.vItemMap.size(); ++index4)
      {
        ItemMap o = (ItemMap) GameScr.vItemMap.elementAt(index4);
        if (num1 <= o.x && o.x <= num2 && num3 <= o.y && o.y <= num4)
        {
          this.focus.addElement((object) o);
          if (this.itemFocus != null && o.Equals((object) this.itemFocus))
            index1 = this.focus.size();
        }
      }
      for (int index5 = 0; index5 < GameScr.vMob.size(); ++index5)
      {
        Mob o = (Mob) GameScr.vMob.elementAt(index5);
        if (o.status != 1 && o.status != 0 && num1 <= o.x && o.x <= num2 && num3 <= o.y && o.y <= num4)
        {
          this.focus.addElement((object) o);
          if (this.mobFocus != null && o.Equals((object) this.mobFocus))
            index1 = this.focus.size();
        }
      }
      for (int index6 = 0; index6 < GameScr.vNpc.size(); ++index6)
      {
        Npc o = (Npc) GameScr.vNpc.elementAt(index6);
        if (o.statusMe != 15 && num1 <= o.cx && o.cx <= num2 && num3 <= o.cy && o.cy <= num4)
        {
          this.focus.addElement((object) o);
          if (this.npcFocus != null && o.Equals((object) this.npcFocus))
            index1 = this.focus.size();
        }
      }
      if (this.focus.size() > 0)
      {
        if (index1 >= this.focus.size())
          index1 = 0;
        this.focusManualTo(this.focus.elementAt(index1));
      }
      else
      {
        this.mobFocus = (Mob) null;
        this.deFocusNPC();
        this.charFocus = (Char) null;
        this.itemFocus = (ItemMap) null;
        Char.isManualFocus = false;
      }
    }
  }

  public void deFocusNPC()
  {
    if (!this.me || this.npcFocus == null)
      return;
    if (!GameCanvas.menu.showMenu)
      Char.chatPopup = (ChatPopup) null;
    this.npcFocus = (Npc) null;
  }

  public void updateCharInBridge()
  {
    if (GameCanvas.lowGraphic)
      return;
    if (TileMap.tileTypeAt(this.cx, this.cy + 1, 1024))
    {
      TileMap.setTileTypeAtPixel(this.cx, this.cy + 1, 512);
      TileMap.setTileTypeAtPixel(this.cx, this.cy - 2, 512);
    }
    if (TileMap.tileTypeAt(this.cx - (int) TileMap.size, this.cy + 1, 512))
    {
      TileMap.killTileTypeAt(this.cx - (int) TileMap.size, this.cy + 1, 512);
      TileMap.killTileTypeAt(this.cx - (int) TileMap.size, this.cy - 2, 512);
    }
    if (!TileMap.tileTypeAt(this.cx + (int) TileMap.size, this.cy + 1, 512))
      return;
    TileMap.killTileTypeAt(this.cx + (int) TileMap.size, this.cy + 1, 512);
    TileMap.killTileTypeAt(this.cx + (int) TileMap.size, this.cy - 2, 512);
  }

  public static void sort(int[] data)
  {
    int num1 = 5;
    for (int index1 = 0; index1 < num1 - 1; ++index1)
    {
      for (int index2 = index1 + 1; index2 < num1; ++index2)
      {
        if (data[index1] < data[index2])
        {
          int num2 = data[index2];
          data[index2] = data[index1];
          data[index1] = num2;
        }
      }
    }
  }

  public static bool setInsc(int cmX, int cmWx, int x, int cmy, int cmyH, int y) => x <= cmWx && x >= cmX && y <= cmyH && y >= cmy;

  public void kickOption(Item item, int maxKick)
  {
    int num = 0;
    if (item == null || item.options == null)
      return;
    for (int index = 0; index < item.options.size(); ++index)
    {
      ItemOption itemOption = (ItemOption) item.options.elementAt(index);
      itemOption.active = (sbyte) 0;
      if (itemOption.optionTemplate.type == 2)
      {
        if (num < maxKick)
        {
          itemOption.active = (sbyte) 1;
          ++num;
        }
      }
      else if (itemOption.optionTemplate.type == 3 && item.upgrade >= 4)
        itemOption.active = (sbyte) 1;
      else if (itemOption.optionTemplate.type == 4 && item.upgrade >= 8)
        itemOption.active = (sbyte) 1;
      else if (itemOption.optionTemplate.type == 5 && item.upgrade >= 12)
        itemOption.active = (sbyte) 1;
      else if (itemOption.optionTemplate.type == 6 && item.upgrade >= 14)
        itemOption.active = (sbyte) 1;
      else if (itemOption.optionTemplate.type == 7 && item.upgrade >= 16)
        itemOption.active = (sbyte) 1;
    }
  }

  public void doInjure(int HPShow, int MPShow, bool isCrit, bool isMob)
  {
    this.isCrit = isCrit;
    this.isMob = isMob;
    Res.outz("CHP= " + (object) this.cHP + " dame -= " + (object) HPShow + " HP FULL= " + (object) this.cHPFull);
    this.cHP -= HPShow;
    this.cMP -= MPShow;
    GameScr.gI().isInjureHp = true;
    GameScr.gI().twHp = 0;
    GameScr.gI().isInjureMp = true;
    GameScr.gI().twMp = 0;
    if (this.cHP < 0)
      this.cHP = 0;
    if (this.cMP < 0)
      this.cMP = 0;
    if (isMob || !isMob && this.cTypePk != (sbyte) 4 && this.damMP != -100)
    {
      if (HPShow <= 0)
      {
        if (this.me)
          GameScr.startFlyText(mResources.miss, this.cx, this.cy - this.ch, 0, -2, mFont.MISS_ME);
        else
          GameScr.startFlyText(mResources.miss, this.cx, this.cy - this.ch, 0, -2, mFont.MISS);
      }
      else
        GameScr.startFlyText("-" + (object) HPShow, this.cx, this.cy - this.ch, 0, -2, isCrit ? mFont.FATAL : mFont.RED);
    }
    if (HPShow > 0)
      this.isInjure = (sbyte) 6;
    ServerEffect.addServerEffect(80, this, 1);
    if (!this.isDie)
      return;
    this.isDie = false;
    Char.isLockKey = false;
    this.startDie((short) this.xSd, (short) this.ySd);
  }

  public void doInjure()
  {
    GameScr.gI().isInjureHp = true;
    GameScr.gI().twHp = 0;
    GameScr.gI().isInjureMp = true;
    GameScr.gI().twMp = 0;
    this.isInjure = (sbyte) 6;
    ServerEffect.addServerEffect(8, this, 1);
    this.isInjureHp = true;
    this.twHp = 0;
  }

  public void startDie(short toX, short toY)
  {
    this.isMonkey = (sbyte) 0;
    this.isWaitMonkey = false;
    if (this.me && this.isDie)
      return;
    if (this.me)
    {
      this.isLockMove = true;
      for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
        ((Char) GameScr.vCharInMap.elementAt(index)).killCharId = -9999;
      if (GameCanvas.panel != null && GameCanvas.panel.cp != null)
        GameCanvas.panel.cp = (ChatPopup) null;
      if (GameCanvas.panel2 != null && GameCanvas.panel2.cp != null)
        GameCanvas.panel2.cp = (ChatPopup) null;
    }
    this.statusMe = 5;
    this.cp2 = (int) toX;
    this.cp3 = (int) toY;
    this.cp1 = 0;
    this.cHP = 0;
    this.testCharId = -9999;
    this.killCharId = -9999;
    if (this.me && this.myskill != null && this.myskill.template.id != (sbyte) 14)
      this.stopUseChargeSkill();
    this.cTypePk = (sbyte) 0;
  }

  public void waitToDie(short toX, short toY)
  {
    this.wdx = toX;
    this.wdy = toY;
  }

  public void liveFromDead()
  {
    this.cHP = this.cHPFull;
    this.cMP = this.cMPFull;
    this.statusMe = 1;
    this.cp1 = this.cp2 = this.cp3 = 0;
    ServerEffect.addServerEffect(109, this, 2);
    GameScr.gI().center = (Command) null;
    GameScr.isHaveSelectSkill = true;
  }

  public bool doUsePotion()
  {
    if (this.arrItemBag == null)
      return false;
    for (int index = 0; index < this.arrItemBag.Length; ++index)
    {
      if (this.arrItemBag[index] != null && this.arrItemBag[index].template.type == (sbyte) 6)
      {
        Service.gI().useItem((sbyte) 0, (sbyte) 1, (sbyte) -1, this.arrItemBag[index].template.id);
        return true;
      }
    }
    return false;
  }

  public bool isLang() => TileMap.mapID == 1 || TileMap.mapID == 27 || TileMap.mapID == 72 || TileMap.mapID == 10 || TileMap.mapID == 17 || TileMap.mapID == 22 || TileMap.mapID == 32 || TileMap.mapID == 38 || TileMap.mapID == 43 || TileMap.mapID == 48;

  public bool isMeCanAttackOtherPlayer(Char cAtt) => cAtt != null && Char.myCharz().myskill != null && Char.myCharz().myskill.template.type != 2 && (Char.myCharz().myskill.template.type != 4 || cAtt.statusMe == 14 || cAtt.statusMe == 5) && (cAtt.cTypePk == (sbyte) 3 && Char.myCharz().cTypePk == (sbyte) 3 || Char.myCharz().cTypePk == (sbyte) 5 || cAtt.cTypePk == (sbyte) 5 || Char.myCharz().cTypePk == (sbyte) 1 && cAtt.cTypePk == (sbyte) 1 || Char.myCharz().cTypePk == (sbyte) 4 && cAtt.cTypePk == (sbyte) 4 || Char.myCharz().testCharId >= 0 && Char.myCharz().testCharId == cAtt.charID || Char.myCharz().killCharId >= 0 && Char.myCharz().killCharId == cAtt.charID && !this.isLang() || cAtt.killCharId >= 0 && cAtt.killCharId == Char.myCharz().charID && !this.isLang() || Char.myCharz().cFlag == (sbyte) 8 && cAtt.cFlag != (sbyte) 0 || Char.myCharz().cFlag != (sbyte) 0 && cAtt.cFlag == (sbyte) 8 || (int) Char.myCharz().cFlag != (int) cAtt.cFlag && Char.myCharz().cFlag != (sbyte) 0 && cAtt.cFlag != (sbyte) 0) && cAtt.statusMe != 14 && cAtt.statusMe != 5;

  public void clearTask()
  {
    Char.myCharz().taskMaint = (Task) null;
    for (int index = 0; index < Char.myCharz().arrItemBag.Length; ++index)
    {
      if (Char.myCharz().arrItemBag[index] != null && Char.myCharz().arrItemBag[index].template.type == (sbyte) 8)
        Char.myCharz().arrItemBag[index] = (Item) null;
    }
    Npc.clearEffTask();
  }

  public int getX() => this.cx;

  public int getY() => this.cy;

  public int getH() => 32;

  public int getW() => 24;

  public void focusManualTo(object objectz)
  {
    switch (objectz)
    {
      case Mob _:
        this.mobFocus = (Mob) objectz;
        this.deFocusNPC();
        this.charFocus = (Char) null;
        this.itemFocus = (ItemMap) null;
        break;
      case Npc _:
        Char.myCharz().mobFocus = (Mob) null;
        Char.myCharz().deFocusNPC();
        Char.myCharz().npcFocus = (Npc) objectz;
        Char.myCharz().charFocus = (Char) null;
        Char.myCharz().itemFocus = (ItemMap) null;
        break;
      case Char _:
        Char.myCharz().mobFocus = (Mob) null;
        Char.myCharz().deFocusNPC();
        Char.myCharz().charFocus = (Char) objectz;
        Char.myCharz().itemFocus = (ItemMap) null;
        break;
      case ItemMap _:
        Char.myCharz().mobFocus = (Mob) null;
        Char.myCharz().deFocusNPC();
        Char.myCharz().charFocus = (Char) null;
        Char.myCharz().itemFocus = (ItemMap) objectz;
        break;
    }
    Char.isManualFocus = true;
  }

  public void stopMoving()
  {
  }

  public void cancelAttack()
  {
  }

  public bool isInvisible() => false;

  public bool focusToAttack()
  {
    if (this.mobFocus != null)
      return true;
    return this.charFocus != null && this.isMeCanAttackOtherPlayer(this.charFocus);
  }

  public void addDustEff(int type)
  {
    if (GameCanvas.lowGraphic)
      return;
    switch (type)
    {
      case 1:
        if (this.clevel < 9)
          break;
        EffecMn.addEff(new Effect(19, this.cx - 5, this.cy + 20, 2, 1, -1));
        break;
      case 2:
        if (this.me && this.isMonkey == (sbyte) 1 || !this.isNhapThe || GameCanvas.gameTick % 5 != 0)
          break;
        EffecMn.addEff(new Effect(22, this.cx - 5, this.cy + 35, 2, 1, -1));
        break;
      case 3:
        if (this.clevel < 9 || this.ySd - this.cy > 5)
          break;
        EffecMn.addEff(new Effect(19, this.cx - 5, this.ySd + 20, 2, 1, -1));
        break;
    }
  }

  public bool isGetFlagImage(sbyte getFlag)
  {
    bool flagImage = true;
    for (int index = 0; index < GameScr.vFlag.size(); ++index)
    {
      PKFlag pkFlag = (PKFlag) GameScr.vFlag.elementAt(index);
      if (pkFlag != null)
      {
        if ((int) pkFlag.cflag == (int) getFlag)
          return true;
        flagImage = false;
      }
    }
    return flagImage;
  }

  private void paintPKFlag(mGraphics g)
  {
    if (this.cdir == 1)
    {
      if (this.cFlag == (sbyte) 0 || this.cFlag == (sbyte) -1)
        return;
      SmallImage.drawSmallImage(g, this.flagImage, this.cx - 10, this.cy - this.ch - (!this.me ? 30 : 30) + (GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), 2, 0);
    }
    else
    {
      if (this.cFlag == (sbyte) 0 || this.cFlag == (sbyte) -1)
        return;
      SmallImage.drawSmallImage(g, this.flagImage, this.cx, this.cy - this.ch - (!this.me ? 30 : 30) + (GameCanvas.gameTick % 20 <= 10 ? 0 : GameCanvas.gameTick % 4 / 2), 0, 0);
    }
  }

  public void removeHoleEff()
  {
    if (this.holder)
    {
      this.holder = false;
      this.charHold = (Char) null;
      this.mobHold = (Mob) null;
    }
    else
    {
      this.holdEffID = 0;
      this.charHold = (Char) null;
      this.mobHold = (Mob) null;
    }
  }

  public void removeProtectEff()
  {
    this.protectEff = false;
    this.eProtect = (Effect) null;
  }

  public void removeBlindEff() => this.blindEff = false;

  public void removeEffect()
  {
    if (this.holdEffID != 0)
      this.holdEffID = 0;
    if (this.holder)
      this.holder = false;
    if (this.protectEff)
      this.protectEff = false;
    this.eProtect = (Effect) null;
    this.charHold = (Char) null;
    this.mobHold = (Mob) null;
    this.blindEff = false;
    this.sleepEff = false;
  }

  public void setPos(short xPos, short yPos, sbyte typePos)
  {
    this.isSetPos = true;
    this.xPos = xPos;
    this.yPos = yPos;
    this.typePos = typePos;
    this.tpos = 0;
    if (!this.me)
      return;
    if (GameCanvas.panel != null)
      GameCanvas.panel.hide();
    if (GameCanvas.panel2 == null)
      return;
    GameCanvas.panel2.hide();
  }

  public void removeHuytSao() => this.huytSao = false;

  public void fusionComplete()
  {
    this.isFusion = false;
    Char.isLockKey = false;
    this.tFusion = 0;
  }

  public void setFusion(sbyte fusion)
  {
    this.tFusion = 0;
    if (fusion == (sbyte) 4 || fusion == (sbyte) 5)
    {
      if (this.me)
        Service.gI().funsion(fusion);
      EffecMn.addEff(new Effect(34, this.cx, this.cy + 12, 2, 1, -1));
    }
    if (fusion == (sbyte) 6)
      EffecMn.addEff(new Effect(38, this.cx, this.cy + 12, 2, 1, -1));
    if (this.me)
    {
      GameCanvas.panel.hideNow();
      Char.isLockKey = true;
    }
    this.isFusion = true;
    if (fusion == (sbyte) 1)
      this.isNhapThe = false;
    else
      this.isNhapThe = true;
  }

  public void removeSleepEff() => this.sleepEff = false;

  public void setPartOld()
  {
    this.headTemp = this.head;
    this.bodyTemp = this.body;
    this.legTemp = this.leg;
    this.bagTemp = this.bag;
  }

  public void setPartTemp(int head, int body, int leg, int bag)
  {
    if (head != -1)
      this.head = head;
    if (body != -1)
      this.body = body;
    if (leg != -1)
      this.leg = leg;
    if (bag == -1)
      return;
    this.bag = bag;
  }

  public void resetPartTemp()
  {
    if (this.headTemp != -1)
    {
      this.head = this.headTemp;
      this.headTemp = -1;
    }
    if (this.bodyTemp != -1)
    {
      this.body = this.bodyTemp;
      this.bodyTemp = -1;
    }
    if (this.legTemp != -1)
    {
      this.leg = this.legTemp;
      this.legTemp = -1;
    }
    if (this.bagTemp == -1)
      return;
    this.bag = this.bagTemp;
    this.bagTemp = -1;
  }

  public Effect getEffById(int id)
  {
    for (int index = 0; index < this.vEffChar.size(); ++index)
    {
      Effect effById = (Effect) this.vEffChar.elementAt(index);
      if (effById.effId == id)
        return effById;
    }
    return (Effect) null;
  }

  public void addEffChar(Effect e)
  {
    this.removeEffChar(0, e.effId);
    this.vEffChar.addElement((object) e);
  }

  public void removeEffChar(int type, int id)
  {
    if (type == -1)
    {
      this.vEffChar.removeAllElements();
    }
    else
    {
      if (this.getEffById(id) == null)
        return;
      this.vEffChar.removeElement((object) this.getEffById(id));
    }
  }

  public void paintEffBehind(mGraphics g)
  {
    for (int index = 0; index < this.vEffChar.size(); ++index)
    {
      Effect effect = (Effect) this.vEffChar.elementAt(index);
      if (effect.layer == 0)
      {
        bool flag = true;
        if (effect.isStand == 0)
          flag = this.statusMe == 1 || this.statusMe == 6;
        if (flag)
          effect.paint(g);
      }
    }
  }

  public void paintEffFront(mGraphics g)
  {
    for (int index = 0; index < this.vEffChar.size(); ++index)
    {
      Effect effect = (Effect) this.vEffChar.elementAt(index);
      if (effect.layer == 1)
      {
        bool flag = true;
        if (effect.isStand == 0)
          flag = this.statusMe == 1 || this.statusMe == 6;
        if (flag)
          effect.paint(g);
      }
    }
  }

  public void updEffChar()
  {
    for (int index = 0; index < this.vEffChar.size(); ++index)
      ((Effect) this.vEffChar.elementAt(index)).update();
  }

  public int checkLuong() => this.luong + this.luongKhoa;

  public void updateEye()
  {
    if (this.head != 934)
      return;
    if (GameCanvas.timeNow - this.timeAddChopmat > 0L)
    {
      ++this.fChopmat;
      if (this.fChopmat <= this.frEye.Length - 1)
        return;
      this.fChopmat = 0;
      this.timeAddChopmat = GameCanvas.timeNow + (long) Res.random(2000, 3500);
      this.frEye = this.frChopCham;
      if (Res.random(2) != 0)
        return;
      this.frEye = this.frChopNhanh;
    }
    else
      this.fChopmat = 0;
  }

  private void paintRedEye(mGraphics g, int xx, int yy, int trans, int anchor)
  {
    if (this.head != 934 || this.statusMe != 1 && this.statusMe != 6)
      return;
    if (Char.fraRedEye == null || Char.fraRedEye.imgFrame == null)
    {
      Char.fraRedEye = new FrameImage(mSystem.loadImage("/redeye.png"), 14, 10);
    }
    else
    {
      if (this.frEye[this.fChopmat] == -1)
        return;
      int num1 = 8;
      int num2 = 15;
      if (trans == 2)
        num1 = -8;
      Char.fraRedEye.drawFrame(this.frEye[this.fChopmat], xx + num1, yy + num2, trans, anchor, g);
    }
  }

  public bool isHead_2Fr(int idHead)
  {
    for (int index = 0; index < Char.Arr_Head_2Fr.Length; ++index)
    {
      if (Char.Arr_Head_2Fr[index][0] == idHead)
        return true;
    }
    return false;
  }

  private void updateFHead()
  {
    if (this.isHead_2Fr(this.head))
    {
      ++this.fHead;
      if (this.fHead <= 10000)
        return;
      this.fHead = 0;
    }
    else
      this.fHead = 0;
  }

  private int getFHead(int idHead)
  {
    int fhead = idHead;
    for (int index = 0; index < Char.Arr_Head_2Fr.Length; ++index)
    {
      if (Char.Arr_Head_2Fr[index][0] == idHead)
        return Char.Arr_Head_2Fr[index][this.fHead / 4 % Char.Arr_Head_2Fr[index].Length];
    }
    return fhead;
  }

  public void paintAuraBehind(mGraphics g)
  {
    if (this.me && !Char.isPaintAura || this.idAuraEff <= (short) -1 || this.statusMe != 1 && this.statusMe != 6 || GameCanvas.panel.isShow || mSystem.currentTimeMillis() - this.timeBlue <= 0L)
      return;
    FrameImage fraImage = mSystem.getFraImage(this.strEffAura + (object) this.idAuraEff + "_0");
    fraImage?.drawFrame(GameCanvas.gameTick / 4 % fraImage.nFrame, this.cx, this.cy, this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
  }

  public void paintAuraFront(mGraphics g)
  {
    if (this.me && !Char.isPaintAura || this.idAuraEff <= (short) -1)
      return;
    if (this.statusMe == 1 || this.statusMe == 6)
    {
      if (GameCanvas.panel.isShow || GameCanvas.lowGraphic)
        return;
      bool flag = false;
      if (mSystem.currentTimeMillis() - this.timeBlue > -1000L && this.IsAddDust1)
      {
        flag = true;
        this.IsAddDust1 = false;
      }
      if (mSystem.currentTimeMillis() - this.timeBlue > -500L && this.IsAddDust2)
      {
        flag = true;
        this.IsAddDust2 = false;
      }
      if (flag)
      {
        GameCanvas.gI().startDust(-1, this.cx - -8, this.cy);
        GameCanvas.gI().startDust(1, this.cx - 8, this.cy);
        this.addDustEff(1);
      }
      if (mSystem.currentTimeMillis() - this.timeBlue <= 0L)
        return;
      FrameImage fraImage = mSystem.getFraImage(this.strEffAura + (object) this.idAuraEff + "_1");
      fraImage?.drawFrame(GameCanvas.gameTick / 4 % fraImage.nFrame, this.cx, this.cy + 2, this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
    }
    else
    {
      this.timeBlue = mSystem.currentTimeMillis() + 1500L;
      this.IsAddDust1 = true;
      this.IsAddDust2 = true;
    }
  }

  public void paintEff_Lvup_behind(mGraphics g)
  {
    if (this.idEff_Set_Item == (short) -1)
      return;
    if (this.fraEff != null)
      this.fraEff.drawFrame(GameCanvas.gameTick / 4 % this.fraEff.nFrame, this.cx, this.cy + 3, this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
    else
      this.fraEff = mSystem.getFraImage(this.strEff_Set_Item + (object) this.idEff_Set_Item + "_0");
  }

  public void paintEff_Lvup_front(mGraphics g)
  {
    if (this.idEff_Set_Item == (short) -1)
      return;
    if (this.fraEffSub != null)
      this.fraEffSub.drawFrame(GameCanvas.gameTick / 4 % this.fraEffSub.nFrame, this.cx, this.cy + 8, this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
    else
      this.fraEffSub = mSystem.getFraImage(this.strEff_Set_Item + (object) this.idEff_Set_Item + "_1");
  }

  public void paintHat_behind(mGraphics g, int cf, int yh)
  {
    try
    {
      if (this.idHat == (short) -1)
        return;
      if (this.isFrNgang(cf))
      {
        if (this.fraHat_behind_2 != null)
          this.fraHat_behind_2.drawFrame(GameCanvas.gameTick / 4 % this.fraHat_behind_2.nFrame, this.cx + Char.hatInfo[cf][0] * (this.cdir != 1 ? -1 : 1), yh + Char.hatInfo[cf][1], this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
        else
          this.fraHat_behind_2 = mSystem.getFraImage(this.strHat_behind + this.strNgang + (object) this.idHat);
      }
      else if (this.fraHat_behind != null)
        this.fraHat_behind.drawFrame(GameCanvas.gameTick / 4 % this.fraHat_behind.nFrame, this.cx + Char.hatInfo[cf][0] * (this.cdir != 1 ? -1 : 1), yh + Char.hatInfo[cf][1], this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
      else
        this.fraHat_behind = mSystem.getFraImage(this.strHat_behind + (object) this.idHat);
    }
    catch (Exception ex)
    {
    }
  }

  public void paintHat_front(mGraphics g, int cf, int yh)
  {
    try
    {
      if (this.idHat == (short) -1)
        return;
      if (this.isFrNgang(cf))
      {
        if (this.fraHat_font_2 != null)
          this.fraHat_font_2.drawFrame(GameCanvas.gameTick / 4 % this.fraHat_font_2.nFrame, this.cx + Char.hatInfo[cf][0] * (this.cdir != 1 ? -1 : 1), yh + Char.hatInfo[cf][1], this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
        else
          this.fraHat_font_2 = mSystem.getFraImage(this.strHat_font + this.strNgang + (object) this.idHat);
      }
      else if (this.fraHat_font != null)
        this.fraHat_font.drawFrame(GameCanvas.gameTick / 4 % this.fraHat_font.nFrame, this.cx + Char.hatInfo[cf][0] * (this.cdir != 1 ? -1 : 1), yh + Char.hatInfo[cf][1], this.cdir != 1 ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
      else
        this.fraHat_font = mSystem.getFraImage(this.strHat_font + (object) this.idHat);
    }
    catch (Exception ex)
    {
    }
  }

  public bool isFrNgang(int fr) => fr == 2 || fr == 3 || fr == 4 || fr == 5 || fr == 6 || fr == 9 || fr == 10 || fr == 13 || fr == 14 || fr == 15 || fr == 16 || fr == 26 || fr == 27 || fr == 28 || fr == 29;
}
