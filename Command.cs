// Decompiled with JetBrains decompiler
// Type: Command
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Command
{
  public ActionChat actionChat;
  public string caption;
  public string[] subCaption;
  public IActionListener actionListener;
  public int idAction;
  public bool isPlaySoundButton = true;
  public Image img;
  public Image imgFocus;
  public int x;
  public int y;
  public int w = mScreen.cmdW;
  public int h = mScreen.cmdH;
  public int hw;
  private int lenCaption;
  public bool isFocus;
  public object p;
  public int type;
  public string caption2 = string.Empty;
  public static Image btn0left;
  public static Image btn0mid;
  public static Image btn0right;
  public static Image btn1left;
  public static Image btn1mid;
  public static Image btn1right;
  public bool cmdClosePanel;

  public Command(
    string caption,
    IActionListener actionListener,
    int action,
    object p,
    int x,
    int y)
  {
    this.caption = caption;
    this.idAction = action;
    this.actionListener = actionListener;
    this.p = p;
    this.x = x;
    this.y = y;
  }

  public Command()
  {
  }

  public Command(string caption, IActionListener actionListener, int action, object p)
  {
    this.caption = caption;
    this.idAction = action;
    this.actionListener = actionListener;
    this.p = p;
  }

  public Command(string caption, int action, object p)
  {
    this.caption = caption;
    this.idAction = action;
    this.p = p;
  }

  public Command(string caption, int action)
  {
    this.caption = caption;
    this.idAction = action;
  }

  public Command(string caption, int action, int x, int y)
  {
    this.caption = caption;
    this.idAction = action;
    this.x = x;
    this.y = y;
  }

  public void perform(string str)
  {
    if (this.actionChat == null)
      return;
    this.actionChat(str);
  }

  public void performAction()
  {
    GameCanvas.clearAllPointerEvent();
    if (this.isPlaySoundButton && (this.caption != null && !this.caption.Equals(string.Empty) && !this.caption.Equals(mResources.saying) || this.img != null))
      SoundMn.gI().buttonClick();
    if (this.idAction <= 0)
      return;
    if (this.actionListener != null)
      this.actionListener.perform(this.idAction, this.p);
    else
      GameScr.gI().actionPerform(this.idAction, this.p);
  }

  public void setType()
  {
    this.type = 1;
    this.w = 160;
    this.hw = 80;
  }

  public void paint(mGraphics g)
  {
    if (this.img != null)
    {
      g.drawImage(this.img, this.x, this.y + mGraphics.addYWhenOpenKeyBoard, 0);
      if (this.isFocus)
      {
        if (this.imgFocus == null)
        {
          if (this.cmdClosePanel)
            g.drawImage(ItemMap.imageFlare, this.x + 8, this.y + mGraphics.addYWhenOpenKeyBoard + 8, 3);
          else
            g.drawImage(ItemMap.imageFlare, this.x - (!this.img.Equals((object) GameScr.imgMenu) ? 0 : 10), this.y + mGraphics.addYWhenOpenKeyBoard, 0);
        }
        else
          g.drawImage(this.imgFocus, this.x, this.y + mGraphics.addYWhenOpenKeyBoard, 0);
      }
      if (!(this.caption != "menu") || this.caption == null)
        return;
      if (!this.isFocus)
        mFont.tahoma_7b_dark.drawString(g, this.caption, this.x + mGraphics.getImageWidth(this.img) / 2, this.y + mGraphics.getImageHeight(this.img) / 2 - 5, 2);
      else
        mFont.tahoma_7b_green2.drawString(g, this.caption, this.x + mGraphics.getImageWidth(this.img) / 2, this.y + mGraphics.getImageHeight(this.img) / 2 - 5, 2);
    }
    else
    {
      if (this.caption != string.Empty)
      {
        if (this.type == 1)
        {
          if (!this.isFocus)
            Command.paintOngMau(Command.btn0left, Command.btn0mid, Command.btn0right, this.x, this.y, 160, g);
          else
            Command.paintOngMau(Command.btn1left, Command.btn1mid, Command.btn1right, this.x, this.y, 160, g);
        }
        else if (!this.isFocus)
          Command.paintOngMau(Command.btn0left, Command.btn0mid, Command.btn0right, this.x, this.y, 76, g);
        else
          Command.paintOngMau(Command.btn1left, Command.btn1mid, Command.btn1right, this.x, this.y, 76, g);
      }
      int x = this.type != 1 ? this.x + 38 : this.x + this.hw;
      if (!this.isFocus)
        mFont.tahoma_7b_dark.drawString(g, this.caption, x, this.y + 7, 2);
      else
        mFont.tahoma_7b_green2.drawString(g, this.caption, x, this.y + 7, 2);
    }
  }

  public static void paintOngMau(
    Image img0,
    Image img1,
    Image img2,
    int x,
    int y,
    int size,
    mGraphics g)
  {
    for (int index = 10; index <= size - 20; index += 10)
      g.drawImage(img1, x + index, y, 0);
    int w0 = size % 10;
    if (w0 > 0)
      g.drawRegion(img1, 0, 0, w0, 24, 0, x + size - 10 - w0, y, 0);
    g.drawImage(img0, x, y, 0);
    g.drawImage(img2, x + size - 10, y, 0);
  }

  public bool isPointerPressInside()
  {
    this.isFocus = false;
    if (GameCanvas.isPointerHoldIn(this.x, this.y, this.w, this.h))
    {
      if (GameCanvas.isPointerDown)
        this.isFocus = true;
      if (GameCanvas.isPointerJustRelease && GameCanvas.isPointerClick)
        return true;
    }
    return false;
  }

  public bool isPointerPressInsideCamera(int cmx, int cmy)
  {
    this.isFocus = false;
    if (GameCanvas.isPointerHoldIn(this.x - cmx, this.y - cmy, this.w, this.h))
    {
      Res.outz("w= " + (object) this.w);
      if (GameCanvas.isPointerDown)
        this.isFocus = true;
      if (GameCanvas.isPointerJustRelease && GameCanvas.isPointerClick)
        return true;
    }
    return false;
  }
}
