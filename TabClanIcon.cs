// Decompiled with JetBrains decompiler
// Type: TabClanIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class TabClanIcon : IActionListener
{
  private int x;
  private int y;
  private int w;
  private int h;
  private Command left;
  private Command right;
  private Command center;
  private int WIDTH = 24;
  public int nItem;
  private int disStart = 50;
  public static Scroll scrMain;
  public int cmtoX;
  public int cmx;
  public int cmvx;
  public int cmdx;
  public bool isShow;
  public bool isGetName;
  public string text;
  private bool isRequest;
  private bool isUpdate;
  public MyVector vItems = new MyVector();
  private int msgID;
  private int select;
  private int lastSelect;
  private ScrollResult sr;

  public TabClanIcon()
  {
    this.left = new Command(mResources.SELECT, (IActionListener) this, 1, (object) null);
    this.right = new Command(mResources.CLOSE, (IActionListener) this, 2, (object) null);
  }

  public void init()
  {
    if (this.isGetName)
    {
      this.w = 170;
      this.h = 118;
      this.x = GameCanvas.w / 2 - this.w / 2;
      this.y = GameCanvas.h / 2 - this.h / 2;
    }
    else
    {
      this.w = 170;
      this.h = 170;
      this.x = GameCanvas.w / 2 - this.w / 2;
      this.y = GameCanvas.h / 2 - this.h / 2;
      if (GameCanvas.h < 240)
        this.y -= 10;
    }
    this.cmx = this.x;
    this.cmtoX = 0;
    this.nItem = this.isRequest ? this.vItems.size() : ClanImage.vClanImage.size();
    if (GameCanvas.isTouch)
    {
      this.left.x = this.x;
      this.left.y = this.y + this.h + 5;
      this.right.x = this.x + this.w - 68;
      this.right.y = this.y + this.h + 5;
    }
    TabClanIcon.scrMain = new Scroll();
    TabClanIcon.scrMain.setStyle(this.nItem, this.WIDTH, this.x, this.y + this.disStart, this.w, this.h - this.disStart, true, 1);
  }

  public void show(bool isGetName)
  {
    if (Char.myCharz().clan != null)
      this.isUpdate = true;
    this.isShow = true;
    this.isGetName = isGetName;
    this.init();
  }

  public void showRequest(int msgID)
  {
    this.isShow = true;
    this.isRequest = true;
    this.msgID = msgID;
    this.init();
  }

  public void hide()
  {
    this.cmtoX = this.x + this.w;
    SmallImage.clearHastable();
  }

  public void paintPeans(mGraphics g)
  {
  }

  public void paintIcon(mGraphics g)
  {
    g.translate(-this.cmx, 0);
    PopUp.paintPopUp(g, this.x, this.y - 17, this.w, this.h + 17, -1, true);
    mFont.tahoma_7b_dark.drawString(g, mResources.select_clan_icon, this.x + this.w / 2, this.y - 7, 2);
    if (this.lastSelect >= 0 && this.lastSelect <= ClanImage.vClanImage.size() - 1)
    {
      ClanImage clanImage = (ClanImage) ClanImage.vClanImage.elementAt(this.lastSelect);
      if (clanImage.idImage != null)
        Char.myCharz().paintBag(g, clanImage.idImage, GameCanvas.w / 2, this.y + 45, 1, false);
    }
    Char.myCharz().paintCharBody(g, GameCanvas.w / 2, this.y + 45, 1, Char.myCharz().cf, false);
    g.setClip(this.x, this.y + this.disStart, this.w, this.h - this.disStart - 10);
    if (TabClanIcon.scrMain != null)
      g.translate(0, -TabClanIcon.scrMain.cmy);
    for (int index = 0; index < this.nItem; ++index)
    {
      int x = this.x + 10;
      int y = this.y + index * this.WIDTH + this.disStart;
      if (y + this.WIDTH - (TabClanIcon.scrMain == null ? 0 : TabClanIcon.scrMain.cmy) >= this.y + this.disStart && y - (TabClanIcon.scrMain == null ? 0 : TabClanIcon.scrMain.cmy) <= this.y + this.disStart + this.h)
      {
        ClanImage clanImage = (ClanImage) ClanImage.vClanImage.elementAt(index);
        mFont mFont = mFont.tahoma_7_grey;
        if (index == this.lastSelect)
          mFont = mFont.tahoma_7_blue;
        if (clanImage.name != null)
          mFont.drawString(g, clanImage.name, x + 20, y, 0);
        if (clanImage.xu > 0)
          mFont.drawString(g, clanImage.xu.ToString() + " " + mResources.XU, x + this.w - 20, y, mFont.RIGHT);
        else if (clanImage.luong > 0)
          mFont.drawString(g, clanImage.luong.ToString() + " " + mResources.LUONG, x + this.w - 20, y, mFont.RIGHT);
        if (clanImage.idImage != null)
          SmallImage.drawSmallImage(g, (int) clanImage.idImage[0], x, y, 0, 0);
      }
    }
    g.translate(0, -g.getTranslateY());
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
  }

  public void paint(mGraphics g)
  {
    if (!this.isRequest)
      this.paintIcon(g);
    else
      this.paintPeans(g);
  }

  public void update()
  {
    if (TabClanIcon.scrMain != null)
      TabClanIcon.scrMain.updatecm();
    if (this.cmx != this.cmtoX)
    {
      this.cmvx = this.cmtoX - this.cmx << 2;
      this.cmdx += this.cmvx;
      this.cmx += this.cmdx >> 3;
      this.cmdx &= 15;
    }
    if (Math.abs(this.cmtoX - this.cmx) < 10)
      this.cmx = this.cmtoX;
    if (this.cmx < this.x + this.w - 10 || this.cmtoX < this.x + this.w - 10)
      return;
    this.isShow = false;
  }

  public void updateKey()
  {
    if (this.left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(this.left)))
      this.left.performAction();
    if (this.right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.right)))
      this.right.performAction();
    if (this.center != null && (GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(this.center)))
      this.center.performAction();
    if (!this.isGetName)
    {
      if (TabClanIcon.scrMain == null)
        return;
      if (GameCanvas.isTouch)
      {
        TabClanIcon.scrMain.updateKey();
        this.select = TabClanIcon.scrMain.selectedItem;
      }
      if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21])
      {
        GameCanvas.keyPressed[!Main.isPC ? 2 : 21] = false;
        --this.select;
        if (this.select < 0)
          this.select = this.nItem - 1;
        TabClanIcon.scrMain.moveTo(this.select * TabClanIcon.scrMain.ITEM_SIZE);
      }
      if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22])
      {
        GameCanvas.keyPressed[!Main.isPC ? 8 : 22] = false;
        ++this.select;
        if (this.select > this.nItem - 1)
          this.select = 0;
        TabClanIcon.scrMain.moveTo(this.select * TabClanIcon.scrMain.ITEM_SIZE);
      }
      if (this.select != -1)
        this.lastSelect = this.select;
    }
    GameCanvas.clearKeyHold();
    GameCanvas.clearKeyPressed();
  }

  public void perform(int idAction, object p)
  {
    if (idAction == 2)
      this.hide();
    if (idAction != 1 || this.isGetName)
      return;
    if (!this.isRequest)
    {
      if (this.lastSelect < 0)
        return;
      this.hide();
      if (Char.myCharz().clan == null)
        Service.gI().getClan((sbyte) 2, (sbyte) ((ClanImage) ClanImage.vClanImage.elementAt(this.lastSelect)).ID, this.text);
      else
        Service.gI().getClan((sbyte) 4, (sbyte) ((ClanImage) ClanImage.vClanImage.elementAt(this.lastSelect)).ID, string.Empty);
    }
    else
    {
      if (this.lastSelect < 0)
        return;
      Item obj = (Item) this.vItems.elementAt(this.select);
    }
  }
}
