// Decompiled with JetBrains decompiler
// Type: EffecMn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class EffecMn
{
  public static MyVector vEff = new MyVector();

  public static void addEff(Effect me) => EffecMn.vEff.addElement((object) me);

  public static void removeEff(int id)
  {
    if (EffecMn.getEffById(id) == null)
      return;
    EffecMn.vEff.removeElement((object) EffecMn.getEffById(id));
  }

  public static Effect getEffById(int id)
  {
    for (int index = 0; index < EffecMn.vEff.size(); ++index)
    {
      Effect effById = (Effect) EffecMn.vEff.elementAt(index);
      if (effById.effId == id)
        return effById;
    }
    return (Effect) null;
  }

  public static void paintBackGroundUnderLayer(mGraphics g, int x, int y, int layer)
  {
    for (int index = 0; index < EffecMn.vEff.size(); ++index)
    {
      if (((Effect) EffecMn.vEff.elementAt(index)).layer == -layer)
        ((Effect) EffecMn.vEff.elementAt(index)).paintUnderBackground(g, x, y);
    }
  }

  public static void paintLayer1(mGraphics g)
  {
    for (int index = 0; index < EffecMn.vEff.size(); ++index)
    {
      if (((Effect) EffecMn.vEff.elementAt(index)).layer == 1)
        ((Effect) EffecMn.vEff.elementAt(index)).paint(g);
    }
  }

  public static void paintLayer2(mGraphics g)
  {
    for (int index = 0; index < EffecMn.vEff.size(); ++index)
    {
      if (((Effect) EffecMn.vEff.elementAt(index)).layer == 2)
        ((Effect) EffecMn.vEff.elementAt(index)).paint(g);
    }
  }

  public static void paintLayer3(mGraphics g)
  {
    for (int index = 0; index < EffecMn.vEff.size(); ++index)
    {
      if (((Effect) EffecMn.vEff.elementAt(index)).layer == 3)
        ((Effect) EffecMn.vEff.elementAt(index)).paint(g);
    }
  }

  public static void paintLayer4(mGraphics g)
  {
    for (int index = 0; index < EffecMn.vEff.size(); ++index)
    {
      if (((Effect) EffecMn.vEff.elementAt(index)).layer == 4)
        ((Effect) EffecMn.vEff.elementAt(index)).paint(g);
    }
  }

  public static void update()
  {
    for (int index = 0; index < EffecMn.vEff.size(); ++index)
      ((Effect) EffecMn.vEff.elementAt(index)).update();
  }
}
