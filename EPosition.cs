// Decompiled with JetBrains decompiler
// Type: EPosition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class EPosition
{
  public int x;
  public int y;
  public int anchor;
  public sbyte follow;
  public sbyte count;
  public sbyte dir = 1;
  public short index = -1;

  public EPosition(int x, int y)
  {
    this.x = x;
    this.y = y;
  }

  public EPosition(int x, int y, int fol)
  {
    this.x = x;
    this.y = y;
    this.follow = (sbyte) fol;
  }

  public EPosition()
  {
  }
}
