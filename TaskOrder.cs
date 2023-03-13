// Decompiled with JetBrains decompiler
// Type: TaskOrder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class TaskOrder
{
  public const sbyte TASK_DAY = 0;
  public const sbyte TASK_BOSS = 1;
  public int taskId;
  public int count;
  public short maxCount;
  public string name;
  public string description;
  public int killId;
  public int mapId;

  public TaskOrder(
    sbyte taskId,
    short count,
    short maxCount,
    string name,
    string description,
    sbyte killId,
    sbyte mapId)
  {
    this.count = (int) count;
    this.maxCount = maxCount;
    this.taskId = (int) taskId;
    this.name = name;
    this.description = description;
    this.killId = (int) killId;
    this.mapId = (int) mapId;
  }
}
