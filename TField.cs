// Decompiled with JetBrains decompiler
// Type: TField
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Threading;

public class TField : IActionListener
{
  public bool isFocus;
  public int x;
  public int y;
  public int width;
  public int height;
  public bool lockArrow;
  public bool justReturnFromTextBox;
  public bool paintFocus = true;
  public const sbyte KEY_LEFT = 14;
  public const sbyte KEY_RIGHT = 15;
  public const sbyte KEY_CLEAR = 19;
  public static int typeXpeed = 2;
  private static readonly int[] MAX_TIME_TO_CONFIRM_KEY = new int[7]
  {
    30,
    14,
    11,
    9,
    6,
    4,
    2
  };
  private static int CARET_HEIGHT = 0;
  private static readonly int CARET_WIDTH = 1;
  private static readonly int CARET_SHOWING_TIME = 5;
  private static readonly int TEXT_GAP_X = 4;
  private static readonly int MAX_SHOW_CARET_COUNER = 10;
  public static readonly int INPUT_TYPE_ANY = 0;
  public static readonly int INPUT_TYPE_NUMERIC = 1;
  public static readonly int INPUT_TYPE_PASSWORD = 2;
  public static readonly int INPUT_ALPHA_NUMBER_ONLY = 3;
  private static string[] print = new string[12]
  {
    " 0",
    ".,@?!_1\"/$-():*+<=>;%&~#%^&*{}[];'/1",
    "abc2áàảãạâấầẩẫậăắằẳẵặ2",
    "def3đéèẻẽẹêếềểễệ3",
    "ghi4íìỉĩị4",
    "jkl5",
    "mno6óòỏõọôốồổỗộơớờởỡợ6",
    "pqrs7",
    "tuv8úùủũụưứừửữự8",
    "wxyz9ýỳỷỹỵ9",
    "*",
    "#"
  };
  private static string[] printA = new string[12]
  {
    "0",
    "1",
    "abc2",
    "def3",
    "ghi4",
    "jkl5",
    "mno6",
    "pqrs7",
    "tuv8",
    "wxyz9",
    "0",
    "0"
  };
  private static string[] printBB = new string[17]
  {
    " 0",
    "er1",
    "ty2",
    "ui3",
    "df4",
    "gh5",
    "jk6",
    "cv7",
    "bn8",
    "m9",
    "0",
    "0",
    "qw!",
    "as?",
    "zx",
    "op.",
    "l,"
  };
  private string text = string.Empty;
  private string passwordText = string.Empty;
  private string paintedText = string.Empty;
  private int caretPos;
  private int counter;
  private int maxTextLenght = 500;
  private int offsetX;
  private static int lastKey = -1984;
  private int keyInActiveState;
  private int indexOfActiveChar;
  private int showCaretCounter = TField.MAX_SHOW_CARET_COUNER;
  private int inputType = TField.INPUT_TYPE_ANY;
  public static bool isQwerty = true;
  public static int typingModeAreaWidth;
  public static int mode = 0;
  public static long timeChangeMode;
  public static readonly string[] modeNotify = new string[4]
  {
    nameof (abc),
    nameof (Abc),
    nameof (ABC),
    "123"
  };
  public static readonly int NOKIA = 0;
  public static readonly int MOTO = 1;
  public static readonly int ORTHER = 2;
  public static readonly int BB = 3;
  public static int changeModeKey = 11;
  public static readonly sbyte abc = 0;
  public static readonly sbyte Abc = 1;
  public static readonly sbyte ABC = 2;
  public static readonly sbyte number123 = 3;
  public static TField currentTField;
  public bool isTfield;
  public bool isPaintMouse = true;
  public string name = string.Empty;
  public string title = string.Empty;
  public string strInfo;
  public Command cmdClear;
  public Command cmdDoneAction;
  private mScreen parentScr;
  private int timeDelayKyCode;
  private int holdCount;
  public static int changeDau;
  private int indexDau = -1;
  private int indexTemplate;
  private int indexCong;
  private long timeDau;
  private static string printDau = "aáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ";
  public static Image imgTf;
  public int timePutKeyClearAll;
  public int timeClearFirt;
  public bool isPaintCarret;
  public bool showSubTextField = true;
  public static TouchScreenKeyboard kb;
  public static int[][] BBKEY = new int[17][]
  {
    new int[2]{ 32, 48 },
    new int[2]{ 49, 69 },
    new int[2]{ 50, 84 },
    new int[2]{ 51, 85 },
    new int[2]{ 52, 68 },
    new int[2]{ 53, 71 },
    new int[2]{ 54, 74 },
    new int[2]{ 55, 67 },
    new int[2]{ 56, 66 },
    new int[2]{ 57, 77 },
    new int[2]{ 42, 128 },
    new int[2]{ 35, 137 },
    new int[2]{ 33, 113 },
    new int[2]{ 63, 97 },
    new int[3]{ 64, 121, 122 },
    new int[2]{ 46, 111 },
    new int[2]{ 44, 108 }
  };

