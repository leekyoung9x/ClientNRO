// Decompiled with JetBrains decompiler
// Type: Main
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;

public class Main : MonoBehaviour
{
  public static Main main;
  public static mGraphics g;
  public static GameMidlet midlet;
  public static string res = nameof (res);
  public static string mainThreadName;
  public static bool started;
  public static bool isIpod;
  public static bool isIphone4;
  public static bool isPC;
  public static bool isWindowsPhone;
  public static bool isIPhone;
  public static bool IphoneVersionApp;
  public static string IMEI;
  public static int versionIp;
  public static int numberQuit = 1;
  public static int typeClient = 4;
  public const sbyte PC_VERSION = 4;
  public const sbyte IP_APPSTORE = 5;
  public const sbyte WINDOWSPHONE = 6;
  private int level;
  public const sbyte IP_JB = 3;
  private int updateCount;
  private int paintCount;
  private int count;
  private int fps;
  private int max;
  private int up;
  private int upmax;
  private long timefps;
  private long timeup;
  private bool isRun;
  public static int waitTick;
  public static int f;
  public static bool isResume;
  public static bool isMiniApp = true;
  public static bool isQuitApp;
  private Vector2 lastMousePos = new Vector2();
  public static int a = 1;
  public static bool isCompactDevice = true;

  private void Start()
  {
    if (Main.started)
      return;
    if (Thread.CurrentThread.Name != nameof (Main))
      Thread.CurrentThread.Name = nameof (Main);
    Main.mainThreadName = Thread.CurrentThread.Name;
    Main.isPC = true;
    Main.started = true;
    if (!Main.isPC)
      return;
    this.level = Rms.loadRMSInt("levelScreenKN");
    if (this.level == 1)
      Screen.SetResolution(720, 320, false);
    else
      Screen.SetResolution(1024, 600, false);
  }

  private void SetInit() => this.enabled = true;

  private void OnHideUnity(bool isGameShown)
  {
    if (!isGameShown)
      Time.timeScale = 0.0f;
    else
      Time.timeScale = 1f;
  }

  private void OnGUI()
  {
    if (this.count < 10)
      return;
    if (this.fps == 0)
      this.timefps = mSystem.currentTimeMillis();
    else if (mSystem.currentTimeMillis() - this.timefps > 1000L)
    {
      this.max = this.fps;
      this.fps = 0;
      this.timefps = mSystem.currentTimeMillis();
    }
    ++this.fps;
    this.checkInput();
    Session_ME.update();
    Session_ME2.update();
    if (!Event.current.type.Equals((object) EventType.Repaint) || this.paintCount > this.updateCount)
      return;
    GameMidlet.gameCanvas.paint(Main.g);
    ++this.paintCount;
    Main.g.reset();
  }

  public void setsizeChange()
  {
    if (this.isRun)
      return;
    Screen.orientation = ScreenOrientation.LandscapeLeft;
    Application.runInBackground = true;
    Application.targetFrameRate = 35;
    this.useGUILayout = false;
    Main.isCompactDevice = Main.detectCompactDevice();
    if ((Object) Main.main == (Object) null)
      Main.main = this;
    this.isRun = true;
    ScaleGUI.initScaleGUI();
    Main.IMEI = !Main.isPC ? this.GetMacAddress() : SystemInfo.deviceUniqueIdentifier;
    Main.isPC = true;
    if (Main.isPC)
      Screen.fullScreen = false;
    if (Main.isWindowsPhone)
      Main.typeClient = 6;
    if (Main.isPC)
      Main.typeClient = 4;
    if (Main.IphoneVersionApp)
      Main.typeClient = 5;
    if (iPhoneSettings.generation == iPhoneGeneration.iPodTouch4Gen)
      Main.isIpod = true;
    if (iPhoneSettings.generation == iPhoneGeneration.iPhone4)
      Main.isIphone4 = true;
    Main.g = new mGraphics();
    Main.midlet = new GameMidlet();
    TileMap.loadBg();
    Paint.loadbg();
    PopUp.loadBg();
    GameScr.loadBg();
    InfoMe.gI().loadCharId();
    Panel.loadBg();
    Menu.loadBg();
    Key.mapKeyPC();
    SoundMn.gI().loadSound(TileMap.mapID);
    Main.g.CreateLineMaterial();
  }

  public static void setBackupIcloud(string path)
  {
  }

  public string GetMacAddress()
  {
    string empty = string.Empty;
    foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
    {
      PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
      if (physicalAddress.ToString() != string.Empty)
        return physicalAddress.ToString();
    }
    return string.Empty;
  }

  public void doClearRMS()
  {
    if (!Main.isPC || Rms.loadRMSInt("lastZoomlevel") == mGraphics.zoomLevel)
      return;
    Rms.clearAll();
    Rms.saveRMSInt("lastZoomlevel", mGraphics.zoomLevel);
    Rms.saveRMSInt("levelScreenKN", this.level);
  }

  public static void closeKeyBoard()
  {
    if (!TouchScreenKeyboard.visible)
      return;
    TField.kb.active = false;
    TField.kb = (TouchScreenKeyboard) null;
  }

