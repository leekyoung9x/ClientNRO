// Decompiled with JetBrains decompiler
// Type: InfoItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class InfoItem
{
  public string s;
  private mFont f;
  public int speed = 70;
  public Char charInfo;
  public bool isChatServer;
  public bool isOnline;
  public int timeCount;
  public int maxTime;
  public long last;
  public long curr;

  public InfoItem(string s)
  {
    this.f = mFont.tahoma_7_green2;
    this.s = s;
    this.speed = 20;
  }

  public InfoItem(string s, mFont f, int speed)
  {
    this.f = f;
    this.s = s;
    this.speed = speed;
  }
}
