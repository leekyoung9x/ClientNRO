// Decompiled with JetBrains decompiler
// Type: ScaleGUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ScaleGUI
{
  public static bool scaleScreen;
  public static float WIDTH;
  public static float HEIGHT;
  private static List<Matrix4x4> stack = new List<Matrix4x4>();

  public static void initScaleGUI()
  {
    Cout.println("Init Scale GUI: Screen.w=" + (object) Screen.width + " Screen.h=" + (object) Screen.height);
    ScaleGUI.WIDTH = (float) Screen.width;
    ScaleGUI.HEIGHT = (float) Screen.height;
    ScaleGUI.scaleScreen = false;
    if (Screen.width <= 1200)
      ;
  }

  public static void BeginGUI()
  {
    if (!ScaleGUI.scaleScreen)
      return;
    ScaleGUI.stack.Add(GUI.matrix);
    Matrix4x4 matrix4x4 = new Matrix4x4();
    float num1 = (float) Screen.width / (float) Screen.height;
    Vector3 zero = Vector3.zero;
    float num2 = (double) num1 >= (double) ScaleGUI.WIDTH / (double) ScaleGUI.HEIGHT ? (float) Screen.height / ScaleGUI.HEIGHT : (float) Screen.width / ScaleGUI.WIDTH;
    matrix4x4.SetTRS(zero, Quaternion.identity, Vector3.one * num2);
    GUI.matrix *= matrix4x4;
  }

  public static void EndGUI()
  {
    if (!ScaleGUI.scaleScreen)
      return;
    GUI.matrix = ScaleGUI.stack[ScaleGUI.stack.Count - 1];
    ScaleGUI.stack.RemoveAt(ScaleGUI.stack.Count - 1);
  }

  public static float scaleX(float x)
  {
    if (!ScaleGUI.scaleScreen)
      return x;
    x = x * ScaleGUI.WIDTH / (float) Screen.width;
    return x;
  }

  public static float scaleY(float y)
  {
    if (!ScaleGUI.scaleScreen)
      return y;
    y = y * ScaleGUI.HEIGHT / (float) Screen.height;
    return y;
  }
}
