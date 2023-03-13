// Decompiled with JetBrains decompiler
// Type: MyRandom
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class MyRandom
{
  public Random r;

  public MyRandom() => this.r = new Random();

  public int nextInt() => this.r.Next();

  public int nextInt(int a) => this.r.Next(a);

  public int nextInt(int a, int b) => this.r.Next(a, b);
}
