// Decompiled with JetBrains decompiler
// Type: EffectChar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class EffectChar
{
  public static EffectTemplate[] effTemplates;
  public static sbyte EFF_ME;
  public static sbyte EFF_FRIEND = 1;
  public int timeStart;
  public int timeLenght;
  public short param;
  public EffectTemplate template;

  public EffectChar(sbyte templateId, int timeStart, int timeLenght, short param)
  {
    this.template = EffectChar.effTemplates[(int) templateId];
    this.timeStart = timeStart;
    this.timeLenght = timeLenght / 1000;
    this.param = param;
  }
}
