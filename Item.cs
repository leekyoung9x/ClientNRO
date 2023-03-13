// Decompiled with JetBrains decompiler
// Type: Item
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Item
{
  public const int OPT_STAR = 34;
  public const int OPT_MOON = 35;
  public const int OPT_SUN = 36;
  public const int OPT_COLORNAME = 41;
  public const int OPT_LVITEM = 72;
  public const int OPT_STARSLOT = 102;
  public const int OPT_MAXSTARSLOT = 107;
  public const int TYPE_BODY_MIN = 0;
  public const int TYPE_BODY_MAX = 6;
  public const int TYPE_AO = 0;
  public const int TYPE_QUAN = 1;
  public const int TYPE_GANGTAY = 2;
  public const int TYPE_GIAY = 3;
  public const int TYPE_RADA = 4;
  public const int TYPE_HAIR = 5;
  public const int TYPE_DAUTHAN = 6;
  public const int TYPE_NGOCRONG = 12;
  public const int TYPE_SACH = 7;
  public const int TYPE_NHIEMVU = 8;
  public const int TYPE_GOLD = 9;
  public const int TYPE_DIAMOND = 10;
  public const int TYPE_BALO = 11;
  public const int TYPE_MOUNT = 23;
  public const int TYPE_MOUNT_VIP = 24;
  public const int TYPE_DIAMOND_LOCK = 34;
  public const int TYPE_TRAINSUIT = 32;
  public const int TYPE_HAT = 35;
  public const sbyte UI_WEAPON = 2;
  public const sbyte UI_BAG = 3;
  public const sbyte UI_BOX = 4;
  public const sbyte UI_BODY = 5;
  public const sbyte UI_STACK = 6;
  public const sbyte UI_STACK_LOCK = 7;
  public const sbyte UI_GROCERY = 8;
  public const sbyte UI_GROCERY_LOCK = 9;
  public const sbyte UI_UPGRADE = 10;
  public const sbyte UI_UPPEARL = 11;
  public const sbyte UI_UPPEARL_LOCK = 12;
  public const sbyte UI_SPLIT = 13;
  public const sbyte UI_STORE = 14;
  public const sbyte UI_BOOK = 15;
  public const sbyte UI_LIEN = 16;
  public const sbyte UI_NHAN = 17;
  public const sbyte UI_NGOCBOI = 18;
  public const sbyte UI_PHU = 19;
  public const sbyte UI_NONNAM = 20;
  public const sbyte UI_NONNU = 21;
  public const sbyte UI_AONAM = 22;
  public const sbyte UI_AONU = 23;
  public const sbyte UI_GANGTAYNAM = 24;
  public const sbyte UI_GANGTAYNU = 25;
  public const sbyte UI_QUANNAM = 26;
  public const sbyte UI_QUANNU = 27;
  public const sbyte UI_GIAYNAM = 28;
  public const sbyte UI_GIAYNU = 29;
  public const sbyte UI_TRADE = 30;
  public const sbyte UI_UPGRADE_GOLD = 31;
  public const sbyte UI_FASHION = 32;
  public const sbyte UI_CONVERT = 33;
  public ItemOption[] itemOption;
  public ItemTemplate template;
  public MyVector options;
  public int itemId;
  public int playerId;
  public bool isSelect;
  public int indexUI;
  public int quantity;
  public int quantilyToBuy;
  public long powerRequire;
  public bool isLock;
  public int sys;
  public int upgrade;
  public int buyCoin;
  public int buyCoinLock;
  public int buyGold;
  public int buyGoldLock;
  public int saleCoinLock;
  public int buySpec;
  public int buyRuby;
  public short iconSpec = -1;
  public sbyte buyType = -1;
  public int typeUI;
  public bool isExpires;
  public bool isBuySpec;
  public EffectCharPaint eff;
  public int indexEff;
  public Image img;
  public string info;
  public string content;
  public string reason = string.Empty;
  public int compare;
  public sbyte isMe;
  public bool newItem;
  public int headTemp = -1;
  public int bodyTemp = -1;
  public int legTemp = -1;
  public int bagTemp = -1;
  public int wpTemp = -1;
  private int[] color = new int[18]
  {
    0,
    0,
    0,
    0,
    600841,
    600841,
    667658,
    667658,
    3346944,
    3346688,
    4199680,
    5052928,
    3276851,
    3932211,
    4587571,
    5046280,
    6684682,
    3359744
  };
  private int[][] colorBorder = new int[5][]
  {
    new int[6]{ 18687, 16869, 15052, 13235, 11161, 9344 },
    new int[6]{ 45824, 39168, 32768, 26112, 19712, 13056 },
    new int[6]
    {
      16744192,
      15037184,
      13395456,
      11753728,
      10046464,
      8404992
    },
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
      16711705,
      15007767,
      13369364,
      11730962,
      10027023,
      8388621
    }
  };
  private int[] size = new int[6]{ 2, 1, 1, 1, 1, 1 };

  public void getCompare() => this.compare = GameCanvas.panel.getCompare(this);

  public string getPrice()
  {
    string price = string.Empty;
    if (this.buyCoin <= 0 && this.buyGold <= 0)
      return (string) null;
    if (this.buyCoin > 0 && this.buyGold <= 0)
      price = this.buyCoin.ToString() + mResources.XU;
    else if (this.buyGold > 0 && this.buyCoin <= 0)
      price = this.buyGold.ToString() + mResources.LUONG;
    else if (this.buyCoin > 0 && this.buyGold > 0)
      price = this.buyCoin.ToString() + mResources.XU + "/" + (object) this.buyGold + mResources.LUONG;
    return price;
  }

  public void paintUpgradeEffect(int x, int y, int upgrade, mGraphics g)
  {
    int num1 = GameScr.indexSize - 2;
    int num2 = 0;
    int index1 = upgrade >= 4 ? (upgrade >= 8 ? (upgrade >= 12 ? (upgrade > 14 ? 4 : 3) : 2) : 1) : 0;
    for (int index2 = num2; index2 < this.size.Length; ++index2)
    {
      int num3 = x - num1 / 2 + this.upgradeEffectX(GameCanvas.gameTick - index2 * 4);
      int num4 = y - num1 / 2 + this.upgradeEffectY(GameCanvas.gameTick - index2 * 4);
      g.setColor(this.colorBorder[index1][index2]);
      g.fillRect(num3 - this.size[index2] / 2, num4 - this.size[index2] / 2, this.size[index2], this.size[index2]);
    }
    if (upgrade == 4 || upgrade == 8)
    {
      for (int index3 = num2; index3 < this.size.Length; ++index3)
      {
        int num5 = x - num1 / 2 + this.upgradeEffectX(GameCanvas.gameTick - num1 * 2 - index3 * 4);
        int num6 = y - num1 / 2 + this.upgradeEffectY(GameCanvas.gameTick - num1 * 2 - index3 * 4);
        g.setColor(this.colorBorder[index1 - 1][index3]);
        g.fillRect(num5 - this.size[index3] / 2, num6 - this.size[index3] / 2, this.size[index3], this.size[index3]);
      }
    }
    if (upgrade != 1 && upgrade != 4 && upgrade != 8)
    {
      for (int index4 = num2; index4 < this.size.Length; ++index4)
      {
        int num7 = x - num1 / 2 + this.upgradeEffectX(GameCanvas.gameTick - num1 * 2 - index4 * 4);
        int num8 = y - num1 / 2 + this.upgradeEffectY(GameCanvas.gameTick - num1 * 2 - index4 * 4);
        g.setColor(this.colorBorder[index1][index4]);
        g.fillRect(num7 - this.size[index4] / 2, num8 - this.size[index4] / 2, this.size[index4], this.size[index4]);
      }
    }
    if (upgrade != 1 && upgrade != 4 && upgrade != 8 && upgrade != 12 && upgrade != 2 && upgrade != 5 && upgrade != 9)
    {
      for (int index5 = num2; index5 < this.size.Length; ++index5)
      {
        int num9 = x - num1 / 2 + this.upgradeEffectX(GameCanvas.gameTick - num1 - index5 * 4);
        int num10 = y - num1 / 2 + this.upgradeEffectY(GameCanvas.gameTick - num1 - index5 * 4);
        g.setColor(this.colorBorder[index1][index5]);
        g.fillRect(num9 - this.size[index5] / 2, num10 - this.size[index5] / 2, this.size[index5], this.size[index5]);
      }
    }
    if (upgrade == 1 || upgrade == 4 || upgrade == 8 || upgrade == 12 || upgrade == 2 || upgrade == 5 || upgrade == 9 || upgrade == 13 || upgrade == 3 || upgrade == 6 || upgrade == 10 || upgrade == 15)
      return;
    for (int index6 = num2; index6 < this.size.Length; ++index6)
    {
      int num11 = x - num1 / 2 + this.upgradeEffectX(GameCanvas.gameTick - num1 * 3 - index6 * 4);
      int num12 = y - num1 / 2 + this.upgradeEffectY(GameCanvas.gameTick - num1 * 3 - index6 * 4);
      g.setColor(this.colorBorder[index1][index6]);
      g.fillRect(num11 - this.size[index6] / 2, num12 - this.size[index6] / 2, this.size[index6], this.size[index6]);
    }
  }

  private int upgradeEffectY(int tick)
  {
    int num1 = GameScr.indexSize - 2;
    int num2 = tick % (4 * num1);
    if (0 <= num2 && num2 < num1)
      return 0;
    if (num1 <= num2 && num2 < num1 * 2)
      return num2 % num1;
    return num1 * 2 <= num2 && num2 < num1 * 3 ? num1 : num1 - num2 % num1;
  }

  private int upgradeEffectX(int tick)
  {
    int num1 = GameScr.indexSize - 2;
    int num2 = tick % (4 * num1);
    if (0 <= num2 && num2 < num1)
      return num2 % num1;
    if (num1 <= num2 && num2 < num1 * 2)
      return num1;
    return num1 * 2 <= num2 && num2 < num1 * 3 ? num1 - num2 % num1 : 0;
  }

  public bool isHaveOption(int id)
  {
    for (int index = 0; index < this.itemOption.Length; ++index)
    {
      ItemOption itemOption = this.itemOption[index];
      if (itemOption != null && itemOption.optionTemplate.id == id)
        return true;
    }
    return false;
  }

  public Item clone()
  {
    Item obj = new Item();
    obj.template = this.template;
    if (this.options != null)
    {
      obj.options = new MyVector();
      for (int index = 0; index < this.options.size(); ++index)
        obj.options.addElement((object) new ItemOption()
        {
          optionTemplate = ((ItemOption) this.options.elementAt(index)).optionTemplate,
          param = ((ItemOption) this.options.elementAt(index)).param
        });
    }
    obj.itemId = this.itemId;
    obj.playerId = this.playerId;
    obj.indexUI = this.indexUI;
    obj.quantity = this.quantity;
    obj.isLock = this.isLock;
    obj.sys = this.sys;
    obj.upgrade = this.upgrade;
    obj.buyCoin = this.buyCoin;
    obj.buyCoinLock = this.buyCoinLock;
    obj.buyGold = this.buyGold;
    obj.buyGoldLock = this.buyGoldLock;
    obj.saleCoinLock = this.saleCoinLock;
    obj.typeUI = this.typeUI;
    obj.isExpires = this.isExpires;
    return obj;
  }

  public bool isTypeBody() => (sbyte) 0 <= this.template.type && this.template.type < (sbyte) 6 || this.template.type == (sbyte) 32 || this.template.type == (sbyte) 35 || this.template.type == (sbyte) 11 || this.template.type == (sbyte) 23;

  public string getLockstring() => this.isLock ? mResources.LOCKED : mResources.NOLOCK;

  public string getUpgradestring()
  {
    if (this.template.level < (sbyte) 10 || this.template.type >= (sbyte) 10)
      return mResources.NOTUPGRADE;
    return this.upgrade == 0 ? mResources.NOUPGRADE : (string) null;
  }

  public bool isTypeUIMe() => this.typeUI == 5 || this.typeUI == 3 || this.typeUI == 4;

  public bool isTypeUIShopView() => this.isTypeUIShop() || this.isTypeUIStore() || this.isTypeUIBook() || this.isTypeUIFashion();

  public bool isTypeUIShop() => this.typeUI == 20 || this.typeUI == 21 || this.typeUI == 22 || this.typeUI == 23 || this.typeUI == 24 || this.typeUI == 25 || this.typeUI == 26 || this.typeUI == 27 || this.typeUI == 28 || this.typeUI == 29 || this.typeUI == 16 || this.typeUI == 17 || this.typeUI == 18 || this.typeUI == 19 || this.typeUI == 2 || this.typeUI == 6 || this.typeUI == 8;

  public bool isTypeUIShopLock() => this.typeUI == 7 || this.typeUI == 9;

  public bool isTypeUIStore() => this.typeUI == 14;

  public bool isTypeUIBook() => this.typeUI == 15;

  public bool isTypeUIFashion() => this.typeUI == 32;

  public bool isUpMax() => this.getUpMax() == this.upgrade;

  public int getUpMax()
  {
    if (this.template.level >= (sbyte) 1 && this.template.level < (sbyte) 20)
      return 4;
    if (this.template.level >= (sbyte) 20 && this.template.level < (sbyte) 40)
      return 8;
    if (this.template.level >= (sbyte) 40 && this.template.level < (sbyte) 50)
      return 12;
    return this.template.level >= (sbyte) 50 && this.template.level < (sbyte) 60 ? 14 : 16;
  }

  public void setPartTemp(int headTemp, int bodyTemp, int legTemp, int bagTemp)
  {
    this.headTemp = headTemp;
    this.bodyTemp = bodyTemp;
    this.legTemp = legTemp;
    this.bagTemp = bagTemp;
  }
}
