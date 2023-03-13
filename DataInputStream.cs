// Decompiled with JetBrains decompiler
// Type: DataInputStream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Threading;
using UnityEngine;

public class DataInputStream
{
  public myReader r;
  private const int INTERVAL = 5;
  private const int MAXTIME = 500;
  public static DataInputStream istemp;
  private static int status;
  private static string filenametemp;

  public DataInputStream(string filename) => this.r = new myReader(ArrayCast.cast(((TextAsset) Resources.Load(filename, typeof (TextAsset))).bytes));

  public DataInputStream(sbyte[] data) => this.r = new myReader(data);

  public static void update()
  {
    if (DataInputStream.status != 2)
      return;
    DataInputStream.status = 1;
    DataInputStream.istemp = DataInputStream.__getResourceAsStream(DataInputStream.filenametemp);
    DataInputStream.status = 0;
  }

  public static DataInputStream getResourceAsStream(string filename) => DataInputStream.__getResourceAsStream(filename);

  private static DataInputStream _getResourceAsStream(string filename)
  {
    if (DataInputStream.status != 0)
    {
      for (int index = 0; index < 500; ++index)
      {
        Thread.Sleep(5);
        if (DataInputStream.status == 0)
          break;
      }
      if (DataInputStream.status != 0)
      {
        Debug.LogError((object) ("CANNOT GET INPUTSTREAM " + filename + " WHEN GETTING " + DataInputStream.filenametemp));
        return (DataInputStream) null;
      }
    }
    DataInputStream.istemp = (DataInputStream) null;
    DataInputStream.filenametemp = filename;
    DataInputStream.status = 2;
    int num;
    for (num = 0; num < 500; ++num)
    {
      Thread.Sleep(5);
      if (DataInputStream.status == 0)
        break;
    }
    if (num != 500)
      return DataInputStream.istemp;
    Debug.LogError((object) ("TOO LONG FOR CREATE INPUTSTREAM " + filename));
    DataInputStream.status = 0;
    return (DataInputStream) null;
  }

  private static DataInputStream __getResourceAsStream(string filename)
  {
    try
    {
      return new DataInputStream(filename);
    }
    catch (Exception ex)
    {
      return (DataInputStream) null;
    }
  }

  public short readShort() => this.r.readShort();

  public int readInt() => this.r.readInt();

  public int read() => (int) this.r.readUnsignedByte();

  public void read(ref sbyte[] data) => this.r.read(ref data);

  public void close() => this.r.Close();

  public void Close() => this.r.Close();

  public string readUTF() => this.r.readUTF();

  public sbyte readByte() => this.r.readByte();

  public long readLong() => this.r.readLong();

  public bool readBoolean() => this.r.readBoolean();

  public int readUnsignedByte() => (int) (byte) this.r.readByte();

  public int readUnsignedShort() => (int) this.r.readUnsignedShort();

  public void readFully(ref sbyte[] data) => this.r.read(ref data);

  public int available() => this.r.available();

  internal void read(ref sbyte[] byteData, int p, int size) => throw new NotImplementedException();
}
