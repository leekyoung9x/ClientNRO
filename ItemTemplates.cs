// Decompiled with JetBrains decompiler
// Type: ItemTemplates
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ItemTemplates
{
  public static MyHashTable itemTemplates = new MyHashTable();

  public static void add(ItemTemplate it) => ItemTemplates.itemTemplates.put((object) it.id, (object) it);

  public static ItemTemplate get(short id) => (ItemTemplate) ItemTemplates.itemTemplates.get((object) id);

  public static short getPart(short itemTemplateID) => ItemTemplates.get(itemTemplateID).part;

  public static short getIcon(short itemTemplateID) => ItemTemplates.get(itemTemplateID).iconID;
}
