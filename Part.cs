// Decompiled with JetBrains decompiler
// Type: Part
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Part
{
  public int type;
  public PartImage[] pi;

  public Part(int type)
  {
    this.type = type;
    if (type == 0)
      this.pi = new PartImage[3];
    if (type == 1)
      this.pi = new PartImage[17];
    if (type == 2)
      this.pi = new PartImage[14];
    if (type != 3)
      return;
    this.pi = new PartImage[2];
  }
}
