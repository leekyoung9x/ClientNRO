// Decompiled with JetBrains decompiler
// Type: EffectPaint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class EffectPaint
{
  public int index;
  public Mob eMob;
  public Char eChar;
  public EffectCharPaint effCharPaint;
  public bool isFly;

  public int getImgId() => this.effCharPaint.arrEfInfo[this.index].idImg;
}
