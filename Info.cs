// Decompiled with JetBrains decompiler
// Type: Info
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Info : IActionListener
{
  public MyVector infoWaitToShow = new MyVector();
  public InfoItem info;
  public int p1 = 5;
  public int p2;
  public int p3;
  public int x;
  public int strWidth;
  public int limLeft = 2;
  public int hI = 20;
  public int xChar;
  public int yChar;
  public int sayWidth = 100;
  public int sayRun;
  public string[] says;
  public int cx;
  public int cy;
  public int ch;
  public bool outSide;
  public int f;
  public int tF;
  public Image img;
  public static Image gocnhon = GameCanvas.loadImage("/mainImage/myTexture2dgocnhon.png");
  public int time;
  public int timeW;
  public int type;
  public int X;
  public int Y;
  public int W;
  public int H;

  public void hide()
  {
    this.says = (string[]) null;
    this.infoWaitToShow.removeAllElements();
  }

  public void paint(mGraphics g, int x, int y, int dir)
  {
    if (this.infoWaitToShow.size() == 0)
      return;
    g.translate(x, y);
    if (this.says != null && this.says.Length != 0 && this.type != 1)
    {
      if (this.outSide)
      {
        this.cx -= GameScr.cmx;
        this.cy -= GameScr.cmy;
        this.cy += 35;
      }
      int num1 = mGraphics.zoomLevel != 1 ? 10 : 0;
      if (this.info.charInfo == null)
        PopUp.paintPopUp(g, this.X, this.Y, this.W, this.H, 16777215, false);
      else
        mSystem.paintPopUp2(g, this.X - 23, this.Y - num1 / 2, this.W + 15, this.H + (!GameCanvas.isTouch ? 14 : 0) + num1);
      if (this.info.charInfo == null)
        g.drawRegion(Info.gocnhon, 0, 0, 9, 8, dir != 1 ? 2 : 0, this.cx - 3 + (dir != 1 ? 20 : -15), this.cy - this.ch - 20 + this.sayRun + 2, mGraphics.TOP | mGraphics.HCENTER);
      int num2 = -1;
      for (int index1 = 0; index1 < this.says.Length; ++index1)
      {
        mFont mFont = mFont.tahoma_7;
        int num3 = 2;
        string say = this.says[index1];
        int num4;
        if (this.says[index1].StartsWith("|"))
        {
          string[] strArray = Res.split(this.says[index1], "|", 0);
          if (strArray.Length == 3)
            say = strArray[2];
          if (strArray.Length == 4)
          {
            say = strArray[3];
            num3 = int.Parse(strArray[2]);
          }
          num4 = int.Parse(strArray[1]);
          num2 = num4;
        }
        else
          num4 = num2;
        switch (num4 + 1)
        {
          case 0:
            mFont = mFont.tahoma_7;
            break;
          case 1:
            mFont = mFont.tahoma_7b_dark;
            break;
          case 2:
            mFont = mFont.tahoma_7b_green;
            break;
          case 3:
            mFont = mFont.tahoma_7b_blue;
            break;
          case 4:
            mFont = mFont.tahoma_7_red;
            break;
          case 5:
            mFont = mFont.tahoma_7_green;
            break;
          case 6:
            mFont = mFont.tahoma_7_blue;
            break;
          case 8:
            mFont = mFont.tahoma_7b_red;
            break;
        }
        if (this.info.charInfo == null)
        {
          mFont.drawString(g, say, this.cx, this.cy - this.ch - 15 + this.sayRun + index1 * 12 - this.says.Length * 12 - 9, 2);
        }
        else
        {
          int x1 = this.X - 23;
          int num5 = this.Y - num1 / 2;
          int w1 = mSystem.clientType != 1 ? this.W + 25 : this.W + 28;
          int num6 = this.H + (!GameCanvas.isTouch ? 14 : 0) + num1;
          g.setColor(4465169);
          g.fillRect(x1, num5 + num6, w1, 2);
          int w2 = this.info.timeCount * w1 / this.info.maxTime;
          if (w2 < 0)
            w2 = 0;
          g.setColor(43758);
          g.fillRect(x1, num5 + num6, w2, 2);
          if (this.info.timeCount == 0)
            return;
          this.info.charInfo.paintHead(g, this.X + 5, this.Y + this.H / 2, 0);
          if (mGraphics.zoomLevel == 1)
            (!this.info.isChatServer ? mFont.tahoma_7b_greenSmall : mFont.tahoma_7b_yellowSmall2).drawString(g, this.info.charInfo.cName, this.X + 12, this.Y + 3, 0);
          else
            (!this.info.isChatServer ? mFont.tahoma_7b_greenSmall : mFont.tahoma_7b_yellowSmall2).drawString(g, this.info.charInfo.cName, this.X + 12, this.Y - 3, 0);
          if (!GameCanvas.isTouch)
          {
            if (!TField.isQwerty)
              mFont.tahoma_7b_green2Small.drawString(g, "Nhấn # để chat", this.X + this.W / 2 + 10, this.Y + this.H, mFont.CENTER);
            else
              mFont.tahoma_7b_green2Small.drawString(g, "Nhấn Y để chat", this.X + this.W / 2 + 10, this.Y + this.H, mFont.CENTER);
          }
          if (mGraphics.zoomLevel == 1)
          {
            TextInfo.paint(g, say, this.X + 14, this.Y + this.H / 2 + 2, this.W - 16, this.H, mFont.tahoma_7_whiteSmall);
          }
          else
          {
            string[] strArray = mFont.tahoma_7_whiteSmall.splitFontArray(say, 120);
            for (int index2 = 0; index2 < strArray.Length; ++index2)
              mFont.tahoma_7_whiteSmall.drawString(g, strArray[index2], this.X + 12, this.Y + 12 + index2 * 12 - 3, 0);
            GameCanvas.resetTrans(g);
          }
        }
      }
      if (this.info.charInfo == null)
        ;
    }
    g.translate(-x, -y);
  }

  public void update()
  {
    if (this.infoWaitToShow.size() == 0 || this.info.timeCount != 0)
      return;
    ++this.time;
    if (this.time < this.info.speed)
      return;
    this.time = 0;
    this.infoWaitToShow.removeElementAt(0);
    if (this.infoWaitToShow.size() == 0)
      return;
    this.info = (InfoItem) this.infoWaitToShow.firstElement();
    this.getInfo();
  }

  public void getInfo()
  {
    this.sayWidth = 100;
    if (GameCanvas.w == 128)
      this.sayWidth = 128;
    int num;
    if (this.info.charInfo != null)
    {
      this.says = new string[1]{ this.info.s };
      num = mGraphics.zoomLevel != 1 ? mFont.tahoma_7_whiteSmall.splitFontArray(this.info.s, 120).Length : this.says.Length;
    }
    else
    {
      this.says = mFont.tahoma_7.splitFontArray(this.info.s, this.sayWidth - 10);
      num = this.says.Length;
    }
    this.sayRun = 7;
    this.X = this.cx - this.sayWidth / 2 - 1;
    this.Y = this.cy - this.ch - 15 + this.sayRun - num * 12 - 15;
    this.W = this.sayWidth + 2 + (this.info.charInfo == null ? 0 : 30);
    this.H = (num + 1) * 12 + 1 + (this.info.charInfo == null ? 0 : 5);
  }

  public void addInfo(string s, int Type, Char cInfo, bool isChatServer)
  {
    this.type = Type;
    if (GameCanvas.w == 128)
      this.limLeft = 1;
    if (this.infoWaitToShow.size() > 10)
      this.infoWaitToShow.removeElementAt(0);
    if (this.infoWaitToShow.size() > 0 && s.Equals(((InfoItem) this.infoWaitToShow.lastElement()).s))
    {
      Res.outz("return");
    }
    else
    {
      InfoItem infoItem = new InfoItem(s);
      if (this.type == 0)
        infoItem.speed = s.Length;
      if (infoItem.speed < 70)
        infoItem.speed = 70;
      if (this.type == 1)
        infoItem.speed = 10000000;
      if (this.type == 3)
      {
        infoItem.speed = 300;
        infoItem.last = mSystem.currentTimeMillis();
        infoItem.timeCount = s.Length * 10 / 4;
        if (infoItem.timeCount < 150)
          infoItem.timeCount = 150;
        infoItem.maxTime = infoItem.timeCount;
      }
      if (cInfo != null)
      {
        infoItem.charInfo = cInfo;
        infoItem.isChatServer = isChatServer;
        GameCanvas.panel.addChatMessage(infoItem);
        if (GameCanvas.isTouch && GameCanvas.panel.isViewChatServer)
          GameScr.info2.cmdChat = new Command(mResources.CHAT, (IActionListener) this, 1000, (object) infoItem);
      }
      if (cInfo != null && GameCanvas.panel.isViewChatServer || cInfo == null)
        this.infoWaitToShow.addElement((object) infoItem);
      if (this.infoWaitToShow.size() == 1)
      {
        this.info = (InfoItem) this.infoWaitToShow.firstElement();
        this.getInfo();
      }
      if (!GameCanvas.isTouch || cInfo == null || !GameCanvas.panel.isViewChatServer || GameCanvas.w - 50 <= 155 + this.W)
        return;
      GameScr.info2.cmdChat.x = GameCanvas.w - this.W - 50;
      GameScr.info2.cmdChat.y = 35;
    }
  }

  public void addInfo(string s, int speed, mFont f)
  {
    if (GameCanvas.w == 128)
      this.limLeft = 1;
    if (this.infoWaitToShow.size() > 10)
      this.infoWaitToShow.removeElementAt(0);
    this.infoWaitToShow.addElement((object) new InfoItem(s, f, speed));
  }

  public bool isEmpty() => this.p1 == 5 && this.infoWaitToShow.size() == 0;

  public void perform(int idAction, object p)
  {
    if (idAction != 1000)
      return;
    ChatTextField.gI().startChat((IChatable) GameScr.gI(), mResources.chat_player);
  }

  public void onCancelChat()
  {
  }
}
