// Decompiled with JetBrains decompiler
// Type: Assets.src.g.ClientInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

namespace Assets.src.g
{
  public class ClientInput : mScreen, IActionListener
  {
    public static ClientInput instance;
    public TField[] tf;
    private int x;
    private int y;
    private int w;
    private int h;
    private string[] strPaint;
    private int focus;
    private int nTf;

    private void init(string t)
    {
      this.w = GameCanvas.w - 20;
      if (this.w > 320)
        this.w = 320;
      Res.outz("title= " + t);
      this.strPaint = mFont.tahoma_7b_dark.splitFontArray(t, this.w - 20);
      this.x = (GameCanvas.w - this.w) / 2;
      this.tf = new TField[this.nTf];
      this.h = this.tf.Length * 35 + (this.strPaint.Length - 1) * 20 + 40;
      this.y = GameCanvas.h - this.h - 40 - (this.strPaint.Length - 1) * 20;
      for (int index = 0; index < this.tf.Length; ++index)
      {
        this.tf[index] = new TField();
        this.tf[index].name = string.Empty;
        this.tf[index].x = this.x + 10;
        this.tf[index].y = this.y + 35 + (this.strPaint.Length - 1) * 20 + index * 35;
        this.tf[index].width = this.w - 20;
        this.tf[index].height = mScreen.ITEM_HEIGHT + 2;
        this.tf[0].isFocus = !GameCanvas.isTouch;
        if (!GameCanvas.isTouch)
          this.right = this.tf[0].cmdClear;
      }
      this.left = new Command(mResources.CLOSE, (IActionListener) this, 1, (object) null);
      this.center = new Command(mResources.OK, (IActionListener) this, 2, (object) null);
      if (!GameCanvas.isTouch)
        return;
      this.center.x = GameCanvas.w / 2 + 18;
      this.left.x = GameCanvas.w / 2 - 85;
      this.center.y = this.left.y = this.y + this.h + 5;
    }

    public static ClientInput gI()
    {
      if (ClientInput.instance == null)
        ClientInput.instance = new ClientInput();
      return ClientInput.instance;
    }

    public override void switchToMe()
    {
      this.focus = 0;
      base.switchToMe();
    }

    public void setInput(int type, string title)
    {
      this.nTf = type;
      this.init(title);
      this.switchToMe();
    }

    public override void paint(mGraphics g)
    {
      GameScr.gI().paint(g);
      PopUp.paintPopUp(g, this.x, this.y, this.w, this.h, -1, true);
      for (int index = 0; index < this.strPaint.Length; ++index)
        mFont.tahoma_7b_green2.drawString(g, this.strPaint[index], GameCanvas.w / 2, this.y + 15 + index * 20, mFont.CENTER);
      for (int index = 0; index < this.tf.Length; ++index)
        this.tf[index].paint(g);
      base.paint(g);
    }

    public override void update()
    {
      GameScr.gI().update();
      for (int index = 0; index < this.tf.Length; ++index)
        this.tf[index].update();
    }

    public override void keyPress(int keyCode)
    {
      for (int index = 0; index < this.tf.Length; ++index)
      {
        if (this.tf[index].isFocus)
        {
          this.tf[index].keyPressed(keyCode);
          break;
        }
      }
      base.keyPress(keyCode);
    }

    public override void updateKey()
    {
      if (GameCanvas.keyPressed[2])
      {
        --this.focus;
        if (this.focus < 0)
          this.focus = this.tf.Length - 1;
      }
      else if (GameCanvas.keyPressed[8])
      {
        ++this.focus;
        if (this.focus > this.tf.Length - 1)
          this.focus = 0;
      }
      if (GameCanvas.keyPressed[2] || GameCanvas.keyPressed[8])
      {
        GameCanvas.clearKeyPressed();
        for (int index = 0; index < this.tf.Length; ++index)
        {
          if (this.focus == index)
          {
            this.tf[index].isFocus = true;
            if (!GameCanvas.isTouch)
              this.right = this.tf[index].cmdClear;
          }
          else
            this.tf[index].isFocus = false;
          if (GameCanvas.isPointerJustRelease && GameCanvas.isPointerHoldIn(this.tf[index].x, this.tf[index].y, this.tf[index].width, this.tf[index].height))
          {
            this.focus = index;
            break;
          }
        }
      }
      base.updateKey();
      GameCanvas.clearKeyPressed();
    }

    public void clearScreen() => ClientInput.instance = (ClientInput) null;

    public void perform(int idAction, object p)
    {
      if (idAction == 1)
      {
        GameScr.instance.switchToMe();
        this.clearScreen();
      }
      if (idAction != 2)
        return;
      for (int index = 0; index < this.tf.Length; ++index)
      {
        if (this.tf[index].getText() == null || this.tf[index].getText().Equals(string.Empty))
        {
          GameCanvas.startOKDlg(mResources.vuilongnhapduthongtin);
          return;
        }
      }
      Service.gI().sendClientInput(this.tf);
      GameScr.instance.switchToMe();
    }
  }
}
