// Decompiled with JetBrains decompiler
// Type: InputStream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class InputStream : myReader
{
  public InputStream()
  {
  }

  public InputStream(sbyte[] data) => this.buffer = data;

  public InputStream(string filename)
    : base(filename)
  {
  }
}
