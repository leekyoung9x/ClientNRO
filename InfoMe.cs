// Decompiled with JetBrains decompiler
// Type: InfoMe
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class InfoMe
{
  public static InfoMe me;
  public int[][] charId = new int[3][];
  public Info info = new Info();
  public int dir;
  public int f;
  public int tF;
  public int cmtoY;
  public int cmy;
  public int cmdy;
  public int cmvy;
  public int cmyLim;
  public int cmtoX;
  public int cmx;
  public int cmdx;
  public int cmvx;
  public int cmxLim;
  public bool isDone;
  public bool isUpdate = true;
  public int timeDelay;
  public int playerID;
  public int timeCount;
  public Command cmdChat;
  public bool isShow;

  public InfoMe()
  {
    for (int index = 0; index < this.charId.Length; ++index)
      this.charId[index] = new int[3];
  }

  public static InfoMe gI()
  {
    if (InfoMe.me == null)
      InfoMe.me = new InfoMe();
    return InfoMe.me;
  }

  public void loadCharId()
  {
    for (int index = 0; index < this.charId.Length; ++index)
      this.charId[index] = new int[3];
  }

  public void paint(mGraphics g)
  {
    if (this.Equals((object) GameScr.info2) && GameScr.gI().isVS() || this.Equals((object) GameScr.info2) && GameScr.gI().popUpYesNo != null || !GameScr.isPaint || GameCanvas.currentScreen != GameScr.gI() && GameCanvas.currentScreen != CrackBallScr.gI() || ChatPopup.serverChatPopUp != null || !this.isUpdate || Char.ischangingMap || GameCanvas.panel.isShow && this.Equals((object) GameScr.info2))
      return;
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    if (this.info != null)
    {
      this.info.paint(g, this.cmx, this.cmy, this.dir);
      if (this.info.info == null || this.info.info.charInfo == null || this.cmdChat != null || GameCanvas.isTouch)
        ;
      if (this.info.info == null || this.info.info.charInfo == null || this.cmdChat == null)
        ;
    }
    if (this.info.info != null && this.info.info.charInfo == null && this.charId != null)
      SmallImage.drawSmallImage(g, this.charId[Char.myCharz().cgender][this.f], this.cmx, this.cmy + 3 + (GameCanvas.gameTick % 10 <= 5 ? 0 : 1), this.dir != 1 ? 2 : 0, StaticObj.VCENTER_HCENTER);
    g.translate(-g.getTranslateX(), -g.getTranslateY());
  }

  public void hide() => this.info.hide();

  public void moveCamera()
  {
    if (this.cmy != this.cmtoY)
    {
      this.cmvy = this.cmtoY - this.cmy << 2;
      this.cmdy += this.cmvy;
      this.cmy += this.cmdy >> 4;
      this.cmdy &= 15;
    }
    if (this.cmx != this.cmtoX)
    {
      this.cmvx = this.cmtoX - this.cmx << 2;
      this.cmdx += this.cmvx;
      this.cmx += this.cmdx >> 4;
      this.cmdx &= 15;
    }
    ++this.tF;
    if (this.tF != 5)
      return;
    this.tF = 0;
    if (this.f == 0)
      this.f = 1;
    else
      this.f = 0;
  }

  public void doClick(int t) => this.timeDelay = t;

  public void update()
  {
    if (this.info != null && this.info.infoWaitToShow != null && this.info.infoWaitToShow.size() == 0 && this.cmy != -40)
    {
      --this.info.timeW;
      if (this.info.timeW <= 0)
      {
        this.cmy = -40;
        this.info.time = 0;
        this.info.infoWaitToShow.removeAllElements();
        this.info.says = (string[]) null;
        this.info.timeW = 200;
      }
    }
    if (this.Equals((object) GameScr.info2) && GameScr.gI().popUpYesNo != null || !this.isUpdate)
      return;
    this.moveCamera();
    if (this.info == null || this.info != null && this.info.info == null)
      return;
    if (!this.isDone)
    {
      if (this.timeDelay > 0)
      {
        --this.timeDelay;
        if (this.timeDelay == 0)
        {
          GameCanvas.panel.setTypeMessage();
          GameCanvas.panel.show();
        }
      }
      if (GameCanvas.gameTick % 3 == 0)
      {
        if (Char.myCharz().cdir == 1)
          this.cmtoX = Char.myCharz().cx - 20 - GameScr.cmx;
        if (Char.myCharz().cdir == -1)
          this.cmtoX = Char.myCharz().cx + 20 - GameScr.cmx;
        if (this.cmtoX <= 24)
          this.cmtoX += this.info.sayWidth / 2;
        if (this.cmtoX >= GameCanvas.w - 24)
          this.cmtoX -= this.info.sayWidth / 2;
        this.cmtoY = Char.myCharz().cy - 40 - GameScr.cmy;
        if (this.info.says != null && this.cmtoY < (this.info.says.Length + 1) * 12 + 10)
          this.cmtoY = (this.info.says.Length + 1) * 12 + 10;
        if (this.info.info.charInfo != null)
        {
          if (GameCanvas.w - 50 > 155 + this.info.W)
          {
            this.cmtoX = GameCanvas.w - 60 - this.info.W / 2;
            this.cmtoY = this.info.H + 10;
          }
          else
          {
            this.cmtoX = GameCanvas.w - 20 - this.info.W / 2;
            this.cmtoY = 45 + this.info.H;
            if (GameCanvas.w > GameCanvas.h || GameCanvas.w < 220)
            {
              this.cmtoX = GameCanvas.w - 20 - this.info.W / 2;
              this.cmtoY = this.info.H + 10;
            }
          }
        }
      }
      this.dir = this.cmx <= Char.myCharz().cx - GameScr.cmx ? 1 : -1;
    }
    if (this.info.info == null)
      return;
    if (this.info.infoWaitToShow.size() > 1)
    {
      if (this.info.info.timeCount == 0)
      {
        ++this.info.time;
        if (this.info.time < this.info.info.speed)
          return;
        this.info.time = 0;
        this.info.infoWaitToShow.removeElementAt(0);
        this.info.info = (InfoItem) this.info.infoWaitToShow.firstElement();
        this.info.getInfo();
      }
      else
      {
        this.info.info.curr = mSystem.currentTimeMillis();
        if (this.info.info.curr - this.info.info.last >= 100L)
        {
          this.info.info.last = mSystem.currentTimeMillis();
          --this.info.info.timeCount;
        }
        if (this.info.info.timeCount != 0)
          return;
        this.info.infoWaitToShow.removeElementAt(0);
        if (this.info.infoWaitToShow.size() == 0)
          return;
        this.info.info = (InfoItem) this.info.infoWaitToShow.firstElement();
        this.info.getInfo();
      }
    }
    else
    {
      if (this.info.infoWaitToShow.size() != 1)
        return;
      if (this.info.info.timeCount == 0)
      {
        ++this.info.time;
        if (this.info.time >= this.info.info.speed)
          this.isDone = true;
        if (this.info.time == this.info.info.speed)
        {
          this.cmtoY = -40;
          this.cmtoX = Char.myCharz().cx - GameScr.cmx + (Char.myCharz().cdir != 1 ? 20 : -20);
        }
        if (this.info.time < this.info.info.speed + 20)
          return;
        this.info.time = 0;
        this.info.infoWaitToShow.removeAllElements();
        this.info.says = (string[]) null;
        this.info.timeW = 200;
      }
      else
      {
        this.info.info.curr = mSystem.currentTimeMillis();
        if (this.info.info.curr - this.info.info.last >= 100L)
        {
          this.info.info.last = mSystem.currentTimeMillis();
          --this.info.info.timeCount;
        }
        if (this.info.info.timeCount != 0)
          return;
        this.isDone = true;
        this.cmtoY = -40;
        this.cmtoX = Char.myCharz().cx - GameScr.cmx + (Char.myCharz().cdir != 1 ? 20 : -20);
        this.info.time = 0;
        this.info.infoWaitToShow.removeAllElements();
        this.info.says = (string[]) null;
        this.cmdChat = (Command) null;
      }
    }
  }

  public void addInfoWithChar(string s, Char c, bool isChatServer)
  {
    this.playerID = c.charID;
    this.info.addInfo(s, 3, c, isChatServer);
    this.isDone = false;
  }

  public void addInfo(string s, int Type)
  {
    s = Res.changeString(s);
    if (this.info.infoWaitToShow.size() > 0 && s.Equals(((InfoItem) this.info.infoWaitToShow.lastElement()).s))
      return;
    if (this.info.infoWaitToShow.size() > 10)
    {
      for (int index = 0; index < 5; ++index)
        this.info.infoWaitToShow.removeElementAt(0);
    }
    Char cInfo = (Char) null;
    this.info.addInfo(s, Type, cInfo, false);
    if (this.info.infoWaitToShow.size() == 1)
    {
      this.cmy = 0;
      this.cmx = Char.myCharz().cx - GameScr.cmx + (Char.myCharz().cdir != 1 ? 20 : -20);
    }
    this.isDone = false;
  }
}
