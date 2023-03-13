// Decompiled with JetBrains decompiler
// Type: DataOutputStream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class DataOutputStream
{
  private myWriter w = new myWriter();

  public void writeShort(short i) => this.w.writeShort(i);

  public void writeInt(int i) => this.w.writeInt(i);

  public void write(sbyte[] data) => this.w.writeSByte(data);

  public sbyte[] toByteArray() => this.w.getData();

  public void close() => this.w.Close();

  public void writeByte(sbyte b) => this.w.writeByte(b);

  public void writeUTF(string name) => this.w.writeUTF(name);

  public void writeBoolean(bool b) => this.w.writeBoolean(b);
}
