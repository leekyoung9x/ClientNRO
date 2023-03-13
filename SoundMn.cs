// Decompiled with JetBrains decompiler
// Type: SoundMn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class SoundMn
{
  public static bool IsDelAcc;
  public static SoundMn gIz;
  public static bool isSound = true;
  public static float volume = 0.5f;
  private static int MAX_VOLUME = 10;
  public static SoundMn.MediaPlayer[] music;
  public static SoundMn.SoundPool[] sound;
  public static int[] soundID;
  public static int AIR_SHIP;
  public static int RAIN = 1;
  public static int TAITAONANGLUONG = 2;
  public static int GET_ITEM;
  public static int MOVE = 1;
  public static int LOW_PUNCH = 2;
  public static int LOW_KICK = 3;
  public static int FLY = 4;
  public static int JUMP = 5;
  public static int PANEL_OPEN = 6;
  public static int BUTTON_CLOSE = 7;
  public static int BUTTON_CLICK = 8;
  public static int MEDIUM_PUNCH = 9;
  public static int MEDIUM_KICK = 10;
  public static int PANEL_CLICK = 11;
  public static int EAT_PEAN = 12;
  public static int OPEN_DIALOG = 13;
  public static int NORMAL_KAME = 14;
  public static int NAMEK_KAME = 15;
  public static int XAYDA_KAME = 16;
  public static int EXPLODE_1 = 17;
  public static int EXPLODE_2 = 18;
  public static int TRAIDAT_KAME = 19;
  public static int HP_UP = 20;
  public static int THAIDUONGHASAN = 21;
  public static int HOISINH = 22;
  public static int GONG = 23;
  public static int KHICHAY = 24;
  public static int BIG_EXPLODE = 25;
  public static int NAMEK_LAZER = 26;
  public static int NAMEK_CHARGE = 27;
  public static int RADAR_CLICK = 28;
  public static int RADAR_ITEM = 29;
  public static int FIREWORK = 30;
  public bool freePool;
  public int poolCount;
  public static int cout = 1;

  public static void init(SoundMn.AssetManager ac) => Sound.setActivity(ac);

  public static SoundMn gI()
  {
    if (SoundMn.gIz == null)
      SoundMn.gIz = new SoundMn();
    return SoundMn.gIz;
  }

  public void loadSound(int mapID) => Sound.init(new int[3]
  {
    SoundMn.AIR_SHIP,
    SoundMn.RAIN,
    SoundMn.TAITAONANGLUONG
  }, new int[31]
  {
    SoundMn.GET_ITEM,
    SoundMn.MOVE,
    SoundMn.LOW_PUNCH,
    SoundMn.LOW_KICK,
    SoundMn.FLY,
    SoundMn.JUMP,
    SoundMn.PANEL_OPEN,
    SoundMn.BUTTON_CLOSE,
    SoundMn.BUTTON_CLICK,
    SoundMn.MEDIUM_PUNCH,
    SoundMn.MEDIUM_KICK,
    SoundMn.PANEL_OPEN,
    SoundMn.EAT_PEAN,
    SoundMn.OPEN_DIALOG,
    SoundMn.NORMAL_KAME,
    SoundMn.NAMEK_KAME,
    SoundMn.XAYDA_KAME,
    SoundMn.EXPLODE_1,
    SoundMn.EXPLODE_2,
    SoundMn.TRAIDAT_KAME,
    SoundMn.HP_UP,
    SoundMn.THAIDUONGHASAN,
    SoundMn.HOISINH,
    SoundMn.GONG,
    SoundMn.KHICHAY,
    SoundMn.BIG_EXPLODE,
    SoundMn.NAMEK_LAZER,
    SoundMn.NAMEK_CHARGE,
    SoundMn.RADAR_CLICK,
    SoundMn.RADAR_ITEM,
    SoundMn.FIREWORK
  });

  public void getSoundOption()
  {
    if (GameCanvas.loginScr.isLogin2 && Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.taskId >= (short) 2)
    {
      Panel.strTool = new string[10]
      {
        mResources.radaCard,
        mResources.quayso,
        mResources.gameInfo,
        mResources.change_flag,
        mResources.change_zone,
        mResources.chat_world,
        mResources.account,
        mResources.option,
        mResources.change_account,
        mResources.REGISTOPROTECT
      };
      if (Char.myCharz().havePet)
        Panel.strTool = new string[11]
        {
          mResources.radaCard,
          mResources.quayso,
          mResources.gameInfo,
          mResources.pet,
          mResources.change_flag,
          mResources.change_zone,
          mResources.chat_world,
          mResources.account,
          mResources.option,
          mResources.change_account,
          mResources.REGISTOPROTECT
        };
    }
    else
    {
      Panel.strTool = new string[9]
      {
        mResources.radaCard,
        mResources.quayso,
        mResources.gameInfo,
        mResources.change_flag,
        mResources.change_zone,
        mResources.chat_world,
        mResources.account,
        mResources.option,
        mResources.change_account
      };
      if (Char.myCharz().havePet)
        Panel.strTool = new string[10]
        {
          mResources.radaCard,
          mResources.quayso,
          mResources.gameInfo,
          mResources.pet,
          mResources.change_flag,
          mResources.change_zone,
          mResources.chat_world,
          mResources.account,
          mResources.option,
          mResources.change_account
        };
    }
    if (!SoundMn.IsDelAcc)
      return;
    string[] strArray = new string[Panel.strTool.Length + 1];
    for (int index = 0; index < Panel.strTool.Length; ++index)
      strArray[index] = Panel.strTool[index];
    strArray[Panel.strTool.Length] = mResources.delacc;
    Panel.strTool = strArray;
  }

  public void getStrOption()
  {
    if (Main.isPC)
      Panel.strCauhinh = new string[4]
      {
        Char.myCharz().idHat == (short) -1 ? mResources.hat_on : mResources.hat_off,
        !Char.isPaintAura ? mResources.aura_on : mResources.aura_off,
        !GameCanvas.isPlaySound ? mResources.turnOnSound : mResources.turnOffSound,
        mGraphics.zoomLevel <= 1 ? mResources.x2Screen : mResources.x1Screen
      };
    else
      Panel.strCauhinh = new string[4]
      {
        Char.myCharz().idHat == (short) -1 ? mResources.hat_on : mResources.hat_off,
        !Char.isPaintAura ? mResources.aura_on : mResources.aura_off,
        !GameCanvas.isPlaySound ? mResources.turnOnSound : mResources.turnOffSound,
        GameScr.isAnalog != 0 ? mResources.turnOffAnalog : mResources.turnOnAnalog
      };
  }

  public void HP_MPup() => Sound.playSound(SoundMn.HP_UP, 0.5f);

  public void charPunch(bool isKick, float volumn)
  {
    if (!Char.myCharz().me)
      SoundMn.volume /= 2f;
    if ((double) volumn <= 0.0)
      volumn = 0.01f;
    int num = Res.random(0, 3);
    if (isKick)
      Sound.playSound(num != 0 ? SoundMn.MEDIUM_KICK : SoundMn.LOW_KICK, 0.1f);
    else
      Sound.playSound(num != 0 ? SoundMn.MEDIUM_PUNCH : SoundMn.LOW_PUNCH, 0.1f);
    ++this.poolCount;
  }

  public void thaiduonghasan()
  {
    Sound.playSound(SoundMn.THAIDUONGHASAN, 0.5f);
    ++this.poolCount;
  }

  public void rain() => Sound.playMus(SoundMn.RAIN, 0.3f, true);

  public void gongName()
  {
    Sound.playSound(SoundMn.NAMEK_CHARGE, 0.3f);
    ++this.poolCount;
  }

  public void gong()
  {
    Sound.playSound(SoundMn.GONG, 0.2f);
    ++this.poolCount;
  }

  public void getItem()
  {
    Sound.playSound(SoundMn.GET_ITEM, 0.3f);
    ++this.poolCount;
  }

  public void soundToolOption()
  {
    GameCanvas.isPlaySound = !GameCanvas.isPlaySound;
    if (GameCanvas.isPlaySound)
    {
      SoundMn.gI().loadSound(TileMap.mapID);
      Rms.saveRMSInt("isPlaySound", 1);
    }
    else
    {
      SoundMn.gI().closeSound();
      Rms.saveRMSInt("isPlaySound", 0);
    }
    this.getStrOption();
  }

  public void AuraToolOption()
  {
    if (Char.isPaintAura)
    {
      Rms.saveRMSInt("isPaintAura", 0);
      Char.isPaintAura = false;
    }
    else
    {
      Rms.saveRMSInt("isPaintAura", 1);
      Char.isPaintAura = true;
    }
    this.getStrOption();
  }

  public void HatToolOption() => Service.gI().sendOptHat();

  public void update()
  {
  }

  public void closeSound()
  {
    Sound.stopAll = true;
    this.stopAll();
  }

  public void openSound()
  {
    if (Sound.music == null)
      this.loadSound(0);
    Sound.stopAll = false;
  }

  public void bigeExlode()
  {
    Sound.playSound(SoundMn.BIG_EXPLODE, 0.5f);
    ++this.poolCount;
  }

  public void explode_1()
  {
    Sound.playSound(SoundMn.EXPLODE_1, 0.5f);
    ++this.poolCount;
  }

  public void explode_2()
  {
    Sound.playSound(SoundMn.EXPLODE_1, 0.5f);
    ++this.poolCount;
  }

  public void traidatKame()
  {
    Sound.playSound(SoundMn.TRAIDAT_KAME, 1f);
    ++this.poolCount;
  }

  public void namekKame()
  {
    Sound.playSound(SoundMn.NAMEK_KAME, 0.3f);
    ++this.poolCount;
  }

  public void nameLazer()
  {
    Sound.playSound(SoundMn.NAMEK_LAZER, 0.3f);
    ++this.poolCount;
  }

  public void xaydaKame()
  {
    Sound.playSound(SoundMn.XAYDA_KAME, 0.3f);
    ++this.poolCount;
  }

  public void mobKame(int type)
  {
    int id = SoundMn.XAYDA_KAME;
    if (type == 13)
      id = SoundMn.NORMAL_KAME;
    Sound.playSound(id, 0.1f);
    ++this.poolCount;
  }

  public void charRun(float volumn)
  {
    if (!Char.myCharz().me)
    {
      SoundMn.volume /= 2f;
      if ((double) volumn <= 0.0)
        volumn = 0.01f;
    }
    if (GameCanvas.gameTick % 8 != 0)
      return;
    Sound.playSound(SoundMn.MOVE, volumn);
    ++this.poolCount;
  }

  public void monkeyRun(float volumn)
  {
    if (GameCanvas.gameTick % 8 != 0)
      return;
    Sound.playSound(SoundMn.KHICHAY, 0.2f);
    ++this.poolCount;
  }

  public void charFall()
  {
    Sound.playSound(SoundMn.MOVE, 0.1f);
    ++this.poolCount;
  }

  public void charJump()
  {
    Sound.playSound(SoundMn.MOVE, 0.2f);
    ++this.poolCount;
  }

  public void panelOpen()
  {
    Sound.playSound(SoundMn.PANEL_OPEN, 0.5f);
    ++this.poolCount;
  }

  public void buttonClose()
  {
    Sound.playSound(SoundMn.BUTTON_CLOSE, 0.5f);
    ++this.poolCount;
  }

  public void buttonClick()
  {
    Sound.playSound(SoundMn.BUTTON_CLICK, 0.5f);
    ++this.poolCount;
  }

  public void stopMove()
  {
  }

  public void charFly()
  {
    Sound.playSound(SoundMn.FLY, 0.2f);
    ++this.poolCount;
  }

  public void stopFly()
  {
  }

  public void openMenu()
  {
    Sound.playSound(SoundMn.BUTTON_CLOSE, 0.5f);
    ++this.poolCount;
  }

  public void panelClick()
  {
    Sound.playSound(SoundMn.PANEL_CLICK, 0.5f);
    ++this.poolCount;
  }

  public void eatPeans()
  {
    Sound.playSound(SoundMn.EAT_PEAN, 0.5f);
    ++this.poolCount;
  }

  public void openDialog() => Sound.playSound(SoundMn.OPEN_DIALOG, 0.5f);

  public void hoisinh()
  {
    Sound.playSound(SoundMn.HOISINH, 0.5f);
    ++this.poolCount;
  }

  public void taitao() => Sound.playMus(SoundMn.TAITAONANGLUONG, 0.5f, true);

  public void taitaoPause()
  {
  }

  public bool isPlayRain()
  {
    try
    {
      return Sound.isPlayingSound();
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool isPlayAirShip() => false;

  public void airShip()
  {
    ++SoundMn.cout;
    if (SoundMn.cout % 2 != 0)
      return;
    Sound.playMus(SoundMn.AIR_SHIP, 0.3f, false);
  }

  public void pauseAirShip()
  {
  }

  public void resumeAirShip()
  {
  }

  public void stopAll() => Sound.stopAllz();

  public void backToRegister()
  {
    Session_ME.gI().close();
    GameCanvas.panel.hide();
    GameCanvas.loginScr.actRegister();
    GameCanvas.loginScr.switchToMe();
  }

  public void newKame()
  {
    ++this.poolCount;
    if (this.poolCount % 15 != 0)
      return;
    Sound.playSound(SoundMn.TRAIDAT_KAME, 0.5f);
  }

  public void radarClick() => Sound.playSound(SoundMn.RADAR_CLICK, 0.5f);

  public void radarItem() => Sound.playSound(SoundMn.RADAR_ITEM, 0.5f);

  public static void playSound(int x, int y, int id, float volume) => Sound.playSound(id, volume);

  public class MediaPlayer
  {
  }

  public class SoundPool
  {
  }

  public class AssetManager
  {
  }
}
