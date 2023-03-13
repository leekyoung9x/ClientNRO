// Decompiled with JetBrains decompiler
// Type: Controller
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.e;
using Assets.src.f;
using Assets.src.g;
using System;
using UnityEngine;

public class Controller : IMessageHandler
{
  protected static Controller me;
  protected static Controller me2;
  public Message messWait;
  public static bool isLoadingData;
  public static bool isConnectOK;
  public static bool isConnectionFail;
  public static bool isDisconnected;
  public static bool isMain;
  private float demCount;
  private int move;
  private int total;
  public static bool isStopReadMessage;
  public static MyHashTable frameHT_NEWBOSS = new MyHashTable();
  public const sbyte PHUBAN_TYPE_CHIENTRUONGNAMEK = 0;
  public const sbyte PHUBAN_START = 0;
  public const sbyte PHUBAN_UPDATE_POINT = 1;
  public const sbyte PHUBAN_END = 2;
  public const sbyte PHUBAN_LIFE = 4;
  public const sbyte PHUBAN_INFO = 5;

  public static Controller gI()
  {
    if (Controller.me == null)
      Controller.me = new Controller();
    return Controller.me;
  }

  public static Controller gI2()
  {
    if (Controller.me2 == null)
      Controller.me2 = new Controller();
    return Controller.me2;
  }

  public void onConnectOK(bool isMain1)
  {
    Controller.isMain = isMain1;
    mSystem.onConnectOK();
  }

  public void onConnectionFail(bool isMain1)
  {
    Controller.isMain = isMain1;
    mSystem.onConnectionFail();
  }

  public void onDisconnected(bool isMain1)
  {
    Controller.isMain = isMain1;
    mSystem.onDisconnected();
  }

  public void requestItemPlayer(Message msg)
  {
    try
    {
      int index = (int) msg.reader().readUnsignedByte();
      Item obj = GameScr.currentCharViewInfo.arrItemBody[index];
      obj.saleCoinLock = msg.reader().readInt();
      obj.sys = (int) msg.reader().readByte();
      obj.options = new MyVector();
      try
      {
        while (true)
          obj.options.addElement((object) new ItemOption((int) msg.reader().readUnsignedByte(), (int) msg.reader().readUnsignedShort()));
      }
      catch (Exception ex)
      {
        Cout.println("Loi tairequestItemPlayer 1" + ex.ToString());
      }
    }
    catch (Exception ex)
    {
      Cout.println("Loi tairequestItemPlayer 2" + ex.ToString());
    }
  }

