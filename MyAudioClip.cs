// Decompiled with JetBrains decompiler
// Type: MyAudioClip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MyAudioClip
{
  public string name;
  public AudioClip clip;
  public long timeStart;

  public MyAudioClip(string filename)
  {
    this.clip = (AudioClip) Resources.Load(filename);
    this.name = filename;
  }

  public void Play()
  {
    Main.main.GetComponent<AudioSource>().PlayOneShot(this.clip);
    this.timeStart = mSystem.currentTimeMillis();
  }

  public bool isPlaying() => false;
}
