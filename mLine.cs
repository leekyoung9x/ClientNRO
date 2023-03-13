// Decompiled with JetBrains decompiler
// Type: mLine
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class mLine
{
  public int x1;
  public int x2;
  public int y1;
  public int y2;
  public float r;
  public float b;
  public float g;
  public float a;

  public mLine(int x1, int y1, int x2, int y2, int cl)
  {
    this.x1 = x1;
    this.y1 = y1;
    this.x2 = x2;
    this.y2 = y2;
    this.setColor(cl);
  }

  public void setColor(int rgb)
  {
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    this.b = (float) num1 / 256f;
    this.g = (float) num2 / 256f;
    this.r = (float) num3 / 256f;
    this.a = (float) byte.MaxValue;
  }
}
