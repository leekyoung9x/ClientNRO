﻿// Decompiled with JetBrains decompiler
// Type: SplashScr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class SplashScr : mScreen
{
  public static int splashScrStat;
  private bool isCheckConnect;
  private bool isSwitchToLogin;
  public static int nData = -1;
  public static int maxData = -1;
  public static SplashScr instance;
  public static Image imgLogo;

  public SplashScr() => SplashScr.instance = this;

  public static void loadSplashScr() => SplashScr.splashScrStat = 0;

  public override void update()
  {
    if (SplashScr.splashScrStat == 30 && !this.isCheckConnect)
    {
      this.isCheckConnect = true;
      if (Rms.loadRMSInt("isPlaySound") != -1)
        GameCanvas.isPlaySound = Rms.loadRMSInt("isPlaySound") == 1;
      if (GameCanvas.isPlaySound)
        SoundMn.gI().loadSound(TileMap.mapID);
      SoundMn.gI().getStrOption();
      ServerListScreen.loadIP();
    }
    ++SplashScr.splashScrStat;
    ServerListScreen.updateDeleteData();
  }

  public static void loadIP()
  {
    if (Rms.loadRMSInt("svselect") == -1)
    {
      int num = 0;
      if (mResources.language > (sbyte) 0)
      {
        for (int index = 0; index < (int) mResources.language; ++index)
          num += ServerListScreen.lengthServer[index];
      }
      ServerListScreen.ipSelect = ServerListScreen.serverPriority != (sbyte) -1 ? (int) ServerListScreen.serverPriority : num + Res.random(0, ServerListScreen.lengthServer[(int) mResources.language]);
      Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
      GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
      GameMidlet.PORT = (int) ServerListScreen.port[ServerListScreen.ipSelect];
      mResources.loadLanguague(ServerListScreen.language[ServerListScreen.ipSelect]);
      LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
      GameCanvas.connect();
    }
    else
    {
      ServerListScreen.ipSelect = Rms.loadRMSInt("svselect");
      if (ServerListScreen.ipSelect > ServerListScreen.nameServer.Length - 1)
      {
        ServerListScreen.ipSelect = (int) ServerListScreen.serverPriority;
        Rms.saveRMSInt("svselect", ServerListScreen.ipSelect);
      }
      GameMidlet.IP = ServerListScreen.address[ServerListScreen.ipSelect];
      GameMidlet.PORT = (int) ServerListScreen.port[ServerListScreen.ipSelect];
      mResources.loadLanguague(ServerListScreen.language[ServerListScreen.ipSelect]);
      LoginScr.serverName = ServerListScreen.nameServer[ServerListScreen.ipSelect];
      GameCanvas.connect();
    }
  }

  public override void paint(mGraphics g)
  {
    if (SplashScr.imgLogo != null && SplashScr.splashScrStat < 30)
    {
      g.setColor(16777215);
      g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
      g.drawImage(SplashScr.imgLogo, GameCanvas.w / 2, GameCanvas.h / 2, 3);
    }
    if (SplashScr.nData != -1)
    {
      g.setColor(0);
      g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
      g.drawImage(LoginScr.imgTitle, GameCanvas.w / 2, GameCanvas.h / 2 - 24, StaticObj.BOTTOM_HCENTER);
      GameCanvas.paintShukiren(GameCanvas.hw, GameCanvas.h / 2 + 24, g);
      mFont.tahoma_7b_white.drawString(g, mResources.downloading_data + (object) (SplashScr.nData * 100 / SplashScr.maxData) + "%", GameCanvas.w / 2, GameCanvas.h / 2, 2);
    }
    else
    {
      if (SplashScr.splashScrStat < 30)
        return;
      g.setColor(0);
      g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
      GameCanvas.paintShukiren(GameCanvas.hw, GameCanvas.hh, g);
      if (ServerListScreen.cmdDeleteRMS == null)
        return;
      mFont.tahoma_7_white.drawString(g, mResources.xoadulieu, GameCanvas.w - 2, GameCanvas.h - 15, 1, mFont.tahoma_7_grey);
    }
  }

  public static void loadImg() => SplashScr.imgLogo = GameCanvas.loadImage("/gamelogo.png");
}
