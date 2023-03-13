// Decompiled with JetBrains decompiler
// Type: SmallImage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.e;
using System;

public class SmallImage
{
  public static int[][] smallImg;
  public static SmallImage instance;
  public static Image[] imgbig;
  public static Small[] imgNew;
  public static MyVector vKeys = new MyVector();
  public static Image imgEmpty = (Image) null;
  public static sbyte[] newSmallVersion;
  public static int smallCount;
  public static short maxSmall;

  public SmallImage() => this.readImage();

  public static void loadBigRMS()
  {
    if (SmallImage.imgbig != null)
      return;
    SmallImage.imgbig = new Image[5]
    {
      GameCanvas.loadImageRMS("/img/Big0.png"),
      GameCanvas.loadImageRMS("/img/Big1.png"),
      GameCanvas.loadImageRMS("/img/Big2.png"),
      GameCanvas.loadImageRMS("/img/Big3.png"),
      GameCanvas.loadImageRMS("/img/Big4.png")
    };
  }

  public static void freeBig()
  {
    SmallImage.imgbig = (Image[]) null;
    mSystem.gcc();
  }

  public static void loadBigImage() => SmallImage.imgEmpty = Image.createRGBImage(new int[1], 1, 1, true);

  public static void init()
  {
    SmallImage.instance = (SmallImage) null;
    SmallImage.instance = new SmallImage();
  }

  public void readData(byte[] data)
  {
  }

  public void readImage()
  {
    int num = 0;
    try
    {
      DataInputStream dataInputStream = new DataInputStream(Rms.loadRMS("NR_image"));
      short length = dataInputStream.readShort();
      SmallImage.smallImg = new int[(int) length][];
      for (int index = 0; index < SmallImage.smallImg.Length; ++index)
        SmallImage.smallImg[index] = new int[5];
      for (int index = 0; index < (int) length; ++index)
      {
        ++num;
        SmallImage.smallImg[index][0] = dataInputStream.readUnsignedByte();
        SmallImage.smallImg[index][1] = (int) dataInputStream.readShort();
        SmallImage.smallImg[index][2] = (int) dataInputStream.readShort();
        SmallImage.smallImg[index][3] = (int) dataInputStream.readShort();
        SmallImage.smallImg[index][4] = (int) dataInputStream.readShort();
      }
    }
    catch (Exception ex)
    {
      Cout.LogError3("Loi readImage: " + ex.ToString() + "i= " + (object) num);
    }
  }

  public static void clearHastable()
  {
  }

  public static void createImage(int id)
  {
    Res.outz("is request =" + (object) id + " zoom=" + (object) mGraphics.zoomLevel);
    if (mGraphics.zoomLevel == 1)
    {
      Image img = GameCanvas.loadImage("/SmallImage/Small" + (object) id + ".png");
      if (img != null)
      {
        SmallImage.imgNew[id] = new Small(img, id);
      }
      else
      {
        SmallImage.imgNew[id] = new Small(SmallImage.imgEmpty, id);
        Service.gI().requestIcon(id);
      }
    }
    else
    {
      Image img = GameCanvas.loadImage("/SmallImage/Small" + (object) id + ".png");
      if (img != null)
      {
        SmallImage.imgNew[id] = new Small(img, id);
      }
      else
      {
        bool flag = false;
        sbyte[] imageData = Rms.loadRMS(mGraphics.zoomLevel.ToString() + "Small" + (object) id);
        if (imageData != null)
        {
          if (SmallImage.newSmallVersion != null && imageData.Length % (int) sbyte.MaxValue != (int) SmallImage.newSmallVersion[id])
            flag = true;
          if (!flag)
          {
            Image image = Image.createImage(imageData, 0, imageData.Length);
            if (image != null)
              SmallImage.imgNew[id] = new Small(image, id);
            else
              flag = true;
          }
        }
        else
          flag = true;
        if (!flag)
          return;
        SmallImage.imgNew[id] = new Small(SmallImage.imgEmpty, id);
        Service.gI().requestIcon(id);
      }
    }
  }

