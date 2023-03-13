// Decompiled with JetBrains decompiler
// Type: Skills
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Skills
{
  public static MyHashTable skills = new MyHashTable();

  public static void add(Skill skill) => Skills.skills.put((object) skill.skillId, (object) skill);

  public static Skill get(short skillId) => (Skill) Skills.skills.get((object) skillId);
}
