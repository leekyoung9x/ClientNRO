// Decompiled with JetBrains decompiler
// Type: ChatTextField
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ChatTextField : IActionListener
{
  private static ChatTextField instance;
  public TField tfChat;
  public bool isShow;
  public IChatable parentScreen;
  private long lastChatTime;
  public Command left;
  public Command cmdChat;
  public Command right;
  public Command center;
  private int x;
  private int y;
  private int w;
  private int h;
  private bool isPublic;
  public Command cmdChat2;
  public int yBegin;
  public int yUp;
  public int KC;
  public string to;
  public string strChat = "Chat ";

  public ChatTextField()
  {
    this.tfChat = new TField();
    if (Main.isWindowsPhone)
      this.tfChat.showSubTextField = false;
    if (Main.isIPhone)
      this.tfChat.isPaintMouse = false;
    this.tfChat.name = "chat";
    if (Main.isWindowsPhone)
      this.tfChat.strInfo = this.tfChat.name;
    this.tfChat.width = GameCanvas.w - 6;
    if (Main.isPC && this.tfChat.width > 250)
      this.tfChat.width = 250;
    this.tfChat.height = mScreen.ITEM_HEIGHT + 2;
    this.tfChat.x = GameCanvas.w / 2 - this.tfChat.width / 2;
    this.tfChat.isFocus = true;
    this.tfChat.setMaxTextLenght(80);
  }

  public void initChatTextField()
  {
    this.left = new Command(mResources.OK, (IActionListener) this, 8000, (object) null, 1, GameCanvas.h - mScreen.cmdH + 1);
    this.right = new Command(mResources.DELETE, (IActionListener) this, 8001, (object) null, GameCanvas.w - 70, GameCanvas.h - mScreen.cmdH + 1);
    this.center = (Command) null;
    this.w = this.tfChat.width + 20;
    this.h = this.tfChat.height + 26;
    this.x = GameCanvas.w / 2 - this.w / 2;
    this.y = this.tfChat.y - 18;
    if (Main.isPC && this.w > 320)
      this.w = 320;
    this.left.x = this.x;
    this.right.x = this.x + this.w - 68;
    if (GameCanvas.isTouch)
    {
      this.tfChat.y -= 5;
      this.y -= 20;
      this.h += 30;
      this.left.x = GameCanvas.w / 2 - 68 - 5;
      this.right.x = GameCanvas.w / 2 + 5;
      this.left.y = GameCanvas.h - 30;
      this.right.y = GameCanvas.h - 30;
    }
    this.cmdChat = new Command();
    this.cmdChat.actionChat = (ActionChat) (str =>
    {
      this.tfChat.justReturnFromTextBox = false;
      this.tfChat.setText(str);
      this.parentScreen.onChatFromMe(str, this.to);
      this.tfChat.setText(string.Empty);
      this.right.caption = mResources.CLOSE;
    });
    this.cmdChat2 = new Command();
    this.cmdChat2.actionChat = (ActionChat) (str =>
    {
      this.tfChat.justReturnFromTextBox = false;
      if (this.parentScreen != null)
      {
        this.tfChat.setText(str);
        this.parentScreen.onChatFromMe(str, this.to);
        this.tfChat.setText(string.Empty);
        this.tfChat.clearKb();
        if (this.right != null)
          this.right.performAction();
      }
      this.isShow = false;
    });
    this.yBegin = this.tfChat.y;
    this.yUp = GameCanvas.h / 2 - 2 * this.tfChat.height;
    if (Main.isWindowsPhone)
      this.tfChat.showSubTextField = false;
    if (!Main.isIPhone)
      return;
    this.tfChat.isPaintMouse = false;
  }

  public void updateWhenKeyBoardVisible()
  {
  }

  public void keyPressed(int keyCode)
  {
    if (this.isShow)
      this.tfChat.keyPressed(keyCode);
    if (this.tfChat.getText().Equals(string.Empty))
      this.right.caption = mResources.CLOSE;
    else
      this.right.caption = mResources.DELETE;
  }

  public static ChatTextField gI() => ChatTextField.instance == null ? (ChatTextField.instance = new ChatTextField()) : ChatTextField.instance;

  public void startChat(int firstCharacter, IChatable parentScreen, string to)
  {
    this.right.caption = mResources.CLOSE;
    this.to = to;
    if (Main.isWindowsPhone)
      this.tfChat.showSubTextField = false;
    if (Main.isIPhone)
      this.tfChat.isPaintMouse = false;
    this.tfChat.keyPressed(firstCharacter);
    if (this.tfChat.getText().Equals(string.Empty) || GameCanvas.currentDialog != null)
      return;
    this.parentScreen = parentScreen;
    this.isShow = true;
  }

  public void startChat(IChatable parentScreen, string to)
  {
    this.right.caption = mResources.CLOSE;
    this.to = to;
    if (Main.isWindowsPhone)
      this.tfChat.showSubTextField = false;
    if (Main.isIPhone)
      this.tfChat.isPaintMouse = false;
    if (GameCanvas.currentDialog == null)
    {
      this.isShow = true;
      this.tfChat.isFocus = true;
      if (!Main.isPC)
      {
        ipKeyboard.openKeyBoard(this.strChat, ipKeyboard.TEXT, string.Empty, this.cmdChat);
        this.tfChat.setFocusWithKb(true);
      }
    }
    this.tfChat.setText(string.Empty);
    this.tfChat.clearAll();
    this.isPublic = false;
  }

  public void startChat2(IChatable parentScreen, string to)
  {
    this.tfChat.setFocusWithKb(true);
    this.to = to;
    this.parentScreen = parentScreen;
    if (Main.isWindowsPhone)
      this.tfChat.showSubTextField = false;
    if (Main.isIPhone)
      this.tfChat.isPaintMouse = false;
    if (GameCanvas.currentDialog == null)
    {
      this.isShow = true;
      if (!Main.isPC)
      {
        ipKeyboard.openKeyBoard(this.strChat, ipKeyboard.TEXT, string.Empty, this.cmdChat2);
        this.tfChat.setFocusWithKb(true);
      }
    }
    this.tfChat.setText(string.Empty);
    this.tfChat.clearAll();
    this.isPublic = false;
  }

  public void updateKey()
  {
  }

  public void update()
  {
    if (!this.isShow)
      return;
    this.tfChat.update();
    if (Main.isWindowsPhone)
      this.updateWhenKeyBoardVisible();
    if (this.tfChat.justReturnFromTextBox)
    {
      this.tfChat.justReturnFromTextBox = false;
      this.parentScreen.onChatFromMe(this.tfChat.getText(), this.to);
      this.tfChat.setText(string.Empty);
      this.right.caption = mResources.CLOSE;
    }
    if (!Main.isPC)
      return;
    if (GameCanvas.keyPressed[15])
    {
      if (this.left != null && this.tfChat.getText() != string.Empty)
        this.left.performAction();
      GameCanvas.keyPressed[15] = false;
      GameCanvas.keyPressed[!Main.isPC ? 5 : 25] = false;
    }
    if (!GameCanvas.keyPressed[14])
      return;
    if (this.right != null)
      this.right.performAction();
    GameCanvas.keyPressed[14] = false;
  }

  public void close()
  {
    this.tfChat.setText(string.Empty);
    this.isShow = false;
  }

  public void paint(mGraphics g)
  {
    if (!this.isShow || Main.isIPhone)
      return;
    int y = !Main.isWindowsPhone ? this.y - this.KC : this.tfChat.y - 5;
    int x = !Main.isWindowsPhone ? this.x : 0;
    int w = !Main.isWindowsPhone ? this.w : GameCanvas.w;
    PopUp.paintPopUp(g, x, y, w, this.h, -1, true);
    if (Main.isPC)
    {
      mFont.tahoma_7b_green2.drawString(g, this.strChat + this.to, this.tfChat.x, this.tfChat.y - (!GameCanvas.isTouch ? 12 : 17), 0);
      GameCanvas.paintz.paintCmdBar(g, this.left, this.center, this.right);
    }
    this.tfChat.paint(g);
  }

  public void perform(int idAction, object p)
  {
    switch (idAction)
    {
      case 8000:
        Cout.LogError("perform chat 8000");
        if (this.parentScreen == null)
          break;
        long num = mSystem.currentTimeMillis();
        if (num - this.lastChatTime < 1000L)
          break;
        this.lastChatTime = num;
        this.parentScreen.onChatFromMe(this.tfChat.getText(), this.to);
        this.tfChat.setText(string.Empty);
        this.right.caption = mResources.CLOSE;
        this.tfChat.clearKb();
        break;
      case 8001:
        Cout.LogError("perform chat 8001");
        if (this.tfChat.getText().Equals(string.Empty))
        {
          this.isShow = false;
          this.parentScreen.onCancelChat();
        }
        this.tfChat.clear();
        break;
    }
  }
}
