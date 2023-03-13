// Decompiled with JetBrains decompiler
// Type: FrameImage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class FrameImage
{
  public int frameWidth;
  public int frameHeight;
  public int nFrame;
  public Image imgFrame;
  public int Id = -1;
  public int numWidth;
  public int numHeight;

  public FrameImage(int ID)
  {
    this.Id = ID;
    Image image = Effect_End.getImage(ID);
    if (image == null)
      return;
    this.imgFrame = image;
    this.frameWidth = (int) Effect_End.arrInfoEff[ID][0];
    this.frameHeight = (int) Effect_End.arrInfoEff[ID][1] / (int) Effect_End.arrInfoEff[ID][2];
    this.nFrame = (int) Effect_End.arrInfoEff[ID][2];
  }

  public FrameImage(Image img, int width, int height)
  {
    if (img == null)
      return;
    this.imgFrame = img;
    this.frameWidth = width;
    this.frameHeight = height;
    this.nFrame = img.getHeight() / height;
    if (this.nFrame >= 1)
      return;
    this.nFrame = 1;
  }

  public FrameImage(Image img, int numW, int numH, int numNull)
  {
    if (img == null)
      return;
    this.imgFrame = img;
    this.numWidth = numW;
    this.numHeight = numH;
    this.frameWidth = this.imgFrame.getWidth() / numW;
    this.frameHeight = this.imgFrame.getHeight() / numH;
    this.nFrame = numW * numH - numNull;
  }

  public void drawFrame(int idx, int x, int y, int trans, int anchor, mGraphics g)
  {
    try
    {
      if (this.imgFrame == null)
        return;
      if (idx > this.nFrame)
        idx = this.nFrame;
      int num1 = idx * this.frameHeight;
      if (num1 > this.frameHeight * (this.nFrame - 1) || num1 < 0)
      {
        int num2 = this.frameHeight * (this.nFrame - 1);
      }
      g.drawRegion(this.imgFrame, 0, idx * this.frameHeight, this.frameWidth, this.frameHeight, trans, x, y, anchor);
    }
    catch (Exception ex)
    {
    }
  }
}
