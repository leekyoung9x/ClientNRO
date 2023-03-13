// Decompiled with JetBrains decompiler
// Type: ItemMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

public class ItemMap : IMapObject
{
  public int x;
  public int y;
  public int xEnd;
  public int yEnd;
  public int f;
  public int vx;
  public int vy;
  public int playerId;
  public int itemMapID;
  public int IdCharMove;
  public ItemTemplate template;
  public sbyte status;
  public bool isHintFocus;
  public int rO;
  public int xO;
  public int yO;
  public int angle;
  public int iAngle;
  public int iDot;
  public int[] xArg;
  public int[] yArg;
  public int[] xDot;
  public int[] yDot;
  public int count;
  public int countAura;
  public static Image imageFlare = GameCanvas.loadImage("/mainImage/myTexture2dflare.png");
  public static Image imageAuraItem1 = GameCanvas.loadImage("/mainImage/myTexture2ditemaura1.png");
  public static Image imageAuraItem2 = GameCanvas.loadImage("/mainImage/myTexture2ditemaura2.png");
  public static Image imageAuraItem3 = GameCanvas.loadImage("/mainImage/myTexture2ditemaura3.png");

  public ItemMap(short itemMapID, short itemTemplateID, int x, int y, int xEnd, int yEnd)
  {
    this.itemMapID = (int) itemMapID;
    this.template = ItemTemplates.get(itemTemplateID);
    this.x = xEnd;
    this.y = y;
    this.xEnd = xEnd;
    this.yEnd = yEnd;
    this.vx = xEnd - x >> 2;
    this.vy = 5;
    Res.outz("playerid=  " + (object) this.playerId + " myid= " + (object) Char.myCharz().charID);
  }

  public ItemMap(int playerId, short itemMapID, short itemTemplateID, int x, int y, short r)
  {
    Res.outz("item map item= " + (object) itemMapID + " template= " + (object) itemTemplateID + " x= " + (object) x + " y= " + (object) y);
    this.itemMapID = (int) itemMapID;
    this.template = ItemTemplates.get(itemTemplateID);
    Res.outz("playerid=  " + (object) playerId + " myid= " + (object) Char.myCharz().charID);
    this.x = this.xEnd = x;
    this.y = this.yEnd = y;
    this.status = (sbyte) 1;
    this.playerId = playerId;
    if (!this.isAuraItem())
      return;
    this.rO = (int) r;
    this.setAuraItem();
  }

  public void setPoint(int xEnd, int yEnd)
  {
    this.xEnd = xEnd;
    this.yEnd = yEnd;
    this.vx = xEnd - this.x >> 2;
    this.vy = yEnd - this.y >> 2;
    this.status = (sbyte) 2;
  }

  public void update()
  {
    if (this.status == (sbyte) 2 && this.x == this.xEnd && this.y == this.yEnd)
    {
      GameScr.vItemMap.removeElement((object) this);
      if (Char.myCharz().itemFocus == null || !Char.myCharz().itemFocus.Equals((object) this))
        return;
      Char.myCharz().itemFocus = (ItemMap) null;
    }
    else
    {
      if (this.status > (sbyte) 0)
      {
        if (this.vx == 0)
          this.x = this.xEnd;
        if (this.vy == 0)
          this.y = this.yEnd;
        if (this.x != this.xEnd)
        {
          this.x += this.vx;
          if (this.vx > 0 && this.x > this.xEnd || this.vx < 0 && this.x < this.xEnd)
            this.x = this.xEnd;
        }
        if (this.y != this.yEnd)
        {
          this.y += this.vy;
          if (this.vy > 0 && this.y > this.yEnd || this.vy < 0 && this.y < this.yEnd)
            this.y = this.yEnd;
        }
      }
      else
      {
        this.status -= (sbyte) 4;
        if (this.status < (sbyte) -12)
        {
          this.y -= 12;
          this.status = (sbyte) 1;
        }
      }
      if (!this.isAuraItem())
        return;
      this.updateAuraItemEff();
    }
  }

