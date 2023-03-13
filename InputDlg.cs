// Decompiled with JetBrains decompiler
// Type: InputDlg
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class InputDlg : Dialog
{
  protected string[] info;
  public TField tfInput;
  private int padLeft;

  public InputDlg()
  {
    this.padLeft = 40;
    if (GameCanvas.w <= 176)
      this.padLeft = 10;
    this.tfInput = new TField();
    this.tfInput.x = this.padLeft + 10;
    this.tfInput.y = GameCanvas.h - mScreen.ITEM_HEIGHT - 43;
    this.tfInput.width = GameCanvas.w - 2 * (this.padLeft + 10);
    this.tfInput.height = mScreen.ITEM_HEIGHT + 2;
    this.tfInput.isFocus = true;
    this.right = this.tfInput.cmdClear;
  }

  public void show(string info, Command ok, int type)
  {
    this.tfInput.setText(string.Empty);
    this.tfInput.setIputType(type);
    this.info = mFont.tahoma_8b.splitFontArray(info, GameCanvas.w - this.padLeft * 2);
    this.left = new Command(mResources.CLOSE, (IActionListener) GameCanvas.gI(), 8882, (object) null);
    this.center = ok;
    this.show();
  }

  public override void paint(mGraphics g)
  {
    GameCanvas.paintz.paintInputDlg(g, this.padLeft, GameCanvas.h - 77 - mScreen.cmdH, GameCanvas.w - this.padLeft * 2, 69, this.info);
    this.tfInput.paint(g);
    base.paint(g);
  }

  public override void keyPress(int keyCode)
  {
    this.tfInput.keyPressed(keyCode);
    base.keyPress(keyCode);
  }

  public override void update()
  {
    this.tfInput.update();
    base.update();
  }

  public override void show() => GameCanvas.currentDialog = (Dialog) this;

  public void hide() => GameCanvas.endDlg();
}
