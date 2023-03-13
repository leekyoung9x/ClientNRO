// Decompiled with JetBrains decompiler
// Type: Info_RadaScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Info_RadaScr
{
  public const sbyte TYPE_MONSTER = 0;
  public const sbyte TYPE_CHARPART = 1;
  public sbyte rank;
  public sbyte amount;
  public sbyte max_amount;
  public sbyte typeMonster;
  public int id;
  public int no;
  public int idIcon;
  public string name;
  public string info;
  public sbyte level;
  public sbyte isUse;
  public Char charInfo;
  public Mob mobInfo;
  public ItemOption[] itemOption;
  private int[] f = new int[10]
  {
    0,
    0,
    0,
    0,
    0,
    1,
    1,
    1,
    1,
    1
  };
  private int count;
  private long timeRequest;
  public ChatPopup cp;
  public MyVector eff = new MyVector(string.Empty);

  public void SetInfo(
    int id,
    int no,
    int idIcon,
    sbyte rank,
    sbyte typeMonster,
    short templateId,
    string name,
    string info,
    Char charInfo,
    ItemOption[] itemOption)
  {
    this.id = id;
    this.no = no;
    this.idIcon = idIcon;
    this.rank = rank;
    this.typeMonster = typeMonster;
    if (templateId != (short) -1)
    {
      this.mobInfo = new Mob();
      this.mobInfo.templateId = (int) templateId;
    }
    this.name = name;
    this.info = info;
    this.charInfo = charInfo;
    this.itemOption = itemOption;
    this.addItemDetail();
  }

  public void SetAmount(sbyte amount, sbyte max_amount)
  {
    this.amount = amount;
    this.max_amount = max_amount;
  }

  public void SetLevel(sbyte level)
  {
    this.level = level;
    this.addItemDetail();
  }

  public void SetUse(sbyte isUse)
  {
    this.isUse = isUse;
    this.addItemDetail();
  }

  public static Char SetCharInfo(int head, int body, int leg, int bag) => new Char()
  {
    head = head,
    body = body,
    leg = leg,
    bag = bag
  };

  public static Info_RadaScr GetInfo(MyVector vec, int id)
  {
    if (vec != null)
    {
      for (int index = 0; index < vec.size(); ++index)
      {
        Info_RadaScr info = (Info_RadaScr) vec.elementAt(index);
        if (info != null && info.id == id)
          return info;
      }
    }
    return (Info_RadaScr) null;
  }

  public void paintInfo(mGraphics g, int x, int y)
  {
    ++this.count;
    if (this.count > this.f.Length - 1)
      this.count = 0;
    if (this.typeMonster == (sbyte) 0)
    {
      if (Mob.arrMobTemplate[this.mobInfo.templateId] == null)
        return;
      if (Mob.arrMobTemplate[this.mobInfo.templateId].data != null)
      {
        Mob.arrMobTemplate[this.mobInfo.templateId].data.paintFrame(g, this.f[this.count], x, y, 0, 0);
      }
      else
      {
        if (this.timeRequest - GameCanvas.timeNow >= 0L)
          return;
        this.timeRequest = GameCanvas.timeNow + 1500L;
        this.mobInfo.getData();
      }
    }
    else
    {
      if (this.charInfo == null)
        return;
      this.charInfo.paintCharBody(g, x, y, 1, this.f[this.count], true);
    }
  }

  public void addItemDetail()
  {
    this.cp = new ChatPopup();
    string empty = string.Empty;
    string chat = string.Empty + "\n|6|" + this.info + "\n--";
    if (this.itemOption != null)
    {
      int num1 = 0;
      bool flag = true;
      while (flag)
      {
        int num2 = 0;
        for (int index = 0; index < this.itemOption.Length; ++index)
        {
          if (!this.itemOption[index].getOptionString().Equals(string.Empty) && num1 == (int) this.itemOption[index].activeCard)
          {
            ++num2;
            break;
          }
        }
        if (num2 == 0)
          break;
        if (num1 == 0)
          chat = chat + "\n|6|2|--" + mResources.unlock + "--";
        else
          chat = chat + "\n|6|2|--" + mResources.equip + " Lv." + (object) num1 + "--";
        for (int index = 0; index < this.itemOption.Length; ++index)
        {
          string optionString = this.itemOption[index].getOptionString();
          if (!optionString.Equals(string.Empty) && num1 == (int) this.itemOption[index].activeCard)
          {
            string str = "1";
            if (this.level == (sbyte) 0)
              str = "2";
            else if (this.itemOption[index].activeCard != (sbyte) 0)
            {
              if (this.isUse == (sbyte) 0)
                str = "2";
              else if ((int) this.level < (int) this.itemOption[index].activeCard)
                str = "2";
            }
            chat = chat + "\n|" + str + "|1|" + optionString;
          }
        }
        if (num2 != 0)
          ++num1;
      }
    }
    this.popUpDetailInit(this.cp, chat);
  }

  public void popUpDetailInit(ChatPopup cp, string chat)
  {
    cp.sayWidth = RadarScr.wText;
    cp.cx = RadarScr.xText;
    cp.says = mFont.tahoma_7.splitFontArray(chat, cp.sayWidth - 8);
    cp.delay = 10000000;
    cp.c = (Npc) null;
    cp.ch = cp.says.Length * 12;
    cp.cy = RadarScr.yText;
    cp.strY = 10;
    cp.lim = cp.ch - RadarScr.hText;
    if (cp.lim >= 0)
      return;
    cp.lim = 0;
  }

  public void SetEff()
  {
    if ((int) this.amount != (int) this.max_amount || this.eff.size() != 0)
      return;
    int num = Res.random(1, 5);
    for (int index = 0; index < num; ++index)
      this.eff.addElement((object) new Position()
      {
        x = Res.random(5, 25),
        y = Res.random(5, 25),
        v = (index * Res.random(0, 8)),
        w = 0,
        anchor = -1
      });
  }

  public void paintEff(mGraphics g, int x, int y)
  {
    this.SetEff();
    for (int index = 0; index < this.eff.size(); ++index)
    {
      Position position = (Position) this.eff.elementAt(index);
      if (position != null)
      {
        if (position.w < position.v)
          ++position.w;
        if (position.w >= position.v)
        {
          position.anchor = GameCanvas.gameTick / 3 % (RadarScr.fraEff.nFrame + 1);
          if (position.anchor >= RadarScr.fraEff.nFrame)
          {
            this.eff.removeElementAt(index);
            --index;
          }
          else
            RadarScr.fraEff.drawFrame(position.anchor, x + position.x, y + position.y, 0, 3, g);
        }
      }
    }
  }
}
