// Decompiled with JetBrains decompiler
// Type: Sound
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System.Threading;
using UnityEngine;

public class Sound
{
  private const int INTERVAL = 5;
  private const int MAXTIME = 100;
  public static int status;
  public static int postem;
  public static int timestart;
  private static string filenametemp;
  private static float volumetem;
  public static bool isSound = true;
  public static bool isNotPlay;
  public static bool stopAll;
  public static AudioSource SoundWater;
  public static AudioSource SoundRun;
  public static AudioSource SoundBGLoop;
  public static AudioClip[] music;
  public static GameObject[] player;
  public static string[] fileName = new string[34]
  {
    "0",
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "10",
    "11",
    "12",
    "13",
    "14",
    "15",
    "16",
    "17",
    "18",
    "19",
    "29",
    "21",
    "22",
    "23",
    "24",
    "25",
    "26",
    "27",
    "28",
    "29",
    "30",
    "31",
    "32",
    "33"
  };
  public static sbyte MLogin = 0;
  public static sbyte MBClick = 1;
  public static sbyte MTone = 2;
  public static sbyte MSanzu = 3;
  public static sbyte MChakumi = 4;
  public static sbyte MChai = 5;
  public static sbyte MOshin = 6;
  public static sbyte MEchigo = 7;
  public static sbyte MKojin = 8;
  public static sbyte MHaruna = 9;
  public static sbyte MHirosaki = 10;
  public static sbyte MOokaza = 11;
  public static sbyte MGiotuyet = 12;
  public static sbyte MHangdong = 13;
  public static sbyte MDeKeu = 14;
  public static sbyte MChimKeu = 15;
  public static sbyte MBuocChan = 16;
  public static sbyte MNuocChay = 17;
  public static sbyte MBomMau = 18;
  public static sbyte MKiemGo = 19;
  public static sbyte MKiem = 20;
  public static sbyte MTieu = 21;
  public static sbyte MKunai = 22;
  public static sbyte MCung = 23;
  public static sbyte MDao = 24;
  public static sbyte MQuat = 25;
  public static sbyte MCung2 = 26;
  public static sbyte MTieu2 = 27;
  public static sbyte MTieu3 = 28;
  public static sbyte MKiem2 = 29;
  public static sbyte MKiem3 = 30;
  public static sbyte MDao2 = 31;
  public static sbyte MDao3 = 32;
  public static sbyte MCung3 = 33;
  public static int l1;

  public static void setActivity(SoundMn.AssetManager ac)
  {
  }

  public static void stop()
  {
    for (int index = 0; index < Sound.player.Length; ++index)
    {
      if ((Object) Sound.player[index] != (Object) null)
        Sound.player[index].GetComponent<AudioSource>().Pause();
    }
  }

  public static bool isPlaying() => false;

  public static void init()
  {
    GameObject gameObject = new GameObject();
    gameObject.name = "Audio Player";
    gameObject.transform.position = Vector3.zero;
    gameObject.AddComponent<AudioListener>();
    Sound.SoundBGLoop = gameObject.AddComponent<AudioSource>();
  }

  public static void init(int[] musicID, int[] sID)
  {
    if (Sound.player != null || Sound.music != null)
      return;
    Sound.init();
    Sound.l1 = musicID.Length;
    Sound.player = new GameObject[musicID.Length + sID.Length];
    Sound.music = new AudioClip[musicID.Length + sID.Length];
    for (int pos = 0; pos < Sound.player.Length; ++pos)
      Sound.getAssetSoundFile(pos >= Sound.l1 ? "/sound/" + (object) (pos - Sound.l1) : "/music/" + (object) pos, pos);
  }

  public static void playSound(int id, float volume) => Sound.play(id + Sound.l1, volume);

  public static void playSound1(int id, float volume) => Sound.play(id, volume);

  public static void getAssetSoundFile(string fileName, int pos)
  {
    Sound.stop(pos);
    string empty = string.Empty;
    Sound.load(Main.res + fileName, pos);
  }

  public static void stopAllz()
  {
    for (int pos = 0; pos < Sound.music.Length; ++pos)
      Sound.stop(pos);
    for (int id = 0; id < Sound.l1; ++id)
      Sound.sTopSoundBG(id);
  }

  public static void stopAllBg()
  {
    for (int pos = 0; pos < Sound.music.Length; ++pos)
      Sound.stop(pos);
    Sound.sTopSoundBG(0);
    Sound.sTopSoundRun();
    Sound.stopSoundNatural(0);
  }

  public static void update()
  {
  }

  public static void stopMusic(int x)
  {
    if (!GameCanvas.isPlaySound)
      return;
    Sound.stop(x);
  }

  public static void play(int id, float volume)
  {
    if (Sound.isNotPlay || !GameCanvas.isPlaySound)
      return;
    Sound.start(volume, id);
  }

  public static void playSoundRun(int id, float volume)
  {
    if (!GameCanvas.isPlaySound || (Object) Sound.SoundRun == (Object) null)
      return;
    Sound.SoundRun.GetComponent<AudioSource>().loop = true;
    Sound.SoundRun.GetComponent<AudioSource>().clip = Sound.music[id];
    Sound.SoundRun.GetComponent<AudioSource>().volume = volume;
    Sound.SoundRun.GetComponent<AudioSource>().Play();
  }

  public static void sTopSoundRun() => Sound.SoundRun.GetComponent<AudioSource>().Stop();

