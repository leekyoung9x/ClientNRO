// Decompiled with JetBrains decompiler
// Type: Hint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;

public class Hint
{
  public static int x;
  public static int y;
  public static int type;
  public static int t;
  public static int xF;
  public static int yF;
  public static bool isShow;
  public static bool activeClick;
  public static bool isViewMap;
  public static bool isCloseMap;
  public static bool isPaint;
  public static bool isCamera;
  public static int trans;
  public static bool paintFlare;
  public static bool isPaintArrow;
  private int s = 2;

  public static bool isOnTask(int tastId, int index) => Char.myCharz().taskMaint != null && (int) Char.myCharz().taskMaint.taskId == tastId && Char.myCharz().taskMaint.index == index;

  public static bool isPaintz() => (!Hint.isOnTask(0, 3) || GameCanvas.panel.currentTabIndex != 0 || GameCanvas.panel.cmy >= 0 && GameCanvas.panel.cmy <= 30) && (!Hint.isOnTask(2, 0) || !GameCanvas.panel.isShow || GameCanvas.panel.currentTabIndex == 0);

  public static void clickNpc()
  {
    if (GameCanvas.panel.isShow)
      Hint.isPaint = false;
    if (GameScr.getNpcTask() == null)
      return;
    Hint.x = GameScr.getNpcTask().cx;
    Hint.y = GameScr.getNpcTask().cy;
    Hint.trans = 0;
    Hint.isCamera = true;
    Hint.type = !GameCanvas.isTouch ? 0 : 1;
  }

  public static void nextMap(int index)
  {
    if (GameCanvas.panel.isShow || PopUp.vPopups.size() - 1 < index)
      return;
    PopUp popUp = (PopUp) PopUp.vPopups.elementAt(index);
    Hint.x = popUp.cx + popUp.sayWidth / 2;
    Hint.y = popUp.cy + 30;
    Hint.isPaint = !popUp.isHide && popUp.isPaint;
    Hint.type = 0;
    Hint.isCamera = true;
    Hint.trans = 0;
    if (GameCanvas.isTouch)
      return;
    Hint.isPaint = false;
  }

