// Decompiled with JetBrains decompiler
// Type: SkillOption
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class SkillOption
{
  public int param;
  public SkillOptionTemplate optionTemplate;
  public string optionString;

  public string getOptionString()
  {
    if (this.optionString == null)
      this.optionString = NinjaUtil.replace(this.optionTemplate.name, "#", string.Empty + (object) this.param);
    return this.optionString;
  }
}
