// Decompiled with JetBrains decompiler
// Type: ClanMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ClanMessage : IActionListener
{
  public int id;
  public int type;
  public int playerId;
  public string playerName;
  public long time;
  public int headId;
  public string[] chat;
  public sbyte color;
  public sbyte role;
  private int timeAgo;
  public int recieve;
  public int maxCap;
  public string[] option;
  public static MyVector vMessage = new MyVector();

  public static void addMessage(ClanMessage cm, int index, bool upToTop)
  {
    for (int index1 = 0; index1 < ClanMessage.vMessage.size(); ++index1)
    {
      ClanMessage o1 = (ClanMessage) ClanMessage.vMessage.elementAt(index1);
      if (o1.id == cm.id)
      {
        ClanMessage o2 = cm;
        ClanMessage.vMessage.removeElement((object) o1);
        if (!upToTop)
        {
          ClanMessage.vMessage.insertElementAt((object) o2, index1);
          return;
        }
        ClanMessage.vMessage.insertElementAt((object) o2, 0);
        return;
      }
      if (o1.maxCap != 0 && o1.recieve == o1.maxCap)
        ClanMessage.vMessage.removeElement((object) o1);
    }
    if (index == -1)
      ClanMessage.vMessage.addElement((object) cm);
    else
      ClanMessage.vMessage.insertElementAt((object) cm, 0);
    if (ClanMessage.vMessage.size() <= 20)
      return;
    ClanMessage.vMessage.removeElementAt(ClanMessage.vMessage.size() - 1);
  }

  public void paint(mGraphics g, int x, int y)
  {
    mFont mFont = mFont.tahoma_7b_dark;
    if (this.role == (sbyte) 0)
      mFont = mFont.tahoma_7b_red;
    else if (this.role == (sbyte) 1)
      mFont = mFont.tahoma_7b_green;
    else if (this.role == (sbyte) 2)
      mFont = mFont.tahoma_7b_green2;
    if (this.type == 0)
    {
      mFont.drawString(g, this.playerName, x + 3, y + 1, 0);
      if (this.color == (sbyte) 0)
        mFont.tahoma_7_grey.drawString(g, this.chat[0] + (this.chat.Length <= 1 ? string.Empty : "..."), x + 3, y + 11, 0);
      else
        mFont.tahoma_7_red.drawString(g, this.chat[0] + (this.chat.Length <= 1 ? string.Empty : "..."), x + 3, y + 11, 0);
      mFont.tahoma_7_grey.drawString(g, NinjaUtil.getTimeAgo(this.timeAgo) + " " + mResources.ago, x + GameCanvas.panel.wScroll - 3, y + 1, mFont.RIGHT);
    }
    if (this.type == 1)
    {
      mFont.drawString(g, this.playerName + " (" + (object) this.recieve + "/" + (object) this.maxCap + ")", x + 3, y + 1, 0);
      mFont.tahoma_7_blue.drawString(g, mResources.request_pea + " " + NinjaUtil.getTimeAgo(this.timeAgo) + " " + mResources.ago, x + 3, y + 11, 0);
    }
    if (this.type != 2)
      return;
    mFont.drawString(g, this.playerName, x + 3, y + 1, 0);
    mFont.tahoma_7_blue.drawString(g, mResources.request_join_clan, x + 3, y + 11, 0);
  }

  public void perform(int idAction, object p)
  {
  }

  public void update()
  {
    if (this.time == 0L)
      return;
    this.timeAgo = (int) (mSystem.currentTimeMillis() / 1000L - this.time);
  }
}
