// Decompiled with JetBrains decompiler
// Type: EffectManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class EffectManager : MyVector
{
  public static EffectManager lowEffects = new EffectManager();
  public static EffectManager midEffects = new EffectManager();
  public static EffectManager hiEffects = new EffectManager();

  public void updateAll()
  {
    for (int index = this.size() - 1; index >= 0; --index)
    {
      Effect_End effectEnd = (Effect_End) this.elementAt(index);
      if (effectEnd != null)
      {
        effectEnd.update();
        if (effectEnd.isRemove)
          this.removeElementAt(index);
      }
    }
  }

  public static void update()
  {
    EffectManager.hiEffects.updateAll();
    EffectManager.midEffects.updateAll();
    EffectManager.lowEffects.updateAll();
  }

  public void paintAll(mGraphics g)
  {
    for (int index = 0; index < this.size(); ++index)
    {
      Effect_End effectEnd = (Effect_End) this.elementAt(index);
      if (effectEnd != null && !effectEnd.isRemove)
        ((Effect_End) this.elementAt(index)).paint(g);
    }
  }

  public void removeAll()
  {
    for (int index = this.size() - 1; index >= 0; --index)
    {
      Effect_End effectEnd = (Effect_End) this.elementAt(index);
      if (effectEnd != null)
      {
        effectEnd.isRemove = true;
        this.removeElementAt(index);
      }
    }
  }

  public static void addHiEffect(Effect_End eff) => EffectManager.hiEffects.addElement((object) eff);

  public static void removeHiEffect(Effect_End eff) => EffectManager.hiEffects.removeElement((object) eff);

  public static void addMidEffects(Effect_End eff) => EffectManager.midEffects.addElement((object) eff);

  public static void removeMidEffects(Effect_End eff) => EffectManager.midEffects.removeElement((object) eff);

  public static void addLowEffect(Effect_End eff) => EffectManager.lowEffects.addElement((object) eff);

  public static void removeLowEffect(Effect_End eff) => EffectManager.lowEffects.removeElement((object) eff);
}
