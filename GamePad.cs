// Decompiled with JetBrains decompiler
// Type: GamePad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class GamePad
{
  private int xC;
  private int yC;
  private int xM;
  private int yM;
  private int xMLast;
  private int yMLast;
  private int R;
  private int r;
  private int d;
  private int xTemp;
  private int yTemp;
  private int deltaX;
  private int deltaY;
  private int delta;
  private int angle;
  public int xZone;
  public int yZone;
  public int wZone;
  public int hZone;
  private bool isGamePad;
  public bool isSmallGamePad;
  public bool isMediumGamePad;
  public bool isLargeGamePad;

  public GamePad()
  {
    this.R = 28;
    if (GameCanvas.w < 300)
    {
      this.isSmallGamePad = true;
      this.isMediumGamePad = false;
      this.isLargeGamePad = false;
    }
    if (GameCanvas.w >= 300 && GameCanvas.w <= 380)
    {
      this.isSmallGamePad = false;
      this.isMediumGamePad = true;
      this.isLargeGamePad = false;
    }
    if (GameCanvas.w > 380)
    {
      this.isSmallGamePad = false;
      this.isMediumGamePad = false;
      this.isLargeGamePad = true;
    }
    if (!this.isLargeGamePad)
    {
      this.xZone = 0;
      this.wZone = GameCanvas.hw;
      this.yZone = GameCanvas.hh >> 1;
      this.hZone = GameCanvas.h - 80;
    }
    else
    {
      this.xZone = 0;
      this.wZone = GameCanvas.hw / 4 * 3 - 20;
      this.yZone = GameCanvas.hh >> 1;
      this.hZone = GameCanvas.h;
    }
  }

  public void update()
  {
    try
    {
      if (GameScr.isAnalog == 0)
        return;
      if (GameCanvas.isPointerDown && !GameCanvas.isPointerJustRelease)
      {
        this.xTemp = GameCanvas.pxFirst;
        this.yTemp = GameCanvas.pyFirst;
        if (this.xTemp < this.xZone || this.xTemp > this.wZone || this.yTemp < this.yZone || this.yTemp > this.hZone)
          return;
        if (!this.isGamePad)
        {
          this.xC = this.xM = this.xTemp;
          this.yC = this.yM = this.yTemp;
        }
        this.isGamePad = true;
        this.deltaX = GameCanvas.px - this.xC;
        this.deltaY = GameCanvas.py - this.yC;
        this.delta = Math.pow(this.deltaX, 2) + Math.pow(this.deltaY, 2);
        this.d = Res.sqrt(this.delta);
        if (Math.abs(this.deltaX) <= 4 && Math.abs(this.deltaY) <= 4)
          return;
        this.angle = Res.angle(this.deltaX, this.deltaY);
        if (!GameCanvas.isPointerHoldIn(this.xC - this.R, this.yC - this.R, 2 * this.R, 2 * this.R))
        {
          if (this.d != 0)
          {
            this.yM = this.deltaY * this.R / this.d;
            this.xM = this.deltaX * this.R / this.d;
            this.xM += this.xC;
            this.yM += this.yC;
            if (!Res.inRect(this.xC - this.R, this.yC - this.R, 2 * this.R, 2 * this.R, this.xM, this.yM))
            {
              this.xM = this.xMLast;
              this.yM = this.yMLast;
            }
            else
            {
              this.xMLast = this.xM;
              this.yMLast = this.yM;
            }
          }
          else
          {
            this.xM = this.xMLast;
            this.yM = this.yMLast;
          }
        }
        else
        {
          this.xM = GameCanvas.px;
          this.yM = GameCanvas.py;
        }
        this.resetHold();
        if (this.checkPointerMove(2))
        {
          if (this.angle <= 360 && this.angle >= 340 || this.angle >= 0 && this.angle <= 20)
          {
            GameCanvas.keyHold[!Main.isPC ? 6 : 24] = true;
            GameCanvas.keyPressed[!Main.isPC ? 6 : 24] = true;
          }
          else if (this.angle > 40 && this.angle < 70)
          {
            GameCanvas.keyHold[!Main.isPC ? 6 : 24] = true;
            GameCanvas.keyPressed[!Main.isPC ? 6 : 24] = true;
          }
          else if (this.angle >= 70 && this.angle <= 110)
          {
            GameCanvas.keyHold[!Main.isPC ? 8 : 22] = true;
            GameCanvas.keyPressed[!Main.isPC ? 8 : 22] = true;
          }
          else if (this.angle > 110 && this.angle < 120)
          {
            GameCanvas.keyHold[!Main.isPC ? 4 : 23] = true;
            GameCanvas.keyPressed[!Main.isPC ? 4 : 23] = true;
          }
          else if (this.angle >= 120 && this.angle <= 200)
          {
            GameCanvas.keyHold[!Main.isPC ? 4 : 23] = true;
            GameCanvas.keyPressed[!Main.isPC ? 4 : 23] = true;
          }
          else if (this.angle > 200 && this.angle < 250)
          {
            GameCanvas.keyHold[!Main.isPC ? 2 : 21] = true;
            GameCanvas.keyPressed[!Main.isPC ? 2 : 21] = true;
            GameCanvas.keyHold[!Main.isPC ? 4 : 23] = true;
            GameCanvas.keyPressed[!Main.isPC ? 4 : 23] = true;
          }
          else if (this.angle >= 250 && this.angle <= 290)
          {
            GameCanvas.keyHold[!Main.isPC ? 2 : 21] = true;
            GameCanvas.keyPressed[!Main.isPC ? 2 : 21] = true;
          }
          else
          {
            if (this.angle <= 290 || this.angle >= 340)
              return;
            GameCanvas.keyHold[!Main.isPC ? 2 : 21] = true;
            GameCanvas.keyPressed[!Main.isPC ? 2 : 21] = true;
            GameCanvas.keyHold[!Main.isPC ? 6 : 24] = true;
            GameCanvas.keyPressed[!Main.isPC ? 6 : 24] = true;
          }
        }
        else
          this.resetHold();
      }
      else
      {
        this.xM = this.xC = 45;
        this.yM = this.isLargeGamePad ? (this.yC = GameCanvas.h - 45) : (this.yC = GameCanvas.h - 90);
        this.isGamePad = false;
        this.resetHold();
      }
    }
    catch (Exception ex)
    {
    }
  }

  private bool checkPointerMove(int distance)
  {
    if (GameScr.isAnalog == 0)
      return false;
    if (Char.myCharz().statusMe == 3)
      return true;
    try
    {
      for (int index = 2; index > 0; --index)
      {
        int i1 = GameCanvas.arrPos[index].x - GameCanvas.arrPos[index - 1].x;
        int i2 = GameCanvas.arrPos[index].y - GameCanvas.arrPos[index - 1].y;
        if (Res.abs(i1) > distance && Res.abs(i2) > distance)
          return false;
      }
    }
    catch (Exception ex)
    {
    }
    return true;
  }

  private void resetHold() => GameCanvas.clearKeyHold();

  public void paint(mGraphics g)
  {
    if (GameScr.isAnalog == 0)
      return;
    g.drawImage(GameScr.imgAnalog1, this.xC, this.yC, mGraphics.HCENTER | mGraphics.VCENTER);
    g.drawImage(GameScr.imgAnalog2, this.xM, this.yM, mGraphics.HCENTER | mGraphics.VCENTER);
  }

  public bool disableCheckDrag() => GameScr.isAnalog != 0 && this.isGamePad;

  public bool disableClickMove()
  {
    try
    {
      if (GameScr.isAnalog == 0)
        return false;
      return GameCanvas.px >= this.xZone && GameCanvas.px <= this.wZone && GameCanvas.py >= this.yZone && GameCanvas.py <= this.hZone || GameCanvas.px >= GameCanvas.w - 50;
    }
    catch (Exception ex)
    {
      return false;
    }
  }
}
