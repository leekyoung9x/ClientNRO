// Decompiled with JetBrains decompiler
// Type: mGraphics
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.e;
using System;
using System.Collections;
using UnityEngine;

public class mGraphics
{
  public static int HCENTER = 1;
  public static int VCENTER = 2;
  public static int LEFT = 4;
  public static int RIGHT = 8;
  public static int TOP = 16;
  public static int BOTTOM = 32;
  private float r;
  private float g;
  private float b;
  private float a;
  public int clipX;
  public int clipY;
  public int clipW;
  public int clipH;
  private bool isClip;
  private bool isTranslate = true;
  private int translateX;
  private int translateY;
  private float translateXf;
  private float translateYf;
  public static int zoomLevel = 1;
  public const int BASELINE = 64;
  public const int SOLID = 0;
  public const int DOTTED = 1;
  public const int TRANS_MIRROR = 2;
  public const int TRANS_MIRROR_ROT180 = 1;
  public const int TRANS_MIRROR_ROT270 = 4;
  public const int TRANS_MIRROR_ROT90 = 7;
  public const int TRANS_NONE = 0;
  public const int TRANS_ROT180 = 3;
  public const int TRANS_ROT270 = 6;
  public const int TRANS_ROT90 = 5;
  public static Hashtable cachedTextures = new Hashtable();
  public static int addYWhenOpenKeyBoard;
  private int clipTX;
  private int clipTY;
  private int currentBGColor;
  private Vector2 pos = new Vector2(0.0f, 0.0f);
  private Rect rect;
  private Matrix4x4 matrixBackup;
  private Vector2 pivot;
  public Vector2 size = new Vector2(128f, 128f);
  public Vector2 relativePosition = new Vector2(0.0f, 0.0f);
  public Color clTrans;
  public static Color transParentColor = new Color(1f, 1f, 1f, 0.0f);
  private Material lineMaterial;

  private void cache(string key, Texture value)
  {
    if (mGraphics.cachedTextures.Count > 400)
      mGraphics.cachedTextures.Clear();
    if (value.width * value.height >= GameCanvas.w * GameCanvas.h)
      return;
    mGraphics.cachedTextures.Add((object) key, (object) value);
  }

  public void translate(int tx, int ty)
  {
    tx *= mGraphics.zoomLevel;
    ty *= mGraphics.zoomLevel;
    this.translateX += tx;
    this.translateY += ty;
    this.isTranslate = true;
    if (this.translateX != 0 || this.translateY != 0)
      return;
    this.isTranslate = false;
  }

  public void translate(float x, float y)
  {
    this.translateXf += x;
    this.translateYf += y;
    this.isTranslate = true;
    if ((double) this.translateXf != 0.0 || (double) this.translateYf != 0.0)
      return;
    this.isTranslate = false;
  }

  public int getTranslateX() => this.translateX / mGraphics.zoomLevel;

  public int getTranslateY() => this.translateY / mGraphics.zoomLevel + mGraphics.addYWhenOpenKeyBoard;

  public void setClip(int x, int y, int w, int h)
  {
    x *= mGraphics.zoomLevel;
    y *= mGraphics.zoomLevel;
    w *= mGraphics.zoomLevel;
    h *= mGraphics.zoomLevel;
    this.clipTX = this.translateX;
    this.clipTY = this.translateY;
    this.clipX = x;
    this.clipY = y;
    this.clipW = w;
    this.clipH = h;
    this.isClip = true;
  }

  public int getClipX() => GameScr.cmx;

  public int getClipY() => GameScr.cmy;

  public int getClipWidth() => GameScr.gW;

  public int getClipHeight() => GameScr.gH;

  public void fillRect(int x, int y, int w, int h, int color, int alpha)
  {
    float alpha1 = 0.5f;
    this.setColor(color, alpha1);
    this.fillRect(x, y, w, h);
  }

