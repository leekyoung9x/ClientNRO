// Decompiled with JetBrains decompiler
// Type: mScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class mScreen
{
  public Command left;
  public Command center;
  public Command right;
  public Command cmdClose;
  public static int ITEM_HEIGHT;
  public static int yOpenKeyBoard = 100;
  public static int cmdW = 68;
  public static int cmdH = 26;
  public static int keyTouch = -1;
  public static int keyMouse = -1;

  public virtual void switchToMe()
  {
    GameCanvas.clearKeyPressed();
    GameCanvas.clearKeyHold();
    if (GameCanvas.currentScreen != null)
      GameCanvas.currentScreen.unLoad();
    GameCanvas.currentScreen = this;
    Cout.LogError3("cur Screen: " + (object) GameCanvas.currentScreen);
  }

  public virtual void unLoad()
  {
  }

  public static void initPos()
  {
  }

  public virtual void keyPress(int keyCode)
  {
  }

  public virtual void update()
  {
  }

  public virtual void updateKey()
  {
    if (GameCanvas.keyPressed[!Main.isPC ? 5 : 25] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.center))
    {
      GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
      mScreen.keyTouch = -1;
      GameCanvas.isPointerJustRelease = false;
      if (this.center != null)
        this.center.performAction();
    }
    if (GameCanvas.keyPressed[12] || mScreen.getCmdPointerLast(GameCanvas.currentScreen.left))
    {
      GameCanvas.keyPressed[12] = false;
      mScreen.keyTouch = -1;
      GameCanvas.isPointerJustRelease = false;
      if (ChatTextField.gI().isShow)
      {
        if (ChatTextField.gI().left != null)
          ChatTextField.gI().left.performAction();
      }
      else if (this.left != null)
        this.left.performAction();
    }
    if (!GameCanvas.keyPressed[13] && !mScreen.getCmdPointerLast(GameCanvas.currentScreen.right))
      return;
    GameCanvas.keyPressed[13] = false;
    mScreen.keyTouch = -1;
    GameCanvas.isPointerJustRelease = false;
    if (ChatTextField.gI().isShow)
    {
      if (ChatTextField.gI().right == null)
        return;
      ChatTextField.gI().right.performAction();
    }
    else
    {
      if (this.right == null)
        return;
      this.right.performAction();
    }
  }

  public static bool getCmdPointerLast(Command cmd)
  {
    if (cmd == null)
      return false;
    if (cmd.x >= 0 && cmd.y != 0)
      return cmd.isPointerPressInside();
    if (GameCanvas.currentDialog != null)
    {
      if (GameCanvas.currentDialog.center != null && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW >> 1, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
      {
        mScreen.keyTouch = 1;
        if (cmd == GameCanvas.currentDialog.center && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          return true;
      }
      if (GameCanvas.currentDialog.left != null && GameCanvas.isPointerHoldIn(0, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
      {
        mScreen.keyTouch = 0;
        if (cmd == GameCanvas.currentDialog.left && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          return true;
      }
      if (GameCanvas.currentDialog.right != null && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
      {
        mScreen.keyTouch = 2;
        if ((cmd == GameCanvas.currentDialog.right || cmd == ChatTextField.gI().right) && GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          return true;
      }
    }
    else
    {
      if (cmd == GameCanvas.currentScreen.left && GameCanvas.isPointerHoldIn(0, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
      {
        mScreen.keyTouch = 0;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          return true;
      }
      if (cmd == GameCanvas.currentScreen.right && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
      {
        mScreen.keyTouch = 2;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          return true;
      }
      if ((cmd == GameCanvas.currentScreen.center || ChatPopup.currChatPopup != null) && GameCanvas.isPointerHoldIn(GameCanvas.w - mScreen.cmdW >> 1, GameCanvas.h - mScreen.cmdH - 5, mScreen.cmdW, mScreen.cmdH + 10))
      {
        mScreen.keyTouch = 1;
        if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
          return true;
      }
    }
    return false;
  }

  public virtual void paint(mGraphics g)
  {
    g.translate(-g.getTranslateX(), -g.getTranslateY());
    g.setClip(0, 0, GameCanvas.w, GameCanvas.h + 1);
    if (ChatTextField.gI().isShow && Main.isPC || GameCanvas.currentDialog != null || GameCanvas.menu.showMenu)
      return;
    GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
  }
}
