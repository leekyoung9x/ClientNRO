// Decompiled with JetBrains decompiler
// Type: BackgroudEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class BackgroudEffect
{
  public static MyVector vBgEffect = new MyVector();
  private int[] x;
  private int[] y;
  private int[] vx;
  private int[] vy;
  public static int[] wP;
  private int num;
  private int xShip;
  private int yShip;
  private int way;
  private int trans;
  private int frameFire;
  private int tFire;
  private int tStart;
  private int speed;
  private bool isFly;
  public static Image imgSnow;
  public static Image imgHatMua;
  public static Image imgMua1;
  public static Image imgMua2;
  public static Image imgSao;
  private static Image imgLacay;
  private static Image imgShip;
  private static Image imgFire1;
  private static Image imgFire2;
  private int[] type;
  private int sum;
  public int typeEff;
  public int xx;
  public int waterY;
  private bool[] isRainEffect;
  private int[] frame;
  private int[] t;
  private bool[] activeEff;
  private int yWater;
  private int colorWater;
  public const int TYPE_MUA = 0;
  public const int TYPE_LATRAIDAT_1 = 1;
  public const int TYPE_LATRAIDAT_2 = 2;
  public const int TYPE_SAMSET = 3;
  public const int TYPE_SAO = 4;
  public const int TYPE_LANAMEK_1 = 5;
  public const int TYPE_LASAYAI_1 = 6;
  public const int TYPE_LANAMEK_2 = 7;
  public const int TYPE_SHIP_TRAIDAT = 8;
  public const int TYPE_HANHTINH = 9;
  public const int TYPE_WATER = 10;
  public const int TYPE_SNOW = 11;
  public const int TYPE_MUA_FRONT = 12;
  public const int TYPE_CLOUD = 13;
  public const int TYPE_FOG = 14;
  public static Image water1 = GameCanvas.loadImage("/mainImage/myTexture2dwater1.png");
  public static Image water2 = GameCanvas.loadImage("/mainImage/myTexture2dwater2.png");
  public static Image imgChamTron1;
  public static Image imgChamTron2;
  public static bool isFog;
  public static bool isPaintFar;
  public static int nCloud;
  public static Image imgCloud1;
  public static Image imgFog;
  public static int cloudw;
  public static int xfog;
  public static int yfog;
  public static int fogw;
  private int[] dem = new int[6]{ 0, 1, 2, 1, 0, 0 };
  private int[] tick;

  public BackgroudEffect(int typeS)
  {
    BackgroudEffect.isFog = true;
    BackgroudEffect.initCloud();
    this.typeEff = typeS;
    switch (this.typeEff)
    {
      case 0:
      case 12:
        if (BackgroudEffect.imgHatMua == null)
          BackgroudEffect.imgHatMua = GameCanvas.loadImageRMS("/bg/mua.png");
        if (BackgroudEffect.imgMua1 == null)
          BackgroudEffect.imgMua1 = GameCanvas.loadImageRMS("/bg/mua1.png");
        if (BackgroudEffect.imgMua2 == null)
          BackgroudEffect.imgMua2 = GameCanvas.loadImageRMS("/bg/mua2.png");
        this.sum = Res.random(GameCanvas.w / 3, GameCanvas.w / 2);
        this.x = new int[this.sum];
        this.y = new int[this.sum];
        this.vx = new int[this.sum];
        this.vy = new int[this.sum];
        this.type = new int[this.sum];
        this.t = new int[this.sum];
        this.frame = new int[this.sum];
        this.isRainEffect = new bool[this.sum];
        this.activeEff = new bool[this.sum];
        for (int index = 0; index < this.sum; ++index)
        {
          this.y[index] = Res.random(-10, GameCanvas.h + 100) + GameScr.cmy;
          this.x[index] = Res.random(-10, GameCanvas.w + 300) + GameScr.cmx;
          this.t[index] = Res.random(0, 1);
          this.vx[index] = -12;
          this.vy[index] = 12;
          this.type[index] = Res.random(1, 3);
          this.isRainEffect[index] = false;
          if (this.type[index] == 2 && index % 2 == 0)
            this.isRainEffect[index] = true;
          this.activeEff[index] = false;
          this.frame[index] = Res.random(1, 2);
        }
        break;
      case 1:
      case 2:
      case 5:
      case 6:
      case 7:
      case 11:
        if (this.typeEff == 1)
          BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay.png");
        if (this.typeEff == 2)
          BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay2.png");
        if (this.typeEff == 5)
          BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay3.png");
        if (this.typeEff == 6)
          BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay4.png");
        if (this.typeEff == 7)
          BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/lacay5.png");
        if (this.typeEff == 11)
          BackgroudEffect.imgLacay = GameCanvas.loadImageRMS("/bg/tuyet.png");
        this.sum = Res.random(15, 25);
        if (this.typeEff == 11)
          this.sum = 100;
        this.x = new int[this.sum];
        this.y = new int[this.sum];
        this.vx = new int[this.sum];
        this.vy = new int[this.sum];
        this.t = new int[this.sum];
        this.frame = new int[this.sum];
        this.activeEff = new bool[this.sum];
        for (int index = 0; index < this.sum; ++index)
        {
          this.x[index] = Res.random(-10, TileMap.pxw + 10);
          this.y[index] = Res.random(0, TileMap.pxh);
          this.frame[index] = Res.random(0, 1);
          this.t[index] = Res.random(0, 1);
          this.vx[index] = Res.random(-3, 3);
          this.vy[index] = Res.random(1, 4);
          if (this.typeEff == 11)
          {
            this.frame[index] = Res.random(0, 2);
            this.vx[index] = Res.abs(Res.random(1, 3));
            this.vy[index] = Res.abs(Res.random(1, 3));
          }
        }
        break;
      case 3:
        GameCanvas.isBoltEff = true;
        break;
      case 4:
        this.sum = Res.random(5, 10);
        if (BackgroudEffect.imgSao == null)
          BackgroudEffect.imgSao = GameCanvas.loadImageRMS("/bg/sao.png");
        this.x = new int[this.sum];
        this.y = new int[this.sum];
        this.frame = new int[this.sum];
        this.t = new int[this.sum];
        this.tick = new int[this.sum];
        for (int index = 0; index < this.sum; ++index)
        {
          this.x[index] = Res.random(0, GameCanvas.w);
          this.y[index] = Res.random(0, 50);
          this.tick[index] = index % 2 != 0 ? (index % 3 != 0 ? (index % 4 != 0 ? 3 : 2) : 1) : 0;
          this.t[index] = Res.random(0, 10);
        }
        break;
      case 8:
        this.tStart = Res.random(100, 300);
        if (BackgroudEffect.imgShip == null)
          BackgroudEffect.imgShip = GameCanvas.loadImageRMS("/bg/ship.png");
        if (BackgroudEffect.imgFire1 == null)
          BackgroudEffect.imgFire1 = GameCanvas.loadImageRMS("/bg/fire1.png");
        if (BackgroudEffect.imgFire2 == null)
          BackgroudEffect.imgFire2 = GameCanvas.loadImageRMS("/bg/fire2.png");
        this.isFly = false;
        this.reloadShip();
        break;
      case 9:
        if (BackgroudEffect.imgChamTron1 == null)
          BackgroudEffect.imgChamTron1 = GameCanvas.loadImageRMS("/bg/cham-tron1.png");
        if (BackgroudEffect.imgChamTron2 == null)
          BackgroudEffect.imgChamTron2 = GameCanvas.loadImageRMS("/bg/cham-tron2.png");
        this.num = 20;
        this.x = new int[this.num];
        this.y = new int[this.num];
        BackgroudEffect.wP = new int[this.num];
        this.vx = new int[this.num];
        for (int index = 0; index < this.num; ++index)
        {
          this.x[index] = Res.abs(Res.random(0, GameCanvas.w));
          this.y[index] = Res.abs(Res.random(10, 80));
          BackgroudEffect.wP[index] = Res.abs(Res.random(1, 3));
          this.vx[index] = BackgroudEffect.wP[index];
        }
        break;
      case 10:
        this.num = 30;
        this.x = new int[this.num];
        this.y = new int[this.num];
        BackgroudEffect.wP = new int[this.num];
        this.vx = new int[this.num];
        int num = 0;
        for (int index = 0; index < this.num; ++index)
        {
          this.x[index] = Res.abs(Res.random(0, GameCanvas.w)) + GameScr.cmx;
          ++num;
          if (num > this.num / 2)
          {
            this.y[index] = Res.abs(Res.random(20, 60));
            BackgroudEffect.wP[index] = 10;
          }
          else
          {
            this.y[index] = Res.abs(Res.random(0, 20));
            BackgroudEffect.wP[index] = 7;
          }
          this.vx[index] = BackgroudEffect.wP[index] / 2 - 2;
        }
        break;
      case 13:
        if (Res.abs(Res.random(0, 2)) != 0)
          break;
        BackgroudEffect.isPaintFar = Res.abs(Res.random(0, 2)) == 0;
        BackgroudEffect.nCloud = Res.abs(Res.random(2, 5));
        BackgroudEffect.initCloud();
        break;
      case 14:
        if (Res.abs(Res.random(0, 2)) != 0)
          break;
        BackgroudEffect.isFog = true;
        BackgroudEffect.initCloud();
        break;
    }
  }

  public static void clearImage() => TileMap.yWater = 0;

  public static bool isHaveRain()
  {
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
    {
      BackgroudEffect backgroudEffect = (BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index);
      if (backgroudEffect.typeEff == 0 || backgroudEffect.typeEff == 12)
        return true;
    }
    return false;
  }

  public static void initCloud()
  {
    if (mSystem.clientType == 1)
    {
      BackgroudEffect.imgCloud1 = (Image) null;
      BackgroudEffect.imgFog = (Image) null;
    }
    else if (GameCanvas.lowGraphic)
    {
      BackgroudEffect.imgCloud1 = (Image) null;
      BackgroudEffect.imgFog = (Image) null;
    }
    else
    {
      if (BackgroudEffect.nCloud > 0)
      {
        if (BackgroudEffect.imgCloud1 == null)
        {
          BackgroudEffect.imgCloud1 = GameCanvas.loadImage("/bg/fog1.png");
          BackgroudEffect.cloudw = BackgroudEffect.imgCloud1.getWidth();
        }
      }
      else
        BackgroudEffect.imgCloud1 = (Image) null;
      if (!BackgroudEffect.isFog)
      {
        BackgroudEffect.imgFog = (Image) null;
      }
      else
      {
        if (BackgroudEffect.imgFog == null)
          BackgroudEffect.imgFog = GameCanvas.loadImage("/bg/fog0.png");
        BackgroudEffect.fogw = 287;
      }
    }
  }

  public static void updateCloud2()
  {
    if (mSystem.clientType == 1 || GameCanvas.lowGraphic || BackgroudEffect.nCloud <= 0)
      return;
    int num1 = GameCanvas.currentScreen != GameScr.gI() ? GameScr.cmx + GameCanvas.w : TileMap.pxw;
    for (int index = 0; index < BackgroudEffect.nCloud; ++index)
    {
      int num2 = index + 1;
      GameCanvas.cloudX[index] -= num2;
      if (GameCanvas.cloudX[index] < -BackgroudEffect.cloudw)
        GameCanvas.cloudX[index] = num1 + 100;
    }
  }

  public static void updateFog()
  {
    if (mSystem.clientType == 1 || GameCanvas.lowGraphic || !BackgroudEffect.isFog)
      return;
    --BackgroudEffect.xfog;
    if (BackgroudEffect.xfog >= -BackgroudEffect.fogw)
      return;
    BackgroudEffect.xfog = 0;
  }

  public static void paintCloud2(mGraphics g)
  {
    if (mSystem.clientType == 1 || GameCanvas.lowGraphic || BackgroudEffect.nCloud == 0 || BackgroudEffect.imgCloud1 == null)
      return;
    for (int index = 0; index < BackgroudEffect.nCloud; ++index)
    {
      int num = index;
      if (num > 3)
        num = 3;
      if (num == 0)
        ;
      g.drawImage(BackgroudEffect.imgCloud1, GameCanvas.cloudX[index], GameCanvas.cloudY[index], 3);
    }
  }

  public static void paintFog(mGraphics g)
  {
    if (mSystem.clientType == 1 || GameCanvas.lowGraphic || !BackgroudEffect.isFog || BackgroudEffect.imgFog == null)
      return;
    for (int xfog = BackgroudEffect.xfog; xfog < TileMap.pxw; xfog += BackgroudEffect.fogw)
    {
      if (xfog >= GameScr.cmx - BackgroudEffect.fogw)
        g.drawImageFog(BackgroudEffect.imgFog, xfog, BackgroudEffect.yfog, 0);
    }
  }

  private void reloadShip()
  {
    int cmx = GameScr.cmx;
    int cmy = GameScr.cmy;
    this.way = Res.random(1, 3);
    this.isFly = false;
    this.speed = Res.random(3, 5);
    if (this.way == 1)
    {
      this.xShip = -50;
      this.yShip = Res.random(cmy, GameCanvas.h - 100 + cmy);
      this.trans = 0;
    }
    else if (this.way == 2)
    {
      this.xShip = TileMap.pxw + 50;
      this.yShip = Res.random(cmy, GameCanvas.h - 100 + cmy);
      this.trans = 2;
    }
    else if (this.way == 3)
    {
      this.xShip = Res.random(50 + cmx, GameCanvas.w - 50 + cmx);
      this.yShip = -50;
      this.trans = Res.random(0, 2) != 0 ? 2 : 0;
    }
    else
    {
      if (this.way != 4)
        return;
      this.xShip = Res.random(50 + cmx, GameCanvas.w - 50 + cmx);
      this.yShip = TileMap.pxh + 50;
      this.trans = Res.random(0, 2) != 0 ? 2 : 0;
    }
  }

  public void paintWater(mGraphics g)
  {
    if (this.typeEff != 10)
      return;
    g.setColor(this.colorWater);
    for (int index = 0; index < this.num; ++index)
      g.drawImage(index >= this.num / 2 ? BackgroudEffect.water1 : BackgroudEffect.water2, this.x[index], this.y[index] + this.yWater, 0);
  }

  public void paintFar(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    if (this.typeEff == 4)
    {
      for (int index = 0; index < this.sum; ++index)
        g.drawRegion(BackgroudEffect.imgSao, 0, 16 * this.frame[index], 16, 16, 0, this.x[index], this.y[index], 0);
    }
    if (this.typeEff != 9)
      return;
    g.setColor(16777215);
    for (int index = 0; index < this.num; ++index)
      g.drawImage(BackgroudEffect.wP[index] != 1 ? BackgroudEffect.imgChamTron2 : BackgroudEffect.imgChamTron1, this.x[index], this.y[index], 3);
  }

  public void update()
  {
    switch (this.typeEff)
    {
      case 0:
      case 12:
        for (int index = 0; index < this.sum; ++index)
        {
          if (index % 3 != 0 && this.typeEff != 12 && TileMap.tileTypeAt(this.x[index], this.y[index] - GameCanvas.transY, 2))
            this.activeEff[index] = true;
          if (index % 3 == 0 && this.y[index] > GameCanvas.h + GameScr.cmy)
          {
            this.x[index] = Res.random(-10, GameCanvas.w + 300) + GameScr.cmx;
            this.y[index] = Res.random(-100, 0) + GameScr.cmy;
          }
          if (!this.activeEff[index])
          {
            this.y[index] += this.vy[index];
            this.x[index] += this.vx[index];
          }
          if (this.activeEff[index])
          {
            ++this.t[index];
            if (this.t[index] > 2)
            {
              ++this.frame[index];
              this.t[index] = 0;
              if (this.frame[index] > 1)
              {
                this.frame[index] = 0;
                this.activeEff[index] = false;
                this.x[index] = Res.random(-10, GameCanvas.w + 300) + GameScr.cmx;
                this.y[index] = Res.random(-100, 0) + GameScr.cmy;
              }
            }
          }
        }
        break;
      case 1:
      case 2:
      case 5:
      case 6:
      case 7:
      case 11:
        for (int index1 = 0; index1 < this.sum; ++index1)
        {
          if (index1 % 3 != 0 && TileMap.tileTypeAt(this.x[index1], this.y[index1] + (TileMap.tileID != 15 ? 0 : 10), 2))
            this.activeEff[index1] = true;
          if (index1 % 3 == 0 && this.y[index1] > TileMap.pxh)
          {
            this.x[index1] = Res.random(-10, TileMap.pxw + 50);
            this.y[index1] = Res.random(-50, 0);
          }
          if (!this.activeEff[index1])
          {
            for (int index2 = 0; index2 < Teleport.vTeleport.size(); ++index2)
            {
              Teleport teleport = (Teleport) Teleport.vTeleport.elementAt(index2);
              if (teleport != null && teleport.paintFire && this.x[index1] < teleport.x + 80 && this.x[index1] > teleport.x - 80 && this.y[index1] < teleport.y + 80 && this.y[index1] > teleport.y - 80)
                this.x[index1] += this.x[index1] >= teleport.x ? 10 : -10;
            }
            this.y[index1] += this.vy[index1];
            this.x[index1] += this.vx[index1];
            ++this.t[index1];
            int num = this.typeEff != 11 ? 4 : 3;
            if (this.t[index1] > (this.typeEff == 2 ? 4 : 2))
            {
              if (this.typeEff != 11)
                ++this.frame[index1];
              this.t[index1] = 0;
              if (this.frame[index1] > num - 1)
                this.frame[index1] = 0;
            }
          }
          else
          {
            ++this.t[index1];
            if (this.t[index1] == 100)
            {
              this.t[index1] = 0;
              this.x[index1] = Res.random(-10, TileMap.pxw + 50);
              this.y[index1] = Res.random(-50, 0);
              this.activeEff[index1] = false;
            }
          }
        }
        break;
      case 4:
        for (int index = 0; index < this.sum; ++index)
        {
          ++this.t[index];
          if (this.t[index] > 10)
          {
            ++this.tick[index];
            this.t[index] = 0;
            if (this.tick[index] > 5)
              this.tick[index] = 0;
            this.frame[index] = this.dem[this.tick[index]];
          }
        }
        break;
      case 8:
        ++this.tFire;
        if (this.tFire == 3)
        {
          this.tFire = 0;
          ++this.frameFire;
          if (this.frameFire > 1)
            this.frameFire = 0;
        }
        if (GameCanvas.gameTick % this.tStart == 0)
          this.isFly = true;
        if (!this.isFly)
          break;
        if (this.way == 1)
        {
          this.xShip += this.speed;
          if (this.xShip <= TileMap.pxw + 50)
            break;
          this.reloadShip();
          break;
        }
        if (this.way == 2)
        {
          this.xShip -= this.speed;
          if (this.xShip >= -50)
            break;
          this.reloadShip();
          break;
        }
        if (this.way == 3)
        {
          this.yShip += this.speed;
          if (this.yShip <= TileMap.pxh + 50)
            break;
          this.reloadShip();
          break;
        }
        if (this.way != 4)
          break;
        this.yShip -= this.speed;
        if (this.yShip >= -50)
          break;
        this.reloadShip();
        break;
      case 9:
        for (int index = 0; index < this.num; ++index)
        {
          this.x[index] -= this.vx[index];
          if (this.x[index] < -this.vx[index])
          {
            BackgroudEffect.wP[index] = Res.abs(Res.random(1, 3));
            this.vx[index] = BackgroudEffect.wP[index];
            this.x[index] = GameCanvas.w + this.vx[index];
          }
        }
        break;
      case 10:
        for (int index = 0; index < this.num; ++index)
        {
          this.x[index] -= this.vx[index];
          if (this.x[index] < -this.vx[index] + GameScr.cmx)
            this.x[index] = GameCanvas.w + this.vx[index] + GameScr.cmx;
        }
        break;
      case 13:
        BackgroudEffect.updateCloud2();
        break;
      case 14:
        BackgroudEffect.updateFog();
        break;
    }
  }

  public void paintFront(mGraphics g)
  {
    switch (this.typeEff)
    {
      case 0:
      case 12:
        int cmx = GameScr.cmx;
        int cmy = GameScr.cmy;
        for (int index = 0; index < this.sum; ++index)
        {
          if (this.type[index] == 2 && this.x[index] >= GameScr.cmx && this.x[index] <= GameCanvas.w + GameScr.cmx && this.y[index] >= GameScr.cmy && this.y[index] <= GameCanvas.h + GameScr.cmy)
          {
            if (this.activeEff[index])
              g.drawRegion(BackgroudEffect.imgHatMua, 0, 10 * this.frame[index], 13, 10, 0, this.x[index], this.y[index] - 10, 0);
            else
              g.drawImage(BackgroudEffect.imgMua1, this.x[index], this.y[index], 0);
          }
        }
        break;
      case 1:
      case 2:
      case 5:
      case 6:
      case 7:
      case 11:
        this.paintLacay1(g, BackgroudEffect.imgLacay);
        break;
      case 13:
        if (BackgroudEffect.isPaintFar)
          break;
        BackgroudEffect.paintCloud2(g);
        break;
    }
  }

  public void paintLacay1(mGraphics g, Image img)
  {
    int num = this.typeEff != 11 ? 4 : 3;
    for (int index = 0; index < this.sum; ++index)
    {
      if (index % 3 == 0 && this.x[index] >= GameScr.cmx && this.x[index] <= GameCanvas.w + GameScr.cmx && this.y[index] >= GameScr.cmy && this.y[index] <= GameCanvas.h + GameScr.cmy)
        g.drawRegion(img, 0, mGraphics.getImageHeight(img) / num * this.frame[index], mGraphics.getImageWidth(img), mGraphics.getImageHeight(img) / num, 0, this.x[index], this.y[index], 0);
    }
  }

  public void paintLacay2(mGraphics g, Image img)
  {
    int num = this.typeEff != 11 ? 4 : 3;
    for (int index = 0; index < this.sum; ++index)
    {
      if (index % 3 != 0 && this.x[index] >= GameScr.cmx && this.x[index] <= GameCanvas.w + GameScr.cmx && this.y[index] >= GameScr.cmy && this.y[index] <= GameCanvas.h + GameScr.cmy)
        g.drawRegion(img, 0, mGraphics.getImageHeight(img) / num * this.frame[index], mGraphics.getImageWidth(img), mGraphics.getImageHeight(img) / num, 0, this.x[index], this.y[index], 0);
    }
  }

  public void paintBehindTile(mGraphics g)
  {
    switch (this.typeEff)
    {
      case 8:
        g.drawRegion(BackgroudEffect.imgShip, 0, 0, BackgroudEffect.imgShip.getWidth(), BackgroudEffect.imgShip.getHeight(), this.trans, this.xShip, this.yShip, 3);
        if (this.way == 1 || this.way == 2)
        {
          int num = this.trans != 0 ? 25 : -25;
          g.drawRegion(BackgroudEffect.imgFire1, 0, this.frameFire * 8, 20, 8, this.trans, this.xShip + num, this.yShip + 5, 3);
          break;
        }
        int num1 = this.trans != 0 ? -11 : 11;
        g.drawRegion(BackgroudEffect.imgFire2, 0, this.frameFire * 18, 8, 18, this.trans, this.xShip + num1, this.yShip + 22, 3);
        break;
      case 13:
        if (!BackgroudEffect.isPaintFar)
          break;
        BackgroudEffect.paintCloud2(g);
        break;
    }
  }

  public void paintBack(mGraphics g)
  {
    switch (this.typeEff)
    {
      case 0:
        int cmx = GameScr.cmx;
        int cmy = GameScr.cmy;
        g.setColor(10742731);
        for (int index = 0; index < this.sum; ++index)
        {
          if (this.type[index] != 2 && this.x[index] >= GameScr.cmx && this.x[index] <= GameCanvas.w + GameScr.cmx && this.y[index] >= GameScr.cmy && this.y[index] <= GameCanvas.h + GameScr.cmy)
            g.drawImage(BackgroudEffect.imgMua2, this.x[index], this.y[index], 0);
        }
        break;
      case 1:
      case 2:
      case 5:
      case 6:
      case 7:
      case 11:
        this.paintLacay2(g, BackgroudEffect.imgLacay);
        break;
    }
  }

  public static void addEffect(int id)
  {
    if (GameCanvas.lowGraphic)
      return;
    BackgroudEffect o = new BackgroudEffect(id);
    BackgroudEffect.vBgEffect.addElement((object) o);
  }

  public static void addWater(int color, int yWater) => BackgroudEffect.vBgEffect.addElement((object) new BackgroudEffect(10)
  {
    colorWater = color,
    yWater = yWater
  });

  public static void paintWaterAll(mGraphics g)
  {
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
      ((BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index)).paintWater(g);
  }

  public static void paintBehindTileAll(mGraphics g)
  {
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
      ((BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index)).paintBehindTile(g);
  }

  public static void paintFrontAll(mGraphics g)
  {
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
      ((BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index)).paintFront(g);
  }

  public static void paintFarAll(mGraphics g)
  {
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
      ((BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index)).paintFar(g);
  }

  public static void paintBackAll(mGraphics g)
  {
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
      ((BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index)).paintBack(g);
  }

  public static void updateEff()
  {
    for (int index = 0; index < BackgroudEffect.vBgEffect.size(); ++index)
      ((BackgroudEffect) BackgroudEffect.vBgEffect.elementAt(index)).update();
  }
}
