// Decompiled with JetBrains decompiler
// Type: ImgByName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;

public class ImgByName
{
  public static MyHashTable hashImagePath = new MyHashTable();

  public static void SetImage(string name, Image img, sbyte nFrame) => ImgByName.hashImagePath.put((object) (string.Empty + name), (object) new MainImage(img, nFrame));

  public static MainImage getImagePath(string nameImg, MyHashTable hash)
  {
    MainImage v = (MainImage) hash.get((object) (string.Empty + nameImg));
    if (v == null)
    {
      v = new MainImage();
      MainImage fromRms = ImgByName.getFromRms(nameImg);
      if (fromRms != null)
      {
        v.img = fromRms.img;
        v.nFrame = fromRms.nFrame;
      }
      hash.put((object) (string.Empty + nameImg), (object) v);
    }
    v.count = GameCanvas.timeNow / 1000L;
    if (v.img == null)
    {
      --v.timeImageNull;
      if (v.timeImageNull <= 0)
      {
        Service.gI().getImgByName(nameImg);
        v.timeImageNull = 200;
      }
    }
    return v;
  }

  public static MainImage getFromRms(string nameImg)
  {
    string filename = mGraphics.zoomLevel.ToString() + "ImgByName_" + nameImg;
    MainImage fromRms1 = (MainImage) null;
    sbyte[] imageData = Rms.loadRMS(filename);
    if (imageData == null)
      return fromRms1;
    MainImage fromRms2;
    try
    {
      fromRms2 = new MainImage();
      fromRms2.nFrame = imageData[0];
      fromRms2.img = Image.createImage(imageData, 1, imageData.Length);
    }
    catch (Exception ex)
    {
      return (MainImage) null;
    }
    return fromRms2;
  }

  public static void saveRMS(string nameImg, sbyte nFrame, sbyte[] data)
  {
    string filename = mGraphics.zoomLevel.ToString() + "ImgByName_" + nameImg;
    DataOutputStream dataOutputStream = new DataOutputStream();
    try
    {
      dataOutputStream.writeByte(nFrame);
      for (int index = 0; index < data.Length; ++index)
        dataOutputStream.writeByte(data[index]);
      Rms.saveRMS(filename, dataOutputStream.toByteArray());
      dataOutputStream.close();
    }
    catch (Exception ex)
    {
    }
  }

  public static void checkDelHash(MyHashTable hash, int minute, bool isTrue)
  {
    MyVector myVector = new MyVector(nameof (checkDelHash));
    if (isTrue)
    {
      hash.clear();
    }
    else
    {
      IDictionaryEnumerator enumerator = hash.GetEnumerator();
      while (enumerator.MoveNext())
      {
        MainImage mainImage = (MainImage) enumerator.Value;
        if (GameCanvas.timeNow / 1000L - mainImage.count > (long) (minute * 60))
        {
          string key = (string) enumerator.Key;
          myVector.addElement((object) key);
        }
      }
      for (int index = 0; index < myVector.size(); ++index)
        hash.remove((object) (string) myVector.elementAt(index));
    }
  }
}
