// Decompiled with JetBrains decompiler
// Type: BgItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class BgItem
{
  public int id;
  public int trans;
  public short idImage;
  public int x;
  public int y;
  public int dx;
  public int dy;
  public sbyte layer;
  public int nTilenotMove;
  public int[] tileX;
  public int[] tileY;
  public static MyHashTable imgNew = new MyHashTable();
  public static MyVector vKeysNew = new MyVector();
  public static MyVector vKeysLast = new MyVector();
  private bool isBlur;
  public int transX;
  public int transY;
  public static int[] idNotBlend = new int[61]
  {
    79,
    80,
    81,
    82,
    83,
    84,
    85,
    86,
    87,
    88,
    89,
    90,
    91,
    92,
    95,
    144,
    99,
    100,
    101,
    102,
    103,
    104,
    105,
    106,
    107,
    108,
    109,
    110,
    111,
    112,
    113,
    114,
    115,
    117,
    118,
    119,
    120,
    121,
    122,
    123,
    124,
    125,
    126,
    (int) sbyte.MaxValue,
    132,
    133,
    134,
    139,
    140,
    141,
    142,
    143,
    144,
    145,
    146,
    147,
    171,
    121,
    122,
    229,
    218
  };
  public static int[] isMiniBgz = new int[18]
  {
    79,
    80,
    81,
    85,
    86,
    90,
    91,
    92,
    99,
    100,
    101,
    102,
    103,
    104,
    105,
    106,
    107,
    108
  };
  public static sbyte[] newSmallVersion;

  public static void clearHashTable()
  {
  }

  public static bool isExistKeyNews(string keyNew)
  {
    for (int index = 0; index < BgItem.vKeysNew.size(); ++index)
    {
      if (((string) BgItem.vKeysNew.elementAt(index)).Equals(keyNew))
        return true;
    }
    return false;
  }

  public static bool isExistKeyLast(string keyLast)
  {
    for (int index = 0; index < BgItem.vKeysLast.size(); ++index)
    {
      if (((string) BgItem.vKeysLast.elementAt(index)).Equals(keyLast))
        return true;
    }
    return false;
  }

  public bool isNotBlend()
  {
    if (mGraphics.zoomLevel == 1 || TileMap.isInAirMap())
      return true;
    for (int index = 0; index < BgItem.idNotBlend.Length; ++index)
    {
      if ((int) this.idImage == BgItem.idNotBlend[index])
        return true;
    }
    return false;
  }

  public bool isMiniBg()
  {
    for (int index = 0; index < BgItem.isMiniBgz.Length; ++index)
    {
      if ((int) this.idImage == BgItem.isMiniBgz[index])
        return true;
    }
    return false;
  }

  public void changeColor()
  {
    if (this.isNotBlend() || this.layer == (sbyte) 2 || this.layer == (sbyte) 4 || BgItem.imgNew.containsKey((object) (this.idImage.ToString() + "blend" + (object) this.layer)))
      return;
    Image img = (Image) BgItem.imgNew.get((object) (this.idImage.ToString() + string.Empty));
    if (img == null || img.getRealImageWidth() <= 4)
      return;
    sbyte[] imageData = Rms.loadRMS("x" + (object) mGraphics.zoomLevel + "blend" + (object) this.idImage + "layer" + (object) this.layer);
    if (imageData == null)
    {
      BgItem.imgNew.put((object) (this.idImage.ToString() + "blend" + (object) this.layer), (object) BgItemMn.blendImage(img, (int) this.layer, (int) this.idImage));
    }
    else
    {
      Image image = Image.createImage(imageData, 0, imageData.Length);
      BgItem.imgNew.put((object) (this.idImage.ToString() + "blend" + (object) this.layer), (object) image);
    }
  }

  public void paint(mGraphics g)
  {
    if (Char.isLoadingMap || this.idImage == (short) 279 && GameScr.gI().tMabuEff >= 110)
      return;
    int cmx = GameScr.cmx;
    int cmy = GameScr.cmy;
    Image image = this.layer == (sbyte) 2 || this.layer == (sbyte) 4 ? (Image) BgItem.imgNew.get((object) (this.idImage.ToString() + string.Empty)) : (this.isNotBlend() ? (Image) BgItem.imgNew.get((object) (this.idImage.ToString() + string.Empty)) : (Image) BgItem.imgNew.get((object) (this.idImage.ToString() + "blend" + (object) this.layer)));
    if (image == null || this.idImage == (short) 96)
      return;
    if (this.layer == (sbyte) 4)
      this.transX = -cmx / 2 + 100;
    if (this.idImage == (short) 28 && this.layer == (sbyte) 3)
      this.transX = -cmx / 3 + 200;
    if ((this.idImage == (short) 67 || this.idImage == (short) 68 || this.idImage == (short) 69 || this.idImage == (short) 70) && this.layer == (sbyte) 3)
      this.transX = -cmx / 3 + 200;
    if (this.isMiniBg() && this.layer < (sbyte) 4)
    {
      this.transX = -(cmx >> 4) + 50;
      this.transY = (cmy >> 5) - 15;
    }
    int x = this.x + this.dx + this.transX;
    int num = this.y + this.dy + this.transY;
    if (this.x + this.dx + image.getWidth() + this.transX >= cmx && this.x + this.dx + this.transX <= cmx + GameCanvas.w && this.y + this.dy + this.transY + image.getHeight() >= cmy && this.y + this.dy + this.transY <= cmy + GameCanvas.h)
    {
      g.drawRegion(image, 0, 0, mGraphics.getImageWidth(image), mGraphics.getImageHeight(image), this.trans, this.x + this.dx + this.transX, this.y + this.dy + this.transY, 0);
      if (this.idImage == (short) 11 && TileMap.mapID != 122)
      {
        g.setClip(x, num + 24, 48, 14);
        for (int index = 0; index < 2; ++index)
          g.drawRegion(TileMap.imgWaterflow, 0, (GameCanvas.gameTick % 8 >> 2) * 24, 24, 24, 0, x + index * 24, num + 24, 0);
        g.setClip(GameScr.cmx, GameScr.cmy, GameScr.gW, GameScr.gH);
      }
    }
    if (!TileMap.isDoubleMap() || this.idImage <= (short) 137 || this.idImage == (short) 156 || this.idImage == (short) 159 || this.idImage == (short) 157 || this.idImage == (short) 165 || this.idImage == (short) 167 || this.idImage == (short) 168 || this.idImage == (short) 169 || this.idImage == (short) 170 || this.idImage == (short) 238 || TileMap.pxw - (this.x + this.dx + this.transX) < cmx || TileMap.pxw - (this.x + this.dx + this.transX + image.getWidth()) > cmx + GameCanvas.w || this.y + this.dy + this.transY + image.getHeight() < cmy || this.y + this.dy + this.transY > cmy + GameCanvas.h || this.idImage >= (short) 241 && this.idImage < (short) 266)
      return;
    g.drawRegion(image, 0, 0, mGraphics.getImageWidth(image), mGraphics.getImageHeight(image), 2, TileMap.pxw - (this.x + this.dx + this.transX), this.y + this.dy + this.transY, StaticObj.TOP_RIGHT);
  }
}
