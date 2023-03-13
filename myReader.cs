// Decompiled with JetBrains decompiler
// Type: myReader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Text;
using UnityEngine;

public class myReader
{
  public sbyte[] buffer;
  private int posRead;
  private int posMark;
  private static string fileName;
  private static int status;

  public myReader()
  {
  }

  public myReader(sbyte[] data) => this.buffer = data;

  public myReader(string filename) => this.buffer = mSystem.convertToSbyte(((TextAsset) Resources.Load(filename, typeof (TextAsset))).bytes);

  public sbyte readSByte()
  {
    if (this.posRead < this.buffer.Length)
      return this.buffer[this.posRead++];
    this.posRead = this.buffer.Length;
    throw new Exception(" loi doc sbyte eof ");
  }

  public sbyte readsbyte() => this.readSByte();

  public sbyte readByte() => this.readSByte();

  public void mark(int readlimit) => this.posMark = this.posRead;

  public void reset() => this.posRead = this.posMark;

  public byte readUnsignedByte() => myReader.convertSbyteToByte(this.readSByte());

  public short readShort()
  {
    short num = 0;
    for (int index = 0; index < 2; ++index)
      num = (short) ((int) (short) ((int) num << 8) | (int) (short) ((int) byte.MaxValue & (int) this.buffer[this.posRead++]));
    return num;
  }

  public ushort readUnsignedShort()
  {
    ushort num = 0;
    for (int index = 0; index < 2; ++index)
      num = (ushort) ((int) (ushort) ((uint) num << 8) | (int) (ushort) ((int) byte.MaxValue & (int) this.buffer[this.posRead++]));
    return num;
  }

  public int readInt()
  {
    int num = 0;
    for (int index = 0; index < 4; ++index)
      num = num << 8 | (int) byte.MaxValue & (int) this.buffer[this.posRead++];
    return num;
  }

  public long readLong()
  {
    long num = 0;
    for (int index = 0; index < 8; ++index)
      num = num << 8 | (long) ((int) byte.MaxValue & (int) this.buffer[this.posRead++]);
    return num;
  }

  public bool readBool() => this.readSByte() > (sbyte) 0;

  public bool readBoolean() => this.readSByte() > (sbyte) 0;

  public string readString()
  {
    short length = this.readShort();
    byte[] bytes = new byte[(int) length];
    for (int index = 0; index < (int) length; ++index)
      bytes[index] = myReader.convertSbyteToByte(this.readSByte());
    return new UTF8Encoding().GetString(bytes);
  }

  public string readStringUTF()
  {
    short length = this.readShort();
    byte[] bytes = new byte[(int) length];
    for (int index = 0; index < (int) length; ++index)
      bytes[index] = myReader.convertSbyteToByte(this.readSByte());
    return new UTF8Encoding().GetString(bytes);
  }

  public string readUTF() => this.readStringUTF();

  public int read() => this.posRead < this.buffer.Length ? (int) this.readSByte() : -1;

  public int read(ref sbyte[] data)
  {
    if (data == null)
      return 0;
    int num = 0;
    for (int index = 0; index < data.Length; ++index)
    {
      data[index] = this.readSByte();
      if (this.posRead > this.buffer.Length)
        return -1;
      ++num;
    }
    return num;
  }

  public void readFully(ref sbyte[] data)
  {
    if (data == null || data.Length + this.posRead > this.buffer.Length)
      return;
    for (int index = 0; index < data.Length; ++index)
      data[index] = this.readSByte();
  }

  public int available() => this.buffer.Length - this.posRead;

  public static byte convertSbyteToByte(sbyte var) => var > (sbyte) 0 ? (byte) var : (byte) ((uint) var + 256U);

  public static byte[] convertSbyteToByte(sbyte[] var)
  {
    byte[] numArray = new byte[var.Length];
    for (int index = 0; index < var.Length; ++index)
      numArray[index] = var[index] <= (sbyte) 0 ? (byte) ((uint) var[index] + 256U) : (byte) var[index];
    return numArray;
  }

  public void Close() => this.buffer = (sbyte[]) null;

  public void close() => this.buffer = (sbyte[]) null;

  public void read(ref sbyte[] data, int arg1, int arg2)
  {
    if (data == null)
      return;
    for (int index = 0; index < arg2; ++index)
    {
      data[index + arg1] = this.readSByte();
      if (this.posRead > this.buffer.Length)
        break;
    }
  }
}
