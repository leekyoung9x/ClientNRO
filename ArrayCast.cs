// Decompiled with JetBrains decompiler
// Type: ArrayCast
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ArrayCast
{
  public static sbyte[] cast(byte[] data)
  {
    sbyte[] numArray = new sbyte[data.Length];
    for (int index = 0; index < numArray.Length; ++index)
      numArray[index] = (sbyte) data[index];
    return numArray;
  }

  public static byte[] cast(sbyte[] data)
  {
    byte[] numArray = new byte[data.Length];
    for (int index = 0; index < numArray.Length; ++index)
      numArray[index] = (byte) data[index];
    return numArray;
  }

  public static char[] ToCharArray(sbyte[] data)
  {
    char[] charArray = new char[data.Length];
    for (int index = 0; index < charArray.Length; ++index)
      charArray[index] = (char) data[index];
    return charArray;
  }
}
