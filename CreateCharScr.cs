// Decompiled with JetBrains decompiler
// Type: CreateCharScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class CreateCharScr : mScreen, IActionListener
{
  public static CreateCharScr instance;
  private PopUp p;
  public static bool isCreateChar = false;
  public static TField tAddName;
  public static int indexGender;
  public static int indexHair;
  public static int selected;
  public static int[][] hairID = new int[3][]
  {
    new int[3]{ 64, 30, 31 },
    new int[3]{ 9, 29, 32 },
    new int[3]{ 6, 27, 28 }
  };
  public static int[] defaultLeg = new int[3]{ 2, 13, 8 };
  public static int[] defaultBody = new int[3]{ 1, 12, 7 };
  private int yButton;
  private int disY;
  private int[] bgID = new int[3]{ 0, 4, 8 };
  public int yBegin;
  private int curIndex;
  private int cx = 168;
  private int cy = 350;
  private int dy = 45;
  private int cp1;
  private int cf;

  public CreateCharScr()
  {
    try
    {
      if (!GameCanvas.lowGraphic)
        CreateCharScr.loadMapFromResource(new sbyte[3]
        {
          (sbyte) 39,
          (sbyte) 40,
          (sbyte) 41
        });
      this.loadMapTableFromResource(new sbyte[3]
      {
        (sbyte) 39,
        (sbyte) 40,
        (sbyte) 41
      });
    }
    catch (Exception ex)
    {
      Cout.LogError("Tao char loi " + ex.ToString());
    }
    if (GameCanvas.w <= 200)
    {
      GameScr.setPopupSize(128, 100);
      GameScr.popupX = (GameCanvas.w - 128) / 2;
      GameScr.popupY = 10;
      this.cy += 15;
      this.dy -= 15;
    }
    CreateCharScr.indexGender = 1;
    CreateCharScr.tAddName = new TField();
    CreateCharScr.tAddName.width = GameCanvas.loginScr.tfUser.width;
    if (GameCanvas.w < 200)
      CreateCharScr.tAddName.width = 60;
    CreateCharScr.tAddName.height = mScreen.ITEM_HEIGHT + 2;
    if (GameCanvas.w < 200)
    {
      CreateCharScr.tAddName.x = GameScr.popupX + 45;
      CreateCharScr.tAddName.y = GameScr.popupY + 12;
    }
    else
    {
      CreateCharScr.tAddName.x = GameCanvas.w / 2 - CreateCharScr.tAddName.width / 2;
      CreateCharScr.tAddName.y = 35;
    }
    if (!GameCanvas.isTouch)
      CreateCharScr.tAddName.isFocus = true;
    CreateCharScr.tAddName.setIputType(TField.INPUT_TYPE_ANY);
    CreateCharScr.tAddName.showSubTextField = false;
    CreateCharScr.tAddName.strInfo = mResources.char_name;
    if (CreateCharScr.tAddName.getText().Equals("@"))
      CreateCharScr.tAddName.setText(GameCanvas.loginScr.tfUser.getText().Substring(0, GameCanvas.loginScr.tfUser.getText().IndexOf("@")));
    CreateCharScr.tAddName.name = mResources.char_name;
    CreateCharScr.indexGender = 1;
    CreateCharScr.indexHair = 0;
    this.center = new Command(mResources.NEWCHAR, (IActionListener) this, 8000, (object) null);
    this.left = new Command(mResources.BACK, (IActionListener) this, 8001, (object) null);
    if (!GameCanvas.isTouch)
      this.right = CreateCharScr.tAddName.cmdClear;
    this.yBegin = CreateCharScr.tAddName.y;
  }

  public static CreateCharScr gI()
  {
    if (CreateCharScr.instance == null)
      CreateCharScr.instance = new CreateCharScr();
    return CreateCharScr.instance;
  }

  public static void init()
  {
  }

  public static void loadMapFromResource(sbyte[] mapID)
  {
    Res.outz("newwwwwwwwww =============");
    for (int index1 = 0; index1 < mapID.Length; ++index1)
    {
      DataInputStream dataInputStream = MyStream.readFile("/mymap/" + (object) mapID[index1]);
      MapTemplate.tmw[index1] = (int) (ushort) dataInputStream.read();
      MapTemplate.tmh[index1] = (int) (ushort) dataInputStream.read();
      Cout.LogError("Thong TIn : " + (object) MapTemplate.tmw[index1] + "::" + (object) MapTemplate.tmh[index1]);
      MapTemplate.maps[index1] = new int[dataInputStream.available()];
      Cout.LogError("lent= " + (object) MapTemplate.maps[index1].Length);
      for (int index2 = 0; index2 < MapTemplate.tmw[index1] * MapTemplate.tmh[index1]; ++index2)
        MapTemplate.maps[index1][index2] = dataInputStream.read();
      MapTemplate.types[index1] = new int[MapTemplate.maps[index1].Length];
    }
  }

  public void loadMapTableFromResource(sbyte[] mapID)
  {
    if (GameCanvas.lowGraphic)
      return;
    try
    {
      for (int index1 = 0; index1 < mapID.Length; ++index1)
      {
        DataInputStream dataInputStream = MyStream.readFile("/mymap/mapTable" + (object) mapID[index1]);
        Cout.LogError("mapTable : " + (object) mapID[index1]);
        short num1 = dataInputStream.readShort();
        MapTemplate.vCurrItem[index1] = new MyVector();
        Res.outz("nItem= " + (object) num1);
        for (int index2 = 0; index2 < (int) num1; ++index2)
        {
          short id = dataInputStream.readShort();
          short num2 = dataInputStream.readShort();
          short num3 = dataInputStream.readShort();
          if (TileMap.getBIById((int) id) != null)
          {
            BgItem biById = TileMap.getBIById((int) id);
            BgItem o = new BgItem();
            o.id = (int) id;
            o.idImage = biById.idImage;
            o.dx = biById.dx;
            o.dy = biById.dy;
            o.x = (int) num2 * (int) TileMap.size;
            o.y = (int) num3 * (int) TileMap.size;
            o.layer = biById.layer;
            MapTemplate.vCurrItem[index1].addElement((object) o);
            if (!BgItem.imgNew.containsKey((object) (o.idImage.ToString() + string.Empty)))
            {
              try
              {
                Image v = GameCanvas.loadImage("/mapBackGround/" + (object) o.idImage + ".png");
                if (v == null)
                {
                  BgItem.imgNew.put((object) (o.idImage.ToString() + string.Empty), (object) Image.createRGBImage(new int[1], 1, 1, true));
                  Service.gI().getBgTemplate(o.idImage);
                }
                else
                  BgItem.imgNew.put((object) (o.idImage.ToString() + string.Empty), (object) v);
              }
              catch (Exception ex)
              {
                Image v = GameCanvas.loadImage("/mapBackGround/" + (object) o.idImage + ".png");
                if (v == null)
                {
                  v = Image.createRGBImage(new int[1], 1, 1, true);
                  Service.gI().getBgTemplate(o.idImage);
                }
                BgItem.imgNew.put((object) (o.idImage.ToString() + string.Empty), (object) v);
              }
              BgItem.vKeysLast.addElement((object) (o.idImage.ToString() + string.Empty));
            }
            if (!BgItem.isExistKeyNews(o.idImage.ToString() + string.Empty))
              BgItem.vKeysNew.addElement((object) (o.idImage.ToString() + string.Empty));
            o.changeColor();
          }
          else
            Res.outz("item null");
        }
      }
    }
    catch (Exception ex)
    {
      Cout.println("LOI TAI loadMapTableFromResource" + ex.ToString());
    }
  }

  public override void switchToMe()
  {
    LoginScr.isContinueToLogin = false;
    GameCanvas.menu.showMenu = false;
    GameCanvas.endDlg();
    base.switchToMe();
    CreateCharScr.indexGender = Res.random(0, 3);
    CreateCharScr.indexHair = Res.random(0, 3);
    this.doChangeMap();
    Char.isLoadingMap = false;
    CreateCharScr.tAddName.setFocusWithKb(true);
  }

  public void doChangeMap()
  {
    TileMap.maps = new int[MapTemplate.maps[CreateCharScr.indexGender].Length];
    for (int index = 0; index < MapTemplate.maps[CreateCharScr.indexGender].Length; ++index)
      TileMap.maps[index] = MapTemplate.maps[CreateCharScr.indexGender][index];
    TileMap.types = MapTemplate.types[CreateCharScr.indexGender];
    TileMap.pxh = MapTemplate.pxh[CreateCharScr.indexGender];
    TileMap.pxw = MapTemplate.pxw[CreateCharScr.indexGender];
    TileMap.tileID = MapTemplate.pxw[CreateCharScr.indexGender];
    TileMap.tmw = MapTemplate.tmw[CreateCharScr.indexGender];
    TileMap.tmh = MapTemplate.tmh[CreateCharScr.indexGender];
    TileMap.tileID = this.bgID[CreateCharScr.indexGender] + 1;
    TileMap.loadMainTile();
    TileMap.loadTileCreatChar();
    GameCanvas.loadBG(this.bgID[CreateCharScr.indexGender]);
    GameScr.loadCamera(false, this.cx, this.cy);
  }

  public override void keyPress(int keyCode) => CreateCharScr.tAddName.keyPressed(keyCode);

  public override void update()
  {
    ++this.cp1;
    if (this.cp1 > 30)
      this.cp1 = 0;
    this.cf = this.cp1 % 15 >= 5 ? 1 : 0;
    CreateCharScr.tAddName.update();
    if (CreateCharScr.selected == 0)
      return;
    CreateCharScr.tAddName.isFocus = false;
  }

  public override void updateKey()
  {
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21])
    {
      --CreateCharScr.selected;
      if (CreateCharScr.selected < 0)
        CreateCharScr.selected = mResources.MENUNEWCHAR.Length - 1;
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22])
    {
      ++CreateCharScr.selected;
      if (CreateCharScr.selected >= mResources.MENUNEWCHAR.Length)
        CreateCharScr.selected = 0;
    }
    if (CreateCharScr.selected == 0)
    {
      if (!GameCanvas.isTouch)
        this.right = CreateCharScr.tAddName.cmdClear;
      CreateCharScr.tAddName.update();
    }
    if (CreateCharScr.selected == 1)
    {
      if (GameCanvas.keyPressed[!Main.isPC ? 4 : 23])
      {
        --CreateCharScr.indexGender;
        if (CreateCharScr.indexGender < 0)
          CreateCharScr.indexGender = mResources.MENUGENDER.Length - 1;
        this.doChangeMap();
      }
      if (GameCanvas.keyPressed[!Main.isPC ? 6 : 24])
      {
        ++CreateCharScr.indexGender;
        if (CreateCharScr.indexGender > mResources.MENUGENDER.Length - 1)
          CreateCharScr.indexGender = 0;
        this.doChangeMap();
      }
      this.right = (Command) null;
    }
    if (CreateCharScr.selected == 2)
    {
      if (GameCanvas.keyPressed[!Main.isPC ? 4 : 23])
      {
        --CreateCharScr.indexHair;
        if (CreateCharScr.indexHair < 0)
          CreateCharScr.indexHair = mResources.hairStyleName[0].Length - 1;
      }
      if (GameCanvas.keyPressed[!Main.isPC ? 6 : 24])
      {
        ++CreateCharScr.indexHair;
        if (CreateCharScr.indexHair > mResources.hairStyleName[0].Length - 1)
          CreateCharScr.indexHair = 0;
      }
      this.right = (Command) null;
    }
    if (GameCanvas.isPointerJustRelease)
    {
      int num1 = 110;
      int num2 = 60;
      int num3 = 78;
      if (GameCanvas.w > GameCanvas.h)
      {
        num1 = 100;
        num2 = 40;
      }
      if (GameCanvas.isPointerHoldIn(GameCanvas.w / 2 - 3 * num3 / 2, 15, num3 * 3, 80))
      {
        CreateCharScr.selected = 0;
        CreateCharScr.tAddName.isFocus = true;
      }
      if (GameCanvas.isPointerHoldIn(GameCanvas.w / 2 - 3 * num3 / 2, num1 - 30, num3 * 3, num2 + 5))
      {
        CreateCharScr.selected = 1;
        int indexGender = CreateCharScr.indexGender;
        CreateCharScr.indexGender = (GameCanvas.px - (GameCanvas.w / 2 - 3 * num3 / 2)) / num3;
        if (CreateCharScr.indexGender < 0)
          CreateCharScr.indexGender = 0;
        if (CreateCharScr.indexGender > mResources.MENUGENDER.Length - 1)
          CreateCharScr.indexGender = mResources.MENUGENDER.Length - 1;
        if (indexGender != CreateCharScr.indexGender)
          this.doChangeMap();
      }
      if (GameCanvas.isPointerHoldIn(GameCanvas.w / 2 - 3 * num3 / 2, num1 - 30 + num2 + 5, num3 * 3, 65))
      {
        CreateCharScr.selected = 2;
        int indexHair = CreateCharScr.indexHair;
        CreateCharScr.indexHair = (GameCanvas.px - (GameCanvas.w / 2 - 3 * num3 / 2)) / num3;
        if (CreateCharScr.indexHair < 0)
          CreateCharScr.indexHair = 0;
        if (CreateCharScr.indexHair > mResources.hairStyleName[0].Length - 1)
          CreateCharScr.indexHair = mResources.hairStyleName[0].Length - 1;
        if (indexHair != CreateCharScr.selected)
          this.doChangeMap();
      }
    }
    if (!TouchScreenKeyboard.visible)
      base.updateKey();
    GameCanvas.clearKeyHold();
    GameCanvas.clearKeyPressed();
  }

  public override void paint(mGraphics g)
  {
    if (Char.isLoadingMap)
      return;
    GameCanvas.paintBGGameScr(g);
    g.translate(-GameScr.cmx, -GameScr.cmy);
    if (!GameCanvas.lowGraphic)
    {
      for (int index = 0; index < MapTemplate.vCurrItem[CreateCharScr.indexGender].size(); ++index)
      {
        BgItem bgItem = (BgItem) MapTemplate.vCurrItem[CreateCharScr.indexGender].elementAt(index);
        if (bgItem.idImage != (short) -1 && bgItem.layer == (sbyte) 1)
          bgItem.paint(g);
      }
    }
    TileMap.paintTilemap(g);
    int num1 = 30;
    if (GameCanvas.w == 128)
      num1 = 20;
    int index1 = CreateCharScr.hairID[CreateCharScr.indexGender][CreateCharScr.indexHair];
    int index2 = CreateCharScr.defaultLeg[CreateCharScr.indexGender];
    int index3 = CreateCharScr.defaultBody[CreateCharScr.indexGender];
    g.drawImage(TileMap.bong, this.cx, this.cy + this.dy, 3);
    Part part1 = GameScr.parts[index1];
    Part part2 = GameScr.parts[index2];
    Part part3 = GameScr.parts[index3];
    SmallImage.drawSmallImage(g, (int) part1.pi[Char.CharInfo[this.cf][0][0]].id, this.cx + Char.CharInfo[this.cf][0][1] + (int) part1.pi[Char.CharInfo[this.cf][0][0]].dx, this.cy - Char.CharInfo[this.cf][0][2] + (int) part1.pi[Char.CharInfo[this.cf][0][0]].dy + this.dy, 0, 0);
    SmallImage.drawSmallImage(g, (int) part2.pi[Char.CharInfo[this.cf][1][0]].id, this.cx + Char.CharInfo[this.cf][1][1] + (int) part2.pi[Char.CharInfo[this.cf][1][0]].dx, this.cy - Char.CharInfo[this.cf][1][2] + (int) part2.pi[Char.CharInfo[this.cf][1][0]].dy + this.dy, 0, 0);
    SmallImage.drawSmallImage(g, (int) part3.pi[Char.CharInfo[this.cf][2][0]].id, this.cx + Char.CharInfo[this.cf][2][1] + (int) part3.pi[Char.CharInfo[this.cf][2][0]].dx, this.cy - Char.CharInfo[this.cf][2][2] + (int) part3.pi[Char.CharInfo[this.cf][2][0]].dy + this.dy, 0, 0);
    if (!GameCanvas.lowGraphic)
    {
      for (int index4 = 0; index4 < MapTemplate.vCurrItem[CreateCharScr.indexGender].size(); ++index4)
      {
        BgItem bgItem = (BgItem) MapTemplate.vCurrItem[CreateCharScr.indexGender].elementAt(index4);
        if (bgItem.idImage != (short) -1 && bgItem.layer == (sbyte) 3)
          bgItem.paint(g);
      }
    }
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    if (GameCanvas.w < 200)
    {
      GameCanvas.paintz.paintFrame(GameScr.popupX, GameScr.popupY, GameScr.popupW, GameScr.popupH, g);
      SmallImage.drawSmallImage(g, (int) part1.pi[Char.CharInfo[0][0][0]].id, GameCanvas.w / 2 + Char.CharInfo[0][0][1] + (int) part1.pi[Char.CharInfo[0][0][0]].dx, GameScr.popupY + 30 + 3 * num1 - Char.CharInfo[0][0][2] + (int) part1.pi[Char.CharInfo[0][0][0]].dy + this.dy, 0, 0);
      SmallImage.drawSmallImage(g, (int) part2.pi[Char.CharInfo[0][1][0]].id, GameCanvas.w / 2 + Char.CharInfo[0][1][1] + (int) part2.pi[Char.CharInfo[0][1][0]].dx, GameScr.popupY + 30 + 3 * num1 - Char.CharInfo[0][1][2] + (int) part2.pi[Char.CharInfo[0][1][0]].dy + this.dy, 0, 0);
      SmallImage.drawSmallImage(g, (int) part3.pi[Char.CharInfo[0][2][0]].id, GameCanvas.w / 2 + Char.CharInfo[0][2][1] + (int) part3.pi[Char.CharInfo[0][2][0]].dx, GameScr.popupY + 30 + 3 * num1 - Char.CharInfo[0][2][2] + (int) part3.pi[Char.CharInfo[0][2][0]].dy + this.dy, 0, 0);
      for (int index5 = 0; index5 < mResources.MENUNEWCHAR.Length; ++index5)
      {
        if (CreateCharScr.selected == index5)
        {
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 2, GameScr.popupX + 10 + (GameCanvas.gameTick % 7 <= 3 ? 0 : 1), GameScr.popupY + 35 + index5 * num1, StaticObj.VCENTER_HCENTER);
          g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 0, GameScr.popupX + GameScr.popupW - 10 - (GameCanvas.gameTick % 7 <= 3 ? 0 : 1), GameScr.popupY + 35 + index5 * num1, StaticObj.VCENTER_HCENTER);
        }
        mFont.tahoma_7b_dark.drawString(g, mResources.MENUNEWCHAR[index5], GameScr.popupX + 20, GameScr.popupY + 30 + index5 * num1, 0);
      }
      mFont.tahoma_7b_dark.drawString(g, mResources.MENUGENDER[CreateCharScr.indexGender], GameScr.popupX + 70, GameScr.popupY + 30 + num1, mFont.LEFT);
      mFont.tahoma_7b_dark.drawString(g, mResources.hairStyleName[CreateCharScr.indexGender][CreateCharScr.indexHair], GameScr.popupX + 55, GameScr.popupY + 30 + 2 * num1, mFont.LEFT);
      CreateCharScr.tAddName.paint(g);
    }
    else
    {
      if (!Main.isPC)
      {
        if (mGraphics.addYWhenOpenKeyBoard != 0)
        {
          this.yButton = 110;
          this.disY = 60;
          if (GameCanvas.w > GameCanvas.h)
          {
            this.yButton = GameScr.popupY + 30 + 3 * num1 + (int) part3.pi[Char.CharInfo[0][2][0]].dy + this.dy - 15;
            this.disY = 35;
          }
        }
        else
        {
          this.yButton = 110;
          this.disY = 60;
          if (GameCanvas.w > GameCanvas.h)
          {
            this.yButton = 100;
            this.disY = 45;
          }
        }
        CreateCharScr.tAddName.y = this.yButton - CreateCharScr.tAddName.height - this.disY + 5;
      }
      else
      {
        this.yButton = 110;
        this.disY = 60;
        if (GameCanvas.w > GameCanvas.h)
        {
          this.yButton = 100;
          this.disY = 45;
        }
        CreateCharScr.tAddName.y = this.yBegin;
      }
      for (int index6 = 0; index6 < 3; ++index6)
      {
        int num2 = 78;
        if (index6 != CreateCharScr.indexGender)
        {
          g.drawImage(GameScr.imgLbtn, GameCanvas.w / 2 - num2 + index6 * num2, this.yButton, 3);
        }
        else
        {
          if (CreateCharScr.selected == 1)
            g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 4, GameCanvas.w / 2 - num2 + index6 * num2, this.yButton - 20 + (GameCanvas.gameTick % 7 <= 3 ? 0 : 1), StaticObj.VCENTER_HCENTER);
          g.drawImage(GameScr.imgLbtnFocus, GameCanvas.w / 2 - num2 + index6 * num2, this.yButton, 3);
        }
        mFont.tahoma_7b_dark.drawString(g, mResources.MENUGENDER[index6], GameCanvas.w / 2 - num2 + index6 * num2, this.yButton - 5, mFont.CENTER);
      }
      for (int index7 = 0; index7 < 3; ++index7)
      {
        int num3 = 78;
        if (index7 != CreateCharScr.indexHair)
        {
          g.drawImage(GameScr.imgLbtn, GameCanvas.w / 2 - num3 + index7 * num3, this.yButton + this.disY, 3);
        }
        else
        {
          if (CreateCharScr.selected == 2)
            g.drawRegion(GameScr.arrow, 0, 0, 13, 16, 4, GameCanvas.w / 2 - num3 + index7 * num3, this.yButton + this.disY - 20 + (GameCanvas.gameTick % 7 <= 3 ? 0 : 1), StaticObj.VCENTER_HCENTER);
          g.drawImage(GameScr.imgLbtnFocus, GameCanvas.w / 2 - num3 + index7 * num3, this.yButton + this.disY, 3);
        }
        mFont.tahoma_7b_dark.drawString(g, mResources.hairStyleName[CreateCharScr.indexGender][index7], GameCanvas.w / 2 - num3 + index7 * num3, this.yButton + this.disY - 5, mFont.CENTER);
      }
      CreateCharScr.tAddName.paint(g);
    }
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    mFont.tahoma_7b_white.drawString(g, mResources.server + " " + LoginScr.serverName, 5, 5, 0, mFont.tahoma_7b_dark);
    if (TouchScreenKeyboard.visible)
      return;
    base.paint(g);
  }

  public void perform(int idAction, object p)
  {
    switch (idAction)
    {
      case 8000:
        if (CreateCharScr.tAddName.getText().Equals(string.Empty))
        {
          GameCanvas.startOKDlg(mResources.char_name_blank);
          break;
        }
        if (CreateCharScr.tAddName.getText().Length < 5)
        {
          GameCanvas.startOKDlg(mResources.char_name_short);
          break;
        }
        if (CreateCharScr.tAddName.getText().Length > 15)
        {
          GameCanvas.startOKDlg(mResources.char_name_long);
          break;
        }
        InfoDlg.showWait();
        Service.gI().createChar(CreateCharScr.tAddName.getText(), CreateCharScr.indexGender, CreateCharScr.hairID[CreateCharScr.indexGender][CreateCharScr.indexHair]);
        break;
      case 8001:
        if (GameCanvas.loginScr.isLogin2)
        {
          GameCanvas.startYesNoDlg(mResources.note, new Command(mResources.YES, (IActionListener) this, 10019, (object) null), new Command(mResources.NO, (IActionListener) this, 10020, (object) null));
          break;
        }
        if (Main.isWindowsPhone)
          GameMidlet.isBackWindowsPhone = true;
        Session_ME.gI().close();
        GameCanvas.serverScreen.switchToMe();
        break;
      case 10019:
        Session_ME.gI().close();
        GameCanvas.endDlg();
        GameCanvas.serverScreen.switchToMe();
        break;
      case 10020:
        GameCanvas.endDlg();
        break;
    }
  }
}
