// Decompiled with JetBrains decompiler
// Type: MovePoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class MovePoint
{
  public int xEnd;
  public int yEnd;
  public int dir;
  public int cvx;
  public int cvy;
  public int status;

  public MovePoint(int xEnd, int yEnd, int act, int dir)
  {
    this.xEnd = xEnd;
    this.yEnd = yEnd;
    this.dir = dir;
    this.status = act;
  }

  public MovePoint(int xEnd, int yEnd)
  {
    this.xEnd = xEnd;
    this.yEnd = yEnd;
  }
}