  public void drawLine(int x1, int y1, int x2, int y2)
  {
    x1 *= mGraphics.zoomLevel;
    y1 *= mGraphics.zoomLevel;
    x2 *= mGraphics.zoomLevel;
    y2 *= mGraphics.zoomLevel;
    if (y1 == y2)
    {
      if (x1 > x2)
      {
        int num = x2;
        x2 = x1;
        x1 = num;
      }
      this.fillRect(x1, y1, x2 - x1, 1);
    }
    else if (x1 == x2)
    {
      if (y1 > y2)
      {
        int num = y2;
        y2 = y1;
        y1 = num;
      }
      this.fillRect(x1, y1, 1, y2 - y1);
    }
    else
    {
      if (this.isTranslate)
      {
        x1 += this.translateX;
        y1 += this.translateY;
        x2 += this.translateX;
        y2 += this.translateY;
      }
      string key = "dl" + (object) this.r + (object) this.g + (object) this.b;
      Texture2D texture2D = (Texture2D) mGraphics.cachedTextures[(object) key];
      if ((UnityEngine.Object) texture2D == (UnityEngine.Object) null)
      {
        texture2D = new Texture2D(1, 1);
        Color color = new Color(this.r, this.g, this.b);
        texture2D.SetPixel(0, 0, color);
        texture2D.Apply();
        this.cache(key, (Texture) texture2D);
      }
      Vector2 pivotPoint = new Vector2((float) x1, (float) y1);
      Vector2 vector2 = new Vector2((float) x2, (float) y2) - pivotPoint;
      float angle = 57.29578f * Mathf.Atan(vector2.y / vector2.x);
      if ((double) vector2.x < 0.0)
        angle += 180f;
      int num = (int) Mathf.Ceil(0.0f);
      GUIUtility.RotateAroundPivot(angle, pivotPoint);
      int x = 0;
      int y = 0;
      int width = 0;
      int height = 0;
      if (this.isClip)
      {
        x = this.clipX;
        y = this.clipY;
        width = this.clipW;
        height = this.clipH;
        if (this.isTranslate)
        {
          x += this.clipTX;
          y += this.clipTY;
        }
      }
      if (this.isClip)
        GUI.BeginGroup(new Rect((float) x, (float) y, (float) width, (float) height));
      Graphics.DrawTexture(new Rect(pivotPoint.x - (float) x, pivotPoint.y - (float) num - (float) y, vector2.magnitude, 1f), (Texture) texture2D);
      if (this.isClip)
        GUI.EndGroup();
      GUIUtility.RotateAroundPivot(-angle, pivotPoint);
    }
  }

  public Color setColorMiniMap(int rgb)
  {
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    float b = (float) num1 / 256f;
    float g = (float) num2 / 256f;
    return new Color((float) num3 / 256f, g, b);
  }

  public float[] getRGB(Color cl) => new float[3]
  {
    256f * cl.r,
    256f * cl.g,
    256f * cl.b
  };

  public void drawRect(int x, int y, int w, int h)
  {
    int num = 1;
    this.fillRect(x, y, w, num);
    this.fillRect(x, y, num, h);
    this.fillRect(x + w, y, num, h + 1);
    this.fillRect(x, y + h, w + 1, num);
  }

  public void fillRect(int x, int y, int w, int h)
  {
    x *= mGraphics.zoomLevel;
    y *= mGraphics.zoomLevel;
    w *= mGraphics.zoomLevel;
    h *= mGraphics.zoomLevel;
    if (w < 0 || h < 0)
      return;
    if (this.isTranslate)
    {
      x += this.translateX;
      y += this.translateY;
    }
    int width1 = 1;
    int height1 = 1;
    string key = "fr" + (object) width1 + (object) height1 + (object) this.r + (object) this.g + (object) this.b + (object) this.a;
    Texture2D image = (Texture2D) mGraphics.cachedTextures[(object) key];
    if ((UnityEngine.Object) image == (UnityEngine.Object) null)
    {
      image = new Texture2D(width1, height1);
      Color color = new Color(this.r, this.g, this.b, this.a);
      image.SetPixel(0, 0, color);
      image.Apply();
      this.cache(key, (Texture) image);
    }
    int x1 = 0;
    int y1 = 0;
    int width2 = 0;
    int height2 = 0;
    if (this.isClip)
    {
      x1 = this.clipX;
      y1 = this.clipY;
      width2 = this.clipW;
      height2 = this.clipH;
      if (this.isTranslate)
      {
        x1 += this.clipTX;
        y1 += this.clipTY;
      }
    }
    if (this.isClip)
      GUI.BeginGroup(new Rect((float) x1, (float) y1, (float) width2, (float) height2));
    GUI.DrawTexture(new Rect((float) (x - x1), (float) (y - y1), (float) w, (float) h), (Texture) image);
    if (!this.isClip)
      return;
    GUI.EndGroup();
  }

  public void setColor(int rgb)
  {
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    this.b = (float) num1 / 256f;
    this.g = (float) num2 / 256f;
    this.r = (float) num3 / 256f;
    this.a = (float) byte.MaxValue;
  }

  public void setColor(Color color)
  {
    this.b = color.b;
    this.g = color.g;
    this.r = color.r;
  }

