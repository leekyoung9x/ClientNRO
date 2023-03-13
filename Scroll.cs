// Decompiled with JetBrains decompiler
// Type: Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Scroll
{
  public int cmtoX;
  public int cmtoY;
  public int cmx;
  public int cmy;
  public int cmvx;
  public int cmvy;
  public int cmdx;
  public int cmdy;
  public int xPos;
  public int yPos;
  public int width;
  public int height;
  public int cmxLim;
  public int cmyLim;
  public static Scroll gI;
  private int pointerDownTime;
  private int pointerDownFirstX;
  private int[] pointerDownLastX = new int[3];
  public bool pointerIsDowning;
  public bool isDownWhenRunning;
  private int cmRun;
  public int selectedItem;
  public int ITEM_SIZE;
  public int nITEM;
  public int ITEM_PER_LINE;
  public bool styleUPDOWN = true;

  public void clear()
  {
    this.cmtoX = 0;
    this.cmtoY = 0;
    this.cmx = 0;
    this.cmy = 0;
    this.cmvx = 0;
    this.cmvy = 0;
    this.cmdx = 0;
    this.cmdy = 0;
    this.cmxLim = 0;
    this.cmyLim = 0;
    this.width = 0;
    this.height = 0;
  }

  public ScrollResult updateKey() => this.styleUPDOWN ? this.updateKeyScrollUpDown(false) : this.updateKeyScrollLeftRight();

  public ScrollResult updateKey(bool isGetSelectNow) => this.styleUPDOWN ? this.updateKeyScrollUpDown(isGetSelectNow) : this.updateKeyScrollLeftRight();

  private ScrollResult updateKeyScrollUpDown(bool isGetNow)
  {
    int xPos = this.xPos;
    int yPos = this.yPos;
    int width = this.width;
    int height = this.height;
    if (GameCanvas.isPointerDown)
    {
      if (!this.pointerIsDowning && GameCanvas.isPointer(xPos, yPos, width, height))
      {
        for (int index = 0; index < this.pointerDownLastX.Length; ++index)
          this.pointerDownLastX[0] = GameCanvas.py;
        this.pointerDownFirstX = GameCanvas.py;
        this.pointerIsDowning = true;
        if (!isGetNow)
          this.selectedItem = -1;
        this.isDownWhenRunning = this.cmRun != 0;
        this.cmRun = 0;
      }
      else if (this.pointerIsDowning)
      {
        ++this.pointerDownTime;
        if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning)
        {
          this.pointerDownFirstX = -1000;
          this.selectedItem = this.ITEM_PER_LINE <= 1 ? (this.cmtoY + GameCanvas.py - yPos) / this.ITEM_SIZE : (this.cmtoY + GameCanvas.py - yPos) / this.ITEM_SIZE * this.ITEM_PER_LINE + (this.cmtoX + GameCanvas.px - xPos) / this.ITEM_SIZE;
        }
        int num = GameCanvas.py - this.pointerDownLastX[0];
        if (!isGetNow)
        {
          if (num != 0 && this.selectedItem != -1)
            this.selectedItem = -1;
        }
        else
          this.selectedItem = (this.cmtoY + GameCanvas.py - yPos) / this.ITEM_SIZE;
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
      }
    }
    bool flag = false;
    if (GameCanvas.isPointerJustRelease && this.pointerIsDowning)
    {
      int i = GameCanvas.py - this.pointerDownLastX[0];
      GameCanvas.isPointerJustRelease = false;
      if (Res.abs(i) < 20 && Res.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
      {
        this.cmRun = 0;
        this.cmtoY = this.cmy;
        this.pointerDownFirstX = -1000;
        this.selectedItem = this.ITEM_PER_LINE <= 1 ? (this.cmtoY + GameCanvas.py - yPos) / this.ITEM_SIZE : (this.cmtoY + GameCanvas.py - yPos) / this.ITEM_SIZE * this.ITEM_PER_LINE + (this.cmtoX + GameCanvas.px - xPos) / this.ITEM_SIZE;
        this.pointerDownTime = 0;
        flag = true;
      }
      else if (this.selectedItem != -1 && this.pointerDownTime > 5)
      {
        this.pointerDownTime = 0;
        flag = true;
      }
      else if (this.selectedItem == -1 && !this.isDownWhenRunning || isGetNow && this.selectedItem != -1 && !this.isDownWhenRunning)
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
    return new ScrollResult()
    {
      selected = this.selectedItem,
      isFinish = flag,
      isDowning = this.pointerIsDowning
    };
  }

  private ScrollResult updateKeyScrollLeftRight()
  {
    int xPos = this.xPos;
    int yPos = this.yPos;
    int width = this.width;
    int height = this.height;
    if (GameCanvas.isPointerDown)
    {
      if (!this.pointerIsDowning && GameCanvas.isPointer(xPos, yPos, width, height))
      {
        for (int index = 0; index < this.pointerDownLastX.Length; ++index)
          this.pointerDownLastX[0] = GameCanvas.px;
        this.pointerDownFirstX = GameCanvas.px;
        this.pointerIsDowning = true;
        this.selectedItem = -1;
        this.isDownWhenRunning = this.cmRun != 0;
        this.cmRun = 0;
      }
      else if (this.pointerIsDowning)
      {
        ++this.pointerDownTime;
        if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.px && !this.isDownWhenRunning)
        {
          this.pointerDownFirstX = -1000;
          this.selectedItem = (this.cmtoX + GameCanvas.px - xPos) / this.ITEM_SIZE;
        }
        int num = GameCanvas.px - this.pointerDownLastX[0];
        if (num != 0 && this.selectedItem != -1)
          this.selectedItem = -1;
        for (int index = this.pointerDownLastX.Length - 1; index > 0; --index)
          this.pointerDownLastX[index] = this.pointerDownLastX[index - 1];
        this.pointerDownLastX[0] = GameCanvas.px;
        this.cmtoX -= num;
        if (this.cmtoX < 0)
          this.cmtoX = 0;
        if (this.cmtoX > this.cmxLim)
          this.cmtoX = this.cmxLim;
        if (this.cmx < 0 || this.cmx > this.cmxLim)
          num /= 2;
        this.cmx -= num;
      }
    }
    bool flag = false;
    if (GameCanvas.isPointerJustRelease && this.pointerIsDowning)
    {
      int i = GameCanvas.px - this.pointerDownLastX[0];
      GameCanvas.isPointerJustRelease = false;
      if (Res.abs(i) < 20 && Res.abs(GameCanvas.px - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
      {
        this.cmRun = 0;
        this.cmtoX = this.cmx;
        this.pointerDownFirstX = -1000;
        this.selectedItem = (this.cmtoX + GameCanvas.px - xPos) / this.ITEM_SIZE;
        this.pointerDownTime = 0;
        flag = true;
      }
      else if (this.selectedItem != -1 && this.pointerDownTime > 5)
      {
        this.pointerDownTime = 0;
        flag = true;
      }
      else if (this.selectedItem == -1 && !this.isDownWhenRunning)
      {
        if (this.cmx < 0)
          this.cmtoX = 0;
        else if (this.cmx > this.cmxLim)
        {
          this.cmtoX = this.cmxLim;
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
    return new ScrollResult()
    {
      selected = this.selectedItem,
      isFinish = flag,
      isDowning = this.pointerIsDowning
    };
  }

  public void updatecm()
  {
    if (this.cmRun != 0 && !this.pointerIsDowning)
    {
      if (this.styleUPDOWN)
      {
        this.cmtoY += this.cmRun / 100;
        if (this.cmtoY < 0)
          this.cmtoY = 0;
        else if (this.cmtoY > this.cmyLim)
          this.cmtoY = this.cmyLim;
        else
          this.cmy = this.cmtoY;
      }
      else
      {
        this.cmtoX += this.cmRun / 100;
        if (this.cmtoX < 0)
          this.cmtoX = 0;
        else if (this.cmtoX > this.cmxLim)
          this.cmtoX = this.cmxLim;
        else
          this.cmx = this.cmtoX;
      }
      this.cmRun = this.cmRun * 9 / 10;
      if (this.cmRun < 100 && this.cmRun > -100)
        this.cmRun = 0;
    }
    if (this.cmx != this.cmtoX && !this.pointerIsDowning)
    {
      this.cmvx = this.cmtoX - this.cmx << 2;
      this.cmdx += this.cmvx;
      this.cmx += this.cmdx >> 4;
      this.cmdx &= 15;
    }
    if (this.cmy == this.cmtoY || this.pointerIsDowning)
      return;
    this.cmvy = this.cmtoY - this.cmy << 2;
    this.cmdy += this.cmvy;
    this.cmy += this.cmdy >> 4;
    this.cmdy &= 15;
  }

  public void setStyle(
    int nItem,
    int ITEM_SIZE,
    int xPos,
    int yPos,
    int width,
    int height,
    bool styleUPDOWN,
    int ITEM_PER_LINE)
  {
    this.xPos = xPos;
    this.yPos = yPos;
    this.ITEM_SIZE = ITEM_SIZE;
    this.nITEM = nItem;
    this.width = width;
    this.height = height;
    this.styleUPDOWN = styleUPDOWN;
    this.ITEM_PER_LINE = ITEM_PER_LINE;
    Res.outz("nItem= " + (object) nItem + " ITEMSIZE= " + (object) ITEM_SIZE + " heghit= " + (object) height);
    if (styleUPDOWN)
    {
      int num = nItem / ITEM_PER_LINE;
      if (nItem % ITEM_PER_LINE != 0)
        ++num;
      this.cmyLim = num * ITEM_SIZE - height;
    }
    else
      this.cmxLim = ITEM_PER_LINE * ITEM_SIZE - width;
    if (this.cmyLim < 0)
      this.cmyLim = 0;
    if (this.cmxLim >= 0)
      return;
    this.cmxLim = 0;
  }

  public void moveTo(int to)
  {
    if (this.styleUPDOWN)
    {
      to -= (this.height - this.ITEM_SIZE) / 2;
      this.cmtoY = to;
      if (this.cmtoY < 0)
        this.cmtoY = 0;
      if (this.cmtoY <= this.cmyLim)
        return;
      this.cmtoY = this.cmyLim;
    }
    else
    {
      to -= (this.width - this.ITEM_SIZE) / 2;
      this.cmtoX = to;
      if (this.cmtoX < 0)
        this.cmtoX = 0;
      if (this.cmtoX <= this.cmxLim)
        return;
      this.cmtoX = this.cmxLim;
    }
  }

  public static Scroll gIz()
  {
    if (Scroll.gI == null)
      Scroll.gI = new Scroll();
    return Scroll.gI;
  }
}
