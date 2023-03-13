// Decompiled with JetBrains decompiler
// Type: ItemTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ItemTime
{
  public short idIcon;
  public int second;
  public int minute;
  private long curr;
  private long last;
  private bool isText;
  private bool dontClear;
  private string text;

  public ItemTime()
  {
  }

  public ItemTime(short idIcon, int s)
  {
    this.idIcon = idIcon;
    this.minute = s / 60;
    this.second = s % 60;
    this.curr = this.last = mSystem.currentTimeMillis();
  }

  public void initTimeText(sbyte id, string text, int time)
  {
    this.dontClear = time == -1;
    this.isText = true;
    this.minute = time / 60;
    this.second = time % 60;
    this.idIcon = (short) id;
    this.curr = this.last = mSystem.currentTimeMillis();
    this.text = text;
  }

  public void initTime(int time, bool isText)
  {
    this.minute = time / 60;
    this.second = time % 60;
    this.curr = this.last = mSystem.currentTimeMillis();
    this.isText = isText;
  }

  public static bool isExistItem(int id)
  {
    for (int index = 0; index < Char.vItemTime.size(); ++index)
    {
      if ((int) ((ItemTime) Char.vItemTime.elementAt(index)).idIcon == id)
        return true;
    }
    return false;
  }

  public static ItemTime getMessageById(int id)
  {
    for (int index = 0; index < GameScr.textTime.size(); ++index)
    {
      ItemTime messageById = (ItemTime) GameScr.textTime.elementAt(index);
      if ((int) messageById.idIcon == id)
        return messageById;
    }
    return (ItemTime) null;
  }

  public static bool isExistMessage(int id)
  {
    for (int index = 0; index < GameScr.textTime.size(); ++index)
    {
      if ((int) ((ItemTime) GameScr.textTime.elementAt(index)).idIcon == id)
        return true;
    }
    return false;
  }

  public static ItemTime getItemById(int id)
  {
    for (int index = 0; index < Char.vItemTime.size(); ++index)
    {
      ItemTime itemById = (ItemTime) Char.vItemTime.elementAt(index);
      if ((int) itemById.idIcon == id)
        return itemById;
    }
    return (ItemTime) null;
  }

  public void initTime(int time)
  {
    this.minute = time / 60;
    this.second = time % 60;
    this.curr = this.last = mSystem.currentTimeMillis();
  }

  public void paint(mGraphics g, int x, int y)
  {
    SmallImage.drawSmallImage(g, (int) this.idIcon, x, y, 0, 3);
    string empty = string.Empty;
    string st = this.minute.ToString() + "'";
    if (this.minute == 0)
      st = this.second.ToString() + "s";
    mFont.tahoma_7b_white.drawString(g, st, x, y + 15, 2, mFont.tahoma_7b_dark);
  }

  public void paintText(mGraphics g, int x, int y)
  {
    string empty = string.Empty;
    string str = this.minute.ToString() + "'";
    if (this.minute < 1)
      str = this.second.ToString() + "s";
    if (this.minute < 0)
      str = string.Empty;
    if (this.dontClear)
      str = string.Empty;
    mFont.tahoma_7b_white.drawString(g, this.text + " " + str, x, y, mFont.LEFT, mFont.tahoma_7b_dark);
  }

  public void update()
  {
    this.curr = mSystem.currentTimeMillis();
    if (this.curr - this.last >= 1000L)
    {
      this.last = mSystem.currentTimeMillis();
      --this.second;
      if (this.second <= 0)
      {
        this.second = 60;
        --this.minute;
      }
    }
    if (this.minute < 0 && !this.isText)
      Char.vItemTime.removeElement((object) this);
    if (this.minute >= 0 || !this.isText || this.dontClear)
      return;
    GameScr.textTime.removeElement((object) this);
  }
}
