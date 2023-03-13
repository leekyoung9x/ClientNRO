// Decompiled with JetBrains decompiler
// Type: BgItemMn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class BgItemMn
{
  public static Image blendImage(Image img, int layer, int idImage)
  {
    int num = TileMap.tileID - 1;
    Image img1 = img;
    if (num == 0 && layer == 1)
      img1 = mGraphics.blend(img, 0.3f, 807956);
    if (num == 1 && layer == 1)
      img1 = mGraphics.blend(img, 0.35f, 739339);
    if (num == 2 && layer == 1)
      img1 = mGraphics.blend(img, 0.1f, 3977975);
    if (num == 3)
    {
      if (layer == 1)
        img1 = mGraphics.blend(img, 0.2f, 15265992);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.1f, 15265992);
    }
    if (num == 4)
    {
      if (layer == 1)
        img1 = mGraphics.blend(img, 0.3f, 1330178);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.1f, 1330178);
    }
    if (num == 6)
    {
      if (layer == 1)
        img1 = mGraphics.blend(img, 0.3f, 420382);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.15f, 420382);
    }
    if (num == 5)
    {
      if (layer == 1)
        img1 = mGraphics.blend(img, 0.35f, 3270903);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.15f, 3270903);
    }
    if (num == 8)
    {
      if (layer == 1)
        img1 = mGraphics.blend(img, 0.3f, 7094528);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.15f, 7094528);
    }
    if (num == 9)
    {
      if (layer == 1)
        img1 = mGraphics.blend(img, 0.3f, 12113627);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.15f, 12113627);
    }
    if (num == 10 && layer == 1)
      img1 = mGraphics.blend(img, 0.3f, 14938312);
    if (num == 10 && layer == 1)
      img1 = mGraphics.blend(img, 0.2f, 14938312);
    if (num == 11)
    {
      if (layer == 1)
        img1 = mGraphics.blend(img, 0.3f, 0);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.15f, 0);
    }
    if (num > 11)
    {
      if (layer == 1 || layer == 2)
        img1 = mGraphics.blend(img, 0.3f, 0);
      if (layer == 3)
        img1 = mGraphics.blend(img, 0.15f, 0);
    }
    byte[] byteArray = BgItemMn.getByteArray(img1);
    Rms.saveRMS("x" + (object) mGraphics.zoomLevel + "blend" + (object) idImage + nameof (layer) + (object) layer, ArrayCast.cast(byteArray));
    return img1;
  }

  public static byte[] getByteArray(Image img)
  {
    try
    {
      return img.texture.EncodeToPNG();
    }
    catch (Exception ex)
    {
      return (byte[]) null;
    }
  }

  public static void blendcurrBg(short id, Image img)
  {
    for (int index = 0; index < TileMap.vCurrItem.size(); ++index)
    {
      BgItem bgItem = (BgItem) TileMap.vCurrItem.elementAt(index);
      if ((int) bgItem.idImage == (int) id && !bgItem.isNotBlend() && bgItem.layer != (sbyte) 2 && bgItem.layer != (sbyte) 4 && !BgItem.imgNew.containsKey((object) (bgItem.idImage.ToString() + "blend" + (object) bgItem.layer)))
      {
        sbyte[] imageData = Rms.loadRMS("x" + (object) mGraphics.zoomLevel + "blend" + (object) id + "layer" + (object) bgItem.layer);
        if (imageData == null)
        {
          BgItem.imgNew.put((object) (bgItem.idImage.ToString() + "blend" + (object) bgItem.layer), (object) BgItemMn.blendImage(img, (int) bgItem.layer, (int) bgItem.idImage));
        }
        else
        {
          Image image = Image.createImage(imageData, 0, imageData.Length);
          BgItem.imgNew.put((object) (bgItem.idImage.ToString() + "blend" + (object) bgItem.layer), (object) image);
        }
      }
    }
  }
}