  private void FixedUpdate()
  {
    Rms.update();
    ++this.count;
    if (this.count < 10)
      return;
    if (this.up == 0)
      this.timeup = mSystem.currentTimeMillis();
    else if (mSystem.currentTimeMillis() - this.timeup > 1000L)
    {
      this.upmax = this.up;
      this.up = 0;
      this.timeup = mSystem.currentTimeMillis();
    }
    ++this.up;
    this.setsizeChange();
    ++this.updateCount;
    ipKeyboard.update();
    GameMidlet.gameCanvas.update();
    Image.update();
    DataInputStream.update();
    SMS.update();
    global::Net.update();
    ++Main.f;
    if (Main.f > 8)
      Main.f = 0;
    if (Main.isPC)
      return;
    int num = 1 / Main.a;
  }

  private void Update()
  {
  }

  private void checkInput()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Vector3 mousePosition = Input.mousePosition;
      GameMidlet.gameCanvas.pointerPressed((int) ((double) mousePosition.x / (double) mGraphics.zoomLevel), (int) (((double) Screen.height - (double) mousePosition.y) / (double) mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
      this.lastMousePos.x = mousePosition.x / (float) mGraphics.zoomLevel;
      this.lastMousePos.y = mousePosition.y / (float) mGraphics.zoomLevel + (float) mGraphics.addYWhenOpenKeyBoard;
    }
    if (Input.GetMouseButton(0))
    {
      Vector3 mousePosition = Input.mousePosition;
      GameMidlet.gameCanvas.pointerDragged((int) ((double) mousePosition.x / (double) mGraphics.zoomLevel), (int) (((double) Screen.height - (double) mousePosition.y) / (double) mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
      this.lastMousePos.x = mousePosition.x / (float) mGraphics.zoomLevel;
      this.lastMousePos.y = mousePosition.y / (float) mGraphics.zoomLevel + (float) mGraphics.addYWhenOpenKeyBoard;
    }
    if (Input.GetMouseButtonUp(0))
    {
      Vector3 mousePosition = Input.mousePosition;
      this.lastMousePos.x = mousePosition.x / (float) mGraphics.zoomLevel;
      this.lastMousePos.y = mousePosition.y / (float) mGraphics.zoomLevel + (float) mGraphics.addYWhenOpenKeyBoard;
      GameMidlet.gameCanvas.pointerReleased((int) ((double) mousePosition.x / (double) mGraphics.zoomLevel), (int) (((double) Screen.height - (double) mousePosition.y) / (double) mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
    }
    if (Input.anyKeyDown && Event.current.type == EventType.KeyDown)
    {
      int keyCode = MyKeyMap.map(Event.current.keyCode);
      if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
      {
        switch (Event.current.keyCode)
        {
          case KeyCode.Minus:
            keyCode = 95;
            break;
          case KeyCode.Alpha2:
            keyCode = 64;
            break;
        }
      }
      if (keyCode != 0)
        GameMidlet.gameCanvas.keyPressedz(keyCode);
    }
    if (Event.current.type == EventType.KeyUp)
    {
      int keyCode = MyKeyMap.map(Event.current.keyCode);
      if (keyCode != 0)
        GameMidlet.gameCanvas.keyReleasedz(keyCode);
    }
    if (!Main.isPC)
      return;
    GameMidlet.gameCanvas.scrollMouse((int) ((double) Input.GetAxis("Mouse ScrollWheel") * 10.0));
    float x1 = Input.mousePosition.x;
    float y1 = Input.mousePosition.y;
    int x2 = (int) x1 / mGraphics.zoomLevel;
    int y2 = (Screen.height - (int) y1) / mGraphics.zoomLevel;
    GameMidlet.gameCanvas.pointerMouse(x2, y2);
  }

  private void OnApplicationQuit()
  {
    Debug.LogWarning((object) "APP QUIT");
    GameCanvas.bRun = false;
    Session_ME.gI().close();
    Session_ME2.gI().close();
    if (!Main.isPC)
      return;
    Application.Quit();
  }

  private void OnApplicationPause(bool paused)
  {
    Main.isResume = false;
    if (paused)
    {
      if (GameCanvas.isWaiting())
        Main.isQuitApp = true;
    }
    else
      Main.isResume = true;
    if (TouchScreenKeyboard.visible)
    {
      TField.kb.active = false;
      TField.kb = (TouchScreenKeyboard) null;
    }
    if (!Main.isQuitApp)
      return;
    Application.Quit();
  }

  public static void exit()
  {
    if (Main.isPC)
      Main.main.OnApplicationQuit();
    else
      Main.a = 0;
  }

  public static bool detectCompactDevice() => iPhoneSettings.generation != iPhoneGeneration.iPhone && iPhoneSettings.generation != iPhoneGeneration.iPhone3G && iPhoneSettings.generation != iPhoneGeneration.iPodTouch1Gen && iPhoneSettings.generation != iPhoneGeneration.iPodTouch2Gen;

  public static bool checkCanSendSMS() => iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation > iPhoneGeneration.iPodTouch4Gen;
}
