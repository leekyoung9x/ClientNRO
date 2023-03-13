// Decompiled with JetBrains decompiler
// Type: Friend
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Friend
{
  public string friendName;
  public sbyte type;

  public Friend(string friendName, sbyte type)
  {
    this.friendName = friendName;
    this.type = type;
  }

  public Friend(string friendName)
  {
    this.friendName = friendName;
    this.type = (sbyte) 2;
  }
}
