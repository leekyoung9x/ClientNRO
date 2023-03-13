// Decompiled with JetBrains decompiler
// Type: MotherCanvas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class MotherCanvas
{
  public static MotherCanvas instance;
  public GameCanvas tCanvas;
  public int zoomLevel = 1;
  public Image imgCache;
  private int[] imgRGBCache;
  private int newWidth;
  private int newHeight;
  private int[] output;
  private int OUTPUTSIZE = 20;

  public MotherCanvas() => this.checkZoomLevel(this.getWidth(), this.getHeight());

  public void checkZoomLevel(int w, int h)
  {
    if (Main.isWindowsPhone)
    {
      mGraphics.zoomLevel = 2;
      if (w * h >= 2073600)
      {
        mGraphics.zoomLevel = 4;
      }
      else
      {
        if (w * h <= 384000)
          return;
        mGraphics.zoomLevel = 3;
      }
    }
    else if (!Main.isPC)
    {
      if (Main.isIpod)
        mGraphics.zoomLevel = 2;
      else if (w * h >= 2073600)
        mGraphics.zoomLevel = 4;
      else if (w * h >= 691200)
      {
        mGraphics.zoomLevel = 3;
      }
      else
      {
        if (w * h <= 153600)
          return;
        mGraphics.zoomLevel = 2;
      }
    }
    else
    {
      mGraphics.zoomLevel = 2;
      if (w * h >= 480000)
        return;
      mGraphics.zoomLevel = 1;
    }
  }

  public int getWidth() => (int) ScaleGUI.WIDTH;

  public int getHeight() => (int) ScaleGUI.HEIGHT;

  public void setChildCanvas(GameCanvas tCanvas) => this.tCanvas = tCanvas;

  protected void paint(mGraphics g) => this.tCanvas.paint(g);

  protected void keyPressed(int keyCode) => this.tCanvas.keyPressedz(keyCode);

  protected void keyReleased(int keyCode) => this.tCanvas.keyReleasedz(keyCode);

  protected void pointerDragged(int x, int y)
  {
    x /= mGraphics.zoomLevel;
    y /= mGraphics.zoomLevel;
    this.tCanvas.pointerDragged(x, y);
  }

  protected void pointerPressed(int x, int y)
  {
    x /= mGraphics.zoomLevel;
    y /= mGraphics.zoomLevel;
    this.tCanvas.pointerPressed(x, y);
  }

  protected void pointerReleased(int x, int y)
  {
    x /= mGraphics.zoomLevel;
    y /= mGraphics.zoomLevel;
    this.tCanvas.pointerReleased(x, y);
  }

  public int getWidthz()
  {
    int width = this.getWidth();
    return width / mGraphics.zoomLevel + width % mGraphics.zoomLevel;
  }

  public int getHeightz()
  {
    int height = this.getHeight();
    return height / mGraphics.zoomLevel + height % mGraphics.zoomLevel;
  }
}
