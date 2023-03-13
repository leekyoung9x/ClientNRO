// Decompiled with JetBrains decompiler
// Type: MoneyCharge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class MoneyCharge : mScreen, IActionListener
{
  public static MoneyCharge instance;
  public TField tfSerial;
  public TField tfCode;
  private int x;
  private int y;
  private int w;
  private int h;
  private string[] strPaint;
  private int focus;
  private int yt;
  private int freeAreaHeight;
  private int yy = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;
  private int yP;

  public MoneyCharge()
  {
    this.w = GameCanvas.w - 20;
    if (this.w > 320)
      this.w = 320;
    this.strPaint = mFont.tahoma_7b_green2.splitFontArray(mResources.pay_card, this.w - 20);
    this.x = (GameCanvas.w - this.w) / 2;
    this.y = GameCanvas.h - 150 - (this.strPaint.Length - 1) * 20;
    this.h = 110 + (this.strPaint.Length - 1) * 20;
    this.yP = this.y;
    this.tfSerial = new TField();
    this.tfSerial.name = mResources.SERI_NUM;
    this.tfSerial.x = this.x + 10;
    this.tfSerial.y = this.y + 35 + (this.strPaint.Length - 1) * 20;
    this.yt = this.tfSerial.y;
    this.tfSerial.width = this.w - 20;
    this.tfSerial.height = mScreen.ITEM_HEIGHT + 2;
    this.tfSerial.isFocus = !GameCanvas.isTouch;
    this.tfSerial.setIputType(TField.INPUT_TYPE_ANY);
    if (Main.isWindowsPhone)
      this.tfSerial.showSubTextField = false;
    if (Main.isIPhone)
      this.tfSerial.isPaintMouse = false;
    if (!GameCanvas.isTouch)
      this.right = this.tfSerial.cmdClear;
    this.tfCode = new TField();
    this.tfCode.name = mResources.CARD_CODE;
    this.tfCode.x = this.x + 10;
    this.tfCode.y = this.tfSerial.y + 35;
    this.tfCode.width = this.w - 20;
    this.tfCode.height = mScreen.ITEM_HEIGHT + 2;
    this.tfCode.isFocus = false;
    this.tfCode.setIputType(TField.INPUT_TYPE_ANY);
    if (Main.isWindowsPhone)
      this.tfCode.showSubTextField = false;
    if (Main.isIPhone)
      this.tfCode.isPaintMouse = false;
    this.left = new Command(mResources.CLOSE, (IActionListener) this, 1, (object) null);
    this.center = new Command(mResources.pay_card2, (IActionListener) this, 2, (object) null);
    if (GameCanvas.isTouch)
    {
      this.center.x = GameCanvas.w / 2 + 18;
      this.left.x = GameCanvas.w / 2 - 85;
      this.center.y = this.left.y = this.y + this.h + 5;
    }
    this.freeAreaHeight = this.tfSerial.y - (4 * this.tfSerial.height - 10);
    this.yP = this.tfSerial.y;
  }

  public static MoneyCharge gI()
  {
    if (MoneyCharge.instance == null)
      MoneyCharge.instance = new MoneyCharge();
    return MoneyCharge.instance;
  }

  public override void switchToMe()
  {
    this.focus = 0;
    base.switchToMe();
  }

  public void updateTfWhenOpenKb()
  {
  }

  public override void paint(mGraphics g)
  {
    GameScr.gI().paint(g);
    PopUp.paintPopUp(g, this.x, this.y, this.w, this.h, -1, true);
    for (int index = 0; index < this.strPaint.Length; ++index)
      mFont.tahoma_7b_green2.drawString(g, this.strPaint[index], GameCanvas.w / 2, this.y + 15 + index * 20, mFont.CENTER);
    this.tfSerial.paint(g);
    this.tfCode.paint(g);
    base.paint(g);
  }

  public override void update()
  {
    GameScr.gI().update();
    this.tfSerial.update();
    this.tfCode.update();
    if (!Main.isWindowsPhone)
      return;
    this.updateTfWhenOpenKb();
  }

  public override void keyPress(int keyCode)
  {
    if (this.tfSerial.isFocus)
      this.tfSerial.keyPressed(keyCode);
    else if (this.tfCode.isFocus)
      this.tfCode.keyPressed(keyCode);
    base.keyPress(keyCode);
  }

  public override void updateKey()
  {
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21])
    {
      --this.focus;
      if (this.focus < 0)
        this.focus = 1;
    }
    else if (GameCanvas.keyPressed[!Main.isPC ? 8 : 22])
    {
      ++this.focus;
      if (this.focus > 1)
        this.focus = 1;
    }
    if (GameCanvas.keyPressed[!Main.isPC ? 2 : 21] || GameCanvas.keyPressed[!Main.isPC ? 8 : 22])
    {
      GameCanvas.clearKeyPressed();
      if (this.focus == 1)
      {
        this.tfSerial.isFocus = false;
        this.tfCode.isFocus = true;
        if (!GameCanvas.isTouch)
          this.right = this.tfCode.cmdClear;
      }
      else if (this.focus == 0)
      {
        this.tfSerial.isFocus = true;
        this.tfCode.isFocus = false;
        if (!GameCanvas.isTouch)
          this.right = this.tfSerial.cmdClear;
      }
      else
      {
        this.tfSerial.isFocus = false;
        this.tfCode.isFocus = false;
      }
    }
    if (GameCanvas.isPointerJustRelease)
    {
      if (GameCanvas.isPointerHoldIn(this.tfSerial.x, this.tfSerial.y, this.tfSerial.width, this.tfSerial.height))
        this.focus = 0;
      else if (GameCanvas.isPointerHoldIn(this.tfCode.x, this.tfCode.y, this.tfCode.width, this.tfCode.height))
        this.focus = 1;
    }
    base.updateKey();
    GameCanvas.clearKeyPressed();
  }

  public void clearScreen() => MoneyCharge.instance = (MoneyCharge) null;

  public void perform(int idAction, object p)
  {
    if (idAction == 1)
    {
      GameScr.instance.switchToMe();
      this.clearScreen();
    }
    if (idAction != 2)
      return;
    if (this.tfSerial.getText() == null || this.tfSerial.getText().Equals(string.Empty))
      GameCanvas.startOKDlg(mResources.serial_blank);
    else if (this.tfCode.getText() == null || this.tfCode.getText().Equals(string.Empty))
    {
      GameCanvas.startOKDlg(mResources.card_code_blank);
    }
    else
    {
      Service.gI().sendCardInfo(this.tfSerial.getText(), this.tfCode.getText());
      GameScr.instance.switchToMe();
      this.clearScreen();
    }
  }
}
