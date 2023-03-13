// Decompiled with JetBrains decompiler
// Type: Rms
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
using System.Threading;
using UnityEngine;

public class Rms
{
  public static int status;
  public static sbyte[] data;
  public static string filename;
  private const int INTERVAL = 5;
  private const int MAXTIME = 500;

  public static void saveRMS(string filename, sbyte[] data)
  {
    if (Thread.CurrentThread.Name == Main.mainThreadName)
      Rms.__saveRMS(filename, data);
    else
      Rms._saveRMS(filename, data);
  }

  public static sbyte[] loadRMS(string filename) => Thread.CurrentThread.Name == Main.mainThreadName ? Rms.__loadRMS(filename) : Rms._loadRMS(filename);

  public static string loadRMSString(string fileName)
  {
    sbyte[] data = Rms.loadRMS(fileName);
    if (data == null)
      return (string) null;
    DataInputStream dataInputStream = new DataInputStream(data);
    try
    {
      string str = dataInputStream.readUTF();
      dataInputStream.close();
      return str;
    }
    catch (Exception ex)
    {
      Cout.println(ex.StackTrace);
    }
    return (string) null;
  }

  public static byte[] convertSbyteToByte(sbyte[] var)
  {
    byte[] numArray = new byte[var.Length];
    for (int index = 0; index < var.Length; ++index)
      numArray[index] = var[index] <= (sbyte) 0 ? (byte) ((uint) var[index] + 256U) : (byte) var[index];
    return numArray;
  }

  public static void saveRMSString(string filename, string data)
  {
    DataOutputStream dataOutputStream = new DataOutputStream();
    try
    {
      dataOutputStream.writeUTF(data);
      Rms.saveRMS(filename, dataOutputStream.toByteArray());
      dataOutputStream.close();
    }
    catch (Exception ex)
    {
      Cout.println(ex.StackTrace);
    }
  }

  private static void _saveRMS(string filename, sbyte[] data)
  {
    if (Rms.status != 0)
    {
      Debug.LogError((object) ("Cannot save RMS " + filename + " because current is saving " + Rms.filename));
    }
    else
    {
      Rms.filename = filename;
      Rms.data = data;
      Rms.status = 2;
      int num;
      for (num = 0; num < 500; ++num)
      {
        Thread.Sleep(5);
        if (Rms.status == 0)
          break;
      }
      if (num != 500)
        return;
      Debug.LogError((object) ("TOO LONG TO SAVE RMS " + filename));
    }
  }

  private static sbyte[] _loadRMS(string filename)
  {
    if (Rms.status != 0)
    {
      Debug.LogError((object) ("Cannot load RMS " + filename + " because current is loading " + Rms.filename));
      return (sbyte[]) null;
    }
    Rms.filename = filename;
    Rms.data = (sbyte[]) null;
    Rms.status = 3;
    int num;
    for (num = 0; num < 500; ++num)
    {
      Thread.Sleep(5);
      if (Rms.status == 0)
        break;
    }
    if (num == 500)
      Debug.LogError((object) ("TOO LONG TO LOAD RMS " + filename));
    return Rms.data;
  }

  public static void update()
  {
    if (Rms.status == 2)
    {
      Rms.status = 1;
      Rms.__saveRMS(Rms.filename, Rms.data);
      Rms.status = 0;
    }
    else
    {
      if (Rms.status != 3)
        return;
      Rms.status = 1;
      Rms.data = Rms.__loadRMS(Rms.filename);
      Rms.status = 0;
    }
  }

  public static int loadRMSInt(string file)
  {
    sbyte[] numArray = Rms.loadRMS(file);
    return numArray == null ? -1 : (int) numArray[0];
  }

  public static void saveRMSInt(string file, int x)
  {
    try
    {
      Rms.saveRMS(file, new sbyte[1]{ (sbyte) x });
    }
    catch (Exception ex)
    {
    }
  }

  public static string GetiPhoneDocumentsPath() => Application.persistentDataPath;

  private static void __saveRMS(string filename, sbyte[] data)
  {
    string path = Rms.GetiPhoneDocumentsPath() + "/" + filename;
    FileStream fileStream = new FileStream(path, FileMode.Create);
    fileStream.Write(ArrayCast.cast(data), 0, data.Length);
    fileStream.Flush();
    fileStream.Close();
    Main.setBackupIcloud(path);
  }

  private static sbyte[] __loadRMS(string filename)
  {
    try
    {
      FileStream fileStream = new FileStream(Rms.GetiPhoneDocumentsPath() + "/" + filename, FileMode.Open);
      byte[] numArray = new byte[fileStream.Length];
      fileStream.Read(numArray, 0, numArray.Length);
      fileStream.Close();
      ArrayCast.cast(numArray);
      return ArrayCast.cast(numArray);
    }
    catch (Exception ex)
    {
      return (sbyte[]) null;
    }
  }

  public static void clearAll()
  {
    Cout.LogError3("clean rms");
    foreach (FileSystemInfo file in new DirectoryInfo(Rms.GetiPhoneDocumentsPath() + "/").GetFiles())
      file.Delete();
  }

  public static void DeleteStorage(string path)
  {
    try
    {
      File.Delete(Rms.GetiPhoneDocumentsPath() + "/" + path);
    }
    catch (Exception ex)
    {
    }
  }

  public static string ByteArrayToString(byte[] ba) => BitConverter.ToString(ba).Replace("-", string.Empty);

  public static byte[] StringToByteArray(string hex)
  {
    int length = hex.Length;
    byte[] byteArray = new byte[length / 2];
    for (int startIndex = 0; startIndex < length; startIndex += 2)
      byteArray[startIndex / 2] = Convert.ToByte(hex.Substring(startIndex, 2), 16);
    return byteArray;
  }

  public static void deleteRecord(string name)
  {
    try
    {
      PlayerPrefs.DeleteKey(name);
    }
    catch (Exception ex)
    {
      Cout.println("loi xoa RMS --------------------------" + ex.ToString());
    }
  }

  public static void clearRMS()
  {
    Rms.deleteRecord("data");
    Rms.deleteRecord("dataVersion");
    Rms.deleteRecord("map");
    Rms.deleteRecord("mapVersion");
    Rms.deleteRecord("skill");
    Rms.deleteRecord("killVersion");
    Rms.deleteRecord("item");
    Rms.deleteRecord("itemVersion");
  }

  public static void saveIP(string strID) => Rms.saveRMSString("NRIPlink", strID);

  public static string loadIP() => Rms.loadRMSString("NRIPlink") ?? (string) null;
}
