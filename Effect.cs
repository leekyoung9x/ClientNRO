// Decompiled with JetBrains decompiler
// Type: Effect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class Effect
{
  public int effId;
  public int typeEff;
  public int indexFrom;
  public int indexTo;
  public bool isNearPlayer;
  public const int NEAR_PLAYER = 0;
  public const int LOOP_NORMAL = 1;
  public const int LOOP_TRANS = 2;
  public const int BACKGROUND = 3;
  public const int CHAR = 4;
  public const int FIRE_TD = 0;
  public const int BIRD = 1;
  public const int FIRE_NAMEK = 2;
  public const int FIRE_SAYAI = 3;
  public const int FROG = 5;
  public const int CA = 4;
  public const int ECH = 6;
  public const int TACKE = 7;
  public const int RAN = 8;
  public const int KHI = 9;
  public const int GACON = 10;
  public const int DANONG = 11;
  public const int DANBUOM = 12;
  public const int QUA = 13;
  public const int THIENTHACH = 14;
  public const int CAVOI = 15;
  public const int NAM = 16;
  public const int RONGTHAN = 17;
  public const int BUOMBAY = 26;
  public const int KHUCGO = 27;
  public const int DOIBAY = 28;
  public const int CONMEO = 29;
  public const int LUATAT = 30;
  public const int ONGCONG = 31;
  public const int KHANGIA1 = 42;
  public const int KHANGIA2 = 43;
  public const int KHANGIA3 = 44;
  public const int KHANGIA4 = 45;
  public const int KHANGIA5 = 46;
  public Char c;
  public int t;
  public int currFrame;
  public int x;
  public int y;
  public int loop;
  public int tLoop;
  public int tLoopCount;
  private bool isPaint = true;
  public int layer;
  public int isStand;
  public static MyVector vEffData = new MyVector();
  public int trans;
  public static MyVector lastEff = new MyVector();
  public static MyVector newEff = new MyVector();
  private int[] khangia1 = new int[10]
  {
    0,
    0,
    0,
    0,
    0,
    1,
    1,
    1,
    1,
    1
  };
  private int[] khangia2 = new int[10]
  {
    2,
    2,
    2,
    2,
    2,
    3,
    3,
    3,
    3,
    3
  };
  private int[] khangia3 = new int[10]
  {
    4,
    4,
    4,
    4,
    4,
    5,
    5,
    5,
    5,
    5
  };
  private int[] khangia4 = new int[10]
  {
    6,
    6,
    6,
    6,
    6,
    7,
    7,
    7,
    7,
    7
  };
  private int[] khangia5 = new int[10]
  {
    8,
    8,
    8,
    8,
    8,
    9,
    9,
    9,
    9,
    9
  };
  private bool isGetTime;

  public Effect()
  {
  }

  public Effect(int id, Char c, int layer, int loop, int loopCount, sbyte isStand)
  {
    this.c = c;
    this.effId = id;
    this.layer = layer;
    this.loop = loop;
    this.tLoop = loopCount;
    this.isStand = (int) isStand;
    if (Effect.getEffDataById(id) == null)
    {
      EffectData eff = new EffectData();
      eff.ID = id;
      if (id >= 42 && id <= 46)
        id = 106;
      string str = "/x" + (object) mGraphics.zoomLevel + "/effectdata/" + (object) id + "/data";
      if (MyStream.readFile(str) != null)
      {
        if (id > 100 && id < 200)
          eff.readData2(str);
        else
          eff.readData(str);
        eff.img = GameCanvas.loadImage("/effectdata/" + (object) id + "/img.png");
      }
      else
        Service.gI().getEffData((short) id);
      Effect.addEffData(eff);
    }
    this.indexFrom = -1;
    this.indexTo = -1;
    this.trans = -1;
    this.typeEff = 4;
  }

  public Effect(int id, int x, int y, int layer, int loop, int loopCount)
  {
    this.x = x;
    this.y = y;
    this.effId = id;
    this.layer = layer;
    this.loop = loop;
    this.tLoop = loopCount;
    if (Effect.getEffDataById(id) == null)
    {
      EffectData eff = new EffectData();
      eff.ID = id;
      if (id >= 42 && id <= 46)
        id = 106;
      string str = "/x" + (object) mGraphics.zoomLevel + "/effectdata/" + (object) id + "/data";
      if (MyStream.readFile(str) != null)
      {
        if (id > 100 && id < 200)
          eff.readData2(str);
        else
          eff.readData(str);
        eff.img = GameCanvas.loadImage("/effectdata/" + (object) id + "/img.png");
      }
      else
        Service.gI().getEffData((short) id);
      Effect.addEffData(eff);
      Effect.lastEff.addElement((object) (this.effId.ToString() + string.Empty));
    }
    this.indexFrom = -1;
    this.indexTo = -1;
    this.typeEff = 1;
    if (Effect.isExistNewEff(this.effId.ToString() + string.Empty))
      return;
    Effect.newEff.addElement((object) (this.effId.ToString() + string.Empty));
  }

  public static void removeEffData(int id)
  {
    for (int index = 0; index < Effect.vEffData.size(); ++index)
    {
      EffectData o = (EffectData) Effect.vEffData.elementAt(index);
      if (o.ID == id)
      {
        Effect.vEffData.removeElement((object) o);
        break;
      }
    }
  }

  public static void addEffData(EffectData eff)
  {
    Effect.vEffData.addElement((object) eff);
    if (TileMap.mapID == 130 || Effect.vEffData.size() <= 10)
      return;
    for (int index = 0; index < 5; ++index)
      Effect.vEffData.removeElementAt(0);
  }

  public static EffectData getEffDataById(int id)
  {
    for (int index = 0; index < Effect.vEffData.size(); ++index)
    {
      EffectData effDataById = (EffectData) Effect.vEffData.elementAt(index);
      if (effDataById.ID == id)
        return effDataById;
    }
    return (EffectData) null;
  }

  public static bool isExistNewEff(string id)
  {
    for (int index = 0; index < Effect.newEff.size(); ++index)
    {
      if (((string) Effect.newEff.elementAt(index)).Equals(id))
        return true;
    }
    return false;
  }

  public bool isPaintz() => this.isPaint;

  public void paintUnderBackground(mGraphics g, int xLayer, int yLayer)
  {
    if (!this.isPaintz() || Effect.getEffDataById(this.effId).img == null)
      return;
    Effect.getEffDataById(this.effId).paintFrame(g, this.currFrame, this.x + xLayer, this.y + yLayer, this.trans, this.layer);
  }

  public void getFrameKhangia()
  {
    if (this.effId == 42)
      this.currFrame = this.khangia1[this.t];
    if (this.effId == 43)
      this.currFrame = this.khangia2[this.t];
    if (this.effId == 44)
      this.currFrame = this.khangia3[this.t];
    if (this.effId == 45)
      this.currFrame = this.khangia4[this.t];
    if (this.effId == 46)
      this.currFrame = this.khangia5[this.t];
    ++this.t;
    if (this.t <= this.khangia1.Length - 1)
      return;
    this.t = 0;
  }

  public void paint(mGraphics g)
  {
    if (!this.isPaintz() || Effect.getEffDataById(this.effId) == null || Effect.getEffDataById(this.effId).img == null)
      return;
    Effect.getEffDataById(this.effId).paintFrame(g, this.currFrame, this.x, this.y, this.trans, this.layer);
  }

  public void update()
  {
    try
    {
      if (this.effId >= 42 && this.effId <= 46)
      {
        this.getFrameKhangia();
      }
      else
      {
        if (Effect.getEffDataById(this.effId) == null || Effect.getEffDataById(this.effId).img == null)
          return;
        if (Effect.getEffDataById(this.effId).arrFrame != null)
        {
          if (!this.isGetTime)
          {
            this.isGetTime = true;
            int b = Effect.getEffDataById(this.effId).arrFrame.Length - 1;
            if (b > 0 && this.typeEff != 1)
              this.t = Res.random(0, b);
            if (this.typeEff == 0)
              this.t = Res.random(this.indexFrom, this.indexTo);
          }
          switch (this.typeEff)
          {
            case 0:
              if (Res.inRect(this.x - 50, this.y - 50, 100, 100, Char.myCharz().cx, Char.myCharz().cy) && this.t > this.indexFrom && this.t < this.indexTo)
              {
                if (this.t < this.indexTo)
                  this.t = this.indexTo;
                this.isNearPlayer = true;
              }
              if (!this.isNearPlayer)
              {
                ++this.t;
                if (this.t == this.indexTo)
                {
                  this.t = this.indexFrom;
                  break;
                }
                break;
              }
              if (this.t < Effect.getEffDataById(this.effId).arrFrame.Length)
              {
                ++this.t;
                break;
              }
              break;
            case 1:
            case 3:
              if (this.t < Effect.getEffDataById(this.effId).arrFrame.Length)
              {
                ++this.t;
                break;
              }
              break;
            case 2:
              if (this.t < Effect.getEffDataById(this.effId).arrFrame.Length)
                ++this.t;
              ++this.tLoopCount;
              if (this.tLoopCount == this.tLoop)
              {
                this.tLoopCount = 0;
                this.trans = Res.random(0, 2);
                break;
              }
              break;
            case 4:
              this.x = this.c.cx;
              this.y = this.c.cy;
              if (this.t < Effect.getEffDataById(this.effId).arrFrame.Length)
              {
                ++this.t;
                break;
              }
              break;
          }
          if (this.t == Effect.getEffDataById(this.effId).arrFrame.Length / 2 && (this.effId == 62 || this.effId == 63 || this.effId == 64 || this.effId == 65))
            SoundMn.playSound(this.x, this.y, SoundMn.FIREWORK, SoundMn.volume);
          if (this.t <= Effect.getEffDataById(this.effId).arrFrame.Length - 1)
            this.currFrame = (int) Effect.getEffDataById(this.effId).arrFrame[this.t];
        }
        if (this.t >= Effect.getEffDataById(this.effId).arrFrame.Length - 1)
        {
          if (this.typeEff == 0 || this.typeEff == 3)
            this.isPaint = false;
          if (this.tLoop == -1)
            EffecMn.vEff.removeElement((object) this);
          if (this.typeEff == 2)
          {
            this.t = 0;
          }
          else
          {
            if (this.typeEff == 1 && this.loop == 1)
              this.isPaint = false;
            if (this.typeEff == 4)
            {
              if (this.loop == -1)
              {
                this.t = 0;
              }
              else
              {
                ++this.tLoopCount;
                if (this.tLoopCount != this.tLoop)
                  return;
                this.tLoopCount = 0;
                --this.loop;
                this.t = 0;
                if (this.loop != 0)
                  return;
                this.c.removeEffChar(0, this.effId);
              }
            }
            else
            {
              this.isNearPlayer = false;
              if (this.loop == -1)
              {
                ++this.tLoopCount;
                if (this.tLoopCount != this.tLoop)
                  return;
                this.tLoopCount = 0;
                this.t = 0;
                if (this.tLoop <= 1)
                  return;
                this.trans = Res.random(0, 2);
              }
              else
              {
                ++this.tLoopCount;
                if (this.tLoopCount != this.tLoop)
                  return;
                this.tLoopCount = 0;
                --this.loop;
                this.t = 0;
                if (this.loop != 0)
                  return;
                EffecMn.vEff.removeElement((object) this);
              }
            }
          }
        }
        else
          this.isPaint = true;
      }
    }
    catch (Exception ex)
    {
      EffecMn.vEff.removeElement((object) this);
    }
  }
}