  public static void clickMob()
  {
    Hint.type = 1;
    if (GameCanvas.panel.isShow)
      Hint.isPaint = false;
    bool flag = false;
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      if (((Mob) GameScr.vMob.elementAt(index)).isHintFocus)
      {
        flag = true;
        break;
      }
    }
    for (int index = 0; index < GameScr.vMob.size(); ++index)
    {
      Mob mob = (Mob) GameScr.vMob.elementAt(index);
      if (mob.isHintFocus)
      {
        Hint.x = mob.x;
        Hint.y = mob.y + 5;
        Hint.isCamera = true;
        if (mob.status != 0)
          break;
        mob.isHintFocus = false;
        break;
      }
      if (!flag)
      {
        if (mob.status == 0)
        {
          mob.isHintFocus = false;
        }
        else
        {
          mob.isHintFocus = true;
          break;
        }
      }
    }
  }

  public static bool isHaveItem()
  {
    if (GameCanvas.panel.isShow)
      Hint.isPaint = false;
    for (int index = 0; index < GameScr.vItemMap.size(); ++index)
    {
      ItemMap itemMap = (ItemMap) GameScr.vItemMap.elementAt(index);
      if (itemMap.playerId == Char.myCharz().charID && itemMap.template.id == (short) 73)
      {
        Hint.type = 1;
        Hint.x = itemMap.x;
        Hint.y = itemMap.y + 5;
        Hint.isCamera = true;
        return true;
      }
    }
    return false;
  }

  public static void paintArrowPointToHint(mGraphics g)
  {
    try
    {
      if (!Hint.isPaintArrow || Hint.x > GameScr.cmx && Hint.x < GameScr.cmx + GameScr.gW && Hint.y > GameScr.cmy && Hint.y < GameScr.cmy + GameScr.gH || GameCanvas.gameTick % 10 < 5 || ChatPopup.currChatPopup != null || ChatPopup.serverChatPopUp != null || GameCanvas.panel.isShow || !Hint.isCamera)
        return;
      int i1 = Hint.x - Char.myCharz().cx;
      int i2 = Hint.y - Char.myCharz().cy;
      int x = 0;
      int y = 0;
      int num = 0;
      if (i1 > 0 && i2 >= 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = GameScr.gW - 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 0;
        }
        else
        {
          x = GameScr.gW / 2;
          y = GameScr.gH - 10;
          num = 5;
        }
      }
      else if (i1 >= 0 && i2 < 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = GameScr.gW - 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 0;
        }
        else
        {
          x = GameScr.gW / 2;
          y = 10;
          num = 6;
        }
      }
      if (i1 < 0 && i2 >= 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 3;
        }
        else
        {
          x = GameScr.gW / 2;
          y = GameScr.gH - 10;
          num = 5;
        }
      }
      else if (i1 <= 0 && i2 < 0)
      {
        if (Res.abs(i1) >= Res.abs(i2))
        {
          x = 10;
          y = GameScr.gH / 2 + 30;
          if (GameCanvas.isTouch)
            y = GameScr.gH / 2 + 10;
          num = 3;
        }
        else
        {
          x = GameScr.gW / 2;
          y = 10;
          num = 6;
        }
      }
      GameScr.resetTranslate(g);
      g.drawRegion(GameScr.arrow, 0, 0, 13, 16, num, x, y, StaticObj.VCENTER_HCENTER);
    }
    catch (Exception ex)
    {
    }
  }

  public static void paint(mGraphics g)
  {
    if (ChatPopup.serverChatPopUp != null || Char.myCharz().isUsePlane || Char.myCharz().isTeleport)
      return;
    Hint.paintArrowPointToHint(g);
    if (GameCanvas.menu.tDelay != 0 || !Hint.isPaint || ChatPopup.scr != null || Char.ischangingMap || GameCanvas.currentScreen != GameScr.gI() || GameCanvas.panel.isShow && GameCanvas.panel.cmx != 0)
      return;
    if (Hint.isCamera)
      g.translate(-GameScr.cmx, -GameScr.cmy);
    if (Hint.trans == 0)
      g.drawImage(Panel.imgBantay, Hint.x - 15, Hint.y, 0);
    if (Hint.trans == 1)
      g.drawRegion(Panel.imgBantay, 0, 0, 14, 16, 2, Hint.x + 15, Hint.y, StaticObj.TOP_RIGHT);
    if (!Hint.paintFlare)
      return;
    g.drawImage(ItemMap.imageFlare, Hint.x, Hint.y, 3);
  }

  public static void hint()
  {
    if (Char.myCharz().taskMaint != null && GameCanvas.currentScreen == GameScr.instance)
    {
      int taskId = (int) Char.myCharz().taskMaint.taskId;
      int index1 = Char.myCharz().taskMaint.index;
      Hint.isCamera = false;
      Hint.trans = 0;
      Hint.type = 0;
      Hint.isPaint = true;
      Hint.isPaintArrow = true;
      if (GameCanvas.menu.showMenu && taskId > 0)
        Hint.isPaint = false;
      switch (taskId)
      {
        case 0:
          if (ChatPopup.currChatPopup != null || Char.myCharz().statusMe == 14)
          {
            Hint.x = GameCanvas.w / 2;
            Hint.y = GameCanvas.h - 15;
            break;
          }
          if (index1 == 0 && TileMap.vGo.size() != 0)
          {
            Hint.x = (int) ((Waypoint) TileMap.vGo.elementAt(0)).minX - 100;
            Hint.y = (int) ((Waypoint) TileMap.vGo.elementAt(0)).minY + 40;
            Hint.isCamera = true;
          }
          if (index1 == 1)
            Hint.nextMap(0);
          if (index1 == 2)
            Hint.clickNpc();
          if (index1 == 3)
          {
            if (!GameCanvas.panel.isShow)
              Hint.clickNpc();
            else if (GameCanvas.panel.currentTabIndex == 0)
            {
              if (GameCanvas.panel.cp == null)
              {
                Hint.x = GameCanvas.panel.xScroll + GameCanvas.panel.wScroll / 2;
                Hint.y = GameCanvas.panel.yScroll + 20;
              }
              else if (GameCanvas.menu.tDelay != 0)
              {
                Hint.x = GameCanvas.panel.xScroll + 25;
                Hint.y = GameCanvas.panel.yScroll + 60;
              }
            }
            else if (GameCanvas.panel.currentTabIndex == 1)
            {
              Hint.x = GameCanvas.panel.startTabPos + 10;
              Hint.y = 65;
            }
          }
          if (index1 == 4)
          {
            if (GameCanvas.panel.isShow)
            {
              Hint.x = GameCanvas.panel.cmdClose.x + 5;
              Hint.y = GameCanvas.panel.cmdClose.y + 5;
            }
            else if (GameCanvas.menu.showMenu)
            {
              Hint.x = GameCanvas.w / 2;
              Hint.y = GameCanvas.h - 20;
            }
            else
              Hint.clickNpc();
          }
          if (index1 != 5)
            break;
          Hint.clickNpc();
          break;
        case 1:
          if (ChatPopup.currChatPopup != null || Char.myCharz().statusMe == 14)
          {
            Hint.x = GameCanvas.w / 2;
            Hint.y = GameCanvas.h - 15;
            break;
          }
          if (index1 == 0)
          {
            if (TileMap.isOfflineMap())
              Hint.nextMap(0);
            else
              Hint.clickMob();
          }
          if (index1 != 1)
            break;
          if (!TileMap.isOfflineMap())
          {
            Hint.nextMap(1);
            break;
          }
          Hint.clickNpc();
          break;
        case 2:
          if (ChatPopup.currChatPopup != null || Char.myCharz().statusMe == 14)
          {
            Hint.x = GameCanvas.w / 2;
            Hint.y = GameCanvas.h - 15;
            break;
          }
          if (index1 == 0)
          {
            if (!TileMap.isOfflineMap())
              Hint.isViewMap = true;
            if (!GameCanvas.panel.isShow)
            {
              if (!Hint.isViewMap)
              {
                Hint.x = GameScr.gI().cmdMenu.x;
                Hint.y = GameScr.gI().cmdMenu.y + 13;
                Hint.trans = 1;
              }
              else
              {
                if (GameScr.getTaskMapId() == TileMap.mapID)
                {
                  if (!Hint.isHaveItem())
                    Hint.clickMob();
                }
                else
                  Hint.nextMap(0);
                if (Hint.isViewMap)
                  Hint.isCloseMap = true;
              }
            }
            else if (!Hint.isViewMap)
            {
              if (GameCanvas.panel.currentTabIndex == 0)
              {
                int num = GameCanvas.h <= 300 ? 10 : 15;
                Hint.x = GameCanvas.panel.xScroll + GameCanvas.panel.wScroll / 2;
                Hint.y = GameCanvas.panel.yScroll + GameCanvas.panel.hScroll - num;
              }
              else
              {
                Hint.x = GameCanvas.panel.startTabPos + 10;
                Hint.y = 65;
              }
            }
            else if (!Hint.isCloseMap)
            {
              Hint.x = GameCanvas.panel.cmdClose.x + 5;
              Hint.y = GameCanvas.panel.cmdClose.y + 5;
            }
            else
              Hint.isPaint = false;
            if (Char.myCharz().cMP <= 0)
            {
              Hint.x = GameScr.xHP + 5;
              Hint.y = GameScr.yHP + 13;
              Hint.isCamera = false;
            }
          }
          if (index1 != 1)
            break;
          Hint.isPaint = false;
          Hint.isPaintArrow = false;
          break;
        default:
          if (Char.myCharz().taskMaint.taskId == (short) 9 && Char.myCharz().taskMaint.index == 2)
          {
            for (int index2 = 0; index2 < PopUp.vPopups.size(); ++index2)
            {
              PopUp popUp = (PopUp) PopUp.vPopups.elementAt(index2);
              if (popUp.cy <= 24)
              {
                Hint.x = popUp.cx + popUp.sayWidth / 2;
                Hint.y = popUp.cy + 30;
                Hint.isCamera = true;
                Hint.isPaint = false;
                Hint.isPaintArrow = true;
                return;
              }
            }
          }
          Hint.isPaint = false;
          Hint.isPaintArrow = false;
          break;
      }
    }
    else
    {
      Hint.isPaint = false;
      Hint.isPaintArrow = false;
    }
  }

  public static void update()
  {
    Hint.hint();
    int num = Hint.trans != 0 ? -2 : 2;
    if (!Hint.activeClick)
    {
      Hint.paintFlare = false;
      ++Hint.t;
      if (Hint.t != 50)
        return;
      Hint.t = 0;
      Hint.activeClick = true;
    }
    else
    {
      ++Hint.t;
      if (Hint.type == 0)
      {
        if (Hint.t == 2)
        {
          Hint.x += 2 * num;
          Hint.y -= 4;
          Hint.paintFlare = true;
        }
        if (Hint.t == 4)
        {
          Hint.x -= 2 * num;
          Hint.y += 4;
          Hint.activeClick = false;
          Hint.paintFlare = false;
          Hint.t = 0;
        }
        if (Hint.t > 4)
          Hint.activeClick = false;
      }
      if (Hint.type != 1)
        return;
      if (Hint.t == 2)
      {
        if (GameCanvas.isTouch)
          GameScr.startFlyText(mResources.press_twice, Hint.x, Hint.y + 10, 0, 20, mFont.MISS_ME);
        Hint.paintFlare = true;
        Hint.x += 2 * num;
        Hint.y -= 4;
      }
      if (Hint.t == 4)
      {
        Hint.paintFlare = false;
        Hint.x -= num;
        Hint.y += 2;
      }
      if (Hint.t == 6)
      {
        Hint.paintFlare = true;
        Hint.x += num;
        Hint.y -= 2;
      }
      if (Hint.t == 8)
      {
        Hint.paintFlare = false;
        Hint.x -= num;
        Hint.y += 2;
      }
      if (Hint.t != 10)
        return;
      Hint.x -= num;
      Hint.y += 2;
      Hint.activeClick = false;
      Hint.t = 0;
    }
  }
}