  public TField(mScreen parentScr)
  {
    this.text = string.Empty;
    this.parentScr = parentScr;
    this.init();
  }

  public TField()
  {
    this.text = string.Empty;
    this.init();
  }

  public TField(int x, int y, int w, int h)
  {
    this.text = string.Empty;
    this.init();
    this.x = x;
    this.y = y;
    this.width = w;
    this.height = h;
  }

  public TField(string text, int maxLen, int inputType)
  {
    this.text = text;
    this.maxTextLenght = maxLen;
    this.inputType = inputType;
    this.init();
    this.isTfield = true;
  }

  public static bool setNormal(char ch) => ch >= '0' && ch <= '9' || ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z';

  public void doChangeToTextBox()
  {
  }

  public static void setVendorTypeMode(int mode)
  {
    if (mode == TField.MOTO)
    {
      TField.print[0] = "0";
      TField.print[10] = " *";
      TField.print[11] = "#";
      TField.changeModeKey = 35;
    }
    else if (mode == TField.NOKIA)
    {
      TField.print[0] = " 0";
      TField.print[10] = "*";
      TField.print[11] = "#";
      TField.changeModeKey = 35;
    }
    else
    {
      if (mode != TField.ORTHER)
        return;
      TField.print[0] = "0";
      TField.print[10] = "*";
      TField.print[11] = " #";
      TField.changeModeKey = 42;
    }
  }

  public void init()
  {
    TField.CARET_HEIGHT = mScreen.ITEM_HEIGHT + 1;
    this.cmdClear = new Command(mResources.DELETE, (IActionListener) this, 1000, (object) null);
    if (Main.isPC)
      TField.typeXpeed = 0;
    if (TField.imgTf != null)
      return;
    TField.imgTf = GameCanvas.loadImage("/mainImage/myTexture2dtf.png");
  }

  public void clearKeyWhenPutText(int keyCode)
  {
    if (keyCode != -8 || this.timeDelayKyCode > 0)
      return;
    if (this.timeDelayKyCode <= 0)
      this.timeDelayKyCode = 1;
    this.clear();
  }

  public void clearAllText()
  {
    this.text = string.Empty;
    if (TField.kb != null)
      TField.kb.text = string.Empty;
    this.caretPos = 0;
    this.setOffset(0);
    this.setPasswordTest();
  }

  public void clear()
  {
    if (this.caretPos <= 0 || this.text.Length <= 0)
      return;
    this.text = this.text.Substring(0, this.caretPos - 1);
    --this.caretPos;
    this.setOffset(0);
    this.setPasswordTest();
    if (TField.kb == null)
      return;
    TField.kb.text = this.text;
  }

  public void clearAll()
  {
    if (this.caretPos <= 0 || this.text.Length <= 0)
      return;
    this.text = this.text.Substring(0, this.text.Length - 1);
    --this.caretPos;
    this.setOffset();
    this.setPasswordTest();
    this.setFocusWithKb(true);
    if (TField.kb == null)
      return;
    TField.kb.text = string.Empty;
  }

