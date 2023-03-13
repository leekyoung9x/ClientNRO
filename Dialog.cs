// Decompiled with JetBrains decompiler
// Type: Dialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public abstract class Dialog
{
  public Command left;
  public Command center;
  public Command right;
  private int lenCaption;

  public virtual void paint(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
    GameCanvas.paintz.paintTabSoft(g);
    GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
  }

  public virtual void keyPress(int keyCode)
  {
    switch (keyCode + 7)
    {
      case 0:
label_6:
        GameCanvas.keyHold[13] = true;
        GameCanvas.keyPressed[13] = true;
        break;
      case 1:
label_5:
        GameCanvas.keyHold[12] = true;
        GameCanvas.keyPressed[12] = true;
        break;
      case 2:
label_7:
        GameCanvas.keyHold[!Main.isPC ? 5 : 25] = true;
        GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = true;
        break;
      case 5:
label_4:
        GameCanvas.keyHold[!Main.isPC ? 8 : 22] = true;
        GameCanvas.keyPressed[!Main.isPC ? 8 : 22] = true;
        break;
      case 6:
label_3:
        GameCanvas.keyHold[!Main.isPC ? 2 : 21] = true;
        GameCanvas.keyPressed[!Main.isPC ? 2 : 21] = true;
        break;
      default:
        switch (keyCode)
        {
          case -39:
            goto label_4;
          case -38:
            goto label_3;
          case -22:
            goto label_6;
          case -21:
            goto label_5;
          case 10:
            goto label_7;
          default:
            return;
        }
    }
  }

  public virtual void update()
  {
    if (this.center != null && (GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(this.center)))
    {
      GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
      GameCanvas.isPointerClick = false;
      mScreen.keyTouch = -1;
      GameCanvas.isPointerJustRelease = false;
      if (this.center != null)
        this.center.performAction();
      mScreen.keyTouch = -1;
    }
    if (this.left != null && (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(this.left)))
    {
      GameCanvas.keyPressed[12] = false;
      GameCanvas.isPointerClick = false;
      mScreen.keyTouch = -1;
      GameCanvas.isPointerJustRelease = false;
      if (this.left != null)
        this.left.performAction();
      mScreen.keyTouch = -1;
    }
    if (this.right != null && (GameCanvas.keyPressed[13] || mScreen.getCmdPointerLast(this.right)))
    {
      GameCanvas.keyPressed[13] = false;
      GameCanvas.isPointerClick = false;
      GameCanvas.isPointerJustRelease = false;
      mScreen.keyTouch = -1;
      if (this.right != null)
        this.right.performAction();
      mScreen.keyTouch = -1;
    }
    GameCanvas.clearKeyPressed();
    GameCanvas.clearKeyHold();
  }

  public virtual void show()
  {
  }
}
