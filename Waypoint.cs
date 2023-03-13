// Decompiled with JetBrains decompiler
// Type: Waypoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class Waypoint : IActionListener
{
  public short minX;
  public short minY;
  public short maxX;
  public short maxY;
  public bool isEnter;
  public bool isOffline;
  public PopUp popup;

  public Waypoint(
    short minX,
    short minY,
    short maxX,
    short maxY,
    bool isEnter,
    bool isOffline,
    string name)
  {
    this.minX = minX;
    this.minY = minY;
    this.maxX = maxX;
    this.maxY = maxY;
    name = Res.changeString(name);
    this.isEnter = isEnter;
    this.isOffline = isOffline;
    if ((TileMap.mapID == 21 || TileMap.mapID == 22 || TileMap.mapID == 23) && this.minX >= (short) 0 && this.minX <= (short) 24 || (TileMap.mapID == 0 && Char.myCharz().cgender != 0 || TileMap.mapID == 7 && Char.myCharz().cgender != 1 || TileMap.mapID == 14 && Char.myCharz().cgender != 2) && isOffline)
      return;
    if (TileMap.isInAirMap() || TileMap.mapID == 47)
    {
      if (minY > (short) 150 && TileMap.isInAirMap())
        return;
      this.popup = new PopUp(name, (int) minX + ((int) maxX - (int) minX) / 2, (int) maxY - (minX <= (short) 100 ? 48 : 24));
      this.popup.command = new Command((string) null, (IActionListener) this, 1, (object) this);
      this.popup.isWayPoint = true;
      this.popup.isPaint = false;
      PopUp.addPopUp(this.popup);
      TileMap.vGo.addElement((object) this);
    }
    else
    {
      if (!isEnter && !isOffline)
      {
        this.popup = new PopUp(name, (int) minX, (int) minY - 24);
        this.popup.command = new Command((string) null, (IActionListener) this, 1, (object) this);
        this.popup.isWayPoint = true;
        this.popup.isPaint = false;
        PopUp.addPopUp(this.popup);
      }
      else
      {
        if (TileMap.isTrainingMap())
        {
          this.popup = new PopUp(name, (int) minX, (int) minY - 16);
        }
        else
        {
          int x = (int) minX + ((int) maxX - (int) minX) / 2;
          this.popup = new PopUp(name, x, (int) minY - (minY == (short) 0 ? -32 : 16));
        }
        this.popup.command = new Command((string) null, (IActionListener) this, 2, (object) this);
        this.popup.isWayPoint = true;
        this.popup.isPaint = false;
        PopUp.addPopUp(this.popup);
      }
      TileMap.vGo.addElement((object) this);
    }
  }

  public void perform(int idAction, object p)
  {
    switch (idAction)
    {
      case 1:
        int xEnd1 = ((int) this.minX + (int) this.maxX) / 2;
        int yEnd = (int) this.maxY;
        if ((int) this.maxY > (int) this.minY + 24)
          yEnd = ((int) this.minY + (int) this.maxY) / 2;
        GameScr.gI().auto = 0;
        Char.myCharz().currentMovePoint = new MovePoint(xEnd1, yEnd);
        Char.myCharz().cdir = Char.myCharz().cx - Char.myCharz().currentMovePoint.xEnd <= 0 ? 1 : -1;
        Service.gI().charMove();
        break;
      case 2:
        GameScr.gI().auto = 0;
        if (Char.myCharz().isInEnterOfflinePoint() != null)
        {
          Service.gI().charMove();
          InfoDlg.showWait();
          Service.gI().getMapOffline();
          Char.ischangingMap = true;
          break;
        }
        if (Char.myCharz().isInEnterOnlinePoint() != null)
        {
          Service.gI().charMove();
          Service.gI().requestChangeMap();
          Char.isLockKey = true;
          Char.ischangingMap = true;
          GameCanvas.clearKeyHold();
          GameCanvas.clearKeyPressed();
          InfoDlg.showWait();
          break;
        }
        int xEnd2 = ((int) this.minX + (int) this.maxX) / 2;
        int maxY = (int) this.maxY;
        Char.myCharz().currentMovePoint = new MovePoint(xEnd2, maxY);
        Char.myCharz().cdir = Char.myCharz().cx - Char.myCharz().currentMovePoint.xEnd <= 0 ? 1 : -1;
        Char.myCharz().endMovePointCommand = new Command((string) null, (IActionListener) this, 2, (object) null);
        break;
    }
  }
}
