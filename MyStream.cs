// Decompiled with JetBrains decompiler
// Type: MyStream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class MyStream
{
  public static DataInputStream readFile(string path)
  {
    path = Main.res + path;
    try
    {
      return DataInputStream.getResourceAsStream(path);
    }
    catch (Exception ex)
    {
      return (DataInputStream) null;
    }
  }
}
