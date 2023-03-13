// Decompiled with JetBrains decompiler
// Type: TileMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class TileMap
{
  public const int T_EMPTY = 0;
  public const int T_TOP = 2;
  public const int T_LEFT = 4;
  public const int T_RIGHT = 8;
  public const int T_TREE = 16;
  public const int T_WATERFALL = 32;
  public const int T_WATERFLOW = 64;
  public const int T_TOPFALL = 128;
  public const int T_OUTSIDE = 256;
  public const int T_DOWN1PIXEL = 512;
  public const int T_BRIDGE = 1024;
  public const int T_UNDERWATER = 2048;
  public const int T_SOLIDGROUND = 4096;
  public const int T_BOTTOM = 8192;
  public const int T_DIE = 16384;
  public const int T_HEBI = 32768;
  public const int T_BANG = 65536;
  public const int T_JUM8 = 131072;
  public const int T_NT0 = 262144;
  public const int T_NT1 = 524288;
  public const int T_CENTER = 1;
  public static int tmw;
  public static int tmh;
  public static int pxw;
  public static int pxh;
  public static int tileID;
  public static int lastTileID = -1;
  public static int[] maps;
  public static int[] types;
  public static Image[] imgTile;
  public static Image imgTileSmall;
  public static Image imgMiniMap;
  public static Image imgWaterfall;
  public static Image imgTopWaterfall;
  public static Image imgWaterflow;
  public static Image imgWaterlowN;
  public static Image imgWaterlowN2;
  public static Image imgWaterF;
  public static Image imgLeaf;
  public static sbyte size = 24;
  private static int bx;
  private static int dbx;
  private static int fx;
  private static int dfx;
  public static string[] instruction;
  public static int[] iX;
  public static int[] iY;
  public static int[] iW;
  public static int iCount;
  public static bool isMapDouble = false;
  public static string mapName = string.Empty;
  public static sbyte versionMap = 1;
  public static int mapID;
  public static int lastBgID = -1;
  public static int zoneID;
  public static int bgID;
  public static int bgType;
  public static int lastType = -1;
  public static int typeMap;
  public static sbyte planetID;
  public static sbyte lastPlanetId = -1;
  public static long timeTranMini;
  public static MyVector vGo = new MyVector();
  public static MyVector vItemBg = new MyVector();
  public static MyVector vCurrItem = new MyVector();
  public static string[] mapNames;
  public static sbyte MAP_NORMAL = 0;
  public static Image bong;
  public const int TRAIDAT_DOINUI = 0;
  public const int TRAIDAT_RUNG = 1;
  public const int TRAIDAT_DAORUA = 2;
  public const int TRAIDAT_DADO = 3;
  public const int NAMEK_THUNGLUNG = 5;
  public const int NAMEK_DOINUI = 4;
  public const int NAMEK_RUNG = 6;
  public const int NAMEK_DAO = 7;
  public const int SAYAI_DOINUI = 8;
  public const int SAYAI_RUNG = 9;
  public const int SAYAI_CITY = 10;
  public const int SAYAI_NIGHT = 11;
  public const int KAMISAMA = 12;
  public const int TIME_ROOM = 13;
  public const int HELL = 15;
  public const int BEERUS = 16;
  public static Image[] bgItem = new Image[8];
  public static MyVector vObject = new MyVector();
  public static int[] offlineId = new int[6]
  {
    21,
    22,
    23,
    39,
    40,
    41
  };
  public static int[] highterId = new int[6]
  {
    21,
    22,
    23,
    24,
    25,
    26
  };
  public static int[] toOfflineId = new int[3]{ 0, 7, 14 };
  public static int[][] tileType;
  public static int[][][] tileIndex;
  public static Image imgLight = GameCanvas.loadImage("/bg/light.png");
  public static int sizeMiniMap = 2;
  public static int gssx;
  public static int gssxe;
  public static int gssy;
  public static int gssye;
  public static int countx;
  public static int county;
  private static int[] colorMini = new int[2]
  {
    5257738,
    8807192
  };
  public static int yWater = 0;

  public static void loadBg()
  {
    TileMap.bong = GameCanvas.loadImage("/mainImage/myTexture2dbong.png");
    if (mGraphics.zoomLevel == 1 || Main.isIpod || Main.isIphone4)
      return;
    TileMap.imgLight = GameCanvas.loadImage("/bg/light.png");
  }

  public static bool isVoDaiMap() => TileMap.mapID == 51 || TileMap.mapID == 103 || TileMap.mapID == 112 || TileMap.mapID == 113 || TileMap.mapID == 129 || TileMap.mapID == 130;

  public static bool isTrainingMap() => TileMap.mapID == 39 || TileMap.mapID == 40 || TileMap.mapID == 41;

  public static bool mapPhuBang() => GameScr.phuban_Info != null && TileMap.mapID == (int) GameScr.phuban_Info.idmapPaint;

  public static BgItem getBIById(int id)
  {
    for (int index = 0; index < TileMap.vItemBg.size(); ++index)
    {
      BgItem biById = (BgItem) TileMap.vItemBg.elementAt(index);
      if (biById.id == id)
        return biById;
    }
    return (BgItem) null;
  }

  public static bool isOfflineMap()
  {
    for (int index = 0; index < TileMap.offlineId.Length; ++index)
    {
      if (TileMap.mapID == TileMap.offlineId[index])
        return true;
    }
    return false;
  }

  public static bool isHighterMap()
  {
    for (int index = 0; index < TileMap.offlineId.Length; ++index)
    {
      if (TileMap.mapID == TileMap.highterId[index])
        return true;
    }
    return false;
  }

  public static bool isToOfflineMap()
  {
    for (int index = 0; index < TileMap.toOfflineId.Length; ++index)
    {
      if (TileMap.mapID == TileMap.toOfflineId[index])
        return true;
    }
    return false;
  }

  public static void freeTilemap()
  {
    TileMap.imgTile = (Image[]) null;
    mSystem.gcc();
  }

  public static void loadTileCreatChar()
  {
  }

  public static bool isExistMoreOne(int id)
  {
    if (id == 156 || id == 330 || id == 345 || id == 334 || TileMap.mapID == 54 || TileMap.mapID == 55 || TileMap.mapID == 56 || TileMap.mapID == 57 || TileMap.mapID == 58 || TileMap.mapID == 59 || TileMap.mapID == 103)
      return false;
    int num = 0;
    for (int index = 0; index < TileMap.vCurrItem.size(); ++index)
    {
      if (((BgItem) TileMap.vCurrItem.elementAt(index)).id == id)
        ++num;
    }
    return num > 2;
  }

  public static void loadTileImage()
  {
    if (TileMap.imgWaterfall == null)
      TileMap.imgWaterfall = GameCanvas.loadImageRMS("/tWater/wtf.png");
    if (TileMap.imgTopWaterfall == null)
      TileMap.imgTopWaterfall = GameCanvas.loadImageRMS("/tWater/twtf.png");
    if (TileMap.imgWaterflow == null)
      TileMap.imgWaterflow = GameCanvas.loadImageRMS("/tWater/wts.png");
    if (TileMap.imgWaterlowN == null)
      TileMap.imgWaterlowN = GameCanvas.loadImageRMS("/tWater/wtsN.png");
    if (TileMap.imgWaterlowN2 == null)
      TileMap.imgWaterlowN2 = GameCanvas.loadImageRMS("/tWater/wtsN2.png");
    mSystem.gcc();
  }

  public static void setTile(int index, int[] mapsArr, int type)
  {
    for (int index1 = 0; index1 < mapsArr.Length; ++index1)
    {
      if (TileMap.maps[index] == mapsArr[index1])
      {
        TileMap.types[index] |= type;
        break;
      }
    }
  }

  public static void loadMap(int tileId)
  {
    TileMap.pxh = TileMap.tmh * (int) TileMap.size;
    TileMap.pxw = TileMap.tmw * (int) TileMap.size;
    Res.outz("load tile ID= " + (object) TileMap.tileID);
    int index1 = tileId - 1;
    try
    {
      for (int index2 = 0; index2 < TileMap.tmw * TileMap.tmh; ++index2)
      {
        for (int index3 = 0; index3 < TileMap.tileType[index1].Length; ++index3)
          TileMap.setTile(index2, TileMap.tileIndex[index1][index3], TileMap.tileType[index1][index3]);
      }
    }
    catch (Exception ex)
    {
      Cout.println("Error Load Map");
      GameMidlet.instance.exit();
    }
  }

  public static bool isInAirMap() => TileMap.mapID == 45 || TileMap.mapID == 46 || TileMap.mapID == 48;

  public static bool isDoubleMap() => TileMap.isMapDouble || TileMap.mapID == 45 || TileMap.mapID == 46 || TileMap.mapID == 48 || TileMap.mapID == 51 || TileMap.mapID == 52 || TileMap.mapID == 103 || TileMap.mapID == 112 || TileMap.mapID == 113 || TileMap.mapID == 115 || TileMap.mapID == 117 || TileMap.mapID == 118 || TileMap.mapID == 119 || TileMap.mapID == 120 || TileMap.mapID == 121 || TileMap.mapID == 125 || TileMap.mapID == 129 || TileMap.mapID == 130;

  public static void getTile()
  {
    if (Main.typeClient == 3 || Main.typeClient == 5)
    {
      if (mGraphics.zoomLevel == 1)
      {
        TileMap.imgTile = new Image[1];
        TileMap.imgTile[0] = GameCanvas.loadImage("/t/" + (object) TileMap.tileID + ".png");
      }
      else
      {
        TileMap.imgTile = new Image[100];
        for (int index = 0; index < TileMap.imgTile.Length; ++index)
          TileMap.imgTile[index] = GameCanvas.loadImage("/t/" + (object) TileMap.tileID + "/" + (object) (index + 1) + ".png");
      }
    }
    else if (mGraphics.zoomLevel == 1)
    {
      if (TileMap.imgTile != null)
      {
        for (int index = 0; index < TileMap.imgTile.Length; ++index)
        {
          if (TileMap.imgTile[index] != null)
          {
            TileMap.imgTile[index].texture = (Texture2D) null;
            TileMap.imgTile[index] = (Image) null;
          }
        }
        mSystem.gcc();
      }
      TileMap.imgTile = new Image[100];
      string empty = string.Empty;
      for (int index = 0; index < TileMap.imgTile.Length; ++index)
      {
        string path;
        if (index < 9)
          path = "/t/" + (object) TileMap.tileID + "/t_0" + (object) (index + 1);
        else
          path = "/t/" + (object) TileMap.tileID + "/t_" + (object) (index + 1);
        TileMap.imgTile[index] = GameCanvas.loadImage(path);
      }
    }
    else if (GameCanvas.loadImageRMS("/t/" + (object) TileMap.tileID + "$1.png") != null)
    {
      Rms.DeleteStorage("x" + (object) mGraphics.zoomLevel + "t" + (object) TileMap.tileID);
      TileMap.imgTile = new Image[100];
      for (int index = 0; index < TileMap.imgTile.Length; ++index)
        TileMap.imgTile[index] = GameCanvas.loadImageRMS("/t/" + (object) TileMap.tileID + "$" + (object) (index + 1) + ".png");
    }
    else
    {
      Image image = GameCanvas.loadImageRMS("/t/" + (object) TileMap.tileID + ".png");
      if (image == null)
        return;
      Rms.DeleteStorage("$");
      TileMap.imgTile = new Image[1];
      TileMap.imgTile[0] = image;
    }
  }

  public static void paintTile(mGraphics g, int frame, int indexX, int indexY)
  {
    if (TileMap.imgTile == null)
      return;
    if (TileMap.imgTile.Length == 1)
      g.drawRegion(TileMap.imgTile[0], 0, frame * (int) TileMap.size, (int) TileMap.size, (int) TileMap.size, 0, indexX * (int) TileMap.size, indexY * (int) TileMap.size, 0);
    else
      g.drawImage(TileMap.imgTile[frame], indexX * (int) TileMap.size, indexY * (int) TileMap.size, 0);
  }

  public static void paintTile(mGraphics g, int frame, int x, int y, int w, int h)
  {
    if (TileMap.imgTile == null)
      return;
    if (TileMap.imgTile.Length == 1)
      g.drawRegion(TileMap.imgTile[0], 0, frame * w, w, w, 0, x, y, 0);
    else
      g.drawImage(TileMap.imgTile[frame], x, y, 0);
  }

  public static void paintTilemapLOW(mGraphics g)
  {
    for (int gssx = GameScr.gssx; gssx < GameScr.gssxe; ++gssx)
    {
      for (int gssy = GameScr.gssy; gssy < GameScr.gssye; ++gssy)
      {
        int frame = TileMap.maps[gssy * TileMap.tmw + gssx] - 1;
        if (frame != -1)
          TileMap.paintTile(g, frame, gssx, gssy);
        if ((TileMap.tileTypeAt(gssx, gssy) & 32) == 32)
          g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 4), 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 0);
        else if ((TileMap.tileTypeAt(gssx, gssy) & 64) == 64)
        {
          if ((TileMap.tileTypeAt(gssx, gssy - 1) & 32) == 32)
            g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 4), 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 0);
          else if ((TileMap.tileTypeAt(gssx, gssy - 1) & 4096) == 4096)
            TileMap.paintTile(g, 21, gssx, gssy);
          Image image;
          switch (TileMap.tileID)
          {
            case 5:
              image = TileMap.imgWaterlowN;
              break;
            case 8:
              image = TileMap.imgWaterlowN2;
              break;
            default:
              image = TileMap.imgWaterflow;
              break;
          }
          g.drawRegion(image, 0, (GameCanvas.gameTick % 8 >> 2) * 24, 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 0);
        }
        if ((TileMap.tileTypeAt(gssx, gssy) & 2048) == 2048)
        {
          if ((TileMap.tileTypeAt(gssx, gssy - 1) & 32) == 32)
            g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 4), 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 0);
          else if ((TileMap.tileTypeAt(gssx, gssy - 1) & 4096) == 4096)
            TileMap.paintTile(g, 21, gssx, gssy);
          TileMap.paintTile(g, TileMap.maps[gssy * TileMap.tmw + gssx] - 1, gssx, gssy);
        }
      }
    }
  }

  public static void paintTilemap(mGraphics g)
  {
    if (Char.isLoadingMap)
      return;
    GameScr.gI().paintBgItem(g, 1);
    for (int index = 0; index < GameScr.vItemMap.size(); ++index)
      ((ItemMap) GameScr.vItemMap.elementAt(index)).paintAuraItemEff(g);
    for (int gssx = GameScr.gssx; gssx < GameScr.gssxe; ++gssx)
    {
      for (int gssy = GameScr.gssy; gssy < GameScr.gssye; ++gssy)
      {
        if (gssx != 0 && gssx != TileMap.tmw - 1)
        {
          int frame = TileMap.maps[gssy * TileMap.tmw + gssx] - 1;
          if ((TileMap.tileTypeAt(gssx, gssy) & 256) != 256)
          {
            if ((TileMap.tileTypeAt(gssx, gssy) & 32) == 32)
              g.drawRegion(TileMap.imgWaterfall, 0, 24 * (GameCanvas.gameTick % 8 >> 1), 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 0);
            else if ((TileMap.tileTypeAt(gssx, gssy) & 128) == 128)
              g.drawRegion(TileMap.imgTopWaterfall, 0, 24 * (GameCanvas.gameTick % 8 >> 1), 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 0);
            else if (TileMap.tileID != 13 || frame == -1)
            {
              if (TileMap.tileID == 2 && (TileMap.tileTypeAt(gssx, gssy) & 512) == 512 && frame != -1)
              {
                TileMap.paintTile(g, frame, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 24, 1);
                TileMap.paintTile(g, frame, gssx * (int) TileMap.size, gssy * (int) TileMap.size + 1, 24, 24);
              }
              if (TileMap.tileID != 3)
                ;
              if ((TileMap.tileTypeAt(gssx, gssy) & 16) == 16)
              {
                TileMap.bx = gssx * (int) TileMap.size - GameScr.cmx;
                TileMap.dbx = TileMap.bx - GameScr.gW2;
                TileMap.dfx = ((int) TileMap.size - 2) * TileMap.dbx / (int) TileMap.size;
                TileMap.fx = TileMap.dfx + GameScr.gW2;
                TileMap.paintTile(g, frame, TileMap.fx + GameScr.cmx, gssy * (int) TileMap.size, 24, 24);
              }
              else if ((TileMap.tileTypeAt(gssx, gssy) & 512) == 512)
              {
                if (frame != -1)
                {
                  TileMap.paintTile(g, frame, gssx * (int) TileMap.size, gssy * (int) TileMap.size, 24, 1);
                  TileMap.paintTile(g, frame, gssx * (int) TileMap.size, gssy * (int) TileMap.size + 1, 24, 24);
                }
              }
              else if (frame != -1)
                TileMap.paintTile(g, frame, gssx, gssy);
            }
          }
        }
      }
    }
    if (GameScr.cmx < 24)
    {
      for (int gssy = GameScr.gssy; gssy < GameScr.gssye; ++gssy)
      {
        int frame = TileMap.maps[gssy * TileMap.tmw + 1] - 1;
        if (frame != -1)
          TileMap.paintTile(g, frame, 0, gssy);
      }
    }
    if (GameScr.cmx <= GameScr.cmxLim)
      return;
    int num = TileMap.tmw - 2;
    for (int gssy = GameScr.gssy; gssy < GameScr.gssye; ++gssy)
    {
      int frame = TileMap.maps[gssy * TileMap.tmw + num] - 1;
      if (frame != -1)
        TileMap.paintTile(g, frame, num + 1, gssy);
    }
  }

  public static bool isWaterEff() => TileMap.mapID != 54 && TileMap.mapID != 55 && TileMap.mapID != 56 && TileMap.mapID != 57 && TileMap.mapID != 138;

  public static void paintOutTilemap(mGraphics g)
  {
    if (GameCanvas.lowGraphic)
      return;
    int num = 0;
    for (int gssx = GameScr.gssx; gssx < GameScr.gssxe; ++gssx)
    {
      for (int gssy = GameScr.gssy; gssy < GameScr.gssye; ++gssy)
      {
        ++num;
        if ((TileMap.tileTypeAt(gssx, gssy) & 64) == 64)
        {
          Image image;
          switch (TileMap.tileID)
          {
            case 5:
              image = TileMap.imgWaterlowN;
              break;
            case 8:
              image = TileMap.imgWaterlowN2;
              break;
            default:
              image = TileMap.imgWaterflow;
              break;
          }
          if (!TileMap.isWaterEff())
          {
            g.drawRegion(image, 0, 0, 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size - 1, 0);
            g.drawRegion(image, 0, 0, 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size - 3, 0);
          }
          g.drawRegion(image, 0, (GameCanvas.gameTick % 8 >> 2) * 24, 24, 24, 0, gssx * (int) TileMap.size, gssy * (int) TileMap.size - 12, 0);
          if (TileMap.yWater == 0 && TileMap.isWaterEff())
          {
            TileMap.yWater = gssy * (int) TileMap.size - 12;
            int color = 16777215;
            switch (GameCanvas.typeBg)
            {
              case 2:
                color = 10871287;
                break;
              case 4:
                color = 8111470;
                break;
              case 7:
                color = 5693125;
                break;
            }
            BackgroudEffect.addWater(color, TileMap.yWater + 15);
          }
        }
      }
    }
    BackgroudEffect.paintWaterAll(g);
  }

  public static void loadMapFromResource(int mapID)
  {
    DataInputStream dataInputStream = MyStream.readFile("/mymap/" + (object) mapID);
    TileMap.tmw = (int) (ushort) dataInputStream.read();
    TileMap.tmh = (int) (ushort) dataInputStream.read();
    TileMap.maps = new int[dataInputStream.available()];
    for (int index = 0; index < TileMap.tmw * TileMap.tmh; ++index)
      TileMap.maps[index] = (int) (ushort) dataInputStream.read();
    TileMap.types = new int[TileMap.maps.Length];
  }

  public static int tileAt(int x, int y)
  {
    try
    {
      return TileMap.maps[y * TileMap.tmw + x];
    }
    catch (Exception ex)
    {
      return 1000;
    }
  }

  public static int tileTypeAt(int x, int y)
  {
    try
    {
      return TileMap.types[y * TileMap.tmw + x];
    }
    catch (Exception ex)
    {
      return 1000;
    }
  }

  public static int tileTypeAtPixel(int px, int py)
  {
    try
    {
      return TileMap.types[py / (int) TileMap.size * TileMap.tmw + px / (int) TileMap.size];
    }
    catch (Exception ex)
    {
      return 1000;
    }
  }

  public static bool tileTypeAt(int px, int py, int t)
  {
    try
    {
      return (TileMap.types[py / (int) TileMap.size * TileMap.tmw + px / (int) TileMap.size] & t) == t;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static void setTileTypeAtPixel(int px, int py, int t) => TileMap.types[py / (int) TileMap.size * TileMap.tmw + px / (int) TileMap.size] |= t;

  public static void setTileTypeAt(int x, int y, int t) => TileMap.types[y * TileMap.tmw + x] = t;

  public static void killTileTypeAt(int px, int py, int t) => TileMap.types[py / (int) TileMap.size * TileMap.tmw + px / (int) TileMap.size] &= ~t;

  public static int tileYofPixel(int py) => py / (int) TileMap.size * (int) TileMap.size;

  public static int tileXofPixel(int px) => px / (int) TileMap.size * (int) TileMap.size;

  public static void loadMainTile()
  {
    if (TileMap.lastTileID == TileMap.tileID)
      return;
    TileMap.getTile();
    TileMap.lastTileID = TileMap.tileID;
  }
}
