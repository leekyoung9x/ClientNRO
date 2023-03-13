// Decompiled with JetBrains decompiler
// Type: ItemOption
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ItemOption
{
  public int param;
  public sbyte active;
  public sbyte activeCard;
  public ItemOptionTemplate optionTemplate;

  public ItemOption()
  {
  }

  public ItemOption(int optionTemplateId, int param)
  {
    if (optionTemplateId == 22)
    {
      optionTemplateId = 6;
      param *= 1000;
    }
    if (optionTemplateId == 23)
    {
      optionTemplateId = 7;
      param *= 1000;
    }
    this.param = param;
    this.optionTemplate = GameScr.gI().iOptionTemplates[optionTemplateId];
  }

  public string getOptionString() => NinjaUtil.replace(this.optionTemplate.name, "#", this.param.ToString() + string.Empty);

  public string getOptionName() => NinjaUtil.replace(this.optionTemplate.name, "+#", string.Empty);

  public string getOptiongColor() => NinjaUtil.replace(this.optionTemplate.name, "$", string.Empty);
}
