// Decompiled with JetBrains decompiler
// Type: Member
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Member
{
  public int ID;
  public short head;
  public short headICON = -1;
  public short leg;
  public short body;
  public string name;
  public sbyte role;
  public string powerPoint;
  public int donate;
  public int receive_donate;
  public int curClanPoint;
  public int clanPoint;
  public int lastRequest;
  public string joinTime;

  public static string getRole(int r)
  {
    switch (r)
    {
      case 0:
        return mResources.clan_leader;
      case 1:
        return mResources.clan_coleader;
      case 2:
        return mResources.member;
      default:
        return string.Empty;
    }
  }
}
