// Decompiled with JetBrains decompiler
// Type: MyKeyMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class MyKeyMap
{
  private static Hashtable h = new Hashtable();

  static MyKeyMap()
  {
    MyKeyMap.h.Add((object) KeyCode.A, (object) 97);
    MyKeyMap.h.Add((object) KeyCode.B, (object) 98);
    MyKeyMap.h.Add((object) KeyCode.C, (object) 99);
    MyKeyMap.h.Add((object) KeyCode.D, (object) 100);
    MyKeyMap.h.Add((object) KeyCode.E, (object) 101);
    MyKeyMap.h.Add((object) KeyCode.F, (object) 102);
    MyKeyMap.h.Add((object) KeyCode.G, (object) 103);
    MyKeyMap.h.Add((object) KeyCode.H, (object) 104);
    MyKeyMap.h.Add((object) KeyCode.I, (object) 105);
    MyKeyMap.h.Add((object) KeyCode.J, (object) 106);
    MyKeyMap.h.Add((object) KeyCode.K, (object) 107);
    MyKeyMap.h.Add((object) KeyCode.L, (object) 108);
    MyKeyMap.h.Add((object) KeyCode.M, (object) 109);
    MyKeyMap.h.Add((object) KeyCode.N, (object) 110);
    MyKeyMap.h.Add((object) KeyCode.O, (object) 111);
    MyKeyMap.h.Add((object) KeyCode.P, (object) 112);
    MyKeyMap.h.Add((object) KeyCode.Q, (object) 113);
    MyKeyMap.h.Add((object) KeyCode.R, (object) 114);
    MyKeyMap.h.Add((object) KeyCode.S, (object) 115);
    MyKeyMap.h.Add((object) KeyCode.T, (object) 116);
    MyKeyMap.h.Add((object) KeyCode.U, (object) 117);
    MyKeyMap.h.Add((object) KeyCode.V, (object) 118);
    MyKeyMap.h.Add((object) KeyCode.W, (object) 119);
    MyKeyMap.h.Add((object) KeyCode.X, (object) 120);
    MyKeyMap.h.Add((object) KeyCode.Y, (object) 121);
    MyKeyMap.h.Add((object) KeyCode.Z, (object) 122);
    MyKeyMap.h.Add((object) KeyCode.Alpha0, (object) 48);
    MyKeyMap.h.Add((object) KeyCode.Alpha1, (object) 49);
    MyKeyMap.h.Add((object) KeyCode.Alpha2, (object) 50);
    MyKeyMap.h.Add((object) KeyCode.Alpha3, (object) 51);
    MyKeyMap.h.Add((object) KeyCode.Alpha4, (object) 52);
    MyKeyMap.h.Add((object) KeyCode.Alpha5, (object) 53);
    MyKeyMap.h.Add((object) KeyCode.Alpha6, (object) 54);
    MyKeyMap.h.Add((object) KeyCode.Alpha7, (object) 55);
    MyKeyMap.h.Add((object) KeyCode.Alpha8, (object) 56);
    MyKeyMap.h.Add((object) KeyCode.Alpha9, (object) 57);
    MyKeyMap.h.Add((object) KeyCode.Space, (object) 32);
    MyKeyMap.h.Add((object) KeyCode.F1, (object) -21);
    MyKeyMap.h.Add((object) KeyCode.F2, (object) -22);
    MyKeyMap.h.Add((object) KeyCode.Equals, (object) -25);
    MyKeyMap.h.Add((object) KeyCode.Minus, (object) 45);
    MyKeyMap.h.Add((object) KeyCode.F3, (object) -23);
    MyKeyMap.h.Add((object) KeyCode.UpArrow, (object) -1);
    MyKeyMap.h.Add((object) KeyCode.DownArrow, (object) -2);
    MyKeyMap.h.Add((object) KeyCode.LeftArrow, (object) -3);
    MyKeyMap.h.Add((object) KeyCode.RightArrow, (object) -4);
    MyKeyMap.h.Add((object) KeyCode.Backspace, (object) -8);
    MyKeyMap.h.Add((object) KeyCode.Return, (object) -5);
    MyKeyMap.h.Add((object) KeyCode.Period, (object) 46);
    MyKeyMap.h.Add((object) KeyCode.At, (object) 64);
    MyKeyMap.h.Add((object) KeyCode.Tab, (object) -26);
  }

  public static int map(KeyCode k)
  {
    object obj = MyKeyMap.h[(object) k];
    return obj == null ? 0 : (int) obj;
  }
}