  public void setOffset()
  {
    if (this.paintedText == null || mFont.tahoma_8b == null)
      return;
    this.paintedText = this.inputType != TField.INPUT_TYPE_PASSWORD ? this.text : this.passwordText;
    if (this.offsetX < 0 && mFont.tahoma_8b.getWidth(this.paintedText) + this.offsetX < this.width - TField.TEXT_GAP_X - 13 - TField.typingModeAreaWidth)
      this.offsetX = this.width - 10 - TField.typingModeAreaWidth - mFont.tahoma_8b.getWidth(this.paintedText);
    if (this.offsetX + mFont.tahoma_8b.getWidth(this.paintedText.Substring(0, this.caretPos)) <= 0)
    {
      this.offsetX = -mFont.tahoma_8b.getWidth(this.paintedText.Substring(0, this.caretPos));
      this.offsetX += 40;
    }
    else if (this.offsetX + mFont.tahoma_8b.getWidth(this.paintedText.Substring(0, this.caretPos)) >= this.width - 12 - TField.typingModeAreaWidth)
      this.offsetX = this.width - 10 - TField.typingModeAreaWidth - mFont.tahoma_8b.getWidth(this.paintedText.Substring(0, this.caretPos)) - 2 * TField.TEXT_GAP_X;
    if (this.offsetX <= 0)
      return;
    this.offsetX = 0;
  }

  private void keyPressedAny(int keyCode)
  {
    string[] strArray = this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY ? TField.printA : TField.print;
    if (keyCode == TField.lastKey)
    {
      this.indexOfActiveChar = (this.indexOfActiveChar + 1) % strArray[keyCode - 48].Length;
      char c = strArray[keyCode - 48][this.indexOfActiveChar];
      char ch;
      switch (TField.mode)
      {
        case 0:
          ch = char.ToLower(c);
          break;
        case 1:
          ch = char.ToUpper(c);
          break;
        case 2:
          ch = char.ToUpper(c);
          break;
        default:
          ch = strArray[keyCode - 48][strArray[keyCode - 48].Length - 1];
          break;
      }
      string str = this.text.Substring(0, this.caretPos - 1) + (object) ch;
      if (this.caretPos < this.text.Length)
        str += this.text.Substring(this.caretPos, this.text.Length);
      this.text = str;
      this.keyInActiveState = TField.MAX_TIME_TO_CONFIRM_KEY[TField.typeXpeed];
      this.setPasswordTest();
    }
    else if (this.text.Length < this.maxTextLenght)
    {
      if (TField.mode == 1 && TField.lastKey != -1984)
        TField.mode = 0;
      this.indexOfActiveChar = 0;
      char c = strArray[keyCode - 48][this.indexOfActiveChar];
      char ch = TField.mode != 0 ? (TField.mode != 1 ? (TField.mode != 2 ? strArray[keyCode - 48][strArray[keyCode - 48].Length - 1] : char.ToUpper(c)) : char.ToUpper(c)) : char.ToLower(c);
      string str = this.text.Substring(0, this.caretPos) + (object) ch;
      if (this.caretPos < this.text.Length)
        str += this.text.Substring(this.caretPos, this.text.Length);
      this.text = str;
      this.keyInActiveState = TField.MAX_TIME_TO_CONFIRM_KEY[TField.typeXpeed];
      ++this.caretPos;
      this.setPasswordTest();
      this.setOffset();
    }
    TField.lastKey = keyCode;
  }

