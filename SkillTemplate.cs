// Decompiled with JetBrains decompiler
// Type: SkillTemplate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class SkillTemplate
{
  public sbyte id;
  public int classId;
  public string name;
  public int maxPoint;
  public int manaUseType;
  public int type;
  public int iconId;
  public string[] description;
  public Skill[] skills;
  public string damInfo;

  public bool isBuffToPlayer() => this.type == 2;

  public bool isUseAlone() => this.type == 3;

  public bool isAttackSkill() => this.type == 1;
}
