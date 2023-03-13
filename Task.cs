// Decompiled with JetBrains decompiler
// Type: Task
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Task
{
  public int index;
  public int max;
  public short[] counts;
  public short taskId;
  public string[] names;
  public string[] details;
  public string[] subNames;
  public string[] contentInfo;
  public short count;

  public Task(
    short taskId,
    sbyte index,
    string name,
    string detail,
    string[] subNames,
    short[] counts,
    short count,
    string[] contentInfo)
  {
    this.taskId = taskId;
    this.index = (int) index;
    this.names = mFont.tahoma_7b_green2.splitFontArray(name, Panel.WIDTH_PANEL - 20);
    this.details = mFont.tahoma_7.splitFontArray(detail, Panel.WIDTH_PANEL - 20);
    this.subNames = subNames;
    this.counts = counts;
    this.count = count;
    this.contentInfo = contentInfo;
  }
}