  public void setBgColor(int rgb)
  {
    if (rgb == this.currentBGColor)
      return;
    this.currentBGColor = rgb;
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    this.b = (float) num1 / 256f;
    this.g = (float) num2 / 256f;
    this.r = (float) num3 / 256f;
    Main.main.GetComponent<Camera>().backgroundColor = new Color(this.r, this.g, this.b);
  }

  public void drawString(string s, int x, int y, GUIStyle style)
  {
    x *= mGraphics.zoomLevel;
    y *= mGraphics.zoomLevel;
    if (this.isTranslate)
    {
      x += this.translateX;
      y += this.translateY;
    }
    int x1 = 0;
    int y1 = 0;
    int width = 0;
    int height = 0;
    if (this.isClip)
    {
      x1 = this.clipX;
      y1 = this.clipY;
      width = this.clipW;
      height = this.clipH;
      if (this.isTranslate)
      {
        x1 += this.clipTX;
        y1 += this.clipTY;
      }
    }
    if (this.isClip)
      GUI.BeginGroup(new Rect((float) x1, (float) y1, (float) width, (float) height));
    GUI.Label(new Rect((float) (x - x1), (float) (y - y1), ScaleGUI.WIDTH, 100f), s, style);
    if (!this.isClip)
      return;
    GUI.EndGroup();
  }

  public void setColor(int rgb, float alpha)
  {
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    this.b = (float) num1 / 256f;
    this.g = (float) num2 / 256f;
    this.r = (float) num3 / 256f;
    this.a = alpha;
  }

  public void drawString(string s, int x, int y, GUIStyle style, int w)
  {
    x *= mGraphics.zoomLevel;
    y *= mGraphics.zoomLevel;
    if (this.isTranslate)
    {
      x += this.translateX;
      y += this.translateY;
    }
    int x1 = 0;
    int y1 = 0;
    int width = 0;
    int height = 0;
    if (this.isClip)
    {
      x1 = this.clipX;
      y1 = this.clipY;
      width = this.clipW;
      height = this.clipH;
      if (this.isTranslate)
      {
        x1 += this.clipTX;
        y1 += this.clipTY;
      }
    }
    if (this.isClip)
      GUI.BeginGroup(new Rect((float) x1, (float) y1, (float) width, (float) height));
    GUI.Label(new Rect((float) (x - x1), (float) (y - y1 - 4), (float) w, 100f), s, style);
    if (!this.isClip)
      return;
    GUI.EndGroup();
  }

  private void UpdatePos(int anchor)
  {
    Vector2 vector2 = new Vector2(0.0f, 0.0f);
    switch (anchor)
    {
      case 3:
        vector2 = new Vector2(this.size.x / 2f, this.size.y / 2f);
        break;
      case 6:
        vector2 = new Vector2(0.0f, (float) (Screen.height / 2));
        break;
      default:
        switch (anchor - 17)
        {
          case 0:
            vector2 = new Vector2((float) (Screen.width / 2), 0.0f);
            break;
          case 3:
            vector2 = new Vector2(0.0f, 0.0f);
            break;
          default:
            switch (anchor - 33)
            {
              case 0:
                vector2 = new Vector2((float) (Screen.width / 2), (float) Screen.height);
                break;
              case 3:
                vector2 = new Vector2(0.0f, (float) Screen.height);
                break;
              default:
                if (anchor != 10)
                {
                  if (anchor != 24)
                  {
                    if (anchor == 40)
                    {
                      vector2 = new Vector2((float) Screen.width, (float) Screen.height);
                      break;
                    }
                    break;
                  }
                  vector2 = new Vector2((float) Screen.width, 0.0f);
                  break;
                }
                vector2 = new Vector2((float) Screen.width, (float) (Screen.height / 2));
                break;
            }
            break;
        }
        break;
    }
    this.pos = vector2 + this.relativePosition;
    this.rect = new Rect(this.pos.x - this.size.x * 0.5f, this.pos.y - this.size.y * 0.5f, this.size.x, this.size.y);
    this.pivot = new Vector2(this.rect.xMin + this.rect.width * 0.5f, this.rect.yMin + this.rect.height * 0.5f);
  }

  public void drawRegion(
    Image arg0,
    int x0,
    int y0,
    int w0,
    int h0,
    int arg5,
    int x,
    int y,
    int arg8)
  {
    x *= mGraphics.zoomLevel;
    y *= mGraphics.zoomLevel;
    x0 *= mGraphics.zoomLevel;
    y0 *= mGraphics.zoomLevel;
    w0 *= mGraphics.zoomLevel;
    h0 *= mGraphics.zoomLevel;
    this._drawRegion(arg0, (float) x0, (float) y0, w0, h0, arg5, x, y, arg8);
  }