  public static void drawSmallImage(
    mGraphics g,
    int id,
    int x,
    int y,
    int transform,
    int anchor)
  {
    if (SmallImage.imgbig == null)
    {
      Small img = SmallImage.imgNew[id];
      if (img == null)
        SmallImage.createImage(id);
      else
        g.drawRegion(img, 0, 0, mGraphics.getImageWidth(img.img), mGraphics.getImageHeight(img.img), transform, x, y, anchor);
    }
    else if (SmallImage.smallImg != null)
    {
      if (id >= SmallImage.smallImg.Length || SmallImage.smallImg[id][1] >= 256 || SmallImage.smallImg[id][3] >= 256 || SmallImage.smallImg[id][2] >= 256 || SmallImage.smallImg[id][4] >= 256)
      {
        Small small = SmallImage.imgNew[id];
        if (small == null)
          SmallImage.createImage(id);
        else
          small.paint(g, transform, x, y, anchor);
      }
      else
      {
        if (SmallImage.imgbig[SmallImage.smallImg[id][0]] == null)
          return;
        g.drawRegion(SmallImage.imgbig[SmallImage.smallImg[id][0]], SmallImage.smallImg[id][1], SmallImage.smallImg[id][2], SmallImage.smallImg[id][3], SmallImage.smallImg[id][4], transform, x, y, anchor);
      }
    }
    else
    {
      if (GameCanvas.currentScreen == GameScr.gI())
        return;
      Small small = SmallImage.imgNew[id];
      if (small == null)
        SmallImage.createImage(id);
      else
        small.paint(g, transform, x, y, anchor);
    }
  }

  public static void drawSmallImage(
    mGraphics g,
    int id,
    int f,
    int x,
    int y,
    int w,
    int h,
    int transform,
    int anchor)
  {
    if (SmallImage.imgbig == null)
    {
      Small small = SmallImage.imgNew[id];
      if (small == null)
        SmallImage.createImage(id);
      else
        g.drawRegion(small.img, 0, f * w, w, h, transform, x, y, anchor);
    }
    else if (SmallImage.smallImg != null)
    {
      if (id >= SmallImage.smallImg.Length || SmallImage.smallImg[id] == null || SmallImage.smallImg[id][1] >= 256 || SmallImage.smallImg[id][3] >= 256 || SmallImage.smallImg[id][2] >= 256 || SmallImage.smallImg[id][4] >= 256)
      {
        Small small = SmallImage.imgNew[id];
        if (small == null)
          SmallImage.createImage(id);
        else
          small.paint(g, transform, f, x, y, w, h, anchor);
      }
      else if (SmallImage.smallImg[id][0] != 4 && SmallImage.imgbig[SmallImage.smallImg[id][0]] != null)
      {
        g.drawRegion(SmallImage.imgbig[SmallImage.smallImg[id][0]], 0, f * w, w, h, transform, x, y, anchor);
      }
      else
      {
        Small small = SmallImage.imgNew[id];
        if (small == null)
          SmallImage.createImage(id);
        else
          small.paint(g, transform, f, x, y, w, h, anchor);
      }
    }
    else
    {
      if (GameCanvas.currentScreen == GameScr.gI())
        return;
      Small small = SmallImage.imgNew[id];
      if (small == null)
        SmallImage.createImage(id);
      else
        small.paint(g, transform, f, x, y, w, h, anchor);
    }
  }

  public static void update()
  {
    int num = 0;
    if (GameCanvas.gameTick % 1000 != 0)
      return;
    for (int index = 0; index < SmallImage.imgNew.Length; ++index)
    {
      if (SmallImage.imgNew[index] != null)
      {
        ++num;
        SmallImage.imgNew[index].update();
        ++SmallImage.smallCount;
      }
    }
    if (num <= 200 || !GameCanvas.lowGraphic)
      return;
    SmallImage.imgNew = new Small[(int) SmallImage.maxSmall];
  }
}
