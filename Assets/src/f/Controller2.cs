// Decompiled with JetBrains decompiler
// Type: Assets.src.f.Controller2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using Assets.src.g;
using System;

namespace Assets.src.f
{
  internal class Controller2
  {
    public static void readMessage(Message msg)
    {
      try
      {
        Res.outz("cmd=" + (object) msg.command);
        sbyte command = msg.command;
        switch ((int) command + 128)
        {
          case 0:
            Controller2.readInfoEffChar(msg);
            break;
          case 1:
            Controller2.readLuckyRound(msg);
            break;
          case 2:
            sbyte num1 = msg.reader().readByte();
            Res.outz("type quay= " + (object) num1);
            if (num1 == (sbyte) 1)
            {
              msg.reader().readByte();
              string num2 = msg.reader().readUTF();
              string finish = msg.reader().readUTF();
              GameScr.gI().showWinNumber(num2, finish);
            }
            if (num1 != (sbyte) 0)
              break;
            GameScr.gI().showYourNumber(msg.reader().readUTF());
            break;
          case 3:
            ChatTextField.gI().isShow = false;
            string title = msg.reader().readUTF();
            Res.outz("titile= " + title);
            sbyte type1 = msg.reader().readByte();
            ClientInput.gI().setInput((int) type1, title);
            for (int index = 0; index < (int) type1; ++index)
            {
              ClientInput.gI().tf[index].name = msg.reader().readUTF();
              sbyte num3 = msg.reader().readByte();
              if (num3 == (sbyte) 0)
                ClientInput.gI().tf[index].setIputType(TField.INPUT_TYPE_NUMERIC);
              if (num3 == (sbyte) 1)
                ClientInput.gI().tf[index].setIputType(TField.INPUT_TYPE_ANY);
              if (num3 == (sbyte) 2)
                ClientInput.gI().tf[index].setIputType(TField.INPUT_TYPE_PASSWORD);
            }
            break;
          case 4:
            sbyte num4 = msg.reader().readByte();
            sbyte num5 = msg.reader().readByte();
            if (num5 == (sbyte) 0)
            {
              if (num4 == (sbyte) 2)
              {
                int charId = msg.reader().readInt();
                if (charId == Char.myCharz().charID)
                  Char.myCharz().removeEffect();
                else if (GameScr.findCharInMap(charId) != null)
                  GameScr.findCharInMap(charId).removeEffect();
              }
              int num6 = (int) msg.reader().readUnsignedByte();
              int charId1 = msg.reader().readInt();
              if (num6 == 32)
              {
                if (num4 == (sbyte) 1)
                {
                  int charId2 = msg.reader().readInt();
                  if (charId1 == Char.myCharz().charID)
                  {
                    Char.myCharz().holdEffID = num6;
                    GameScr.findCharInMap(charId2).setHoldChar(Char.myCharz());
                  }
                  else if (GameScr.findCharInMap(charId1) != null && charId2 != Char.myCharz().charID)
                  {
                    GameScr.findCharInMap(charId1).holdEffID = num6;
                    GameScr.findCharInMap(charId2).setHoldChar(GameScr.findCharInMap(charId1));
                  }
                  else if (GameScr.findCharInMap(charId1) != null && charId2 == Char.myCharz().charID)
                  {
                    GameScr.findCharInMap(charId1).holdEffID = num6;
                    Char.myCharz().setHoldChar(GameScr.findCharInMap(charId1));
                  }
                }
                else if (charId1 == Char.myCharz().charID)
                  Char.myCharz().removeHoleEff();
                else if (GameScr.findCharInMap(charId1) != null)
                  GameScr.findCharInMap(charId1).removeHoleEff();
              }
              if (num6 == 33)
              {
                if (num4 == (sbyte) 1)
                {
                  if (charId1 == Char.myCharz().charID)
                    Char.myCharz().protectEff = true;
                  else if (GameScr.findCharInMap(charId1) != null)
                    GameScr.findCharInMap(charId1).protectEff = true;
                }
                else if (charId1 == Char.myCharz().charID)
                  Char.myCharz().removeProtectEff();
                else if (GameScr.findCharInMap(charId1) != null)
                  GameScr.findCharInMap(charId1).removeProtectEff();
              }
              if (num6 == 39)
              {
                if (num4 == (sbyte) 1)
                {
                  if (charId1 == Char.myCharz().charID)
                    Char.myCharz().huytSao = true;
                  else if (GameScr.findCharInMap(charId1) != null)
                    GameScr.findCharInMap(charId1).huytSao = true;
                }
                else if (charId1 == Char.myCharz().charID)
                  Char.myCharz().removeHuytSao();
                else if (GameScr.findCharInMap(charId1) != null)
                  GameScr.findCharInMap(charId1).removeHuytSao();
              }
              if (num6 == 40)
              {
                if (num4 == (sbyte) 1)
                {
                  if (charId1 == Char.myCharz().charID)
                    Char.myCharz().blindEff = true;
                  else if (GameScr.findCharInMap(charId1) != null)
                    GameScr.findCharInMap(charId1).blindEff = true;
                }
                else if (charId1 == Char.myCharz().charID)
                  Char.myCharz().removeBlindEff();
                else if (GameScr.findCharInMap(charId1) != null)
                  GameScr.findCharInMap(charId1).removeBlindEff();
              }
              if (num6 == 41)
              {
                if (num4 == (sbyte) 1)
                {
                  if (charId1 == Char.myCharz().charID)
                    Char.myCharz().sleepEff = true;
                  else if (GameScr.findCharInMap(charId1) != null)
                    GameScr.findCharInMap(charId1).sleepEff = true;
                }
                else if (charId1 == Char.myCharz().charID)
                  Char.myCharz().removeSleepEff();
                else if (GameScr.findCharInMap(charId1) != null)
                  GameScr.findCharInMap(charId1).removeSleepEff();
              }
              if (num6 == 42)
              {
                if (num4 == (sbyte) 1)
                {
                  if (charId1 == Char.myCharz().charID)
                    Char.myCharz().stone = true;
                }
                else if (charId1 == Char.myCharz().charID)
                  Char.myCharz().stone = false;
              }
            }
            if (num5 != (sbyte) 1)
              break;
            int num7 = (int) msg.reader().readUnsignedByte();
            sbyte mobIndex = msg.reader().readByte();
            Res.outz("modbHoldID= " + (object) mobIndex + " skillID= " + (object) num7 + "eff ID= " + (object) num4);
            if (num7 == 32)
            {
              if (num4 == (sbyte) 1)
              {
                int charId = msg.reader().readInt();
                if (charId == Char.myCharz().charID)
                {
                  GameScr.findMobInMap(mobIndex).holdEffID = num7;
                  Char.myCharz().setHoldMob(GameScr.findMobInMap(mobIndex));
                }
                else if (GameScr.findCharInMap(charId) != null)
                {
                  GameScr.findMobInMap(mobIndex).holdEffID = num7;
                  GameScr.findCharInMap(charId).setHoldMob(GameScr.findMobInMap(mobIndex));
                }
              }
              else
                GameScr.findMobInMap(mobIndex).removeHoldEff();
            }
            if (num7 == 40)
            {
              if (num4 == (sbyte) 1)
                GameScr.findMobInMap(mobIndex).blindEff = true;
              else
                GameScr.findMobInMap(mobIndex).removeBlindEff();
            }
            if (num7 != 41)
              break;
            if (num4 == (sbyte) 1)
            {
              GameScr.findMobInMap(mobIndex).sleepEff = true;
              break;
            }
            GameScr.findMobInMap(mobIndex).removeSleepEff();
            break;
          case 5:
            int charId3 = msg.reader().readInt();
            if (GameScr.findCharInMap(charId3) == null)
              break;
            GameScr.findCharInMap(charId3).perCentMp = (int) msg.reader().readByte();
            break;
          case 6:
            Npc npcInMap = GameScr.findNPCInMap(msg.reader().readShort());
            sbyte length1 = msg.reader().readByte();
            npcInMap.duahau = new int[(int) length1];
            Res.outz("N DUA HAU= " + (object) length1);
            for (int index = 0; index < (int) length1; ++index)
              npcInMap.duahau[index] = (int) msg.reader().readShort();
            npcInMap.setStatus(msg.reader().readByte(), msg.reader().readInt());
            break;
          case 7:
            Service.logMap = mSystem.currentTimeMillis() - Service.curCheckMap;
            Service.gI().sendCheckMap();
            break;
          case 8:
            Service.logController = mSystem.currentTimeMillis() - Service.curCheckController;
            Service.gI().sendCheckController();
            break;
          case 9:
            Char.myCharz().rank = msg.reader().readInt();
            break;
          case 11:
            GameScr.gI().tMabuEff = 0;
            GameScr.gI().percentMabu = msg.reader().readByte();
            if (GameScr.gI().percentMabu == (sbyte) 100)
              GameScr.gI().mabuEff = true;
            if (GameScr.gI().percentMabu != (sbyte) 101)
              break;
            Npc.mabuEff = true;
            break;
          case 12:
            GameScr.canAutoPlay = msg.reader().readByte() == (sbyte) 1;
            break;
          case 13:
            Char.myCharz().setPowerInfo(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
            break;
          case 15:
            sbyte[] numArray = new sbyte[10];
            for (int index = 0; index < 10; ++index)
            {
              numArray[index] = msg.reader().readByte();
              Res.outz("vlue i= " + (object) numArray[index]);
            }
            GameScr.gI().onKSkill(numArray);
            GameScr.gI().onOSkill(numArray);
            GameScr.gI().onCSkill(numArray);
            break;
          case 17:
            short num8 = msg.reader().readShort();
            ImageSource.vSource = new MyVector();
            for (int index = 0; index < (int) num8; ++index)
            {
              string ID = msg.reader().readUTF();
              sbyte version = msg.reader().readByte();
              ImageSource.vSource.addElement((object) new ImageSource(ID, version));
            }
            ImageSource.checkRMS();
            ImageSource.saveRMS();
            break;
          case 18:
            sbyte num9 = msg.reader().readByte();
            if (num9 == (sbyte) 1)
            {
              int id = msg.reader().readInt();
              sbyte[] data = Rms.loadRMS(id.ToString() + string.Empty);
              if (data == null)
                Service.gI().sendServerData((sbyte) 1, -1, (sbyte[]) null);
              else
                Service.gI().sendServerData((sbyte) 1, id, data);
            }
            if (num9 != (sbyte) 0)
              break;
            int num10 = msg.reader().readInt();
            short length2 = msg.reader().readShort();
            sbyte[] data1 = new sbyte[(int) length2];
            msg.reader().read(ref data1, 0, (int) length2);
            Rms.saveRMS(num10.ToString() + string.Empty, data1);
            break;
          case 22:
            short num11 = msg.reader().readShort();
            int num12 = (int) msg.reader().readShort();
            if (ItemTime.isExistItem((int) num11))
            {
              ItemTime.getItemById((int) num11).initTime(num12);
              break;
            }
            ItemTime o1 = new ItemTime(num11, num12);
            Char.vItemTime.addElement((object) o1);
            break;
          case 23:
            TransportScr.gI().time = (short) 0;
            TransportScr.gI().maxTime = msg.reader().readShort();
            TransportScr.gI().last = TransportScr.gI().curr = mSystem.currentTimeMillis();
            TransportScr.gI().type = msg.reader().readByte();
            TransportScr.gI().switchToMe();
            break;
          case 25:
            switch (msg.reader().readByte())
            {
              case 0:
                GameCanvas.panel.vFlag.removeAllElements();
                sbyte num13 = msg.reader().readByte();
                for (int index1 = 0; index1 < (int) num13; ++index1)
                {
                  Item o2 = new Item();
                  short id = msg.reader().readShort();
                  if (id != (short) -1)
                  {
                    o2.template = ItemTemplates.get(id);
                    sbyte length3 = msg.reader().readByte();
                    if (length3 != (sbyte) -1)
                    {
                      o2.itemOption = new ItemOption[(int) length3];
                      for (int index2 = 0; index2 < o2.itemOption.Length; ++index2)
                      {
                        int optionTemplateId = (int) msg.reader().readUnsignedByte();
                        int num14 = (int) msg.reader().readUnsignedShort();
                        if (optionTemplateId != -1)
                          o2.itemOption[index2] = new ItemOption(optionTemplateId, num14);
                      }
                    }
                  }
                  GameCanvas.panel.vFlag.addElement((object) o2);
                }
                GameCanvas.panel.setTypeFlag();
                GameCanvas.panel.show();
                return;
              case 1:
                int num15 = msg.reader().readInt();
                sbyte cflag = msg.reader().readByte();
                Res.outz("---------------actionFlag1:  " + (object) num15 + " : " + (object) cflag);
                if (num15 == Char.myCharz().charID)
                  Char.myCharz().cFlag = cflag;
                else if (GameScr.findCharInMap(num15) != null)
                  GameScr.findCharInMap(num15).cFlag = cflag;
                GameScr.gI().getFlagImage(num15, cflag);
                return;
              case 2:
                sbyte num16 = msg.reader().readByte();
                int num17 = (int) msg.reader().readShort();
                GameScr.vFlag.addElement((object) new PKFlag()
                {
                  cflag = num16,
                  IDimageFlag = num17
                });
                for (int index = 0; index < GameScr.vFlag.size(); ++index)
                {
                  PKFlag pkFlag = (PKFlag) GameScr.vFlag.elementAt(index);
                  Res.outz("i: " + (object) index + "  cflag: " + (object) pkFlag.cflag + "   IDimageFlag: " + (object) pkFlag.IDimageFlag);
                }
                for (int index = 0; index < GameScr.vCharInMap.size(); ++index)
                {
                  Char @char = (Char) GameScr.vCharInMap.elementAt(index);
                  if (@char != null && (int) @char.cFlag == (int) num16)
                    @char.flagImage = num17;
                }
                if ((int) Char.myCharz().cFlag != (int) num16)
                  return;
                Char.myCharz().flagImage = num17;
                return;
              default:
                return;
            }
          case 26:
            switch (msg.reader().readByte())
            {
              case 0:
                return;
              case 1:
                GameCanvas.loginScr.isLogin2 = false;
                Service.gI().login(Rms.loadRMSString("acc"), Rms.loadRMSString("pass"), GameMidlet.VERSION, (sbyte) 0);
                LoginScr.isLoggingIn = true;
                return;
              default:
                return;
            }
          case 27:
            GameCanvas.loginScr.isLogin2 = true;
            GameCanvas.connect();
            string str = msg.reader().readUTF();
            Rms.saveRMSString("userAo" + (object) ServerListScreen.ipSelect, str);
            Service.gI().setClientType();
            Service.gI().login(str, string.Empty, GameMidlet.VERSION, (sbyte) 1);
            break;
          case 28:
            InfoDlg.hide();
            bool flag = false;
            if (GameCanvas.w > 2 * Panel.WIDTH_PANEL)
              flag = true;
            sbyte index3 = msg.reader().readByte();
            Res.outz("t Indxe= " + (object) index3);
            GameCanvas.panel.maxPageShop[(int) index3] = (int) msg.reader().readByte();
            GameCanvas.panel.currPageShop[(int) index3] = (int) msg.reader().readByte();
            Res.outz("max page= " + (object) GameCanvas.panel.maxPageShop[(int) index3] + " curr page= " + (object) GameCanvas.panel.currPageShop[(int) index3]);
            int length4 = (int) msg.reader().readUnsignedByte();
            Char.myCharz().arrItemShop[(int) index3] = new Item[length4];
            for (int index4 = 0; index4 < length4; ++index4)
            {
              short id = msg.reader().readShort();
              if (id != (short) -1)
              {
                Res.outz("template id= " + (object) id);
                Char.myCharz().arrItemShop[(int) index3][index4] = new Item();
                Char.myCharz().arrItemShop[(int) index3][index4].template = ItemTemplates.get(id);
                Char.myCharz().arrItemShop[(int) index3][index4].itemId = (int) msg.reader().readShort();
                Char.myCharz().arrItemShop[(int) index3][index4].buyCoin = msg.reader().readInt();
                Char.myCharz().arrItemShop[(int) index3][index4].buyGold = msg.reader().readInt();
                Char.myCharz().arrItemShop[(int) index3][index4].buyType = msg.reader().readByte();
                Char.myCharz().arrItemShop[(int) index3][index4].quantity = msg.reader().readInt();
                Char.myCharz().arrItemShop[(int) index3][index4].isMe = msg.reader().readByte();
                Panel.strWantToBuy = mResources.say_wat_do_u_want_to_buy;
                sbyte length5 = msg.reader().readByte();
                if (length5 != (sbyte) -1)
                {
                  Char.myCharz().arrItemShop[(int) index3][index4].itemOption = new ItemOption[(int) length5];
                  for (int index5 = 0; index5 < Char.myCharz().arrItemShop[(int) index3][index4].itemOption.Length; ++index5)
                  {
                    int optionTemplateId = (int) msg.reader().readUnsignedByte();
                    int num18 = (int) msg.reader().readUnsignedShort();
                    if (optionTemplateId != -1)
                    {
                      Char.myCharz().arrItemShop[(int) index3][index4].itemOption[index5] = new ItemOption(optionTemplateId, num18);
                      Char.myCharz().arrItemShop[(int) index3][index4].compare = GameCanvas.panel.getCompare(Char.myCharz().arrItemShop[(int) index3][index4]);
                    }
                  }
                }
                if (msg.reader().readByte() == (sbyte) 1)
                {
                  int headTemp = (int) msg.reader().readShort();
                  int bodyTemp = (int) msg.reader().readShort();
                  int legTemp = (int) msg.reader().readShort();
                  int bagTemp = (int) msg.reader().readShort();
                  Char.myCharz().arrItemShop[(int) index3][index4].setPartTemp(headTemp, bodyTemp, legTemp, bagTemp);
                }
              }
            }
            if (flag)
              GameCanvas.panel2.setTabKiGui();
            GameCanvas.panel.setTabShop();
            GameCanvas.panel.cmy = GameCanvas.panel.cmtoY = 0;
            break;
          case 39:
            GameCanvas.open3Hour = msg.reader().readByte() == (sbyte) 1;
            break;
          default:
            switch (command)
            {
              case 121:
                mSystem.publicID = msg.reader().readUTF();
                mSystem.strAdmob = msg.reader().readUTF();
                Res.outz("SHOW AD public ID= " + mSystem.publicID);
                mSystem.createAdmob();
                return;
              case 122:
                short num19 = msg.reader().readShort();
                Res.outz("second login = " + (object) num19);
                LoginScr.timeLogin = num19;
                LoginScr.currTimeLogin = LoginScr.lastTimeLogin = mSystem.currentTimeMillis();
                GameCanvas.endDlg();
                return;
              case 123:
                Res.outz("SET POSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSss");
                int charId4 = msg.reader().readInt();
                short xPos = msg.reader().readShort();
                short yPos = msg.reader().readShort();
                sbyte typePos = msg.reader().readByte();
                Char c = (Char) null;
                if (charId4 == Char.myCharz().charID)
                  c = Char.myCharz();
                else if (GameScr.findCharInMap(charId4) != null)
                  c = GameScr.findCharInMap(charId4);
                if (c == null)
                  return;
                ServerEffect.addServerEffect(typePos != (sbyte) 0 ? 173 : 60, c, 1);
                c.setPos(xPos, yPos, typePos);
                return;
              case 124:
                short id1 = msg.reader().readShort();
                string info = msg.reader().readUTF();
                Res.outz("noi chuyen = " + info + "npc ID= " + (object) id1);
                GameScr.findNPCInMap(id1)?.addInfo(info);
                return;
              case 125:
                sbyte fusion = msg.reader().readByte();
                int charId5 = msg.reader().readInt();
                if (charId5 == Char.myCharz().charID)
                {
                  Char.myCharz().setFusion(fusion);
                  return;
                }
                if (GameScr.findCharInMap(charId5) == null)
                  return;
                GameScr.findCharInMap(charId5).setFusion(fusion);
                return;
              case sbyte.MaxValue:
                Controller2.readInfoRada(msg);
                return;
              default:
                switch (command)
                {
                  case 48:
                    ServerListScreen.ipSelect = (int) msg.reader().readByte();
                    GameCanvas.instance.doResetToLoginScr((mScreen) GameCanvas.serverScreen);
                    Session_ME.gI().close();
                    GameCanvas.endDlg();
                    ServerListScreen.waitToLogin = true;
                    return;
                  case 51:
                    Mabu charInMap1 = (Mabu) GameScr.findCharInMap(msg.reader().readInt());
                    sbyte id2 = msg.reader().readByte();
                    short x1 = msg.reader().readShort();
                    short y1 = msg.reader().readShort();
                    sbyte length6 = msg.reader().readByte();
                    Char[] charHit = new Char[(int) length6];
                    int[] damageHit = new int[(int) length6];
                    for (int index6 = 0; index6 < (int) length6; ++index6)
                    {
                      int charId6 = msg.reader().readInt();
                      Res.outz("char ID=" + (object) charId6);
                      charHit[index6] = (Char) null;
                      charHit[index6] = charId6 == Char.myCharz().charID ? Char.myCharz() : GameScr.findCharInMap(charId6);
                      damageHit[index6] = msg.reader().readInt();
                    }
                    charInMap1.setSkill(id2, x1, y1, charHit, damageHit);
                    return;
                  case 52:
                    sbyte num20 = msg.reader().readByte();
                    if (num20 == (sbyte) 1)
                    {
                      int charId7 = msg.reader().readInt();
                      if (charId7 == Char.myCharz().charID)
                      {
                        Char.myCharz().setMabuHold(true);
                        Char.myCharz().cx = (int) msg.reader().readShort();
                        Char.myCharz().cy = (int) msg.reader().readShort();
                      }
                      else
                      {
                        Char charInMap2 = GameScr.findCharInMap(charId7);
                        if (charInMap2 != null)
                        {
                          charInMap2.setMabuHold(true);
                          charInMap2.cx = (int) msg.reader().readShort();
                          charInMap2.cy = (int) msg.reader().readShort();
                        }
                      }
                    }
                    if (num20 == (sbyte) 0)
                    {
                      int charId8 = msg.reader().readInt();
                      if (charId8 == Char.myCharz().charID)
                        Char.myCharz().setMabuHold(false);
                      else
                        GameScr.findCharInMap(charId8)?.setMabuHold(false);
                    }
                    if (num20 == (sbyte) 2)
                    {
                      int charId9 = msg.reader().readInt();
                      int id3 = msg.reader().readInt();
                      ((Mabu) GameScr.findCharInMap(charId9)).eat(id3);
                    }
                    if (num20 != (sbyte) 3)
                      return;
                    GameScr.mabuPercent = msg.reader().readByte();
                    return;
                  default:
                    switch (command)
                    {
                      case 31:
                        int charId10 = msg.reader().readInt();
                        if (msg.reader().readByte() == (sbyte) 1)
                        {
                          short num21 = msg.reader().readShort();
                          sbyte fimg = -1;
                          int[] frameNew = (int[]) null;
                          short wimg = 0;
                          short himg = 0;
                          try
                          {
                            fimg = msg.reader().readByte();
                            if (fimg > (sbyte) 0)
                            {
                              sbyte length7 = msg.reader().readByte();
                              frameNew = new int[(int) length7];
                              for (int index7 = 0; index7 < (int) length7; ++index7)
                                frameNew[index7] = (int) msg.reader().readByte();
                              wimg = msg.reader().readShort();
                              himg = msg.reader().readShort();
                            }
                          }
                          catch (Exception ex)
                          {
                          }
                          if (charId10 == Char.myCharz().charID)
                          {
                            Char.myCharz().petFollow = new PetFollow();
                            Char.myCharz().petFollow.smallID = num21;
                            if (fimg <= (sbyte) 0)
                              return;
                            Char.myCharz().petFollow.SetImg((int) fimg, frameNew, (int) wimg, (int) himg);
                            return;
                          }
                          Char charInMap3 = GameScr.findCharInMap(charId10);
                          charInMap3.petFollow = new PetFollow();
                          charInMap3.petFollow.smallID = num21;
                          if (fimg <= (sbyte) 0)
                            return;
                          charInMap3.petFollow.SetImg((int) fimg, frameNew, (int) wimg, (int) himg);
                          return;
                        }
                        if (charId10 == Char.myCharz().charID)
                        {
                          Char.myCharz().petFollow.remove();
                          Char.myCharz().petFollow = (PetFollow) null;
                          return;
                        }
                        Char charInMap4 = GameScr.findCharInMap(charId10);
                        charInMap4.petFollow.remove();
                        charInMap4.petFollow = (PetFollow) null;
                        return;
                      case 42:
                        GameCanvas.endDlg();
                        LoginScr.isContinueToLogin = false;
                        Char.isLoadingMap = false;
                        sbyte haveName = msg.reader().readByte();
                        if (GameCanvas.registerScr == null)
                          GameCanvas.registerScr = new RegisterScreen(haveName);
                        GameCanvas.registerScr.switchToMe();
                        return;
                      case 93:
                        string chatVip = Res.changeString(msg.reader().readUTF());
                        GameScr.gI().chatVip(chatVip);
                        return;
                      case 100:
                        sbyte num22 = msg.reader().readByte();
                        sbyte index8 = msg.reader().readByte();
                        Item obj = (Item) null;
                        if (num22 == (sbyte) 0)
                          obj = Char.myCharz().arrItemBody[(int) index8];
                        if (num22 == (sbyte) 1)
                          obj = Char.myCharz().arrItemBag[(int) index8];
                        short id4 = msg.reader().readShort();
                        if (id4 == (short) -1)
                          return;
                        obj.template = ItemTemplates.get(id4);
                        obj.quantity = msg.reader().readInt();
                        obj.info = msg.reader().readUTF();
                        obj.content = msg.reader().readUTF();
                        sbyte length8 = msg.reader().readByte();
                        if (length8 == (sbyte) 0)
                          return;
                        obj.itemOption = new ItemOption[(int) length8];
                        for (int index9 = 0; index9 < obj.itemOption.Length; ++index9)
                        {
                          int optionTemplateId = (int) msg.reader().readUnsignedByte();
                          Res.outz("id o= " + (object) optionTemplateId);
                          int num23 = (int) msg.reader().readUnsignedShort();
                          if (optionTemplateId != -1)
                            obj.itemOption[index9] = new ItemOption(optionTemplateId, num23);
                        }
                        return;
                      case 101:
                        Res.outz("big boss--------------------------------------------------");
                        BigBoss bigBoss = Mob.getBigBoss();
                        if (bigBoss == null)
                          return;
                        sbyte type2 = msg.reader().readByte();
                        if (type2 == (sbyte) 0 || type2 == (sbyte) 1 || type2 == (sbyte) 2 || type2 == (sbyte) 4 || type2 == (sbyte) 3)
                        {
                          if (type2 == (sbyte) 3)
                          {
                            bigBoss.xTo = bigBoss.xFirst = (int) msg.reader().readShort();
                            bigBoss.yTo = bigBoss.yFirst = (int) msg.reader().readShort();
                            bigBoss.setFly();
                          }
                          else
                          {
                            sbyte length9 = msg.reader().readByte();
                            Res.outz("CHUONG nChar= " + (object) length9);
                            Char[] cAttack = new Char[(int) length9];
                            int[] dame = new int[(int) length9];
                            for (int index10 = 0; index10 < (int) length9; ++index10)
                            {
                              int charId11 = msg.reader().readInt();
                              Res.outz("char ID=" + (object) charId11);
                              cAttack[index10] = (Char) null;
                              cAttack[index10] = charId11 == Char.myCharz().charID ? Char.myCharz() : GameScr.findCharInMap(charId11);
                              dame[index10] = msg.reader().readInt();
                            }
                            bigBoss.setAttack(cAttack, dame, type2);
                          }
                        }
                        if (type2 == (sbyte) 5)
                        {
                          bigBoss.haftBody = true;
                          bigBoss.status = 2;
                        }
                        if (type2 == (sbyte) 6)
                        {
                          bigBoss.getDataB2();
                          bigBoss.x = (int) msg.reader().readShort();
                          bigBoss.y = (int) msg.reader().readShort();
                        }
                        if (type2 == (sbyte) 7)
                          bigBoss.setAttack((Char[]) null, (int[]) null, type2);
                        if (type2 == (sbyte) 8)
                        {
                          bigBoss.xTo = bigBoss.xFirst = (int) msg.reader().readShort();
                          bigBoss.yTo = bigBoss.yFirst = (int) msg.reader().readShort();
                          bigBoss.status = 2;
                        }
                        if (type2 != (sbyte) 9)
                          return;
                        bigBoss.x = bigBoss.y = bigBoss.xTo = bigBoss.yTo = bigBoss.xFirst = bigBoss.yFirst = -1000;
                        return;
                      case 102:
                        sbyte num24 = msg.reader().readByte();
                        if (num24 == (sbyte) 0 || num24 == (sbyte) 1 || num24 == (sbyte) 2 || num24 == (sbyte) 6)
                        {
                          BigBoss2 bigBoss2 = Mob.getBigBoss2();
                          if (bigBoss2 == null)
                            return;
                          if (num24 == (sbyte) 6)
                          {
                            bigBoss2.x = bigBoss2.y = bigBoss2.xTo = bigBoss2.yTo = bigBoss2.xFirst = bigBoss2.yFirst = -1000;
                            return;
                          }
                          sbyte length10 = msg.reader().readByte();
                          Char[] cAttack = new Char[(int) length10];
                          int[] dame = new int[(int) length10];
                          for (int index11 = 0; index11 < (int) length10; ++index11)
                          {
                            int charId12 = msg.reader().readInt();
                            cAttack[index11] = (Char) null;
                            cAttack[index11] = charId12 == Char.myCharz().charID ? Char.myCharz() : GameScr.findCharInMap(charId12);
                            dame[index11] = msg.reader().readInt();
                          }
                          bigBoss2.setAttack(cAttack, dame, num24);
                        }
                        if (num24 == (sbyte) 3 || num24 == (sbyte) 4 || num24 == (sbyte) 5 || num24 == (sbyte) 7)
                        {
                          BachTuoc bachTuoc = Mob.getBachTuoc();
                          if (bachTuoc == null)
                            return;
                          if (num24 == (sbyte) 7)
                          {
                            bachTuoc.x = bachTuoc.y = bachTuoc.xTo = bachTuoc.yTo = bachTuoc.xFirst = bachTuoc.yFirst = -1000;
                            return;
                          }
                          if (num24 == (sbyte) 3 || num24 == (sbyte) 4)
                          {
                            sbyte length11 = msg.reader().readByte();
                            Char[] cAttack = new Char[(int) length11];
                            int[] dame = new int[(int) length11];
                            for (int index12 = 0; index12 < (int) length11; ++index12)
                            {
                              int charId13 = msg.reader().readInt();
                              cAttack[index12] = (Char) null;
                              cAttack[index12] = charId13 == Char.myCharz().charID ? Char.myCharz() : GameScr.findCharInMap(charId13);
                              dame[index12] = msg.reader().readInt();
                            }
                            bachTuoc.setAttack(cAttack, dame, num24);
                          }
                          if (num24 == (sbyte) 5)
                          {
                            short xMoveTo = msg.reader().readShort();
                            bachTuoc.move(xMoveTo);
                          }
                        }
                        if (num24 <= (sbyte) 9 || num24 >= (sbyte) 30)
                          return;
                        Controller2.readActionBoss(msg, (int) num24);
                        return;
                      case 113:
                        int loop = (int) msg.reader().readByte();
                        int layer = (int) msg.reader().readByte();
                        int id5 = (int) msg.reader().readUnsignedByte();
                        short x2 = msg.reader().readShort();
                        short y2 = msg.reader().readShort();
                        short loopCount = msg.reader().readShort();
                        EffecMn.addEff(new Effect(id5, (int) x2, (int) y2, layer, loop, (int) loopCount));
                        return;
                      case 114:
                        try
                        {
                          msg.reader().readUTF();
                          mSystem.curINAPP = msg.reader().readByte();
                          mSystem.maxINAPP = msg.reader().readByte();
                          return;
                        }
                        catch (Exception ex)
                        {
                          return;
                        }
                      default:
                        return;
                    }
                }
            }
        }
      }
      catch (Exception ex)
      {
      }
    }

    private static void readLuckyRound(Message msg)
    {
      try
      {
        switch (msg.reader().readByte())
        {
          case 0:
            sbyte length1 = msg.reader().readByte();
            short[] idImage1 = new short[(int) length1];
            for (int index = 0; index < (int) length1; ++index)
              idImage1[index] = msg.reader().readShort();
            sbyte typePrice = msg.reader().readByte();
            int price = msg.reader().readInt();
            short idTicket = msg.reader().readShort();
            CrackBallScr.gI().SetCrackBallScr(idImage1, (byte) typePrice, price, idTicket);
            break;
          case 1:
            sbyte length2 = msg.reader().readByte();
            short[] idImage2 = new short[(int) length2];
            for (int index = 0; index < (int) length2; ++index)
              idImage2[index] = msg.reader().readShort();
            CrackBallScr.gI().DoneCrackBallScr(idImage2);
            break;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private static void readInfoRada(Message msg)
    {
      try
      {
        switch (msg.reader().readByte())
        {
          case 0:
            RadarScr.gI();
            MyVector list = new MyVector(string.Empty);
            short numMax = msg.reader().readShort();
            int num1 = 0;
            for (int index1 = 0; index1 < (int) numMax; ++index1)
            {
              Info_RadaScr o = new Info_RadaScr();
              int id = (int) msg.reader().readShort();
              int no = index1 + 1;
              int idIcon = (int) msg.reader().readShort();
              sbyte rank = msg.reader().readByte();
              sbyte amount = msg.reader().readByte();
              sbyte max_amount = msg.reader().readByte();
              short templateId = -1;
              Char charInfo = (Char) null;
              sbyte typeMonster = msg.reader().readByte();
              if (typeMonster == (sbyte) 0)
                templateId = msg.reader().readShort();
              else
                charInfo = Info_RadaScr.SetCharInfo((int) msg.reader().readShort(), (int) msg.reader().readShort(), (int) msg.reader().readShort(), (int) msg.reader().readShort());
              string name = msg.reader().readUTF();
              string info = msg.reader().readUTF();
              sbyte level = msg.reader().readByte();
              sbyte isUse = msg.reader().readByte();
              sbyte length = msg.reader().readByte();
              ItemOption[] itemOption = (ItemOption[]) null;
              if (length != (sbyte) 0)
              {
                itemOption = new ItemOption[(int) length];
                for (int index2 = 0; index2 < itemOption.Length; ++index2)
                {
                  int optionTemplateId = (int) msg.reader().readUnsignedByte();
                  int num2 = (int) msg.reader().readUnsignedShort();
                  sbyte num3 = msg.reader().readByte();
                  if (optionTemplateId != -1)
                  {
                    itemOption[index2] = new ItemOption(optionTemplateId, num2);
                    itemOption[index2].activeCard = num3;
                  }
                }
              }
              o.SetInfo(id, no, idIcon, rank, typeMonster, templateId, name, info, charInfo, itemOption);
              o.SetLevel(level);
              o.SetUse(isUse);
              o.SetAmount(amount, max_amount);
              list.addElement((object) o);
              if (level > (sbyte) 0)
                ++num1;
            }
            RadarScr.gI().SetRadarScr(list, num1, (int) numMax);
            RadarScr.gI().switchToMe();
            break;
          case 1:
            int id1 = (int) msg.reader().readShort();
            sbyte isUse1 = msg.reader().readByte();
            if (Info_RadaScr.GetInfo(RadarScr.list, id1) != null)
              Info_RadaScr.GetInfo(RadarScr.list, id1).SetUse(isUse1);
            RadarScr.SetListUse();
            break;
          case 2:
            int id2 = (int) msg.reader().readShort();
            sbyte level1 = msg.reader().readByte();
            int num4 = 0;
            for (int index = 0; index < RadarScr.list.size(); ++index)
            {
              Info_RadaScr infoRadaScr = (Info_RadaScr) RadarScr.list.elementAt(index);
              if (infoRadaScr != null)
              {
                if (infoRadaScr.id == id2)
                  infoRadaScr.SetLevel(level1);
                if (infoRadaScr.level > (sbyte) 0)
                  ++num4;
              }
            }
            RadarScr.SetNum(num4, RadarScr.list.size());
            if (Info_RadaScr.GetInfo(RadarScr.listUse, id2) == null)
              break;
            Info_RadaScr.GetInfo(RadarScr.listUse, id2).SetLevel(level1);
            break;
          case 3:
            int id3 = (int) msg.reader().readShort();
            sbyte amount1 = msg.reader().readByte();
            sbyte max_amount1 = msg.reader().readByte();
            if (Info_RadaScr.GetInfo(RadarScr.list, id3) != null)
              Info_RadaScr.GetInfo(RadarScr.list, id3).SetAmount(amount1, max_amount1);
            if (Info_RadaScr.GetInfo(RadarScr.listUse, id3) == null)
              break;
            Info_RadaScr.GetInfo(RadarScr.listUse, id3).SetAmount(amount1, max_amount1);
            break;
          case 4:
            int charId = msg.reader().readInt();
            short num5 = msg.reader().readShort();
            Char @char = charId != Char.myCharz().charID ? GameScr.findCharInMap(charId) : Char.myCharz();
            if (@char == null)
              break;
            @char.idAuraEff = num5;
            break;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private static void readInfoEffChar(Message msg)
    {
      try
      {
        sbyte num = msg.reader().readByte();
        int charId = msg.reader().readInt();
        Char c = charId != Char.myCharz().charID ? GameScr.findCharInMap(charId) : Char.myCharz();
        switch (num)
        {
          case 0:
            int id1 = (int) msg.reader().readShort();
            int layer = (int) msg.reader().readByte();
            int loop = (int) msg.reader().readByte();
            short loopCount = msg.reader().readShort();
            sbyte isStand = msg.reader().readByte();
            c?.addEffChar(new Effect(id1, c, layer, loop, (int) loopCount, isStand));
            break;
          case 1:
            int id2 = (int) msg.reader().readShort();
            c?.removeEffChar(0, id2);
            break;
          case 2:
            c?.removeEffChar(-1, 0);
            break;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private static void readActionBoss(Message msg, int actionBoss)
    {
      try
      {
        NewBoss newBoss = Mob.getNewBoss(msg.reader().readByte());
        if (newBoss == null)
          return;
        if (actionBoss == 10)
        {
          short xMoveTo = msg.reader().readShort();
          short yMoveTo = msg.reader().readShort();
          newBoss.move(xMoveTo, yMoveTo);
        }
        if (actionBoss >= 11 && actionBoss <= 20)
        {
          sbyte length = msg.reader().readByte();
          Char[] cAttack = new Char[(int) length];
          int[] dame = new int[(int) length];
          for (int index = 0; index < (int) length; ++index)
          {
            int charId = msg.reader().readInt();
            cAttack[index] = (Char) null;
            cAttack[index] = charId == Char.myCharz().charID ? Char.myCharz() : GameScr.findCharInMap(charId);
            dame[index] = msg.reader().readInt();
          }
          sbyte dir = msg.reader().readByte();
          newBoss.setAttack(cAttack, dame, (sbyte) (actionBoss - 10), dir);
        }
        if (actionBoss == 21)
        {
          newBoss.xTo = (int) msg.reader().readShort();
          newBoss.yTo = (int) msg.reader().readShort();
          newBoss.setFly();
        }
        if (actionBoss != 22)
          ;
        if (actionBoss != 23)
          return;
        newBoss.setDie();
      }
      catch (Exception ex)
      {
      }
    }
  }
}