  public void drawRegion(
    Image arg0,
    int x0,
    int y0,
    int w0,
    int h0,
    int arg5,
    float x,
    float y,
    int arg8)
  {
    x *= (float) mGraphics.zoomLevel;
    y *= (float) mGraphics.zoomLevel;
    x0 *= mGraphics.zoomLevel;
    y0 *= mGraphics.zoomLevel;
    w0 *= mGraphics.zoomLevel;
    h0 *= mGraphics.zoomLevel;
    this.__drawRegion(arg0, x0, y0, w0, h0, arg5, x, y, arg8);
  }

  public void drawRegion(
    Image arg0,
    int x0,
    int y0,
    int w0,
    int h0,
    int arg5,
    int x,
    int y,
    int arg8,
    bool isClip)
  {
    this.drawRegion(arg0, x0, y0, w0, h0, arg5, x, y, arg8);
  }

  public void __drawRegion(
    Image image,
    int x0,
    int y0,
    int w,
    int h,
    int transform,
    float x,
    float y,
    int anchor)
  {
    if (image == null)
      return;
    if (this.isTranslate)
    {
      x += (float) this.translateX;
      y += (float) this.translateY;
    }
    float num1 = (float) w;
    float num2 = (float) h;
    float num3 = 0.0f;
    float num4 = 0.0f;
    float num5 = 0.0f;
    float num6 = 0.0f;
    float num7 = 1f;
    float num8 = 0.0f;
    int num9 = 1;
    if ((anchor & mGraphics.HCENTER) == mGraphics.HCENTER)
      num5 -= num1 / 2f;
    if ((anchor & mGraphics.VCENTER) == mGraphics.VCENTER)
      num6 -= num2 / 2f;
    if ((anchor & mGraphics.RIGHT) == mGraphics.RIGHT)
      num5 -= num1;
    if ((anchor & mGraphics.BOTTOM) == mGraphics.BOTTOM)
      num6 -= num2;
    x += num5;
    y += num6;
    int x1 = 0;
    int width = 0;
    if (this.isClip)
    {
      x1 = this.clipX;
      int clipY = this.clipY;
      width = this.clipW;
      int clipH = this.clipH;
      if (this.isTranslate)
      {
        x1 += this.clipTX;
        clipY += this.clipTY;
      }
      Rect r1 = new Rect(x, y, (float) w, (float) h);
      Rect r2 = new Rect((float) x1, (float) clipY, (float) width, (float) clipH);
      Rect rect = this.intersectRect(r1, r2);
      if ((double) rect.width <= 0.0 || (double) rect.height <= 0.0)
        return;
      num1 = rect.width;
      num2 = rect.height;
      num3 = rect.x - r1.x;
      num4 = rect.y - r1.y;
    }
    float num10 = 0.0f;
    float num11 = 0.0f;
    switch (transform)
    {
      case 1:
        num9 = -1;
        num11 += num2;
        break;
      case 2:
        num10 += num1;
        num7 = -1f;
        if (this.isClip)
        {
          if ((double) x1 > (double) x)
          {
            num8 = -num3;
            break;
          }
          if ((double) (x1 + width) < (double) x + (double) w)
          {
            num8 = (float) -((double) (x1 + width) - (double) x - (double) w);
            break;
          }
          break;
        }
        break;
      case 3:
        num9 = -1;
        num11 += num2;
        num7 = -1f;
        num10 += num1;
        break;
    }
    int num12 = 0;
    int num13 = 0;
    if (transform == 5 || transform == 6 || transform == 4 || transform == 7)
    {
      this.matrixBackup = GUI.matrix;
      this.size = new Vector2((float) w, (float) h);
      this.relativePosition = new Vector2(x, y);
      this.UpdatePos(3);
      if (transform == 6)
        this.UpdatePos(3);
      else if (transform == 5)
      {
        this.size = new Vector2((float) w, (float) h);
        this.UpdatePos(3);
      }
      if (transform == 5)
        GUIUtility.RotateAroundPivot(90f, this.pivot);
      else if (transform == 6)
        GUIUtility.RotateAroundPivot(270f, this.pivot);
      else if (transform == 4)
      {
        GUIUtility.RotateAroundPivot(270f, this.pivot);
        num10 += num1;
        num7 = -1f;
        if (this.isClip)
        {
          if ((double) x1 > (double) x)
            num8 = -num3;
          else if ((double) (x1 + width) < (double) x + (double) w)
            num8 = (float) -((double) (x1 + width) - (double) x - (double) w);
        }
      }
      else if (transform == 7)
      {
        GUIUtility.RotateAroundPivot(270f, this.pivot);
        num9 = -1;
        num11 += num2;
      }
    }
    Graphics.DrawTexture(new Rect(x + num3 + num10 + (float) num12, y + num4 + (float) num13 + num11, num1 * num7, num2 * (float) num9), (Texture) image.texture, new Rect(((float) x0 + num3 + num8) / (float) image.texture.width, (float) ((double) image.texture.height - (double) num2 - ((double) y0 + (double) num4)) / (float) image.texture.height, num1 / (float) image.texture.width, num2 / (float) image.texture.height), 0, 0, 0, 0);
    if (transform != 5 && transform != 6 && transform != 4 && transform != 7)
      return;
    GUI.matrix = this.matrixBackup;
  }