  public void paint(mGraphics g)
  {
    if (this.isAuraItem())
    {
      g.drawImage(TileMap.bong, this.x + 3, this.y, mGraphics.VCENTER | mGraphics.HCENTER);
      if (this.status <= (sbyte) 0)
      {
        if (this.countAura < 10)
          g.drawImage(ItemMap.imageAuraItem1, this.x, this.y + (int) this.status + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
        else
          g.drawImage(ItemMap.imageAuraItem2, this.x, this.y + (int) this.status + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
      }
      else if (this.countAura < 10)
        g.drawImage(ItemMap.imageAuraItem1, this.x, this.y + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
      else
        g.drawImage(ItemMap.imageAuraItem2, this.x, this.y + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
    }
    else
    {
      if (this.isAuraItem())
        return;
      if (GameCanvas.gameTick % 4 == 0)
        g.drawImage(ItemMap.imageFlare, this.x, this.y + (int) this.status + 13, mGraphics.BOTTOM | mGraphics.HCENTER);
      if (this.status <= (sbyte) 0)
        SmallImage.drawSmallImage(g, (int) this.template.iconID, this.x, this.y + (int) this.status + 3, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
      else
        SmallImage.drawSmallImage(g, (int) this.template.iconID, this.x, this.y + 3, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
      if (Char.myCharz().itemFocus == null || !Char.myCharz().itemFocus.Equals((object) this) || this.status == (sbyte) 2)
        return;
      g.drawRegion(Mob.imgHP, 0, 24, 9, 6, 0, this.x, this.y - 17, 3);
    }
  }

  private bool isAuraItem() => this.template.type == (sbyte) 22;

  private void setAuraItem()
  {
    this.xO = this.x;
    this.yO = this.y;
    this.iDot = 120;
    this.angle = 0;
    if (GameCanvas.lowGraphic)
      return;
    this.iAngle = 360 / this.iDot;
    this.xArg = new int[this.iDot];
    this.yArg = new int[this.iDot];
    this.xDot = new int[this.iDot];
    this.yDot = new int[this.iDot];
    this.setDotPosition();
  }

  private void updateAuraItemEff()
  {
    ++this.count;
    ++this.countAura;
    if (this.countAura >= 40)
      this.countAura = 0;
    if (this.count >= this.iDot)
      this.count = 0;
    if (this.count % 10 != 0 || GameCanvas.lowGraphic)
      return;
    ServerEffect.addServerEffect(114, this.x - 5, this.y - 30, 1);
  }

  public void paintAuraItemEff(mGraphics g)
  {
    if (GameCanvas.lowGraphic || !this.isAuraItem())
      return;
    for (int index = 0; index < this.yArg.Length; ++index)
    {
      if (this.count == index)
      {
        if (this.countAura <= 20)
          g.drawImage(ItemMap.imageAuraItem3, this.xDot[index], this.yDot[index] + 3, mGraphics.BOTTOM | mGraphics.HCENTER);
        else
          SmallImage.drawSmallImage(g, (int) this.template.iconID, this.xDot[index], this.yDot[index] + 3, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
      }
    }
  }

  private void setDotPosition()
  {
    if (GameCanvas.lowGraphic)
      return;
    for (int index = 0; index < this.yArg.Length; ++index)
    {
      this.yArg[index] = Res.abs(this.rO * Res.sin(this.angle) / 1024);
      this.xArg[index] = Res.abs(this.rO * Res.cos(this.angle) / 1024);
      if (this.angle < 90)
      {
        this.xDot[index] = this.xO + this.xArg[index];
        this.yDot[index] = this.yO - this.yArg[index];
      }
      else if (this.angle >= 90 && this.angle < 180)
      {
        this.xDot[index] = this.xO - this.xArg[index];
        this.yDot[index] = this.yO - this.yArg[index];
      }
      else if (this.angle >= 180 && this.angle < 270)
      {
        this.xDot[index] = this.xO - this.xArg[index];
        this.yDot[index] = this.yO + this.yArg[index];
      }
      else
      {
        this.xDot[index] = this.xO + this.xArg[index];
        this.yDot[index] = this.yO + this.yArg[index];
      }
      this.angle += this.iAngle;
    }
  }

  public int getX() => this.x;

  public int getY() => this.y;

  public int getH() => 20;

  public int getW() => 20;

  public void stopMoving()
  {
  }

  public bool isInvisible() => false;
}