  private void keyPressedAscii(int keyCode)
  {
    if ((this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY) && (keyCode < 48 || keyCode > 57) && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 122))
      return;
    if (this.text.Length < this.maxTextLenght)
    {
      string str = this.text.Substring(0, this.caretPos) + (object) (char) keyCode;
      if (this.caretPos < this.text.Length)
        str += this.text.Substring(this.caretPos, this.text.Length - this.caretPos);
      this.text = str;
      ++this.caretPos;
      this.setPasswordTest();
      this.setOffset(0);
    }
    if (TField.kb == null)
      return;
    TField.kb.text = this.text;
  }

  public static void setMode()
  {
    ++TField.mode;
    if (TField.mode > 3)
      TField.mode = 0;
    TField.lastKey = TField.changeModeKey;
    TField.timeChangeMode = (long) (Environment.TickCount / 1000);
  }

  private void setDau()
  {
    this.timeDau = (long) (Environment.TickCount / 100);
    if (this.indexDau == -1)
    {
      for (int caretPos = this.caretPos; caretPos > 0; --caretPos)
      {
        char ch1 = this.text[caretPos - 1];
        for (int index = 0; index < TField.printDau.Length; ++index)
        {
          char ch2 = TField.printDau[index];
          if ((int) ch1 == (int) ch2)
          {
            this.indexTemplate = index;
            this.indexCong = 0;
            this.indexDau = caretPos - 1;
            return;
          }
        }
      }
      this.indexDau = -1;
    }
    else
    {
      ++this.indexCong;
      if (this.indexCong >= 6)
        this.indexCong = 0;
      string str1 = this.text.Substring(0, this.indexDau);
      string str2 = this.text.Substring(this.indexDau + 1);
      string str3 = TField.printDau.Substring(this.indexTemplate + this.indexCong, 1);
      this.text = str1 + str3 + str2;
    }
  }

  public bool keyPressed(int keyCode)
  {
    if (Main.isPC && keyCode == -8)
    {
      this.clearKeyWhenPutText(-8);
      return true;
    }
    if (keyCode == 8 || keyCode == -8 || keyCode == 204)
    {
      this.clear();
      return true;
    }
    if (TField.isQwerty && keyCode >= 32)
    {
      this.keyPressedAscii(keyCode);
      return false;
    }
    if (keyCode == TField.changeDau && this.inputType == TField.INPUT_TYPE_ANY)
    {
      this.setDau();
      return false;
    }
    if (keyCode == 42)
      keyCode = 58;
    if (keyCode == 35)
      keyCode = 59;
    if (keyCode >= 48 && keyCode <= 59)
    {
      if (this.inputType == TField.INPUT_TYPE_ANY || this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY)
        this.keyPressedAny(keyCode);
      else if (this.inputType == TField.INPUT_TYPE_NUMERIC)
      {
        this.keyPressedAscii(keyCode);
        this.keyInActiveState = 1;
      }
    }
    else
    {
      this.indexOfActiveChar = 0;
      TField.lastKey = -1984;
      if (keyCode == 14 && !this.lockArrow)
      {
        if (this.caretPos > 0)
        {
          --this.caretPos;
          this.setOffset(0);
          this.showCaretCounter = TField.MAX_SHOW_CARET_COUNER;
          return false;
        }
      }
      else if (keyCode == 15 && !this.lockArrow)
      {
        if (this.caretPos < this.text.Length)
        {
          ++this.caretPos;
          this.setOffset(0);
          this.showCaretCounter = TField.MAX_SHOW_CARET_COUNER;
          return false;
        }
      }
      else
      {
        if (keyCode == 19)
        {
          this.clear();
          return false;
        }
        TField.lastKey = keyCode;
      }
    }
    return true;
  }

  public void setOffset(int index)
  {
    this.paintedText = this.inputType != TField.INPUT_TYPE_PASSWORD ? this.text : this.passwordText;
    int width = mFont.tahoma_8b.getWidth(this.paintedText.Substring(0, this.caretPos));
    switch (index)
    {
      case -1:
        if (width + this.offsetX < 15 && this.caretPos > 0 && this.caretPos < this.paintedText.Length)
        {
          this.offsetX += mFont.tahoma_8b.getWidth(this.paintedText.Substring(this.caretPos, 1));
          break;
        }
        break;
      case 1:
        if (width + this.offsetX > this.width - 25 && this.caretPos < this.paintedText.Length && this.caretPos > 0)
        {
          this.offsetX -= mFont.tahoma_8b.getWidth(this.paintedText.Substring(this.caretPos - 1, 1));
          break;
        }
        break;
      default:
        this.offsetX = -(width - (this.width - 12));
        break;
    }
    if (this.offsetX > 0)
    {
      this.offsetX = 0;
    }
    else
    {
      if (this.offsetX >= 0)
        return;
      int num = mFont.tahoma_8b.getWidth(this.paintedText) - (this.width - 12);
      if (this.offsetX >= -num)
        return;
      this.offsetX = -num;
    }
  }

  public void paintInputTf(
    mGraphics g,
    bool iss,
    int x,
    int y,
    int w,
    int h,
    int xText,
    int yText,
    string text,
    string info)
  {
    g.setColor(0);
    if (iss)
    {
      g.drawRegion(TField.imgTf, 0, 81, 29, 27, 0, x, y, 0);
      g.drawRegion(TField.imgTf, 0, 135, 29, 27, 0, x + w - 29, y, 0);
      g.drawRegion(TField.imgTf, 0, 108, 29, 27, 0, x + w - 58, y, 0);
      for (int index = 0; index < (w - 58) / 29; ++index)
        g.drawRegion(TField.imgTf, 0, 108, 29, 27, 0, x + 29 + index * 29, y, 0);
    }
    else
    {
      g.drawRegion(TField.imgTf, 0, 0, 29, 27, 0, x, y, 0);
      g.drawRegion(TField.imgTf, 0, 54, 29, 27, 0, x + w - 29, y, 0);
      g.drawRegion(TField.imgTf, 0, 27, 29, 27, 0, x + w - 58, y, 0);
      for (int index = 0; index < (w - 58) / 29; ++index)
        g.drawRegion(TField.imgTf, 0, 27, 29, 27, 0, x + 29 + index * 29, y, 0);
    }
    g.setClip(x + 3, y + 1, w - 4, h);
    if (text != null && !text.Equals(string.Empty))
    {
      mFont.tahoma_8b.drawString(g, text, xText, yText, 0);
    }
    else
    {
      if (info == null)
        return;
      if (iss)
        mFont.tahoma_7b_focus.drawString(g, info, xText, yText, 0);
      else
        mFont.tahoma_7b_unfocus.drawString(g, info, xText, yText, 0);
    }
  }

  public void paint(mGraphics g)
  {
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    bool iss = this.isFocused();
    this.paintedText = this.inputType != TField.INPUT_TYPE_PASSWORD ? this.text : this.passwordText;
    this.paintInputTf(g, iss, this.x, this.y - 1, this.width, this.height + 5, TField.TEXT_GAP_X + this.offsetX + this.x + 1, this.y + (this.height - mFont.tahoma_8b.getHeight()) / 2 + 2, this.paintedText, this.name);
    g.setClip(this.x + 3, this.y + 1, this.width - 4, this.height - 2);
    g.setColor(0);
    if (!iss || !this.isPaintMouse || !this.isPaintCarret)
      return;
    if (this.keyInActiveState == 0 && (this.showCaretCounter > 0 || this.counter / TField.CARET_SHOWING_TIME % 4 == 0))
    {
      g.setColor(7999781);
      g.fillRect(TField.TEXT_GAP_X + 1 + this.offsetX + this.x + mFont.tahoma_8b.getWidth(this.paintedText.Substring(0, this.caretPos) + "a") - TField.CARET_WIDTH - mFont.tahoma_8b.getWidth("a"), this.y + (this.height - TField.CARET_HEIGHT) / 2 + 5, TField.CARET_WIDTH, TField.CARET_HEIGHT);
    }
    GameCanvas.resetTrans(g);
    if (this.text == null || this.text.Length <= 0 || !GameCanvas.isTouch)
      return;
    g.drawImage(GameCanvas.imgClear, this.x + this.width - 13, this.y + this.height / 2 + 3, mGraphics.VCENTER | mGraphics.HCENTER);
  }

  private bool isFocused() => this.isFocus;

  public string subString(string str, int index, int indexTo)
  {
    if (index >= 0 && indexTo > str.Length - 1)
      return str.Substring(index);
    if (index < 0 || index > str.Length - 1 || indexTo < 0 || indexTo > str.Length - 1)
      return string.Empty;
    string empty = string.Empty;
    for (int index1 = index; index1 < indexTo; ++index1)
      empty += (string) (object) str[index1];
    return empty;
  }

  private void setPasswordTest()
  {
    if (this.inputType != TField.INPUT_TYPE_PASSWORD)
      return;
    this.passwordText = string.Empty;
    for (int index = 0; index < this.text.Length; ++index)
      this.passwordText += "*";
    if (this.keyInActiveState <= 0 || this.caretPos <= 0)
      return;
    this.passwordText = this.passwordText.Substring(0, this.caretPos - 1) + (object) this.text[this.caretPos - 1] + this.passwordText.Substring(this.caretPos, this.passwordText.Length);
  }

  public void update()
  {
    this.isPaintCarret = true;
    if (Main.isPC)
    {
      if (this.timeDelayKyCode > 0)
        --this.timeDelayKyCode;
      if (this.timeDelayKyCode <= 0)
        this.timeDelayKyCode = 0;
    }
    if (TField.kb != null && TField.currentTField == this)
    {
      if (TField.kb.text.Length < 40 && this.isFocus)
        this.setText(TField.kb.text);
      if (TField.kb.done && this.cmdDoneAction != null)
        this.cmdDoneAction.performAction();
    }
    ++this.counter;
    if (this.keyInActiveState > 0)
    {
      --this.keyInActiveState;
      if (this.keyInActiveState == 0)
      {
        this.indexOfActiveChar = 0;
        if (TField.mode == 1 && TField.lastKey != TField.changeModeKey && this.isFocus)
          TField.mode = 0;
        TField.lastKey = -1984;
        this.setPasswordTest();
      }
    }
    if (this.showCaretCounter > 0)
      --this.showCaretCounter;
    if (GameCanvas.isPointerJustRelease)
      this.setTextBox();
    if (this.indexDau == -1 || (long) (Environment.TickCount / 100) - this.timeDau <= 5L)
      return;
    this.indexDau = -1;
  }

  public void setTextBox()
  {
    if (GameCanvas.isPointerHoldIn(this.x + this.width - 20, this.y, 40, this.height))
    {
      this.clearAllText();
      this.isFocus = true;
    }
    else if (GameCanvas.isPointerHoldIn(this.x, this.y, this.width - 20, this.height))
      this.setFocusWithKb(true);
    else
      this.setFocus(false);
  }

  public void setFocus(bool isFocus)
  {
    if (this.isFocus != isFocus)
      TField.mode = 0;
    TField.lastKey = -1984;
    TField.timeChangeMode = (long) (int) (DateTime.Now.Ticks / 1000L);
    this.isFocus = isFocus;
    if (!isFocus)
      return;
    TField.currentTField = this;
    if (TField.kb == null)
      return;
    TField.kb.text = TField.currentTField.text;
  }

  public void setFocusWithKb(bool isFocus)
  {
    if (this.isFocus != isFocus)
      TField.mode = 0;
    TField.lastKey = -1984;
    TField.timeChangeMode = (long) (int) (DateTime.Now.Ticks / 1000L);
    this.isFocus = isFocus;
    if (isFocus)
      TField.currentTField = this;
    else if (TField.currentTField == this)
      TField.currentTField = (TField) null;
    if (!(Thread.CurrentThread.Name == Main.mainThreadName) || TField.currentTField == null)
      return;
    isFocus = true;
    TouchScreenKeyboard.hideInput = !TField.currentTField.showSubTextField;
    TouchScreenKeyboardType t = TouchScreenKeyboardType.ASCIICapable;
    if (this.inputType == TField.INPUT_TYPE_NUMERIC)
      t = TouchScreenKeyboardType.NumberPad;
    bool type = false;
    if (this.inputType == TField.INPUT_TYPE_PASSWORD)
      type = true;
    TField.kb = TouchScreenKeyboard.Open(TField.currentTField.text, t, false, false, type, false, TField.currentTField.name);
    if (TField.kb != null)
      TField.kb.text = TField.currentTField.text;
    Cout.LogWarning("SHOW KEYBOARD FOR " + TField.currentTField.text);
  }

  public string getText() => this.text;

  public void clearKb()
  {
    if (TField.kb == null)
      return;
    TField.kb.text = string.Empty;
  }

  public void setText(string text)
  {
    if (text == null)
      return;
    TField.lastKey = -1984;
    this.keyInActiveState = 0;
    this.indexOfActiveChar = 0;
    this.text = text;
    this.paintedText = text;
    if (text == string.Empty)
      TouchScreenKeyboard.Clear();
    this.setPasswordTest();
    this.caretPos = text.Length;
    this.setOffset();
  }

  public void insertText(string text)
  {
    this.text = this.text.Substring(0, this.caretPos) + text + this.text.Substring(this.caretPos);
    this.setPasswordTest();
    this.caretPos += text.Length;
    this.setOffset();
  }

  public int getMaxTextLenght() => this.maxTextLenght;

  public void setMaxTextLenght(int maxTextLenght) => this.maxTextLenght = maxTextLenght;

  public int getIputType() => this.inputType;

  public void setIputType(int iputType)
  {
    this.inputType = iputType;
    this.setMaxTextLenght(500);
  }

  public void perform(int idAction, object p)
  {
    if (idAction != 1000)
      return;
    this.clear();
  }
}