  public void _drawRegion(
    Image image,
    float x0,
    float y0,
    int w,
    int h,
    int transform,
    int x,
    int y,
    int anchor)
  {
    if (image == null)
      return;
    if (this.isTranslate)
    {
      x += this.translateX;
      y += this.translateY;
    }
    float num1 = (float) w;
    float num2 = (float) h;
    float num3 = 0.0f;
    float num4 = 0.0f;
    float num5 = 0.0f;
    float num6 = 0.0f;
    float num7 = 1f;
    float num8 = 0.0f;
    int num9 = 1;
    if ((anchor & mGraphics.HCENTER) == mGraphics.HCENTER)
      num5 -= num1 / 2f;
    if ((anchor & mGraphics.VCENTER) == mGraphics.VCENTER)
      num6 -= num2 / 2f;
    if ((anchor & mGraphics.RIGHT) == mGraphics.RIGHT)
      num5 -= num1;
    if ((anchor & mGraphics.BOTTOM) == mGraphics.BOTTOM)
      num6 -= num2;
    x += (int) num5;
    y += (int) num6;
    int x1 = 0;
    int width = 0;
    if (this.isClip)
    {
      x1 = this.clipX;
      int clipY = this.clipY;
      width = this.clipW;
      int clipH = this.clipH;
      if (this.isTranslate)
      {
        x1 += this.clipTX;
        clipY += this.clipTY;
      }
      Rect r1 = new Rect((float) x, (float) y, (float) w, (float) h);
      Rect r2 = new Rect((float) x1, (float) clipY, (float) width, (float) clipH);
      Rect rect = this.intersectRect(r1, r2);
      if ((double) rect.width <= 0.0 || (double) rect.height <= 0.0)
        return;
      num1 = rect.width;
      num2 = rect.height;
      num3 = rect.x - r1.x;
      num4 = rect.y - r1.y;
    }
    float num10 = 0.0f;
    float num11 = 0.0f;
    switch (transform)
    {
      case 1:
        num9 = -1;
        num11 += num2;
        break;
      case 2:
        num10 += num1;
        num7 = -1f;
        if (this.isClip)
        {
          if (x1 > x)
          {
            num8 = -num3;
            break;
          }
          if (x1 + width < x + w)
          {
            num8 = (float) -(x1 + width - x - w);
            break;
          }
          break;
        }
        break;
      case 3:
        num9 = -1;
        num11 += num2;
        num7 = -1f;
        num10 += num1;
        break;
    }
    int num12 = 0;
    int num13 = 0;
    if (transform == 5 || transform == 6 || transform == 4 || transform == 7)
    {
      this.matrixBackup = GUI.matrix;
      this.size = new Vector2((float) w, (float) h);
      this.relativePosition = new Vector2((float) x, (float) y);
      this.UpdatePos(3);
      if (transform == 6)
        this.UpdatePos(3);
      else if (transform == 5)
      {
        this.size = new Vector2((float) w, (float) h);
        this.UpdatePos(3);
      }
      if (transform == 5)
        GUIUtility.RotateAroundPivot(90f, this.pivot);
      else if (transform == 6)
        GUIUtility.RotateAroundPivot(270f, this.pivot);
      else if (transform == 4)
      {
        GUIUtility.RotateAroundPivot(270f, this.pivot);
        num10 += num1;
        num7 = -1f;
        if (this.isClip)
        {
          if (x1 > x)
            num8 = -num3;
          else if (x1 + width < x + w)
            num8 = (float) -(x1 + width - x - w);
        }
      }
      else if (transform == 7)
      {
        GUIUtility.RotateAroundPivot(270f, this.pivot);
        num9 = -1;
        num11 += num2;
      }
    }
    Graphics.DrawTexture(new Rect((float) x + num3 + num10 + (float) num12, (float) y + num4 + (float) num13 + num11, num1 * num7, num2 * (float) num9), (Texture) image.texture, new Rect((x0 + num3 + num8) / (float) image.texture.width, (float) ((double) image.texture.height - (double) num2 - ((double) y0 + (double) num4)) / (float) image.texture.height, num1 / (float) image.texture.width, num2 / (float) image.texture.height), 0, 0, 0, 0);
    if (transform != 5 && transform != 6 && transform != 4 && transform != 7)
      return;
    GUI.matrix = this.matrixBackup;
  }

