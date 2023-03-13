// Decompiled with JetBrains decompiler
// Type: ItemTemplate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ItemTemplate
{
  public short id;
  public sbyte type;
  public sbyte gender;
  public string name;
  public string[] subName;
  public string description;
  public sbyte level;
  public short iconID;
  public short part;
  public bool isUpToUp;
  public int w;
  public int h;
  public int strRequire;

  public ItemTemplate(
    short templateID,
    sbyte type,
    sbyte gender,
    string name,
    string description,
    sbyte level,
    int strRequire,
    short iconID,
    short part,
    bool isUpToUp)
  {
    this.id = templateID;
    this.type = type;
    this.gender = gender;
    this.name = name;
    this.name = Res.changeString(this.name);
    this.description = description;
    this.description = Res.changeString(this.description);
    this.level = level;
    this.strRequire = strRequire;
    this.iconID = iconID;
    this.part = part;
    this.isUpToUp = isUpToUp;
  }
}
