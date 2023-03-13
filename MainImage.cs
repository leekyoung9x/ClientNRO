// Decompiled with JetBrains decompiler
// Type: MainImage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class MainImage
{
  public Image img;
  public long count = -1;
  public int timeImageNull;
  public int idImage;
  public long timerequest;
  public sbyte nFrame = 1;
  public long timeUse = mSystem.currentTimeMillis();

  public MainImage()
  {
  }

  public MainImage(Image im, sbyte nFrame)
  {
    this.img = im;
    this.count = 0L;
    this.nFrame = nFrame;
  }
}