  public void drawRegionGui(
    Image image,
    float x0,
    float y0,
    int w,
    int h,
    int transform,
    float x,
    float y,
    int anchor)
  {
    GUI.color = this.setColorMiniMap(807956);
    x *= (float) mGraphics.zoomLevel;
    y *= (float) mGraphics.zoomLevel;
    x0 *= (float) mGraphics.zoomLevel;
    y0 *= (float) mGraphics.zoomLevel;
    w *= mGraphics.zoomLevel;
    h *= mGraphics.zoomLevel;
  }

  public void drawRegion2(
    Image image,
    float x0,
    float y0,
    int w,
    int h,
    int transform,
    int x,
    int y,
    int anchor)
  {
    GUI.color = image.colorBlend;
    if (this.isTranslate)
    {
      x += this.translateX;
      y += this.translateY;
    }
    string key = "dg" + (object) x0 + (object) y0 + (object) w + (object) h + (object) transform + (object) image.GetHashCode();
    Texture2D image1 = (Texture2D) mGraphics.cachedTextures[(object) key];
    if ((UnityEngine.Object) image1 == (UnityEngine.Object) null)
    {
      image1 = Image.createImage(image, (int) x0, (int) y0, w, h, transform).texture;
      this.cache(key, (Texture) image1);
    }
    int x1 = 0;
    int y1 = 0;
    int width = 0;
    int height = 0;
    float num1 = (float) w;
    float num2 = (float) h;
    float num3 = 0.0f;
    float num4 = 0.0f;
    if ((anchor & mGraphics.HCENTER) == mGraphics.HCENTER)
      num3 -= num1 / 2f;
    if ((anchor & mGraphics.VCENTER) == mGraphics.VCENTER)
      num4 -= num2 / 2f;
    if ((anchor & mGraphics.RIGHT) == mGraphics.RIGHT)
      num3 -= num1;
    if ((anchor & mGraphics.BOTTOM) == mGraphics.BOTTOM)
      num4 -= num2;
    x += (int) num3;
    y += (int) num4;
    if (this.isClip)
    {
      x1 = this.clipX;
      y1 = this.clipY;
      width = this.clipW;
      height = this.clipH;
      if (this.isTranslate)
      {
        x1 += this.clipTX;
        y1 += this.clipTY;
      }
    }
    if (this.isClip)
      GUI.BeginGroup(new Rect((float) x1, (float) y1, (float) width, (float) height));
    GUI.DrawTexture(new Rect((float) (x - x1), (float) (y - y1), (float) w, (float) h), (Texture) image1);
    if (this.isClip)
      GUI.EndGroup();
    GUI.color = new Color(1f, 1f, 1f, 1f);
  }

  public void drawImagaByDrawTexture(Image image, float x, float y)
  {
    x *= (float) mGraphics.zoomLevel;
    y *= (float) mGraphics.zoomLevel;
    GUI.DrawTexture(new Rect(x + (float) this.translateX, y + (float) this.translateY, (float) image.getRealImageWidth(), (float) image.getRealImageHeight()), (Texture) image.texture);
  }

  public void drawImage(Image image, int x, int y, int anchor)
  {
    if (image == null)
      return;
    this.drawRegion(image, 0, 0, mGraphics.getImageWidth(image), mGraphics.getImageHeight(image), 0, x, y, anchor);
  }

  public void drawImageFog(Image image, int x, int y, int anchor)
  {
    if (image == null)
      return;
    this.drawRegion(image, 0, 0, image.texture.width, image.texture.height, 0, x, y, anchor);
  }

  public void drawImage(Image image, int x, int y)
  {
    if (image == null)
      return;
    this.drawRegion(image, 0, 0, mGraphics.getImageWidth(image), mGraphics.getImageHeight(image), 0, x, y, mGraphics.TOP | mGraphics.LEFT);
  }

  public void drawImage(Image image, float x, float y, int anchor)
  {
    if (image == null)
      return;
    this.drawRegion(image, 0, 0, mGraphics.getImageWidth(image), mGraphics.getImageHeight(image), 0, x, y, anchor);
  }

