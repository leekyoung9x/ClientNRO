// Decompiled with JetBrains decompiler
// Type: Assets.src.g.ImageSource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

namespace Assets.src.g
{
  internal class ImageSource
  {
    public sbyte version;
    public string id;
    public static MyVector vSource = new MyVector();
    public static MyVector vRms = new MyVector();

    public ImageSource(string ID, sbyte version)
    {
      this.id = ID;
      this.version = version;
    }

    public static void checkRMS()
    {
      MyVector vID = new MyVector();
      sbyte[] data = Rms.loadRMS(nameof (ImageSource));
      if (data == null)
      {
        Service.gI().imageSource(vID);
      }
      else
      {
        ImageSource.vRms = new MyVector();
        DataInputStream dataInputStream = new DataInputStream(data);
        if (dataInputStream == null)
          return;
        try
        {
          short length = dataInputStream.readShort();
          string[] strArray = new string[(int) length];
          sbyte[] numArray = new sbyte[(int) length];
          for (int index = 0; index < (int) length; ++index)
          {
            strArray[index] = dataInputStream.readUTF();
            numArray[index] = dataInputStream.readByte();
            ImageSource.vRms.addElement((object) new ImageSource(strArray[index], numArray[index]));
          }
          dataInputStream.close();
        }
        catch (Exception ex)
        {
          ex.StackTrace.ToString();
        }
        Res.outz("vS size= " + (object) ImageSource.vSource.size() + " vRMS size= " + (object) ImageSource.vRms.size());
        for (int index = 0; index < ImageSource.vSource.size(); ++index)
        {
          ImageSource o = (ImageSource) ImageSource.vSource.elementAt(index);
          if (!ImageSource.isExistID(o.id))
            vID.addElement((object) o);
        }
        for (int index = 0; index < ImageSource.vRms.size(); ++index)
        {
          ImageSource o = (ImageSource) ImageSource.vRms.elementAt(index);
          if ((int) ImageSource.getVersionRMSByID(o.id) != (int) ImageSource.getCurrVersionByID(o.id))
            vID.addElement((object) o);
        }
        Service.gI().imageSource(vID);
      }
    }

    public static sbyte getVersionRMSByID(string id)
    {
      for (int index = 0; index < ImageSource.vRms.size(); ++index)
      {
        if (id.Equals(((ImageSource) ImageSource.vRms.elementAt(index)).id))
          return ((ImageSource) ImageSource.vRms.elementAt(index)).version;
      }
      return -1;
    }

    public static sbyte getCurrVersionByID(string id)
    {
      for (int index = 0; index < ImageSource.vSource.size(); ++index)
      {
        if (id.Equals(((ImageSource) ImageSource.vSource.elementAt(index)).id))
          return ((ImageSource) ImageSource.vSource.elementAt(index)).version;
      }
      return -1;
    }

    public static bool isExistID(string id)
    {
      for (int index = 0; index < ImageSource.vRms.size(); ++index)
      {
        if (id.Equals(((ImageSource) ImageSource.vRms.elementAt(index)).id))
          return true;
      }
      return false;
    }

    public static void saveRMS()
    {
      DataOutputStream dataOutputStream = new DataOutputStream();
      try
      {
        dataOutputStream.writeShort((short) ImageSource.vSource.size());
        for (int index = 0; index < ImageSource.vSource.size(); ++index)
        {
          dataOutputStream.writeUTF(((ImageSource) ImageSource.vSource.elementAt(index)).id);
          dataOutputStream.writeByte(((ImageSource) ImageSource.vSource.elementAt(index)).version);
        }
        Rms.saveRMS(nameof (ImageSource), dataOutputStream.toByteArray());
        dataOutputStream.close();
      }
      catch (Exception ex)
      {
        ex.StackTrace.ToString();
      }
    }
  }
}
