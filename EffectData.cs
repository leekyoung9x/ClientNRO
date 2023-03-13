// Decompiled with JetBrains decompiler
// Type: EffectData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class EffectData
{
  public Image img;
  public ImageInfo[] imgInfo;
  public Frame[] frame;
  public short[] arrFrame;
  public int ID;
  public int typeData;
  public int width;
  public int height;

  public ImageInfo getImageInfo(sbyte id)
  {
    for (int index = 0; index < this.imgInfo.Length; ++index)
    {
      if (this.imgInfo[index].ID == (int) id)
        return this.imgInfo[index];
    }
    return (ImageInfo) null;
  }

  public void readData(string patch)
  {
    DataInputStream dataInputStream;
    try
    {
      dataInputStream = MyStream.readFile(patch);
    }
    catch (Exception ex)
    {
      return;
    }
    this.readData(dataInputStream.r);
  }

  public void readData2(string patch)
  {
    DataInputStream dataInputStream;
    try
    {
      dataInputStream = MyStream.readFile(patch);
    }
    catch (Exception ex)
    {
      return;
    }
    this.readEffect(dataInputStream.r);
  }

  public void readEffect(myReader msg)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    try
    {
      sbyte length1 = msg.readByte();
      Res.outz("size IMG==========" + (object) length1);
      this.imgInfo = new ImageInfo[(int) length1];
      for (int index = 0; index < (int) length1; ++index)
      {
        this.imgInfo[index] = new ImageInfo();
        this.imgInfo[index].ID = (int) msg.readByte();
        this.imgInfo[index].x0 = (int) msg.readUnsignedByte();
        this.imgInfo[index].y0 = (int) msg.readUnsignedByte();
        this.imgInfo[index].w = (int) msg.readUnsignedByte();
        this.imgInfo[index].h = (int) msg.readUnsignedByte();
      }
      this.frame = new Frame[(int) msg.readShort()];
      for (int index1 = 0; index1 < this.frame.Length; ++index1)
      {
        this.frame[index1] = new Frame();
        sbyte length2 = msg.readByte();
        this.frame[index1].dx = new short[(int) length2];
        this.frame[index1].dy = new short[(int) length2];
        this.frame[index1].idImg = new sbyte[(int) length2];
        for (int index2 = 0; index2 < (int) length2; ++index2)
        {
          this.frame[index1].dx[index2] = msg.readShort();
          this.frame[index1].dy[index2] = msg.readShort();
          this.frame[index1].idImg[index2] = msg.readByte();
          if (index1 == 0)
          {
            if (num1 > (int) this.frame[index1].dx[index2])
              num1 = (int) this.frame[index1].dx[index2];
            if (num2 > (int) this.frame[index1].dy[index2])
              num2 = (int) this.frame[index1].dy[index2];
            if (num3 < (int) this.frame[index1].dx[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].w)
              num3 = (int) this.frame[index1].dx[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].w;
            if (num4 < (int) this.frame[index1].dy[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].h)
              num4 = (int) this.frame[index1].dy[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].h;
            this.width = num3 - num1;
            this.height = num4 - num2;
          }
        }
      }
      this.arrFrame = new short[(int) msg.readShort()];
      for (int index = 0; index < this.arrFrame.Length; ++index)
        this.arrFrame[index] = msg.readShort();
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
      Res.outz("1");
    }
  }

  public void readData(myReader iss)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    try
    {
      sbyte length1 = iss.readByte();
      this.imgInfo = new ImageInfo[(int) length1];
      for (int index = 0; index < (int) length1; ++index)
      {
        this.imgInfo[index] = new ImageInfo();
        this.imgInfo[index].ID = (int) iss.readByte();
        this.imgInfo[index].x0 = (int) iss.readByte();
        this.imgInfo[index].y0 = (int) iss.readByte();
        this.imgInfo[index].w = (int) iss.readByte();
        this.imgInfo[index].h = (int) iss.readByte();
      }
      short length2 = iss.readShort();
      this.frame = new Frame[(int) length2];
      for (int index1 = 0; index1 < (int) length2; ++index1)
      {
        this.frame[index1] = new Frame();
        sbyte length3 = iss.readByte();
        this.frame[index1].dx = new short[(int) length3];
        this.frame[index1].dy = new short[(int) length3];
        this.frame[index1].idImg = new sbyte[(int) length3];
        for (int index2 = 0; index2 < (int) length3; ++index2)
        {
          this.frame[index1].dx[index2] = iss.readShort();
          this.frame[index1].dy[index2] = iss.readShort();
          this.frame[index1].idImg[index2] = iss.readByte();
          if (index1 == 0)
          {
            if (num1 > (int) this.frame[index1].dx[index2])
              num1 = (int) this.frame[index1].dx[index2];
            if (num2 > (int) this.frame[index1].dy[index2])
              num2 = (int) this.frame[index1].dy[index2];
            if (num3 < (int) this.frame[index1].dx[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].w)
              num3 = (int) this.frame[index1].dx[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].w;
            if (num4 < (int) this.frame[index1].dy[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].h)
              num4 = (int) this.frame[index1].dy[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].h;
            this.width = num3 - num1;
            this.height = num4 - num2;
          }
        }
      }
      short length4 = iss.readShort();
      this.arrFrame = new short[(int) length4];
      for (int index = 0; index < (int) length4; ++index)
        this.arrFrame[index] = iss.readShort();
    }
    catch (Exception ex)
    {
      Cout.LogError("LOI TAI readData cua EffectDAta" + ex.ToString());
    }
  }

  public void readData(sbyte[] data) => this.readData(new myReader(data));

  public void readDataNewBoss(sbyte[] data, sbyte typeread) => this.readMobNew(new myReader(data), typeread);

  public void paintFrame(mGraphics g, int f, int x, int y, int trans, int layer)
  {
    if (this.frame == null || this.frame.Length == 0)
      return;
    Frame frame = this.frame[f];
    for (int index = 0; index < frame.dx.Length; ++index)
    {
      ImageInfo imageInfo = this.getImageInfo(frame.idImg[index]);
      try
      {
        if (trans == -1)
          g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 0, x + (int) frame.dx[index], y + (int) frame.dy[index], 0);
        if (trans == 0)
          g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 0, x + (int) frame.dx[index], y + (int) frame.dy[index] - (layer >= 4 || layer <= 0 ? 0 : GameCanvas.transY), 0);
        if (trans == 1)
          g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 2, x - (int) frame.dx[index], y + (int) frame.dy[index] - (layer >= 4 || layer <= 0 ? 0 : GameCanvas.transY), StaticObj.TOP_RIGHT);
        if (trans == 2)
          g.drawRegion(this.img, imageInfo.x0, imageInfo.y0, imageInfo.w, imageInfo.h, 7, x - (int) frame.dx[index], y + (int) frame.dy[index] - (layer >= 4 || layer <= 0 ? 0 : GameCanvas.transY), StaticObj.VCENTER_HCENTER);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void readMobNew(myReader msg, sbyte typeread)
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    try
    {
      sbyte length1 = msg.readByte();
      this.imgInfo = new ImageInfo[(int) length1];
      for (int index = 0; index < (int) length1; ++index)
      {
        this.imgInfo[index] = new ImageInfo();
        this.imgInfo[index].ID = (int) msg.readByte();
        if (typeread == (sbyte) 1)
        {
          this.imgInfo[index].x0 = (int) msg.readUnsignedByte();
          this.imgInfo[index].y0 = (int) msg.readUnsignedByte();
        }
        else
        {
          this.imgInfo[index].x0 = (int) msg.readShort();
          this.imgInfo[index].y0 = (int) msg.readShort();
        }
        this.imgInfo[index].w = (int) msg.readUnsignedByte();
        this.imgInfo[index].h = (int) msg.readUnsignedByte();
      }
      this.frame = new Frame[(int) msg.readShort()];
      for (int index1 = 0; index1 < this.frame.Length; ++index1)
      {
        this.frame[index1] = new Frame();
        sbyte length2 = msg.readByte();
        this.frame[index1].dx = new short[(int) length2];
        this.frame[index1].dy = new short[(int) length2];
        this.frame[index1].idImg = new sbyte[(int) length2];
        for (int index2 = 0; index2 < (int) length2; ++index2)
        {
          this.frame[index1].dx[index2] = msg.readShort();
          this.frame[index1].dy[index2] = msg.readShort();
          this.frame[index1].idImg[index2] = msg.readByte();
          if (index1 == 0)
          {
            if (num1 > (int) this.frame[index1].dx[index2])
              num1 = (int) this.frame[index1].dx[index2];
            if (num2 > (int) this.frame[index1].dy[index2])
              num2 = (int) this.frame[index1].dy[index2];
            if (num3 < (int) this.frame[index1].dx[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].w)
              num3 = (int) this.frame[index1].dx[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].w;
            if (num4 < (int) this.frame[index1].dy[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].h)
              num4 = (int) this.frame[index1].dy[index2] + this.imgInfo[(int) this.frame[index1].idImg[index2]].h;
            this.width = num3 - num1;
            this.height = num4 - num2;
          }
        }
      }
      this.arrFrame = new short[(int) msg.readShort()];
      for (int index = 0; index < this.arrFrame.Length; ++index)
        this.arrFrame[index] = msg.readShort();
    }
    catch (Exception ex)
    {
    }
  }
}
