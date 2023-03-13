// Decompiled with JetBrains decompiler
// Type: Service
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.g;
using System;

public class Service
{
  private ISession session = (ISession) Session_ME.gI();
  protected static Service instance;
  public static long curCheckController;
  public static long curCheckMap;
  public static long logController;
  public static long logMap;
  public int demGui;
  public static bool reciveFromMainSession;

  public static Service gI()
  {
    if (Service.instance == null)
      Service.instance = new Service();
    return Service.instance;
  }

  public void gotoPlayer(int id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 18);
      message.writer().writeInt(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void androidPack()
  {
    if (mSystem.android_pack == null)
      return;
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 126);
      message.writer().writeUTF(mSystem.android_pack);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void charInfo(
    string day,
    string month,
    string year,
    string address,
    string cmnd,
    string dayCmnd,
    string noiCapCmnd,
    string sdt,
    string name)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 42);
      message.writer().writeUTF(day);
      message.writer().writeUTF(month);
      message.writer().writeUTF(year);
      message.writer().writeUTF(address);
      message.writer().writeUTF(cmnd);
      message.writer().writeUTF(dayCmnd);
      message.writer().writeUTF(noiCapCmnd);
      message.writer().writeUTF(sdt);
      message.writer().writeUTF(name);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void androidPack2()
  {
    if (mSystem.android_pack == null)
      return;
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 126);
      message.writer().writeUTF(mSystem.android_pack);
      this.session = !Session_ME2.gI().isConnected() || Session_ME2.connecting ? (ISession) Session_ME.gI() : (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void checkAd(sbyte status)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -44);
      message.writer().writeByte(status);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void combine(sbyte action, MyVector id)
  {
    Res.outz(nameof (combine));
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -81);
      message.writer().writeByte(action);
      if (action == (sbyte) 1)
      {
        message.writer().writeByte(id.size());
        for (int index = 0; index < id.size(); ++index)
        {
          message.writer().writeByte(((Item) id.elementAt(index)).indexUI);
          Res.outz("gui id " + (object) ((Item) id.elementAt(index)).indexUI);
        }
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void giaodich(sbyte action, int playerID, sbyte index, int num)
  {
    Res.outz2("giao dich action = " + (object) action);
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -86);
      message.writer().writeByte(action);
      if (action == (sbyte) 0 || action == (sbyte) 1)
      {
        Res.outz2(">>>> len playerID =" + (object) playerID);
        message.writer().writeInt(playerID);
      }
      if (action == (sbyte) 2)
      {
        Res.outz2("gui len index =" + (object) index + " num= " + (object) num);
        message.writer().writeByte(index);
        message.writer().writeInt(num);
      }
      if (action == (sbyte) 4)
      {
        Res.outz2(">>>> len index =" + (object) index);
        message.writer().writeByte(index);
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendClientInput(TField[] t)
  {
    Message message = (Message) null;
    try
    {
      Res.outz(" gui input ");
      message = new Message((sbyte) -125);
      Res.outz("byte lent = " + (object) t.Length);
      message.writer().writeByte(t.Length);
      for (int index = 0; index < t.Length; ++index)
        message.writer().writeUTF(t[index].getText());
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void speacialSkill(sbyte index)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 112);
      message.writer().writeByte(index);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void test(short x, short y)
  {
    Res.outz("gui x= " + (object) x + " y= " + (object) y);
    Message message = (Message) null;
    try
    {
      message = new Message(0);
      message.writer().writeShort(x);
      message.writer().writeShort(y);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void test2()
  {
    Res.outz("gui test1");
    Message message = (Message) null;
    try
    {
      message = new Message(1);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void testJoint()
  {
  }

  public void mobCapcha(char ch)
  {
    Res.outz("cap char c= " + (object) ch);
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -85);
      message.writer().writeChar(ch);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void friend(sbyte action, int playerId)
  {
    Res.outz("add friend");
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -80);
      message.writer().writeByte(action);
      if (playerId != -1)
        message.writer().writeInt(playerId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getArchivemnt(int index)
  {
    Res.outz("get ngoc");
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -76);
      message.writer().writeByte(index);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getPlayerMenu(int playerID)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -79);
      message.writer().writeInt(playerID);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clanImage(sbyte id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -62);
      message.writer().writeByte(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void skill_not_focus(sbyte status)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -45);
      message.writer().writeByte(status);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clanDonate(int id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -54);
      message.writer().writeInt(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clanMessage(int type, string text, int clanID)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -51);
      message.writer().writeByte(type);
      if (type == 0)
        message.writer().writeUTF(text);
      if (type == 2)
        message.writer().writeInt(clanID);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void useItem(sbyte type, sbyte where, sbyte index, short template)
  {
    Cout.println("USE ITEM! " + (object) type);
    if (Char.myCharz().statusMe == 14)
      return;
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -43);
      message.writer().writeByte(type);
      message.writer().writeByte(where);
      message.writer().writeByte(index);
      if (index == (sbyte) -1)
        message.writer().writeShort(template);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void joinClan(int id, sbyte action)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -49);
      message.writer().writeInt(id);
      message.writer().writeByte(action);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clanMember(int id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -50);
      message.writer().writeInt(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void searchClan(string text)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -47);
      message.writer().writeUTF(text);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestClan(short id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -53);
      message.writer().writeShort(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clanRemote(int id, sbyte role)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -56);
      message.writer().writeInt(id);
      message.writer().writeByte(role);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void leaveClan()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -55);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clanInvite(sbyte action, int playerID, int clanID, int code)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -57);
      message.writer().writeByte(action);
      if (action == (sbyte) 0)
        message.writer().writeInt(playerID);
      if (action == (sbyte) 1 || action == (sbyte) 2)
      {
        message.writer().writeInt(clanID);
        message.writer().writeInt(code);
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getClan(sbyte action, sbyte id, string text)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -46);
      message.writer().writeByte(action);
      if (action == (sbyte) 2 || action == (sbyte) 4)
      {
        message.writer().writeByte(id);
        message.writer().writeUTF(text);
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void updateCaption(sbyte gender)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -41);
      message.writer().writeByte(gender);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getItem(sbyte type, sbyte id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -40);
      message.writer().writeByte(type);
      message.writer().writeByte(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getTask(int npcTemplateId, int menuId, int optionId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 40);
      message.writer().writeByte(npcTemplateId);
      message.writer().writeByte(menuId);
      if (optionId >= 0)
        message.writer().writeByte(optionId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public Message messageNotLogin(sbyte command)
  {
    Message message = new Message((sbyte) -29);
    message.writer().writeByte(command);
    return message;
  }

  public Message messageNotMap(sbyte command)
  {
    Message message = new Message((sbyte) -28);
    message.writer().writeByte(command);
    return message;
  }

  public static Message messageSubCommand(sbyte command)
  {
    Message message = new Message((sbyte) -30);
    message.writer().writeByte(command);
    return message;
  }

  public void setClientType()
  {
    if (Rms.loadRMSInt("clienttype") != -1)
      Main.typeClient = Rms.loadRMSInt("clienttype");
    try
    {
      Message message = this.messageNotLogin((sbyte) 2);
      message.writer().writeByte(Main.typeClient);
      message.writer().writeByte(mGraphics.zoomLevel);
      message.writer().writeBoolean(false);
      message.writer().writeInt(GameCanvas.w);
      message.writer().writeInt(GameCanvas.h);
      message.writer().writeBoolean(TField.isQwerty);
      message.writer().writeBoolean(GameCanvas.isTouch);
      message.writer().writeUTF(GameCanvas.getPlatformName() + "|" + GameMidlet.VERSION);
      this.session.sendMessage(message);
      message.cleanup();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
  }

  public void setClientType2()
  {
    Res.outz("SET CLIENT TYPE");
    if (Rms.loadRMSInt("clienttype") != -1)
      mSystem.clientType = Rms.loadRMSInt("clienttype");
    try
    {
      Res.outz("setType");
      Message message = this.messageNotLogin((sbyte) 2);
      message.writer().writeByte(mSystem.clientType);
      message.writer().writeByte(mGraphics.zoomLevel);
      Res.outz("gui zoomlevel = " + (object) mGraphics.zoomLevel);
      message.writer().writeBoolean(false);
      message.writer().writeInt(GameCanvas.w);
      message.writer().writeInt(GameCanvas.h);
      message.writer().writeBoolean(TField.isQwerty);
      message.writer().writeBoolean(GameCanvas.isTouch);
      message.writer().writeUTF(GameCanvas.getPlatformName() + "|" + GameMidlet.VERSION);
      this.session = (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
      message.cleanup();
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
  }

  public void sendCheckController()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -120);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      Service.curCheckController = mSystem.currentTimeMillis();
      message.cleanup();
    }
  }

  public void sendCheckMap()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -121);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      Service.curCheckMap = mSystem.currentTimeMillis();
      message.cleanup();
    }
  }

  public void login(string username, string pass, string version, sbyte type)
  {
    try
    {
      Message message = this.messageNotLogin((sbyte) 0);
      message.writer().writeUTF(username);
      message.writer().writeUTF(pass);
      message.writer().writeUTF(version);
      message.writer().writeByte(type);
      this.session.sendMessage(message);
      message.cleanup();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
  }

  public void requestRegister(
    string username,
    string pass,
    string usernameAo,
    string passAo,
    string version)
  {
    try
    {
      Message message = this.messageNotLogin((sbyte) 1);
      message.writer().writeUTF(username);
      message.writer().writeUTF(pass);
      if (usernameAo != null && !usernameAo.Equals(string.Empty))
      {
        message.writer().writeUTF(usernameAo);
        message.writer().writeUTF("a");
      }
      this.session.sendMessage(message);
      message.cleanup();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
  }

  public void requestChangeMap()
  {
    Message message = new Message((sbyte) -23);
    this.session.sendMessage(message);
    message.cleanup();
  }

  public void magicTree(sbyte type)
  {
    Message message = new Message((sbyte) -34);
    try
    {
      message.writer().writeByte(type);
      this.session.sendMessage(message);
      message.cleanup();
    }
    catch (Exception ex)
    {
    }
  }

  public void requestChangeZone(int zoneId, int indexUI)
  {
    Message message = new Message((sbyte) 21);
    try
    {
      message.writer().writeByte(zoneId);
      this.session.sendMessage(message);
      message.cleanup();
    }
    catch (Exception ex)
    {
    }
  }

  public void checkMMove(int second)
  {
    Message message = new Message((sbyte) -78);
    try
    {
      message.writer().writeInt(second);
      this.session.sendMessage(message);
      message.cleanup();
    }
    catch (Exception ex)
    {
    }
  }

  public void charMove()
  {
    int num1 = Char.myCharz().cx - Char.myCharz().cxSend;
    int num2 = Char.myCharz().cy - Char.myCharz().cySend;
    if (Char.ischangingMap || num1 == 0 && num2 == 0 || Controller.isStopReadMessage || Char.myCharz().isTeleport || Char.myCharz().cy <= 0)
      return;
    if (Char.myCharz().telePortSkill)
      return;
    try
    {
      Message message = new Message((sbyte) -7);
      Char.myCharz().cxSend = Char.myCharz().cx;
      Char.myCharz().cySend = Char.myCharz().cy;
      Char.myCharz().cdirSend = Char.myCharz().cdir;
      Char.myCharz().cactFirst = Char.myCharz().statusMe;
      if (TileMap.tileTypeAt(Char.myCharz().cx / (int) TileMap.size, Char.myCharz().cy / (int) TileMap.size) == 0)
      {
        message.writer().writeByte((sbyte) 1);
        if (Char.myCharz().canFly)
        {
          if (!Char.myCharz().isHaveMount)
            Char.myCharz().cMP -= Char.myCharz().cMPGoc / 100 * (Char.myCharz().isMonkey != (sbyte) 1 ? 1 : 2);
          if (Char.myCharz().cMP < 0)
            Char.myCharz().cMP = 0;
          GameScr.gI().isInjureMp = true;
          GameScr.gI().twMp = 0;
        }
      }
      else
        message.writer().writeByte((sbyte) 0);
      message.writer().writeShort(Char.myCharz().cx);
      if (num2 != 0)
        message.writer().writeShort(Char.myCharz().cy);
      this.session.sendMessage(message);
      ++GameScr.tickMove;
      message.cleanup();
    }
    catch (Exception ex)
    {
      Cout.LogError("LOI CHAR MOVE " + ex.ToString());
    }
  }

  public void selectCharToPlay(string charname)
  {
    Message message = new Message((sbyte) -28);
    try
    {
      message.writer().writeByte((sbyte) 1);
      message.writer().writeUTF(charname);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    this.session.sendMessage(message);
  }

  public void selectZone(sbyte sub, int value)
  {
  }

  public void createChar(string name, int gender, int hair)
  {
    Message message = new Message((sbyte) -28);
    try
    {
      message.writer().writeByte((sbyte) 2);
      message.writer().writeUTF(name);
      message.writer().writeByte(gender);
      message.writer().writeByte(hair);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    this.session.sendMessage(message);
  }

  public void requestModTemplate(int modTemplateId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 11);
      message.writer().writeByte(modTemplateId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestNpcTemplate(int npcTemplateId)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 12);
      message.writer().writeByte(npcTemplateId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestSkill(int skillId)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 9);
      message.writer().writeShort(skillId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestItemInfo(int typeUI, int indexUI)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 35);
      message.writer().writeByte(typeUI);
      message.writer().writeByte(indexUI);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestItemPlayer(int charId, int indexUI)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 90);
      message.writer().writeInt(charId);
      message.writer().writeByte(indexUI);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void upSkill(int skillTemplateId, int point)
  {
    Message message = (Message) null;
    try
    {
      message = Service.messageSubCommand((sbyte) 17);
      message.writer().writeShort(skillTemplateId);
      message.writer().writeByte(point);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void saleItem(sbyte action, sbyte type, short id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 7);
      message.writer().writeByte(action);
      message.writer().writeByte(type);
      message.writer().writeShort(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void buyItem(sbyte type, int id, int quantity)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 6);
      message.writer().writeByte(type);
      message.writer().writeShort(id);
      if (quantity > 1)
        message.writer().writeShort(quantity);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void selectSkill(int skillTemplateId)
  {
    Cout.println(Char.myCharz().cName + " SELECT SKILL " + (object) skillTemplateId);
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 34);
      message.writer().writeShort(skillTemplateId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getEffData(short id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -66);
      message.writer().writeShort(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void openUIZone()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 29);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void confirmMenu(short npcID, sbyte select)
  {
    Res.outz("confirme menu" + (object) select);
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 32);
      message.writer().writeShort(npcID);
      message.writer().writeByte(select);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void openMenu(int npcId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 33);
      message.writer().writeShort(npcId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void menu(int npcId, int menuId, int optionId)
  {
    Cout.println("menuid: " + (object) menuId);
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 22);
      message.writer().writeByte(npcId);
      message.writer().writeByte(menuId);
      message.writer().writeByte(optionId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void menuId(short menuId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 27);
      message.writer().writeShort(menuId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void textBoxId(short menuId, string str)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 88);
      message.writer().writeShort(menuId);
      message.writer().writeUTF(str);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestItem(int typeUI)
  {
    Message message = (Message) null;
    try
    {
      message = Service.messageSubCommand((sbyte) 22);
      message.writer().writeByte(typeUI);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void boxSort()
  {
    Message message = (Message) null;
    try
    {
      message = Service.messageSubCommand((sbyte) 19);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void boxCoinOut(int coinOut)
  {
    Message message = (Message) null;
    try
    {
      message = Service.messageSubCommand((sbyte) 21);
      message.writer().writeInt(coinOut);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void upgradeItem(Item item, Item[] items, bool isGold)
  {
    GameCanvas.msgdlg.pleasewait();
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 14);
      message.writer().writeBoolean(isGold);
      message.writer().writeByte(item.indexUI);
      for (int index = 0; index < items.Length; ++index)
      {
        if (items[index] != null)
          message.writer().writeByte(items[index].indexUI);
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void crystalCollectLock(Item[] items)
  {
    GameCanvas.msgdlg.pleasewait();
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 13);
      for (int index = 0; index < items.Length; ++index)
      {
        if (items[index] != null)
          message.writer().writeByte(items[index].indexUI);
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void acceptInviteTrade(int playerMapId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 37);
      message.writer().writeInt(playerMapId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void cancelInviteTrade()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 50);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void tradeAccept()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 39);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void tradeItemLock(int coin, Item[] items)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 38);
      message.writer().writeInt(coin);
      int num = 0;
      for (int index = 0; index < items.Length; ++index)
      {
        if (items[index] != null)
          ++num;
      }
      message.writer().writeByte(num);
      for (int index = 0; index < items.Length; ++index)
      {
        if (items[index] != null)
          message.writer().writeByte(items[index].indexUI);
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendPlayerAttack(MyVector vMob, MyVector vChar, int type)
  {
    try
    {
      Message message = (Message) null;
      if (type == 0)
        return;
      if (vMob.size() > 0 && vChar.size() > 0)
      {
        switch (type)
        {
          case 1:
            message = new Message((sbyte) -4);
            break;
          case 2:
            message = new Message((sbyte) 67);
            break;
        }
        message.writer().writeByte(vMob.size());
        for (int index = 0; index < vMob.size(); ++index)
        {
          Mob mob = (Mob) vMob.elementAt(index);
          message.writer().writeByte(mob.mobId);
        }
        for (int index = 0; index < vChar.size(); ++index)
        {
          Char @char = (Char) vChar.elementAt(index);
          if (@char != null)
            message.writer().writeInt(@char.charID);
          else
            message.writer().writeInt(-1);
        }
      }
      else if (vMob.size() > 0)
      {
        message = new Message((sbyte) 54);
        for (int index = 0; index < vMob.size(); ++index)
        {
          Mob mob = (Mob) vMob.elementAt(index);
          if (!mob.isMobMe)
          {
            message.writer().writeByte(mob.mobId);
          }
          else
          {
            message.writer().writeByte((sbyte) -1);
            message.writer().writeInt(mob.mobId);
          }
        }
      }
      else if (vChar.size() > 0)
      {
        message = new Message((sbyte) -60);
        for (int index = 0; index < vChar.size(); ++index)
        {
          Char @char = (Char) vChar.elementAt(index);
          message.writer().writeInt(@char.charID);
        }
      }
      if (message == null)
        return;
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
  }

  public void pickItem(int itemMapId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -20);
      message.writer().writeShort(itemMapId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void throwItem(int index)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -18);
      message.writer().writeByte(index);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void returnTownFromDead()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -15);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void wakeUpFromDead()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -16);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void chat(string text)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 44);
      message.writer().writeUTF(text);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void updateData()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -87);
      this.session = !Session_ME2.gI().isConnected() || Session_ME2.connecting ? (ISession) Session_ME.gI() : (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void updateMap()
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 6);
      this.session = !Session_ME2.gI().isConnected() || Session_ME2.connecting ? (ISession) Session_ME.gI() : (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void updateSkill()
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 7);
      this.session = !Session_ME2.gI().isConnected() || Session_ME2.connecting ? (ISession) Session_ME.gI() : (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void updateItem()
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 8);
      this.session = !Session_ME2.gI().isConnected() || Session_ME2.connecting ? (ISession) Session_ME.gI() : (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clientOk()
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 13);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void tradeInvite(int charId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 36);
      message.writer().writeInt(charId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void addFriend(string name)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 53);
      message.writer().writeUTF(name);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void addPartyAccept(int charId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 76);
      message.writer().writeInt(charId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void addPartyCancel(int charId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 77);
      message.writer().writeInt(charId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void testInvite(int charId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 59);
      message.writer().writeInt(charId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void addCuuSat(int charId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 62);
      message.writer().writeInt(charId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void addParty(string name)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 75);
      message.writer().writeUTF(name);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void player_vs_player(sbyte action, sbyte type, int playerId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -59);
      message.writer().writeByte(action);
      message.writer().writeByte(type);
      message.writer().writeInt(playerId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestMaptemplate(int maptemplateId)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 10);
      message.writer().writeByte(maptemplateId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void outParty()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 79);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestPlayerInfo(MyVector chars)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 18);
      message.writer().writeByte(chars.size());
      for (int index = 0; index < chars.size(); ++index)
      {
        Char @char = (Char) chars.elementAt(index);
        message.writer().writeInt(@char.charID);
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void pleaseInputParty(string str)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 16);
      message.writer().writeUTF(str);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void acceptPleaseParty(string str)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 17);
      message.writer().writeUTF(str);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void chatPlayer(string text, int id)
  {
    Res.outz("chat player text = " + text);
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -72);
      message.writer().writeInt(id);
      message.writer().writeUTF(text);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void chatGlobal(string text)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -71);
      message.writer().writeUTF(text);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void chatPrivate(string to, string text)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 91);
      message.writer().writeUTF(to);
      message.writer().writeUTF(text);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendCardInfo(string NAP, string PIN)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 16);
      message.writer().writeUTF(NAP);
      message.writer().writeUTF(PIN);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void saveRms(string key, sbyte[] data)
  {
    Message message = (Message) null;
    try
    {
      message = Service.messageSubCommand((sbyte) 60);
      message.writer().writeUTF(key);
      message.writer().writeInt(data.Length);
      message.writer().write(data);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void loadRMS(string key)
  {
    Cout.println("REQUEST RMS");
    Message message = (Message) null;
    try
    {
      message = Service.messageSubCommand((sbyte) 61);
      message.writer().writeUTF(key);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clearTask()
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 17);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void changeName(string name, int id)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 18);
      message.writer().writeInt(id);
      message.writer().writeUTF(name);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestIcon(int id)
  {
    GameCanvas.connect();
    Message message = (Message) null;
    try
    {
      Res.outz("REQUEST ICON " + (object) id);
      message = new Message((sbyte) -67);
      message.writer().writeInt(id);
      this.session = !Session_ME2.gI().isConnected() || Session_ME2.connecting ? (ISession) Session_ME.gI() : (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void doConvertUpgrade(int index1, int index2, int index3)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 33);
      message.writer().writeByte(index1);
      message.writer().writeByte(index2);
      message.writer().writeByte(index3);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void inviteClanDun(string name)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 34);
      message.writer().writeUTF(name);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void inputNumSplit(int indexItem, int numSplit)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 40);
      message.writer().writeByte(indexItem);
      message.writer().writeInt(numSplit);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void activeAccProtect(int pass)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 37);
      message.writer().writeInt(pass);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void clearAccProtect(int pass)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 41);
      message.writer().writeInt(pass);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void updateActive(int passOld, int passNew)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 38);
      message.writer().writeInt(passOld);
      message.writer().writeInt(passNew);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void openLockAccProtect(int pass2)
  {
    Message message = (Message) null;
    try
    {
      message = this.messageNotMap((sbyte) 39);
      message.writer().writeInt(pass2);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getBgTemplate(short id)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -32);
      message.writer().writeShort(id);
      this.session = !Session_ME2.gI().isConnected() || Session_ME2.connecting ? (ISession) Session_ME.gI() : (ISession) Session_ME2.gI();
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getMapOffline()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -33);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void finishUpdate()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -38);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void finishLoadMap()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -39);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getChest(sbyte action)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -35);
      message.writer().writeByte(action);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestBagImage(sbyte ID)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -63);
      message.writer().writeByte(ID);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getBag(sbyte action)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -36);
      message.writer().writeByte(action);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getBody(sbyte action)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -37);
      message.writer().writeByte(action);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void login2(string user)
  {
    Res.outz("Login 2");
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -101);
      message.writer().writeUTF(user);
      message.writer().writeByte(1);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getMagicTree(sbyte action)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -34);
      message.writer().writeByte(action);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void upPotential(int typePotential, int num)
  {
    Message message = (Message) null;
    try
    {
      message = Service.messageSubCommand((sbyte) 16);
      message.writer().writeByte(typePotential);
      message.writer().writeShort(num);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getResource(sbyte action, MyVector vResourceIndex)
  {
    Res.outz("request resource action= " + (object) action);
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -74);
      message.writer().writeByte(action);
      if (action == (sbyte) 2 && vResourceIndex != null)
      {
        message.writer().writeShort(vResourceIndex.size());
        for (int index = 0; index < vResourceIndex.size(); ++index)
          message.writer().writeShort(short.Parse((string) vResourceIndex.elementAt(index)));
      }
      if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
      {
        this.session = (ISession) Session_ME2.gI();
      }
      else
      {
        Service.reciveFromMainSession = true;
        this.session = (ISession) Session_ME.gI();
      }
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      Cout.println(ex.Message + ex.StackTrace);
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestMapSelect(int selected)
  {
    Res.outz("request magic tree");
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -91);
      message.writer().writeByte(selected);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void petInfo()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -107);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendTop(string topName, sbyte selected)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -96);
      message.writer().writeUTF(topName);
      message.writer().writeByte(selected);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void enemy(sbyte b, int charID)
  {
    Message message = (Message) null;
    Res.outz("add enemy");
    try
    {
      message = new Message((sbyte) -99);
      message.writer().writeByte(b);
      if (b == (sbyte) 1 || b == (sbyte) 2)
        message.writer().writeInt(charID);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void kigui(sbyte action, int itemId, sbyte moneyType, int money, int quaintly)
  {
    Message message = (Message) null;
    try
    {
      Res.outz("ki gui action= " + (object) action);
      message = new Message((sbyte) -100);
      message.writer().writeByte(action);
      if (action == (sbyte) 0)
      {
        message.writer().writeShort(itemId);
        message.writer().writeByte(moneyType);
        message.writer().writeInt(money);
        message.writer().writeInt(quaintly);
      }
      if (action == (sbyte) 1 || action == (sbyte) 2)
        message.writer().writeShort(itemId);
      if (action == (sbyte) 3)
      {
        message.writer().writeShort(itemId);
        message.writer().writeByte(moneyType);
        message.writer().writeInt(money);
      }
      if (action == (sbyte) 4)
      {
        message.writer().writeByte(moneyType);
        message.writer().writeByte(money);
        Res.outz("currTab= " + (object) moneyType + " page= " + (object) money);
      }
      if (action == (sbyte) 5)
        message.writer().writeShort(itemId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getFlag(sbyte action, sbyte flagType)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -103);
      message.writer().writeByte(action);
      Res.outz("------------service--  " + (object) action + "   " + (object) flagType);
      if (action != (sbyte) 0)
        message.writer().writeByte(flagType);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void setLockInventory(int pass)
  {
    Message message = (Message) null;
    try
    {
      Res.outz("------------setLockInventory:     " + (object) pass);
      message = new Message((sbyte) -104);
      message.writer().writeInt(pass);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void petStatus(sbyte status)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -108);
      message.writer().writeByte(status);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void transportNow()
  {
    Message message = (Message) null;
    try
    {
      Res.outz("------------transportNow  ");
      message = new Message((sbyte) -105);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void funsion(sbyte type)
  {
    Message message = (Message) null;
    try
    {
      Res.outz("FUNSION");
      message = new Message((sbyte) 125);
      message.writer().writeByte(type);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void imageSource(MyVector vID)
  {
    Message message = (Message) null;
    try
    {
      Res.outz("IMAGE SOURCE size= " + (object) vID.size());
      message = new Message((sbyte) -111);
      message.writer().writeShort(vID.size());
      if (vID.size() > 0)
      {
        for (int index = 0; index < vID.size(); ++index)
        {
          Res.outz("gui len str " + ((ImageSource) vID.elementAt(index)).id);
          message.writer().writeUTF(((ImageSource) vID.elementAt(index)).id);
        }
      }
      if (Session_ME2.gI().isConnected() && !Session_ME2.connecting)
      {
        this.session = (ISession) Session_ME2.gI();
      }
      else
      {
        this.session = (ISession) Session_ME.gI();
        Service.reciveFromMainSession = true;
      }
      this.session.sendMessage(message);
      this.session = (ISession) Session_ME.gI();
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getQuayso()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -126);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendServerData(sbyte action, int id, sbyte[] data)
  {
    Message message = (Message) null;
    try
    {
      Res.outz("SERVER DATA");
      message = new Message((sbyte) -110);
      message.writer().writeByte(action);
      if (action == (sbyte) 1)
      {
        message.writer().writeInt(id);
        if (data != null)
        {
          int length = data.Length;
          message.writer().writeShort(length);
          message.writer().write(ref data, 0, length);
        }
      }
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void changeOnKeyScr(sbyte[] skill)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -113);
      for (int index = 0; index < GameScr.onScreenSkill.Length; ++index)
        message.writer().writeByte(skill[index]);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void requestPean()
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -114);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendThachDau(int id)
  {
    Res.outz("GUI THACH DAU");
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -118);
      message.writer().writeInt(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void messagePlayerMenu(int charId)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -30);
      message.writer().writeByte((sbyte) 63);
      message.writer().writeInt(charId);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void playerMenuAction(int charId, short select)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) -30);
      message.writer().writeByte((sbyte) 64);
      message.writer().writeInt(charId);
      message.writer().writeShort(select);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    finally
    {
      message.cleanup();
    }
  }

  public void getImgByName(string nameImg)
  {
    Message message = (Message) null;
    try
    {
      message = new Message((sbyte) 66);
      message.writer().writeUTF(nameImg);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void SendCrackBall(byte type, byte soluong)
  {
    Message message = new Message((sbyte) -127);
    try
    {
      message.writer().writeByte((int) type);
      if (soluong > (byte) 0)
        message.writer().writeByte((int) soluong);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void SendRada(int i, int id)
  {
    Message message = new Message(sbyte.MaxValue);
    try
    {
      message.writer().writeByte(i);
      if (id != -1)
        message.writer().writeShort(id);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendOptHat()
  {
    Message message = new Message((sbyte) 24);
    try
    {
      message.writer().writeByte(0);
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }

  public void sendDelAcc()
  {
    Message message = new Message((sbyte) 69);
    try
    {
      this.session.sendMessage(message);
    }
    catch (Exception ex)
    {
    }
    finally
    {
      message.cleanup();
    }
  }
}