  public void drawRoundRect(int x, int y, int w, int h, int arcWidth, int arcHeight) => this.drawRect(x, y, w, h);

  public void fillRoundRect(int x, int y, int width, int height, int arcWidth, int arcHeight) => this.fillRect(x, y, width, height);

  public void reset()
  {
    this.isClip = false;
    this.isTranslate = false;
    this.translateX = 0;
    this.translateY = 0;
  }

  public Rect intersectRect(Rect r1, Rect r2)
  {
    float x1 = r1.x;
    float y1 = r1.y;
    float x2 = r2.x;
    float y2 = r2.y;
    float num1 = x1 + r1.width;
    float num2 = y1 + r1.height;
    float num3 = x2 + r2.width;
    float num4 = y2 + r2.height;
    if ((double) x1 < (double) x2)
      x1 = x2;
    if ((double) y1 < (double) y2)
      y1 = y2;
    if ((double) num1 > (double) num3)
      num1 = num3;
    if ((double) num2 > (double) num4)
      num2 = num4;
    float width = num1 - x1;
    float height = num2 - y1;
    if ((double) width < -30000.0)
      width = -30000f;
    if ((double) height < -30000.0)
      height = -30000f;
    return new Rect(x1, y1, (float) (int) width, (float) (int) height);
  }

  public void drawImageScale(Image image, int x, int y, int w, int h, int tranform)
  {
    GUI.color = Color.red;
    x *= mGraphics.zoomLevel;
    y *= mGraphics.zoomLevel;
    w *= mGraphics.zoomLevel;
    h *= mGraphics.zoomLevel;
    if (image == null)
      return;
    Graphics.DrawTexture(new Rect((float) (x + this.translateX), (float) (y + this.translateY), tranform != 0 ? (float) -w : (float) w, (float) h), (Texture) image.texture);
  }

  public void drawImageSimple(Image image, int x, int y)
  {
    x *= mGraphics.zoomLevel;
    y *= mGraphics.zoomLevel;
    if (image == null)
      return;
    Graphics.DrawTexture(new Rect((float) x, (float) y, (float) image.w, (float) image.h), (Texture) image.texture);
  }

  public static int getImageWidth(Image image) => image.getWidth();

  public static int getImageHeight(Image image) => image.getHeight();

  public static bool isNotTranColor(Color color) => !(color == Color.clear) && !(color == mGraphics.transParentColor);

  public static Image blend(Image img0, float level, int rgb)
  {
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    float b1 = (float) num1 / 256f;
    float g1 = (float) num2 / 256f;
    Color color1 = new Color((float) num3 / 256f, g1, b1);
    Color[] pixels = img0.texture.GetPixels();
    float r = color1.r;
    float g2 = color1.g;
    float b2 = color1.b;
    for (int index = 0; index < pixels.Length; ++index)
    {
      Color color2 = pixels[index];
      if (mGraphics.isNotTranColor(color2))
      {
        float num4 = (r - color2.r) * level + color2.r;
        float num5 = (g2 - color2.g) * level + color2.g;
        float num6 = (b2 - color2.b) * level + color2.b;
        if ((double) num4 > (double) byte.MaxValue)
          num4 = (float) byte.MaxValue;
        if ((double) num4 < 0.0)
          num4 = 0.0f;
        if ((double) num5 > (double) byte.MaxValue)
          num5 = (float) byte.MaxValue;
        if ((double) num5 < 0.0)
          num5 = 0.0f;
        if ((double) num6 < 0.0)
          num6 = 0.0f;
        if ((double) num6 > (double) byte.MaxValue)
          num6 = (float) byte.MaxValue;
        pixels[index].r = num4;
        pixels[index].g = num5;
        pixels[index].b = num6;
      }
    }
    Image image = Image.createImage(img0.getRealImageWidth(), img0.getRealImageHeight());
    image.texture.SetPixels(pixels);
    Image.setTextureQuality(image.texture);
    image.texture.Apply();
    Cout.LogError2("BLEND ----------------------------------------------------");
    return image;
  }

  public static Color setColorObj(int rgb)
  {
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    float b = (float) num1 / 256f;
    float g = (float) num2 / 256f;
    return new Color((float) num3 / 256f, g, b);
  }

  public void fillTrans(Image imgTrans, int x, int y, int w, int h)
  {
    this.setColor(0, 0.5f);
    this.fillRect(x * mGraphics.zoomLevel, y * mGraphics.zoomLevel, w * mGraphics.zoomLevel, h * mGraphics.zoomLevel);
  }