  public static bool isPlayingSound() => !((Object) Sound.SoundRun == (Object) null) && Sound.SoundRun.GetComponent<AudioSource>().isPlaying;

  public static void playSoundNatural(int id, float volume, bool isLoop)
  {
    if (!GameCanvas.isPlaySound || (Object) Sound.SoundBGLoop == (Object) null)
      return;
    Sound.SoundWater.GetComponent<AudioSource>().loop = isLoop;
    Sound.SoundWater.GetComponent<AudioSource>().clip = Sound.music[id];
    Sound.SoundWater.GetComponent<AudioSource>().volume = volume;
    Sound.SoundWater.GetComponent<AudioSource>().Play();
  }

  public static void stopSoundNatural(int id) => Sound.SoundWater.GetComponent<AudioSource>().Stop();

  public static bool isPlayingSoundatural(int id) => !((Object) Sound.SoundWater == (Object) null) && Sound.SoundWater.GetComponent<AudioSource>().isPlaying;

  public static void playMus(int type, float vl, bool loop)
  {
    if (Sound.isNotPlay)
      return;
    vl -= 0.3f;
    if ((double) vl <= 0.0)
      vl = 0.01f;
    Sound.playSoundBGLoop(type, vl);
  }

  public static void playSoundBGLoop(int id, float volume)
  {
    if (!GameCanvas.isPlaySound)
      return;
    if (id == SoundMn.AIR_SHIP)
    {
      Sound.playSound1(id, volume + 0.2f);
    }
    else
    {
      if ((Object) Sound.SoundBGLoop == (Object) null || Sound.isPlayingSoundBG(id))
        return;
      Sound.SoundBGLoop.GetComponent<AudioSource>().loop = true;
      Sound.SoundBGLoop.GetComponent<AudioSource>().clip = Sound.music[id];
      Sound.SoundBGLoop.GetComponent<AudioSource>().volume = volume;
      Sound.SoundBGLoop.GetComponent<AudioSource>().Play();
    }
  }

  public static void sTopSoundBG(int id) => Sound.SoundBGLoop.GetComponent<AudioSource>().Stop();

  public static bool isPlayingSoundBG(int id) => !((Object) Sound.SoundBGLoop == (Object) null) && Sound.SoundBGLoop.GetComponent<AudioSource>().isPlaying;

  public static void load(string filename, int pos)
  {
    if (Thread.CurrentThread.Name == Main.mainThreadName)
      Sound.__load(filename, pos);
    else
      Sound._load(filename, pos);
  }

  private static void _load(string filename, int pos)
  {
    if (Sound.status != 0)
    {
      Cout.LogError("CANNOT LOAD AUDIO " + filename + " WHEN LOADING " + Sound.filenametemp);
    }
    else
    {
      Sound.filenametemp = filename;
      Sound.postem = pos;
      Sound.status = 2;
      int num;
      for (num = 0; num < 100; ++num)
      {
        Thread.Sleep(5);
        if (Sound.status == 0)
          break;
      }
      if (num == 100)
        Cout.LogError("TOO LONG FOR LOAD AUDIO " + filename);
      else
        Cout.Log("Load Audio " + filename + " done in " + (object) (num * 5) + "ms");
    }
  }

  private static void __load(string filename, int pos)
  {
    Sound.music[pos] = (AudioClip) Resources.Load(filename, typeof (AudioClip));
    GameObject.Find("Main Camera").AddComponent<AudioSource>();
    Sound.player[pos] = GameObject.Find("Main Camera");
  }

  public static void start(float volume, int pos)
  {
    if (Thread.CurrentThread.Name == Main.mainThreadName)
      Sound.__start(volume, pos);
    else
      Sound._start(volume, pos);
  }

  public static void _start(float volume, int pos)
  {
    if (Sound.status != 0)
    {
      Debug.LogError((object) "CANNOT START AUDIO WHEN STARTING");
    }
    else
    {
      Sound.volumetem = volume;
      Sound.postem = pos;
      Sound.status = 3;
      int num;
      for (num = 0; num < 100; ++num)
      {
        Thread.Sleep(5);
        if (Sound.status == 0)
          break;
      }
      if (num == 100)
        Debug.LogError((object) "TOO LONG FOR START AUDIO");
      else
        Debug.Log((object) ("Start Audio done in " + (object) (num * 5) + "ms"));
    }
  }

  public static void __start(float volume, int pos)
  {
    if ((Object) Sound.player[pos] == (Object) null)
      return;
    Sound.player[pos].GetComponent<AudioSource>().PlayOneShot(Sound.music[pos], volume);
  }

  public static void stop(int pos)
  {
    if (Thread.CurrentThread.Name == Main.mainThreadName)
      Sound.__stop(pos);
    else
      Sound._stop(pos);
  }

  public static void _stop(int pos)
  {
    if (Sound.status != 0)
    {
      Debug.LogError((object) "CANNOT STOP AUDIO WHEN STOPPING");
    }
    else
    {
      Sound.postem = pos;
      Sound.status = 4;
      int num;
      for (num = 0; num < 100; ++num)
      {
        Thread.Sleep(5);
        if (Sound.status == 0)
          break;
      }
      if (num == 100)
        Debug.LogError((object) "TOO LONG FOR STOP AUDIO");
      else
        Debug.Log((object) ("Stop Audio done in " + (object) (num * 5) + "ms"));
    }
  }

  public static void __stop(int pos)
  {
    if (!((Object) Sound.player[pos] != (Object) null))
      return;
    Sound.player[pos].GetComponent<AudioSource>().Stop();
  }
}