  public void onMessage(Message msg)
  {
    GameCanvas.debugSession.removeAllElements();
    GameCanvas.debug("SA1", 2);
    try
    {
      mSystem.LogCMD(">>>cmd= " + (object) msg.command);
      Char char1 = (Char) null;
      MyVector myVector = new MyVector();
      Controller2.readMessage(msg);
      sbyte command1 = msg.command;
      switch ((int) command1 + 99)
      {
        case 0:
          InfoDlg.hide();
          if (msg.reader().readByte() == (sbyte) 0)
          {
            GameCanvas.panel.vEnemy.removeAllElements();
            int num = (int) msg.reader().readUnsignedByte();
            for (int index = 0; index < num; ++index)
            {
              Char char2 = new Char();
              char2.charID = msg.reader().readInt();
              char2.head = (int) msg.reader().readShort();
              char2.headICON = (int) msg.reader().readShort();
              char2.body = (int) msg.reader().readShort();
              char2.leg = (int) msg.reader().readShort();
              char2.bag = (int) msg.reader().readShort();
              char2.cName = msg.reader().readUTF();
              InfoItem o = new InfoItem(msg.reader().readUTF());
              bool flag = msg.reader().readBoolean();
              o.charInfo = char2;
              o.isOnline = flag;
              Res.outz("isonline = " + (object) flag);
              GameCanvas.panel.vEnemy.addElement((object) o);
            }
            GameCanvas.panel.setTypeEnemy();
            GameCanvas.panel.show();
            goto case 41;
          }
          else
            goto case 41;
        case 1:
          sbyte num1 = msg.reader().readByte();
          GameCanvas.menu.showMenu = false;
          if (num1 == (sbyte) 0)
          {
            GameCanvas.startYesNoDlg(msg.reader().readUTF(), new Command(mResources.YES, (IActionListener) GameCanvas.instance, 888397, (object) msg.reader().readUTF()), new Command(mResources.NO, (IActionListener) GameCanvas.instance, 888396, (object) null));
            goto case 41;
          }
          else
            goto case 41;
        case 2:
          Char.myCharz().cNangdong = (long) msg.reader().readInt();
          goto case 41;
        case 3:
          sbyte t = msg.reader().readByte();
          GameCanvas.panel.vTop.removeAllElements();
          string str1 = msg.reader().readUTF();
          sbyte num2 = msg.reader().readByte();
          for (int index = 0; index < (int) num2; ++index)
          {
            int num3 = msg.reader().readInt();
            int num4 = msg.reader().readInt();
            short num5 = msg.reader().readShort();
            short num6 = msg.reader().readShort();
            short num7 = msg.reader().readShort();
            short num8 = msg.reader().readShort();
            string str2 = msg.reader().readUTF();
            string str3 = msg.reader().readUTF();
            GameCanvas.panel.vTop.addElement((object) new TopInfo()
            {
              rank = num3,
              headID = (int) num5,
              headICON = (int) num6,
              body = num7,
              leg = num8,
              name = str2,
              info = str3,
              info2 = msg.reader().readUTF(),
              pId = num4
            });
          }
          GameCanvas.panel.topName = str1;
          GameCanvas.panel.setTypeTop(t);
          GameCanvas.panel.show();
          goto case 41;
        case 4:
          sbyte num9 = msg.reader().readByte();
          Res.outz("type= " + (object) num9);
          if (num9 == (sbyte) 0)
          {
            int num10 = msg.reader().readInt();
            short templateId = msg.reader().readShort();
            int num11 = msg.readInt3Byte();
            SoundMn.gI().explode_1();
            if (num10 == Char.myCharz().charID)
            {
              Char.myCharz().mobMe = new Mob(num10, false, false, false, false, false, (int) templateId, 1, num11, (sbyte) 0, num11, (short) (Char.myCharz().cx + (Char.myCharz().cdir != 1 ? -40 : 40)), (short) Char.myCharz().cy, (sbyte) 4, (sbyte) 0);
              Char.myCharz().mobMe.isMobMe = true;
              EffecMn.addEff(new Effect(18, Char.myCharz().mobMe.x, Char.myCharz().mobMe.y, 2, 10, -1));
              Char.myCharz().tMobMeBorn = 30;
              GameScr.vMob.addElement((object) Char.myCharz().mobMe);
            }
            else
            {
              Char charInMap = GameScr.findCharInMap(num10);
              if (charInMap != null)
              {
                charInMap.mobMe = new Mob(num10, false, false, false, false, false, (int) templateId, 1, num11, (sbyte) 0, num11, (short) charInMap.cx, (short) charInMap.cy, (sbyte) 4, (sbyte) 0)
                {
                  isMobMe = true
                };
                GameScr.vMob.addElement((object) charInMap.mobMe);
              }
              else if (GameScr.findMobInMap(num10) == null)
                GameScr.vMob.addElement((object) new Mob(num10, false, false, false, false, false, (int) templateId, 1, num11, (sbyte) 0, num11, (short) -100, (short) -100, (sbyte) 4, (sbyte) 0)
                {
                  isMobMe = true
                });
            }
          }
          if (num9 == (sbyte) 1)
          {
            int charId = msg.reader().readInt();
            int mobId = (int) msg.reader().readByte();
            Res.outz("mod attack id= " + (object) charId);
            if (charId == Char.myCharz().charID)
            {
              if (GameScr.findMobInMap(mobId) != null)
                Char.myCharz().mobMe.attackOtherMob(GameScr.findMobInMap(mobId));
            }
            else
            {
              Char charInMap = GameScr.findCharInMap(charId);
              if (charInMap != null && GameScr.findMobInMap(mobId) != null)
                charInMap.mobMe.attackOtherMob(GameScr.findMobInMap(mobId));
            }
          }
          if (num9 == (sbyte) 2)
          {
            int mobId = msg.reader().readInt();
            int charId = msg.reader().readInt();
            int HPShow = msg.readInt3Byte();
            int num12 = msg.readInt3Byte();
            if (mobId == Char.myCharz().charID)
            {
              Res.outz("mob dame= " + (object) HPShow);
              Char charInMap = GameScr.findCharInMap(charId);
              if (charInMap != null)
              {
                charInMap.cHPNew = num12;
                if (Char.myCharz().mobMe.isBusyAttackSomeOne)
                {
                  charInMap.doInjure(HPShow, 0, false, true);
                }
                else
                {
                  Char.myCharz().mobMe.dame = HPShow;
                  Char.myCharz().mobMe.setAttack(charInMap);
                }
              }
            }
            else
            {
              Mob mobInMap = GameScr.findMobInMap(mobId);
              if (mobInMap != null)
              {
                if (charId == Char.myCharz().charID)
                {
                  Char.myCharz().cHPNew = num12;
                  if (mobInMap.isBusyAttackSomeOne)
                  {
                    Char.myCharz().doInjure(HPShow, 0, false, true);
                  }
                  else
                  {
                    mobInMap.dame = HPShow;
                    mobInMap.setAttack(Char.myCharz());
                  }
                }
                else
                {
                  Char charInMap = GameScr.findCharInMap(charId);
                  if (charInMap != null)
                  {
                    charInMap.cHPNew = num12;
                    if (mobInMap.isBusyAttackSomeOne)
                    {
                      charInMap.doInjure(HPShow, 0, false, true);
                    }
                    else
                    {
                      mobInMap.dame = HPShow;
                      mobInMap.setAttack(charInMap);
                    }
                  }
                }
              }
            }
          }
          if (num9 == (sbyte) 3)
          {
            int charId = msg.reader().readInt();
            int mobId = msg.reader().readInt();
            int num13 = msg.readInt3Byte();
            int num14 = msg.readInt3Byte();
            char1 = (Char) null;
            Char char3 = Char.myCharz().charID != charId ? GameScr.findCharInMap(charId) : Char.myCharz();
            if (char3 != null)
            {
              Mob mobInMap = GameScr.findMobInMap(mobId);
              if (char3.mobMe != null)
                char3.mobMe.attackOtherMob(mobInMap);
              if (mobInMap != null)
              {
                mobInMap.hp = num13;
                if (num14 == 0)
                {
                  mobInMap.x = mobInMap.xFirst;
                  mobInMap.y = mobInMap.yFirst;
                  GameScr.startFlyText(mResources.miss, mobInMap.x, mobInMap.y - mobInMap.h, 0, -2, mFont.MISS);
                }
                else
                  GameScr.startFlyText("-" + (object) num14, mobInMap.x, mobInMap.y - mobInMap.h, 0, -2, mFont.ORANGE);
              }
            }
          }
          if (num9 != (sbyte) 4)
            ;
          if (num9 == (sbyte) 5)
          {
            int charId = msg.reader().readInt();
            sbyte index = msg.reader().readByte();
            int mobId = msg.reader().readInt();
            int num15 = msg.readInt3Byte();
            int num16 = msg.readInt3Byte();
            char1 = (Char) null;
            Char char4 = charId != Char.myCharz().charID ? GameScr.findCharInMap(charId) : Char.myCharz();
            if (char4 == null)
              break;
            if ((TileMap.tileTypeAtPixel(char4.cx, char4.cy) & 2) == 2)
              char4.setSkillPaint(GameScr.sks[(int) index], 0);
            else
              char4.setSkillPaint(GameScr.sks[(int) index], 1);
            Mob mobInMap = GameScr.findMobInMap(mobId);
            char4.cdir = char4.cx > mobInMap.x ? -1 : 1;
            char4.mobFocus = mobInMap;
            mobInMap.hp = num16;
            GameCanvas.debug("SA83v2", 2);
            if (num15 == 0)
            {
              mobInMap.x = mobInMap.xFirst;
              mobInMap.y = mobInMap.yFirst;
              GameScr.startFlyText(mResources.miss, mobInMap.x, mobInMap.y - mobInMap.h, 0, -2, mFont.MISS);
            }
            else
              GameScr.startFlyText("-" + (object) num15, mobInMap.x, mobInMap.y - mobInMap.h, 0, -2, mFont.ORANGE);
          }
          if (num9 == (sbyte) 6)
          {
            int charId = msg.reader().readInt();
            if (charId == Char.myCharz().charID)
              Char.myCharz().mobMe.startDie();
            else
              GameScr.findCharInMap(charId)?.mobMe.startDie();
          }
          if (num9 == (sbyte) 7)
          {
            int charId = msg.reader().readInt();
            if (charId == Char.myCharz().charID)
            {
              Char.myCharz().mobMe = (Mob) null;
              for (int index = 0; index < GameScr.vMob.size(); ++index)
              {
                if (((Mob) GameScr.vMob.elementAt(index)).mobId == charId)
                  GameScr.vMob.removeElementAt(index);
              }
              goto case 41;
            }
            else
            {
              Char charInMap = GameScr.findCharInMap(charId);
              for (int index = 0; index < GameScr.vMob.size(); ++index)
              {
                if (((Mob) GameScr.vMob.elementAt(index)).mobId == charId)
                  GameScr.vMob.removeElementAt(index);
              }
              if (charInMap != null)
              {
                charInMap.mobMe = (Mob) null;
                goto case 41;
              }
              else
                goto case 41;
            }
          }
          else
            goto case 41;
        case 5:
          while (msg.reader().available() > 0)
          {
            short num17 = msg.reader().readShort();
            int num18 = msg.reader().readInt();
            for (int index = 0; index < Char.myCharz().vSkill.size(); ++index)
            {
              Skill skill = (Skill) Char.myCharz().vSkill.elementAt(index);
              if (skill != null && (int) skill.skillId == (int) num17)
              {
                if (num18 < skill.coolDown)
                  skill.lastTimeUseThisSkill = mSystem.currentTimeMillis() - (long) (skill.coolDown - num18);
                Res.outz("1 chieu id= " + (object) skill.template.id + " cooldown= " + (object) num18 + "curr cool down= " + (object) skill.coolDown);
              }
            }
          }
          goto case 41;
        case 6:
          short length1 = msg.reader().readShort();
          BgItem.newSmallVersion = new sbyte[(int) length1];
          for (int index = 0; index < (int) length1; ++index)
            BgItem.newSmallVersion[index] = msg.reader().readByte();
          goto case 41;
        case 7:
          Main.typeClient = (int) msg.reader().readByte();
          Rms.clearAll();
          Rms.saveRMSInt("clienttype", Main.typeClient);
          Rms.saveRMSInt("lastZoomlevel", mGraphics.zoomLevel);
          GameCanvas.startOK(mResources.plsRestartGame, 8885, (object) null);
          goto case 41;
        case 8:
          sbyte length2 = msg.reader().readByte();
          GameCanvas.panel.mapNames = new string[(int) length2];
          GameCanvas.panel.planetNames = new string[(int) length2];
          for (int index = 0; index < (int) length2; ++index)
          {
            GameCanvas.panel.mapNames[index] = msg.reader().readUTF();
            GameCanvas.panel.planetNames[index] = msg.reader().readUTF();
          }
          GameCanvas.panel.setTypeMapTrans();
          GameCanvas.panel.show();
          goto case 41;
        case 9:
          sbyte num19 = msg.reader().readByte();
          Res.outz("type = " + (object) num19);
          int charId1 = msg.reader().readInt();
          if (num19 != (sbyte) -1)
          {
            short num20 = msg.reader().readShort();
            short num21 = msg.reader().readShort();
            short num22 = msg.reader().readShort();
            sbyte num23 = msg.reader().readByte();
            Res.outz("is Monkey = " + (object) num23);
            if (Char.myCharz().charID == charId1)
            {
              Char.myCharz().isMask = true;
              Char.myCharz().isMonkey = num23;
              if (Char.myCharz().isMonkey != (sbyte) 0)
              {
                Char.myCharz().isWaitMonkey = false;
                Char.myCharz().isLockMove = false;
              }
            }
            else if (GameScr.findCharInMap(charId1) != null)
            {
              GameScr.findCharInMap(charId1).isMask = true;
              GameScr.findCharInMap(charId1).isMonkey = num23;
            }
            if (num20 != (short) -1)
            {
              if (charId1 == Char.myCharz().charID)
                Char.myCharz().head = (int) num20;
              else if (GameScr.findCharInMap(charId1) != null)
                GameScr.findCharInMap(charId1).head = (int) num20;
            }
            if (num21 != (short) -1)
            {
              if (charId1 == Char.myCharz().charID)
                Char.myCharz().body = (int) num21;
              else if (GameScr.findCharInMap(charId1) != null)
                GameScr.findCharInMap(charId1).body = (int) num21;
            }
            if (num22 != (short) -1)
            {
              if (charId1 == Char.myCharz().charID)
                Char.myCharz().leg = (int) num22;
              else if (GameScr.findCharInMap(charId1) != null)
                GameScr.findCharInMap(charId1).leg = (int) num22;
            }
          }
          if (num19 == (sbyte) -1)
          {
            if (Char.myCharz().charID == charId1)
            {
              Char.myCharz().isMask = false;
              Char.myCharz().isMonkey = (sbyte) 0;
              goto case 41;
            }
            else if (GameScr.findCharInMap(charId1) != null)
            {
              GameScr.findCharInMap(charId1).isMask = false;
              GameScr.findCharInMap(charId1).isMonkey = (sbyte) 0;
              goto case 41;
            }
            else
              goto case 41;
          }
          else
            goto case 41;
        case 11:
          GameCanvas.endDlg();
          GameCanvas.serverScreen.switchToMe();
          goto case 41;
        case 12:
          Res.outz("GET UPDATE_DATA " + (object) msg.reader().available() + " bytes");
          msg.reader().mark(100000);
          this.createData(msg.reader(), true);
          msg.reader().reset();
          sbyte[] data1 = new sbyte[msg.reader().available()];
          msg.reader().readFully(ref data1);
          Rms.saveRMS("NRdataVersion", new sbyte[1]
          {
            GameScr.vcData
          });
          LoginScr.isUpdateData = false;
          if ((int) GameScr.vsData == (int) GameScr.vcData && (int) GameScr.vsMap == (int) GameScr.vcMap && (int) GameScr.vsSkill == (int) GameScr.vcSkill && (int) GameScr.vsItem == (int) GameScr.vcItem)
          {
            Res.outz(GameScr.vsData.ToString() + "," + (object) GameScr.vsMap + "," + (object) GameScr.vsSkill + "," + (object) GameScr.vsItem);
            GameScr.gI().readDart();
            GameScr.gI().readEfect();
            GameScr.gI().readArrow();
            GameScr.gI().readSkill();
            Service.gI().clientOk();
            break;
          }
          goto case 41;
        case 13:
          sbyte num24 = msg.reader().readByte();
          Res.outz("server gui ve giao dich action = " + (object) num24);
          if (num24 == (sbyte) 0)
          {
            int playerID = msg.reader().readInt();
            GameScr.gI().giaodich(playerID);
          }
          if (num24 == (sbyte) 1)
          {
            int num25 = msg.reader().readInt();
            Char charInMap = GameScr.findCharInMap(num25);
            if (charInMap == null)
              break;
            GameCanvas.panel.setTypeGiaoDich(charInMap);
            GameCanvas.panel.show();
            Service.gI().getPlayerMenu(num25);
          }
          if (num24 == (sbyte) 2)
          {
            sbyte num26 = msg.reader().readByte();
            for (int index = 0; index < GameCanvas.panel.vMyGD.size(); ++index)
            {
              Item o = (Item) GameCanvas.panel.vMyGD.elementAt(index);
              if (o.indexUI == (int) num26)
              {
                GameCanvas.panel.vMyGD.removeElement((object) o);
                break;
              }
            }
          }
          if (num24 != (sbyte) 5)
            ;
          if (num24 == (sbyte) 6)
          {
            GameCanvas.panel.isFriendLock = true;
            if (GameCanvas.panel2 != null)
              GameCanvas.panel2.isFriendLock = true;
            GameCanvas.panel.vFriendGD.removeAllElements();
            if (GameCanvas.panel2 != null)
              GameCanvas.panel2.vFriendGD.removeAllElements();
            int num27 = msg.reader().readInt();
            sbyte num28 = msg.reader().readByte();
            Res.outz("item size = " + (object) num28);
            for (int index1 = 0; index1 < (int) num28; ++index1)
            {
              Item o = new Item();
              o.template = ItemTemplates.get(msg.reader().readShort());
              o.quantity = msg.reader().readInt();
              int length3 = (int) msg.reader().readUnsignedByte();
              if (length3 != 0)
              {
                o.itemOption = new ItemOption[length3];
                for (int index2 = 0; index2 < o.itemOption.Length; ++index2)
                {
                  int optionTemplateId = (int) msg.reader().readUnsignedByte();
                  int num29 = (int) msg.reader().readUnsignedShort();
                  if (optionTemplateId != -1)
                  {
                    o.itemOption[index2] = new ItemOption(optionTemplateId, num29);
                    o.compare = GameCanvas.panel.getCompare(o);
                  }
                }
              }
              if (GameCanvas.panel2 != null)
                GameCanvas.panel2.vFriendGD.addElement((object) o);
              else
                GameCanvas.panel.vFriendGD.addElement((object) o);
            }
            if (GameCanvas.panel2 != null)
            {
              GameCanvas.panel2.setTabGiaoDich(false);
              GameCanvas.panel2.friendMoneyGD = num27;
            }
            else
            {
              GameCanvas.panel.friendMoneyGD = num27;
              if (GameCanvas.panel.currentTabIndex == 2)
                GameCanvas.panel.setTabGiaoDich(false);
            }
          }
          if (num24 == (sbyte) 7)
          {
            InfoDlg.hide();
            if (GameCanvas.panel.isShow)
            {
              GameCanvas.panel.hide();
              goto case 41;
            }
            else
              goto case 41;
          }
          else
            goto case 41;
        case 14:
          Res.outz("CAP CHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
          sbyte num30 = msg.reader().readByte();
          if (num30 == (sbyte) 0)
          {
            int lenght = (int) msg.reader().readUnsignedShort();
            Res.outz("lent =" + (object) lenght);
            sbyte[] data2 = new sbyte[lenght];
            msg.reader().read(ref data2, 0, lenght);
            GameScr.imgCapcha = Image.createImage(data2, 0, lenght);
            GameScr.gI().keyInput = "-----";
            GameScr.gI().strCapcha = msg.reader().readUTF();
            GameScr.gI().keyCapcha = new int[GameScr.gI().strCapcha.Length];
            GameScr.gI().mobCapcha = new Mob();
            GameScr.gI().right = (Command) null;
          }
          if (num30 == (sbyte) 1)
            MobCapcha.isAttack = true;
          if (num30 == (sbyte) 2)
          {
            MobCapcha.explode = true;
            GameScr.gI().right = GameScr.gI().cmdFocus;
            goto case 41;
          }
          else
            goto case 41;
        case 15:
          int index3 = (int) msg.reader().readUnsignedByte();
          Mob mob1 = (Mob) null;
          try
          {
            mob1 = (Mob) GameScr.vMob.elementAt(index3);
          }
          catch (Exception ex)
          {
          }
          if (mob1 != null)
          {
            mob1.maxHp = msg.reader().readInt();
            goto case 41;
          }
          else
            goto case 41;
        case 16:
          sbyte num31 = msg.reader().readByte();
          if (num31 == (sbyte) 0)
          {
            int num32 = (int) msg.reader().readShort();
            int num33 = (int) msg.reader().readShort();
            int num34 = (int) msg.reader().readUnsignedByte();
            int num35 = msg.reader().readInt();
            msg.reader().readUTF();
            int num36 = (int) msg.reader().readShort();
            int num37 = (int) msg.reader().readShort();
            GameScr.gI().isRongNamek = msg.reader().readByte() == (sbyte) 1;
            GameScr.gI().xR = num36;
            GameScr.gI().yR = num37;
            Res.outz("xR= " + (object) num36 + " yR= " + (object) num37 + " +++++++++++++++++++++++++++++++++++++++");
            if (Char.myCharz().charID == num35)
            {
              GameCanvas.panel.hideNow();
              GameScr.gI().activeRongThanEff(true);
            }
            else if (TileMap.mapID == num32 && TileMap.zoneID == num34)
              GameScr.gI().activeRongThanEff(false);
            else if (mGraphics.zoomLevel > 1)
              GameScr.gI().doiMauTroi();
            GameScr.gI().mapRID = num32;
            GameScr.gI().bgRID = num33;
            GameScr.gI().zoneRID = num34;
          }
          if (num31 == (sbyte) 1)
          {
            Res.outz("map RID = " + (object) GameScr.gI().mapRID + " zone RID= " + (object) GameScr.gI().zoneRID);
            Res.outz("map ID = " + (object) TileMap.mapID + " zone ID= " + (object) TileMap.zoneID);
            if (TileMap.mapID == GameScr.gI().mapRID && TileMap.zoneID == GameScr.gI().zoneRID)
            {
              GameScr.gI().hideRongThanEff();
            }
            else
            {
              GameScr.gI().isRongThanXuatHien = false;
              if (GameScr.gI().isRongNamek)
                GameScr.gI().isRongNamek = false;
            }
          }
          if (num31 != (sbyte) 2)
            goto case 41;
          else
            goto case 41;
        case 17:
          sbyte length4 = msg.reader().readByte();
          TileMap.tileIndex = new int[(int) length4][][];
          TileMap.tileType = new int[(int) length4][];
          for (int index4 = 0; index4 < (int) length4; ++index4)
          {
            sbyte length5 = msg.reader().readByte();
            TileMap.tileType[index4] = new int[(int) length5];
            TileMap.tileIndex[index4] = new int[(int) length5][];
            for (int index5 = 0; index5 < (int) length5; ++index5)
            {
              TileMap.tileType[index4][index5] = msg.reader().readInt();
              sbyte length6 = msg.reader().readByte();
              TileMap.tileIndex[index4][index5] = new int[(int) length6];
              for (int index6 = 0; index6 < (int) length6; ++index6)
                TileMap.tileIndex[index4][index5][index6] = (int) msg.reader().readByte();
            }
          }
          goto case 41;
        case 18:
          sbyte num38 = msg.reader().readByte();
          if (num38 == (sbyte) 0)
          {
            string src1 = msg.reader().readUTF();
            string src2 = msg.reader().readUTF();
            GameCanvas.panel.setTypeCombine();
            GameCanvas.panel.combineInfo = mFont.tahoma_7b_blue.splitFontArray(src1, Panel.WIDTH_PANEL);
            GameCanvas.panel.combineTopInfo = mFont.tahoma_7.splitFontArray(src2, Panel.WIDTH_PANEL);
            GameCanvas.panel.show();
          }
          if (num38 == (sbyte) 1)
          {
            GameCanvas.panel.vItemCombine.removeAllElements();
            sbyte num39 = msg.reader().readByte();
            for (int index7 = 0; index7 < (int) num39; ++index7)
            {
              sbyte num40 = msg.reader().readByte();
              for (int index8 = 0; index8 < Char.myCharz().arrItemBag.Length; ++index8)
              {
                Item o = Char.myCharz().arrItemBag[index8];
                if (o != null && o.indexUI == (int) num40)
                {
                  o.isSelect = true;
                  GameCanvas.panel.vItemCombine.addElement((object) o);
                }
              }
            }
            if (GameCanvas.panel.isShow)
              GameCanvas.panel.setTabCombine();
          }
          if (num38 == (sbyte) 2)
          {
            GameCanvas.panel.combineSuccess = (sbyte) 0;
            GameCanvas.panel.setCombineEff(0);
          }
          if (num38 == (sbyte) 3)
          {
            GameCanvas.panel.combineSuccess = (sbyte) 1;
            GameCanvas.panel.setCombineEff(0);
          }
          if (num38 == (sbyte) 4)
          {
            short num41 = msg.reader().readShort();
            GameCanvas.panel.iconID3 = num41;
            GameCanvas.panel.combineSuccess = (sbyte) 0;
            GameCanvas.panel.setCombineEff(1);
          }
          if (num38 == (sbyte) 5)
          {
            short num42 = msg.reader().readShort();
            GameCanvas.panel.iconID3 = num42;
            GameCanvas.panel.combineSuccess = (sbyte) 0;
            GameCanvas.panel.setCombineEff(2);
          }
          if (num38 == (sbyte) 6)
          {
            short num43 = msg.reader().readShort();
            short num44 = msg.reader().readShort();
            GameCanvas.panel.combineSuccess = (sbyte) 0;
            GameCanvas.panel.setCombineEff(3);
            GameCanvas.panel.iconID1 = num43;
            GameCanvas.panel.iconID3 = num44;
          }
          if (num38 == (sbyte) 7)
          {
            short num45 = msg.reader().readShort();
            GameCanvas.panel.iconID3 = num45;
            GameCanvas.panel.combineSuccess = (sbyte) 0;
            GameCanvas.panel.setCombineEff(4);
          }
          if (num38 == (sbyte) 8)
          {
            GameCanvas.panel.iconID3 = (short) -1;
            GameCanvas.panel.combineSuccess = (sbyte) 1;
            GameCanvas.panel.setCombineEff(4);
          }
          short num46 = 21;
          try
          {
            num46 = msg.reader().readShort();
          }
          catch (Exception ex)
          {
          }
          for (int index9 = 0; index9 < GameScr.vNpc.size(); ++index9)
          {
            Npc npc = (Npc) GameScr.vNpc.elementAt(index9);
            if (npc.template.npcTemplateId == (int) num46)
            {
              GameCanvas.panel.xS = npc.cx - GameScr.cmx;
              GameCanvas.panel.yS = npc.cy - GameScr.cmy;
              GameCanvas.panel.idNPC = (int) num46;
              break;
            }
          }
          goto case 41;
        case 19:
          sbyte num47 = msg.reader().readByte();
          InfoDlg.hide();
          if (num47 == (sbyte) 0)
          {
            GameCanvas.panel.vFriend.removeAllElements();
            int num48 = (int) msg.reader().readUnsignedByte();
            for (int index10 = 0; index10 < num48; ++index10)
            {
              Char char5 = new Char();
              char5.charID = msg.reader().readInt();
              char5.head = (int) msg.reader().readShort();
              char5.headICON = (int) msg.reader().readShort();
              char5.body = (int) msg.reader().readShort();
              char5.leg = (int) msg.reader().readShort();
              char5.bag = (int) msg.reader().readUnsignedByte();
              char5.cName = msg.reader().readUTF();
              bool flag = msg.reader().readBoolean();
              GameCanvas.panel.vFriend.addElement((object) new InfoItem(mResources.power + ": " + msg.reader().readUTF())
              {
                charInfo = char5,
                isOnline = flag
              });
            }
            GameCanvas.panel.setTypeFriend();
            GameCanvas.panel.show();
          }
          if (num47 == (sbyte) 3)
          {
            MyVector vFriend = GameCanvas.panel.vFriend;
            int num49 = msg.reader().readInt();
            Res.outz("online offline id=" + (object) num49);
            for (int index11 = 0; index11 < vFriend.size(); ++index11)
            {
              InfoItem infoItem = (InfoItem) vFriend.elementAt(index11);
              if (infoItem.charInfo != null && infoItem.charInfo.charID == num49)
              {
                Res.outz("online= " + (object) infoItem.isOnline);
                infoItem.isOnline = msg.reader().readBoolean();
                break;
              }
            }
          }
          if (num47 == (sbyte) 2)
          {
            MyVector vFriend = GameCanvas.panel.vFriend;
            int num50 = msg.reader().readInt();
            for (int index12 = 0; index12 < vFriend.size(); ++index12)
            {
              InfoItem o = (InfoItem) vFriend.elementAt(index12);
              if (o.charInfo != null && o.charInfo.charID == num50)
              {
                vFriend.removeElement((object) o);
                break;
              }
            }
            if (GameCanvas.panel.isShow)
            {
              GameCanvas.panel.setTabFriend();
              goto case 41;
            }
            else
              goto case 41;
          }
          else
            goto case 41;
        case 20:
          InfoDlg.hide();
          msg.reader().readInt();
          Char charMenu = GameCanvas.panel.charMenu;
          if (charMenu == null)
            break;
          charMenu.cPower = msg.reader().readLong();
          charMenu.currStrLevel = msg.reader().readUTF();
          goto case 41;
        case 22:
          short length7 = msg.reader().readShort();
          SmallImage.newSmallVersion = new sbyte[(int) length7];
          SmallImage.maxSmall = length7;
          SmallImage.imgNew = new Small[(int) length7];
          for (int index13 = 0; index13 < (int) length7; ++index13)
            SmallImage.newSmallVersion[index13] = msg.reader().readByte();
          goto case 41;
        case 23:
          switch (msg.reader().readByte())
          {
            case 0:
              sbyte length8 = msg.reader().readByte();
              if (length8 <= (sbyte) 0)
                return;
              Char.myCharz().arrArchive = new Archivement[(int) length8];
              for (int index14 = 0; index14 < (int) length8; ++index14)
              {
                Char.myCharz().arrArchive[index14] = new Archivement();
                Char.myCharz().arrArchive[index14].info1 = (index14 + 1).ToString() + ". " + msg.reader().readUTF();
                Char.myCharz().arrArchive[index14].info2 = msg.reader().readUTF();
                Char.myCharz().arrArchive[index14].money = (int) msg.reader().readShort();
                Char.myCharz().arrArchive[index14].isFinish = msg.reader().readBoolean();
                Char.myCharz().arrArchive[index14].isRecieve = msg.reader().readBoolean();
              }
              GameCanvas.panel.setTypeArchivement();
              GameCanvas.panel.show();
              goto label_901;
            case 1:
              int index15 = (int) msg.reader().readUnsignedByte();
              if (Char.myCharz().arrArchive[index15] != null)
              {
                Char.myCharz().arrArchive[index15].isRecieve = true;
                goto label_901;
              }
              else
                goto label_901;
            default:
              goto label_901;
          }
        case 25:
          if (ServerListScreen.stopDownload)
            break;
          if (!GameCanvas.isGetResourceFromServer())
          {
            Service.gI().getResource((sbyte) 3, (MyVector) null);
            SmallImage.loadBigRMS();
            SplashScr.imgLogo = (Image) null;
            if (Rms.loadRMSString("acc") != null || Rms.loadRMSString("userAo" + (object) ServerListScreen.ipSelect) != null)
              LoginScr.isContinueToLogin = true;
            GameCanvas.loginScr = new LoginScr();
            GameCanvas.loginScr.switchToMe();
            break;
          }
          bool flag1 = true;
          sbyte num51 = msg.reader().readByte();
          Res.outz("action = " + (object) num51);
          if (num51 == (sbyte) 0)
          {
            int num52 = msg.reader().readInt();
            string s = Rms.loadRMSString("ResVersion");
            int num53 = s == null || !(s != string.Empty) ? -1 : int.Parse(s);
            if (num53 == -1 || num53 != num52)
            {
              ServerListScreen.loadScreen = false;
              GameCanvas.serverScreen.show2();
            }
            else
            {
              Res.outz("login ngay");
              SmallImage.loadBigRMS();
              SplashScr.imgLogo = (Image) null;
              ServerListScreen.loadScreen = true;
              if (GameCanvas.currentScreen != GameCanvas.loginScr)
                GameCanvas.serverScreen.switchToMe();
            }
          }
          if (num51 == (sbyte) 1)
          {
            ServerListScreen.strWait = mResources.downloading_data;
            ServerListScreen.nBig = (int) msg.reader().readShort();
            Service.gI().getResource((sbyte) 2, (MyVector) null);
          }
          if (num51 == (sbyte) 2)
          {
            try
            {
              Controller.isLoadingData = true;
              GameCanvas.endDlg();
              ++ServerListScreen.demPercent;
              ServerListScreen.percent = ServerListScreen.demPercent * 100 / ServerListScreen.nBig;
              string[] strArray = Res.split(msg.reader().readUTF(), "/", 0);
              string filename = "x" + (object) mGraphics.zoomLevel + strArray[strArray.Length - 1];
              int length9 = msg.reader().readInt();
              sbyte[] data3 = new sbyte[length9];
              msg.reader().read(ref data3, 0, length9);
              Rms.saveRMS(filename, data3);
            }
            catch (Exception ex)
            {
              GameCanvas.startOK(mResources.pls_restart_game_error, 8885, (object) null);
            }
          }
          if (num51 == (sbyte) 3 && flag1)
          {
            Controller.isLoadingData = false;
            int num54 = msg.reader().readInt();
            Res.outz("last version= " + (object) num54);
            Rms.saveRMSString("ResVersion", num54.ToString() + string.Empty);
            Service.gI().getResource((sbyte) 3, (MyVector) null);
            GameCanvas.endDlg();
            SplashScr.imgLogo = (Image) null;
            SmallImage.loadBigRMS();
            mSystem.gcc();
            ServerListScreen.bigOk = true;
            ServerListScreen.loadScreen = true;
            GameScr.gI().loadGameScr();
            if (GameCanvas.currentScreen != GameCanvas.loginScr)
            {
              GameCanvas.serverScreen.switchToMe();
              goto case 41;
            }
            else
              goto case 41;
          }
          else
            goto case 41;
        case 29:
          Res.outz("BIG MESSAGE .......................................");
          GameCanvas.endDlg();
          int num55 = (int) msg.reader().readShort();
          string chat1 = msg.reader().readUTF();
          Npc c1 = new Npc(-1, 0, 0, 0, 0, 0);
          c1.avatar = num55;
          ChatPopup.addBigMessage(chat1, 100000, c1);
          sbyte num56 = msg.reader().readByte();
          if (num56 == (sbyte) 0)
          {
            ChatPopup.serverChatPopUp.cmdMsg1 = new Command(mResources.CLOSE, (IActionListener) ChatPopup.serverChatPopUp, 1001, (object) null);
            ChatPopup.serverChatPopUp.cmdMsg1.x = GameCanvas.w / 2 - 35;
            ChatPopup.serverChatPopUp.cmdMsg1.y = GameCanvas.h - 35;
          }
          if (num56 == (sbyte) 1)
          {
            string p = msg.reader().readUTF();
            string caption = msg.reader().readUTF();
            ChatPopup.serverChatPopUp.cmdMsg1 = new Command(caption, (IActionListener) ChatPopup.serverChatPopUp, 1000, (object) p);
            ChatPopup.serverChatPopUp.cmdMsg1.x = GameCanvas.w / 2 - 75;
            ChatPopup.serverChatPopUp.cmdMsg1.y = GameCanvas.h - 35;
            ChatPopup.serverChatPopUp.cmdMsg2 = new Command(mResources.CLOSE, (IActionListener) ChatPopup.serverChatPopUp, 1001, (object) null);
            ChatPopup.serverChatPopUp.cmdMsg2.x = GameCanvas.w / 2 + 11;
            ChatPopup.serverChatPopUp.cmdMsg2.y = GameCanvas.h - 35;
            goto case 41;
          }
          else
            goto case 41;
        case 30:
          Char.myCharz().cMaxStamina = msg.reader().readShort();
          goto case 41;
        case 31:
          Char.myCharz().cStamina = (int) msg.reader().readShort();
          goto case 41;
        case 32:
          Res.outz("RECIEVE ICON");
          ++this.demCount;
          int index16 = msg.reader().readInt();
          sbyte[] numArray1;
          try
          {
            numArray1 = NinjaUtil.readByteArray(msg);
            Res.outz("request hinh icon = " + (object) index16);
            if (index16 == 3896)
              Res.outz("SIZE CHECK= " + (object) numArray1.Length);
            SmallImage.imgNew[index16].img = this.createImage(numArray1);
          }
          catch (Exception ex)
          {
            numArray1 = (sbyte[]) null;
            SmallImage.imgNew[index16].img = Image.createRGBImage(new int[1], 1, 1, true);
          }
          if (numArray1 != null && mGraphics.zoomLevel > 1)
          {
            Rms.saveRMS(mGraphics.zoomLevel.ToString() + "Small" + (object) index16, numArray1);
            goto case 41;
          }
          else
            goto case 41;
        case 33:
          short id1 = msg.reader().readShort();
          sbyte[] data4 = NinjaUtil.readByteArray(msg);
          EffectData effDataById = Effect.getEffDataById((int) id1);
          sbyte typeread1 = msg.reader().readSByte();
          if (typeread1 == (sbyte) 0)
            effDataById.readData(data4);
          else
            effDataById.readDataNewBoss(data4, typeread1);
          sbyte[] imageData1 = NinjaUtil.readByteArray(msg);
          effDataById.img = Image.createImage(imageData1, 0, imageData1.Length);
          goto case 41;
        case 34:
          Res.outz("TELEPORT ...................................................");
          InfoDlg.hide();
          int charId2 = msg.reader().readInt();
          sbyte num57 = msg.reader().readByte();
          if (num57 != (sbyte) 0)
          {
            if (Char.myCharz().charID == charId2)
            {
              Controller.isStopReadMessage = true;
              GameScr.lockTick = 500;
              GameScr.gI().center = (Command) null;
              if (num57 == (sbyte) 0 || num57 == (sbyte) 1 || num57 == (sbyte) 3)
                Teleport.addTeleport(new Teleport(Char.myCharz().cx, Char.myCharz().cy, Char.myCharz().head, Char.myCharz().cdir, 0, true, num57 != (sbyte) 1 ? (int) num57 : Char.myCharz().cgender));
              if (num57 == (sbyte) 2)
              {
                GameScr.lockTick = 50;
                Char.myCharz().hide();
                goto case 41;
              }
              else
                goto case 41;
            }
            else
            {
              Char charInMap = GameScr.findCharInMap(charId2);
              if ((num57 == (sbyte) 0 || num57 == (sbyte) 1 || num57 == (sbyte) 3) && charInMap != null)
              {
                charInMap.isUsePlane = true;
                Teleport.addTeleport(new Teleport(charInMap.cx, charInMap.cy, charInMap.head, charInMap.cdir, 0, false, num57 != (sbyte) 1 ? (int) num57 : charInMap.cgender)
                {
                  id = charId2
                });
              }
              if (num57 == (sbyte) 2)
              {
                charInMap.hide();
                goto case 41;
              }
              else
                goto case 41;
            }
          }
          else
            goto case 41;
        case 35:
          int charId3 = msg.reader().readInt();
          int num58 = (int) msg.reader().readUnsignedByte();
          if (charId3 == Char.myCharz().charID)
          {
            Char.myCharz().bag = num58;
            goto case 41;
          }
          else if (GameScr.findCharInMap(charId3) != null)
          {
            GameScr.findCharInMap(charId3).bag = num58;
            goto case 41;
          }
          else
            goto case 41;
        case 36:
          Res.outz("GET BAG");
          int num59 = (int) msg.reader().readUnsignedByte();
          sbyte length10 = msg.reader().readByte();
          ClanImage v = new ClanImage();
          v.ID = num59;
          if (length10 > (sbyte) 0)
          {
            v.idImage = new short[(int) length10];
            for (int index17 = 0; index17 < (int) length10; ++index17)
            {
              v.idImage[index17] = msg.reader().readShort();
              Res.outz("ID=  " + (object) num59 + " frame= " + (object) v.idImage[index17]);
            }
            ClanImage.idImages.put((object) (num59.ToString() + string.Empty), (object) v);
            goto case 41;
          }
          else
            goto case 41;
        case 37:
          int ID = (int) msg.reader().readUnsignedByte();
          sbyte length11 = msg.reader().readByte();
          if (length11 > (sbyte) 0)
          {
            ClanImage clanImage = ClanImage.getClanImage((sbyte) ID);
            if (clanImage != null)
            {
              clanImage.idImage = new short[(int) length11];
              for (int index18 = 0; index18 < (int) length11; ++index18)
              {
                clanImage.idImage[index18] = msg.reader().readShort();
                if (clanImage.idImage[index18] > (short) 0)
                  SmallImage.vKeys.addElement((object) (clanImage.idImage[index18].ToString() + string.Empty));
              }
              goto case 41;
            }
            else
              goto case 41;
          }
          else
            goto case 41;
        case 38:
          int charId4 = msg.reader().readInt();
          if (charId4 != Char.myCharz().charID)
          {
            if (GameScr.findCharInMap(charId4) != null)
            {
              GameScr.findCharInMap(charId4).clanID = msg.reader().readInt();
              if (GameScr.findCharInMap(charId4).clanID == -2)
              {
                GameScr.findCharInMap(charId4).isCopy = true;
                goto case 41;
              }
              else
                goto case 41;
            }
            else
              goto case 41;
          }
          else if (Char.myCharz().clan != null)
          {
            Char.myCharz().clan.ID = msg.reader().readInt();
            goto case 41;
          }
          else
            goto case 41;
        case 39:
          GameCanvas.debug("SA7666", 2);
          int charId5 = msg.reader().readInt();
          int charId6 = -1;
          if (charId5 != Char.myCharz().charID)
          {
            Char charInMap = GameScr.findCharInMap(charId5);
            if (charInMap == null)
              break;
            if (charInMap.currentMovePoint != null)
            {
              charInMap.createShadow(charInMap.cx, charInMap.cy, 10);
              charInMap.cx = charInMap.currentMovePoint.xEnd;
              charInMap.cy = charInMap.currentMovePoint.yEnd;
            }
            int index19 = (int) msg.reader().readUnsignedByte();
            Res.outz("player skill ID= " + (object) index19);
            if ((TileMap.tileTypeAtPixel(charInMap.cx, charInMap.cy) & 2) == 2)
              charInMap.setSkillPaint(GameScr.sks[index19], 0);
            else
              charInMap.setSkillPaint(GameScr.sks[index19], 1);
            sbyte length12 = msg.reader().readByte();
            Res.outz("nAttack = " + (object) length12);
            Char[] charArray = new Char[(int) length12];
            int length13;
            for (length13 = 0; length13 < charArray.Length; ++length13)
            {
              charId6 = msg.reader().readInt();
              Char char6;
              if (charId6 == Char.myCharz().charID)
              {
                char6 = Char.myCharz();
                if (!GameScr.isChangeZone && GameScr.isAutoPlay && GameScr.canAutoPlay)
                {
                  Service.gI().requestChangeZone(-1, -1);
                  GameScr.isChangeZone = true;
                }
              }
              else
                char6 = GameScr.findCharInMap(charId6);
              charArray[length13] = char6;
              if (length13 == 0)
                charInMap.cdir = charInMap.cx > char6.cx ? -1 : 1;
            }
            if (length13 > 0)
            {
              charInMap.attChars = new Char[length13];
              for (int index20 = 0; index20 < charInMap.attChars.Length; ++index20)
                charInMap.attChars[index20] = charArray[index20];
              charInMap.mobFocus = (Mob) null;
              charInMap.charFocus = charInMap.attChars[0];
            }
          }
          else
          {
            msg.reader().readByte();
            msg.reader().readByte();
            charId6 = msg.reader().readInt();
          }
          try
          {
            sbyte num60 = msg.reader().readByte();
            Res.outz("isRead continue = " + (object) num60);
            if (num60 == (sbyte) 1)
            {
              sbyte num61 = msg.reader().readByte();
              Res.outz("type skill = " + (object) num61);
              if (charId6 == Char.myCharz().charID)
              {
                Char char7 = Char.myCharz();
                int num62 = msg.readInt3Byte();
                Res.outz("dame hit = " + (object) num62);
                char7.isDie = msg.reader().readBoolean();
                if (char7.isDie)
                  Char.isLockKey = true;
                Res.outz("isDie=" + (object) char7.isDie + "---------------------------------------");
                int num63 = 0;
                bool isCrit = msg.reader().readBoolean();
                char7.isCrit = isCrit;
                char7.isMob = false;
                int HPShow = num62 + num63;
                char7.damHP = HPShow;
                if (num61 == (sbyte) 0)
                {
                  char7.doInjure(HPShow, 0, isCrit, false);
                  goto case 41;
                }
                else
                  goto case 41;
              }
              else
              {
                Char charInMap = GameScr.findCharInMap(charId6);
                if (charInMap == null)
                  break;
                int num64 = msg.readInt3Byte();
                Res.outz("dame hit= " + (object) num64);
                charInMap.isDie = msg.reader().readBoolean();
                Res.outz("isDie=" + (object) charInMap.isDie + "---------------------------------------");
                int num65 = 0;
                bool isCrit = msg.reader().readBoolean();
                charInMap.isCrit = isCrit;
                charInMap.isMob = false;
                int HPShow = num64 + num65;
                charInMap.damHP = HPShow;
                if (num61 == (sbyte) 0)
                {
                  charInMap.doInjure(HPShow, 0, isCrit, false);
                  goto case 41;
                }
                else
                  goto case 41;
              }
            }
            else
              goto case 41;
          }
          catch (Exception ex)
          {
            goto case 41;
          }
        case 40:
          sbyte typePK = msg.reader().readByte();
          GameScr.gI().player_vs_player(msg.reader().readInt(), msg.reader().readInt(), msg.reader().readUTF(), typePK);
          goto case 41;
        case 41:
        case 177:
        case 178:
label_901:
          sbyte command2 = msg.command;
          switch ((int) command2 + 17)
          {
            case 0:
              GameCanvas.debug("SA88", 2);
              Char.myCharz().meDead = true;
              Char.myCharz().cPk = msg.reader().readByte();
              Char.myCharz().startDie(msg.reader().readShort(), msg.reader().readShort());
              try
              {
                Char.myCharz().cPower = msg.reader().readLong();
                Char.myCharz().applyCharLevelPercent();
              }
              catch (Exception ex)
              {
                Cout.println("Loi tai ME_DIE " + (object) msg.command);
              }
              Char.myCharz().countKill = 0;
              break;
            case 1:
              GameCanvas.debug("SA90", 2);
              if (Char.myCharz().wdx != (short) 0 || Char.myCharz().wdy != (short) 0)
              {
                Char.myCharz().cx = (int) Char.myCharz().wdx;
                Char.myCharz().cy = (int) Char.myCharz().wdy;
                Char.myCharz().wdx = Char.myCharz().wdy = (short) 0;
              }
              Char.myCharz().liveFromDead();
              Char.myCharz().isLockMove = false;
              Char.myCharz().meDead = false;
              break;
            case 4:
              GameCanvas.debug("SA82", 2);
              int index21 = (int) msg.reader().readUnsignedByte();
              if (index21 > GameScr.vMob.size() - 1 || index21 < 0)
                return;
              Mob mob2 = (Mob) GameScr.vMob.elementAt(index21);
              mob2.sys = (int) msg.reader().readByte();
              mob2.levelBoss = msg.reader().readByte();
              if (mob2.levelBoss != (sbyte) 0)
                mob2.typeSuperEff = Res.random(0, 3);
              mob2.x = mob2.xFirst;
              mob2.y = mob2.yFirst;
              mob2.status = 5;
              mob2.injureThenDie = false;
              mob2.hp = msg.reader().readInt();
              mob2.maxHp = mob2.hp;
              ServerEffect.addServerEffect(60, mob2.x, mob2.y, 1);
              break;
            case 5:
              Res.outz("SERVER SEND MOB DIE");
              GameCanvas.debug("SA85", 2);
              Mob mob3 = (Mob) null;
              try
              {
                mob3 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
              }
              catch (Exception ex)
              {
                Cout.println("LOi tai NPC_DIE cmd " + (object) msg.command);
              }
              if (mob3 != null && mob3.status != 0 && mob3.status != 0)
              {
                mob3.startDie();
                try
                {
                  int num66 = msg.readInt3Byte();
                  if (msg.reader().readBool())
                    GameScr.startFlyText("-" + (object) num66, mob3.x, mob3.y - mob3.h, 0, -2, mFont.FATAL);
                  else
                    GameScr.startFlyText("-" + (object) num66, mob3.x, mob3.y - mob3.h, 0, -2, mFont.ORANGE);
                  sbyte num67 = msg.reader().readByte();
                  for (int index22 = 0; index22 < (int) num67; ++index22)
                  {
                    ItemMap o = new ItemMap(msg.reader().readShort(), msg.reader().readShort(), mob3.x, mob3.y, (int) msg.reader().readShort(), (int) msg.reader().readShort());
                    int num68 = msg.reader().readInt();
                    o.playerId = num68;
                    Res.outz("playerid= " + (object) num68 + " my id= " + (object) Char.myCharz().charID);
                    GameScr.vItemMap.addElement((object) o);
                    if (Res.abs(o.y - Char.myCharz().cy) < 24 && Res.abs(o.x - Char.myCharz().cx) < 24)
                      Char.myCharz().charFocus = (Char) null;
                  }
                  break;
                }
                catch (Exception ex)
                {
                  Cout.println("LOi tai NPC_DIE " + ex.ToString() + " cmd " + (object) msg.command);
                  break;
                }
              }
              else
                break;
            case 6:
              GameCanvas.debug("SA86", 2);
              Mob mob4 = (Mob) null;
              try
              {
                int index23 = (int) msg.reader().readUnsignedByte();
                mob4 = (Mob) GameScr.vMob.elementAt(index23);
              }
              catch (Exception ex)
              {
                Cout.println("Loi tai NPC_ATTACK_ME " + (object) msg.command);
              }
              if (mob4 != null)
              {
                Char.myCharz().isDie = false;
                Char.isLockKey = false;
                int HPShow = msg.readInt3Byte();
                int MPShow;
                try
                {
                  MPShow = msg.readInt3Byte();
                }
                catch (Exception ex)
                {
                  MPShow = 0;
                }
                if (mob4.isBusyAttackSomeOne)
                {
                  Char.myCharz().doInjure(HPShow, MPShow, false, true);
                  break;
                }
                mob4.dame = HPShow;
                mob4.dameMp = MPShow;
                mob4.setAttack(Char.myCharz());
                break;
              }
              break;
            case 7:
              GameCanvas.debug("SA87", 2);
              Mob mob5 = (Mob) null;
              try
              {
                mob5 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
              }
              catch (Exception ex)
              {
              }
              GameCanvas.debug("SA87x1", 2);
              if (mob5 != null)
              {
                GameCanvas.debug("SA87x2", 2);
                Char charInMap = GameScr.findCharInMap(msg.reader().readInt());
                if (charInMap == null)
                  return;
                GameCanvas.debug("SA87x3", 2);
                int num69 = msg.readInt3Byte();
                mob5.dame = charInMap.cHP - num69;
                charInMap.cHPNew = num69;
                GameCanvas.debug("SA87x4", 2);
                try
                {
                  charInMap.cMP = msg.readInt3Byte();
                }
                catch (Exception ex)
                {
                }
                GameCanvas.debug("SA87x5", 2);
                if (mob5.isBusyAttackSomeOne)
                  charInMap.doInjure(mob5.dame, 0, false, true);
                else
                  mob5.setAttack(charInMap);
                GameCanvas.debug("SA87x6", 2);
                break;
              }
              break;
            case 8:
              GameCanvas.debug("SA83", 2);
              Mob mob6 = (Mob) null;
              try
              {
                mob6 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
              }
              catch (Exception ex)
              {
              }
              GameCanvas.debug("SA83v1", 2);
              if (mob6 != null)
              {
                mob6.hp = msg.readInt3Byte();
                int num70 = msg.readInt3Byte();
                if (num70 == 1)
                  return;
                bool flag2 = false;
                try
                {
                  flag2 = msg.reader().readBoolean();
                }
                catch (Exception ex)
                {
                }
                sbyte id2 = msg.reader().readByte();
                if (id2 != (sbyte) -1)
                  EffecMn.addEff(new Effect((int) id2, mob6.x, mob6.getY(), 3, 1, -1));
                GameCanvas.debug("SA83v2", 2);
                if (flag2)
                  GameScr.startFlyText("-" + (object) num70, mob6.x, mob6.getY() - mob6.getH(), 0, -2, mFont.FATAL);
                else if (num70 == 0)
                {
                  mob6.x = mob6.xFirst;
                  mob6.y = mob6.yFirst;
                  GameScr.startFlyText(mResources.miss, mob6.x, mob6.getY() - mob6.getH(), 0, -2, mFont.MISS);
                }
                else
                  GameScr.startFlyText("-" + (object) num70, mob6.x, mob6.getY() - mob6.getH(), 0, -2, mFont.ORANGE);
              }
              GameCanvas.debug("SA83v3", 2);
              break;
            case 9:
              GameCanvas.debug("SA89", 2);
              Char charInMap1 = GameScr.findCharInMap(msg.reader().readInt());
              if (charInMap1 == null)
                return;
              charInMap1.cPk = msg.reader().readByte();
              charInMap1.waitToDie(msg.reader().readShort(), msg.reader().readShort());
              break;
            case 10:
              GameCanvas.debug("SA80", 2);
              int num71 = msg.reader().readInt();
              Cout.println("RECEVED MOVE OF " + (object) num71);
              for (int index24 = 0; index24 < GameScr.vCharInMap.size(); ++index24)
              {
                Char char8 = (Char) null;
                try
                {
                  char8 = (Char) GameScr.vCharInMap.elementAt(index24);
                }
                catch (Exception ex)
                {
                  Cout.println("Loi PLAYER_MOVE " + ex.ToString());
                }
                if (char8 != null)
                {
                  if (char8.charID == num71)
                  {
                    GameCanvas.debug("SA8x2y" + (object) index24, 2);
                    char8.moveTo((int) msg.reader().readShort(), (int) msg.reader().readShort(), 0);
                    char8.lastUpdateTime = mSystem.currentTimeMillis();
                    break;
                  }
                }
                else
                  break;
              }
              GameCanvas.debug("SA80x3", 2);
              break;
            case 11:
              GameCanvas.debug("SA81", 2);
              int num72 = msg.reader().readInt();
              for (int index25 = 0; index25 < GameScr.vCharInMap.size(); ++index25)
              {
                Char char9 = (Char) GameScr.vCharInMap.elementAt(index25);
                if (char9 != null && char9.charID == num72)
                {
                  if (!char9.isInvisiblez && !char9.isUsePlane)
                    ServerEffect.addServerEffect(60, char9.cx, char9.cy, 1);
                  if (char9.isUsePlane)
                    return;
                  GameScr.vCharInMap.removeElementAt(index25);
                  return;
                }
              }
              break;
            case 12:
              GameCanvas.debug("SA79", 2);
              int num73 = msg.reader().readInt();
              int num74 = msg.reader().readInt();
              Char char10;
              if (num74 != -100)
              {
                char10 = new Char();
                char10.charID = num73;
                char10.clanID = num74;
              }
              else
              {
                char10 = (Char) new Mabu();
                char10.charID = num73;
                char10.clanID = num74;
              }
              if (char10.clanID == -2)
                char10.isCopy = true;
              if (this.readCharInfo(char10, msg))
              {
                sbyte num75 = msg.reader().readByte();
                if (char10.cy <= 10 && num75 != (sbyte) 0 && num75 != (sbyte) 2)
                {
                  Res.outz("nhân vật bay trên trời xuống x= " + (object) char10.cx + " y= " + (object) char10.cy);
                  Teleport p = new Teleport(char10.cx, char10.cy, char10.head, char10.cdir, 1, false, num75 != (sbyte) 1 ? (int) num75 : char10.cgender);
                  p.id = char10.charID;
                  char10.isTeleport = true;
                  Teleport.addTeleport(p);
                }
                if (num75 == (sbyte) 2)
                  char10.show();
                for (int index26 = 0; index26 < GameScr.vMob.size(); ++index26)
                {
                  Mob mob7 = (Mob) GameScr.vMob.elementAt(index26);
                  if (mob7 != null && mob7.isMobMe && mob7.mobId == char10.charID)
                  {
                    Res.outz("co 1 con quai");
                    char10.mobMe = mob7;
                    char10.mobMe.x = char10.cx;
                    char10.mobMe.y = char10.cy - 40;
                    break;
                  }
                }
                if (GameScr.findCharInMap(char10.charID) == null)
                  GameScr.vCharInMap.addElement((object) char10);
                char10.isMonkey = msg.reader().readByte();
                short num76 = msg.reader().readShort();
                Res.outz("mount id= " + (object) num76 + "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                if (num76 != (short) -1)
                {
                  char10.isHaveMount = true;
                  if (num76 == (short) 346 || num76 == (short) 347 || num76 == (short) 348)
                    char10.isMountVip = false;
                  else if (num76 == (short) 349 || num76 == (short) 350 || num76 == (short) 351)
                  {
                    char10.isMountVip = true;
                  }
                  else
                  {
                    switch (num76)
                    {
                      case 396:
                        char10.isEventMount = true;
                        break;
                      case 532:
                        char10.isSpeacialMount = true;
                        break;
                      default:
                        if ((int) num76 >= (int) Char.ID_NEW_MOUNT)
                        {
                          char10.idMount = num76;
                          break;
                        }
                        break;
                    }
                  }
                }
                else
                  char10.isHaveMount = false;
              }
              sbyte num77 = msg.reader().readByte();
              Res.outz("addplayer:   " + (object) num77);
              char10.cFlag = num77;
              char10.isNhapThe = msg.reader().readByte() == (sbyte) 1;
              try
              {
                char10.idAuraEff = msg.reader().readShort();
                char10.idEff_Set_Item = (short) msg.reader().readSByte();
                char10.idHat = msg.reader().readShort();
              }
              catch (Exception ex)
              {
              }
              GameScr.gI().getFlagImage(char10.charID, char10.cFlag);
              break;
            case 14:
              GameCanvas.debug("SA78", 2);
              sbyte num78 = msg.reader().readByte();
              int num79 = msg.reader().readInt();
              if (num78 == (sbyte) 0)
                Char.myCharz().cPower += (long) num79;
              if (num78 == (sbyte) 1)
                Char.myCharz().cTiemNang += (long) num79;
              if (num78 == (sbyte) 2)
              {
                Char.myCharz().cPower += (long) num79;
                Char.myCharz().cTiemNang += (long) num79;
              }
              Char.myCharz().applyCharLevelPercent();
              if (Char.myCharz().cTypePk != (sbyte) 3)
              {
                GameScr.startFlyText((num79 <= 0 ? (object) string.Empty : (object) "+").ToString() + (object) num79, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch, 0, -4, mFont.GREEN);
                if (num79 > 0 && Char.myCharz().petFollow != null && Char.myCharz().petFollow.smallID == (short) 5002)
                {
                  ServerEffect.addServerEffect(55, Char.myCharz().petFollow.cmx, Char.myCharz().petFollow.cmy, 1);
                  ServerEffect.addServerEffect(55, Char.myCharz().cx, Char.myCharz().cy, 1);
                  break;
                }
                break;
              }
              break;
            case 15:
              GameCanvas.debug("SA77", 22);
              int num80 = msg.reader().readInt();
              Char.myCharz().yen += num80;
              GameScr.startFlyText(num80 <= 0 ? string.Empty + (object) num80 : "+" + (object) num80, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch - 10, 0, -2, mFont.YELLOW);
              break;
            case 16:
              GameCanvas.debug("SA77", 222);
              int num81 = msg.reader().readInt();
              Char.myCharz().xu += (long) num81;
              Char.myCharz().xuStr = mSystem.numberTostring(Char.myCharz().xu);
              Char.myCharz().yen -= num81;
              GameScr.startFlyText("+" + (object) num81, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch - 10, 0, -2, mFont.YELLOW);
              break;
            default:
              switch (command2)
              {
                case 95:
                  GameCanvas.debug("SA77", 22);
                  int num82 = msg.reader().readInt();
                  Char.myCharz().xu += (long) num82;
                  Char.myCharz().xuStr = mSystem.numberTostring(Char.myCharz().xu);
                  GameScr.startFlyText(num82 <= 0 ? string.Empty + (object) num82 : "+" + (object) num82, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch - 10, 0, -2, mFont.YELLOW);
                  break;
                case 96:
                  GameCanvas.debug("SA77a", 22);
                  Char.myCharz().taskOrders.addElement((object) new TaskOrder(msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readUTF(), msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readByte()));
                  break;
                case 97:
                  sbyte num83 = msg.reader().readByte();
                  for (int index27 = 0; index27 < Char.myCharz().taskOrders.size(); ++index27)
                  {
                    TaskOrder taskOrder = (TaskOrder) Char.myCharz().taskOrders.elementAt(index27);
                    if (taskOrder.taskId == (int) num83)
                    {
                      taskOrder.count = (int) msg.reader().readShort();
                      break;
                    }
                  }
                  break;
                default:
                  switch ((int) command2 + 75)
                  {
                    case 0:
                      Mob mob8 = (Mob) null;
                      try
                      {
                        mob8 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
                      }
                      catch (Exception ex)
                      {
                      }
                      if (mob8 != null)
                      {
                        mob8.levelBoss = msg.reader().readByte();
                        if (mob8.levelBoss > (sbyte) 0)
                        {
                          mob8.typeSuperEff = Res.random(0, 3);
                          break;
                        }
                        break;
                      }
                      break;
                    case 2:
                      sbyte num84 = msg.reader().readByte();
                      for (int index28 = 0; index28 < GameScr.vNpc.size(); ++index28)
                      {
                        Npc npc = (Npc) GameScr.vNpc.elementAt(index28);
                        if (npc.template.npcTemplateId == (int) num84)
                        {
                          npc.isHide = msg.reader().readByte() == (sbyte) 0;
                          break;
                        }
                      }
                      break;
                    default:
                      switch (command2)
                      {
                        case 18:
                          sbyte num85 = msg.reader().readByte();
                          for (int index29 = 0; index29 < (int) num85; ++index29)
                          {
                            int charId7 = msg.reader().readInt();
                            int num86 = (int) msg.reader().readShort();
                            int num87 = (int) msg.reader().readShort();
                            int num88 = msg.readInt3Byte();
                            Char charInMap2 = GameScr.findCharInMap(charId7);
                            if (charInMap2 != null)
                            {
                              charInMap2.cx = num86;
                              charInMap2.cy = num87;
                              charInMap2.cHP = charInMap2.cHPShow = num88;
                              charInMap2.lastUpdateTime = mSystem.currentTimeMillis();
                            }
                          }
                          break;
                        case 19:
                          Char.myCharz().countKill = (int) msg.reader().readUnsignedShort();
                          Char.myCharz().countKillMax = (int) msg.reader().readUnsignedShort();
                          break;
                        case 44:
                          GameCanvas.debug("SA91", 2);
                          int charId8 = msg.reader().readInt();
                          string info1 = msg.reader().readUTF();
                          Res.outz("user id= " + (object) charId8 + " text= " + info1);
                          Char char11 = Char.myCharz().charID != charId8 ? GameScr.findCharInMap(charId8) : Char.myCharz();
                          if (char11 == null)
                            return;
                          char11.addInfo(info1);
                          break;
                        case 45:
                          GameCanvas.debug("SA84", 2);
                          Mob mob9 = (Mob) null;
                          try
                          {
                            mob9 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
                          }
                          catch (Exception ex)
                          {
                            Cout.println("Loi tai NPC_MISS  " + ex.ToString());
                          }
                          if (mob9 != null)
                          {
                            mob9.hp = msg.reader().readInt();
                            GameScr.startFlyText(mResources.miss, mob9.x, mob9.y - mob9.h, 0, -2, mFont.MISS);
                            break;
                          }
                          break;
                        case 66:
                          Res.outz("ME DIE XP DOWN NOT IMPLEMENT YET!!!!!!!!!!!!!!!!!!!!!!!!!!");
                          break;
                        case 74:
                          GameCanvas.debug("SA85", 2);
                          Mob mob10 = (Mob) null;
                          try
                          {
                            mob10 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
                          }
                          catch (Exception ex)
                          {
                            Cout.println("Loi tai NPC CHANGE " + (object) msg.command);
                          }
                          if (mob10 != null && mob10.status != 0 && mob10.status != 0)
                          {
                            mob10.status = 0;
                            ServerEffect.addServerEffect(60, mob10.x, mob10.y, 1);
                            ItemMap o = new ItemMap(msg.reader().readShort(), msg.reader().readShort(), mob10.x, mob10.y, (int) msg.reader().readShort(), (int) msg.reader().readShort());
                            GameScr.vItemMap.addElement((object) o);
                            if (Res.abs(o.y - Char.myCharz().cy) < 24 && Res.abs(o.x - Char.myCharz().cx) < 24)
                            {
                              Char.myCharz().charFocus = (Char) null;
                              break;
                            }
                            break;
                          }
                          break;
                      }
                      break;
                  }
                  break;
              }
              break;
          }
          GameCanvas.debug("SA92", 2);
          break;
        case 42:
          string strInvite = msg.reader().readUTF();
          int clanID = msg.reader().readInt();
          int code = msg.reader().readInt();
          GameScr.gI().clanInvite(strInvite, clanID, code);
          goto case 41;
        case 46:
          Res.outz("MY CLAN INFO");
          InfoDlg.hide();
          bool flag3 = false;
          int num89 = msg.reader().readInt();
          Res.outz("clanId= " + (object) num89);
          if (num89 == -1)
          {
            Char.myCharz().clan = (Clan) null;
            ClanMessage.vMessage.removeAllElements();
            if (GameCanvas.panel.member != null)
              GameCanvas.panel.member.removeAllElements();
            if (GameCanvas.panel.myMember != null)
              GameCanvas.panel.myMember.removeAllElements();
            if (GameCanvas.currentScreen != GameScr.gI())
              break;
            GameCanvas.panel.setTabClans();
            break;
          }
          GameCanvas.panel.tabIcon = (TabClanIcon) null;
          if (Char.myCharz().clan == null)
            Char.myCharz().clan = new Clan();
          Char.myCharz().clan.ID = num89;
          Char.myCharz().clan.name = msg.reader().readUTF();
          Char.myCharz().clan.slogan = msg.reader().readUTF();
          Char.myCharz().clan.imgID = (int) msg.reader().readUnsignedByte();
          Char.myCharz().clan.powerPoint = msg.reader().readUTF();
          Char.myCharz().clan.leaderName = msg.reader().readUTF();
          Char.myCharz().clan.currMember = (int) msg.reader().readUnsignedByte();
          Char.myCharz().clan.maxMember = (int) msg.reader().readUnsignedByte();
          Char.myCharz().role = msg.reader().readByte();
          Char.myCharz().clan.clanPoint = msg.reader().readInt();
          Char.myCharz().clan.level = (int) msg.reader().readByte();
          GameCanvas.panel.myMember = new MyVector();
          for (int index30 = 0; index30 < Char.myCharz().clan.currMember; ++index30)
            GameCanvas.panel.myMember.addElement((object) new Member()
            {
              ID = msg.reader().readInt(),
              head = msg.reader().readShort(),
              headICON = msg.reader().readShort(),
              leg = msg.reader().readShort(),
              body = msg.reader().readShort(),
              name = msg.reader().readUTF(),
              role = msg.reader().readByte(),
              powerPoint = msg.reader().readUTF(),
              donate = msg.reader().readInt(),
              receive_donate = msg.reader().readInt(),
              clanPoint = msg.reader().readInt(),
              curClanPoint = msg.reader().readInt(),
              joinTime = NinjaUtil.getDate(msg.reader().readInt())
            });
          int num90 = (int) msg.reader().readUnsignedByte();
          for (int index31 = 0; index31 < num90; ++index31)
            this.readClanMsg(msg, -1);
          if (GameCanvas.panel.isSearchClan || GameCanvas.panel.isViewMember || GameCanvas.panel.isMessage)
            GameCanvas.panel.setTabClans();
          if (flag3)
          {
            GameCanvas.panel.setTabClans();
            goto case 41;
          }
          else
            goto case 41;
        case 47:
          sbyte num91 = msg.reader().readByte();
          if (num91 == (sbyte) 0)
          {
            Member o = new Member();
            o.ID = msg.reader().readInt();
            o.head = msg.reader().readShort();
            o.headICON = msg.reader().readShort();
            o.leg = msg.reader().readShort();
            o.body = msg.reader().readShort();
            o.name = msg.reader().readUTF();
            o.role = msg.reader().readByte();
            o.powerPoint = msg.reader().readUTF();
            o.donate = msg.reader().readInt();
            o.receive_donate = msg.reader().readInt();
            o.clanPoint = msg.reader().readInt();
            o.joinTime = NinjaUtil.getDate(msg.reader().readInt());
            if (GameCanvas.panel.myMember == null)
              GameCanvas.panel.myMember = new MyVector();
            GameCanvas.panel.myMember.addElement((object) o);
            GameCanvas.panel.initTabClans();
          }
          if (num91 == (sbyte) 1)
          {
            GameCanvas.panel.myMember.removeElementAt((int) msg.reader().readByte());
            --GameCanvas.panel.currentListLength;
            GameCanvas.panel.initTabClans();
          }
          if (num91 == (sbyte) 2)
          {
            Member member = new Member();
            member.ID = msg.reader().readInt();
            member.head = msg.reader().readShort();
            member.headICON = msg.reader().readShort();
            member.leg = msg.reader().readShort();
            member.body = msg.reader().readShort();
            member.name = msg.reader().readUTF();
            member.role = msg.reader().readByte();
            member.powerPoint = msg.reader().readUTF();
            member.donate = msg.reader().readInt();
            member.receive_donate = msg.reader().readInt();
            member.clanPoint = msg.reader().readInt();
            member.joinTime = NinjaUtil.getDate(msg.reader().readInt());
            for (int index32 = 0; index32 < GameCanvas.panel.myMember.size(); ++index32)
            {
              Member o1 = (Member) GameCanvas.panel.myMember.elementAt(index32);
              if (o1.ID == member.ID)
              {
                if (Char.myCharz().charID == member.ID)
                  Char.myCharz().role = member.role;
                Member o2 = member;
                GameCanvas.panel.myMember.removeElement((object) o1);
                GameCanvas.panel.myMember.insertElementAt((object) o2, index32);
                return;
              }
            }
            goto case 41;
          }
          else
            goto case 41;
        case 48:
          InfoDlg.hide();
          this.readClanMsg(msg, 0);
          if (GameCanvas.panel.isMessage && GameCanvas.panel.type == 5)
          {
            GameCanvas.panel.initTabClans();
            goto case 41;
          }
          else
            goto case 41;
        case 49:
          InfoDlg.hide();
          GameCanvas.panel.member = new MyVector();
          sbyte num92 = msg.reader().readByte();
          for (int index33 = 0; index33 < (int) num92; ++index33)
            GameCanvas.panel.member.addElement((object) new Member()
            {
              ID = msg.reader().readInt(),
              head = msg.reader().readShort(),
              headICON = msg.reader().readShort(),
              leg = msg.reader().readShort(),
              body = msg.reader().readShort(),
              name = msg.reader().readUTF(),
              role = msg.reader().readByte(),
              powerPoint = msg.reader().readUTF(),
              donate = msg.reader().readInt(),
              receive_donate = msg.reader().readInt(),
              clanPoint = msg.reader().readInt(),
              joinTime = NinjaUtil.getDate(msg.reader().readInt())
            });
          GameCanvas.panel.isViewMember = true;
          GameCanvas.panel.isSearchClan = false;
          GameCanvas.panel.isMessage = false;
          GameCanvas.panel.currentListLength = GameCanvas.panel.member.size() + 2;
          GameCanvas.panel.initTabClans();
          goto case 41;
        case 52:
          InfoDlg.hide();
          sbyte length14 = msg.reader().readByte();
          Res.outz("clan = " + (object) length14);
          if (length14 == (sbyte) 0)
          {
            GameCanvas.panel.clanReport = mResources.cannot_find_clan;
            GameCanvas.panel.clans = (Clan[]) null;
          }
          else
          {
            GameCanvas.panel.clans = new Clan[(int) length14];
            Res.outz("clan search lent= " + (object) GameCanvas.panel.clans.Length);
            for (int index34 = 0; index34 < GameCanvas.panel.clans.Length; ++index34)
            {
              GameCanvas.panel.clans[index34] = new Clan();
              GameCanvas.panel.clans[index34].ID = msg.reader().readInt();
              GameCanvas.panel.clans[index34].name = msg.reader().readUTF();
              GameCanvas.panel.clans[index34].slogan = msg.reader().readUTF();
              GameCanvas.panel.clans[index34].imgID = (int) msg.reader().readUnsignedByte();
              GameCanvas.panel.clans[index34].powerPoint = msg.reader().readUTF();
              GameCanvas.panel.clans[index34].leaderName = msg.reader().readUTF();
              GameCanvas.panel.clans[index34].currMember = (int) msg.reader().readUnsignedByte();
              GameCanvas.panel.clans[index34].maxMember = (int) msg.reader().readUnsignedByte();
              GameCanvas.panel.clans[index34].date = msg.reader().readInt();
            }
          }
          GameCanvas.panel.isSearchClan = true;
          GameCanvas.panel.isViewMember = false;
          GameCanvas.panel.isMessage = false;
          if (GameCanvas.panel.isSearchClan)
          {
            GameCanvas.panel.initTabClans();
            goto case 41;
          }
          else
            goto case 41;
        case 53:
          InfoDlg.hide();
          sbyte num93 = msg.reader().readByte();
          if (num93 == (sbyte) 1 || num93 == (sbyte) 3)
          {
            GameCanvas.endDlg();
            ClanImage.vClanImage.removeAllElements();
            int num94 = (int) msg.reader().readUnsignedByte();
            for (int index35 = 0; index35 < num94; ++index35)
            {
              ClanImage cm = new ClanImage();
              cm.ID = (int) msg.reader().readUnsignedByte();
              cm.name = msg.reader().readUTF();
              cm.xu = msg.reader().readInt();
              cm.luong = msg.reader().readInt();
              if (!ClanImage.isExistClanImage(cm.ID))
              {
                ClanImage.addClanImage(cm);
              }
              else
              {
                ClanImage.getClanImage((sbyte) cm.ID).name = cm.name;
                ClanImage.getClanImage((sbyte) cm.ID).xu = cm.xu;
                ClanImage.getClanImage((sbyte) cm.ID).luong = cm.luong;
              }
            }
            if (Char.myCharz().clan != null)
              GameCanvas.panel.changeIcon();
          }
          if (num93 == (sbyte) 4)
          {
            Char.myCharz().clan.imgID = (int) msg.reader().readUnsignedByte();
            Char.myCharz().clan.slogan = msg.reader().readUTF();
            goto case 41;
          }
          else
            goto case 41;
        case 54:
          sbyte num95 = msg.reader().readByte();
          int charId9 = msg.reader().readInt();
          short index36 = msg.reader().readShort();
          Res.outz("skill type= " + (object) num95 + "   player use= " + (object) charId9);
          if (num95 == (sbyte) 0)
          {
            Res.outz("id use= " + (object) charId9);
            if (Char.myCharz().charID != charId9)
            {
              Char charInMap3 = GameScr.findCharInMap(charId9);
              if ((TileMap.tileTypeAtPixel(charInMap3.cx, charInMap3.cy) & 2) == 2)
              {
                charInMap3.setSkillPaint(GameScr.sks[(int) index36], 0);
              }
              else
              {
                charInMap3.setSkillPaint(GameScr.sks[(int) index36], 1);
                charInMap3.delayFall = 20;
              }
            }
            else
            {
              Char.myCharz().saveLoadPreviousSkill();
              Res.outz("LOAD LAST SKILL");
            }
            sbyte num96 = msg.reader().readByte();
            Res.outz("npc size= " + (object) num96);
            for (int index37 = 0; index37 < (int) num96; ++index37)
            {
              sbyte index38 = msg.reader().readByte();
              sbyte num97 = msg.reader().readByte();
              Res.outz("index= " + (object) index38);
              if (index36 >= (short) 42 && index36 <= (short) 48)
              {
                ((Mob) GameScr.vMob.elementAt((int) index38)).isFreez = true;
                ((Mob) GameScr.vMob.elementAt((int) index38)).seconds = (int) num97;
                ((Mob) GameScr.vMob.elementAt((int) index38)).last = ((Mob) GameScr.vMob.elementAt((int) index38)).cur = mSystem.currentTimeMillis();
              }
            }
            sbyte num98 = msg.reader().readByte();
            for (int index39 = 0; index39 < (int) num98; ++index39)
            {
              int charId10 = msg.reader().readInt();
              sbyte num99 = msg.reader().readByte();
              Res.outz("player ID= " + (object) charId10 + " my ID= " + (object) Char.myCharz().charID);
              if (index36 >= (short) 42 && index36 <= (short) 48)
              {
                if (charId10 == Char.myCharz().charID)
                {
                  if (!Char.myCharz().isFlyAndCharge && !Char.myCharz().isStandAndCharge)
                  {
                    GameScr.gI().isFreez = true;
                    Char.myCharz().isFreez = true;
                    Char.myCharz().freezSeconds = (int) num99;
                    Char.myCharz().lastFreez = Char.myCharz().currFreez = mSystem.currentTimeMillis();
                    Char.myCharz().isLockMove = true;
                  }
                }
                else
                {
                  Char charInMap4 = GameScr.findCharInMap(charId10);
                  if (charInMap4 != null && !charInMap4.isFlyAndCharge && !charInMap4.isStandAndCharge)
                  {
                    charInMap4.isFreez = true;
                    charInMap4.seconds = (int) num99;
                    charInMap4.freezSeconds = (int) num99;
                    charInMap4.lastFreez = GameScr.findCharInMap(charId10).currFreez = mSystem.currentTimeMillis();
                  }
                }
              }
            }
          }
          if (num95 == (sbyte) 1 && charId9 != Char.myCharz().charID)
            GameScr.findCharInMap(charId9).isCharge = true;
          if (num95 == (sbyte) 3)
          {
            if (charId9 == Char.myCharz().charID)
            {
              Char.myCharz().isCharge = false;
              SoundMn.gI().taitaoPause();
              Char.myCharz().saveLoadPreviousSkill();
            }
            else
              GameScr.findCharInMap(charId9).isCharge = false;
          }
          if (num95 == (sbyte) 4)
          {
            if (charId9 == Char.myCharz().charID)
            {
              Char.myCharz().seconds = (int) msg.reader().readShort() - 1000;
              Char.myCharz().last = mSystem.currentTimeMillis();
              Res.outz("second= " + (object) Char.myCharz().seconds + " last= " + (object) Char.myCharz().last);
            }
            else if (GameScr.findCharInMap(charId9) != null)
            {
              switch (GameScr.findCharInMap(charId9).cgender)
              {
                case 0:
                  GameScr.findCharInMap(charId9).useChargeSkill(false);
                  break;
                case 1:
                  GameScr.findCharInMap(charId9).useChargeSkill(true);
                  break;
              }
              GameScr.findCharInMap(charId9).skillTemplateId = (int) index36;
              GameScr.findCharInMap(charId9).isUseSkillAfterCharge = true;
              GameScr.findCharInMap(charId9).seconds = (int) msg.reader().readShort();
              GameScr.findCharInMap(charId9).last = mSystem.currentTimeMillis();
            }
          }
          if (num95 == (sbyte) 5)
          {
            if (charId9 == Char.myCharz().charID)
              Char.myCharz().stopUseChargeSkill();
            else if (GameScr.findCharInMap(charId9) != null)
              GameScr.findCharInMap(charId9).stopUseChargeSkill();
          }
          if (num95 == (sbyte) 6)
          {
            if (charId9 == Char.myCharz().charID)
              Char.myCharz().setAutoSkillPaint(GameScr.sks[(int) index36], 0);
            else if (GameScr.findCharInMap(charId9) != null)
            {
              GameScr.findCharInMap(charId9).setAutoSkillPaint(GameScr.sks[(int) index36], 0);
              SoundMn.gI().gong();
            }
          }
          if (num95 == (sbyte) 7)
          {
            if (charId9 == Char.myCharz().charID)
            {
              Char.myCharz().seconds = (int) msg.reader().readShort();
              Res.outz("second = " + (object) Char.myCharz().seconds);
              Char.myCharz().last = mSystem.currentTimeMillis();
            }
            else if (GameScr.findCharInMap(charId9) != null)
            {
              GameScr.findCharInMap(charId9).useChargeSkill(true);
              GameScr.findCharInMap(charId9).seconds = (int) msg.reader().readShort();
              GameScr.findCharInMap(charId9).last = mSystem.currentTimeMillis();
              SoundMn.gI().gong();
            }
          }
          if (num95 == (sbyte) 8 && charId9 != Char.myCharz().charID && GameScr.findCharInMap(charId9) != null)
          {
            GameScr.findCharInMap(charId9).setAutoSkillPaint(GameScr.sks[(int) index36], 0);
            goto case 41;
          }
          else
            goto case 41;
        case 55:
          bool flag4 = false;
          if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
            flag4 = true;
          sbyte typeShop = msg.reader().readByte();
          int length15 = (int) msg.reader().readUnsignedByte();
          Char.myCharz().arrItemShop = new Item[length15][];
          GameCanvas.panel.shopTabName = new string[length15 + (flag4 ? 0 : 1)][];
          for (int index40 = 0; index40 < GameCanvas.panel.shopTabName.Length; ++index40)
            GameCanvas.panel.shopTabName[index40] = new string[2];
          if (typeShop == (sbyte) 2)
          {
            GameCanvas.panel.maxPageShop = new int[length15];
            GameCanvas.panel.currPageShop = new int[length15];
          }
          if (!flag4)
            GameCanvas.panel.shopTabName[length15] = mResources.inventory;
          for (int index41 = 0; index41 < length15; ++index41)
          {
            string[] strArray = Res.split(msg.reader().readUTF(), "\n", 0);
            if (typeShop == (sbyte) 2)
              GameCanvas.panel.maxPageShop[index41] = (int) msg.reader().readUnsignedByte();
            if (strArray.Length == 2)
              GameCanvas.panel.shopTabName[index41] = strArray;
            if (strArray.Length == 1)
            {
              GameCanvas.panel.shopTabName[index41][0] = strArray[0];
              GameCanvas.panel.shopTabName[index41][1] = string.Empty;
            }
            int length16 = (int) msg.reader().readUnsignedByte();
            Char.myCharz().arrItemShop[index41] = new Item[length16];
            Panel.strWantToBuy = mResources.say_wat_do_u_want_to_buy;
            if (typeShop == (sbyte) 1)
              Panel.strWantToBuy = mResources.say_wat_do_u_want_to_buy2;
            for (int index42 = 0; index42 < length16; ++index42)
            {
              short id3 = msg.reader().readShort();
              if (id3 != (short) -1)
              {
                Char.myCharz().arrItemShop[index41][index42] = new Item();
                Char.myCharz().arrItemShop[index41][index42].template = ItemTemplates.get(id3);
                Res.outz("name " + (object) index41 + " = " + Char.myCharz().arrItemShop[index41][index42].template.name + " id templat= " + (object) Char.myCharz().arrItemShop[index41][index42].template.id);
                switch (typeShop)
                {
                  case 0:
                    Char.myCharz().arrItemShop[index41][index42].buyCoin = msg.reader().readInt();
                    Char.myCharz().arrItemShop[index41][index42].buyGold = msg.reader().readInt();
                    break;
                  case 1:
                    Char.myCharz().arrItemShop[index41][index42].powerRequire = msg.reader().readLong();
                    break;
                  case 2:
                    Char.myCharz().arrItemShop[index41][index42].itemId = (int) msg.reader().readShort();
                    Char.myCharz().arrItemShop[index41][index42].buyCoin = msg.reader().readInt();
                    Char.myCharz().arrItemShop[index41][index42].buyGold = msg.reader().readInt();
                    Char.myCharz().arrItemShop[index41][index42].buyType = msg.reader().readByte();
                    Char.myCharz().arrItemShop[index41][index42].quantity = msg.reader().readInt();
                    Char.myCharz().arrItemShop[index41][index42].isMe = msg.reader().readByte();
                    break;
                  case 3:
                    Char.myCharz().arrItemShop[index41][index42].isBuySpec = true;
                    Char.myCharz().arrItemShop[index41][index42].iconSpec = msg.reader().readShort();
                    Char.myCharz().arrItemShop[index41][index42].buySpec = msg.reader().readInt();
                    break;
                  case 4:
                    Char.myCharz().arrItemShop[index41][index42].reason = msg.reader().readUTF();
                    break;
                  case 8:
                    Char.myCharz().arrItemShop[index41][index42].buyCoin = msg.reader().readInt();
                    Char.myCharz().arrItemShop[index41][index42].buyGold = msg.reader().readInt();
                    Char.myCharz().arrItemShop[index41][index42].quantity = msg.reader().readInt();
                    break;
                }
                int length17 = (int) msg.reader().readUnsignedByte();
                if (length17 != 0)
                {
                  Char.myCharz().arrItemShop[index41][index42].itemOption = new ItemOption[length17];
                  for (int index43 = 0; index43 < Char.myCharz().arrItemShop[index41][index42].itemOption.Length; ++index43)
                  {
                    int optionTemplateId = (int) msg.reader().readUnsignedByte();
                    int num100 = (int) msg.reader().readUnsignedShort();
                    if (optionTemplateId != -1)
                    {
                      Char.myCharz().arrItemShop[index41][index42].itemOption[index43] = new ItemOption(optionTemplateId, num100);
                      Char.myCharz().arrItemShop[index41][index42].compare = GameCanvas.panel.getCompare(Char.myCharz().arrItemShop[index41][index42]);
                    }
                  }
                }
                sbyte num101 = msg.reader().readByte();
                Char.myCharz().arrItemShop[index41][index42].newItem = num101 != (sbyte) 0;
                if (msg.reader().readByte() == (sbyte) 1)
                {
                  int headTemp = (int) msg.reader().readShort();
                  int bodyTemp = (int) msg.reader().readShort();
                  int legTemp = (int) msg.reader().readShort();
                  int bagTemp = (int) msg.reader().readShort();
                  Char.myCharz().arrItemShop[index41][index42].setPartTemp(headTemp, bodyTemp, legTemp, bagTemp);
                }
              }
            }
          }
          if (flag4)
          {
            if (typeShop != (sbyte) 2)
            {
              GameCanvas.panel2 = new Panel();
              GameCanvas.panel2.tabName[7] = new string[1][]
              {
                new string[1]{ string.Empty }
              };
              GameCanvas.panel2.setTypeBodyOnly();
              GameCanvas.panel2.show();
            }
            else
            {
              GameCanvas.panel2 = new Panel();
              GameCanvas.panel2.setTypeKiGuiOnly();
              GameCanvas.panel2.show();
            }
          }
          GameCanvas.panel.tabName[1] = GameCanvas.panel.shopTabName;
          if (typeShop == (sbyte) 2)
          {
            string[][] strArray = GameCanvas.panel.tabName[1];
            if (flag4)
              GameCanvas.panel.tabName[1] = new string[4][]
              {
                strArray[0],
                strArray[1],
                strArray[2],
                strArray[3]
              };
            else
              GameCanvas.panel.tabName[1] = new string[5][]
              {
                strArray[0],
                strArray[1],
                strArray[2],
                strArray[3],
                strArray[4]
              };
          }
          GameCanvas.panel.setTypeShop((int) typeShop);
          GameCanvas.panel.show();
          goto case 41;
        case 56:
          sbyte itemAction = msg.reader().readByte();
          sbyte where = msg.reader().readByte();
          sbyte index44 = msg.reader().readByte();
          string info2 = msg.reader().readUTF();
          GameCanvas.panel.itemRequest(itemAction, info2, where, index44);
          goto case 41;
        case 57:
          Char.myCharz().cHPGoc = msg.readInt3Byte();
          Char.myCharz().cMPGoc = msg.readInt3Byte();
          Char.myCharz().cDamGoc = msg.reader().readInt();
          Char.myCharz().cHPFull = msg.readInt3Byte();
          Char.myCharz().cMPFull = msg.readInt3Byte();
          Char.myCharz().cHP = msg.readInt3Byte();
          Char.myCharz().cMP = msg.readInt3Byte();
          Char.myCharz().cspeed = (int) msg.reader().readByte();
          Char.myCharz().hpFrom1000TiemNang = msg.reader().readByte();
          Char.myCharz().mpFrom1000TiemNang = msg.reader().readByte();
          Char.myCharz().damFrom1000TiemNang = msg.reader().readByte();
          Char.myCharz().cDamFull = msg.reader().readInt();
          Char.myCharz().cDefull = msg.reader().readInt();
          Char.myCharz().cCriticalFull = (int) msg.reader().readByte();
          Char.myCharz().cTiemNang = msg.reader().readLong();
          Char.myCharz().expForOneAdd = msg.reader().readShort();
          Char.myCharz().cDefGoc = (int) msg.reader().readShort();
          Char.myCharz().cCriticalGoc = (int) msg.reader().readByte();
          InfoDlg.hide();
          goto case 41;
        case 58:
          sbyte length18 = msg.reader().readByte();
          Char.myCharz().strLevel = new string[(int) length18];
          for (int index45 = 0; index45 < (int) length18; ++index45)
          {
            string str4 = msg.reader().readUTF();
            Char.myCharz().strLevel[index45] = str4;
          }
          Res.outz("---   xong  level caption cmd : " + (object) msg.command);
          goto case 41;
        case 62:
          sbyte num102 = msg.reader().readByte();
          Res.outz("cAction= " + (object) num102);
          if (num102 == (sbyte) 0)
          {
            Char.myCharz().head = (int) msg.reader().readShort();
            Char.myCharz().setDefaultPart();
            int length19 = (int) msg.reader().readUnsignedByte();
            Res.outz("num body = " + (object) length19);
            Char.myCharz().arrItemBody = new Item[length19];
            for (int index46 = 0; index46 < length19; ++index46)
            {
              short id4 = msg.reader().readShort();
              if (id4 != (short) -1)
              {
                Char.myCharz().arrItemBody[index46] = new Item();
                Char.myCharz().arrItemBody[index46].template = ItemTemplates.get(id4);
                int type = (int) Char.myCharz().arrItemBody[index46].template.type;
                Char.myCharz().arrItemBody[index46].quantity = msg.reader().readInt();
                Char.myCharz().arrItemBody[index46].info = msg.reader().readUTF();
                Char.myCharz().arrItemBody[index46].content = msg.reader().readUTF();
                int length20 = (int) msg.reader().readUnsignedByte();
                if (length20 != 0)
                {
                  Char.myCharz().arrItemBody[index46].itemOption = new ItemOption[length20];
                  for (int index47 = 0; index47 < Char.myCharz().arrItemBody[index46].itemOption.Length; ++index47)
                  {
                    int optionTemplateId = (int) msg.reader().readUnsignedByte();
                    int num103 = (int) msg.reader().readUnsignedShort();
                    if (optionTemplateId != -1)
                      Char.myCharz().arrItemBody[index46].itemOption[index47] = new ItemOption(optionTemplateId, num103);
                  }
                }
                switch (type)
                {
                  case 0:
                    Char.myCharz().body = (int) Char.myCharz().arrItemBody[index46].template.part;
                    continue;
                  case 1:
                    Char.myCharz().leg = (int) Char.myCharz().arrItemBody[index46].template.part;
                    continue;
                  default:
                    continue;
                }
              }
            }
            goto case 41;
          }
          else
            goto case 41;
        case 63:
          sbyte num104 = msg.reader().readByte();
          Res.outz("cAction= " + (object) num104);
          if (num104 == (sbyte) 0)
          {
            int length21 = (int) msg.reader().readUnsignedByte();
            Char.myCharz().arrItemBag = new Item[length21];
            GameScr.hpPotion = 0;
            Res.outz("numC=" + (object) length21);
            for (int index48 = 0; index48 < length21; ++index48)
            {
              short id5 = msg.reader().readShort();
              if (id5 != (short) -1)
              {
                Char.myCharz().arrItemBag[index48] = new Item();
                Char.myCharz().arrItemBag[index48].template = ItemTemplates.get(id5);
                Char.myCharz().arrItemBag[index48].quantity = msg.reader().readInt();
                Char.myCharz().arrItemBag[index48].info = msg.reader().readUTF();
                Char.myCharz().arrItemBag[index48].content = msg.reader().readUTF();
                Char.myCharz().arrItemBag[index48].indexUI = index48;
                int length22 = (int) msg.reader().readUnsignedByte();
                if (length22 != 0)
                {
                  Char.myCharz().arrItemBag[index48].itemOption = new ItemOption[length22];
                  for (int index49 = 0; index49 < Char.myCharz().arrItemBag[index48].itemOption.Length; ++index49)
                  {
                    int optionTemplateId = (int) msg.reader().readUnsignedByte();
                    int num105 = (int) msg.reader().readUnsignedShort();
                    if (optionTemplateId != -1)
                      Char.myCharz().arrItemBag[index48].itemOption[index49] = new ItemOption(optionTemplateId, num105);
                  }
                  Char.myCharz().arrItemBag[index48].compare = GameCanvas.panel.getCompare(Char.myCharz().arrItemBag[index48]);
                }
                if (Char.myCharz().arrItemBag[index48].template.type != (sbyte) 11)
                  ;
                if (Char.myCharz().arrItemBag[index48].template.type == (sbyte) 6)
                  GameScr.hpPotion += Char.myCharz().arrItemBag[index48].quantity;
              }
            }
          }
          if (num104 == (sbyte) 2)
          {
            sbyte index50 = msg.reader().readByte();
            int num106 = msg.reader().readInt();
            int quantity = Char.myCharz().arrItemBag[(int) index50].quantity;
            Char.myCharz().arrItemBag[(int) index50].quantity = num106;
            if (Char.myCharz().arrItemBag[(int) index50].quantity < quantity && Char.myCharz().arrItemBag[(int) index50].template.type == (sbyte) 6)
              GameScr.hpPotion -= quantity - Char.myCharz().arrItemBag[(int) index50].quantity;
            if (Char.myCharz().arrItemBag[(int) index50].quantity == 0)
            {
              Char.myCharz().arrItemBag[(int) index50] = (Item) null;
              goto case 41;
            }
            else
              goto case 41;
          }
          else
            goto case 41;
        case 64:
          sbyte num107 = msg.reader().readByte();
          Res.outz("cAction= " + (object) num107);
          if (num107 == (sbyte) 0)
          {
            int length23 = (int) msg.reader().readUnsignedByte();
            Char.myCharz().arrItemBox = new Item[length23];
            GameCanvas.panel.hasUse = 0;
            for (int index51 = 0; index51 < length23; ++index51)
            {
              short id6 = msg.reader().readShort();
              if (id6 != (short) -1)
              {
                Char.myCharz().arrItemBox[index51] = new Item();
                Char.myCharz().arrItemBox[index51].template = ItemTemplates.get(id6);
                Char.myCharz().arrItemBox[index51].quantity = msg.reader().readInt();
                Char.myCharz().arrItemBox[index51].info = msg.reader().readUTF();
                Char.myCharz().arrItemBox[index51].content = msg.reader().readUTF();
                int length24 = (int) msg.reader().readUnsignedByte();
                if (length24 != 0)
                {
                  Char.myCharz().arrItemBox[index51].itemOption = new ItemOption[length24];
                  for (int index52 = 0; index52 < Char.myCharz().arrItemBox[index51].itemOption.Length; ++index52)
                  {
                    int optionTemplateId = (int) msg.reader().readUnsignedByte();
                    int num108 = (int) msg.reader().readUnsignedShort();
                    if (optionTemplateId != -1)
                      Char.myCharz().arrItemBox[index51].itemOption[index52] = new ItemOption(optionTemplateId, num108);
                  }
                }
                ++GameCanvas.panel.hasUse;
              }
            }
          }
          if (num107 == (sbyte) 1)
          {
            bool flag5 = false;
            try
            {
              if (msg.reader().readByte() == (sbyte) 1)
                flag5 = true;
            }
            catch (Exception ex)
            {
            }
            GameCanvas.panel.setTypeBox();
            GameCanvas.panel.isBoxClan = flag5;
            GameCanvas.panel.show();
          }
          if (num107 == (sbyte) 2)
          {
            sbyte index53 = msg.reader().readByte();
            int num109 = msg.reader().readInt();
            Char.myCharz().arrItemBox[(int) index53].quantity = num109;
            if (Char.myCharz().arrItemBox[(int) index53].quantity == 0)
            {
              Char.myCharz().arrItemBox[(int) index53] = (Item) null;
              goto case 41;
            }
            else
              goto case 41;
          }
          else
            goto case 41;
        case 65:
          sbyte num110 = msg.reader().readByte();
          Res.outz("act= " + (object) num110);
          if (num110 == (sbyte) 0 && GameScr.gI().magicTree != null)
          {
            Res.outz("toi duoc day");
            MagicTree magicTree = GameScr.gI().magicTree;
            magicTree.id = (int) msg.reader().readShort();
            magicTree.name = msg.reader().readUTF();
            magicTree.name = Res.changeString(magicTree.name);
            magicTree.x = (int) msg.reader().readShort();
            magicTree.y = (int) msg.reader().readShort();
            magicTree.level = (int) msg.reader().readByte();
            magicTree.currPeas = (int) msg.reader().readShort();
            magicTree.maxPeas = (int) msg.reader().readShort();
            Res.outz("curr Peas= " + (object) magicTree.currPeas);
            magicTree.strInfo = msg.reader().readUTF();
            magicTree.seconds = msg.reader().readInt();
            magicTree.timeToRecieve = magicTree.seconds;
            sbyte length25 = msg.reader().readByte();
            magicTree.peaPostionX = new int[(int) length25];
            magicTree.peaPostionY = new int[(int) length25];
            for (int index54 = 0; index54 < (int) length25; ++index54)
            {
              magicTree.peaPostionX[index54] = (int) msg.reader().readByte();
              magicTree.peaPostionY[index54] = (int) msg.reader().readByte();
            }
            magicTree.isUpdate = msg.reader().readBool();
            magicTree.last = magicTree.cur = mSystem.currentTimeMillis();
            GameScr.gI().magicTree.isUpdateTree = true;
          }
          if (num110 == (sbyte) 1)
          {
            MyVector menuItems = new MyVector();
            try
            {
              while (msg.reader().available() > 0)
              {
                string caption = msg.reader().readUTF();
                menuItems.addElement((object) new Command(caption, (IActionListener) GameCanvas.instance, 888392, (object) null));
              }
            }
            catch (Exception ex)
            {
              Cout.println("Loi MAGIC_TREE " + ex.ToString());
            }
            GameCanvas.menu.startAt(menuItems, 3);
          }
          if (num110 == (sbyte) 2)
          {
            GameScr.gI().magicTree.remainPeas = (int) msg.reader().readShort();
            GameScr.gI().magicTree.seconds = msg.reader().readInt();
            GameScr.gI().magicTree.last = GameScr.gI().magicTree.cur = mSystem.currentTimeMillis();
            GameScr.gI().magicTree.isUpdateTree = true;
            GameScr.gI().magicTree.isPeasEffect = true;
            goto case 41;
          }
          else
            goto case 41;
        case 67:
          short id7 = msg.reader().readShort();
          int lenght1 = msg.reader().readInt();
          Image image1 = (Image) null;
          sbyte[] numArray2;
          try
          {
            numArray2 = new sbyte[lenght1];
            for (int index55 = 0; index55 < lenght1; ++index55)
              numArray2[index55] = msg.reader().readByte();
            image1 = Image.createImage(numArray2, 0, lenght1);
            BgItem.imgNew.put((object) (id7.ToString() + string.Empty), (object) image1);
          }
          catch (Exception ex)
          {
            numArray2 = (sbyte[]) null;
            BgItem.imgNew.put((object) (id7.ToString() + string.Empty), (object) Image.createRGBImage(new int[1], 1, 1, true));
          }
          if (numArray2 != null)
          {
            if (mGraphics.zoomLevel > 1)
              Rms.saveRMS(mGraphics.zoomLevel.ToString() + "bgItem" + (object) id7, numArray2);
            BgItemMn.blendcurrBg(id7, image1);
            goto case 41;
          }
          else
            goto case 41;
        case 68:
          TileMap.vItemBg.removeAllElements();
          short num111 = msg.reader().readShort();
          Cout.LogError2("nItem= " + (object) num111);
          for (int index56 = 0; index56 < (int) num111; ++index56)
          {
            BgItem o = new BgItem();
            o.id = index56;
            o.idImage = msg.reader().readShort();
            o.layer = msg.reader().readByte();
            o.dx = (int) msg.reader().readShort();
            o.dy = (int) msg.reader().readShort();
            sbyte length26 = msg.reader().readByte();
            o.tileX = new int[(int) length26];
            o.tileY = new int[(int) length26];
            for (int index57 = 0; index57 < (int) length26; ++index57)
            {
              o.tileX[index56] = (int) msg.reader().readByte();
              o.tileY[index56] = (int) msg.reader().readByte();
            }
            TileMap.vItemBg.addElement((object) o);
          }
          goto case 41;
        case 69:
          this.messageSubCommand(msg);
          goto case 41;
        case 70:
          this.messageNotLogin(msg);
          goto case 41;
        case 71:
          this.messageNotMap(msg);
          goto case 41;
        case 73:
          ServerListScreen.testConnect = 2;
          GameCanvas.debug("SA2", 2);
          GameCanvas.startOKDlg(msg.reader().readUTF());
          InfoDlg.hide();
          LoginScr.isContinueToLogin = false;
          Char.isLoadingMap = false;
          if (GameCanvas.currentScreen == GameCanvas.loginScr)
          {
            GameCanvas.serverScreen.switchToMe();
            goto case 41;
          }
          else
            goto case 41;
        case 74:
          GameCanvas.debug("SA3", 2);
          GameScr.info1.addInfo(msg.reader().readUTF(), 0);
          goto case 41;
        case 75:
          Char.isLoadingMap = true;
          Cout.println("GET MAP INFO");
          GameScr.gI().magicTree = (MagicTree) null;
          GameCanvas.isLoading = true;
          GameCanvas.debug("SA75", 2);
          GameScr.resetAllvector();
          GameCanvas.endDlg();
          TileMap.vGo.removeAllElements();
          PopUp.vPopups.removeAllElements();
          mSystem.gcc();
          TileMap.mapID = (int) msg.reader().readUnsignedByte();
          TileMap.planetID = msg.reader().readByte();
          TileMap.tileID = (int) msg.reader().readByte();
          TileMap.bgID = (int) msg.reader().readByte();
          Cout.println("load planet from server: " + (object) TileMap.planetID + "bgType= " + (object) TileMap.bgType + ".............................");
          TileMap.typeMap = (int) msg.reader().readByte();
          TileMap.mapName = msg.reader().readUTF();
          TileMap.zoneID = (int) msg.reader().readByte();
          GameCanvas.debug("SA75x1", 2);
          try
          {
            TileMap.loadMapFromResource(TileMap.mapID);
          }
          catch (Exception ex)
          {
            Service.gI().requestMaptemplate(TileMap.mapID);
            this.messWait = msg;
            break;
          }
          this.loadInfoMap(msg);
          try
          {
            TileMap.isMapDouble = msg.reader().readByte() != (sbyte) 0;
          }
          catch (Exception ex)
          {
          }
          GameScr.cmx = GameScr.cmtoX;
          GameScr.cmy = GameScr.cmtoY;
          goto case 41;
        case 77:
          GameCanvas.debug("SA65", 2);
          Char.isLockKey = true;
          Char.ischangingMap = true;
          GameScr.gI().timeStartMap = 0;
          GameScr.gI().timeLengthMap = 0;
          Char.myCharz().mobFocus = (Mob) null;
          Char.myCharz().npcFocus = (Npc) null;
          Char.myCharz().charFocus = (Char) null;
          Char.myCharz().itemFocus = (ItemMap) null;
          Char.myCharz().focus.removeAllElements();
          Char.myCharz().testCharId = -9999;
          Char.myCharz().killCharId = -9999;
          GameCanvas.resetBg();
          GameScr.gI().resetButton();
          GameScr.gI().center = (Command) null;
          goto case 41;
        case 78:
          GameCanvas.debug("SA60", 2);
          short num112 = msg.reader().readShort();
          for (int index58 = 0; index58 < GameScr.vItemMap.size(); ++index58)
          {
            if (((ItemMap) GameScr.vItemMap.elementAt(index58)).itemMapID == (int) num112)
            {
              GameScr.vItemMap.removeElementAt(index58);
              break;
            }
          }
          goto case 41;
        case 79:
          GameCanvas.debug("SA61", 2);
          Char.myCharz().itemFocus = (ItemMap) null;
          short num113 = msg.reader().readShort();
          for (int index59 = 0; index59 < GameScr.vItemMap.size(); ++index59)
          {
            ItemMap itemMap = (ItemMap) GameScr.vItemMap.elementAt(index59);
            if (itemMap.itemMapID == (int) num113)
            {
              itemMap.setPoint(Char.myCharz().cx, Char.myCharz().cy - 10);
              string s = msg.reader().readUTF();
              int num114 = 0;
              try
              {
                num114 = (int) msg.reader().readShort();
                if (itemMap.template.type == (sbyte) 9)
                {
                  num114 = (int) msg.reader().readShort();
                  Char.myCharz().xu += (long) num114;
                  Char.myCharz().xuStr = mSystem.numberTostring(Char.myCharz().xu);
                }
                else if (itemMap.template.type == (sbyte) 10)
                {
                  num114 = (int) msg.reader().readShort();
                  Char.myCharz().luong += num114;
                  Char.myCharz().luongStr = mSystem.numberTostring((long) Char.myCharz().luong);
                }
                else if (itemMap.template.type == (sbyte) 34)
                {
                  num114 = (int) msg.reader().readShort();
                  Char.myCharz().luongKhoa += num114;
                  Char.myCharz().luongKhoaStr = mSystem.numberTostring((long) Char.myCharz().luongKhoa);
                }
              }
              catch (Exception ex)
              {
              }
              if (s.Equals(string.Empty))
              {
                if (itemMap.template.type == (sbyte) 9)
                {
                  GameScr.startFlyText((num114 >= 0 ? (object) "+" : (object) string.Empty).ToString() + (object) num114, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch, 0, -2, mFont.YELLOW);
                  SoundMn.gI().getItem();
                }
                else if (itemMap.template.type == (sbyte) 10)
                {
                  GameScr.startFlyText((num114 >= 0 ? (object) "+" : (object) string.Empty).ToString() + (object) num114, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch, 0, -2, mFont.GREEN);
                  SoundMn.gI().getItem();
                }
                else if (itemMap.template.type == (sbyte) 34)
                {
                  GameScr.startFlyText((num114 >= 0 ? (object) "+" : (object) string.Empty).ToString() + (object) num114, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch, 0, -2, mFont.RED);
                  SoundMn.gI().getItem();
                }
                else
                {
                  GameScr.info1.addInfo(mResources.you_receive + " " + (num114 <= 0 ? string.Empty : num114.ToString() + " ") + itemMap.template.name, 0);
                  SoundMn.gI().getItem();
                }
                if (num114 > 0 && Char.myCharz().petFollow != null && Char.myCharz().petFollow.smallID == (short) 4683)
                {
                  ServerEffect.addServerEffect(55, Char.myCharz().petFollow.cmx, Char.myCharz().petFollow.cmy, 1);
                  ServerEffect.addServerEffect(55, Char.myCharz().cx, Char.myCharz().cy, 1);
                  break;
                }
                break;
              }
              if (s.Length == 1)
              {
                Cout.LogError3("strInf.Length =1:  " + s);
                break;
              }
              GameScr.info1.addInfo(s, 0);
              break;
            }
          }
          goto case 41;
        case 80:
          GameCanvas.debug("SA62", 2);
          short num115 = msg.reader().readShort();
          Char charInMap5 = GameScr.findCharInMap(msg.reader().readInt());
          for (int index60 = 0; index60 < GameScr.vItemMap.size(); ++index60)
          {
            ItemMap itemMap = (ItemMap) GameScr.vItemMap.elementAt(index60);
            if (itemMap.itemMapID == (int) num115)
            {
              if (charInMap5 == null)
                return;
              itemMap.setPoint(charInMap5.cx, charInMap5.cy - 10);
              if (itemMap.x < charInMap5.cx)
              {
                charInMap5.cdir = -1;
                break;
              }
              if (itemMap.x > charInMap5.cx)
              {
                charInMap5.cdir = 1;
                break;
              }
              break;
            }
          }
          goto case 41;
        case 81:
          GameCanvas.debug("SA63", 2);
          int index61 = (int) msg.reader().readByte();
          GameScr.vItemMap.addElement((object) new ItemMap(msg.reader().readShort(), Char.myCharz().arrItemBag[index61].template.id, Char.myCharz().cx, Char.myCharz().cy, (int) msg.reader().readShort(), (int) msg.reader().readShort()));
          Char.myCharz().arrItemBag[index61] = (Item) null;
          goto case 41;
        case 85:
          GameCanvas.debug("SA64", 2);
          Char charInMap6 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap6 == null)
            break;
          GameScr.vItemMap.addElement((object) new ItemMap(msg.reader().readShort(), msg.reader().readShort(), charInMap6.cx, charInMap6.cy, (int) msg.reader().readShort(), (int) msg.reader().readShort()));
          goto case 41;
        case 95:
          GameCanvas.debug("SA76", 2);
          Char charInMap7 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap7 == null)
            break;
          GameCanvas.debug("SA76v1", 2);
          if ((TileMap.tileTypeAtPixel(charInMap7.cx, charInMap7.cy) & 2) == 2)
            charInMap7.setSkillPaint(GameScr.sks[(int) msg.reader().readUnsignedByte()], 0);
          else
            charInMap7.setSkillPaint(GameScr.sks[(int) msg.reader().readUnsignedByte()], 1);
          GameCanvas.debug("SA76v2", 2);
          charInMap7.attMobs = new Mob[(int) msg.reader().readByte()];
          for (int index62 = 0; index62 < charInMap7.attMobs.Length; ++index62)
          {
            Mob mob11 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readByte());
            charInMap7.attMobs[index62] = mob11;
            if (index62 == 0)
              charInMap7.cdir = charInMap7.cx > mob11.x ? -1 : 1;
          }
          GameCanvas.debug("SA76v3", 2);
          charInMap7.charFocus = (Char) null;
          charInMap7.mobFocus = charInMap7.attMobs[0];
          Char[] charArray1 = new Char[10];
          int length27 = 0;
          try
          {
            for (length27 = 0; length27 < charArray1.Length; ++length27)
            {
              int charId11 = msg.reader().readInt();
              Char char12 = charId11 != Char.myCharz().charID ? GameScr.findCharInMap(charId11) : Char.myCharz();
              charArray1[length27] = char12;
              if (length27 == 0)
                charInMap7.cdir = charInMap7.cx > char12.cx ? -1 : 1;
            }
          }
          catch (Exception ex)
          {
            Cout.println("Loi PLAYER_ATTACK_N_P " + ex.ToString());
          }
          GameCanvas.debug("SA76v4", 2);
          if (length27 > 0)
          {
            charInMap7.attChars = new Char[length27];
            for (int index63 = 0; index63 < charInMap7.attChars.Length; ++index63)
              charInMap7.attChars[index63] = charArray1[index63];
            charInMap7.charFocus = charInMap7.attChars[0];
            charInMap7.mobFocus = (Mob) null;
          }
          GameCanvas.debug("SA76v5", 2);
          goto case 41;
        case 100:
          bool flag6 = msg.reader().readBool();
          Res.outz("isRes= " + (object) flag6);
          if (!flag6)
          {
            GameCanvas.startOKDlg(msg.reader().readUTF());
            goto case 41;
          }
          else
          {
            GameCanvas.loginScr.isLogin2 = false;
            Rms.saveRMSString("userAo" + (object) ServerListScreen.ipSelect, string.Empty);
            GameCanvas.endDlg();
            GameCanvas.loginScr.doLogin();
            goto case 41;
          }
        case 101:
          Char.isLoadingMap = true;
          LoginScr.isLoggingIn = false;
          if (!GameScr.isLoadAllData)
            GameScr.gI().initSelectChar();
          BgItem.clearHashTable();
          GameCanvas.endDlg();
          CreateCharScr.isCreateChar = true;
          CreateCharScr.gI().switchToMe();
          goto case 41;
        case 105:
          GameCanvas.debug("SA70", 2);
          Char.myCharz().xu = msg.reader().readLong();
          Char.myCharz().luong = msg.reader().readInt();
          Char.myCharz().luongKhoa = msg.reader().readInt();
          Char.myCharz().xuStr = mSystem.numberTostring(Char.myCharz().xu);
          Char.myCharz().luongStr = mSystem.numberTostring((long) Char.myCharz().luong);
          Char.myCharz().luongKhoaStr = mSystem.numberTostring((long) Char.myCharz().luongKhoa);
          GameCanvas.endDlg();
          goto case 41;
        case 106:
          sbyte type1 = msg.reader().readByte();
          short id8 = msg.reader().readShort();
          string info3 = msg.reader().readUTF();
          GameCanvas.panel.saleRequest(type1, info3, id8);
          goto case 41;
        case 110:
          GameCanvas.debug("SA9", 2);
          int mobTemplateId = (int) msg.reader().readByte();
          sbyte typeread2 = msg.reader().readByte();
          if (typeread2 != (sbyte) 0)
            Mob.arrMobTemplate[mobTemplateId].data.readDataNewBoss(NinjaUtil.readByteArray(msg), typeread2);
          else
            Mob.arrMobTemplate[mobTemplateId].data.readData(NinjaUtil.readByteArray(msg));
          for (int index64 = 0; index64 < GameScr.vMob.size(); ++index64)
          {
            Mob mob12 = (Mob) GameScr.vMob.elementAt(index64);
            if (mob12.templateId == mobTemplateId)
            {
              mob12.w = Mob.arrMobTemplate[mobTemplateId].data.width;
              mob12.h = Mob.arrMobTemplate[mobTemplateId].data.height;
            }
          }
          sbyte[] imageData2 = NinjaUtil.readByteArray(msg);
          Image image2 = Image.createImage(imageData2, 0, imageData2.Length);
          Mob.arrMobTemplate[mobTemplateId].data.img = image2;
          int num116 = (int) msg.reader().readByte();
          Mob.arrMobTemplate[mobTemplateId].data.typeData = num116;
          if (num116 == 1 || num116 == 2)
          {
            this.readFrameBoss(msg, mobTemplateId);
            goto case 41;
          }
          else
            goto case 41;
        case 119:
          this.phuban_Info(msg);
          goto case 41;
        case 123:
          this.read_opt(msg);
          goto case 41;
        case 126:
          MyVector menuItems1 = new MyVector();
          msg.reader().readUTF();
          int num117 = (int) msg.reader().readByte();
          for (int index65 = 0; index65 < num117; ++index65)
          {
            string caption = msg.reader().readUTF();
            short p = msg.reader().readShort();
            menuItems1.addElement((object) new Command(caption, (IActionListener) GameCanvas.instance, 88819, (object) p));
          }
          GameCanvas.menu.startWithoutCloseButton(menuItems1, 3);
          goto case 41;
        case 128:
          GameCanvas.debug("SA58", 2);
          GameScr.gI().openUIZone(msg);
          goto case 41;
        case 131:
          GameCanvas.debug("SA68", 2);
          int num118 = (int) msg.reader().readShort();
          for (int index66 = 0; index66 < GameScr.vNpc.size(); ++index66)
          {
            Npc npc = (Npc) GameScr.vNpc.elementAt(index66);
            if (npc.template.npcTemplateId == num118 && npc.Equals((object) Char.myCharz().npcFocus))
            {
              string chat2 = msg.reader().readUTF();
              string[] menu = new string[(int) msg.reader().readByte()];
              for (int index67 = 0; index67 < menu.Length; ++index67)
                menu[index67] = msg.reader().readUTF();
              GameScr.gI().createMenu(menu, npc);
              ChatPopup.addChatPopup(chat2, 100000, npc);
              return;
            }
          }
          Npc npc1 = new Npc(num118, 0, -100, 100, num118, GameScr.info1.charId[Char.myCharz().cgender][2]);
          Res.outz(Char.myCharz().npcFocus == null ? "null" : "!null");
          string chat3 = msg.reader().readUTF();
          string[] menu1 = new string[(int) msg.reader().readByte()];
          for (int index68 = 0; index68 < menu1.Length; ++index68)
            menu1[index68] = msg.reader().readUTF();
          try
          {
            short num119 = msg.reader().readShort();
            npc1.avatar = (int) num119;
          }
          catch (Exception ex)
          {
          }
          Res.outz(Char.myCharz().npcFocus == null ? "null" : "!null");
          GameScr.gI().createMenu(menu1, npc1);
          ChatPopup.addChatPopup(chat3, 100000, npc1);
          goto case 41;
        case 132:
          GameCanvas.debug("SA51", 2);
          InfoDlg.hide();
          GameCanvas.clearKeyHold();
          GameCanvas.clearKeyPressed();
          MyVector menuItems2 = new MyVector();
          try
          {
            while (true)
            {
              string caption = msg.reader().readUTF();
              menuItems2.addElement((object) new Command(caption, (IActionListener) GameCanvas.instance, 88822, (object) null));
            }
          }
          catch (Exception ex)
          {
            Cout.println("Loi OPEN_UI_MENU " + ex.ToString());
          }
          if (Char.myCharz().npcFocus == null)
            break;
          for (int index69 = 0; index69 < Char.myCharz().npcFocus.template.menu.Length; ++index69)
          {
            string[] p = Char.myCharz().npcFocus.template.menu[index69];
            menuItems2.addElement((object) new Command(p[0], (IActionListener) GameCanvas.instance, 88820, (object) p));
          }
          GameCanvas.menu.startAt(menuItems2, 3);
          goto case 41;
        case 137:
          GameCanvas.debug("SA67", 2);
          InfoDlg.hide();
          int num120 = (int) msg.reader().readShort();
          Res.outz("OPEN_UI_SAY ID= " + (object) num120);
          string chat4 = Res.changeString(msg.reader().readUTF());
          for (int index70 = 0; index70 < GameScr.vNpc.size(); ++index70)
          {
            Npc c2 = (Npc) GameScr.vNpc.elementAt(index70);
            Res.outz("npc id= " + (object) c2.template.npcTemplateId);
            if (c2.template.npcTemplateId == num120)
            {
              ChatPopup.addChatPopupMultiLine(chat4, 100000, c2);
              GameCanvas.panel.hideNow();
              return;
            }
          }
          Npc c3 = new Npc(num120, 0, 0, 0, num120, GameScr.info1.charId[Char.myCharz().cgender][2]);
          if (c3.template.npcTemplateId == 5)
            c3.charID = 5;
          try
          {
            c3.avatar = (int) msg.reader().readShort();
          }
          catch (Exception ex)
          {
          }
          ChatPopup.addChatPopupMultiLine(chat4, 100000, c3);
          GameCanvas.panel.hideNow();
          goto case 41;
        case 138:
          GameCanvas.debug("SA49", 2);
          GameScr.gI().typeTradeOrder = 2;
          if (GameScr.gI().typeTrade >= 2 && GameScr.gI().typeTradeOrder >= 2)
          {
            InfoDlg.showWait();
            goto case 41;
          }
          else
            goto case 41;
        case 139:
          GameCanvas.debug("SA52", 2);
          GameCanvas.taskTick = 150;
          short taskId = msg.reader().readShort();
          sbyte index71 = msg.reader().readByte();
          string name = Res.changeString(msg.reader().readUTF());
          string detail = Res.changeString(msg.reader().readUTF());
          string[] subNames = new string[(int) msg.reader().readByte()];
          string[] contentInfo = new string[subNames.Length];
          GameScr.tasks = new int[subNames.Length];
          GameScr.mapTasks = new int[subNames.Length];
          short[] counts = new short[subNames.Length];
          short count = -1;
          for (int index72 = 0; index72 < subNames.Length; ++index72)
          {
            string str5 = Res.changeString(msg.reader().readUTF());
            GameScr.tasks[index72] = (int) msg.reader().readByte();
            GameScr.mapTasks[index72] = (int) msg.reader().readShort();
            string str6 = Res.changeString(msg.reader().readUTF());
            counts[index72] = (short) -1;
            if (!str5.Equals(string.Empty))
            {
              subNames[index72] = str5;
              contentInfo[index72] = str6;
            }
          }
          try
          {
            count = msg.reader().readShort();
            for (int index73 = 0; index73 < subNames.Length; ++index73)
              counts[index73] = msg.reader().readShort();
          }
          catch (Exception ex)
          {
            Cout.println("Loi TASK_GET " + ex.ToString());
          }
          Char.myCharz().taskMaint = new Task(taskId, index71, name, detail, subNames, counts, count, contentInfo);
          if (Char.myCharz().npcFocus != null)
            Npc.clearEffTask();
          Char.taskAction(false);
          goto case 41;
        case 140:
          GameCanvas.debug("SA53", 2);
          GameCanvas.taskTick = 100;
          Res.outz("TASK NEXT");
          ++Char.myCharz().taskMaint.index;
          Char.myCharz().taskMaint.count = (short) 0;
          Npc.clearEffTask();
          Char.taskAction(true);
          goto case 41;
        case 142:
          GameCanvas.taskTick = 50;
          GameCanvas.debug("SA55", 2);
          Char.myCharz().taskMaint.count = msg.reader().readShort();
          if (Char.myCharz().npcFocus != null)
          {
            Npc.clearEffTask();
            goto case 41;
          }
          else
            goto case 41;
        case 145:
          GameCanvas.debug("SA5", 2);
          Cout.LogWarning("Controler RESET_POINT  " + (object) Char.ischangingMap);
          Char.isLockKey = false;
          Char.myCharz().setResetPoint((int) msg.reader().readShort(), (int) msg.reader().readShort());
          goto case 41;
        case 146:
          GameCanvas.debug("SA4", 2);
          GameScr.gI().resetButton();
          goto case 41;
        case 149:
          sbyte num121 = msg.reader().readByte();
          Panel.vGameInfo.removeAllElements();
          for (int index74 = 0; index74 < (int) num121; ++index74)
          {
            GameInfo o = new GameInfo();
            o.id = msg.reader().readShort();
            o.main = msg.reader().readUTF();
            o.content = msg.reader().readUTF();
            Panel.vGameInfo.addElement((object) o);
            bool flag7 = Rms.loadRMSInt(o.id.ToString() + string.Empty) != -1;
            o.hasRead = flag7;
          }
          goto case 41;
        case 153:
          Char charInMap8 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap8 == null)
            break;
          int index75 = (int) msg.reader().readUnsignedByte();
          if ((TileMap.tileTypeAtPixel(charInMap8.cx, charInMap8.cy) & 2) == 2)
            charInMap8.setSkillPaint(GameScr.sks[index75], 0);
          else
            charInMap8.setSkillPaint(GameScr.sks[index75], 1);
          GameCanvas.debug("SA769991v2", 2);
          Mob[] mobArray = new Mob[10];
          int length28 = 0;
          try
          {
            GameCanvas.debug("SA769991v3", 2);
            for (length28 = 0; length28 < mobArray.Length; ++length28)
            {
              GameCanvas.debug("SA769991v4-num" + (object) length28, 2);
              Mob mob13 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readByte());
              mobArray[length28] = mob13;
              if (length28 == 0)
                charInMap8.cdir = charInMap8.cx > mob13.x ? -1 : 1;
              GameCanvas.debug("SA769991v5-num" + (object) length28, 2);
            }
          }
          catch (Exception ex)
          {
            Cout.println("Loi PLAYER_ATTACK_NPC " + ex.ToString());
          }
          GameCanvas.debug("SA769992", 2);
          if (length28 > 0)
          {
            charInMap8.attMobs = new Mob[length28];
            for (int index76 = 0; index76 < charInMap8.attMobs.Length; ++index76)
              charInMap8.attMobs[index76] = mobArray[index76];
            charInMap8.charFocus = (Char) null;
            charInMap8.mobFocus = charInMap8.attMobs[0];
            goto case 41;
          }
          else
            goto case 41;
        case 155:
          GameCanvas.debug("SXX6", 2);
          char1 = (Char) null;
          int charId12 = msg.reader().readInt();
          if (charId12 == Char.myCharz().charID)
          {
            bool flag8 = false;
            Char char13 = Char.myCharz();
            char13.cHP = msg.readInt3Byte();
            int num122 = msg.readInt3Byte();
            Res.outz("dame hit = " + (object) num122);
            if (num122 != 0)
              char13.doInjure();
            int num123 = 0;
            try
            {
              flag8 = msg.reader().readBoolean();
              sbyte id9 = msg.reader().readByte();
              if (id9 != (sbyte) -1)
              {
                Res.outz("hit eff= " + (object) id9);
                EffecMn.addEff(new Effect((int) id9, char13.cx, char13.cy, 3, 1, -1));
              }
            }
            catch (Exception ex)
            {
            }
            int num124 = num122 + num123;
            if (Char.myCharz().cTypePk != (sbyte) 4)
            {
              if (num124 == 0)
              {
                GameScr.startFlyText(mResources.miss, char13.cx, char13.cy - char13.ch, 0, -3, mFont.MISS_ME);
                goto case 41;
              }
              else
              {
                GameScr.startFlyText("-" + (object) num124, char13.cx, char13.cy - char13.ch, 0, -3, flag8 ? mFont.FATAL : mFont.RED);
                goto case 41;
              }
            }
            else
              goto case 41;
          }
          else
          {
            Char charInMap9 = GameScr.findCharInMap(charId12);
            if (charInMap9 == null)
              break;
            charInMap9.cHP = msg.readInt3Byte();
            bool flag9 = false;
            int num125 = msg.readInt3Byte();
            if (num125 != 0)
              charInMap9.doInjure();
            int num126 = 0;
            try
            {
              flag9 = msg.reader().readBoolean();
              sbyte id10 = msg.reader().readByte();
              if (id10 != (sbyte) -1)
              {
                Res.outz("hit eff= " + (object) id10);
                EffecMn.addEff(new Effect((int) id10, charInMap9.cx, charInMap9.cy, 3, 1, -1));
              }
            }
            catch (Exception ex)
            {
            }
            int num127 = num125 + num126;
            if (charInMap9.cTypePk != (sbyte) 4)
            {
              if (num127 == 0)
              {
                GameScr.startFlyText(mResources.miss, charInMap9.cx, charInMap9.cy - charInMap9.ch, 0, -3, mFont.MISS);
                goto case 41;
              }
              else
              {
                GameScr.startFlyText("-" + (object) num127, charInMap9.cx, charInMap9.cy - charInMap9.ch, 0, -3, flag9 ? mFont.FATAL : mFont.ORANGE);
                goto case 41;
              }
            }
            else
              goto case 41;
          }
        case 156:
          GameCanvas.debug("SZ6", 2);
          MyVector menuItems3 = new MyVector();
          menuItems3.addElement((object) new Command(msg.reader().readUTF(), (IActionListener) GameCanvas.instance, 88817, (object) null));
          GameCanvas.menu.startAt(menuItems3, 3);
          goto case 41;
        case 157:
          GameCanvas.debug("SZ7", 2);
          int charId13 = msg.reader().readInt();
          Char char14 = charId13 != Char.myCharz().charID ? GameScr.findCharInMap(charId13) : Char.myCharz();
          char14.moveFast = new short[3];
          char14.moveFast[0] = (short) 0;
          short num128 = msg.reader().readShort();
          short num129 = msg.reader().readShort();
          char14.moveFast[1] = num128;
          char14.moveFast[2] = num129;
          try
          {
            int charId14 = msg.reader().readInt();
            Char char15 = charId14 != Char.myCharz().charID ? GameScr.findCharInMap(charId14) : Char.myCharz();
            char15.cx = (int) num128;
            char15.cy = (int) num129;
            goto case 41;
          }
          catch (Exception ex)
          {
            Cout.println("Loi MOVE_FAST " + ex.ToString());
            goto case 41;
          }
        case 161:
          GameCanvas.debug("SZ3", 2);
          Char charInMap10 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap10 != null)
          {
            charInMap10.killCharId = Char.myCharz().charID;
            Char.myCharz().npcFocus = (Npc) null;
            Char.myCharz().mobFocus = (Mob) null;
            Char.myCharz().itemFocus = (ItemMap) null;
            Char.myCharz().charFocus = charInMap10;
            Char.isManualFocus = true;
            GameScr.info1.addInfo(charInMap10.cName + mResources.CUU_SAT, 0);
            goto case 41;
          }
          else
            goto case 41;
        case 162:
          GameCanvas.debug("SZ4", 2);
          Char.myCharz().killCharId = msg.reader().readInt();
          Char.myCharz().npcFocus = (Npc) null;
          Char.myCharz().mobFocus = (Mob) null;
          Char.myCharz().itemFocus = (ItemMap) null;
          Char.myCharz().charFocus = GameScr.findCharInMap(Char.myCharz().killCharId);
          Char.isManualFocus = true;
          goto case 41;
        case 163:
          GameCanvas.debug("SZ5", 2);
          Char char16 = Char.myCharz();
          try
          {
            char16 = GameScr.findCharInMap(msg.reader().readInt());
          }
          catch (Exception ex)
          {
            Cout.println("Loi CLEAR_CUU_SAT " + ex.ToString());
          }
          char16.killCharId = -9999;
          goto case 41;
        case 164:
          sbyte id11 = msg.reader().readSByte();
          string text = msg.reader().readUTF();
          short time = msg.reader().readShort();
          if (ItemTime.isExistMessage((int) id11))
          {
            if (time != (short) 0)
            {
              ItemTime.getMessageById((int) id11).initTimeText(id11, text, (int) time);
              goto case 41;
            }
            else
            {
              GameScr.textTime.removeElement((object) ItemTime.getMessageById((int) id11));
              goto case 41;
            }
          }
          else
          {
            ItemTime o = new ItemTime();
            o.initTimeText(id11, text, (int) time);
            GameScr.textTime.addElement((object) o);
            goto case 41;
          }
        case 165:
          this.readGetImgByName(msg);
          goto case 41;
        case 167:
          Res.outz("ADD ITEM TO MAP --------------------------------------");
          GameCanvas.debug("SA6333", 2);
          short itemMapID = msg.reader().readShort();
          short itemTemplateID = msg.reader().readShort();
          int x = (int) msg.reader().readShort();
          int y = (int) msg.reader().readShort();
          int playerId = msg.reader().readInt();
          short r = 0;
          if (playerId == -2)
            r = msg.reader().readShort();
          ItemMap o3 = new ItemMap(playerId, itemMapID, itemTemplateID, x, y, r);
          GameScr.vItemMap.addElement((object) o3);
          goto case 41;
        case 168:
          SoundMn.IsDelAcc = msg.reader().readByte() != (sbyte) 0;
          goto case 41;
        case 180:
          GameCanvas.debug("SXX4", 2);
          ((Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte())).isDisable = msg.reader().readBool();
          goto case 41;
        case 181:
          GameCanvas.debug("SXX5", 2);
          ((Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte())).isDontMove = msg.reader().readBool();
          goto case 41;
        case 182:
          GameCanvas.debug("SXX8", 2);
          int charId15 = msg.reader().readInt();
          Char char17 = charId15 != Char.myCharz().charID ? GameScr.findCharInMap(charId15) : Char.myCharz();
          if (char17 == null)
            break;
          Mob mobToAttack = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
          if (char17.mobMe != null)
          {
            char17.mobMe.attackOtherMob(mobToAttack);
            goto case 41;
          }
          else
            goto case 41;
        case 183:
          int charId16 = msg.reader().readInt();
          Char char18;
          if (charId16 == Char.myCharz().charID)
          {
            char18 = Char.myCharz();
          }
          else
          {
            char18 = GameScr.findCharInMap(charId16);
            if (char18 == null)
              break;
          }
          char18.cHP = char18.cHPFull;
          char18.cMP = char18.cMPFull;
          char18.cx = (int) msg.reader().readShort();
          char18.cy = (int) msg.reader().readShort();
          char18.liveFromDead();
          goto case 41;
        case 184:
          GameCanvas.debug("SXX5", 2);
          ((Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte())).isFire = msg.reader().readBool();
          goto case 41;
        case 185:
          GameCanvas.debug("SXX5", 2);
          Mob mob14 = (Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte());
          mob14.isIce = msg.reader().readBool();
          if (!mob14.isIce)
          {
            ServerEffect.addServerEffect(77, mob14.x, mob14.y - 9, 1);
            goto case 41;
          }
          else
            goto case 41;
        case 186:
          GameCanvas.debug("SXX5", 2);
          ((Mob) GameScr.vMob.elementAt((int) msg.reader().readUnsignedByte())).isWind = msg.reader().readBool();
          goto case 41;
        case 187:
          string info4 = msg.reader().readUTF();
          short p1 = msg.reader().readShort();
          GameCanvas.inputDlg.show(info4, new Command(mResources.ACCEPT, (IActionListener) GameCanvas.instance, 88818, (object) p1), TField.INPUT_TYPE_ANY);
          goto case 41;
        case 189:
          GameCanvas.debug("SA577", 2);
          this.requestItemPlayer(msg);
          goto case 41;
        case 191:
          if (GameCanvas.currentScreen == GameScr.instance)
            GameCanvas.endDlg();
          string str7 = msg.reader().readUTF();
          string str8 = Res.changeString(msg.reader().readUTF());
          string empty = string.Empty;
          Char c4 = (Char) null;
          sbyte num130 = 0;
          if (!str7.Equals(string.Empty))
          {
            c4 = new Char();
            c4.charID = msg.reader().readInt();
            c4.head = (int) msg.reader().readShort();
            c4.headICON = (int) msg.reader().readShort();
            c4.body = (int) msg.reader().readShort();
            c4.bag = (int) msg.reader().readShort();
            c4.leg = (int) msg.reader().readShort();
            num130 = msg.reader().readByte();
            c4.cName = str7;
          }
          string s1 = empty + str8;
          InfoDlg.hide();
          if (str7.Equals(string.Empty))
          {
            GameScr.info1.addInfo(s1, 0);
            goto case 41;
          }
          else
          {
            GameScr.info2.addInfoWithChar(s1, c4, num130 == (sbyte) 0);
            if (GameCanvas.panel.isShow && GameCanvas.panel.type == 8)
            {
              GameCanvas.panel.initLogMessage();
              goto case 41;
            }
            else
              goto case 41;
          }
        case 193:
          GameCanvas.debug("SA3", 2);
          GameScr.info1.addInfo(msg.reader().readUTF(), 0);
          goto case 41;
        case 211:
          sbyte num131 = msg.reader().readByte();
          Res.outz("spec type= " + (object) num131);
          switch (num131)
          {
            case 0:
              Panel.spearcialImage = msg.reader().readShort();
              Panel.specialInfo = msg.reader().readUTF();
              goto label_901;
            case 1:
              sbyte length29 = msg.reader().readByte();
              Char.myCharz().infoSpeacialSkill = new string[(int) length29][];
              Char.myCharz().imgSpeacialSkill = new short[(int) length29][];
              GameCanvas.panel.speacialTabName = new string[(int) length29][];
              for (int index77 = 0; index77 < (int) length29; ++index77)
              {
                GameCanvas.panel.speacialTabName[index77] = new string[2];
                string[] strArray = Res.split(msg.reader().readUTF(), "\n", 0);
                if (strArray.Length == 2)
                  GameCanvas.panel.speacialTabName[index77] = strArray;
                if (strArray.Length == 1)
                {
                  GameCanvas.panel.speacialTabName[index77][0] = strArray[0];
                  GameCanvas.panel.speacialTabName[index77][1] = string.Empty;
                }
                int length30 = (int) msg.reader().readByte();
                Char.myCharz().infoSpeacialSkill[index77] = new string[length30];
                Char.myCharz().imgSpeacialSkill[index77] = new short[length30];
                for (int index78 = 0; index78 < length30; ++index78)
                {
                  Char.myCharz().imgSpeacialSkill[index77][index78] = msg.reader().readShort();
                  Char.myCharz().infoSpeacialSkill[index77][index78] = msg.reader().readUTF();
                }
              }
              GameCanvas.panel.tabName[25] = GameCanvas.panel.speacialTabName;
              GameCanvas.panel.setTypeSpeacialSkill();
              GameCanvas.panel.show();
              goto label_901;
            default:
              goto label_901;
          }
        default:
          switch (command1)
          {
            case -112:
              sbyte num132 = msg.reader().readByte();
              if (num132 == (sbyte) 0)
                GameScr.findMobInMap(msg.reader().readByte()).clearBody();
              if (num132 == (sbyte) 1)
              {
                GameScr.findMobInMap(msg.reader().readByte()).setBody(msg.reader().readShort());
                goto label_901;
              }
              else
                goto label_901;
            case -107:
              sbyte num133 = msg.reader().readByte();
              if (num133 == (sbyte) 0)
                Char.myCharz().havePet = false;
              if (num133 == (sbyte) 1)
                Char.myCharz().havePet = true;
              if (num133 == (sbyte) 2)
              {
                InfoDlg.hide();
                Char.myPetz().head = (int) msg.reader().readShort();
                Char.myPetz().setDefaultPart();
                int length31 = (int) msg.reader().readUnsignedByte();
                Res.outz("num body = " + (object) length31);
                Char.myPetz().arrItemBody = new Item[length31];
                for (int index79 = 0; index79 < length31; ++index79)
                {
                  short id12 = msg.reader().readShort();
                  Res.outz("template id= " + (object) id12);
                  if (id12 != (short) -1)
                  {
                    Res.outz("1");
                    Char.myPetz().arrItemBody[index79] = new Item();
                    Char.myPetz().arrItemBody[index79].template = ItemTemplates.get(id12);
                    int type2 = (int) Char.myPetz().arrItemBody[index79].template.type;
                    Char.myPetz().arrItemBody[index79].quantity = msg.reader().readInt();
                    Res.outz("3");
                    Char.myPetz().arrItemBody[index79].info = msg.reader().readUTF();
                    Char.myPetz().arrItemBody[index79].content = msg.reader().readUTF();
                    int length32 = (int) msg.reader().readUnsignedByte();
                    Res.outz("option size= " + (object) length32);
                    if (length32 != 0)
                    {
                      Char.myPetz().arrItemBody[index79].itemOption = new ItemOption[length32];
                      for (int index80 = 0; index80 < Char.myPetz().arrItemBody[index79].itemOption.Length; ++index80)
                      {
                        int optionTemplateId = (int) msg.reader().readUnsignedByte();
                        int num134 = (int) msg.reader().readUnsignedShort();
                        if (optionTemplateId != -1)
                          Char.myPetz().arrItemBody[index79].itemOption[index80] = new ItemOption(optionTemplateId, num134);
                      }
                    }
                    switch (type2)
                    {
                      case 0:
                        Char.myPetz().body = (int) Char.myPetz().arrItemBody[index79].template.part;
                        continue;
                      case 1:
                        Char.myPetz().leg = (int) Char.myPetz().arrItemBody[index79].template.part;
                        continue;
                      default:
                        continue;
                    }
                  }
                }
                Char.myPetz().cHP = msg.readInt3Byte();
                Char.myPetz().cHPFull = msg.readInt3Byte();
                Char.myPetz().cMP = msg.readInt3Byte();
                Char.myPetz().cMPFull = msg.readInt3Byte();
                Char.myPetz().cDamFull = msg.readInt3Byte();
                Char.myPetz().cName = msg.reader().readUTF();
                Char.myPetz().currStrLevel = msg.reader().readUTF();
                Char.myPetz().cPower = msg.reader().readLong();
                Char.myPetz().cTiemNang = msg.reader().readLong();
                Char.myPetz().petStatus = msg.reader().readByte();
                Char.myPetz().cStamina = (int) msg.reader().readShort();
                Char.myPetz().cMaxStamina = msg.reader().readShort();
                Char.myPetz().cCriticalFull = (int) msg.reader().readByte();
                Char.myPetz().cDefull = (int) msg.reader().readShort();
                Char.myPetz().arrPetSkill = new Skill[(int) msg.reader().readByte()];
                Res.outz("SKILLENT = " + (object) Char.myPetz().arrPetSkill);
                for (int index81 = 0; index81 < Char.myPetz().arrPetSkill.Length; ++index81)
                {
                  short skillId = msg.reader().readShort();
                  if (skillId != (short) -1)
                  {
                    Char.myPetz().arrPetSkill[index81] = Skills.get(skillId);
                  }
                  else
                  {
                    Char.myPetz().arrPetSkill[index81] = new Skill();
                    Char.myPetz().arrPetSkill[index81].template = (SkillTemplate) null;
                    Char.myPetz().arrPetSkill[index81].moreInfo = msg.reader().readUTF();
                  }
                }
                if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
                {
                  GameCanvas.panel2 = new Panel();
                  GameCanvas.panel2.tabName[7] = new string[1][]
                  {
                    new string[1]{ string.Empty }
                  };
                  GameCanvas.panel2.setTypeBodyOnly();
                  GameCanvas.panel2.show();
                  GameCanvas.panel.setTypePetMain();
                  GameCanvas.panel.show();
                  goto label_901;
                }
                else
                {
                  GameCanvas.panel.tabName[21] = mResources.petMainTab;
                  GameCanvas.panel.setTypePetMain();
                  GameCanvas.panel.show();
                  goto label_901;
                }
              }
              else
                goto label_901;
            default:
              goto label_901;
          }
      }
    }
    catch (Exception ex)
    {
    }
    finally
    {
      msg?.cleanup();
    }
  }

  private void createItem(myReader d)
  {
    GameScr.vcItem = d.readByte();
    ItemTemplates.itemTemplates.clear();
    GameScr.gI().iOptionTemplates = new ItemOptionTemplate[(int) d.readUnsignedByte()];
    for (int index = 0; index < GameScr.gI().iOptionTemplates.Length; ++index)
    {
      GameScr.gI().iOptionTemplates[index] = new ItemOptionTemplate();
      GameScr.gI().iOptionTemplates[index].id = index;
      GameScr.gI().iOptionTemplates[index].name = d.readUTF();
      GameScr.gI().iOptionTemplates[index].type = (int) d.readByte();
    }
    int num = (int) d.readShort();
    for (int templateID = 0; templateID < num; ++templateID)
      ItemTemplates.add(new ItemTemplate((short) templateID, d.readByte(), d.readByte(), d.readUTF(), d.readUTF(), d.readByte(), d.readInt(), d.readShort(), d.readShort(), d.readBool()));
  }

  private void createSkill(myReader d)
  {
    GameScr.vcSkill = d.readByte();
    GameScr.gI().sOptionTemplates = new SkillOptionTemplate[(int) d.readByte()];
    for (int index = 0; index < GameScr.gI().sOptionTemplates.Length; ++index)
    {
      GameScr.gI().sOptionTemplates[index] = new SkillOptionTemplate();
      GameScr.gI().sOptionTemplates[index].id = index;
      GameScr.gI().sOptionTemplates[index].name = d.readUTF();
    }
    GameScr.nClasss = new NClass[(int) d.readByte()];
    for (int index1 = 0; index1 < GameScr.nClasss.Length; ++index1)
    {
      GameScr.nClasss[index1] = new NClass();
      GameScr.nClasss[index1].classId = index1;
      GameScr.nClasss[index1].name = d.readUTF();
      GameScr.nClasss[index1].skillTemplates = new SkillTemplate[(int) d.readByte()];
      for (int index2 = 0; index2 < GameScr.nClasss[index1].skillTemplates.Length; ++index2)
      {
        GameScr.nClasss[index1].skillTemplates[index2] = new SkillTemplate();
        GameScr.nClasss[index1].skillTemplates[index2].id = d.readByte();
        GameScr.nClasss[index1].skillTemplates[index2].name = d.readUTF();
        GameScr.nClasss[index1].skillTemplates[index2].maxPoint = (int) d.readByte();
        GameScr.nClasss[index1].skillTemplates[index2].manaUseType = (int) d.readByte();
        GameScr.nClasss[index1].skillTemplates[index2].type = (int) d.readByte();
        GameScr.nClasss[index1].skillTemplates[index2].iconId = (int) d.readShort();
        GameScr.nClasss[index1].skillTemplates[index2].damInfo = d.readUTF();
        int lineWidth = 130;
        if (GameCanvas.w == 128 || GameCanvas.h <= 208)
          lineWidth = 100;
        GameScr.nClasss[index1].skillTemplates[index2].description = mFont.tahoma_7_green2.splitFontArray(d.readUTF(), lineWidth);
        GameScr.nClasss[index1].skillTemplates[index2].skills = new Skill[(int) d.readByte()];
        for (int index3 = 0; index3 < GameScr.nClasss[index1].skillTemplates[index2].skills.Length; ++index3)
        {
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3] = new Skill();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].skillId = d.readShort();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].template = GameScr.nClasss[index1].skillTemplates[index2];
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].point = (int) d.readByte();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].powRequire = d.readLong();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].manaUse = (int) d.readShort();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].coolDown = d.readInt();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].dx = (int) d.readShort();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].dy = (int) d.readShort();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].maxFight = (int) d.readByte();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].damage = d.readShort();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].price = d.readShort();
          GameScr.nClasss[index1].skillTemplates[index2].skills[index3].moreInfo = d.readUTF();
          Skills.add(GameScr.nClasss[index1].skillTemplates[index2].skills[index3]);
        }
      }
    }
  }

  private void createMap(myReader d)
  {
    GameScr.vcMap = d.readByte();
    TileMap.mapNames = new string[(int) d.readUnsignedByte()];
    for (int index = 0; index < TileMap.mapNames.Length; ++index)
      TileMap.mapNames[index] = d.readUTF();
    Npc.arrNpcTemplate = new NpcTemplate[(int) d.readByte()];
    for (sbyte index1 = 0; (int) index1 < Npc.arrNpcTemplate.Length; ++index1)
    {
      Npc.arrNpcTemplate[(int) index1] = new NpcTemplate();
      Npc.arrNpcTemplate[(int) index1].npcTemplateId = (int) index1;
      Npc.arrNpcTemplate[(int) index1].name = d.readUTF();
      Npc.arrNpcTemplate[(int) index1].headId = (int) d.readShort();
      Npc.arrNpcTemplate[(int) index1].bodyId = (int) d.readShort();
      Npc.arrNpcTemplate[(int) index1].legId = (int) d.readShort();
      Npc.arrNpcTemplate[(int) index1].menu = new string[(int) d.readByte()][];
      for (int index2 = 0; index2 < Npc.arrNpcTemplate[(int) index1].menu.Length; ++index2)
      {
        Npc.arrNpcTemplate[(int) index1].menu[index2] = new string[(int) d.readByte()];
        for (int index3 = 0; index3 < Npc.arrNpcTemplate[(int) index1].menu[index2].Length; ++index3)
          Npc.arrNpcTemplate[(int) index1].menu[index2][index3] = d.readUTF();
      }
    }
    Mob.arrMobTemplate = new MobTemplate[(int) d.readByte()];
    for (sbyte index = 0; (int) index < Mob.arrMobTemplate.Length; ++index)
    {
      Mob.arrMobTemplate[(int) index] = new MobTemplate();
      Mob.arrMobTemplate[(int) index].mobTemplateId = index;
      Mob.arrMobTemplate[(int) index].type = d.readByte();
      Mob.arrMobTemplate[(int) index].name = d.readUTF();
      Mob.arrMobTemplate[(int) index].hp = d.readInt();
      Mob.arrMobTemplate[(int) index].rangeMove = d.readByte();
      Mob.arrMobTemplate[(int) index].speed = d.readByte();
      Mob.arrMobTemplate[(int) index].dartType = d.readByte();
    }
  }

  private void createData(myReader d, bool isSaveRMS)
  {
    GameScr.vcData = d.readByte();
    if (!isSaveRMS)
      return;
    Rms.saveRMS("NR_dart", NinjaUtil.readByteArray(d));
    Rms.saveRMS("NR_arrow", NinjaUtil.readByteArray(d));
    Rms.saveRMS("NR_effect", NinjaUtil.readByteArray(d));
    Rms.saveRMS("NR_image", NinjaUtil.readByteArray(d));
    Rms.saveRMS("NR_part", NinjaUtil.readByteArray(d));
    Rms.saveRMS("NR_skill", NinjaUtil.readByteArray(d));
    Rms.DeleteStorage("NRdata");
  }

  private Image createImage(sbyte[] arr)
  {
    try
    {
      return Image.createImage(arr, 0, arr.Length);
    }
    catch (Exception ex)
    {
    }
    return (Image) null;
  }

  public int[] arrayByte2Int(sbyte[] b)
  {
    int[] numArray = new int[b.Length];
    for (int index = 0; index < b.Length; ++index)
    {
      int num = (int) b[index];
      if (num < 0)
        num += 256;
      numArray[index] = num;
    }
    return numArray;
  }

  public void readClanMsg(Message msg, int index)
  {
    try
    {
      ClanMessage cm = new ClanMessage();
      sbyte num = msg.reader().readByte();
      cm.type = (int) num;
      cm.id = msg.reader().readInt();
      cm.playerId = msg.reader().readInt();
      cm.playerName = msg.reader().readUTF();
      cm.role = msg.reader().readByte();
      cm.time = (long) (msg.reader().readInt() + 1000000000);
      bool upToTop = false;
      GameScr.isNewClanMessage = false;
      switch (num)
      {
        case 0:
          string str = msg.reader().readUTF();
          GameScr.isNewClanMessage = true;
          if (mFont.tahoma_7.getWidth(str) > Panel.WIDTH_PANEL - 60)
          {
            cm.chat = mFont.tahoma_7.splitFontArray(str, Panel.WIDTH_PANEL - 10);
          }
          else
          {
            cm.chat = new string[1];
            cm.chat[0] = str;
          }
          cm.color = msg.reader().readByte();
          break;
        case 1:
          cm.recieve = (int) msg.reader().readByte();
          cm.maxCap = (int) msg.reader().readByte();
          upToTop = msg.reader().readByte() == (sbyte) 1;
          if (upToTop)
            GameScr.isNewClanMessage = true;
          if (cm.playerId != Char.myCharz().charID)
          {
            if (cm.recieve < cm.maxCap)
              cm.option = new string[1]{ mResources.donate };
            else
              cm.option = (string[]) null;
          }
          if (GameCanvas.panel.cp != null)
          {
            GameCanvas.panel.updateRequest(cm.recieve, cm.maxCap);
            break;
          }
          break;
        case 2:
          if (Char.myCharz().role == (sbyte) 0)
          {
            GameScr.isNewClanMessage = true;
            cm.option = new string[2]
            {
              mResources.CANCEL,
              mResources.receive
            };
            break;
          }
          break;
      }
      if (GameCanvas.currentScreen != GameScr.instance)
        GameScr.isNewClanMessage = false;
      else if (GameCanvas.panel.isShow && GameCanvas.panel.type == 0 && GameCanvas.panel.currentTabIndex == 3)
        GameScr.isNewClanMessage = false;
      ClanMessage.addMessage(cm, index, upToTop);
    }
    catch (Exception ex)
    {
      Cout.println("LOI TAI CMD -= " + (object) msg.command);
    }
  }

  public void loadCurrMap(sbyte teleport3)
  {
    Res.outz("is loading map = " + (object) Char.isLoadingMap);
    GameScr.gI().auto = 0;
    GameScr.isChangeZone = false;
    CreateCharScr.instance = (CreateCharScr) null;
    GameScr.info1.isUpdate = false;
    GameScr.info2.isUpdate = false;
    GameScr.lockTick = 0;
    GameCanvas.panel.isShow = false;
    SoundMn.gI().stopAll();
    if (!GameScr.isLoadAllData && !CreateCharScr.isCreateChar)
      GameScr.gI().initSelectChar();
    GameScr.loadCamera(false, teleport3 != (sbyte) 1 ? -1 : Char.myCharz().cx, teleport3 != (sbyte) 0 ? 0 : -1);
    TileMap.loadMainTile();
    TileMap.loadMap(TileMap.tileID);
    Res.outz("LOAD GAMESCR 2");
    Char.myCharz().cvx = 0;
    Char.myCharz().statusMe = 4;
    Char.myCharz().currentMovePoint = (MovePoint) null;
    Char.myCharz().mobFocus = (Mob) null;
    Char.myCharz().charFocus = (Char) null;
    Char.myCharz().npcFocus = (Npc) null;
    Char.myCharz().itemFocus = (ItemMap) null;
    Char.myCharz().skillPaint = (SkillPaint) null;
    Char.myCharz().setMabuHold(false);
    Char.myCharz().skillPaintRandomPaint = (SkillPaint) null;
    GameCanvas.clearAllPointerEvent();
    if (Char.myCharz().cy >= TileMap.pxh - 100)
    {
      Char.myCharz().isFlyUp = true;
      Char.myCharz().cx += Res.abs(Res.random(0, 80));
      Service.gI().charMove();
    }
    GameScr.gI().loadGameScr();
    GameCanvas.loadBG(TileMap.bgID);
    Char.isLockKey = false;
    Res.outz("cy= " + (object) Char.myCharz().cy + "---------------------------------------------");
    for (int index = 0; index < Char.myCharz().vEff.size(); ++index)
    {
      if (((EffectChar) Char.myCharz().vEff.elementAt(index)).template.type == (sbyte) 10)
      {
        Char.isLockKey = true;
        break;
      }
    }
    GameCanvas.clearKeyHold();
    GameCanvas.clearKeyPressed();
    GameScr.gI().dHP = Char.myCharz().cHP;
    GameScr.gI().dMP = Char.myCharz().cMP;
    Char.ischangingMap = false;
    GameScr.gI().switchToMe();
    if (Char.myCharz().cy <= 10 && teleport3 != (sbyte) 0 && teleport3 != (sbyte) 2)
    {
      Teleport.addTeleport(new Teleport(Char.myCharz().cx, Char.myCharz().cy, Char.myCharz().head, Char.myCharz().cdir, 1, true, teleport3 != (sbyte) 1 ? (int) teleport3 : Char.myCharz().cgender));
      Char.myCharz().isTeleport = true;
    }
    if (teleport3 == (sbyte) 2)
      Char.myCharz().show();
    if (GameScr.gI().isRongThanXuatHien)
    {
      if (TileMap.mapID == GameScr.gI().mapRID && TileMap.zoneID == GameScr.gI().zoneRID)
        GameScr.gI().callRongThan(GameScr.gI().xR, GameScr.gI().yR);
      if (mGraphics.zoomLevel > 1)
        GameScr.gI().doiMauTroi();
    }
    InfoDlg.hide();
    InfoDlg.show(TileMap.mapName, mResources.zone + " " + (object) TileMap.zoneID, 30);
    GameCanvas.endDlg();
    GameCanvas.isLoading = false;
    Hint.clickMob();
    Hint.clickNpc();
    GameCanvas.debug("SA75x9", 2);
  }

  public void loadInfoMap(Message msg)
  {
    try
    {
      if (mGraphics.zoomLevel == 1)
        SmallImage.clearHastable();
      Char.myCharz().cx = Char.myCharz().cxSend = Char.myCharz().cxFocus = (int) msg.reader().readShort();
      Char.myCharz().cy = Char.myCharz().cySend = Char.myCharz().cyFocus = (int) msg.reader().readShort();
      Char.myCharz().xSd = Char.myCharz().cx;
      Char.myCharz().ySd = Char.myCharz().cy;
      Res.outz("head= " + (object) Char.myCharz().head + " body= " + (object) Char.myCharz().body + " left= " + (object) Char.myCharz().leg + " x= " + (object) Char.myCharz().cx + " y= " + (object) Char.myCharz().cy + " chung toc= " + (object) Char.myCharz().cgender);
      if (Char.myCharz().cx >= 0 && Char.myCharz().cx <= 100)
        Char.myCharz().cdir = 1;
      else if (Char.myCharz().cx >= TileMap.tmw - 100 && Char.myCharz().cx <= TileMap.tmw)
        Char.myCharz().cdir = -1;
      GameCanvas.debug("SA75x4", 2);
      int num1 = (int) msg.reader().readByte();
      Res.outz("vGo size= " + (object) num1);
      if (!GameScr.info1.isDone)
      {
        GameScr.info1.cmx = Char.myCharz().cx - GameScr.cmx;
        GameScr.info1.cmy = Char.myCharz().cy - GameScr.cmy;
      }
      for (int index = 0; index < num1; ++index)
      {
        Waypoint waypoint = new Waypoint(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readUTF());
        if (TileMap.mapID != 21 && TileMap.mapID != 22 && TileMap.mapID != 23 || waypoint.minX < (short) 0 || waypoint.minX > (short) 24)
          ;
      }
      Resources.UnloadUnusedAssets();
      GC.Collect();
      GameCanvas.debug("SA75x5", 2);
      int num2 = (int) msg.reader().readByte();
      Mob.newMob.removeAllElements();
      for (sbyte index = 0; (int) index < num2; ++index)
      {
        Mob o1 = new Mob((int) index, msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readBoolean(), (int) msg.reader().readByte(), (int) msg.reader().readByte(), msg.reader().readInt(), msg.reader().readByte(), msg.reader().readInt(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte());
        o1.xSd = o1.x;
        o1.ySd = o1.y;
        o1.isBoss = msg.reader().readBoolean();
        if (Mob.arrMobTemplate[o1.templateId].type != (sbyte) 0)
        {
          o1.dir = (int) index % 3 != 0 ? 1 : -1;
          o1.x += 10 - (int) index % 20;
        }
        o1.isMobMe = false;
        BigBoss o2 = (BigBoss) null;
        BachTuoc o3 = (BachTuoc) null;
        BigBoss2 o4 = (BigBoss2) null;
        NewBoss o5 = (NewBoss) null;
        if (o1.templateId == 70)
          o2 = new BigBoss((int) index, (short) o1.x, (short) o1.y, 70, o1.hp, o1.maxHp, o1.sys);
        if (o1.templateId == 71)
          o3 = new BachTuoc((int) index, (short) o1.x, (short) o1.y, 71, o1.hp, o1.maxHp, o1.sys);
        if (o1.templateId == 72)
          o4 = new BigBoss2((int) index, (short) o1.x, (short) o1.y, 72, o1.hp, o1.maxHp, 3);
        if (o1.isBoss)
          o5 = new NewBoss((int) index, (short) o1.x, (short) o1.y, o1.templateId, o1.hp, o1.maxHp, o1.sys);
        if (o5 != null)
          GameScr.vMob.addElement((object) o5);
        else if (o2 != null)
          GameScr.vMob.addElement((object) o2);
        else if (o3 != null)
          GameScr.vMob.addElement((object) o3);
        else if (o4 != null)
          GameScr.vMob.addElement((object) o4);
        else
          GameScr.vMob.addElement((object) o1);
      }
      for (int index = 0; index < Mob.lastMob.size(); ++index)
      {
        string str = (string) Mob.lastMob.elementAt(index);
        if (!Mob.isExistNewMob(str))
        {
          Mob.arrMobTemplate[int.Parse(str)].data = (EffectData) null;
          Mob.lastMob.removeElementAt(index);
          --index;
        }
      }
      if (Char.myCharz().mobMe != null && GameScr.findMobInMap(Char.myCharz().mobMe.mobId) == null)
      {
        Char.myCharz().mobMe.getData();
        Char.myCharz().mobMe.x = Char.myCharz().cx;
        Char.myCharz().mobMe.y = Char.myCharz().cy - 40;
        GameScr.vMob.addElement((object) Char.myCharz().mobMe);
      }
      int num3 = (int) msg.reader().readByte();
      byte num4 = 0;
      while ((int) num4 < num3)
        ++num4;
      GameCanvas.debug("SA75x6", 2);
      int num5 = (int) msg.reader().readByte();
      Res.outz("NPC size= " + (object) num5);
      for (int npcId = 0; npcId < num5; ++npcId)
      {
        sbyte status = msg.reader().readByte();
        short cx = msg.reader().readShort();
        short cy = msg.reader().readShort();
        sbyte templateId = msg.reader().readByte();
        short num6 = msg.reader().readShort();
        if (templateId != (sbyte) 6 && (Char.myCharz().taskMaint.taskId >= (short) 7 && (Char.myCharz().taskMaint.taskId != (short) 7 || Char.myCharz().taskMaint.index > 1) || templateId != (sbyte) 7 && templateId != (sbyte) 8 && templateId != (sbyte) 9) && (Char.myCharz().taskMaint.taskId >= (short) 6 || templateId != (sbyte) 16))
        {
          if (templateId == (sbyte) 4)
          {
            GameScr.gI().magicTree = new MagicTree(npcId, (int) status, (int) cx, (int) cy, (int) templateId, (int) num6);
            Service.gI().magicTree((sbyte) 2);
            GameScr.vNpc.addElement((object) GameScr.gI().magicTree);
          }
          else
          {
            Npc o = new Npc(npcId, (int) status, (int) cx, (int) cy + 3, (int) templateId, (int) num6);
            GameScr.vNpc.addElement((object) o);
          }
        }
      }
      GameCanvas.debug("SA75x7", 2);
      int num7 = (int) msg.reader().readByte();
      Res.outz("item size = " + (object) num7);
      for (int index1 = 0; index1 < num7; ++index1)
      {
        short itemMapID = msg.reader().readShort();
        short itemTemplateID = msg.reader().readShort();
        int x = (int) msg.reader().readShort();
        int y = (int) msg.reader().readShort();
        int playerId = msg.reader().readInt();
        short r = 0;
        if (playerId == -2)
          r = msg.reader().readShort();
        ItemMap o = new ItemMap(playerId, itemMapID, itemTemplateID, x, y, r);
        bool flag = false;
        for (int index2 = 0; index2 < GameScr.vItemMap.size(); ++index2)
        {
          if (((ItemMap) GameScr.vItemMap.elementAt(index2)).itemMapID == o.itemMapID)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          GameScr.vItemMap.addElement((object) o);
      }
      TileMap.vCurrItem.removeAllElements();
      if (mGraphics.zoomLevel == 1)
        BgItem.clearHashTable();
      BgItem.vKeysNew.removeAllElements();
      if (!GameCanvas.lowGraphic || GameCanvas.lowGraphic && TileMap.isVoDaiMap() || TileMap.mapID == 45 || TileMap.mapID == 46 || TileMap.mapID == 47 || TileMap.mapID == 48)
      {
        short num8 = msg.reader().readShort();
        Res.outz("nItem= " + (object) num8);
        for (int index = 0; index < (int) num8; ++index)
        {
          short id = msg.reader().readShort();
          short num9 = msg.reader().readShort();
          short num10 = msg.reader().readShort();
          if (TileMap.getBIById((int) id) != null)
          {
            BgItem biById = TileMap.getBIById((int) id);
            BgItem o = new BgItem();
            o.id = (int) id;
            o.idImage = biById.idImage;
            o.dx = biById.dx;
            o.dy = biById.dy;
            o.x = (int) num9 * (int) TileMap.size;
            o.y = (int) num10 * (int) TileMap.size;
            o.layer = biById.layer;
            if (TileMap.isExistMoreOne(o.id))
            {
              o.trans = index % 2 != 0 ? 2 : 0;
              if (TileMap.mapID == 45)
                o.trans = 0;
            }
            if (!BgItem.imgNew.containsKey((object) (o.idImage.ToString() + string.Empty)))
            {
              if (mGraphics.zoomLevel == 1)
              {
                Image v = GameCanvas.loadImage("/mapBackGround/" + (object) o.idImage + ".png");
                if (v == null)
                {
                  v = Image.createRGBImage(new int[1], 1, 1, true);
                  Service.gI().getBgTemplate(o.idImage);
                }
                BgItem.imgNew.put((object) (o.idImage.ToString() + string.Empty), (object) v);
              }
              else
              {
                bool flag = false;
                sbyte[] imageData = Rms.loadRMS(mGraphics.zoomLevel.ToString() + "bgItem" + (object) o.idImage);
                if (imageData != null)
                {
                  if (BgItem.newSmallVersion != null)
                  {
                    Res.outz("Small  last= " + (object) (imageData.Length % (int) sbyte.MaxValue) + "new Version= " + (object) BgItem.newSmallVersion[(int) o.idImage]);
                    if (imageData.Length % (int) sbyte.MaxValue != (int) BgItem.newSmallVersion[(int) o.idImage])
                      flag = true;
                  }
                  if (!flag)
                  {
                    Image image = Image.createImage(imageData, 0, imageData.Length);
                    if (image != null)
                      BgItem.imgNew.put((object) (o.idImage.ToString() + string.Empty), (object) image);
                    else
                      flag = true;
                  }
                }
                else
                  flag = true;
                if (flag)
                {
                  Image v = GameCanvas.loadImage("/mapBackGround/" + (object) o.idImage + ".png");
                  if (v == null)
                  {
                    v = Image.createRGBImage(new int[1], 1, 1, true);
                    Service.gI().getBgTemplate(o.idImage);
                  }
                  BgItem.imgNew.put((object) (o.idImage.ToString() + string.Empty), (object) v);
                }
              }
              BgItem.vKeysLast.addElement((object) (o.idImage.ToString() + string.Empty));
            }
            if (!BgItem.isExistKeyNews(o.idImage.ToString() + string.Empty))
              BgItem.vKeysNew.addElement((object) (o.idImage.ToString() + string.Empty));
            o.changeColor();
            TileMap.vCurrItem.addElement((object) o);
          }
        }
        for (int index = 0; index < BgItem.vKeysLast.size(); ++index)
        {
          string str = (string) BgItem.vKeysLast.elementAt(index);
          if (!BgItem.isExistKeyNews(str))
          {
            BgItem.imgNew.remove((object) str);
            if (BgItem.imgNew.containsKey((object) (str + "blend" + (object) 1)))
              BgItem.imgNew.remove((object) (str + "blend" + (object) 1));
            if (BgItem.imgNew.containsKey((object) (str + "blend" + (object) 3)))
              BgItem.imgNew.remove((object) (str + "blend" + (object) 3));
            BgItem.vKeysLast.removeElementAt(index);
            --index;
          }
        }
        BackgroudEffect.isFog = false;
        BackgroudEffect.nCloud = 0;
        EffecMn.vEff.removeAllElements();
        BackgroudEffect.vBgEffect.removeAllElements();
        Effect.newEff.removeAllElements();
        short num11 = msg.reader().readShort();
        for (int index = 0; index < (int) num11; ++index)
          this.keyValueAction(msg.reader().readUTF(), msg.reader().readUTF());
        for (int index = 0; index < Effect.lastEff.size(); ++index)
        {
          string str = (string) Effect.lastEff.elementAt(index);
          if (!Effect.isExistNewEff(str))
          {
            Effect.removeEffData(int.Parse(str));
            Effect.lastEff.removeElementAt(index);
            --index;
          }
        }
      }
      else
      {
        short num12 = msg.reader().readShort();
        for (int index = 0; index < (int) num12; ++index)
        {
          msg.reader().readShort();
          msg.reader().readShort();
          msg.reader().readShort();
        }
        short num13 = msg.reader().readShort();
        for (int index = 0; index < (int) num13; ++index)
        {
          msg.reader().readUTF();
          msg.reader().readUTF();
        }
      }
      TileMap.bgType = (int) msg.reader().readByte();
      this.loadCurrMap(msg.reader().readByte());
      Char.isLoadingMap = false;
      GameCanvas.debug("SA75x8", 2);
      Resources.UnloadUnusedAssets();
      GC.Collect();
      Cout.LogError("----------DA CHAY XONG LOAD INFO MAP");
    }
    catch (Exception ex)
    {
      Cout.LogError("LOI TAI LOADMAP INFO " + ex.ToString());
    }
  }

  public void keyValueAction(string key, string value)
  {
    switch (key)
    {
      case "eff":
        if (Panel.graphics > 0)
          break;
        string[] strArray = Res.split(value, ".", 0);
        int id = int.Parse(strArray[0]);
        int layer = int.Parse(strArray[1]);
        int x = int.Parse(strArray[2]);
        int y = int.Parse(strArray[3]);
        int loop;
        int loopCount;
        if (strArray.Length <= 4)
        {
          loop = -1;
          loopCount = 1;
        }
        else
        {
          loop = int.Parse(strArray[4]);
          loopCount = int.Parse(strArray[5]);
        }
        Effect me = new Effect(id, x, y, layer, loop, loopCount);
        if (strArray.Length > 6)
        {
          me.typeEff = int.Parse(strArray[6]);
          if (strArray.Length > 7)
          {
            me.indexFrom = int.Parse(strArray[7]);
            me.indexTo = int.Parse(strArray[8]);
          }
        }
        EffecMn.addEff(me);
        break;
      case "beff":
        if (Panel.graphics > 1)
          break;
        BackgroudEffect.addEffect(int.Parse(value));
        break;
    }
  }

  public void messageNotMap(Message msg)
  {
    GameCanvas.debug("SA6", 2);
    try
    {
      sbyte num1 = msg.reader().readByte();
      mSystem.LogCMD("---messageNotMap : " + (object) num1);
      switch (num1)
      {
        case 4:
          GameCanvas.debug("SA8", 2);
          GameCanvas.loginScr.savePass();
          GameScr.isAutoPlay = false;
          GameScr.canAutoPlay = false;
          LoginScr.isUpdateAll = true;
          LoginScr.isUpdateData = true;
          LoginScr.isUpdateMap = true;
          LoginScr.isUpdateSkill = true;
          LoginScr.isUpdateItem = true;
          GameScr.vsData = msg.reader().readByte();
          GameScr.vsMap = msg.reader().readByte();
          GameScr.vsSkill = msg.reader().readByte();
          GameScr.vsItem = msg.reader().readByte();
          msg.reader().readByte();
          if (GameCanvas.loginScr.isLogin2)
          {
            Rms.saveRMSString("acc", string.Empty);
            Rms.saveRMSString("pass", string.Empty);
          }
          else
            Rms.saveRMSString("userAo" + (object) ServerListScreen.ipSelect, string.Empty);
          if ((int) GameScr.vsData != (int) GameScr.vcData)
          {
            GameScr.isLoadAllData = false;
            Service.gI().updateData();
          }
          else
          {
            try
            {
              LoginScr.isUpdateData = false;
            }
            catch (Exception ex)
            {
              GameScr.vcData = (sbyte) -1;
              Service.gI().updateData();
            }
          }
          if ((int) GameScr.vsMap != (int) GameScr.vcMap)
          {
            GameScr.isLoadAllData = false;
            Service.gI().updateMap();
          }
          else
          {
            try
            {
              if (!GameScr.isLoadAllData)
                this.createMap(new DataInputStream(Rms.loadRMS("NRmap")).r);
              LoginScr.isUpdateMap = false;
            }
            catch (Exception ex)
            {
              GameScr.vcMap = (sbyte) -1;
              Service.gI().updateMap();
            }
          }
          if ((int) GameScr.vsSkill != (int) GameScr.vcSkill)
          {
            GameScr.isLoadAllData = false;
            Service.gI().updateSkill();
          }
          else
          {
            try
            {
              if (!GameScr.isLoadAllData)
                this.createSkill(new DataInputStream(Rms.loadRMS("NRskill")).r);
              LoginScr.isUpdateSkill = false;
            }
            catch (Exception ex)
            {
              GameScr.vcSkill = (sbyte) -1;
              Service.gI().updateSkill();
            }
          }
          if ((int) GameScr.vsItem != (int) GameScr.vcItem)
          {
            GameScr.isLoadAllData = false;
            Service.gI().updateItem();
          }
          else
          {
            try
            {
              this.loadItemNew(new DataInputStream(Rms.loadRMS("NRitem0")).r, (sbyte) 0, false);
              this.loadItemNew(new DataInputStream(Rms.loadRMS("NRitem1")).r, (sbyte) 1, false);
              this.loadItemNew(new DataInputStream(Rms.loadRMS("NRitem2")).r, (sbyte) 2, false);
              this.loadItemNew(new DataInputStream(Rms.loadRMS("NRitem100")).r, (sbyte) 100, false);
              LoginScr.isUpdateItem = false;
            }
            catch (Exception ex)
            {
              GameScr.vcItem = (sbyte) -1;
              Service.gI().updateItem();
            }
          }
          if ((int) GameScr.vsData == (int) GameScr.vcData && (int) GameScr.vsMap == (int) GameScr.vcMap && (int) GameScr.vsSkill == (int) GameScr.vcSkill && (int) GameScr.vsItem == (int) GameScr.vcItem)
          {
            if (!GameScr.isLoadAllData)
            {
              GameScr.gI().readDart();
              GameScr.gI().readEfect();
              GameScr.gI().readArrow();
              GameScr.gI().readSkill();
            }
            Service.gI().clientOk();
          }
          sbyte length = msg.reader().readByte();
          Res.outz("CAPTION LENT= " + (object) length);
          GameScr.exps = new long[(int) length];
          for (int index = 0; index < GameScr.exps.Length; ++index)
            GameScr.exps[index] = msg.reader().readLong();
          break;
        case 6:
          Res.outz("GET UPDATE_MAP " + (object) msg.reader().available() + " bytes");
          msg.reader().mark(100000);
          this.createMap(msg.reader());
          msg.reader().reset();
          sbyte[] data1 = new sbyte[msg.reader().available()];
          msg.reader().readFully(ref data1);
          Rms.saveRMS("NRmap", data1);
          Rms.saveRMS("NRmapVersion", new sbyte[1]
          {
            GameScr.vcMap
          });
          LoginScr.isUpdateMap = false;
          if ((int) GameScr.vsData != (int) GameScr.vcData || (int) GameScr.vsMap != (int) GameScr.vcMap || (int) GameScr.vsSkill != (int) GameScr.vcSkill || (int) GameScr.vsItem != (int) GameScr.vcItem)
            break;
          GameScr.gI().readDart();
          GameScr.gI().readEfect();
          GameScr.gI().readArrow();
          GameScr.gI().readSkill();
          Service.gI().clientOk();
          break;
        case 7:
          Res.outz("GET UPDATE_SKILL " + (object) msg.reader().available() + " bytes");
          msg.reader().mark(100000);
          this.createSkill(msg.reader());
          msg.reader().reset();
          sbyte[] data2 = new sbyte[msg.reader().available()];
          msg.reader().readFully(ref data2);
          Rms.saveRMS("NRskill", data2);
          Rms.saveRMS("NRskillVersion", new sbyte[1]
          {
            GameScr.vcSkill
          });
          LoginScr.isUpdateSkill = false;
          if ((int) GameScr.vsData != (int) GameScr.vcData || (int) GameScr.vsMap != (int) GameScr.vcMap || (int) GameScr.vsSkill != (int) GameScr.vcSkill || (int) GameScr.vsItem != (int) GameScr.vcItem)
            break;
          GameScr.gI().readDart();
          GameScr.gI().readEfect();
          GameScr.gI().readArrow();
          GameScr.gI().readSkill();
          Service.gI().clientOk();
          break;
        case 8:
          Res.outz("GET UPDATE_ITEM " + (object) msg.reader().available() + " bytes");
          this.createItemNew(msg.reader());
          break;
        case 9:
          GameCanvas.debug("SA11", 2);
          break;
        case 10:
          try
          {
            Char.isLoadingMap = true;
            Res.outz("REQUEST MAP TEMPLATE");
            GameCanvas.isLoading = true;
            TileMap.maps = (int[]) null;
            TileMap.types = (int[]) null;
            mSystem.gcc();
            GameCanvas.debug("SA99", 2);
            TileMap.tmw = (int) msg.reader().readByte();
            TileMap.tmh = (int) msg.reader().readByte();
            TileMap.maps = new int[TileMap.tmw * TileMap.tmh];
            Res.outz("   M apsize= " + (object) (TileMap.tmw * TileMap.tmh));
            for (int index = 0; index < TileMap.maps.Length; ++index)
            {
              int num2 = (int) msg.reader().readByte();
              if (num2 < 0)
                num2 += 256;
              TileMap.maps[index] = (int) (ushort) num2;
            }
            TileMap.types = new int[TileMap.maps.Length];
            msg = this.messWait;
            this.loadInfoMap(msg);
            try
            {
              TileMap.isMapDouble = msg.reader().readByte() != (sbyte) 0;
            }
            catch (Exception ex)
            {
            }
          }
          catch (Exception ex)
          {
            Cout.LogError("LOI TAI CASE REQUEST_MAPTEMPLATE " + ex.ToString());
          }
          msg.cleanup();
          this.messWait.cleanup();
          msg = this.messWait = (Message) null;
          break;
        case 12:
          GameCanvas.debug("SA10", 2);
          break;
        case 16:
          MoneyCharge.gI().switchToMe();
          break;
        case 17:
          GameCanvas.debug("SYB123", 2);
          Char.myCharz().clearTask();
          break;
        case 18:
          GameCanvas.isLoading = false;
          GameCanvas.endDlg();
          int p = msg.reader().readInt();
          GameCanvas.inputDlg.show(mResources.changeNameChar, new Command(mResources.OK, (IActionListener) GameCanvas.instance, 88829, (object) p), TField.INPUT_TYPE_ANY);
          break;
        case 20:
          Char.myCharz().cPk = msg.reader().readByte();
          GameScr.info1.addInfo(mResources.PK_NOW + " " + (object) Char.myCharz().cPk, 0);
          break;
        default:
          switch (num1)
          {
            case 33:
              return;
            case 34:
              return;
            case 35:
              GameCanvas.endDlg();
              GameScr.gI().resetButton();
              GameScr.info1.addInfo(msg.reader().readUTF(), 0);
              return;
            case 36:
              GameScr.typeActive = msg.reader().readByte();
              Res.outz("load Me Active: " + (object) GameScr.typeActive);
              return;
            default:
              return;
          }
      }
    }
    catch (Exception ex)
    {
      Cout.LogError("LOI TAI messageNotMap + " + (object) msg.command);
    }
    finally
    {
      msg?.cleanup();
    }
  }

  public void messageNotLogin(Message msg)
  {
    try
    {
      sbyte num = msg.reader().readByte();
      mSystem.LogCMD("---messageNotLogin : " + (object) num);
      if (num != (sbyte) 2)
        return;
      string str = msg.reader().readUTF();
      if (mSystem.isTest)
        str = "88:192.168.1.88:20000:0,53:112.213.85.53:20000:0," + str;
      ServerListScreen.linkDefault = mSystem.clientType != 1 ? str : str;
      ServerListScreen.getServerList(ServerListScreen.linkDefault);
      try
      {
        Panel.CanNapTien = msg.reader().readByte() == (sbyte) 1;
      }
      catch (Exception ex)
      {
      }
    }
    catch (Exception ex)
    {
    }
    finally
    {
      msg?.cleanup();
    }
  }

  public void messageSubCommand(Message msg)
  {
    try
    {
      GameCanvas.debug("SA12", 2);
      sbyte num1 = msg.reader().readByte();
      mSystem.LogCMD("---messageSubCommand : " + (object) num1);
      switch (num1)
      {
        case 0:
          GameCanvas.debug("SA21", 2);
          RadarScr.list = new MyVector();
          Teleport.vTeleport.removeAllElements();
          GameScr.vCharInMap.removeAllElements();
          GameScr.vItemMap.removeAllElements();
          Char.vItemTime.removeAllElements();
          GameScr.loadImg();
          GameScr.currentCharViewInfo = Char.myCharz();
          Char.myCharz().charID = msg.reader().readInt();
          Char.myCharz().ctaskId = (int) msg.reader().readByte();
          Char.myCharz().cgender = (int) msg.reader().readByte();
          Char.myCharz().head = (int) msg.reader().readShort();
          Char.myCharz().cName = msg.reader().readUTF();
          Char.myCharz().cPk = msg.reader().readByte();
          Char.myCharz().cTypePk = msg.reader().readByte();
          Char.myCharz().cPower = msg.reader().readLong();
          Char.myCharz().applyCharLevelPercent();
          Char.myCharz().eff5BuffHp = (int) msg.reader().readShort();
          Char.myCharz().eff5BuffMp = (int) msg.reader().readShort();
          Char.myCharz().nClass = GameScr.nClasss[(int) msg.reader().readByte()];
          Char.myCharz().vSkill.removeAllElements();
          Char.myCharz().vSkillFight.removeAllElements();
          GameScr.gI().dHP = Char.myCharz().cHP;
          GameScr.gI().dMP = Char.myCharz().cMP;
          sbyte num2 = msg.reader().readByte();
          for (sbyte index = 0; (int) index < (int) num2; ++index)
            this.useSkill(Skills.get(msg.reader().readShort()));
          GameScr.gI().sortSkill();
          GameScr.gI().loadSkillShortcut();
          Char.myCharz().xu = msg.reader().readLong();
          Char.myCharz().luongKhoa = msg.reader().readInt();
          Char.myCharz().luong = msg.reader().readInt();
          Char.myCharz().xuStr = mSystem.numberTostring(Char.myCharz().xu);
          Char.myCharz().luongStr = mSystem.numberTostring((long) Char.myCharz().luong);
          Char.myCharz().luongKhoaStr = mSystem.numberTostring((long) Char.myCharz().luongKhoa);
          Char.myCharz().arrItemBody = new Item[(int) msg.reader().readByte()];
          try
          {
            Char.myCharz().setDefaultPart();
            for (int index1 = 0; index1 < Char.myCharz().arrItemBody.Length; ++index1)
            {
              short id = msg.reader().readShort();
              if (id != (short) -1)
              {
                ItemTemplate itemTemplate = ItemTemplates.get(id);
                int type = (int) itemTemplate.type;
                Char.myCharz().arrItemBody[index1] = new Item();
                Char.myCharz().arrItemBody[index1].template = itemTemplate;
                Char.myCharz().arrItemBody[index1].quantity = msg.reader().readInt();
                Char.myCharz().arrItemBody[index1].info = msg.reader().readUTF();
                Char.myCharz().arrItemBody[index1].content = msg.reader().readUTF();
                int length = (int) msg.reader().readUnsignedByte();
                if (length != 0)
                {
                  Char.myCharz().arrItemBody[index1].itemOption = new ItemOption[length];
                  for (int index2 = 0; index2 < Char.myCharz().arrItemBody[index1].itemOption.Length; ++index2)
                  {
                    int optionTemplateId = (int) msg.reader().readUnsignedByte();
                    int num3 = (int) msg.reader().readUnsignedShort();
                    if (optionTemplateId != -1)
                      Char.myCharz().arrItemBody[index1].itemOption[index2] = new ItemOption(optionTemplateId, num3);
                  }
                }
                switch (type)
                {
                  case 0:
                    Res.outz("toi day =======================================" + (object) Char.myCharz().body);
                    Char.myCharz().body = (int) Char.myCharz().arrItemBody[index1].template.part;
                    continue;
                  case 1:
                    Char.myCharz().leg = (int) Char.myCharz().arrItemBody[index1].template.part;
                    Res.outz("toi day =======================================" + (object) Char.myCharz().leg);
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
          catch (Exception ex)
          {
          }
          Char.myCharz().arrItemBag = new Item[(int) msg.reader().readByte()];
          GameScr.hpPotion = 0;
          for (int index3 = 0; index3 < Char.myCharz().arrItemBag.Length; ++index3)
          {
            short id = msg.reader().readShort();
            if (id != (short) -1)
            {
              Char.myCharz().arrItemBag[index3] = new Item();
              Char.myCharz().arrItemBag[index3].template = ItemTemplates.get(id);
              Char.myCharz().arrItemBag[index3].quantity = msg.reader().readInt();
              Char.myCharz().arrItemBag[index3].info = msg.reader().readUTF();
              Char.myCharz().arrItemBag[index3].content = msg.reader().readUTF();
              Char.myCharz().arrItemBag[index3].indexUI = index3;
              sbyte length = msg.reader().readByte();
              if (length != (sbyte) 0)
              {
                Char.myCharz().arrItemBag[index3].itemOption = new ItemOption[(int) length];
                for (int index4 = 0; index4 < Char.myCharz().arrItemBag[index3].itemOption.Length; ++index4)
                {
                  int optionTemplateId = (int) msg.reader().readUnsignedByte();
                  int num4 = (int) msg.reader().readUnsignedShort();
                  if (optionTemplateId != -1)
                  {
                    Char.myCharz().arrItemBag[index3].itemOption[index4] = new ItemOption(optionTemplateId, num4);
                    Char.myCharz().arrItemBag[index3].getCompare();
                  }
                }
              }
              if (Char.myCharz().arrItemBag[index3].template.type == (sbyte) 6)
                GameScr.hpPotion += Char.myCharz().arrItemBag[index3].quantity;
            }
          }
          Char.myCharz().arrItemBox = new Item[(int) msg.reader().readByte()];
          GameCanvas.panel.hasUse = 0;
          for (int index5 = 0; index5 < Char.myCharz().arrItemBox.Length; ++index5)
          {
            short id = msg.reader().readShort();
            if (id != (short) -1)
            {
              Char.myCharz().arrItemBox[index5] = new Item();
              Char.myCharz().arrItemBox[index5].template = ItemTemplates.get(id);
              Char.myCharz().arrItemBox[index5].quantity = msg.reader().readInt();
              Char.myCharz().arrItemBox[index5].info = msg.reader().readUTF();
              Char.myCharz().arrItemBox[index5].content = msg.reader().readUTF();
              Char.myCharz().arrItemBox[index5].itemOption = new ItemOption[(int) msg.reader().readByte()];
              for (int index6 = 0; index6 < Char.myCharz().arrItemBox[index5].itemOption.Length; ++index6)
              {
                int optionTemplateId = (int) msg.reader().readUnsignedByte();
                int num5 = (int) msg.reader().readUnsignedShort();
                if (optionTemplateId != -1)
                {
                  Char.myCharz().arrItemBox[index5].itemOption[index6] = new ItemOption(optionTemplateId, num5);
                  Char.myCharz().arrItemBox[index5].getCompare();
                }
              }
              ++GameCanvas.panel.hasUse;
            }
          }
          Char.myCharz().statusMe = 4;
          GameScr.isViewClanInvite = Rms.loadRMSInt(Char.myCharz().cName + "vci") >= 1;
          short length1 = msg.reader().readShort();
          Char.idHead = new short[(int) length1];
          Char.idAvatar = new short[(int) length1];
          for (int index = 0; index < (int) length1; ++index)
          {
            Char.idHead[index] = msg.reader().readShort();
            Char.idAvatar[index] = msg.reader().readShort();
          }
          for (int index = 0; index < GameScr.info1.charId.Length; ++index)
            GameScr.info1.charId[index] = new int[3];
          GameScr.info1.charId[Char.myCharz().cgender][0] = (int) msg.reader().readShort();
          GameScr.info1.charId[Char.myCharz().cgender][1] = (int) msg.reader().readShort();
          GameScr.info1.charId[Char.myCharz().cgender][2] = (int) msg.reader().readShort();
          Char.myCharz().isNhapThe = msg.reader().readByte() == (sbyte) 1;
          Res.outz("NHAP THE= " + (object) Char.myCharz().isNhapThe);
          GameScr.deltaTime = mSystem.currentTimeMillis() - (long) msg.reader().readInt() * 1000L;
          GameScr.isNewMember = msg.reader().readByte();
          Service.gI().updateCaption((sbyte) Char.myCharz().cgender);
          Service.gI().androidPack();
          try
          {
            Char.myCharz().idAuraEff = msg.reader().readShort();
            Char.myCharz().idEff_Set_Item = (short) msg.reader().readSByte();
            Char.myCharz().idHat = msg.reader().readShort();
            break;
          }
          catch (Exception ex)
          {
            break;
          }
        case 1:
          GameCanvas.debug("SA13", 2);
          Char.myCharz().nClass = GameScr.nClasss[(int) msg.reader().readByte()];
          Char.myCharz().cTiemNang = msg.reader().readLong();
          Char.myCharz().vSkill.removeAllElements();
          Char.myCharz().vSkillFight.removeAllElements();
          Char.myCharz().myskill = (Skill) null;
          break;
        case 2:
          GameCanvas.debug("SA14", 2);
          if (Char.myCharz().statusMe != 14 && Char.myCharz().statusMe != 5)
          {
            Char.myCharz().cHP = Char.myCharz().cHPFull;
            Char.myCharz().cMP = Char.myCharz().cMPFull;
            Cout.LogError2(" ME_LOAD_SKILL");
          }
          Char.myCharz().vSkill.removeAllElements();
          Char.myCharz().vSkillFight.removeAllElements();
          sbyte num6 = msg.reader().readByte();
          for (sbyte index = 0; (int) index < (int) num6; ++index)
            this.useSkill(Skills.get(msg.reader().readShort()));
          GameScr.gI().sortSkill();
          if (!GameScr.isPaintInfoMe)
            break;
          GameScr.indexRow = -1;
          GameScr.gI().left = GameScr.gI().center = (Command) null;
          break;
        case 4:
          GameCanvas.debug("SA23", 2);
          Char.myCharz().xu = msg.reader().readLong();
          Char.myCharz().luong = msg.reader().readInt();
          Char.myCharz().cHP = msg.readInt3Byte();
          Char.myCharz().cMP = msg.readInt3Byte();
          Char.myCharz().luongKhoa = msg.reader().readInt();
          Char.myCharz().xuStr = mSystem.numberTostring(Char.myCharz().xu);
          Char.myCharz().luongStr = mSystem.numberTostring((long) Char.myCharz().luong);
          Char.myCharz().luongKhoaStr = mSystem.numberTostring((long) Char.myCharz().luongKhoa);
          break;
        case 5:
          GameCanvas.debug("SA24", 2);
          int cHp = Char.myCharz().cHP;
          Char.myCharz().cHP = msg.readInt3Byte();
          if (Char.myCharz().cHP > cHp && Char.myCharz().cTypePk != (sbyte) 4)
          {
            GameScr.startFlyText("+" + (object) (Char.myCharz().cHP - cHp) + " " + mResources.HP, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch - 20, 0, -1, mFont.HP);
            SoundMn.gI().HP_MPup();
            if (Char.myCharz().petFollow != null && Char.myCharz().petFollow.smallID == (short) 5003)
              MonsterDart.addMonsterDart(Char.myCharz().petFollow.cmx + (Char.myCharz().petFollow.dir != 1 ? -10 : 10), Char.myCharz().petFollow.cmy + 10, true, -1, -1, Char.myCharz(), 29);
          }
          if (Char.myCharz().cHP < cHp)
            GameScr.startFlyText("-" + (object) (cHp - Char.myCharz().cHP) + " " + mResources.HP, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch - 20, 0, -1, mFont.HP);
          GameScr.gI().dHP = Char.myCharz().cHP;
          if (GameScr.isPaintInfoMe)
            break;
          break;
        case 6:
          GameCanvas.debug("SA25", 2);
          if (Char.myCharz().statusMe == 14 || Char.myCharz().statusMe == 5)
            break;
          int cMp = Char.myCharz().cMP;
          Char.myCharz().cMP = msg.readInt3Byte();
          if (Char.myCharz().cMP > cMp)
          {
            GameScr.startFlyText("+" + (object) (Char.myCharz().cMP - cMp) + " " + mResources.KI, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch - 23, 0, -2, mFont.MP);
            SoundMn.gI().HP_MPup();
            if (Char.myCharz().petFollow != null && Char.myCharz().petFollow.smallID == (short) 5001)
              MonsterDart.addMonsterDart(Char.myCharz().petFollow.cmx + (Char.myCharz().petFollow.dir != 1 ? -10 : 10), Char.myCharz().petFollow.cmy + 10, true, -1, -1, Char.myCharz(), 29);
          }
          if (Char.myCharz().cMP < cMp)
            GameScr.startFlyText("-" + (object) (cMp - Char.myCharz().cMP) + " " + mResources.KI, Char.myCharz().cx, Char.myCharz().cy - Char.myCharz().ch - 23, 0, -2, mFont.MP);
          Res.outz("curr MP= " + (object) Char.myCharz().cMP);
          GameScr.gI().dMP = Char.myCharz().cMP;
          if (GameScr.isPaintInfoMe)
            break;
          break;
        case 7:
          Char charInMap1 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap1 == null)
            break;
          charInMap1.clanID = msg.reader().readInt();
          if (charInMap1.clanID == -2)
            charInMap1.isCopy = true;
          this.readCharInfo(charInMap1, msg);
          try
          {
            charInMap1.idAuraEff = msg.reader().readShort();
            charInMap1.idEff_Set_Item = (short) msg.reader().readSByte();
            charInMap1.idHat = msg.reader().readShort();
            break;
          }
          catch (Exception ex)
          {
            break;
          }
        case 8:
          GameCanvas.debug("SA26", 2);
          Char charInMap2 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap2 == null)
            break;
          charInMap2.cspeed = (int) msg.reader().readByte();
          break;
        case 9:
          GameCanvas.debug("SA27", 2);
          Char charInMap3 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap3 == null)
            break;
          charInMap3.cHP = msg.readInt3Byte();
          charInMap3.cHPFull = msg.readInt3Byte();
          break;
        case 10:
          GameCanvas.debug("SA28", 2);
          Char charInMap4 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap4 == null)
            break;
          charInMap4.cHP = msg.readInt3Byte();
          charInMap4.cHPFull = msg.readInt3Byte();
          charInMap4.eff5BuffHp = (int) msg.reader().readShort();
          charInMap4.eff5BuffMp = (int) msg.reader().readShort();
          charInMap4.wp = (int) msg.reader().readShort();
          if (charInMap4.wp != -1)
            break;
          charInMap4.setDefaultWeapon();
          break;
        case 11:
          GameCanvas.debug("SA29", 2);
          Char charInMap5 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap5 == null)
            break;
          charInMap5.cHP = msg.readInt3Byte();
          charInMap5.cHPFull = msg.readInt3Byte();
          charInMap5.eff5BuffHp = (int) msg.reader().readShort();
          charInMap5.eff5BuffMp = (int) msg.reader().readShort();
          charInMap5.body = (int) msg.reader().readShort();
          if (charInMap5.body != -1)
            break;
          charInMap5.setDefaultBody();
          break;
        case 12:
          GameCanvas.debug("SA30", 2);
          Char charInMap6 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap6 == null)
            break;
          charInMap6.cHP = msg.readInt3Byte();
          charInMap6.cHPFull = msg.readInt3Byte();
          charInMap6.eff5BuffHp = (int) msg.reader().readShort();
          charInMap6.eff5BuffMp = (int) msg.reader().readShort();
          charInMap6.leg = (int) msg.reader().readShort();
          if (charInMap6.leg != -1)
            break;
          charInMap6.setDefaultLeg();
          break;
        case 13:
          GameCanvas.debug("SA31", 2);
          Char charInMap7 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap7 == null)
            break;
          charInMap7.cHP = msg.readInt3Byte();
          charInMap7.cHPFull = msg.readInt3Byte();
          charInMap7.eff5BuffHp = (int) msg.reader().readShort();
          charInMap7.eff5BuffMp = (int) msg.reader().readShort();
          break;
        case 14:
          GameCanvas.debug("SA32", 2);
          Char charInMap8 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap8 == null)
            break;
          charInMap8.cHP = msg.readInt3Byte();
          sbyte num7 = msg.reader().readByte();
          Res.outz("player load hp type= " + (object) num7);
          if (num7 == (sbyte) 1)
          {
            ServerEffect.addServerEffect(11, charInMap8, 5);
            ServerEffect.addServerEffect(104, charInMap8, 4);
          }
          try
          {
            charInMap8.cHPFull = msg.readInt3Byte();
            break;
          }
          catch (Exception ex)
          {
            break;
          }
        case 15:
          GameCanvas.debug("SA33", 2);
          Char charInMap9 = GameScr.findCharInMap(msg.reader().readInt());
          if (charInMap9 == null)
            break;
          charInMap9.cHP = msg.readInt3Byte();
          charInMap9.cHPFull = msg.readInt3Byte();
          charInMap9.cx = (int) msg.reader().readShort();
          charInMap9.cy = (int) msg.reader().readShort();
          charInMap9.statusMe = 1;
          charInMap9.cp3 = 3;
          ServerEffect.addServerEffect(109, charInMap9, 2);
          break;
        case 19:
          GameCanvas.debug("SA17", 2);
          Char.myCharz().boxSort();
          break;
        case 21:
          GameCanvas.debug("SA19", 2);
          int num8 = msg.reader().readInt();
          Char.myCharz().xuInBox -= num8;
          Char.myCharz().xu += (long) num8;
          Char.myCharz().xuStr = mSystem.numberTostring(Char.myCharz().xu);
          break;
        case 23:
          short skillId = msg.reader().readShort();
          Skill skill1 = Skills.get(skillId);
          this.useSkill(skill1);
          if (skillId == (short) 0 || skillId == (short) 14 || skillId == (short) 28)
            break;
          GameScr.info1.addInfo(mResources.LEARN_SKILL + " " + skill1.template.name, 0);
          break;
        case 35:
          GameCanvas.debug("SY3", 2);
          int charId1 = msg.reader().readInt();
          Res.outz("CID = " + (object) charId1);
          if (TileMap.mapID == 130)
            GameScr.gI().starVS();
          if (charId1 == Char.myCharz().charID)
          {
            Char.myCharz().cTypePk = msg.reader().readByte();
            if (GameScr.gI().isVS() && Char.myCharz().cTypePk != (sbyte) 0)
              GameScr.gI().starVS();
            Res.outz("type pk= " + (object) Char.myCharz().cTypePk);
            Char.myCharz().npcFocus = (Npc) null;
            if (!GameScr.gI().isMeCanAttackMob(Char.myCharz().mobFocus))
              Char.myCharz().mobFocus = (Mob) null;
            Char.myCharz().itemFocus = (ItemMap) null;
          }
          else
          {
            Char charInMap10 = GameScr.findCharInMap(charId1);
            if (charInMap10 != null)
            {
              Res.outz("type pk= " + (object) charInMap10.cTypePk);
              charInMap10.cTypePk = msg.reader().readByte();
              if (charInMap10.isAttacPlayerStatus())
                Char.myCharz().charFocus = charInMap10;
            }
          }
          for (int charId2 = 0; charId2 < GameScr.vCharInMap.size(); ++charId2)
          {
            Char charInMap11 = GameScr.findCharInMap(charId2);
            if (charInMap11 != null && charInMap11.cTypePk != (sbyte) 0 && (int) charInMap11.cTypePk == (int) Char.myCharz().cTypePk)
            {
              if (!Char.myCharz().mobFocus.isMobMe)
                Char.myCharz().mobFocus = (Mob) null;
              Char.myCharz().npcFocus = (Npc) null;
              Char.myCharz().itemFocus = (ItemMap) null;
              break;
            }
          }
          Res.outz("update type pk= ");
          break;
        default:
          switch ((int) num1 - 61)
          {
            case 0:
              string str1 = msg.reader().readUTF();
              sbyte[] data = new sbyte[msg.reader().readInt()];
              msg.reader().read(ref data);
              if (data.Length == 0)
                data = (sbyte[]) null;
              switch (str1)
              {
                case "KSkill":
                  GameScr.gI().onKSkill(data);
                  return;
                case "OSkill":
                  GameScr.gI().onOSkill(data);
                  return;
                case "CSkill":
                  GameScr.gI().onCSkill(data);
                  return;
                default:
                  return;
              }
            case 1:
              Res.outz("ME UPDATE SKILL");
              Skill skill2 = Skills.get(msg.reader().readShort());
              for (int index = 0; index < Char.myCharz().vSkill.size(); ++index)
              {
                if ((int) ((Skill) Char.myCharz().vSkill.elementAt(index)).template.id == (int) skill2.template.id)
                {
                  Char.myCharz().vSkill.setElementAt((object) skill2, index);
                  break;
                }
              }
              for (int index = 0; index < Char.myCharz().vSkillFight.size(); ++index)
              {
                if ((int) ((Skill) Char.myCharz().vSkillFight.elementAt(index)).template.id == (int) skill2.template.id)
                {
                  Char.myCharz().vSkillFight.setElementAt((object) skill2, index);
                  break;
                }
              }
              for (int index = 0; index < GameScr.onScreenSkill.Length; ++index)
              {
                if (GameScr.onScreenSkill[index] != null && (int) GameScr.onScreenSkill[index].template.id == (int) skill2.template.id)
                {
                  GameScr.onScreenSkill[index] = skill2;
                  break;
                }
              }
              for (int index = 0; index < GameScr.keySkill.Length; ++index)
              {
                if (GameScr.keySkill[index] != null && (int) GameScr.keySkill[index].template.id == (int) skill2.template.id)
                {
                  GameScr.keySkill[index] = skill2;
                  break;
                }
              }
              if ((int) Char.myCharz().myskill.template.id == (int) skill2.template.id)
                Char.myCharz().myskill = skill2;
              GameScr.info1.addInfo(mResources.hasJustUpgrade1 + skill2.template.name + mResources.hasJustUpgrade2 + (object) skill2.point, 0);
              return;
            case 2:
              sbyte num9 = msg.reader().readByte();
              if (num9 <= (sbyte) 0)
                return;
              InfoDlg.showWait();
              MyVector vPlayerMenu = GameCanvas.panel.vPlayerMenu;
              for (int index = 0; index < (int) num9; ++index)
              {
                string caption = msg.reader().readUTF();
                string str2 = msg.reader().readUTF();
                short num10 = msg.reader().readShort();
                Char.myCharz().charFocus.menuSelect = (int) num10;
                vPlayerMenu.addElement((object) new Command(caption, 11115, (object) Char.myCharz().charFocus)
                {
                  caption2 = str2
                });
              }
              InfoDlg.hide();
              GameCanvas.panel.setTabPlayerMenu();
              return;
            default:
              return;
          }
      }
    }
    catch (Exception ex)
    {
      Cout.println("Loi tai Sub : " + ex.ToString());
    }
    finally
    {
      msg?.cleanup();
    }
  }

  private void useSkill(Skill skill)
  {
    if (Char.myCharz().myskill == null)
      Char.myCharz().myskill = skill;
    else if (skill.template.Equals((object) Char.myCharz().myskill.template))
      Char.myCharz().myskill = skill;
    Char.myCharz().vSkill.addElement((object) skill);
    if (skill.template.type != 1 && skill.template.type != 4 && skill.template.type != 2 && skill.template.type != 3 || skill.template.maxPoint != 0 && (skill.template.maxPoint <= 0 || skill.point <= 0))
      return;
    if ((int) skill.template.id == Char.myCharz().skillTemplateId)
      Service.gI().selectSkill(Char.myCharz().skillTemplateId);
    Char.myCharz().vSkillFight.addElement((object) skill);
  }

  public bool readCharInfo(Char c, Message msg)
  {
    try
    {
      c.clevel = (int) msg.reader().readByte();
      c.isInvisiblez = msg.reader().readBoolean();
      c.cTypePk = msg.reader().readByte();
      Res.outz("ADD TYPE PK= " + (object) c.cTypePk + " to player " + (object) c.charID + " @@ " + c.cName);
      c.nClass = GameScr.nClasss[(int) msg.reader().readByte()];
      c.cgender = (int) msg.reader().readByte();
      c.head = (int) msg.reader().readShort();
      c.cName = msg.reader().readUTF();
      c.cHP = msg.readInt3Byte();
      c.dHP = c.cHP;
      if (c.cHP == 0)
        c.statusMe = 14;
      c.cHPFull = msg.readInt3Byte();
      if (c.cy >= TileMap.pxh - 100)
        c.isFlyUp = true;
      c.body = (int) msg.reader().readShort();
      c.leg = (int) msg.reader().readShort();
      c.bag = (int) msg.reader().readUnsignedByte();
      Res.outz(" body= " + (object) c.body + " leg= " + (object) c.leg + " bag=" + (object) c.bag + "BAG ==" + (object) c.bag + "*********************************");
      c.isShadown = true;
      msg.reader().readByte();
      if (c.wp == -1)
        c.setDefaultWeapon();
      if (c.body == -1)
        c.setDefaultBody();
      if (c.leg == -1)
        c.setDefaultLeg();
      c.cx = (int) msg.reader().readShort();
      c.cy = (int) msg.reader().readShort();
      c.xSd = c.cx;
      c.ySd = c.cy;
      c.eff5BuffHp = (int) msg.reader().readShort();
      c.eff5BuffMp = (int) msg.reader().readShort();
      int num = (int) msg.reader().readByte();
      for (int index = 0; index < num; ++index)
      {
        EffectChar o = new EffectChar(msg.reader().readByte(), msg.reader().readInt(), msg.reader().readInt(), msg.reader().readShort());
        c.vEff.addElement((object) o);
        if (o.template.type == (sbyte) 12 || o.template.type == (sbyte) 11)
          c.isInvisiblez = true;
      }
      return true;
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
    return false;
  }

  private void readGetImgByName(Message msg)
  {
    try
    {
      string str = msg.reader().readUTF();
      sbyte nFrame = msg.reader().readByte();
      sbyte[] numArray = NinjaUtil.readByteArray(msg);
      Image image = this.createImage(numArray);
      ImgByName.SetImage(str, image, nFrame);
      if (numArray == null)
        return;
      ImgByName.saveRMS(str, nFrame, numArray);
    }
    catch (Exception ex)
    {
    }
  }

  private void createItemNew(myReader d)
  {
    try
    {
      this.loadItemNew(d, (sbyte) -1, true);
    }
    catch (Exception ex)
    {
    }
  }

  private void loadItemNew(myReader d, sbyte type, bool isSave)
  {
    try
    {
      d.mark(100000);
      GameScr.vcItem = d.readByte();
      type = d.readByte();
      switch (type)
      {
        case 0:
          GameScr.gI().iOptionTemplates = new ItemOptionTemplate[(int) d.readUnsignedByte()];
          for (int index = 0; index < GameScr.gI().iOptionTemplates.Length; ++index)
          {
            GameScr.gI().iOptionTemplates[index] = new ItemOptionTemplate();
            GameScr.gI().iOptionTemplates[index].id = index;
            GameScr.gI().iOptionTemplates[index].name = d.readUTF();
            GameScr.gI().iOptionTemplates[index].type = (int) d.readByte();
          }
          if (!isSave)
            break;
          d.reset();
          sbyte[] data1 = new sbyte[d.available()];
          d.readFully(ref data1);
          Rms.saveRMS("NRitem0", data1);
          break;
        case 1:
          ItemTemplates.itemTemplates.clear();
          int num1 = (int) d.readShort();
          for (int templateID = 0; templateID < num1; ++templateID)
            ItemTemplates.add(new ItemTemplate((short) templateID, d.readByte(), d.readByte(), d.readUTF(), d.readUTF(), d.readByte(), d.readInt(), d.readShort(), d.readShort(), d.readBoolean()));
          if (!isSave)
            break;
          d.reset();
          sbyte[] data2 = new sbyte[d.available()];
          d.readFully(ref data2);
          Rms.saveRMS("NRitem1", data2);
          break;
        case 2:
          int num2 = (int) d.readShort();
          int num3 = (int) d.readShort();
          for (int templateID = num2; templateID < num3; ++templateID)
            ItemTemplates.add(new ItemTemplate((short) templateID, d.readByte(), d.readByte(), d.readUTF(), d.readUTF(), d.readByte(), d.readInt(), d.readShort(), d.readShort(), d.readBoolean()));
          if (!isSave)
            break;
          d.reset();
          sbyte[] data3 = new sbyte[d.available()];
          d.readFully(ref data3);
          Rms.saveRMS("NRitem2", data3);
          Rms.saveRMS("NRitemVersion", new sbyte[1]
          {
            GameScr.vcItem
          });
          LoginScr.isUpdateItem = false;
          if ((int) GameScr.vsData != (int) GameScr.vcData || (int) GameScr.vsMap != (int) GameScr.vcMap || (int) GameScr.vsSkill != (int) GameScr.vcSkill || (int) GameScr.vsItem != (int) GameScr.vcItem)
            break;
          GameScr.gI().readDart();
          GameScr.gI().readEfect();
          GameScr.gI().readArrow();
          GameScr.gI().readSkill();
          Service.gI().clientOk();
          break;
        case 100:
          Char.Arr_Head_2Fr = this.readArrHead(d);
          if (!isSave)
            break;
          d.reset();
          sbyte[] data4 = new sbyte[d.available()];
          d.readFully(ref data4);
          Rms.saveRMS("NRitem100", data4);
          break;
      }
    }
    catch (Exception ex)
    {
      ex.ToString();
    }
  }

  private void readFrameBoss(Message msg, int mobTemplateId)
  {
    try
    {
      int length1 = (int) msg.reader().readByte();
      int[][] v = new int[length1][];
      for (int index1 = 0; index1 < length1; ++index1)
      {
        int length2 = (int) msg.reader().readByte();
        v[index1] = new int[length2];
        for (int index2 = 0; index2 < length2; ++index2)
          v[index1][index2] = (int) msg.reader().readByte();
      }
      Controller.frameHT_NEWBOSS.put((object) (mobTemplateId.ToString() + string.Empty), (object) v);
    }
    catch (Exception ex)
    {
    }
  }

  private int[][] readArrHead(myReader d)
  {
    int[][] numArray = new int[1][]
    {
      new int[2]{ 542, 543 }
    };
    try
    {
      numArray = new int[(int) d.readShort()][];
      for (int index1 = 0; index1 < numArray.Length; ++index1)
      {
        int length = (int) d.readByte();
        numArray[index1] = new int[length];
        for (int index2 = 0; index2 < length; ++index2)
          numArray[index1][index2] = (int) d.readShort();
      }
    }
    catch (Exception ex)
    {
    }
    return numArray;
  }

  public void phuban_Info(Message msg)
  {
    try
    {
      sbyte type_PB = msg.reader().readByte();
      if (type_PB != (sbyte) 0)
        return;
      this.readPhuBan_CHIENTRUONGNAMEK(msg, (int) type_PB);
    }
    catch (Exception ex)
    {
    }
  }

  private void readPhuBan_CHIENTRUONGNAMEK(Message msg, int type_PB)
  {
    try
    {
      switch (msg.reader().readByte())
      {
        case 0:
          short idmapPaint = msg.reader().readShort();
          string nameTeam1 = msg.reader().readUTF();
          string nameTeam2 = msg.reader().readUTF();
          int maxPoint = msg.reader().readInt();
          short timeSecond1 = msg.reader().readShort();
          int num1 = (int) msg.reader().readByte();
          GameScr.phuban_Info = new InfoPhuBan(type_PB, idmapPaint, nameTeam1, nameTeam2, maxPoint, timeSecond1);
          GameScr.phuban_Info.maxLife = num1;
          GameScr.phuban_Info.updateLife(type_PB, 0, 0);
          break;
        case 1:
          int pointTeam1 = msg.reader().readInt();
          int pointTeam2 = msg.reader().readInt();
          if (GameScr.phuban_Info == null)
            break;
          GameScr.phuban_Info.updatePoint(type_PB, pointTeam1, pointTeam2);
          break;
        case 2:
          sbyte num2 = msg.reader().readByte();
          short type = 0;
          short num3 = -1;
          switch (num2)
          {
            case 1:
              type = (short) 1;
              num3 = (short) 3;
              break;
            case 2:
              type = (short) 2;
              break;
          }
          short subtype = -1;
          GameScr.phuban_Info = (InfoPhuBan) null;
          GameScr.addEffectEnd((int) type, (int) subtype, GameCanvas.hw, GameCanvas.hh, 0, 0);
          break;
        case 4:
          int lifeTeam1 = (int) msg.reader().readByte();
          int lifeTeam2 = (int) msg.reader().readByte();
          if (GameScr.phuban_Info == null)
            break;
          GameScr.phuban_Info.updateLife(type_PB, lifeTeam1, lifeTeam2);
          break;
        case 5:
          short timeSecond2 = msg.reader().readShort();
          if (GameScr.phuban_Info == null)
            break;
          GameScr.phuban_Info.updateTime(type_PB, timeSecond2);
          break;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void read_opt(Message msg)
  {
    try
    {
      if (msg.reader().readByte() != (sbyte) 0)
        return;
      short num = msg.reader().readShort();
      Char.myCharz().idHat = num;
      SoundMn.gI().getStrOption();
    }
    catch (Exception ex)
    {
    }
  }
}