  public static int blendColor(float level, int color, int colorBlend)
  {
    Color color1 = mGraphics.setColorObj(colorBlend);
    float num1 = color1.r * (float) byte.MaxValue;
    float num2 = color1.g * (float) byte.MaxValue;
    float num3 = color1.b * (float) byte.MaxValue;
    Color color2 = mGraphics.setColorObj(color);
    float num4 = (num1 + color2.r) * level + color2.r;
    float num5 = (num2 + color2.g) * level + color2.g;
    float num6 = (num3 + color2.b) * level + color2.b;
    if ((double) num4 > (double) byte.MaxValue)
      num4 = (float) byte.MaxValue;
    if ((double) num4 < 0.0)
      num4 = 0.0f;
    if ((double) num5 > (double) byte.MaxValue)
      num5 = (float) byte.MaxValue;
    if ((double) num5 < 0.0)
      num5 = 0.0f;
    if ((double) num6 < 0.0)
      num6 = 0.0f;
    if ((double) num6 > (double) byte.MaxValue)
      num6 = (float) byte.MaxValue;
    return (int) num6 & (int) byte.MaxValue + ((int) num5 << 8) & (int) byte.MaxValue + ((int) num4 << 16) & (int) byte.MaxValue;
  }

  public static int getIntByColor(Color cl)
  {
    float num1 = cl.r * (float) byte.MaxValue;
    float num2 = cl.b * (float) byte.MaxValue;
    float num3 = cl.g * (float) byte.MaxValue;
    return ((int) num1 & (int) byte.MaxValue) << 16 | ((int) num3 & (int) byte.MaxValue) << 8 | (int) num2 & (int) byte.MaxValue;
  }

  public static int getRealImageWidth(Image img) => img.w;

  public static int getRealImageHeight(Image img) => img.h;

  public void fillArg(int i, int j, int k, int l, int m, int n) => this.fillRect(i * mGraphics.zoomLevel, j * mGraphics.zoomLevel, k * mGraphics.zoomLevel, l * mGraphics.zoomLevel);

  public void CreateLineMaterial()
  {
    if ((bool) (UnityEngine.Object) this.lineMaterial)
      return;
    this.lineMaterial = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {  Blend SrcAlpha OneMinusSrcAlpha  ZWrite Off Cull Off Fog { Mode Off }  BindChannels { Bind \"vertex\", vertex Bind \"color\", color }} } }");
    this.lineMaterial.hideFlags = HideFlags.HideAndDontSave;
    this.lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
  }

  public void drawlineGL(MyVector totalLine)
  {
    this.lineMaterial.SetPass(0);
    GL.PushMatrix();
    GL.Begin(1);
    for (int index1 = 0; index1 < totalLine.size(); ++index1)
    {
      mLine mLine = (mLine) totalLine.elementAt(index1);
      GL.Color(new Color(mLine.r, mLine.g, mLine.b, mLine.a));
      int x1 = mLine.x1 * mGraphics.zoomLevel;
      int y1 = mLine.y1 * mGraphics.zoomLevel;
      int x2 = mLine.x2 * mGraphics.zoomLevel;
      int y2 = mLine.y2 * mGraphics.zoomLevel;
      if (this.isTranslate)
      {
        x1 += this.translateX;
        y1 += this.translateY;
        x2 += this.translateX;
        y2 += this.translateY;
      }
      for (int index2 = 0; index2 < mGraphics.zoomLevel; ++index2)
      {
        GL.Vertex((Vector3) new Vector2((float) (x1 + index2), (float) (y1 + index2)));
        GL.Vertex((Vector3) new Vector2((float) (x2 + index2), (float) (y2 + index2)));
        if (index2 > 0)
        {
          GL.Vertex((Vector3) new Vector2((float) (x1 + index2), (float) y1));
          GL.Vertex((Vector3) new Vector2((float) (x2 + index2), (float) y2));
          GL.Vertex((Vector3) new Vector2((float) x1, (float) (y1 + index2)));
          GL.Vertex((Vector3) new Vector2((float) x2, (float) (y2 + index2)));
        }
      }
    }
    GL.End();
    GL.PopMatrix();
    totalLine.removeAllElements();
  }

  public void drawLine(mGraphics g, int x, int y, int xTo, int yTo, int nLine, int color)
  {
    MyVector totalLine = new MyVector();
    for (int index = 0; index < nLine; ++index)
      totalLine.addElement((object) new mLine(x, y, xTo + index, yTo + index, color));
    g.drawlineGL(totalLine);
  }

  internal void drawRegion(
    Small img,
    int p1,
    int p2,
    int p3,
    int p4,
    int transform,
    int x,
    int y,
    int anchor)
  {
    throw new NotImplementedException();
  }
}
